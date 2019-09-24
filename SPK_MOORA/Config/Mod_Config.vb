Imports System.Security.Cryptography
Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Web
Imports System.Data.SqlClient
Imports System.Net.Mail
Imports System.Net.NetworkInformation
Module Mod_Config

    Public Function CheckForInternetConnection() As Boolean
        Try
            Using client = New WebClient()
                Using stream = client.OpenRead("http://www.google.com")
                    Return True
                End Using
            End Using
        Catch
            Return False
        End Try
    End Function
    Public Sub GetServerList(ByVal cmbServers As ComboBox)
            Dim Server As String = String.Empty
            Dim instance As System.Data.Sql.SqlDataSourceEnumerator = System.Data.Sql.SqlDataSourceEnumerator.Instance
            Dim table As System.Data.DataTable = instance.GetDataSources()
            For Each row As System.Data.DataRow In table.Rows
                Server = String.Empty
                Server = row("ServerName")
                If row("InstanceName").ToString.Length > 0 Then
                    Server = Server & "\" & row("InstanceName")
                End If
                cmbServers.Items.Add(Server)
            Next
            cmbServers.SelectedIndex = cmbServers.FindStringExact(Environment.MachineName)
        End Sub

        Public Function IsConnectionAvailable() As Boolean
            Dim objUrl As New System.Uri("http://www.google.com")
            Dim objWebReq As System.Net.WebRequest
            objWebReq = System.Net.WebRequest.Create(objUrl)
            Dim objresp As System.Net.WebResponse

            Try
                objresp = objWebReq.GetResponse
                objresp.Close()
                objresp = Nothing
                Return True

            Catch ex As Exception
                objresp = Nothing
                objWebReq = Nothing
                Return False
            End Try
        End Function
        Sub SMSFunc(ByVal st1 As String, ByVal st2 As String, ByVal st3 As String)
            st3 = st3.Replace("@MobileNo", st1).Replace("@Message", st2)
            Dim request As HttpWebRequest
            Dim response As HttpWebResponse = Nothing
            Dim myUri As New Uri(st3)
            request = DirectCast(WebRequest.Create(myUri), HttpWebRequest)
            response = DirectCast(request.GetResponse(), HttpWebResponse)
        End Sub

        Public Function Encrypt(ByVal password As String) As String
            Dim strmsg As String = String.Empty
            Dim encode As Byte() = New Byte(password.Length - 1) {}
            encode = Encoding.UTF8.GetBytes(password)
            strmsg = Convert.ToBase64String(encode)
            Return strmsg
        End Function

        Public Function Decrypt(ByVal encryptpwd As String) As String
            Dim decryptpwd As String = String.Empty
            Dim encodepwd As New UTF8Encoding()
            Dim Decode As Decoder = encodepwd.GetDecoder()
            Dim todecode_byte As Byte() = Convert.FromBase64String(encryptpwd)
            Dim charCount As Integer = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length)
            Dim decoded_char As Char() = New Char(charCount - 1) {}
            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0)
            decryptpwd = New [String](decoded_char)
            Return decryptpwd
        End Function

        Public Sub SendMail(ByVal s1 As String, ByVal s2 As String, ByVal s3 As String, ByVal s4 As String, ByVal s5 As String, ByVal s6 As String, ByVal s7 As Integer, ByVal s8 As String, ByVal s9 As String)
            Dim msg As New MailMessage()
            Try
                msg.From = New MailAddress(s1)
                msg.[To].Add(s2)
                msg.Body = s3
                msg.Attachments.Add(New Attachment(s4))
                msg.IsBodyHtml = True
                msg.Subject = s5
                Dim smt As New SmtpClient(s6)
                smt.Port = s7
                smt.Credentials = New NetworkCredential(s8, s9)
                smt.EnableSsl = True
                smt.Send(msg)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
        Private Function getMacAddress() As String
            Try
                Dim adapters As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
                Dim adapter As NetworkInterface
                Dim myMac As String = String.Empty

                For Each adapter In adapters
                    Select Case adapter.NetworkInterfaceType
                        'Exclude Tunnels, Loopbacks and PPP
                        Case NetworkInterfaceType.Tunnel, NetworkInterfaceType.Loopback, NetworkInterfaceType.Ppp
                        Case Else
                            If Not adapter.GetPhysicalAddress.ToString = String.Empty And Not adapter.GetPhysicalAddress.ToString = "00000000000000E0" Then
                                myMac = adapter.GetPhysicalAddress.ToString
                                Exit For ' Got a mac so exit for
                            End If

                    End Select
                Next adapter

                Return myMac
            Catch ex As Exception
                Return String.Empty
            End Try
        End Function

    End Module

