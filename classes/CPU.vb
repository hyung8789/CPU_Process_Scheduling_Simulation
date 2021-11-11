Imports CPU_Process_Scheduling_Simulation.CPUArgs
Imports CPU_Process_Scheduling_Simulation.Process
Imports CPU_Process_Scheduling_Simulation.ProcessQueue

Public Class CPU
    ' 프로세스 스케줄링 작업이 수행 되어 프로세스가 수행 될 CPU 정의

#Region "Public"
    Public _cpuArgs As CPUArgs '프로세스 스케줄링을 위한 옵션 값
    ''' <summary>
    ''' CPU 인스턴스 초기화
    ''' </summary>
    Public Sub New()
        Me._cpuArgs = New CPUArgs()
        Me._readyQueue = New ProcessQueue()
        Me._arrivalQueue = Nothing '모든 프로세스가 동일 시간에 도착하지 않을 시 할당
        Me._allocatedProcess = Nothing
    End Sub
    ''' <summary>
    ''' 초기화 작업 수행
    ''' </summary>
    ''' <param name="srcProcessList">프로세스 스케줄링이 수행 될 프로세스 목록</param>
    Public Sub Init(ByVal srcProcessList As List(Of Process))
        If IsNothing(srcProcessList) Then
            Throw New Exception("CPU - Init Exception : not assigned ProcessList")
        End If

        If Not IsNothing(Me._arrivalQueue) Then
            Me._arrivalQueue = Nothing
        End If

        If Me._cpuArgs.IgnoreArrivalTime Then '도착시간 무시 (모든 프로세스가 동일한 시간에 도착 가정)
            Me._readyQueue.EnqueueRange(srcProcessList)
        Else '도착시간 존재 (각각의 프로세스마다 도착시간 존재)
            Me._arrivalQueue = New ProcessQueue() '도착 큐 할당
            Me._arrivalQueue.EnqueueRangeWithOrderOption(ORDER_TYPE_FLAG.ARRIVAL_TIME, srcProcessList) '빠른 도착시간 순으로 처리를 위하여 도착 큐에 도착시간 기준 오름차순 정렬하여 삽입
        End If
    End Sub
    ''' <summary>
    ''' 현재 CPU의 자원을 할당받기 위해 대기 중인 혹은 도착 할 예정인 모든 프로세스들에 대한 스케줄링 작업 시작
    ''' </summary>
    Public Sub DoProcessSchedulingJob()
        Dim arrivedProccessCount As Short = 0 '시뮬레이션 진행 과정 중 도착 한 프로세스 수
        Dim totalProcessCountForSchedulingJob As Short '스케줄링 작업을 위한 전체 프로세스 수 (평균 계산 위함)
        If Me._cpuArgs.IgnoreArrivalTime Then '도착시간 무시 (모든 프로세스가 동일한 시간에 도착 가정)
            totalProcessCountForSchedulingJob = Me._readyQueue.GetNumOfWaitingProcesses() '준비 큐로 전체 프로세스 수 할당
            arrivedProccessCount = totalProcessCountForSchedulingJob '동일 시간 (진행시간 0)에 모든 프로세스가 도착 한 것으로 가정
        Else '도착시간 존재 (각각의 프로세스마다 도착시간 존재)
            totalProcessCountForSchedulingJob = Me._arrivalQueue.GetNumOfWaitingProcesses() '도착 큐로 전체 프로세스 수 할당
        End If

        Dim isPreemptive As Boolean '선점형 여부
        Select Case Me._cpuArgs.SchedulingType '선점형 여부 할당
            Case SCHEDULING_TYPE.FCFS, SCHEDULING_TYPE.SJF, SCHEDULING_TYPE.HRN, SCHEDULING_TYPE.PRIORITY_NON_PREEMPTIVE '비선점형
                isPreemptive = False

            Case SCHEDULING_TYPE.SRTN, SCHEDULING_TYPE.RR, SCHEDULING_TYPE.PRIORITY_PREEMPTIVE '선점형
                isPreemptive = True
        End Select

        Dim isCompleted As Boolean = False '시뮬레이션 완료 여부

        ' < 누적 CPU 유휴시간 >
        ' 누적 CPU 유휴시간은 최대 도착시간 (Short 최대 값 32767)을 초과하지 않음
        Dim accCpuIdleTime As Short = 0 '누적 CPU 유휴시간 (다음 프로세스가 아직 도착하지 않아 CPU가 아무런 작업도 수행하지 않고 대기 중인 시간)

        ' < 누적 프로세스 실행시간 >
        ' 생성 가능 한 최대 프로세스의 수 (Short 최대 값 32767)에 대하여
        ' 모든 프로세스들이 프로세스에 할당 가능 한 최대 실행시간 (Short 최대 값 32767)만큼 할당되어 있으면
        ' 최대 32767 * 32767 = 1,073,676,289 만큼의 누적 프로세스 실행시간이 필요
        Dim accProcessBurstTime As UInteger = 0 '누적 프로세스 실행시간

        ' < 누적 프로세스 대기시간 >
        ' 생성 가능 한 최대 프로세스의 수 (Short 최대 값 32767)에 대하여
        ' 모든 프로세스들이 프로세스에 할당 가능 한 최대 실행시간 (Short 최대 값 32767)만큼 할당되어 있으며,
        ' 비선점형에서 모든 프로세스가 진행시간 0에 동시에 도착하여 한 프로세스가 끝날 때까지 다른 프로세스들은 계속 대기하면,
        ' 최대 (32767 - 1) * 32767 = 1,073,643,522 만큼의 누적 프로세스 대기시간이 필요
        Dim accProcessWaitingTime As UInteger = 0 '누적 프로세스 대기시간 (다른 프로세스가 작업 중 프로세스 준비 큐의 프로세스들이 CPU의 자원을 할당받기 위해 대기 중인 시간)

        ' < 누적 문맥교환 횟수 카운트 >
        ' 생성 가능 한 최대 프로세스의 수 (Short 최대 값 32767)에 대하여
        ' 모든 프로세스들이 프로세스에 할당 가능 한 최대 실행시간 (Short 최대 값 32767)만큼 할당되어 있으며,
        ' 선점형에서 Time Quantum의 최소 단위인 1 단위로 스케줄링하며 매 번 문맥교환 수행한다고 가정 시,
        ' 최대 32767 * 32767 =  1,073,676,289 번 발생 가능
        Dim accContextSwitchingCount As UInteger = 0 '누적 문맥교환 횟수 카운트

        ResultManager.UpdateResult(ResultManager.UPDATE_MODE.APPEND, "--- 현재 스케줄링 타입 : " + _strSchedulingType(Me._cpuArgs.SchedulingType) + " ---")

        While Not isCompleted
            ' 1) 이하, 현재 CPU의 자원을 할당받기 위해 대기 중인 혹은 도착 할 예정인 모든 프로세스들에 대해 처리가 끝날 때까지 반복
            ' => 도착시간 무시 여부에 따라 시뮬레이션 완료 여부를 다음과 같이 판별
            '   1-1) 도착시간 무시 (모든 프로세스가 동일한 시간에 도착 가정)
            '   : 현재 준비 큐에 대기 중인 프로세스가 없으며, 현재 CPU의 자원이 할당 된 프로세스가 없을 경우 종료
            '
            '   1-2) 도착시간 존재 (각각의 프로세스마다 도착시간이 별도로 존재)
            '   : 현재 도착 큐에 대기 중인 프로세스가 없으며, 또한 현재 준비 큐에 대기 중인 프로세스가 없고, 현재 CPU의 자원이 할당 된 프로세스가 없을 경우 종료
            '
            ' 2) 프로세스 도착 이벤트 및 준비 작업 (준비 큐 재정렬, 문맥교환) 처리
            '
            ' 3) 스케쥴러에 의해 프로세스에 대한 CPU의 처리 작업 수행 (자원 할당, 해제)

            ' 4) 이전 프로세스의 수행에 따른 현재 준비 큐에서 대기 중인 프로세스들에 대한 대기시간 할당

