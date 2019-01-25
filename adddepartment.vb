Public Class adddepartment

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        loaddeptname()
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dept As String = TextBox1.Text

        Try

            checkstate()
            dbconn.Open()
            With cmd
                .Connection = dbconn
                .CommandText = "INSERT INTO department (dept_name) VALUES('" & dept & "')"
                .ExecuteNonQuery()
                MessageBox.Show(dept + " has been added!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
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