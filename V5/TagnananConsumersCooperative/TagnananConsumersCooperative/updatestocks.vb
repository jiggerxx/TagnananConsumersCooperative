Public Class updatestocks
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
                'MessageBox.Show(dept + " has been updated!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                
            End With
        Catch ex As Exception
            MessageBox.Show("Not Added! " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        dbconn.Close()

        Try

            checkstate()
            dbconn.Open()
            With cmd
                .Connection = dbconn
                .CommandText = "UPDATE acquired_products SET stat='1' WHERE prodname = '" & ComboBox1.Text & "' AND srrnum = '" & ComboBox2.Text & "'"
                .ExecuteNonQuery()
                MessageBox.Show(ComboBox1.Text + "[" + ComboBox2.Text + "] has been updated!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)


            End With
        Catch ex As Exception
            MessageBox.Show("Not Added! " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        dbconn.Close()
        dbconn.Dispose()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        loadsrrnumlist()
        ComboBox2.Enabled = True
    End Sub

    Sub loadsrrnumlist()
        Dim prodcomboSource As New Dictionary(Of String, String)()
        Dim prodautocomplete As New AutoCompleteStringCollection
        Dim tandf As Boolean = False

        Try

            ComboBox2.DataSource = Nothing

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
                ComboBox2.AutoCompleteSource = AutoCompleteSource.CustomSource
                ComboBox2.AutoCompleteCustomSource = prodautocomplete
                ComboBox2.DataSource = New BindingSource(prodcomboSource, Nothing)
                ComboBox2.DisplayMember = "Value"
                ComboBox2.ValueMember = "Key"
                ComboBox2.SelectedIndex = -1


            Catch ex As Exception
                MessageBox.Show(ex.ToString + " Error in Updating Stocks", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            'MessageBox.Show("No SRR Found! Please Add One First!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        ComboBox2.SelectedIndex = -1

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

       

            dbconn.Close()
            dbconn.Open()
            Try

                With cmd
                    .Connection = dbconn
                    .CommandText = " SELECT qty,srp FROM acquired_products WHERE srrnum ='" & ComboBox2.Text & "'"
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
End Class