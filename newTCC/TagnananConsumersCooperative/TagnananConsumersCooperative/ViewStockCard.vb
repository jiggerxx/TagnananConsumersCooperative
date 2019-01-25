Public Class ViewStockCard

    'For Combobox Product List
    Dim items As List(Of String) = New List(Of String)

    Private Sub ViewStockCard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim tandf As Boolean = False

        Try

            checkstate()
            dbconn.Open()

            With cmd
                .Connection = dbconn
                .CommandText = "SELECT * FROM tcc_db.products"
                dr = cmd.ExecuteReader

                ComboBox1.Items.Clear()
                items.Clear()

                While dr.Read
                    items.Add(dr.Item("prodname"))
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

                ComboBox1.Items.AddRange(items.ToArray())
                ComboBox1.SelectionStart = ComboBox1.Text.Length

            Catch ex As Exception
                MessageBox.Show(ex.ToString + " Error in Products", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            Try
                'MessageBox.Show("No Products Found! Please Add One First!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ViewSRRVale()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class