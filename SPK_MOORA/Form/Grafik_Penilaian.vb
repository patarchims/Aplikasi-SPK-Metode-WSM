Imports System.Data.OleDb
Imports MySql.Data.MySqlClient
Imports JS_FlatMaterialUI.CustomMessageBox
Public Class Grafik_Penilaian
    Private Sub btnTampil_Click(sender As Object, e As EventArgs) Handles btnTampil.Click
        Try
            TampilDiGrid()
            TampilGrafik()
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
    End Sub
    Sub TampilDiGrid()
        tutupkoneksi()
        cekkoneksi()
        Dim table As New DataTable()
        'sql = "
        '        SELECT @c1:=round(SQRT(sum(pow(c1,2))),2)  , @c2:=round(SQRT(sum(pow(c2,2))),2) , 
        '        @c3:=round(SQRT(sum(pow(c3,2))),2) ,@c4:=round(SQRT(sum(pow(c4,2))),2) , 
        '        @c5:=round(SQRT(sum(pow(c5,2))),2) FROM tb_penilaian ;
        '       "
        sqlcommand = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
        Dr.Close()
        Dr = sqlcommand.ExecuteReader()
        Dr.Read()
        Dr.Close()
        sql1 = "
               SELECT id as No,nama, @DATA1:=(n1+n2+n3) AS Estimasi, @DATA2:=(n4+n5) AS Loyalitym,
                @DATA3:=(n6+n7) As Penampilan ,@DATA4:=(n8+n9+n10) 
                As Attitude, @TOTAL:=(@DATA1+@DATA2+@DATA3+@DATA4) as Total
                FROM tb_penilaian INNER JOIN tb_alternatif 
                ON tb_alternatif.id_alternatif=tb_penilaian.id_alternatif
                ;
                "
        Dim AdapterAll As New MySqlDataAdapter(sql1, conn)
        AdapterAll.Fill(table)
        GrdView.DataSource = table
        GrdView.Refresh()
        tutupkoneksi()
        AturDataGrid()
    End Sub


    Sub AturDataGrid()
        Try
            With GrdView
                .Columns(0).HeaderText = "NO"
                .Columns(1).HeaderText = "NAMA"
                .Columns(2).HeaderText = "ESTIMASI"
                .Columns(3).HeaderText = "LOYALITY"
                .Columns(4).HeaderText = "PENAMPILAN"
                .Columns(5).HeaderText = "ATTITUDE"
                .Columns(6).HeaderText = "TOTAL"


                .Columns(0).Width = 80
                .Columns(1).Width = 100
                .Columns(2).Width = 175
                .Columns(3).Width = 85
                .Columns(4).Width = 80
                .Columns(5).Width = 80
                .Columns(6).Width = 80

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

    Sub TampilGrafik()
        Try
            Dim hitung = GrdView.RowCount
            Dim baris As Integer
            Grafik.Series("Alternatif").Points.Clear()
            For baris = 0 To hitung - 1 Step 1
                Dim NilaiHasilAkhir As Double = GrdView.Rows(baris).Cells(6).Value
                Me.Grafik.Series("Alternatif").Points.AddXY(GrdView.Rows(baris).Cells(1).Value, NilaiHasilAkhir)
            Next
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
    End Sub
End Class