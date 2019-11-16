<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRules
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRules))
        Me.lblRules = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.picRule = New System.Windows.Forms.PictureBox()
        CType(Me.picRule, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblRules
        '
        Me.lblRules.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRules.Location = New System.Drawing.Point(8, 111)
        Me.lblRules.Name = "lblRules"
        Me.lblRules.Size = New System.Drawing.Size(349, 173)
        Me.lblRules.TabIndex = 0
        Me.lblRules.Text = "Rules: -Each player makes a move every other turn"
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(265, 244)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(92, 37)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'picRule
        '
        Me.picRule.Image = Global.FinalGame_Vero.My.Resources.Resources.C4Rules
        Me.picRule.Location = New System.Drawing.Point(-7, -1)
        Me.picRule.Name = "picRule"
        Me.picRule.Size = New System.Drawing.Size(383, 108)
        Me.picRule.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picRule.TabIndex = 2
        Me.picRule.TabStop = False
        '
        'frmRules
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Maroon
        Me.ClientSize = New System.Drawing.Size(373, 293)
        Me.Controls.Add(Me.picRule)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lblRules)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmRules"
        Me.Text = "Rules"
        CType(Me.picRule, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblRules As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents picRule As System.Windows.Forms.PictureBox
End Class
