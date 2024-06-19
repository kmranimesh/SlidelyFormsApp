Imports System.Net
Imports Newtonsoft.Json.Linq

Public Class ViewSubmissionsForm
    Private WithEvents txtName As TextBox
    Private WithEvents txtEmail As TextBox
    Private WithEvents txtPhoneNum As TextBox
    Private WithEvents txtGithubLink As TextBox
    Private currentIndex As Integer = 0
    Private submissions As JArray

    Private Sub ViewSubmissionsForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.P Then
            btnPrevious.PerformClick()
        ElseIf e.Control AndAlso e.KeyCode = Keys.N Then
            btnNext.PerformClick()
        End If
    End Sub

    Private Sub ViewSubmissionsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Using client As New WebClient()
            Dim json As String = client.DownloadString("http://localhost:3000/read")
            submissions = JArray.Parse(json)
            UpdateForm()
        End Using
    End Sub

    Private Sub UpdateForm()
        If submissions IsNot Nothing AndAlso submissions.Count > 0 Then
            Dim submission As JObject = submissions(currentIndex)
            txtName.Text = submission("name").ToString()
            txtEmail.Text = submission("email").ToString()
            txtPhoneNum.Text = submission("phone").ToString()
            txtGithubLink.Text = submission("github_link").ToString()
            lblStopwatchTime.Text = submission("stopwatch_time").ToString()
        End If
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        If currentIndex > 0 Then
            currentIndex -= 1
            UpdateForm()
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If currentIndex < submissions.Count - 1 Then
            currentIndex += 1
            UpdateForm()
        End If
    End Sub
End Class
