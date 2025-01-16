Imports MySql.Data.MySqlClient

Public Class AddTeacherForm
    Dim connectionString As String = "Server=localhost;User=root;Password=;Database=SchoolDB;"

    Private Sub btnAddTeacher_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        ' Retrieve teacher details from textboxes
        Dim name As String = TextBox1.Text.Trim()
        Dim subject As String = TextBox2.Text.Trim()

        ' Validate input
        If String.IsNullOrWhiteSpace(name) OrElse String.IsNullOrWhiteSpace(subject) Then
            MessageBox.Show("Please enter all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Insert teacher record into the database
        Dim query As String = "INSERT INTO Teachers (Name, Subject) VALUES (@Name, @Subject)"
        Using conn As New MySqlConnection(connectionString),
              cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@Name", name)
            cmd.Parameters.AddWithValue("@Subject", subject)
            Try
                conn.Open()
                cmd.ExecuteNonQuery()
                MessageBox.Show("Teacher added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ' Clear textboxes after addition
                TextBox1.Clear()
                TextBox2.Clear()
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        StudentsForm.Show()
        Me.Hide()
    End Sub
End Class
