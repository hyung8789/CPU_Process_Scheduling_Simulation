Public Class ProcessQueue
    ' List를 이용한 Wrapper Class 타입의 프로세스 큐 정의 (FIFO)

#Region "Public"
    'https://docs.microsoft.com/ko-kr/dotnet/standard/collections/
    'https://docs.microsoft.com/ko-kr/dotnet/api/system.collections.generic?view=net-5.0

    Public Enum VALIDATION_MODE '유효성 검증 모드
        ' UI 로직으로부터 유효성 검증이 완료 된 데이터에 대해 큐에 삽입 시 유효성 검증을 수행할 필요는 없으므로 ALLOW_ALL로 설정
        ' 이 외, 디버그 혹은 기타 등등에서 STRICT_MODE로 모든 입력값에 대해 중복 데이터 여부 검사

        ALLOW_ALL '모두 허용
        STRICT_MODE '모두 검사 (디버그용)
    End Enum
    <Flags>
    Public Enum ORDER_TYPE_FLAG '정렬 타입 플래그
        ' ARRIVAL_TIME (1bit, 0001) | PRIORITY (1bit, 0010) | BURST_TIME (1bit, 0100)
        ' ex) ORDER_TYPE_FLAG.ARRIVAL_TIME Or ORDER_TYPE_FLAG.PRIORITY : 도착시간 순으로 먼저 오름차순 정렬 후 우선순위 순으로 내림차순 후속 정렬
        ' ---
        ' 다중 플래그 조건을 Iteration하면서 검사 시 LSB부터 도착시간 -> 우선순위 -> 실행시간 기준으로 정렬을 수행한다.
        ' 도착시간이 최우선적으로 정렬 우선순위를 가지고, 그 다음으로 우선순위 -> 실행시간 순으로 정렬 우선순위를 가진다.
        ' 이에 따라, 사용자가 입력 한 우선순위가 존재하는 상황에서, 우선순위와 실행시간의 다중 조건으로 정렬 수행 시 먼저 우선순위 순으로 정렬되며,
        ' 후속 정렬 조건으로서 실행시간을 이용한다.
        ' 만일, 정렬 순서 변동 시 비트 위치 변경할 것

        ARRIVAL_TIME = 1 '도착시간 기준 오름차순 정렬
        PRIORITY = 2 '우선순위 기준 내림차순 정렬
        BURST_TIME = 4 '실행시간 기준 오름차순 정렬
    End Enum
    ''' <summary>
    ''' 프로세스 큐 인스턴스 초기화
    ''' </summary>
    Public Sub New()
        Me._internalList = New List(Of Process)
        Me._validationMode = VALIDATION_MODE.ALLOW_ALL
    End Sub
    ''' <summary>
    ''' 초기화 작업 수행
    ''' </summary>
    ''' <param name="srcValidationMode">유효성 검증 모드</param>
    Public Sub Init(Optional ByVal srcValidationMode As VALIDATION_MODE = VALIDATION_MODE.ALLOW_ALL)
        Me._validationMode = srcValidationMode

        If Not IsNothing(Me._internalList) Then '내부 리스트가 이미 할당되어 있으면
            Me._internalList.Clear() '모든 요소 초기화
        Else
            Throw New Exception("ProcessQueue - Init Exception : not assigned object")
        End If
    End Sub
    ''' <summary>
    ''' 프로세스 목록 내의 모든 프로세스를 정렬하여 순차적으로 내부 리스트에 삽입
    ''' </summary>
    Public Sub EnqueueRangeWithOrderOption(ByVal srcOrderTypeFlags As ORDER_TYPE_FLAG, ByVal srcProcessList As List(Of Process))
        Dim tmpOrderedList As List(Of Process) = srcProcessList '정렬 수행 할 프로세스 목록
        tmpOrderedList = Me.OrderList(srcOrderTypeFlags, tmpOrderedList) '정렬 수행

        For Each process In tmpOrderedList '프로세스 목록의 모든 프로세스에 대하여
            Me.Enqueue(process) '삽입
        Next

        tmpOrderedList = Nothing
    End Sub
    ''' <summary>
    ''' 프로세스 목록 내의 모든 프로세스를 순차적으로 내부 리스트에 삽입
    ''' </summary>
    ''' <param name="srcProcessList">삽입하고자 하는 프로세스 목록</param>
    Public Sub EnqueueRange(ByVal srcProcessList As List(Of Process))
        For Each process In srcProcessList '프로세스 목록의 모든 프로세스에 대하여
            Me.Enqueue(process) '삽입
        Next
    End Sub
    ''' <summary>
    ''' 프로세스를 순차적으로 내부 리스트에 삽입
    ''' </summary>
    ''' <param name="srcProcess">삽입하고자 하는 프로세스</param>
    Public Sub Enqueue(ByVal srcProcess As Process)
        Select Case Me._validationMode
            Case VALIDATION_MODE.ALLOW_ALL
                'do nothing

            Case VALIDATION_MODE.STRICT_MODE
                If Me.IsDuplicateProcessNameExist(srcProcess) Then '중복 프로세스 이름이 존재 시 예외 던짐
                    Throw New Exception("ProcessQueue - Enqueue Exception : already exist process name")
                End If
        End Select

        Me._internalList.Add(srcProcess)
    End Sub
    ''' <summary>
    ''' 내부 리스트에서 순차적인 요소 반환 및 제거
    ''' </summary>
    ''' <returns>프로세스</returns>
    Public Function Dequeue() As Process
        Dim retVal = Nothing '반환 값

        If Me._internalList.Count > 0 Then '내부 요소가 존재하면 첫 번째 요소를 할당 후 제거
            retVal = Me._internalList.First()
            Me._internalList.RemoveAt(0)
        End If

        Return retVal
    End Function
    ''' <summary>
    ''' 내부 리스트에서 제거 없이 순차적인 요소 반환
    ''' </summary>
    ''' <returns>프로세스</returns>
    Public Function Peek() As Process
        Dim retVal = Nothing '반환 값

        If Me._internalList.Count > 0 Then '내부 요소가 존재하면 첫 번째 요소를 할당
            retVal = Me._internalList.First()
        End If

        Return retVal
    End Function
    ''' <summary>
    ''' 내부 리스트에 대기 중인 프로세스 수 반환
    ''' </summary>
    ''' <returns>대기중인 프로세스 수</returns>
    Public Function GetNumOfWaitingProcesses() As Short
        Return Me._internalList.Count
    End Function
    ''' <summary>
    ''' 정렬 타입에 따라 내부 리스트 요소 정렬하여 재구성
    ''' </summary>
    ''' <param name="srcOrderTypeFlags">정렬 타입 플래그</param>
    Public Sub ReOrder(ByVal srcOrderTypeFlags As ORDER_TYPE_FLAG)
        If Me._internalList.Count >= 2 Then '2개 이상의 내부 요소가 존재하면 정렬 수행
            Me._internalList = Me.OrderList(srcOrderTypeFlags, Me._internalList)
        End If
    End Sub
    ''' <summary>
    ''' 내부 리스트 상에서의 요소 인덱스 위치의 요소 제거없이 반환
    ''' </summary>
    ''' <param name="srcIndex">내부 리스트 상에서의 요소 인덱스</param>
    ''' <returns>프로세스</returns>
    Public Function ElementAt(ByVal srcIndex As Short) As Process
        If srcIndex < 0 Or srcIndex >= Me._internalList.Count Then
            Throw New Exception("ProcessQueue - ElementAt Exception : out of range")
        End If

        Return Me._internalList.ElementAt(srcIndex)
    End Function
#End Region

#Region "Private"
    Private _internalList As List(Of Process) '내부 리스트
    Private _validationMode As VALIDATION_MODE '유효성 검증 모드
    ''' <summary>
    ''' 내부 리스트 내의 중복 프로세스 이름 검사 (STRICT_MODE 전용)
    ''' </summary>
    ''' <param name="srcProcess">이름 검사 및 삽입을 위한 프로세스</param>
    ''' <returns>중복 이름 존재 시 True, 그 외 False</returns>
    Private Function IsDuplicateProcessNameExist(ByVal srcProcess As Process) As Boolean
        For i = 0 To (Me._internalList.Count - 1)
            If Me._internalList.ElementAt(i).GetName() = srcProcess.GetName() Then '일치하는 이름이 이미 존재하면
                Return True '중복 이름 존재
            End If
        Next

        Return False '중복 이름 존재하지 않음
    End Function
    ''' <summary>
    ''' 기존 리스트에 대한 정렬 수행 및 정렬 된 리스트 반환
    ''' </summary>
    ''' <param name="srcOrderTypeFlags">정렬 타입 플래그</param>
    ''' <param name="srcProcessList">정렬하고자 하는 기존 리스트</param>
    ''' <returns>정렬이 수행되지 않았으면 기존 리스트 반환, 정렬이 수행되었으면 정렬 된 리스트 반환</returns>
    Private Function OrderList(ByVal srcOrderTypeFlags As ORDER_TYPE_FLAG, ByVal srcProcessList As List(Of Process)) As List(Of Process)
        If IsNothing(srcProcessList) Then
            Throw New Exception("ProcessQueue - OrderList Exception : not assigned object")
        End If

        Dim tmpOrderedEnumerable As IOrderedEnumerable(Of Process) = Nothing '임시 정렬 된 요소
        Dim retVal As List(Of Process) = Nothing '반환 값

        Debug.WriteLine("ProcessQueue - OrderList : debug")
        For Each flag In [Enum].GetValues(srcOrderTypeFlags.GetType) '정렬 타입 플래그에 대하여 순차적으로 비교 (LSB -> MSB)
            If IsNothing(tmpOrderedEnumerable) Then '아직 정렬되지 않았으면
                If srcOrderTypeFlags.HasFlag(flag) Then '해당 플래그를 갖고 있을 경우
                    Debug.WriteLine("orderby - current flag : " + flag.ToString)

                    Select Case flag '해당 플래그에 따라
                        Case ORDER_TYPE_FLAG.ARRIVAL_TIME '도착시간에 따라 오름차순 정렬
                            tmpOrderedEnumerable = srcProcessList.OrderBy(Function(x) x.GetArrivalTime)

                        Case ORDER_TYPE_FLAG.PRIORITY '우선순위에 따라 내림차순 정렬
                            tmpOrderedEnumerable = srcProcessList.OrderByDescending(Function(x) x.GetPriority)

                        Case ORDER_TYPE_FLAG.BURST_TIME '실행시간에 따라 오름차순 정렬
                            tmpOrderedEnumerable = srcProcessList.OrderBy(Function(x) x.GetBurstTime)
                    End Select
                End If

            Else '이미 정렬되었으면 이전 정렬 조건을 만족하면서 후속 정렬 수행
                If srcOrderTypeFlags.HasFlag(flag) Then '해당 플래그를 갖고 있을 경우
                    Debug.WriteLine("thenby - current flag : " + flag.ToString)

                    Select Case flag '해당 플래그에 따라
                        Case ORDER_TYPE_FLAG.ARRIVAL_TIME '도착시간에 따라 오름차순 정렬
                            tmpOrderedEnumerable = tmpOrderedEnumerable.ThenBy(Function(x) x.GetArrivalTime)

                        Case ORDER_TYPE_FLAG.PRIORITY '우선순위에 따라 내림차순 정렬
                            tmpOrderedEnumerable = tmpOrderedEnumerable.ThenByDescending(Function(x) x.GetPriority)

                        Case ORDER_TYPE_FLAG.BURST_TIME '실행시간에 따라 오름차순 정렬
                            tmpOrderedEnumerable = tmpOrderedEnumerable.ThenBy(Function(x) x.GetBurstTime)
                    End Select
                End If
            End If
        Next

        If IsNothing(tmpOrderedEnumerable) Then '정렬이 수행되지 않았으면
            Return srcProcessList
        Else '정렬이 수행되었으면
            retVal = New List(Of Process)(tmpOrderedEnumerable.ToList)
            tmpOrderedEnumerable = Nothing

            Return retVal '정렬 된 리스트 반환
        End If
    End Function
#End Region
End Class