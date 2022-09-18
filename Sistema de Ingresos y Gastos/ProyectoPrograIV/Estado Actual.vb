Public Class Estado_Actual
    Private Sub Estado_Actual_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub CargarGastos()
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
            DGEstado.DataSource = ds1
            DGEstado.DataMember = ds1.Tables(0).TableName


            '//////Calcula el total de gasto/////////

            Dim ds2 As New Data.DataSet()
            sql.CommandText = "SELECT SUM (Monto) As Total FROM Gasto WHERE IDUsuario = @IDUsuario"


            Dim da2 As New SqlClient.SqlDataAdapter(sql)
            da1.Fill(ds2)


            TotalGastos.Text = ds2.Tables(0).Rows(0)(0).ToString()




        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub CargarGastosPagados()
        Try

            Dim con As New SqlClient.SqlConnection()
            Dim sql As New SqlClient.SqlCommand()

            Dim ds1 As New Data.DataSet()

            con.ConnectionString = "Data Source=(Local);Initial Catalog=BaseCuentas;Integrated Security=True"
            con.Open()
            sql.Connection = con
            sql.CommandType = CommandType.Text
            sql.CommandText = "Select * from Gasto where IDUsuario =@IDUsuario and Estado = 'Pagado' "

            sql.Parameters.Add("@IDUsuario", SqlDbType.NVarChar)
            sql.Parameters(0).Value = ProyectoPrograIV.Menu.IDUsuario.Text


            Dim da1 As New SqlClient.SqlDataAdapter(sql)
            da1.Fill(ds1)
            DGEstado.DataSource = ds1
            DGEstado.DataMember = ds1.Tables(0).TableName


            '//////Calcula el total de gasto/////////

            Dim ds2 As New Data.DataSet()
            sql.CommandText = "SELECT SUM (Monto) As Total FROM Gasto WHERE IDUsuario = @IDUsuario and Estado = 'Pagado'"


            Dim da2 As New SqlClient.SqlDataAdapter(sql)
            da1.Fill(ds2)


            TotalGastos.Text = ds2.Tables(0).Rows(0)(0).ToString()




        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Private Sub CargarGastosPendientes()
        Try

            Dim con As New SqlClient.SqlConnection()
            Dim sql As New SqlClient.SqlCommand()

            Dim ds1 As New Data.DataSet()

            con.ConnectionString = "Data Source=(Local);Initial Catalog=BaseCuentas;Integrated Security=True"
            con.Open()
            sql.Connection = con
            sql.CommandType = CommandType.Text
            sql.CommandText = "Select * from Gasto where IDUsuario =@IDUsuario and Estado = 'Pendiente' "

            sql.Parameters.Add("@IDUsuario", SqlDbType.NVarChar)
            sql.Parameters(0).Value = ProyectoPrograIV.Menu.IDUsuario.Text


            Dim da1 As New SqlClient.SqlDataAdapter(sql)
            da1.Fill(ds1)
            DGEstado.DataSource = ds1
            DGEstado.DataMember = ds1.Tables(0).TableName


            '//////Calcula el total de gasto/////////

            Dim ds2 As New Data.DataSet()
            sql.CommandText = "SELECT SUM (Monto) As Total FROM Gasto WHERE IDUsuario = @IDUsuario and Estado = 'Pendiente'"


            Dim da2 As New SqlClient.SqlDataAdapter(sql)
            da1.Fill(ds2)


            TotalGastos.Text = ds2.Tables(0).Rows(0)(0).ToString()




        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub





    Private Sub CargarIngresos()
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
            DGEstado.DataSource = ds1
            DGEstado.DataMember = ds1.Tables(0).TableName


            '//////Calcula el total de ingresos/////////

            Dim ds2 As New Data.DataSet()
            sql.CommandText = "SELECT SUM (Monto) As Total FROM Ingresos WHERE IDUsuario = @IDUsuario"


            Dim da2 As New SqlClient.SqlDataAdapter(sql)
            da1.Fill(ds2)


            TotalIngresos.Text = ds2.Tables(0).Rows(0)(0).ToString()




        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub CargarIngresosPendientes()
        Try

            Dim con As New SqlClient.SqlConnection()
            Dim sql As New SqlClient.SqlCommand()

            Dim ds1 As New Data.DataSet()


            con.ConnectionString = "Data Source=(Local);Initial Catalog=BaseCuentas;Integrated Security=True"
            con.Open()
            sql.Connection = con
            sql.CommandType = CommandType.Text
            sql.CommandText = "Select * from Ingresos where IDUsuario =@IDUsuario And Estado='Pendiente'"

            sql.Parameters.Add("@IDUsuario", SqlDbType.NVarChar)
            sql.Parameters(0).Value = ProyectoPrograIV.Menu.IDUsuario.Text

            Dim da1 As New SqlClient.SqlDataAdapter(sql)
            da1.Fill(ds1)
            DGEstado.DataSource = ds1
            DGEstado.DataMember = ds1.Tables(0).TableName


            '//////Calcula el total de ingresos/////////

            Dim ds2 As New Data.DataSet()
            sql.CommandText = "SELECT SUM (Monto) As Total FROM Ingresos WHERE IDUsuario = @IDUsuario And Estado='Pendiente'"


            Dim da2 As New SqlClient.SqlDataAdapter(sql)
            da1.Fill(ds2)


            TotalIngresos.Text = ds2.Tables(0).Rows(0)(0).ToString()




        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub CargarIngresosPagados()
        Try

            Dim con As New SqlClient.SqlConnection()
            Dim sql As New SqlClient.SqlCommand()

            Dim ds1 As New Data.DataSet()


            con.ConnectionString = "Data Source=(Local);Initial Catalog=BaseCuentas;Integrated Security=True"
            con.Open()
            sql.Connection = con
            sql.CommandType = CommandType.Text
            sql.CommandText = "Select * from Ingresos where IDUsuario =@IDUsuario And Estado='Pagado'"

            sql.Parameters.Add("@IDUsuario", SqlDbType.NVarChar)
            sql.Parameters(0).Value = ProyectoPrograIV.Menu.IDUsuario.Text

            Dim da1 As New SqlClient.SqlDataAdapter(sql)
            da1.Fill(ds1)
            DGEstado.DataSource = ds1
            DGEstado.DataMember = ds1.Tables(0).TableName


            '//////Calcula el total de ingresos/////////

            Dim ds2 As New Data.DataSet()
            sql.CommandText = "SELECT SUM (Monto) As Total FROM Ingresos WHERE IDUsuario = @IDUsuario And Estado='Pagado'"


            Dim da2 As New SqlClient.SqlDataAdapter(sql)
            da1.Fill(ds2)


            TotalIngresos.Text = ds2.Tables(0).Rows(0)(0).ToString()




        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub



    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        CargarGastos()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        CargarIngresos()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        CargarIngresosPendientes()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        CargarIngresosPagados()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CargarGastosPendientes()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        CargarGastosPagados()
    End Sub
End Class