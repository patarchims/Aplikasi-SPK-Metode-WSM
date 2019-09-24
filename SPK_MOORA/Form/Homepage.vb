Public Class Homepage
    Private Sub Homepage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        JumlahKriteria()
        JumlahSUBKriteria()
        JumlahPemain()
        JumlahPenilaian()
    End Sub

    Sub JumlahKriteria()
        On Error Resume Next
        cekkoneksi()
        CountKriteria.Text = ""
        sql = "
              SELECT COUNT(*) as Jumlah from tb_kriteria
            "
        sqlcommand = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
        Dr.Close()
        Dr = sqlcommand.ExecuteReader
        If Dr.HasRows Then
            Do Until Not Dr.Read
                CountKriteria.Text = Dr!jumlah
            Loop
        Else
            CountKriteria.Text = "0"
        End If
        tutupkoneksi()
    End Sub
    Sub JumlahPenilaian()
        On Error Resume Next
        cekkoneksi()
        CountPenilaian.Text = ""
        sql = "
              SELECT COUNT(*) as Jumlah from tb_penilaian
            "
        sqlcommand = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
        Dr.Close()
        Dr = sqlcommand.ExecuteReader
        If Dr.HasRows Then
            Do Until Not Dr.Read
                CountPenilaian.Text = Dr!jumlah
            Loop
        Else
            CountPenilaian.Text = "0"
        End If
        tutupkoneksi()
    End Sub
    Sub JumlahSUBKriteria()
        On Error Resume Next
        cekkoneksi()
        CountSubKriteria.Text = ""
        sql = "
              SELECT COUNT(*) as Jumlah from tb_subkriteria
            "
        sqlcommand = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
        Dr.Close()
        Dr = sqlcommand.ExecuteReader
        If Dr.HasRows Then
            Do Until Not Dr.Read
                CountSubKriteria.Text = Dr!jumlah
            Loop
        Else
            CountSubKriteria.Text = "0"
        End If
        tutupkoneksi()
    End Sub

    Sub JumlahPemain()
        On Error Resume Next
        cekkoneksi()
        CountPemain.Text = ""
        sql = "
              SELECT COUNT(*) as Jumlah from tb_alternatif
            "
        sqlcommand = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
        Dr.Close()
        Dr = sqlcommand.ExecuteReader
        If Dr.HasRows Then
            Do Until Not Dr.Read
                CountPemain.Text = Dr!jumlah
            Loop
        Else
            CountPemain.Text = "0"
        End If
        tutupkoneksi()
    End Sub

    Private Sub CountPemain_TextChanged(sender As Object, e As EventArgs) Handles CountPemain.TextChanged

    End Sub
End Class