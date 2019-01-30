Public Class Form1

    Private Sub Label2_Click(sender As Object, e As EventArgs)
       
    End Sub

    Private Sub Label2_Click_1(sender As Object, e As EventArgs) Handles Label2.Click
        allstockgrid.MdiParent = MDIParent1
        allstockgrid.Dock = DockStyle.Fill
        allstockgrid.Show()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadoutofstock()
        loadallstock()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        allstockgrid.MdiParent = MDIParent1
        allstockgrid.Dock = DockStyle.Fill
        allstockgrid.Show()
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint
        
    End Sub

    Private Sub Panel2_Click(sender As Object, e As EventArgs) Handles Panel2.Click
        allstockgrid.MdiParent = MDIParent1
        allstockgrid.Dock = DockStyle.Fill
        allstockgrid.Show()
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        outofstockgrid.MdiParent = MDIParent1
        outofstockgrid.Dock = DockStyle.Fill
        outofstockgrid.Show()
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        outofstockgrid.MdiParent = MDIParent1
        outofstockgrid.Dock = DockStyle.Fill
        outofstockgrid.Show()
    End Sub

    Private Sub Panel5_Click(sender As Object, e As EventArgs) Handles Panel5.Click
        outofstockgrid.MdiParent = MDIParent1
        outofstockgrid.Dock = DockStyle.Fill
        outofstockgrid.Show()
    End Sub
End Class
