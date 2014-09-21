Imports System.IO

Public Class frmTagVerifyer
    Dim Tagdata As str_search_result
    Private Sub frmTagVerifyer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub FillData(albumId As Integer)
        'Laden der API Daten
        Dim r As str_search_result = api_lookup(albumId)

        'Laden der Tagdaten in eine Variable
        Tagdata = r

        'Anzaigen der Albumdaten
        LoadWebImageToPictureBox(picCover, r.tracks(0).artworkUrl600)
        txtAlbumName.Text = r.tracks(0).collectionCensoredName
        txtArtist.Text = r.tracks(0).artistiName
        txtGenre.Text = r.tracks(0).primaryGenreName
        txtYear.Text = r.tracks(0).releaseDate

        'Füllen der Tag ListView
        For i = 1 To r.result_count - 1
            lvwAddItem(lvTracks, r.tracks(i).artistiName, r.tracks(i).trackName, TimeSpan.FromMilliseconds(r.tracks(i).trackTimeMillis).ToString, r.tracks(i).trackNumber, r.tracks(i).discNumber, r.tracks(i).primaryGenreName)
        Next

        'Füllen der Files ListView
        For i = 0 To selectedFiles.Length - 1
            Dim fi As New FileInfo(selectedFiles(i))
            Dim tf As TagLib.File = TagLib.File.Create(fi.FullName)

            lvwAddItem(lvFiles, tf.Properties.Duration.ToString, fi.Name, tf.Tag.Track)
        Next
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click

        For i = 0 To lvFiles.Items.Count - 1
            Dim tf As TagLib.File = TagLib.File.Create(selectedFiles(i))
            Dim tn As Integer = CInt(lvFiles.Items(i).SubItems(2).Text)
            With Tagdata.tracks(tn)
                tf.Tag.Album = .collectionCensoredName
                tf.Tag.AlbumArtists = New String() {Tagdata.tracks(0).artistiName} 'Der AlbumArtist wird aus den AlbumInformationen geladen
                tf.Tag.Performers = New String() {.artistiName}
                tf.Tag.Comment = "TagWithiTagger"
                tf.Tag.Copyright = .copyright
                tf.Tag.Disc = .discNumber
                tf.Tag.DiscCount = .discCount
                tf.Tag.Genres = New String() {.primaryGenreName}
                tf.Tag.Title = .trackName
                tf.Tag.Track = .trackNumber
                tf.Tag.TrackCount = .trackCount
                tf.Tag.Year = .releaseDate.Year
                picCover.Image.Save(Application.StartupPath & "\tmpcov.jpg", System.Drawing.Imaging.ImageFormat.Jpeg)
                tf.Tag.Pictures = New TagLib.IPicture() {TagLib.Picture.CreateFromPath(Application.StartupPath & "\tmpcov.jpg")}
                tf.Tag.Pictures(0).Type = TagLib.PictureType.FrontCover
            End With

            Dim customTag As TagLib.Mpeg4.AppleTag = tf.GetTag(TagLib.TagTypes.Apple)
            Dim vector = New TagLib.ByteVector()
            vector.Add(CByte(10))
            customTag.SetData("stik", vector, CInt(TagLib.Mpeg4.AppleDataBox.FlagType.ContainsData))

            tf.Save()
            tf.Dispose()
        Next

    End Sub
End Class