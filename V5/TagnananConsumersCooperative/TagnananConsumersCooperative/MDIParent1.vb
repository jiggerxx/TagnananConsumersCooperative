Imports System.Windows.Forms

Public Class MDIParent1

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs)
        ' Create a new instance of the child form.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Window " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Add code here to open the file.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Add code here to save the current contents of the form to a file.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub

    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Me.ToolStrip.Visible = Me.ToolBarToolStripMenuItem.Checked
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer

    Private Sub DASHBOARDToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DASHBOARDToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles DASHBOARDToolStripMenuItem.Click

        Me.Panel1.Visible = False
        For Each f As Form In Me.MdiChildren
            f.Close()
        Next

        Form1.MdiParent = Me
        Form1.Dock = DockStyle.Fill
        Form1.Show()
    End Sub

    Private Sub MDIParent1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
     
        Me.Panel1.Visible = False
        For Each f As Form In Me.MdiChildren
            f.Close()
        Next

        Form1.MdiParent = Me
        Form1.Dock = DockStyle.Fill
        Form1.Show()
        loadoutofstock()
    End Sub

    Private Sub MenuStrip_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip.ItemClicked

    End Sub

    Private Sub STOCKRECIEVINGREPORTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles STOCKRECIEVINGREPORTToolStripMenuItem.Click
       

    End Sub

    Private Sub CUSTOMERToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CUSTOMERToolStripMenuItem.Click
     

        Me.Panel1.Visible = True
        For Each f As Form In Me.MdiChildren
            f.Close()
        Next
        Dim view1 As New Panel
        Me.Panel1.Controls.Clear()
        view1 = View.Panel1
        Me.Panel1.Controls.Add(view1)
        loadcustomersingrid()

    End Sub

    Private Sub POSToolStripMenuItem_Click(sender As Object, e As EventArgs)


        Me.Panel1.Visible = True
        For Each f As Form In Me.MdiChildren
            f.Close()
        Next

        Dim view1 As New Panel
        Me.Panel1.Controls.Clear()
        view1 = POS.Panel1
        Me.Panel1.Controls.Add(view1)


        POS.TextBox8.Text = System.DateTime.Now.ToString("yyyy/MM/dd")

    End Sub


    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub user_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ADDToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ADDToolStripMenuItem.Click
        Me.Panel1.Visible = False
        For Each f As Form In Me.MdiChildren
            f.Close()
        Next

        stockrecieving.MdiParent = Me
        stockrecieving.Dock = DockStyle.Fill
        stockrecieving.Show()
    End Sub

    Private Sub VIEWToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VIEWToolStripMenuItem.Click
        Me.Panel1.Visible = False
        For Each f As Form In Me.MdiChildren
            f.Close()
        Next

        stockrecievinglist.MdiParent = Me
        stockrecievinglist.Dock = DockStyle.Fill
        stockrecievinglist.Show()
        loadsrrlist()
       
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        login.loginpassword.Clear()
        login.loginusername.Clear()
        login.Show()
        Me.Hide()
    End Sub

    Private Sub user_Click(sender As Object, e As EventArgs)
        usermanagement.Show()
    End Sub

    Private Sub POSToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles POSToolStripMenuItem1.Click
        Me.Panel1.Visible = False
        For Each f As Form In Me.MdiChildren
            f.Close()
        Next

        cart2.MdiParent = Me
        cart2.Dock = DockStyle.Fill
        cart2.Show()
        loadproductswithstocks()

    End Sub

    Public Function Loader()

        With cart2
            .DataGridView1.Rows.Clear()
            .prodcode.Text = "-"
            .prodname.Text = "-"

            .srp.Text = "-"
            .qty.Text = "-"
            .ComboBox1.SelectedIndex = -1
            .totalcost.Text = "-"

            .cartcounterX = 0
            .draftcounterX = 0
            .totalpays = 0
            .draftpays = 0
            .totalunits = 0

        End With
        Return Nothing
    End Function

    Private Sub STOCKCARDToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles STOCKCARDToolStripMenuItem.Click
        Me.Panel1.Visible = False
        For Each f As Form In Me.MdiChildren
            f.Close()
        Next

        ViewStockCard.MdiParent = Me
        ViewStockCard.Dock = DockStyle.Fill
        ViewStockCard.Show()
    End Sub

    Private Sub RETURNTOSTOCKToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RETURNTOSTOCKToolStripMenuItem.Click
       
    End Sub

    Private Sub REPORTSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles REPORTSToolStripMenuItem.Click
        Me.Panel1.Visible = False
        For Each f As Form In Me.MdiChildren
            f.Close()
        Next

        reports.MdiParent = Me
        reports.Dock = DockStyle.Fill
        reports.Show()
    End Sub

    Private Sub VIEWToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles VIEWToolStripMenuItem1.Click
        Me.Panel1.Visible = False
        For Each f As Form In Me.MdiChildren
            f.Close()
        Next

        returnlist.MdiParent = Me
        returnlist.Dock = DockStyle.Fill
        returnlist.Show()
    End Sub

    Private Sub ADDToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ADDToolStripMenuItem1.Click
        Me.Panel1.Visible = False
        For Each f As Form In Me.MdiChildren
            f.Close()
        Next

        returntostock.MdiParent = Me
        returntostock.Dock = DockStyle.Fill
        returntostock.Show()
    End Sub

    Private Sub user_Click_1(sender As Object, e As EventArgs) Handles user.Click
        usermanagement.Show()
        Me.Enabled = False
    End Sub
End Class
