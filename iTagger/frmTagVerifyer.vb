Public Class frmTagVerifyer

    Private Sub frmTagVerifyer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub FillData(albumId As Integer)
        Dim r As str_search_result = api_lookup(albumId)

        LoadWebImageToPictureBox(picCover, r.tracks(0).artworkUrl600)
    End Sub
End Class