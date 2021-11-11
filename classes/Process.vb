Public Class Process
    ' 프로세스 정의
    ' ---
    ' 도착시간, 우선순위, 실행시간은 CPU의 자원을 우선적으로 할당받기 위해
    ' 준비 큐 내부의 각 프로세스들을 정렬하는데 사용될 수 있다.

#Region "Public"
    Public Enum PROCESS_STATE '프로세스 상태
        ' 실제 프로세스의 상태에는 추가적으로 I/O 작업과 같은 처리를 위한 중지(BLOCKED) 상태가 존재하며, 
        ' 실행 상태에서 I/O 작업 발생 시 중단 상태로 전이되지만, 이는 단순화하기 위해 생략하며, 
        ' 선점형 스케줄링에서 프로세스 간 선점을 위한 문맥교환이 발생할 경우 강제로 실행 상태에서 준비 상태로 전이한다.
        ' ---
        ' https://en.wikipedia.org/wiki/Process_state
        ' https://docs.oracle.com/cd/E19683-01/816-5042/psched-16/index.html

        READY '준비 상태
        RUNNING '실행 상태
        TERMINATED '종료 상태
    End Enum
    Public Shared _strProcessState As String() = {
       "준비 상태",
       "실행 상태",
       "종료 상태"
    } '프로세스 상태 문자열
    ''' <summary>
    ''' 프로세스 인스턴스 초기화
    ''' </summary>
    Public Sub New()
        Me._name = String.Empty
        Me._burstTime = 0

        Me._priorty = 0
        Me._waitingTime = 0

        Me._processState = PROCESS_STATE.READY
        Me._isSelfProcessJobResultAlreadyOutputed = False
    End Sub
    ''' <summary>
    ''' 초기화 작업 수행
    ''' </summary>
    ''' <param name="srcName">이름</param>
    ''' <param name="srcBurstTime">실행시간</param>
    ''' <param name="srcArrivalTime">도착시간 (Optional)</param>
    ''' <param name="srcPriority">우선순위 (Optional)</param>
    Public Sub Init(ByVal srcName As String, ByVal srcBurstTime As Short,
                    Optional ByVal srcArrivalTime As Short = 0, Optional ByVal srcPriority As Short = 0)
        If String.IsNullOrEmpty(srcName) Then
            Throw New Exception("Process - Init Exception : not entered Process Name")
        Else
            Me._name = srcName
        End If

        If srcBurstTime <= 0 Then
            Throw New Exception("Process - Init Exception : burst time cannot be equal to or less than 0")
        Else
            Me._burstTime = srcBurstTime
        End If

        If srcArrivalTime < 0 Then
            Throw New Exception("Process - Init Exception : arrival time cannot be less than 0")
        Else
            Me._arrivalTime = srcArrivalTime
        End If

        If srcPriority < 0 Then
            Throw New Exception("Process - Init Exception : priority cannot be less than 0")
        Else
            Me._priorty = srcPriority
        End If

        Me._waitingTime = 0
        Me._processState = PROCESS_STATE.READY

        Me._isSelfProcessJobResultAlreadyOutputed = False
    End Sub
    ''' <summary>
    ''' 프로세스가 CPU의 자원을 할당받은 규정 시간량만큼 자신의 작업 수행 (프로세스 상태 전이 발생)
    ''' </summary>
    ''' <param name="srcCurrentSimTime">시뮬레이션 현재시간 (누적 CPU 유휴시간 + 누적 프로세스 실행시간)</param>
    ''' <param name="srcTimeQuantum">CPU의 자원을 할당받은 규정 시간량</param>
    ''' <param name="isContinuousJob">연속 된 동일 프로세스의 작업 여부</param>
    ''' <param name="firstExecutedSimTime">연속 된 프로세스의 작업을 위한 프로세스의 최초 실행 시점의 시뮬레이션 진행시간</param>
    ''' <returns>자신이 작업을 수행 한 시간</returns>
    Public Function DoSelfProcessJob(ByVal srcCurrentSimTime As UInteger, ByVal srcTimeQuantum As Short,
                                     Optional ByVal isContinuousJob As Boolean = False, Optional ByVal firstExecutedSimTime As UInteger = 0) As Short
        Dim timeQuantum As Short = 0 '규정 시간량
        Dim oldProcessState As PROCESS_STATE = Me._processState '이전 프로세스 상태

        Select Case oldProcessState '이전 프로세스 상태에 따라
            Case PROCESS_STATE.READY '준비 상태일 시 실행 상태로 전이
                Me._processState = PROCESS_STATE.RUNNING

            Case PROCESS_STATE.RUNNING '실행 상태일 시
                'do nothing

            Case PROCESS_STATE.TERMINATED '이미 종료 상태일 경우
                Throw New Exception("Process - DoSelfProcessJob Exception : already terminated")
        End Select

        If Not oldProcessState.Equals(Me._processState) Then '이전 프로세스 상태에서 변동이 있으면
            ResultManager.UpdateResult(ResultManager.UPDATE_MODE.APPEND, "※ 상태 전이 발생 : " + Me._name + "이(가) " + _strProcessState(oldProcessState) + "에서 " +
                                       _strProcessState(Me._processState) + "(으)로 전이")

            oldProcessState = Me._processState '이전 프로세스 상태 갱신 (종료 상태 전이 시 출력 위함)
        End If

        If Me._burstTime < srcTimeQuantum Then '규정 시간량보다 일찍 작업이 끝날 경우 남은 실행시간만큼만 수행하여야 함
            timeQuantum = Me._burstTime
        Else '규정 시간량만큼 수행하여야 함
            timeQuantum = srcTimeQuantum
        End If

        Me._burstTime -= timeQuantum '자신의 작업 수행

        If Not Me._isSelfProcessJobResultAlreadyOutputed Then '프로세스 자신의 처리 결과가 아직 출력되지 않았을 경우
            ResultManager.UpdateResult(ResultManager.UPDATE_MODE.APPEND, String.Empty) '이전 출력 결과를 보존하며, OVERWRITE 모드로 출력 위해 빈 줄 추가
            Me._isSelfProcessJobResultAlreadyOutputed = True
        End If

        If isContinuousJob Then '연속 된 동일 프로세스의 작업일 경우
            ResultManager.UpdateResult(ResultManager.UPDATE_MODE.OVERWRITE, "현재 진행시간 (" + (srcCurrentSimTime + timeQuantum).ToString + ") : " +
                                  Me._name + "이(가) " + firstExecutedSimTime.ToString + "에서 " + (srcCurrentSimTime + timeQuantum).ToString + "까지 작업 수행 (남은 실행시간 : " + Me._burstTime.ToString + ")")
        Else '연속 된 동일 프로세스의 작업이 아닐 경우
            ResultManager.UpdateResult(ResultManager.UPDATE_MODE.OVERWRITE, "현재 진행시간 (" + (srcCurrentSimTime + timeQuantum).ToString + ") : " +
                                  Me._name + "이(가) " + srcCurrentSimTime.ToString + "에서 " + (srcCurrentSimTime + timeQuantum).ToString + "까지 작업 수행 (남은 실행시간 : " + Me._burstTime.ToString + ")")
        End If

        If Me._burstTime = 0 Then '자신의 모든 작업 완료 시 종료 상태로 전이
            Me._processState = PROCESS_STATE.TERMINATED
            ResultManager.UpdateResult(ResultManager.UPDATE_MODE.APPEND, "※ 상태 전이 발생 : " + Me._name + "이(가) " + _strProcessState(oldProcessState) + "에서 " +
                               _strProcessState(Me._processState) + "(으)로 전이")
        End If

        Return timeQuantum '자신이 수행 한 시간 반환
    End Function
    ''' <summary>
    ''' 자신의 모든 정보 출력
    ''' </summary>
    Public Sub DebugProcessInfo()
        Debug.WriteLine("--- Debug Info ---")
        Debug.WriteLine("프로세스 명 : " + Me._name)
        Debug.WriteLine("도착시간 : " + Me._arrivalTime.ToString)
        Debug.WriteLine("실행시간 : " + Me._burstTime.ToString)
        Debug.WriteLine("우선순위 : " + Me._priorty.ToString)
        Debug.WriteLine("대기시간 : " + Me._waitingTime.ToString)
        Debug.WriteLine("상태 : " + _strProcessState(Me._processState))
        Debug.WriteLine("------------------")
    End Sub
    ''' <summary>
    ''' 자신의 프로세스 이름 반환
    ''' </summary>
    ''' <returns>프로세스 이름</returns>
    Public Function GetName() As String
        Return Me._name
    End Function
    ''' <summary>
    ''' 자신의 도착시간 반환
    ''' </summary>
    ''' <returns>도착시간</returns>
    Public Function GetArrivalTime() As Short
        Return Me._arrivalTime
    End Function
    ''' <summary>
    ''' 자신의 실행시간 반환
    ''' </summary>
    ''' <returns>실행시간</returns>
    Public Function GetBurstTime() As Short
        Return Me._burstTime
    End Function
    ''' <summary>
    ''' 자신의 우선순위 반환
    ''' </summary>
    ''' <returns>우선순위</returns>
    Public Function GetPriority() As Single
        Return Me._priorty
    End Function
    ''' <summary>
    ''' 자신의 대기시간 반환
    ''' </summary>
    ''' <returns>대기시간</returns>
    Public Function GetWaitingTime() As Short
        Return Me._waitingTime
    End Function
    ''' <summary>
    ''' 자신의 현재 프로세스 상태 반환
    ''' </summary>
    ''' <returns></returns>
    Public Function GetProcessState() As PROCESS_STATE
        Return Me._processState
    End Function
    ''' <summary>
    ''' 자신의 우선순위 설정
    ''' </summary>
    Public Sub SetPriority(srcPriority As Single)
        If srcPriority < 0 Then
            Throw New Exception("Process - SetPriority Exception : out of range")
        End If

        Me._priorty = srcPriority
    End Sub
    ''' <summary>
    ''' 자신의 대기시간 설정
    ''' </summary>
    ''' <param name="srcWaitingTime">대기시간</param>
    Public Sub SetWaitingTime(srcWaitingTime As Short)
        If srcWaitingTime < 0 Then
            Throw New Exception("Process - SetWaitingTime Exception : out of range")
        End If

        Me._waitingTime = srcWaitingTime
    End Sub
    ''' <summary>
    ''' 강제 프로세스 상태 전이
    ''' </summary>
    ''' <param name="srcProcessState">강제로 전이 될 프로세스 상태</param>
    Public Sub ForceTransitionProcessState(ByVal srcProcessState As PROCESS_STATE)
        Dim oldProcessState As PROCESS_STATE = Me._processState '이전 프로세스 상태
        Me._processState = srcProcessState

        If Not oldProcessState.Equals(Me._processState) Then '이전 프로세스 상태에서 변동이 있으면
            ResultManager.UpdateResult(ResultManager.UPDATE_MODE.APPEND, "※ 상태 전이 발생 : " + Me._name + "이(가) 스케쥴러에 의해 강제로 " + _strProcessState(oldProcessState) + "에서 " +
                                       _strProcessState(Me._processState) + "(으)로 전이")
        End If

        Me._isSelfProcessJobResultAlreadyOutputed = False '상태 전이 발생 시 다음에 자신의 처리 결과 출력을 위하여 초기화
    End Sub
#End Region

#Region "Private"
    Private _name As String '프로세스 이름
    Private _arrivalTime As Short '도착시간
    Private _burstTime As Short '실행시간 (가변적)

    ' 사용자로부터 초기 우선순위를 입력받을 시에는 Short(정수)로 처리하지만, 내부적으로 계산하여 재할당할 경우 Single(실수)로 처리
    Private _priorty As Single '우선순위 (가변적, 높을수록 먼저 수행)
    Private _waitingTime As Short '대기시간 (가변적, 준비 큐에 들어왔지만 CPU의 자원을 할당받지 못하고 대기하고 있는 시간)

    Private _processState As PROCESS_STATE '프로세스 상태 (가변적, 남은 실행시간에 따라 변동)
    Private _isSelfProcessJobResultAlreadyOutputed As Boolean '프로세스 자신의 처리 결과가 이전에 이미 출력되었는지 출력 여부
#End Region
End Class