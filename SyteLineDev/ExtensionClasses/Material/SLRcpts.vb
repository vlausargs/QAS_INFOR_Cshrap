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
Imports Microsoft.Extensions.DependencyInjection

<IDOExtensionClass("SLRcpts")> _
Public Class SLRcpts
    Inherits CSIExtensionClassBase

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CheckMrpWbExistsSp(ByVal FromItem As String, ByVal ToItem As String, ByRef MrpWbExists As Integer?, ByRef Infobar As String) As Integer
        Dim iCheckMrpWbExistsExt As ICheckMrpWbExists = Me.GetService(Of ICheckMrpWbExists)()

        Dim result As (ReturnCode As Integer?, oMrpWbExists As Integer?, oInfobar As String) = iCheckMrpWbExistsExt.CheckMrpWbExistsSp(FromItem, ToItem, MrpWbExists, Infobar)
        Dim Severity As Integer = result.ReturnCode.Value
        MrpWbExists = result.oMrpWbExists
        Infobar = result.oInfobar

        Return Severity
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DeleteMrpWbAndFirmJobSp(ByVal Item As String, ByVal Job As String, ByVal Suffix As Short?, ByVal RefNum As String, ByVal FromWorkbench As Byte?,
<[Optional]> ByVal ReleaseDate As DateTime?,
<[Optional]> ByVal DueDate As DateTime?,
<[Optional], DefaultParameterValue(0)> ByVal ReqdQty As Decimal?,
<[Optional]> ByVal RefType As String,
<[Optional], DefaultParameterValue(0)> ByVal RefLineSuf As Short?,
<[Optional], DefaultParameterValue(0)> ByVal RefRelease As Short?,
<[Optional], DefaultParameterValue(0)> ByVal RefSeq As Integer?,
<[Optional]> ByVal Whse As String,
<[Optional], DefaultParameterValue(CByte(0))> ByVal CopyCurrentBOM As Byte?,
<[Optional], DefaultParameterValue(CByte(0))> ByVal CopyIndentedBOM As Byte?,
<[Optional]> ByVal SessionID As Guid?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iDeleteMrpWbAndFirmJobExt As IDeleteMrpWbAndFirmJob = New DeleteMrpWbAndFirmJobFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iDeleteMrpWbAndFirmJobExt.DeleteMrpWbAndFirmJobSp(Item, Job, Suffix, RefNum, FromWorkbench, ReleaseDate, DueDate, ReqdQty, RefType, RefLineSuf, RefRelease, RefSeq, Whse, CopyCurrentBOM, CopyIndentedBOM, SessionID, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GuidSystemParCanAnySp(ByVal Type1 As String, ByVal FormName1 As String, ByVal Type2 As String, ByVal FormName2 As String, ByRef Privilege1 As Short?, ByRef Privilege2 As Short?, ByRef GUID As Guid?, ByRef ApsParmApsmode As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iGuidSystemParCanAnyExt As IGuidSystemParCanAny = New GuidSystemParCanAnyFactory().Create(appDb)

            Dim oPrivilege1 As PrivilegeType = Privilege1
            Dim oPrivilege2 As PrivilegeType = Privilege2
            Dim oGUID As GuidType = GUID
            Dim oApsParmApsmode As ApsModeType = ApsParmApsmode
            Dim oInfobar As InfobarType = Infobar

            Dim Severity As Integer = iGuidSystemParCanAnyExt.GuidSystemParCanAnySp(Type1, FormName1, Type2, FormName2, oPrivilege1, oPrivilege2, oGUID, oApsParmApsmode, oInfobar)

            Privilege1 = oPrivilege1
            Privilege2 = oPrivilege2
            GUID = oGUID
            ApsParmApsmode = oApsParmApsmode
            Infobar = oInfobar

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function MpsGenSp(ByVal FromPlanCode As String, ByVal ToPlanCode As String, ByVal FromItem As String, ByVal ToItem As String,
<[Optional], DefaultParameterValue(CByte(0))> ByVal DeleteMrpWb As Byte?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iMpsGenExt As IMpsGen = New MpsGenFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iMpsGenExt.MpsGenSp(FromPlanCode, ToPlanCode, FromItem, ToItem, DeleteMrpWb, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function RcptsLeaveDueDateSp(ByVal DueDate As DateTime?, ByVal Item As String, ByVal NewRowPointer As Guid?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iRcptsLeaveDueDateExt As IRcptsLeaveDueDate = New RcptsLeaveDueDateFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iRcptsLeaveDueDateExt.RcptsLeaveDueDateSp(DueDate, Item, NewRowPointer, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function
End Class

