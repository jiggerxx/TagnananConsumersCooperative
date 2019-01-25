Public Class AddCustomer


    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dept As String = ComboBox1.Text
        Dim fname As String = TextBox1.Text
        Dim mname As String = TextBox2.Text
        Dim lname As String = TextBox3.Text
        Dim street_purok As String = TextBox4.Text
        Dim brgy As String = TextBox5.Text
        Dim city As String = TextBox6.Text
        Dim province As String = TextBox7.Text
        Dim contactnumber As String = TextBox8.Text
        Dim creditlimit As String = TextBox10.Text

        If (String.IsNullOrWhiteSpace(fname) Or String.IsNullOrWhiteSpace(mname) Or String.IsNullOrWhiteSpace(lname) Or String.IsNullOrWhiteSpace(street_purok) Or String.IsNullOrWhiteSpace(brgy) Or String.IsNullOrWhiteSpace(city) Or String.IsNullOrWhiteSpace(province) Or String.IsNullOrWhiteSpace(creditlimit)) Then

            MessageBox.Show("Please input complete customer info")

        Else

            Try

                checkstate()
                dbconn.Open()
                With cmd
                    .Connection = dbconn
                    .CommandText = "INSERT INTO customers (fname,mname,lname,street_purok,barangay,city,province,contact_number,creditlimit,balance,department) VALUES('" & fname & "','" & mname & "','" & lname & "','" & street_purok & "','" & brgy & "','" & city & "','" & province & "','" & contactnumber & "','" & creditlimit & "','0','" & dept & "')"
                    .ExecuteNonQuery()
                    MessageBox.Show("Customer information has been added!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TextBox1.Clear()
                    TextBox2.Clear()
                    TextBox3.Clear()
                    TextBox4.Clear()
                    TextBox5.Clear()
                    TextBox6.Clear()
                    TextBox7.Clear()
                    TextBox8.Clear()
                    TextBox10.Clear()

                End With
            Catch ex As Exception
                MessageBox.Show("Customer Information Not Added! " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

            dbconn.Close()
            dbconn.Dispose()


            loadcustomers()
            loadcustomersingrid()


        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        View.Panel1.Enabled = True
        Me.Close()
        Me.Dispose()


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        adddepartment.Show()
    End Sub
End Class