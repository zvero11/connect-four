Public Class frmOver
    'Zachary Vero
    Private Sub rbEasy_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbEasy.CheckedChanged, rbMed.CheckedChanged, rbHard.CheckedChanged
        If rbEasy.Checked = True Then   '}Updates the Difficulty if the user decides to change
            frmGame.intDif = 1          '}
        End If
        If rbMed.Checked = True Then    '}
            frmGame.intDif = 2          '}
        End If
        If rbHard.Checked = True Then   '}
            frmGame.intDif = 3          '}
        End If
    End Sub

    Private Sub frmOver_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        For x = 1 To 7                          '}Removes all of the "pieces", preparing for another match
            For y = 1 To 7                      '}
                With frmGame.picSpot(x, y)      '}
                    .Image = My.Resources.Empty '}
                    .BackColor = Color.Gray     '}
                End With                        '}
            Next                                '}
        Next                                    '}
        frmGame.blnOver = False                 '}
    End Sub
    Private Sub frmOver_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If frmGame.intDif = 1 Then  '}Checks which Difficulty is currently selected
            rbEasy.Checked = True   '}
        End If
        If frmGame.intDif = 2 Then  '}
            rbMed.Checked = True    '}
        End If
        If frmGame.intDif = 3 Then  '}
            rbHard.Checked = True   '}
        End If
        If Mid(frmGame.strWinner, 1, 1) = "P" Then  '}If in two player mode, difficulty isn't an option 
            gbDiff.Visible = False                  '}
            btnPlay.Width += 174                    '}
            btnExit.Width += 174                    '}
        End If
        picTitle.Image = My.Resources.ResourceManager.GetObject("C4" + frmGame.strWinner)   'Choses Title image based off o who won
        If frmGame.strWinner = "Winner" Or frmGame.strWinner = "Player1" Then   'If player 1 wins, back color is blue
            Me.BackColor = Color.MidnightBlue
        Else
            Me.BackColor = Color.Maroon 'if bot or player 2 wins, back color is red
        End If
    End Sub

    Private Sub btnPlay_Click(sender As System.Object, e As System.EventArgs) Handles btnPlay.Click
        For x = 1 To 7                          '}Removes all of the "pieces", preparing for another match
            For y = 1 To 7                      '}
                With frmGame.picSpot(x, y)      '}
                    .Image = My.Resources.Empty '}
                    .BackColor = Color.Gray     '}
                End With                        '}
            Next                                '}
        Next                                    '}
        frmGame.blnOver = False                 '}
        Me.Close()  'Closes the game is over screen
    End Sub

    Private Sub btnExit_Click(sender As System.Object, e As System.EventArgs) Handles btnExit.Click
        frmGame.Close() '}Closes the entire game
        Me.Close()      '}
    End Sub
End Class