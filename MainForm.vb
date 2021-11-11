Imports System.ComponentModel
Imports System.IO
Imports System.Resources

Public Class MainForm
#Region "Public"
    ''' <summary>
    ''' 메인 폼 인스턴스 초기화
    ''' </summary>
    Public Sub New()
        InitializeComponent()

        Me._cpu = New CPU()
        ResultManager.Init(Me.result_ListBox)
    End Sub
#End Region

#Region "Private"
    Private _cpu As CPU '프로세스 스케줄링 작업이 수행 되어 프로세스가 수행 될 CPU

    Private _titleBarMouseClicked As Boolean = False '타이틀바 마우스 클릭 여부
    Private _currentMainFormtPos As Point '메인 폼 현재 위치
    ''' <summary>
    ''' 초기화 작업 수행
    ''' </summary>
    Private Sub Init()
    End Sub

#Region "타이틀바 이벤트 처리 영역"
    ''' <summary>
    ''' 타이틀바 패널 마우스 단추 클릭 이벤트 처리
    ''' </summary>
    ''' <param name="sender">이벤트를 발생시킨 객체 (ex : 버튼)</param>
    ''' <param name="e">이벤트에 대한 인자</param>
    Private Sub titleBar_Panel_MouseDown(sender As Object, e As MouseEventArgs) Handles titleBar_Panel.MouseDown
        Me._titleBarMouseClicked = True
        Me._currentMainFormtPos = New Point(e.X, e.Y) ' 마우스 단추 클릭 시점의 메인 폼 현재 위치 저장 
    End Sub
    ''' <summary>
    ''' 타이틀바 패널 위에서 마우스 이동 이벤트 처리
    ''' </summary>
    ''' <param name="sender">이벤트를 발생시킨 객체></param>
    ''' <param name="e">이벤트에 대한 인자</param>
    Private Sub titleBar_Panel_MouseMove(sender As Object, e As MouseEventArgs) Handles titleBar_Panel.MouseMove
        If Me._titleBarMouseClicked And e.Button = MouseButtons.Left Then '왼쪽 마우스 단추가 눌린 상태에서 이동되었으면
            Me.Location = New Point(Me.Left - (Me._currentMainFormtPos.X - e.X), Me.Top - (Me._currentMainFormtPos.Y - e.Y)) '현재 폼의 좌표를 이동
        End If
    End Sub
    ''' <summary>
    ''' 타이틀바 패널 위에서 마우스 클릭 해제 이벤트 처리
    ''' </summary>
    ''' <param name="sender">이벤트를 발생시킨 객체></param>
    ''' <param name="e">이벤트에 대한 인자</param>
    Private Sub titleBar_Panel_MouseUp(sender As Object, e As MouseEventArgs) Handles titleBar_Panel.MouseUp
        Me._titleBarMouseClicked = False '클릭 해제 시 이동하지 않음
    End Sub
#End Region
    ''' <summary>
    ''' 도움말 버튼 클릭 이벤트 처리
    ''' </summary>
    ''' <param name="sender">이벤트를 발생시킨 객체></param>
    ''' <param name="e">이벤트에 대한 인자</param>
    Private Sub help_Button_Click(sender As Object, e As EventArgs) Handles help_Button.Click
        System.Diagnostics.Process.Start("https://github.com/hyung8789/CPU_Process_Scheduling_Simulation")
    End Sub
    ''' <summary>
    ''' 최소화 버튼 클릭 이벤트 처리
    ''' </summary>
    ''' <param name="sender">이벤트를 발생시킨 객체></param>
    ''' <param name="e">이벤트에 대한 인자</param>
    Private Sub minimize_Button_Click(sender As Object, e As EventArgs) Handles minimize_Button.Click
        Me.WindowState = FormWindowState.Minimized '현재 폼 최소화
    End Sub
#Region "프로세스 그룹 내의 버튼 이벤트 처리 영역"
    ''' <summary>
    ''' 실행 버튼 클릭 이벤트 처리
    ''' </summary>
    ''' <param name="sender">이벤트를 발생시킨 객체></param>
    ''' <param name="e">이벤트에 대한 인자</param>
    Private Sub run_Button_Click(sender As Object, e As EventArgs) Handles run_Button.Click
        If Me.processScheduling_BackgroundWorker.IsBusy Then '프로세스 스케줄링을 위한 BackgroundWorker가 작업 중이면
            Return
        End If

        If Me.process_ListView.Items.Count() > 0 Then
            Dim processList As List(Of Process) = New List(Of Process) '프로세스 목록
            Debug.WriteLine("processList Gen : " + System.GC.GetGeneration(processList).ToString)

            For Each item As ListViewItem In Me.process_ListView.Items '입력 받은 프로세스 리스트 뷰의 각 프로세스들에 대하여
                Dim process As Process = New Process() '프로세스

                '프로세스명, 도착시간, 실행시간, 우선순위 순으로 리스트 박스에 입력되어 있으므로, 프로세스 초기화 시 해당 순서로 입력
                process.Init(item.Name,
                             srcArrivalTime:=CType(item.SubItems(1).Text, Short),
                             srcBurstTime:=CType(item.SubItems(2).Text, Short),
                             srcPriority:=CType(item.SubItems(3).Text, Short))

                processList.Add(process) '프로세스 목록에 추가
            Next

            Me.LoggingProcessList()
            Me._cpu.Init(processList)

            ' https://docs.microsoft.com/ko-kr/dotnet/api/system.componentmodel.backgroundworker?view=netframework-4.8&f1url=%3FappId%3DDev16IDEF1%26l%3DKO-KR%26k%3Dk(System.ComponentModel.BackgroundWorker);k(TargetFrameworkMoniker-.NETFramework,Version%253Dv4.8);k(DevLang-VB)%26rd%3Dtrue
            ' https://docs.microsoft.com/ko-kr/dotnet/standard/events/
            Me.processScheduling_BackgroundWorker.RunWorkerAsync()
        End If
    End Sub
