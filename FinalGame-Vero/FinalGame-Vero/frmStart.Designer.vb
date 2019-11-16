<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStart
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStart))
        Me.btn1v1 = New System.Windows.Forms.Button()
        Me.btn1vBot = New System.Windows.Forms.Button()
        Me.picTitle = New System.Windows.Forms.PictureBox()
        Me.gbDiff = New System.Windows.Forms.GroupBox()
        Me.rbHard = New System.Windows.Forms.RadioButton()
        Me.rbMed = New System.Windows.Forms.RadioButton()
        Me.rbEasy = New System.Windows.Forms.RadioButton()
        CType(Me.picTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDiff.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn1v1
        '
        Me.btn1v1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn1v1.Location = New System.Drawing.Point(49, 219)
        Me.btn1v1.Name = "btn1v1"
        Me.btn1v1.Size = New System.Drawing.Size(140, 43)
        Me.btn1v1.TabIndex = 0
        Me.btn1v1.Text = "Two Player"
        Me.btn1v1.UseVisualStyleBackColor = True
        '
        'btn1vBot
        '
        Me.btn1vBot.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn1vBot.Location = New System.Drawing.Point(49, 277)
        Me.btn1vBot.Name = "btn1vBot"
        Me.btn1vBot.Size = New System.Drawing.Size(140, 66)
        Me.btn1vBot.TabIndex = 1
        Me.btn1vBot.Text = "Single Player"
        Me.btn1vBot.UseVisualStyleBackColor = True
        '
        'picTitle
        '
        Me.picTitle.Image = Global.FinalGame_Vero.My.Resources.Resources.C4Title
        Me.picTitle.Location = New System.Drawing.Point(-1, -1)
        Me.picTitle.Name = "picTitle"
        Me.picTitle.Size = New System.Drawing.Size(424, 199)
        Me.picTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picTitle.TabIndex = 3
        Me.picTitle.TabStop = False
        '
        'gbDiff
        '
        Me.gbDiff.Controls.Add(Me.rbHard)
        Me.gbDiff.Controls.Add(Me.rbMed)
        Me.gbDiff.Controls.Add(Me.rbEasy)
        Me.gbDiff.Font = New System.Drawing.Font("MS Reference Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDiff.ForeColor = System.Drawing.Color.Black
        Me.gbDiff.Location = New System.Drawing.Point(258, 219)
        Me.gbDiff.Name = "gbDiff"
        Me.gbDiff.Size = New System.Drawing.Size(98, 114)
        Me.gbDiff.TabIndex = 4
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
        'frmStart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.MidnightBlue
        Me.ClientSize = New System.Drawing.Size(420, 370)
        Me.Controls.Add(Me.gbDiff)
        Me.Controls.Add(Me.btn1vBot)
        Me.Controls.Add(Me.btn1v1)
        Me.Controls.Add(Me.picTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmStart"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Connect 4"
        CType(Me.picTitle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDiff.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn1v1 As System.Windows.Forms.Button
    Friend WithEvents btn1vBot As System.Windows.Forms.Button
    Friend WithEvents picTitle As System.Windows.Forms.PictureBox
    Friend WithEvents gbDiff As System.Windows.Forms.GroupBox
    Friend WithEvents rbHard As System.Windows.Forms.RadioButton
    Friend WithEvents rbMed As System.Windows.Forms.RadioButton
    Friend WithEvents rbEasy As System.Windows.Forms.RadioButton
End Class
