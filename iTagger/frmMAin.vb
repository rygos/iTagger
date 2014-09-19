﻿Public Class frmMAin

    Private Sub frmMAin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = wCap()
    End Sub

    Private Sub cmdOpenPath_Click(sender As Object, e As EventArgs) Handles cmdOpenPath.Click
        fbd.Description = "Ordner öffnen..."
        fbd.ShowDialog()
        Dim oDir As IO.DirectoryInfo
        oDir = New IO.DirectoryInfo(fbd.SelectedPath)

        FillList(oDir)
    End Sub

    Private Sub FillList(odir As IO.DirectoryInfo)
        lvFiles.Items.Clear()

        Dim oSubDir As IO.DirectoryInfo
        Dim oFile As IO.FileInfo


        ' zunächst alle Dateien des Ordners aufspüren
        For Each oFile In odir.GetFiles()
            With oFile
                Dim tf As TagLib.File = TagLib.File.Create(oFile.FullName)
                lvwAddItem(lvFiles, tf.Tag.FirstPerformer, tf.Tag.Title, tf.Length, tf.Tag.Album, _
                           tf.Tag.Track & "/" & tf.Tag.TrackCount, tf.Tag.Disc & "/" & tf.Tag.DiscCount, _
                           tf.Tag.FirstGenre, oFile.FullName, tf.Tag.Comment)
            End With
        Next

        ' Jetzt alle Unterverzeichnis durchlaufen
        ' und die Prozedur rekursiv selbst aufrufen
        For Each oSubDir In odir.GetDirectories()
            FillList(oSubDir)
        Next
    End Sub
End Class
