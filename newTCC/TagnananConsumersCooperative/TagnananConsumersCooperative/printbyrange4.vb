Imports System
Imports System.Data
Imports MySql.Data.MySqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine


Public Class printbyrange4
    Public adapt As New MySqlDataAdapter
    Private conn As String = "Data Source=localhost; Database= tcc_db; User ID =root; Password=;"
    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub printbyrange_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loaddeptname()

        'ComboBox1.SelectedIndex = 0
        'ComboBox2.SelectedIndex = 0
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dsConn As New MySqlConnection(conn)
        Dim dsDA As New MySqlDataAdapter
        Dim selecteddate As String = DateTimePicker1.Value.ToString("yyyy-MM-dd")
        Dim selecteddate2 As String = DateTimePicker2.Value.ToString("yyyy-MM-dd")
        'Dim rd As CrystalDecisions.CrystalReports.Engine.ReportDocument

        Try

            Dim d As New DataSet

            dsConn.Open()

            Dim strSQL As String = ""

            'If ComboBox1.SelectedItem = "Acquired" Then

            '    If ComboBox2.SelectedIndex = 0 Then
            '        strSQL = "SELECT '" & ComboBox2.SelectedItem.ToString & "' as selectedtype,'" & selecteddate2 & "' as maxdate,'" & selecteddate & "' as mindate,CONCAT(supplier_province,', ',supplier_city,', ',supplier_barangay,', ',supplier_street) as suppaddress,stocks_acquired.*,stocks_acquired.*,supplier.* FROM stocks_acquired LEFT JOIN supplier ON stocks_acquired.supplier_code = supplier.supplier_code WHERE stocks_acquired.datereceived BETWEEN '" & selecteddate & "' AND '" & selecteddate2 & "'"
            '    Else
            '        strSQL = "SELECT '" & ComboBox2.SelectedItem.ToString & "' as selectedtype,'" & selecteddate2 & "' as maxdate,'" & selecteddate & "' as mindate,CONCAT(supplier_province,', ',supplier_city,', ',supplier_barangay,', ',supplier_street) as suppaddress,stocks_acquired.*,stocks_acquired.*,supplier.* FROM stocks_acquired LEFT JOIN supplier ON stocks_acquired.supplier_code = supplier.supplier_code WHERE stocks_acquired.datereceived BETWEEN '" & selecteddate & "' AND '" & selecteddate2 & "' AND transac_tax = '" & ComboBox2.SelectedItem.ToString & "'"
            '    End If

            '    dsDA.SelectCommand = New MySqlCommand(strSQL, dsConn)
            '    dsDA.Fill(d, "printbytransacnumber")

            '    rd = New acquiredreportbyrange
            '    rd.SetDataSource(d)
            'ElseIf ComboBox1.SelectedItem = "Released" Then
            '    strSQL = "SELECT stocks_release.*,'" & selecteddate2 & "' as maxdate,'" & selecteddate & "' as mindate,released_products.*,products.*,units.*,type.* FROM stocks_release LEFT JOIN released_products ON stocks_release.releasereceiptnum = released_products.releasereceiptnum LEFT JOIN products ON  released_products.prodcode = products.prodcode LEFT JOIN units ON products.unitID = units.unitID LEFT JOIN type ON products.prodtype = type.typeID WHERE stocks_release.daterelease BETWEEN '" & selecteddate & "' AND '" & selecteddate2 & "'"
            '    dsDA.SelectCommand = New MySqlCommand(strSQL, dsConn)
            '    dsDA.Fill(d, "dailyreportingrelease")

            '    rd = New releasereportrange
            '    rd.SetDataSource(d)
            'End If

            Dim query As String
            Dim creditsalesreportlistalldept As New DataSet
            Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument = New creditsalesreportlistalldept
            Dim fromx As CrystalDecisions.CrystalReports.Engine.TextObject
            Dim tox As CrystalDecisions.CrystalReports.Engine.TextObject
            Dim gtotal As CrystalDecisions.CrystalReports.Engine.TextObject
            Dim prep As CrystalDecisions.CrystalReports.Engine.TextObject


            fromx = rptDoc.ReportDefinition.ReportObjects("Text18")
            tox = rptDoc.ReportDefinition.ReportObjects("Text19")
            gtotal = rptDoc.ReportDefinition.ReportObjects("Text36")
            prep = rptDoc.ReportDefinition.ReportObjects("Text22")


            fromx.Text = selecteddate
            tox.Text = selecteddate2
            'dept.Text = ComboBox1.Text

            dbconn.Close()
            dbconn.Open()
            Try

                With cmd
                    .Connection = dbconn
                    .CommandText = "SELECT FORMAT(SUM(customer_utangs.balance),2) as gtotal FROM department LEFT JOIN customers ON customers.department = department.dept_name LEFT JOIN customer_utangs ON customers.custcode = customer_utangs.custcode WHERE  customer_utangs.transacdate BETWEEN '" & selecteddate & "' AND '" & selecteddate2 & "'"
                    dr = cmd.ExecuteReader

                    While dr.Read
                        gtotal.Text = dr.Item("gtotal")

                    End While

                End With

                dbconn.Close()
                dbconn.Dispose()

            Catch ex As Exception
                'MessageBox.Show(ex.Message)
            End Try

            prep.Text = MDIParent1.user.Text

            Try
                dbconn.Close()
                dbconn.Open()

                query = "SELECT customers.department,FORMAT(SUM(customer_utangs.balance),2) as gtotal FROM department LEFT JOIN customers ON customers.department = department.dept_name LEFT JOIN customer_utangs ON customers.custcode = customer_utangs.custcode  WHERE customer_utangs.transacdate BETWEEN '" & selecteddate & "' AND '" & selecteddate2 & "' GROUP BY department.dept_name "
                adapt = New MySqlDataAdapter(query, dbconn)
                adapt.Fill(creditsalesreportlistalldept, "creditsalesreportlistalldept")

                rptDoc.SetDataSource(creditsalesreportlistalldept)
                dbconn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message + "creditsalesreportlistalldept")
            End Try


            ReportView.CrystalReportViewer1.ReportSource = rptDoc
            ReportView.ShowDialog()
            ReportView.Dispose()


            dsConn.Close()
            dsConn.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        reports.Enabled = True
        Me.Close()

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
        'If ComboBox1.SelectedIndex = 0 Then
        '    ComboBox2.Enabled = True
        'Else
        '    ComboBox2.Enabled = False
        'End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_1(sender As Object, e As EventArgs)
        'dbconn.Close()
        'dbconn.Open()
        'Try

        '    With cmd
        '        .Connection = dbconn
        '        .CommandText = " SELECT department FROM customers WHERE custcode ='" & ComboBox1.SelectedValue.ToString & "'"
        '        dr = cmd.ExecuteReader

        '        While dr.Read
        '            TextBox1.Text = dr.Item("department")

        '        End While

        '    End With

        '    dbconn.Close()
        '    dbconn.Dispose()

        'Catch ex As Exception
        '    'MessageBox.Show(ex.Message)
        'End Try
    End Sub
End Class