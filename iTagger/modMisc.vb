Imports System.IO
Imports System.Net

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

    Public Function cPic_Taglib_vb(Pic As TagLib.IPicture) As System.Drawing.Image
        Dim ms As New MemoryStream(Pic.Data.Data)
        Dim image As System.Drawing.Image = System.Drawing.Image.FromStream(ms)

        Return image
    End Function

    Public Function LoadWebImageToPictureBox(ByVal pb _
   As PictureBox, ByVal ImageURL As String) As Boolean

        Dim objImage As MemoryStream
        Dim objwebClient As WebClient
        Dim sURL As String = Trim(ImageURL)
        Dim bAns As Boolean

        Try
            If Not sURL.ToLower().StartsWith("http://") _
                 Then sURL = "http://" & sURL
            objwebClient = New WebClient()


            objImage = New  _
               MemoryStream(objwebClient.DownloadData(sURL))
            pb.Image = Image.FromStream(objImage)
            bAns = True
        Catch ex As Exception

            bAns = False
        End Try

        Return bAns

    End Function
End Module
