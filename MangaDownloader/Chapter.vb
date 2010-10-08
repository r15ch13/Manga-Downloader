Imports System.Text.RegularExpressions
Imports System.Net

Public Class Manga

    Public Event MangaListComplete(ByVal arr As ArrayList)
    Private Sub eMangaListComplete(ByVal arr As ArrayList)
        RaiseEvent MangaListComplete(arr)
    End Sub

    Public Sub GetMangaList(ByVal url As String, ByVal baseurl As String)
        CrossThread.RunAsync(AddressOf MangaListReader, url, baseurl)
    End Sub
    Private Sub MangaListReader(ByVal url As String, ByVal baseurl As String)
        Try
            Dim tmpArrayList As New ArrayList
            Dim _request As System.Net.WebRequest = System.Net.WebRequest.Create(url)
            Dim _stream As System.IO.Stream = _request.GetResponse.GetResponseStream

            Dim _source As String = New System.IO.StreamReader(_stream).ReadToEnd
            Dim _strings As String() = Regex.Split(_source, "\]\,\[")

            CrossThread.RunGui(AddressOf eTotalChapters, _strings.Count)
            Dim i As Integer = 0
            For Each v As String In _strings
                If i > 0 Then
                    If i = _strings.Count - 1 Then
                        tmpArrayList.Add(Regex.Replace(v, "\]\)\;.*", "").Replace("""", ""))
                    Else
                        tmpArrayList.Add(v.Replace("""", ""))
                    End If
                End If
                i += 1
            Next
            CrossThread.RunGui(AddressOf eMangaListComplete, tmpArrayList)
            _stream.Close()
        Catch ex As WebException
            CrossThread.RunGui(AddressOf eError, ex.Message)
            Debug.WriteLine("ChapterReader: " & ex.ToString)
            '/dev/null
        End Try
    End Sub




    Public Event [Error](ByVal msg As String)
    Private Sub eError(ByVal msg As String)
        RaiseEvent [Error](msg)
    End Sub


    Public Event TotalChapters(ByVal c As Integer)
    Private Sub eTotalChapters(ByVal c As Integer)
        RaiseEvent TotalChapters(c)
    End Sub

    Public Event ChapterProgress()
    Private Sub eChapterProgress()
        RaiseEvent ChapterProgress()
    End Sub

    Public Event ChapterComplete(ByVal arr As ArrayList)
    Private Sub eChapterComplete(ByVal arr As ArrayList)
        RaiseEvent ChapterComplete(arr)
    End Sub

    Public Sub GetChapters(ByVal url As String, ByVal baseurl As String)
        CrossThread.RunAsync(AddressOf ChapterReader, url, baseurl)
    End Sub

    Private Sub ChapterReader(ByVal url As String, ByVal baseurl As String)
        Try
            Dim tmpArrayList As New ArrayList
            Dim _request As System.Net.WebRequest = System.Net.WebRequest.Create(url)
            Dim _stream As System.IO.Stream = _request.GetResponse.GetResponseStream

            Dim _source As String = New System.IO.StreamReader(_stream).ReadToEnd
            Dim _matches As MatchCollection = Regex.Matches(_source, "<td class=\""ch-subject\""><a href=\""(.*)\"">.*<\/a>")

            CrossThread.RunGui(AddressOf eTotalChapters, _matches.Count)

            For Each v As Match In _matches
                If v.Groups.Count > 1 Then
                    tmpArrayList.Add(baseurl & v.Groups.Item(1).Value)
                    CrossThread.RunGui(AddressOf eChapterProgress)
                End If
            Next
            CrossThread.RunGui(AddressOf eChapterComplete, tmpArrayList)
            _stream.Close()
        Catch ex As WebException
            CrossThread.RunGui(AddressOf eError, ex.Message)
            Debug.WriteLine("ChapterReader: " & ex.ToString)
            '/dev/null
        End Try
    End Sub






    Public Event FirstChapterPageProgress()
    Private Sub eFirstChapterPageProgress()
        RaiseEvent FirstChapterPageProgress()
    End Sub

    Public Event FirstChapterPageComplete(ByVal arr As ArrayList)
    Private Sub eFirstChapterPageComplete(ByVal arr As ArrayList)
        RaiseEvent FirstChapterPageComplete(arr)
    End Sub

    Public Sub GetFirstChapterPage(ByVal arr As ArrayList, ByVal baseurl As String)
        CrossThread.RunAsync(AddressOf FirstChapterPageReader, arr, baseurl)
    End Sub

    Private Sub FirstChapterPageReader(ByVal arr As ArrayList, ByVal baseurl As String)
        Try
            Dim tmpArrayList As New ArrayList
            For Each url As String In arr

                Dim _request As System.Net.WebRequest = System.Net.WebRequest.Create(baseurl & url)
                Dim _stream As System.IO.Stream = _request.GetResponse.GetResponseStream

                Dim _source As String = New System.IO.StreamReader(_stream).ReadToEnd
                Dim _match As Match = Regex.Match(_source, "<a href=\""(.*)\"">Begin reading.*<\/a>")

                If _match.Groups.Count > 1 Then
                    tmpArrayList.Add(baseurl & _match.Groups.Item(1).Value)
                    CrossThread.RunGui(AddressOf eFirstChapterPageProgress)
                End If

                _stream.Close()
            Next
            CrossThread.RunGui(AddressOf eFirstChapterPageComplete, tmpArrayList)
        Catch ex As WebException
            CrossThread.RunGui(AddressOf eError, ex.Message)
            Debug.WriteLine("FirstChapterPageReader: " & vbNewLine & ex.ToString)
            '/dev/null
        End Try
    End Sub














    Public Event PageProgress()
    Private Sub ePageProgress()
        RaiseEvent PageProgress()
    End Sub

    Public Event PageComplete(ByVal arr As ArrayList)
    Private Sub ePageComplete(ByVal arr As ArrayList)
        RaiseEvent PageComplete(arr)
    End Sub

    Public Sub GetPages(ByVal arr As ArrayList, ByVal baseurl As String)
        CrossThread.RunAsync(AddressOf PageReader, arr, baseurl)
    End Sub

    Public Sub PageReader(ByVal arr As ArrayList, ByVal baseurl As String)
        Try
            Dim tmpOuterArrayList As New ArrayList
            For Each url As String In arr
                Dim tmpInnerArrayList As New ArrayList
                Dim _request As System.Net.WebRequest = System.Net.WebRequest.Create(url)
                Dim _stream As System.IO.Stream = _request.GetResponse.GetResponseStream

                Dim _source As String = New System.IO.StreamReader(_stream).ReadToEnd

                Dim _match As Match = Regex.Match(_source, "<select name=""page"" id=""id_page_select"" class=""page-select"">(.*)<\/select>", RegexOptions.Singleline)

                If Not _match.Value = "" Then
                    Dim _options As String = _match.Groups.Item(1).Value.Replace("</option> ", "</option> " & vbNewLine).Replace(" selected=""selected""", "").Trim()
                    Dim _matches As MatchCollection = Regex.Matches(_options, "<option value=""(.*)"">.*<\/option>")

                    For Each v As Match In _matches
                        If v.Groups.Count > 1 Then
                            tmpInnerArrayList.Add(Me.CutPage(url) & v.Groups.Item(1).Value & "/")
                        End If
                    Next

                    CrossThread.RunGui(AddressOf ePageProgress)

                    tmpOuterArrayList.Add(tmpInnerArrayList)
                End If
                _stream.Close()
            Next
            CrossThread.RunGui(AddressOf ePageComplete, tmpOuterArrayList)
        Catch ex As Exception
            CrossThread.RunGui(AddressOf eError, ex.Message)
            Debug.WriteLine("PageReader: " & vbNewLine & ex.ToString)
            '/dev/null
        End Try
    End Sub

    Private Function CutPage(ByVal url As String) As String
        Try
            Dim tmp As String = url.Substring(0, url.LastIndexOf("/"))
            Return tmp.Substring(0, tmp.LastIndexOf("/") + 1)
        Catch ex As WebException
            Return url
        End Try
    End Function










    Public Event PictureProgress()
    Private Sub ePictureProgress()
        RaiseEvent PictureProgress()
    End Sub

    'Public Event PictureStartDownload(ByRef urls As String, ByRef chapter As String)
    'Private Sub ePictureStartDownload(ByRef urls As String, ByRef chapter As String)
    '    RaiseEvent PictureStartDownload(urls, chapter)
    'End Sub

    Public Event PictureDownload(ByVal url As String, ByVal chapter As String)
    Private Sub ePictureDownload(ByVal url As String, ByVal chapter As String)
        RaiseEvent PictureDownload(url, chapter)
    End Sub

    Public Event PictureComplete()
    Private Sub ePictureComplete()
        RaiseEvent PictureComplete()
    End Sub

    Public Sub GetPictures(ByVal arr As ArrayList)
        CrossThread.RunAsync(AddressOf PictureReader, arr)
    End Sub

    Public Sub PictureReader(ByVal arr As ArrayList)
        ' Try
        For Each chapter As ArrayList In arr
            Dim tmp As String = ""
            Dim tmpurl As String = ""
            For Each url As String In chapter
                tmpurl = url
                Dim _request As System.Net.WebRequest = System.Net.WebRequest.Create(url)
                Dim _stream As System.IO.Stream = _request.GetResponse.GetResponseStream

                Dim _source As String = New System.IO.StreamReader(_stream).ReadToEnd
                Dim _matches As MatchCollection = Regex.Matches(_source, "<img class=\""manga-page\"" src=\""(.*)\"" alt=\"".*\"" \/>")

                For Each v As Match In _matches
                    If v.Groups.Count > 1 Then
                        tmp &= v.Groups.Item(1).Value & vbNewLine
                        CrossThread.RunGui(AddressOf ePictureDownload, v.Groups.Item(1).Value, Me.CutPage(tmpurl))
                        CrossThread.RunGui(AddressOf ePictureProgress)
                    End If
                Next
                _stream.Close()
            Next
            'CrossThread.RunGui(AddressOf ePictureStartDownload, tmp, Me.CutPage(tmpurl))
        Next
        CrossThread.RunGui(AddressOf ePictureComplete)
        'Catch ex As WebException
        '    CrossThread.RunGui(AddressOf eError, ex.Message)
        '    Debug.WriteLine("PictureReader: " & vbNewLine & ex.ToString)
        '    '/dev/null
        'End Try
    End Sub


End Class
