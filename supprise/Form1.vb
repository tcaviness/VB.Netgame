Imports System.Speech.Synthesis

Public Class frmbirth
    Private Sub frmbirth_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim x As New SpeechSynthesizer()
        x.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult)
        x.Speak("Happy birthday to you! Happy birthday to you!")
        x.Dispose()
        Timer1.Enabled = False
        Form2.Show()
        Me.Hide()
    End Sub
End Class
