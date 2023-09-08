Option Explicit On
Option Strict On

Imports Mongoose.IDO
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.DataAccess
Imports Mongoose.Core.Common
Imports Mongoose.IDO.Protocol
Imports CSI.MG
Imports CSI.Logistics.Vendor
Imports System.Runtime.InteropServices

<IDOExtensionClass("SLPoparms")> _
Public Class SLPoparms
    Inherits ExtensionClassBase

    Private ReadOnly ParmsTable As String = "poparms"
    Public Function GetSystemParm(ByRef strParmValue As String, ByVal strParmName As String) As Integer
        GetSystemParm = 0

        Try
            Dim loadResponse As LoadCollectionResponseData
            loadResponse = Me.Context.Commands.LoadCollection("SLPoparms", strParmName, String.Empty, String.Empty, 0)

            strParmValue = loadResponse(0, strParmName).GetValue(String.Empty)
        Catch ex As Exception
            GetSystemParm = 16
            MGException.Throw(ex.Message)
        End Try

        Return GetSystemParm
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetParmVchrAuthorizeSp(ByRef VchrAuthorize As Byte?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iGetParmVchrAuthorizeExt As IGetParmVchrAuthorize = New GetParmVchrAuthorizeFactory().Create(appDb)

            Dim Severity As Integer = iGetParmVchrAuthorizeExt.GetParmVchrAuthorizeSp(VchrAuthorize)

            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetPoParmsSp(ByRef ParmsPostJour As Byte?, ByRef ParmsEcConvFact As Decimal?, ByRef PoParmsVendorRequired As Byte?, ByRef PoParmsAmendPo As Byte?, ByRef PoParmsPoChange As String,
<[Optional]> ByVal Site As String,
<[Optional]> ByRef PurOrdTemplate As Short?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iGetPoParmsExt As IGetPoParms = New GetPoParmsFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, ParmsPostJour As Byte?, ParmsEcConvFact As Decimal?, PoParmsVendorRequired As Byte?, PoParmsAmendPo As Byte?, PoParmsPoChange As String, PurOrdTemplate As Short?) = iGetPoParmsExt.GetPoParmsSp(ParmsPostJour, ParmsEcConvFact, PoParmsVendorRequired, PoParmsAmendPo, PoParmsPoChange, Site, PurOrdTemplate)
            Dim Severity As Integer = result.ReturnCode.Value
            ParmsPostJour = result.ParmsPostJour
            ParmsEcConvFact = result.ParmsEcConvFact
            PoParmsVendorRequired = result.PoParmsVendorRequired
            PoParmsAmendPo = result.PoParmsAmendPo
            PoParmsPoChange = result.PoParmsPoChange
            PurOrdTemplate = result.PurOrdTemplate
            Return Severity
        End Using
    End Function
End Class