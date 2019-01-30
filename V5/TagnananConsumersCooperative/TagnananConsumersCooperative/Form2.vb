Public Class Form2

    Private Sub Form2_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        'MDIParent1.Panel1.Visible = False
        'For Each f As Form In MDIParent1.MdiChildren
        '    f.Close()
        'Next

        'cart2.MdiParent = MDIParent1
        'cart2.Dock = DockStyle.Fill
        'cart2.Show()
        'cart2.Enabled = False
        'loadproductswithstocks()
        'Me.Show()
        'loadcustomer()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadcustomer()
    End Sub
End Class