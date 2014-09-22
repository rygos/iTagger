Imports System.IO

Public Class frmTagVerifyer
    Dim Tagdata As str_search_result
    Dim AlbumGenre As String
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
            TagLib.ByteVector.UseBrokenLatin1Behavior = True
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
                If .primaryGenreName = vbNullString Then
                    tf.Tag.Genres = New String() {txtGenre.Text}
                Else
                    tf.Tag.Genres = New String() {.primaryGenreName}
                End If

                tf.Tag.Title = .trackName
                tf.Tag.Track = .trackNumber
                tf.Tag.TrackCount = .trackCount
                tf.Tag.Year = .releaseDate.Year

                picCover.Image.Save(Application.StartupPath & "\tmpcov.jpg", System.Drawing.Imaging.ImageFormat.Jpeg)
                tf.Tag.Pictures = New TagLib.IPicture() {TagLib.Picture.CreateFromPath(Application.StartupPath & "\tmpcov.jpg")}
                tf.Tag.Pictures(0).Type = TagLib.PictureType.FrontCover

                'Nun kommen die Custom-Tags 
                '#########################################
                'AppleTag Onjekt
                Dim atag As TagLib.Mpeg4.AppleTag = TryCast(tf.GetTag(TagLib.TagTypes.Apple, True), TagLib.Mpeg4.AppleTag)

                'ITUNESADVISORY
                Dim b_rtng As TagLib.ReadOnlyByteVector = "rtng" 'ITUNESADVISORY
                Dim i_rtng As Integer
                Select Case .trackExplicitness
                    Case "explicit"
                        i_rtng = 4
                    Case "cleaned"
                        i_rtng = 2
                    Case "notExplicit"
                        i_rtng = 0
                End Select
                Dim v_rtng As New TagLib.ByteVector
                v_rtng.Add(CByte(i_rtng))
                Dim ab_rtng As New TagLib.Mpeg4.AppleDataBox(v_rtng, CInt(TagLib.Mpeg4.AppleDataBox.FlagType.ContainsData))
                atag.SetData(b_rtng, New TagLib.Mpeg4.AppleDataBox() {ab_rtng})

                'ITUNESMEDIATYPE
                Dim b_stik As TagLib.ReadOnlyByteVector = "stik" 'ITUNESMEDIATYPE
                Dim i_stik As Integer = 1
                Dim v_stik As New TagLib.ByteVector
                v_stik.Add(CByte(1))
                Dim ab_stik As New TagLib.Mpeg4.AppleDataBox(v_stik, CInt(TagLib.Mpeg4.AppleDataBox.FlagType.ContainsData))
                atag.SetData(b_stik, New TagLib.Mpeg4.AppleDataBox() {ab_stik})

                'ITUNESCATALOGID
                Dim b_cnID As TagLib.ReadOnlyByteVector = "cnID" 'ITUNESCATALOGID
                Dim ab_cnID As New TagLib.Mpeg4.AppleDataBox(TagLib.ByteVector.FromInt(.trackId), CInt(TagLib.Mpeg4.AppleDataBox.FlagType.ContainsText))
                atag.SetData(b_cnID, New TagLib.Mpeg4.AppleDataBox() {ab_cnID})


                'An dieser Stelle wird das Compilation tag gesetzt
                If .collectionArtistName = "Various Artists" Then
                    atag.IsCompilation = True
                Else
                    atag.IsCompilation = False
                End If

            End With

            tf.Save()
            tf.Dispose()
        Next

        frmMAin.removeTaggedItems()
        Me.Close()

    End Sub

    Private Sub TracknummerZuweisenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TracknummerZuweisenToolStripMenuItem.Click
        Dim TrackNum As String = InputBox("Bitte hier die Tracknummer eingeben:", "Neue Tracknummer zuweisen...")
        If TrackNum = vbNullString Then

        Else
            lvFiles.SelectedItems(0).SubItems(2).Text = TrackNum
        End If


    End Sub
End Class