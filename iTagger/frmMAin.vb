Public Class frmMAin

    Private Sub frmMAin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = wCap()
    End Sub

    Private Sub cmdOpenPath_Click(sender As Object, e As EventArgs) Handles cmdOpenPath.Click
        fbd.Description = "Ordner öffnen..."
        If Not fbd.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            Dim oDir As IO.DirectoryInfo
            oDir = New IO.DirectoryInfo(fbd.SelectedPath)
            txtPath.Text = oDir.FullName
            lvFiles.Items.Clear()
            FillList(oDir)

            setlblSelection(lvFiles.SelectedItems.Count, lvFiles.Items.Count)
        End If
    End Sub

    Public Sub removeTaggedItems()
        For Each i In lvFiles.SelectedItems
            lvFiles.Items.Remove(i)
        Next
    End Sub

    Private Sub FillList(odir As IO.DirectoryInfo)
        Dim oSubDir As IO.DirectoryInfo
        Dim oFile As IO.FileInfo


        ' zunächst alle Dateien des Ordners aufspüren
        For Each oFile In odir.GetFiles()
            If oFile.Extension = ".mp3" Or oFile.Extension = ".m4a" Then
                If oFile.Name.StartsWith("._") = False Then
                    With oFile
                        Debug.Print(oFile.FullName)
                        Dim tf As TagLib.File = TagLib.File.Create(oFile.FullName)
                        Dim com As String = tf.Tag.Comment
                        If com <> "TagWithiTagger" Then
                            lvwAddItem(lvFiles, tf.Tag.FirstPerformer, tf.Tag.Title, tf.Length, tf.Tag.Album, _
                                       tf.Tag.Track & "/" & tf.Tag.TrackCount, tf.Tag.Disc & "/" & tf.Tag.DiscCount, _
                                       tf.Tag.FirstGenre, oFile.FullName, tf.Tag.Comment)
                        End If
                    End With
                End If
            End If
        Next

        ' Jetzt alle Unterverzeichnis durchlaufen
        ' und die Prozedur rekursiv selbst aufrufen
        For Each oSubDir In odir.GetDirectories()
            FillList(oSubDir)
        Next
    End Sub

    Private Sub cmdGetTags_Click(sender As Object, e As EventArgs) Handles cmdGetTags.Click
        If lvFiles.SelectedItems.Count <> 0 Then
            ReDim selectedFiles(lvFiles.SelectedItems.Count - 1)
            For i = 0 To lvFiles.SelectedItems.Count - 1
                selectedFiles(i) = lvFiles.SelectedItems(i).SubItems(7).Text
            Next
            cmdGetTags.Enabled = False
            frmAlbumSelection.Show()
            frmAlbumSelection.FillList(lvFiles.SelectedItems(0).SubItems(0).Text & " " & lvFiles.SelectedItems(0).SubItems(3).Text)
        Else
            MsgBox("Es muss Mindestens eine Datei ausgewählt werden.")
        End If
    End Sub

    Private Sub setlblSelection(SelectedFiles As Integer, TotalFiles As Integer)
        lblSelection.Text = "Ausgewählte Dateien: " & SelectedFiles & " von " & TotalFiles
    End Sub

    Private Sub lvFiles_ItemSelectionChanged(sender As Object, e As ListViewItemSelectionChangedEventArgs) Handles lvFiles.ItemSelectionChanged
        setlblSelection(lvFiles.SelectedItems.Count, lvFiles.Items.Count)
    End Sub

    Private Sub cmdReload_Click(sender As Object, e As EventArgs) Handles cmdReload.Click
        If txtPath.Text <> vbNullString Or IO.Directory.Exists(txtPath.Text) = True Then
            Dim odir As IO.DirectoryInfo = New IO.DirectoryInfo(txtPath.Text)
            lvFiles.Items.Clear()
            FillList(odir)
        End If
    End Sub

    Private Sub BeendenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BeendenToolStripMenuItem.Click
        End
    End Sub

    Private Sub ALACEncoderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ALACEncoderToolStripMenuItem.Click
        If IO.File.Exists(Application.StartupPath & "\qaac\qaac.exe") = True Then
            frmEncoder.Show()
        Else
            MsgBox("Für den Encoder ist die Applikation qaac.exe notwendig. Diese muss in den folgenden Ordner vorhanden sein.", MsgBoxStyle.Critical, "qaac.exe fehlt...")
            IO.Directory.CreateDirectory(Application.StartupPath & "\qaac")
            Shell("explorer.exe " & Application.StartupPath & "\qaac\")
        End If

    End Sub
End Class
