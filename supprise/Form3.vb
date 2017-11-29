
Public Class Form3
    Dim img() As Image = {My.Resources.smallpac1, My.Resources.smallpacrd2, My.Resources.smallpacD}
    Dim imgu() As Image = {My.Resources.smallpac1, My.Resources.smallpacru2, My.Resources.smallpacU}
    Dim imgr() As Image = {My.Resources.smallpac1, My.Resources.smallpacr1, My.Resources.smallpacR}
    Dim imgl() As Image = {My.Resources.smallpac1, My.Resources.smallpacrl2, My.Resources.smallpacL}
    Dim ran As New Random()
    Dim x() As Integer = {448, 826, 16, 16, 182, 385, 385, 385, 385, 385}
    Dim y() As Integer = {288, 348, 566, 15, 15, 249, 249, 249, 249, 249}

    Dim picCake(10) As PictureBox
    Dim point As Integer
    Dim rite As Boolean
    Dim lift As Boolean
    Dim up As Boolean
    Dim down As Boolean
    Dim d As Integer = 0
    Dim u As Integer = 0
    Dim l As Integer = 0
    Dim r As Integer = 0


    Private Sub Form3_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Right Then
            rite = True
        End If
        If e.KeyCode = Keys.Left Then
            lift = True
        End If
        If e.KeyCode = Keys.Up Then
            up = True
        End If
        If e.KeyCode = Keys.Down Then
            down = True
        ElseIf e.KeyCode = Keys.Escape Then
            End
        End If

    End Sub

    Private Sub Form3_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Right Then
            rite = False
        End If
        If e.KeyCode = Keys.Left Then
            lift = False
        End If
        If e.KeyCode = Keys.Up Then
            up = False
        End If
        If e.KeyCode = Keys.Down Then
            down = False
        End If
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        picCake(0) = Me.PictureBox2
        picCake(1) = Me.PictureBox7
        picCake(2) = Me.PictureBox8
        picCake(3) = Me.PictureBox9
        picCake(4) = Me.PictureBox10
        picCake(5) = Me.PictureBox11
        picCake(6) = Me.PictureBox12
        picCake(7) = Me.PictureBox13
        picCake(8) = Me.PictureBox14
        picCake(9) = Me.PictureBox15
        picCake(10) = Me.PictureBox16

    End Sub

    Private Sub RMTMove_Tick(sender As Object, e As EventArgs) Handles RMTMove.Tick

        If rite = True Then
            PictureBox1.Left += 3
        End If
        If lift = True Then
            PictureBox1.Left -= 3
        End If
        If up = True Then
            PictureBox1.Top -= 3
        End If
        If down = True Then
            PictureBox1.Top += 3
        End If

    End Sub

    Private Sub collionT_Tick(sender As Object, e As EventArgs) Handles collionT.Tick
        Randomize()
        Dim rx As Integer = ran.Next(0, 10)
        Dim ry As Integer = ran.Next(0, 10)

        If PictureBox1.Bounds.IntersectsWith(PictureBox3.Bounds) Then
            PictureBox1.Left += 30
        End If
        If PictureBox1.Bounds.IntersectsWith(PictureBox6.Bounds) Then
            PictureBox1.Top += 30
        End If
        If PictureBox1.Bounds.IntersectsWith(PictureBox4.Bounds) Then
            PictureBox1.Left -= 30
        End If
        If PictureBox1.Bounds.IntersectsWith(PictureBox5.Bounds) Then
            PictureBox1.Top -= 30
        End If
        If PictureBox1.Bounds.IntersectsWith(PictureBox20.Bounds) And PictureBox20.Visible = True Then
            PictureBox1.Left += 30
        End If
        If PictureBox1.Bounds.IntersectsWith(PictureBox19.Bounds) And PictureBox19.Visible = True Then
            PictureBox1.Top -= 30
        End If
        If PictureBox1.Bounds.IntersectsWith(PictureBox18.Bounds) And PictureBox18.Visible = True Then
            PictureBox1.Top += 30
        End If
        If PictureBox1.Bounds.IntersectsWith(PictureBox17.Bounds) And PictureBox17.Visible = True Then
            PictureBox1.Left -= 30
        End If
        If PictureBox1.Bounds.IntersectsWith(black1.Bounds) And black1.Visible = True Then
            PictureBox1.Visible = False
            PictureBox1.Left = x(rx)
            PictureBox1.Top = y(ry)
            PictureBox1.Visible = True
        End If
        For i = 0 To 10
            If PictureBox1.Bounds.IntersectsWith(picCake(i).Bounds) And picCake(i).Visible = True Then
                picCake(i).Visible = False
                point += 10
                Points(point)
                My.Computer.Audio.Play(My.Resources.credit, AudioPlayMode.Background)
            End If
        Next


    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If rite = True Then
            r += 1
            PictureBox1.Image = imgr(r)
            If r = 2 Or rite = False Then
                r = 0
                PictureBox1.Image = imgr(0)
            End If
        End If
        If lift = True Then
            l += 1
            PictureBox1.Image = imgl(l)
            If l = 2 Or lift = False Then
                l = 0
                PictureBox1.Image = imgl(0)
            End If
        End If
        If up = True Then
            u += 1
            PictureBox1.Image = imgu(u)
            If u = 2 Or up = False Then
                u = 0
                PictureBox1.Image = imgu(0)
            End If
        End If
        If down = True Then
            d += 1
            PictureBox1.Image = img(d)
            If d = 2 Or down = False Then
                d = 0
                PictureBox1.Image = img(0)
            End If
        End If
    End Sub
    Public Sub Points(ByVal a As Integer)

        If a = 110 Then
            RMTMove.Enabled = False
            collionT.Enabled = False
            Timer1.Enabled = False
            blackmove.Enabled = False
            blackoff.Enabled = False
            My.Computer.Audio.Play(My.Resources.intro, AudioPlayMode.BackgroundLoop)
            If MessageBox.Show("YOU HAVE WON THE GAME! GLAD YOU ATE THAT MUCH CAKE!", "HAPPY BIRTHDAY", MessageBoxButtons.OK) = DialogResult.OK Then
                End
            End If
        End If
    End Sub

    Private Sub blackmove_Tick(sender As Object, e As EventArgs) Handles blackmove.Tick
        Randomize()
        Dim n As Integer = ran.Next(0, 5)
        Dim rax As Int32 = ran.Next(16, 664)
        Dim ray As Int32 = ran.Next(16, 486)
        Select Case n
            Case 0
                black1.Visible = True
                black1.Left = rax
                black1.Top = ray
            Case 1
                black1.Visible = True
                black1.Left = rax
                black1.Top = ray
            Case 2
                black1.Visible = True
                black1.Left = rax
                black1.Top = ray
            Case 3
                black1.Visible = True
                black1.Left = rax
                black1.Top = ray
            Case 4
                black1.Visible = True
                black1.Left = rax
                black1.Top = ray
            Case 5
                black1.Visible = True
                black1.Left = rax
                black1.Top = ray
        End Select

    End Sub

    Private Sub blackoff_Tick(sender As Object, e As EventArgs) Handles blackoff.Tick
        Randomize()
        Dim w As Integer = ran.Next(0, 5)
        Dim oox As Int32 = ran.Next(16, 664)
        Dim ooy As Int32 = ran.Next(16, 486)
        Select Case w
            Case 0
                black1.Visible = False
                black1.Left = oox
                black1.Top = ooy
            Case 1
                black1.Visible = False
                black1.Left = oox
                black1.Top = ooy
            Case 2
                black1.Visible = False
                black1.Left = oox
                black1.Top = ooy
            Case 3
                black1.Visible = False
                black1.Left = oox
                black1.Top = ooy
            Case 4
                black1.Visible = False
                black1.Left = oox
                black1.Top = ooy
            Case 5
                black1.Visible = False
                black1.Left = oox
                black1.Top = ooy
        End Select
    End Sub
End Class