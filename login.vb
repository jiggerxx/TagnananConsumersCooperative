
Public Class login

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim username As String = loginusername.Text
        Dim password As String = loginpassword.Text
        Dim active As Integer = 1
        Dim position As String

        If (String.IsNullOrEmpty(username) Or String.IsNullOrWhiteSpace(password)) Then
            MessageBox.Show("Please fill all fields!", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else


            Dim wrapper As New EncryptDecryptVB(password)
            password = wrapper.EncryptData(password)


            Dim tandf As Boolean
            Try
                dbconn.Open()

                With cmd
                    .Connection = dbconn
                    .CommandText = "SELECT * FROM tcc_db.user"
                    dr = cmd.ExecuteReader

                    While dr.Read
                        If username.Equals(dr.GetString("username")) And password.Equals(dr.GetString("password")) Then

                            Dim name As String = dr.Item("fname")
                            Dim mname As String = dr.Item("mname")
                            Dim lname As String = dr.Item("lname")
                            position = dr.Item("acctype")
                            MessageBox.Show("Welcome " + name + " " + mname + " " + lname + "!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            tandf = True

                            MDIParent1.user.Text = position & " - " & name

                            If position = "CASHIER" Then
                                MDIParent1.DASHBOARDToolStripMenuItem.Visible = False
                                MDIParent1.STOCKSToolStripMenuItem.Visible = False
                                MDIParent1.CUSTOMERToolStripMenuItem.Visible = False
                                MDIParent1.user.Visible = False
                            End If

                            MDIParent1.Show()
                            Me.Hide()
                        End If
                    End While
                    If tandf = False Then
                        MessageBox.Show("Account Not Found!", "", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        loginpassword.Clear()
                        loginusername.Clear()
                        loginusername.Focus()


                    End If

                End With

            Catch ex As Exception
                'MessageBox.Show(ex.Message + "Account Not Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                loginusername.Clear()
                loginpassword.Clear()
            End Try
            dbconn.Close()
            dbconn.Dispose()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            checkstate()
            dbconn.Open()

            With cmd
                .Connection = dbconn
                .CommandText = "SELECT * FROM tcc_db.user where acctype='ADMIN'"
                dr = cmd.ExecuteReader

                While dr.Read
                    LinkLabel1.Visible = False
                End While

            End With

        Catch ex As Exception
        End Try
        dbconn.Close()
        dbconn.Dispose()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Register.Show()
        Register.TextBox2.Focus()
        Register.ComboBox1.SelectedIndex = 0
        Register.ComboBox1.Enabled = False
        Me.Hide()
    End Sub
End Class