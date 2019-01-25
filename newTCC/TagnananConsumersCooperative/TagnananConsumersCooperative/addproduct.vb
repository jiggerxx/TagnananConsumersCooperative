Public Class addproduct

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim bcode As String = TextBox3.Text
        Dim pname As String = TextBox2.Text
        Dim ptype As String

        Dim result As Integer = MessageBox.Show("Add item?" + vbNewLine + "Prodcut Name: " + pname.ToUpper, "", MessageBoxButtons.YesNoCancel)
        If result = DialogResult.Cancel Then

        ElseIf result = DialogResult.No Then

        ElseIf result = DialogResult.Yes Then

            Try

                ptype = DirectCast(ComboBox3.SelectedItem, KeyValuePair(Of String, String)).Value
            Catch ex As Exception
                ptype = ""
            End Try
            checkstate()
            dbconn.Open()

            Try

                checkstate()
                dbconn.Open()
                With cmd
                    .Connection = dbconn
                    .CommandText = "INSERT INTO products (barcode,prodname,prodtype,stock,srp) VALUES('" & bcode & "','" & pname & "','" & ptype & "',0,0)"
                    .ExecuteNonQuery()
                    MessageBox.Show("Product " + pname + " has been added!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TextBox2.Clear()
                    TextBox3.Clear()
                    ComboBox3.SelectedIndex = -1


                End With
            Catch ex As Exception
                MessageBox.Show("Product Not Added! " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

            dbconn.Close()
            dbconn.Dispose()
        End If

        loadproducts()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class