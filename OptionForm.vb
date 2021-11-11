Imports CPU_Process_Scheduling_Simulation.CPUArgs

Public Class OptionForm
    ''' <summary>
    ''' 옵션 폼 인스턴스 초기화
    ''' </summary>
    ''' <param name="srcCpuArgs">프로세스 스케줄링을 위한 옵션 값</param>
    Public Sub New(ByVal srcCpuArgs As CPUArgs)
        InitializeComponent()

        Me.version_Label.Text = "v" + Application.ProductVersion '프로그램 버전 할당
        Me._refCpuArgs = srcCpuArgs

        If Me.schedulingAlgorithm_ComboBox.Items.Count = 0 Then '콤보박스에 추가 된 항목이 없으면
            Me.schedulingAlgorithm_ComboBox.Items.AddRange(CPUArgs._strSchedulingType)
        End If

        '유효성 검증을 위한 최소값, 최대값 설정
        Me.timeQuantumForPreemptive_NumericUpDown.Minimum = 1
        Me.timeQuantumForPreemptive_NumericUpDown.Maximum = Short.MaxValue

        Me.Init()
    End Sub

#Region "Private"
    Private _refCpuArgs As CPUArgs '프로세스 스케줄링을 위한 옵션 값 (참조)
    ''' <summary>
    ''' 초기화 작업 수행
    ''' </summary>
    Private Sub Init()
        '기존 옵션 값으로 할당
        Me.schedulingAlgorithm_ComboBox.SelectedIndex = Me._refCpuArgs.SchedulingType
        Me.ignorePriority_CheckBox.Checked = Me._refCpuArgs.IgnorePriority
        Me.ignoreArrivalTime_CheckBox.Checked = Me._refCpuArgs.IgnoreArrivalTime
        Me.timeQuantumForPreemptive_NumericUpDown.Value = Me._refCpuArgs.TimeQuantumForPreemptive
    End Sub
    ''' <summary>
    ''' 입력 값 할당
    ''' </summary>
    Private Sub AllocateInputValues()
        Me._refCpuArgs.SchedulingType = Me.schedulingAlgorithm_ComboBox.SelectedIndex
        Me._refCpuArgs.IgnorePriority = Me.ignorePriority_CheckBox.Checked
        Me._refCpuArgs.IgnoreArrivalTime = Me.ignoreArrivalTime_CheckBox.Checked

        '사용자 입력값에 대해 사용자가 확인 버튼을 누르지 않고 엔터 키를 누를 경우, 값이 그대로 입력되므로 정수로만 입력받기 위해, 강제 형변환 수행
        Me._refCpuArgs.TimeQuantumForPreemptive = CShort(Me.timeQuantumForPreemptive_NumericUpDown.Value)
    End Sub
#Region "폼 이벤트 처리 영역"
    ''' <summary>
    ''' 현재 폼에 대해 키를 처음 누를 때 발생하는 이벤트 처리
    ''' </summary>
    ''' <param name="sender">이벤트를 발생시킨 객체></param>
    ''' <param name="e">이벤트에 대한 인자</param>
    Private Sub OptionForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode() = Keys.Escape Then 'ESC 키 입력
            Me.DialogResult = DialogResult.Cancel

        ElseIf e.KeyCode() = Keys.Enter Then '엔터 키 입력
            Me.AllocateInputValues()
            Me.DialogResult = DialogResult.OK

        Else
            'do nothing
        End If
    End Sub
    ''' <summary>
    ''' 공용 활성 컨트롤화 이벤트 처리
    ''' </summary>
    ''' <param name="sender">이벤트를 발생시킨 객체></param>
    ''' <param name="e">이벤트에 대한 인자</param>
    Private Sub Common_Enter(sender As Object, e As EventArgs) Handles timeQuantumForPreemptive_NumericUpDown.Enter
        If TypeOf sender Is TextBox Then '텍스트박스 타입이면
            Dim textBox As TextBox = CType(sender, TextBox)
            textBox.Select(0, textBox.Text.Length) '시작 위치부터 끝까지 선택

        ElseIf TypeOf sender Is NumericUpDown Then 'numericUpDown 타입이면
            Dim numericUpDown As NumericUpDown = CType(sender, NumericUpDown)
            numericUpDown.Select(0, numericUpDown.Value.ToString.Length) '시작 위치부터 끝까지 선택
        End If
    End Sub
    ''' <summary>
    ''' 스케줄링 알고리즘 콤보박스 선택 항목에 대한 인덱스 변경 이벤트 처리
    ''' </summary>
    ''' <param name="sender">이벤트를 발생시킨 객체></param>
    ''' <param name="e">이벤트에 대한 인자</param>
    Private Sub schedulingAlgorithm_ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles schedulingAlgorithm_ComboBox.SelectedIndexChanged
        Select Case CType(sender, ComboBox).SelectedIndex '스케줄링 알고리즘 콤보박스의 현재 선택 된 항목에 따라
            Case SCHEDULING_TYPE.PRIORITY_NON_PREEMPTIVE, SCHEDULING_TYPE.PRIORITY_PREEMPTIVE '강제적으로 우선순위 입력 값 무시 체크박스 체크 해제 및 비활성화
                '우선순위 기반 스케줄링일 경우 초기 우선순위를 이용하여 스케줄링해야함
                Me.ignorePriority_CheckBox.Checked = False
                Me.ignorePriority_CheckBox.Enabled = False

            Case Else '우선순위 입력 값 무시 체크박스 활성화
                Me.ignorePriority_CheckBox.Enabled = True
        End Select
    End Sub
#End Region

#Region "하단 버튼 이벤트 처리 영역"
    ''' <summary>
    ''' 초기화 버튼 클릭 이벤트 처리
    ''' </summary>
    ''' <param name="sender">이벤트를 발생시킨 객체></param>
    ''' <param name="e">이벤트에 대한 인자</param>
    Private Sub init_Button_Click(sender As Object, e As EventArgs) Handles init_Button.Click
        Me._refCpuArgs.Init() '프로세스 스케줄링을 위한 옵션 값 초기화
        Me.Init() '폼 초기화
    End Sub
    ''' <summary>
    ''' 확인 버튼 클릭 이벤트 처리
    ''' </summary>
    ''' <param name="sender">이벤트를 발생시킨 객체></param>
    ''' <param name="e">이벤트에 대한 인자</param>
    Private Sub ok_Button_Click(sender As Object, e As EventArgs) Handles ok_Button.Click
        Me.AllocateInputValues()
        Me.DialogResult = DialogResult.OK
    End Sub
    ''' <summary>
    ''' 취소 버튼 클릭 이벤트 처리
    ''' </summary>
    ''' <param name="sender">이벤트를 발생시킨 객체></param>
    ''' <param name="e">이벤트에 대한 인자</param>
    Private Sub cancel_Button_Click(sender As Object, e As EventArgs) Handles cancel_Button.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub
#End Region
#End Region
End Class