
Imports MySql.Data.MySqlClient

Public Class StudentsForm
    Private connectionString As String = "Server=localhost;User=root;Password=;Database=SchoolDB;"

    Public Sub New()
        InitializeComponent()
        ' Load student data into DataGridView when the form loads
        LoadStudentData()
    End Sub

    Private Sub LoadStudentData()
        Dim query As String = "SELECT * FROM Students"
        Using conn As New MySqlConnection(connectionString),
              cmd As New MySqlCommand(query, conn),
              adapter As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()
            adapter.Fill(dt)
            DataGridView1.DataSource = dt
        End Using
    End Sub

    Private Sub UpdateRecord(ByVal rowIndex As Integer)
        If rowIndex >= 0 AndAlso rowIndex < DataGridView1.Rows.Count Then
            Dim studentId As Integer = Convert.ToInt32(DataGridView1.Rows(rowIndex).Cells("StudentID").Value)
            Dim updateForm As New UpdateStudentForm(studentId)
            updateForm.ShowDialog()
            ' Refresh DataGridView after update form is closed
            LoadStudentData()
        End If
    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        UpdateRecord(e.RowIndex)
    End Sub


    Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        Search()
    End Sub

    Private Sub DeleteRecords()
        If DataGridView1.SelectedRows.Count > 0 Then
            If MessageBox.Show("Are you sure you want to delete selected student(s)?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                For Each row As DataGridViewRow In DataGridView1.SelectedRows
                    Dim studentId As Integer = Convert.ToInt32(row.Cells("StudentID").Value)
                    DeleteStudent(studentId)
                Next
                ' Refresh DataGridView after deletion
                LoadStudentData()
            End If
        Else
            MessageBox.Show("Please select at least one student to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    


    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDelete.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim studentId As Integer = Convert.ToInt32(DataGridView1.SelectedRows(0).Cells("StudentID").Value)
            DeleteRecords(studentId)
            LoadStudentData()
        End If
    End Sub

        Private Sub DeleteRecords(ByVal studentId As Integer)
            ' Delete related marks records
            DeleteRelatedMarks(studentId)
            ' Delete student record
            DeleteStudent(studentId)
        End Sub

        Private Sub DeleteRelatedMarks(ByVal studentId As Integer)
            Dim query As String = "DELETE FROM Marks WHERE StudentID = @StudentID"
            Using conn As New MySqlConnection(connectionString),
                  cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@StudentID", studentId)
                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Sub

        Private Sub DeleteStudent(ByVal studentId As Integer)
            Dim query As String = "DELETE FROM Students WHERE StudentID = @StudentID"
            Using conn As New MySqlConnection(connectionString),
                  cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@StudentID", studentId)
                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Sub





    Private Sub Search()
        Dim searchTerm As String = txtSearch.Text.Trim()
        If Not String.IsNullOrWhiteSpace(searchTerm) Then
            Dim query As String = "SELECT * FROM Students WHERE Name LIKE @SearchTerm OR Grade LIKE @SearchTerm"
            Using conn As New MySqlConnection(connectionString),
                  cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@SearchTerm", "%" & searchTerm & "%")
                Dim adapter As New MySqlDataAdapter(cmd)
                Dim dt As New DataTable()
                adapter.Fill(dt)
                DataGridView1.DataSource = dt
            End Using
        Else
            LoadStudentData() ' Reload all students if search term is empty
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        AddTeacherForm.Show()
        Me.Hide()
    End Sub

    Private Sub btnUpdateFinance_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdateFinance.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim studentId As Integer = Convert.ToInt32(DataGridView1.SelectedRows(0).Cells("StudentID").Value)
            Dim financeForm As New FinanceUpdateForm(studentId)
            financeForm.ShowDialog()
        End If
    End Sub


    Private Sub btnCaptureMarks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCaptureMarks.Click
        Dim markForm As New MarkCaptureForm()
        markForm.ShowDialog()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        RegisterStudentForm.Show()
        Me.Hide()
    End Sub
End Class
