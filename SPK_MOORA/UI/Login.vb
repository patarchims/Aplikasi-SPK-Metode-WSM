Imports JS_FlatMaterialUI.CustomMessageBox
Public Class Login
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        KOneksiAwal()
    End Sub

    Private Sub LblCLosed_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles LblCLosed.MouseEnter
        LblCLosed.BackColor = Color.Crimson
    End Sub

    Private Sub LblCLosed_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles LblCLosed.MouseLeave
        LblCLosed.BackColor = Color.FromArgb(55, 172, 252)
    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Login()
    End Sub

    Private Sub btnLogin_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.GotFocus
        btnLogin.BackColor = Color.FromArgb(43, 147, 223)
    End Sub

    Private Sub btnLogin_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.LostFocus
        btnLogin.BackColor = Color.FromArgb(57, 160, 235)
    End Sub

    Private Sub btnLogin_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.MouseEnter

        btnLogin.BackColor = Color.FromArgb(43, 147, 223)
    End Sub

    Private Sub btnLogin_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.MouseLeave

        btnLogin.BackColor = Color.FromArgb(57, 160, 235)
    End Sub
    Sub Bersih()
        txtPassword.Text = ""
        txtUsername.Text = ""
    End Sub
    Sub Login()
        If Len(Trim(txtUsername.Text)) = 0 Then
            'MessageBox.Show("Username Belum diinput", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ShowMessageBox("username Belum diinput", "Warning", MessageBoxType.Warning)
            txtUsername.Focus()
            Exit Sub
        End If
        If Len(Trim(txtPassword.Text)) = 0 Then
            'MessageBox.Show("Username Password Belum diinput", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ShowMessageBox("Password Belum diinput", "Warning", MessageBoxType.Warning)
            txtUsername.Focus()
            Exit Sub
        End If

        On Error Resume Next

        Dr.Close()
        cekkoneksi()
        sqlcommand = New MySql.Data.MySqlClient.MySqlCommand("Select * from users Where username='" & txtUsername.Text & "' and password='" & Encrypt(txtPassword.Text) & "'", conn)
        Dr = sqlcommand.ExecuteReader
        Dr.Read()
        If Not Dr.HasRows Then
            ShowMessageBox("Maaf, Username atau Password Anda Salah", "Error", MessageBoxType.Critical)
            Dr.Close()
            tutupkoneksi()
            Bersih()
            txtUsername.Focus()
            txtPassword.BackColor = Color.FromArgb(55, 172, 252)
            Exit Sub
        ElseIf Dr.Item("user_type") = "Administrator" Then
            cekkoneksi()
            sql = "INSERT INTO logs values ('" & txtUsername.Text & "','Administrator','" & System.DateTime.Now & "')"
            sqlcommand = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
            tutupkoneksi()
            cekkoneksi()
            sqlcommand.ExecuteNonQuery()
            tutupkoneksi()

            'Menu_Utama.Panel_Menu.Controls.Clear()
            'Menu_Utama.LblUser_Type.Text = Dr.Item("user_type")
            'Menu_Utama.txtUserType.Text = "Administrator"
            'Menu_Utama.Lbl_User.Text = Dr.Item("username")
            ' Menu_Utama.Lbl_User.Text = Me.txtUsername.Text
            Splash.Show()
            Me.Hide()
            'Menu_Admin.TopLevel = False
            'Menu_Utama.Panel_Menu.Controls.Add(Menu_Admin)
            'Menu_Admin.Show()
            'Me.Hide()
            'ElseIf Dr.Item("user_type") = "User" Then
            '    cekkoneksi()
            '    sql = "INSERT INTO logs values ('" & txtusername.Text & "','User','" & System.DateTime.Now & "')"
            '    sqlcommand = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
            '    tutupkoneksi()
            '    cekkoneksi()
            '    sqlcommand.ExecuteNonQuery()
            '    tutupkoneksi()

            '    Menu_Utama.Show()
            '    Menu_Utama.LblUser_Type.Text = Dr.Item("user_type")
            '    Menu_Utama.Lbl_User.Text = Dr.Item("username")
            '    Menu_Utama.Panel_Menu.Controls.Clear()
            '    Menu_User.TopLevel = False
            '    Menu_Utama.Panel_Menu.Controls.Add(Menu_User)
            '    Menu_User.Show()
            '    'frmSplash.Show()
            '    'Menu_Utama.show()
            '    Me.Hide()
        End If
    End Sub
    Private Sub txtusername_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUsername.GotFocus
        txtUsername.BackColor = Color.FromArgb(55, 172, 252)
        Try
            If txtUsername.Text = "USERNAME" Then
                txtUsername.Text = ""
            End If
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
    End Sub

    Private Sub txtusername_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUsername.LostFocus
        txtUsername.BackColor = Color.FromArgb(55, 172, 252)
        Try
            If txtUsername.Text = "" Then
                txtUsername.Text = "USERNAME"
                txtUsername.Font = New Font("Segoe UI Semibold", 12, FontStyle.Bold)
                txtUsername.ForeColor = Color.White
            End If
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
    End Sub

    Private Sub txtusername_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUsername.TextChanged
        Try
            If txtUsername.Text = "USERNAME" Then
                txtUsername.Font = New Font("Segoe UI Semibold", 12, FontStyle.Bold)
                txtUsername.ForeColor = Color.White
            ElseIf txtUsername.Text <> "" Then
                txtUsername.Font = New Font("Segoe UI Semibold", 12, FontStyle.Bold)
                txtUsername.ForeColor = Color.White
            End If
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
    End Sub

    Private Sub txtpassword_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPassword.GotFocus
        txtPassword.BackColor = Color.FromArgb(55, 172, 252)
        Try
            If txtPassword.Text = "PASSWORD" Then
                txtPassword.Text = ""
                txtPassword.PasswordChar = "•"
            End If
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try

    End Sub

    Private Sub txtpassword_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPassword.LostFocus
        txtPassword.BackColor = Color.FromArgb(55, 172, 252)
        Try
            If txtPassword.Text = "" Then
                txtPassword.PasswordChar = ""
                txtPassword.Text = "PASSWORD"
                txtPassword.Font = New Font("Segoe UI Semibold", 12, FontStyle.Bold)
                txtPassword.ForeColor = Color.White
            End If
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
    End Sub

    Private Sub LblCLosed_Click(sender As Object, e As EventArgs) Handles LblCLosed.Click
        Me.Close()
    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged

    End Sub

    Private Sub txtPassword_Click(sender As Object, e As EventArgs) Handles txtPassword.Click
        Try
            If txtPassword.Text = "PASSWORD" Then
                txtPassword.Text = ""
                txtPassword.PasswordChar = "•"
            End If
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
    End Sub

    Private Sub txtUsername_ImeModeChanged(sender As Object, e As EventArgs) Handles txtUsername.ImeModeChanged

    End Sub

    Private Sub txtUsername_Click(sender As Object, e As EventArgs) Handles txtUsername.Click
        Try
            If txtUsername.Text = "USERNAME" Then
                txtUsername.Text = ""
            End If
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
    End Sub

    Private Sub txtUsername_ChangeUICues(sender As Object, e As UICuesEventArgs) Handles txtUsername.ChangeUICues
        Try
            If txtUsername.Text = "USERNAME" Then
                txtUsername.Font = New Font("Segoe UI Semibold", 12, FontStyle.Bold)
                txtUsername.ForeColor = Color.White
            ElseIf txtUsername.Text <> "" Then
                txtUsername.Font = New Font("Segoe UI Semibold", 12, FontStyle.Bold)
                txtUsername.ForeColor = Color.White
            End If
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
    End Sub
End Class