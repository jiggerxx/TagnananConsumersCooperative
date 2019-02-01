Imports MySql.Data.MySqlClient
Imports System.Data.DataTable
Public Class stockrecieving

    Public adapt As New MySqlDataAdapter
    Private Sub stockrecieving_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblDate.Text = Today
        loadsrrnum()
        loadproducts()
        loadsuppliers()



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

                End While

            End With

            dbconn.Close()
            dbconn.Dispose()

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        dbconn.Close()
        dbconn.Open()
        Try

            With cmd
                .Connection = dbconn
                .CommandText = " SELECT CONCAT(supplier_street,',',supplier_barangay,',',supplier_city,',',supplier_city) as 'address' FROM supplier WHERE supplier_code ='" & ComboBox2.SelectedValue.ToString & "'"
                dr = cmd.ExecuteReader

                While dr.Read
                    txtSuppAdd.Text = dr.Item("address").ToString

                End While

            End With

            dbconn.Close()
            dbconn.Dispose()

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If txtPurchCapital.Text = "" Then
            MessageBox.Show("PLEASE FILL ALL FIELDS")
        Else
            Dim ppp As Double = CDbl(txtPurchCapital.Text) / CDbl(txtProdQuantity.Text)
            txtPricePerPiece.Text = Format(CDbl(ppp), "0,0.00")

            Dim mp As Double = ppp + (ppp * 0.1)
            txtMarkupPrice.Text = Format(CDbl(mp), "0,0.00")

            profit.Text = (ppp * 0.1) * CDbl(txtProdQuantity.Text)

            txtGrandTotal.Text = Format(CDbl(txtMarkupPrice.Text) * CDbl(txtProdQuantity.Text), "0,0.00")
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim changepercent As Double

        changepercent = ((CDbl(txtMarkupPrice.Text) - CDbl(txtPricePerPiece.Text)) / CDbl(txtPricePerPiece.Text)) * 100
        txtInterest.Text = Format(changepercent, "0,0.00")

        profit.Text = Format((CDbl(txtPricePerPiece.Text) * (CDbl(txtInterest.Text) / 100)) * CDbl(txtProdQuantity.Text), "0,0.00")

        txtGrandTotal.Text = Format(CDbl(txtMarkupPrice.Text) * CDbl(txtProdQuantity.Text), "0,0.00")





    End Sub


    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        'Dim for1 As String = Format((CDbl(Val(txtPricePerPiece.Text)) * CDbl(Val(txtProdQuantity.Text))), "0.00").ToString
        'Dim for2 As String = Format((CDbl(Val(txtPurchCapital.Text)) * 0.1), "0,000").ToString
        DataGridView1.Rows.Add(New String() {txtProdCode.Text, ComboBox1.Text, txtProdType.Text, txtProdQuantity.Text, txtPurchCapital.Text, txtInterest.Text & "(" & Format((CDbl(txtPricePerPiece.Text) * (CDbl(txtInterest.Text) / 100)), "0,0.00") & ")", txtPricePerPiece.Text, txtMarkupPrice.Text, txtGrandTotal.Text})

        Dim gtotal As Double = "0"
        gtotal = CDbl(txtPurchCapital.Text)

        Label26.Text = Format(CDbl(Label26.Text) + gtotal, "0,0.00")
        ComboBox1.SelectedIndex = -1
        txtProdCode.Text = ""
        txtProdBarcode.Text = ""
        txtProdType.Text = ""
        txtPreviousPrice.Text = ""
        txtProdQuantity.Text = ""

        'txtSuppAdd.Text = ""
        'ComboBox3.SelectedIndex = -1
        txtPurchCapital.Text = ""
        txtInterest.Text = "10"
        txtPricePerPiece.Text = ""
        txtMarkupPrice.Text = ""
        txtGrandTotal.Text = ""
        profit.Text = ""
        'txtInvoiceType.Text = ""
        Panel4.Enabled = False

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim stocks As Integer
        Dim invtype As String = ""
        Dim suppname As String = DirectCast(ComboBox2.SelectedItem, KeyValuePair(Of String, String)).Value

        If ComboBox4.SelectedIndex = 0 Then
            invtype = "Cash Invoice"
        ElseIf ComboBox4.SelectedIndex = 1 Then
            invtype = "Delivery Report"
        End If



        If dbconn.State = ConnectionState.Open Then
            dbconn.Close()
        End If
        dbconn.Open()
        With cmd
            .Connection = dbconn
            .CommandText = "INSERT INTO stocks_acquired VALUES('" & ("SRR-" & txtSRR.Text) & "','" & invtype & "','" & txtInvoiceType.Text & "','" & DateTimePicker1.Value.ToString("yyyy/MM/dd HH:MM:ss") & "','" & Today.ToString("yyyy/MM/dd HH:MM:ss") & "','" & suppname & "','" & txtSuppAdd.Text & "','" & Label26.Text & "','" & MDIParent1.user.Text & "')"
            .ExecuteNonQuery()
            MessageBox.Show("SRR #" + txtSRR.Text + " has been saved!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End With

        'MessageBox.Show("" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)


        dbconn.Close()
        dbconn.Dispose()

        Dim qtyholder As Integer

        For x As Integer = 0 To DataGridView1.RowCount - 1
            Try
                checkstate()
                dbconn.Open()
                With cmd
                    .Connection = dbconn
                    .CommandText = "SELECT stock FROM products WHERE prodcode = '" & DataGridView1.Rows(x).Cells(0).Value & "'"
                    dr = cmd.ExecuteReader
                End With

                While dr.Read
                    qtyholder = Val(dr.Item("stock")) + DataGridView1.Rows(x).Cells(3).Value
                End While

            Catch ex As Exception

            End Try
            dbconn.Close()
            dbconn.Dispose()

            'Try

            checkstate()
            dbconn.Open()
            With cmd
                .Connection = dbconn
                .CommandText = "INSERT INTO acquired_products VALUES('" & ("SRR-" & txtSRR.Text) & "','" & DataGridView1.Rows(x).Cells(0).Value & "','" & DataGridView1.Rows(x).Cells(1).Value & "','" & DataGridView1.Rows(x).Cells(3).Value & "','" & DataGridView1.Rows(x).Cells(6).Value & "','" & DataGridView1.Rows(x).Cells(7).Value & "','" & qtyholder & "','" & DateTimePicker1.Value.ToString("yyyy/MM/dd HH:MM:ss") & "','" & DataGridView1.Rows(x).Cells(4).Value & "','0')"
                .ExecuteNonQuery()

            End With
            'Catch ex As Exception
            'MessageBox.Show("Error! " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)

            'End Try
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
                    End While

                End With

            Catch ex As Exception
                MessageBox.Show(ex.Message + "Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            dbconn.Close()
            dbconn.Dispose()

            If stocks = "0" Then

                stocks = stocks + Convert.ToInt32(DataGridView1.Rows(x).Cells(3).Value)

                Try
                    checkstate()
                    dbconn.Open()
                    With cmd

                        .Connection = dbconn
                        .CommandText = "UPDATE products SET stock='" & stocks & "', srp = '" & DataGridView1.Rows(x).Cells(7).Value & "' WHERE prodcode='" & DataGridView1.Rows(x).Cells(0).Value & "'"
                        .ExecuteNonQuery()
                    End With
                Catch ex As Exception
                    MessageBox.Show("Error!" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                dbconn.Close()
                dbconn.Dispose()

                Try
                    checkstate()
                    dbconn.Open()
                    With cmd

                        .Connection = dbconn
                        .CommandText = "UPDATE acquired_products SET stat='1' WHERE prodcode='" & DataGridView1.Rows(x).Cells(0).Value & "'"
                        .ExecuteNonQuery()
                    End With
                Catch ex As Exception
                    MessageBox.Show("Error!" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                dbconn.Close()
                dbconn.Dispose()
            End If
        Next

        Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument = New SRR
        Dim srrnum As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim supname As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim supadd As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim invnum As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim daterec As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim gtotal As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim prep As CrystalDecisions.CrystalReports.Engine.TextObject

        srrnum = rptDoc.ReportDefinition.ReportObjects("Text8")
        supname = rptDoc.ReportDefinition.ReportObjects("Text11")
        supadd = rptDoc.ReportDefinition.ReportObjects("Text12")
        invnum = rptDoc.ReportDefinition.ReportObjects("Text14")
        daterec = rptDoc.ReportDefinition.ReportObjects("Text16")
        gtotal = rptDoc.ReportDefinition.ReportObjects("Text36")
        prep = rptDoc.ReportDefinition.ReportObjects("Text22")

        srrnum.Text = txtSRR.Text
        supname.Text = suppname
        supadd.Text = txtSuppAdd.Text
        invnum.Text = txtInvoiceType.Text
        daterec.Text = DateTimePicker1.Value.Date.ToString
        gtotal.Text = "P" & Label26.Text
        prep.Text = MDIParent1.user.Text


        Dim query As String
        Dim SRR As New DataSet


        Try
            dbconn.Open()

            query = "SELECT prodcode,prodname,qty,srp,purchasecapital FROM acquired_products WHERE srrnum = '" & ("SRR-" & txtSRR.Text) & "'"
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
        loadtypes()
        addproduct.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        supplier.Show()
    End Sub

    Private Sub txtInvoiceType_Leave(sender As Object, e As EventArgs) Handles txtInvoiceType.Leave

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Panel4.Enabled = True
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Panel2.Enabled = True
    End Sub
End Class