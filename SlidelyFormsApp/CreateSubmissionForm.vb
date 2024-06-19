Imports System.Net
Imports System.Text
Imports Newtonsoft.Json.Linq


Public Class CreateSubmissionForm
    Private WithEvents txtName As TextBox
    Private WithEvents txtEmail As TextBox
    Private WithEvents txtPhoneNum As TextBox
    Private WithEvents txtGithubLink As TextBox
    Private stopwatchRunning As Boolean = False
    Private stopwatchTime As TimeSpan = TimeSpan.Zero

    Private Sub CreateSubmissionForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.T Then
            btnToggleStopwatch.PerformClick()
        ElseIf e.Control AndAlso e.KeyCode = Keys.S Then
            btnSubmit.PerformClick()
        End If
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs)
        stopwatchRunning = True
        Timer1.Start()
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs)
        stopwatchRunning = False
        Timer1.Stop()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If stopwatchRunning Then
            stopwatchTime = stopwatchTime.Add(TimeSpan.FromSeconds(1))
            lblStopwatchTime.Text = stopwatchTime.ToString("hh\:mm\:ss")
        End If
    End Sub

    Private Sub btnToggleStopwatch_Click(sender As Object, e As EventArgs) Handles btnToggleStopwatch.Click
        stopwatchRunning = Not stopwatchRunning
        Timer1.Enabled = stopwatchRunning
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim submission As New JObject()
        submission("name") = txtName.Text
        submission("email") = txtEmail.Text
        submission("phone") = txtPhoneNum.Text
        submission("github_link") = txtGithubLink.Text
        submission("stopwatch_time") = lblStopwatchTime.Text

        Using client As New WebClient()
            client.Headers(HttpRequestHeader.ContentType) = "application/json"
            Dim json As String = submission.ToString()
            client.UploadString("http://localhost:3000/create", "POST", json)
        End Using

        MessageBox.Show("Submission created successfully!")
    End Sub
End Class
