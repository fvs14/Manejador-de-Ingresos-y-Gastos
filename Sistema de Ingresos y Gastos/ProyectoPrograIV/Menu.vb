Public Class Menu
    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub IngresosToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim f As New Ingreso

        f.MdiParent = Me

        f.Show()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs)
        Dim f As New Ingreso

        f.MdiParent = Me

        f.Show()
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Dim f As New Gastos

        f.MdiParent = Me

        f.Show()
    End Sub

    Private Sub GastosToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim f As New Gastos

        f.MdiParent = Me

        f.Show()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Dim f As New Ingreso

        f.MdiParent = Me

        f.Show()
    End Sub



    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Application.Exit()
    End Sub

    Private Sub Menu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        Dim f As New SemanaGasto

        f.MdiParent = Me

        f.Show()
    End Sub

    Private Sub VerRegistroDeGatosToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim f As New SemanaGasto

        f.MdiParent = Me

        f.Show()
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Dim f As New Editor_de_cuentas

        f.MdiParent = Me

        f.Show()
    End Sub

    Private Sub ToolStripButton1_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim f As New Estado_Actual

        f.MdiParent = Me

        f.Show()
    End Sub

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles ToolStripButton9.Click
        Dim f As New CrearUsuario

        f.MdiParent = Me

        f.Show()
    End Sub

    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click
        Try


            Dim con As New SqlClient.SqlConnection()
            Dim sql As New SqlClient.SqlCommand()

            Dim ds1 As New Data.DataSet()

            con.ConnectionString = "Data Source=(Local);Initial Catalog=BaseCuentas;Integrated Security=True"
            con.Open()
            sql.Connection = con
            sql.CommandType = CommandType.Text
            sql.CommandText = "Select IDUsuario from Usuario where IDUsuario = @IDUsuario"

            sql.Parameters.Add("@IDUsuario", SqlDbType.NVarChar)
            sql.Parameters(0).Value = IDUsuario.Text
            Dim da1 As New SqlClient.SqlDataAdapter(sql)
            da1.Fill(ds1)


            IDUsuario.Text = ds1.Tables(0).Rows(0)(0).ToString()



            IDUsuario.Enabled = False
            ToolStripButton1.Enabled = True
            ToolStripButton2.Enabled = True
            ToolStripButton3.Enabled = True
            ToolStripButton4.Enabled = True
            ToolStripButton6.Enabled = True
            ToolStripButton8.Enabled = True

            Try

                Dim con2 As New SqlClient.SqlConnection()
                Dim sql2 As New SqlClient.SqlCommand()

                Dim ds2 As New Data.DataSet()


                con2.ConnectionString = "Data Source=(Local);Initial Catalog=BaseCuentas;Integrated Security=True"
                con2.Open()
                sql2.Connection = con
                sql2.CommandType = CommandType.Text
                sql2.CommandText = "Select Count (IDGasto) AS Number from Gasto where IDUsuario =@IDUsuario And Estado='Pendiente'  "


                sql2.Parameters.Add("@IDUsuario", SqlDbType.NVarChar)
                sql2.Parameters(0).Value = IDUsuario.Text

                'sql2.Parameters.Add("@fecha", SqlDbType.Date)
                'sql2.Parameters(1).Value = Convert.ToDateTime(FechaActual.Text)

                Dim da2 As New SqlClient.SqlDataAdapter(sql2)
                da2.Fill(ds2)

                Pendientes.Text = ds2.Tables(0).Rows(0)(0).ToString()

                Dim pendiente As Int64 = Convert.ToInt64(Pendientes.Text)

                Pendientes.Text = "Tiene " + ds2.Tables(0).Rows(0)(0).ToString() + " facturas pendientes"

                MessageBox.Show(IDUsuario.Text + " tienes " + pendiente.ToString + " facturas pendites !!!!")




            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try



        Catch ex As Exception
            MessageBox.Show("Usuario No Existe")

        End Try
    End Sub



End Class