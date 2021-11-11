<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddProcessForm
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기에서는 수정하지 마세요.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.innerAddProcess_TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.processInfoInput_GroupBox = New System.Windows.Forms.GroupBox()
        Me.priority_NumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.burstTime_NumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.arrivalTime_NumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.name_TextBox = New System.Windows.Forms.TextBox()
        Me.priority_Label = New System.Windows.Forms.Label()
        Me.burstTime_Label = New System.Windows.Forms.Label()
        Me.arrivalTime_Label = New System.Windows.Forms.Label()
        Me.name_Label = New System.Windows.Forms.Label()
        Me.outerAddProcess_TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.innerButton_Option_TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.ok_Button = New System.Windows.Forms.Button()
        Me.cancel_Button = New System.Windows.Forms.Button()
        Me.innerAddProcess_TableLayoutPanel.SuspendLayout()
        Me.processInfoInput_GroupBox.SuspendLayout()
        CType(Me.priority_NumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.burstTime_NumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.arrivalTime_NumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.outerAddProcess_TableLayoutPanel.SuspendLayout()
        Me.innerButton_Option_TableLayoutPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'innerAddProcess_TableLayoutPanel
        '
        Me.innerAddProcess_TableLayoutPanel.ColumnCount = 3
        Me.innerAddProcess_TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.innerAddProcess_TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90.0!))
        Me.innerAddProcess_TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.innerAddProcess_TableLayoutPanel.Controls.Add(Me.processInfoInput_GroupBox, 1, 1)
        Me.innerAddProcess_TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.innerAddProcess_TableLayoutPanel.Location = New System.Drawing.Point(3, 3)
        Me.innerAddProcess_TableLayoutPanel.Name = "innerAddProcess_TableLayoutPanel"
        Me.innerAddProcess_TableLayoutPanel.RowCount = 3
        Me.innerAddProcess_TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.innerAddProcess_TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.0!))
        Me.innerAddProcess_TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.innerAddProcess_TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.innerAddProcess_TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.innerAddProcess_TableLayoutPanel.Size = New System.Drawing.Size(577, 291)
        Me.innerAddProcess_TableLayoutPanel.TabIndex = 0
        '
        'processInfoInput_GroupBox
        '
        Me.processInfoInput_GroupBox.Controls.Add(Me.priority_NumericUpDown)
        Me.processInfoInput_GroupBox.Controls.Add(Me.burstTime_NumericUpDown)
        Me.processInfoInput_GroupBox.Controls.Add(Me.arrivalTime_NumericUpDown)
        Me.processInfoInput_GroupBox.Controls.Add(Me.name_TextBox)
        Me.processInfoInput_GroupBox.Controls.Add(Me.priority_Label)
        Me.processInfoInput_GroupBox.Controls.Add(Me.burstTime_Label)
        Me.processInfoInput_GroupBox.Controls.Add(Me.arrivalTime_Label)
        Me.processInfoInput_GroupBox.Controls.Add(Me.name_Label)
        Me.processInfoInput_GroupBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.processInfoInput_GroupBox.Location = New System.Drawing.Point(31, 17)
        Me.processInfoInput_GroupBox.Name = "processInfoInput_GroupBox"
        Me.processInfoInput_GroupBox.Size = New System.Drawing.Size(513, 255)
        Me.processInfoInput_GroupBox.TabIndex = 0
        Me.processInfoInput_GroupBox.TabStop = False
        Me.processInfoInput_GroupBox.Text = "프로세스 정보 입력"
        '
        'priority_NumericUpDown
        '
        Me.priority_NumericUpDown.Location = New System.Drawing.Point(8, 211)
        Me.priority_NumericUpDown.Name = "priority_NumericUpDown"
        Me.priority_NumericUpDown.Size = New System.Drawing.Size(492, 21)
        Me.priority_NumericUpDown.TabIndex = 7
        Me.priority_NumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'burstTime_NumericUpDown
        '
        Me.burstTime_NumericUpDown.Location = New System.Drawing.Point(8, 152)
        Me.burstTime_NumericUpDown.Name = "burstTime_NumericUpDown"
        Me.burstTime_NumericUpDown.Size = New System.Drawing.Size(492, 21)
        Me.burstTime_NumericUpDown.TabIndex = 6
        Me.burstTime_NumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'arrivalTime_NumericUpDown
        '
        Me.arrivalTime_NumericUpDown.Location = New System.Drawing.Point(8, 96)
        Me.arrivalTime_NumericUpDown.Name = "arrivalTime_NumericUpDown"
        Me.arrivalTime_NumericUpDown.Size = New System.Drawing.Size(492, 21)
        Me.arrivalTime_NumericUpDown.TabIndex = 5
        Me.arrivalTime_NumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'name_TextBox
        '
        Me.name_TextBox.Location = New System.Drawing.Point(8, 43)
        Me.name_TextBox.Name = "name_TextBox"
        Me.name_TextBox.Size = New System.Drawing.Size(492, 21)
        Me.name_TextBox.TabIndex = 4
        '
        'priority_Label
        '
        Me.priority_Label.AutoSize = True
        Me.priority_Label.Location = New System.Drawing.Point(6, 196)
        Me.priority_Label.Name = "priority_Label"
        Me.priority_Label.Size = New System.Drawing.Size(323, 12)
        Me.priority_Label.TabIndex = 3
        Me.priority_Label.Text = "우선순위 (Priority, 0 ~ 32767) : 높을수록 실행 우선권 획득"
        '
        'burstTime_Label
        '
        Me.burstTime_Label.AutoSize = True
        Me.burstTime_Label.Location = New System.Drawing.Point(6, 137)
        Me.burstTime_Label.Name = "burstTime_Label"
        Me.burstTime_Label.Size = New System.Drawing.Size(474, 12)
        Me.burstTime_Label.TabIndex = 2
        Me.burstTime_Label.Text = "실행시간 (Burst Time, 1 ~ 32767) : 프로세스가 자신의 작업을 수행하는데 걸리는 시간"
        '
        'arrivalTime_Label
        '
        Me.arrivalTime_Label.AutoSize = True
        Me.arrivalTime_Label.Location = New System.Drawing.Point(6, 81)
        Me.arrivalTime_Label.Name = "arrivalTime_Label"
        Me.arrivalTime_Label.Size = New System.Drawing.Size(348, 12)
        Me.arrivalTime_Label.TabIndex = 1
        Me.arrivalTime_Label.Text = "도착시간 (Arrival Time, 0 ~ 32767) : 프로세스가 도착하는 시간"
        '
        'name_Label
        '
        Me.name_Label.AutoSize = True
        Me.name_Label.Location = New System.Drawing.Point(6, 28)
        Me.name_Label.Name = "name_Label"
        Me.name_Label.Size = New System.Drawing.Size(494, 12)
        Me.name_Label.TabIndex = 0
        Me.name_Label.Text = "이름 (Process Name, 최소 1글자, 공백 및 중복 이름 허용 안함) : 프로세스의 고유한 이름"
        '
        'outerAddProcess_TableLayoutPanel
        '
        Me.outerAddProcess_TableLayoutPanel.ColumnCount = 1
        Me.outerAddProcess_TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.outerAddProcess_TableLayoutPanel.Controls.Add(Me.innerButton_Option_TableLayoutPanel, 0, 1)
        Me.outerAddProcess_TableLayoutPanel.Controls.Add(Me.innerAddProcess_TableLayoutPanel, 0, 0)
        Me.outerAddProcess_TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.outerAddProcess_TableLayoutPanel.Location = New System.Drawing.Point(0, 0)
        Me.outerAddProcess_TableLayoutPanel.Name = "outerAddProcess_TableLayoutPanel"
        Me.outerAddProcess_TableLayoutPanel.RowCount = 2
        Me.outerAddProcess_TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.0!))
        Me.outerAddProcess_TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.outerAddProcess_TableLayoutPanel.Size = New System.Drawing.Size(583, 331)
        Me.outerAddProcess_TableLayoutPanel.TabIndex = 2
        '
        'innerButton_Option_TableLayoutPanel
        '
        Me.innerButton_Option_TableLayoutPanel.ColumnCount = 3
        Me.innerButton_Option_TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.innerButton_Option_TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.innerButton_Option_TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.innerButton_Option_TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.innerButton_Option_TableLayoutPanel.Controls.Add(Me.ok_Button, 1, 0)
        Me.innerButton_Option_TableLayoutPanel.Controls.Add(Me.cancel_Button, 2, 0)
        Me.innerButton_Option_TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.innerButton_Option_TableLayoutPanel.Location = New System.Drawing.Point(3, 300)
        Me.innerButton_Option_TableLayoutPanel.Name = "innerButton_Option_TableLayoutPanel"
        Me.innerButton_Option_TableLayoutPanel.RowCount = 1
        Me.innerButton_Option_TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.innerButton_Option_TableLayoutPanel.Size = New System.Drawing.Size(577, 28)
        Me.innerButton_Option_TableLayoutPanel.TabIndex = 1
        '
        'ok_Button
        '
        Me.ok_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ok_Button.Location = New System.Drawing.Point(349, 3)
        Me.ok_Button.Name = "ok_Button"
        Me.ok_Button.Size = New System.Drawing.Size(109, 22)
        Me.ok_Button.TabIndex = 7
        Me.ok_Button.Text = "확인"
        Me.ok_Button.UseVisualStyleBackColor = True
        '
        'cancel_Button
        '
        Me.cancel_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cancel_Button.Location = New System.Drawing.Point(464, 3)
        Me.cancel_Button.Name = "cancel_Button"
        Me.cancel_Button.Size = New System.Drawing.Size(110, 22)
        Me.cancel_Button.TabIndex = 8
        Me.cancel_Button.Text = "취소"
        Me.cancel_Button.UseVisualStyleBackColor = True
        '
        'AddProcessForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(583, 331)
        Me.Controls.Add(Me.outerAddProcess_TableLayoutPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AddProcessForm"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "프로세스 추가"
        Me.innerAddProcess_TableLayoutPanel.ResumeLayout(False)
        Me.processInfoInput_GroupBox.ResumeLayout(False)
        Me.processInfoInput_GroupBox.PerformLayout()
        CType(Me.priority_NumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.burstTime_NumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.arrivalTime_NumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.outerAddProcess_TableLayoutPanel.ResumeLayout(False)
        Me.innerButton_Option_TableLayoutPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents innerAddProcess_TableLayoutPanel As TableLayoutPanel
    Private WithEvents processInfoInput_GroupBox As GroupBox
    Private WithEvents outerAddProcess_TableLayoutPanel As TableLayoutPanel
    Private WithEvents innerButton_Option_TableLayoutPanel As TableLayoutPanel
    Private WithEvents ok_Button As Button
    Private WithEvents cancel_Button As Button
    Friend WithEvents priority_NumericUpDown As NumericUpDown
    Friend WithEvents burstTime_NumericUpDown As NumericUpDown
    Friend WithEvents arrivalTime_NumericUpDown As NumericUpDown
    Friend WithEvents name_TextBox As TextBox
    Friend WithEvents priority_Label As Label
    Friend WithEvents burstTime_Label As Label
    Friend WithEvents arrivalTime_Label As Label
    Friend WithEvents name_Label As Label
End Class
