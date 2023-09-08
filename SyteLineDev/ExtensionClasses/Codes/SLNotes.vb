Option Explicit On
Option Strict On

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common

<IDOExtensionClass("SLNotes")> _
Public Class SLNotes
    Inherits ExtensionClassBase
    Public Function UpdateNotes(ByVal Key As String, ByVal Sequence As String, ByVal Text As String) As Integer


        Dim ResultSet As IDataReader

        UpdateNotes = 0

        Dim strText As String
        Dim strKey As String
        Dim strSeq As String

        strText = Replace(Text, "'", "''")
        strKey = Key
        strSeq = Sequence

        Try
            Using db As ApplicationDB = IDORuntime.Context.CreateApplicationDB()
                Using cmd As IDbCommand = db.CreateCommand()
                    cmd.CommandText = "SELECT key_ FROM notes " &
                                  "WHERE key_= @Key AND seq = @Seq"
                    db.AddCommandParameterWithValue(cmd, "Key", strKey)
                    db.AddCommandParameterWithValue(cmd, "Seq", strSeq)
                    ResultSet = db.ExecuteReader(cmd)

                    If ResultSet.Read() Then
                        cmd.CommandText = "UPDATE notes SET txt = @Text" &
                                          "WHERE key_= @Key AND seq = @Seq"
                    Else
                        cmd.CommandText = "INSERT INTO notes (key_, seq, txt) " &
                                          "VALUES (@Key, @Seq, @Text)"
                    End If
                    cmd.Parameters.Clear()
                    db.AddCommandParameterWithValue(cmd, "Key", strKey)
                    db.AddCommandParameterWithValue(cmd, "Seq", strSeq)
                    db.AddCommandParameterWithValue(cmd, "Text", strText)
                    db.ExecuteNonQuery(cmd)
                    If Not ResultSet Is Nothing AndAlso Not ResultSet.IsClosed Then
                        ResultSet.Close()
                    End If
                End Using
            End Using
            Exit Function
        Catch ex As Exception
            UpdateNotes = -1
        End Try

    End Function

End Class

