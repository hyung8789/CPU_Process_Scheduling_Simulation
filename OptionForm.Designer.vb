<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class OptionForm
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OptionForm))
        Me.innerOption_TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.timeQuantumForPreemptive_GroupBox = New System.Windows.Forms.GroupBox()
        Me.timeQuantumForPreemptive_NumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.timeQuantumForPreemptive_Label = New System.Windows.Forms.Label()
        Me.processOption_GroupBox = New System.Windows.Forms.GroupBox()
        Me.ignoreArrivalTime_CheckBox = New System.Windows.Forms.CheckBox()
        Me.ignorePriority_CheckBox = New System.Windows.Forms.CheckBox()
        Me.schedulingAlgorithm_GroupBox = New System.Windows.Forms.GroupBox()
        Me.schedulingAlgorithm_ComboBox = New System.Windows.Forms.ComboBox()
        Me.outerOption_TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.innerButton_Option_TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.init_Button = New System.Windows.Forms.Button()
        Me.ok_Button = New System.Windows.Forms.Button()
        Me.cancel_Button = New System.Windows.Forms.Button()
        Me.version_Label = New System.Windows.Forms.Label()
        Me.innerOption_TableLayoutPanel.SuspendLayout()
        Me.timeQuantumForPreemptive_GroupBox.SuspendLayout()
        CType(Me.timeQuantumForPreemptive_NumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.processOption_GroupBox.SuspendLayout()
        Me.schedulingAlgorithm_GroupBox.SuspendLayout()
        Me.outerOption_TableLayoutPanel.SuspendLayout()
        Me.innerButton_Option_TableLayoutPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'innerOption_TableLayoutPanel
        '
        Me.innerOption_TableLayoutPanel.ColumnCount = 3
        Me.innerOption_TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.innerOption_TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90.0!))
        Me.innerOption_TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.innerOption_TableLayoutPanel.Controls.Add(Me.timeQuantumForPreemptive_GroupBox, 1, 3)
        Me.innerOption_TableLayoutPanel.Controls.Add(Me.processOption_GroupBox, 1, 2)
        Me.innerOption_TableLayoutPanel.Controls.Add(Me.schedulingAlgorithm_GroupBox, 1, 1)
        Me.innerOption_TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.innerOption_TableLayoutPanel.Location = New System.Drawing.Point(3, 3)
        Me.innerOption_TableLayoutPanel.Name = "innerOption_TableLayoutPanel"
        Me.innerOption_TableLayoutPanel.RowCount = 5
        Me.innerOption_TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.innerOption_TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.innerOption_TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.innerOption_TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.innerOption_TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.innerOption_TableLayoutPanel.Size = New System.Drawing.Size(639, 313)
        Me.innerOption_TableLayoutPanel.TabIndex = 0
        '
        'timeQuantumForPreemptive_GroupBox
        '
        Me.timeQuantumForPreemptive_GroupBox.Controls.Add(Me.timeQuantumForPreemptive_NumericUpDown)
        Me.timeQuantumForPreemptive_GroupBox.Controls.Add(Me.timeQuantumForPreemptive_Label)
        Me.timeQuantumForPreemptive_GroupBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.timeQuantumForPreemptive_GroupBox.Location = New System.Drawing.Point(34, 205)
        Me.timeQuantumForPreemptive_GroupBox.Name = "timeQuantumForPreemptive_GroupBox"
        Me.timeQuantumForPreemptive_GroupBox.Size = New System.Drawing.Size(569, 87)
        Me.timeQuantumForPreemptive_GroupBox.TabIndex = 2
        Me.timeQuantumForPreemptive_GroupBox.TabStop = False
        Me.timeQuantumForPreemptive_GroupBox.Text = "선점형 Time Quantum 값"
        '
        'timeQuantumForPreemptive_NumericUpDown
        '
        Me.timeQuantumForPreemptive_NumericUpDown.Location = New System.Drawing.Point(16, 55)
        Me.timeQuantumForPreemptive_NumericUpDown.Name = "timeQuantumForPreemptive_NumericUpDown"
        Me.timeQuantumForPreemptive_NumericUpDown.Size = New System.Drawing.Size(534, 21)
        Me.timeQuantumForPreemptive_NumericUpDown.TabIndex = 1
        Me.timeQuantumForPreemptive_NumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'timeQuantumForPreemptive_Label
        '
        Me.timeQuantumForPreemptive_Label.AutoSize = True
        Me.timeQuantumForPreemptive_Label.Location = New System.Drawing.Point(14, 29)
        Me.timeQuantumForPreemptive_Label.Name = "timeQuantumForPreemptive_Label"
        Me.timeQuantumForPreemptive_Label.Size = New System.Drawing.Size(536, 12)
        Me.timeQuantumForPreemptive_Label.TabIndex = 0
        Me.timeQuantumForPreemptive_Label.Text = "해당 Time Quantum 단위마다 선점형 스케줄링에서 프로세스에 대한 스케줄링을 수행 (1 ~ 32767)"
        '
        'processOption_GroupBox
        '
        Me.processOption_GroupBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.processOption_GroupBox.Controls.Add(Me.ignoreArrivalTime_CheckBox)
        Me.processOption_GroupBox.Controls.Add(Me.ignorePriority_CheckBox)
        Me.processOption_GroupBox.Location = New System.Drawing.Point(34, 96)
        Me.processOption_GroupBox.Name = "processOption_GroupBox"
        Me.processOption_GroupBox.Size = New System.Drawing.Size(569, 103)
        Me.processOption_GroupBox.TabIndex = 1
        Me.processOption_GroupBox.TabStop = False
        Me.processOption_GroupBox.Text = "프로세스 도착시간 && 우선순위"
        '
        'ignoreArrivalTime_CheckBox
        '
        Me.ignoreArrivalTime_CheckBox.AutoSize = True
        Me.ignoreArrivalTime_CheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ignoreArrivalTime_CheckBox.Location = New System.Drawing.Point(16, 63)
        Me.ignoreArrivalTime_CheckBox.Name = "ignoreArrivalTime_CheckBox"
        Me.ignoreArrivalTime_CheckBox.Size = New System.Drawing.Size(379, 16)
        Me.ignoreArrivalTime_CheckBox.TabIndex = 1
        Me.ignoreArrivalTime_CheckBox.Text = "모든 프로세스가 동일한 시간에 도착 가정 (도착시간 입력 값 무시)"
        Me.ignoreArrivalTime_CheckBox.UseVisualStyleBackColor = True
        '
        'ignorePriority_CheckBox
        '
        Me.ignorePriority_CheckBox.AutoSize = True
        Me.ignorePriority_CheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ignorePriority_CheckBox.Location = New System.Drawing.Point(16, 32)
        Me.ignorePriority_CheckBox.Name = "ignorePriority_CheckBox"
        Me.ignorePriority_CheckBox.Size = New System.Drawing.Size(427, 16)
        Me.ignorePriority_CheckBox.TabIndex = 0
        Me.ignorePriority_CheckBox.Text = "모든 프로세스의 초기 우선순위가 동일하다고 가정 (우선순위 입력 값 무시)"
        Me.ignorePriority_CheckBox.UseVisualStyleBackColor = True
        '
        'schedulingAlgorithm_GroupBox
        '
        Me.schedulingAlgorithm_GroupBox.Controls.Add(Me.schedulingAlgorithm_ComboBox)
        Me.schedulingAlgorithm_GroupBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.schedulingAlgorithm_GroupBox.Location = New System.Drawing.Point(34, 18)
        Me.schedulingAlgorithm_GroupBox.Name = "schedulingAlgorithm_GroupBox"
        Me.schedulingAlgorithm_GroupBox.Size = New System.Drawing.Size(569, 72)
        Me.schedulingAlgorithm_GroupBox.TabIndex = 0
        Me.schedulingAlgorithm_GroupBox.TabStop = False
        Me.schedulingAlgorithm_GroupBox.Text = "CPU 프로세스 스케줄링 알고리즘"
        '
        'schedulingAlgorithm_ComboBox
        '
        Me.schedulingAlgorithm_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.schedulingAlgorithm_ComboBox.FormattingEnabled = True
        Me.schedulingAlgorithm_ComboBox.Location = New System.Drawing.Point(16, 32)
        Me.schedulingAlgorithm_ComboBox.Name = "schedulingAlgorithm_ComboBox"
        Me.schedulingAlgorithm_ComboBox.Size = New System.Drawing.Size(534, 20)
        Me.schedulingAlgorithm_ComboBox.TabIndex = 0
        '
        'outerOption_TableLayoutPanel
        '
        Me.outerOption_TableLayoutPanel.ColumnCount = 1
        Me.outerOption_TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.outerOption_TableLayoutPanel.Controls.Add(Me.innerButton_Option_TableLayoutPanel, 0, 1)
        Me.outerOption_TableLayoutPanel.Controls.Add(Me.innerOption_TableLayoutPanel, 0, 0)
        Me.outerOption_TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.outerOption_TableLayoutPanel.Location = New System.Drawing.Point(0, 0)
        Me.outerOption_TableLayoutPanel.Name = "outerOption_TableLayoutPanel"
        Me.outerOption_TableLayoutPanel.RowCount = 2
        Me.outerOption_TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.0!))
        Me.outerOption_TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.outerOption_TableLayoutPanel.Size = New System.Drawing.Size(645, 355)
        Me.outerOption_TableLayoutPanel.TabIndex = 1
        '
        'innerButton_Option_TableLayoutPanel
        '
        Me.innerButton_Option_TableLayoutPanel.ColumnCount = 4
        Me.innerButton_Option_TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.innerButton_Option_TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.innerButton_Option_TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.innerButton_Option_TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.innerButton_Option_TableLayoutPanel.Controls.Add(Me.init_Button, 1, 0)
        Me.innerButton_Option_TableLayoutPanel.Controls.Add(Me.ok_Button, 2, 0)
        Me.innerButton_Option_TableLayoutPanel.Controls.Add(Me.cancel_Button, 3, 0)
        Me.innerButton_Option_TableLayoutPanel.Controls.Add(Me.version_Label, 0, 0)
        Me.innerButton_Option_TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.innerButton_Option_TableLayoutPanel.Location = New System.Drawing.Point(3, 322)
        Me.innerButton_Option_TableLayoutPanel.Name = "innerButton_Option_TableLayoutPanel"
        Me.innerButton_Option_TableLayoutPanel.RowCount = 1
        Me.innerButton_Option_TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.innerButton_Option_TableLayoutPanel.Size = New System.Drawing.Size(639, 30)
        Me.innerButton_Option_TableLayoutPanel.TabIndex = 1
        '
        'init_Button
        '
        Me.init_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.init_Button.Location = New System.Drawing.Point(258, 3)
        Me.init_Button.Name = "init_Button"
        Me.init_Button.Size = New System.Drawing.Size(121, 24)
        Me.init_Button.TabIndex = 6
        Me.init_Button.Text = "초기화"
        Me.init_Button.UseVisualStyleBackColor = True
        '
        'ok_Button
        '
        Me.ok_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ok_Button.Location = New System.Drawing.Point(385, 3)
        Me.ok_Button.Name = "ok_Button"
        Me.ok_Button.Size = New System.Drawing.Size(121, 24)
        Me.ok_Button.TabIndex = 7
        Me.ok_Button.Text = "확인"
        Me.ok_Button.UseVisualStyleBackColor = True
        '
        'cancel_Button
        '
        Me.cancel_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cancel_Button.Location = New System.Drawing.Point(512, 3)
        Me.cancel_Button.Name = "cancel_Button"
        Me.cancel_Button.Size = New System.Drawing.Size(124, 24)
        Me.cancel_Button.TabIndex = 8
        Me.cancel_Button.Text = "취소"
        Me.cancel_Button.UseVisualStyleBackColor = True
        '
        'version_Label
        '
        Me.version_Label.AutoSize = True
        Me.version_Label.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.version_Label.Location = New System.Drawing.Point(3, 18)
        Me.version_Label.Name = "version_Label"
        Me.version_Label.Size = New System.Drawing.Size(249, 12)
        Me.version_Label.TabIndex = 12
        Me.version_Label.Text = "Version will be displayed here"
        '
        'OptionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(645, 355)
        Me.Controls.Add(Me.outerOption_TableLayoutPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "OptionForm"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Option"
        Me.innerOption_TableLayoutPanel.ResumeLayout(False)
        Me.timeQuantumForPreemptive_GroupBox.ResumeLayout(False)
        Me.timeQuantumForPreemptive_GroupBox.PerformLayout()
        CType(Me.timeQuantumForPreemptive_NumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.processOption_GroupBox.ResumeLayout(False)
        Me.processOption_GroupBox.PerformLayout()
        Me.schedulingAlgorithm_GroupBox.ResumeLayout(False)
        Me.outerOption_TableLayoutPanel.ResumeLayout(False)
        Me.innerButton_Option_TableLayoutPanel.ResumeLayout(False)
        Me.innerButton_Option_TableLayoutPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents innerOption_TableLayoutPanel As TableLayoutPanel
    Private WithEvents timeQuantumForPreemptive_GroupBox As GroupBox
    Private WithEvents processOption_GroupBox As GroupBox
    Private WithEvents schedulingAlgorithm_GroupBox As GroupBox
    Private WithEvents outerOption_TableLayoutPanel As TableLayoutPanel
    Private WithEvents innerButton_Option_TableLayoutPanel As TableLayoutPanel
    Private WithEvents init_Button As Button
    Private WithEvents ok_Button As Button
    Private WithEvents cancel_Button As Button
    Private WithEvents version_Label As Label
    Friend WithEvents schedulingAlgorithm_ComboBox As ComboBox
    Friend WithEvents ignoreArrivalTime_CheckBox As CheckBox
    Friend WithEvents ignorePriority_CheckBox As CheckBox
    Friend WithEvents timeQuantumForPreemptive_Label As Label
    Friend WithEvents timeQuantumForPreemptive_NumericUpDown As NumericUpDown
End Class
