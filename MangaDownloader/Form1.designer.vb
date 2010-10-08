<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.CheckBoxAll = New System.Windows.Forms.CheckBox
        Me.ListViewChapters = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ButtonStart = New System.Windows.Forms.Button
        Me.ProgressBarPictures = New System.Windows.Forms.ProgressBar
        Me.ProgressBarPage = New System.Windows.Forms.ProgressBar
        Me.ProgressBarFirstChapterPage = New System.Windows.Forms.ProgressBar
        Me.ProgressBarChapter = New System.Windows.Forms.ProgressBar
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.PictureBoxState = New System.Windows.Forms.PictureBox
        Me.ComboBoxMangaList = New System.Windows.Forms.ComboBox
        Me.PictureBoxInfo = New System.Windows.Forms.PictureBox
        Me.CheckBoxOneFolder = New System.Windows.Forms.CheckBox
        Me.Button1 = New System.Windows.Forms.Button
        CType(Me.PictureBoxState, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CheckBoxAll
        '
        Me.CheckBoxAll.AutoSize = True
        Me.CheckBoxAll.Enabled = False
        Me.CheckBoxAll.Location = New System.Drawing.Point(12, 43)
        Me.CheckBoxAll.Name = "CheckBoxAll"
        Me.CheckBoxAll.Size = New System.Drawing.Size(155, 17)
        Me.CheckBoxAll.TabIndex = 34
        Me.CheckBoxAll.Text = "Alle markieren/demarkieren"
        Me.CheckBoxAll.UseVisualStyleBackColor = True
        '
        'ListViewChapters
        '
        Me.ListViewChapters.CheckBoxes = True
        Me.ListViewChapters.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.ListViewChapters.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.ListViewChapters.Location = New System.Drawing.Point(12, 68)
        Me.ListViewChapters.MultiSelect = False
        Me.ListViewChapters.Name = "ListViewChapters"
        Me.ListViewChapters.Size = New System.Drawing.Size(477, 423)
        Me.ListViewChapters.TabIndex = 33
        Me.ListViewChapters.UseCompatibleStateImageBehavior = False
        Me.ListViewChapters.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Width = 473
        '
        'ButtonStart
        '
        Me.ButtonStart.Enabled = False
        Me.ButtonStart.Location = New System.Drawing.Point(362, 39)
        Me.ButtonStart.Name = "ButtonStart"
        Me.ButtonStart.Size = New System.Drawing.Size(105, 23)
        Me.ButtonStart.TabIndex = 31
        Me.ButtonStart.Text = "Download starten"
        Me.ButtonStart.UseVisualStyleBackColor = True
        '
        'ProgressBarPictures
        '
        Me.ProgressBarPictures.Location = New System.Drawing.Point(75, 551)
        Me.ProgressBarPictures.Maximum = 0
        Me.ProgressBarPictures.Name = "ProgressBarPictures"
        Me.ProgressBarPictures.Size = New System.Drawing.Size(414, 12)
        Me.ProgressBarPictures.Step = 1
        Me.ProgressBarPictures.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBarPictures.TabIndex = 27
        '
        'ProgressBarPage
        '
        Me.ProgressBarPage.Location = New System.Drawing.Point(75, 533)
        Me.ProgressBarPage.Maximum = 0
        Me.ProgressBarPage.Name = "ProgressBarPage"
        Me.ProgressBarPage.Size = New System.Drawing.Size(414, 12)
        Me.ProgressBarPage.Step = 1
        Me.ProgressBarPage.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBarPage.TabIndex = 27
        '
        'ProgressBarFirstChapterPage
        '
        Me.ProgressBarFirstChapterPage.Location = New System.Drawing.Point(75, 515)
        Me.ProgressBarFirstChapterPage.Maximum = 0
        Me.ProgressBarFirstChapterPage.Name = "ProgressBarFirstChapterPage"
        Me.ProgressBarFirstChapterPage.Size = New System.Drawing.Size(414, 12)
        Me.ProgressBarFirstChapterPage.Step = 1
        Me.ProgressBarFirstChapterPage.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBarFirstChapterPage.TabIndex = 27
        '
        'ProgressBarChapter
        '
        Me.ProgressBarChapter.Location = New System.Drawing.Point(75, 497)
        Me.ProgressBarChapter.Maximum = 0
        Me.ProgressBarChapter.Name = "ProgressBarChapter"
        Me.ProgressBarChapter.Size = New System.Drawing.Size(414, 12)
        Me.ProgressBarChapter.Step = 1
        Me.ProgressBarChapter.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBarChapter.TabIndex = 27
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 497)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "Kapitel:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 515)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Startseiten:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 533)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "Seiten:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 551)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 41
        Me.Label4.Text = "Bilder:"
        '
        'PictureBoxState
        '
        Me.PictureBoxState.Image = Global.OneMangaDownloader.My.Resources.Resources.delete
        Me.PictureBoxState.Location = New System.Drawing.Point(473, 14)
        Me.PictureBoxState.Name = "PictureBoxState"
        Me.PictureBoxState.Size = New System.Drawing.Size(16, 16)
        Me.PictureBoxState.TabIndex = 39
        Me.PictureBoxState.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBoxState, "Klicke hier um die Liste erneut zu laden")
        '
        'ComboBoxMangaList
        '
        Me.ComboBoxMangaList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBoxMangaList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.ComboBoxMangaList.DropDownHeight = 400
        Me.ComboBoxMangaList.Enabled = False
        Me.ComboBoxMangaList.FormattingEnabled = True
        Me.ComboBoxMangaList.IntegralHeight = False
        Me.ComboBoxMangaList.Location = New System.Drawing.Point(12, 12)
        Me.ComboBoxMangaList.Name = "ComboBoxMangaList"
        Me.ComboBoxMangaList.Size = New System.Drawing.Size(455, 21)
        Me.ComboBoxMangaList.TabIndex = 42
        '
        'PictureBoxInfo
        '
        Me.PictureBoxInfo.Image = Global.OneMangaDownloader.My.Resources.Resources.information
        Me.PictureBoxInfo.Location = New System.Drawing.Point(473, 43)
        Me.PictureBoxInfo.Name = "PictureBoxInfo"
        Me.PictureBoxInfo.Size = New System.Drawing.Size(16, 16)
        Me.PictureBoxInfo.TabIndex = 39
        Me.PictureBoxInfo.TabStop = False
        '
        'CheckBoxOneFolder
        '
        Me.CheckBoxOneFolder.AutoSize = True
        Me.CheckBoxOneFolder.Location = New System.Drawing.Point(173, 43)
        Me.CheckBoxOneFolder.Name = "CheckBoxOneFolder"
        Me.CheckBoxOneFolder.Size = New System.Drawing.Size(167, 17)
        Me.CheckBoxOneFolder.TabIndex = 43
        Me.CheckBoxOneFolder.Text = "In einen Ordner herunterladen"
        Me.CheckBoxOneFolder.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(253, 116)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 44
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(501, 575)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.CheckBoxOneFolder)
        Me.Controls.Add(Me.ComboBoxMangaList)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBoxInfo)
        Me.Controls.Add(Me.PictureBoxState)
        Me.Controls.Add(Me.ProgressBarChapter)
        Me.Controls.Add(Me.CheckBoxAll)
        Me.Controls.Add(Me.ProgressBarFirstChapterPage)
        Me.Controls.Add(Me.ListViewChapters)
        Me.Controls.Add(Me.ProgressBarPage)
        Me.Controls.Add(Me.ButtonStart)
        Me.Controls.Add(Me.ProgressBarPictures)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "OneManga Downloader"
        CType(Me.PictureBoxState, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ProgressBarChapter As System.Windows.Forms.ProgressBar
    Friend WithEvents ProgressBarFirstChapterPage As System.Windows.Forms.ProgressBar
    Friend WithEvents ProgressBarPage As System.Windows.Forms.ProgressBar
    Friend WithEvents ListViewChapters As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents CheckBoxAll As System.Windows.Forms.CheckBox
    Friend WithEvents ProgressBarPictures As System.Windows.Forms.ProgressBar
    Friend WithEvents PictureBoxState As System.Windows.Forms.PictureBox
    Friend WithEvents ButtonStart As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ComboBoxMangaList As System.Windows.Forms.ComboBox
    Friend WithEvents PictureBoxInfo As System.Windows.Forms.PictureBox
    Friend WithEvents CheckBoxOneFolder As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class
