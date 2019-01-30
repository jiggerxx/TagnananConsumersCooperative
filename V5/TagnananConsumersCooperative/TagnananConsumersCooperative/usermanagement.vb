Public Class usermanagement

    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        Register.ShowDialog()
    End Sub

    Private Sub Button26_Click(sender As Object, e As EventArgs)
        ' editaccount.ShowDialog()
    End Sub

    Private Sub Button28_Click(sender As Object, e As EventArgs)
        'disableaccount.ShowDialog()
    End Sub

    Private Sub Button27_Click(sender As Object, e As EventArgs)
        ' enableaccount.ShowDialog()
    End Sub

    Private Sub Button34_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button33_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        'main.Button12.BackColor = Color.FromArgb(236, 159, 32)
        Me.Close()
        MDIParent1.Enabled = True
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
        'deletetransac.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        'supplier.ShowDialog()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        addtype.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs)
        'deleteproduct.ShowDialog()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)
        ' deleteaccount.ShowDialog()
    End Sub

    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles Button1.Click
        loadproductsx()
        updatestocks.Show()
        Me.Enabled = False
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        addproduct.Show()
        Me.Enabled = False
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        loadproductsx()
        updatestocksinfo.Show()
        Me.Enabled = False
    End Sub
End Class