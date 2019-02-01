Imports MySql.Data.MySqlClient
Imports System.Data.DataTable

Public Class stockrecievinglist

    Public dataArray(9999, 12) As String
    Dim selectedDR As String = ""

    Public adapt As New MySqlDataAdapter
    Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument = New SRR
    Dim srrnum As CrystalDecisions.CrystalReports.Engine.TextObject
    Dim supname As CrystalDecisions.CrystalReports.Engine.TextObject
    Dim supadd As CrystalDecisions.CrystalReports.Engine.TextObject
    Dim invnum As CrystalDecisions.CrystalReports.Engine.TextObject
    Dim daterec As CrystalDecisions.CrystalReports.Engine.TextObject
    Dim gtotal As CrystalDecisions.CrystalReports.Engine.TextObject
    Dim prep As CrystalDecisions.CrystalReports.Engine.TextObject
    Dim rowclicked As Integer = 0


    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        loadsrrlistsearch(TextBox1.Text)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text.Equals("") Then

            loadsrrlist()
        End If
    End Sub

    Private Sub srrlist_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles srrlist.CellContentClick
        Button2.Enabled = False
    End Sub

    Private Sub srrlist_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles srrlist.CellMouseDoubleClick
        Button2.Enabled = True
        srrnum = rptDoc.ReportDefinition.ReportObjects("Text8")
        supname = rptDoc.ReportDefinition.ReportObjects("Text11")
        supadd = rptDoc.ReportDefinition.ReportObjects("Text12")
        invnum = rptDoc.ReportDefinition.ReportObjects("Text14")
        daterec = rptDoc.ReportDefinition.ReportObjects("Text16")
        gtotal = rptDoc.ReportDefinition.ReportObjects("Text36")
        prep = rptDoc.ReportDefinition.ReportObjects("Text22")



        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            rowclicked = e.RowIndex
        End If

        DataGridView2.Rows.Clear()

        Try
            dbconn.Open()

            With cmd
                .Connection = dbconn
                .CommandText = "SELECT * FROM acquired_products WHERE acquired_products.srrnum = '" & srrlist.Rows(rowclicked).Cells(0).Value & "'"
                dr = cmd.ExecuteReader

                While dr.Read

                    DataGridView2.Rows.Add(New String() {dr.Item("prodcode"), dr.Item("prodname"), dr.Item("qty"), dr.Item("srp"), dr.Item("purchasecapital")})

                End While

            End With

            srrnum.Text = srrlist.Rows(rowclicked).Cells(0).Value
            supname.Text = srrlist.Rows(rowclicked).Cells(5).Value
            supadd.Text = srrlist.Rows(rowclicked).Cells(6).Value
            invnum.Text = srrlist.Rows(rowclicked).Cells(2).Value
            daterec.Text = srrlist.Rows(rowclicked).Cells(3).Value
            gtotal.Text = srrlist.Rows(rowclicked).Cells(7).Value
            prep.Text = srrlist.Rows(rowclicked).Cells(8).Value


        Catch ex As Exception
            MessageBox.Show(ex.Message + "Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        dbconn.Close()
        dbconn.Dispose()

    End Sub

    Private Sub srrlist_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles srrlist.CellMouseClick

        'selectedDR = dataArray(rowclicked, 0)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click





        Dim query As String
        Dim SRR As New DataSet


        Try
            dbconn.Open()

            query = "SELECT prodcode,prodname,qty,srp,purchasecapital FROM acquired_products WHERE srrnum = '" & srrlist.Rows(rowclicked).Cells(0).Value & "'"
            adapt = New MySqlDataAdapter(query, dbconn)
            adapt.Fill(SRR, "SRR")

            rptDoc.SetDataSource(SRR)
            dbconn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message + "SRR")
        End Try


        ReportView.CrystalReportViewer1.ReportSource = rptDoc
        ReportView.ShowDialog()
        ReportView.Dispose()
    End Sub

    Private Sub MaterialFlatButton1_Click(sender As Object, e As EventArgs) Handles MaterialFlatButton1.Click
        loadsrrlist()
        DataGridView2.Rows.Clear()
    End Sub
End Class