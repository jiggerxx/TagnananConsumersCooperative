Public Class reports

    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label2_Click_1(sender As Object, e As EventArgs)
        allstockgrid.MdiParent = MDIParent1
        allstockgrid.Dock = DockStyle.Fill
        allstockgrid.Show()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadoutofstock()
        loadallstock()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)
        allstockgrid.MdiParent = MDIParent1
        allstockgrid.Dock = DockStyle.Fill
        allstockgrid.Show()
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Panel2_Click(sender As Object, e As EventArgs)
        allstockgrid.MdiParent = MDIParent1
        allstockgrid.Dock = DockStyle.Fill
        allstockgrid.Show()
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs)
        outofstockgrid.MdiParent = MDIParent1
        outofstockgrid.Dock = DockStyle.Fill
        outofstockgrid.Show()
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs)
        outofstockgrid.MdiParent = MDIParent1
        outofstockgrid.Dock = DockStyle.Fill
        outofstockgrid.Show()
    End Sub

    Private Sub Panel5_Click(sender As Object, e As EventArgs)
        outofstockgrid.MdiParent = MDIParent1
        outofstockgrid.Dock = DockStyle.Fill
        outofstockgrid.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        printbyrange.Show()
        Me.Enabled = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        printbyrange2.Show()
        Me.Enabled = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        printbyrange3.Show()
        Me.Enabled = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        printbyrange4.Show()
        Me.Enabled = False
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        printbyrange5.Show()
        Me.Enabled = False
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        printbyrange6.Show()
        Me.Enabled = False
    End Sub
End Class
