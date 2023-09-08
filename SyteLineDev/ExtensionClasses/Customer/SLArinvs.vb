Option Explicit On
Option Strict On

Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Collections
Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common
Imports CSI.Data.SQL.UDDT
Imports CSI.MG
Imports CSI.Logistics.Customer
Imports CSI.Finance.AR
Imports System.Runtime.InteropServices
Imports CSI.Logistics.Vendor
Imports CSI.Data.RecordSets
Imports CSI.Data.CRUD
Imports Microsoft.Extensions.DependencyInjection

<IDOExtensionClass("SLArinvs")>
Public Class SLArinvs
    Inherits CSIExtensionClassBase
    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function VATImport_ValidateFiles(ByRef Infobar As String) As Integer
        Dim sImportDir As String = Nothing
        Dim sArchiveDir As String = Nothing

        Dim loadResponse As LoadCollectionResponseData
        Dim ResponseData As InvokeResponseData

        'Get the Import and Archive Directories from Order Entry Parameters
        loadResponse = Me.Context.Commands.LoadCollection("SLCoparms", "CNVATImportDir,CNVATArchiveDir", "ParmKey = 0", "", 0)
        For index As Integer = 0 To loadResponse.Items.Count - 1
            Try
                sImportDir = loadResponse(index, "CNVATImportDir").GetValue(Of String)()
            Catch ex As NullReferenceException
                sImportDir = ""
            End Try
            Try
                sArchiveDir = loadResponse(index, "CNVATArchiveDir").GetValue(Of String)()
            Catch ex As NullReferenceException
                sArchiveDir = ""
            End Try
        Next

        'If no import directory specified in parms, nothing to do
        If String.IsNullOrEmpty(sImportDir) Then
            ResponseData = Me.Context.Commands.Invoke("ApplicationMessages", "MsgAppSp", Infobar _
               , "E=NoExist0", "@coparms.CN_vat_import_dir", "" _
               , "", "", "", "", "", "", "", "", "", "", "", "", "")
            Infobar = ResponseData.Parameters(0).GetValue(Of String)()
            VATImport_ValidateFiles = 16
            Return 16
        End If

        'If no archive directory specified in parms, nothing to do
        If String.IsNullOrEmpty(sArchiveDir) Then
            ResponseData = Me.Context.Commands.Invoke("ApplicationMessages", "MsgAppSp", Infobar _
               , "E=NoExist0", "@coparms.CN_vat_archive_dir", "" _
               , "", "", "", "", "", "", "", "", "", "", "", "", "")
            Infobar = ResponseData.Parameters(0).GetValue(Of String)()
            VATImport_ValidateFiles = 16
            Return 16
        End If

        Infobar = ""
        Return 0
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function VATImport_PreviewFiles() As DataTable
        Dim sImportDir As String = Nothing
        Dim loadResponse As LoadCollectionResponseData
        Dim errMsg As String = String.Empty
        Dim serverOper As SLServerOperations = New SLServerOperations()
        Dim fileOper As SLFileOperations = New SLFileOperations(serverOper)

        Try
            'Get the Import and Archive Directories from Order Entry Parameters
            loadResponse = Me.Context.Commands.LoadCollection("SLCoparms", "CNVATImportDir,CNVATArchiveDir", "ParmKey = 0", "", 0)
            For index As Integer = 0 To loadResponse.Items.Count - 1
                Try
                    sImportDir = loadResponse(index, "CNVATImportDir").GetValue(Of String)()
                Catch ex As NullReferenceException
                    sImportDir = ""
                End Try
            Next


            'Read files from the Import directory
            fileOper.LoadAllFile(sImportDir, errMsg)

        Catch ex As Exception
        Finally
            If serverOper IsNot Nothing Then
                If serverOper.AppDBConnection IsNot Nothing Then
                    serverOper.AppDBConnection.Dispose()
                    serverOper.AppDBConnection = Nothing
                End If
                serverOper.Dispose()
                serverOper = Nothing
            End If
        End Try

        Return BuildImportDataTable(fileOper.FilesContentDic)
    End Function

    Private Function BuildImportDataTable(ByVal filesContentDic As Dictionary(Of String, Collection)) As DataTable
        'Setup datatable
        Dim importDataTable As DataTable = New DataTable("ImportDataTable")
        Dim importDataDic As Dictionary(Of String, SLVatEntity) = New Dictionary(Of String, SLVatEntity)()
        Dim kv As KeyValuePair(Of String, SLVatEntity)
        importDataTable.Columns.Add("UbAction", GetType(Byte))
        importDataTable.Columns.Add("InvNum", GetType(String))
        importDataTable.Columns.Add("CNVATInvNum", GetType(String))
        importDataTable.Columns.Add("CNVATSalesTax", GetType(Decimal))
        importDataTable.Columns.Add("SalesTax", GetType(Decimal))

        FetchVatInfoIntoDic(filesContentDic, importDataDic)
        For Each kv In importDataDic
            Dim newrow As DataRow = importDataTable.NewRow()
            newrow("UbAction") = kv.Value.UbAction
            newrow("InvNum") = kv.Value.InvNum
            newrow("CNVATInvNum") = kv.Value.CNVATInvNum
            newrow("CNVATSalesTax") = kv.Value.CNVATSalesTax
            newrow("SalesTax") = kv.Value.SalesTax
            importDataTable.Rows.Add(newrow)
        Next

        Return importDataTable
    End Function

    Private Sub FetchVatInfoIntoDic(ByVal filesContentDic As Dictionary(Of String, Collection), ByRef importDataDic As Dictionary(Of String, SLVatEntity))
        Dim kv As KeyValuePair(Of String, Collection)
        Dim sqlScript As String = String.Empty

        Dim processID As String = String.Empty
        Dim queryResult As DataTable = New DataTable()

        For Each kv In filesContentDic
            For Each fileLine As String In kv.Value
                Dim vatEntity As SLVatEntity = New SLVatEntity()
                Dim strLine() As String
                Dim successBuildEntity As Boolean = True
                If fileLine = "SJJK0201" Then
                    Exit For
                End If
                Dim serOper As SLServerOperations = New SLServerOperations()
                strLine = Split(fileLine.Replace("~~", "`"), "`")
                Try

                    vatEntity.UbAction = Convert.ToByte(strLine(0))
                    vatEntity.CNVATInvNum = strLine(4)
                    vatEntity.InvNum = strLine(8)
                    vatEntity.CNVATSalesTax = Convert.ToDecimal(strLine(11))
                    sqlScript = "SELECT ISNULL((CASE WHEN (select top 1 tax_system from tax_system WHERE tax_mode = 'I') = 2 THEN sales_tax_2 ELSE sales_tax END),0) AS sales_tax, inv_num FROM arinv WHERE inv_num = dbo.ExpandKyByType('InvNumType', N'" + strLine(8) + "')"
                    queryResult = serOper.SelectData(sqlScript, processID)
                    If queryResult.Rows.Count > 0 Then
                        vatEntity.SalesTax = Convert.ToDecimal(queryResult.Rows(0).Item("sales_tax").ToString)
                    Else
                        successBuildEntity = False
                    End If
                Catch ex As Exception
                    successBuildEntity = False
                Finally
                    If serOper IsNot Nothing Then
                        If serOper.AppDBConnection IsNot Nothing Then
                            serOper.AppDBConnection.Dispose()
                            serOper.AppDBConnection = Nothing
                        End If
                        serOper.Dispose()
                        serOper = Nothing
                    End If
                End Try

                If successBuildEntity Then
                    If importDataDic.ContainsKey(vatEntity.InvNum) Then
                        importDataDic.Remove(vatEntity.InvNum)
                    End If
                    importDataDic.Add(vatEntity.InvNum, vatEntity)
                End If
            Next
        Next
    End Sub

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function VATImport_ProcessFiles(ByRef Infobar As String) As Integer
        Dim sImportDir As String = String.Empty
        Dim sArchiveDir As String = Nothing
        Dim loadResponse As LoadCollectionResponseData
        Dim ResponseData As InvokeResponseData
        Dim serverOper As SLServerOperations = New SLServerOperations()
        Dim fileOper As SLFileOperations = New SLFileOperations(serverOper)

        Try
            'Get the Import and Archive Directories from Order Entry Parameters
            loadResponse = Me.Context.Commands.LoadCollection("SLCoparms", "CNVATImportDir,CNVATArchiveDir", "ParmKey = 0", "", 0)
            For index As Integer = 0 To loadResponse.Items.Count - 1
                Try
                    sImportDir = loadResponse(index, "CNVATImportDir").GetValue(Of String)()
                Catch ex As NullReferenceException
                    sImportDir = ""
                End Try
                Try
                    sArchiveDir = loadResponse(index, "CNVATArchiveDir").GetValue(Of String)()
                Catch ex As NullReferenceException
                    sArchiveDir = ""
                End Try
            Next

            'If no import directory specified in parms, nothing to do
            If String.IsNullOrEmpty(sImportDir) Then
                ResponseData = Me.Context.Commands.Invoke("ApplicationMessages", "MsgAppSp", Infobar _
                   , "E=IsCompare", "@coparms.CN_vat_import_dir", "@!blank" _
                   , "", "", "", "", "", "", "", "", "", "", "", "", "")
                Infobar = ResponseData.Parameters(0).GetValue(Of String)()
                VATImport_ProcessFiles = 16
                Return 16
            End If

            'If no archive directory specified in parms, nothing to do
            If String.IsNullOrEmpty(sArchiveDir) Then
                ResponseData = Me.Context.Commands.Invoke("ApplicationMessages", "MsgAppSp", Infobar _
                   , "E=IsCompare", "@coparms.CN_vat_archive_dir", "@!blank" _
                   , "", "", "", "", "", "", "", "", "", "", "", "", "")
                Infobar = ResponseData.Parameters(0).GetValue(Of String)()
                VATImport_ProcessFiles = 16
                Return 16
            End If

            fileOper.ArchiveAllFile(sImportDir, sArchiveDir, Infobar)

            Infobar = ""

        Catch ex As Exception
        Finally
            If fileOper IsNot Nothing Then
                fileOper = Nothing
            End If
            If serverOper IsNot Nothing Then
                If serverOper.AppDBConnection IsNot Nothing Then
                    serverOper.AppDBConnection = Nothing
                End If
                serverOper = Nothing
            End If
        End Try

        Return 0
    End Function

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ArinvInvNumValidateCancellationSp(ByVal CustNum As String, ByVal InvNum As String, ByRef InvSeq As Integer?, ByRef ApplyToInvNum As String, ByRef Amount As Decimal?, ByRef Freight As Decimal?, ByRef MiscCharges As Decimal?, ByRef SalesTax As Decimal?, ByRef SalesTax2 As Decimal?, ByRef FixedRate As Byte?, ByRef ExchRate As Decimal?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iArinvInvNumValidateCancellationExt As IArinvInvNumValidateCancellation = New ArinvInvNumValidateCancellationFactory().Create(appDb)
            Dim oInvSeq As ArInvSeqType = InvSeq
            Dim oApplyToInvNum As InvNumType = ApplyToInvNum
            Dim oAmount As AmountType = Amount
            Dim oFreight As AmountType = Freight
            Dim oMiscCharges As AmountType = MiscCharges
            Dim oSalesTax As AmountType = SalesTax
            Dim oSalesTax2 As AmountType = SalesTax2
            Dim oFixedRate As ListYesNoType = FixedRate
            Dim oExchRate As ExchRateType = ExchRate
            Dim oInfobar As InfobarType = Infobar
            Dim Severity As Integer = iArinvInvNumValidateCancellationExt.ArinvInvNumValidateCancellationSp(CustNum, InvNum, oInvSeq, oApplyToInvNum, oAmount, oFreight, oMiscCharges, oSalesTax, oSalesTax2, oFixedRate, oExchRate, oInfobar)
            InvSeq = oInvSeq
            ApplyToInvNum = oApplyToInvNum
            Amount = oAmount
            Freight = oFreight
            MiscCharges = oMiscCharges
            SalesTax = oSalesTax
            SalesTax2 = oSalesTax2
            FixedRate = oFixedRate
            ExchRate = oExchRate
            Infobar = oInfobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_GetVATInvoiceInfoSp(ByVal CustNumStarting As String, ByVal CustNumEnding As String, ByVal CoNumStarting As String, ByVal CoNumEnding As String, ByVal InvNumStarting As String, ByVal InvNumEnding As String, ByVal InvDateStarting As DateTime?, ByVal InvDateEnding As DateTime?, ByVal FileType As String, ByVal CurrCode As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim iCLM_GetVATInvoiceInfoExt As ICLM_GetVATInvoiceInfo = New CLM_GetVATInvoiceInfoFactory().Create(appDb, bunchedLoadCollection)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iCLM_GetVATInvoiceInfoExt.CLM_GetVATInvoiceInfoSp(CustNumStarting, CustNumEnding, CoNumStarting, CoNumEnding, InvNumStarting, InvNumEnding, InvDateStarting, InvDateEnding, FileType, CurrCode)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GenerateVATFileSp(ByVal InvoiceList As String, ByVal FileType As String, ByVal pLanguage As String,
<[Optional]> ByRef VATExportLogicalFolder As String,
<[Optional]> ByRef FileName As String,
<[Optional]> ByRef FileContent As String, ByRef Infobar As String) As Integer
        Dim iGenerateVATFileExt As IGenerateVATFile = New GenerateVATFileFactory().Create(Me, True)
        Dim result As (ReturnCode As Integer?, VATExportLogicalFolder As String, FileName As String, FileContent As String, Infobar As String) = iGenerateVATFileExt.GenerateVATFileSp(InvoiceList, FileType, pLanguage, VATExportLogicalFolder, FileName, FileContent, Infobar)
        Dim Severity As Integer = result.ReturnCode.Value
        VATExportLogicalFolder = result.VATExportLogicalFolder
        FileName = result.FileName
        FileContent = result.FileContent
        Infobar = result.Infobar
        Return Severity
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetInvSequenceLockSp(ByVal InvNum As String, ByRef InfoBar As String) As Integer
        Dim iGetInvSequenceLockExt As IGetInvSequenceLock = New GetInvSequenceLockFactory().Create(Me, True)

        Dim oInfoBar As InfobarType = InfoBar


        Dim result As (ReturnCode As Integer?, Infobar As String) = iGetInvSequenceLockExt.GetInvSequenceLockSp(InvNum, oInfoBar)

        Dim Severity As Integer = result.ReturnCode.Value

        InfoBar = oInfoBar

        Return Severity

    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function InvoicesDebitAndCreditMemosSp(ByVal CustNum As String, ByVal CustSeq As Integer?, ByVal ArinvType As String, ByVal InvoiceDate As DateTime?, ByRef DueDate As DateTime?, ByRef CustType As String, ByRef TermsCode As String, ByRef PayType As String, ByRef TaxCode1 As String, ByRef TaxCode2 As String, ByRef CurrCode As String, ByRef ExchRate As Decimal?, ByRef CurrRateIsFixed As Byte?, ByRef UseExchRate As Byte?, ByRef Acct As String, ByRef AcctUnit1 As String, ByRef AcctUnit2 As String, ByRef AcctUnit3 As String, ByRef AcctUnit4 As String, ByRef AccessUnit1 As String, ByRef AccessUnit2 As String, ByRef AccessUnit3 As String, ByRef AccessUnit4 As String, ByRef Infobar As String, ByRef CustIncludePrice As Byte?, ByRef RevDayExist As Byte?, ByRef IsControl As Byte?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iInvoicesDebitAndCreditMemosExt As IInvoicesDebitAndCreditMemos = New InvoicesDebitAndCreditMemosFactory().Create(appDb)

            Dim oDueDate As DateType = DueDate
            Dim oCustType As CustTypeType = CustType
            Dim oTermsCode As TermsCodeType = TermsCode
            Dim oPayType As CustPayTypeType = PayType
            Dim oTaxCode1 As TaxCodeType = TaxCode1
            Dim oTaxCode2 As TaxCodeType = TaxCode2
            Dim oCurrCode As CurrCodeType = CurrCode
            Dim oExchRate As ExchRateType = ExchRate
            Dim oCurrRateIsFixed As ListYesNoType = CurrRateIsFixed
            Dim oUseExchRate As ListYesNoType = UseExchRate
            Dim oAcct As AcctType = Acct
            Dim oAcctUnit1 As UnitCode1Type = AcctUnit1
            Dim oAcctUnit2 As UnitCode2Type = AcctUnit2
            Dim oAcctUnit3 As UnitCode3Type = AcctUnit3
            Dim oAcctUnit4 As UnitCode4Type = AcctUnit4
            Dim oAccessUnit1 As UnitCodeAccessType = AccessUnit1
            Dim oAccessUnit2 As UnitCodeAccessType = AccessUnit2
            Dim oAccessUnit3 As UnitCodeAccessType = AccessUnit3
            Dim oAccessUnit4 As UnitCodeAccessType = AccessUnit4
            Dim oInfobar As Infobar = Infobar
            Dim oCustIncludePrice As ListYesNoType = CustIncludePrice
            Dim oRevDayExist As ListYesNoType = RevDayExist
            Dim oIsControl As ListYesNoType = IsControl

            Dim Severity As Integer = iInvoicesDebitAndCreditMemosExt.InvoicesDebitAndCreditMemosSp(CustNum, CustSeq, ArinvType, InvoiceDate, oDueDate, oCustType, oTermsCode, oPayType, oTaxCode1, oTaxCode2, oCurrCode, oExchRate, oCurrRateIsFixed, oUseExchRate, oAcct, oAcctUnit1, oAcctUnit2, oAcctUnit3, oAcctUnit4, oAccessUnit1, oAccessUnit2, oAccessUnit3, oAccessUnit4, oInfobar, oCustIncludePrice, oRevDayExist, oIsControl)

            DueDate = oDueDate
            CustType = oCustType
            TermsCode = oTermsCode
            PayType = oPayType
            TaxCode1 = oTaxCode1
            TaxCode2 = oTaxCode2
            CurrCode = oCurrCode
            ExchRate = oExchRate
            CurrRateIsFixed = oCurrRateIsFixed
            UseExchRate = oUseExchRate
            Acct = oAcct
            AcctUnit1 = oAcctUnit1
            AcctUnit2 = oAcctUnit2
            AcctUnit3 = oAcctUnit3
            AcctUnit4 = oAcctUnit4
            AccessUnit1 = oAccessUnit1
            AccessUnit2 = oAccessUnit2
            AccessUnit3 = oAccessUnit3
            AccessUnit4 = oAccessUnit4
            Infobar = oInfobar
            CustIncludePrice = oCustIncludePrice
            RevDayExist = oRevDayExist
            IsControl = oIsControl

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function InvPostingVerifyCloseFormSp(ByVal PSessionID As Guid?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iInvPostingVerifyCloseFormExt As IInvPostingVerifyCloseForm = New InvPostingVerifyCloseFormFactory().Create(appDb)

            Dim oInfobar As Infobar = Infobar

            Dim Severity As Integer = iInvPostingVerifyCloseFormExt.InvPostingVerifyCloseFormSp(PSessionID, oInfobar)

            Infobar = oInfobar

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function MultipleDueDateSp(ByVal TermsCode As String, ByRef MultiDueDate As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iMultipleDueDateExt As IMultipleDueDate = New MultipleDueDateFactory().Create(Me, True)

            Dim result As (ReturnCode As Integer?, MultiDueDate As Integer?) = iMultipleDueDateExt.MultipleDueDateSp(TermsCode, MultiDueDate)
            MultiDueDate = result.MultiDueDate
            Dim Severity As Integer = result.ReturnCode.Value
            Return Severity

        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ValidateCoNumSp(ByVal CoNum As String, ByRef PromptMsg As String, ByRef PromptButtons As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iValidateCoNumExt As IValidateCoNum = New ValidateCoNumFactory().Create(appDb)

            Dim oPromptMsg As InfobarType = PromptMsg
            Dim oPromptButtons As InfobarType = PromptButtons

            Dim Severity As Integer = iValidateCoNumExt.ValidateCoNumSp(CoNum, oPromptMsg, oPromptButtons)

            PromptMsg = oPromptMsg
            PromptButtons = oPromptButtons

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function Rpt_InvoicePayDaySp(
<[Optional]> ByVal PStartInvoice As String,
<[Optional]> ByVal PEndInvoice As String,
<[Optional]> ByVal PStartCustomer As String,
<[Optional]> ByVal PEndCustomer As String,
<[Optional], DefaultParameterValue(CByte(1))> ByVal PDisplayHeader As Byte?,
<[Optional]> ByVal pSite As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iRpt_InvoicePayDayExt As IRpt_InvoicePayDay = New Rpt_InvoicePayDayFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iRpt_InvoicePayDayExt.Rpt_InvoicePayDaySp(PStartInvoice, PEndInvoice, PStartCustomer, PEndCustomer, PDisplayHeader, pSite)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function AddARDueDateSeqSp(ByVal pCustNum As String, ByVal pInvNum As String, ByVal pInvSeq As Integer?, ByVal pInvoiceDate As DateTime?, ByVal pTermsCode As String, ByVal pMultiDueDateFlag As Byte?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iAddARDueDateSeqExt As IAddARDueDateSeq = New AddARDueDateSeqFactory().Create(appDb, MGInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iAddARDueDateSeqExt.AddARDueDateSeqSp(pCustNum, pInvNum, pInvSeq, pInvoiceDate, pTermsCode, pMultiDueDateFlag, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ArinvCalcTaxAmtSp(ByVal PInvDate As DateTime?, ByVal PTermsCode As String, ByVal PAmount As Decimal?, ByVal PFreight As Decimal?, ByVal PMisc As Decimal?, ByVal PCurrCode As String, ByVal PExchRate As Decimal?, ByVal PUseExchRate As Integer?, ByVal PPlaces As Integer?, ByVal PTaxCode1 As String, ByVal PTaxCode2 As String, ByRef PSalesTax1 As Decimal?, ByRef PSalesTax2 As Decimal?, ByRef Infobar As String, ByVal IncludeTaxInPrice As Integer?,
        <[Optional], DefaultParameterValue(0)> ByVal PCalledFromTrigger As Integer?, <[Optional]> ByVal PARInvRowPointer As Guid?, <[Optional], DefaultParameterValue(0)> ByRef PGrossSalesTax1 As Decimal?, <[Optional], DefaultParameterValue(0)> ByRef PGrossSalesTax2 As Decimal?, <[Optional], DefaultParameterValue(0)> ByRef PWithholdingTax1 As Decimal?, <[Optional], DefaultParameterValue(0)> ByRef PWithholdingTax2 As Decimal?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iArinvCalcTaxAmtExt As IArinvCalcTaxAmt = New ArinvCalcTaxAmtFactory().Create(Me, True)
            Dim result As (ReturnCode As Integer?, PsalesTax1 As Decimal?, PsalesTax2 As Decimal?, PGrossSalesTax1 As Decimal?, PGrossSalesTax2 As Decimal?, PWithholdingTax1 As Decimal?, PWithholdingTax2 As Decimal?, Inforbar As String) = iArinvCalcTaxAmtExt.ArinvCalcTaxAmtSp(PInvDate, PTermsCode, PAmount, PFreight, PMisc, PCurrCode, PExchRate, PUseExchRate, PPlaces, PTaxCode1, PTaxCode2, PSalesTax1, PSalesTax2, Infobar, IncludeTaxInPrice, PCalledFromTrigger, PARInvRowPointer, PGrossSalesTax1, PGrossSalesTax2, PWithholdingTax1, PWithholdingTax2)
            Dim Severity As Integer = result.ReturnCode.Value
            PSalesTax1 = result.PsalesTax1
            PSalesTax2 = result.PsalesTax2
            PGrossSalesTax1 = result.PGrossSalesTax1
            PGrossSalesTax2 = result.PGrossSalesTax2
            PWithholdingTax1 = result.PWithholdingTax1
            PWithholdingTax2 = result.PWithholdingTax2
            Infobar = result.Inforbar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ArinvCustomerInfoSp(ByVal CustNum As String, ByVal ArinvType As String, ByVal InvoiceDate As DateTime?, ByRef DueDate As DateTime?, ByRef CustType As String, ByRef TermsCode As String, ByRef PayType As String, ByRef TaxCode1 As String, ByRef TaxCode2 As String, ByRef CurrCode As String, ByRef ExchRate As Decimal?, ByRef CurrRateIsFixed As Integer?, ByRef UseExchRate As Integer?, ByRef Acct As String, ByRef AcctUnit1 As String, ByRef AcctUnit2 As String, ByRef AcctUnit3 As String, ByRef AcctUnit4 As String, ByRef AccessUnit1 As String, ByRef AccessUnit2 As String, ByRef AccessUnit3 As String, ByRef AccessUnit4 As String, ByRef Infobar As String, ByVal App_To_Inv_Num As String, ByRef IsControl As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iArinvCustomerInfoExt As IArinvCustomerInfo = New ArinvCustomerInfoFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, DueDate As DateTime?, CustType As String, TermsCode As String, PayType As String, TaxCode1 As String, TaxCode2 As String, CurrCode As String, ExchRate As Decimal?, CurrRateIsFixed As Integer?, UseExchRate As Integer?, Acct As String, AcctUnit1 As String, AcctUnit2 As String, AcctUnit3 As String, AcctUnit4 As String, AccessUnit1 As String, AccessUnit2 As String, AccessUnit3 As String, AccessUnit4 As String, Infobar As String, IsControl As Integer?) = iArinvCustomerInfoExt.ArinvCustomerInfoSp(CustNum, ArinvType, InvoiceDate, DueDate, CustType, TermsCode, PayType, TaxCode1, TaxCode2, CurrCode, ExchRate, CurrRateIsFixed, UseExchRate, Acct, AcctUnit1, AcctUnit2, AcctUnit3, AcctUnit4, AccessUnit1, AccessUnit2, AccessUnit3, AccessUnit4, Infobar, App_To_Inv_Num, IsControl)
            Dim Severity As Integer = result.ReturnCode.Value
            DueDate = result.DueDate
            CustType = result.CustType
            TermsCode = result.TermsCode
            PayType = result.PayType
            TaxCode1 = result.TaxCode1
            TaxCode2 = result.TaxCode2
            CurrCode = result.CurrCode
            ExchRate = result.ExchRate
            CurrRateIsFixed = result.CurrRateIsFixed
            UseExchRate = result.UseExchRate
            Acct = result.Acct
            AcctUnit1 = result.AcctUnit1
            AcctUnit2 = result.AcctUnit2
            AcctUnit3 = result.AcctUnit3
            AcctUnit4 = result.AcctUnit4
            AccessUnit1 = result.AccessUnit1
            AccessUnit2 = result.AccessUnit2
            AccessUnit3 = result.AccessUnit3
            AccessUnit4 = result.AccessUnit4
            Infobar = result.Infobar
            IsControl = result.IsControl
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ArinvgSp(ByVal PArinv As Guid?, ByRef Infobar As String,
        <[Optional]> ByVal EarnedRebateRowPointer As Guid?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iArinvgExt As IArinvg = New ArinvgFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Inforbar As String) = iArinvgExt.ArinvgSp(PArinv, Infobar, EarnedRebateRowPointer)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Inforbar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ArinvInvNumValidateSp(ByVal CustNum As String, ByVal ArinvType As String, ByVal InvNum As String, ByVal InvDate As DateTime?, ByVal CalledFrom As String, ByRef PromptMsg As String, ByRef Infobar As String,
<[Optional], DefaultParameterValue(CByte(0))> ByVal IsApplyToInvNum As Byte?,
<[Optional], DefaultParameterValue(Nothing)> ByRef CoNum As String,
<[Optional]> ByRef PCurrCode As String,
<[Optional]> ByRef PTaxDate As DateTime?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iArinvInvNumValidateExt As IArinvInvNumValidate = New ArinvInvNumValidateFactory().Create(appDb, MGInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PromptMsg As String, Infobar As String, CoNum As String, PCurrCode As String, PTaxDate As DateTime?) = iArinvInvNumValidateExt.ArinvInvNumValidateSp(CustNum, ArinvType, InvNum, InvDate, CalledFrom, PromptMsg, Infobar, IsApplyToInvNum, CoNum, PCurrCode, PTaxDate)
            Dim Severity As Integer = result.ReturnCode.Value
            PromptMsg = result.PromptMsg
            Infobar = result.Infobar
            CoNum = result.CoNum
            PCurrCode = result.PCurrCode
            PTaxDate = result.PTaxDate
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_GetInvoiceNoSp(ByVal CustNum As String,
    <[Optional], DefaultParameterValue(CByte(0))> ByVal Cancellation As Byte?) As DataTable
        Dim iCLM_GetInvoiceNoExt As ICLM_GetInvoiceNo = Me.GetService(Of ICLM_GetInvoiceNo)()
        Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iCLM_GetInvoiceNoExt.CLM_GetInvoiceNoSp(CustNum, Cancellation)
        Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
        Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
        Return dt
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CustomerRevDaySp(ByVal CustNum As String, ByRef RevDayExist As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iCustomerRevDayExt As ICustomerRevDay = New CustomerRevDayFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, RevDayExist As Integer?, Inforbar As String) = iCustomerRevDayExt.CustomerRevDaySp(CustNum, RevDayExist, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            RevDayExist = result.RevDayExist
            Infobar = result.Inforbar
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CustPriceIncludeTaxSp(ByVal CustNum As String, ByVal CustSeq As Integer?, ByRef CustIncludePrice As Integer?,
<[Optional]> ByVal PSite As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iCustPriceIncludeTaxExt As ICustPriceIncludeTax = New CustPriceIncludeTaxFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, CustIncludePrice As Integer?) = iCustPriceIncludeTaxExt.CustPriceIncludeTaxSp(CustNum, CustSeq, CustIncludePrice, PSite)
            Dim Severity As Integer = result.ReturnCode.Value
            CustIncludePrice = result.CustIncludePrice
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetCustExchRateSp(ByVal CustNum As String, ByVal CurrCode As String, ByVal InvoiceDate As DateTime?, ByRef ExchRate As Decimal?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iGetCustExchRateExt As IGetCustExchRate = New GetCustExchRateFactory().Create(appDb, MGInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, ExchRate As Decimal?, Infobar As String) = iGetCustExchRateExt.GetCustExchRateSp(CustNum, CurrCode, InvoiceDate, ExchRate, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            ExchRate = result.ExchRate
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetDueDateSp(ByVal ArinvType As String, ByVal TermsCode As String, ByVal InvoiceDate As DateTime?, ByRef DueDate As DateTime?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iGetDueDateExt As IGetDueDate = New GetDueDateFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, DueDate As DateTime?, Infobar As String) = iGetDueDateExt.GetDueDateSp(ArinvType, TermsCode, InvoiceDate, DueDate, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            DueDate = result.DueDate
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetKeyLengthSp(ByVal KeyName As String, ByRef KeyLength As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iGetKeyLengthExt As IGetKeyLength = New GetKeyLengthFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, KeyLength As Integer?, infobar As String) = iGetKeyLengthExt.GetKeyLengthSp(KeyName, KeyLength, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            KeyLength = result.KeyLength
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ImportVATFilesSp(ByVal PAction As Byte?, ByVal PInvNum As String, ByVal PVATInvNum As String, ByVal PVATSalesTax As Decimal?, ByVal PSalesTax As Decimal?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iImportVATFilesExt As IImportVATFiles = New ImportVATFilesFactory().Create(appDb, MGInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iImportVATFilesExt.ImportVATFilesSp(PAction, PInvNum, PVATInvNum, PVATSalesTax, PSalesTax)
            Dim Severity As Integer = result.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function ImportVATManagerSp(ByVal FilePath As String, ByVal Filenames As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iImportVATManagerExt As IImportVATManager = New ImportVATManagerFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iImportVATManagerExt.ImportVATManagerSp(FilePath, Filenames)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function InvoiceTableUpdSp(ByVal pInvNum As String, ByVal pInvSeq As Integer?, ByVal pPostFromCo As Byte?, ByVal pTaxDate As DateTime?, ByVal pExchRate As Decimal?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iInvoiceTableUpdExt As IInvoiceTableUpd = New InvoiceTableUpdFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iInvoiceTableUpdExt.InvoiceTableUpdSp(pInvNum, pInvSeq, pPostFromCo, pTaxDate, pExchRate, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function InvoiceTransactionSp(
        <[Optional]> ByVal pSessionIDChar As String,
        <[Optional]> ByVal pCallingProgram As Integer?,
        <[Optional]> ByVal pStartingCustNum As String,
        <[Optional]> ByVal pEndingCustNum As String,
        <[Optional]> ByVal pStartingInvNumber As String,
        <[Optional]> ByVal pEndingInvNumber As String,
        <[Optional]> ByVal pStartingInvDate As DateTime?,
        <[Optional]> ByVal pEndingInvDate As DateTime?,
        <[Optional]> ByVal pStartingDueDate As DateTime?,
        <[Optional]> ByVal pEndingDueDate As DateTime?,
        <[Optional]> ByVal pInvoice As String,
        <[Optional]> ByVal pDebitMemo As String,
        <[Optional]> ByVal pCreditMemo As String,
        <[Optional]> ByVal pDisplayTotals As Integer?,
        <[Optional]> ByVal pSortByInvoice As Integer?,
        <[Optional]> ByVal pDisplayHeader As Integer?,
        <[Optional]> ByVal pSite As String,
        <[Optional]> ByVal pToSite As String,
        <[Optional]> ByVal pStartBuilderInvNum As String,
        <[Optional]> ByVal pEndBuilderInvNum As String,
        <[Optional]> ByVal pSeperateDRandCRtot As Integer?,
        <[Optional]> ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iInvoiceTransactionExt As IInvoiceTransaction = New InvoiceTransactionFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iInvoiceTransactionExt.InvoiceTransactionSp(pSessionIDChar, pCallingProgram, pStartingCustNum, pEndingCustNum, pStartingInvNumber, pEndingInvNumber, pStartingInvDate, pEndingInvDate, pStartingDueDate, pEndingDueDate, pInvoice, pDebitMemo, pCreditMemo, pDisplayTotals, pSortByInvoice, pDisplayHeader, pSite, pToSite, pStartBuilderInvNum, pEndBuilderInvNum, pSeperateDRandCRtot, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function InvoicingBGSp(ByVal SessionID As Guid?, ByVal InvoiceType As String, ByVal BGTaskName As String,
<[Optional], DefaultParameterValue("R")> ByVal InvType As String,
<[Optional], DefaultParameterValue("I")> ByVal InvCred As String,
<[Optional]> ByVal InvDate As DateTime?,
<[Optional]> ByVal StartCustomer As String,
<[Optional]> ByVal EndCustomer As String,
<[Optional]> ByVal StartOrderNum As String,
<[Optional]> ByVal EndOrderNum As String,
<[Optional]> ByVal StartLine As Short?,
<[Optional]> ByVal EndLine As Short?,
<[Optional]> ByVal StartRelease As Short?,
<[Optional]> ByVal EndRelease As Short?,
<[Optional]> ByVal StartLastShipDate As DateTime?,
<[Optional]> ByVal EndLastShipDate As DateTime?,
<[Optional]> ByVal StartPackNum As Integer?,
<[Optional]> ByVal EndPackNum As Integer?,
<[Optional], DefaultParameterValue(CByte(0))> ByVal CreateFromPackSlip As Byte?,
<[Optional], DefaultParameterValue("N")> ByVal pMooreForms As String,
<[Optional], DefaultParameterValue(CByte(0))> ByVal pNonDraftCust As Byte?,
<[Optional]> ByVal SelectedStartInvNum As String,
<[Optional], DefaultParameterValue(CByte(0))> ByVal CheckShipItemActiveFlag As Byte?,
<[Optional], DefaultParameterValue("")> ByRef StartInvNum As String,
<[Optional], DefaultParameterValue("")> ByRef EndInvNum As String,
<[Optional], DefaultParameterValue("CI")> ByVal PrintItemCustomerItem As String,
<[Optional], DefaultParameterValue(CByte(0))> ByVal TransToDomCurr As Byte?,
<[Optional], DefaultParameterValue(CByte(1))> ByVal PrintSerialNumbers As Byte?,
<[Optional], DefaultParameterValue(CByte(0))> ByVal PrintPlanItemMaterial As Byte?,
<[Optional], DefaultParameterValue("N")> ByVal PrintConfigurationDetail As String,
<[Optional], DefaultParameterValue(CByte(0))> ByVal PrintEuro As Byte?,
<[Optional], DefaultParameterValue(CByte(1))> ByVal PrintCustomerNotes As Byte?,
<[Optional], DefaultParameterValue(CByte(1))> ByVal PrintOrderNotes As Byte?,
<[Optional], DefaultParameterValue(CByte(1))> ByVal PrintOrderLineNotes As Byte?,
<[Optional], DefaultParameterValue(CByte(1))> ByVal PrintOrderBlanketLineNotes As Byte?,
<[Optional], DefaultParameterValue(CByte(0))> ByVal PrintProgressiveBillingNotes As Byte?,
<[Optional], DefaultParameterValue(CByte(1))> ByVal PrintInternalNotes As Byte?,
<[Optional], DefaultParameterValue(CByte(1))> ByVal PrintExternalNotes As Byte?,
<[Optional], DefaultParameterValue(CByte(0))> ByVal PrintItemOverview As Byte?,
<[Optional], DefaultParameterValue(CByte(1))> ByVal DisplayHeader As Byte?,
<[Optional], DefaultParameterValue(CByte(1))> ByVal PrintLineReleaseDescription As Byte?,
<[Optional], DefaultParameterValue(CByte(1))> ByVal PrintStandardOrderText As Byte?,
<[Optional], DefaultParameterValue(CByte(1))> ByVal PrintBillToNotes As Byte?,
<[Optional]> ByVal LangCode As String,
<[Optional], DefaultParameterValue(CByte(0))> ByVal PrintDiscountAmt As Byte?,
<[Optional]> ByVal BatchId As Integer?,
<[Optional]> ByVal BGSessionId As String,
<[Optional]> ByVal UserId As Decimal?,
<[Optional]> ByRef Infobar As String,
<[Optional]> ByVal LCRVar As Byte?,
<[Optional]> ByVal pBegDoNum As String,
<[Optional]> ByVal pEndDoNum As String,
<[Optional]> ByVal pBegCustPo As String,
<[Optional]> ByVal pEndCustPo As String,
<[Optional]> ByRef DoHdrList As String,
<[Optional]> ByVal PItemTypeCust As Byte?,
<[Optional]> ByVal PItemTypeItem As Byte?,
<[Optional]> ByRef PrintConInvReport As Integer?,
<[Optional]> ByVal PInvNum As String,
<[Optional]> ByVal POrderNums As Byte?,
<[Optional]> ByVal PMiscCharges As Decimal?,
<[Optional]> ByVal PSalesTax As Decimal?,
<[Optional]> ByVal PFreight As Decimal?,
<[Optional]> ByVal TCustPT As String,
<[Optional]> ByVal PApplyToInvNum As String,
<[Optional]> ByVal TOpt As String,
<[Optional]> ByVal UseProfile As Byte?,
<[Optional], DefaultParameterValue("PROCESS")> ByVal Mode As String,
<[Optional], DefaultParameterValue(CByte(1))> ByVal PrintLotNumbers As Byte?,
<[Optional]> ByVal StartInvDate As DateTime?,
<[Optional]> ByVal EndInvDate As DateTime?,
<[Optional]> ByVal CurrentCultureName As String,
<[Optional]> ByVal StartingShipment As Decimal?,
<[Optional]> ByVal EndingShipment As Decimal?,
<[Optional]> ByVal CalledFrom As String,
<[Optional]> ByVal InvoicBuilderProcessID As Guid?,
<[Optional], DefaultParameterValue(CByte(0))> ByVal PrintDrawingNumber As Byte?,
<[Optional], DefaultParameterValue(CByte(0))> ByVal PrintTax As Byte?,
<[Optional], DefaultParameterValue(CByte(0))> ByVal PrintCurrencyCode As Byte?,
<[Optional], DefaultParameterValue(CByte(0))> ByVal PrintDeliveryIncoTerms As Byte?,
<[Optional], DefaultParameterValue(CByte(0))> ByVal PrintEUDetails As Byte?,
<[Optional], DefaultParameterValue(CByte(0))> ByVal PrintHeaderOnAllPages As Byte?,
<[Optional], DefaultParameterValue(CByte(0))> ByVal CreateFromShipment As Byte?,
<[Optional], DefaultParameterValue(CByte(0))> ByVal PrintTaxID As Byte?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iInvoicingBGExt As IInvoicingBG = New InvoicingBGFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, StartInvNum As String, EndInvNum As String, Infobar As String, DoHdrList As String, PrintConInvReport As Integer?) = iInvoicingBGExt.InvoicingBGSp(SessionID, InvoiceType, BGTaskName, InvType, InvCred, InvDate, StartCustomer, EndCustomer, StartOrderNum, EndOrderNum, StartLine, EndLine, StartRelease, EndRelease, StartLastShipDate, EndLastShipDate, StartPackNum, EndPackNum, CreateFromPackSlip, pMooreForms, pNonDraftCust, SelectedStartInvNum, CheckShipItemActiveFlag, StartInvNum, EndInvNum, PrintItemCustomerItem, TransToDomCurr, PrintSerialNumbers, PrintPlanItemMaterial, PrintConfigurationDetail, PrintEuro, PrintCustomerNotes, PrintOrderNotes, PrintOrderLineNotes, PrintOrderBlanketLineNotes, PrintProgressiveBillingNotes, PrintInternalNotes, PrintExternalNotes, PrintItemOverview, DisplayHeader, PrintLineReleaseDescription, PrintStandardOrderText, PrintBillToNotes, LangCode, PrintDiscountAmt, BatchId, BGSessionId, UserId, Infobar, LCRVar, pBegDoNum, pEndDoNum, pBegCustPo, pEndCustPo, DoHdrList, PItemTypeCust, PItemTypeItem, PrintConInvReport, PInvNum, POrderNums, PMiscCharges, PSalesTax, PFreight, TCustPT, PApplyToInvNum, TOpt, UseProfile, Mode, PrintLotNumbers, StartInvDate, EndInvDate, CurrentCultureName, StartingShipment, EndingShipment, CalledFrom, InvoicBuilderProcessID, PrintDrawingNumber, PrintTax, PrintCurrencyCode, PrintDeliveryIncoTerms, PrintEUDetails, PrintHeaderOnAllPages, CreateFromShipment, PrintTaxID)
            Dim Severity As Integer = result.ReturnCode.Value
            StartInvNum = result.StartInvNum
            EndInvNum = result.EndInvNum
            Infobar = result.Infobar
            DoHdrList = result.DoHdrList
            PrintConInvReport = result.PrintConInvReport
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function InvPostingArinvdSnapShotSp(ByVal PSessionID As Guid?, ByRef Infobar As String,
        <[Optional]> ByVal ToSite As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iInvPostingArinvdSnapShotExt As IInvPostingArinvdSnapShot = New InvPostingArinvdSnapShotFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iInvPostingArinvdSnapShotExt.InvPostingArinvdSnapShotSp(PSessionID, Infobar, ToSite)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function InvPostingAutoDistSp(ByVal PSessionID As Guid?, ByVal PCustNum As String, ByVal PInvNum As String, ByVal PInvSeq As Integer?, ByRef Infobar As String,
        <[Optional]> ByVal ToSite As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iInvPostingAutoDistExt As IInvPostingAutoDist = New InvPostingAutoDistFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iInvPostingAutoDistExt.InvPostingAutoDistSp(PSessionID, PCustNum, PInvNum, PInvSeq, Infobar, ToSite)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function InvPostingBGSp(
        <[Optional]> ByVal StartingCustNum As String,
        <[Optional]> ByVal EndingCustNum As String,
        <[Optional]> ByVal InvNumStarting As String,
        <[Optional]> ByVal InvNumEnding As String,
        <[Optional]> ByVal InvoiceDateStarting As DateTime?,
        <[Optional]> ByVal InvoiceDateEnding As DateTime?,
        <[Optional]> ByVal DueDateStarting As DateTime?,
        <[Optional]> ByVal DueDateEnding As DateTime?,
        <[Optional]> ByVal InvoiceFlag As String,
        <[Optional]> ByVal DebitMemoFlag As String,
        <[Optional]> ByVal CreditMemoFlag As String,
        <[Optional]> ByVal DisplayTotals As Integer?,
        <[Optional]> ByVal SortBy As Integer?,
        <[Optional]> ByVal DisplayHeader As Integer?,
        <[Optional]> ByVal SeparateDrCrAmounts As Integer?,
        <[Optional]> ByVal SessionIDChar As String,
        <[Optional]> ByVal ToSite As String,
        <[Optional]> ByVal StartBuilderInvNum As String,
        <[Optional]> ByVal EndBuilderInvNum As String,
        <[Optional]> ByVal PSite As String,
        <[Optional]> ByVal UserId As Decimal?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iInvPostingBGExt As IInvPostingBG = New InvPostingBGFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iInvPostingBGExt.InvPostingBGSp(StartingCustNum, EndingCustNum, InvNumStarting, InvNumEnding, InvoiceDateStarting, InvoiceDateEnding, DueDateStarting, DueDateEnding, InvoiceFlag, DebitMemoFlag, CreditMemoFlag, DisplayTotals, SortBy, DisplayHeader, SeparateDrCrAmounts, SessionIDChar, ToSite, StartBuilderInvNum, EndBuilderInvNum, PSite, UserId)
            Dim Severity As Integer = result.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function InvPostingCreateTTSp(ByVal PStartingCustNum As String, ByVal PEndingCustNum As String, ByVal PStartingInvNum As String, ByVal PEndingInvNum As String, ByVal PStartingInvDate As DateTime?, ByVal PEndingInvDate As DateTime?, ByVal PStartingDueDate As DateTime?, ByVal PEndingDueDate As DateTime?, ByVal PInvoice As String, ByVal PDebitMemo As String, ByVal PCreditMemo As String, ByVal PSessionID As Guid?,
        <[Optional]> ByVal StartBuilderInvNum As String,
        <[Optional]> ByVal EndBuilderInvNum As String,
        <[Optional]> ByVal ToSite As String,
        <[Optional], DefaultParameterValue(0)> ByVal CalledFromBackground As Integer?,
        <[Optional], DefaultParameterValue(0)> ByVal SkipResultSet As Integer?) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iInvPostingCreateTTExt As IInvPostingCreateTT = New InvPostingCreateTTFactory().Create(Me, True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iInvPostingCreateTTExt.InvPostingCreateTTSp(PStartingCustNum, PEndingCustNum, PStartingInvNum, PEndingInvNum, PStartingInvDate, PEndingInvDate, PStartingDueDate, PEndingDueDate, PInvoice, PDebitMemo, PCreditMemo, PSessionID, StartBuilderInvNum, EndBuilderInvNum, ToSite, CalledFromBackground, SkipResultSet)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function InvPostingDeleteTTSp(ByVal PSessionID As Guid?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iInvPostingDeleteTTExt As IInvPostingDeleteTT = New InvPostingDeleteTTFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iInvPostingDeleteTTExt.InvPostingDeleteTTSp(PSessionID)
            Dim Severity As Integer = result.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function InvPostingLockJournSp(ByVal PSessionID As Guid?, ByVal PUserID As Decimal?, ByRef PJHeaderRowPointer As Guid?, ByRef Infobar As String,
        <[Optional]> ByVal ToSite As String,
        <[Optional], DefaultParameterValue(1)> ByVal LockJournal As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iInvPostingLockJournExt As IInvPostingLockJourn = New InvPostingLockJournFactory().Create(Me, True)
            Dim result As (ReturnCode As Integer?, PJHeaderRowPointer As Guid?, Infobar As String) = iInvPostingLockJournExt.InvPostingLockJournSp(PSessionID, PUserID, PJHeaderRowPointer, Infobar, ToSite, LockJournal)
            Dim Severity As Integer = result.ReturnCode.Value
            PJHeaderRowPointer = result.PJHeaderRowPointer
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function InvPostingSp(ByVal PSessionID As Guid?, ByVal PCustNum As String, ByVal PInvNum As String, ByVal PInvSeq As Integer?, ByVal PJHeaderRowPointer As Guid?, ByRef PostExtFin As Integer?, ByRef ExtFinOperationCounter As Decimal?, ByRef Infobar As String,
        <[Optional]> ByVal ToSite As String,
        <[Optional]> ByVal PostSite As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iInvPostingExt As IInvPosting = New InvPostingFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PostExtFin As Integer?, ExtFinOperationCounter As Decimal?, Infobar As String) = iInvPostingExt.InvPostingSp(PSessionID, PCustNum, PInvNum, PInvSeq, PJHeaderRowPointer, PostExtFin, ExtFinOperationCounter, Infobar, ToSite, PostSite)
            Dim Severity As Integer = result.ReturnCode.Value
            PostExtFin = result.PostExtFin
            ExtFinOperationCounter = result.ExtFinOperationCounter
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function InvPostingVerifyPrintSp(ByRef PSessionID As Guid?, ByRef Infobar As String,
        <[Optional]> ByVal ToSite As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iInvPostingVerifyPrintExt As IInvPostingVerifyPrint = New InvPostingVerifyPrintFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PSessionID As Guid?, Infobar As String) = iInvPostingVerifyPrintExt.InvPostingVerifyPrintSp(PSessionID, Infobar, ToSite)
            Dim Severity As Integer = result.ReturnCode.Value
            PSessionID = result.PSessionID
            Infobar = result.Infobar
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

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetExchRateSp(ByVal CustNum As String, ByVal InvoiceDate As DateTime?, ByRef ExchRate As Decimal?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iGetExchRateExt As IGetExchRate = New GetExchRateFactory().Create(appDb, MGInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, ExchRate As Decimal?, Infobar As String) = iGetExchRateExt.GetExchRateSp(CustNum, InvoiceDate, ExchRate, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            ExchRate = result.ExchRate
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function
End Class
