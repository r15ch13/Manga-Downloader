Imports System.Reflection

Public Class About
    Public Overloads Shared Sub ShowIt()
        Using D As New About
            D.ShowDialog()
        End Using
    End Sub

    Public Sub New()
        InitializeComponent()

        Me.GroupBoxAbout.Text = "About: " & My.Application.Info.ProductName
        Me.LinkLabelr15ch13.Text = My.Application.Info.Copyright
        Me.LabelVersion.Text = Me.FileVersion()
    End Sub

    Private Sub ButtonOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOk.Click
        Me.Close()
    End Sub

    Private Sub LinkLabelr15ch13_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabelr15ch13.LinkClicked
        Process.Start("http://www.r15ch13.de/")
    End Sub

    Private Sub LinkLabelLicence_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabelLicence.LinkClicked
        Process.Start("http://creativecommons.org/licenses/by-nc-sa/3.0/")
    End Sub

    Public Function AssemblyVersion() As String
        Return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString()
    End Function

    Public Function FileVersion() As String
        Return FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FileVersion()
    End Function

End Class