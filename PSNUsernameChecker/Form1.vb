Imports System
Imports System.IO
Imports System.Net
Public Class Form1

    Private Sub btnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        check()
    End Sub

    Sub check()
        Dim web As New WebClient
        Dim page As String
        For Each username As String In ListBox1.Items
            page = web.DownloadString("http://www.laimmckenzie.com/psn/api/avatar.php?psn=" + username)
            If page.Contains("http://") Then

            Else
                ListBox2.Items.Add(username)
            End If
        Next
        MsgBox(ListBox2.Items.Count.ToString + (" Usernames are free out of " + ListBox1.Items.Count.ToString))
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        lstLoad()
    End Sub

    Sub lstLoad()
        ListBox1.Items.Clear()
        Dim r As New IO.StreamReader("list.txt")
        While (r.Peek() > -1)
            If ListBox1.Items.Count <= 99 Then
                ListBox1.Items.Add(r.ReadLine)

                lblList.Text = "Check List(" + ListBox1.Items.Count.ToString + ")"
                If lblList.Text.Contains("100") Then
                    Me.lblList.Left = Me.ClientSize.Width \ 2 - Me.lblList.Width - 60
                Else
                    Me.lblList.Left = Me.ClientSize.Width \ 2 - Me.lblList.Width - 65
                End If
            Else
                Exit Sub
            End If
        End While
        r.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        save()
    End Sub

    Sub save()
        Dim w As New IO.StreamWriter("save.txt")
        Dim i As Integer
        For i = 0 To ListBox2.Items.Count - 1
            w.WriteLine(ListBox2.Items.Item(i))
        Next
        w.Close()
    End Sub

    Private Sub btnAbout_Click(sender As Object, e As EventArgs) Handles btnAbout.Click
        MsgBox("Laim McKenzie" + vbCrLf + "Build Date: 4/4/2015" + vbCrLf + "Build: R34 (EN)" + vbCrLf + "API: laimmckenzie.com/psn/")
    End Sub
End Class
