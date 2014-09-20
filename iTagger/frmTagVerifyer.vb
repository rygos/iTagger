Imports System.IO

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

        For i = 1 To r.result_count - 1
            lvwAddItem(lvTracks, r.tracks(i).artistiName, r.tracks(i).trackName, TimeSpan.FromMilliseconds(r.tracks(i).trackTimeMillis).ToString, r.tracks(i).trackNumber, r.tracks(i).discNumber, r.tracks(i).primaryGenreName)
        Next

        For i = 0 To selectedFiles.Length - 1
            Dim fi As New FileInfo(selectedFiles(i))
            Dim tf As TagLib.File = TagLib.File.Create(fi.FullName)

            lvwAddItem(lvFiles, tf.Properties.Duration.ToString, fi.Name, tf.Tag.Track)
        Next
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub
End Class