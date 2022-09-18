Public Class SemanaGasto
    Private Sub SemanaGasto_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            Dim con As New SqlClient.SqlConnection()
            Dim sql As New SqlClient.SqlCommand()

            Dim ds1 As New Data.DataSet()


            con.ConnectionString = "Data Source=(Local);Initial Catalog=BaseCuentas;Integrated Security=True"
            con.Open()
            sql.Connection = con
            sql.CommandType = CommandType.Text
            sql.CommandText = "Select * from Ingresos where IDUsuario =@IDUsuario AND FechaFactura BETWEEN @Fecha1 AND @Fecha2 "

            sql.Parameters.Add("@IDUsuario", SqlDbType.NVarChar)
            sql.Parameters(0).Value = ProyectoPrograIV.Menu.IDUsuario.Text
            sql.Parameters.Add("@Fecha1", SqlDbType.Date)
            sql.Parameters(1).Value = Fecha1.Text
            sql.Parameters.Add("@Fecha2", SqlDbType.Date)
            sql.Parameters(2).Value = Fecha2.Text

            Dim da1 As New SqlClient.SqlDataAdapter(sql)
            da1.Fill(ds1)
            DataGridView1.DataSource = ds1
            DataGridView1.DataMember = ds1.Tables(0).TableName


            '//////Calcula el total de ingresos/////////

            Dim ds2 As New Data.DataSet()
            sql.CommandText = "SELECT SUM (Monto) As Total FROM Ingresos WHERE IDUsuario = @IDUsuario AND FechaFactura BETWEEN @Fecha1 AND @Fecha2  "


            Dim da2 As New SqlClient.SqlDataAdapter(sql)
            da1.Fill(ds2)


            Ingreso.Text = ds2.Tables(0).Rows(0)(0).ToString()

            Dim resta As Int64 = Convert.ToInt64(Ingreso.Text) - Convert.ToInt64(Gasto.Text)
            If resta < 0 Then
                deuda.Text = resta
                sobrante.Text = 0
            Else
                sobrante.Text = resta
                deuda.Text = 0
            End If



        Catch ex As Exception
            deuda.Text = 0
            sobrante.Text = 0
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try

            Dim con As New SqlClient.SqlConnection()
            Dim sql As New SqlClient.SqlCommand()

            Dim ds1 As New Data.DataSet()


            con.ConnectionString = "Data Source=(Local);Initial Catalog=BaseCuentas;Integrated Security=True"
            con.Open()
            sql.Connection = con
            sql.CommandType = CommandType.Text
            sql.CommandText = "Select * from Gasto where IDUsuario =@IDUsuario AND FechaFactura BETWEEN @Fecha1 AND @Fecha2 "

            sql.Parameters.Add("@IDUsuario", SqlDbType.NVarChar)
            sql.Parameters(0).Value = ProyectoPrograIV.Menu.IDUsuario.Text
            sql.Parameters.Add("@Fecha1", SqlDbType.Date)
            sql.Parameters(1).Value = Fecha1.Text
            sql.Parameters.Add("@Fecha2", SqlDbType.Date)
            sql.Parameters(2).Value = Fecha2.Text

            Dim da1 As New SqlClient.SqlDataAdapter(sql)
            da1.Fill(ds1)
            DataGridView1.DataSource = ds1
            DataGridView1.DataMember = ds1.Tables(0).TableName


            '//////Calcula el total de ingresos/////////

            Dim ds2 As New Data.DataSet()
            sql.CommandText = "SELECT SUM (Monto) As Total FROM Gasto WHERE IDUsuario = @IDUsuario AND FechaFactura BETWEEN @Fecha1 AND @Fecha2  "


            Dim da2 As New SqlClient.SqlDataAdapter(sql)
            da1.Fill(ds2)


            Gasto.Text = ds2.Tables(0).Rows(0)(0).ToString()

            Dim resta As Int64 = Convert.ToInt64(Ingreso.Text) - Convert.ToInt64(Gasto.Text)
            If resta < 0 Then
                deuda.Text = resta
                sobrante.Text = 0
            Else
                sobrante.Text = resta
                deuda.Text = 0
            End If



        Catch ex As Exception

            sobrante.Text = 0
            deuda.Text = 0
        End Try
    End Sub
End Class