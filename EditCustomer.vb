Public Class EditCustomer

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Try
            checkstate()
            dbconn.Open()

            With cmd
                .Connection = dbconn
                .CommandText = "SELECT * FROM customers where custcode='" & DirectCast(ComboBox2.SelectedItem, KeyValuePair(Of String, String)).Key & "'"
                dr = cmd.ExecuteReader

                While dr.Read

                    TextBox1.Text = dr.Item("fname")
                    TextBox2.Text = dr.Item("mname")
                    TextBox3.Text = dr.Item("lname")
                    TextBox4.Text = dr.Item("street_purok")
                    TextBox5.Text = dr.Item("barangay")
                    TextBox6.Text = dr.Item("city")
                    TextBox7.Text = dr.Item("province")
                    TextBox8.Text = dr.Item("contact_number")
                    TextBox10.Text = dr.Item("creditlimit")
  
                End While

            End With
        Catch ex As Exception

        End Try
        dbconn.Close()
        dbconn.Dispose()


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim fname As String = TextBox1.Text
        Dim mname As String = TextBox2.Text
        Dim lname As String = TextBox3.Text
        Dim street_purok As String = TextBox4.Text
        Dim brgy As String = TextBox5.Text
        Dim city As String = TextBox6.Text
        Dim province As String = TextBox7.Text
        Dim contactnumber As String = TextBox8.Text
        Dim creditlimit As String = TextBox10.Text
        Dim selectedkey As String = DirectCast(ComboBox2.SelectedItem, KeyValuePair(Of String, String)).Key


        If (String.IsNullOrWhiteSpace(fname) Or String.IsNullOrWhiteSpace(mname) Or String.IsNullOrWhiteSpace(lname) Or String.IsNullOrWhiteSpace(street_purok) Or String.IsNullOrWhiteSpace(brgy) Or String.IsNullOrWhiteSpace(city) Or String.IsNullOrWhiteSpace(province) Or String.IsNullOrWhiteSpace(creditlimit)) Then

            MessageBox.Show("Please input complete customer info")

        Else

            Try

                checkstate()
                dbconn.Open()
                With cmd

                    .Connection = dbconn
                    .CommandText = "UPDATE customers SET fname='" & fname & "',mname='" & mname & "',lname='" & lname & "',street_purok='" & street_purok & "',barangay='" & brgy & "',city='" & city & "',province='" & province & "',creditlimit='" & creditlimit & "' WHERE custcode='" & selectedkey & "'"
                    .ExecuteNonQuery()
                    MessageBox.Show("Customer " + fname + " " + mname + " " + lname + " has been updated!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)


                End With
            Catch ex As Exception
                MessageBox.Show("Account not updated! " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

            dbconn.Close()
            dbconn.Dispose()

            loadcustomers()
            loadcustomersingrid()


        End If

    End Sub
End Class