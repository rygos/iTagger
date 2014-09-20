Public Class frmAlbumSelection

    Private Sub frmAlbumSelection_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub FillList(searchString As String)
        Dim r As str_search_result = api_search(searchString)

        If r.result_count <> 0 Then
            For Each i In r.tracks
                lvwAddItem(lvAlbums, i.collectionArtistName, i.collectionCensoredName, i.trackCount, i.copyright, i.collectionId)
            Next
        End If

    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        Dim tColId As Integer = CInt(lvAlbums.SelectedItems(0).SubItems(4).Text)

        If tColId <> 0 Then
            frmTagVerifyer.Show()
            frmTagVerifyer.FillData(tColId)
            Me.Close()
        Else
            MsgBox("Es wurde kein Album ausgewählt.")
        End If


    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub
End Class