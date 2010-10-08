Imports System.Threading
Imports System.Text.RegularExpressions

Public Class Form1
    Private _baseurl As String = "http://www.onemanga.com"
    Private _chapterpath As String
    Private _filename As String
    Private _onefolder As Boolean = False
    'Private _downloadpath As String = Application.StartupPath
    Private _downloadpath As String = FileIO.SpecialDirectories.Desktop

    Private _chapters As New ArrayList
    Private _firstchapterpage As New ArrayList
    Private _pages As New ArrayList
    Private _tmpArrayList As New ArrayList

    Private WithEvents _manga As Manga

    Public Sub New()
        Me.SetStyle(System.Windows.Forms.ControlStyles.DoubleBuffer, True)
        Me.SetStyle(System.Windows.Forms.ControlStyles.AllPaintingInWmPaint, False)
        'Me.SetStyle(System.Windows.Forms.ControlStyles.ResizeRedraw, True)
        'Me.SetStyle(System.Windows.Forms.ControlStyles.UserPaint, True)
        'Me.SetStyle(System.Windows.Forms.ControlStyles.SupportsTransparentBackColor, True)

        InitializeComponent()
        Try
            If FileIO.FileSystem.FileExists("download.log") Then
                FileIO.FileSystem.DeleteFile("download.log")
            End If
        Catch ex As Exception
            '/dev/null
        End Try
    End Sub

    Private Sub frmSimpleThreading_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me._manga = New Manga()
        CrossThread.RunAsync(AddressOf Me._manga.GetMangaList, "http://content.s-onemanga.com/content-data.js", Me._baseurl)
    End Sub

    Private Sub _manga_Error(ByVal msg As String) Handles _manga.Error
        MessageBox.Show(msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
        Me.Reset()
    End Sub


    Private Sub _manga_MangaListComplete(ByVal arr As ArrayList) Handles _manga.MangaListComplete
        For Each v As String In arr
            Dim item As ComboBoxItem = New ComboBoxItem(v)
            Me.ComboBoxMangaList.Items.Add(item)
            Me.ComboBoxMangaList.AutoCompleteCustomSource.Add(Convert.ToString(item))
        Next
        Me.ComboBoxMangaList.Enabled = True
        Me.PictureBoxState.Image = My.Resources.Resources.accept
    End Sub

    Private Sub PictureBoxState_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxState.Click
        Me.PictureBoxState.Enabled = False
        Me.Reset()
        Me.PictureBoxState.Image = My.Resources.Resources.delete
        Me.ComboBoxMangaList.Enabled = False
        'http://om-content.onemanga.com/lookup-items.js
        CrossThread.RunAsync(AddressOf Me._manga.GetMangaList, "http://content.s-onemanga.com/lookup-items.js", Me._baseurl)
        Me.PictureBoxState.Enabled = True
    End Sub

    Private Sub PictureBoxInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxInfo.Click
        Call About.ShowDialog()
    End Sub



#Region "Chapter"
    Private Sub ButtonGetChapters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxMangaList.SelectedIndexChanged
        Me._chapters.Clear()
        Me._firstchapterpage.Clear()
        Me._pages.Clear()
        Me._tmpArrayList.Clear()
        Me.CheckBoxAll.CheckState = CheckState.Unchecked
        Me.ListViewChapters.Items.Clear()

        If TypeOf Me.ComboBoxMangaList.SelectedItem Is ComboBoxItem Then
            CrossThread.RunAsync(AddressOf Me._manga.GetChapters, Me._baseurl & DirectCast(Me.ComboBoxMangaList.SelectedItem, ComboBoxItem).Url, Me._baseurl)
        End If
    End Sub

    Private Sub _manga_TotalChapters(ByVal c As Integer) Handles _manga.TotalChapters
        Me.ProgressBarChapter.Maximum = c
    End Sub

    Private Sub _manga_ChapterProgress() Handles _manga.ChapterProgress
        If Not (Me.ProgressBarChapter.Value + 1) > Me.ProgressBarChapter.Maximum Then Me.ProgressBarChapter.Value += 1
    End Sub

    Private Sub _manga_ChapterUrl(ByVal arr As ArrayList) Handles _manga.ChapterComplete
        Me._chapters.Add(arr)
        Me.ListViewChapters.BeginUpdate()
        For Each url As String In arr
            Me.ListViewChapters.Items.Add(url.Replace(Me._baseurl, ""))
        Next
        Me.ListViewChapters.EndUpdate()
        Me.ButtonStart.Enabled = True
        Me.CheckBoxAll.Enabled = True
    End Sub
#End Region


#Region "FirstChapterPage"
    Private Function ListViewItemsChecked() As Boolean
        For Each item As ListViewItem In Me.ListViewChapters.Items
            If item.Checked Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub ButtonStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonStart.Click
        If Me.ListViewChapters.CheckedItems.Count > 0 Then
            Me._tmpArrayList.Clear()
            Me.ListViewChapters.Enabled = False
            Me.CheckBoxAll.Enabled = False
            Me.CheckBoxOneFolder.Enabled = False
            Me.ComboBoxMangaList.Enabled = False
            Me.ButtonStart.Enabled = False

            Me.ProgressBarFirstChapterPage.Maximum = Me.ListViewChapters.CheckedItems.Count
            Me.ProgressBarPage.Maximum = Me.ListViewChapters.CheckedItems.Count
            Me.ProgressBarPictures.Maximum = Me.ListViewChapters.CheckedItems.Count

            For Each item As ListViewItem In Me.ListViewChapters.CheckedItems
                Me._tmpArrayList.Add(item.Text)
            Next

            CrossThread.RunAsync(AddressOf Me._manga.GetFirstChapterPage, Me._tmpArrayList, Me._baseurl)
        Else
            MsgBox("Bitte mindestens ein Kapitel auswählen")
        End If
    End Sub

    Private Sub _manga_FirstChapterPageProgress() Handles _manga.FirstChapterPageProgress
        If Not (Me.ProgressBarFirstChapterPage.Value + 1) > Me.ProgressBarFirstChapterPage.Maximum Then Me.ProgressBarFirstChapterPage.Value += 1
    End Sub

    Private Sub _manga_FirstChapterPageUrl(ByVal arr As ArrayList) Handles _manga.FirstChapterPageComplete
        Me._firstchapterpage = arr
        Me.LoadPages()
    End Sub
#End Region


#Region "Page"
    Private Sub LoadPages()
        CrossThread.RunAsync(AddressOf Me._manga.GetPages, Me._firstchapterpage, Me._baseurl)
    End Sub

    Private Sub _manga_PageProgress() Handles _manga.PageProgress
        If Not (Me.ProgressBarPage.Value + 1) > Me.ProgressBarPage.Maximum Then Me.ProgressBarPage.Value += 1
    End Sub

    Private Sub _manga_PageComplete(ByVal arr As ArrayList) Handles _manga.PageComplete
        Dim c As Integer = arr.Count

        While c > 0
            Me._pages.Add(arr.Item(c - 1))
            c -= 1
        End While

        Me.LoadPictures()
    End Sub
#End Region


#Region "Pictures"
    Private Sub LoadPictures()
        Me.ProgressBarPictures.Maximum = PicturesTotal()
        CrossThread.RunAsync(AddressOf Me._manga.GetPictures, Me._pages)
    End Sub

    Private Function PicturesTotal() As Integer
        Dim i As Integer = 0
        For Each chapter As ArrayList In Me._pages
            For Each page As String In chapter
                i += 1
            Next
        Next
        Return i
    End Function

    Private Sub _manga_PictureProgress() Handles _manga.PictureProgress
        If Not (Me.ProgressBarPictures.Value + 1) > Me.ProgressBarPictures.Maximum Then Me.ProgressBarPictures.Value += 1
    End Sub



    Private Sub _manga_PictureDownload(ByVal url As String, ByVal chapter As String) Handles _manga.PictureDownload
        Try
            Dim outputname As String

            Dim _match As Match = Regex.Match(chapter.Replace(Me._baseurl, ""), "/(.*)/([\d\.]+)/")

            Dim chaptername As String = _match.Groups.Item(1).Value
            Dim chapterindex As String = _match.Groups.Item(2).Value

            If chapterindex.Length = 1 Then
                chapterindex = "00" & chapterindex
            ElseIf chapterindex.Length = 2 Then
                chapterindex = "0" & chapterindex
            End If

            If Me._onefolder Then
                Me._chapterpath = Me._downloadpath & "\Mangas\" & chaptername & "\"
            Else
                Me._chapterpath = Me._downloadpath & "\Mangas\" & chaptername & "\" & chapterindex & "\"
            End If


            If Not FileIO.FileSystem.DirectoryExists(Me._chapterpath) Then
                FileIO.FileSystem.CreateDirectory(Me._chapterpath)
            End If

            If FileIO.FileSystem.FileExists(Application.StartupPath & "\wget\wget.exe") Then

                Dim p As New Process

                If Me._onefolder Then
                    outputname = chapterindex & "-" & url.Substring(url.LastIndexOf("/") + 1, url.Length - url.LastIndexOf("/") - 1)
                Else
                    outputname = url.Substring(url.LastIndexOf("/") + 1, url.Length - url.LastIndexOf("/") - 1)
                End If

                p.StartInfo.Arguments = String.Format("-nv -nc -b -a wget.log -U ""{2}"" ""{1}"" -O ""{0}""", Me._chapterpath & outputname, url, "Mozilla/5.0")
                p.StartInfo.FileName = Application.StartupPath & "\wget\wget.exe"
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                p.Start()

            Else
                MessageBox.Show("wget.exe konnte nicht gefunden werden. Der Download wurde abgebrochen. Bitte installiere das Programm neu.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.Close()
                Application.Exit()
            End If
        Catch ex As Exception
            Debug.WriteLine("PictureStartDownload: " & vbNewLine & ex.ToString)
            '/dev/null
        End Try
    End Sub

    'Private Sub _manga_PictureStartDownload(ByVal urls As String, ByVal chapter As String) Handles _manga.PictureStartDownload
    '    Try

    '        Dim _match As Match = Regex.Match(chapter.Replace(Me._baseurl, ""), "/(.*)/(\d+)/")

    '        Dim chaptername As String = _match.Groups.Item(1).Value
    '        Dim chapterindex As String = _match.Groups.Item(2).Value

    '        If chapterindex.Length = 1 Then
    '            chapterindex = "00" & chapterindex
    '        ElseIf chapterindex.Length = 2 Then
    '            chapterindex = "0" & chapterindex
    '        End If

    '        Me._chapterpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\Mangas\" & chaptername & "\" & chapterindex & "\"

    '        Me._filename = chapter.Replace(Me._baseurl, "")
    '        Me._filename = Me._filename.Substring(1, Me._filename.Length - 2)
    '        Me._filename = Me._filename.Replace("/", "_")
    '        Me._filename &= ".txt"

    '        If Not FileIO.FileSystem.DirectoryExists(Me._chapterpath) Then
    '            FileIO.FileSystem.CreateDirectory(Me._chapterpath)
    '        End If

    '        FileIO.FileSystem.WriteAllText(Me._chapterpath & Me._filename, urls, False, System.Text.Encoding.ASCII)

    '        If FileIO.FileSystem.FileExists(Application.StartupPath & "\wget\wget.exe") Then
    '            Dim p As New Process

    '            p.StartInfo.Arguments = String.Format("-nv -nc -b -a wget.log -U ""{2}"" -i ""{0}{1}"" -P ""{0}", Me._chapterpath, Me._filename, "Mozilla/5.0")
    '            p.StartInfo.FileName = Application.StartupPath & "\wget\wget.exe"
    '            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
    '            p.Start()

    '        Else
    '            MessageBox.Show("wget.exe konnte nicht gefunden werden. Der Download wurde abgebrochen. Bitte installiere das Programm neu.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
    '            Me.Close()
    '            Application.Exit()
    '        End If
    '    Catch ex As Exception
    '        Debug.WriteLine("PictureStartDownload: " & vbNewLine & ex.ToString)
    '        '/dev/null
    '    End Try
    'End Sub

    Private Sub _manga_PictureComplete() Handles _manga.PictureComplete
        MessageBox.Show("Download abgeschlossen.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Me.Reset()
    End Sub
#End Region

    Private Sub CheckBoxAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxAll.CheckedChanged
        If Me.CheckBoxAll.Checked Then
            For Each item As ListViewItem In Me.ListViewChapters.Items
                item.Checked = True
            Next
        Else
            For Each item As ListViewItem In Me.ListViewChapters.Items
                item.Checked = False
            Next
        End If
    End Sub

    Private Sub CheckBoxOneFolder_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxOneFolder.CheckedChanged
        If Me.CheckBoxOneFolder.Checked Then
            Me._onefolder = True
        Else
            Me._onefolder = False
        End If
    End Sub


    Private Sub Reset()
        Me._chapters.Clear()
        Me._firstchapterpage.Clear()
        Me._pages.Clear()
        Me._tmpArrayList.Clear()

        Me.ButtonStart.Enabled = False

        Me.ComboBoxMangaList.SelectedIndex = -1
        Me.ComboBoxMangaList.Enabled = True
        Me.CheckBoxOneFolder.Enabled = True
        Me.CheckBoxAll.Enabled = False
        Me.CheckBoxAll.CheckState = CheckState.Unchecked
        Me.ListViewChapters.Enabled = True
        Me.ListViewChapters.Items.Clear()


        Me.ProgressBarChapter.Value = 0
        Me.ProgressBarFirstChapterPage.Value = 0
        Me.ProgressBarPage.Value = 0
        Me.ProgressBarPictures.Value = 0

        Me.ProgressBarChapter.Maximum = 100
        Me.ProgressBarFirstChapterPage.Maximum = 100
        Me.ProgressBarPage.Maximum = 100
        Me.ProgressBarPictures.Maximum = 100

        Me._manga = New Manga()
    End Sub


    
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Dim asd As List(Of dbManga) = dbManga.getAll
        Dim manga1 As dbManga = dbManga.get(1)
        manga1.Name = "Test"
        manga1.Save()
    End Sub
End Class