#Region "프로세스 도착 이벤트 및 준비 작업 (준비 큐 재정렬, 문맥교환) 처리 영역"
            If Not Me._cpuArgs.IgnoreArrivalTime Then '도착시간 존재 (각각의 프로세스마다 도착시간 존재)
                Me.ProcessArrivalEventProc(arrivedProccessCount, accCpuIdleTime, accProcessBurstTime)
            End If

            Me.PreProcessingProc(isPreemptive, arrivedProccessCount, accContextSwitchingCount)
#End Region

#Region "스케쥴러에 의해 프로세스에 대한 CPU의 처리 작업 수행 영역 (자원 할당, 해제)"
            Dim lastProcessBurstTime As Short = 0 '마지막으로 수행 된 프로세스의 실행시간
            lastProcessBurstTime = Me.CpuProcessingProc(isPreemptive, accCpuIdleTime, accProcessBurstTime, accProcessWaitingTime)
#End Region

#Region "이전 프로세스의 수행에 따른 현재 준비 큐에서 대기 중인 프로세스들에 대한 대기시간 할당 처리 영역"
            If lastProcessBurstTime > 0 Then '이전에 실행 된 프로세스가 수행 한 실행시간이 존재할 경우
                For i = 0 To (Me._readyQueue.GetNumOfWaitingProcesses() - 1) '준비 큐의 프로세스들에 대해 대기시간 갱신
                    Dim waitingProcess As Process = Me._readyQueue.ElementAt(i) '대기 중인 프로세스
                    waitingProcess.SetWaitingTime(waitingProcess.GetWaitingTime() + lastProcessBurstTime) '대기시간 갱신 (이전에 실행 된 프로세스가 수행 한 실행시간만큼 누적)
                Next
            End If
#End Region

#Region "도착시간 무시 여부에 따라 종료 조건 판별 영역"
            If Not Me._cpuArgs.IgnoreArrivalTime Then '도착시간 존재 (각각의 프로세스마다 도착시간 존재)
                isCompleted = (Me._readyQueue.GetNumOfWaitingProcesses() = 0) And
                   (Me._arrivalQueue.GetNumOfWaitingProcesses() = 0) And
                   IsNothing(Me._allocatedProcess)
            Else '도착시간 무시 (모든 프로세스가 동일한 시간에 도착 가정)
                isCompleted = (Me._readyQueue.GetNumOfWaitingProcesses() = 0) And
                   IsNothing(Me._allocatedProcess)
            End If
