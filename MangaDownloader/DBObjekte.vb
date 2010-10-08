Imports System.Data

Public MustInherit Class Database
    Private Shared conn As SQLite.SQLiteConnection
    Public Shared Function Open(Optional ByVal connectionString As String = "Data Source=manga.db3;Version=3;Compress=True;") As SQLite.SQLiteConnection
        Try
            conn = New SQLite.SQLiteConnection(connectionString)
            conn.Open()
            Return conn
        Catch ex As SQLite.SQLiteException
            Call Debug.WriteLine("SQLiteException - Open: " & ex.Message)
        End Try
        Return Nothing
    End Function
End Class

'Public MustInherit Class db
'    Private _connection As SQLite.SQLiteConnection
'    Private WithEvents _timer As Timers.Timer

'    Public Function ExecuteNonQuery(ByVal command As String, Optional ByRef exclusiveConnection As SQLite.SQLiteConnection = Nothing) As Integer
'        Try
'            If exclusiveConnection Is Nothing Then exclusiveConnection = getConnection()
'            Return New SQLite.SQLiteCommand(command, exclusiveConnection).ExecuteNonQuery()
'        Catch ex As SQLite.SQLiteException
'            Call Debug.WriteLine("SQLiteException - ExecuteNonQuery: " & ex.Message & vbNewLine & command)
'        End Try
'        Return Nothing
'    End Function

'    Public Function ExecuteReader(ByVal command As String, Optional ByRef exclusiveConnection As SQLite.SQLiteConnection = Nothing) As SQLite.SQLiteDataReader
'        Try
'            If exclusiveConnection Is Nothing Then exclusiveConnection = getConnection()
'            Return New SQLite.SQLiteCommand(command, exclusiveConnection).ExecuteReader()
'        Catch ex As SQLite.SQLiteException
'            Call Debug.WriteLine("SQLiteException - ExecuteReader: " & ex.Message & vbNewLine & command)
'        End Try
'        Return Nothing
'    End Function

'    Public Function ExecuteAdapter(ByVal command As String, Optional ByRef exclusiveConnection As SQLite.SQLiteConnection = Nothing) As SQLite.SQLiteDataAdapter
'        Try
'            If exclusiveConnection Is Nothing Then exclusiveConnection = getConnection()
'            Return New SQLite.SQLiteDataAdapter(command, exclusiveConnection)
'        Catch ex As SQLite.SQLiteException
'            Call Debug.WriteLine("SQLiteException - ExecuteAdapter: " & ex.Message & vbNewLine & command)
'        End Try
'        Return Nothing
'    End Function

'    Public Function ExecuteScalar(ByVal command As String, Optional ByRef exclusiveConnection As SQLite.SQLiteConnection = Nothing) As Object
'        Try
'            If exclusiveConnection Is Nothing Then exclusiveConnection = getConnection()
'            Return New SQLite.SQLiteCommand(command, exclusiveConnection).ExecuteScalar()
'        Catch ex As SQLite.SQLiteException
'            Call Debug.WriteLine("SQLiteException - ExecuteScalar: " & ex.Message & vbNewLine & command)
'        End Try
'        Return Nothing
'    End Function

'    Public Sub closeConnection()
'        Try
'            If Not TypeOf Me._connection Is SQLite.SQLiteConnection Then If Me._connection.State <> ConnectionState.Closed Then Me._connection.Close()
'        Catch ex As SQLite.SQLiteException
'            Call Debug.WriteLine("SQLiteException - closeConnection: " & ex.Message & vbNewLine & Command())
'        End Try
'    End Sub

'    Private Sub OnTimedEvent(ByVal source As Object, ByVal e As Timers.ElapsedEventArgs) Handles _timer.Elapsed
'        Call closeConnection()
'    End Sub

'    Private Function getConnection() As SQLite.SQLiteConnection
'        If Not TypeOf Me._timer Is Timers.Timer Then Me._timer = New Timers.Timer(10000)
'        Me._timer.Stop()
'        Me._timer.Start()
'        Try
'            If Not TypeOf Me._connection Is SQLite.SQLiteConnection Then Me._connection = New SQLite.SQLiteConnection("Data Source=manga.db3;Version=3;Compress=True;")
'            If Me._connection.State <> ConnectionState.Open Then Me._connection.Open()
'            Return Me._connection
'        Catch ex As SQLite.SQLiteException
'            Call Debug.WriteLine("SQLiteException - getConnection: " & ex.Message & vbNewLine & Command())
'        End Try
'        Return Nothing
'    End Function


'End Class

Public Class dbManga
    Inherits Database

    Public DatabaseId As Integer
    Public Name As String
    Public Link As String
    Private insertSQL As SQLite.SQLiteCommand
    Private param As New List(Of SQLite.SQLiteParameter)

    Public Sub New(ByVal id As Integer, ByVal name As String, ByVal link As String)
        Me.DatabaseId = id
        Me.Name = name
        Me.Link = link
        Me.param.Add(New SQLite.SQLiteParameter("@name", Me.Name))
        Me.param.Add(New SQLite.SQLiteParameter("@link", Me.Link))
    End Sub

    Public Sub Save()
        Me.insertSQL = New SQLite.SQLiteCommand("UPDATE manga SET name = '@name', link = '@link' WHERE rowid = " & Convert.ToString(Me.DatabaseId) & ";", dbManga.Open)
        With insertSQL
            '.Parameters.AddRange(param.ToArray)
            Dim name As New SQLite.SQLiteParameter("@name", SqlDbType.Text)
            name.Value = Me.Name

            .Parameters.Add()
            .Parameters.Add(New SQLite.SQLiteParameter("@link", Me.Link))
            .ExecuteNonQuery()
        End With
    End Sub
    Public Function Create() As Object
        With New SQLite.SQLiteCommand("INSERT INTO manga (name,link) VALUE ('', '@name', '@link');", dbManga.Open)
            .Parameters.AddRange(param.ToArray)
            .ExecuteNonQuery()
        End With
        Return New SQLite.SQLiteCommand("SELECT last_insert_rowid();", dbManga.Open).ExecuteScalar()
    End Function

    Public Shared Function getAll() As List(Of dbManga)
        Dim list As New List(Of dbManga)
        Try
            Dim reader As SQLite.SQLiteDataReader = New SQLite.SQLiteCommand("SELECT rowid,name,link FROM manga;", dbManga.Open).ExecuteReader
            While reader.Read
                list.Add(New dbManga(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)))
            End While
            Call reader.Close()
        Catch ex As Exception
        End Try
        Return list
    End Function

    Public Shared Function [get](ByVal id As Integer) As dbManga
        Dim reader As SQLite.SQLiteDataReader = Nothing
        Try
            reader = New SQLite.SQLiteCommand("SELECT rowid,name,link FROM manga WHERE rowid = " & Convert.ToString(id) & " LIMIT 1;", dbManga.Open).ExecuteReader
            Call reader.Read()
            Return New dbManga(reader.GetInt32(0), reader.GetString(1), reader.GetString(2))
        Catch ex As Exception
        Finally
            If TypeOf reader Is SQLite.SQLiteDataReader AndAlso Not reader.IsClosed Then Call reader.Close()
        End Try
        Return Nothing
    End Function
End Class

Public Class dbChapter
    Public Sub New(ByVal m As dbManga)

    End Sub
End Class

Public Class dbPicture
    Public Sub New(ByVal c As dbChapter)

    End Sub
End Class
