Option Explicit On
Option Strict On

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common
Imports System.Xml
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Soap
Imports CSI.Data.SQL.UDDT
Imports System
Imports System.Data
Imports CSI.Finance.Chinese
Imports CSI.MG
Imports System.Runtime.InteropServices
Imports CSI.Data.CRUD
Imports CSI.Data.RecordSets
Imports Microsoft.Extensions.DependencyInjection
'// <Ref>System.Runtime.Serialization.Formatters.Soap.dll</Ref>
<IDOExtensionClass("CHJournals")> _
Public Class CHJournals

    Inherits CSIExtensionClassBase

    Public Function CHSImportJournalVb(ByVal sData As String, ByVal ControlNumber As String, ByVal SessionId As String, ByRef Infobar As String) As Integer
        On Error GoTo ImportFailedErrHandler

        Dim intRetValue As InvokeResponseData
        Dim i As Integer

        Dim TransNum As Object
        Dim Acct As Object
        Dim TransDate As Object
        Dim DomAmt As Object
        Dim Ref As Object
        Dim VendNum As Object
        Dim Voucher As Object
        Dim CheckNum As Object
        Dim CheckDate As Object
        Dim FromSite As Object
        Dim FromId As Object
        Dim VouchSeq As Object
        Dim RefType As Object
        Dim MatlTransNum As Object
        Dim DTransNum As Object
        Dim BankCode As Object
        Dim AcctUnit1 As Object
        Dim AcctUnit2 As Object
        Dim AcctUnit3 As Object
        Dim AcctUnit4 As Object
        Dim CurrCode As Object
        Dim ExchRate As Object
        Dim ForAmount As Object
        Dim Site As Object
        Dim Hierarchy As Object
        Dim Consolidated As Object
        Dim ControlPrefix As Object
        Dim ControlSite As Object
        Dim ControlYear As Object
        Dim ControlPeriod As Object
        Dim iControlNumber As Object
        Dim iYear As Object
        Dim iPeriod As Object
        Dim CHVouNum As Object
        Dim Line As Object

        'destination array
        Dim arrInput(,) As Object
        Dim oXmlFormatter As SoapFormatter
        Dim oMemStream As MemoryStream
        Dim oWriter As StreamWriter


        intRetValue = Me.Invoke("CHSInputJournalDelSp", SessionId, IDONull.Value)

        If intRetValue.IsReturnValueStdError Then
            Infobar = intRetValue.Parameters(1).Value
            GoTo ImportFailedErrHandler
        End If

        'sData is an array that had been serialized using SOAPFormatter and passed to this method
        'Deserialize the string back to get the array
        oXmlFormatter = New SoapFormatter
        oMemStream = New MemoryStream
        oWriter = New StreamWriter(oMemStream)
        oWriter.Write(sData)
        oWriter.Flush()
        oMemStream.Seek(0, SeekOrigin.Begin)
        arrInput = CType(oXmlFormatter.Deserialize(oMemStream), Object(,))
        oXmlFormatter = Nothing
        oMemStream.Close()
        oMemStream = Nothing
        oWriter.Close()
        oWriter = Nothing
        i = 0

        Do While i <= UBound(arrInput, 2)


            TransNum = arrInput(0, i)
            If (String.IsNullOrEmpty(TransNum.ToString)) Then
                TransNum = 0
            Else
                TransNum = CDec(TransNum)
            End If

            Acct = arrInput(1, i)

            TransDate = arrInput(2, i)
            If (String.IsNullOrEmpty(TransDate.ToString)) Then
                TransDate = IDONull.Value
            Else
                TransDate = CDate(TransDate)
            End If

            DomAmt = arrInput(3, i)
            If (String.IsNullOrEmpty(DomAmt.ToString)) Then
                DomAmt = 0
            Else
                DomAmt = CDec(DomAmt)
            End If

            Ref = arrInput(4, i)
            VendNum = arrInput(5, i)

            Voucher = arrInput(6, i)

            CheckNum = arrInput(7, i)
            If (String.IsNullOrEmpty(CheckNum.ToString)) Then
                CheckNum = 0
            Else
                CheckNum = CLng(CheckNum)
            End If

            CheckDate = arrInput(8, i)
            If (String.IsNullOrEmpty(CheckDate.ToString)) Then
                CheckDate = IDONull.Value
            Else
                CheckDate = CDate(CheckDate)
            End If

            FromSite = arrInput(9, i)
            FromId = arrInput(10, i)

            VouchSeq = arrInput(11, i)
            If (String.IsNullOrEmpty(VouchSeq.ToString)) Then
                VouchSeq = 0
            Else
                VouchSeq = CLng(VouchSeq)
            End If

            RefType = arrInput(12, i)

            MatlTransNum = arrInput(13, i)
            If (String.IsNullOrEmpty(MatlTransNum.ToString)) Then
                MatlTransNum = 0
            Else
                MatlTransNum = CDec(MatlTransNum)
            End If

            DTransNum = arrInput(14, i)
            If (String.IsNullOrEmpty(DTransNum.ToString)) Then
                DTransNum = 0
            Else
                DTransNum = CDec(DTransNum)
            End If

            BankCode = arrInput(15, i)
            AcctUnit1 = arrInput(16, i)
            AcctUnit2 = arrInput(17, i)
            AcctUnit3 = arrInput(18, i)
            AcctUnit4 = arrInput(19, i)
            CurrCode = arrInput(20, i)

            ExchRate = arrInput(21, i)
            If (String.IsNullOrEmpty(ExchRate.ToString)) Then
                ExchRate = 0
            Else
                ExchRate = CDec(ExchRate)
            End If

            ForAmount = arrInput(22, i)
            If (String.IsNullOrEmpty(ForAmount.ToString)) Then
                ForAmount = 0
            Else
                ForAmount = CDec(ForAmount)
            End If

            Site = arrInput(23, i).ToString
            Hierarchy = arrInput(24, i)
            Consolidated = arrInput(25, i)
            ControlPrefix = arrInput(26, i)
            ControlSite = arrInput(27, i)

            ControlYear = arrInput(28, i)
            If String.IsNullOrEmpty(ControlYear.ToString) Then
                ControlYear = 0
            Else
                ControlYear = CInt(ControlYear)
            End If

            ControlPeriod = arrInput(29, i)
            If String.IsNullOrEmpty(ControlPeriod.ToString) Then
                ControlPeriod = 0
            Else
                ControlPeriod = CInt(ControlPeriod)
            End If

            iControlNumber = arrInput(30, i)
            If String.IsNullOrEmpty(iControlNumber.ToString) Then
                iControlNumber = 0
            Else
                iControlNumber = CInt(iControlNumber)
            End If

            iYear = arrInput(31, i)
            If String.IsNullOrEmpty(iYear.ToString) Then
                iYear = 0
            Else
                iYear = CInt(iYear)
            End If

            iPeriod = arrInput(32, i)
            If (String.IsNullOrEmpty(iPeriod.ToString)) Then
                iPeriod = 0
            Else
                iPeriod = CInt(iPeriod)
            End If

            CHVouNum = arrInput(33, i)
            If (String.IsNullOrEmpty(CHVouNum.ToString)) Then
                CHVouNum = IDONull.Value
            End If

            Line = arrInput(34, i)
            If (String.IsNullOrEmpty(Line.ToString)) Then
                Line = 0
            Else
                Line = CInt(Line)
            End If


            intRetValue = Me.Invoke("CHSInputJournalInsSp", TransNum, Acct, TransDate, DomAmt, _
                            Ref, VendNum, Voucher, CheckNum, CheckDate, _
                            FromSite, FromId, VouchSeq, RefType, MatlTransNum, _
                            DTransNum, BankCode, AcctUnit1, AcctUnit2, AcctUnit3, _
                            AcctUnit4, CurrCode, ExchRate, ForAmount, Site, _
                            Hierarchy, Consolidated, ControlPrefix, ControlSite, ControlYear, _
                            ControlPeriod, iControlNumber, iYear, iPeriod, CHVouNum, _
                            Line, SessionId, IDONull.Value)

            If intRetValue.IsReturnValueStdError Then
                Infobar = intRetValue.Parameters(36).Value
                GoTo ImportFailedErrHandler
                Exit Do
            End If
            i = i + 1
        Loop

        intRetValue = Me.Invoke("CHSInputJournalSp", SessionId, ControlNumber, IDONull.Value)

        If intRetValue.IsReturnValueStdError Then
            Infobar = intRetValue.Parameters(2).Value
            GoTo ImportFailedErrHandler
        End If
        Exit Function

