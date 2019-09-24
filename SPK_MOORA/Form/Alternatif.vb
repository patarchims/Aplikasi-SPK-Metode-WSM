Imports System.Data.OleDb
Imports MySql.Data.MySqlClient
Imports JS_FlatMaterialUI.CustomMessageBox
Public Class Alternatif
    Private Sub Pemain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call TampilGrid()
        Call KondisiBersih()
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Call KondisiBersih()
        btnHapus.Enabled = False
        btnTambah.Enabled = True
        btnBatal.Enabled = False
    End Sub
    Sub KondisiBersih()
        txtnim.Text = ""
        txtnama.Text = ""
        txtid.Text = ""
        With CboKelamin.Items
            .Clear()
            .Add("Laki-Laki")
            .Add("Perempuan")
        End With
        txtalamat.Text = ""
        txthp.Text = ""

        txtid.Enabled = False
        txtnama.Enabled = False
        txtnim.Enabled = False
        CboKelamin.Enabled = False
        txtalamat.Enabled = False
        txthp.Enabled = False
        txtid.Visible = False

        btnTambah.Enabled = True
        btnSimpan.Enabled = False
        'btnEdit.Enabled = False
        btnHapus.Enabled = False
        btnBatal.Enabled = False

        btnTambah.Focus()
    End Sub

    Sub KondisiTambah()
        txtnama.Text = ""
        txtid.Text = ""
        With CboKelamin.Items
            .Clear()
            .Add("Laki-Laki")
            .Add("Perempuan")
        End With
        txtalamat.Text = ""
        txthp.Text = ""
        txtnim.Text = ""
        txtid.Enabled = False
        txtnama.Enabled = True

        btnTambah.Enabled = False
        btnSimpan.Enabled = True
        'btnEdit.Enabled = False
        btnHapus.Enabled = False
        btnBatal.Enabled = True

        txtnim.Enabled = True
        txtnama.Enabled = True
        CboKelamin.Enabled = True
        txtalamat.Enabled = True
        txthp.Enabled = True
        txtid.Enabled = True
        txtid.Visible = False
        txtnim.Focus()
    End Sub
    Sub TampilGrid()
        tutupkoneksi()
        cekkoneksi()
        Dim table As New DataTable()
        Dim Adapter As New MySqlDataAdapter("SELECT * from tb_alternatif ", conn)
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
        Dim Adapter As New MySqlDataAdapter("SELECT * from tb_alternatif where " &
        "nama like '" & Trim(txtCari.Text) & "%' or nim like '" & Trim(txtCari.Text) & "%' order by id_alternatif", conn)
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
                .Columns(1).HeaderText = "NIM"
                .Columns(2).HeaderText = "NAMA"
                .Columns(3).HeaderText = "JENIS KELAMIN"
                .Columns(4).HeaderText = "ALAMAT"
                .Columns(5).HeaderText = "NO HP"

                .Columns(0).Width = 130
                .Columns(1).Width = 100
                .Columns(2).Width = 165
                .Columns(3).Width = 100
                .Columns(4).Width = 200
                .Columns(5).Width = 165


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

    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        Try
            Call KondisiTambah()
            Call KodeOtomatis()
            txtnim.Focus()
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
    End Sub

    Sub KodeOtomatis()
        tutupkoneksi()
        cekkoneksi()
        Dim strSementara As String = ""
        Dim strIsi As String = ""
        sqlcommand = New MySqlCommand("select * from tb_alternatif order by id_alternatif desc", conn)
        Dr = sqlcommand.ExecuteReader
        If Dr.Read Then
            strSementara = Microsoft.VisualBasic.Right(Dr.Item("id_alternatif"), 1)
            strIsi = Val(strSementara) + 1
            txtid.Text = "A" & strIsi
        Else
            txtid.Text = "A1"
        End If
        txtnama.Focus()
    End Sub


    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Try
            If txtnama.Text = "" Or txtnim.Text = "" Or CboKelamin.Text = "" Or txtalamat.Text = "" Or txthp.Text = "" Then
                ShowMessageBox("Data Isian Harus Lengkap", "Critical", MessageBoxType.Critical)

            Else
                tutupkoneksi()
                cekkoneksi()
                sql = "SELECT * FROM tb_alternatif WHERE id_alternatif='" & Trim(txtid.Text) & "'"
                sqlcommand = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                Dr.Close()
                Dr = sqlcommand.ExecuteReader()
                Dr.Read()
                If Not Dr.HasRows Then
                    sql = "INSERT INTO tb_alternatif values ('" & txtid.Text & "','" &
                        txtnim.Text & "','" & txtnama.Text & "','" & CboKelamin.Text & "' ,'" & txtalamat.Text & "','" & txthp.Text & "')"
                    sqlcommand = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    tutupkoneksi()
                    cekkoneksi()
                    sqlcommand.ExecuteNonQuery()
                    tutupkoneksi()
                    TampilGrid()
                    ShowMessageBox("Data Berhasil Disimpan.", "Infomasi!", MessageBoxType.Information)
                    Call KondisiBersih()
                Else
                    sql = "UPDATE tb_alternatif set nik='" & txtnim.Text & "',nama='" & txtnama.Text & "'
                    ,jenis_kelamin='" & CboKelamin.Text & "',alamat='" & txtalamat.Text & "',no_hp='" & txthp.Text & "'
                    WHERE id_alternatif='" & Trim(txtid.Text) & "'"
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
        sql = "SELECT * FROM tb_alternatif where id_alternatif='" & txtid.Text & "'"
        sqlcommand = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
        Dr.Close()
        Dr = sqlcommand.ExecuteReader
        Dr.Read()
        If Not Dr.HasRows Then tutupkoneksi() : Exit Sub
        Message = ShowMessageBox("Apakah Anda Yakin Untuk Menghapus Data ini?", "Konfirmasi", MessageBoxType.Question)
        If Message = DialogResult.Yes Then
            tutupkoneksi()
            sql = "Delete From tb_alternatif where id_alternatif ='" & txtid.Text & "'"
            cekkoneksi()
            sqlcommand = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
            sqlcommand.ExecuteNonQuery()
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

    Private Sub GrdView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrdView.CellContentClick
        KlikGrid()
    End Sub

    Sub KlikGrid()
        Try
            If GrdView.RowCount > 0 Then
                Dim baris As Integer
                With GrdView
                    baris = .CurrentRow.Index
                    txtid.Text = .Item(0, baris).Value
                    txtnim.Text = .Item(1, baris).Value
                    txtnama.Text = .Item(2, baris).Value
                    CboKelamin.Text = .Item(3, baris).Value
                    txtalamat.Text = .Item(4, baris).Value
                    txthp.Text = .Item(5, baris).Value

                    txtnim.Enabled = False
                    txtnama.Enabled = True
                    CboKelamin.Enabled = True
                    txtalamat.Enabled = True
                    txthp.Enabled = True

                    btnTambah.Enabled = False
                    btnSimpan.Enabled = True
                    btnHapus.Enabled = True
                    btnBatal.Enabled = True
                End With
            ElseIf GrdView.RowCount = 0 Then
                MsgBox("Data Pemain Kosong!", MsgBoxStyle.Exclamation, "Peringatan")
            End If
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
    End Sub
End Class