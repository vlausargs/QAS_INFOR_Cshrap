Option Explicit On
Option Strict On

Imports System.Data.SqlClient
Imports System.Text

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common

Imports CSI.Data.SQL.UDDT
Imports System
Imports System.Data
Imports CSI.Material
Imports CSI.MG
Imports System.Runtime.InteropServices
Imports CSI.Production
Imports IMessageProvider = Mongoose.IDO.IMessageProvider
Imports CSI.Logistics.Customer
Imports CSI.Data.RecordSets
Imports CSI.Data.CRUD
Imports CSI.ExternalContracts.FactoryTrack

''' <summary>
''' IDO extension class for the SyteLine SLJobTran IDO. 
''' </summary>
''' <remarks></remarks>
<IDOExtensionClass("SLJobTrans")>
Public Class SLJobTrans
    Inherits CSIExtensionClassBase
    Implements IExtFTSLJobTrans

    Const POSTSEQ As Long = 1000000000

    Private Function BuildJobTranFilter(
       ByVal PostComplete As Byte,
       ByVal StartJob As String,
       ByVal EndJob As String,
       ByVal StartSuffix As Nullable(Of Short),
       ByVal EndSuffix As Nullable(Of Short),
       ByVal StartTranDate As Nullable(Of DateTime),
       ByVal EndTranDate As Nullable(Of DateTime),
       ByVal StartEmpNum As String,
       ByVal EndEmpNum As String,
       ByVal StartShift As String,
       ByVal EndShift As String,
       ByVal StartUserCode As String,
       ByVal EndUserCode As String,
       ByVal StartTranDateOffset As Nullable(Of Short),
       ByVal EndTranDateOffset As Nullable(Of Short)) As String

        Dim filter As New StringBuilder()

        Dim StrStartTranDate As String
        Dim StrEndTranDate As String

        filter.Append("Posted = 0 AND TransClass = 'J'")

        '  The input parameters to this method are used to apply tighter constraints to the
        ' jobtran records which are retrieved for the first loop.

        If Not IDONull.IsNull(StartShift) Then filter.AppendFormat(" AND Shift >= {0}", SqlLiteral.Format(StartShift))
        If Not IDONull.IsNull(EndShift) Then filter.AppendFormat(" AND Shift <= {0}", SqlLiteral.Format(EndShift))

        'Apply Date Offset for background task and set midnight and endday for dates
        'ReturnCode = ApplyDateOffsetSp(StartTranDate, StartTranDateOffset, 0)
        'If ReturnCode = 0 And Err.Number = 0 Then
        '   ReturnCode = ApplyDateOffsetSp(EndTranDate, EndTranDateOffset, 1)
        'End If
        'If ReturnCode <> 0 Or Err.Number <> 0 Then
        '   JobJobP = 16
        '   GoTo Done
        'End If

        If Not IDONull.IsNull(StartJob) Then filter.AppendFormat(" AND Job >= {0}", SqlLiteral.Format(StartJob))
        If Not IDONull.IsNull(EndJob) Then filter.AppendFormat(" AND Job <= {0}", SqlLiteral.Format(EndJob))

        If Not IDONull.IsNull(StartSuffix) Then filter.AppendFormat(" AND Suffix >= {0}", SqlLiteral.Format(StartSuffix))
        If Not IDONull.IsNull(EndSuffix) Then filter.AppendFormat(" AND ( (Suffix IS NULL) OR (Suffix <= {0}) )", SqlLiteral.Format(EndSuffix))

        If Not IDONull.IsNull(StartTranDate) Then
            StrStartTranDate = Format(StartTranDate, "yyyy-MM-dd") & "T00:00:00.000"
            filter.AppendFormat(" AND TransDate >= ({0})", SqlLiteral.Format(StrStartTranDate))
        End If

        If Not IDONull.IsNull(EndTranDate) Then
            StrEndTranDate = Format(EndTranDate, "yyyy-MM-dd") & "T23:59:59.997"
            filter.AppendFormat(" AND TransDate <= ({0})", SqlLiteral.Format(StrEndTranDate))
        End If

        If Not IDONull.IsNull(StartEmpNum) Then filter.AppendFormat(" AND EmpNum >= {0}", SqlLiteral.Format(StartEmpNum))

        '  If an ending emp num is specified, but no starting emp num, get the null emp
        ' num values as well.  If start emp num is specified already, skip the NULL emp
        ' num values.  I believe this is what the Progress code did in SL6.
        If Not IDONull.IsNull(EndEmpNum) Then
            If IDONull.IsNull(StartEmpNum) Then
                filter.AppendFormat(" AND (EmpNum IS NULL OR EmpNum <= {0}", SqlLiteral.Format(EndEmpNum))
            Else
                filter.AppendFormat(" AND EmpNum <= {0}", SqlLiteral.Format(EndEmpNum))
            End If
        End If

        If Not IDONull.IsNull(StartUserCode) Then filter.AppendFormat(" AND UserCode >= {0}", SqlLiteral.Format(StartUserCode))
        If Not IDONull.IsNull(EndUserCode) Then
            If IDONull.IsNull(StartUserCode) Then
                filter.AppendFormat(" AND (UserCode IS NULL OR UserCode <= {0})", SqlLiteral.Format(EndUserCode))
            Else
                filter.AppendFormat(" AND UserCode <= {0}", SqlLiteral.Format(EndUserCode))
            End If
        End If

        If PostComplete = 0 Then
            filter.Append(" AND CloseJob = 0 AND CompleteOp = 0")
        End If

        Return filter.ToString()

    End Function
    Private Function BuildJobTranFilterWc(
ByVal Wc As String,
ByVal StartEmpNum As String,
ByVal EndEmpNum As String) As String

        Dim filter As New StringBuilder()

        filter.Append("Posted = 0 AND TransClass = 'W'")

        If Not IDONull.IsNull(Wc) Then filter.AppendFormat(" AND wc = {0}", SqlLiteral.Format(Wc))

        If Not IDONull.IsNull(StartEmpNum) Then filter.AppendFormat(" AND EmpNum >= {0}", SqlLiteral.Format(StartEmpNum))

        '  If an ending emp num is specified, but no starting emp num, get the null emp
        ' num values as well.  If start emp num is specified already, skip the NULL emp
        ' num values.  I believe this is what the Progress code did in SL6.
        If Not IDONull.IsNull(EndEmpNum) Then
            If IDONull.IsNull(StartEmpNum) Then
                filter.AppendFormat(" AND (EmpNum IS NULL OR EmpNum <= {0}", SqlLiteral.Format(EndEmpNum))
            Else
                filter.AppendFormat(" AND EmpNum <= {0}", SqlLiteral.Format(EndEmpNum))
            End If
        End If

        filter.Append(" AND CloseJob = 0 AND CompleteOp = 0")

        Return filter.ToString()

    End Function
    Private Function CallMsgAppSp(ByRef Infobar As String,
                                    ByVal BaseMsg As String,
                                    ByVal Parm1 As String,
                                    ByVal Parm2 As String,
                                    ByVal Parm3 As String,
                                    ByVal Parm4 As String,
                                    ByVal Parm5 As String,
                                    ByVal Parm6 As String,
                                    ByVal Parm7 As String,
                                    ByVal Parm8 As String,
                                    ByVal Parm9 As String,
                                    ByVal Parm10 As String,
                                    ByVal Parm11 As String,
                                    ByVal Parm12 As String,
                                    ByVal Parm13 As String,
                                    ByVal Parm14 As String,
                                    ByVal Parm15 As String) As Integer

        Dim oResponse As InvokeResponseData

        oResponse = Me.Context.Commands.Invoke("SLJobtMats", "MsgAppSp", Infobar, BaseMsg, Parm1, Parm2, Parm3, Parm4, Parm5, Parm6, Parm7, Parm8, Parm9,
                                         Parm10, Parm11, Parm12, Parm13, Parm14, Parm15)

        CallMsgAppSp = CInt(oResponse.ReturnValue)
        Infobar = oResponse.Parameters(0).GetValue(Of String)()

        oResponse = Nothing

    End Function
    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function JobJtcPost(ByVal TransClass As String,
                                ByVal FromTransNum As Nullable(Of Long),
                                ByVal ToTransNum As Nullable(Of Long),
                                ByVal FromTransDate As Nullable(Of DateTime),
                                ByVal ToTransDate As Nullable(Of DateTime),
                                ByVal FromJob As String,
                                ByVal ToJob As String,
                                ByVal FromSuffix As Nullable(Of Short),
                                ByVal ToSuffix As Nullable(Of Short),
                                ByRef Infobar As String) As Integer

        Dim JobtClsCol As LoadCollectionResponseData
        Dim TransNum As String
        Dim Filter As StringBuilder
        Dim PropertyList As String
        Dim iReturnValue As Integer
        Dim ErrorCount As Integer
        Dim Counter As Integer
        Dim ResponseData As InvokeResponseData
        Dim messageProvider As IMessageProvider = Nothing
        Dim SessionID As Guid

        Try
            Infobar = ""
            ErrorCount = 0
            Counter = 0
            SessionID = Mongoose.IDO.IDORuntime.Context.SessionID

            Filter = New StringBuilder()

            Filter.Append("CHARINDEX(JobtranTransClass, '" & TransClass & "') > 0")
            'msession.SessionObject = Session

            'Filter = "CHARINDEX(JobtranTransClass, '" & TransClass & "') > 0"
            If Not IDONull.IsNull(FromTransNum) Then
                Filter.AppendFormat(" And JtTransNum >= {0}", SqlLiteral.Format(FromTransNum))
            End If
            If Not IDONull.IsNull(ToTransNum) Then
                Filter.AppendFormat(" AND JtTransNum <= {0}", SqlLiteral.Format(ToTransNum))
            End If
            If Not IDONull.IsNull(FromTransDate) Then
                Filter.AppendFormat(" AND JobtranTransDate >= {0}", SqlLiteral.Format(FromTransDate))
            End If
            If Not IDONull.IsNull(ToTransDate) Then
                Filter.AppendFormat(" AND JobtranTransDate <= {0}", SqlLiteral.Format(ToTransDate))
            End If
            If Not IDONull.IsNull(FromJob) Then
                Filter.AppendFormat(" AND JobtranJob >= {0}", SqlLiteral.Format(FromJob))
            End If
            If Not IDONull.IsNull(ToJob) Then
                Filter.AppendFormat(" AND JobtranJob <= {0}", SqlLiteral.Format(ToJob))
            End If
            If Not IDONull.IsNull(FromSuffix) Then
                Filter.AppendFormat(" AND JobtranSuffix >= {0}", SqlLiteral.Format(FromSuffix))
            End If
            If Not IDONull.IsNull(ToSuffix) Then
                Filter.AppendFormat(" AND JobtranSuffix <= {0}", SqlLiteral.Format(ToSuffix))
            End If

            PropertyList = "JtTransNum"
            JobtClsCol = Me.Context.Commands.LoadCollection("SLJobtCls", PropertyList, Filter.ToString, String.Empty, 0)

            For index As Integer = 0 To JobtClsCol.Items.Count - 1
                Counter = Counter + 1
                Infobar = ""
                Try
                    'Call JobJobPJobtPcISp
                    TransNum = JobtClsCol(index, "JtTransNum").Value
                    ResponseData = Me.Invoke("JobJobPJobtPcISp", TransNum, SessionID, Infobar)
                    iReturnValue = CInt(ResponseData.ReturnValue)
                    If InStr(1, Infobar, "$jobt_mat") > 0 Then
                        Infobar = Mid(Infobar, 1, InStr(1, Infobar, "$") - 1)
                    End If
                    If ResponseData.IsReturnValueStdError Or iReturnValue <> 0 Then
                        ErrorCount = ErrorCount + 1
                        Infobar = ResponseData.Parameters(2).GetValue(Of String)()
                        ResponseData = Me.Context.Commands.Invoke("SLJobtCls", "JobtClsLogErrorSp", TransNum, Infobar)
                        iReturnValue = CInt(ResponseData.ReturnValue)
                        If ResponseData.IsReturnValueStdError Or iReturnValue <> 0 Then
                            iReturnValue = 16
                            Infobar = ""
                        Else
                            iReturnValue = 0
                        End If

                    Else
                    End If

                Catch ex As Exception
                    ErrorCount = ErrorCount + 1
                End Try

            Next
            messageProvider = Me.GetMessageProvider()
            If ErrorCount > 0 Then
                Infobar = ""
                Infobar = messageProvider.GetMessage("E=CmdFailed", CStr("@:PostPendingJobLaborTransactions"))
                Infobar = messageProvider.AppendMessage(Infobar, "I=#Invalid", CStr(ErrorCount), CStr("@jobt_cls"))
            Else
                Infobar = ""
                Infobar = messageProvider.AppendMessage(Infobar, "I=CmdSucceeded", CStr("@:PostPendingJobLaborTransactions"))
            End If
            Counter = Counter - ErrorCount
            Infobar = messageProvider.AppendMessage(Infobar, "I=#Post", CStr(Counter), CStr("@jobt_cls"))
        Catch ex As Exception
            Throw New MGException()
        End Try

    End Function

    '  This routine does some further range checking for the main loop in the JobJobp methods.
    Private Function SkipJobTransRow(ByVal EmpNum As String,
                                ByVal StartDept As String,
                                ByVal EndDept As String,
                                ByVal EmpDept As String,
                                ByVal EmpType As String,
                                ByVal ValidEmpTypes As String,
                                ByVal WcDept As String) As Boolean
        Dim result As Boolean
        result = False
        If Not IDONull.IsNull(EmpNum) Then
            If Not IDONull.IsNull(StartDept) And StartDept > EmpDept Then result = True

            If Not IDONull.IsNull(EndDept) And (EndDept < EmpDept Or IDONull.IsNull(EmpDept)) Then result = True

            If InStr(1, ValidEmpTypes, EmpType) = 0 Then result = True

        End If

        If Not IDONull.IsNull(WcDept) Then
            If Not IDONull.IsNull(StartDept) And StartDept > WcDept Then result = True
            If Not IDONull.IsNull(EndDept) And EndDept < WcDept Then result = True
        End If
        Return result

    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PSScrapTransPost(ByVal SessionID As Guid, ByVal TransNum As Long, ByVal Coby As Byte, ByRef Infobar As String) As Integer Implements IExtFTSLJobTrans.PSScrapTransPost

        Dim loadResponse As LoadCollectionResponseData
        Dim filter As String
        Dim message As String = String.Empty
        Dim success As Boolean
        Dim jobtPcISpSuccess As Boolean = True
        Dim returnValue As Integer = 0
        Dim transSeq As Integer
        Dim matErrorCount As Integer = 0
        Dim messageProvider As IMessageProvider = Nothing

        Infobar = String.Empty
        filter = String.Format("SessionId = {0} AND TransNum = {1}", SqlLiteral.Format(SessionID), SqlLiteral.Format(TransNum))

        Try
            loadResponse = Me.Context.Commands.LoadCollection("SLTtJobtMatPosts", "TransNum,TransSeq", filter, String.Empty, 0)

            For index As Integer = 0 To loadResponse.Items.Count - 1
                transSeq = loadResponse(index, "TransSeq").GetValue(Of Integer)()

                ' call the JobtPostSp - this is a transactional call
                success = CallJobtPostSp(SessionID, "PSSCRAP", TransNum, transSeq, message)

                If Not success Then
                    ' if the post failed, log the error
                    matErrorCount = matErrorCount + 1
                    success = CallJobtMatLogErrorSp(SessionID, TransNum, transSeq, message)

                    If Not success Then
                        ' if we can't report an errors then something is really wrong...bail
                        Throw New MGException(message)
                    End If
                End If
            Next

            If matErrorCount = 0 Then
                jobtPcISpSuccess = Me.CallJobtPcISp(TransNum, Coby, message)

                If Not jobtPcISpSuccess Then
                    ' if JobtPcISp failed, log the error
                    Me.Context.Commands.Invoke("SLJobtCls", "JobtClsLogErrorSp", TransNum, message)
                End If
            End If

            messageProvider = Me.GetMessageProvider()

            If matErrorCount <> 0 Then
                Infobar = messageProvider.GetMessage("E=CmdFailed", "@%post")
                Infobar = messageProvider.AppendMessage(Infobar, "I=CmdMustPerform", "@:PostPendingMaterialTransactions")
            End If

            If Not jobtPcISpSuccess Then
                Infobar = messageProvider.GetMessage("E=CmdFailed", "@%post")
                Infobar = messageProvider.AppendMessage(Infobar, "I=CmdMustPerform", "@:PostPendingJobLaborTransactions")
            End If

            If (matErrorCount = 0) And jobtPcISpSuccess Then
                Infobar = messageProvider.GetMessage("I=CmdSucceeded", "@%post")
            End If

        Catch ex As Exception
            Infobar = ex.Message
            returnValue = 16
        End Try

        Return returnValue

    End Function
    Private Function CallJobtPcISp(ByVal transNum As Long, ByVal Coby As Byte, ByRef message As String) As Boolean

        Dim success As Boolean = False
        Dim invokeResponse As New InvokeResponseData

        Try
            invokeResponse = Me.Invoke("JobtPcISp", transNum, Coby, message)
            If Not invokeResponse.IsReturnValueStdError() Then success = True
            message = invokeResponse.Parameters(2).Value
        Catch ex As Exception
            message = MGException.ExtractMessages(ex)
        End Try

        Return success

    End Function

    Private Function CallJobtPostSp(
       ByVal sessionID As Guid,
       ByVal callFrom As String,
       ByVal transNum As Long,
       ByVal transSeq As Integer,
       ByRef message As String) As Boolean

        Dim invokeResponse As New InvokeResponseData
        Dim success As Boolean = False

        Try
            ' Call the JobtPostSp method through the framework.  Since this method is
            ' marked as a transactional method, the framework will make sure it executes
            ' in a transaction.
            invokeResponse = Me.Invoke("JobtPostSp", sessionID, callFrom, transNum, transSeq, message)

            ' check the return code for a standard error result
            If Not invokeResponse.IsReturnValueStdError() Then success = True

            ' return the Infobar parameter to the caller
            message = invokeResponse.Parameters(4).Value
        Catch ex As Exception
            ' return the exception message to the caller
            message = MGException.ExtractMessages(ex)
        End Try

        Return success

    End Function
    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PSCmplTransPost(ByVal SessionID As Guid,
                                        ByVal TransNum As Nullable(Of Long),
                                        ByVal Coby As String,
                                        ByRef Infobar As String) As Integer Implements IExtFTSLJobTrans.PSCmplTransPost
        Dim ttJobtMatPostCol As LoadCollectionResponseData
        Dim oCollection As LoadCollectionResponseData
        Dim ResponseData As InvokeResponseData
        Dim Filter As StringBuilder
        Dim Filter1 As StringBuilder
        Dim PropertyList As String
        Dim iReturnValue As Integer
        Dim TransSeq As Integer
        Dim MatErrorCount As Integer
        Dim LbrErrorCount As Integer
        Dim TransDate As Date
        Dim Job As String
        Dim OperNum As Integer
        Dim EmpNum As String
        Dim PsNum As String
        Dim xTransNum As Long
        Dim messageProvider As IMessageProvider = Nothing

        Try
            PSCmplTransPost = 0
            MatErrorCount = 0
            LbrErrorCount = 0
            Infobar = ""
            iReturnValue = 0

            Filter = New StringBuilder()
            Filter1 = New StringBuilder()

            If Not IDONull.IsNull(SessionID) Then
                Filter1.AppendFormat(" SessionId =  {0}", SqlLiteral.Format(SessionID))
            End If
            PropertyList = "TransNum, TransSeq"

            ttJobtMatPostCol = Me.Context.Commands.LoadCollection("SL.SLTtJobtMatPosts",
                                                    PropertyList, Filter1.ToString, "", 0)
            For index As Integer = 0 To ttJobtMatPostCol.Items.Count - 1
                xTransNum = TextUtil.ParseNormalizedString(Of Long)(ttJobtMatPostCol.Item(index,
                                                                "TransNum").Value, 0)
                TransSeq = TextUtil.ParseNormalizedString(Of Integer)(ttJobtMatPostCol.Item(index,
                                                                "TransSeq").Value, 0)
                Try
                    ResponseData = Me.Context.Commands.Invoke("SLJobTrans",
                                        "JobtPostSp", SessionID, "PSCMPL", xTransNum, TransSeq, Infobar)
                    iReturnValue = CInt(ResponseData.ReturnValue)
                    If ResponseData.IsReturnValueStdError Or iReturnValue <> 0 Then
                        MatErrorCount = MatErrorCount + 1
                        ResponseData = Me.Context.Commands.Invoke("SLJobtMats" _
                        , "JobtMatLogErrorSp", xTransNum, TransSeq, Infobar)
                        If ResponseData.IsReturnValueStdError Or iReturnValue <> 0 Then
                            iReturnValue = 16
                            Infobar = ResponseData.Parameters(2).GetValue(Of String)()
                        Else
                            iReturnValue = 0
                            Infobar = ""
                        End If
                    Else

                    End If
                Catch ex As Exception
                    MatErrorCount = MatErrorCount + 1
                    Infobar = MGException.ExtractMessages(ex)
                End Try

            Next

            If MatErrorCount = 0 Then
                ' need to loop through data in case multiple jobtran records where created
                ' get filter information
                oCollection = Me.LoadCollection("TransDate, Job, OperNum, EmpNum, PsNum",
                    "TransNum = " & CStr(TransNum), "", 0)
                TransDate = oCollection.Item(0, "TransDate").GetValue(Of Date)()
                Job = oCollection.Item(0, "Job").GetValue(Of String)()
                OperNum = oCollection.Item(0, "OperNum").GetValue(Of Integer)()
                Try
                    EmpNum = oCollection.Item(0, "EmpNum").GetValue(Of String)()
                Catch ex As NullReferenceException
                    EmpNum = ""
                End Try
                PsNum = oCollection.Item(0, "PsNum").GetValue(Of String)()

                oCollection = Nothing

                ' start to look at matching transaction numbers
                Filter.AppendFormat("Posted = 1 AND TransType = 'M' AND TransClass = 'S'" &
                    " AND TransDate = {0}" &
                    " AND PsNum = {1}" &
                    " AND Job = {2}" &
                    " AND OperNum = {3}", SqlLiteral.Format(TransDate),
                    SqlLiteral.Format(PsNum), SqlLiteral.Format(Job),
                    SqlLiteral.Format(OperNum))

                If Not IDONull.IsNull(EmpNum) Then
                    Filter.AppendFormat(" AND EmpNum = {0}", SqlLiteral.Format(EmpNum))
                Else
                    Filter.AppendFormat(" AND EmpNum IS NULL")
                End If
                Filter.AppendFormat(" ORDER BY TransNum")
                oCollection = Me.LoadCollection("TransNum", Filter.ToString, "", 0)

                For index As Integer = 0 To oCollection.Items.Count - 1
                    TransNum = oCollection.Item(index, "TransNum").GetValue(Of Long)()
                    Try
                        ResponseData = Me.Invoke("JobtPcISp", TransNum, Coby, Infobar)
                        iReturnValue = CInt(ResponseData.ReturnValue)
                        If ResponseData.IsReturnValueStdError Or iReturnValue <> 0 Then
                            LbrErrorCount = LbrErrorCount + 1
                            iReturnValue = 16
                        Else
                            Infobar = ResponseData.Parameters(2).Value
                        End If

                    Catch ex As Exception
                        LbrErrorCount = LbrErrorCount + 1
                        Infobar = MGException.ExtractMessages(ex)
                    End Try

                Next
            End If
            messageProvider = Me.GetMessageProvider()

            If MatErrorCount <> 0 Then
                Infobar = messageProvider.GetMessage("E=CmdFailed", "@%post")
                Infobar = messageProvider.AppendMessage(Infobar, "I=CmdMustPerform", CStr("@:PostPendingMaterialTransactions"))
            End If
            If LbrErrorCount <> 0 Then
                Infobar = messageProvider.GetMessage("E=CmdFailed", "@%post")
                Infobar = messageProvider.AppendMessage(Infobar, "I=CmdMustPerform", CStr("@:PostPendingJobLaborTransactions"))
            End If

            If MatErrorCount = 0 And LbrErrorCount = 0 Then
                Infobar = messageProvider.AppendMessage(Infobar, "I=CmdSucceeded", CStr("@%post"))
            End If

        Catch ex As Exception
            PSCmplTransPost = 16

        End Try
    End Function
    <IDOMethod(MethodFlags.None)>
    Public Function JobWipTransPost(ByVal SessionID As Guid, ByVal TransNum As Long, ByVal Coby As Byte, ByRef Infobar As String) As Integer Implements IExtFTSLJobTrans.JobWipTransPost

        Dim loadResponse As LoadCollectionResponseData
        Dim filter As String
        Dim message As String = String.Empty
        Dim matErrorCount As Integer = 0
        Dim transSeq As Integer
        Dim success As Boolean
        Dim returnValue As Integer = 0
        Dim messageProvider As IMessageProvider = Nothing
        Dim jobtPcISpSuccess As Boolean = True

        filter = String.Format("SessionId = {0} AND TransNum = {1}", SqlLiteral.Format(SessionID), SqlLiteral.Format(TransNum))

        Try
            loadResponse = Me.Context.Commands.LoadCollection("SLTtJobtMatPosts", "TransNum,TransSeq", filter, "", 0)
            For index As Integer = 0 To loadResponse.Items.Count - 1
                transSeq = loadResponse(index, "TransSeq").GetValue(Of Integer)()

                ' call the JobtPostSp - this is a transactional call
                success = CallJobtPostSp(SessionID, "", TransNum, transSeq, message)

                If Not success Then
                    ' if the post failed, log the error
                    matErrorCount = matErrorCount + 1
                    success = CallJobtMatLogErrorSp(SessionID, TransNum, transSeq, message)

                    ' if we can't report an errors then something is really wrong...bail
                    If Not success Then Throw New MGException(message)

                End If
            Next

            If matErrorCount = 0 Then
                jobtPcISpSuccess = Me.CallJobtPcISp(TransNum, Coby, message)

                If Not jobtPcISpSuccess Then
                    ' if JobtPcISp failed, log the error
                    Me.Context.Commands.Invoke("SLJobtCls", "JobtClsLogErrorSp", TransNum, message)
                End If
            End If

            messageProvider = Me.GetMessageProvider()

            If matErrorCount <> 0 Then
                Infobar = messageProvider.GetMessage("E=CmdFailed", "@%post")
                Infobar = messageProvider.AppendMessage("I=CmdMustPerform", "@:PostPendingMaterialTransactions")
            End If

            If Not jobtPcISpSuccess Then
                Infobar = messageProvider.GetMessage("E=CmdFailed", "@%post")
                Infobar = messageProvider.AppendMessage("I=CmdMustPerform", "@:PostPendingJobLaborTransactions")
            End If

            If (matErrorCount = 0) And jobtPcISpSuccess Then
                Infobar = messageProvider.GetMessage("I=CmdSucceeded", "@%post")
            End If

        Catch ex As Exception
            Infobar = MGException.ExtractMessages(ex)
            returnValue = 16
        End Try

        Return returnValue

    End Function
    Private Function CallJobJobPJobtPcISp(ByVal TransNum As Long, ByVal SessionID As Guid, ByRef message As String) As Boolean

        Dim success As Boolean = False
        Dim invokeResponse As New InvokeResponseData

        Try
            invokeResponse = Me.Invoke("JobJobPJobtPcISp", TransNum, SessionID, String.Empty)
            If Not invokeResponse.IsReturnValueStdError() Then success = True
            message = invokeResponse.Parameters(2).Value
        Catch ex As Exception
            message = MGException.ExtractMessages(ex)
        End Try

        Return success
    End Function
    ''' <summary>
    ''' Job posting
    ''' </summary>
    ''' <param name="PostComplete"></param>
    ''' <param name="PostNegativeInventory"></param>
    ''' <param name="StartJob"></param>
    ''' <param name="EndJob"></param>
    ''' <param name="StartSuffix"></param>
    ''' <param name="EndSuffix"></param>
    ''' <param name="StartTranDate"></param>
    ''' <param name="EndTranDate"></param>
    ''' <param name="StartEmpNum"></param>
    ''' <param name="EndEmpNum"></param>
    ''' <param name="StartDept"></param>
    ''' <param name="EndDept"></param>
    ''' <param name="StartShift"></param>
    ''' <param name="EndShift"></param>
    ''' <param name="StartUserCode"></param>
    ''' <param name="EndUserCode"></param>
    ''' <param name="ValidEmpTypes"></param>
    ''' <param name="CurWhse"></param>
    ''' <param name="StartTranDateOffset"></param>
    ''' <param name="EndTranDateOffset"></param>
    ''' <param name="Infobar"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' This method will be executed without an active transaction when called
    ''' through the framework.
    ''' </remarks>
   <IDOMethod(MethodFlags.None)> _
    Public Function JobJobP( _
       ByVal PostComplete As Byte, _
       ByVal PostNegativeInventory As Byte, _
       ByVal StartJob As String, _
       ByVal EndJob As String, _
       ByVal StartSuffix As Nullable(Of Short), _
       ByVal EndSuffix As Nullable(Of Short), _
       ByVal StartTranDate As Nullable(Of DateTime), _
       ByVal EndTranDate As Nullable(Of DateTime), _
       ByVal StartEmpNum As String, _
       ByVal EndEmpNum As String, _
       ByVal StartDept As String, _
       ByVal EndDept As String, _
       ByVal StartShift As String, _
       ByVal EndShift As String, _
       ByVal StartUserCode As String, _
       ByVal EndUserCode As String, _
       ByVal ValidEmpTypes As String, _
       ByVal CurWhse As String, _
       ByVal StartTranDateOffset As Nullable(Of Short), _
       ByVal EndTranDateOffset As Nullable(Of Short), _
       ByRef Infobar As String, _
       ByRef PromptButtons As String, _
       ByVal Wc As String, _
       ByVal DocumentNum As String) As Integer Implements IExtFTSLJobTrans.JobJobP

        Dim apsSyncResponse As InvokeResponseData
        Dim jobTranResponse As LoadCollectionResponseData
        Dim ttJobMatPostResponse As LoadCollectionResponseData
        Dim sessionID As Guid
        Dim filter As String
        Dim empNum As String
        Dim empDept As String
        Dim empType As String
        Dim wcDept As String
        Dim rowPointer As String
        Dim skip As Boolean
        Dim curTransNum As Long
        Dim TMatCount As Long = 0
        Dim TClsCount As Long = 0
        Dim TNone As Long = 0
        Dim ErrorOccurred As Long = 0
        Dim returnValue As Integer = 0
        Dim message As String = String.Empty
        Dim success As Boolean
        Dim transNum As Long
        Dim transSeq As Integer
        Dim invokeResponse As New InvokeResponseData
        Dim PostJobInfobar As String
        Dim bApsSyncDefer As Boolean
        Try
            PromptButtons = ""
            sessionID = Guid.NewGuid()

            ' call ApsSyncDeferSp
            bApsSyncDefer = False
            apsSyncResponse = Me.Invoke("ApsSyncDeferSp", String.Empty, "SLJobTrans.JobJobP() 1")
            If apsSyncResponse.IsReturnValueStdError() Then
                Throw New MGException(apsSyncResponse.Parameters(0).ToString())
            End If
            bApsSyncDefer = True

            If IDONull.IsNull(Wc) Then
                filter = Me.BuildJobTranFilter(
                   PostComplete,
                   StartJob,
                   EndJob,
                   StartSuffix,
                   EndSuffix,
                   StartTranDate,
                   EndTranDate,
                   StartEmpNum,
                   EndEmpNum,
                   StartShift,
                   EndShift,
                   StartUserCode,
                   EndUserCode,
                   StartTranDateOffset,
                   EndTranDateOffset)
            Else
                filter = Me.BuildJobTranFilterWc(
                   Wc,
                   StartEmpNum,
                   EndEmpNum)
            End If

            jobTranResponse = Me.LoadCollection(
               "TransNum, EmpNum, EmpEmpType, EmpDept, DerJobPWcDept, RowPointer", filter,
               "Posted, LowLevel DESC, Job, Suffix, CloseJob, OperNum, CompleteOp, TransNum",
               0)

            If jobTranResponse.Items.Count > 0 Then
                For index As Integer = 0 To jobTranResponse.Items.Count - 1
                    empNum = String.Empty
                    empDept = String.Empty
                    empType = String.Empty
                    wcDept = String.Empty

                    If Not jobTranResponse(index, "EmpNum").IsNull Then empNum = jobTranResponse(index, "EmpNum").Value
                    If Not jobTranResponse(index, "EmpDept").IsNull Then empDept = jobTranResponse(index, "EmpDept").Value
                    If Not jobTranResponse(index, "EmpEmpType").IsNull Then empType = jobTranResponse(index, "EmpEmpType").Value
                    If Not jobTranResponse(index, "DerJobPWcDept").IsNull Then wcDept = jobTranResponse(index, "DerJobPWcDept").Value

                    empDept = jobTranResponse(index, "EmpDept").Value
                    ' Some of the constraints are handled by this function.  They could have been put
                    ' into a more complicated SQL select statement, but I chose this simpler algorithmn.
                    skip = Me.SkipJobTransRow(empNum, StartDept, EndDept, empDept, empType, ValidEmpTypes, wcDept)

                    If Not skip Then
                        rowPointer = jobTranResponse(index, "RowPointer").Value
                        curTransNum = jobTranResponse(index, "TransNum").GetValue(Of Long)()

                        TNone = 1
                        ' Post the current record and if it fails, exit the loop while saving the message.
                        success = Me.CallPostJobTransactions1Sp(sessionID, rowPointer, PostNegativeInventory, CurWhse, message, PromptButtons, DocumentNum)
                        If Not success Then
                            ErrorOccurred = 1
                            Throw New MGException(message)
                        End If
                        ttJobMatPostResponse = Me.Context.Commands.LoadCollection(
                           "SLttJobtMatPosts",
                           "TransNum, TransSeq",
                           String.Format("SessionId = {0}", SqlLiteral.Format(sessionID)),
                           "",
                           0)

                        For ttIndex As Integer = 0 To ttJobMatPostResponse.Items.Count - 1
                            transNum = ttJobMatPostResponse(ttIndex, "TransNum").GetValue(Of Long)()
                            transSeq = ttJobMatPostResponse(ttIndex, "TransSeq").GetValue(Of Integer)()

                            If (transSeq <> POSTSEQ) And (transSeq <> 0) Then
                                success = Me.CallJobtPostSp(sessionID, "", transNum, transSeq, message)

                                If Not success Then
                                    TClsCount = TClsCount + 1
                                    TMatCount = TMatCount + 1

                                    success = Me.CallJobtMatLogErrorSp(sessionID, transNum, transSeq, message)
                                    If Not success Then Throw New MGException(message)
                                End If
                            Else
                                ' The POSTSEQ sequence indicates that all the regular trans num/seq values have
                                ' posted and the JobtPcISp method can now be called.
                                success = Me.CallJobJobPJobtPcISp(transNum, sessionID, message)

                                If Not success Or InStr(1, message, "$jobt_mat") > 0 Then
                                    If InStr(1, message, "$jobt_mat") > 0 Then
                                        message = Mid(message, 1, InStr(1, message, "$") - 1)
                                        TMatCount = TMatCount + 1
                                        success = Me.CallJobtMatLogErrorSp(sessionID, transNum, 0, message)
                                    Else
                                        TClsCount = TClsCount + 1

                                        success = Me.CallJobtClsLogErrorSp(transNum, message)
                                    End If
                                    If Not success Then Throw New MGException(message)
                                End If
                            End If
                        Next
                    End If
                Next
            End If

            invokeResponse = Me.Context.Commands.Invoke(
                                      "SLJobTrans",
                                      "JobPMessagesSp",
                                      TNone,
                                      TMatCount,
                                      TClsCount,
                                      ErrorOccurred,
                                      curTransNum,
                                      Infobar)

            If Not invokeResponse.IsReturnValueStdError() Then
                returnValue = 0
                Infobar = invokeResponse.Parameters(5).Value
            Else
                MGException.Throw(invokeResponse.Parameters(5).Value)
            End If


            ' ReturnCode = oIDO.JobPMessagesSp(TNone, TMatCount, TClsCount, ErrorOccurred, CurTransNum, Infobar)
            ' success = Me.CallJobPMessagesSp(TNone, TMatCount, TClsCount, ErrorOccurred, curTransNum, message)
        Catch ex As Exception
            Try
                If bApsSyncDefer Then
                    apsSyncResponse = Me.Invoke("ApsSyncImmediateSp", String.Empty, 0, "SLJobTrans.JobJobP() 0")
                    bApsSyncDefer = False
                End If
                Infobar = MGException.ExtractMessages(ex)
                PostJobInfobar = Infobar

                Infobar = ""
                invokeResponse = Me.Context.Commands.Invoke(
                                                  "SLJobTrans",
                                                  "JobPMessagesSp",
                                                  TNone,
                                                  TMatCount,
                                                  TClsCount,
                                                  ErrorOccurred,
                                                  curTransNum,
                                                  Infobar)

                Infobar = PostJobInfobar + invokeResponse.Parameters(5).Value
                returnValue = 16
            Catch
                ' Let errors get handled by the Finally below
            End Try
        Finally
            If bApsSyncDefer Then
                If returnValue = 0 Then
                    apsSyncResponse = Me.Invoke("ApsSyncImmediateSp", String.Empty, 0, "SLJobTrans.JobJobP() 3")
                    If returnValue = 0 And apsSyncResponse.IsReturnValueStdError() Then
                        Infobar = apsSyncResponse.Parameters(0).ToString()
                        returnValue = 16
                    End If
                Else
                    apsSyncResponse = Me.Invoke("ApsSyncImmediateSp", String.Empty, 1, "SLJobTrans.JobJobP() 2")
                End If
                bApsSyncDefer = False
            End If
        End Try

        Return returnValue

    End Function
    Private Function CallPostJobTransactions1Sp( _
       ByVal sessionID As Guid, _
       ByVal rowPointer As String, _
       ByVal postNegativeInv As Byte, _
       ByVal curWhse As String, _
       ByRef message As String, _
       ByRef PromptButtons As String, _
       ByVal DocumentNum As String) As Boolean

        Dim success As Boolean = False
        Dim postJobResponse As InvokeResponseData

        Try
            postJobResponse = Me.Invoke("PostJobTransactions1Sp", sessionID, rowPointer, postNegativeInv, curWhse, IDONull.Value, IDONull.Value, DocumentNum)
            If Not postJobResponse.IsReturnValueStdError() Then success = True
            message = postJobResponse.Parameters(4).Value
            PromptButtons = postJobResponse.Parameters(5).Value
        Catch ex As Exception
            message = MGException.ExtractMessages(ex)
        End Try

        Return success

    End Function
    Private Function CallJobtClsLogErrorSp(ByVal transNum As Long, ByVal message As String) As Boolean

        Dim success As Boolean = False
        Dim invokeResponse As New InvokeResponseData

        Try
            invokeResponse = Me.Context.Commands.Invoke( _
               "SLJobtCls", _
               "JobtClsLogErrorSp", _
               transNum, _
               message)

            If invokeResponse.IsReturnValueStdError() Then
                message = "JobtClsLogErrorSp failed." ' should never happen, but just in case...
            Else
                success = True
            End If
        Catch ex As Exception
            message = MGException.ExtractMessages(ex)
        End Try

        Return success

    End Function
    Private Function CallJobtMatLogErrorSp(ByVal sessionID As Guid, ByVal transNum As Long, ByVal transSeq As Integer, ByRef message As String) As Boolean

        Dim success As Boolean = False
        Dim invokeResponse As New InvokeResponseData

        Try
            invokeResponse = Me.Context.Commands.Invoke(
               "SLJobtMats",
               "JobtMatLogErrorSp",
               sessionID,
               transNum,
               transSeq,
               message)
            If Not invokeResponse.IsReturnValueStdError() Then success = True
            message = invokeResponse.Parameters(2).Value
        Catch ex As Exception
            message = MGException.ExtractMessages(ex)
        End Try

        Return success

    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function WarningReceiveItemToContainerSp(ByVal ContainerNum As String, ByRef PromptMsg As String, ByRef PromptButtons As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iWarningReceiveItemToContainerExt As IWarningReceiveItemToContainer = New WarningReceiveItemToContainerFactory().Create(appDb)

            Dim oPromptMsg As InfobarType = PromptMsg
            Dim oPromptButtons As InfobarType = PromptButtons

            Dim Severity As Integer = iWarningReceiveItemToContainerExt.WarningReceiveItemToContainerSp(ContainerNum, oPromptMsg, oPromptButtons)

            PromptMsg = oPromptMsg
            PromptButtons = oPromptButtons


            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ApsSyncDeferSetVarsSp(ByVal [SET] As String, ByRef Infobar As String) As Integer Implements IExtFTSLJobTrans.ApsSyncDeferSetVarsSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iApsSyncDeferSetVarsExt As IApsSyncDeferSetVars = New ApsSyncDeferSetVarsFactory().Create(appDb)
            Dim oInfobar As InfobarType = Infobar
            Dim Severity As Integer = iApsSyncDeferSetVarsExt.ApsSyncDeferSetVarsSp([SET], oInfobar)
            Infobar = oInfobar
            Return Severity
        End Using
    End Function



    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ApsSyncImmediateSetVarsSp(ByVal [SET] As String, ByRef Infobar As String,
<[Optional], DefaultParameterValue(0)> ByVal DropDeferred As Integer?) As Integer Implements IExtFTSLJobTrans.ApsSyncImmediateSetVarsSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iApsSyncImmediateSetVarsExt As IApsSyncImmediateSetVars = New ApsSyncImmediateSetVarsFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iApsSyncImmediateSetVarsExt.ApsSyncImmediateSetVarsSp([SET], Infobar, DropDeferred)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CheckSerialSp(ByVal PSerNum As String, ByVal PItem As String, ByRef Infobar As String) As Integer Implements IExtFTSLJobTrans.CheckSerialSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iCheckSerialExt As ICheckSerial = New CheckSerialFactory().Create(appDb)

            Dim oInfobar As InfobarType = Infobar

            Dim Severity As Integer = iCheckSerialExt.CheckSerialSp(PSerNum, PItem, oInfobar)

            Infobar = oInfobar

            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DeleteJobtMatSp(ByVal TransClass As String, ByVal FromTransNum As Decimal?, ByVal ToTransNum As Decimal?, ByVal FromTransDate As DateTime?, ByVal ToTransDate As DateTime?, ByVal FromJob As String, ByVal ToJob As String, ByVal FromSuffix As Short?, ByVal ToSuffix As Short?, ByVal FromItem As String, ByVal ToItem As String, ByVal FromEmpNum As String, ByVal ToEmpNum As String, ByVal FromLoc As String, ByVal ToLoc As String, ByRef CounterItem As Integer?, ByRef Infobar As String,
<[Optional]> ByVal StartingTransDateOffset As Short?,
<[Optional]> ByVal EndingTransDateOffset As Short?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iDeleteJobtMatExt As IDeleteJobtMat = New DeleteJobtMatFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, CounterItem As Integer?, Infobar As String) = iDeleteJobtMatExt.DeleteJobtMatSp(TransClass, FromTransNum, ToTransNum, FromTransDate, ToTransDate, FromJob, ToJob, FromSuffix, ToSuffix, FromItem, ToItem, FromEmpNum, ToEmpNum, FromLoc, ToLoc, CounterItem, Infobar, StartingTransDateOffset, EndingTransDateOffset)
            Dim Severity As Integer = result.ReturnCode.Value
            CounterItem = result.CounterItem
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DeletePendingJobLaborTransSp(ByVal TransClass As String, ByVal FromTransNum As Decimal?, ByVal ToTransNum As Decimal?, ByVal FromJob As String, ByVal FromJobSuffix As Short?, ByVal ToJob As String, ByVal ToJobSuffix As Short?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iDeletePendingJobLaborTransExt As IDeletePendingJobLaborTrans = New DeletePendingJobLaborTransFactory().Create(appDb)

            Dim oInfobar As InfobarType = Infobar

            Dim Severity As Integer = iDeletePendingJobLaborTransExt.DeletePendingJobLaborTransSp(TransClass, FromTransNum, ToTransNum, FromJob, FromJobSuffix, ToJob, ToJobSuffix, oInfobar)

            Infobar = oInfobar

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DeletePSTransSp(ByVal SessionID As Guid?, ByRef Infobar As String) As Integer
        Dim iDeletePSTransExt As IDeletePSTrans = New DeletePSTransFactory().Create(Me, True)
        Dim result As (ReturnCode As Integer?, Infobar As String) = iDeletePSTransExt.DeletePSTransSp(SessionID, Infobar)
        Infobar = result.Infobar
        Return result.ReturnCode.Value
    End Function


    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function DJobTranSP(
<[Optional], DefaultParameterValue("P")> ByVal Delete As String,
<[Optional]> ByVal FromDate As DateTime?,
<[Optional]> ByVal ToDate As DateTime?,
<[Optional]> ByVal FromTraxNum As Decimal?,
<[Optional]> ByVal ToTraxNum As Decimal?,
<[Optional]> ByVal FromJobNum As String,
<[Optional]> ByVal ToJobNum As String,
<[Optional]> ByVal FromJobSuf As Short?,
<[Optional]> ByVal ToJobSuf As Short?,
<[Optional]> ByVal FromEmpNum As String,
<[Optional]> ByVal ToEmpNum As String,
<[Optional], DefaultParameterValue("SRCMIQD")> ByVal TransType As String,
<[Optional]> ByVal JobType As String, ByRef CounterItem As Integer?, ByRef Infobar As String,
<[Optional]> ByVal StartingTransDateOffset As Short?,
<[Optional]> ByVal EndingTransDateOffset As Short?) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim iDJobTranExt As IDJobTran = New DJobTranFactory().Create(appDb, bunchedLoadCollection)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?, CounterItem As Integer?, Infobar As String) = iDJobTranExt.DJobTranSP(Delete, FromDate, ToDate, FromTraxNum, ToTraxNum, FromJobNum, ToJobNum, FromJobSuf, ToJobSuf, FromEmpNum, ToEmpNum, TransType, JobType, CounterItem, Infobar, StartingTransDateOffset, EndingTransDateOffset)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            CounterItem = result.CounterItem
            Infobar = result.Infobar
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetEmpShiftSp(ByVal pEmpNum As String, ByRef pShift As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iGetEmpShiftExt As IGetEmpShift = New GetEmpShiftFactory().Create(appDb)

            Dim opShift As ShiftType = pShift

            Dim Severity As Integer = iGetEmpShiftExt.GetEmpShiftSp(pEmpNum, opShift)

            pShift = opShift

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetItemByJobSp(ByVal pJob As String, ByVal pSuffix As Short?, ByRef pItem As String, ByRef pDescription As String, ByRef pSerialTracked As Byte?, ByRef pLotTracked As Byte?, ByRef pLotPrefix As String, ByRef Infobar As String, ByRef pSerialPrefix As String, ByRef pCostCode As Byte?, ByRef pPeassignSerials As Byte?, ByRef pPreassignLots As Byte?, ByRef pParentJobPeassignSerials As Byte?, ByRef pParentJobPreassignLots As Byte?) As Integer Implements IExtFTSLJobTrans.GetItemByJobSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iGetItemByJobExt As IGetItemByJob = New GetItemByJobFactory().Create(appDb)

            Dim opItem As ItemType = pItem
            Dim opDescription As DescriptionType = pDescription
            Dim opSerialTracked As ListYesNoType = pSerialTracked
            Dim opLotTracked As ListYesNoType = pLotTracked
            Dim opLotPrefix As LotPrefixType = pLotPrefix
            Dim oInfobar As InfobarType = Infobar
            Dim opSerialPrefix As SerialPrefixType = pSerialPrefix
            Dim opCostCode As ListYesNoType = pCostCode
            Dim opPeassignSerials As ListYesNoType = pPeassignSerials
            Dim opPreassignLots As ListYesNoType = pPreassignLots
            Dim opParentJobPeassignSerials As ListYesNoType = pParentJobPeassignSerials
            Dim opParentJobPreassignLots As ListYesNoType = pParentJobPreassignLots

            Dim Severity As Integer = iGetItemByJobExt.GetItemByJobSp(pJob, pSuffix, opItem, opDescription, opSerialTracked, opLotTracked, opLotPrefix, oInfobar, opSerialPrefix, opCostCode, opPeassignSerials, opPreassignLots, opParentJobPeassignSerials, opParentJobPreassignLots)

            pItem = opItem
            pDescription = opDescription
            pSerialTracked = opSerialTracked
            pLotTracked = opLotTracked
            pLotPrefix = opLotPrefix
            Infobar = oInfobar
            pSerialPrefix = opSerialPrefix
            pCostCode = opCostCode
            pPeassignSerials = opPeassignSerials
            pPreassignLots = opPreassignLots
            pParentJobPeassignSerials = opParentJobPeassignSerials
            pParentJobPreassignLots = opParentJobPreassignLots

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function JobBookingCheckSp(ByVal pJob As String, ByVal pSuffix As Short?, ByVal pOperNum As Integer?, ByVal pComplete As Byte?, ByVal pQtyComplete As Decimal?, ByVal pQtyScrapped As Decimal?, ByVal pHasLoc As Byte?, ByRef Infobar As String) As Integer Implements IExtFTSLJobTrans.JobBookingCheckSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iJobBookingCheckExt As IJobBookingCheck = New JobBookingCheckFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iJobBookingCheckExt.JobBookingCheckSp(pJob, pSuffix, pOperNum, pComplete, pQtyComplete, pQtyScrapped, pHasLoc, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function JobtranCloseJobValidSp(ByVal InJob As String, ByVal InSuffix As Short?, ByVal InCloseJob As Byte?, ByRef PromptMsg As String, ByRef PromptButtons As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iJobtranCloseJobValidExt As IJobtranCloseJobValid = New JobtranCloseJobValidFactory().Create(appDb)

            Dim oPromptMsg As InfobarType = PromptMsg
            Dim oPromptButtons As InfobarType = PromptButtons

            Dim Severity As Integer = iJobtranCloseJobValidExt.JobtranCloseJobValidSp(InJob, InSuffix, InCloseJob, oPromptMsg, oPromptButtons)

            PromptMsg = oPromptMsg
            PromptButtons = oPromptButtons

            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function JobtranJobValidSp(ByVal TransType As String, ByVal InJob As String, ByVal OldJob As String, ByRef InSuffix As Short?, ByVal OldSuffix As Short?, ByVal InOperNum As Integer?, ByVal JobOfPreviousRecord As String, ByRef JobCoProdMix As Byte?, ByRef JobOrdType As String, ByRef JobItem As String, ByRef ItemLotTracked As Byte?, ByRef ItemSerialTracked As Byte?, ByRef ItemDesc As String, ByRef ItemUm As String, ByRef JobWhse As String, ByRef JobRootJob As String, ByRef JobRootSuf As Short?, ByRef JobRefJob As String, ByRef JobStat As String, ByRef JobJobType As String, ByRef CntrlPoint As Byte?, ByRef Wc As String, ByRef WcDesc As String, ByRef OperNum As Integer?, ByRef NextOper As Integer?, ByRef NextWc As String, ByRef NextWcDesc As String, ByRef OperComplete As Byte?, ByRef Location As String, ByRef LocDesc As String, ByRef PIssueParent As Byte?, ByRef PProjNum As String, ByRef PTaskNum As Integer?, ByRef PSeq As Integer?, ByRef PromptMsg As String, ByRef PromptButtons As String, ByRef Infobar As String, ByRef JobPreassignLots As Byte?, ByRef JobPreassignSerials As Byte?, ByRef ItemLotPrefix As String, ByRef ItemSerialPrefix As String, ByRef Rework As Byte?,
<[Optional]> ByRef JobRefSuf As Short?,
<[Optional]> ByRef JobpPreassignLots As Byte?,
<[Optional]> ByRef JobpPreassignSerials As Byte?,
<[Optional], DefaultParameterValue(CByte(0))> ByVal AllOperComplete As Byte?,
<[Optional]> ByVal OldTransType As String,
<[Optional]> ByRef NewOldJob As String) As Integer Implements IExtFTSLJobTrans.JobtranJobValidSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iJobtranJobValidExt As IJobtranJobValid = New JobtranJobValidFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, InSuffix As Short?, JobCoProdMix As Byte?, JobOrdType As String, JobItem As String, ItemLotTracked As Byte?, ItemSerialTracked As Byte?, ItemDesc As String, ItemUm As String, JobWhse As String, JobRootJob As String, JobRootSuf As Short?, JobRefJob As String, JobStat As String, JobJobType As String, CntrlPoint As Byte?, Wc As String, WcDesc As String, OperNum As Integer?, NextOper As Integer?, NextWc As String, NextWcDesc As String, OperComplete As Byte?, Location As String, LocDesc As String, PIssueParent As Byte?, PProjNum As String, PTaskNum As Integer?, PSeq As Integer?, PromptMsg As String, PromptButtons As String, Infobar As String, JobPreassignLots As Byte?, JobPreassignSerials As Byte?, ItemLotPrefix As String, ItemSerialPrefix As String, Rework As Byte?, JobRefSuf As Short?, JobpPreassignLots As Byte?, JobpPreassignSerials As Byte?, NewOldJob As String) = iJobtranJobValidExt.JobtranJobValidSp(TransType, InJob, OldJob, InSuffix, OldSuffix, InOperNum, JobOfPreviousRecord, JobCoProdMix, JobOrdType, JobItem, ItemLotTracked, ItemSerialTracked, ItemDesc, ItemUm, JobWhse, JobRootJob, JobRootSuf, JobRefJob, JobStat, JobJobType, CntrlPoint, Wc, WcDesc, OperNum, NextOper, NextWc, NextWcDesc, OperComplete, Location, LocDesc, PIssueParent, PProjNum, PTaskNum, PSeq, PromptMsg, PromptButtons, Infobar, JobPreassignLots, JobPreassignSerials, ItemLotPrefix, ItemSerialPrefix, Rework, JobRefSuf, JobpPreassignLots, JobpPreassignSerials, AllOperComplete, OldTransType, NewOldJob)
            Dim Severity As Integer = result.ReturnCode.Value
            InSuffix = result.InSuffix
            JobCoProdMix = result.JobCoProdMix
            JobOrdType = result.JobOrdType
            JobItem = result.JobItem
            ItemLotTracked = result.ItemLotTracked
            ItemSerialTracked = result.ItemSerialTracked
            ItemDesc = result.ItemDesc
            ItemUm = result.ItemUm
            JobWhse = result.JobWhse
            JobRootJob = result.JobRootJob
            JobRootSuf = result.JobRootSuf
            JobRefJob = result.JobRefJob
            JobStat = result.JobStat
            JobJobType = result.JobJobType
            CntrlPoint = result.CntrlPoint
            Wc = result.Wc
            WcDesc = result.WcDesc
            OperNum = result.OperNum
            NextOper = result.NextOper
            NextWc = result.NextWc
            NextWcDesc = result.NextWcDesc
            OperComplete = result.OperComplete
            Location = result.Location
            LocDesc = result.LocDesc
            PIssueParent = result.PIssueParent
            PProjNum = result.PProjNum
            PTaskNum = result.PTaskNum
            PSeq = result.PSeq
            PromptMsg = result.PromptMsg
            PromptButtons = result.PromptButtons
            Infobar = result.Infobar
            JobPreassignLots = result.JobPreassignLots
            JobPreassignSerials = result.JobPreassignSerials
            ItemLotPrefix = result.ItemLotPrefix
            ItemSerialPrefix = result.ItemSerialPrefix
            Rework = result.Rework
            JobRefSuf = result.JobRefSuf
            JobpPreassignLots = result.JobpPreassignLots
            JobpPreassignSerials = result.JobpPreassignSerials
            NewOldJob = result.NewOldJob
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function JobtranLocValidSp(ByVal Item As String, ByVal Job As String, ByVal Suffix As Short?, ByVal InLoc As String, ByVal Whse As String, ByRef LocDesc As String, ByRef QuestionAsked As Byte?, ByRef PromptMsg As String, ByRef PromptButtons As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iJobtranLocValidExt As IJobtranLocValid = New JobtranLocValidFactory().Create(appDb)

            Dim oLocDesc As DescriptionType = LocDesc
            Dim oQuestionAsked As ListYesNoType = QuestionAsked
            Dim oPromptMsg As InfobarType = PromptMsg
            Dim oPromptButtons As InfobarType = PromptButtons
            Dim oInfobar As InfobarType = Infobar

            Dim Severity As Integer = iJobtranLocValidExt.JobtranLocValidSp(Item, Job, Suffix, InLoc, Whse, oLocDesc, oQuestionAsked, oPromptMsg, oPromptButtons, oInfobar)

            LocDesc = oLocDesc
            QuestionAsked = oQuestionAsked
            PromptMsg = oPromptMsg
            PromptButtons = oPromptButtons
            Infobar = oInfobar

            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function JobtranLotValidSp(ByVal InLot As String, ByVal InItem As String, ByVal RefNum As String, ByVal RefLine As Short?, ByVal RefType As String, ByRef OutLot As String, ByRef AddQuestionAsked As Byte?, ByRef ContQuestionAsked As Byte?, ByRef PromptMsg As String, ByRef PromptButtons As String, ByRef Infobar As String,
<[Optional]> ByVal PreassignLots As Byte?,
<[Optional], DefaultParameterValue(0)> ByVal Quantity As Decimal?,
<[Optional]> ByRef TrxRestrictCode As String) As Integer Implements IExtFTSLJobTrans.JobtranLotValidSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iJobtranLotValidExt As IJobtranLotValid = New JobtranLotValidFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, OutLot As String, AddQuestionAsked As Byte?, ContQuestionAsked As Byte?, PromptMsg As String, PromptButtons As String, Infobar As String, TrxRestrictCode As String) = iJobtranLotValidExt.JobtranLotValidSp(InLot, InItem, RefNum, RefLine, RefType, OutLot, AddQuestionAsked, ContQuestionAsked, PromptMsg, PromptButtons, Infobar, PreassignLots, Quantity, TrxRestrictCode)
            Dim Severity As Integer = result.ReturnCode.Value
            OutLot = result.OutLot
            AddQuestionAsked = result.AddQuestionAsked
            ContQuestionAsked = result.ContQuestionAsked
            PromptMsg = result.PromptMsg
            PromptButtons = result.PromptButtons
            Infobar = result.Infobar
            TrxRestrictCode = result.TrxRestrictCode
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function JobtranNextOperValidSp(ByVal InJob As String, ByVal InSuffix As Short?, ByVal InNextOper As Integer?, ByRef Wc As String, ByRef WcDesc As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iJobtranNextOperValidExt As IJobtranNextOperValid = New JobtranNextOperValidFactory().Create(appDb)

            Dim oWc As WcType = Wc
            Dim oWcDesc As DescriptionType = WcDesc
            Dim oInfobar As InfobarType = Infobar

            Dim Severity As Integer = iJobtranNextOperValidExt.JobtranNextOperValidSp(InJob, InSuffix, InNextOper, oWc, oWcDesc, oInfobar)

            Wc = oWc
            WcDesc = oWcDesc
            Infobar = oInfobar

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function JobtranOperNumValidSp(ByVal TransType As String, ByVal InJob As String, ByVal InSuffix As Short?, ByVal InOperNum As Integer?, ByRef OldOperNum As Integer?, ByRef CntrlPoint As Byte?, ByRef Wc As String, ByRef WcDesc As String, ByRef CostCode As String, ByRef NextOper As Integer?, ByRef NextWc As String, ByRef NextWcDesc As String, ByRef Loc As String, ByRef LocDesc As String, ByRef OperComplete As Byte?, ByRef PromptMsg As String, ByRef PromptButtons As String, ByRef Infobar As String, ByRef JobQtyPerSheet As Decimal?) As Integer Implements IExtFTSLJobTrans.JobtranOperNumValidSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iJobtranOperNumValidExt As IJobtranOperNumValid = New JobtranOperNumValidFactory().Create(appDb)

            Dim oOldOperNum As OperNumType = OldOperNum
            Dim oCntrlPoint As ListYesNoType = CntrlPoint
            Dim oWc As WcType = Wc
            Dim oWcDesc As DescriptionType = WcDesc
            Dim oCostCode As CostCodeType = CostCode
            Dim oNextOper As OperNumType = NextOper
            Dim oNextWc As WcType = NextWc
            Dim oNextWcDesc As DescriptionType = NextWcDesc
            Dim oLoc As LocType = Loc
            Dim oLocDesc As DescriptionType = LocDesc
            Dim oOperComplete As ListYesNoType = OperComplete
            Dim oPromptMsg As InfobarType = PromptMsg
            Dim oPromptButtons As InfobarType = PromptButtons
            Dim oInfobar As InfobarType = Infobar
            Dim oJobQtyPerSheet As QtyUnitType = JobQtyPerSheet

            Dim Severity As Integer = iJobtranOperNumValidExt.JobtranOperNumValidSp(TransType, InJob, InSuffix, InOperNum, oOldOperNum, oCntrlPoint, oWc, oWcDesc, oCostCode, oNextOper, oNextWc, oNextWcDesc, oLoc, oLocDesc, oOperComplete, oPromptMsg, oPromptButtons, oInfobar, oJobQtyPerSheet)

            OldOperNum = oOldOperNum
            CntrlPoint = oCntrlPoint
            Wc = oWc
            WcDesc = oWcDesc
            CostCode = oCostCode
            NextOper = oNextOper
            NextWc = oNextWc
            NextWcDesc = oNextWcDesc
            Loc = oLoc
            LocDesc = oLocDesc
            OperComplete = oOperComplete
            PromptMsg = oPromptMsg
            PromptButtons = oPromptButtons
            Infobar = oInfobar
            JobQtyPerSheet = oJobQtyPerSheet

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function JobtranQtyCompleteValidSp(ByVal InJob As String, ByVal InSuffix As Short?, ByVal InOperNum As Integer?, ByVal InQtyComplete As Decimal?, ByRef PromptMsg As String, ByRef PromptButtons As String) As Integer Implements IExtFTSLJobTrans.JobtranQtyCompleteValidSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iJobtranQtyCompleteValidExt As IJobtranQtyCompleteValid = New JobtranQtyCompleteValidFactory().Create(appDb)

            Dim oPromptMsg As InfobarType = PromptMsg
            Dim oPromptButtons As InfobarType = PromptButtons

            Dim Severity As Integer = iJobtranQtyCompleteValidExt.JobtranQtyCompleteValidSp(InJob, InSuffix, InOperNum, InQtyComplete, oPromptMsg, oPromptButtons)

            PromptMsg = oPromptMsg
            PromptButtons = oPromptButtons

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function JobtranTransTypeValidSp(ByVal InTransType As String, ByVal InJob As String, ByVal InSuffix As Short?, ByVal InTransDate As DateTime?, ByVal InEmpNum As String, ByVal InShift As String, ByVal InTransNum As Decimal?, ByRef OutEmpNum As String, ByRef OutShift As String, ByRef OutPayRate As String, ByRef OutPrRate As Decimal?, ByRef OutJobRate As Decimal?, ByRef OutJob As String, ByRef OutSuffix As Short?, ByRef OutOperNum As Integer?, ByRef OutCoProductMix As Byte?, ByRef OutEmpName As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iJobtranTransTypeValidExt As IJobtranTransTypeValid = New JobtranTransTypeValidFactory().Create(appDb)

            Dim oOutEmpNum As EmpNumType = OutEmpNum
            Dim oOutShift As ShiftType = OutShift
            Dim oOutPayRate As PayBasisType = OutPayRate
            Dim oOutPrRate As PayRateType = OutPrRate
            Dim oOutJobRate As PayRateType = OutJobRate
            Dim oOutJob As JobType = OutJob
            Dim oOutSuffix As SuffixType = OutSuffix
            Dim oOutOperNum As OperNumType = OutOperNum
            Dim oOutCoProductMix As CoProductMixType = OutCoProductMix
            Dim oOutEmpName As NameType = OutEmpName

            Dim Severity As Integer = iJobtranTransTypeValidExt.JobtranTransTypeValidSp(InTransType, InJob, InSuffix, InTransDate, InEmpNum, InShift, InTransNum, oOutEmpNum, oOutShift, oOutPayRate, oOutPrRate, oOutJobRate, oOutJob, oOutSuffix, oOutOperNum, oOutCoProductMix, oOutEmpName)

            OutEmpNum = oOutEmpNum
            OutShift = oOutShift
            OutPayRate = oOutPayRate
            OutPrRate = oOutPrRate
            OutJobRate = oOutJobRate
            OutJob = oOutJob
            OutSuffix = oOutSuffix
            OutOperNum = oOutOperNum
            OutCoProductMix = oOutCoProductMix
            OutEmpName = oOutEmpName

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function JustInTimeGenerateTransNumSp(ByVal SessionID As Guid?, ByRef TJobtranTransNum As Decimal?, ByRef Infobar As String) As Integer Implements IExtFTSLJobTrans.JustInTimeGenerateTransNumSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iJustInTimeGenerateTransNumExt As IJustInTimeGenerateTransNum = New JustInTimeGenerateTransNumFactory().Create(appDb)

            Dim oTJobtranTransNum As HugeTransNumType = TJobtranTransNum
            Dim oInfobar As InfobarType = Infobar

            Dim Severity As Integer = iJustInTimeGenerateTransNumExt.JustInTimeGenerateTransNumSp(SessionID, oTJobtranTransNum, oInfobar)

            TJobtranTransNum = oTJobtranTransNum
            Infobar = oInfobar

            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function JustInTimeTransactionSetVarsSp(ByVal [SET] As String, ByVal TItem As String, ByVal TcQtuQty As Decimal?, ByVal TWhse As String, ByVal TLoc As String, ByVal TLot As String, ByVal TTransDate As DateTime?, ByVal TShift As String, ByVal TEmpNum As String, ByVal PPostNeg As Byte?, ByVal SerialPrefix As String, ByVal SessionID As Guid?, ByRef Infobar As String,
<[Optional]> ByVal DocumentNum As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iJustInTimeTransactionSetVarsExt As IJustInTimeTransactionSetVars = New JustInTimeTransactionSetVarsFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iJustInTimeTransactionSetVarsExt.JustInTimeTransactionSetVarsSp([SET], TItem, TcQtuQty, TWhse, TLoc, TLot, TTransDate, TShift, TEmpNum, PPostNeg, SerialPrefix, SessionID, Infobar, DocumentNum)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function JustInTimeTransactionSp(ByVal TItem As String, ByVal TcQtuQty As Decimal?, ByVal TWhse As String, ByVal TLoc As String, ByVal TLot As String, ByVal TTransDate As DateTime?, ByVal TShift As String, ByVal TEmpNum As String, ByVal PPostNeg As Integer?, ByVal SerialPrefix As String, ByVal SessionID As Guid?, ByRef Infobar As String,
<[Optional]> ByVal ContainerNum As String,
<[Optional]> ByVal DocumentNum As String) As Integer Implements IExtFTSLJobTrans.JustInTimeTransactionSp
        Dim iJustInTimeTransactionExt As IJustInTimeTransaction = New JustInTimeTransactionFactory().Create(Me, True)
        Dim result As (ReturnCode As Integer?, Infobar As String) = iJustInTimeTransactionExt.JustInTimeTransactionSp(TItem, TcQtuQty, TWhse, TLoc, TLot, TTransDate, TShift, TEmpNum, PPostNeg, SerialPrefix, SessionID, Infobar, ContainerNum, DocumentNum)
        Dim Severity As Integer = result.ReturnCode.Value
        Infobar = result.Infobar
        Return Severity
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function MO_LoadCojobQtyPerCycleSp(ByVal Job As String, ByVal Suffix As Short?, ByVal OperNum As Integer?, ByRef MOCoJob As Byte?, ByRef JobQtyPerCycle As Decimal?, ByRef [Shared] As Byte?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iMO_LoadCojobQtyPerCycleExt As IMO_LoadCojobQtyPerCycle = New MO_LoadCojobQtyPerCycleFactory().Create(appDb)

            Dim oMOCoJob As ListYesNoType = MOCoJob
            Dim oJobQtyPerCycle As QtyUnitType = JobQtyPerCycle
            Dim oShared As ListYesNoType = [Shared]

            Dim Severity As Integer = iMO_LoadCojobQtyPerCycleExt.MO_LoadCojobQtyPerCycleSp(Job, Suffix, OperNum, oMOCoJob, oJobQtyPerCycle, oShared)

            MOCoJob = oMOCoJob
            JobQtyPerCycle = oJobQtyPerCycle
            [Shared] = oShared

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function Pojob3PPreSp(ByVal TJob As String, ByVal TSuffix As Integer?, ByVal TOper As Integer?, ByRef TNextOper As Integer?, ByRef TIsLastOper As Integer?, ByRef ParmsLotGenExp As Integer?, ByRef SessionID As Guid?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iPojob3PPreExt As IPojob3PPre = New Pojob3PPreFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, TNextOper As Integer?, TIsLastOper As Integer?, ParmsLotGenExp As Integer?, SessionID As Guid?, Infobar As String) = iPojob3PPreExt.Pojob3PPreSp(TJob, TSuffix, TOper, TNextOper, TIsLastOper, ParmsLotGenExp, SessionID, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            TNextOper = result.TNextOper
            TIsLastOper = result.TIsLastOper
            ParmsLotGenExp = result.ParmsLotGenExp
            SessionID = result.SessionID
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PostWcLaborSp(ByVal pWc As String, ByVal pEmpNum As String, ByVal pAHrs As Decimal?, ByVal pStartTime As Integer?, ByVal pEndTime As Integer?, ByVal pShift As String, ByVal pTransDate As DateTime?, ByVal SessionID As Guid?, ByRef SJobtranTransNum As Decimal?, ByRef tCoby As Byte?, ByRef Infobar As String,
<[Optional]> ByVal DocumentNum As String) As Integer Implements IExtFTSLJobTrans.PostWcLaborSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iPostWcLaborExt As IPostWcLabor = New PostWcLaborFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, SJobtranTransNum As Decimal?, tCoby As Byte?, Infobar As String) = iPostWcLaborExt.PostWcLaborSp(pWc, pEmpNum, pAHrs, pStartTime, pEndTime, pShift, pTransDate, SessionID, SJobtranTransNum, tCoby, Infobar, DocumentNum)
            Dim Severity As Integer = result.ReturnCode.Value
            SJobtranTransNum = result.SJobtranTransNum
            tCoby = result.tCoby
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function Pojob3PSp(ByVal TJob As String, ByVal TSuffix As Short?, ByVal TOper As Integer?, ByVal TTransDate As DateTime?, ByVal TComplete As Decimal?, ByVal TCompleteUM As String, ByVal TScrapped As Decimal?, ByVal TScrappedUM As String, ByVal TMove As Decimal?, ByVal TMovedUM As String, ByVal TNextOper As Integer?, ByVal TRsnCode As String, ByVal TOperComplete As Byte?, ByVal TCloseJob As Byte?, ByVal TIssueParent As Byte?, ByVal TCurWhse As String, ByVal JobMatSessionID As Guid?, ByRef TToLoc As String, ByRef TToLot As String, ByRef RestartPoint As Integer?, ByRef TCoby As Integer?, ByRef XJobtranTransNum As Decimal?, ByRef PromptMsg As String, ByRef PromptButtons As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iPojob3PExt As IPojob3P = New Pojob3PFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, TToLoc As String, TToLot As String, RestartPoint As Integer?, TCoby As Integer?, XJobtranTransNum As Decimal?, PromptMsg As String, PromptButtons As String, Infobar As String) = iPojob3PExt.Pojob3PSp(TJob, TSuffix, TOper, TTransDate, TComplete, TCompleteUM, TScrapped, TScrappedUM, TMove, TMovedUM, TNextOper, TRsnCode, TOperComplete, TCloseJob, TIssueParent, TCurWhse, JobMatSessionID, TToLoc, TToLot, RestartPoint, TCoby, XJobtranTransNum, PromptMsg, PromptButtons, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            TToLoc = result.TToLoc
            TToLot = result.TToLot
            RestartPoint = result.RestartPoint
            TCoby = result.TCoby
            XJobtranTransNum = result.XJobtranTransNum
            PromptMsg = result.PromptMsg
            PromptButtons = result.PromptButtons
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function Pojob3PValidateCloseJobSp(ByVal TJob As String, ByVal TSuffix As Short?, ByVal TOper As Integer?, ByVal TMove As Decimal?, ByVal TNextOper As Integer?, ByVal TCloseJob As Byte?, ByRef ResponseNum As Integer?, ByRef ResponseSeq As Integer?, ByRef PromptMsg As String, ByRef PromptButtons As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iPojob3PValidateCloseJobExt As IPojob3PValidateCloseJob = New Pojob3PValidateCloseJobFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, ResponseNum As Integer?, ResponseSeq As Integer?, PromptMsg As String, PromptButtons As String, Infobar As String) = iPojob3PValidateCloseJobExt.Pojob3PValidateCloseJobSp(TJob, TSuffix, TOper, TMove, TNextOper, TCloseJob, ResponseNum, ResponseSeq, PromptMsg, PromptButtons, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            ResponseNum = result.ResponseNum
            ResponseSeq = result.ResponseSeq
            PromptMsg = result.PromptMsg
            PromptButtons = result.PromptButtons
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function Pojob3PValidateJobWrapperSp(ByVal TJob As String, ByVal TSuffix As Integer?, ByVal TOper As Integer?, ByVal TMove As Decimal?, ByVal TCurWhse As String, ByRef TNextOper As Integer?, ByRef TCompleteUM As String, ByRef TScrappedUM As String, ByRef TMovedUM As String, ByRef TPromptForLoc As Integer?, ByRef TPromptForLot As Integer?, ByRef TPromptCloseJob As Integer?, ByRef TPromptIssueParent As Integer?, ByRef TSerNumTracked As Integer?, ByRef TSerNumPrefix As String, ByRef TIsLastOper As Integer?, ByRef TToLoc As String, ByRef TToLocDescription As String, ByRef TToLot As String, ByRef JobItem As String, ByRef TPreassignLots As Integer?, ByRef Infobar As String,
        <[Optional]> ByRef JobRevision As String,
        <[Optional]> ByRef TItemTrackECN As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iPojob3PValidateJobWrapperExt As IPojob3PValidateJobWrapper = New Pojob3PValidateJobWrapperFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, TNextOper As Integer?, TCompleteUM As String, TScrappedUM As String, TMovedUM As String, TPromptForLoc As Integer?, TPromptForLot As Integer?, TPromptCloseJob As Integer?, TPromptIssueParent As Integer?, TSerNumTracked As Integer?, TSerNumPrefix As String, TIsLastOper As Integer?, TToLoc As String, TToLocDescription As String, TToLot As String, JobItem As String, TPreassignLots As Integer?, Infobar As String, JobRevision As String, TItemTrackECN As Integer?) = iPojob3PValidateJobWrapperExt.Pojob3PValidateJobWrapperSp(TJob, TSuffix, TOper, TMove, TCurWhse, TNextOper, TCompleteUM, TScrappedUM, TMovedUM, TPromptForLoc, TPromptForLot, TPromptCloseJob, TPromptIssueParent, TSerNumTracked, TSerNumPrefix, TIsLastOper, TToLoc, TToLocDescription, TToLot, JobItem, TPreassignLots, Infobar, JobRevision, TItemTrackECN)
            Dim Severity As Integer = result.ReturnCode.Value
            TNextOper = result.TNextOper
            TCompleteUM = result.TCompleteUM
            TScrappedUM = result.TScrappedUM
            TMovedUM = result.TMovedUM
            TPromptForLoc = result.TPromptForLoc
            TPromptForLot = result.TPromptForLot
            TPromptCloseJob = result.TPromptCloseJob
            TPromptIssueParent = result.TPromptIssueParent
            TSerNumTracked = result.TSerNumTracked
            TSerNumPrefix = result.TSerNumPrefix
            TIsLastOper = result.TIsLastOper
            TToLoc = result.TToLoc
            TToLocDescription = result.TToLocDescription
            TToLot = result.TToLot
            JobItem = result.JobItem
            TPreassignLots = result.TPreassignLots
            Infobar = result.Infobar
            JobRevision = result.JobRevision
            TItemTrackECN = result.TItemTrackECN
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function Pojob3PValidateOperCompleteSp(ByVal TJob As String, ByVal TSuffix As Short?, ByVal TOper As Integer?, ByVal TOperComplete As Byte?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iPojob3PValidateOperCompleteExt As IPojob3PValidateOperComplete = New Pojob3PValidateOperCompleteFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iPojob3PValidateOperCompleteExt.Pojob3PValidateOperCompleteSp(TJob, TSuffix, TOper, TOperComplete, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ProcessJobMatlTransSetVarsSp(ByVal [SET] As String, ByVal Job As String, ByVal Suffix As Short?, ByVal OperNum As Integer?, ByVal Sequence As Short?,
<[Optional], DefaultParameterValue(CByte(0))> ByVal DeleteTmpSer As Byte?,
<[Optional], DefaultParameterValue(CByte(0))> ByVal Backflush As Byte?,
<[Optional], DefaultParameterValue(CByte(0))> ByVal ByProduct As Byte?,
<[Optional]> ByVal UM As String, ByVal Item As String,
<[Optional]> ByVal Description As String,
<[Optional]> ByVal Wc As String, ByVal Whse As String,
<[Optional]> ByVal Loc As String,
<[Optional]> ByVal Lot As String, ByVal TransDate As DateTime?, ByVal MatlCost As Decimal?, ByVal LbrCost As Decimal?, ByVal FovhdCost As Decimal?, ByVal VovhdCost As Decimal?, ByVal OutCost As Decimal?, ByVal Cost As Decimal?,
<[Optional]> ByVal PlanCost As Decimal?, ByVal Qty As Decimal?,
<[Optional]> ByVal Acct As String,
<[Optional]> ByVal AcctUnit1 As String,
<[Optional]> ByVal AcctUnit2 As String,
<[Optional]> ByVal AcctUnit3 As String,
<[Optional]> ByVal AcctUnit4 As String,
<[Optional]> ByVal RowPointer As Guid?, ByVal JobmatlRefType As String, ByVal JobmatlRefNum As String, ByVal JobmatlRefLineSuf As Short?, ByVal JobmatlRefRelease As Short?, ByRef Infobar As String, ByVal ImportDocId As String, ByVal JobLot As String, ByVal JobSerial As String, ByVal ContainerNum As String, ByVal RecordDate As DateTime?,
<[Optional]> ByVal EmpNum As String,
<[Optional]> ByVal DocumentNum As String) As Integer Implements IExtFTSLJobTrans.ProcessJobMatlTransSetVarsSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iProcessJobMatlTransSetVarsExt As IProcessJobMatlTransSetVars = New ProcessJobMatlTransSetVarsFactory().Create(appDb, MGInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iProcessJobMatlTransSetVarsExt.ProcessJobMatlTransSetVarsSp([SET], Job, Suffix, OperNum, Sequence, DeleteTmpSer, Backflush, ByProduct, UM, Item, Description, Wc, Whse, Loc, Lot, TransDate, MatlCost, LbrCost, FovhdCost, VovhdCost, OutCost, Cost, PlanCost, Qty, Acct, AcctUnit1, AcctUnit2, AcctUnit3, AcctUnit4, RowPointer, JobmatlRefType, JobmatlRefNum, JobmatlRefLineSuf, JobmatlRefRelease, Infobar, ImportDocId, JobLot, JobSerial, ContainerNum, RecordDate, EmpNum, DocumentNum)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PSGenerateTransNumSp(ByVal SessionID As Guid?, ByRef TJobtranTransNum As Decimal?, ByRef Infobar As String) As Integer Implements IExtFTSLJobTrans.PSGenerateTransNumSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iPSGenerateTransNumExt As IPSGenerateTransNum = New PSGenerateTransNumFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, TJobtranTransNum As Decimal?, Infobar As String) = iPSGenerateTransNumExt.PSGenerateTransNumSp(SessionID, TJobtranTransNum, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            TJobtranTransNum = result.TJobtranTransNum
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function UnPostedJobTranPreDispSp(ByRef rpt_in_hrs As Integer?, ByRef job_stockrm As Integer?, ByRef check_oper_seq As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iUnPostedJobTranPreDispExt As IUnPostedJobTranPreDisp = New UnPostedJobTranPreDispFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, rpt_in_hrs As Integer?, job_stockrm As Integer?, check_oper_seq As String) = iUnPostedJobTranPreDispExt.UnPostedJobTranPreDispSp(rpt_in_hrs, job_stockrm, check_oper_seq)
            Dim Severity As Integer = result.ReturnCode.Value
            rpt_in_hrs = result.rpt_in_hrs
            job_stockrm = result.job_stockrm
            check_oper_seq = result.check_oper_seq
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function WcMachineTimeTransPreSp(ByRef PWorkCenter As String, ByRef TRptInHrs As Integer?, ByRef PromptMsg As String, ByRef PromptButtons As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iWcMachineTimeTransPreExt As IWcMachineTimeTransPre = New WcMachineTimeTransPreFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PWorkCenter As String, TRptInHrs As Integer?, PromptMsg As String, PromptButtons As String, Infobar As String) = iWcMachineTimeTransPreExt.WcMachineTimeTransPreSp(PWorkCenter, TRptInHrs, PromptMsg, PromptButtons, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            PWorkCenter = result.PWorkCenter
            TRptInHrs = result.TRptInHrs
            PromptMsg = result.PromptMsg
            PromptButtons = result.PromptButtons
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function Rpt_WorkCenterTransactionSp(
<[Optional], DefaultParameterValue(Nothing)> ByVal TransGroup As String,
<[Optional]> ByVal WorkCentereStart As String,
<[Optional]> ByVal WorkCenterEnd As String,
<[Optional]> ByVal EmployeeStart As String,
<[Optional]> ByVal EmployeeEnd As String,
<[Optional]> ByVal TransDateStart As DateTime?,
<[Optional]> ByVal TransDateEnd As DateTime?,
<[Optional]> ByVal ShiftStart As String,
<[Optional]> ByVal ShiftEnd As String,
<[Optional]> ByVal TransType As String,
<[Optional]> ByVal DocNumStart As String,
<[Optional]> ByVal DocNumEnd As String,
<[Optional], DefaultParameterValue(Nothing)> ByVal BackflushTrans As String,
<[Optional]> ByVal PStartRecDateOffset As Short?,
<[Optional]> ByVal PEndRecDateOffset As Short?,
<[Optional]> ByVal PrintCost As String,
<[Optional]> ByVal pSite As String,
<[Optional]> ByVal BGUser As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iRpt_WorkCenterTransactionExt As IRpt_WorkCenterTransaction = New Rpt_WorkCenterTransactionFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iRpt_WorkCenterTransactionExt.Rpt_WorkCenterTransactionSp(TransGroup, WorkCentereStart, WorkCenterEnd, EmployeeStart, EmployeeEnd, TransDateStart, TransDateEnd, ShiftStart, ShiftEnd, TransType, DocNumStart, DocNumEnd, BackflushTrans, PStartRecDateOffset, PEndRecDateOffset, PrintCost, pSite, BGUser)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ProcessJobMatlTransSp(ByVal Job As String, ByVal Suffix As Short?, ByVal OperNum As Integer?, ByVal Sequence As Short?,
<[Optional], DefaultParameterValue(CByte(0))> ByVal DeleteTmpSer As Byte?,
<[Optional], DefaultParameterValue(CByte(0))> ByVal Backflush As Byte?,
<[Optional], DefaultParameterValue(CByte(0))> ByVal ByProduct As Byte?,
<[Optional]> ByVal UM As String, ByVal Item As String,
<[Optional]> ByVal Description As String,
<[Optional]> ByVal Wc As String, ByVal Whse As String,
<[Optional]> ByVal Loc As String,
<[Optional]> ByVal Lot As String, ByVal TransDate As DateTime?, ByVal MatlCost As Decimal?, ByVal LbrCost As Decimal?, ByVal FovhdCost As Decimal?, ByVal VovhdCost As Decimal?, ByVal OutCost As Decimal?, ByVal Cost As Decimal?,
<[Optional]> ByVal PlanCost As Decimal?, ByVal Qty As Decimal?,
<[Optional]> ByVal Acct As String,
<[Optional]> ByVal AcctUnit1 As String,
<[Optional]> ByVal AcctUnit2 As String,
<[Optional]> ByVal AcctUnit3 As String,
<[Optional]> ByVal AcctUnit4 As String,
<[Optional]> ByVal RowPointer As Guid?, ByVal JobmatlRefType As String, ByVal JobmatlRefNum As String, ByVal JobmatlRefLineSuf As Short?, ByVal JobmatlRefRelease As Short?, ByRef Infobar As String, ByVal ImportDocId As String,
<[Optional]> ByVal JobLot As String,
<[Optional]> ByVal JobSerial As String,
<[Optional]> ByVal ContainerNum As String,
<[Optional]> ByVal RecordDate As DateTime?,
<[Optional]> ByVal EmpNum As String,
<[Optional]> ByVal DocumentNum As String) As Integer Implements IExtFTSLJobTrans.ProcessJobMatlTransSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iProcessJobMatlTransExt As IProcessJobMatlTrans = New ProcessJobMatlTransFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iProcessJobMatlTransExt.ProcessJobMatlTransSp(Job, Suffix, OperNum, Sequence, DeleteTmpSer, Backflush, ByProduct, UM, Item, Description, Wc, Whse, Loc, Lot, TransDate, MatlCost, LbrCost, FovhdCost, VovhdCost, OutCost, Cost, PlanCost, Qty, Acct, AcctUnit1, AcctUnit2, AcctUnit3, AcctUnit4, RowPointer, JobmatlRefType, JobmatlRefNum, JobmatlRefLineSuf, JobmatlRefRelease, Infobar, ImportDocId, JobLot, JobSerial, ContainerNum, RecordDate, EmpNum, DocumentNum)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function SetIssueParentSp(ByVal PJob As String, ByVal PSuffix As Short?, ByRef PIssueParent As Byte?, ByRef PProjNum As String, ByRef PTaskNum As Integer?, ByRef PSeq As Integer?, ByRef Infobar As String) As Integer Implements IExtFTSLJobTrans.SetIssueParentSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iSetIssueParentExt As ISetIssueParent = New SetIssueParentFactory().Create(appDb)
            Dim Severity As Integer = iSetIssueParentExt.SetIssueParentSp(PJob, PSuffix, PIssueParent, PProjNum, PTaskNum, PSeq, Infobar)
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GenerateGUIDSp(ByRef GUID As Guid?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iGenerateGUIDExt As IGenerateGUID = New GenerateGUIDFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, GUID As System.Guid?) = iGenerateGUIDExt.GenerateGUIDSp(GUID)
            Dim Severity As Integer = result.ReturnCode.Value
            GUID = result.GUID
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function JobtranCalcRateSp(ByVal InPayRate As String, ByVal InEmpNum As String, ByVal InShift As String, ByVal InTransDate As DateTime?, ByRef OutPrRate As Decimal?, ByRef OutJobRate As Decimal?) As Integer Implements IExtFTSLJobTrans.JobtranCalcRateSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iJobtranCalcRateExt As IJobtranCalcRate = New JobtranCalcRateFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, OutPrRate As Decimal?, OutJobRate As Decimal?) = iJobtranCalcRateExt.JobtranCalcRateSp(InPayRate, InEmpNum, InShift, InTransDate, OutPrRate, OutJobRate)
            Dim Severity As Integer = result.ReturnCode.Value
            OutPrRate = result.OutPrRate
            OutJobRate = result.OutJobRate
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function JobtranEmpValidSp(ByVal EmpNum As String, ByVal PayRate As String, ByVal TransDate As DateTime?, ByRef OutShift As String, ByRef OutEmpName As String, ByRef OutPrRate As Decimal?, ByRef OutJobRate As Decimal?, ByRef PromptMsg As String, ByRef PromptButtons As String) As Integer Implements IExtFTSLJobTrans.JobtranEmpValidSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iJobtranEmpValidExt As IJobtranEmpValid = New JobtranEmpValidFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, OutShift As String, OutEmpName As String, OutPrRate As Decimal?, OutJobRate As Decimal?, PromptMsg As String, PromptButtons As String) = iJobtranEmpValidExt.JobtranEmpValidSp(EmpNum, PayRate, TransDate, OutShift, OutEmpName, OutPrRate, OutJobRate, PromptMsg, PromptButtons)
            Dim Severity As Integer = result.ReturnCode.Value
            OutShift = result.OutShift
            OutEmpName = result.OutEmpName
            OutPrRate = result.OutPrRate
            OutJobRate = result.OutJobRate
            PromptMsg = result.PromptMsg
            PromptButtons = result.PromptButtons
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ApsSyncDeferSp(ByRef Infobar As String,
    <[Optional]> ByVal Context As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim MGInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iApsSyncDeferExt As IApsSyncDefer = New ApsSyncDeferFactory().Create(appDb, MGInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iApsSyncDeferExt.ApsSyncDeferSp(Infobar, Context)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ApsSyncImmediateSp(ByRef Infobar As String,
        <[Optional], DefaultParameterValue(0)> ByVal DropDeferred As Integer?,
        <[Optional]> ByVal Context As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iApsSyncImmediateExt As IApsSyncImmediate = New ApsSyncImmediateFactory().Create(Me, True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iApsSyncImmediateExt.ApsSyncImmediateSp(Infobar, DropDeferred, Context)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function BuildSerialSp(ByVal TransNum As Decimal?, ByRef Infobar As String,
<[Optional]> ByVal ContainerNum As String,
<[Optional]> ByVal ManufacturedDate As DateTime?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iBuildSerialExt As IBuildSerial = New BuildSerialFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iBuildSerialExt.BuildSerialSp(TransNum, Infobar, ContainerNum, ManufacturedDate)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CoProductSaveSp(
        <[Optional]> ByVal TmpCoProduct As Guid?,
        <[Optional]> ByVal RefStr As String, ByRef Infobar As String,
        <[Optional]> ByVal Item As String,
        <[Optional]> ByVal QtyComplete As Decimal?,
        <[Optional]> ByVal QtyScrapped As Decimal?,
        <[Optional]> ByVal QtyMoved As Decimal?,
        <[Optional]> ByVal ReasonCode As String,
        <[Optional]> ByVal NextOper As Integer?,
        <[Optional]> ByVal Loc As String,
        <[Optional]> ByVal Lot As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCoProductSaveExt As ICoProductSave = New CoProductSaveFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iCoProductSaveExt.CoProductSaveSp(TmpCoProduct, RefStr, Infobar, Item, QtyComplete, QtyScrapped, QtyMoved, ReasonCode, NextOper, Loc, Lot)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DeleteJobtranitemSp(ByVal TransNum As Decimal?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iDeleteJobtranitemExt As IDeleteJobtranitem = New DeleteJobtranitemFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iDeleteJobtranitemExt.DeleteJobtranitemSp(TransNum)
            Dim Severity As Integer = result.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function JobJobPJobtPcISp(ByVal pTransNum As Decimal?, ByVal SessionId As Guid?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iJobJobPJobtPcIExt As IJobJobPJobtPcI = New JobJobPJobtPcIFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iJobJobPJobtPcIExt.JobJobPJobtPcISp(pTransNum, SessionId, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function JobP2Sp(ByVal SJobtranRowPointer As Guid?,
        <[Optional], DefaultParameterValue(0)> ByVal PPostNeg As Integer?, ByRef TCoby As Integer?, ByRef Infobar As String,
        <[Optional]> ByVal CurWhse As String,
        <[Optional]> ByRef PromptButtons As String,
        <[Optional]> ByVal DocumentNum As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iJobP2Ext As IJobP2 = New JobP2Factory().Create(Me, True)
            Dim result As (ReturnCode As Integer?, TCoby As Integer?, Infobar As String, PromptButtons As String) = iJobP2Ext.JobP2Sp(SJobtranRowPointer, PPostNeg, TCoby, Infobar, CurWhse, PromptButtons, DocumentNum)
            Dim Severity As Integer = result.ReturnCode.Value
            TCoby = result.TCoby
            Infobar = result.Infobar
            PromptButtons = result.PromptButtons
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function JobPMessagesSp(ByVal TNone As Byte?, ByVal TMatCount As Integer?, ByVal TClsCount As Integer?, ByVal ErrorOccurred As Byte?, ByVal CurTransNum As Decimal?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iJobPMessagesExt As IJobPMessages = New JobPMessagesFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iJobPMessagesExt.JobPMessagesSp(TNone, TMatCount, TClsCount, ErrorOccurred, CurTransNum, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function JobRBookingCheckSp(ByVal Job As String, ByVal Suffix As Integer?, ByVal Qty As Decimal?, ByVal Override As Integer?, ByRef CanOverride As Integer?, ByRef Infobar As String,
        <[Optional]> ByVal JobItem As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iJobRBookingCheckExt As IJobRBookingCheck = New JobRBookingCheckFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, CanOverride As Integer?, Infobar As String) = iJobRBookingCheckExt.JobRBookingCheckSp(Job, Suffix, Qty, Override, CanOverride, Infobar, JobItem)
            Dim Severity As Integer = result.ReturnCode.Value
            CanOverride = result.CanOverride
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function JobtPcISp(ByVal JobtClsJtTransNum As Decimal?,
        <[Optional]> ByVal TCoby As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iJobtPcIExt As IJobtPcI = New JobtPcIFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iJobtPcIExt.JobtPcISp(JobtClsJtTransNum, TCoby, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function JobtPostSp(ByVal SessionId As Guid?, ByVal CallFrom As String, ByVal PTransNum As Decimal?, ByVal PTransSeq As Integer?, ByRef Infobar As String,
        <[Optional]> ByVal DocumentNum As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iJobtPostExt As IJobtPost = New JobtPostFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iJobtPostExt.JobtPostSp(SessionId, CallFrom, PTransNum, PTransSeq, Infobar, DocumentNum)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function JobtranPostSaveSp(ByVal Job As String, ByVal Suffix As Short?, ByVal OperNum As Integer?, ByVal Wc As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iJobtranPostSaveExt As IJobtranPostSave = New JobtranPostSaveFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iJobtranPostSaveExt.JobtranPostSaveSp(Job, Suffix, OperNum, Wc)
            Dim Severity As Integer = result.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function JobtranPreSaveSp(ByVal Job As String, ByVal Suffix As Short?, ByVal OperNum As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iJobtranPreSaveExt As IJobtranPreSave = New JobtranPreSaveFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iJobtranPreSaveExt.JobtranPreSaveSp(Job, Suffix, OperNum, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function Pojob3PValidateJobSp(ByVal TJob As String, ByVal TSuffix As Integer?, ByVal TOper As Integer?, ByVal TNextOper As Integer?, ByRef TCompleteUM As String, ByRef TScrappedUM As String, ByRef TMovedUM As String, ByRef TPromptForLoc As Integer?, ByRef TPromptForLot As Integer?, ByRef TPromptCloseJob As Integer?, ByRef TPromptIssueParent As Integer?, ByRef TSerNumTracked As Integer?, ByRef TSerNumPrefix As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iPojob3PValidateJobExt As IPojob3PValidateJob = New Pojob3PValidateJobFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, TCompleteUM As String, TScrappedUM As String, TMovedUM As String, TPromptForLoc As Integer?, TPromptForLot As Integer?, TPromptCloseJob As Integer?, TPromptIssueParent As Integer?, TSerNumTracked As Integer?, TSerNumPrefix As String, Infobar As String) = iPojob3PValidateJobExt.Pojob3PValidateJobSp(TJob, TSuffix, TOper, TNextOper, TCompleteUM, TScrappedUM, TMovedUM, TPromptForLoc, TPromptForLot, TPromptCloseJob, TPromptIssueParent, TSerNumTracked, TSerNumPrefix, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            TCompleteUM = result.TCompleteUM
            TScrappedUM = result.TScrappedUM
            TMovedUM = result.TMovedUM
            TPromptForLoc = result.TPromptForLoc
            TPromptForLot = result.TPromptForLot
            TPromptCloseJob = result.TPromptCloseJob
            TPromptIssueParent = result.TPromptIssueParent
            TSerNumTracked = result.TSerNumTracked
            TSerNumPrefix = result.TSerNumPrefix
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PostJobTransactions1Sp(ByVal SessionID As Guid?, ByVal SJobtranRowPointer As Guid?, ByVal PPostNeg As Integer?, ByVal CurWhse As String, ByRef Infobar As String,
    <[Optional]> ByRef PromptButtons As String,
    <[Optional]> ByVal DocumentNum As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iPostJobTransactions1Ext As IPostJobTransactions1 = New PostJobTransactions1Factory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String, PromptButtons As String) = iPostJobTransactions1Ext.PostJobTransactions1Sp(SessionID, SJobtranRowPointer, PPostNeg, CurWhse, Infobar, PromptButtons, DocumentNum)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            PromptButtons = result.PromptButtons
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DeleteTmpJobTranItemSp(ByVal TmpJobTranItemId As Guid?) As Integer
        Dim iDeleteTmpJobTranItemExt As IDeleteTmpJobTranItem = New DeleteTmpJobTranItemFactory().Create(Me, True)
        Dim result As Integer? = iDeleteTmpJobTranItemExt.DeleteTmpJobTranItemSp(TmpJobTranItemId)
        Dim Severity As Integer = result.Value
        Return Severity
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function RSQC_CreateJITReceiverSp(ByVal i_QtyReceived As Decimal?, ByVal i_Whse As String, ByVal i_Item As String, ByVal i_CallingFunction As String, ByRef o_PopUp As Integer?, ByRef o_PrintTag As Integer?, ByRef o_RcvrNums As String, ByRef o_Messages As String, ByRef Infobar As String) As Integer
        Dim iRSQC_CreateJITReceiverExt As IRSQC_CreateJITReceiver = New RSQC_CreateJITReceiverFactory().Create(Me, True)
        Dim result As (ReturnCode As Integer?, o_PopUp As Integer?, o_PrintTag As Integer?, o_RcvrNums As String, o_Messages As String, Infobar As String) = iRSQC_CreateJITReceiverExt.RSQC_CreateJITReceiverSp(i_QtyReceived, i_Whse, i_Item, i_CallingFunction, o_PopUp, o_PrintTag, o_RcvrNums, o_Messages, Infobar)
        Dim Severity As Integer = result.ReturnCode.Value
        o_PopUp = result.o_PopUp
        o_PrintTag = result.o_PrintTag
        o_RcvrNums = result.o_RcvrNums
        o_Messages = result.o_Messages
        Infobar = result.Infobar
        Return Severity
    End Function
End Class

