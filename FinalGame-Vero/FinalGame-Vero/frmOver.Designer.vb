<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOver
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOver))
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnPlay = New System.Windows.Forms.Button()
        Me.gbDiff = New System.Windows.Forms.GroupBox()
        Me.rbHard = New System.Windows.Forms.RadioButton()
        Me.rbMed = New System.Windows.Forms.RadioButton()
        Me.rbEasy = New System.Windows.Forms.RadioButton()
        Me.picTitle = New System.Windows.Forms.PictureBox()
        Me.gbDiff.SuspendLayout()
        CType(Me.picTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("MS Reference Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(27, 271)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(131, 43)
        Me.btnExit.TabIndex = 0
        Me.btnExit.Text = "Quit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnPlay
        '
        Me.btnPlay.Font = New System.Drawing.Font("MS Reference Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPlay.Location = New System.Drawing.Point(27, 200)
        Me.btnPlay.Name = "btnPlay"
        Me.btnPlay.Size = New System.Drawing.Size(131, 43)
        Me.btnPlay.TabIndex = 1
        Me.btnPlay.Text = "Play Again"
        Me.btnPlay.UseVisualStyleBackColor = True
        '
        'gbDiff
        '
        Me.gbDiff.Controls.Add(Me.rbHard)
        Me.gbDiff.Controls.Add(Me.rbMed)
        Me.gbDiff.Controls.Add(Me.rbEasy)
        Me.gbDiff.Font = New System.Drawing.Font("MS Reference Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDiff.ForeColor = System.Drawing.Color.Black
        Me.gbDiff.Location = New System.Drawing.Point(184, 200)
        Me.gbDiff.Name = "gbDiff"
        Me.gbDiff.Size = New System.Drawing.Size(98, 114)
        Me.gbDiff.TabIndex = 3
        Me.gbDiff.TabStop = False
        Me.gbDiff.Text = "Difficulty"
        '
        'rbHard
        '
        Me.rbHard.Location = New System.Drawing.Point(6, 74)
        Me.rbHard.Name = "rbHard"
        Me.rbHard.Size = New System.Drawing.Size(74, 21)
        Me.rbHard.TabIndex = 2
        Me.rbHard.TabStop = True
        Me.rbHard.Text = "Hard"
        Me.rbHard.UseVisualStyleBackColor = True
        '
        'rbMed
        '
        Me.rbMed.Location = New System.Drawing.Point(6, 47)
        Me.rbMed.Name = "rbMed"
        Me.rbMed.Size = New System.Drawing.Size(83, 21)
        Me.rbMed.TabIndex = 1
        Me.rbMed.TabStop = True
        Me.rbMed.Text = "Medium"
        Me.rbMed.UseVisualStyleBackColor = True
        '
        'rbEasy
        '
        Me.rbEasy.Location = New System.Drawing.Point(6, 22)
        Me.rbEasy.Name = "rbEasy"
        Me.rbEasy.Size = New System.Drawing.Size(74, 21)
        Me.rbEasy.TabIndex = 0
        Me.rbEasy.TabStop = True
        Me.rbEasy.Text = "Easy"
        Me.rbEasy.UseVisualStyleBackColor = True
        '
        'picTitle
        '
        Me.picTitle.Image = Global.FinalGame_Vero.My.Resources.Resources.C4Player1
        Me.picTitle.Location = New System.Drawing.Point(-1, -3)
        Me.picTitle.Name = "picTitle"
        Me.picTitle.Size = New System.Drawing.Size(356, 183)
        Me.picTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picTitle.TabIndex = 4
        Me.picTitle.TabStop = False
        '
        'frmOver
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.MidnightBlue
        Me.ClientSize = New System.Drawing.Size(354, 334)
        Me.Controls.Add(Me.picTitle)
        Me.Controls.Add(Me.gbDiff)
        Me.Controls.Add(Me.btnPlay)
        Me.Controls.Add(Me.btnExit)
        Me.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmOver"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Connect 4"
        Me.gbDiff.ResumeLayout(False)
        CType(Me.picTitle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnPlay As System.Windows.Forms.Button
    Friend WithEvents gbDiff As System.Windows.Forms.GroupBox
    Friend WithEvents rbHard As System.Windows.Forms.RadioButton
    Friend WithEvents rbMed As System.Windows.Forms.RadioButton
    Friend WithEvents rbEasy As System.Windows.Forms.RadioButton
    Friend WithEvents picTitle As System.Windows.Forms.PictureBox
End Class
