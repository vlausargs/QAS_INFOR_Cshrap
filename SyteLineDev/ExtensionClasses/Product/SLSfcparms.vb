Option Explicit On
Option Strict On

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common
Imports Mongoose.Core.DataAccess

Imports CSI.Data.SQL.UDDT
Imports CSI.Production
Imports CSI.MG
Imports System.Runtime.InteropServices

''' <summary>
''' IDO extension class for the SyteLine SLSfcparms IDO. 
''' </summary>
''' <remarks></remarks>
''' 
<IDOExtensionClass("SLSfcparms")> _
Public Class SLSfcparms
    Inherits ExtensionClassBase

    Public ParmsTable As String = "sfcparms"

    ''' <summary>
    ''' Get a named MRP parameter value.
    ''' </summary>
    ''' <param name="parmValue">The parameter value.</param>
    ''' <param name="parmName">The SFC parameter name.</param>
    ''' <returns>The return value is (0).  If an error occurrs and exception is raised.</returns>
    ''' <remarks>Raises an MGException if a failure occurrs</remarks>
    <IDOMethod(MethodFlags.None)> _
    Public Function GetSystemParm(ByRef parmValue As String, _
                                ByVal parmName As String) As Integer

        Dim ResultSet As IDataReader = Nothing
        Try
            ' create an AppDB instance for our application database
            Using db As ApplicationDB = IDORuntime.Context.CreateApplicationDB()
                ' create a new SqlCommand
                Using cmd As IDbCommand = db.CreateCommand()
                    cmd.CommandText = String.Format("SELECT {0} FROM " & ParmsTable, parmName)
                    cmd.CommandType = CommandType.Text
                    Try
                        ' execute the command through the framework
                        ResultSet = db.ExecuteReader(cmd)
                    Catch ex As Exception
                        Throw New Exception(GetMessageProvider.GetMessage("E=NoExist1", "@!Parameters", "@mrp_parm", parmName))
                    End Try

                    Using reader As New MGDataReader(ResultSet)
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
            If ResultSet IsNot Nothing AndAlso Not ResultSet.IsClosed Then
                ResultSet.Close()
            End If
        End Try
        Return 0
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function JobParmUpdateBasisSp(ByVal RunBasis As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iJobParmUpdateBasisExt As IJobParmUpdateBasis = New JobParmUpdateBasisFactory().Create(appDb)

            Dim Severity As Integer = iJobParmUpdateBasisExt.JobParmUpdateBasisSp(RunBasis)

            Return Severity
        End Using
    End Function
End Class

