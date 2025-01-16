Imports MySql.Data.MySqlClient

Public Class MarkCaptureForm
    Dim connectionString As String = "Server=localhost;User=root;Password=;Database=SchoolDB;"

    Private Sub MarkCaptureForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        ' Load student and teacher data into ComboBoxes
        LoadStudents()
        LoadTeachers()
    End Sub

    Private Sub LoadStudents()
        Dim query As String = "SELECT StudentID, Name FROM Students"
        Using conn As New MySqlConnection(connectionString),
              cmd As New MySqlCommand(query, conn),
              adapter As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()
            adapter.Fill(dt)
            ComboBox1.DataSource = dt
            ComboBox1.DisplayMember = "Name"
            ComboBox1.ValueMember = "StudentID"
        End Using
    End Sub

    Private Sub LoadTeachers()
        Dim query As String = "SELECT TeacherID, Name FROM Teachers"
        Using conn As New MySqlConnection(connectionString),
              cmd As New MySqlCommand(query, conn),
              adapter As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()
            adapter.Fill(dt)
            ComboBox2.DataSource = dt
            ComboBox2.DisplayMember = "Name"
            ComboBox2.ValueMember = "TeacherID"
        End Using
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Dim studentId As Integer = Convert.ToInt32(ComboBox1.SelectedValue)
        Dim teacherId As Integer = Convert.ToInt32(ComboBox2.SelectedValue)
        Dim subject As String = TextBox1.Text.Trim()
        Dim mark As Integer = Convert.ToInt32(TextBox2.Text)
        Dim changeReason As String = TextBox3.Text.Trim()

        If String.IsNullOrWhiteSpace(subject) OrElse String.IsNullOrWhiteSpace(TextBox2.Text) Then
            MessageBox.Show("Please enter all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim query As String = "INSERT INTO Marks (StudentID, TeacherID, Subject, Mark, ChangeReason) VALUES (@StudentID, @TeacherID, @Subject, @Mark, @ChangeReason)"
        Using conn As New MySqlConnection(connectionString),
              cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@StudentID", studentId)
            cmd.Parameters.AddWithValue("@TeacherID", teacherId)
            cmd.Parameters.AddWithValue("@Subject", subject)
            cmd.Parameters.AddWithValue("@Mark", mark)
            cmd.Parameters.AddWithValue("@ChangeReason", changeReason)
            conn.Open()
            cmd.ExecuteNonQuery()
            MessageBox.Show("Mark captured successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Using
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        StudentsForm.Show()
        Me.Hide()
    End Sub
End Class
