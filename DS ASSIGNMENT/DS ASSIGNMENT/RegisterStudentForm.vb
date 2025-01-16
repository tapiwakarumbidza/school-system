Imports MySql.Data.MySqlClient

Public Class RegisterStudentForm
    Dim connectionString As String = "Server=localhost;User=root;Password=;Database=SchoolDB;"

    Private Sub btnRegister_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        ' Retrieve student details from textboxes
        Dim name As String = TextBox1.Text.Trim()
        Dim age As Integer = Integer.Parse(TextBox4.Text.Trim()) ' Assuming TextBox4 is for age
        Dim grade As String = TextBox5.Text.Trim() ' Assuming TextBox5 is for grade
        Dim address As String = TextBox2.Text.Trim()
        Dim parentContact As String = TextBox3.Text.Trim()

        ' Validate input
        If String.IsNullOrWhiteSpace(name) OrElse String.IsNullOrWhiteSpace(address) OrElse String.IsNullOrWhiteSpace(parentContact) OrElse String.IsNullOrWhiteSpace(grade) Then
            MessageBox.Show("Please enter all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Insert student record into the database
        Dim query As String = "INSERT INTO Students (Name, Age, Grade, Address, ParentContact) VALUES (@Name, @Age, @Grade, @Address, @ParentContact)"
        Using conn As New MySqlConnection(connectionString),
              cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@Name", name)
            cmd.Parameters.AddWithValue("@Age", age)
            cmd.Parameters.AddWithValue("@Grade", grade)
            cmd.Parameters.AddWithValue("@Address", address)
            cmd.Parameters.AddWithValue("@ParentContact", parentContact)
            Try
                conn.Open()
                cmd.ExecuteNonQuery()
                MessageBox.Show("Student registered successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ' Clear textboxes after registration
                TextBox1.Clear()
                TextBox4.Clear()
                TextBox5.Clear()
                TextBox2.Clear()
                TextBox3.Clear()
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

   

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        StudentsForm.Show()
        Me.Hide()
    End Sub

    Private Sub RegisterStudentForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
