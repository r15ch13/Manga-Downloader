<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class About
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.LabelVersion = New System.Windows.Forms.Label
        Me.LinkLabelLicence = New System.Windows.Forms.LinkLabel
        Me.LinkLabelr15ch13 = New System.Windows.Forms.LinkLabel
        Me.ButtonOk = New System.Windows.Forms.Button
        Me.TextLabelLicence = New System.Windows.Forms.Label
        Me.TextLabelAuthor = New System.Windows.Forms.Label
        Me.TextLabelVersion = New System.Windows.Forms.Label
        Me.GroupBoxAbout = New System.Windows.Forms.GroupBox
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.GroupBoxAbout.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelVersion
        '
        Me.LabelVersion.AutoSize = True
        Me.LabelVersion.Location = New System.Drawing.Point(73, 3)
        Me.LabelVersion.Margin = New System.Windows.Forms.Padding(3)
        Me.LabelVersion.Name = "LabelVersion"
        Me.LabelVersion.Size = New System.Drawing.Size(40, 13)
        Me.LabelVersion.TabIndex = 3
        Me.LabelVersion.Text = "0.0.0.0"
        '
        'LinkLabelLicence
        '
        Me.LinkLabelLicence.AutoSize = True
        Me.LinkLabelLicence.Location = New System.Drawing.Point(73, 49)
        Me.LinkLabelLicence.Margin = New System.Windows.Forms.Padding(3)
        Me.LinkLabelLicence.Name = "LinkLabelLicence"
        Me.LinkLabelLicence.Size = New System.Drawing.Size(162, 13)
        Me.LinkLabelLicence.TabIndex = 2
        Me.LinkLabelLicence.TabStop = True
        Me.LinkLabelLicence.Text = "Creative Commons (by-nc-sa) 3.0"
        '
        'LinkLabelr15ch13
        '
        Me.LinkLabelr15ch13.AutoSize = True
        Me.LinkLabelr15ch13.Location = New System.Drawing.Point(73, 26)
        Me.LinkLabelr15ch13.Margin = New System.Windows.Forms.Padding(3)
        Me.LinkLabelr15ch13.Name = "LinkLabelr15ch13"
        Me.LinkLabelr15ch13.Size = New System.Drawing.Size(88, 13)
        Me.LinkLabelr15ch13.TabIndex = 1
        Me.LinkLabelr15ch13.TabStop = True
        Me.LinkLabelr15ch13.Text = "www.r15ch13.de"
        '
        'ButtonOk
        '
        Me.ButtonOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonOk.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonOk.Location = New System.Drawing.Point(211, 102)
        Me.ButtonOk.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonOk.Name = "ButtonOk"
        Me.ButtonOk.Size = New System.Drawing.Size(75, 23)
        Me.ButtonOk.TabIndex = 2
        Me.ButtonOk.Text = "OK"
        Me.ButtonOk.UseVisualStyleBackColor = True
        '
        'TextLabelLicence
        '
        Me.TextLabelLicence.AutoSize = True
        Me.TextLabelLicence.Location = New System.Drawing.Point(3, 49)
        Me.TextLabelLicence.Margin = New System.Windows.Forms.Padding(3)
        Me.TextLabelLicence.Name = "TextLabelLicence"
        Me.TextLabelLicence.Size = New System.Drawing.Size(47, 13)
        Me.TextLabelLicence.TabIndex = 0
        Me.TextLabelLicence.Text = "License:"
        '
        'TextLabelAuthor
        '
        Me.TextLabelAuthor.AutoSize = True
        Me.TextLabelAuthor.Location = New System.Drawing.Point(3, 26)
        Me.TextLabelAuthor.Margin = New System.Windows.Forms.Padding(3)
        Me.TextLabelAuthor.Name = "TextLabelAuthor"
        Me.TextLabelAuthor.Size = New System.Drawing.Size(41, 13)
        Me.TextLabelAuthor.TabIndex = 0
        Me.TextLabelAuthor.Text = "Author:"
        '
        'TextLabelVersion
        '
        Me.TextLabelVersion.AutoSize = True
        Me.TextLabelVersion.Location = New System.Drawing.Point(3, 3)
        Me.TextLabelVersion.Margin = New System.Windows.Forms.Padding(3)
        Me.TextLabelVersion.Name = "TextLabelVersion"
        Me.TextLabelVersion.Size = New System.Drawing.Size(45, 13)
        Me.TextLabelVersion.TabIndex = 0
        Me.TextLabelVersion.Text = "Version:"
        '
        'GroupBoxAbout
        '
        Me.GroupBoxAbout.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxAbout.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupBoxAbout.Location = New System.Drawing.Point(9, 9)
        Me.GroupBoxAbout.Margin = New System.Windows.Forms.Padding(0)
        Me.GroupBoxAbout.Name = "GroupBoxAbout"
        Me.GroupBoxAbout.Size = New System.Drawing.Size(277, 89)
        Me.GroupBoxAbout.TabIndex = 3
        Me.GroupBoxAbout.TabStop = False
        Me.GroupBoxAbout.Text = "About"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.Controls.Add(Me.TextLabelVersion, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelVersion, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LinkLabelr15ch13, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TextLabelAuthor, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LinkLabelLicence, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TextLabelLicence, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(271, 70)
        Me.TableLayoutPanel1.TabIndex = 4
        '
        'About
        '
        Me.AcceptButton = Me.ButtonOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.ButtonOk
        Me.ClientSize = New System.Drawing.Size(295, 130)
        Me.Controls.Add(Me.GroupBoxAbout)
        Me.Controls.Add(Me.ButtonOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "About"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "300; 273"
        Me.Text = "About"
        Me.TopMost = True
        Me.GroupBoxAbout.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelVersion As System.Windows.Forms.Label
    Friend WithEvents LinkLabelLicence As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabelr15ch13 As System.Windows.Forms.LinkLabel
    Friend WithEvents ButtonOk As System.Windows.Forms.Button
    Friend WithEvents TextLabelLicence As System.Windows.Forms.Label
    Friend WithEvents TextLabelAuthor As System.Windows.Forms.Label
    Friend WithEvents TextLabelVersion As System.Windows.Forms.Label
    Friend WithEvents GroupBoxAbout As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
End Class
