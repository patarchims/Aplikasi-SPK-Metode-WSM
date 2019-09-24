Public Class Splash
    Private Sub Splash_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label4.Text = ""

        Timer1.Start()
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Visible = True
        ProgressBar1.Value = ProgressBar1.Value + 2
        If (ProgressBar1.Value = 10) Then
            Label4.Text = "Membaca modul.."
        ElseIf (ProgressBar1.Value = 20) Then
            Label4.Text = "Mengaktifkan modul."
        ElseIf (ProgressBar1.Value = 40) Then
            Label4.Text = "Memulai modul.."
        ElseIf (ProgressBar1.Value = 60) Then
            Label4.Text = "Memuat modules.."
        ElseIf (ProgressBar1.Value = 80) Then
            Label4.Text = "Selesai memuat modul.."
        ElseIf (ProgressBar1.Value = 100) Then
            Menu_Utama.Show()
            Timer1.Enabled = False
            Me.Hide()
        End If
    End Sub
End Class