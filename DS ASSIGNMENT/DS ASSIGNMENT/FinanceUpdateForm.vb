Imports MySql.Data.MySqlClient

Public Class FinanceUpdateForm
    Dim connectionString As String = "Server=localhost;User=root;Password=;Database=SchoolDB;"
    Dim studentId As Integer

    Public Sub New(ByVal id As Integer)
        InitializeComponent()
        studentId = id
    End Sub

    Private Sub FinanceUpdateForm_Load(ByVal sender As Object, ByVal e As EventArgs)
        LoadFinanceData()
    End Sub

    Private Sub LoadFinanceData()
        Dim query As String = "SELECT * FROM Finance WHERE StudentID = @StudentID"
        Using conn As New MySqlConnection(connectionString),
              cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@StudentID", studentId)
            conn.Open()
            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            If reader.Read() Then
                txtTuitionFee.Text = reader("TuitionFee").ToString()
                txtOtherFees.Text = reader("OtherFees").ToString()
                txtBalance.Text = reader("Balance").ToString()
            Else
                ' Initialize with default values if no record exists
                txtTuitionFee.Text = "0.00"
                txtOtherFees.Text = "0.00"
                txtBalance.Text = "0.00"
            End If
        End Using
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Dim tuitionFee As Decimal = Convert.ToDecimal(txtTuitionFee.Text)
        Dim otherFees As Decimal = Convert.ToDecimal(txtOtherFees.Text)
        Dim balance As Decimal = Convert.ToDecimal(txtBalance.Text)

        Dim query As String
        If FinanceRecordExists() Then
            query = "UPDATE Finance SET TuitionFee = @TuitionFee, OtherFees = @OtherFees, Balance = @Balance WHERE StudentID = @StudentID"
        Else
            query = "INSERT INTO Finance (StudentID, TuitionFee, OtherFees, Balance) VALUES (@StudentID, @TuitionFee, @OtherFees, @Balance)"
        End If

        Using conn As New MySqlConnection(connectionString),
              cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@StudentID", studentId)
            cmd.Parameters.AddWithValue("@TuitionFee", tuitionFee)
            cmd.Parameters.AddWithValue("@OtherFees", otherFees)
            cmd.Parameters.AddWithValue("@Balance", balance)
            conn.Open()
            cmd.ExecuteNonQuery()
            MessageBox.Show("Finance details updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Using
    End Sub

    Private Function FinanceRecordExists() As Boolean
        Dim query As String = "SELECT COUNT(*) FROM Finance WHERE StudentID = @StudentID"
        Using conn As New MySqlConnection(connectionString),
              cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@StudentID", studentId)
            conn.Open()
            Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            Return count > 0
        End Using
    End Function



    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        StudentsForm.Show()
        Me.Hide()
    End Sub
End Class