#Region "BackcgroundWorker 이벤트 처리 영역"
    ''' <summary>
    ''' 프로세스 스케줄링을 위한 BackgroundWorker가 별도의 스레드에서 비동기적으로 실행 할 작업 
    ''' </summary>
    ''' <param name="sender">이벤트를 발생시킨 객체></param>
    ''' <param name="e">이벤트에 대한 인자</param>
    Private Sub processScheduling_BackgroundWorker_DoWork(sender As Object, e As DoWorkEventArgs) Handles processScheduling_BackgroundWorker.DoWork
        ResultManager.ClearResult(False)
        Me._cpu.DoProcessSchedulingJob()
    End Sub
    ''' <summary>
    ''' 프로세스 스케줄링을 위한 BackgroundWorker가 완료(성공, 실패 또는 취소)되었을 때 발생
    ''' </summary>
    ''' <param name="sender">이벤트를 발생시킨 객체></param>
    ''' <param name="e">이벤트에 대한 인자</param>
    Private Sub processScheduling_BackgroundWorker_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles processScheduling_BackgroundWorker.RunWorkerCompleted
        If Not IsNothing(e.Error) Then '작업 중 발생한 오류가 존재 시
            MessageBox.Show(e.Error.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        ' https://docs.microsoft.com/ko-kr/dotnet/standard/garbage-collection/fundamentals
        System.GC.Collect() '전체 세대에 대한 강제 가비지 컬렉션 실시
        For i = 0 To 2
            Debug.WriteLine("GC Gen " + i.ToString + " CollectionCount : " + System.GC.CollectionCount(i).ToString)
        Next
    End Sub
#End Region
    ''' <summary>
    ''' 옵션 버튼 클릭 이벤트 처리
    ''' </summary>
    ''' <param name="sender">이벤트를 발생시킨 객체></param>
    ''' <param name="e">이벤트에 대한 인자</param>
    Private Sub option_Button_Click(sender As Object, e As EventArgs) Handles option_Button.Click
        If Me.processScheduling_BackgroundWorker.IsBusy Then '프로세스 스케줄링을 위한 BackgroundWorker가 작업 중이면
            Return
        End If

        Dim optionForm = New OptionForm(Me._cpu._cpuArgs)
        optionForm.ShowDialog()
        optionForm.Dispose()
    End Sub
    ''' <summary>
    ''' 프로세스 추가 버튼 클릭 이벤트 처리
    ''' </summary>
    ''' <param name="sender">이벤트를 발생시킨 객체></param>
    ''' <param name="e">이벤트에 대한 인자</param>
    Private Sub addProcess_Button_Click(sender As Object, e As EventArgs) Handles addProcess_Button.Click
        If Me.process_ListView.Items.Count() >= Short.MaxValue Then '최대 프로세스 개수를 초과하여 리스트에 추가 시도 할 경우
            MessageBox.Show("프로세스는 최대 " + Short.MaxValue.ToString + "개만 만들 수 있습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim addProcessForm = New AddProcessForm()
        If addProcessForm.ShowDialog() = DialogResult.OK Then '유효성 검사 후 프로세스 리스트 뷰에 추가
            If Me.process_ListView.Items.ContainsKey(AddProcessForm._listViewItem.Name) Then '이미 존재하는 프로세스 이름일 경우
                MessageBox.Show("이미 존재하는 프로세스 이름입니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Me.process_ListView.Items.Add(AddProcessForm._listViewItem)
            End If
        End If

        addProcessForm.Dispose()
    End Sub
    ''' <summary>
    ''' 선택 된 프로세스 제거 버튼 클릭 이벤트 처리
    ''' </summary>
    ''' <param name="sender">이벤트를 발생시킨 객체></param>
    ''' <param name="e">이벤트에 대한 인자</param>
    Private Sub removeProcess_Button_Click(sender As Object, e As EventArgs) Handles removeProcess_Button.Click
        For Each selectedItem In Me.process_ListView.SelectedItems() '선택 된 항목에 대하여 제거
            Me.process_ListView.Items.Remove(selectedItem)
        Next
    End Sub
    ''' <summary>
    ''' 프로세스 목록 초기화 버튼 클릭 이벤트 처리
    ''' </summary>
    ''' <param name="sender">이벤트를 발생시킨 객체></param>
    ''' <param name="e">이벤트에 대한 인자</param>
    Private Sub clearProcess_Button_Click(sender As Object, e As EventArgs) Handles clearProcess_Button.Click
        Me.process_ListView.Items.Clear()
    End Sub
    ''' <summary>
    ''' 종료 버튼 클릭 이벤트 처리
    ''' </summary>
    ''' <param name="sender">이벤트를 발생시킨 객체></param>
    ''' <param name="e">이벤트에 대한 인자</param>
    Private Sub exit_Button_Click(sender As Object, e As EventArgs) Handles exit_Button.Click
        Me.Close() '현재 폼 닫기
    End Sub
#End Region

#Region "실행 결과 그룹 내의 버튼 이벤트 처리 영역"
    ''' <summary>
    ''' 클립보드에 모두 복사 버튼 클릭 이벤트 처리
    ''' </summary>
    ''' <param name="sender">이벤트를 발생시킨 객체></param>
    ''' <param name="e">이벤트에 대한 인자</param>
    Private Sub copyResult_Button_Click(sender As Object, e As EventArgs) Handles copyResult_Button.Click
        If Me.processScheduling_BackgroundWorker.IsBusy Then '프로세스 스케줄링을 위한 BackgroundWorker가 작업 중이면
            Return
        End If

        Dim strResult As String = String.Empty '결과 문자열

        For Each item In Me.result_ListBox.Items '결과 리스트 박스의 항목들 출력
            strResult += (item.ToString + System.Environment.NewLine)
        Next

        strResult += System.Environment.NewLine

        Try
            Clipboard.SetText(strResult)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    ''' <summary>
    ''' 메모장으로 결과 보기 버튼 클릭 이벤트 처리
    ''' </summary>
    ''' <param name="sender">이벤트를 발생시킨 객체></param>
    ''' <param name="e">이벤트에 대한 인자</param>
    Private Sub viewResultWithNotepad_Button_Click(sender As Object, e As EventArgs) Handles viewResultWithNotepad_Button.Click
        If Me.processScheduling_BackgroundWorker.IsBusy Then '프로세스 스케줄링을 위한 BackgroundWorker가 작업 중이면
            Return
        End If

        ' https://docs.microsoft.com/en-us/dotnet/visual-basic/developing-apps/programming/drives-directories-files/how-to-write-text-to-files
        ' https://docs.microsoft.com/en-us/dotnet/api/system.io.streamwriter?view=net-5.0

        Dim sw As StreamWriter = Nothing
        Dim resultFileFullPath As String = My.Computer.FileSystem.CurrentDirectory + "/result.log" '출력 파일 전체 경로

        Try
            sw = New StreamWriter(resultFileFullPath, False)
            For Each item In Me.result_ListBox.Items '결과 리스트 박스의 항목들 출력
                sw.WriteLine(item.ToString)
            Next

            sw.WriteLine()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sw.Flush()
            sw.Close()
        End Try

        Try
            System.Diagnostics.Process.Start("notepad.exe", resultFileFullPath) '메모장으로 열기
        Catch ex As Exception
            MessageBox.Show(ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    ''' <summary>
    ''' 실행 결과 초기화 버튼 클릭 이벤트 처리
    ''' </summary>
    ''' <param name="sender">이벤트를 발생시킨 객체></param>
    ''' <param name="e">이벤트에 대한 인자</param>
    Private Sub clearResult_Button_Click(sender As Object, e As EventArgs) Handles clearResult_Button.Click
        If Me.processScheduling_BackgroundWorker.IsBusy Then '프로세스 스케줄링을 위한 BackgroundWorker가 작업 중이면
            Return
        End If

        ResultManager.ClearResult(True)
    End Sub
#End Region
#Region "기타 이벤트 처리 영역"
    ''' <summary>
    ''' 링크 라벨에 대한 클릭 이벤트 처리
    ''' </summary>
    ''' <param name="sender">이벤트를 발생시킨 객체></param>
    ''' <param name="e">이벤트에 대한 인자</param>
    Private Sub about_LinkLabel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles about_LinkLabel.LinkClicked
        System.Diagnostics.Process.Start("https://github.com/hyung8789")
    End Sub
    ''' <summary>
    ''' 사용자가 입력 한 프로세스 목록 로깅
    ''' </summary>
    Public Sub LoggingProcessList()
        Dim sw As StreamWriter = Nothing
        Dim logFileFullPath As String = My.Computer.FileSystem.CurrentDirectory + "/plist.log" '

        Try
            sw = New StreamWriter(logFileFullPath, False)
            For Each item As ListViewItem In Me.process_ListView.Items '입력 받은 프로세스 리스트 뷰의 각 프로세스들에 대하여
                sw.WriteLine(item.Name + " | 도착시간 : " + item.SubItems(1).Text + " | 실행시간 : " + item.SubItems(2).Text + " | 우선순위 : " + item.SubItems(3).Text)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sw.Flush()
            sw.Close()
        End Try
    End Sub
#End Region
#End Region
End Class
