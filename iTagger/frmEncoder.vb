Public Class frmEncoder

    Private Sub frmEncoder_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Encode_All_Files(odir As IO.DirectoryInfo)
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
                            
                        End If
                    End With
                End If
            End If
        Next

        ' Jetzt alle Unterverzeichnis durchlaufen
        ' und die Prozedur rekursiv selbst aufrufen
        For Each oSubDir In odir.GetDirectories()
            Encode_All_Files(oSubDir)
        Next
    End Sub
End Class