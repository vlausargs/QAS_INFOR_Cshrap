Option Explicit On
Option Strict On

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common
Imports System.Data.SqlClient
Imports CSI.Logistics.Customer
Imports CSI.MG
Imports System.Runtime.InteropServices
Imports CSI.Logistics.Vendor
Imports CSI.Data.RecordSets
Imports CSI.Data.CRUD
Imports CSI.ExternalContracts.Portals

<IDOExtensionClass("SLRmas")>
Public Class SLRmas
    Inherits CSIExtensionClassBase
    Implements ISLRmas

    ' the following should take cust num and/or cust seq to format the address
    ' IdoCollectionSchema.AddDerivedPropertyDefinition "FormatAddress", "adr.name + CHAR(13) + CHAR(10) + Case when (len(IsNull(adr.addr##1, ''))>0)  then adr.addr##1 + CHAR(13) + CHAR(10) else '' End + Case when (len(IsNull(adr.addr##2, ''))>0)  then adr.addr##2 + CHAR(13) + CHAR(10) else '' end + Case when (len(IsNull(adr.addr##3, ''))>0)  then adr.addr##3 + CHAR(13) + CHAR(10) else '' end + adr.city + ' ' + adr.state + ' ' + adr.zip + CHAR(13) + CHAR(10) + adr.country", idoDTString, 255, idoPAReadOnly, ""
    <IDOMethod(MethodFlags.None)>
    Public Function FormatAddress(ByRef CustNum As String, ByRef CustSeq As Integer, ByRef AddressText As String) As Integer
        Dim oLoadResponseData As LoadCollectionResponseData
        Dim sTempAddress As System.Text.StringBuilder

        Try

            FormatAddress = 0
            sTempAddress = New System.Text.StringBuilder()

            oLoadResponseData = Me.Context.Commands.LoadCollection(
            "SLCustAddrs",
            "Name, Addr_1, Addr_2, Addr_3, Addr_4, City, State, Zip, Country",
            String.Format("CustNum = {0} AND CustSeq = {1}", SqlLiteral.Format(CustNum), SqlLiteral.Format(CustSeq)),
            String.Empty, 1)

            If oLoadResponseData.Items.Count = 1 Then
                Dim cityStateZip As String

                cityStateZip = String.Format(
                "{0} {1} {2}",
                oLoadResponseData(0, "City").Value,
                oLoadResponseData(0, "State").Value,
                oLoadResponseData(0, "Zip").Value)

                sTempAddress.AppendLine(oLoadResponseData(0, "Name").Value)
                If Not oLoadResponseData(0, "Addr_1").IsNull Then sTempAddress.AppendLine(oLoadResponseData(0, "Addr_1").Value)
                If Not oLoadResponseData(0, "Addr_2").IsNull Then sTempAddress.AppendLine(oLoadResponseData(0, "Addr_2").Value)
                If Not oLoadResponseData(0, "Addr_3").IsNull Then sTempAddress.AppendLine(oLoadResponseData(0, "Addr_3").Value)
                If Not oLoadResponseData(0, "Addr_4").IsNull Then sTempAddress.AppendLine(oLoadResponseData(0, "Addr_4").Value)
                sTempAddress.AppendLine(cityStateZip)
                sTempAddress.AppendLine(oLoadResponseData(0, "Country").Value)

                AddressText = sTempAddress.ToString()
            Else
                MGException.Throw(Me.GetMessageProvider.GetMessage("E=NoExist0", "@custaddr"))
            End If

            Return 0

        Catch ex As Exception
            MGException.Throw(MGException.ExtractMessages(ex))
        End Try
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function FormatAddressWhseSp(ByVal CustNum As String, ByVal CustSeq As Integer?, ByRef BillToAddress As String, ByRef ShipToAddress As String, ByRef Whse As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iFormatAddressWhseExt As IFormatAddressWhse = New FormatAddressWhseFactory().Create(appDb)

            Dim Severity As Integer = iFormatAddressWhseExt.FormatAddressWhseSp(CustNum, CustSeq, BillToAddress, ShipToAddress, Whse, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CreateRmaRequestSp(ByVal CustNum As String, ByVal TakenBy As String, ByVal LineItem As String, ByVal LineCustItem As String, ByVal LineQtyToReturnConv As Decimal?, ByVal CoNum As String, ByVal CoLine As Short?, ByVal CoRelease As Short?, ByVal LineReasonText As String, ByVal LineOrigInvNum As String, ByRef Infobar As String) As Integer Implements ISLRmas.CreateRmaRequestSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iCreateRmaRequestExt As ICreateRmaRequest = New CreateRmaRequestFactory().Create(appDb)

            Dim Severity As Integer = iCreateRmaRequestExt.CreateRmaRequestSp(CustNum, TakenBy, LineItem, LineCustItem, LineQtyToReturnConv, CoNum, CoLine, CoRelease, LineReasonText, LineOrigInvNum, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function RmaItemCloseHeaderSp(ByVal PRmaNum As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iRmaItemCloseHeaderExt As IRmaItemCloseHeader = New RmaItemCloseHeaderFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iRmaItemCloseHeaderExt.RmaItemCloseHeaderSp(PRmaNum, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function RMAReturnCheckSp(ByVal RMANum As String, ByVal CustNum As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iRMAReturnCheckExt As IRMAReturnCheck = New RMAReturnCheckFactory().Create(appDb)

            Dim Severity As Integer = iRMAReturnCheckExt.RMAReturnCheckSp(RMANum, CustNum, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function RmaStatusValidSp(ByVal RMANum As String, ByVal OldStatus As String, ByVal Status As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iRmaStatusValidExt As IRmaStatusValid = New RmaStatusValidFactory().Create(appDb)

            Dim Severity As Integer = iRmaStatusValidExt.RmaStatusValidSp(RMANum, OldStatus, Status, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PortalValidateRMARequestSp(ByVal CustNum As String, ByVal TakenBy As String, ByVal LineItem As String, ByVal LineCustItem As String, ByVal LineQtyToReturnConv As Decimal?, ByVal CoNum As String, ByVal CoLine As Short?, ByVal CoRelease As Short?, ByVal LineReasonText As String, ByVal LineOrigInvNum As String, ByRef Infobar As String) As Integer Implements ISLRmas.PortalValidateRmaRequestSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iPortalValidateRMARequestExt As IPortalValidateRmaRequest = New PortalValidateRmaRequestFactory().Create(appDb)

            Dim Severity As Integer = iPortalValidateRMARequestExt.PortalValidateRmaRequestSp(CustNum, TakenBy, LineItem, LineCustItem, LineQtyToReturnConv, CoNum, CoLine, CoRelease, LineReasonText, LineOrigInvNum, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_DomesticCurrencySp(ByVal CurrCode As String,
<[Optional], DefaultParameterValue(0)> ByVal UseBuyRate As Integer?,
<[Optional]> ByVal TRate As Decimal?,
<[Optional]> ByVal PossibleDate As DateTime?,
<[Optional]> ByVal Amount1 As Decimal?,
<[Optional]> ByVal Amount2 As Decimal?,
<[Optional]> ByVal Amount3 As Decimal?,
<[Optional]> ByVal Amount4 As Decimal?,
<[Optional]> ByVal Amount5 As Decimal?,
<[Optional]> ByVal Amount6 As Decimal?,
<[Optional]> ByVal Amount7 As Decimal?,
<[Optional]> ByVal Amount8 As Decimal?,
<[Optional]> ByVal Amount9 As Decimal?,
<[Optional]> ByVal Amount10 As Decimal?,
<[Optional]> ByVal Amount11 As Decimal?,
<[Optional]> ByVal Amount12 As Decimal?,
<[Optional]> ByVal Amount13 As Decimal?,
<[Optional]> ByVal Amount14 As Decimal?,
<[Optional]> ByVal Amount15 As Decimal?,
<[Optional]> ByVal Amount16 As Decimal?,
<[Optional]> ByVal Amount17 As Decimal?,
<[Optional]> ByVal Amount18 As Decimal?,
<[Optional]> ByVal Amount19 As Decimal?,
<[Optional]> ByVal Amount20 As Decimal?,
<[Optional]> ByVal Amount21 As Decimal?,
<[Optional]> ByVal Amount22 As Decimal?,
<[Optional]> ByVal Amount23 As Decimal?,
<[Optional]> ByVal Amount24 As Decimal?,
<[Optional]> ByVal Amount25 As Decimal?,
<[Optional]> ByVal Amount26 As Decimal?,
<[Optional]> ByVal Amount27 As Decimal?,
<[Optional]> ByVal Amount28 As Decimal?,
<[Optional]> ByVal Amount29 As Decimal?,
<[Optional]> ByVal Amount30 As Decimal?,
<[Optional]> ByVal Amount31 As Decimal?,
<[Optional]> ByVal Amount32 As Decimal?,
<[Optional]> ByVal Amount33 As Decimal?,
<[Optional]> ByVal Amount34 As Decimal?,
<[Optional]> ByVal Amount35 As Decimal?,
<[Optional]> ByVal Amount36 As Decimal?,
<[Optional]> ByVal Amount37 As Decimal?,
<[Optional]> ByVal Amount38 As Decimal?,
<[Optional]> ByVal Amount39 As Decimal?,
<[Optional]> ByVal Amount40 As Decimal?) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim iCLM_DomesticCurrencyExt As CSI.Logistics.Customer.ICLM_DomesticCurrency = New CSI.Logistics.Customer.CLM_DomesticCurrencyFactory().Create(Me, True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iCLM_DomesticCurrencyExt.CLM_DomesticCurrencySp(CurrCode, UseBuyRate, TRate, PossibleDate, Amount1, Amount2, Amount3, Amount4, Amount5, Amount6, Amount7, Amount8, Amount9, Amount10, Amount11, Amount12, Amount13, Amount14, Amount15, Amount16, Amount17, Amount18, Amount19, Amount20, Amount21, Amount22, Amount23, Amount24, Amount25, Amount26, Amount27, Amount28, Amount29, Amount30, Amount31, Amount32, Amount33, Amount34, Amount35, Amount36, Amount37, Amount38, Amount39, Amount40)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

End Class
