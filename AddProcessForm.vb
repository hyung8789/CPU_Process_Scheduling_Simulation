Public Class AddProcessForm
#Region "Public"
    Public Shared _listViewItem As ListViewItem '리스트 뷰에 추가 위한 항목
    ''' <summary>
    ''' 프로세스 추가 폼 인스턴스 초기화
    ''' </summary>
    Public Sub New()
        InitializeComponent()

        _listViewItem = Nothing

        '유효성 검증을 위한 최소값, 최대값 설정
        Me.name_TextBox.MaxLength = 259
        Me.arrivalTime_NumericUpDown.Minimum = 0
        Me.arrivalTime_NumericUpDown.Maximum = Short.MaxValue
        Me.burstTime_NumericUpDown.Minimum = 1
        Me.burstTime_NumericUpDown.Maximum = Short.MaxValue
        Me.priority_NumericUpDown.Minimum = 0
        Me.priority_NumericUpDown.Maximum = Short.MaxValue
    End Sub
#End Region

#Region "Private"
    ''' <summary>
    ''' 초기화 작업 수행
    ''' </summary>
    Private Sub Init()
    End Sub
    ''' <summary>
    ''' 리스트 뷰에 추가 위한 항목 생성
    ''' </summary>
    ''' <returns>작업 성공 시 True, 실패 시 False 반환</returns>
    Private Function CreateListViewItem() As Boolean
        If String.IsNullOrEmpty(Me.name_TextBox.Text.Trim()) Then '선행,후행 공백을 제거 한 후 비교
            MessageBox.Show("이름이 입력되지 않았거나 공백입니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        _listViewItem = New ListViewItem()
        _listViewItem.Text = Me.name_TextBox.Text.Trim()
        _listViewItem.Name = Me.name_TextBox.Text.Trim() '고유 한 리스트 뷰 아이템을 식별하기 위한 이름 (키로 비교 위함)

        '사용자 입력값에 대해 사용자가 확인 버튼을 누르지 않고 엔터 키를 누를 경우, 값이 그대로 입력되므로 정수로만 입력받기 위해, 강제 형변환 수행
        _listViewItem.SubItems.Add(CShort(Me.arrivalTime_NumericUpDown.Value)) '도착시간
        _listViewItem.SubItems.Add(CShort(Me.burstTime_NumericUpDown.Value)) '실행시간
        _listViewItem.SubItems.Add(CShort(Me.priority_NumericUpDown.Value)) '우선순위

        Return True
    End Function
#Region "폼 이벤트 처리 영역"
    ''' <summary>
    ''' 현재 폼에 대해 키를 처음 누를 때 발생하는 이벤트 처리
    ''' </summary>
    ''' <param name="sender">이벤트를 발생시킨 객체></param>
    ''' <param name="e">이벤트에 대한 인자</param>
    Private Sub AddProcessForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode() = Keys.Escape Then 'ESC 키 입력
            Me.DialogResult = DialogResult.Cancel

        ElseIf e.KeyCode() = Keys.Enter Then '엔터 키 입력
            If Me.CreateListViewItem() Then '리스트 뷰에 추가 위한 항목 생성 성공 시
                Me.DialogResult = DialogResult.OK
            End If

        Else
            'do nothing
        End If
    End Sub
    ''' <summary>
    ''' 공용 활성 컨트롤화 이벤트 처리
    ''' </summary>
    ''' <param name="sender">이벤트를 발생시킨 객체></param>
    ''' <param name="e">이벤트에 대한 인자</param>
    Private Sub Common_Enter(sender As Object, e As EventArgs) Handles name_TextBox.Enter, priority_NumericUpDown.Enter, burstTime_NumericUpDown.Enter, arrivalTime_NumericUpDown.Enter
        'Debug.WriteLine(sender.GetType().ToString)

        If TypeOf sender Is TextBox Then '텍스트박스 타입이면
            Dim textBox As TextBox = CType(sender, TextBox)
            textBox.Select(0, textBox.Text.Length) '시작 위치부터 끝까지 선택

        ElseIf TypeOf sender Is NumericUpDown Then 'numericUpDown 타입이면
            Dim numericUpDown As NumericUpDown = CType(sender, NumericUpDown)
            numericUpDown.Select(0, numericUpDown.Value.ToString.Length) '시작 위치부터 끝까지 선택
        End If
    End Sub
#End Region
#Region "하단 버튼 이벤트 처리 영역"
    ''' <summary>
    ''' 확인 버튼 클릭 이벤트 처리
    ''' </summary>
    ''' <param name="sender">이벤트를 발생시킨 객체></param>
    ''' <param name="e">이벤트에 대한 인자</param>
    Private Sub ok_Button_Click(sender As Object, e As EventArgs) Handles ok_Button.Click
        If Me.CreateListViewItem() Then '리스트 뷰에 추가 위한 항목 생성 성공 시
            Me.DialogResult = DialogResult.OK
        End If
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