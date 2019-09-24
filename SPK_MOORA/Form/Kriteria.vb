Imports System.Data.OleDb
Imports MySql.Data.MySqlClient
Imports JS_FlatMaterialUI.CustomMessageBox
Public Class Kriteria
    Dim JmlData As Integer
    Dim jml_nilai As Integer = 0
    Dim prb As Double = 0
    Dim pembulatan As Double = 0
    Private Sub Kriteria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtNormalisasiKriteria.Visible = False
        txtKodeKriteria.Visible = False
        Call TampilGrid()
        Call KondisiBersih()

    End Sub

    Sub KondisiBersih()
        Try
            txtKodeKriteria.Text = ""
            txtNamaKriteria.Text = ""
            txtBobotKriteria.Text = ""
            txtNormalisasiKriteria.Text = ""

            txtKodeKriteria.Enabled = False
            txtNamaKriteria.Enabled = False
            txtBobotKriteria.Enabled = False
            txtNormalisasiKriteria.Enabled = False

            btnTambah.Enabled = True
            btnSimpan.Enabled = False
            'btnEdit.Enabled = False
            btnHapus.Enabled = False
            btnBatal.Enabled = False

            btnTambah.Focus()
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
    End Sub

    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        Try
            jml_nilai = 0
            Call KondisiTambah()
            Call KodeOtomatis()
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
    End Sub
    Sub KodeOtomatis()
        tutupkoneksi()
        cekkoneksi()
        Dim strSementara As String = ""
        Dim strIsi As String = ""
        sqlcommand = New MySqlCommand("select * from tb_kriteria order by id_kriteria desc", conn)
        Dr = sqlcommand.ExecuteReader
        If Dr.Read Then
            strSementara = Microsoft.VisualBasic.Right(Dr.Item("id_kriteria"), 1)
            strIsi = Val(strSementara) + 1
            txtKodeKriteria.Text = "C" & strIsi
        Else
            txtKodeKriteria.Text = "C1"
        End If
        txtNamaKriteria.Focus()
    End Sub
    Sub KondisiTambah()
        Try
            txtKodeKriteria.Text = ""
            txtNamaKriteria.Text = ""
            txtBobotKriteria.Text = ""
            txtNormalisasiKriteria.Text = ""

            txtKodeKriteria.Enabled = False
            txtNamaKriteria.Enabled = True
            txtBobotKriteria.Enabled = True
            txtNormalisasiKriteria.Enabled = False

            btnTambah.Enabled = False
            btnSimpan.Enabled = True
            'btnEdit.Enabled = False
            btnHapus.Enabled = False
            btnBatal.Enabled = True

            txtNamaKriteria.Focus()
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
    End Sub


    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If txtKodeKriteria.Text = "" Or txtNamaKriteria.Text = "" Or txtBobotKriteria.Text = "" Then
            ShowMessageBox("Data Isian Harus Lengkap", "Critical", MessageBoxType.Critical)

        Else
            tutupkoneksi()
            cekkoneksi()
            sql = "SELECT * FROM tb_kriteria WHERE id_kriteria='" & Trim(txtKodeKriteria.Text) & "'"
            sqlcommand = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
            Dr.Close()
            Dr = sqlcommand.ExecuteReader()
            Dr.Read()
            If Not Dr.HasRows Then
                sql = "INSERT INTO tb_kriteria values ('" & txtKodeKriteria.Text & "','" &
                    txtNamaKriteria.Text & "','" & txtBobotKriteria.Text & "','" & Val(Microsoft.VisualBasic.Str(txtNormalisasiKriteria.Text)) & "')"
                sqlcommand = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                tutupkoneksi()
                cekkoneksi()
                sqlcommand.ExecuteNonQuery()
                tutupkoneksi()
                TampilGrid()
                ShowMessageBox("Data Berhasil Disimpan.", "Infomasi!", MessageBoxType.Information)
                Call KondisiBersih()
            Else
                sql = "UPDATE tb_kriteria set nama_kriteria='" & txtNamaKriteria.Text & "',bobot='" & txtBobotKriteria.Text & "',normalisasi='" & txtNormalisasiKriteria.Text & "' WHERE id_kriteria='" & Trim(txtKodeKriteria.Text) & "'"
                sqlcommand = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                tutupkoneksi()
                cekkoneksi()
                sqlcommand.ExecuteNonQuery()
                tutupkoneksi()
                TampilGrid()
                ShowMessageBox("Data Berhasil Diubah.", "Infomasi!", MessageBoxType.Information)
                Call KondisiBersih()
            End If
        End If
    End Sub
    Sub TampilGrid()
        tutupkoneksi()
        cekkoneksi()
        Dim table As New DataTable()
        Dim Adapter As New MySqlDataAdapter("SELECT * from tb_kriteria ", conn)
        Adapter.Fill(table)
        GrdView.DataSource = table
        GrdView.Refresh()
        tutupkoneksi()
        AturDataGrid()
    End Sub

    Sub TampilGrid_Cari()
        Try
            tutupkoneksi()
            cekkoneksi()
            Dim table As New DataTable()
            Dim Adapter As New MySqlDataAdapter("SELECT * from tb_kriteria where " &
            "nama_kriteria like '" & Trim(txtCari.Text) & "%' order by id_kriteria", conn)
            Adapter.Fill(table)
            GrdView.DataSource = table
            GrdView.Refresh()
            tutupkoneksi()
            AturDataGrid()
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try

    End Sub
    Sub AturDataGrid()
        Try
            With GrdView
                .Columns(0).HeaderText = "KODE"
                .Columns(1).HeaderText = "NAMA"
                .Columns(2).HeaderText = "PERCEN"
                .Columns(3).HeaderText = "BOBOT"

                .Columns(0).Width = 80
                .Columns(1).Width = 450
                .Columns(2).Width = 115
                .Columns(3).Width = 150

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

    Private Sub txtBobotKriteria_TextChanged(sender As Object, e As EventArgs) Handles txtBobotKriteria.TextChanged
        'Dim bobot As Integer
        'bobot = Val(txtBobotKriteria.Text) / 100
        'txtNormalisasiKriteria.Text = bobot

        On Error Resume Next
        txtNormalisasiKriteria.Text = Val(Microsoft.VisualBasic.Str(txtBobotKriteria.Text)) / 100
    End Sub

    Private Sub txtBobotKriteria_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBobotKriteria.KeyPress
        If (Not e.KeyChar = ChrW(Keys.Back) And ("0123456789.").IndexOf(e.KeyChar) = -1) Or (e.KeyChar = "." And txtBobotKriteria.Text.ToCharArray().Count(Function(c) c = ".") > 0) Then
            e.Handled = True
        End If
    End Sub



    Private Sub GrdView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrdView.CellContentClick
        KlikGrid()
    End Sub

    Private Sub txtCari_TextChanged(sender As Object, e As EventArgs) Handles txtCari.TextChanged

    End Sub

    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        TampilGrid_Cari()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        TampilGrid()
        txtCari.Text = "-- Nama Kriteria --"
        txtCari.ForeColor = Color.Gray
    End Sub

    Private Sub txtCari_ClientSizeChanged(sender As Object, e As EventArgs) Handles txtCari.ClientSizeChanged

    End Sub

    Private Sub txtCari_Click(sender As Object, e As EventArgs) Handles txtCari.Click
        txtCari.Text = ""
    End Sub

    Sub KlikGrid()
        Try
            If GrdView.RowCount > 0 Then
                Dim baris As Integer
                With GrdView
                    baris = .CurrentRow.Index
                    txtKodeKriteria.Text = .Item(0, baris).Value
                    txtNamaKriteria.Text = .Item(1, baris).Value
                    txtBobotKriteria.Text = .Item(2, baris).Value
                    txtNormalisasiKriteria.Text = .Item(3, baris).Value

                    txtKodeKriteria.Enabled = False
                    txtNamaKriteria.Enabled = True
                    txtBobotKriteria.Enabled = True
                    txtNormalisasiKriteria.Enabled = False

                    btnTambah.Enabled = False
                    btnSimpan.Enabled = True
                    'btnEdit.Enabled = True
                    btnHapus.Enabled = True
                    btnBatal.Enabled = True
                End With
            ElseIf GrdView.RowCount = 0 Then
                MsgBox("Data Kriteria Kosong!", MsgBoxStyle.Exclamation, "Peringatan")
            End If
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
    End Sub

    Private Sub GrdView_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrdView.CellContentDoubleClick
        KlikGrid()
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        Dim Message As DialogResult
        tutupkoneksi()
        cekkoneksi()
        sql = "SELECT * FROM tb_kriteria where id_kriteria='" & txtKodeKriteria.Text & "'"
        sqlcommand = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
        Dr.Close()
        Dr = sqlcommand.ExecuteReader
        Dr.Read()
        If Not Dr.HasRows Then tutupkoneksi() : Exit Sub
        Message = ShowMessageBox("Apakah Anda Yakin Untuk Menghapus Data ini?", "Konfirmasi", MessageBoxType.Question)
        If Message = DialogResult.Yes Then
            tutupkoneksi()
            sql = "Delete From tb_kriteria where id_kriteria ='" & txtKodeKriteria.Text & "'"
            cekkoneksi()
            sqlcommand = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
            sqlcommand.ExecuteNonQuery()
            sqlcommand = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
            tutupkoneksi()
            cekkoneksi()
            sqlcommand.ExecuteNonQuery()
            TampilGrid()
            Call KondisiBersih()
            tutupkoneksi()
            ShowMessageBox("Data Berhasil Dihapus.", "Infomasi!", MessageBoxType.Information)
        Else
            Exit Sub
            TampilGrid()
        End If
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Try
            jml_nilai = 0
            Call KondisiBersih()
            'GrdView.Rows.Clear()
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
    End Sub
End Class