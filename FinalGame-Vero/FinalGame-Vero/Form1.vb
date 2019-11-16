Public Class frmGame
    'Zachary Vero
    Public picSpot(7, 7) As PictureBox
    Public intDif As Integer, intP2W As Integer, intP1W As Integer, blnOver As Boolean, strWinner As String
    Private intStop As Integer, intPlayer As Integer, intStart As Integer, blnBot As Integer, intAmnt As Integer, strNames(141) As String, picHighL(7) As PictureBox
    Private Const intP2Start As Integer = 643

    Private Sub frmGame_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frmRules.Close()    'closes rules form along with game form
    End Sub
    Private Sub frmGame_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Const intSize As Integer = 100  'Size of each space
        Dim intWordS As Integer
        Randomize() 'makes sure all random numbers are truly random
        Call Names()    'loads in the database for the names
        intDif = frmStart.intDiff   'finds which difficulty was chosen
        intWordS = Len(frmStart.strVs) * 19     'Sees how much space is needed for the bot'c name that was chosen
        lblP2.Left = intP2Start - intWordS  'moves the bot's name to a position where the name wouldn't be cut off
        lblP2P.Left = intP2Start - intWordS - 40    'moves the bot's/player 2's next to the name
        lblP2P.Text = intP2W.ToString + "|" '}outputs the amount of points each player has
        lblP1P.Text = "|" + intP1W.ToString '}
        Me.Size = New Point(intSize * 7 + 10, intSize * 8 + 45) 'sets the form to a fixed size
        lblP2.Text = frmStart.strVs 'labels the bot/player 2 with their name
        If lblP2.Text = "Player 2" Then 'tests to see if two player mode
            RestartCounterToolStripMenuItem.Visible = False         '} if in two player mode, difficulty option is not shown, and gives option for single player
            SinglePlayerToolStripMenuItem.Text = "Single Player"    '}
        Else
            RestartCounterToolStripMenuItem.Visible = True      '} if in single player mode, difficulty option is shown, and gives option for two player
            SinglePlayerToolStripMenuItem.Text = "Two Player"   '}
        End If
        For x = 1 To 7                                                              '}Creates each position on the board, and puts the position in the correct location, while defaulting each position to empty
            For y = 1 To 7                                                          '}
                picSpot(x, y) = New PictureBox                                      '}
                With picSpot(x, y)                                                  '}
                    .Image = My.Resources.Empty                                     '}
                    .BackColor = Color.Gray                                         '}
                    .SizeMode = PictureBoxSizeMode.StretchImage                     '}
                    .Size = New Point(intSize, intSize)                             '}
                    .Location = New Point(intSize * (x - 1), intSize * (y - 1) + 40) '}
                    .Name = "pos" & x.ToString & y.ToString                         '}
                End With                                                            '}
                Me.Controls.Add(picSpot(x, y))                                      '}  
                AddHandler picSpot(x, y).Click, AddressOf Detect                    '}
            Next y                                                                  '}
        Next x                                                                      '}
        For x = 1 To 7
            picHighL(x) = New PictureBox                    '}Creates 7 picture boxes that will highlight the position u are over
            With picHighL(x)                                '}
                .BackColor = Color.Gray                     '}
                .Size = New Point(intSize, intSize)         '}
                .Location = New Point(intSize * (x - 1), 1) '}
            End With                                        '}
            Me.Controls.Add(picHighL(x))                    '}
        Next
    End Sub
    Sub Detect(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim picPiece As PictureBox = DirectCast(sender, PictureBox)
        Dim strX As String, strY As String, intX As Integer, intY As Integer, intWin As Integer, blnUse As Integer
        Dim intOpt(7) As Integer, intMost(5) As Integer, intChose(7) As Integer
        If blnOver = False Then
            strX = Mid(picPiece.Name, 4, 1) '}finds where the piece was placed
            strY = Mid(picPiece.Name, 5, 1) '}

            intX = strX
            intY = strY
            If picSpot(intX, 1).BackColor = Color.Gray And tmrDrop.Enabled = False Then 'tests if a piece currently isn't being dropped, and if there is room in the column chosen 
                intAmnt += 1    'increases amount of turns so far
                Call Fall(intX, intY)   'finds out the lowest position possible in the chosen column
                intStop = intY  'decides where to stop for when the piece id dropped
                intStart = intX 'shows where the piece is being dropped
                If intAmnt Mod 2 <> 0 Then  'if it's player one's turn
                    picSpot(intX, intY).BackColor = Color.Blue
                    intPlayer = 1
                Else    'if player 2's turn
                    picSpot(intX, intY).BackColor = Color.Red
                    intPlayer = 2
                End If
                tmrDrop.Enabled = True 'places the piece
                For i = 1 To 8  'checks each position around the piece
                    blnUse = True 'if checking the position the first time
                    intWin = 0  'defaults "points" at zero
                    Call Win(intX, intY, i, intWin, blnUse) 'Tests if the player won
                    If intWin >= 4 Then 'player wins if the position has 4 or more points (pieces in a row)
                        i = 10  'stops looking for mor winning positions
                        intAmnt = 0 'resets amount of turns
                        blnOver = True  'declares game is over
                        If SinglePlayerToolStripMenuItem.Text = "Two Player" Then 'if in single player
                            strWinner = "Winner"    'the user has one
                            intP1W += 1 'increases the user's wins
                            lblP1P.Text = "|" + intP1W.ToString 'restates amount of times the user has won
                        Else    'if in two player
                            If intPlayer = 1 Then   'if player one won
                                intP1W += 1 'increases player 1's wins
                                lblP1P.Text = "|" + intP1W.ToString 'restates amount of times the user has won
                                strWinner = "Player1"   'declares winner
                            Else    'if player two won
                                intP2W += 1 'increases player 2's wins
                                lblP2P.Text = "|" + intP2W.ToString 'resatates amount of times the user has won
                                strWinner = "Player2"   'declares winner
                            End If
                        End If
                        frmOver.Show()  'starts up game over form
                    End If
                Next
            End If
        End If
    End Sub

    Sub Fall(ByVal intX As Integer, ByRef intY As Integer)
        Dim blnChosen As Boolean
        For y = 1 To 7
            If picSpot(intX, y).BackColor = Color.Blue Or picSpot(intX, y).BackColor = Color.Red Then   'if the position is full 
                intY = y - 1    'if positon is full, next piece can go above it
                blnChosen = True    'decalres that a spot was chosen
            End If
            If y = 7 And blnChosen = False Then 'if there aren't any pieces in the column
                intY = y    'the position chosen is lowest to the bottom
            End If
            If blnChosen = True Then    'of a postion is chosen
                y = 10  'escapes loop
            End If
        Next
    End Sub
    Sub Win(ByVal intX As Integer, ByVal intY As Integer, ByVal intPos As Integer, ByRef intWin As Integer, ByRef blnUse As Boolean)
        If intPlayer = 1 Then   'If player 1
            If intPos = 1 Then  'If testing for position 1
                If blnUse = True And intX < 7 And intY < 7 Then 'checks to see that the testing won't go out of bounds, and only checks this if first check
                    blnUse = False  'shuts of first check
                    If picSpot(intX + 1, intY + 1).BackColor = Color.Blue Then  ' tests if piece in opposite direction is blue
                        intWin += 1 'if blue, +1 point
                        Call Win(intX, intY, intPos, intWin, blnUse)    'Checks for more blue pieces
                    Else
                        Call Win(intX, intY, intPos, intWin, blnUse)    'Checks for more blue pieces
                    End If
                ElseIf blnBot = True Then   'only checks if in single player mode
                    If intX > 1 And intY > 1 Then   'checks to see that testing won't go out of bounds
                        If picSpot(intX - 1, intY - 1).BackColor = Color.Blue Then  'looks for blue pieces
                            intWin += 1 'if another blue piece is found, +1 point
                            Call Win(intX - 1, intY - 1, intPos, intWin, blnUse)    'Checks for more pieces
                        End If
                    End If
                Else
                    blnUse = False  'shuts off first use
                    If intX > 0 And intY > 0 Then   'makes sure that testing doesn't go out of bounds
                        If picSpot(intX, intY).BackColor = Color.Blue Then  'looks for blue piece
                            intWin += 1 'if piece if found, +1 pint
                            Call Win(intX - 1, intY - 1, intPos, intWin, blnUse) 'looks for more blue pieces
                        End If
                    End If
                End If
            ElseIf intPos = 2 Then                                                  '}| repeats everything in pos 1, except in different diections
                If blnUse = True And intY < 7 Then                                  '}|
                    blnUse = False                                                  '}V
                    If picSpot(intX, intY + 1).BackColor = Color.Blue Then
                        intWin += 1
                        Call Win(intX, intY, intPos, intWin, blnUse)
                    Else
                        Call Win(intX, intY, intPos, intWin, blnUse)
                    End If
                ElseIf blnBot = True Then
                    If intY > 1 Then
                        If picSpot(intX, intY - 1).BackColor = Color.Blue Then
                            intWin += 1
                            Call Win(intX, intY - 1, intPos, intWin, blnUse)
                        End If
                    End If
                Else
                    blnUse = False
                    If intY > 0 Then
                        If picSpot(intX, intY).BackColor = Color.Blue Then
                            intWin += 1
                            Call Win(intX, intY - 1, intPos, intWin, blnUse)
                        End If
                    End If
                End If
            ElseIf intPos = 3 Then
                If blnUse = True And intX > 1 And intY < 7 Then
                    blnUse = False
                    If picSpot(intX - 1, intY + 1).BackColor = Color.Blue Then
                        intWin += 1
                        Call Win(intX, intY, intPos, intWin, blnUse)
                    Else
                        Call Win(intX, intY, intPos, intWin, blnUse)
                    End If
                ElseIf blnBot = True Then
                    If intX < 7 And intY > 1 Then
                        If picSpot(intX + 1, intY - 1).BackColor = Color.Blue Then
                            intWin += 1
                            Call Win(intX + 1, intY - 1, intPos, intWin, blnUse)
                        End If
                    End If
                Else
                    blnUse = False
                    If intX < 8 And intY > 0 Then
                        If picSpot(intX, intY).BackColor = Color.Blue Then
                            intWin += 1
                            Call Win(intX + 1, intY - 1, intPos, intWin, blnUse)
                        End If
                    End If
                End If
            ElseIf intPos = 4 Then
                If blnUse = True And intX > 1 Then
                    blnUse = False
                    If picSpot(intX - 1, intY).BackColor = Color.Blue Then
                        intWin += 1
                        Call Win(intX, intY, intPos, intWin, blnUse)
                    Else
                        Call Win(intX, intY, intPos, intWin, blnUse)
                    End If
                ElseIf blnBot = True Then
                    If intX < 7 Then
                        If picSpot(intX + 1, intY).BackColor = Color.Blue Then
                            intWin += 1
                            Call Win(intX + 1, intY, intPos, intWin, blnUse)
                        End If
                    End If
                Else
                    blnUse = False
                    If intX < 8 Then
                        If picSpot(intX, intY).BackColor = Color.Blue Then
                            intWin += 1
                            Call Win(intX + 1, intY, intPos, intWin, blnUse)
                        End If
                    End If
                End If
            ElseIf intPos = 5 Then
                If blnUse = True And intX > 1 And intY > 1 Then
                    blnUse = False
                    If picSpot(intX - 1, intY - 1).BackColor = Color.Blue Then
                        intWin += 1
                        Call Win(intX, intY, intPos, intWin, blnUse)
                    Else
                        Call Win(intX, intY, intPos, intWin, blnUse)
                    End If
                ElseIf blnBot = True Then
                    If intX < 7 And intY < 7 Then
                        If picSpot(intX + 1, intY + 1).BackColor = Color.Blue Then
                            intWin += 1
                            Call Win(intX + 1, intY + 1, intPos, intWin, blnUse)
                        End If
                    End If
                Else
                    blnUse = False
                    If intX < 8 And intY < 8 Then
                        If picSpot(intX, intY).BackColor = Color.Blue Then
                            intWin += 1
                            Call Win(intX + 1, intY + 1, intPos, intWin, blnUse)
                        End If
                    End If
                End If
            ElseIf intPos = 6 Then
                If blnUse = True And intY > 1 Then
                    blnUse = False
                    If picSpot(intX, intY - 1).BackColor = Color.Blue Then
                        intWin += 1
                        Call Win(intX, intY, intPos, intWin, blnUse)
                    Else
                        Call Win(intX, intY, intPos, intWin, blnUse)
                    End If
                ElseIf blnBot = True Then
                    If intY < 7 Then
                        If picSpot(intX, intY + 1).BackColor = Color.Blue Then
                            intWin += 1
                            Call Win(intX, intY + 1, intPos, intWin, blnUse)
                        End If
                    End If
                Else
                    blnUse = False
                    If intY < 8 Then
                        If picSpot(intX, intY).BackColor = Color.Blue Then
                            intWin += 1
                            Call Win(intX, intY + 1, intPos, intWin, blnUse)
                        End If
                    End If
                End If
            ElseIf intPos = 7 Then
                If blnUse = True And intX < 7 And intY > 1 Then
                    blnUse = False
                    If picSpot(intX + 1, intY - 1).BackColor = Color.Blue Then
                        intWin += 1
                        Call Win(intX, intY, intPos, intWin, blnUse)
                    Else
                        Call Win(intX, intY, intPos, intWin, blnUse)
                    End If
                ElseIf blnBot = True Then
                    If intX > 1 And intY < 7 Then
                        If picSpot(intX - 1, intY + 1).BackColor = Color.Blue Then
                            intWin += 1
                            Call Win(intX - 1, intY + 1, intPos, intWin, blnUse)
                        End If
                    End If
                Else
                    blnUse = False
                    If intX > 0 And intY < 8 Then
                        If picSpot(intX, intY).BackColor = Color.Blue Then
                            intWin += 1
                            Call Win(intX - 1, intY + 1, intPos, intWin, blnUse)
                        End If
                    End If
                End If
            Else
                If blnUse = True And intX < 7 Then
                    blnUse = False
                    If picSpot(intX + 1, intY).BackColor = Color.Blue Then
                        intWin += 1
                        Call Win(intX, intY, intPos, intWin, blnUse)
                    Else
                        Call Win(intX, intY, intPos, intWin, blnUse)
                    End If
                ElseIf blnBot = True Then
                    If intX > 1 Then
                        If picSpot(intX - 1, intY).BackColor = Color.Blue Then
                            intWin += 1
                            Call Win(intX - 1, intY, intPos, intWin, blnUse)
                        End If
                    End If
                Else
                    blnUse = False
                    If intX > 0 Then
                        If picSpot(intX, intY).BackColor = Color.Blue Then
                            intWin += 1
                            Call Win(intX - 1, intY, intPos, intWin, blnUse)
                        End If
                    End If
                End If
            End If
        Else    'For Player2/Bot, is exact same as code for player 1, but looks for red pieces
            If intPos = 1 Then
                If blnUse = True And intX < 7 And intY < 7 Then
                    blnUse = False
                    If picSpot(intX + 1, intY + 1).BackColor = Color.Red Then
                        intWin += 1
                        Call Win(intX, intY, intPos, intWin, blnUse)
                    Else
                        Call Win(intX, intY, intPos, intWin, blnUse)
                    End If
                ElseIf blnBot = True Then
                    If intX > 1 And intY > 1 Then
                        If picSpot(intX - 1, intY - 1).BackColor = Color.Red Then
                            intWin += 1
                            Call Win(intX - 1, intY - 1, intPos, intWin, blnUse)
                        End If
                    End If
                Else
                    blnUse = False
                    If intX > 0 And intY > 0 Then
                        If picSpot(intX, intY).BackColor = Color.Red Then
                            intWin += 1
                            Call Win(intX - 1, intY - 1, intPos, intWin, blnUse)
                        End If
                    End If
                End If
            ElseIf intPos = 2 Then
                If blnUse = True And intY < 7 Then
                    blnUse = False
                    If picSpot(intX, intY + 1).BackColor = Color.Red Then
                        intWin += 1
                        Call Win(intX, intY, intPos, intWin, blnUse)
                    Else
                        Call Win(intX, intY, intPos, intWin, blnUse)
                    End If
                ElseIf blnBot = True Then
                    If intY > 1 Then
                        If picSpot(intX, intY - 1).BackColor = Color.Red Then
                            intWin += 1
                            Call Win(intX, intY - 1, intPos, intWin, blnUse)
                        End If
                    End If
                Else
                    blnUse = False
                    If intY > 0 Then
                        If picSpot(intX, intY).BackColor = Color.Red Then
                            intWin += 1
                            Call Win(intX, intY - 1, intPos, intWin, blnUse)
                        End If
                    End If
                End If
            ElseIf intPos = 3 Then
                If blnUse = True And intX > 1 And intY < 7 Then
                    blnUse = False
                    If picSpot(intX - 1, intY + 1).BackColor = Color.Red Then
                        intWin += 1
                        Call Win(intX, intY, intPos, intWin, blnUse)
                    Else
                        Call Win(intX, intY, intPos, intWin, blnUse)
                    End If
                ElseIf blnBot = True Then
                    If intX < 7 And intY > 1 Then
                        If picSpot(intX + 1, intY - 1).BackColor = Color.Red Then
                            intWin += 1
                            Call Win(intX + 1, intY - 1, intPos, intWin, blnUse)
                        End If
                    End If
                Else
                    blnUse = False
                    If intX < 8 And intY > 0 Then
                        If picSpot(intX, intY).BackColor = Color.Red Then
                            intWin += 1
                            Call Win(intX + 1, intY - 1, intPos, intWin, blnUse)
                        End If
                    End If
                End If
            ElseIf intPos = 4 Then
                If blnUse = True And intX > 1 Then
                    blnUse = False
                    If picSpot(intX - 1, intY).BackColor = Color.Red Then
                        intWin += 1
                        Call Win(intX, intY, intPos, intWin, blnUse)
                    Else
                        Call Win(intX, intY, intPos, intWin, blnUse)
                    End If
                ElseIf blnBot = True Then
                    If intX < 7 Then
                        If picSpot(intX + 1, intY).BackColor = Color.Red Then
                            intWin += 1
                            Call Win(intX + 1, intY, intPos, intWin, blnUse)
                        End If
                    End If
                Else
                    blnUse = False
                    If intX < 8 Then
                        If picSpot(intX, intY).BackColor = Color.Red Then
                            intWin += 1
                            Call Win(intX + 1, intY, intPos, intWin, blnUse)
                        End If
                    End If
                End If
            ElseIf intPos = 5 Then
                If blnUse = True And intX > 1 And intY > 1 Then
                    blnUse = False
                    If picSpot(intX - 1, intY - 1).BackColor = Color.Red Then
                        intWin += 1
                        Call Win(intX, intY, intPos, intWin, blnUse)
                    Else
                        Call Win(intX, intY, intPos, intWin, blnUse)
                    End If
                ElseIf blnBot = True Then
                    If intX < 7 And intY < 7 Then
                        If picSpot(intX + 1, intY + 1).BackColor = Color.Red Then
                            intWin += 1
                            Call Win(intX + 1, intY + 1, intPos, intWin, blnUse)
                        End If
                    End If
                Else
                    blnUse = False
                    If intX < 8 And intY < 8 Then
                        If picSpot(intX, intY).BackColor = Color.Red Then
                            intWin += 1
                            Call Win(intX + 1, intY + 1, intPos, intWin, blnUse)
                        End If
                    End If
                End If
            ElseIf intPos = 6 Then
                If blnUse = True And intY > 1 Then
                    blnUse = False
                    If picSpot(intX, intY - 1).BackColor = Color.Red Then
                        intWin += 1
                        Call Win(intX, intY, intPos, intWin, blnUse)
                    Else
                        Call Win(intX, intY, intPos, intWin, blnUse)
                    End If
                ElseIf blnBot = True Then
                    If intY < 7 Then
                        If picSpot(intX, intY + 1).BackColor = Color.Red Then
                            intWin += 1
                            Call Win(intX, intY + 1, intPos, intWin, blnUse)
                        End If
                    End If
                Else
                    blnUse = False
                    If intY < 8 Then
                        If picSpot(intX, intY).BackColor = Color.Red Then
                            intWin += 1
                            Call Win(intX, intY + 1, intPos, intWin, blnUse)
                        End If
                    End If
                End If
            ElseIf intPos = 7 Then
                If blnUse = True And intX < 7 And intY > 1 Then
                    blnUse = False
                    If picSpot(intX + 1, intY - 1).BackColor = Color.Red Then
                        intWin += 1
                        Call Win(intX, intY, intPos, intWin, blnUse)
                    Else
                        Call Win(intX, intY, intPos, intWin, blnUse)
                    End If
                ElseIf blnBot = True Then
                    If intX > 1 And intY < 7 Then
                        If picSpot(intX - 1, intY + 1).BackColor = Color.Red Then
                            intWin += 1
                            Call Win(intX - 1, intY + 1, intPos, intWin, blnUse)
                        End If
                    End If
                Else
                    blnUse = False
                    If intX > 0 And intY < 8 Then
                        If picSpot(intX, intY).BackColor = Color.Red Then
                            intWin += 1
                            Call Win(intX - 1, intY + 1, intPos, intWin, blnUse)
                        End If
                    End If
                End If
            Else
                If blnUse = True And intX < 7 Then
                    blnUse = False
                    If picSpot(intX + 1, intY).BackColor = Color.Red Then
                        intWin += 1
                        Call Win(intX, intY, intPos, intWin, blnUse)
                    Else
                        Call Win(intX, intY, intPos, intWin, blnUse)
                    End If
                ElseIf blnBot = True Then
                    If intX > 1 Then
                        If picSpot(intX - 1, intY).BackColor = Color.Red Then
                            intWin += 1
                            Call Win(intX - 1, intY, intPos, intWin, blnUse)
                        End If
                    End If
                Else
                    blnUse = False
                    If intX > 0 Then
                        If picSpot(intX, intY).BackColor = Color.Red Then
                            intWin += 1
                            Call Win(intX - 1, intY, intPos, intWin, blnUse)
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub tmrDrop_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrDrop.Tick
        Static intZ As Integer, intY As Integer, intFix As Integer
        Dim strPlayer As String
        If intPlayer = 1 Then   'If player 1
            strPlayer = "Blue"  'Blue piece being dropped
        Else    'player 2
            strPlayer = "Red"   'Red piece being dropped
        End If
        If intZ = 0 Then    'First step in cycle
            picSpot(intStart, intY + 1).Image = My.Resources.ResourceManager.GetObject(strPlayer + 1.ToString)
            intFix = 1  'Keeps the bottom of the piece ahead of the cycle                                       
            intZ += 1   'moves on the cycle                                                                     
        Else
            If intZ > 2 Then 'tests for next step in cycle
                intZ = 1    'resets cycle
                intY += 1   'moves the piece down
            End If
            If intZ = 1 Then    'tests for step in cycle
                picSpot(intStart, intY + intFix).Image = My.Resources.Empty 'resets the image behind the pice
                picSpot(intStart, intY + 1).Image = My.Resources.ResourceManager.GetObject(strPlayer + 2.ToString) 'moves the piece on
                intFix = 0  'turns off the push
            ElseIf intZ = 2 Then    'Next step in cycle
                picSpot(intStart, intY + 1).Image = My.Resources.ResourceManager.GetObject(strPlayer + 3.ToString)  'next piece position
                picSpot(intStart, intY + 2).Image = My.Resources.ResourceManager.GetObject(strPlayer + 1.ToString)  'next piece position
            Else
                picSpot(intStart, intY + 1).Image = My.Resources.Empty  'next piece position
                picSpot(intStart, intY + 1).Image = My.Resources.ResourceManager.GetObject(strPlayer + 2.ToString)  'next piece position
            End If
            intZ += 1   'moves on the cycle
            If intY = intStop - 1 And intZ = 2 Then 'if the piece has reached it's destination 
                intZ = 0    'resets cycle
                intY = 0    'resets Y position
                tmrDrop.Enabled = False 'ends the dropping
                If intPlayer = 1 Then   'if the user just went,
                    Call Bot(intY)  'bot makes his move
                End If
            End If
        End If
    End Sub
    Function rand(ByVal intLow As Integer, ByVal intHigh As Integer)
        Dim intRnum As Integer                                  '}random function
        intRnum = Int(Rnd() * (intHigh - intLow + 1) + intLow)  '}
        Return intRnum                                          '}
    End Function
    Sub Bot(ByVal intY As Integer)
        Dim intOpt(7) As Integer, intMost(5) As Integer, intChose(7, 7) As Integer
        Dim intHigh As Integer, intH As Integer, intRnum As Integer, intWin As Integer, blnUse As Boolean, intChosen As Integer, blnRand As Boolean, intRtest As Integer, intYChange As Integer, blnDiff As Boolean, intX As Integer
        If Mid(lblP2.Text, 1, 3) = "Bot" And blnOver = False Then 'Bot
            intPlayer = 2   'changes player
            intAmnt += 1    'next turn
            If intAmnt = 2 And intDif >= 3 Then 'if first time bot makes move, and bot is on hard   }If first turn, piece is placed next to where user 1 places theier piece to
                If intStart = 1 Then        '}makes sure move stays in bounds                       }make sure that the player can't trap the bot within 4 turns
                    intRnum = 1             '}                                                      }
                ElseIf intStart = 7 Then    '}                                                      }
                    intRnum = -1            '}                                                      }
                Else                                                                            '   }    
                    intRnum = rand(-1, 0)   'choses a random position                               }
                    If intRnum = 0 Then 'if zero is chosen                                          }
                        intRnum = 1 'changes the position to 1                                      }
                    End If
                End If

                intStart = intStart + intRnum   'choses the column of the first piece
                picSpot(intStart, 7).BackColor = Color.Red  'places the piece
                tmrDrop.Enabled = True
            Else
                If intDif >= 2 Then 'if bot is medium or hard
                    blnBot = True   'if bot
                    For j = 1 To 7  'tests each possible move
                        intHigh = 0
                        If picSpot(j, 1).BackColor = Color.Gray Then 'makes sure that their is room in the column it's checking
                            Call Fall(j, intY)  'checks for how far the piece will drop
                            For i = 1 To 8  'Tests each position
                                blnUse = True   'if first use
                                intWin = 0  'resets points
                                Call Win(j, intY, i, intWin, blnUse)    'checks how many points will be earned if this move is made
                                If intWin > intHigh Then    'checks to see if this position is the most possible points in this column
                                    intHigh = intWin    'sets most points in this column
                                End If
                            Next i
                            If intHigh >= 3 Then    'If 3 points or more are scored, then it's a winning move
                                intOpt(j) = 5   'this is the highest valued move
                            Else
                                intOpt(j) = intHigh 'values the column at how many points it earned
                            End If

                            intPlayer = 1   'pretends to be the other player to see if there is anywhere the bot can blocked
                            intHigh = 0 'resets highest value
                            For i = 1 To 8  'Testing for blocks
                                blnUse = True   'first check
                                intWin = 0  'resets points
                                Call Win(j, intY, i, intWin, blnUse)    'tests for how many points the player can earn
                                If intWin > intHigh Then    'gets highest value for the column
                                    intHigh = intWin
                                End If
                                If intHigh >= 3 And intOpt(j) <> 5 Then 'if more than 3 points are scored, the player will win if not blocked/ tests to make sure the bot can't already win
                                    intOpt(j) = 4   'values the move as a block (second highest valued move)
                                End If
                            Next i
                            intPlayer = 2   'Changes back to bot
                            intMost(intOpt(j)) += 1 'increases the amount of possible moves to earn that score
                            intChose(intOpt(j), intMost(intOpt(j))) = j 'allows the ability to track down the the move seleccted later on
                        End If
                    Next j
                    If intMost(5) > 0 Then      '}Choses which type of move(value) will be chosen based on the highest possible
                        intH = intMost(5) 'the amount of total moves with this value'}
                        intChosen = 5           '}|
                    ElseIf intMost(4) > 0 Then  '}|
                        intH = intMost(4)       '}|
                        intChosen = 4           '}V
                    ElseIf intMost(3) > 0 Then  '}
                        intH = intMost(3)       '}
                        intChosen = 3           '}
                    ElseIf intMost(2) > 0 Then  '}
                        intH = intMost(2)       '}
                        intChosen = 2           '}
                    ElseIf intMost(1) > 0 Then  '}
                        intH = intMost(1)       '}
                        intChosen = 1           '}
                    Else                        '}
                        intChosen = 0           '}
                        intH = intMost(0)       '}
                    End If
                    intRnum = rand(1, intH) 'Choses a random move with highest value possible
                    intRtest = intRnum  'declares which move is being tested
                    Call Fall(intChose(intChosen, intRnum), intY)   'sees how far the move can go down
                    intYChange = intY   'declares the y value being tested on
                    If intChosen <= 3 And intY <> 1 And intDif >= 3 Then  'Check for setups
                        picSpot(intChose(intChosen, intRnum), intYChange).BackColor = Color.Red 'Simulates the player moking a move in the chosen column
                        Call Fall(intChose(intChosen, intRnum), intY)   'shows new lowest position, on top of simulated move
                        intPlayer = 1   'pretends to be othe player
                        intHigh = 0 'resets high
                        For i = 1 To 8  'tests each direction
                            blnUse = True   'first check
                            intWin = 0  'resets points
                            Call Win(intChose(intChosen, intRnum), intY, i, intWin, blnUse) 'sees how many points the player will earn
                            If intWin > intHigh Then    'checks for highest points at the column
                                intHigh = intWin
                            End If
                        Next
                        intWin = intHigh    'sets the points at highest for the column
                        blnRand = False 'hasn't test other options yet
                        picSpot(intChose(intChosen, intRtest), intYChange).BackColor = Color.Gray   'resets simulated move
                        Do While intWin >= 3    'if simulated move produces a win for the player
                            blnDiff = False 'if first move tested
                            Call Fall(intChose(intChosen, intRnum), intY) 'checks for lowest position
                            intYChange = intY   'sets the y where the move is being simulated
                            picSpot(intChose(intChosen, intRnum), intY).BackColor = Color.Red   'places simulated move
                            Call Fall(intChose(intChosen, intRnum), intY)   'sets new lowest position
                            For i = 1 To 8  'tests each driection
                                blnUse = True   'first check
                                intWin = 0  'resets points
                                Call Win(intChose(intChosen, intRnum), intY, i, intWin, blnUse) 'checks for points
                                If intWin >= 3 Then 'if winning move
                                    picSpot(intChose(intChosen, intRnum), intYChange).BackColor = Color.Gray    'resets simulated move
                                    If blnRand = False Then 'if new rnum has not been produced yet
                                        blnRand = True  'shows that a new rnum has been produced
                                        intRnum = 1 'tests first rnum in value
                                        i = 10  'leaves the direction check
                                        blnDiff = True  'shows that a new move is being tested
                                    ElseIf intRnum < intH Then  'if there are more options in the value being tested
                                        intRnum += 1    'checks in rnum
                                        i = 10  'leaves direction check
                                        blnDiff = True  'new move being tested
                                    Else
                                        If intChosen = 0 Then   'if last possible value
                                            intWin = 0  'bot accepts bad move, bc there are no other options
                                        Else
                                            If intChose(intChosen - 1, 1) = 0 Then  'if there are no other values
                                                If intChosen = 1 Then   'if last possible move
                                                    intWin = 0  'bot accepts bad move
                                                ElseIf intChose(intChosen - 2, 1) <> 0 Then 'if the value 1 less than the current value beingtested doesn;t have any possible moves
                                                    intChosen -= 2  'the new value being tested is two less than previous value
                                                    blnDiff = True  'new value being tested
                                                Else
                                                    intWin = 0  'bot accepts move
                                                End If
                                            Else
                                                intChosen -= 1  'checks another value
                                                intRnum = 1 'checks first of the other value
                                                intWin = 10 'tests if new move isn't a losing move
                                                intH = intMost(intChosen)   'finds the amount of possible moves for the new value being tested
                                                i = 10  'leaves direction check
                                                blnDiff = True  'tests new value
                                            End If
                                        End If
                                    End If
                                End If
                            Next
                            If blnDiff = False Then 'if there isn't a new value being tested
                                picSpot(intChose(intChosen, intRnum), intYChange).BackColor = Color.Gray 'resets original simulation 
                            End If
                        Loop
                        intPlayer = 2   'goes back to bot
                    End If
                    intX = intChose(intChosen, intRnum) 'choses the column where the piece will be placed
                Else    'if on lowest possible difficulty
                    intX = rand(1, 7)   'bot choses a rando move
                    Call Fall(intX, intY)   'sees how much room there is in the column chosen
                    Do While intY <= 0  'tests to make sure that there is room in the selected column
                        intX = rand(1, 7)   'looks for new value
                        Call Fall(intX, intY)   'sees how much room there is in the column chosen
                    Loop
                End If

                Call Fall(intX, intY)   'sees how for down the move shosen will go
                picSpot(intX, intY).BackColor = Color.Red   'places the move
                intStart = intX 'shows which column the piece will be placed in
                intStop = intY  'shows how far down the piece will drop

                blnBot = False  'turns off bot
                If blnOver = False Then 'tests to make sure the game isn't over
                    tmrDrop.Enabled = True  'drops piece
                    For i = 1 To 8  'tests to see if piece dropped is a winning move
                        blnUse = True   'first check
                        intWin = 0  'resets points
                        Call Win(intX, intY, i, intWin, blnUse) 'sees how many points earned for piece in specific direction
                        If intWin >= 4 Then 'if winning move
                            i = 10  'leaves direction loop
                            intAmnt = 0 'resets turns
                            intP2W += 1 'increases wins for the bot
                            lblP2P.Text = intP2W.ToString + "|" 'readjust amount of wins for the bot
                            strWinner = "Loser" 'declares that the user is a loser 
                            frmOver.Show()  'shows game over screen
                            blnOver = True  'declares that the game is over
                        End If
                    Next
                End If
            End If
        End If
    End Sub

    Private Sub RulesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RulesToolStripMenuItem.Click
        frmRules.Show() 'shows the rules table
    End Sub

    Private Sub EasyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EasyToolStripMenuItem.Click
        Dim intYN As Integer, intWordS As Integer
        intYN = MsgBox("Are you sure you want to change difficulty? The current game will restart, and scores will be reset.", MsgBoxStyle.YesNo, "Difficulty Change")    'warns the user about changing the difficulty
        If intYN = 6 Then 'if yes
            lblP2.Text = "Bot " + strNames(rand(0, 59)) 'finds bot new name
            intWordS = Len(lblP2.Text) * 19             '}updates new name, and position of points and name
            lblP2.Left = intP2Start - intWordS          '}
            lblP2P.Left = intP2Start - intWordS - 40    '}
            lblP2.Left = intP2Start - intWordS          '}
            intDif = 1  'new bot difficulty
            intAmnt = 0                         '} resets game
            intP1W = 0                          '}  
            intP2W = 0                          '}
            lblP2P.Text = intP2W.ToString + "|" '}
            lblP1P.Text = "|" + intP1W.ToString '}
            Call restart()                      '}
        End If
    End Sub
    Sub restart()
        For x = 1 To 7
            For y = 1 To 7
                With picSpot(x, y)
                    .Image = My.Resources.Empty '}removes all pieces from the board
                    .BackColor = Color.Gray     '}
                End With
            Next
        Next
    End Sub

    Private Sub MediumToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MediumToolStripMenuItem.Click
        Dim intYN As Integer, intWordS As Integer
        intYN = MsgBox("Are you sure you want to change difficulty? The current game will restart, and scores will be reset.", MsgBoxStyle.YesNo, "Difficulty Change") 'warns the user about changing the difficulty
        If intYN = 6 Then 'if yes
            lblP2.Text = "Bot " + strNames(rand(60, 114))   'finds bot new name
            intWordS = Len(lblP2.Text) * 19         '}updates new name, and position of points and name
            lblP2.Left = intP2Start - intWordS      '}
            lblP2P.Left = intP2Start - intWordS - 40 '}
            lblP2.Left = intP2Start - intWordS      '}
            intDif = 2  'new difficulty
            intAmnt = 0                             '}resets game
            intP1W = 0                              '}
            intP2W = 0                              '}
            lblP2P.Text = intP2W.ToString + "|"     '}
            lblP1P.Text = "|" + intP1W.ToString     '}
            Call restart()                          '}
        End If
    End Sub

    Private Sub HardToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HardToolStripMenuItem.Click
        Dim intYN As Integer, intWordS As Integer
        intYN = MsgBox("Are you sure you want to change difficulty? The current game will restart, and scores will be reset.", MsgBoxStyle.YesNo, "Difficulty Change") 'warns the user about changing the difficulty
        If intYN = 6 Then 'if yes
            lblP2.Text = "Bot " + strNames(rand(115, 141))  'finds new bot's name
            intWordS = Len(lblP2.Text) * 19         '}updates new name, and position of points and name
            lblP2.Left = intP2Start - intWordS      '}
            lblP2P.Left = intP2Start - intWordS - 40 '}
            lblP2.Left = intP2Start - intWordS      '}
            intDif = 3  'New difficulty
            intAmnt = 0                         '}resets game
            intP1W = 0                          '}
            intP2W = 0                          '}
            lblP2P.Text = intP2W.ToString + "|" '}
            lblP1P.Text = "|" + intP1W.ToString '}
            Call restart()                      '}
        End If
    End Sub

    Private Sub QuitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles QuitToolStripMenuItem.Click
        Me.Close()  'closes game
    End Sub

    Private Sub RefreshStatsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RefreshStatsToolStripMenuItem.Click
        Dim intYN As Integer
        intYN = MsgBox("Are you sure you want to refresh the score?", MsgBoxStyle.YesNo, "Refresh Score")   'warns user about refreshing score
        If intYN = 6 Then   'if yes
            intP1W = 0                          '}resets score
            intP2W = 0                          '}
            lblP2P.Text = intP2W.ToString + "|" '}
            lblP1P.Text = "|" + intP1W.ToString '}
        End If
    End Sub
    Private Sub SinglePlayerToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SinglePlayerToolStripMenuItem.Click
        Dim intYN As Integer, intWordS As Integer
        If SinglePlayerToolStripMenuItem.Text = "Single Player" Then    'if in two player mode
            intYN = MsgBox("Are you sure you want to switch to single player? The current game will restart, scores will be reset, and difficulty will be defaulted to easy.", MsgBoxStyle.YesNo, "Single Player") 'warns about switching to two player mode
            If intYN = 6 Then   'if yes
                SinglePlayerToolStripMenuItem.Text = "Two Player"   'changes option to two player
                RestartCounterToolStripMenuItem.Visible = True  'adds difficulty option
                lblP2.Text = "Bot " + strNames(rand(0, 59)) '}gets new bot name and readjusts postion of name and points
                intWordS = Len(lblP2.Text) * 19             '}
                lblP2.Left = intP2Start - intWordS          '}
                lblP2P.Left = intP2Start - intWordS - 40    '}
                lblP2.Left = intP2Start - intWordS          '}
                intDif = 1  'defaults difficulty to easy
                intAmnt = 0                         '}restarts board
                blnBot = True                       '}
                intP1W = 0                          '}
                intP2W = 0                          '}
                lblP2P.Text = intP2W.ToString + "|" '}
                lblP1P.Text = "|" + intP1W.ToString '}
                Call restart()                      '}
            End If
        Else    'if in single player mode 
            intYN = MsgBox("Are you sure you want to switch to Two player? The current game will restart, and scores will be reset.", MsgBoxStyle.YesNo, "Two Player") 'warns the user
            If intYN = 6 Then   'if yes
                SinglePlayerToolStripMenuItem.Text = "Single Player"    'changes option to single player
                RestartCounterToolStripMenuItem.Visible = False 'removes difficulty option
                lblP2.Text = "Player 2"                 '}gets new name, and positions
                intWordS = Len(lblP2.Text) * 19         '}
                lblP2.Left = intP2Start - intWordS      '}
                lblP2P.Left = intP2Start - intWordS - 40 '}
                lblP2.Left = intP2Start - intWordS      '}
                intDif = 1 'default difficulty to easy
                intAmnt = 0                         '}resets board
                blnBot = False                      '}
                intP1W = 0                          '}
                intP2W = 0                          '}
                lblP2P.Text = intP2W.ToString + "|" '}
                lblP1P.Text = "|" + intP1W.ToString '}
                Call restart()                      '}
            End If
        End If
    End Sub
    Sub Names()
        strNames(0) = "Albert"      '}|Database for names
        strNames(1) = "Allen"       '}|
        strNames(2) = "Bert"        '}V
        strNames(3) = "Bob"
        strNames(4) = "Cecil"
        strNames(5) = "Clarence"
        strNames(6) = "Elliot"
        strNames(7) = "Elmer"
        strNames(8) = "Ernie"
        strNames(9) = "Eugene"
        strNames(10) = "Fergus"
        strNames(11) = "Ferris"
        strNames(12) = "Frank"
        strNames(13) = "Frasier"
        strNames(14) = "Fred"
        strNames(15) = "George"
        strNames(16) = "Graham"
        strNames(17) = "Harvey"
        strNames(19) = "Irwin"
        strNames(20) = "Lester"
        strNames(21) = "Marvin"
        strNames(22) = "Neil"
        strNames(23) = "Niles"
        strNames(25) = "Oliver"
        strNames(26) = "Opie"
        strNames(27) = "Toby"
        strNames(28) = "Ulric"
        strNames(29) = "Ulysses"
        strNames(30) = "Uri"
        strNames(31) = "Waldo"
        strNames(32) = "Wally"
        strNames(33) = "Walt"
        strNames(34) = "Wesley"
        strNames(35) = "Yanni"
        strNames(36) = "Yogi"
        strNames(37) = "Yuri"
        strNames(38) = "Alfred"
        strNames(39) = "Bill"
        strNames(40) = "Brandon"
        strNames(41) = "Calvin"
        strNames(42) = "Dean"
        strNames(43) = "Ethan"
        strNames(44) = "Harold"
        strNames(45) = "Henry"
        strNames(46) = "Irving"
        strNames(47) = "Jason"
        strNames(48) = "Josh"
        strNames(49) = "Martin"
        strNames(50) = "Nick"
        strNames(51) = "Norm"
        strNames(52) = "Orin"
        strNames(53) = "Pat"
        strNames(54) = "Perry"
        strNames(55) = "Ron"
        strNames(56) = "Shawn"
        strNames(57) = "Tim"
        strNames(58) = "Will"
        strNames(59) = "Wyatt"
        'MEDIUM
        strNames(60) = "Adam"
        strNames(61) = "Andy"
        strNames(62) = "Chris"
        strNames(63) = "Colin"
        strNames(64) = "Dennis"
        strNames(65) = "Doug"
        strNames(66) = "Gary"
        strNames(67) = "Grant"
        strNames(68) = "Greg"
        strNames(69) = "Ian"
        strNames(70) = "Jerry"
        strNames(71) = "Jon"
        strNames(72) = "Keith"
        strNames(73) = "Mark"
        strNames(74) = "Mike"
        strNames(75) = "Nate"
        strNames(76) = "Paul"
        strNames(77) = "Scott"
        strNames(78) = "Steve"
        strNames(79) = "Tom"
        strNames(80) = "Yahn"
        strNames(81) = "Adrian"
        strNames(82) = "Brad"
        strNames(83) = "Connor"
        strNames(84) = "Dave"
        strNames(85) = "Derek"
        strNames(86) = "Don"
        strNames(87) = "Eric"
        strNames(88) = "Erik"
        strNames(89) = "Finn"
        strNames(90) = "Jeff"
        strNames(91) = "Kevin"
        strNames(92) = "Reed"
        strNames(93) = "Rick"
        strNames(94) = "Ted"
        strNames(95) = "Troy"
        strNames(96) = "Wade"
        strNames(97) = "Wayne"
        strNames(98) = "Xander"
        strNames(99) = "Xavier"
        strNames(100) = "Chad"
        strNames(101) = "Chet"
        strNames(102) = "Gabe"
        strNames(103) = "Hank"
        strNames(104) = "Ivan"
        strNames(105) = "Jim"
        strNames(106) = "Joe"
        strNames(107) = "John"
        strNames(108) = "Tony"
        strNames(109) = "Tyler"
        strNames(111) = "Victor"
        strNames(112) = "Vladimir"
        strNames(113) = "Zane"
        strNames(114) = "Zim"
        'Hard
        strNames(115) = "Cory"
        strNames(116) = "Quinn"
        strNames(117) = "Seth"
        strNames(118) = "Vinny"
        strNames(119) = "Arnold"
        strNames(120) = "Brett"
        strNames(121) = "Kurt"
        strNames(122) = "Kyle"
        strNames(123) = "Moe"
        strNames(124) = "Quade"
        strNames(125) = "Quintin"
        strNames(126) = "Ringo"
        strNames(127) = "Rip"
        strNames(128) = "Zach"
        strNames(129) = "Cliffe"
        strNames(130) = "Crusher"
        strNames(131) = "Gunner"
        strNames(132) = "Minh"
        strNames(133) = "Pheonix"
        strNames(134) = "Rock"
        strNames(135) = "Shark"
        strNames(136) = "Steel"
        strNames(137) = "Stone"
        strNames(138) = "Vitaliy"
        strNames(139) = "Wolf"
        strNames(140) = "Zed"
        strNames(141) = "ChrisPage"
    End Sub
    Private Sub tmrHighL_Tick(sender As System.Object, e As System.EventArgs) Handles tmrHighL.Tick 'always run to see where you will be placing your piece
        Dim intX As Integer, intM As Integer
        intM = MousePosition.X - Me.Location.X  'finds coorinates of cursor on the form only
        If intM <= 100 Then     '}finds where ther cursor is, and which column its on
            intX = 1            '}
        ElseIf intM <= 200 Then '}
            intX = 2            '}
        ElseIf intM <= 300 Then '}
            intX = 3            '}
        ElseIf intM <= 400 Then '}
            intX = 4            '}
        ElseIf intM <= 500 Then '}
            intX = 5            '}
        ElseIf intM <= 600 Then '}
            intX = 6            '}
        Else                    '}
            intX = 7            '}
        End If
        For x = 1 To 7
            If x <> intX Then   'if the cursor isn't over the coluumn
                picHighL(x).BackColor = Color.Gray  'resets the highlight to gray
            Else    'if cursor is over the column
                picHighL(intX).BackColor = Color.White  'highlighter turns white
            End If
        Next
    End Sub
End Class
