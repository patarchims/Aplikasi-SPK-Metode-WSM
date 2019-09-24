<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblCLosed = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.panelPassword = New System.Windows.Forms.Panel()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.panelUsername = New System.Windows.Forms.Panel()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.panelPassword.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelUsername.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(172, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(311, 462)
        Me.Panel1.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(154, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(15, 435)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(162, 19)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "patarchims@gmail.com"
        '
        'Panel2
        '
        Me.Panel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(154, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.Panel2.Location = New System.Drawing.Point(18, 431)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(270, 3)
        Me.Panel2.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(154, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(16, 402)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(134, 19)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Patramore Junior IT"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label2.Image = CType(resources.GetObject("Label2.Image"), System.Drawing.Image)
        Me.Label2.Location = New System.Drawing.Point(57, 107)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(187, 219)
        Me.Label2.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(71, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(158, 33)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Login System"
        '
        'LblCLosed
        '
        Me.LblCLosed.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(172, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.LblCLosed.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LblCLosed.Font = New System.Drawing.Font("Calibri", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCLosed.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.LblCLosed.Location = New System.Drawing.Point(569, 0)
        Me.LblCLosed.Name = "LblCLosed"
        Me.LblCLosed.Size = New System.Drawing.Size(60, 48)
        Me.LblCLosed.TabIndex = 22
        Me.LblCLosed.Text = "X"
        Me.LblCLosed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(320, 131)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(299, 39)
        Me.Label6.TabIndex = 64
        Me.Label6.Text = "Login System"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'panelPassword
        '
        Me.panelPassword.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(172, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.panelPassword.Controls.Add(Me.PictureBox4)
        Me.panelPassword.Controls.Add(Me.txtPassword)
        Me.panelPassword.Location = New System.Drawing.Point(358, 254)
        Me.panelPassword.Name = "panelPassword"
        Me.panelPassword.Size = New System.Drawing.Size(229, 42)
        Me.panelPassword.TabIndex = 63
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(9, 10)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(26, 22)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 44
        Me.PictureBox4.TabStop = False
        '
        'txtPassword
        '
        Me.txtPassword.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(172, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPassword.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.ForeColor = System.Drawing.Color.Transparent
        Me.txtPassword.Location = New System.Drawing.Point(46, 10)
        Me.txtPassword.MaxLength = 18
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(163, 22)
        Me.txtPassword.TabIndex = 2
        Me.txtPassword.Text = "PASSWORD"
        '
        'panelUsername
        '
        Me.panelUsername.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(172, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.panelUsername.Controls.Add(Me.PictureBox5)
        Me.panelUsername.Controls.Add(Me.txtUsername)
        Me.panelUsername.Location = New System.Drawing.Point(358, 196)
        Me.panelUsername.Name = "panelUsername"
        Me.panelUsername.Size = New System.Drawing.Size(229, 42)
        Me.panelUsername.TabIndex = 62
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(9, 10)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(26, 22)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox5.TabIndex = 44
        Me.PictureBox5.TabStop = False
        '
        'txtUsername
        '
        Me.txtUsername.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(172, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtUsername.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsername.ForeColor = System.Drawing.Color.Transparent
        Me.txtUsername.Location = New System.Drawing.Point(46, 10)
        Me.txtUsername.MaxLength = 18
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(163, 22)
        Me.txtUsername.TabIndex = 1
        Me.txtUsername.Text = "USERNAME"
        '
        'btnLogin
        '
        Me.btnLogin.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(172, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogin.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogin.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnLogin.Location = New System.Drawing.Point(411, 356)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(114, 49)
        Me.btnLogin.TabIndex = 61
        Me.btnLogin.Text = "Login"
        Me.btnLogin.UseVisualStyleBackColor = False
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(628, 462)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.panelPassword)
        Me.Controls.Add(Me.panelUsername)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.LblCLosed)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.panelPassword.ResumeLayout(False)
        Me.panelPassword.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelUsername.ResumeLayout(False)
        Me.panelUsername.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents LblCLosed As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents panelPassword As Panel
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents panelUsername As Panel
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents btnLogin As Button
End Class
