Public Class frmTagVerifyer

    Private Sub frmTagVerifyer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub FillData(albumId As Integer)
        'Laden der API Daten
        Dim r As str_search_result = api_lookup(albumId)

        'Anzaigen der Albumdaten
        LoadWebImageToPictureBox(picCover, r.tracks(0).artworkUrl600)
        txtAlbumName.Text = r.tracks(0).collectionCensoredName
        txtArtist.Text = r.tracks(0).artistiName
        txtGenre.Text = r.tracks(0).primaryGenreName
        txtYear.Text = r.tracks(0).releaseDate
    End Sub
End Class