#End Region
        End While

        ResultManager.UpdateResult(ResultManager.UPDATE_MODE.APPEND, "--- DONE ---")
        ResultManager.UpdateResult(ResultManager.UPDATE_MODE.APPEND, "시뮬레이션 총 소요시간 : " + (accCpuIdleTime + accProcessBurstTime).ToString)
        ResultManager.UpdateResult(ResultManager.UPDATE_MODE.APPEND, "누적 CPU 유휴시간 : " + accCpuIdleTime.ToString)
        ResultManager.UpdateResult(ResultManager.UPDATE_MODE.APPEND, "누적 실행시간 : " + accProcessBurstTime.ToString)
        ResultManager.UpdateResult(ResultManager.UPDATE_MODE.APPEND, "누적 대기시간 : " + accProcessWaitingTime.ToString)
        ResultManager.UpdateResult(ResultManager.UPDATE_MODE.APPEND, "누적 반환시간 : " + (accProcessBurstTime + accProcessWaitingTime).ToString)
        ResultManager.UpdateResult(ResultManager.UPDATE_MODE.APPEND, "누적 문맥교환 횟수 : " + accContextSwitchingCount.ToString)
        ResultManager.UpdateResult(ResultManager.UPDATE_MODE.APPEND, "평균 실행시간 : " + CSng(accProcessBurstTime / totalProcessCountForSchedulingJob).ToString)
        ResultManager.UpdateResult(ResultManager.UPDATE_MODE.APPEND, "평균 대기시간 : " + CSng(accProcessWaitingTime / totalProcessCountForSchedulingJob).ToString)
        ResultManager.UpdateResult(ResultManager.UPDATE_MODE.APPEND, "평균 반환시간 : " + CSng((accProcessBurstTime + accProcessWaitingTime) / totalProcessCountForSchedulingJob).ToString)
    End Sub
