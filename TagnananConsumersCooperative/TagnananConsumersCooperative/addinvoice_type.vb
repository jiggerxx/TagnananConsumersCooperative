Public Class addinvoice_type

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        loadinvoicetype()
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim inv As String = TextBox1.Text

        Try

            checkstate()
            dbconn.Open()
            With cmd
                .Connection = dbconn
                .CommandText = "INSERT INTO invoice_type (invtype) VALUES('" & inv & "')"
                .ExecuteNonQuery()
                MessageBox.Show(inv + " has been added!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TextBox1.Clear()
                loaddeptname()
            End With
        Catch ex As Exception
            MessageBox.Show("Name Not Added! " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        dbconn.Close()
        dbconn.Dispose()

    End Sub
End Class