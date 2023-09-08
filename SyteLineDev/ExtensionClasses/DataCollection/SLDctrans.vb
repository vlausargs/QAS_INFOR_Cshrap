Option Explicit On
Option Strict On

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
Imports CSI.Material
Imports CSI.ExternalContracts.FactoryTrack

<IDOExtensionClass("SLDctrans")> _
Public Class SLDctrans
    Inherits ExtensionClassBase
    Implements IExtFTSLDctrans

    <IDOMethod(MethodFlags.None, "Infobar")> _
    Public Function DctrPVb(ByVal PPostDate As Nullable(Of DateTime), ByRef Infobar As String) As Integer

        Dim oCollection As LoadCollectionResponseData
        Dim Filter As String
        Dim TransNum As Integer
        Dim DocumentNum As String
        Dim iReturnValue As Integer
        Dim responseData As InvokeResponseData
        Dim ApsSyncInfobar As String
        Dim bApsSyncDefer As Boolean
        Dim iErrorFlag As Integer

        bApsSyncDefer = False
        DctrPVb = 0
        iReturnValue = 0
        ApsSyncInfobar = ""
        ' Defer APS sync transactions
        Try
            responseData = Me.Context.Commands.Invoke("SLJobTrans", "ApsSyncDeferSp", Infobar, "SLDctrans.DctrPVb()")
            If responseData.IsReturnValueStdError Then
                iReturnValue = 16
                Infobar = responseData.Parameters(0).Value
                Exit Function
            End If

            bApsSyncDefer = True

            If IDONull.IsNull(PPostDate) Then
                PPostDate = DateTime.Now
            End If

            Filter = "CHARINDEX(Stat, 'UP') > 0 AND TransType  = '2' "
            Filter = Filter & " And TransDate <= dbo.DayEndOf(" & SqlLiteral.Format(PPostDate) & ")"

            oCollection = Me.LoadCollection("TransNum, DocumentNum", Filter, "", 0)
            For index As Integer = 0 To oCollection.Items.Count - 1
                TransNum = oCollection(index, "TransNum").GetValue(Of Integer)(0)
                DocumentNum = oCollection(index, "DocumentNum").Value
                Try
                    responseData = Me.Context.Commands.Invoke("SLDctrans", "DctrPSp", TransNum, Infobar, DocumentNum)
                    Infobar = responseData.Parameters(1).Value
                Catch ex As Exception
                    Infobar = MGException.ExtractMessages(ex)
                    iErrorFlag = 1
                End Try

                If responseData.IsReturnValueStdError Or iErrorFlag = 1 Then
                    responseData = Me.Context.Commands.Invoke("SLDctrans", "DctransLogErrorSp", TransNum, Infobar)
                    If responseData.IsReturnValueStdError Then
                        Infobar = "UNKNOWN ERROR CALLING DctransLogErrorSp"
                        iReturnValue = 16
                        Exit Function
                    End If
                End If
            Next
        Catch ex As Exception
            Infobar = MGException.ExtractMessages(ex)
            DctrPVb = 16
        Finally
            ' Deal with deferred APS transactions
            If bApsSyncDefer Then
                Try
                    If iReturnValue = 0 Then
                        responseData = Me.Context.Commands.Invoke("SLJobTrans", "ApsSyncImmediateSp", ApsSyncInfobar, 0, "SLDctrans.DctrPVb()")
                    Else
                        responseData = Me.Context.Commands.Invoke("SLJobTrans", "ApsSyncImmediateSp", ApsSyncInfobar, 1, "SLDctrans.DctrPVb()")
                    End If

                    ApsSyncInfobar = responseData.Parameters(0).Value

                    If responseData.IsReturnValueStdError Then
                        iReturnValue = 16
                        Infobar = ApsSyncInfobar
                    End If

                Catch ex As Exception
                    iReturnValue = 16
                    Infobar = Infobar & ":" & MGException.ExtractMessages(ex)
                End Try
            End If
            DctrPVb = iReturnValue
            oCollection = Nothing
            responseData = Nothing
        End Try

    End Function
    <IDOMethod(MethodFlags.None, "Infobar")> _
    Public Function DctsPVb(ByVal PPostDate As Nullable(Of DateTime), ByRef Infobar As String) As Integer

        Dim oCollection As LoadCollectionResponseData
        Dim Filter As String
        Dim TransNum As Integer
        Dim DocumentNum As String
        Dim iReturnValue As Integer
        Dim ApsSyncInfobar As String
        Dim bApsSyncDefer As Boolean
        Dim ResponseData As InvokeResponseData
        Dim iErrorFlag As Integer

        bApsSyncDefer = False
        DctsPVb = 0
        iReturnValue = 0
        ApsSyncInfobar = ""
        ' Defer APS sync transactions
        Try
            ResponseData = Me.Context.Commands.Invoke("SLJobTrans", "ApsSyncDeferSp", Infobar, "SLDctrans.DctsPVb()")
            If ResponseData.IsReturnValueStdError Then
                iReturnValue = 16
                Infobar = ResponseData.Parameters(0).Value
                Exit Function
            End If

            bApsSyncDefer = True

            If IDONull.IsNull(PPostDate) Then
                PPostDate = DateTime.Now
            End If

            Filter = "CHARINDEX(Stat, 'UP') > 0 AND TransType  = '1' "
            Filter = Filter & " And TransDate <= dbo.DayEndOf(" & SqlLiteral.Format(PPostDate) & ")"

            oCollection = Me.LoadCollection("TransNum, DocumentNum", Filter, "", 0)
            For index As Integer = 0 To oCollection.Items.Count - 1
                TransNum = oCollection(index, "TransNum").GetValue(Of Integer)(0)
                DocumentNum = oCollection(index, "DocumentNum").Value
                Try
                    ResponseData = Me.Context.Commands.Invoke("SLDctrans", "DctsPSp", TransNum, Infobar, DocumentNum)
                    Infobar = ResponseData.Parameters(1).Value
                Catch ex As Exception
                    Infobar = MGException.ExtractMessages(ex)
                    iErrorFlag = 1
                End Try
                If ResponseData.IsReturnValueStdError Or iErrorFlag = 1 Then
                    ResponseData = Me.Context.Commands.Invoke("SLDctrans", "DctransLogErrorSp", TransNum, Infobar)
                    If ResponseData.IsReturnValueStdError Then
                        Infobar = "UNKNOWN ERROR CALLING DctransLogErrorSp"
                        iReturnValue = 16
                        Exit Function
                    End If
                End If
            Next
        Catch ex As Exception
            Infobar = MGException.ExtractMessages(ex)
            DctsPVb = 16
        Finally
            ' Deal with deferred APS transactions
            If bApsSyncDefer Then
                Try
                    If iReturnValue = 0 Then
                        ResponseData = Me.Context.Commands.Invoke("SLJobTrans", "ApsSyncImmediateSp", ApsSyncInfobar, 0, "SLDctrans.DctsPVb()")
                    Else
                        ResponseData = Me.Context.Commands.Invoke("SLJobTrans", "ApsSyncImmediateSp", ApsSyncInfobar, 1, "SLDctrans.DctsPVb()")
                    End If

                    ApsSyncInfobar = ResponseData.Parameters(0).Value

                    If ResponseData.IsReturnValueStdError Then
                        iReturnValue = 16
                        Infobar = ApsSyncInfobar
                    End If

                Catch ex As Exception
                    iReturnValue = 16
                    Infobar = Infobar & ":" & MGException.ExtractMessages(ex)
                End Try
            End If
            DctsPVb = iReturnValue
            oCollection = Nothing
            ResponseData = Nothing
        End Try
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DctranDSp(ByVal Status As String, ByVal TransType As String, ByVal FromTransNum As Decimal?, ByVal ToTransNum As Decimal?, ByVal FromTransDate As DateTime?, ByVal ToTransDate As DateTime?, ByRef Infobar As String,
<[Optional]> ByVal StartingTransDateOffset As Short?,
<[Optional]> ByVal EndingTransDateOffset As Short?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iDctranDExt As IDctranD = New DctranDFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iDctranDExt.DctranDSp(Status, TransType, FromTransNum, ToTransNum, FromTransDate, ToTransDate, Infobar, StartingTransDateOffset, EndingTransDateOffset)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function dctsLotRvallotSp(ByVal Item As String, ByVal Lot As String, ByVal RemoteSiteLot As String, ByRef Infobar As String,
<[Optional]> ByVal Site As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim idctsLotRvallotExt As IdctsLotRvallot = New dctsLotRvallotFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = idctsLotRvallotExt.dctsLotRvallotSp(Item, Lot, RemoteSiteLot, Infobar, Site)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ChkSnSp(ByVal PSite As String, ByVal PSerNum As String, ByVal PItem As String, ByVal PQtyShip As Decimal?, ByRef PErr As String, ByRef Infobar As String,
<[Optional], DefaultParameterValue(CByte(0))> ByVal CalledFromSerialTrigger As Byte?) As Integer Implements IExtFTSLDctrans.ChkSnSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iChkSnExt As IChkSn = New ChkSnFactory().Create(appDb)

            Dim result As (ReturnCode As Integer?, PErr As String, Infobar As String) = iChkSnExt.ChkSnSp(PSite, PSerNum, PItem, PQtyShip, PErr, Infobar, CalledFromSerialTrigger)

            Dim Severity As Integer = result.ReturnCode.Value
            PErr = result.PErr
            Infobar = result.Infobar

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function RvallocSp(ByVal Site As String, ByVal Whse As String, ByVal Item As String, ByVal Loc As String, ByRef PromptMsg As String, ByRef PromptButtons As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iRvallocExt As IRvalloc = New RvallocFactory().Create(appDb)
            Dim Severity As Integer = iRvallocExt.RvallocSp(Site, Whse, Item, Loc, PromptMsg, PromptButtons, Infobar)
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ItemLocAddSp(ByVal Whse As String, ByVal Item As String, ByVal Loc As String, ByVal UcFlag As Byte?, ByVal UnitCost As Decimal?, ByVal MatlCost As Decimal?, ByVal LbrCost As Decimal?, ByVal FovhdCost As Decimal?, ByVal VovhdCost As Decimal?, ByVal OutCost As Decimal?,
<[Optional], DefaultParameterValue(CByte(0))> ByVal SetPermFlag As Byte?, ByRef RowPointer As Guid?, ByRef Infobar As String,
<[Optional]> ByVal PermFlagValue As Byte?,
<[Optional]> ByVal MrbFlagValue As Byte?,
<[Optional]> ByVal locMrbFlag As Byte?,
<[Optional]> ByVal locLocType As String,
<[Optional]> ByVal locWC As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iItemLocAddExt As IItemLocAdd = New ItemLocAddFactory().Create(appDb, MGInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, RowPointer As Guid?, Infobar As String) = iItemLocAddExt.ItemLocAddSp(Whse, Item, Loc, UcFlag, UnitCost, MatlCost, LbrCost, FovhdCost, VovhdCost, OutCost, SetPermFlag, RowPointer, Infobar, PermFlagValue, MrbFlagValue, locMrbFlag, locLocType, locWC)
            Dim Severity As Integer = result.ReturnCode.Value
            RowPointer = result.RowPointer
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function TrnShipLocValidSp(ByVal Item As String, ByVal Whse As String, ByVal Site As String, ByRef Loc As String, ByRef ItemLocQuestionAsked As Byte?, ByRef PromptMsg As String, ByRef PromptButtons As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iTrnShipLocValidExt As ITrnShipLocValid = New TrnShipLocValidFactory().Create(appDb)

            Dim Severity As Integer = iTrnShipLocValidExt.TrnShipLocValidSp(Item, Whse, Site, Loc, ItemLocQuestionAsked, PromptMsg, PromptButtons, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcATransSp(ByVal pTermId As String, ByVal TTransType As String, ByVal pEmpNum As String, ByVal pTransDate As DateTime?, ByVal pTransfer As String, ByVal pLine As Short?, ByVal pUM As String, ByVal pQty As Decimal?, ByVal pLoc As String, ByVal pLot As String, ByVal pTrnLot As String, ByVal pRemoteSiteTrnLotProcess As String, ByVal pUseExistingSerials As Byte?, ByRef InfoBar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iDcATransExt As IDcATrans = New DcATransFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iDcATransExt.DcATransSp(pTermId, TTransType, pEmpNum, pTransDate, pTransfer, pLine, pUM, pQty, pLoc, pLot, pTrnLot, pRemoteSiteTrnLotProcess, pUseExistingSerials, InfoBar)
            Dim Severity As Integer = result.ReturnCode.Value
            InfoBar = result.InfoBar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DctransLogErrorSp(ByVal PTransNum As Integer?, ByVal ErrorMsg As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iDctransLogErrorExt As IDctransLogError = New DctransLogErrorFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iDctransLogErrorExt.DctransLogErrorSp(PTransNum, ErrorMsg)
            Dim Severity As Integer = result.Value
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DctrPSp(ByVal PTransNum As Integer?, ByRef Infobar As String,
<[Optional]> ByVal DocumentNum As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iDctrPExt As IDctrP = New DctrPFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iDctrPExt.DctrPSp(PTransNum, Infobar, DocumentNum)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DctsPSp(ByVal PTransNum As Integer?, ByRef Infobar As String,
<[Optional]> ByVal DocumentNum As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iDctsPExt As IDctsP = New DctsPFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iDctsPExt.DctsPSp(PTransNum, Infobar, DocumentNum)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcCycleValLotSP(ByVal DCItemItem As String, ByVal DCItemWhse As String, ByVal DCItemLoc As String, ByVal DCItemLot As String,
<[Optional]> ByVal Title As String, ByRef AddLot As Byte?, ByRef PromptAddMsg As String, ByRef PromptAddButtons As String, ByRef PromptExpLotMsg As String, ByRef PromptExpLotButtons As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iDcCycleValLotExt As IDcCycleValLot = New DcCycleValLotFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, AddLot As Byte?, PromptAddMsg As String, PromptAddButtons As String, PromptExpLotMsg As String, PromptExpLotButtons As String, Infobar As String) = iDcCycleValLotExt.DcCycleValLotSP(DCItemItem, DCItemWhse, DCItemLoc, DCItemLot, Title, AddLot, PromptAddMsg, PromptAddButtons, PromptExpLotMsg, PromptExpLotButtons, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            AddLot = result.AddLot
            PromptAddMsg = result.PromptAddMsg
            PromptAddButtons = result.PromptAddButtons
            PromptExpLotMsg = result.PromptExpLotMsg
            PromptExpLotButtons = result.PromptExpLotButtons
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetDcparmAutopostEscFlagSp(ByVal AutoPostFieldName As String, ByRef AutoPostFlag As Integer?, ByRef EscFlag As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iGetDcparmAutopostEscFlagExt As IGetDcparmAutopostEscFlag = New GetDcparmAutopostEscFlagFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, AutoPostFlag As Integer?, EscFlag As String, Infobar As String) = iGetDcparmAutopostEscFlagExt.GetDcparmAutopostEscFlagSp(AutoPostFieldName, AutoPostFlag, EscFlag, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            AutoPostFlag = result.AutoPostFlag
            EscFlag = result.EscFlag
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function
End Class
