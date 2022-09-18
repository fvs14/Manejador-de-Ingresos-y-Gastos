Public Class CrearUsuario
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try


            Dim con As New SqlClient.SqlConnection()
            Dim sql As New SqlClient.SqlCommand()
            Dim res As New DialogResult()

            con.ConnectionString = "Data Source=(Local);Initial Catalog=BaseCuentas;Integrated Security=True"
            con.Open()
            sql.Connection = con
            sql.CommandType = CommandType.Text
            sql.CommandText = "Insert into [Usuario] Values (@IDUsuario,@Nombre)"

            sql.Parameters.Add("@Nombre", SqlDbType.NVarChar)
            sql.Parameters(0).Value = txtNombre.Text
            sql.Parameters.Add("@IDUsuario", SqlDbType.NVarChar)
            sql.Parameters(1).Value = txtUsuario.Text

            res = MessageBox.Show("Desea Ingresar este Usuario", "Agregar Reg", MessageBoxButtons.YesNo)
            If res = DialogResult.Yes Then
                sql.ExecuteNonQuery()
                MessageBox.Show("Usuario Guardado")


            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class