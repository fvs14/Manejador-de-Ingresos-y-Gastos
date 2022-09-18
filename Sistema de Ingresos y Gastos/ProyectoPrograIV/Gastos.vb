Public Class Gastos
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try


            Dim con As New SqlClient.SqlConnection()
            Dim sql As New SqlClient.SqlCommand()
            Dim res As New DialogResult()

            con.ConnectionString = "Data Source=(Local);Initial Catalog=BaseCuentas;Integrated Security=True"
            con.Open()
            sql.Connection = con
            sql.CommandType = CommandType.Text
            sql.CommandText = "Insert into [Gasto] Values (@FechaFactura,@FechaVencimiento,@Tipo,@Estado,@Monto,@Detalle,@IDUsuario)"

            sql.Parameters.Add("@FechaFactura", SqlDbType.Date)
            sql.Parameters(0).Value = Convert.ToDateTime(FechaFacturaG.Text)
            sql.Parameters.Add("@FechaVencimiento", SqlDbType.Date)
            sql.Parameters(1).Value = Convert.ToDateTime(FechaVencimientoG.Text)
            sql.Parameters.Add("@Tipo", SqlDbType.NVarChar)
            sql.Parameters(2).Value = TipoG.Text
            sql.Parameters.Add("@Estado", SqlDbType.NVarChar)
            sql.Parameters(3).Value = EstadoG.Text
            sql.Parameters.Add("@Monto", SqlDbType.NVarChar)
            sql.Parameters(4).Value = Convert.ToDecimal(MontoG.Text)
            sql.Parameters.Add("@Detalle", SqlDbType.NVarChar)
            sql.Parameters(5).Value = DetalleG.Text
            sql.Parameters.Add("@IDUsuario", SqlDbType.NVarChar)
            sql.Parameters(6).Value = ProyectoPrograIV.Menu.IDUsuario.Text



            res = MessageBox.Show("Desea Ingresar este Gasto", "Agregar Reg", MessageBoxButtons.YesNo)
            If res = DialogResult.Yes Then
                sql.ExecuteNonQuery()
                MessageBox.Show("Gasto Guardado")


            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Application.Exit()
    End Sub
End Class