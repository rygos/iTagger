Public Class frmMAin

    Private Sub frmMAin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = wCap()
    End Sub

    Private Sub cmdOpenPath_Click(sender As Object, e As EventArgs) Handles cmdOpenPath.Click
        fbd.Description = "Ordner öffnen..."
        If Not fbd.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            Dim oDir As IO.DirectoryInfo
            oDir = New IO.DirectoryInfo(fbd.SelectedPath)

            FillList(oDir)

            setlblSelection(lvFiles.SelectedItems.Count, lvFiles.Items.Count)
        End If
    End Sub

    Private Sub FillList(odir As IO.DirectoryInfo)
        lvFiles.Items.Clear()

        Dim oSubDir As IO.DirectoryInfo
        Dim oFile As IO.FileInfo


        ' zunächst alle Dateien des Ordners aufspüren
        For Each oFile In odir.GetFiles()
            If oFile.Extension = ".mp3" Or oFile.Extension = ".m4a" Then
                With oFile
                    Dim tf As TagLib.File = TagLib.File.Create(oFile.FullName)
                    lvwAddItem(lvFiles, tf.Tag.FirstPerformer, tf.Tag.Title, tf.Length, tf.Tag.Album, _
                               tf.Tag.Track & "/" & tf.Tag.TrackCount, tf.Tag.Disc & "/" & tf.Tag.DiscCount, _
                               tf.Tag.FirstGenre, oFile.FullName, tf.Tag.Comment)

                End With
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
                selectedFiles(i) = lvFiles.SelectedItems(i).SubItems(7).ToString
            Next
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

End Class
