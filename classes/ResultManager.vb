Public Class ResultManager
    ' 결과 출력 위한 ResultManager 정의

#Region "Public"
    Public Enum UPDATE_MODE '갱신 모드
        APPEND '새로 추가
        OVERWRITE '마지막으로 추가 된 항목 수정
    End Enum
    ''' <summary>
    ''' ResultManager 공유 요소 초기화
    ''' </summary>
    ''' <param name="srcResultListBox">결과 갱신 시 사용 할 메인 폼의 결과 리스트 박스</param>
    Public Shared Sub Init(ByVal srcResultListBox As ListBox)
        _refResultListBox = srcResultListBox
        ClearResult()
    End Sub
    ''' <summary>
    ''' 결과 리스트 박스에 결과 갱신
    ''' </summary>
    ''' <param name="srcUpdateMode">갱신 모드</param>
    ''' <param name="srcStrData">결과 리스트 박스에 갱신 할 문자열 데이터</param>
    Public Shared Sub UpdateResult(ByVal srcUpdateMode As UPDATE_MODE, ByVal srcStrData As String)
        If IsNothing(_refResultListBox) Then
            Throw New Exception("ResultManager - UpdateResult : not initialized")
        End If

        ' 컨트롤 객체에 대하여 BeginInvoke를 사용하여 비동기적으로 갱신을 수행할 시,
        ' UI 스레드는 일반적인 작업 (컨트롤 그리기 및 사용자와의 UI 상호작용 응답)을 수행하기 전에 갱신을 위한 대리자를 수행한다.
        ' 대리자 대상 (결과 리스트 박스)에 대해 비동기적으로 너무 많은 작업
        ' (ex: RR, timeQuantumForPreemptive 1, 충분한 양의 실행시간, 기존 내용 Overwrite 시) 
        ' 을 수행 할 경우 UI 스레드가 일반적인 작업을 수행하지 못하고, Freezing한다.
        ' ---
        ' BeginInvoke : 출력 결과를 버퍼링하였다가 갱신하여, 너무 자주 갱신하지 않도록 해야 함
        ' Invoke : 동기적으로 UI 스레드에서 결과 리스트 박스에 결과가 갱신 된 후 다음 작업(컨트롤 그리기 및 마우스 응답)을 수행, 단 결과가 갱신되는 속도는 동기식으로 수행하므로 BeginInvoke보다 느림
        ' https://docs.microsoft.com/ko-kr/dotnet/desktop/winforms/controls/how-to-make-thread-safe-calls-to-windows-forms-controls?view=netframeworkdesktop-4.8

        Select Case srcUpdateMode
            Case UPDATE_MODE.APPEND '새로 추가
                If _refResultListBox.InvokeRequired() Then '호출한 스레드가 작업 스레드인 경우 컨트롤을 실제로 호출하는 대리자를 이용하여 동기적으로 수행
                    _refResultListBox.Invoke(Sub() _refResultListBox.Items.Add(srcStrData))
                    _refResultListBox.Invoke(Sub() _refResultListBox.SetSelected(_refResultListBox.Items.Count - 1, True)) '새로 추가 된 항목으로 스크롤 다운

                Else 'UI 스레드(메인 스레드)인 경우 직접 수행
                    _refResultListBox.Items.Add(srcStrData)
                    _refResultListBox.SetSelected(_refResultListBox.Items.Count - 1, True) '새로 추가 된 항목으로 스크롤 다운
                End If

            Case UPDATE_MODE.OVERWRITE '마지막으로 추가 된 항목 수정
                If _refResultListBox.InvokeRequired() Then '호출한 스레드가 작업 스레드인 경우 컨트롤을 실제로 호출하는 대리자를 이용하여 동기적으로 수행
                    _refResultListBox.Invoke(Sub() _refResultListBox.Items(_refResultListBox.Items.Count - 1) = srcStrData)

                Else 'UI 스레드(메인 스레드)인 경우 직접 수행
                    _refResultListBox.Items(_refResultListBox.Items.Count - 1) = srcStrData
                End If
        End Select
    End Sub
    ''' <summary>
    ''' 결과 리스트 박스 초기화
    ''' </summary>
    ''' <param name="dispReady">"Ready" 문자열 출력 여부</param>
    Public Shared Sub ClearResult(Optional ByVal dispReady As Boolean = True)
        If IsNothing(_refResultListBox) Then
            Throw New Exception("ResultManager - UpdateResult : not initialized")
        End If

        If _refResultListBox.InvokeRequired() Then '호출한 스레드가 작업 스레드인 경우 컨트롤을 실제로 호출하는 대리자를 이용하여 동기적으로 수행
            _refResultListBox.Invoke(Sub() _refResultListBox.Items.Clear())

            If dispReady Then
                _refResultListBox.Invoke(Sub() _refResultListBox.Items.Add("Ready"))
            End If

        Else 'UI 스레드(메인 스레드)인 경우 직접 수행
            _refResultListBox.Items.Clear()

            If dispReady Then
                _refResultListBox.Items.Add("Ready")
            End If
        End If
    End Sub
#End Region

#Region "Private"
    Private Shared _refResultListBox As ListBox '메인 폼의 결과 리스트 박스 (참조)
#End Region
End Class
