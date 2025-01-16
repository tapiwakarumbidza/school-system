Imports MySql.Data.MySqlClient

Public Class UpdateStudentForm
    Dim connectionString As String = "Server=localhost;User=root;Password=;Database=SchoolDB;"
    Dim studentId As Integer

    Public Sub New(ByVal id As Integer)
        InitializeComponent()
        studentId = id
    End Sub

    Private Sub UpdateStudentForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        ' Load student data into form when it loads
        LoadStudentData()
    End Sub
 


    Private Sub LoadStudentData()
        Dim query As String = "SELECT * FROM Students WHERE StudentID = @StudentID"
        Using conn As New MySqlConnection(connectionString),
              cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@StudentID", studentId)
            conn.Open()
            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            If reader.Read() Then
                ' Populate form fields with student data
                TextBox1.Text = reader("Name").ToString()
                TextBox2.Text = reader("Age").ToString()
                TextBox3.Text = reader("Grade").ToString()
                TextBox4.Text = reader("Address").ToString()
                TextBox5.Text = reader("ParentContact").ToString()
            End If
        End Using
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdate.Click
        ' Get updated values from form fields
        Dim name As String = TextBox1.Text.Trim()
        Dim age As Integer = Convert.ToInt32(TextBox2.Text)
        Dim grade As String = TextBox3.Text.Trim()
        Dim address As String = TextBox4.Text.Trim()
        Dim parentContact As String = TextBox5.Text.Trim()

        ' Update student record in the database
        Dim query As String = "UPDATE Students SET Name = @Name, Age = @Age, Grade = @Grade, Address = @Address, ParentContact = @ParentContact WHERE StudentID = @StudentID"
        Using conn As New MySqlConnection(connectionString),
              cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@Name", name)
            cmd.Parameters.AddWithValue("@Age", age)
            cmd.Parameters.AddWithValue("@Grade", grade)
            cmd.Parameters.AddWithValue("@Address", address)
            cmd.Parameters.AddWithValue("@ParentContact", parentContact)
            cmd.Parameters.AddWithValue("@StudentID", studentId)
            conn.Open()
            cmd.ExecuteNonQuery()
            MessageBox.Show("Student record updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Using
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        StudentsForm.Show()
        Me.Hide()
    End Sub
End Class
