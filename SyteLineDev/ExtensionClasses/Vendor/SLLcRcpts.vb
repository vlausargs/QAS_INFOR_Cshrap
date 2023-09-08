Option Explicit On
Option Strict On

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.Core.Common
Imports CSI.MG
Imports Mongoose.IDO.DataAccess
Imports CSI.Logistics.Vendor
Imports CSI.Data.CRUD
Imports System.Runtime.InteropServices
Imports CSI.Data.RecordSets

<IDOExtensionClass("SLLcRcpts")>
Public Class SLLcRcpts
    Inherits Mongoose.IDO.ExtensionClassBase

    Public Overrides Sub SetContext(ByVal context As Mongoose.IDO.IIDOExtensionClassContext)
        MyBase.SetContext(context)
        ' Add event handler for post UpdateCollection
        AddHandler Me.Context.IDO.PostUpdateCollection, AddressOf Me.PostUpdateCollection
    End Sub

    Private Sub PostUpdateCollection(ByVal sender As Object, ByVal args As IDOEventArgs)
        Dim process_id As String
        Dim updateRequest As UpdateCollectionRequestData
        Dim updateArgs As IDOUpdateEventArgs
        Dim bCustomUpdate As Boolean
        'Cast the args parameter as an IDOUpdateEventArgs
        updateArgs = CType(args, IDOUpdateEventArgs)

        If (updateArgs.ActionMask And (UpdateAction.Insert Or UpdateAction.Update)) = (UpdateAction.Insert Or UpdateAction.Update) Then

            updateRequest = CType(args.RequestPayload, UpdateCollectionRequestData)
            bCustomUpdate = (Len(updateRequest.CustomUpdate) > 0)
            If bCustomUpdate Then
                process_id = updateRequest.Items(0).Properties("UbProcessID").Value
                Me.Invoke("GenerateLCVouchersPostUpdSp", process_id)
            End If

        End If
    End Sub


    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_GenerateLCVouchersSp(ByVal VendNum As String, ByVal VendCurrCode As String, ByVal BeginReceiveDate As DateTime?, ByVal EndReceiveDate As DateTime?, ByVal SelectionMethod As String, ByVal LandedCostSelect As String,
<[Optional]> ByVal FilterString As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim iCLM_GenerateLCVouchersExt As ICLM_GenerateLCVouchers = New CLM_GenerateLCVouchersFactory().Create(appDb, bunchedLoadCollection)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iCLM_GenerateLCVouchersExt.CLM_GenerateLCVouchersSp(VendNum, VendCurrCode, BeginReceiveDate, EndReceiveDate, SelectionMethod, LandedCostSelect, FilterString)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GenerateLCVoucherCompStatusSp(ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iGenerateLCVoucherCompStatusExt As IGenerateLCVoucherCompStatus = New GenerateLCVoucherCompStatusFactory().Create(appDb)

            Dim Severity As Integer = iGenerateLCVoucherCompStatusExt.GenerateLCVoucherCompStatusSp(Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GenerateLCVouchersPocWarnSp(ByVal RefNum As String, ByVal RefType As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iGenerateLCVouchersPocWarnExt As IGenerateLCVouchersPocWarn = New GenerateLCVouchersPocWarnFactory().Create(appDb)

            Dim Severity As Integer = iGenerateLCVouchersPocWarnExt.GenerateLCVouchersPocWarnSp(RefNum, RefType, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GenerateLCVouchersPreUpdSp(ByVal VendNum As String, ByVal InvoiceDate As DateTime?, ByVal GLDistDate As DateTime?, ByVal VendorInvoice As String, ByVal VendExchRate As Decimal?, ByVal AmtBrokerage As Decimal?, ByVal AmtDuty As Decimal?, ByVal AmtFreight As Decimal?, ByVal AmtLocFreight As Decimal?, ByVal AmtInsurance As Decimal?, ByRef Infobar As String, ByVal AmtTax1 As Decimal?, ByVal AmtTax2 As Decimal?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iGenerateLCVouchersPreUpdExt As IGenerateLCVouchersPreUpd = New GenerateLCVouchersPreUpdFactory().Create(appDb)

            Dim Severity As Integer = iGenerateLCVouchersPreUpdExt.GenerateLCVouchersPreUpdSp(VendNum, InvoiceDate, GLDistDate, VendorInvoice, VendExchRate, AmtBrokerage, AmtDuty, AmtFreight, AmtLocFreight, AmtInsurance, Infobar, AmtTax1, AmtTax2)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GrnApprovedLineExistsSp(ByVal GrnNum As String, ByVal RefNum As String, ByVal RefLineSuf As Short?, ByVal RefRelease As Short?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iGrnApprovedLineExistsExt As IGrnApprovedLineExists = New GrnApprovedLineExistsFactory().Create(appDb)

            Dim Severity As Integer = iGrnApprovedLineExistsExt.GrnApprovedLineExistsSp(GrnNum, RefNum, RefLineSuf, RefRelease, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GenerateLCVouchersCustomUpdSp(ByVal ProcessId As Guid?, ByVal RefNum As String, ByVal RefLineSuf As Short?, ByVal RefRelease As Short?, ByVal RefType As String, ByVal LcType As String, ByVal RcvdDate As DateTime?, ByVal VendNum As String, ByVal DomAmtEstimate As Decimal?, ByVal AmtApplied As Decimal?, ByVal VchAmt As Decimal?, ByVal GrnNum As String, ByVal RcptAmtOvrd As Byte?, ByVal AmtFrnEst As Decimal?, ByVal DateSeq As Short?, ByVal UnitCost As Decimal?, ByVal DomUnitCost As Decimal?, ByVal QtyReceived As Decimal?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iGenerateLCVouchersCustomUpdExt As IGenerateLCVouchersCustomUpd = New GenerateLCVouchersCustomUpdFactory().Create(appDb, MGInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iGenerateLCVouchersCustomUpdExt.GenerateLCVouchersCustomUpdSp(ProcessId, RefNum, RefLineSuf, RefRelease, RefType, LcType, RcvdDate, VendNum, DomAmtEstimate, AmtApplied, VchAmt, GrnNum, RcptAmtOvrd, AmtFrnEst, DateSeq, UnitCost, DomUnitCost, QtyReceived)
            Dim Severity As Integer = result.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GenerateLCVouchersPostUpdSp(ByVal ProcessId As Guid?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iGenerateLCVouchersPostUpdExt As IGenerateLCVouchersPostUpd = New GenerateLCVouchersPostUpdFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iGenerateLCVouchersPostUpdExt.GenerateLCVouchersPostUpdSp(ProcessId)
            Dim Severity As Integer = result.Value
            Return Severity
        End Using
    End Function
End Class
