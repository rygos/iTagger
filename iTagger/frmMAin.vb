Public Class frmMAin

    Private Sub frmMAin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = wCap()
    End Sub

    Private Sub cmdOpenPath_Click(sender As Object, e As EventArgs) Handles cmdOpenPath.Click
        fbd.Description = "Ordner öffnen..."


    End Sub
End Class
