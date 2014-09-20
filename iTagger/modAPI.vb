Imports System.Net
Imports Newtonsoft.Json.Linq
Imports System.Web

Module modAPI
    Const BasePath As String = "https://itunes.apple.com/"
    Public selectedFiles() As String

    Public Structure str_search_result
        Dim result_count As Integer
        Dim tracks() As str_track
    End Structure

    Public Structure str_track
        Dim wrapperType As String
        Dim kind As String
        Dim artistId As Integer
        Dim collectionId As Integer
        Dim trackId As Integer
        Dim artistiName As String
        Dim collectionName As String
        Dim trackName As String
        Dim collectionCensoredName As String
        Dim trackCensoredName As String
        Dim collectionArtistName As String
        Dim collectionArtistId As String
        Dim collectionArtistViewUrl As String
        Dim artistViewUrl As String
        Dim collectionViewUrl As String
        Dim trackViewUrl As String
        Dim previewUrl As String
        Dim artworkUrl30 As String
        Dim artworkUrl60 As String
        Dim artworkUrl100 As String
        Dim artworkUrl600 As String
        Dim collectionPrice As String
        Dim trackPrice As String
        Dim releaseDate As Date
        Dim collectionExplicitness As String
        Dim trackExplicitness As String
        Dim discCount As Integer
        Dim discNumber As Integer
        Dim trackCount As Integer
        Dim trackNumber As Integer
        Dim trackTimeMillis As Integer
        Dim country As String
        Dim currency As String
        Dim primaryGenreName As String
        Dim copyright As String
    End Structure

    ''' <summary>
    ''' Such in der ITunes API
    ''' </summary>
    ''' <param name="sTerm">Suchbegriffe</param>
    ''' <param name="sCountry">Land ISO</param>
    ''' <param name="sMedia">Welche Mediendaten sollen durchsucht werden</param>
    ''' <param name="sEntity">Welche ergebisse sollen angezeigt werden</param>
    ''' <param name="sAttribute">Spezifizieren des Suchbegriffs</param>
    ''' <param name="iLimit">Zahl zwischen 1 und 200</param>
    ''' <param name="sLang">Sprache der Ausgabe</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function api_search(sTerm As String, Optional sCountry As String = "DE", Optional sMedia As String = "music", Optional sEntity As String = "album", _
                           Optional sAttribute As String = "mixTerm", Optional iLimit As Integer = 200, Optional sLang As String = "de_de") As str_search_result

        Dim sURL As String = BasePath & "search?"

        If sTerm = vbNullString Then
            Return Nothing
        Else
            sURL = sURL & "&term=" & (sTerm)
        End If

        sURL = sURL & "&country=" & sCountry & "&limit=" & iLimit & "&entity=" & sEntity

        Dim wc As New WebClient
        wc.Encoding = System.Text.Encoding.UTF8
        Dim wcresult As String = wc.DownloadString(HttpUtility.UrlDecode(sURL))


        Dim jt As JObject = JObject.Parse(wcresult)
        Dim result As str_search_result
        result.result_count = CInt(jt("resultCount").ToString)
        ReDim result.tracks(result.result_count - 1)
        Dim i As Integer = 0

        If CInt(jt("resultCount").ToString) <> 0 Then
            For Each item In jt("results").Children
                With result.tracks(i)
                    .artistId = item("artistId").ToString
                    .artistiName = item("artistName").ToString
                    .artistViewUrl = item("artistViewUrl").ToString
                    .artworkUrl100 = item("artworkUrl100").ToString
                    .artworkUrl600 = item("artworkUrl100").ToString.Replace("100x100", "600x600")

                    If IsNothing(item("collectionArtistId")) Then
                        .collectionArtistId = .artistId
                    Else
                        .collectionArtistId = item("collectionArtistId").ToString
                    End If

                    If IsNothing(item("collectionArtistName")) Then
                        .collectionArtistName = .artistiName
                    Else
                        .collectionArtistName = item("collectionArtistName").ToString
                    End If

                    If IsNothing(item("collectionArtistViewUrl")) Then
                        .collectionArtistViewUrl = .artistViewUrl
                    Else
                        .collectionArtistViewUrl = item("collectionArtistViewUrl").ToString
                    End If

                    .collectionCensoredName = item("collectionCensoredName").ToString
                    .collectionExplicitness = item("collectionExplicitness").ToString
                    .collectionId = item("collectionId").ToString
                    .collectionName = item("collectionName").ToString
                    .collectionPrice = If(IsNothing(item("collectionPrice")), "", item("collectionPrice").ToString)
                    .collectionViewUrl = item("collectionViewUrl").ToString
                    .country = item("country").ToString
                    .currency = item("currency").ToString
                    .discCount = If(IsNothing(item("discCount")), 1, CInt(item("discCount").ToString))
                    .discNumber = If(IsNothing(item("discNumber")), 1, CInt(item("discNumber").ToString))
                    .kind = If(IsNothing(item("kind")), "", item("kind").ToString)
                    .previewUrl = If(IsNothing(item("previewUrl")), "", item("previewUrl").ToString)

                    'Wenn das Genre nicht verfügbar ist, sollte es aus der AlbumID genommen werden
                    'Empfehle eine neue Funktion dafür.
                    .primaryGenreName = If(IsNothing(item("primaryGenreName")), "", item("primaryGenreName").ToString)
                    .releaseDate = item("releaseDate").ToString
                    .trackCensoredName = If(IsNothing(item("trackCensoredName")), "", item("trackCensoredName").ToString)
                    .trackCount = item("trackCount").ToString
                    .trackExplicitness = If(IsNothing(item("trackExplicitness")), "", item("trackExplicitness").ToString)
                    .trackId = If(IsNothing(item("trackId")), 1, CInt(item("trackId").ToString))
                    .trackName = If(IsNothing(item("trackName")), "", item("trackName").ToString)
                    .trackNumber = If(IsNothing(item("trackNumber")), 1, CInt(item("trackNumber").ToString))
                    .trackPrice = If(IsNothing(item("trackPrice")), "", item("trackPrice").ToString)
                    .trackTimeMillis = If(IsNothing(item("trackTimeMillis")), 1, CInt(item("trackTimeMillis").ToString))
                    .trackViewUrl = If(IsNothing(item("trackViewUrl")), "", item("trackViewUrl").ToString)
                    .wrapperType = item("wrapperType").ToString
                    .copyright = item("copyright").ToString
                End With


                i += 1
            Next
            result.result_count = CInt(jt("resultCount").ToString)
        Else
            result.result_count = 0
        End If

        Return result

    End Function


    Public Function api_lookup(sTerm As String, Optional sCountry As String = "de") As str_search_result
        Dim sURL As String = BasePath & "lookup?"

        If sTerm = vbNullString Then
            Return Nothing
        Else
            sURL = sURL & "&id=" & (sTerm)
        End If

        sURL = sURL & "&country=" & sCountry

        Dim wc As New WebClient
        wc.Encoding = System.Text.Encoding.UTF8
        Dim wcresult As String = wc.DownloadString(HttpUtility.UrlDecode(sURL))


        Dim jt As JObject = JObject.Parse(wcresult)
        Dim result As str_search_result
        result.result_count = CInt(jt("resultCount").ToString)
        ReDim result.tracks(result.result_count - 1)
        Dim i As Integer = 0

        If CInt(jt("resultCount").ToString) <> 0 Then
            For Each item In jt("results").Children
                With result.tracks(i)
                    .artistId = item("artistId").ToString
                    .artistiName = item("artistName").ToString
                    .artistViewUrl = item("artistViewUrl").ToString
                    .artworkUrl100 = item("artworkUrl100").ToString
                    .artworkUrl600 = item("artworkUrl100").ToString.Replace("100x100", "600x600")

                    If IsNothing(item("collectionArtistId")) Then
                        .collectionArtistId = .artistId
                    Else
                        .collectionArtistId = item("collectionArtistId").ToString
                    End If

                    If IsNothing(item("collectionArtistName")) Then
                        .collectionArtistName = .artistiName
                    Else
                        .collectionArtistName = item("collectionArtistName").ToString
                    End If

                    If IsNothing(item("collectionArtistViewUrl")) Then
                        .collectionArtistViewUrl = .artistViewUrl
                    Else
                        .collectionArtistViewUrl = item("collectionArtistViewUrl").ToString
                    End If

                    .collectionCensoredName = item("collectionCensoredName").ToString
                    .collectionExplicitness = item("collectionExplicitness").ToString
                    .collectionId = item("collectionId").ToString
                    .collectionName = item("collectionName").ToString
                    .collectionPrice = If(IsNothing(item("collectionPrice")), "", item("collectionPrice").ToString)
                    .collectionViewUrl = item("collectionViewUrl").ToString
                    .country = item("country").ToString
                    .currency = item("currency").ToString
                    .discCount = If(IsNothing(item("discCount")), 1, CInt(item("discCount").ToString))
                    .discNumber = If(IsNothing(item("discNumber")), 1, CInt(item("discNumber").ToString))
                    .kind = If(IsNothing(item("kind")), "", item("kind").ToString)
                    .previewUrl = If(IsNothing(item("previewUrl")), "", item("previewUrl").ToString)

                    'Wenn das Genre nicht verfügbar ist, sollte es aus der AlbumID genommen werden
                    'Empfehle eine neue Funktion dafür.
                    .primaryGenreName = If(IsNothing(item("primaryGenreName")), "", item("primaryGenreName").ToString)
                    .releaseDate = item("releaseDate").ToString
                    .trackCensoredName = item("trackCensoredName").ToString
                    .trackCount = item("trackCount").ToString
                    .trackExplicitness = item("trackExplicitness").ToString
                    .trackId = item("trackId").ToString
                    .trackName = item("trackName").ToString
                    .trackNumber = item("trackNumber").ToString
                    .trackPrice = If(IsNothing(item("trackPrice")), "", item("trackPrice").ToString)
                    .trackTimeMillis = item("trackTimeMillis").ToString
                    .trackViewUrl = item("trackViewUrl").ToString
                    .wrapperType = item("wrapperType").ToString
                End With


                i += 1
            Next
            result.result_count = CInt(jt("resultCount").ToString)



        Else
            result.result_count = 0
        End If



        Return result
    End Function


End Module
