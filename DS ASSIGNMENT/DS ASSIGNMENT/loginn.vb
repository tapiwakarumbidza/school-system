Imports MySql.Data.MySqlClient

Public Class LoginnForm
    ' Database connection
    Dim conn As MySqlConnection = New MySqlConnection("Server=localhost;User=root;Password=;Database=SchoolDB;")

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Dim username As String = TextBox1.Text.Trim()
        Dim password As String = TextBox2.Text

        ' Validate user input
        If String.IsNullOrEmpty(username) OrElse String.IsNullOrEmpty(password) Then
            Label1.Text = "Please enter username and password."
            Return
        End If

        ' Check if user exists in the database
        Dim query As String = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password"
        Dim count As Integer

        Try
            conn.Open()
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Username", username)
                cmd.Parameters.AddWithValue("@Password", password)
                count = Convert.ToInt32(cmd.ExecuteScalar())
            End Using

            If count > 0 Then
                ' Login successful, open the form for registering a new student
                Dim registerForm As New RegisterStudentForm()
                registerForm.Show()
                Me.Hide()
            Else
                ' Login failed, display error message
                Label1.Text = "Invalid username or password."
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub
End Class
