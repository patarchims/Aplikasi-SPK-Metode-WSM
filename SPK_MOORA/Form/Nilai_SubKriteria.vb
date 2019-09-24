Imports System.Data.OleDb
Imports MySql.Data.MySqlClient
Imports JS_FlatMaterialUI.CustomMessageBox
Public Class Nilai_SubKriteria
    Private Sub Nilai_SubKriteria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Tampil_DataKriteria()
        TampilGrid()
        TidakAktif()
    End Sub
    Sub TidakAktif()
        txtkd_subkriteria.Enabled = False
        cboKriteria.Enabled = False
        txtkodeKriteria.Hide()
        txtnama.Enabled = False
        txtnilai.Enabled = False
        btnSimpan.Enabled = False
        btnHapus.Enabled = False
        btnBatal.Enabled = False
        btnTambah.Enabled = True
    End Sub

    Sub Tampil_DataKriteria()
        On Error Resume Next
        cboKriteria.Items.Clear()
        cekkoneksi()
        sql = "
            SELECT * from tb_kriteria "
        sqlcommand = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
        Dr.Close()
        Dr = sqlcommand.ExecuteReader
        If Dr.HasRows Then
            Do Until Not Dr.Read
                cboKriteria.Items.Add(Dr!nama_kriteria)
            Loop
        Else
            cboKriteria.Items.Clear()
        End If
        tutupkoneksi()
    End Sub


    Sub Cari_KodeKriteria()
        On Error Resume Next
        txtkodeKriteria.Text = ""
        cekkoneksi()
        sql = "Select * From tb_kriteria where  nama_kriteria='" & cboKriteria.Text & "'"
        sqlcommand = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
        Dr.Close()
        Dr = sqlcommand.ExecuteReader
        If Dr.HasRows Then
            Do Until Not Dr.Read
                txtkodeKriteria.Text = Dr!id_kriteria
            Loop
        Else
            txtkodeKriteria.Text = ""
        End If
        tutupkoneksi()
    End Sub

    Private Sub cboKriteria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboKriteria.SelectedIndexChanged

    End Sub

    Private Sub cboKriteria_TextChanged(sender As Object, e As EventArgs) Handles cboKriteria.TextChanged
        Cari_KodeKriteria()
    End Sub
    Sub KodeOtomatis()
        tutupkoneksi()
        cekkoneksi()
        Dim strSementara As String = ""
        Dim strIsi As String = ""
        sqlcommand = New MySqlCommand("select * from tb_subkriteria order by id desc", conn)
        Dr = sqlcommand.ExecuteReader
        If Dr.Read Then
            strSementara = Microsoft.VisualBasic.Right(Dr.Item("id_subkriteria"), 2)
            strIsi = Val(strSementara) + 1
            txtkd_subkriteria.Text = "SK" & strIsi
        Else
            txtkd_subkriteria.Text = "SK1"
        End If
        cboKriteria.Focus()
        txtkd_subkriteria.Enabled = False
    End Sub
    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        btnTambah.Enabled = False
        btnSimpan.Enabled = True
        btnBatal.Enabled = True
        cboKriteria.Focus()
        AKtif()
        Tampil_DataKriteria()
        KodeOtomatis()
    End Sub
    Sub AKtif()
        txtnama.Enabled = True
        txtnilai.Enabled = True
        cboKriteria.Enabled = True
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Bersih()
        TidakAktif()
    End Sub
    Sub Bersih()
        txtkd_subkriteria.Text = ""
        txtkodeKriteria.Text = ""
        txtnilai.Text = ""
        cboKriteria.Text = ""
        txtnama.Text = ""
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Try
            If txtkodeKriteria.Text = "" Or txtnama.Text = "" Or txtnilai.Text = "" Then
                ShowMessageBox("Data Isian Harus Lengkap", "Critical", MessageBoxType.Critical)

            Else
                tutupkoneksi()
                cekkoneksi()
                sql = "SELECT * FROM tb_subkriteria WHERE id_subkriteria='" & Trim(txtkd_subkriteria.Text) & "'"
                sqlcommand = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                Dr.Close()
                Dr = sqlcommand.ExecuteReader()
                Dr.Read()
                If Not Dr.HasRows Then
                    sql = "INSERT INTO tb_subkriteria values ('" & txtkd_subkriteria.Text & "','" &
                        txtkodeKriteria.Text & "','" & txtnama.Text & "','" & txtnilai.Text & "')"
                    sqlcommand = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    tutupkoneksi()
                    cekkoneksi()
                    sqlcommand.ExecuteNonQuery()
                    tutupkoneksi()
                    TampilGrid()
                    ShowMessageBox("Data Berhasil Disimpan.", "Infomasi!", MessageBoxType.Information)
                    Call Bersih()
                    TidakAktif()
                Else
                    sql = "UPDATE tb_subkriteria set nama_subkriteria='" & txtnama.Text & "',nilai='" & txtnilai.Text & "' WHERE id_subkriteria='" & Trim(Kode.Text) & "'"
                    sqlcommand = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    tutupkoneksi()
                    cekkoneksi()
                    sqlcommand.ExecuteNonQuery()
                    tutupkoneksi()
                    TampilGrid()
                    ShowMessageBox("Data Berhasil Diubah.", "Infomasi!", MessageBoxType.Information)
                    Call Bersih()
                    TidakAktif()
                End If

            End If
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
    End Sub

    Sub TampilGrid()
        tutupkoneksi()
        cekkoneksi()
        Dim table As New DataTable()
        Dim Adapter As New MySqlDataAdapter("SELECT id_subkriteria,  nama_subkriteria, nama_kriteria, nilai FROM tb_subkriteria inner join tb_kriteria on tb_kriteria.id_kriteria=tb_subkriteria.id_kriteria ", conn)
        Adapter.Fill(table)
        GrdView.DataSource = table
        GrdView.Refresh()
        tutupkoneksi()
        AturDataGrid()
    End Sub

    Sub AturDataGrid()
        Try
            With GrdView
                .Columns(0).HeaderText = "KODE SUB KRITERIA"
                .Columns(1).HeaderText = "NAMA SUB KRITERIA"
                .Columns(2).HeaderText = "KRITERIA"
                .Columns(3).HeaderText = "NILAI"

                .Columns(0).Width = 130
                .Columns(1).Width = 400
                .Columns(2).Width = 165
                .Columns(3).Width = 100


                .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(55, 172, 252)
                .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(87, 209, 254)
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(6, 94, 154)
            End With
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
    End Sub

    Private Sub GrdView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrdView.CellContentClick

    End Sub
End Class