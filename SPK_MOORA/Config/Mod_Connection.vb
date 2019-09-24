Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Net.NetworkInformation
Imports JS_FlatMaterialUI.CustomMessageBox
Module Mod_Connection

    Public server As String
        Public ds As New DataSet
        Public dtData As New Data.DataTable
        Public conn As New MySqlConnection
        Public sqlcommand As New MySqlCommand
        Public sqlcommand1 As New MySqlCommand
        Public sqlcommand2 As New MySqlCommand
        Public sqladapter As New MySqlDataAdapter 'RD Sql adapter
        Public Konfirmasi As MsgBoxResult
        Public Dr As MySqlDataReader
        Public Dr1 As MySqlDataReader
        Public Cur As New Form
        Public sql, sql1 As String

        Public Read1, Read2, Read3, Read4, Read5, Read6, Read7, Read8, Read9 As MySqlDataReader

        Public sqlDetail, sqldelete As String
        Function getMacAddress()
            Dim nics() As NetworkInterface = NetworkInterface.GetAllNetworkInterfaces()
            Return nics(1).GetPhysicalAddress.ToString
        End Function
        Public Sub cekkoneksi()
        server = "SERVER= localhost; USERID= root; password=; database=wsm_db; Convert Zero Datetime=true; AllowUserVariables=True "
        conn.ConnectionString = server
            conn.Open()
        End Sub
        Public Sub tutupkoneksi()
            With conn
                .Dispose()
                .Close()
            End With
        End Sub
    Public Sub KOneksiAwal()
        Try
            server = "SERVER= localhost; USERID= root; password=; database=wsm_db; Convert Zero Datetime=true; AllowUserVariables=True"
            conn.ConnectionString = server
            conn.Open()
        Catch
            ShowMessageBox("Tidak Terhubung Dengan Database & 
            Pasitikan Database Aktif", "Error!", MessageBoxType.Critical)
            End
        End Try
    End Sub

End Module
