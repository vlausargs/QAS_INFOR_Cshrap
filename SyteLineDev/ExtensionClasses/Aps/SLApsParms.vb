Option Explicit On
Option Strict On

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common
Imports CSI.MG
Imports CSI.Production.APS
Imports CSI.Data.SQL.UDDT

<IDOExtensionClass("SLApsParms")> _
Public Class SLApsParms
    Inherits CSIExtensionClassBase
    ' this one takes the name of the parm to retrieve
    Public Function GetSystemParm(ByRef strParmValue As String, ByVal strParmName As String) As Integer


        Dim oDataReader As IDataReader = Nothing

        GetSystemParm = 0
        Try
            Using appDB As ApplicationDB = IDORuntime.Context.CreateApplicationDB()
                ' create a new SqlCommand
                Using cmd As IDbCommand = appDB.CreateCommand()
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT " & strParmName & " FROM aps_parm"
                    Try
                        ' execute the command through the framework
                        oDataReader = appDB.ExecuteReader(cmd)
                    Catch ex As Exception
                        If Not oDataReader Is Nothing Then
                            If Not oDataReader.IsClosed Then
                                oDataReader.Close()
                            End If
                        End If
                        GetSystemParm = 16
                        MGException.Throw(MGException.ExtractMessages(ex))
                    End Try

                    If oDataReader.Read Then
                        strParmValue = oDataReader.Item(strParmName).ToString
                    Else
                        If Not oDataReader Is Nothing Then
                            If Not oDataReader.IsClosed Then
                                oDataReader.Close()
                            End If
                        End If
                        GetSystemParm = 16
                        MGException.Throw(Me.GetMessageProvider.GetMessage("E=NoExist1", "@!Parameters", "@aps_parm", strParmName))
                        '("APS" & ":" & "No system parms have been defined, or " & strParmName & " is not a valid system parm.")
                    End If
                    If Not oDataReader Is Nothing Then
                        If Not oDataReader.IsClosed Then
                            oDataReader.Close()
                        End If
                    End If
                End Using
            End Using
            Exit Function
        Catch ex As Exception
            GetSystemParm = 16
            MGException.Throw(MGException.ExtractMessages(ex))
        End Try
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ApsClearOutputSp() As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iApsClearOutputExt As IApsClearOutput = New ApsClearOutputFactory().Create(appDb)
            Dim Severity As Integer = iApsClearOutputExt.ApsClearOutputSp()
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ApsGetSqlInfoSp(ByRef SqlUser As String, ByRef SqlPassword As String, ByRef SqlAlwaysOn As Integer?) As Integer
        Dim iApsGetSqlInfoExt As IApsGetSqlInfo = New ApsGetSqlInfoFactory().Create(Me, True)
        Dim result As (ReturnCode As Integer?, SqlUser As String, SqlPassword As String, SqlAlwaysOn As Integer?) = iApsGetSqlInfoExt.ApsGetSqlInfoSp(SqlUser, SqlPassword, SqlAlwaysOn)
        SqlUser = result.SqlUser
        SqlPassword = result.SqlPassword
        SqlAlwaysOn = result.SqlAlwaysOn
        Return result.ReturnCode.Value
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetTenantIDSp(ByRef TenantID As String) As Integer
        Dim iGetTenantIDExt As IGetTenantID = New GetTenantIDFactory().Create(Me, True)
        Dim result As (ReturnCode As Integer?, TenantID As String) = iGetTenantIDExt.GetTenantIDSp(TenantID)
        TenantID = result.TenantID
        Dim Severity As Integer = result.ReturnCode.Value
        Return Severity
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ApsCopyPlannerDataSp(ByVal AltNo As Short?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iApsCopyPlannerDataExt As IApsCopyPlannerData = New ApsCopyPlannerDataFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iApsCopyPlannerDataExt.ApsCopyPlannerDataSp(AltNo)
            Dim Severity As Integer = result.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PlanningModeSp(ByVal apsmode As String, ByVal infcap As Decimal?) As Integer
        Dim iPlanningModeExt As IPlanningMode = New PlanningModeFactory().Create(Me, True)
        Dim result As Integer? = iPlanningModeExt.PlanningModeSp(apsmode, infcap)
        Dim Severity As Integer = result.Value
        Return Severity
    End Function
End Class
