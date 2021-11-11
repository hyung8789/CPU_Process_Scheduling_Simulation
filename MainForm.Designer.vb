<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.outerMain_TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.about_LinkLabel = New System.Windows.Forms.LinkLabel()
        Me.process_GroupBox = New System.Windows.Forms.GroupBox()
        Me.innerProcessGroupBox_TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.process_ListView = New System.Windows.Forms.ListView()
        Me.name_ColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.arrivalTime_ColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.burstTime_ColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.priority_ColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.innerButton_ProcessGroupBox_TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.exit_Button = New System.Windows.Forms.Button()
        Me.clearProcess_Button = New System.Windows.Forms.Button()
        Me.removeProcess_Button = New System.Windows.Forms.Button()
        Me.addProcess_Button = New System.Windows.Forms.Button()
        Me.option_Button = New System.Windows.Forms.Button()
        Me.run_Button = New System.Windows.Forms.Button()
        Me.result_GroupBox = New System.Windows.Forms.GroupBox()
        Me.innerResultGroupBox_TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.result_ListBox = New System.Windows.Forms.ListBox()
        Me.innerButton_ResultGroupBox_TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.viewResultWithNotepad_Button = New System.Windows.Forms.Button()
        Me.clearResult_Button = New System.Windows.Forms.Button()
        Me.copyResult_Button = New System.Windows.Forms.Button()
        Me.titleBar_Panel = New System.Windows.Forms.Panel()
        Me.help_Button = New System.Windows.Forms.Button()
        Me.minimize_Button = New System.Windows.Forms.Button()
        Me.logo_PictureBox = New System.Windows.Forms.PictureBox()
        Me.processScheduling_BackgroundWorker = New System.ComponentModel.BackgroundWorker()
        Me.outerMain_TableLayoutPanel.SuspendLayout()
        Me.process_GroupBox.SuspendLayout()
        Me.innerProcessGroupBox_TableLayoutPanel.SuspendLayout()
        Me.innerButton_ProcessGroupBox_TableLayoutPanel.SuspendLayout()
        Me.result_GroupBox.SuspendLayout()
        Me.innerResultGroupBox_TableLayoutPanel.SuspendLayout()
        Me.innerButton_ResultGroupBox_TableLayoutPanel.SuspendLayout()
        Me.titleBar_Panel.SuspendLayout()
        CType(Me.logo_PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'outerMain_TableLayoutPanel
        '
        Me.outerMain_TableLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble
        Me.outerMain_TableLayoutPanel.ColumnCount = 1
        Me.outerMain_TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.outerMain_TableLayoutPanel.Controls.Add(Me.about_LinkLabel, 0, 4)
        Me.outerMain_TableLayoutPanel.Controls.Add(Me.process_GroupBox, 0, 2)
        Me.outerMain_TableLayoutPanel.Controls.Add(Me.result_GroupBox, 0, 3)
        Me.outerMain_TableLayoutPanel.Controls.Add(Me.titleBar_Panel, 0, 0)
        Me.outerMain_TableLayoutPanel.Controls.Add(Me.logo_PictureBox, 0, 1)
        Me.outerMain_TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.outerMain_TableLayoutPanel.Location = New System.Drawing.Point(0, 0)
        Me.outerMain_TableLayoutPanel.Name = "outerMain_TableLayoutPanel"
        Me.outerMain_TableLayoutPanel.RowCount = 5
        Me.outerMain_TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.outerMain_TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.outerMain_TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.0!))
        Me.outerMain_TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.outerMain_TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.outerMain_TableLayoutPanel.Size = New System.Drawing.Size(780, 537)
        Me.outerMain_TableLayoutPanel.TabIndex = 0
        '
        'about_LinkLabel
        '
        Me.about_LinkLabel.AutoSize = True
        Me.about_LinkLabel.Dock = System.Windows.Forms.DockStyle.Right
        Me.about_LinkLabel.LinkColor = System.Drawing.Color.White
        Me.about_LinkLabel.Location = New System.Drawing.Point(598, 505)
        Me.about_LinkLabel.Name = "about_LinkLabel"
        Me.about_LinkLabel.Size = New System.Drawing.Size(176, 29)
        Me.about_LinkLabel.TabIndex = 0
        Me.about_LinkLabel.TabStop = True
        Me.about_LinkLabel.Text = "https://github.com/hyung8789"
        Me.about_LinkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'process_GroupBox
        '
        Me.process_GroupBox.Controls.Add(Me.innerProcessGroupBox_TableLayoutPanel)
        Me.process_GroupBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.process_GroupBox.ForeColor = System.Drawing.Color.White
        Me.process_GroupBox.Location = New System.Drawing.Point(6, 114)
        Me.process_GroupBox.Name = "process_GroupBox"
        Me.process_GroupBox.Size = New System.Drawing.Size(768, 227)
        Me.process_GroupBox.TabIndex = 1
        Me.process_GroupBox.TabStop = False
        Me.process_GroupBox.Text = "프로세스 목록 및 입력"
        '
        'innerProcessGroupBox_TableLayoutPanel
        '
        Me.innerProcessGroupBox_TableLayoutPanel.ColumnCount = 2
        Me.innerProcessGroupBox_TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.0!))
        Me.innerProcessGroupBox_TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.innerProcessGroupBox_TableLayoutPanel.Controls.Add(Me.process_ListView, 0, 0)
        Me.innerProcessGroupBox_TableLayoutPanel.Controls.Add(Me.innerButton_ProcessGroupBox_TableLayoutPanel, 1, 0)
        Me.innerProcessGroupBox_TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.innerProcessGroupBox_TableLayoutPanel.Location = New System.Drawing.Point(3, 17)
        Me.innerProcessGroupBox_TableLayoutPanel.Name = "innerProcessGroupBox_TableLayoutPanel"
        Me.innerProcessGroupBox_TableLayoutPanel.RowCount = 1
        Me.innerProcessGroupBox_TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.innerProcessGroupBox_TableLayoutPanel.Size = New System.Drawing.Size(762, 207)
        Me.innerProcessGroupBox_TableLayoutPanel.TabIndex = 0
        '
        'process_ListView
        '
        Me.process_ListView.AutoArrange = False
        Me.process_ListView.BackColor = System.Drawing.Color.Black
        Me.process_ListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.name_ColumnHeader, Me.arrivalTime_ColumnHeader, Me.burstTime_ColumnHeader, Me.priority_ColumnHeader})
        Me.process_ListView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.process_ListView.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.process_ListView.ForeColor = System.Drawing.Color.Lime
        Me.process_ListView.FullRowSelect = True
        Me.process_ListView.HideSelection = False
        Me.process_ListView.Location = New System.Drawing.Point(3, 3)
        Me.process_ListView.Name = "process_ListView"
        Me.process_ListView.Size = New System.Drawing.Size(603, 201)
        Me.process_ListView.TabIndex = 1
        Me.process_ListView.UseCompatibleStateImageBehavior = False
        Me.process_ListView.View = System.Windows.Forms.View.Details
        '
        'name_ColumnHeader
        '
        Me.name_ColumnHeader.Text = "프로세스명 (Process Name)"
        Me.name_ColumnHeader.Width = 180
        '
        'arrivalTime_ColumnHeader
        '
        Me.arrivalTime_ColumnHeader.Text = "도착시간 (Arrival Time)"
        Me.arrivalTime_ColumnHeader.Width = 150
        '
        'burstTime_ColumnHeader
        '
        Me.burstTime_ColumnHeader.Text = "실행시간 (Burst Time)"
        Me.burstTime_ColumnHeader.Width = 150
        '
        'priority_ColumnHeader
        '
        Me.priority_ColumnHeader.Text = "우선순위 (Priority)"
        Me.priority_ColumnHeader.Width = 150
        '
        'innerButton_ProcessGroupBox_TableLayoutPanel
        '
        Me.innerButton_ProcessGroupBox_TableLayoutPanel.ColumnCount = 1
        Me.innerButton_ProcessGroupBox_TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.innerButton_ProcessGroupBox_TableLayoutPanel.Controls.Add(Me.exit_Button, 0, 5)
        Me.innerButton_ProcessGroupBox_TableLayoutPanel.Controls.Add(Me.clearProcess_Button, 0, 4)
        Me.innerButton_ProcessGroupBox_TableLayoutPanel.Controls.Add(Me.removeProcess_Button, 0, 3)
        Me.innerButton_ProcessGroupBox_TableLayoutPanel.Controls.Add(Me.addProcess_Button, 0, 2)
        Me.innerButton_ProcessGroupBox_TableLayoutPanel.Controls.Add(Me.option_Button, 0, 1)
        Me.innerButton_ProcessGroupBox_TableLayoutPanel.Controls.Add(Me.run_Button, 0, 0)
        Me.innerButton_ProcessGroupBox_TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.innerButton_ProcessGroupBox_TableLayoutPanel.Location = New System.Drawing.Point(612, 3)
        Me.innerButton_ProcessGroupBox_TableLayoutPanel.Name = "innerButton_ProcessGroupBox_TableLayoutPanel"
        Me.innerButton_ProcessGroupBox_TableLayoutPanel.RowCount = 6
        Me.innerButton_ProcessGroupBox_TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.innerButton_ProcessGroupBox_TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.innerButton_ProcessGroupBox_TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.innerButton_ProcessGroupBox_TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.innerButton_ProcessGroupBox_TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.innerButton_ProcessGroupBox_TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.innerButton_ProcessGroupBox_TableLayoutPanel.Size = New System.Drawing.Size(147, 201)
        Me.innerButton_ProcessGroupBox_TableLayoutPanel.TabIndex = 2
        '
        'exit_Button
        '
        Me.exit_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.exit_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.exit_Button.Location = New System.Drawing.Point(3, 168)
        Me.exit_Button.Name = "exit_Button"
        Me.exit_Button.Size = New System.Drawing.Size(141, 30)
        Me.exit_Button.TabIndex = 5
        Me.exit_Button.Text = "종료"
        Me.exit_Button.UseVisualStyleBackColor = True
        '
        'clearProcess_Button
        '
        Me.clearProcess_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.clearProcess_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.clearProcess_Button.Location = New System.Drawing.Point(3, 135)
        Me.clearProcess_Button.Name = "clearProcess_Button"
        Me.clearProcess_Button.Size = New System.Drawing.Size(141, 27)
        Me.clearProcess_Button.TabIndex = 4
        Me.clearProcess_Button.Text = "프로세스 목록 초기화"
        Me.clearProcess_Button.UseVisualStyleBackColor = True
        '
        'removeProcess_Button
        '
        Me.removeProcess_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.removeProcess_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.removeProcess_Button.Location = New System.Drawing.Point(3, 102)
        Me.removeProcess_Button.Name = "removeProcess_Button"
        Me.removeProcess_Button.Size = New System.Drawing.Size(141, 27)
        Me.removeProcess_Button.TabIndex = 3
        Me.removeProcess_Button.Text = "선택 된 프로세스 제거"
        Me.removeProcess_Button.UseVisualStyleBackColor = True
        '
        'addProcess_Button
        '
        Me.addProcess_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.addProcess_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.addProcess_Button.Location = New System.Drawing.Point(3, 69)
        Me.addProcess_Button.Name = "addProcess_Button"
        Me.addProcess_Button.Size = New System.Drawing.Size(141, 27)
        Me.addProcess_Button.TabIndex = 2
        Me.addProcess_Button.Text = "프로세스 추가"
        Me.addProcess_Button.UseVisualStyleBackColor = True
        '
        'option_Button
        '
        Me.option_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.option_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.option_Button.Location = New System.Drawing.Point(3, 36)
        Me.option_Button.Name = "option_Button"
        Me.option_Button.Size = New System.Drawing.Size(141, 27)
        Me.option_Button.TabIndex = 1
        Me.option_Button.Text = "옵션"
        Me.option_Button.UseVisualStyleBackColor = True
        '
        'run_Button
        '
        Me.run_Button.BackColor = System.Drawing.Color.Black
        Me.run_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.run_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.run_Button.ForeColor = System.Drawing.Color.White
        Me.run_Button.Location = New System.Drawing.Point(3, 3)
        Me.run_Button.Name = "run_Button"
        Me.run_Button.Size = New System.Drawing.Size(141, 27)
        Me.run_Button.TabIndex = 0
        Me.run_Button.Text = "실행"
        Me.run_Button.UseVisualStyleBackColor = False
        '
        'result_GroupBox
        '
        Me.result_GroupBox.Controls.Add(Me.innerResultGroupBox_TableLayoutPanel)
        Me.result_GroupBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.result_GroupBox.ForeColor = System.Drawing.Color.White
        Me.result_GroupBox.Location = New System.Drawing.Point(6, 350)
        Me.result_GroupBox.Name = "result_GroupBox"
        Me.result_GroupBox.Size = New System.Drawing.Size(768, 149)
        Me.result_GroupBox.TabIndex = 2
        Me.result_GroupBox.TabStop = False
        Me.result_GroupBox.Text = "실행 결과"
        '
        'innerResultGroupBox_TableLayoutPanel
        '
        Me.innerResultGroupBox_TableLayoutPanel.ColumnCount = 2
        Me.innerResultGroupBox_TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.0!))
        Me.innerResultGroupBox_TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.innerResultGroupBox_TableLayoutPanel.Controls.Add(Me.result_ListBox, 0, 0)
        Me.innerResultGroupBox_TableLayoutPanel.Controls.Add(Me.innerButton_ResultGroupBox_TableLayoutPanel, 1, 0)
        Me.innerResultGroupBox_TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.innerResultGroupBox_TableLayoutPanel.Location = New System.Drawing.Point(3, 17)
        Me.innerResultGroupBox_TableLayoutPanel.Name = "innerResultGroupBox_TableLayoutPanel"
        Me.innerResultGroupBox_TableLayoutPanel.RowCount = 1
        Me.innerResultGroupBox_TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.innerResultGroupBox_TableLayoutPanel.Size = New System.Drawing.Size(762, 129)
        Me.innerResultGroupBox_TableLayoutPanel.TabIndex = 0
        '
        'result_ListBox
        '
        Me.result_ListBox.BackColor = System.Drawing.Color.Black
        Me.result_ListBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.result_ListBox.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.result_ListBox.ForeColor = System.Drawing.Color.LimeGreen
        Me.result_ListBox.FormattingEnabled = True
        Me.result_ListBox.Location = New System.Drawing.Point(3, 3)
        Me.result_ListBox.Name = "result_ListBox"
        Me.result_ListBox.ScrollAlwaysVisible = True
        Me.result_ListBox.Size = New System.Drawing.Size(603, 123)
        Me.result_ListBox.TabIndex = 0
        '
        'innerButton_ResultGroupBox_TableLayoutPanel
        '
        Me.innerButton_ResultGroupBox_TableLayoutPanel.ColumnCount = 1
        Me.innerButton_ResultGroupBox_TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.innerButton_ResultGroupBox_TableLayoutPanel.Controls.Add(Me.viewResultWithNotepad_Button, 0, 1)
        Me.innerButton_ResultGroupBox_TableLayoutPanel.Controls.Add(Me.clearResult_Button, 0, 2)
        Me.innerButton_ResultGroupBox_TableLayoutPanel.Controls.Add(Me.copyResult_Button, 0, 0)
        Me.innerButton_ResultGroupBox_TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.innerButton_ResultGroupBox_TableLayoutPanel.Location = New System.Drawing.Point(612, 3)
        Me.innerButton_ResultGroupBox_TableLayoutPanel.Name = "innerButton_ResultGroupBox_TableLayoutPanel"
        Me.innerButton_ResultGroupBox_TableLayoutPanel.RowCount = 3
        Me.innerButton_ResultGroupBox_TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.innerButton_ResultGroupBox_TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.innerButton_ResultGroupBox_TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.innerButton_ResultGroupBox_TableLayoutPanel.Size = New System.Drawing.Size(147, 123)
        Me.innerButton_ResultGroupBox_TableLayoutPanel.TabIndex = 1
        '
        'viewResultWithNotepad_Button
        '
        Me.viewResultWithNotepad_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.viewResultWithNotepad_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.viewResultWithNotepad_Button.Location = New System.Drawing.Point(3, 44)
        Me.viewResultWithNotepad_Button.Name = "viewResultWithNotepad_Button"
        Me.viewResultWithNotepad_Button.Size = New System.Drawing.Size(141, 35)
        Me.viewResultWithNotepad_Button.TabIndex = 1
        Me.viewResultWithNotepad_Button.Text = "메모장으로 결과 보기"
        Me.viewResultWithNotepad_Button.UseVisualStyleBackColor = True
        '
        'clearResult_Button
        '
        Me.clearResult_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.clearResult_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.clearResult_Button.Location = New System.Drawing.Point(3, 85)
        Me.clearResult_Button.Name = "clearResult_Button"
        Me.clearResult_Button.Size = New System.Drawing.Size(141, 35)
        Me.clearResult_Button.TabIndex = 2
        Me.clearResult_Button.Text = "실행 결과 초기화"
        Me.clearResult_Button.UseVisualStyleBackColor = True
        '
        'copyResult_Button
        '
        Me.copyResult_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.copyResult_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.copyResult_Button.Location = New System.Drawing.Point(3, 3)
        Me.copyResult_Button.Name = "copyResult_Button"
        Me.copyResult_Button.Size = New System.Drawing.Size(141, 35)
        Me.copyResult_Button.TabIndex = 0
        Me.copyResult_Button.Text = "클립보드에 모두 복사"
        Me.copyResult_Button.UseVisualStyleBackColor = True
        '
        'titleBar_Panel
        '
        Me.titleBar_Panel.Controls.Add(Me.help_Button)
        Me.titleBar_Panel.Controls.Add(Me.minimize_Button)
        Me.titleBar_Panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.titleBar_Panel.Location = New System.Drawing.Point(6, 6)
        Me.titleBar_Panel.Name = "titleBar_Panel"
        Me.titleBar_Panel.Size = New System.Drawing.Size(768, 19)
        Me.titleBar_Panel.TabIndex = 3
        '
        'help_Button
        '
        Me.help_Button.BackColor = System.Drawing.Color.Black
        Me.help_Button.Dock = System.Windows.Forms.DockStyle.Right
        Me.help_Button.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.help_Button.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.help_Button.Location = New System.Drawing.Point(728, 0)
        Me.help_Button.Name = "help_Button"
        Me.help_Button.Size = New System.Drawing.Size(20, 19)
        Me.help_Button.TabIndex = 2
        Me.help_Button.Text = "?"
        Me.help_Button.UseVisualStyleBackColor = False
        '
        'minimize_Button
        '
        Me.minimize_Button.Dock = System.Windows.Forms.DockStyle.Right
        Me.minimize_Button.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.minimize_Button.Location = New System.Drawing.Point(748, 0)
        Me.minimize_Button.Name = "minimize_Button"
        Me.minimize_Button.Size = New System.Drawing.Size(20, 19)
        Me.minimize_Button.TabIndex = 3
        Me.minimize_Button.Text = "-"
        Me.minimize_Button.UseVisualStyleBackColor = True
        '
        'logo_PictureBox
        '
        Me.logo_PictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.logo_PictureBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.logo_PictureBox.Image = Global.CPU_Process_Scheduling_Simulation.My.Resources.Resources.logo
        Me.logo_PictureBox.Location = New System.Drawing.Point(6, 34)
        Me.logo_PictureBox.Name = "logo_PictureBox"
        Me.logo_PictureBox.Size = New System.Drawing.Size(768, 71)
        Me.logo_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.logo_PictureBox.TabIndex = 4
        Me.logo_PictureBox.TabStop = False
        '
        'processScheduling_BackgroundWorker
        '
        Me.processScheduling_BackgroundWorker.WorkerReportsProgress = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(780, 537)
        Me.Controls.Add(Me.outerMain_TableLayoutPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MainForm"
        Me.Text = "CPU Process Scheduling Simulation"
        Me.outerMain_TableLayoutPanel.ResumeLayout(False)
        Me.outerMain_TableLayoutPanel.PerformLayout()
        Me.process_GroupBox.ResumeLayout(False)
        Me.innerProcessGroupBox_TableLayoutPanel.ResumeLayout(False)
        Me.innerButton_ProcessGroupBox_TableLayoutPanel.ResumeLayout(False)
        Me.result_GroupBox.ResumeLayout(False)
        Me.innerResultGroupBox_TableLayoutPanel.ResumeLayout(False)
        Me.innerButton_ResultGroupBox_TableLayoutPanel.ResumeLayout(False)
        Me.titleBar_Panel.ResumeLayout(False)
        CType(Me.logo_PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents outerMain_TableLayoutPanel As TableLayoutPanel
    Friend WithEvents about_LinkLabel As LinkLabel
    Friend WithEvents process_GroupBox As GroupBox
    Friend WithEvents result_GroupBox As GroupBox
    Friend WithEvents innerProcessGroupBox_TableLayoutPanel As TableLayoutPanel
    Friend WithEvents process_ListView As ListView
    Friend WithEvents innerButton_ProcessGroupBox_TableLayoutPanel As TableLayoutPanel
    Friend WithEvents clearProcess_Button As Button
    Friend WithEvents removeProcess_Button As Button
    Friend WithEvents addProcess_Button As Button
    Friend WithEvents option_Button As Button
    Friend WithEvents run_Button As Button
    Friend WithEvents innerResultGroupBox_TableLayoutPanel As TableLayoutPanel
    Friend WithEvents result_ListBox As ListBox
    Friend WithEvents innerButton_ResultGroupBox_TableLayoutPanel As TableLayoutPanel
    Friend WithEvents clearResult_Button As Button
    Friend WithEvents copyResult_Button As Button
    Protected Friend WithEvents name_ColumnHeader As ColumnHeader
    Friend WithEvents arrivalTime_ColumnHeader As ColumnHeader
    Friend WithEvents burstTime_ColumnHeader As ColumnHeader
    Friend WithEvents priority_ColumnHeader As ColumnHeader
    Friend WithEvents titleBar_Panel As Panel
    Private WithEvents help_Button As Button
    Private WithEvents minimize_Button As Button
    Friend WithEvents exit_Button As Button
    Friend WithEvents logo_PictureBox As PictureBox
    Friend WithEvents viewResultWithNotepad_Button As Button
    Friend WithEvents processScheduling_BackgroundWorker As System.ComponentModel.BackgroundWorker
End Class
