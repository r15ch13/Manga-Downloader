Imports System.Text.RegularExpressions

Public Class ComboBoxItem
    Private _name As String
    Private _url As String


    Public Sub New(ByVal item As String)
        Dim tmp As String() = Regex.Split(item, "\,\/")
        If tmp.Count = 2 Then
            Me._name = tmp(0)
            Me._url = "/" & tmp(1)
        End If
    End Sub

    Public ReadOnly Property Name() As String
        Get
            Return Me._name
        End Get
    End Property

    Public ReadOnly Property Url() As String
        Get
            Return Me._url
        End Get
    End Property

    Public Overrides Function ToString() As String
        If Me.Name = Nothing Then
            Return ""
        Else
            Return Me.Name
        End If
    End Function
End Class