#End Region
#Region "Private"
    Private _allocatedProcess As Process '현재 CPU의 자원을 할당받아 실행 중인 프로세스

    Private _arrivalQueue As ProcessQueue '도착 큐
    Private _readyQueue As ProcessQueue '프로세스 준비 큐
    ''' <summary>
    ''' 프로세스 도착 이벤트 처리
    ''' </summary>
    ''' <param name="srcArrivedProccessCount">시뮬레이션 진행 과정 중 도착 한 프로세스 수</param>
    ''' <param name="srcAccCpuIdleTIme">누적 CPU 유휴시간</param>
    ''' <param name="srcAccProcessBurstTime">누적 프로세스 실행시간</param>
    Private Sub ProcessArrivalEventProc(ByRef srcArrivedProccessCount As Short, ByRef srcAccCpuIdleTIme As Short, ByVal srcAccProcessBurstTime As UInteger)
        ' < 프로세스 도착 이벤트 처리 >
        '
        ' 1) 도착 큐에서 대기 중인 프로세스가 존재할 경우, 도착 예정인 프로세스의 도착시간과 현재 시뮬레이션 시간을 비교
        '   1-1) CPU가 대기해야 할 시간 (다음 프로세스 도착 시간 - 현재 시간)이 존재하고, 현재 CPU가 유휴 상태일 경우 다음 프로세스가 도착 시까지 누적 CPU 유휴시간 증가
        '
        ' 2) 도착 큐에서 현재시간 이전 혹은 현재시간에 도착 여부에 따라 처리
        '   2-1) 현재시간 이전에 도착 한 프로세스 : (현재시간 - 도착시간)으로 해당 프로세스의 대기시간 할당, 준비 큐에 삽입
        '   => 현재시간 이전에 도착 한 프로세스는 시뮬레이션 과정에서 이전에 CPU의 자원을 할당받은 다른 프로세스가 실행되는 과정 중 이미 도착하였지만
        '   CPU의 자원을 할당받지 못하고 대기하고 있던 프로세스로서, 현재시간 이전에 도착 한 프로세스의 대기시간을 현재시간과 현재시간 이전에 도착 한 프로세스의 도착시간 차로 할당
        '
        '   2-2) 현재시간에 도착 한 프로세스 : 준비 큐에 삽입 (방금 도착하였으므로, 대기시간 할당이 필요 없음)
        '
        ' 3) 현재시간 이전에 이미 도착하였거나, 도착 한 프로세스(들)에 대하여 준비 큐에 삽입
        ' => 현재시간 이전에 다수 개의 프로세스가 도착하였거나, 현재시간에 다수 개의 프로세스가 도착할 수 있다.
        ' ---
        ' 도착 이벤트 발생에 따라 도착 한 프로세스에 대기시간 (현재시간 - 도착시간)이 할당 된 다음, 준비 큐에 삽입되었으므로,
        ' 이미 준비 큐에서 대기 중인 프로세스들에 대해 대기시간을 이전 프로세스의 수행 시간만큼 누적하여 할당하는 것은 
        ' 도착 큐에서 준비 큐로 방금 삽입 된 프로세스는 아직 CPU의 프로세스에 대한 처리 작업이 발생하기 전이므로 제외되어야 한다.
        ' 이에 따라, 이전 프로세스의 수행 시간에 따라 현재 준비 큐의 전체 프로세스들에 대해 대기시간을 이전 프로세스의 수행 시간만큼 누적하여 할당하는 처리는
        ' 스케쥴러에 의해 프로세스에 대한 CPU의 처리 작업 수행 후에 수행되어야 한다.

        If Me._arrivalQueue.GetNumOfWaitingProcesses() > 0 Then '도착 큐에서 대기 중인 프로세스가 존재 시
            Dim currentSimTime = srcAccProcessBurstTime + srcAccCpuIdleTIme '시뮬레이션 현재시간 (누적 CPU 유휴시간 + 누적 프로세스 실행시간)
            Dim nextProcessArrivalTime = Me._arrivalQueue.Peek().GetArrivalTime() '다음 프로세스 도착시간
            Dim cpuWaitingTime = nextProcessArrivalTime - currentSimTime 'CPU가 유휴상태일 시 대기해야 할 시간
            Dim isCpuIdleState As Boolean = (IsNothing(Me._allocatedProcess) And
                Me._readyQueue.GetNumOfWaitingProcesses() = 0) 'CPU의 유휴 상태 여부 (현재 CPU에 할당 된 프로세스가 없고, 준비 큐에 대기 중인 프로세스가 없는 경우)

            If cpuWaitingTime > 0 And isCpuIdleState Then 'CPU가 대기해야 할 시간이 존재하고, CPU가 유휴 상태일 경우
                Dim oldSimTime = currentSimTime '출력 위한 이전 시뮬레이션 시간

                srcAccCpuIdleTIme += cpuWaitingTime '누적 CPU 유휴시간 증가
                currentSimTime = srcAccProcessBurstTime + srcAccCpuIdleTIme '시뮬레이션 현재시간 재계산

                ResultManager.UpdateResult(ResultManager.UPDATE_MODE.APPEND, "현재 진행시간 (" + currentSimTime.ToString + ") : " + "CPU가 다음 프로세스가 도착 할 때까지 " +
                                               oldSimTime.ToString + "에서 " + currentSimTime.ToString + "까지 " + cpuWaitingTime.ToString + "만큼 대기 발생")
            End If

            While Me._arrivalQueue.GetNumOfWaitingProcesses() > 0 '도착 큐의 프로세스들에 대하여
                Dim arrivedProcess As Process = Nothing '도착 한 프로세스

                If Me._arrivalQueue.Peek().GetArrivalTime() < currentSimTime Then '현재시간 이전에 도착한 프로세스들에 대하여
                    arrivedProcess = Me._arrivalQueue.Dequeue()
                    arrivedProcess.SetWaitingTime(currentSimTime - arrivedProcess.GetArrivalTime()) '도착 한 프로세스에 대기시간 할당 (현재시간 - 도착시간)
                    srcArrivedProccessCount += 1 '시뮬레이션 진행 과정 중 도착 한 프로세스 수 증가

                    Me._readyQueue.Enqueue(arrivedProcess) '도착 한 프로세스를 준비 큐에 삽입
                ElseIf Me._arrivalQueue.Peek().GetArrivalTime() = currentSimTime Then '현재시간에 도착한 프로세스들에 대하여
                    arrivedProcess = Me._arrivalQueue.Dequeue()
                    srcArrivedProccessCount += 1 '시뮬레이션 진행 과정 중 도착 한 프로세스 수 증가

                    Me._readyQueue.Enqueue(arrivedProcess) '도착 한 프로세스를 준비 큐에 삽입
                Else '아직 도착하지 않은 프로세스일 경우, 도착시간 순서대로 정렬되어 있는 도착 큐에서 판별 종료
                    Exit While
                End If

                ResultManager.UpdateResult(ResultManager.UPDATE_MODE.APPEND, "※ 도착 이벤트 발생 : " + arrivedProcess.GetName() + "이(가) 진행시간 " +
                                   arrivedProcess.GetArrivalTime().ToString + "에 도착")
            End While
        End If
    End Sub
    ''' <summary>
    ''' 준비 작업 처리 (준비 큐 재정렬, 문맥교환)
    ''' </summary>
    ''' <param name="isPreemptive">선점형 여부</param>
    ''' <param name="srcArrivedProccessCount">시뮬레이션 진행 과정 중 도착 한 프로세스 수</param>
    ''' <param name="srcAccContextSwitchingCount">누적 문맥교환 횟수 카운트</param>
    Private Sub PreProcessingProc(ByVal isPreemptive As Boolean, ByRef srcArrivedProccessCount As Short, ByRef srcAccContextSwitchingCount As UInteger)
        ' < 준비 작업 처리 (준비 큐 재정렬, 문맥교환) >
        '
        '   1) First Come First Service (비선점형)
        '   - 초기 우선순위를 무시 할 경우 : 준비 큐에 대한 정렬 수행하지 않음
        '   - 초기 우선순위를 사용 할 경우 : 도착 한 프로세스가 존재 할 경우 준비 큐에 대한 높은 우선순위 기준 실행 위하여 우선순위 기준 내림차순 정렬
        '
        '   2) Shortest Job First (비선점형)
        '   - 초기 우선순위를 무시 할 경우 : 도착 한 프로세스가 존재 할 경우 준비 큐에 대한 짧은 실행시간 우선 실행 위하여 실행시간 기준 오름차순 정렬
        '   - 초기 우선순위를 사용 할 경우 : 도착 한 프로세스가 존재 할 경우 준비 큐에 대한 짧은 실행시간 우선 실행 위하여 실행시간 기준 오름차순 정렬 및 우선순위 기준 내림차순 정렬
        '
        '   3) Highest Response-Ratio Next (비선점형)
        '   (대기시간+실행시간) / 실행시간으로 현재 준비 큐에서 대기 중인 프로세스들에 대하여 우선순위 갱신하여 할당
        '   - 초기 우선순위를 무시 할 경우 : 갱신 된 우선순위 할당
        '   - 초기 우선순위를 사용 할 경우 : 초기 우선순위가 갱신 된 우선순위보다 같거나 높을 경우 초기 우선순위를 계속 이용, 갱신 된 우선순위가 초기 우선순위보다 높을 경우 갱신 된 우선순위로 우선순위 갱신
        '   (사용자가 부여한 초기 우선순위는 갱신 된 우선순위보다 높은 우선순위를 갖는다.)
        '   항상 준비 큐에 대한 높은 우선순위 기준 실행 위하여 우선순위 기준 내림차순 정렬
        '
        '   4) Priority-based scheduling (비선점형)
        '   도착 한 프로세스가 존재 할 경우 준비 큐에 대한 높은 우선순위 기준 실행 위하여 우선순위 기준 내림차순 정렬
        '
        '   5) Shortest Remaining Time Next (선점형)
        '   - 초기 우선순위를 무시 할 경우 : 도착 한 프로세스가 존재 할 경우 준비 큐에 대한 짧은 실행시간 우선 실행 위하여 실행시간 기준 오름차순 정렬
        '   - 초기 우선순위를 사용 할 경우 : 도착 한 프로세스가 존재 할 경우 준비 큐에 대한 짧은 실행시간 우선 실행 위하여 실행시간 기준 오름차순 정렬 및 우선순위 기준 내림차순 정렬
        '   현재 실행 중인 프로세스가 존재하며, 준비 큐에 대기 중인 프로세스가 존재하면서, 현재 실행 중인 프로세스보다 준비 큐의 프로세스보다 남은 실행시간이 더 짧은 경우, 문맥교환 수행
        '
        '   6) Round-Robin (선점형)
        '   - 초기 우선순위를 무시 할 경우 : 준비 큐에 대한 정렬 수행하지 않음
        '   - 초기 우선순위를 사용 할 경우 : 도착 한 프로세스가 존재 할 경우 준비 큐에 대한 높은 우선순위 기준 실행 위하여 우선순위 기준 내림차순 정렬
        '   현재 실행 중인 프로세스가 존재하며, 준비 큐에 대기 중인 프로세스가 존재하면 문맥교환 수행
        '
        '   7) Priority-based scheduling (선점형)
        '   도착 한 프로세스가 존재 할 경우 준비 큐에 대한 높은 우선순위 기준 실행 위하여 우선순위 기준 내림차순 정렬
        '   현재 실행 중인 프로세스가 존재하며, 준비 큐에 대기 중인 프로세스가 존재하면서, 현재 실행 중인 프로세스보다 준비 큐의 프로세스가 우선순위가 높은 경우, 문맥교환 수행
        '   ---
        '   (공통 처리)
        '   1) 프로세스가 도착하지 않은 상황에서 불필요한 정렬에 따른 오버헤드를 방지하기 위해 도착 한 프로세스가 존재하지 않을 경우 재정렬을 수행하지 않는다.
        '   => 단, HRRN의 경우 실시간으로 우선순위를 갱신하여 재정렬을 수행하므로, 이는 제외
        '   2) 다음 도착 이벤트 처리를 위해 시뮬레이션 진행 과정 중 도착 한 프로세스 수 초기화

        Select Case Me._cpuArgs.SchedulingType '필요 할 경우 준비 큐 재정렬, 문맥교환 수행
            Case SCHEDULING_TYPE.FCFS
                If Not Me._cpuArgs.IgnorePriority And srcArrivedProccessCount > 0 Then '초기 우선순위를 사용하며, 도착 한 프로세스들이 존재 할 경우
                    Me._readyQueue.ReOrder(ORDER_TYPE_FLAG.PRIORITY) '높은 우선순위 기준 실행 위하여 우선순위 기준 내림차순 정렬
                End If

            Case SCHEDULING_TYPE.SJF
                If srcArrivedProccessCount > 0 Then '도착 한 프로세스들이 존재 할 경우
                    If Me._cpuArgs.IgnorePriority Then '초기 우선순위 무시 (우선순위 입력 값 무시)
                        Me._readyQueue.ReOrder(ORDER_TYPE_FLAG.BURST_TIME) '짧은 실행시간 우선 실행 위하여 실행시간 기준 오름차순 정렬
                    Else '초기 우선순위 사용
                        Me._readyQueue.ReOrder(ORDER_TYPE_FLAG.BURST_TIME Or ORDER_TYPE_FLAG.PRIORITY) '짧은 실행시간 우선 실행 위하여 실행시간 기준 오름차순 정렬 및 우선순위 기준 내림차순 정렬
                    End If
                End If

            Case SCHEDULING_TYPE.HRN 'Highest Response-Ratio Next (비선점형) : (대기시간+실행시간) / 실행시간으로 우선순위 할당하여 높은 순으로 처리
                For i = 0 To (Me._readyQueue.GetNumOfWaitingProcesses() - 1) '준비 큐의 프로세스들에 대해 우선순위 갱신
                    ' < HRN에서 초기 우선순위 무시 (우선순위 입력 값 무시) 여부에 따른 우선순위 처리 방법 >
                    '
                    ' 1) 초기 우선순위를 무시
                    '   => 갱신 된 우선순위 사용
                    '
                    ' 2) 초기 우선순위 사용
                    '   => 초기 우선순위가 갱신 된 우선순위보다 같거나 높을 경우 초기 우선순위를 계속 이용, 
                    '   갱신 된 우선순위가 초기 우선순위보다 높을 경우 갱신 된 우선순위로 우선순위 갱신
                    '   (사용자가 부여한 초기 우선순위는 갱신 된 우선순위보다 높은 우선순위를 갖는다.)

                    Dim waitingProcess As Process = Me._readyQueue.ElementAt(i) '대기 중인 프로세스
                    Dim waitingTime = waitingProcess.GetWaitingTime() '대기시간
                    Dim burstTime = waitingProcess.GetBurstTime() '실행시간

                    Dim oldPriority As Single = waitingProcess.GetPriority() '이전 우선순위
                    Dim updatedPriority As Single = (waitingTime + burstTime) / burstTime '갱신 된 우선순위 : (대기시간 + 실행시간) / 실행시간

                    If Me._cpuArgs.IgnorePriority Then '초기 우선순위 무시 (우선순위 입력 값 무시)
                        waitingProcess.SetPriority(updatedPriority) '갱신 된 우선순위 할당
                    Else '초기 우선순위 사용
                        If oldPriority >= updatedPriority Then '사용자가 부여한 초기 우선순위가 갱신 된 우선순위보다 같거나 높을 경우
                            'do nothing (초기 우선순위를 계속 이용)
                        Else '갱신 된 우선순위가 사용자가 부여한 초기 우선순위보다 높을 경우
                            waitingProcess.SetPriority(updatedPriority) '갱신 된 우선순위 할당
                            ResultManager.UpdateResult(ResultManager.UPDATE_MODE.APPEND, "※ 우선순위 재 할당 발생 : " + waitingProcess.GetName() + "의 우선순위 (" + oldPriority.ToString + " -> " +
                                                       updatedPriority.ToString + ")")
                        End If
                    End If
                Next
                Me._readyQueue.ReOrder(ORDER_TYPE_FLAG.PRIORITY) '높은 우선순위 기준 실행 위하여 우선순위 기준 내림차순 정렬

            Case SCHEDULING_TYPE.PRIORITY_NON_PREEMPTIVE 'Priority-based scheduling (비선점형) : 초기 할당 된 우선순위를 이용하여 우선순위 기반 스케줄링
                If srcArrivedProccessCount > 0 Then '도착 한 프로세스들이 존재 할 경우
                    Me._readyQueue.ReOrder(ORDER_TYPE_FLAG.PRIORITY) '높은 우선순위 기준 실행 위하여 우선순위 기준 내림차순 정렬
                End If

            Case SCHEDULING_TYPE.SRTN '미리 정의 된 Time Quantum 만큼 실행 후 남은 실행시간이 제일 짧은 순으로 처리, SJF의 선점형
                If srcArrivedProccessCount > 0 Then '도착 한 프로세스들이 존재 할 경우
                    If Me._cpuArgs.IgnorePriority Then '초기 우선순위 무시 (우선순위 입력 값 무시)
                        Me._readyQueue.ReOrder(ORDER_TYPE_FLAG.BURST_TIME) '짧은 실행시간 우선 실행 위하여 실행시간 기준 오름차순 정렬
                    Else '초기 우선순위 사용
                        Me._readyQueue.ReOrder(ORDER_TYPE_FLAG.BURST_TIME Or ORDER_TYPE_FLAG.PRIORITY) '짧은 실행시간 우선 실행 위하여 실행시간 기준 오름차순 정렬 및 우선순위 기준 내림차순 정렬
                    End If
                End If

                If Not IsNothing(Me._allocatedProcess) And Me._readyQueue.GetNumOfWaitingProcesses() > 0 Then '현재 실행 중인 프로세스가 존재하며, 준비 큐에 대기 중인 프로세스가 존재하면
                    If Me._allocatedProcess.GetBurstTime() > Me._readyQueue.Peek().GetBurstTime() Then '현재 실행 중인 프로세스가 준비 큐의 프로세스보다 남은 실행시간이 더 짧은 경우
                        Me.ContextSwitchingProc(srcAccContextSwitchingCount, isPreemptive) '문맥교환 수행
                    End If
                End If

            Case SCHEDULING_TYPE.RR 'Round-Robin (선점형) : 미리 정의 된 Time Quantum 기준으로 돌아가며 처리
                ' < RR에서 우선순위에 따른 기아 현상 방지 >
                '
                ' 프로세스 우선순위에 따라 낮은 우선순위의 프로세스가 자원을 할당받지 못하고
                ' 계속 대기하는 기아 현상을 막기 위해, 도착 한 프로세스가 존재 할 경우만 재정렬 수행

                If Not Me._cpuArgs.IgnorePriority And srcArrivedProccessCount > 0 Then '초기 우선순위를 사용하며, 도착 한 프로세스들이 존재 할 경우
                    Me._readyQueue.ReOrder(ORDER_TYPE_FLAG.PRIORITY) '높은 우선순위 기준 실행 위하여 우선순위 기준 내림차순 정렬
                End If

                If Not IsNothing(Me._allocatedProcess) And Me._readyQueue.GetNumOfWaitingProcesses() > 0 Then '현재 실행 중인 프로세스가 존재하며, 준비 큐에 대기 중인 프로세스가 존재하면
                    Me.ContextSwitchingProc(srcAccContextSwitchingCount, isPreemptive) '문맥교환 수행
                End If

            Case SCHEDULING_TYPE.PRIORITY_PREEMPTIVE 'Priority-based scheduling (선점형) : 초기 할당 된 우선순위를 이용하여 우선순위 기반 스케줄링
                If srcArrivedProccessCount > 0 Then '도착 한 프로세스들이 존재 할 경우
                    Me._readyQueue.ReOrder(ORDER_TYPE_FLAG.PRIORITY) '높은 우선순위 기준 실행 위하여 우선순위 기준 내림차순 정렬
                End If

                If Not IsNothing(Me._allocatedProcess) And Me._readyQueue.GetNumOfWaitingProcesses() > 0 Then '현재 실행 중인 프로세스가 존재하며, 준비 큐에 대기 중인 프로세스가 존재하면
                    If Me._allocatedProcess.GetPriority() < Me._readyQueue.Peek().GetPriority() Then '현재 실행 중인 프로세스보다 준비 큐에 대기 중인 프로세스가 우선순위가 높은 경우
                        Me.ContextSwitchingProc(srcAccContextSwitchingCount, isPreemptive) '문맥교환 수행
                    End If
                End If
        End Select

        srcArrivedProccessCount = 0 '시뮬레이션 진행 과정 중 도착 한 프로세스 수 초기화
    End Sub
    ''' <summary>
    ''' 스케쥴러에 의해 프로세스에 대한 CPU의 처리 (자원 할당, 해제)
    ''' </summary>
    ''' <param name="isPreemptive">선점형 여부</param>
    ''' <param name="srcAccCpuIdleTIme">누적 CPU 유휴시간</param>
    ''' <param name="srcAccProcessBurstTime">누적 프로세스 실행시간</param>
    ''' <param name="srcAccProcessWaitingTime">누적 프로세스 대기시간</param>
    ''' <returns>프로세스가 작업을 수행 한 실행시간</returns>
    Private Function CpuProcessingProc(ByVal isPreemptive As Boolean, ByVal srcAccCpuIdleTIme As Short, ByRef srcAccProcessBurstTime As UInteger, ByRef srcAccProcessWaitingTime As UInteger) As Short
        ' (선점형 스케줄링의 프로세스에 대한 처리)
        ' 현재 할당 된 프로세스 존재 (단, 남은 실행시간 > 0) | 준비 큐에 대기 중인 프로세스 존재 | 수행 작업
        ' T                                                    T                                   현재 할당 된 프로세스의 작업을 timeQuantum 만큼 계속 처리, 완료 시 자원 해제
        ' T                                                    F                                   현재 할당 된 프로세스의 작업을 timeQuantum 만큼 계속 처리, 완료 시 자원 해제
        ' F                                                    T                                   준비 큐의 새로운 프로세스에 자원 할당 및 timeQuantum 만큼 처리, 완료 시 자원 해제
        ' F                                                    F                                   do nothing
        ' ---
        ' => 이전 프로세스가 계속하여 다음 CPU의 자원 할당 시점에 자신의 작업을 처리 할 시 이전 프로세스를 위해 결과 출력 시 작업을 시작하였던 최초 시뮬레이션 현재시간을 백업하였다가 출력
        ' (즉, 선점형 스케줄링이지만 더 이상 CPU의 자원을 할당받고자 대기하는 프로세스가 존재하지 않거나, 이전 프로세스에 대해 문맥교환이 발생하지 않은 경우)
        ' ---
        ' (비선점형 스케줄링의 프로세스에 대한 처리)
        ' 현재 할당 된 프로세스 존재 (단, 남은 실행시간 > 0) | 준비 큐에 대기 중인 프로세스 존재 | 수행 작업
        ' T                                                    T                                   오류
        ' T                                                    F                                   오류
        ' F                                                    T                                   준비 큐의 새로운 프로세스에 자원 할당, 모두 완료 될 때까지 수행 후 자원 해제
        ' F                                                    F                                   do nothing
        ' ---
        ' (공통 처리)
        ' 1) 수행 작업 판별 시점에 현재 할당 된 프로세스의 남은 실행시간이 0이거나 종료 상태일 경우 오류 (이전에 할당 해제되었어야 함)
        ' 2) CPU의 자원을 할당받아 프로세스가 수행 한 시간만큼 누적 프로세스 실행시간 증가
        ' 3) 완료 된 프로세스에 대해 프로세스가 대기하였던 대기시간만큼 누적 대기시간 증가

        Dim isAlreadyAllocatedProcessExists As Boolean = Not IsNothing(Me._allocatedProcess) '현재 할당 된 프로세스 존재 여부
        Dim isReadyQueueWaitingProcessExists As Boolean = (Me._readyQueue.GetNumOfWaitingProcesses() > 0) '준비 큐에 대기 중인 프로세스 존재 여부

        '중간 과정 출력 위한 값들
        Static Dim firstExecutedSimTime As UInteger = 0 '프로세스의 최초 실행 시점의 시뮬레이션 진행시간 (연속 된 동일 프로세스의 작업에 대한 중간 결과 출력 위함)
        Static Dim isContinuousJob As Boolean = False '연속 된 동일 프로세스의 작업 여부

        Dim timeQuantum As Short = 0 ' CPU의 자원을 프로세스에 할당 시의 규정 시간량
        Dim processBurstTime As Short = 0 '프로세스가 작업을 수행한 실행시간

        If isAlreadyAllocatedProcessExists Then '이미 할당 된 프로세스가 존재하며
            If Me._allocatedProcess.GetBurstTime() = 0 Or
                Me._allocatedProcess.GetProcessState() = PROCESS_STATE.TERMINATED Then '남은 실행시간이 0이거나 종료 된 프로세스면
                Throw New Exception("CPU - CpuProcessingProc Exception : not proceed process exists")
            End If
        End If

        If isPreemptive Then '선점형 스케줄링
            timeQuantum = Me._cpuArgs.TimeQuantumForPreemptive '선점형 스케줄링을 위해 규정 된 시간량만큼 할당

            If isAlreadyAllocatedProcessExists And (isReadyQueueWaitingProcessExists Or Not isReadyQueueWaitingProcessExists) Then 'T T or T F
                isContinuousJob = True
                GoTo ALLOCATED_PROCESS_PROC '할당 된 프로세스 실행 처리 루틴으로 이동
            ElseIf Not isAlreadyAllocatedProcessExists And isReadyQueueWaitingProcessExists Then 'F T
                firstExecutedSimTime = srcAccCpuIdleTIme + srcAccProcessBurstTime '출력 위하여 프로세스의 최초 실행 시점의 시뮬레이션 진행시간 백업
                isContinuousJob = False
                GoTo ALLOCATE_NEW_PROCESS_PROC '준비 큐의 새로운 프로세스에 자원 할당 처리 루틴으로 이동
            Else 'F F
                Return 0 'do nothing
            End If
        Else '비선점형 스케줄링
            timeQuantum = Short.MaxValue '프로세스의 모든 작업을 수행하기 위해 충분한 시간을 할당

            If isAlreadyAllocatedProcessExists And (isReadyQueueWaitingProcessExists Or Not isReadyQueueWaitingProcessExists) Then 'T T or T F
                Throw New Exception("CPU - CpuProcessingProc Exception : not deallocated process exists (Non-Preemptive)")
            ElseIf Not isAlreadyAllocatedProcessExists And isReadyQueueWaitingProcessExists Then 'F T
                GoTo ALLOCATE_NEW_PROCESS_PROC '준비 큐의 새로운 프로세스에 자원 할당 처리 루틴으로 이동
            Else 'F F
                Return 0 'do nothing
            End If
        End If

