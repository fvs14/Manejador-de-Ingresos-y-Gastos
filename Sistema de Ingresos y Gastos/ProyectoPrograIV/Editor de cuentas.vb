Public Class Editor_de_cuentas
    Private Sub Editor_de_cuentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles Monto.TextChanged

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles IdIngreso.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim con As New SqlClient.SqlConnection()
            Dim sql As New SqlClient.SqlCommand()
            Dim ds As New Data.DataSet()
            con.ConnectionString = "Data Source=(local);Initial Catalog=BaseCuentas;Integrated Security=True"
            con.Open()
            sql.Connection = con
            sql.CommandType = CommandType.Text
            sql.CommandText = "Select * from [Ingresos] where IDIngresos = @IdIngreso  and IDUsuario=@IDUsuario"
            sql.Parameters.Add("@IdIngreso", SqlDbType.Int)
            sql.Parameters(0).Value = IdIngreso.Text
            sql.Parameters.Add("@IDUsuario", SqlDbType.NVarChar)
            sql.Parameters(1).Value = ProyectoPrograIV.Menu.IDUsuario.Text
            Dim da As New SqlClient.SqlDataAdapter(sql)
            da.Fill(ds)
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = ds.Tables(0).TableName

            If ds.Tables(0).Rows.Count <= 0 Then
                MessageBox.Show("No hay registro para ese Id", "Buscar Tabla Order")


            Else

                DateTimePicker1.Text = ds.Tables(0).Rows(0)(1).ToString()
                DateTimePicker2.Text = ds.Tables(0).Rows(0)(2).ToString()
                Tipo.Text = ds.Tables(0).Rows(0)(3).ToString()
                Estado.Text = ds.Tables(0).Rows(0)(4).ToString()
                Monto.Text = ds.Tables(0).Rows(0)(5).ToString()
                detalle.Text = ds.Tables(0).Rows(0)(6).ToString()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ActualizarDataGridViewsIng()

    End Sub

    Private Sub ActualizarDataGridViewsIng()
        Try

            Dim con As New SqlClient.SqlConnection()
            Dim sql As New SqlClient.SqlCommand()

            Dim ds1 As New Data.DataSet()


            con.ConnectionString = "Data Source=(Local);Initial Catalog=BaseCuentas;Integrated Security=True"
            con.Open()
            sql.Connection = con
            sql.CommandType = CommandType.Text
            sql.CommandText = "Select * from Ingresos where IDUsuario =@IDUsuario "

            sql.Parameters.Add("@IDUsuario", SqlDbType.NVarChar)
            sql.Parameters(0).Value = ProyectoPrograIV.Menu.IDUsuario.Text



            Dim da1 As New SqlClient.SqlDataAdapter(sql)
            da1.Fill(ds1)
            DataGridView1.DataSource = ds1
            DataGridView1.DataMember = ds1.Tables(0).TableName


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ActualizarDataGridViewsGas()
        Try

            Dim con As New SqlClient.SqlConnection()
            Dim sql As New SqlClient.SqlCommand()

            Dim ds1 As New Data.DataSet()


            con.ConnectionString = "Data Source=(Local);Initial Catalog=BaseCuentas;Integrated Security=True"
            con.Open()
            sql.Connection = con
            sql.CommandType = CommandType.Text
            sql.CommandText = "Select * from Gasto where IDUsuario =@IDUsuario "

            sql.Parameters.Add("@IDUsuario", SqlDbType.NVarChar)
            sql.Parameters(0).Value = ProyectoPrograIV.Menu.IDUsuario.Text



            Dim da1 As New SqlClient.SqlDataAdapter(sql)
            da1.Fill(ds1)
            DataGridView1.DataSource = ds1
            DataGridView1.DataMember = ds1.Tables(0).TableName


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub



    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim con As New SqlClient.SqlConnection()
            Dim sql As New SqlClient.SqlCommand()
            Dim res As New DialogResult()

            con.ConnectionString = "Data Source=(local);Initial Catalog=BaseCuentas;Integrated Security=True"
            con.Open()
            sql.Connection = con
            sql.CommandType = CommandType.Text
            sql.CommandText = "Delete from [Ingresos] where IDIngresos = @id"
            sql.Parameters.Add("@id", SqlDbType.Int)
            sql.Parameters(0).Value = IdIngreso.Text
            res = MessageBox.Show("Desea Borrar REgistro", "Borrar Reg", MessageBoxButtons.YesNo)
            If res = DialogResult.Yes Then
                sql.ExecuteNonQuery()

                ActualizarDataGridViewsIng()


            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim con As New SqlClient.SqlConnection()
            Dim sql As New SqlClient.SqlCommand()
            Dim res As New DialogResult()

            con.ConnectionString = "Data Source=(local);Initial Catalog=BaseCuentas;Integrated Security=True"
            con.Open()
            sql.Connection = con
            sql.CommandType = CommandType.Text
            sql.CommandText = "Update [Ingresos] set FechaFactura=@Fecha, FechadeVencimiento=@FechaVencimiento, Tipo=@Tipo, Estado=@Estado,Monto=@Monto,Detalle=@Detalle where IDIngresos = @IDIngresos and IDUsuario=@IdUsuario"



            sql.Parameters.Add("@Fecha", SqlDbType.Date)
            sql.Parameters(0).Value = Convert.ToDateTime(DateTimePicker1.Text)
            sql.Parameters.Add("@FechaVencimiento", SqlDbType.Date)
            sql.Parameters(1).Value = Convert.ToDateTime(DateTimePicker2.Text)
            sql.Parameters.Add("@Tipo", SqlDbType.NVarChar)
            sql.Parameters(2).Value = Tipo.Text
            sql.Parameters.Add("@Estado", SqlDbType.NVarChar)
            sql.Parameters(3).Value = Estado.Text
            sql.Parameters.Add("@Monto", SqlDbType.Float)
            sql.Parameters(4).Value = Convert.ToDecimal(Monto.Text)
            sql.Parameters.Add("@Detalle", SqlDbType.NVarChar)
            sql.Parameters(5).Value = detalle.Text
            sql.Parameters.Add("@IDIngresos", SqlDbType.Int)
            sql.Parameters(6).Value = Convert.ToInt32(IdIngreso.Text)
            sql.Parameters.Add("@IDUsuario", SqlDbType.NVarChar)
            sql.Parameters(7).Value = ProyectoPrograIV.Menu.IDUsuario.Text






            res = MessageBox.Show("Desea Modificar Registro", "Modificar Reg", MessageBoxButtons.YesNo)
            If res = DialogResult.Yes Then
                sql.ExecuteNonQuery()

                ActualizarDataGridViewsIng()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ActualizarDataGridViewsGas()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Try
            Dim con As New SqlClient.SqlConnection()
            Dim sql As New SqlClient.SqlCommand()
            Dim ds As New Data.DataSet()
            con.ConnectionString = "Data Source=(local);Initial Catalog=BaseCuentas;Integrated Security=True"
            con.Open()
            sql.Connection = con
            sql.CommandType = CommandType.Text
            sql.CommandText = "Select * from [Gasto] where IDGasto = @IdGasto  and IDUsuario=@IDUsuario"
            sql.Parameters.Add("@IdGasto", SqlDbType.Int)
            sql.Parameters(0).Value = IdGasto.Text
            sql.Parameters.Add("@IDUsuario", SqlDbType.NVarChar)
            sql.Parameters(1).Value = ProyectoPrograIV.Menu.IDUsuario.Text
            Dim da As New SqlClient.SqlDataAdapter(sql)
            da.Fill(ds)
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = ds.Tables(0).TableName

            If ds.Tables(0).Rows.Count <= 0 Then
                MessageBox.Show("No hay registro para ese Id", "Buscar Tabla Order")


            Else

                DateTimePicker1.Text = ds.Tables(0).Rows(0)(1).ToString()
                DateTimePicker2.Text = ds.Tables(0).Rows(0)(2).ToString()
                Tipo.Text = ds.Tables(0).Rows(0)(3).ToString()
                Estado.Text = ds.Tables(0).Rows(0)(4).ToString()
                Monto.Text = ds.Tables(0).Rows(0)(5).ToString()
                detalle.Text = ds.Tables(0).Rows(0)(6).ToString()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try
            Dim con As New SqlClient.SqlConnection()
            Dim sql As New SqlClient.SqlCommand()
            Dim res As New DialogResult()

            con.ConnectionString = "Data Source=(local);Initial Catalog=BaseCuentas;Integrated Security=True"
            con.Open()
            sql.Connection = con
            sql.CommandType = CommandType.Text
            sql.CommandText = "Delete from [Gasto] where IDGasto = @id"
            sql.Parameters.Add("@id", SqlDbType.Int)
            sql.Parameters(0).Value = IdGasto.Text
            res = MessageBox.Show("Desea Borrar REgistro", "Borrar Reg", MessageBoxButtons.YesNo)
            If res = DialogResult.Yes Then
                sql.ExecuteNonQuery()

                ActualizarDataGridViewsGas()


            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Try
            Dim con As New SqlClient.SqlConnection()
            Dim sql As New SqlClient.SqlCommand()
            Dim res As New DialogResult()

            con.ConnectionString = "Data Source=(local);Initial Catalog=BaseCuentas;Integrated Security=True"
            con.Open()
            sql.Connection = con
            sql.CommandType = CommandType.Text
            sql.CommandText = "Update [Gasto] set FechaFactura=@Fecha, FechadeVencimiento=@FechaVencimiento, Tipo=@Tipo, Estado=@Estado,Monto=@Monto,Detalle=@Detalle where IDGasto = @IDGasto and IDUsuario=@IdUsuario"



            sql.Parameters.Add("@Fecha", SqlDbType.Date)
            sql.Parameters(0).Value = Convert.ToDateTime(DateTimePicker1.Text)
            sql.Parameters.Add("@FechaVencimiento", SqlDbType.Date)
            sql.Parameters(1).Value = Convert.ToDateTime(DateTimePicker2.Text)
            sql.Parameters.Add("@Tipo", SqlDbType.NVarChar)
            sql.Parameters(2).Value = Tipo.Text
            sql.Parameters.Add("@Estado", SqlDbType.NVarChar)
            sql.Parameters(3).Value = Estado.Text
            sql.Parameters.Add("@Monto", SqlDbType.Float)
            sql.Parameters(4).Value = Convert.ToDecimal(Monto.Text)
            sql.Parameters.Add("@Detalle", SqlDbType.NVarChar)
            sql.Parameters(5).Value = detalle.Text
            sql.Parameters.Add("@IDGasto", SqlDbType.Int)
            sql.Parameters(6).Value = Convert.ToInt32(IdGasto.Text)
            sql.Parameters.Add("@IDUsuario", SqlDbType.NVarChar)
            sql.Parameters(7).Value = ProyectoPrograIV.Menu.IDUsuario.Text






            res = MessageBox.Show("Desea Modificar Registro", "Modificar Reg", MessageBoxButtons.YesNo)
            If res = DialogResult.Yes Then
                sql.ExecuteNonQuery()

                ActualizarDataGridViewsGas()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub
End Class