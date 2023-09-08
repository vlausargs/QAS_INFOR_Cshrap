Option Explicit On
Option Strict On

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common

Imports CSI.Data.SQL.UDDT
Imports CSI.Material
Imports CSI.MG
Imports System.Runtime.InteropServices

<IDOExtensionClass("SLForecasts")> _
Public Class SLForecasts
    Inherits Mongoose.IDO.ExtensionClassBase

    Public Overrides Sub SetContext(ByVal context As Mongoose.IDO.IIDOExtensionClassContext)
        MyBase.SetContext(context)
        ' Add event handlers for pre and post UpdateCollection
        AddHandler Me.Context.IDO.PreUpdateCollection, AddressOf Me.PreUpdateCollection
        AddHandler Me.Context.IDO.PostUpdateCollection, AddressOf Me.PostUpdateCollection
    End Sub

    Private Sub PreUpdateCollection(ByVal sender As Object, ByVal args As IDOEventArgs)
        Me.Context.Commands.Invoke("SLJobTrans", "ApsSyncDeferSp", IDONull.Value, "SLForecasts.PreUpdateCollection()")
        Me.Context.Commands.Invoke("DefineVariables", "DefineVariableSp", "BufferForecast", "1", IDONull.Value)
    End Sub

    Private Sub PostUpdateCollection(ByVal sender As Object, ByVal args As IDOEventArgs)
        Dim PInfobar As String = IDONull.Value.ToString
        Dim resp As InvokeResponseData

        resp = Me.Invoke("ForecastPostSaveSp", PInfobar)
        If resp.ReturnValue <> "0" Then
            MGException.Throw(resp.Parameters(0).GetValue(Of String)())
        End If
        Me.Context.Commands.Invoke("SLJobTrans", "ApsSyncImmediateSp", IDONull.Value, 0, "SLForecasts.PostUpdateCollection()")
    End Sub

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ForecastDateCalcSp(ByVal Item As String,
                                       ByVal Fcstdate As DateTime?,
                                       ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iForecastDateCalcExt As IForecastDateCalc = New ForecastDateCalcFactory().Create(appDb)

            Dim oInfobar As InfobarType = Infobar

            Dim Severity As Integer = iForecastDateCalcExt.ForecastDateCalcSp(Item, Fcstdate, oInfobar)

            Infobar = oInfobar

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ForecastPreDisplaySp(ByRef CanDueLTProjected As Short?, ByRef CanDueNEProjected As Short?, ByRef McalFirstDate As DateTime?, ByRef McalLastDate As DateTime?, ByRef ApsParmApsmode As String, ByRef MrpParmReqSrc As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iForecastPreDisplayExt As IForecastPreDisplay = New ForecastPreDisplayFactory().Create(appDb)

            Dim oCanDueLTProjected As PrivilegeType = CanDueLTProjected
            Dim oCanDueNEProjected As PrivilegeType = CanDueNEProjected
            Dim oMcalFirstDate As DateType = McalFirstDate
            Dim oMcalLastDate As DateType = McalLastDate
            Dim oApsParmApsmode As ApsModeType = ApsParmApsmode
            Dim oMrpParmReqSrc As MrpReqSrcType = MrpParmReqSrc
            Dim oInfobar As InfobarType = Infobar

            Dim Severity As Integer = iForecastPreDisplayExt.ForecastPreDisplaySp(oCanDueLTProjected, oCanDueNEProjected, oMcalFirstDate, oMcalLastDate, oApsParmApsmode, oMrpParmReqSrc, oInfobar)

            CanDueLTProjected = oCanDueLTProjected
            CanDueNEProjected = oCanDueNEProjected
            McalFirstDate = oMcalFirstDate
            McalLastDate = oMcalLastDate
            ApsParmApsmode = oApsParmApsmode
            MrpParmReqSrc = oMrpParmReqSrc
            Infobar = oInfobar

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ForecastCalcSp(ByVal Item As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iForecastCalcExt As IForecastCalc = New ForecastCalcFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iForecastCalcExt.ForecastCalcSp(Item)
            Dim Severity As Integer = result.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ForecastPostSaveSp(ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iForecastPostSaveExt As IForecastPostSave = New ForecastPostSaveFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iForecastPostSaveExt.ForecastPostSaveSp(Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function McalDateSp(ByRef McalFirst As DateTime?, ByRef McalLast As DateTime?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iMcalDateExt As IMcalDate = New McalDateFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, McalFirst As DateTime?, McalLast As DateTime?, Infobar As String) = iMcalDateExt.McalDateSp(McalFirst, McalLast, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            McalFirst = result.McalFirst
            McalLast = result.McalLast
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function
End Class
