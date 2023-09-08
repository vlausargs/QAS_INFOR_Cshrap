
Option Explicit On
Option Strict On

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.Core.Common
Imports System.Data.SqlClient
Imports Mongoose.IDO.DataAccess
Imports CSI.Finance
Imports CSI.MG

<IDOExtensionClass("SLFaParms")> _
Public Class SLFaParms
    Inherits ExtensionClassBase
    Public Function GetFaParm(ByRef strParmValue As String, ByVal strParmName As String) As Integer

        Dim resultSet As IDataReader

        GetFaParm = 0

        On Error GoTo ErrorHandler

        Using appDB As ApplicationDB = IDORuntime.Context.CreateApplicationDB()
            Using cmd As IDbCommand = appDB.CreateCommand()
                ' execute the command through the framework
                cmd.CommandText = "SELECT " & strParmName & " FROM faparms"
                cmd.CommandType = CommandType.Text
                resultSet = appDB.ExecuteReader(cmd)
            End Using

            If resultSet.Read() Then
                strParmValue = CStr(resultSet.GetValue(0))
            Else
                If Not resultSet Is Nothing AndAlso Not resultSet.IsClosed Then
                    resultSet.Close()
                End If
                Err.Raise(vbObjectError, "Finance", "No system faparms have been defined, or " & strParmName & " is not a valid system faparm.")
            End If
            If Not resultSet Is Nothing AndAlso Not resultSet.IsClosed Then
                resultSet.Close()
            End If
        End Using
        Exit Function
        resultSet = Nothing
ErrorHandler:
        GetFaParm = 16
        Err.Raise(vbObjectError, "Finance", Err.Description)
        resultSet = Nothing
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetDeprCodeSP(ByRef DeprCode As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iGetDeprCodeExt As IGetDeprCode = New GetDeprCodeFactory().Create(appDb)

            Dim Severity As Integer = iGetDeprCodeExt.GetDeprCodeSP(DeprCode)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetFaParmsSp(ByRef Code1Title As String, ByRef Code2Title As String, ByRef Code3Title As String, ByRef Code4Title As String, ByRef NumPeriods As Short?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iGetFaParmsExt As IGetFaParms = New GetFaParmsFactory().Create(appDb)

            Dim Severity As Integer = iGetFaParmsExt.GetFaParmsSp(Code1Title, Code2Title, Code3Title, Code4Title, NumPeriods)

            Return Severity
        End Using
    End Function
End Class