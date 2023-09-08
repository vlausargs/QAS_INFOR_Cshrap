Option Explicit On
Option Strict On

Imports CSI.Data.RecordSets
Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common
Imports CSI.Data.SQL.UDDT
Imports System
Imports System.Data
Imports CSI.DataCollection
Imports CSI.MG
Imports System.Runtime.InteropServices
<IDOExtensionClass("SLDcsfcs")> _
Public Class SLDcsfcs
    Inherits CSIExtensionClassBase
    <IDOMethod(MethodFlags.None, "Infobar")> _
    Public Function DcsfcPVb(ByVal PPostDate As Nullable(Of DateTime), _
                                ByRef Infobar As String) As Integer

        Dim ResponseData As New InvokeResponseData
        Dim oCollection As LoadCollectionResponseData
        Dim Filter As String
        Dim TransNum As Long
        Dim RowPointer As Guid
        Dim iDelCount As Long
        Dim CanOverride As Object
        Dim StopPost As String
        Dim bAutoPostJob As Boolean
        Dim dDerSiteDate As DateTime
        Dim PostJobInfobar As String
        Dim PostJobInfobarBuffer As String
        Dim ApsSyncInfobar As String = String.Empty
        Dim bApsSyncDefer As Boolean
        Dim orderBy As String

        Dim TransClass As String
        Dim Job As String
        Dim Suffix As String
        Dim EmpNum As String
        Dim TransType As String
        Dim DocumentNum As String
        Dim PostMode As Integer

        Dim PostComplete As Byte
        Dim Whse As String = Nothing
        Dim Wc As String

        ' Try
        iDelCount = 0
        PostJobInfobar = ""
        PostJobInfobarBuffer = ""
        bApsSyncDefer = False
        DcsfcPVb = 0

        Try
            oCollection = Me.Context.Commands.LoadCollection("SLDcparms", "AutoPostJob, DerSiteDate", "", "", 0)
            If oCollection.Items.Count > 0 Then
                bAutoPostJob = oCollection.Item(0, "AutoPostJob").GetValue(Of Boolean)()
                dDerSiteDate = oCollection.Item(0, "DerSiteDate").GetValue(Of DateTime)()
            End If

            ' Defer APS sync transactions
            If bAutoPostJob Then
                oCollection = Me.Context.Commands.LoadCollection("SLInvparms", "DefWhse", "", "", 0)
                If oCollection.Items.Count > 0 Then
                    Whse = oCollection.Item(0, "DefWhse").GetValue(Of String)()
                End If
                ResponseData = Me.Context.Commands.Invoke("SLJobTrans", "ApsSyncDeferSp", Infobar, "SLDcfcs.DcsfcPVb()")
                Infobar = ResponseData.Parameters(0).Value
                If ResponseData.IsReturnValueStdError Then
                    DcsfcPVb = 16
                    Exit Function
                Else
                    bApsSyncDefer = True
                End If
            End If

            StopPost = "0"
            CanOverride = 0

            If IDONull.IsNull(PPostDate) Then
                PPostDate = dDerSiteDate
            End If

            Filter = "CHARINDEX(Stat, 'UPE') > 0 AND TransType  <> ''"
            Filter = Filter & " And PostDate <= dbo.DayEndOf(" & SqlLiteral.Format(PPostDate) & ")"
            orderBy = "EmpNum, PostDate, DerSortTime"

            oCollection = Me.LoadCollection("TransNum, RowPointer", Filter, orderBy, 0)

            For index As Integer = 0 To oCollection.Items.Count - 1
                Infobar = ""
                RowPointer = oCollection.Item(index, "RowPointer").GetValue(Of Guid)()
                TransNum = oCollection.Item(index, "TransNum").GetValue(Of Long)()
                Try
                    ResponseData = Me.Invoke("DcDcsfcPSp", RowPointer, PPostDate, StopPost, CanOverride, Infobar)
                    StopPost = ResponseData.Parameters(2).Value
                    CanOverride = ResponseData.Parameters(3).Value
                    Infobar = ResponseData.Parameters(4).Value
                Catch ex As Exception
                    Infobar = "System Error: DcDcsfcPSp(TransNum:" & TransNum &
                              vbCrLf & MGException.ExtractMessages(ex) & ")"
                    DcsfcPVb = 16
                    Exit For
                End Try

                If ResponseData.IsReturnValueStdError Then
                    ResponseData = Me.Invoke("DcsfcLogErrorSp", TransNum, CanOverride, Infobar)
                    Infobar = ResponseData.Parameters(2).Value
                    If ResponseData.IsReturnValueStdError Then
                        Infobar = "UNKNOWN ERROR CALLING DcsfcLogErrorSp"
                        DcsfcPVb = 16
                        Exit For
                    End If
                End If
                If StopPost = "1" Then
                    ' [Post] is being performed by another user.
                    DcsfcPVb = 16
                    Exit For
                End If
            Next

            If DcsfcPVb = 0 Then

                'create jobtran and validate
                'Post the transaction records based on the PostMode = 1/2/3
                For PostMode = 1 To 3
                    Filter = "CHARINDEX(Stat, 'I') > 0"
                    Filter = Filter & " And PostDate <= dbo.DayEndOf(" & SqlLiteral.Format(PPostDate) & ")"

                    Select Case PostMode
                        Case 1 'Post all dcscf's that don't close anything.
                            Filter = Filter & " and CompleteOp = 0 and CloseJob = 0"

                        Case 2 'Post all dcsfc's that close only a single operation
                            Filter = Filter & " and CompleteOp = 1 and CloseJob = 0"

                        Case 3 'Post all dcsfc's that close the job
                            Filter = Filter & " and CloseJob = 1"

                    End Select

                    oCollection = Nothing
                    oCollection = Me.LoadCollection("Job, Suffix, EmpNum, TransNum, TransType, Termid, Wc, DocumentNum", Filter, orderBy, 0)

                    For index As Integer = 0 To oCollection.Items.Count - 1
                        TransType = oCollection(index, "TransType").Value

                        If InStr("123456789DEFGHJ", TransType) = 0 Or
                            (bAutoPostJob And
                              (Not String.IsNullOrEmpty(oCollection(index, "Termid").Value) Or TransType = "7")
                            ) Then

                            Job = oCollection(index, "Job").Value
                            Suffix = oCollection(index, "Suffix").Value
                            EmpNum = oCollection(index, "EmpNum").Value
                            Wc = oCollection(index, "Wc").Value
                            DocumentNum = oCollection(index, "DocumentNum").Value

                            If PostMode = 1 Then
                                PostComplete = 0
                            Else
                                PostComplete = 1
                            End If

                            If InStr("123456789DEFGHJ", TransType) <> 0 Then
                                TransClass = "J"
                            Else
                                TransClass = "W"
                            End If

                            Try
                                If TransClass = "J" Then
                                    ResponseData = Me.Context.Commands.Invoke("SLJobTrans", "JobJobP", PostComplete, 1, Job, Job, Suffix, Suffix, "", "",
                                                                                  EmpNum, EmpNum, "", "", "", "", "", "", "H S N", Whse, "", "", PostJobInfobar, "", "", DocumentNum)
                                Else
                                    ResponseData = Me.Context.Commands.Invoke("SLJobTrans", "JobJobP", PostComplete, 1, "", "", "", "", "", "",
                                                                                  EmpNum, EmpNum, "", "", "", "", "", "", "H S N", Whse, "", "", PostJobInfobar, "", Wc, DocumentNum)
                                End If
                            Catch ex As Exception
                                If TransClass = "J" Then
                                    Infobar = "System Error: JobJobP(EmpNum:" & EmpNum & ", Job:" & Job & "-" & Suffix &
                                                                   vbCrLf & MGException.ExtractMessages(ex)
                                Else
                                    Infobar = "System Error: JobJobP(EmpNum:" & EmpNum & ", Wc:" & Wc &
                                                                   vbCrLf & MGException.ExtractMessages(ex)
                                End If
                                DcsfcPVb = 16
                                Exit For
                            End Try

                            If ResponseData.IsReturnValueStdError Then
                                PostJobInfobar = ResponseData.Parameters(20).Value

                                If TransClass = "J" Then
                                    Infobar = "Standard Error: JobJobP(EmpNum:" & EmpNum & ", Job:" & Job & "-" & Suffix &
                                                                   vbCrLf & PostJobInfobar
                                Else
                                    Infobar = "Standard Error: JobJobP(EmpNum:" & EmpNum & ", Wc:" & Wc &
                                                                   vbCrLf & PostJobInfobar
                                End If

                                DcsfcPVb = 16
                                Exit For
                            End If

                        End If ' AutoPostJob

                        'Delete dcsfc
                        TransNum = oCollection(index, "TransNum").GetValue(Of Long)()
                        Infobar = ""

                        Try
                            ResponseData = Me.Invoke("DcsfcDSp", "", "", "", "", TransNum, TransNum, "", "", "", "", Infobar, "", "", iDelCount)
                            Infobar = ResponseData.Parameters(10).Value
                            iDelCount = ResponseData.Parameters(13).GetValue(Of Long)(0)
                            If ResponseData.IsReturnValueStdError Then
                                DcsfcPVb = 16
                                Exit For
                            End If
                        Catch ex As Exception
                            Infobar = "System Error: DcsfcDSp(TransNum:" & TransNum & _
                                      vbCrLf & MGException.ExtractMessages(ex) & ")"
                            DcsfcPVb = 16
                            Exit For
                        End Try
                    Next

                    If DcsfcPVb <> 0 Then
                        Exit For
                    End If
                Next
            End If

            'Format prevouse loop post warnings for DcBackground log file
            If PostJobInfobarBuffer <> "" Then
                If Infobar <> "" Then
                    Infobar = PostJobInfobarBuffer & vbCrLf & Infobar
                Else
                    Infobar = PostJobInfobarBuffer
                End If
            End If

        Catch ex As Exception
            Infobar = MGException.ExtractMessages(ex)
        Finally
            ' Deal with deferred APS transactions
            If bApsSyncDefer Then
                Try
                    If DcsfcPVb = 0 Then
                        ResponseData = Me.Context.Commands.Invoke("SLJobTrans", "ApsSyncImmediateSp", ApsSyncInfobar, 0, "SLDcfcs.DcsfcPVb()")
                    Else
                        ResponseData = Me.Context.Commands.Invoke("SLJobTrans", "ApsSyncImmediateSp", ApsSyncInfobar, 1, "SLDcfcs.DcsfcPVb()")
                    End If

                    ApsSyncInfobar = ResponseData.Parameters(0).Value

                    If ResponseData.IsReturnValueStdError Then
                        DcsfcPVb = 16
                        Infobar = ApsSyncInfobar
                    End If

                Catch ex As Exception
                    DcsfcPVb = 16
                    Infobar = Infobar & ":" & MGException.ExtractMessages(ex)
                End Try
            End If
            oCollection = Nothing
            ResponseData = Nothing
        End Try

    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcsfcDSp(ByVal Status As String, ByVal TransType As String, ByVal FromEmpNum As String, ByVal ToEmpNum As String, ByVal FromTransNum As Decimal?, ByVal ToTransNum As Decimal?, ByVal FromTransDate As DateTime?, ByVal ToTransDate As DateTime?, ByVal FromWC As String, ByVal ToWC As String, ByRef Infobar As String,
<[Optional]> ByVal StartingTransDateOffset As Short?,
<[Optional]> ByVal EndingTransDateOffset As Short?, ByRef PreDelCount As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iDcsfcDExt As IDcsfcD = New DcsfcDFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String, PreDelCount As Integer?) = iDcsfcDExt.DcsfcDSp(Status, TransType, FromEmpNum, ToEmpNum, FromTransNum, ToTransNum, FromTransDate, ToTransDate, FromWC, ToWC, Infobar, StartingTransDateOffset, EndingTransDateOffset, PreDelCount)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            PreDelCount = result.PreDelCount
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcsfcEmpValidSp(ByVal EmpNum As String, ByVal TransType As String, ByVal OldTransType As String, ByVal TransStat As String, ByRef OutPrRate As Decimal?, ByRef OutJobRate As Decimal?, ByRef OutIndCode As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iDcsfcEmpValidExt As IDcsfcEmpValid = New DcsfcEmpValidFactory().Create(appDb)
            Dim oOutPrRate As PayRateType = OutPrRate
            Dim oOutJobRate As PayRateType = OutJobRate
            Dim oOutIndCode As IndCodeType = OutIndCode
            Dim oInfobar As InfobarType = Infobar
            Dim Severity As Integer = iDcsfcEmpValidExt.DcsfcEmpValidSp(EmpNum, TransType, OldTransType, TransStat, oOutPrRate, oOutJobRate, oOutIndCode, oInfobar)
            OutPrRate = oOutPrRate
            OutJobRate = oOutJobRate
            OutIndCode = oOutIndCode
            Infobar = oInfobar
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcsfcJobValidSp(ByVal IsNew As Byte?, ByVal InJob As String, ByVal InSuffix As Short?, ByVal InOperNum As Integer?, ByVal TransType As String, ByVal TransNum As Integer?, ByRef OutJobWhse As String, ByRef JobItem As String, ByRef CoProdMix As Byte?, ByRef ItemLotTracked As Byte?, ByRef ItemSerialTracked As Byte?, ByRef CntrlPoint As Byte?, ByRef Wc As String, ByRef OperComplete As Byte?, ByRef Infobar As String,
<[Optional]> ByRef ItemTrackECN As Byte?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iDcsfcJobValidExt As IDcsfcJobValid = New DcsfcJobValidFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, OutJobWhse As String, JobItem As String, CoProdMix As Byte?, ItemLotTracked As Byte?, ItemSerialTracked As Byte?, CntrlPoint As Byte?, Wc As String, OperComplete As Byte?, Infobar As String, ItemTrackECN As Byte?) = iDcsfcJobValidExt.DcsfcJobValidSp(IsNew, InJob, InSuffix, InOperNum, TransType, TransNum, OutJobWhse, JobItem, CoProdMix, ItemLotTracked, ItemSerialTracked, CntrlPoint, Wc, OperComplete, Infobar, ItemTrackECN)
            Dim Severity As Integer = result.ReturnCode.Value
            OutJobWhse = result.OutJobWhse
            JobItem = result.JobItem
            CoProdMix = result.CoProdMix
            ItemLotTracked = result.ItemLotTracked
            ItemSerialTracked = result.ItemSerialTracked
            CntrlPoint = result.CntrlPoint
            Wc = result.Wc
            OperComplete = result.OperComplete
            Infobar = result.Infobar
            ItemTrackECN = result.ItemTrackECN
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcsfcLocValidSp(ByVal Item As String, ByVal Job As String, ByVal Suffix As Short?, ByVal InLoc As String, ByVal Whse As String, ByRef QuestionAsked As Byte?, ByRef PromptMsg As String, ByRef PromptButtons As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iDcsfcLocValidExt As IDcsfcLocValid = New DcsfcLocValidFactory().Create(appDb)
            Dim oQuestionAsked As ListYesNoType = QuestionAsked
            Dim oPromptMsg As InfobarType = PromptMsg
            Dim oPromptButtons As InfobarType = PromptButtons
            Dim oInfobar As InfobarType = Infobar
            Dim Severity As Integer = iDcsfcLocValidExt.DcsfcLocValidSp(Item, Job, Suffix, InLoc, Whse, oQuestionAsked, oPromptMsg, oPromptButtons, oInfobar)
            QuestionAsked = oQuestionAsked
            PromptMsg = oPromptMsg
            PromptButtons = oPromptButtons
            Infobar = oInfobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcsfcLotValidSp(ByVal InLot As String, ByVal InItem As String, ByVal RefNum As String, ByVal RefLine As Short?, ByVal RefRelease As Short?, ByVal RefType As String, ByRef OutLot As String, ByRef AddQuestionAsked As Byte?, ByRef ContQuestionAsked As Byte?, ByRef PromptMsg As String, ByRef PromptButtons As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iDcsfcLotValidExt As IDcsfcLotValid = New DcsfcLotValidFactory().Create(appDb)
            Dim oOutLot As LotType = OutLot
            Dim oAddQuestionAsked As FlagNyType = AddQuestionAsked
            Dim oContQuestionAsked As FlagNyType = ContQuestionAsked
            Dim oPromptMsg As InfobarType = PromptMsg
            Dim oPromptButtons As InfobarType = PromptButtons
            Dim oInfobar As InfobarType = Infobar
            Dim Severity As Integer = iDcsfcLotValidExt.DcsfcLotValidSp(InLot, InItem, RefNum, RefLine, RefRelease, RefType, oOutLot, oAddQuestionAsked, oContQuestionAsked, oPromptMsg, oPromptButtons, oInfobar)
            OutLot = oOutLot
            AddQuestionAsked = oAddQuestionAsked
            ContQuestionAsked = oContQuestionAsked
            PromptMsg = oPromptMsg
            PromptButtons = oPromptButtons
            Infobar = oInfobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcsfcNextOperValidSp(ByVal InJob As String, ByVal InSuffix As Short?, ByVal InNextOper As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iDcsfcNextOperValidExt As IDcsfcNextOperValid = New DcsfcNextOperValidFactory().Create(appDb)
            Dim oInfobar As InfobarType = Infobar
            Dim Severity As Integer = iDcsfcNextOperValidExt.DcsfcNextOperValidSp(InJob, InSuffix, InNextOper, oInfobar)
            Infobar = oInfobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcsfcOperNumValidSp(ByVal InJob As String, ByVal InSuffix As Short?, ByVal InOperNum As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iDcsfcOperNumValidExt As IDcsfcOperNumValid = New DcsfcOperNumValidFactory().Create(appDb)
            Dim oInfobar As InfobarType = Infobar
            Dim Severity As Integer = iDcsfcOperNumValidExt.DcsfcOperNumValidSp(InJob, InSuffix, InOperNum, oInfobar)
            Infobar = oInfobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcsfcTransTypeValidSp(ByVal TransType As String, ByVal TransStat As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iDcsfcTransTypeValidExt As IDcsfcTransTypeValid = New DcsfcTransTypeValidFactory().Create(appDb)
            Dim oInfobar As InfobarType = Infobar
            Dim Severity As Integer = iDcsfcTransTypeValidExt.DcsfcTransTypeValidSp(TransType, TransStat, oInfobar)
            Infobar = oInfobar
            Return Severity
        End Using
    End Function


    Public Function WcLbrDcValidateSp(ByVal Wc As String, ByVal AHrs As Decimal?, ByVal JobRate As Decimal?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iWcLbrDcValidateExt As IWcLbrDcValidate = New WcLbrDcValidateFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iWcLbrDcValidateExt.WcLbrDcValidateSp(Wc, AHrs, JobRate, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DCAJobtrxSp(ByVal PEmpNum As String, ByVal PDate As DateTime?, ByVal PTime As Integer?, ByVal PTermid As String, ByVal PTransType As String, ByVal PJob As String, ByVal PSuffix As Short?, ByVal POperNum As Integer?, ByVal PIndCode As String, ByVal PQtyComplete As Decimal?, ByVal PQtyScrapped As Decimal?, ByVal PCompleteOp As Byte?, ByVal PLoc As String, ByVal PLot As String, ByVal PQtyMoved As Decimal?, ByVal PReasonCode As String, ByVal PWc As String, ByVal Machine As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim iDCAJobtrxExt As IDCAJobtrx = New DCAJobtrxFactory().Create(Me, True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iDCAJobtrxExt.DCAJobtrxSp(PEmpNum, PDate, PTime, PTermid, PTransType, PJob, PSuffix, POperNum, PIndCode, PQtyComplete, PQtyScrapped, PCompleteOp, PLoc, PLot, PQtyMoved, PReasonCode, PWc, Machine, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcDcsfcCSp(ByVal JobtranRowPointer As Guid?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iDcDcsfcCExt As IDcDcsfcC = New DcDcsfcCFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iDcDcsfcCExt.DcDcsfcCSp(JobtranRowPointer)
            Dim Severity As Integer = result.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcDcsfcPSp(ByVal DcsfcRowpointer As Guid?, ByVal PPostDate As DateTime?, ByRef StopPost As Integer?, ByRef PCanOverride As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iDcDcsfcPExt As IDcDcsfcP = New DcDcsfcPFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, StopPost As Integer?, PCanOverride As Integer?, Infobar As String) = iDcDcsfcPExt.DcDcsfcPSp(DcsfcRowpointer, PPostDate, StopPost, PCanOverride, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            StopPost = result.StopPost
            PCanOverride = result.PCanOverride
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function DcSfcLoadWcSp() As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iDcSfcLoadWcExt As IDcSfcLoadWc = New DcSfcLoadWcFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (Data As CSI.Data.CRUD.ICollectionLoadResponse, ReturnCode As Integer?) = iDcSfcLoadWcExt.DcSfcLoadWcSp()
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcsfcLogErrorSp(ByVal PTransNum As Integer?, ByVal PCanOverride As Byte?, ByVal ErrorMsg As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iDcsfcLogErrorExt As IDcsfcLogError = New DcsfcLogErrorFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iDcsfcLogErrorExt.DcsfcLogErrorSp(PTransNum, PCanOverride, ErrorMsg)
            Dim Severity As Integer = result.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DeleteDcSfcOptimisticLockSp(ByVal TransNum As Integer?, ByVal OldStat As String, ByVal OldErrorMsg As String, ByVal OldRecordDate As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iDeleteDcSfcOptimisticLockExt As IDeleteDcSfcOptimisticLock = New DeleteDcSfcOptimisticLockFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iDeleteDcSfcOptimisticLockExt.DeleteDcSfcOptimisticLockSp(TransNum, OldStat, OldErrorMsg, OldRecordDate, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetDcparmAutopostSp(ByVal AutoPostFieldName As String, ByRef AutoPostFlag As Integer?, ByRef EscFlag As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iGetDcparmAutopostEscFlagExt As IGetDcparmAutopostEscFlag = New GetDcparmAutopostEscFlagFactory().Create(appDb, MGInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, AutoPostFlag As Integer?, EscFlag As String, Infobar As String) = iGetDcparmAutopostEscFlagExt.GetDcparmAutopostEscFlagSp(AutoPostFieldName, AutoPostFlag, EscFlag, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            AutoPostFlag = result.AutoPostFlag
            EscFlag = result.EscFlag
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function
End Class
