Public Class frmRules
    'Zachary Vero
    Private Sub frmRules_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblRules.Text = "Objective: - To get 4 of your color pieces in a row"                           '}ourputs rules and objectives
        lblRules.Text = lblRules.Text + vbCrLf + "Rules: - Each player makes a move every other turn"   '}
        lblRules.Text = lblRules.Text + vbCrLf + "- You may win diaganally, horizontly, and vertically" '}
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()  'closes form
    End Sub
End Class