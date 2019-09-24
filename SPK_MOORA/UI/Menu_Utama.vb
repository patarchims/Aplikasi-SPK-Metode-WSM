Imports System.Data.OleDb
Imports System.Linq
Imports MySql.Data.MySqlClient
Imports JS_FlatMaterialUI.CustomMessageBox
Public Class Menu_Utama
    Private Sub Menu_Utama_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TampilAwal()
    End Sub
    Sub TampilAwal()
        PanelUtama.Controls.Clear()
        Homepage.TopLevel = False
        PanelUtama.Controls.Add(Homepage)
        Homepage.Show()
    End Sub
    Public Function rubahtgl(ByVal tgl As String)
        Return Replace(Replace(Replace(Replace(Replace(Replace(Replace(tgl, "Sunday", "Minggu"), "Monday", "Senin"), "Tuesday", "Selasa"), "Wednesday", "Rabu"), "Thursday", "Kamis"), "Friday", "Jumat"), "Saturday", "Sabtu")
    End Function


    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
        Try
            txtWaktu.Text = Format(Now, "hh:mm:ss tt")
            txtHari.Text = rubahtgl(Format(CDate(Now.Date), "dddd, dd MMMM yyyy"))
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
    End Sub
    Sub TampilKriteria()
        PanelUtama.Controls.Clear()
        Kriteria.TopLevel = False
        PanelUtama.Controls.Add(Kriteria)
        Kriteria.Show()
    End Sub

    Sub TampilSubKriteria()
        PanelUtama.Controls.Clear()
        Sub_Kriteria.TopLevel = False
        PanelUtama.Controls.Add(Sub_Kriteria)
        Sub_Kriteria.Show()
    End Sub

    Sub TampilPemainFutsal()
        PanelUtama.Controls.Clear()
        Alternatif.TopLevel = False
        PanelUtama.Controls.Add(Alternatif)
        Alternatif.Show()
    End Sub

    Sub TampilGrafik()
        PanelUtama.Controls.Clear()
        Grafik_Penilaian.TopLevel = False
        PanelUtama.Controls.Add(Grafik_Penilaian)
        Grafik_Penilaian.Show()
    End Sub


    Sub TampilLaporan()
        PanelUtama.Controls.Clear()
        Report_Rangking.TopLevel = False
        PanelUtama.Controls.Add(Report_Rangking)
        Report_Rangking.Show()
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Dim Message As DialogResult
        Message = ShowMessageBox("Ingin Keluar Dari Aplikasi Ini?", "Keluar", MessageBoxType.Question)
        If Message = DialogResult.Yes Then
            End
        Else
            Exit Sub
        End If
    End Sub

    Private Sub btnHomepage_Click(sender As Object, e As EventArgs) Handles btnHomepage.Click
        TampilAwal()
        Homepage.JumlahKriteria()
        Homepage.JumlahPemain()
        Homepage.JumlahSUBKriteria()
        Homepage.JumlahPenilaian()
    End Sub

    Private Sub btnKriteria_Click(sender As Object, e As EventArgs) Handles btnKriteria.Click
        TampilKriteria()
    End Sub

    Private Sub btnSubKriteria_Click(sender As Object, e As EventArgs) Handles btnSubKriteria.Click
        TampilNilaiKriteria()
        Nilai_SubKriteria.Tampil_DataKriteria()
        Nilai_SubKriteria.TampilGrid()
    End Sub

    Sub TampilNilaiKriteria()
        PanelUtama.Controls.Clear()
        Nilai_SubKriteria.TopLevel = False
        PanelUtama.Controls.Add(Nilai_SubKriteria)
        Nilai_SubKriteria.Show()
    End Sub
    Private Sub btnKaryawan_Click(sender As Object, e As EventArgs) Handles btnKaryawan.Click
        TampilPemainFutsal
    End Sub

    Private Sub btnPenilaian_Click(sender As Object, e As EventArgs) Handles btnPenilaian.Click
        TampilPenilaianWSM()
    End Sub
    Sub TampilPenilaianWSM()
        PanelUtama.Controls.Clear()
        Penilaian_WSM.TopLevel = False
        PanelUtama.Controls.Add(Penilaian_WSM)
        Penilaian_WSM.Show()
    End Sub

    Private Sub btnGrafik_Click(sender As Object, e As EventArgs) Handles btnGrafik.Click
        TampilGrafik()
    End Sub

    Private Sub btnLaporan_Click(sender As Object, e As EventArgs) Handles btnLaporan.Click
        TampilLaporan()
        Report_Rangking.RefreshReport()
    End Sub

    Private Sub btnMinimized_Click(sender As Object, e As EventArgs) Handles btnMinimized.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class