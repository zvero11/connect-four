Public Class frmStart
    'Zachary Vero
    Public strVs As String, intDiff As Integer
    Private intLow As Integer, intHigh As Integer, strNames(141) As String
    Private Sub btn1v1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1v1.Click
        strVs = "Player 2"  'shows that the user is playing another player
        frmGame.Show()  'launches game screen
        Me.Close()  'closes startup screen
    End Sub
    Private Sub btn1vBot_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn1vBot.Click
        strVs = "Bot " + strNames(rand(intLow, intHigh))    'Choses the bot's name
        frmGame.Show()  'launches game screen
        Me.Close()  'closes startup screen
    End Sub
    Private Sub frmStart_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Randomize() 'makes sure all random numbers are truly random
        rbEasy.Checked = True   'default difficulty is Easy
        strNames(0) = "Albert"  '} "Database" for all of the possible bot names
        strNames(1) = "Allen"   '}
        strNames(2) = "Bert"    '}
        strNames(3) = "Bob"     '{V
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
    Function rand(ByVal intLow As Integer, intHigh As Integer) As Integer
        Dim intRnum As Integer                                  '}finds the random number
        intRnum = Int(Rnd() * (intHigh - intLow + 1) + intLow)  '}
        Return intRnum                                          '}
    End Function
    Private Sub rbEasy_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbEasy.CheckedChanged, rbMed.CheckedChanged, rbHard.CheckedChanged
        If rbEasy.Checked = True Then   '}Finds which difficulty was selected, and decides the selection of names for the bot based off of the difficulty of the bot
            intDiff = 1                 '}
            intHigh = 59                '}
            intLow = 0                  '}
        End If
        If rbMed.Checked = True Then    '}
            intDiff = 2                 '}
            intHigh = 114               '}
            intLow = 60                 '}
        End If
        If rbHard.Checked = True Then   '}
            intDiff = 3                 '}
            intHigh = 141               '}
            intLow = 115                '}
        End If
    End Sub
End Class