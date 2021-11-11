Public Class CPUArgs
    ' 프로세스 스케줄링을 위한 옵션 값 정의
    '---
    ' https://examradar.com/process-scheduling-algorithm-fcfs-first-come-first-serve-questions-answers/
    ' https://www.studytonight.com/operating-system/highest-response-ratio-next-hrrn-scheduling

#Region "Public"
    Public Enum SCHEDULING_TYPE '스케줄링 타입
        FCFS = 0 'First Come First Service (비선점형) : 선입선출 방식으로 제일 먼저 도착한 프로세스부터 처리
        SJF 'Shortest Job First (비선점형) : 실행시간이 제일 짧은 순으로 처리
        HRN 'Highest Response-Ratio Next (비선점형) : (대기시간+실행시간) / 실행시간으로 우선순위 할당하여 높은 순으로 처리
        PRIORITY_NON_PREEMPTIVE 'Priority-based scheduling (비선점형) : 초기 할당 된 우선순위를 이용하는 고정 우선순위 기반 스케줄링

        SRTN 'Shortest Remaining Time Next (선점형) : 미리 정의 된 Time Quantum 만큼 실행 후 남은 실행시간이 제일 짧은 순으로 처리, SJF의 선점형
        RR 'Round-Robin (선점형) : 미리 정의 된 Time Quantum 만큼 모든 프로세스에 대해 돌아가며 처리
        PRIORITY_PREEMPTIVE 'Priority-based scheduling (선점형) : 초기 할당 된 우선순위를 이용하는 고정 우선순위 기반 스케줄링
    End Enum
    Public Shared _strSchedulingType As String() = {
        "First Come First Service (비선점형)",
        "Shortest Job First (비선점형)",
        "Highest Response-Ratio Next (비선점형)",
        "Priority-based scheduling (비선점형)",
        "Shortest Remaining Time Next (선점형)",
        "Round-Robin (선점형)",
        "Priority-based scheduling (선점형)"
    } '스케줄링 타입 문자열
    ''' <summary>
    ''' 프로세스 스케줄링을 위한 옵션 값 인스턴스 초기화
    ''' </summary>
    Public Sub New()
        Me.Init()
    End Sub
    ''' <summary>
    ''' 초기화 작업 수행
    ''' </summary>
    Public Sub Init()
        Me._timeQuantumForPreemptive = 1
        Me._schedulingType = SCHEDULING_TYPE.FCFS
        Me._ignoreArrivalTime = False
        Me._ignorePriority = False
    End Sub
    Public Property TimeQuantumForPreemptive As Short
        Get
            Return Me._timeQuantumForPreemptive
        End Get
        Set(value As Short)
            Me._timeQuantumForPreemptive = value
        End Set
    End Property

    Public Property SchedulingType As SCHEDULING_TYPE
        Get
            Return Me._schedulingType
        End Get
        Set(value As SCHEDULING_TYPE)
            Me._schedulingType = value
        End Set
    End Property

    Public Property IgnoreArrivalTime As Boolean
        Get
            Return Me._ignoreArrivalTime
        End Get
        Set(value As Boolean)
            Me._ignoreArrivalTime = value
        End Set
    End Property

    Public Property IgnorePriority As Boolean
        Get
            Return Me._ignorePriority
        End Get
        Set(value As Boolean)
            Me._ignorePriority = value
        End Set
    End Property
#End Region

#Region "Private"
    Private _timeQuantumForPreemptive As Short '선점형 스케줄링을 위한 CPU의 자원을 프로세스에 할당 시의 규정 시간량
    Private _schedulingType As SCHEDULING_TYPE '스케줄링 타입
    Private _ignoreArrivalTime As Boolean '모든 프로세스가 동일한 시간에 도착 가정 여부
    Private _ignorePriority As Boolean '모든 프로세스의 초기 우선순위가 동일하다는 가정 여부
#End Region
End Class