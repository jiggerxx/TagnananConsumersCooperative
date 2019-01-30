Public Class View

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        loadcustomers()

        EditCustomer.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Panel1.Enabled = False
        loaddeptname()
        AddCustomer.ShowDialog()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        loadcustomersearchedclick(TextBox1.Text)
    End Sub

    Private Sub View_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class