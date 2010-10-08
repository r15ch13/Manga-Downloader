'IDE-Voreinstellungen:
'Option Explicit On
'Option Strict On

'"My Project"-Einstellungen:
'Imports Microsoft.VisualBasic.ControlChars
'Imports System.Windows.Forms
'Imports System

#Region " VB2008 hat diese 3 generischen Delegaten bereits deklariert, daher sollten sie bei Verwendung von VB2008 nicht noch einmal deklariert werden."
'Public Delegate Sub Action()
'Public Delegate Sub Action(Of T1, T2)(ByVal Arg1 As T1, ByVal Arg2 As T2)
'Public Delegate Sub Action(Of T1, T2, T3)(ByVal Arg1 As T1, ByVal Arg2 As T2, ByVal Arg3 As T3)
#End Region

''' <summary>
''' Stellt Methoden bereit, mit denen ein beliebiger Methoden-Aufruf mit bis zu 3 Argumenten
''' in einen Nebenthread verlegt werden kann, bzw. aus einem Nebenthread in den Hauptthread
''' </summary>
Public Class CrossThread

    Public Shared Sub RunAsync(Of T1, T2, T3)(ByVal Action As Action(Of T1, T2, T3), ByVal Arg1 As T1, ByVal Arg2 As T2, ByVal Arg3 As T3)
        ' Aufruf von Action.EndInvoke() gewährleisten, indem er als Callback-Argument mitgegeben wird
        Action.BeginInvoke(Arg1, Arg2, Arg3, AddressOf Action.EndInvoke, Nothing)
    End Sub
    Public Shared Sub RunAsync(Of T1, T2)(ByVal Action As Action(Of T1, T2), ByVal Arg1 As T1, ByVal Arg2 As T2)
        Action.BeginInvoke(Arg1, Arg2, AddressOf Action.EndInvoke, Nothing)
    End Sub
    Public Shared Sub RunAsync(Of T1)(ByVal Action As Action(Of T1), ByVal Arg1 As T1)
        Action.BeginInvoke(Arg1, AddressOf Action.EndInvoke, Nothing)
    End Sub
    Public Shared Sub RunAsync(ByVal Action As Action)
        Action.BeginInvoke(AddressOf Action.EndInvoke, Nothing)
    End Sub

    Private Shared Function GuiCrossInvoke(ByVal Action As [Delegate], ByVal ParamArray Args() As Object) As Boolean
        If Application.OpenForms.Count = 0 Then
            'wenn kein Form mehr da ist, so tun, als ob das Invoking ausgeführt wäre
            Return True
        End If
        If Application.OpenForms(0).InvokeRequired Then
            Application.OpenForms(0).BeginInvoke(Action, Args)
            Return True
        End If
    End Function

    Public Shared Sub RunGui(Of T1, T2, T3)(ByVal Action As Action(Of T1, T2, T3), ByVal Arg1 As T1, ByVal Arg2 As T2, ByVal Arg3 As T3)
        'falls Invoking nicht erforderlich, die Action direkt ausführen
        If Not GuiCrossInvoke(Action, Arg1, Arg2, Arg3) Then Action(Arg1, Arg2, Arg3)
    End Sub
    Public Shared Sub RunGui(Of T1, T2)(ByVal Action As Action(Of T1, T2), ByVal Arg1 As T1, ByVal Arg2 As T2)
        If Not GuiCrossInvoke(Action, Arg1, Arg2) Then Action(Arg1, Arg2)
    End Sub
    Public Shared Sub RunGui(Of T1)(ByVal Action As Action(Of T1), ByVal Arg1 As T1)
        If Not GuiCrossInvoke(Action, Arg1) Then Action(Arg1)
    End Sub
    Public Shared Sub RunGui(ByVal Action As Action)
        If Not GuiCrossInvoke(Action) Then Action()
    End Sub

End Class