ImportFailedErrHandler:
        If Err.Number > 0 Then
            Infobar = Err.Description
        End If
        CHSImportJournalVb = 16
    End Function


    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CHSCLM_LoadJournalSp(ByVal Id As String, ByVal TransDate As DateTime?,
<[Optional]> ByVal FilterString As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As CSI.MG.IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim iCHSCLM_LoadJournalExt As ICHSCLM_LoadJournal = New CHSCLM_LoadJournalFactory().Create(appDb, bunchedLoadCollection)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iCHSCLM_LoadJournalExt.CHSCLM_LoadJournalSp(Id, TransDate, FilterString)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CHSCLM_LoadSystemVouchersSp() As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As CSI.MG.IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim iCHSCLM_LoadSystemVouchersExt As ICHSCLM_LoadSystemVouchers = New CHSCLM_LoadSystemVouchersFactory().Create(appDb, bunchedLoadCollection)
            Dim dt As DataTable = iCHSCLM_LoadSystemVouchersExt.CHSCLM_LoadSystemVouchersSp()
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CHSJournalSyncSp(ByVal Id As String, ByVal TransDate As DateTime?, ByVal UserName As String, ByRef InfoBar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iCHSJournalSyncExt As ICHSJournalSync = New CHSJournalSyncFactory().Create(appDb)
            Dim oInfoBar As InfobarType = InfoBar
            Dim Severity As Integer = iCHSJournalSyncExt.CHSJournalSyncSp(Id, TransDate, UserName, oInfoBar)
            InfoBar = oInfoBar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CHSUpdateJournalRefSp(ByVal CHVounum As String, ByVal TransDate As DateTime?, ByVal Ref As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iCHSUpdateJournalRefExt As ICHSUpdateJournalRef = New CHSUpdateJournalRefFactory().Create(appDb)
            Dim oInfobar As InfobarType = Infobar
            Dim Severity As Integer = iCHSUpdateJournalRefExt.CHSUpdateJournalRefSp(CHVounum, TransDate, Ref, oInfobar)
            Infobar = oInfobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CHSCLM_ListVouchersSp(
        <[Optional]> ByVal FilterString As String) As DataTable
        Dim iCHSCLM_ListVouchersExt As ICHSCLM_ListVouchers = Me.GetService(Of ICHSCLM_ListVouchers)()
        Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iCHSCLM_ListVouchersExt.CHSCLM_ListVouchersSp(FilterString)
        Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
        Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
        Return dt
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CHSInputJournalDelSp(ByVal SessionId As Guid?, ByRef Infobar As String) As Integer

        Dim iCHSInputJournalDelExt As ICHSInputJournalDel = New CHSInputJournalDelFactory().Create(Me, True)
        Dim result As (ReturnCode As Integer?, Infobar As String) = iCHSInputJournalDelExt.CHSInputJournalDelSp(SessionId, Infobar)
        Return result.ReturnCode.Value

    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CHSInputJournalInsSp(ByVal TransNum As Decimal?, ByVal Acct As String, ByVal TransDate As DateTime?, ByVal DomAmt As Decimal?, ByVal Ref As String, ByVal VendNum As String, ByVal Voucher As String, ByVal CheckNum As Integer?, ByVal CheckDate As DateTime?, ByVal FromSite As String, ByVal FromId As String, ByVal VouchSeq As Decimal?, ByVal RefType As String, ByVal MatlTransNum As Decimal?, ByVal DTransNum As Decimal?, ByVal BankCode As String, ByVal AcctUnit1 As String, ByVal AcctUnit2 As String, ByVal AcctUnit3 As String, ByVal AcctUnit4 As String, ByVal CurrCode As String, ByVal ExchRate As Decimal?, ByVal ForAmount As Decimal?, ByVal Site As String, ByVal Hierarchy As String, ByVal Consolidated As String, ByVal ControlPrefix As String, ByVal ControlSite As String, ByVal ControlYear As Short?, ByVal ControlPeriod As Byte?, ByVal ControlNumber As Decimal?, ByVal Year As Short?, ByVal Period As Byte?, ByVal CHVouNum As String, ByVal Line As Integer?, ByVal SessionId As Guid?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCHSInputJournalInsExt As ICHSInputJournalIns = New CHSInputJournalInsFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iCHSInputJournalInsExt.CHSInputJournalInsSp(TransNum, Acct, TransDate, DomAmt, Ref, VendNum, Voucher, CheckNum, CheckDate, FromSite, FromId, VouchSeq, RefType, MatlTransNum, DTransNum, BankCode, AcctUnit1, AcctUnit2, AcctUnit3, AcctUnit4, CurrCode, ExchRate, ForAmount, Site, Hierarchy, Consolidated, ControlPrefix, ControlSite, ControlYear, ControlPeriod, ControlNumber, Year, Period, CHVouNum, Line, SessionId, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CHSInputJournalSp(ByVal SessionId As Guid?, ByVal ControlNumber As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iCHSInputJournalExt As ICHSInputJournal = New CHSInputJournalFactory().Create(appDb)

            Dim Severity As Integer = iCHSInputJournalExt.CHSInputJournalSp(SessionId, ControlNumber, Infobar)

            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CHSCLM_LoadVouchersSp(
<[Optional]> ByVal CHVounum As String,
<[Optional]> ByVal TransDate As DateTime?,
<[Optional]> ByVal FilterString As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim iCHSCLM_LoadVouchersExt As ICHSCLM_LoadVouchers = New CHSCLM_LoadVouchersFactory().Create(appDb, bunchedLoadCollection)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iCHSCLM_LoadVouchersExt.CHSCLM_LoadVouchersSp(CHVounum, TransDate, FilterString)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function
End Class

