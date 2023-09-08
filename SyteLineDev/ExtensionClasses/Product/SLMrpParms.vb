Option Explicit On
Option Strict On

Imports System.Data.SqlClient

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common
Imports Mongoose.Core.DataAccess

''' <summary>
''' IDO extension class for the SyteLine SLMrpParms IDO. 
''' </summary>
''' <remarks></remarks>
''' 
<IDOExtensionClass("SLMrpParms")> _
Public Class SLMrpParms
    Inherits ExtensionClassBase

    Public ParmsTable As String = "mrp_parm"

    ''' <summary>
    ''' Get a named MRP parameter value.
    ''' </summary>
    ''' <param name="parmValue">The parameter value.</param>
    ''' <param name="parmName">The MRP parameter name.</param>
    ''' <returns>The return value is (0).  If an error occurrs and exception is raised.</returns>
    ''' <remarks>Raises an MGException if a failure occurrs</remarks>
    <IDOMethod(MethodFlags.None)> _
    Public Function GetSystemParm(ByRef parmValue As String, _
                                    ByVal parmName As String) As Integer

        Dim dr As IDataReader = Nothing
        Try
            ' create an AppDB instance for our application database
            Using db As ApplicationDB = IDORuntime.Context.CreateApplicationDB()
                ' create a new SqlCommand
                Using cmd As IDbCommand = db.CreateCommand()
                    cmd.CommandText = String.Format(
                "SELECT [{0}] FROM [" & ParmsTable & "]", parmName)
                    cmd.CommandType = CommandType.Text
                    Try
                        ' execute the command through the framework
                        dr = db.ExecuteReader(cmd)
                    Catch ex As Exception
                        Throw New Exception(GetMessageProvider.GetMessage("E=NoExist1", "@!Parameters", "@mrp_parm", parmName))
                    End Try

                    Using reader As New MGDataReader(dr)
                        If reader.Read() Then
                            ' return the parameter using the framework's internal format
                            ' NOTE:  starting with 6.0.0.2 version of framework you can 
                            '        convert to internal format using this equivalent API:
                            '
                            '        parmValue = MGType.ToInternal(dr.GetValue(0))
                            parmValue =
                            TextUtil.FormatNormalizedString(reader.RawReader.GetValue(0))
                        Else
                            Throw New Exception(GetMessageProvider.GetMessage("E=NotOneExists", "@" & ParmsTable))
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MGException.Throw(ex.Message)
        Finally
            If dr IsNot Nothing AndAlso Not dr.IsClosed Then
                dr.Close()
            End If
        End Try
        Return 0
    End Function
End Class

