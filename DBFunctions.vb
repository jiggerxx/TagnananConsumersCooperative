Imports MySql.Data.MySqlClient

Module DBFunctions


    Public dbconn As New MySqlConnection("server=localhost;userid=root;password=;database=tcc_db")
    Public cmd As New MySqlCommand
    Public dr As MySqlDataReader

    Public dbconn2 As New MySqlConnection("server=localhost;userid=root;password=;database=tcc_db")
    Public cmd2 As New MySqlCommand
    Public dr2 As MySqlDataReader

    Public dbconn3 As New MySqlConnection("server=localhost;userid=root;password=;database=tcc_db")
    Public cmd3 As New MySqlCommand
    Public dr3 As MySqlDataReader

    Public Function addSRR()



        Return Nothing
    End Function

    Public Function checkstate() As Boolean
        Try
            If dbconn.State = ConnectionState.Open Then
                'MessageBox.Show("Database is open!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dbconn.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("Database Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Nothing
    End Function

    Public Function loadsrrnum()

        Dim CreateCommand As MySqlCommand = dbconn.CreateCommand
        Dim da As New MySqlDataAdapter("SELECT * FROM stocks_acquired WHERE srrnum LIKE 'SRR%'", dbconn)
        Dim dt As New DataTable

        da.Fill(dt)

        stockrecieving.txtSRR.Text = Now.Year.ToString() & "-" & Format(dt.Rows.Count() + 1, "0000")

        Return Nothing
    End Function

    Public Function loadrtsnum()

        Dim CreateCommand As MySqlCommand = dbconn.CreateCommand
        Dim da As New MySqlDataAdapter("SELECT * FROM stocks_acquired WHERE srrnum LIKE 'RTS%'", dbconn)
        Dim dt As New DataTable

        da.Fill(dt)

        returntostock.txtSRR.Text = Now.Year.ToString() & "-" & Format(dt.Rows.Count() + 1, "0000")

        Return Nothing
    End Function

    Public Function loadusernum()

        Dim CreateCommand As MySqlCommand = dbconn.CreateCommand
        Dim da As New MySqlDataAdapter("SELECT * FROM employees", dbconn)
        Dim dt As New DataTable

        da.Fill(dt)

        stockrecieving.txtSRR.Text = Now.Year.ToString() & "-EMP-" & Format(dt.Rows.Count() + 1, "0000")

        Return Nothing
    End Function

    Public Function loadoutofstock()
        Dim outstocks As Integer = 0
        outofstockgrid.outofstock_grid.Rows.Clear()
        Try

            checkstate()
            dbconn.Open()

            With cmd
                .Connection = dbconn
                .CommandText = "SELECT * FROM products WHERE stock='0'"
                dr = cmd.ExecuteReader

                While dr.Read
                    outstocks = outstocks + 1
                    outofstockgrid.outofstock_grid.Rows.Add(dr.Item("prodcode"), dr.Item("prodname"), dr.Item("barcode"), dr.Item("prodtype"), dr.Item("srp"))
                End While
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message + "Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        dbconn.Close()
        dbconn.Dispose()

        Form1.Label10.Text = outstocks

        Return Nothing
    End Function

    Public Function loadallstock()
        Dim outstocks As Integer = 0
        allstockgrid.prodgrid.Rows.Clear()
        Try

            checkstate()
            dbconn.Open()

            With cmd
                .Connection = dbconn
                .CommandText = "SELECT * FROM products "
                dr = cmd.ExecuteReader

                While dr.Read
                    outstocks = outstocks + 1
                    allstockgrid.prodgrid.Rows.Add(dr.Item("prodcode"), dr.Item("prodname"), dr.Item("barcode"), dr.Item("prodtype"), dr.Item("srp"), dr.Item("stock"))
                End While
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message + "Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        dbconn.Close()
        dbconn.Dispose()

        Form1.Label2.Text = outstocks

        Return Nothing
    End Function

    Public Function loadoutofstocksearchedclick(ByVal e)
        Dim outstocks As Integer = 0


        If e = "" Then
            MsgBox("No input!")
        Else

            outofstockgrid.outofstock_grid.Rows.Clear()
            Try

                checkstate()
                dbconn.Open()

                With cmd
                    .Connection = dbconn
                    .CommandText = "SELECT * FROM products WHERE stock = '0' AND prodname LIKE '%" & e & "%'"
                    dr = cmd.ExecuteReader

                    While dr.Read
                        outofstockgrid.outofstock_grid.Rows.Add(dr.Item("prodcode"), dr.Item("prodname"), dr.Item("barcode"), dr.Item("prodtype"), dr.Item("srp"))
                    End While
                End With

            Catch ex As Exception
                MessageBox.Show(ex.Message + "Error!", "Record not found!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
        dbconn2.Close()
        dbconn2.Dispose()



        Return Nothing
    End Function

    Public Function loadallstocksearchedclick(ByVal e)
        Dim outstocks As Integer = 0


        If e = "" Then
            MsgBox("No input!")
        Else

            outofstockgrid.outofstock_grid.Rows.Clear()
            Try

                checkstate()
                dbconn.Open()

                With cmd
                    .Connection = dbconn
                    .CommandText = "SELECT * FROM products AND prodname LIKE '%" & e & "%'"
                    dr = cmd.ExecuteReader

                    While dr.Read
                        outofstockgrid.outofstock_grid.Rows.Add(dr.Item("prodcode"), dr.Item("prodname"), dr.Item("barcode"), dr.Item("prodtype"), dr.Item("srp"))
                    End While
                End With

            Catch ex As Exception
                MessageBox.Show(ex.Message + "Error!", "Record not found!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
        dbconn2.Close()
        dbconn2.Dispose()



        Return Nothing
    End Function

    Public Function loadproducts()

        Dim prodcomboSource As New Dictionary(Of String, String)()
        Dim prodautocomplete As New AutoCompleteStringCollection
        Dim tandf As Boolean = False

        Try

            stockrecieving.ComboBox1.DataSource = Nothing

            checkstate()
            dbconn.Open()

            With cmd
                .Connection = dbconn
                .CommandText = "SELECT * FROM products"
                dr = cmd.ExecuteReader

                While dr.Read

                    prodcomboSource.Add(dr.Item("prodcode"), dr.Item("prodname"))
                    prodautocomplete.AddRange(New String() {dr.Item("prodname")})

                    tandf = True
                End While
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message + "Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        dbconn.Close()
        dbconn.Dispose()

        If tandf Then
            Try
                stockrecieving.ComboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource
                stockrecieving.ComboBox1.AutoCompleteCustomSource = prodautocomplete
                stockrecieving.ComboBox1.DataSource = New BindingSource(prodcomboSource, Nothing)
                stockrecieving.ComboBox1.DisplayMember = "Value"
                stockrecieving.ComboBox1.ValueMember = "Key"
                stockrecieving.ComboBox1.SelectedIndex = -1

                'updatestocks.ComboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource
                'updatestocks.ComboBox1.AutoCompleteCustomSource = prodautocomplete
                'updatestocks.ComboBox1.DataSource = New BindingSource(prodcomboSource, Nothing)
                'updatestocks.ComboBox1.DisplayMember = "Value"
                'updatestocks.ComboBox1.ValueMember = "Key"
                'updatestocks.ComboBox1.SelectedIndex = -1


            Catch ex As Exception
                MessageBox.Show(ex.ToString + " Error in Products", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("No Products Found! Please Add One First!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        stockrecieving.ComboBox1.SelectedIndex = -1

        Return Nothing
    End Function

    Public Function loadproductsx()

        Dim prodcomboSource As New Dictionary(Of String, String)()
        Dim prodautocomplete As New AutoCompleteStringCollection
        Dim tandf As Boolean = False

        Try

            stockrecieving.ComboBox1.DataSource = Nothing

            checkstate()
            dbconn.Open()

            With cmd
                .Connection = dbconn
                .CommandText = "SELECT * FROM products"
                dr = cmd.ExecuteReader

                While dr.Read

                    prodcomboSource.Add(dr.Item("prodcode"), dr.Item("prodname"))
                    prodautocomplete.AddRange(New String() {dr.Item("prodname")})

                    tandf = True
                End While
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message + "Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        dbconn.Close()
        dbconn.Dispose()

        If tandf Then
            Try


                updatestocks.ComboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource
                updatestocks.ComboBox1.AutoCompleteCustomSource = prodautocomplete
                updatestocks.ComboBox1.DataSource = New BindingSource(prodcomboSource, Nothing)
                updatestocks.ComboBox1.DisplayMember = "Value"
                updatestocks.ComboBox1.ValueMember = "Key"
                updatestocks.ComboBox1.SelectedIndex = -1


            Catch ex As Exception
                MessageBox.Show(ex.ToString + " Error in Products", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("No Products Found! Please Add One First!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        stockrecieving.ComboBox1.SelectedIndex = -1

        Return Nothing
    End Function

    Public Function loadsuppliers()
        Dim Suppliersource As New Dictionary(Of String, String)()
        Dim Supplierautocomplete As New AutoCompleteStringCollection
        Dim tandf As Boolean = False

        Try
            
            stockrecieving.ComboBox2.DataSource = Nothing

            checkstate()
            dbconn.Open()

            With cmd
                .Connection = dbconn
                .CommandText = "SELECT * FROM supplier"
                dr = cmd.ExecuteReader

                While dr.Read

                    Suppliersource.Add(dr.Item("supplier_code"), dr.Item("supplier_name"))
                    Supplierautocomplete.AddRange(New String() {dr.Item("supplier_name")})

                    tandf = True
                End While
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message + "Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        dbconn.Close()
        dbconn.Dispose()

        If tandf Then
            Try


                stockrecieving.ComboBox2.AutoCompleteSource = AutoCompleteSource.CustomSource
                stockrecieving.ComboBox2.AutoCompleteCustomSource = Supplierautocomplete
                stockrecieving.ComboBox2.DataSource = New BindingSource(Suppliersource, Nothing)
                stockrecieving.ComboBox2.DisplayMember = "Value"
                stockrecieving.ComboBox2.ValueMember = "Key"
                stockrecieving.ComboBox2.SelectedIndex = -1

            Catch ex As Exception
                MessageBox.Show(ex.ToString + " Error in Supplier", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("No Records Found! Please Add One First!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        stockrecieving.ComboBox2.SelectedIndex = -1
        Return Nothing
    End Function

    Public Function loadtypes()

        Dim typesource As New Dictionary(Of String, String)()
        Dim typeautocomplete As New AutoCompleteStringCollection
        Dim tandf As Boolean = False

        Try

            addproduct.ComboBox3.DataSource = Nothing


            checkstate()
            dbconn.Open()

            With cmd
                .Connection = dbconn
                .CommandText = "SELECT * FROM type"
                dr = cmd.ExecuteReader

                While dr.Read

                    typesource.Add(dr.Item("typeID"), dr.Item("type"))
                    typeautocomplete.AddRange(New String() {dr.Item("type")})

                    tandf = True
                End While
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message + "Error1!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        dbconn.Close()
        dbconn.Dispose()

        If tandf Then
            Try
                addproduct.ComboBox3.AutoCompleteSource = AutoCompleteSource.CustomSource
                addproduct.ComboBox3.AutoCompleteCustomSource = typeautocomplete
                addproduct.ComboBox3.DataSource = New BindingSource(typesource, Nothing)
                addproduct.ComboBox3.DisplayMember = "Value"
                addproduct.ComboBox3.ValueMember = "Key"
                addproduct.ComboBox3.SelectedIndex = -1

                printbyrange7.ComboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource
                printbyrange7.ComboBox1.AutoCompleteCustomSource = typeautocomplete
                printbyrange7.ComboBox1.DataSource = New BindingSource(typesource, Nothing)
                printbyrange7.ComboBox1.DisplayMember = "Value"
                printbyrange7.ComboBox1.ValueMember = "Key"
                printbyrange7.ComboBox1.SelectedIndex = -1
            Catch ex As Exception
                MessageBox.Show(ex.ToString + " Error in Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("No Records Found! Please Add One First!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Return Nothing
    End Function

    Public Function loaddeptname()

        Dim typesource As New Dictionary(Of String, String)()
        Dim typeautocomplete As New AutoCompleteStringCollection
        Dim tandf As Boolean = False

        Try

            AddCustomer.ComboBox1.DataSource = Nothing
            printbyrange3.ComboBox1.DataSource = Nothing
            printbyrange5.ComboBox1.DataSource = Nothing

            checkstate()
            dbconn.Open()

            With cmd
                .Connection = dbconn
                .CommandText = "SELECT * FROM department"
                dr = cmd.ExecuteReader

                While dr.Read

                    typesource.Add(dr.Item("dept_id"), dr.Item("dept_name"))
                    typeautocomplete.AddRange(New String() {dr.Item("dept_name")})

                    tandf = True
                End While
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message + "Error1!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        dbconn.Close()
        dbconn.Dispose()

        If tandf Then
            Try
                AddCustomer.ComboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource
                AddCustomer.ComboBox1.AutoCompleteCustomSource = typeautocomplete
                AddCustomer.ComboBox1.DataSource = New BindingSource(typesource, Nothing)
                AddCustomer.ComboBox1.DisplayMember = "Value"
                AddCustomer.ComboBox1.ValueMember = "Key"
                AddCustomer.ComboBox1.SelectedIndex = -1

                printbyrange3.ComboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource
                printbyrange3.ComboBox1.AutoCompleteCustomSource = typeautocomplete
                printbyrange3.ComboBox1.DataSource = New BindingSource(typesource, Nothing)
                printbyrange3.ComboBox1.DisplayMember = "Value"
                printbyrange3.ComboBox1.ValueMember = "Key"
                printbyrange3.ComboBox1.SelectedIndex = -1

                printbyrange5.ComboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource
                printbyrange5.ComboBox1.AutoCompleteCustomSource = typeautocomplete
                printbyrange5.ComboBox1.DataSource = New BindingSource(typesource, Nothing)
                printbyrange5.ComboBox1.DisplayMember = "Value"
                printbyrange5.ComboBox1.ValueMember = "Key"
                printbyrange5.ComboBox1.SelectedIndex = -1

            Catch ex As Exception
                MessageBox.Show(ex.ToString + " Error in Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("No Records Found! Please Add One First!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Return Nothing
    End Function
    Public Function loadcustomers()
        Dim accvalue As New Dictionary(Of String, String)()
        Dim accauto As New AutoCompleteStringCollection
        Dim tandf As Boolean = False

        Try
            EditCustomer.ComboBox2.DataSource = Nothing


            checkstate()
            dbconn.Open()

            With cmd
                .Connection = dbconn
                .CommandText = "SELECT * FROM tcc_db.customers"
                dr = cmd.ExecuteReader

                While dr.Read

                    accvalue.Add(dr.Item("custcode"), dr.Item("fname"))
                    accauto.AddRange(New String() {dr.Item("fname") + ": " + dr.Item("custcode").ToString()})

                    tandf = True
                End While
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message + "Error1!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        dbconn.Close()
        dbconn.Dispose()

        If tandf Then
            Try
                EditCustomer.ComboBox2.AutoCompleteSource = AutoCompleteSource.CustomSource
                EditCustomer.ComboBox2.AutoCompleteCustomSource = accauto
                EditCustomer.ComboBox2.DataSource = New BindingSource(accvalue, Nothing)
                EditCustomer.ComboBox2.DisplayMember = "Value"
                EditCustomer.ComboBox2.ValueMember = "Key"
                EditCustomer.ComboBox2.SelectedIndex = 0


            Catch ex As Exception
                MessageBox.Show(ex.ToString + " Error in Edit Customer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("No Records Found! Please Add One First!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Return Nothing
    End Function

    Public Function loadcustomersearchedclick(ByVal e)



        If e = "" Then
            MsgBox("No input!")
        Else

            View.DataGridView1.Rows.Clear()
            Try

                checkstate()
                dbconn.Open()

                With cmd2
                    .Connection = dbconn
                    .CommandText = "SELECT * FROM customers WHERE  fname LIKE '%" & e & "%' OR mname LIKE '%" & e & "%' OR lname LIKE '%" & e & "%' OR custcode LIKE '%" & e & "%'"
                    dr2 = cmd2.ExecuteReader

                    While dr2.Read

                        View.DataGridView1.Rows.Add(dr2.Item("custcode"), dr2.Item("fname") + " " + dr2.Item("mname") + " " + dr2.Item("lname"), dr2.Item("street_purok") + " " + dr2.Item("barangay") + " " + dr2.Item("city") + " " + dr2.Item("province"), dr2.Item("contact_number"), dr2.Item("creditlimit"), dr2.Item("balance"))
                    End While
                End With

            Catch ex As Exception
                MessageBox.Show(ex.Message + "Error!", "Record not found!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
        dbconn.Close()
        dbconn.Dispose()



        Return Nothing
    End Function

    Public Function loadcustomersingrid()




        View.DataGridView1.Rows.Clear()
        Try

            checkstate()
            dbconn.Open()

            With cmd2
                .Connection = dbconn
                .CommandText = "SELECT * FROM tcc_db.customers "
                dr2 = cmd2.ExecuteReader

                While dr2.Read

                    View.DataGridView1.Rows.Add(dr2.Item("custcode"), dr2.Item("department"), dr2.Item("fname") + " " + dr2.Item("mname") + " " + dr2.Item("lname"), dr2.Item("street_purok") + " " + dr2.Item("barangay") + " " + dr2.Item("city") + " " + dr2.Item("province"), dr2.Item("contact_number"), dr2.Item("creditlimit"), dr2.Item("balance"))
                End While
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message + "Error!", "Record not found!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        dbconn.Close()
        dbconn.Dispose()



        Return Nothing
    End Function

    Public Function loadsrrlist()
        Dim outstocks As Integer = 0
        stockrecievinglist.srrlist.Rows.Clear()
        Try

            checkstate()
            dbconn.Open()

            With cmd
                .Connection = dbconn
                .CommandText = "SELECT * FROM stocks_acquired WHERE srrnum LIKE 'SRR%' ORDER BY srrnum ASC"
                dr = cmd.ExecuteReader

                While dr.Read
                    stockrecievinglist.srrlist.Rows.Add(dr.Item("srrnum"), dr.Item("invoice_type"), dr.Item("invoice_number"), dr.Item("datereceived"), dr.Item("transacdate"), dr.Item("suppname"), dr.Item("suppadd"), "P" & Format(CDbl(dr.Item("amount")), "0,0.00"), dr.Item("prepby"))
                End While
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message + "Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        dbconn.Close()
        dbconn.Dispose()

       
        Return Nothing
    End Function

    Public Function loadrtslist()
        Dim outstocks As Integer = 0
        stockrecievinglist.srrlist.Rows.Clear()
        Try

            checkstate()
            dbconn.Open()

            With cmd
                .Connection = dbconn
                .CommandText = "SELECT * FROM stocks_acquired WHERE srrnum LIKE 'RTS%' ORDER BY srrnum ASC"
                dr = cmd.ExecuteReader

                While dr.Read
                    returnlist.srrlist.Rows.Add(dr.Item("srrnum"), dr.Item("transacdate"), "P" & Format(CDbl(dr.Item("amount")), "0,000.00"), dr.Item("prepby"))
                End While
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message + "Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        dbconn.Close()
        dbconn.Dispose()


        Return Nothing
    End Function

    Public Function loadsrrlistsearch(ByVal e)
        Dim outstocks As Integer = 0
        stockrecievinglist.srrlist.Rows.Clear()
        Try

            checkstate()
            dbconn.Open()

            With cmd
                .Connection = dbconn
                .CommandText = "SELECT * FROM stocks_acquired WHERE srrnum LIKE '%" & e & "%'"
                dr = cmd.ExecuteReader

                While dr.Read
                    stockrecievinglist.srrlist.Rows.Add(dr.Item("srrnum"), dr.Item("invoice_type"), dr.Item("invoice_number"), dr.Item("datereceived"), dr.Item("transacdate"), dr.Item("suppname"), dr.Item("suppadd"), "P" & Format(CDbl(dr.Item("amount")), "0,000.00"), "PRINT")
                End While
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message + "Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        dbconn.Close()
        dbconn.Dispose()


        Return Nothing
    End Function

    Public Function loadcustomer()
        Dim custvalue As New Dictionary(Of String, String)()
        Dim custauto As New AutoCompleteStringCollection
        Dim tandf As Boolean = False

        Try
            invoice.ComboBox5.DataSource = Nothing

            checkstate()
            dbconn.Open()

            With cmd
                .Connection = dbconn
                .CommandText = "SELECT * FROM tcc_db.customers"
                dr = cmd.ExecuteReader

                While dr.Read

                    custvalue.Add(dr.Item("custcode"), dr.Item("lname") + ", " + dr.Item("fname") + " " + dr.Item("mname"))
                    custauto.AddRange(New String() {dr.Item("lname") + ", " + dr.Item("fname") + " " + dr.Item("mname")})

                    tandf = True
                End While
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message + "loadcustomer!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        dbconn.Close()
        dbconn.Dispose()

        If tandf Then
            Try
                invoice.ComboBox5.AutoCompleteSource = AutoCompleteSource.CustomSource
                invoice.ComboBox5.AutoCompleteCustomSource = custauto
                invoice.ComboBox5.DataSource = New BindingSource(custvalue, Nothing)
                invoice.ComboBox5.DisplayMember = "Value"
                invoice.ComboBox5.ValueMember = "Key"
                invoice.ComboBox5.SelectedIndex = -1

                printbyrange.ComboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource
                printbyrange.ComboBox1.AutoCompleteCustomSource = custauto
                printbyrange.ComboBox1.DataSource = New BindingSource(custvalue, Nothing)
                printbyrange.ComboBox1.DisplayMember = "Value"
                printbyrange.ComboBox1.ValueMember = "Key"
                printbyrange.ComboBox1.SelectedIndex = -1

                printbyrange2.ComboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource
                printbyrange2.ComboBox1.AutoCompleteCustomSource = custauto
                printbyrange2.ComboBox1.DataSource = New BindingSource(custvalue, Nothing)
                printbyrange2.ComboBox1.DisplayMember = "Value"
                printbyrange2.ComboBox1.ValueMember = "Key"
                printbyrange2.ComboBox1.SelectedIndex = -1

            Catch ex As Exception
                MessageBox.Show(ex.ToString + " Error in Load loadcustomer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("No Customer Found! Please Add One First!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Return Nothing
    End Function

    Public Function loadproductswithstocks()

        Dim prodcomboSource As New Dictionary(Of String, String)()
        Dim prodautocomplete As New AutoCompleteStringCollection
        Dim tandf As Boolean = False

        Try

            cart2.ComboBox1.DataSource = Nothing

            checkstate()
            dbconn.Open()

            With cmd
                .Connection = dbconn
                .CommandText = "SELECT * FROM products WHERE stock <> 0"
                dr = cmd.ExecuteReader

                While dr.Read

                    prodcomboSource.Add(dr.Item("prodcode"), dr.Item("prodname") + " : " + dr.Item("barcode"))
                    prodautocomplete.AddRange(New String() {dr.Item("prodname") + " : " + dr.Item("barcode")})

                    tandf = True
                End While
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message + "Error1!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        dbconn.Close()
        dbconn.Dispose()

        If tandf Then
            Try

                cart2.ComboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource
                cart2.ComboBox1.AutoCompleteCustomSource = prodautocomplete
                cart2.ComboBox1.DataSource = New BindingSource(prodcomboSource, Nothing)
                cart2.ComboBox1.DisplayMember = "Value"
                cart2.ComboBox1.ValueMember = "Key"
                cart2.ComboBox1.SelectedIndex = -1

            Catch ex As Exception
                MessageBox.Show(ex.ToString + " Error in Products", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("No Products Found! Please Add One First!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Return Nothing
    End Function

    Public Function loadproductsrts()

        Dim prodcomboSource As New Dictionary(Of String, String)()
        Dim prodautocomplete As New AutoCompleteStringCollection
        Dim tandf As Boolean = False

        Try

            returntostock.ComboBox1.DataSource = Nothing

            checkstate()
            dbconn.Open()

            With cmd
                .Connection = dbconn
                .CommandText = "SELECT * FROM products WHERE srp <> 0"
                dr = cmd.ExecuteReader

                While dr.Read

                    prodcomboSource.Add(dr.Item("prodcode"), dr.Item("prodname"))
                    prodautocomplete.AddRange(New String() {dr.Item("prodname")})

                    tandf = True
                End While
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message + "Error1!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        dbconn.Close()
        dbconn.Dispose()

        If tandf Then
            Try

                returntostock.ComboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource
                returntostock.ComboBox1.AutoCompleteCustomSource = prodautocomplete
                returntostock.ComboBox1.DataSource = New BindingSource(prodcomboSource, Nothing)
                returntostock.ComboBox1.DisplayMember = "Value"
                returntostock.ComboBox1.ValueMember = "Key"
                returntostock.ComboBox1.SelectedIndex = -1

            Catch ex As Exception
                MessageBox.Show(ex.ToString + " Error in Products", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("No Products Found! Please Add One First!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Return Nothing
    End Function

    Public Function ViewSRRVale()

        Try
            checkstate()
            dbconn.Open()

            ViewStockCard.DataGridView1.Rows.Clear()

            With cmd
                .Connection = dbconn
                .CommandText = "SELECT ap.daterecieved,ap.srrnum, ap.qty,'' as rpqty, ap.srp, ap.purchasecapital,'' AS amount " &
                               "FROM acquired_products AS ap WHERE ap.prodname = '" & ViewStockCard.ComboBox1.SelectedItem.ToString & "' " &
                               "UNION SELECT r.transacdate, r.transacnum, '', rp.qty AS rpQTY, '','', r.finaltotal " &
                               "FROM resibo AS r " &
                               "INNER JOIN resibo_products AS rp ON r.transacnum = rp.transacnum " &
                               "INNER JOIN products AS p ON p.prodcode = rp.prodcode WHERE p.prodname = '" & ViewStockCard.ComboBox1.SelectedItem.ToString & "'"
                dr = cmd.ExecuteReader

                While dr.Read
                    ViewStockCard.DataGridView1.Rows.Add(dr.Item("daterecieved"), dr.Item("srrnum"), dr.Item("qty"), dr.Item("rpqty"), dr.Item("srp"), dr.Item("purchasecapital"), dr.Item("amount"))
                End While
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message + "Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


        Return Nothing
    End Function
End Module
