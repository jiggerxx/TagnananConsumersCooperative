Public Class updatestocksinfo
    Dim stocks As Double = 0
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        loadproductswithstocks()
        usermanagement.Enabled = True
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dept As String = ComboBox1.Text

        Try

            checkstate()
            dbconn.Open()
            With cmd
                .Connection = dbconn
                .CommandText = "UPDATE products SET stock=" & (stocks + CDbl(TextBox1.Text)) & ",srp='" & TextBox2.Text & "' WHERE prodname = '" & ComboBox1.Text & "'"
                .ExecuteNonQuery()
                MessageBox.Show(dept + " has been updated!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End With
        Catch ex As Exception
            MessageBox.Show("Not Added! " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        dbconn.Close()

        'Try

        '    checkstate()
        '    dbconn.Open()
        '    With cmd
        '        .Connection = dbconn
        '        .CommandText = "UPDATE products SET stat='1' WHERE prodname = '" & ComboBox1.Text & "' AND srrnum = '" & ComboBox2.Text & "'"
        '        .ExecuteNonQuery()
        '        'MessageBox.Show(ComboBox1.Text + "[" + ComboBox2.Text + "] has been updated!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)


        '    End With
        'Catch ex As Exception
        '    MessageBox.Show("Not Added! " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)

        'End Try
        dbconn.Close()
        dbconn.Dispose()

        ComboBox1.SelectedIndex = -1
        TextBox1.Clear()
        TextBox2.Clear()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        dbconn.Close()
        dbconn.Open()
        Try

            With cmd
                .Connection = dbconn
                .CommandText = " SELECT stock,srp FROM products WHERE prodname ='" & ComboBox1.Text & "'"
                dr = cmd.ExecuteReader

                While dr.Read
                    TextBox1.Text = dr.Item("stock")
                    TextBox2.Text = dr.Item("srp")

                End While

            End With

            dbconn.Close()
            dbconn.Dispose()

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try


        dbconn.Close()
        dbconn.Open()


        'loadsrrnumlist()
        'ComboBox2.Enabled = True
    End Sub

    Sub loadsrrnumlist()
        Dim prodcomboSource As New Dictionary(Of String, String)()
        Dim prodautocomplete As New AutoCompleteStringCollection
        Dim tandf As Boolean = False

        Try

            ComboBox1.DataSource = Nothing

            checkstate()
            dbconn.Open()

            With cmd
                .Connection = dbconn
                .CommandText = "SELECT srrnum FROM acquired_products WHERE prodname ='" & ComboBox1.Text & "' AND stat = '0'"
                dr = cmd.ExecuteReader

                While dr.Read

                    prodcomboSource.Add(dr.Item("srrnum"), dr.Item("srrnum"))
                    prodautocomplete.AddRange(New String() {dr.Item("srrnum")})

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
                ComboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource
                ComboBox1.AutoCompleteCustomSource = prodautocomplete
                ComboBox1.DataSource = New BindingSource(prodcomboSource, Nothing)
                ComboBox1.DisplayMember = "Value"
                ComboBox1.ValueMember = "Key"
                ComboBox1.SelectedIndex = -1


            Catch ex As Exception
                MessageBox.Show(ex.ToString + " Error in Updating Stocks", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            'MessageBox.Show("No SRR Found! Please Add One First!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        ComboBox1.SelectedIndex = -1

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs)



        dbconn.Close()
        dbconn.Open()
        Try

            With cmd
                .Connection = dbconn
                .CommandText = " SELECT qty,srp FROM products WHERE srrnum ='" & ComboBox1.Text & "'"
                dr = cmd.ExecuteReader

                While dr.Read
                    TextBox1.Text = dr.Item("qty")
                    TextBox2.Text = dr.Item("srp")

                End While

            End With

            dbconn.Close()
            dbconn.Dispose()

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try


        dbconn.Close()
        dbconn.Open()
        Try

            With cmd
                .Connection = dbconn
                .CommandText = " SELECT * FROM products WHERE prodname ='" & ComboBox1.Text & "'"
                dr = cmd.ExecuteReader

                While dr.Read
                    stocks = CDbl(dr.Item("stock"))
                End While

            End With

            dbconn.Close()
            dbconn.Dispose()

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub updatestocksinfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadproductsx()
    End Sub
End Class