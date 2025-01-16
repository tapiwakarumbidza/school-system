Imports MySql.Data.MySqlClient

Public Class AdminForm
    ' Database connection
    Dim conn As MySqlConnection = New MySqlConnection("Server=localhost;User=root;Password=;Database=SchoolDB;")

    Private Sub btnRegister_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRegister.Click
        ' Get user input
        Dim username As String = TextBox1.Text.Trim()
        Dim password As String = TextBox2.Text
        Dim role As String = ComboBox1.SelectedItem.ToString()

        ' Validate user input
        If String.IsNullOrEmpty(username) OrElse String.IsNullOrEmpty(password) OrElse String.IsNullOrEmpty(role) Then
            MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Open database connection
        Try
            conn.Open()

            ' Insert user record into database
            Dim query As String = "INSERT INTO Users (Username, Password, Role) VALUES (@Username, @Password, @Role)"
            Using cmd As MySqlCommand = New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Username", username)
                cmd.Parameters.AddWithValue("@Password", password)
                cmd.Parameters.AddWithValue("@Role", role)
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("User registered successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error registering user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            ' Close database connection
            conn.Close()
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        LoginForm.Show()
        Me.Hide()
    End Sub
End Class
