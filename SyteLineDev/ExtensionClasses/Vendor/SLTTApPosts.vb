'Option Explicit On
'Option Strict On

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.Core.Common
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.DataAccess
Imports CSI.MG
Imports CSI.Logistics.Vendor
Imports CSI.Data.SQL.UDDT
Imports CSI.Finance.AP
Imports System.Runtime.InteropServices
Imports CSI.Data.CRUD
Imports CSI.Data.RecordSets
'Imports System.Transactions.TransactionScope


<IDOExtensionClass("SLTTApPosts")>
Public Class SLTTApPosts
    Inherits CSIExtensionClassBase

    Private ReadOnly Transactions As Object

    Public Function ApVchPostingBG(ByRef StartingVendNum As String _
                                   , ByRef EndingVendNum As String _
                                   , ByRef VoucherStarting As String _
                                   , ByRef VoucherEnding As String _
                                   , ByRef DueDateStarting As String _
                                   , ByRef DueDateEnding As String _
                                   , ByVal DisDateStarting As String _
                                   , ByVal DisDateEnding As String _
                                   , ByVal AuthorizationStatus As String _
                                   , ByVal SortBy As String _
                                   , ByVal DisplayTotals As String _
                                   , ByVal DisplayHeader As String _
                                   , ByVal SeparateDrCrAmounts As String _
                                   , ByVal SessionIDChar As String _
                                   , ByVal pSite As String _
                                   , ByVal UserId As String _
                                   , ByRef Infobar As String) _
                                   As Integer

        Dim db As AppDB = Mongoose.IDO.IDORuntime.Context.CreateAppDB
        Dim cmd As IDbCommand

        Dim Response As InvokeResponseData
        Dim VoucherArgs As New InvokeParameterList()
        Dim rVoucherData As LoadCollectionResponseData
        Dim VendNum As String
        Dim Voucher As String
        Dim ErrorFlag As Integer
        Dim ApDispInfobar As String = Nothing
        Dim AptrxInfobar As String = Nothing
        Dim PostExtFin As String = Nothing 'Integer = 0
        Dim ExtFinOperationCounter As String = Nothing 'Double = 0

        MyBase.SetContext(Context)
        Dim sessionidguid As Guid = IDORuntime.Context.SessionID
        'Dim userName As String = IDORuntime.Context.UserName

        Try
            If pSite = vbNullString Then
                pSite = IDORuntime.Context.Site.ToString()
            End If

            Response = Me.Context.Commands.Invoke("SP!" _
                                           , "InitSessionContextSp" _
                                           , "APVoucherPostingReport" _
                                           , sessionidguid _
                                           , pSite)

            Response = Me.Context.Commands.Invoke("SP!" _
                                           , "APVchPostingVerifyPrintSp" _
                                           , sessionidguid _
                                           , Infobar)

            If Response.IsReturnValueStdError Then
                Infobar = Response.Parameters(1).Value
                Return (Response.ReturnValue)
            End If

            Dim VoucherProps As New PropertyList("VendNum, Voucher, Name, DerOutOfPeriod")
            VoucherArgs.Add(sessionidguid)
            VoucherArgs.Add(StartingVendNum)
            VoucherArgs.Add(EndingVendNum)
            VoucherArgs.Add(VoucherStarting)
            VoucherArgs.Add(VoucherEnding)
            VoucherArgs.Add(DueDateStarting)
            VoucherArgs.Add(DueDateEnding)
            VoucherArgs.Add(DueDateEnding)
            VoucherArgs.Add(DisDateEnding)
            VoucherArgs.Add(AuthorizationStatus)
            VoucherArgs.Add(SortBy)
            VoucherArgs.Add(1)

            rVoucherData = Me.Context.Commands.LoadCollection(
                   New LoadCollectionRequestData() With
                   {
                      .IDOName = "SLTTApPosts",
                      .PropertyList = VoucherProps,
                      .CustomLoadMethod = New CustomLoadMethod() With
                        {.Name = "APVchPostPopulateTTSp", .Parameters = VoucherArgs}}
                      )

            If rVoucherData.Items.Count > 0 Then

                Response = Me.Context.Commands.Invoke("SLParms" _
                                           , "JourlockSp" _
                                           , "AP Dist" _
                                           , UserId _
                                           , 1 _
                                           , Infobar)
                If Response.IsReturnValueStdError Then
                    Infobar = Response.Parameters(2).Value
                    Return (Response.ReturnValue)
                End If

                For index As Integer = 0 To rVoucherData.Items.Count - 1
                    VendNum = rVoucherData.Item(index, "VendNum").ToString
                    Voucher = rVoucherData.Item(index, "Voucher").ToString

                    'Response = Me.Context.Commands.Invoke("SLTTApposts" _
                    '                       , "APVchPostingAutoDistSp" _
                    '                       , sessionidguid _
                    '                       , VendNum _
                    '                       , Voucher _
                    '                       , ApDispInfobar)
                    cmd = db.CreateCommand()
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = "APVchPostingAutoDistSp"
                    db.AddCommandParameterWithValue(cmd, "PSessionID", sessionidguid, ParameterDirection.Input)
                    db.AddCommandParameterWithValue(cmd, "PVendNum", VendNum, ParameterDirection.Input)
                    db.AddCommandParameterWithValue(cmd, "PVoucher", Voucher, ParameterDirection.Input)
                    db.AddCommandParameterWithValue(cmd, "Infobar", ApDispInfobar, ParameterDirection.Output).Size = 5600
                    cmd.ExecuteNonQuery()
                    ApDispInfobar = CType(cmd.Parameters("@Infobar"), IDbDataParameter).Value.ToString()

                    If ApDispInfobar IsNot Nothing And Not ApDispInfobar = "" Then
                        ErrorFlag = 1
                        ErrorToBuffer(sessionidguid _
                                    , VendNum _
                                    , Voucher _
                                    , ApDispInfobar)
                    Else
                        cmd = db.CreateCommand()
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.CommandText = "AptrxpSp"
                        db.AddCommandParameterWithValue(cmd, "PVendNum", VendNum, ParameterDirection.Input)
                        db.AddCommandParameterWithValue(cmd, "PVoucher", Voucher, ParameterDirection.Input)
                        db.AddCommandParameterWithValue(cmd, "PSessionID", sessionidguid, ParameterDirection.Input)
                        db.AddCommandParameterWithValue(cmd, "PostExtFin", PostExtFin, ParameterDirection.Output).Size = 5600
                        db.AddCommandParameterWithValue(cmd, "ExtFinOperationCounter", ExtFinOperationCounter, ParameterDirection.Output).Size = 5600
                        db.AddCommandParameterWithValue(cmd, "Infobar", AptrxInfobar, ParameterDirection.Output).Size = 5600
                        cmd.ExecuteNonQuery()

                        PostExtFin = CType(cmd.Parameters("@PostExtFin"), IDbDataParameter).Value.ToString()
                        ExtFinOperationCounter = CType(cmd.Parameters("@ExtFinOperationCounter"), IDbDataParameter).Value.ToString()
                        AptrxInfobar = CType(cmd.Parameters("@Infobar"), IDbDataParameter).Value.ToString()

                        If AptrxInfobar IsNot Nothing And Not AptrxInfobar = "" Then
                            ErrorFlag = 1
                            ErrorToBuffer(sessionidguid _
                                                , VendNum _
                                                , Voucher _
                                                , AptrxInfobar)

                        ElseIf PostExtFin = "1" Then
                            Response = Me.Context.Commands.Invoke("SLExtfinParms" _
                                                               , "ExtFinAddBatchToBGQueueSp" _
                                                               , ExtFinOperationCounter _
                                                               , Voucher _
                                                               , Infobar _
                                                               , pSite
                                                               )

                            If Response.IsReturnValueStdError Then
                                Infobar = Response.Parameters(2).Value
                                Return (Response.ReturnValue)
                            End If

                        End If
                    End If

                    ApDispInfobar = Nothing
                    AptrxInfobar = Nothing
                Next

                Response = Me.Context.Commands.Invoke("SLParms" _
                                           , "JourlockSp" _
                                           , "AP Dist" _
                                           , UserId _
                                           , 0 _
                                           , Infobar)

                If Response.IsReturnValueStdError Then
                    Infobar = Response.Parameters(2).Value
                    Return (Response.ReturnValue)
                End If

            End If

            Response = Me.Context.Commands.Invoke("SLTTApposts" _
                                           , "APVchPostingAptrxdSnapShotSp" _
                                           , sessionidguid _
                                           , Infobar)
            If Response.IsReturnValueStdError Then
                Infobar = Response.Parameters(2).Value
                Return (Response.ReturnValue)
            End If

            Dim TaskParms As String
            TaskParms = "SETVARVALUES(" _
                      & "StartingVendNum =  ~LIT~(" & CStr(StartingVendNum) & ")" _
                      & ", EndingVendNum =  ~LIT~(" & CStr(EndingVendNum) & ")" _
                      & ",VoucherStarting =  ~LIT~(" & CStr(VoucherStarting) & ")" _
                      & ",VoucherEnding =  ~LIT~(" & CStr(VoucherEnding) & ")" _
                      & ",DueDateStarting =  ~LIT~(" & CStr(DueDateStarting) & ")" _
                      & ",DisDateStarting =  ~LIT~(" & CStr(DisDateStarting) & ")" _
                      & ",DisDateEnding =  ~LIT~(" & CStr(DisDateEnding) & ")" _
                      & ",AuthorizationStatus =  ~LIT~(" & CStr(AuthorizationStatus) & ")" _
                      & ",SortBy =  ~LIT~(" & CStr(SortBy) & ")" _
                      & ",DisplayTotals =  ~LIT~(" & CStr(DisplayTotals) & ")" _
                      & ",DisplayHeader =  ~LIT~(" & CStr(DisplayHeader) & ")" _
                      & ",SeparateDrCrAmounts =  ~LIT~(" & CStr(SeparateDrCrAmounts) & ")" _
                      & ",SessionId =  ~LIT~(" & sessionidguid.ToString & ")" _
                      & ",pSite =  ~LIT~(" & pSite.ToString & ")" _
                      & ")"

            Response = Me.Context.Commands.Invoke("BGTaskDefinitions" _
                                           , "BGTaskSubmit" _
                                           , "APVoucherPostingReport" _
                                           , TaskParms _
                                           , "" _
                                           , Infobar
                                           )
            If Response.IsReturnValueStdError Then
                Infobar = Response.Parameters(2).Value
                Return (Response.ReturnValue)
            End If


            If ErrorFlag = 1 Then
                TaskParms = sessionidguid.ToString & " ," & pSite.ToString
                Response = Me.Context.Commands.Invoke("BGTaskDefinitions" _
                                           , "BGTaskSubmit" _
                                           , "APVoucherPostingBackgroundMessage" _
                                           , TaskParms _
                                           , "" _
                                           , Infobar
                                           )
                If Response.IsReturnValueStdError Then
                    Infobar = Response.Parameters(2).Value
                    Return (Response.ReturnValue)
                End If

                Response = Me.Context.Commands.Invoke("PublicationSubscribers" _
                                           , "NotifyPublicationSubscribersSp" _
                                           , "APVoucherPostingBackgroundError" _
                                           , "I=#Partial1" _
                                           , "I=PleaseSeeErrorMessageReport" _
                                           , Infobar _
                                           , "" _
                                           , "@!APVoucherPostingInTheBackground" _
                                           , "" _
                                           , "" _
                                           , "" _
                                           , "" _
                                           , "" _
                                           , "" _
                                           , "" _
                                           , "" _
                                           , "" _
                                           , "" _
                                           , "" _
                                           , "" _
                                           , "" _
                                           , "" _
                                           , "@!APVoucherPostingInTheBackground"
                                           )
                If Response.IsReturnValueStdError Then
                    Infobar = Response.Parameters(2).Value
                    Return (Response.ReturnValue)
                End If

            End If

            Response = Nothing
            rVoucherData = Nothing
            cmd = Nothing
            db = Nothing

        Catch ex As Exception
            Response = Me.Context.Commands.Invoke("ApplicationMessages", "MsgAppSp",
                       Infobar, "E=CmdFailed", "SLTTApPosts", "",
                       "", "", "", "", "", "", "", "", "", "", "", "", "")
            Infobar = Response.Parameters(0).Value & Chr(13) & ex.Message
            Throw New MGException(Infobar)
        End Try
        Return 0
    End Function
    Public Sub ErrorToBuffer(ByRef sessionidguid As Guid _
                             , ByRef VendNum As String _
                             , ByRef Voucher As String _
                             , ByRef Infobar As String)

        Dim db As AppDB = Mongoose.IDO.IDORuntime.Context.CreateAppDB
        Dim cmd As IDbCommand
        Dim Sequence As Integer

        cmd = db.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "SELECT ISNULL(MAX(SEQUENCE),0) + 1 FROM tmp_MessageBuffer " _
                                          & "WHERE SessionID = '" & (sessionidguid.ToString) & "'"
        Sequence = CType(cmd.ExecuteScalar(), Integer)
        cmd.Dispose()

        Dim Msgbuff As New IDOUpdateItem()
        Dim InsertMsgbuff As New UpdateCollectionRequestData()

        Msgbuff.Action = UpdateAction.Insert
        Msgbuff.Properties.Add("SessionID", sessionidguid.ToString)
        Msgbuff.Properties.Add("Sequence", Sequence)
        Msgbuff.Properties.Add("MessageText", Infobar)

        InsertMsgbuff.Items.Add(Msgbuff)
        InsertMsgbuff.IDOName = "SLTmpMsgBuffers"
        Me.Context.Commands.UpdateCollection(InsertMsgbuff)

        Dim AptrxProps As New PropertyList("BgPostingStat")
        Dim filter As String = String.Format("VendNum = '{0}' AND Voucher = '{1}'" _
                                           , VendNum _
                                           , Voucher)
        Dim ApTrxCollection As LoadCollectionResponseData
        ApTrxCollection = Me.Context.Commands.LoadCollection("SLAptrxs", AptrxProps, filter, String.Empty, 0)

        Dim ApTrxRequest As New UpdateCollectionRequestData("SLAptrxs")
        For Each item As IDOItem In ApTrxCollection.Items
            Dim updateItem As New IDOUpdateItem With {
                .Action = UpdateAction.Update,
                .ItemNumber = 1,
                .ItemID = item.ItemID
            }
            updateItem.Properties.Add("BgPostingStat", "E")
            ApTrxRequest.Items.Add(updateItem)
            Me.Context.Commands.UpdateCollection(ApTrxRequest)
        Next
    End Sub

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function APVchPostClearTTSP(ByVal PSessionID As Guid?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iAPVchPostClearTTExt As IAPVchPostClearTT = New APVchPostClearTTFactory().Create(appDb)
            Dim Severity As Integer = iAPVchPostClearTTExt.APVchPostClearTTSP(PSessionID)
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function APVchPostingVerifyCloseFormSp(ByVal PSessionID As Guid?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iAPVchPostingVerifyCloseFormExt As IAPVchPostingVerifyCloseForm = New APVchPostingVerifyCloseFormFactory().Create(appDb)
            Dim oInfobar As Infobar = Infobar
            Dim Severity As Integer = iAPVchPostingVerifyCloseFormExt.APVchPostingVerifyCloseFormSp(PSessionID, oInfobar)
            Infobar = oInfobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function AptrxpSp(ByVal PVendNum As String, ByVal PVoucher As Integer?, ByVal PSessionID As Guid?, ByRef PostExtFin As Integer?, ByRef ExtFinOperationCounter As Decimal?, ByRef Infobar As String) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iAptrxpExt As IAptrxp = New AptrxpFactory().Create(appDb, MGInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)

            Dim result As (ReturnCode As Integer?, PostExtFin As Integer?, ExtFinOperationCounter As Decimal?, Infobar As String) = iAptrxpExt.AptrxpSp(PVendNum, PVoucher, PSessionID, PostExtFin, ExtFinOperationCounter, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            PostExtFin = result.PostExtFin
            ExtFinOperationCounter = result.ExtFinOperationCounter
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function APVchPostingAptrxdSnapShotSp(ByVal PSessionID As Guid?, ByRef Infobar As String) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim iAPVchPostingAptrxdSnapShotExt As IAPVchPostingAptrxdSnapShot = New APVchPostingAptrxdSnapShotFactory().Create(Me, True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iAPVchPostingAptrxdSnapShotExt.APVchPostingAptrxdSnapShotSp(PSessionID, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function APVchPostingAutoDistSp(ByVal PSessionID As Guid?, ByVal PVendNum As String, ByVal PVoucher As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iAPVchPostingAutoDistExt As IAPVchPostingAutoDist = New APVchPostingAutoDistFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iAPVchPostingAutoDistExt.APVchPostingAutoDistSp(PSessionID, PVendNum, PVoucher, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ApVchPostingBGSp(
<[Optional]> ByVal StartingVendNum As String,
<[Optional]> ByVal EndingVendNum As String,
<[Optional]> ByVal VoucherStarting As Integer?,
<[Optional]> ByVal VoucherEnding As Integer?,
<[Optional]> ByVal DueDateStarting As DateTime?,
<[Optional]> ByVal DueDateEnding As DateTime?,
<[Optional]> ByVal DisDateStarting As DateTime?,
<[Optional]> ByVal DisDateEnding As DateTime?,
<[Optional]> ByVal AuthorizationStatus As String,
<[Optional]> ByVal SortBy As String,
<[Optional]> ByVal DisplayTotals As Byte?,
<[Optional]> ByVal DisplayHeader As Byte?,
<[Optional]> ByVal SeparateDrCrAmounts As Byte?,
<[Optional]> ByVal SessionIDChar As String,
<[Optional]> ByVal pSite As String,
<[Optional]> ByVal UserId As Decimal?) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iApVchPostingBGExt As IApVchPostingBG = New ApVchPostingBGFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iApVchPostingBGExt.ApVchPostingBGSp(StartingVendNum, EndingVendNum, VoucherStarting, VoucherEnding, DueDateStarting, DueDateEnding, DisDateStarting, DisDateEnding, AuthorizationStatus, SortBy, DisplayTotals, DisplayHeader, SeparateDrCrAmounts, SessionIDChar, pSite, UserId)
            Dim Severity As Integer = result.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function APVchPostingVerifyPrintSp(ByRef PSessionID As Guid?, ByRef Infobar As String) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iAPVchPostingVerifyPrintExt As IAPVchPostingVerifyPrint = New APVchPostingVerifyPrintFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PSessionID As Guid?, Infobar As String) = iAPVchPostingVerifyPrintExt.APVchPostingVerifyPrintSp(PSessionID, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            PSessionID = result.PSessionID
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function APVchPostPopulateTTSP(ByVal PSessionID As Guid?, ByVal PStartingVendNum As String, ByVal PEndingVendNum As String, ByVal PStartingVoucherNum As Integer?, ByVal PEndingVoucherNum As Integer?, ByVal PStartingDueDate As DateTime?, ByVal PEndingDueDate As DateTime?, ByVal PStartingDistDate As DateTime?, ByVal PEndingDistDate As DateTime?, ByVal PAuthStatus As String, ByVal PSortVchVend As String,
<[Optional], DefaultParameterValue(CByte(0))> ByVal CalledFromBackground As Byte?) As DataTable
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iAPVchPostPopulateTTExt As IAPVchPostPopulateTT = New APVchPostPopulateTTFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iAPVchPostPopulateTTExt.APVchPostPopulateTTSp(PSessionID, PStartingVendNum, PEndingVendNum, PStartingVoucherNum, PEndingVoucherNum, PStartingDueDate, PEndingDueDate, PStartingDistDate, PEndingDistDate, PAuthStatus, PSortVchVend, CalledFromBackground)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CheckAPVoucherPrintSp(ByVal SessionID As Guid?, ByRef Infobar As String) As Integer
        Dim iCheckAPVoucherPrintExt As ICheckAPVoucherPrint = New CheckAPVoucherPrintFactory().Create(Me, True)
        Dim result As (ReturnCode As Integer?, Infobar As String) = iCheckAPVoucherPrintExt.CheckAPVoucherPrintSp(SessionID, Infobar)
        Dim Severity As Integer = result.ReturnCode.Value
        Infobar = result.Infobar
        Return Severity
    End Function
End Class

