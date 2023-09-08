Option Explicit On
Option Strict On

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common

Imports CSI.Data.SQL.UDDT
Imports CSI.Production
Imports CSI.MG
Imports System.Runtime.InteropServices
Imports CSI.Data.CRUD
Imports CSI.Data.RecordSets
Imports CSI.ExternalContracts.FactoryTrack

<IDOExtensionClass("SLJobtMats")> _
Public Class SLJobtMats
    Inherits ExtensionClassBase
    Implements IExtFTSLJobtMats
    <IDOMethod(MethodFlags.None, "Infobar")> _
    Public Function PostAllJobtMatVB(ByVal StartTransNum As String, _
                                 ByVal EndTransNum As String, _
                                 ByVal StartJob As String, _
                                 ByVal EndJob As String, _
                                 ByVal StartSuffix As String, _
                                 ByVal EndSuffix As String, _
                                 ByVal StartTransDate As Nullable(Of DateTime), _
                                 ByVal EndTransDate As Nullable(Of DateTime), _
                                 ByVal StartEmpNum As String, _
                                 ByVal EndEmpNum As String, _
                                 ByVal StartLoc As String, _
                                 ByVal EndLoc As String, _
                                 ByVal StartItem As String, _
                                 ByVal EndItem As String, _
                                 ByVal ValidTransClass As String, _
                                 ByVal SessionID As String, _
                                 ByRef Infobar As String) As Integer Implements IExtFTSLJobtMats.PostAllJobtMatVB

        Dim oCollection As LoadCollectionResponseData
        Dim Filter As String = ""
        Dim ReturnCode As Integer
        Dim iGood As Integer
        Dim iBad As Integer
        Dim TransNum As String
        Dim TransSeq As String
        Dim StrStartTranDate As String
        Dim StrEndTranDate As String
        Dim oResponse As InvokeResponseData

        Try
            PostAllJobtMatVB = 0

            TransNum = String.Empty
            TransSeq = String.Empty

            If ValidTransClass.Length > 0 Then
                Filter = String.Format(" TransClass = '{0}' ", ValidTransClass.Chars(0))
            End If
            If ValidTransClass.Length > 1 Then
                Filter = Filter & String.Format(" OR TransClass = '{0}' ", ValidTransClass.Chars(1))
            End If
            If ValidTransClass.Length > 2 Then
                Filter = Filter & String.Format(" OR TransClass = '{0}' ", ValidTransClass.Chars(2))
            End If
            If ValidTransClass.Length > 3 Then
                Filter = Filter & String.Format(" OR TransClass = '{0}' ", ValidTransClass.Chars(3))
            End If
            Filter = If(String.IsNullOrEmpty(Filter), "", String.Format(" ( {0} ) ", Filter))

            If StartTransNum <> "" Then
                Filter = Filter & " AND TransNum >= " & StartTransNum
            End If
            If EndTransNum <> "" Then
                Filter = Filter & " AND TransNum <= " & EndTransNum
            End If
            If StartJob <> "" Then
                Filter = Filter & " AND Job >= '" & StartJob & "'"
            End If
            If EndJob <> "" Then
                Filter = Filter & " AND Job <= '" & EndJob & "'"
            End If

            If StartSuffix <> "" Then
                Filter = Filter & " AND Suffix >= CASE WHEN Job = '" & StartJob & "' THEN " _
                    & CStr(StartSuffix) & " ELSE (-32768) END"
            End If
            If EndSuffix <> "" Then
                Filter = Filter & " AND Suffix <= CASE WHEN Job = '" & EndJob & "' THEN " _
                    & CStr(EndSuffix) & " ELSE (32767) END"
            End If

            If Not IDONull.IsNull(StartTransDate) Then
                StrStartTranDate = Format(StartTransDate, "yyyy-MM-dd") & "T00:00:00.000"
                Filter = Filter & String.Format(" AND TransDate >= ({0})", SqlLiteral.Format(StrStartTranDate))
            End If

            If Not IDONull.IsNull(EndTransDate) Then
                StrEndTranDate = Format(EndTransDate, "yyyy-MM-dd") & "T23:59:59.997"
                Filter = Filter & String.Format(" AND TransDate <= ({0})", SqlLiteral.Format(StrEndTranDate))
            End If

            If StartEmpNum <> "" Then
                Filter = Filter & " AND EmpNum >= '" & StartEmpNum & "'"
            End If
            '  If an ending emp num is specified, but no starting emp num, get the null emp
            ' num values as well.  If start emp num is specified already, skip the NULL emp
            ' num values.  I believe this is what the Progress code did in SL6.
            If EndEmpNum <> "" Then
                If StartEmpNum = "" Then
                    Filter = Filter & " AND (EmpNum IS NULL OR EmpNum >= '" & EndEmpNum & "')"
                Else
                    Filter = Filter & " AND EmpNum <= '" & EndEmpNum & "'"
                End If
            End If
            If StartLoc <> "" Then
                Filter = Filter & " AND Loc >= '" & StartLoc & "'"
            End If
            If EndLoc <> "" Then
                If StartLoc = "" Then
                    Filter = Filter & " AND (Loc IS NULL OR Loc >= '" & EndLoc & "')"
                Else
                    Filter = Filter & " AND Loc <= '" & EndLoc & "'"
                End If
            End If
            If StartItem <> "" Then
                Filter = Filter & " AND Item >= '" & StartItem & "'"
            End If
            If EndItem <> "" Then
                Filter = Filter & " AND Item <= '" & EndItem & "'"
            End If

            oCollection = Me.LoadCollection("TransNum, TransSeq", Filter, "", 0)

            For index As Integer = 0 To oCollection.Items.Count - 1
                TransNum = oCollection(index, "TransNum").Value
                TransSeq = oCollection(index, "TransSeq").Value

                ReturnCode = JobtPost(TransNum, TransSeq, SessionID, Infobar)

                If ReturnCode <> 0 Then
                    iBad = iBad + 1
                    ReturnCode = JobtMatLogError(SessionID, TransNum, TransSeq, Infobar)

                    If ReturnCode <> 0 Then
                        MGException.Throw(Infobar)
                    End If
                Else
                    iGood = iGood + 1
                End If
            Next

            If iBad = 0 Then

                oResponse = Me.Context.Commands.Invoke("ApplicationMessages", "MsgAppSp", _
                                Infobar, "I=CmdSucceeded", "@%Process", "", _
                                "", "", "", "", "", "", "", "", "", "", "", "", "")
                ReturnCode = CInt(oResponse.ReturnValue)

                Infobar = oResponse.Parameters(0).Value
            Else

                oResponse = Me.Context.Commands.Invoke("ApplicationMessages", "MsgAppSp", _
                                Infobar, "I=#Invalid", iBad, "@jobt_mat", "", _
                                "", "", "", "", "", "", "", "", "", "", "", "")

                ReturnCode = CInt(oResponse.ReturnValue)
                Infobar = oResponse.Parameters(0).Value
            End If
            oResponse = Me.Context.Commands.Invoke("ApplicationMessages", "MsgAppSp", _
                            Infobar, "I=#Post", iGood, "@jobt_mat", _
                            "", "", "", "", "", "", "", "", "", "", "", "", "")

            ReturnCode = CInt(oResponse.ReturnValue)
            Infobar = Infobar & vbCrLf & oResponse.Parameters(0).Value
        Finally
            oResponse = Nothing
            oCollection = Nothing
        End Try
    End Function
    <IDOMethod(MethodFlags.RequiresTransaction, "Infobar")> _
    Private Function JobtPost(ByVal TransNum As String, _
                                ByVal TransSeq As String, _
                                ByVal SessionID As String, _
                                ByRef Infobar As String) As Integer
        Dim Response As InvokeResponseData

        JobtPost = 0
        Try
            Infobar = String.Empty

            Response = Me.Context.Commands.Invoke("SL.SLJobTrans", "JobtPostSp", SessionID, "SLJobtMats", TransNum, TransSeq, Infobar)
            Infobar = Response.Parameters(4).Value()

            'Commit the transaction only when the return value is less than 5.
            If CInt(Response.ReturnValue) > 5 Then
                MGException.Throw(Infobar)
            End If

        Catch ex As Exception
            Infobar = MGException.ExtractMessages(ex)
            JobtPost = 16
        End Try

    End Function
    <IDOMethod(MethodFlags.RequiresTransaction, "Infobar")> _
    Private Function JobtMatLogError(ByVal SessionID As String, _
                                        ByVal TransNum As String, _
                                        ByVal TransSeq As String, _
                                        ByRef Infobar As String) As Integer

        Dim Response As InvokeResponseData

        JobtMatLogError = 0
        Try
            Response = Me.Invoke("JobtMatLogErrorSp", SessionID, TransNum, TransSeq, Infobar)

            If CInt(Response.ReturnValue) > 5 Then
                Infobar = Response.Parameters(3).Value
                JobtMatLogError = 16
            Else
                Infobar = String.Empty
            End If

        Catch ex As Exception
            Infobar = MGException.ExtractMessages(ex)
            JobtMatLogError = 16
        End Try

    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PendingMaterialPostValidateSp(ByVal TransClass As String, ByVal StartingTransDate As DateTime?, ByVal EndingTransDate As DateTime?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iPendingMaterialPostValidateExt As IPendingMaterialPostValidate = New PendingMaterialPostValidateFactory().Create(appDb)

            Dim oInfobar As InfobarType = Infobar

            Dim Severity As Integer = iPendingMaterialPostValidateExt.PendingMaterialPostValidateSp(TransClass, StartingTransDate, EndingTransDate, oInfobar)

            Infobar = oInfobar

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_GetBatchedJobMatlsSp(ByVal Site As String, ByVal ProdBatchId As Integer?, ByVal JobmatlItem As String, ByVal JobmatlDesc As String, ByVal ExtScrap As Byte?, ByVal CurWhse As String, ByVal ShowBFlushMatls As Byte?, ByVal ContainerNum As String, ByRef Infobar As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim iCLM_GetBatchedJobMatlsExt As ICLM_GetBatchedJobMatls = New CLM_GetBatchedJobMatlsFactory().Create(appDb, bunchedLoadCollection)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?, Infobar As String) = iCLM_GetBatchedJobMatlsExt.CLM_GetBatchedJobMatlsSp(Site, ProdBatchId, JobmatlItem, JobmatlDesc, ExtScrap, CurWhse, ShowBFlushMatls, ContainerNum, Infobar)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Infobar = result.Infobar
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_JobMaterialKitBuilderSp(
<[Optional]> ByVal StartingItem As String,
<[Optional]> ByVal EndingItem As String,
<[Optional]> ByVal PlannerCode As String,
<[Optional]> ByVal StartingDueDate As DateTime?,
<[Optional]> ByVal EndingDueDate As DateTime?,
<[Optional]> ByVal FilterString As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim iCLM_JobMaterialKitBuilderExt As ICLM_JobMaterialKitBuilder = New CLM_JobMaterialKitBuilderFactory().Create(appDb, bunchedLoadCollection)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iCLM_JobMaterialKitBuilderExt.CLM_JobMaterialKitBuilderSp(StartingItem, EndingItem, PlannerCode, StartingDueDate, EndingDueDate, FilterString)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function BflushLotValSp(ByVal Whse As String, ByVal Lot As String, ByVal Selected As Byte?, ByVal JobMatlItem As String, ByVal Loc As String, ByRef Infobar As String, ByVal RefNum As String, ByVal OperNum As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iBflushLotValExt As IBflushLotVal = New BflushLotValFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iBflushLotValExt.BflushLotValSp(Whse, Lot, Selected, JobMatlItem, Loc, Infobar, RefNum, OperNum)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function JobtMatLogErrorSp(ByVal SessionId As Guid?, ByVal PTransNum As Decimal?, ByVal PTransSeq As Integer?, ByVal ErrorMsg As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iJobtMatLogErrorExt As IJobtMatLogError = New JobtMatLogErrorFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iJobtMatLogErrorExt.JobtMatLogErrorSp(SessionId, PTransNum, PTransSeq, ErrorMsg)
            Dim Severity As Integer = result.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function Rpt_PendingMaterialTransactionsSp(ByVal PTransNumStarting As Decimal?, ByVal PTransNumEnding As Decimal?, ByVal PTransDateStarting As DateTime?, ByVal PTransDateEnding As DateTime?, ByVal PJobStarting As String, ByVal PJobEnding As String, ByVal PSuffixStarting As Short?, ByVal PSuffixEnding As Short?, ByVal PItemStarting As String, ByVal PItemEnding As String, ByVal PLocationStarting As String, ByVal PLocationEnding As String, ByVal PEmployeeStarting As String, ByVal PEmployeeEnding As String, ByVal PTransClass As String,
<[Optional]> ByVal PSite As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim iRpt_PendingMaterialTransactionsExt As IRpt_PendingMaterialTransactions = New Rpt_PendingMaterialTransactionsFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iRpt_PendingMaterialTransactionsExt.Rpt_PendingMaterialTransactionsSp(PTransNumStarting, PTransNumEnding, PTransDateStarting, PTransDateEnding, PJobStarting, PJobEnding, PSuffixStarting, PSuffixEnding, PItemStarting, PItemEnding, PLocationStarting, PLocationEnding, PEmployeeStarting, PEmployeeEnding, PTransClass, PSite)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function
End Class
