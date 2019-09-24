Imports System.Data.OleDb
Imports MySql.Data.MySqlClient
Imports JS_FlatMaterialUI.CustomMessageBox
Public Class Sub_Kriteria
    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        Try
            Call KondisiTambah()
            Call KodeOtomatis()
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
    End Sub

    Private Sub Sub_Kriteria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call TampilGrid()
        Call KondisiBersih()
    End Sub
    Sub KodeOtomatis()
        tutupkoneksi()
        cekkoneksi()
        Dim strSementara As String = ""
        Dim strIsi As String = ""
        sqlcommand = New MySqlCommand("select * from tb_subkriteria order by id_subkriteria desc", conn)
        Dr = sqlcommand.ExecuteReader
        If Dr.Read Then
            strSementara = Microsoft.VisualBasic.Right(Dr.Item("id_subkriteria"), 1)
            strIsi = Val(strSementara) + 1
            txtkode.Text = "K" & strIsi
        Else
            txtkode.Text = "K1"
        End If
        txtnama.Focus()
    End Sub
    Sub KondisiBersih()
        txtkode.Text = ""
        txtnama.Text = ""
        txtnilai.Text = ""


        txtkode.Enabled = False
        txtnama.Enabled = False
        txtnilai.Enabled = False


        btnTambah.Enabled = True
        btnSimpan.Enabled = False
        'btnEdit.Enabled = False
        btnHapus.Enabled = False
        btnBatal.Enabled = False

        btnTambah.Focus()
    End Sub

    Sub KondisiTambah()
        txtkode.Text = ""
        txtnama.Text = ""
        txtnilai.Text = ""

        txtkode.Enabled = False
        txtnama.Enabled = True
        txtnilai.Enabled = True


        btnTambah.Enabled = False
        btnSimpan.Enabled = True
        'btnEdit.Enabled = False
        btnHapus.Enabled = False
        btnBatal.Enabled = True

        txtnama.Focus()
    End Sub
    Sub TampilGrid()
        tutupkoneksi()
        cekkoneksi()
        Dim table As New DataTable()
        Dim Adapter As New MySqlDataAdapter("SELECT * from tb_subkriteria ", conn)
        Adapter.Fill(table)
        GrdView.DataSource = table
        GrdView.Refresh()
        tutupkoneksi()
        AturDataGrid()
    End Sub
    Sub TampilGrid_Cari()
        tutupkoneksi()
        cekkoneksi()
        Dim table As New DataTable()
        Dim Adapter As New MySqlDataAdapter("SELECT * from tb_subkriteria where " &
        "nama_subkriteria like '" & Trim(txtCari.Text) & "%' order by id_subkriteria", conn)
        Adapter.Fill(table)
        GrdView.DataSource = table
        GrdView.Refresh()
        tutupkoneksi()
        AturDataGrid()
    End Sub
    Sub AturDataGrid()
        Try
            With GrdView
                .Columns(0).HeaderText = "NO"
                .Columns(1).HeaderText = "KODE"
                .Columns(2).HeaderText = "NAMA"
                .Columns(3).HeaderText = "NILAI"

                .Columns(0).Width = 50
                .Columns(1).Width = 130
                .Columns(2).Width = 450
                .Columns(2).Width = 100


                .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(55, 172, 252)
                .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(87, 209, 254)
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(6, 94, 154)
            End With
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
    End Sub
    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        TampilGrid_Cari()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        TampilGrid()
    End Sub

    Private Sub txtCari_Click(sender As Object, e As EventArgs) Handles txtCari.Click
        txtCari.Text = ""
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Try
            If txtkode.Text = "" Or txtnama.Text = "" Or txtnilai.Text = "" Then
                ShowMessageBox("Data Isian Harus Lengkap", "Critical", MessageBoxType.Critical)

            Else
                tutupkoneksi()
                cekkoneksi()
                sql = "SELECT * FROM tb_subkriteria WHERE id_subkriteria='" & Trim(txtkode.Text) & "'"
                sqlcommand = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                Dr.Close()
                Dr = sqlcommand.ExecuteReader()
                Dr.Read()
                If Not Dr.HasRows Then
                    sql = "INSERT INTO tb_subkriteria values ('" & txtkode.Text & "','" &
                        txtnama.Text & "','" & txtnilai.Text & "')"
                    sqlcommand = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    tutupkoneksi()
                    cekkoneksi()
                    sqlcommand.ExecuteNonQuery()
                    tutupkoneksi()
                    TampilGrid()
                    ShowMessageBox("Data Berhasil Disimpan.", "Infomasi!", MessageBoxType.Information)
                    Call KondisiBersih()
                Else
                    sql = "UPDATE tb_subkriteria set nama_subkriteria='" & txtnama.Text & "',nilai='" & txtnilai.Text & "' WHERE id_subkriteria='" & Trim(txtkode.Text) & "'"
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
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        Dim Message As DialogResult
        tutupkoneksi()
        cekkoneksi()
        sql = "SELECT * FROM tb_subkriteria where id_subkriteria='" & txtkode.Text & "'"
        sqlcommand = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
        Dr.Close()
        Dr = sqlcommand.ExecuteReader
        Dr.Read()
        If Not Dr.HasRows Then tutupkoneksi() : Exit Sub
        Message = ShowMessageBox("Apakah Anda Yakin Untuk Menghapus Data ini?", "Konfirmasi", MessageBoxType.Question)
        If Message = DialogResult.Yes Then
            tutupkoneksi()
            sql = "Delete From tb_subkriteria where id_subkriteria ='" & txtkode.Text & "'"
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
            Call KondisiBersih()
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
    End Sub

    Sub KlikGrid()
        Try
            If GrdView.RowCount > 0 Then
                Dim baris As Integer
                With GrdView
                    baris = .CurrentRow.Index

                    txtkode.Text = .Item(1, baris).Value
                    txtnama.Text = .Item(2, baris).Value
                    txtnilai.Text = .Item(3, baris).Value

                    txtkode.Enabled = False
                    txtnama.Enabled = True
                    txtnilai.Enabled = True

                    btnTambah.Enabled = False
                    btnSimpan.Enabled = True

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

    Private Sub GrdView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrdView.CellContentClick
        KlikGrid()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class