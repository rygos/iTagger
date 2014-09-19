Module modMisc

    ''' <summary>
    ''' Programmtitel setzen
    ''' </summary>
    ''' <returns>Programmtitel mit Version</returns>
    ''' <remarks></remarks>
    Public Function wCap() As String
        Return Application.ProductName & " - v" & Application.ProductVersion
    End Function

    Public Sub lvwAddItem(ByVal lvw As ListView, ByVal ParamArray Text() As String)
        With lvw.Items
            .Add(New ListViewItem(Text))
        End With
    End Sub
End Module
