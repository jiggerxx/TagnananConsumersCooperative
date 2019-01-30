Public Class invoice
    Public transacsnum As String = ""
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim transnumber As String = TextBox1.Text
        Dim datetransac As String = transacdatepicker.Value.ToString("yyyy-MM-dd")
        Dim custname As String
        Dim custcode As String
        Dim totalcost As Double = Convert.ToDouble(TextBox3.Text)
        Dim discount As Double = Convert.ToDouble(TextBox4.Text)
        Dim cashier As String = TextBox5.Text
        Dim totalwdiscount As Double = Convert.ToDouble(TextBox6.Text)
        Dim credit As Double = 0
      
        Dim paymenttype As String = ComboBox4.Text
        Dim prionumber As String = Label14.Text

        Dim cash As String = TextBox7.Text
        Dim chan As String = TextBox8.Text

        Try
            custcode = DirectCast(ComboBox5.SelectedItem, KeyValuePair(Of String, String)).Key
            custname = DirectCast(ComboBox5.SelectedItem, KeyValuePair(Of String, String)).Value
        Catch ex As Exception
            custcode = ""
            custname = ""
        End Try


        If paymenttype = "CASH" And custcode = "" Then
            MessageBox.Show("Payment type selected is vale. Customer must be selected to continue!")
        Else
            Try

                checkstate()
                dbconn.Open()
                With cmd
                    .Connection = dbconn
                    .CommandText = "INSERT INTO resibo VALUES('" & transnumber & "','" & datetransac & "','" & custcode & "','" & totalcost & "','" & discount & "','" & totalwdiscount & "','" & cashier & "', '" & paymenttype & "', '" & prionumber & "', '" & cash & "', '" & chan & "')"
                    .ExecuteNonQuery()
                    MessageBox.Show("Transaction #" + transnumber + " has been added!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    TextBox1.Clear()
                    TextBox3.Clear()
                    TextBox4.Clear()
                    TextBox5.Clear()
                    TextBox6.Clear()
                    transacsnum = transnumber

                End With
            Catch ex As Exception
                MessageBox.Show("Transaction #" + transnumber + " not added! " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            dbconn.Close()
            dbconn.Dispose()

            Dim qtyholder As Integer

            For x As Integer = 0 To cart2.cartcounterX - 1

                Try
                    checkstate()
                    dbconn.Open()
                    With cmd
                        .Connection = dbconn
                        .CommandText = "SELECT stock FROM products WHERE prodcode = '" & cart2.cartdataArray(x, 0) & "'"
                        dr = cmd.ExecuteReader
                    End With

                    While dr.Read
                        qtyholder = Val(dr.Item("stock")) - Val(cart2.cartdataArray(x, 5))
                    End While

                Catch ex As Exception

                End Try
                dbconn.Close()
                dbconn.Dispose()

                Dim stocks As Integer = 0
                Try

                    checkstate()
                    dbconn.Open()
                    With cmd
                        .Connection = dbconn
                        .CommandText = "insert into resibo_products values('" & transnumber & "','" & cart2.cartdataArray(x, 0) & "','" & cart2.cartdataArray(x, 5) & "','" & Format(CDbl(cart2.cartdataArray(x, 6)), "0.00") & "' ," & qtyholder & ")"
                        .ExecuteNonQuery()

                    End With
                Catch ex As Exception
                    MessageBox.Show("error! 123" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)

                End Try
                dbconn.Close()
                dbconn.Dispose()

                Try
                    checkstate()
                    dbconn.Open()

                    With cmd
                        .Connection = dbconn
                        .CommandText = "select * from products where prodcode='" & cart2.cartdataArray(x, 0) & "'"
                        dr = cmd.ExecuteReader

                        While dr.Read
                            stocks = dr.Item("stock")
                        End While

                    End With

                Catch ex As Exception
                    MessageBox.Show(ex.Message + "error!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                dbconn.Close()
                dbconn.Dispose()

                stocks = stocks - cart2.cartdataArray(x, 5)

                Try
                    checkstate()
                    dbconn.Open()
                    With cmd
                        .Connection = dbconn
                        .CommandText = "update products set stock='" & stocks & "' where prodcode='" & cart2.cartdataArray(x, 0) & "'"
                        .ExecuteNonQuery()

                    End With
                Catch ex As Exception
                    MessageBox.Show("error!" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)

                End Try
                dbconn.Close()
                dbconn.Dispose()

                'totalunits = totalunits + (cart.cartdataArray(x, 3) * cart.cartdataArray(x, 5))

            Next

            If paymenttype = "VALE" Then
                Try

                    checkstate()
                    dbconn.Open()
                    With cmd
                        .Connection = dbconn
                        .CommandText = "insert into customer_utangs values('" & transnumber & "','" & custcode & "','0','" & totalwdiscount & "','" & datetransac & "')"
                        .ExecuteNonQuery()

                    End With
                Catch ex As Exception
                    MessageBox.Show("error! " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)

                End Try
                dbconn.Close()
                dbconn.Dispose()


                Try
                    checkstate()
                    dbconn.Open()

                    With cmd
                        .Connection = dbconn
                        .CommandText = "select * from customers where custcode='" & ComboBox5.SelectedValue.ToString & "'"
                        dr = cmd.ExecuteReader

                        While dr.Read
                            credit = CDbl(dr.Item("creditlimit"))
                        End While

                    End With

                Catch ex As Exception
                    MessageBox.Show(ex.Message + "error!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                dbconn.Close()
                dbconn.Dispose()

                credit = credit - CDbl(trick.Text)
            End If

            Try
                checkstate()
                dbconn.Open()
                With cmd
                    .Connection = dbconn
                    .CommandText = "update customers set balance='" & credit & "' where custcode='" & ComboBox5.SelectedValue.ToString & "'"
                    .ExecuteNonQuery()

                End With
            Catch ex As Exception
                MessageBox.Show("error!" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
            dbconn.Close()
            dbconn.Dispose()

            'If cart.mixxerCounterX <> 0 Then
            '    For x = 0 To cart.mixxerCounterX - 1
            '        Try
            '            checkstate()
            '            dbconn.Open()
            '            With cmd
            '                .Connection = dbconn
            '                .CommandText = "insert into mixxer_transac values('" & cart.mixxerArray(x, 0) & "','" & cart.mixxerArray(x, 1) & "','" & transnumber & "','" & datetransac & "','" & cart.mixxerArray(x, 3) & "','" & cart.mixxerArray(x, 2) & "')"
            '                .ExecuteNonQuery()
            '            End With
            '        Catch ex As Exception
            '            MessageBox.Show("error in mixxer query! " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '        End Try
            '        dbconn.Close()
            '        dbconn.Dispose()
            '    Next
            'End If

            'If agentkey <> "" Then

            '    Try
            '        checkstate()
            '        dbconn.Open()
            '        With cmd
            '            .Connection = dbconn
            '            .CommandText = "insert into agents_transac values('" & agentkey & "','" & transnumber & "','" & datetransac & "','" & cart.totalunits & "','" & cart.agentcanvassertotal & "')"
            '            .ExecuteNonQuery()
            '        End With
            '    Catch ex As Exception
            '        MessageBox.Show("error in agents query! " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)

            '    End Try
            '    dbconn.Close()
            '    dbconn.Dispose()
            'End If

            'If pintorkey <> "" Then

            '    Dim totalpintor As Double = 0

            '    totalpintor = (cart.pintorreadymixtotal + cart.pintormixtotal) - ((cart.pintorreadymixtotal + cart.pintormixtotal) * 0.12)

            '    Try
            '        checkstate()
            '        dbconn.Open()
            '        With cmd
            '            .Connection = dbconn
            '            .CommandText = "insert into pintor_transac values('" & pintorkey & "','" & transnumber & "','" & cart.pintorreadymixtotal & "','" & cart.pintormixtotal & "','" & totalpintor & "','" & datetransac & "')"
            '            .ExecuteNonQuery()

            '        End With
            '    Catch ex As Exception
            '        MessageBox.Show("Error in pintor query! " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)

            '    End Try
            '    dbconn.Close()
            '    dbconn.Dispose()

            'End If

            printreceipt.datafrom = "invoice"
            printreceipt.selectedtransacnum = transnumber
            printreceipt.ShowDialog()

            Me.Close()
            Me.Dispose()


        End If

    End Sub

    Private Sub invoice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadproductswithstocks()
        'TextBox5.Text = MDIParent1.user.Text

        'Dim firstprionum As Boolean = False
        'Dim firsttransacnum As Boolean = False
        'Dim prionum As Integer = 0
        'Dim transacnum As Integer = 0
        'Dim datenow As String = Date.Today.ToString("yyyy-MM-dd")



        'Try
        '    checkstate()
        '    dbconn.Open()

        '    With cmd
        '        .Connection = dbconn
        '        .CommandText = "SELECT MAX(prionum) as maxprionum FROM resibo WHERE transacdate='" & datenow & "'"
        '        dr = cmd.ExecuteReader

        '        While dr.Read
        '            prionum = dr.Item("maxprionum")
        '            firstprionum = True
        '        End While

        '    End With

        'Catch ex As Exception

        'End Try
        'dbconn.Close()
        'dbconn.Dispose()

        'If firstprionum Then
        '    Label14.Text = "" & prionum + 1
        'Else
        '    Label14.Text = "1"
        'End If

        'Try
        '    checkstate()
        '    dbconn.Open()

        '    With cmd
        '        .Connection = dbconn
        '        .CommandText = "SELECT MAX(transacnum) as maxtransacnum FROM resibo  WHERE transacdate='" & datenow & "'"
        '        dr = cmd.ExecuteReader

        '        While dr.Read
        '            transacnum = dr.Item("maxtransacnum")
        '            firsttransacnum = True
        '        End While

        '    End With

        'Catch ex As Exception

        'End Try
        'dbconn.Close()
        'dbconn.Dispose()

        'If firsttransacnum Then
        '    TextBox1.Text = "" & transacnum + 1
        'Else
        '    TextBox1.Text = Date.Today.ToString("yyyyMMdd") & "1"
        'End If

        'ComboBox4.SelectedIndex = 0
        loadcustomer()
        TextBox4.Text = 0
    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or Asc(e.KeyChar) = 8)
        If (e.KeyChar.ToString = ".") And (TextBox4.Text.Contains(e.KeyChar.ToString)) Then
            e.Handled = True
            Exit Sub
        End If
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs)
        'addagent.ShowDialog()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        'addagent.ShowDialog()
    End Sub

    Private Sub TextBox4_Leave(sender As Object, e As EventArgs) Handles TextBox4.Leave
        Dim discount As Double
        Dim total As Double = Convert.ToDouble(TextBox3.Text)
        Dim finaltotal As Double = 0

        Try
            discount = Convert.ToDouble(TextBox4.Text)
        Catch ex As Exception
            TextBox4.Text = 0
            discount = 0
        End Try

        'discount = (discount / 100)
        'finaltotal = total * discount
        'finaltotal = total - finaltotal

        finaltotal = total - discount

        TextBox6.Text = finaltotal

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)
        'addagent.ShowDialog()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
        'addcustomerinfo.ShowDialog()
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged

        trick.Text = TextBox6.Text
        If ComboBox4.Text = "CASH" Then
            GroupBox1.Visible = True
            TextBox7.Visible = True
            TextBox7.Focus()
        Else
            GroupBox1.Visible = False
            TextBox7.Visible = False
        End If

        'If ComboBox4.Text = "Charge" Then
        '    ComboBox6.Enabled = True
        '    ComboBox6.SelectedIndex = 0
        'Else
        '    ComboBox6.Enabled = False
        '    ComboBox6.SelectedIndex = -1
        'End If
    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox5.SelectedIndexChanged
        dbconn.Close()
        dbconn.Open()
        Try

            With cmd
                .Connection = dbconn
                .CommandText = " SELECT * FROM customers WHERE custcode ='" & ComboBox5.SelectedValue.ToString & "'"
                dr = cmd.ExecuteReader

                While dr.Read

                    TextBox2.Text = Format(CDbl(dr.Item("balance")), "0,0.00")
                End While

            End With

            dbconn.Close()
            dbconn.Dispose()

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs)
  
    End Sub

    Private Sub TextBox7_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox7.TextChanged

        If (TextBox7.Text.Equals("")) Then
            TextBox7.Text = ".00"
            TextBox7.BackColor = Color.White
            TextBox7.ForeColor = Color.Black
        ElseIf CDbl(TextBox6.Text) < CDbl(TextBox7.Text) Or CDbl(TextBox6.Text) = CDbl(TextBox7.Text) Then
            TextBox7.BackColor = Color.Green
            TextBox7.ForeColor = Color.White
        Else
            TextBox7.BackColor = Color.Red
            TextBox7.ForeColor = Color.White
        End If
    End Sub

    Private Sub TextBox7_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox7.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox8.Text = Format((CDbl(TextBox7.Text) - CDbl(TextBox6.Text)), "0.00")
            TextBox7.Text = Format(CDbl(TextBox7.Text), "0.00")
        End If
    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged

    End Sub
End Class