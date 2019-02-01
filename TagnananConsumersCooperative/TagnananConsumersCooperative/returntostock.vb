Imports MySql.Data.MySqlClient
Imports System.Data.DataTable
Public Class returntostock


    Dim srp As Double = 0

    Public adapt As New MySqlDataAdapter
    Private Sub returntostock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblDate.Text = Today
        loadrtsnum()
        loadproductsrts()




    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        dbconn.Close()
        dbconn.Open()
        Try

            With cmd
                .Connection = dbconn
                .CommandText = " SELECT * FROM products WHERE prodcode ='" & ComboBox1.SelectedValue.ToString & "'"
                dr = cmd.ExecuteReader

                While dr.Read
                    txtProdCode.Text = dr.Item("prodcode").ToString
                    txtProdBarcode.Text = dr.Item("barcode").ToString
                    txtProdType.Text = dr.Item("prodtype").ToString
                    txtPreviousPrice.Text = dr.Item("srp").ToString
                    srp = dr.Item("srp").ToString
                End While

            End With

            dbconn.Close()
            dbconn.Dispose()

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs)
        'dbconn.Close()
        'dbconn.Open()
        'Try

        '    With cmd
        '        .Connection = dbconn
        '        .CommandText = " SELECT CONCAT(supplier_street,',',supplier_barangay,',',supplier_city,',',supplier_city) as 'address' FROM supplier WHERE supplier_code ='" & ComboBox2.SelectedValue.ToString & "'"
        '        dr = cmd.ExecuteReader

        '        While dr.Read
        '            txtSuppAdd.Text = dr.Item("address").ToString

        '        End While

        '    End With

        '    dbconn.Close()
        '    dbconn.Dispose()

        'Catch ex As Exception
        '    'MessageBox.Show(ex.Message)
        'End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

       

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)


        
    End Sub


    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        'Dim for1 As String = Format((CDbl(Val(txtPricePerPiece.Text)) * CDbl(Val(txtProdQuantity.Text))), "0.00").ToString
        'Dim for2 As String = Format((CDbl(Val(txtPurchCapital.Text)) * 0.1), "0,000").ToString
        DataGridView1.Rows.Add(New String() {txtProdCode.Text, ComboBox1.Text, txtProdQuantity.Text, txtPreviousPrice.Text, txtGrandTotal.Text})

        Dim gtotal As Double = "0"
        gtotal = CDbl(txtGrandTotal.Text)

        Label26.Text = (CDbl(Label26.Text) + gtotal).ToString

        ComboBox1.SelectedIndex = -1
        txtProdCode.Text = ""
        txtProdBarcode.Text = ""
        txtProdType.Text = ""
        txtPreviousPrice.Text = "0"
        txtProdQuantity.Text = "0"

        'txtSuppAdd.Text = ""
        'ComboBox3.SelectedIndex = -1
       
        'txtInvoiceType.Text = ""
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim stocks As Integer
        Dim srp As Double = 0
        Dim invtype As String = ""




        If dbconn.State = ConnectionState.Open Then
            dbconn.Close()
        End If
        dbconn.Open()
        With cmd
            .Connection = dbconn
            .CommandText = "INSERT INTO stocks_acquired VALUES('" & ("RTS" & txtSRR.Text) & "','" & invtype & "','0','" & lblDate.Text & "','" & lblDate.Text & "','0','0','" & Label26.Text & "','" & MDIParent1.user.Text & "')"
            .ExecuteNonQuery()
            MessageBox.Show("RTS #" + txtSRR.Text + " has been saved!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End With

        'MessageBox.Show("" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)


        dbconn.Close()
        dbconn.Dispose()



        For x As Integer = 0 To DataGridView1.RowCount - 1
            Try

                checkstate()
                dbconn.Open()
                With cmd
                    .Connection = dbconn
                    .CommandText = "INSERT INTO acquired_products VALUES('" & ("RTS" & txtSRR.Text) & "','" & DataGridView1.Rows(x).Cells(0).Value & "','" & DataGridView1.Rows(x).Cells(1).Value & "','" & DataGridView1.Rows(x).Cells(2).Value & "','" & DataGridView1.Rows(x).Cells(3).Value & "','" & lblDate.Text & "','" & DataGridView1.Rows(x).Cells(4).Value & "')"
                    .ExecuteNonQuery()

                End With
            Catch ex As Exception
                MessageBox.Show("Error! " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
            dbconn.Close()
            dbconn.Dispose()

            Try
                checkstate()
                dbconn.Open()

                With cmd
                    .Connection = dbconn
                    .CommandText = "SELECT * FROM tcc_db.products where prodcode='" & DataGridView1.Rows(x).Cells(0).Value & "'"
                    dr = cmd.ExecuteReader

                    While dr.Read
                        stocks = dr.Item("stock")
                        srp = CDbl(dr.Item("srp"))
                    End While

                End With

            Catch ex As Exception
                MessageBox.Show(ex.Message + "Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            dbconn.Close()
            dbconn.Dispose()



            stocks = stocks + Convert.ToInt32(DataGridView1.Rows(x).Cells(2).Value)

            Try
                checkstate()
                dbconn.Open()
                With cmd

                    .Connection = dbconn
                    .CommandText = "UPDATE products SET stock='" & stocks & "' WHERE prodcode='" & DataGridView1.Rows(x).Cells(0).Value & "'"
                    .ExecuteNonQuery()
                End With
            Catch ex As Exception
                MessageBox.Show("Error!" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            dbconn.Close()
            dbconn.Dispose()


        Next

        Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument = New RTS
        Dim srrnum As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim daterec As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim gtotal As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim prep As CrystalDecisions.CrystalReports.Engine.TextObject

        srrnum = rptDoc.ReportDefinition.ReportObjects("Text8")
        daterec = rptDoc.ReportDefinition.ReportObjects("Text10")
        gtotal = rptDoc.ReportDefinition.ReportObjects("Text36")
        prep = rptDoc.ReportDefinition.ReportObjects("Text22")

        daterec.Text = lblDate.Text
        srrnum.Text = txtSRR.Text
        gtotal.Text = "P" & Format(CDbl(Label26.Text), "0,000.00")
        prep.Text = MDIParent1.user.Text


        Dim query As String
        Dim SRR As New DataSet


        Try
            dbconn.Open()

            query = "SELECT prodcode,prodname,qty,srp,purchasecapital FROM acquired_products WHERE srrnum = '" & ("RTS" & txtSRR.Text) & "'"
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

    Private Sub btnAddProd_Click(sender As Object, e As EventArgs) Handles btnAddProd.Click
        
            Dim ggrand As Double = 0

            Dim quantity As Double = CDbl(txtProdQuantity.Text)
            ggrand = srp * quantity

            Label4.Text = Format(ggrand, "0.00")
            txtGrandTotal.Text = Label4.Text

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        supplier.Show()
    End Sub

    Private Sub txtProdQuantity_TextChanged(sender As Object, e As EventArgs) Handles txtProdQuantity.TextChanged
       
    End Sub
End Class