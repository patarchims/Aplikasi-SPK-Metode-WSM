Imports System.Data.OleDb
Imports MySql.Data.MySqlClient
Imports JS_FlatMaterialUI.CustomMessageBox
Public Class Penilaian_WSM
    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        KondisiBersih()
        AKtif()
        txtnama.Focus()
        GrdAlternatif.Visible = False
    End Sub
    Sub KondisiBersih()
        txtnama.Text = ""
        txtalamat.Text = ""
        txtkelamin.Text = ""
        Tampil_DataKriteria()
    End Sub
    Sub AKtif()
        txtnama.Enabled = True
        txtkelamin.Enabled = False
        txtalamat.Enabled = False
    End Sub
    Sub TidakAktif()
        txtnama.Enabled = False
        txtalamat.Enabled = False
        txtkelamin.Enabled = False
    End Sub

    Private Sub txtnama_TextChanged(sender As Object, e As EventArgs) Handles txtnama.TextChanged
        If txtnama.Text = "" Then
            GrdAlternatif.Visible = False
        Else
            TampilAlternatif()
            GrdAlternatif.Visible = True
        End If
    End Sub
    Sub TampilAlternatif()
        tutupkoneksi()
        cekkoneksi()
        Dim table As New DataTable()
        Dim Adapter As New MySqlDataAdapter("SELECT id_alternatif, nama, jenis_kelamin, alamat  from tb_alternatif where " &
        "nama like '" & Trim(txtnama.Text) & "%' order by id_alternatif", conn)
        Adapter.Fill(table)
        GrdAlternatif.DataSource = table
        GrdAlternatif.Refresh()
        tutupkoneksi()
        AturDataGridAlternatif()
    End Sub

    Sub Cari_SubKriteria()
        On Error Resume Next
        cboSubKriteria.Items.Clear()
        cekkoneksi()
        sql = "SELECT id_subkriteria, nama_kriteria, nama_subkriteria, nilai FROM tb_subkriteria INNER JOIN tb_kriteria on tb_kriteria.id_kriteria=tb_subkriteria.id_kriteria where  tb_kriteria.nama_kriteria='" & cboKriteria.Text & "'"
        sqlcommand = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
        Dr.Close()
        Dr = sqlcommand.ExecuteReader
        If Dr.HasRows Then
            Do Until Not Dr.Read
                cboSubKriteria.Items.Add(Dr!nama_subkriteria)
            Loop
        Else
            cboSubKriteria.Items.Clear()
        End If
        tutupkoneksi()
    End Sub
    Sub AturDataGridAlternatif()
        Try
            With GrdAlternatif
                .Columns(0).HeaderText = "ID"
                .Columns(1).HeaderText = "NAMA"
                .Columns(2).HeaderText = "JENIS KELAMIN"
                .Columns(3).HeaderText = "ALAMAT"


                .Columns(0).Width = 130
                .Columns(1).Width = 150
                .Columns(2).Width = 165
                .Columns(3).Width = 250



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

    Private Sub GrdAlternatif_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
        KlikGirdAlternatif()
        GrdAlternatif.Visible = False

    End Sub
    Sub KlikGirdAlternatif()
        lblKode_nama.Text = GrdAlternatif.CurrentRow.Cells(0).Value
        txtnama.Text = GrdAlternatif.CurrentRow.Cells(1).Value
        txtkelamin.Text = GrdAlternatif.CurrentRow.Cells(2).Value
        txtalamat.Text = GrdAlternatif.CurrentRow.Cells(3).Value
        'On Error Resume Next
        'Dim i As Integer
        'i = GrdAlternatif.CurrentRow.Index
        'lblKode_nama.Text = GrdAlternatif.Item(0, i).ToString
        'txtnama.Text = GrdAlternatif.Item(1, i).Value
        'txtkelamin.Text = GrdAlternatif.Item(2, i).Value
        'txtalamat.Text = GrdAlternatif.Item(3, i).Value
        ''' Try
        ''If GrdAlternatif.RowCount > 0 Then
        'Dim baris As Integer
        'With GrdAlternatif

        '    baris = .CurrentRow.Index
        '    lblKode_nama.Text = .Item(0, baris).Value
        '    txtnama.Text = .Item(1, baris).Value
        '    txtkelamin.Text = .Item(2, baris).Value
        '    'txtkelamin.Text = .Item(2, baris).Value
        '    'txtalamat.Text = .Item(3, baris).Value
        '    'txtalamat.Text = .Item()
        '    '.Rows.



        '    'lblKode_nama.Text = .Item(0, baris).Value
        '    'txtnama.Text = .Item(1, baris).Value
        '    'txtkelamin.Text = .Item(2, baris).Value
        '    'txtalamat.Text = .Item(3, baris).Value
        '    'txtid.Visible = False
        '    'txtalamat.Enabled = False
        '    'txtkelamin.Enabled = False
        'End With
        ''ElseIf GrdAlternatif.RowCount = 0 Then
        ''MsgBox("Data Alternatif Kosong!", MsgBoxStyle.Exclamation, "Peringatan")
        ''End If
        ''Catch ex As Exception
        ''MsgBox("Terjadi kesalahan! " & ex.Message)
        '' End Try
    End Sub


    Private Sub Penilaian_WSM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GrdAlternatif.Visible = False
        KondisiBersih()
        TidakAktif()
        btnBatal.Enabled = False
        btnSimpan.Enabled = False
        btnHapus.Enabled = False
        btnTambah.Enabled = True
        lblKode_nama.Visible = False
        lblKdSubKriteria.Visible = False
        lblNilai_Subkriteria.Visible = False
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

    Private Sub cboKriteria_SelectedIndexChanged(sender As Object, e As EventArgs)
        Cari_SubKriteria()
    End Sub



    Private Sub cboSubKriteria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSubKriteria.SelectedIndexChanged
        TentukanNilaiSubKriteria()
        txtNilai.Focus()
        lblNilai_Subkriteria.Visible = False
    End Sub
    Sub TentukanNilaiSubKriteria()
        On Error Resume Next
        lblKdSubKriteria.Text = ""
        cekkoneksi()
        sql = "SELECT * FROM tb_subkriteria where  nama_subkriteria='" & cboSubKriteria.Text & "' order by id ASC"
        sqlcommand = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
        Dr.Close()
        Dr = sqlcommand.ExecuteReader
        If Dr.HasRows Then
            Do Until Not Dr.Read
                'cbo.Items.Add(Dr!nama_subkriteria)
                lblKdSubKriteria.Text = Dr!id_subkriteria
                lblNilai_Subkriteria.Text = Dr!nilai
            Loop
        Else
            lblKdSubKriteria.Text = ""
        End If
        tutupkoneksi()
    End Sub

    Private Sub cboKriteria_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cboKriteria.SelectedIndexChanged
        Cari_SubKriteria()
    End Sub

    Private Sub txtNilai_TextChanged(sender As Object, e As EventArgs) Handles txtNilai.TextChanged
        'Dim nilai As Integer = txtNilai.Text
        On Error Resume Next
        If txtNilai.Text = "" Then
            txtNilai.Focus()
        ElseIf txtNilai.Text >= 101 Then
            ShowMessageBox("Batas Maximal Nilai 100.", "Kesalahan!", MessageBoxType.Critical)
            txtNilai.Focus()

        Else
            Select Case lblKdSubKriteria.Text
                Case "SK1"
                    txtN1.Text = Val(txtNilai.Text) * Val(lblNilai_Subkriteria.Text)
                Case "SK2"
                    txtN2.Text = Val(txtNilai.Text) * Val(lblNilai_Subkriteria.Text)
                Case "SK3"
                    txtN3.Text = Val(txtNilai.Text) * Val(lblNilai_Subkriteria.Text)
                Case "SK4"
                    txtN4.Text = Val(txtNilai.Text) * Val(lblNilai_Subkriteria.Text)
                Case "SK5"
                    txtN5.Text = Val(txtNilai.Text) * Val(lblNilai_Subkriteria.Text)
                Case "SK6"
                    txtN6.Text = Val(txtNilai.Text) * Val(lblNilai_Subkriteria.Text)
                Case "SK7"
                    txtN7.Text = Val(txtNilai.Text) * Val(lblNilai_Subkriteria.Text)
                Case "SK8"
                    txtN8.Text = Val(txtNilai.Text) * Val(lblNilai_Subkriteria.Text)
                Case "SK9"
                    txtN9.Text = Val(txtNilai.Text) * Val(lblNilai_Subkriteria.Text)
                Case "SK10"
                    txtN10.Text = Val(txtNilai.Text) * Val(lblNilai_Subkriteria.Text)

            End Select

        End If


    End Sub

    Private Sub btnTampung_Click(sender As Object, e As EventArgs) Handles btnTampung.Click
        Simpan()
    End Sub
    Sub Simpan()
        Try
            Dim message As DialogResult
            If lblKode_nama.Text = "" Then
                ShowMessageBox("Isikan Data Nama Terlebih Dahulu", "Critical", MessageBoxType.Critical)
            ElseIf lblKdSubKriteria.Text = "" Or txtNilai.Text = "" Then
                ShowMessageBox("Pilih Data Kriteria Terlebih Dahulu", "Critical", MessageBoxType.Critical)
            Else
                tutupkoneksi()
                cekkoneksi()
                sql = "SELECT * from tb_datanilai
                    WHERE id_alternatif='" & Trim(lblKode_nama.Text) & "' and  id_subkriteria='" & Trim(lblKdSubKriteria.Text) & "' "
                sqlcommand = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                Dr.Close()
                Dr = sqlcommand.ExecuteReader()
                Dr.Read()
                If Not Dr.HasRows Then
                    sql = "INSERT INTO tb_datanilai values (NULL,'" & lblKode_nama.Text & "','" &
                        lblKdSubKriteria.Text & "','" & txtNilai.Text & "')"
                    sqlcommand = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    tutupkoneksi()
                    cekkoneksi()
                    sqlcommand.ExecuteNonQuery()
                    tutupkoneksi()
                    TampilGrid()
                    ShowMessageBox("Data Berhasil Disimpan.", "Infomasi!", MessageBoxType.Information)
                    txtNilai.Text = ""
                    cboSubKriteria.Focus()
                    btnSimpan.Enabled = True


                Else
                    message = ShowMessageBox("Data yang Anda masukkan sudah ada, apakah ada ingin mengubahnya?", "Konfirmasi", MessageBoxType.Question)
                    If message = DialogResult.Yes Then
                        sql = "UPDATE tb_datanilai set nilai='" & txtNilai.Text & "' WHERE id_alternatif='" & Trim(lblKode_nama.Text) & "' and id_subkriteria='" & Trim(lblKdSubKriteria.Text) & "'"
                        sqlcommand = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                        tutupkoneksi()
                        cekkoneksi()
                        sqlcommand.ExecuteNonQuery()
                        TampilGrid()
                        tutupkoneksi()
                        txtNilai.Text = ""
                        cboSubKriteria.Focus()
                        btnSimpan.Enabled = True
                    Else
                        Exit Sub
                        TampilGrid()

                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
    End Sub


    Sub TampilGrid()
        Try
            tutupkoneksi()
            cekkoneksi()
            Dim table As New DataTable()
            Dim Adapter As New MySqlDataAdapter("            
            SELECT tb_datanilai.id, nama, nama_subkriteria, tb_datanilai.nilai FROM tb_datanilai 
            INNER JOIN tb_alternatif ON tb_alternatif.id_alternatif=tb_datanilai.id_alternatif 
            INNER JOIN tb_subkriteria ON tb_subkriteria.id_subkriteria=tb_datanilai.id_subkriteria
            where tb_datanilai.id_alternatif='" & Trim(lblKode_nama.Text) & "'", conn)
            Adapter.Fill(table)
            GrdView.DataSource = table
            GrdView.Refresh()
            tutupkoneksi()
            AturGrid()
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
    End Sub
    Sub AturGrid()
        Try
            With GrdView
                .Columns(0).HeaderText = "ID"
                .Columns(1).HeaderText = "Nama"
                .Columns(2).HeaderText = "Nama Sub Kriteria"
                .Columns(3).HeaderText = "Nilai"

                .Columns(0).Width = 50
                .Columns(1).Width = 300
                .Columns(2).Width = 250
                .Columns(3).Width = 115



                .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(55, 172, 252)
                .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(87, 209, 254)
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(6, 94, 154)

            End With
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
    End Sub



    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Try
            Dim message As DialogResult
            Dim N1, N2, N3, N4, N5, N6, N7, N8, N9, N10 As Double
            N1 = Val(txtN1.Text)
            N2 = Val(txtN2.Text)
            N3 = Val(txtN3.Text)
            N4 = Val(txtN4.Text)
            N5 = Val(txtN5.Text)
            N6 = Val(txtN6.Text)
            N7 = Val(txtN7.Text)
            N8 = Val(txtN8.Text)
            N9 = Val(txtN9.Text)
            N10 = Val(txtN10.Text)

            If txtN1.Text = "" Or txtN2.Text = "" Or txtN3.Text = "" Or txtN4.Text = "" Or txtN5.Text = "" Or
               txtN6.Text = "" Or txtN6.Text = "" Or txtN7.Text = "" Or txtN8.Text = "" Or txtN9.Text = "" Or txtN10.Text = "" Then
                ShowMessageBox("Isikan Data Dengan Lengkap Terlebih Dahulu", "Critical", MessageBoxType.Critical)

            Else
                tutupkoneksi()
                cekkoneksi()
                sql = "SELECT * from tb_penilaian
                    WHERE id_alternatif='" & Trim(lblKode_nama.Text) & "' "
                sqlcommand = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                Dr.Close()
                Dr = sqlcommand.ExecuteReader()
                Dr.Read()
                If Not Dr.HasRows Then
                    sql = "INSERT INTO tb_penilaian values (NULL,'" & lblKode_nama.Text & "','" & N1 & "', '" & N2 & "', '" &
                    N3 & "','" & N4 & "','" & N5 & "','" & N6 & "','" & N7 & "','" & N8 & "','" & N9 & "','" & N10 & "')"
                    sqlcommand = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    tutupkoneksi()
                    cekkoneksi()
                    sqlcommand.ExecuteNonQuery()
                    tutupkoneksi()
                    lblKode_nama.Text = ""
                    TampilGrid()
                    ShowMessageBox("Data Berhasil Disimpan.", "Infomasi!", MessageBoxType.Information)
                    txtNilai.Text = ""
                    cboSubKriteria.Focus()
                    btnSimpan.Enabled = False
                    btnTambah.Enabled = True
                    btnBatal.Enabled = False
                    btnHapus.Enabled = False
                    Bersihkan()
                Else
                    message = ShowMessageBox("Data yang Anda masukkan sudah ada, apakah ada ingin mengubahnya?", "Konfirmasi", MessageBoxType.Question)
                    If message = DialogResult.Yes Then
                        sql = "UPDATE tb_penilaian set n1='" & N1 & "',  n2='" & N2 & "',  n3='" &
                            N3 & "',  n4='" & N4 & "',  n5='" & N5 & "',  n6='" & N6 & "',  n7='" &
                            N7 & "',  n8='" & N8 & "',  n9='" & N9 & "',  n10='" & N10 & "' WHERE id_alternatif='" & Trim(lblKode_nama.Text) & "'"
                        sqlcommand = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                        tutupkoneksi()
                        cekkoneksi()
                        sqlcommand.ExecuteNonQuery()
                        lblKode_nama.Text = ""
                        TampilGrid()
                        tutupkoneksi()
                        txtNilai.Text = ""
                        cboSubKriteria.Focus()
                        btnSimpan.Enabled = True
                        btnTambah.Enabled = True
                        btnBatal.Enabled = False
                        btnHapus.Enabled = False
                        Bersihkan()
                    Else
                        Exit Sub
                        TampilGrid()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
    End Sub

    Private Sub GrdAlternatif_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles GrdAlternatif.CellContentClick
        KlikGirdAlternatif()
        GrdAlternatif.Visible = False
        cboKriteria.Focus()
    End Sub

    Private Sub GrdAlternatif_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrdAlternatif.CellContentDoubleClick
        KlikGirdAlternatif()
        GrdAlternatif.Visible = False
        cboKriteria.Focus()
    End Sub

    Sub Bersihkan()
        txtN1.Text = ""
        txtN2.Text = ""
        txtN3.Text = ""
        txtN4.Text = ""
        txtN5.Text = ""
        txtN6.Text = ""
        txtN7.Text = ""
        txtN8.Text = ""
        txtN9.Text = ""
        txtN10.Text = ""
        lblKdSubKriteria.Text = ""
        lblKode_nama.Text = ""
        lblNilai_Subkriteria.Text = ""
        txtnama.Text = ""
        txtkelamin.Text = ""
        txtalamat.Text = ""
    End Sub

    Private Sub txtNilai_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNilai.KeyDown
        If e.KeyCode = Keys.Enter Then
            Simpan()
        End If
    End Sub
End Class