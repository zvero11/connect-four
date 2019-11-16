<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGame
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGame))
        Me.tmrDrop = New System.Windows.Forms.Timer(Me.components)
        Me.lblP1 = New System.Windows.Forms.Label()
        Me.lblP2 = New System.Windows.Forms.Label()
        Me.mnuTop = New System.Windows.Forms.MenuStrip()
        Me.DifficultyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RulesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QuitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RestartCounterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EasyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MediumToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefreshStatsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SinglePlayerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblP2P = New System.Windows.Forms.Label()
        Me.lblP1P = New System.Windows.Forms.Label()
        Me.tmrHighL = New System.Windows.Forms.Timer(Me.components)
        Me.picRed = New System.Windows.Forms.PictureBox()
        Me.picBlue = New System.Windows.Forms.PictureBox()
        Me.mnuTop.SuspendLayout()
        CType(Me.picRed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picBlue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tmrDrop
        '
        Me.tmrDrop.Interval = 50
        '
        'lblP1
        '
        Me.lblP1.AutoSize = True
        Me.lblP1.Font = New System.Drawing.Font("Microsoft YaHei UI", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblP1.Location = New System.Drawing.Point(60, 742)
        Me.lblP1.Name = "lblP1"
        Me.lblP1.Size = New System.Drawing.Size(140, 41)
        Me.lblP1.TabIndex = 0
        Me.lblP1.Text = "Player 1"
        '
        'lblP2
        '
        Me.lblP2.Font = New System.Drawing.Font("Microsoft YaHei UI", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblP2.Location = New System.Drawing.Point(643, 742)
        Me.lblP2.Name = "lblP2"
        Me.lblP2.Size = New System.Drawing.Size(283, 41)
        Me.lblP2.TabIndex = 1
        Me.lblP2.Text = "Player 2"
        '
        'mnuTop
        '
        Me.mnuTop.BackColor = System.Drawing.Color.Transparent
        Me.mnuTop.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DifficultyToolStripMenuItem, Me.RestartCounterToolStripMenuItem, Me.RefreshStatsToolStripMenuItem, Me.SinglePlayerToolStripMenuItem})
        Me.mnuTop.Location = New System.Drawing.Point(0, 0)
        Me.mnuTop.Name = "mnuTop"
        Me.mnuTop.Size = New System.Drawing.Size(708, 24)
        Me.mnuTop.TabIndex = 2
        Me.mnuTop.Text = "Menus"
        '
        'DifficultyToolStripMenuItem
        '
        Me.DifficultyToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RulesToolStripMenuItem, Me.QuitToolStripMenuItem})
        Me.DifficultyToolStripMenuItem.Name = "DifficultyToolStripMenuItem"
        Me.DifficultyToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.DifficultyToolStripMenuItem.Text = "File"
        '
        'RulesToolStripMenuItem
        '
        Me.RulesToolStripMenuItem.Name = "RulesToolStripMenuItem"
        Me.RulesToolStripMenuItem.Size = New System.Drawing.Size(102, 22)
        Me.RulesToolStripMenuItem.Text = "Rules"
        '
        'QuitToolStripMenuItem
        '
        Me.QuitToolStripMenuItem.Name = "QuitToolStripMenuItem"
        Me.QuitToolStripMenuItem.Size = New System.Drawing.Size(102, 22)
        Me.QuitToolStripMenuItem.Text = "Quit"
        '
        'RestartCounterToolStripMenuItem
        '
        Me.RestartCounterToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EasyToolStripMenuItem, Me.MediumToolStripMenuItem, Me.HardToolStripMenuItem})
        Me.RestartCounterToolStripMenuItem.Name = "RestartCounterToolStripMenuItem"
        Me.RestartCounterToolStripMenuItem.Size = New System.Drawing.Size(67, 20)
        Me.RestartCounterToolStripMenuItem.Text = "Difficulty"
        '
        'EasyToolStripMenuItem
        '
        Me.EasyToolStripMenuItem.Name = "EasyToolStripMenuItem"
        Me.EasyToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
        Me.EasyToolStripMenuItem.Text = "Easy"
        '
        'MediumToolStripMenuItem
        '
        Me.MediumToolStripMenuItem.Name = "MediumToolStripMenuItem"
        Me.MediumToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
        Me.MediumToolStripMenuItem.Text = "Medium"
        '
        'HardToolStripMenuItem
        '
        Me.HardToolStripMenuItem.Name = "HardToolStripMenuItem"
        Me.HardToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
        Me.HardToolStripMenuItem.Text = "Hard"
        '
        'RefreshStatsToolStripMenuItem
        '
        Me.RefreshStatsToolStripMenuItem.Name = "RefreshStatsToolStripMenuItem"
        Me.RefreshStatsToolStripMenuItem.Size = New System.Drawing.Size(86, 20)
        Me.RefreshStatsToolStripMenuItem.Text = "Refresh Stats"
        '
        'SinglePlayerToolStripMenuItem
        '
        Me.SinglePlayerToolStripMenuItem.Name = "SinglePlayerToolStripMenuItem"
        Me.SinglePlayerToolStripMenuItem.Size = New System.Drawing.Size(86, 20)
        Me.SinglePlayerToolStripMenuItem.Text = "Single Player"
        '
        'lblP2P
        '
        Me.lblP2P.AutoSize = True
        Me.lblP2P.Font = New System.Drawing.Font("Microsoft YaHei UI", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblP2P.Location = New System.Drawing.Point(653, 742)
        Me.lblP2P.Name = "lblP2P"
        Me.lblP2P.Size = New System.Drawing.Size(0, 41)
        Me.lblP2P.TabIndex = 5
        '
        'lblP1P
        '
        Me.lblP1P.AutoSize = True
        Me.lblP1P.Font = New System.Drawing.Font("Microsoft YaHei UI", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblP1P.Location = New System.Drawing.Point(206, 742)
        Me.lblP1P.Name = "lblP1P"
        Me.lblP1P.Size = New System.Drawing.Size(0, 41)
        Me.lblP1P.TabIndex = 6
        '
        'tmrHighL
        '
        Me.tmrHighL.Enabled = True
        Me.tmrHighL.Interval = 1
        '
        'picRed
        '
        Me.picRed.Image = Global.FinalGame_Vero.My.Resources.Resources.Red2
        Me.picRed.Location = New System.Drawing.Point(650, 742)
        Me.picRed.Name = "picRed"
        Me.picRed.Size = New System.Drawing.Size(46, 41)
        Me.picRed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picRed.TabIndex = 4
        Me.picRed.TabStop = False
        '
        'picBlue
        '
        Me.picBlue.Image = Global.FinalGame_Vero.My.Resources.Resources.Blue2
        Me.picBlue.Location = New System.Drawing.Point(8, 742)
        Me.picBlue.Name = "picBlue"
        Me.picBlue.Size = New System.Drawing.Size(46, 41)
        Me.picBlue.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picBlue.TabIndex = 3
        Me.picBlue.TabStop = False
        '
        'frmGame
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gray
        Me.ClientSize = New System.Drawing.Size(708, 786)
        Me.Controls.Add(Me.lblP1P)
        Me.Controls.Add(Me.picRed)
        Me.Controls.Add(Me.picBlue)
        Me.Controls.Add(Me.lblP2)
        Me.Controls.Add(Me.lblP1)
        Me.Controls.Add(Me.mnuTop)
        Me.Controls.Add(Me.lblP2P)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.mnuTop
        Me.Name = "frmGame"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Connect 4"
        Me.mnuTop.ResumeLayout(False)
        Me.mnuTop.PerformLayout()
        CType(Me.picRed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picBlue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tmrDrop As System.Windows.Forms.Timer
    Friend WithEvents lblP1 As System.Windows.Forms.Label
    Friend WithEvents lblP2 As System.Windows.Forms.Label
    Friend WithEvents mnuTop As System.Windows.Forms.MenuStrip
    Friend WithEvents DifficultyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RulesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents QuitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RestartCounterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RefreshStatsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EasyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MediumToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HardToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents picBlue As System.Windows.Forms.PictureBox
    Friend WithEvents picRed As System.Windows.Forms.PictureBox
    Friend WithEvents lblP2P As System.Windows.Forms.Label
    Friend WithEvents lblP1P As System.Windows.Forms.Label
    Friend WithEvents SinglePlayerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmrHighL As System.Windows.Forms.Timer

End Class
