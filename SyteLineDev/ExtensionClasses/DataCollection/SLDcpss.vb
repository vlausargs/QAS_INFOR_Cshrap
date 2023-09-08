Option Explicit On
Option Strict On

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common
Imports Microsoft.VisualBasic.Strings
Imports CSI.Data.SQL.UDDT
Imports System
Imports System.Data
Imports CSI.DataCollection
Imports CSI.MG
Imports System.Runtime.InteropServices

<IDOExtensionClass("SLDcpss")> _
Public Class SLDcpss
    Inherits ExtensionClassBase
    Const POSTSEQ As Long = 1000000000

    <IDOMethod(MethodFlags.None, "Infobar")> _
    Public Function DcpsPVb(ByVal PDcpsType As String, _
                            ByVal PPostDate As Nullable(Of DateTime), _
                            ByRef Infobar As String) As Integer
        Dim oCollection As LoadCollectionResponseData
        Dim Filter As String
        Dim TransNum As Long
        Dim DocumentNum As String
        Dim TransSeq As Long
        Dim SessionID As Guid
        Dim ResponseData As InvokeResponseData = Nothing
        Dim iErrorFlag As Integer
        Dim dDerSiteDate As DateTime

        DcpsPVb = 0

        oCollection = Me.Context.Commands.LoadCollection("SLDcparms", "DerSiteDate", "", "", 0)
        If oCollection.Items.Count > 0 Then
            dDerSiteDate = oCollection.Item(0, "DerSiteDate").GetValue(Of DateTime)()
        End If

        If IDONull.IsNull(PPostDate) Then
            PPostDate = dDerSiteDate
        End If

        Filter = String.Format( _
           "CHARINDEX(Stat, 'UP') > 0 AND TransType  = {0} AND TransNum > 0 " & _
           "AND PostDate <= dbo.DayEndOf({1})", _
           SqlLiteral.Format(PDcpsType), _
           SqlLiteral.Format(PPostDate))

        ' jac: get session ID from IDORuntime.Context
        SessionID = IDORuntime.Context.SessionID

        Try ' Global Exception
            oCollection = Me.LoadCollection("TransNum, DocumentNum", Filter, String.Empty, 0)
            For index As Integer = 0 To oCollection.Items.Count - 1
                TransNum = oCollection(index, "TransNum").GetValue(Of Integer)(0)
                DocumentNum = oCollection(index, "DocumentNum").Value
                Try
                    ResponseData = Me.Invoke("DcpsPSp", PDcpsType, TransNum, Infobar, DocumentNum)
                    Infobar = ResponseData.Parameters(2).Value
                Catch ex As Exception ' Catching exception during execution on DcpsPSp 
                    Infobar = MGException.ExtractMessages(ex)
                    iErrorFlag = 1
                End Try

                If ResponseData.IsReturnValueStdError Or iErrorFlag = 1 Then
                    ResponseData = Me.Invoke("DcpsLogErrorSp", TransNum, Infobar)
                    If ResponseData.IsReturnValueStdError Then
                        DcpsPVb = ResponseData.GetReturnValue(Of Integer)()
                        Infobar = "UNKNOWN ERROR CALLING DcpsLogErrorSp"
                        Exit Function
                    End If
                End If
            Next

            oCollection = Me.Context.Commands.LoadCollection( _
               "SLttJobtMatPosts", _
               "TransNum, TransSeq", _
               String.Format("SessionID = {0}", SqlLiteral.Format(SessionID)), _
               "", 0)

            For index As Integer = 0 To oCollection.Items.Count - 1
                TransNum = oCollection(index, "TransNum").GetValue(Of Integer)(0)
                TransSeq = oCollection(index, "TransSeq").GetValue(Of Long)(0)
                Try
                    If TransSeq <> POSTSEQ Then
                        ResponseData = Me.Context.Commands.Invoke("SLJobTrans", "JobtPostSp", SessionID, "", TransNum, TransSeq, Infobar)
                        Infobar = ResponseData.Parameters(4).Value
                        If ResponseData.IsReturnValueStdError Then
                            ResponseData = Me.Context.Commands.Invoke("SLJobtMats", "JobtMatLogErrorSp", SessionID, TransNum, TransSeq, Infobar)
                        End If
                    Else            'After 100000
                        ResponseData = Me.Context.Commands.Invoke("SLJobTrans", "JobJobPJobtPcISp", TransNum, SessionID, Infobar)
                        Infobar = ResponseData.Parameters(2).Value
                        If ResponseData.IsReturnValueStdError Then
                            ResponseData = Me.Context.Commands.Invoke("SLJobtCls", "JobtClsLogErrorSp", TransNum, Infobar)
                        End If
                    End If
                Catch ex As Exception
                    Infobar = "System Error: TransNum:" & TransNum & _
                                            vbCrLf & MGException.ExtractMessages(ex)
                    DcpsPVb = 16
                    Exit Function
                End Try
            Next

        Catch ex As Exception 'Global Exception
            Infobar = Infobar & ":" & MGException.ExtractMessages(ex)
            DcpsPVb = 16
        Finally
            oCollection = Nothing
            ResponseData = Nothing
        End Try
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcpsDSp(ByVal Status As String, ByVal TransType As String, ByVal FromTransNum As Decimal?, ByVal ToTransNum As Decimal?, ByVal FromTransDate As DateTime?, ByVal ToTransDate As DateTime?, ByRef Infobar As String,
<[Optional]> ByVal StartingTransDateOffset As Short?,
<[Optional]> ByVal EndingTransDateOffset As Short?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iDcpsDExt As IDcpsD = New DcpsDFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iDcpsDExt.DcpsDSp(Status, TransType, FromTransNum, ToTransNum, FromTransDate, ToTransDate, Infobar, StartingTransDateOffset, EndingTransDateOffset)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcAPsSp(ByVal TermId As String, ByVal PTransType As String, ByVal EmpNum As String, ByVal TTransDate As DateTime?, ByVal PsItem As String, ByVal PsNum As String, ByVal Wc As String, ByVal OperNum As Integer?, ByVal Qty As Decimal?, ByVal Loc As String, ByVal Lot As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iDcAPsExt As IDcAPs = New DcAPsFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iDcAPsExt.DcAPsSp(TermId, PTransType, EmpNum, TTransDate, PsItem, PsNum, Wc, OperNum, Qty, Loc, Lot, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcpsLogErrorSp(ByVal PTransNum As Integer?, ByVal ErrorMsg As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iDcpsLogErrorExt As IDcpsLogError = New DcpsLogErrorFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iDcpsLogErrorExt.DcpsLogErrorSp(PTransNum, ErrorMsg)
            Dim Severity As Integer = result.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcpsPSp(ByVal PDcpsType As String, ByVal PTransNum As Integer?, ByRef Infobar As String,
<[Optional]> ByVal DocumentNum As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iDcpsPExt As IDcpsP = New DcpsPFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iDcpsPExt.DcpsPSp(PDcpsType, PTransNum, Infobar, DocumentNum)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function
End Class
