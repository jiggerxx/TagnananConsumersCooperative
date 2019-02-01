Public Class outofstockgrid

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        loadoutofstocksearchedclick(TextBox1.Text.ToString)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text.Equals("") Then

            loadoutofstock()
        End If
    End Sub
End Class