ALLOCATE_NEW_PROCESS_PROC: '준비 큐의 새로운 프로세스에 자원 할당 처리 루틴
        Me._allocatedProcess = Me._readyQueue.Dequeue() '준비 큐로부터 CPU에 프로세스 할당
        GoTo ALLOCATED_PROCESS_PROC '할당 된 프로세스 처리 루틴으로 이동

ALLOCATED_PROCESS_PROC: '할당 된 프로세스 처리 루틴
        processBurstTime = Me._allocatedProcess.DoSelfProcessJob((srcAccCpuIdleTIme + srcAccProcessBurstTime), timeQuantum,
                                                                 isContinuousJob, firstExecutedSimTime) '규정 시간량만큼 프로세스 작업 수행

        If Me._allocatedProcess.GetProcessState() = PROCESS_STATE.TERMINATED Then '현재 프로세스가 모든 작업을 완료하여 종료 되었을 경우
            srcAccProcessWaitingTime += Me._allocatedProcess.GetWaitingTime() '해당 프로세스가 대기하였던 대기시간만큼 누적 대기시간 증가
            Me._allocatedProcess = Nothing '해당 프로세스에 대한 CPU의 자원 해제
        End If

        srcAccProcessBurstTime += processBurstTime '프로세스가 수행 한 시간만큼 누적 프로세스 실행시간 증가

        Return processBurstTime '프로세스가 작업을 수행 한 실행시간 반환
    End Function
    ''' <summary>
    ''' 선점형 스케줄링에 대한 문맥교환 수행
    ''' </summary>
    ''' <param name="srcAccContextSwitchingCount">누적 문맥교환 횟수 카운트</param>
    ''' <param name="isPreemptive">선점형 여부</param>
    Private Sub ContextSwitchingProc(ByRef srcAccContextSwitchingCount As Short, ByVal isPreemptive As Boolean)
        ' < 문맥교환 >
        ' 스케줄링 시 프로세스들에게 CPU의 자원을 할당해 줄 때,
        ' 현재 자원이 할당된 프로세스의 정보를 PCB에 저장하고 새로운 프로세스에게, CPU의 자원을 할당하여 실행되도록 하는 것
        ' ---
        ' 여기서는, 현재 CPU의 자원을 할당받아 실행 중인 프로세스(단, 작업이 아직 끝나지 않은 프로세스)를 
        ' 스케줄러에 의해 강제로 준비 상태로 전이시키고 프로세스 준비 큐의 맨 뒤로 삽입한다.
        ' 문맥교환이 발생하는 시점은 현재 할당 된 프로세스가 존재하며 (단, 남은 실행시간 > 0),
        ' 준비 큐에 대기 중인 프로세스가 존재하는 경우에 발생하므로 현재 프로세스의 남은 시간 및 준비 큐의 남은 프로세스 수는 별도로 판별하지 않는다.

        If Not isPreemptive Then '선점형 스케줄링이 아닐 경우
            Throw New Exception("CPU - ContextSwitchingProc Exception : wrong cond")
        End If

        If Not IsNothing(Me._allocatedProcess) Then '현재 CPU의 자원을 할당받아 실행 중인 프로세스 존재
            ResultManager.UpdateResult(ResultManager.UPDATE_MODE.APPEND, "※ 문맥교환 발생 : " + Me._allocatedProcess.GetName() +
                                       " -> " + Me._readyQueue.Peek().GetName())

            Me._allocatedProcess.DebugProcessInfo()
            Me._readyQueue.Peek().DebugProcessInfo()

            Me._allocatedProcess.ForceTransitionProcessState(PROCESS_STATE.READY) '강제로 준비 상태로 전이
            Me._readyQueue.Enqueue(Me._allocatedProcess) '준비 큐의 맨 뒤로 삽입
            Me._allocatedProcess = Nothing 'CPU의 자원 해제

            srcAccContextSwitchingCount += 1 '누적 문맥교환 횟수 증가
        End If
    End Sub
#End Region
End Class