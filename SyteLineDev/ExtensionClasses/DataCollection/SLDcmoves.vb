Imports System.Data.SqlClient
Imports System.Text

Imports Mongoose.Core.Common
Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports CSI.Data.SQL.UDDT
Imports System
Imports System.Data
Imports CSI.DataCollection
Imports CSI.MG
Imports System.Runtime.InteropServices
Imports CSI.Material

<IDOExtensionClass("SLDcmoves")>
Public Class SLDcmoves
    Inherits CSIExtensionClassBase
    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcmovePVb(ByVal PPostDate As Nullable(Of DateTime), ByRef Infobar As String) As Integer

        Dim oCollection As LoadCollectionResponseData
        Dim Filter As String
        Dim TransNum As Integer
        Dim ResponseData As New InvokeResponseData
        Dim iErrorFlag As Integer
        Dim iCanOverride As Integer
        Try
            DcmovePVb = 0

            If IDONull.IsNull(PPostDate) Then
                PPostDate = DateTime.Now
            End If

            Filter = "CHARINDEX(Stat, 'UPE') > 0 AND TransType  = '1' AND TransNum > 0 "
            Filter = Filter & " And TransDate <= dbo.DayEndOf(" & SqlLiteral.Format(PPostDate) & ")"

            oCollection = Me.LoadCollection("TransNum", Filter, String.Empty, 0)

            For index As Integer = 0 To oCollection.Items.Count - 1
                Infobar = ""
                TransNum = oCollection(index, "TransNum").GetValue(Of Integer)(0)
                Try
                    ResponseData = Me.Invoke("DcmovePSp", TransNum, iCanOverride, Infobar)
                    iCanOverride = CInt(ResponseData.Parameters(1).Value)
                    Infobar = ResponseData.Parameters(2).Value
                Catch ex As Exception
                    Infobar = MGException.ExtractMessages(ex)
                    iErrorFlag = 1
                End Try
                If ResponseData.IsReturnValueStdError Or iErrorFlag = 1 Then
                    ResponseData = Me.Invoke("DcmoveLogErrorSp", TransNum, iCanOverride, Infobar)
                    If ResponseData.IsReturnValueStdError Then
                        Infobar = "UNKNOWN ERROR CALLING DcmoveLogErrorSp"
                        DcmovePVb = 16
                        oCollection = Nothing
                        ResponseData = Nothing
                        Exit Function
                    End If
                End If
            Next
        Catch ex As Exception
            Infobar = Infobar & ":" & MGException.ExtractMessages(ex)
            DcmovePVb = 16
        End Try
        oCollection = Nothing
        ResponseData = Nothing
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcmoveDSp(ByVal Status As String, ByVal FromTransNum As Decimal?, ByVal ToTransNum As Decimal?, ByVal FromTransDate As DateTime?, ByVal ToTransDate As DateTime?, ByRef Infobar As String,
<[Optional]> ByVal StartingTransDateOffset As Short?,
<[Optional]> ByVal EndingTransDateOffset As Short?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iDcmoveDExt As IDcmoveD = New DcmoveDFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iDcmoveDExt.DcmoveDSp(Status, FromTransNum, ToTransNum, FromTransDate, ToTransDate, Infobar, StartingTransDateOffset, EndingTransDateOffset)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ItemlocValidateSp(ByVal Item As String, ByVal Whse As String, ByVal Loc As String,
<[Optional], DefaultParameterValue(CByte(0))> ByVal VerifyAccounts As Byte?,
<[Optional], DefaultParameterValue(CByte(0))> ByVal CheckUserAccount As Byte?,
<[Optional]> ByVal UserAcct As String, ByRef Infobar As String,
<[Optional]> ByRef Prompt As String,
<[Optional]> ByRef PromptButtons As String,
<[Optional], DefaultParameterValue(CByte(1))> ByVal Outgoing As Byte?,
<[Optional]> ByRef ItemQtyOnHand As Decimal?,
<[Optional]> ByVal OldLoc As String,
<[Optional]> ByVal CoNum As String,
<[Optional]> ByVal CoLine As Short?,
<[Optional]> ByVal CoRelease As Short?,
<[Optional]> ByVal Lot As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iItemlocValidateExt As IItemlocValidate = New ItemlocValidateFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String, Prompt As String, PromptButtons As String, ItemQtyOnHand As Decimal?) = iItemlocValidateExt.ItemlocValidateSp(Item, Whse, Loc, VerifyAccounts, CheckUserAccount, UserAcct, Infobar, Prompt, PromptButtons, Outgoing, ItemQtyOnHand, OldLoc, CoNum, CoLine, CoRelease, Lot)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Prompt = result.Prompt
            PromptButtons = result.PromptButtons
            ItemQtyOnHand = result.ItemQtyOnHand
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ItemQtyDetlSp(ByVal Site As String, ByVal Type As String, ByVal WhseType As String, ByVal Whse As String, ByVal Item As String, ByVal Loc As String, ByVal Lot As String, ByVal DeltaQty As Decimal?, ByVal [Return] As Byte?, ByVal Action As String, ByVal TrnNum As String, ByVal TrnLine As Short?, ByVal TransNum As Decimal?, ByVal RsvdNum As Decimal?, ByVal Stat As String, ByVal Byprod As Byte?, ByVal Workkey As String, ByRef PromptMsg As String, ByRef PromptButtons As String, ByRef Infobar As String,
<[Optional]> ByVal ImportDocId As String,
<[Optional], DefaultParameterValue(0)> ByRef CallForm As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim iItemQtyDetlExt As IItemQtyDetl = New ItemQtyDetlFactory().Create(Me, True)
            Dim result As (ReturnCode As Integer?, PromptMsg As String, PromptButtons As String, Infobar As String, CallForm As Integer?) = iItemQtyDetlExt.ItemQtyDetlSp(Site, Type, WhseType, Whse, Item, Loc, Lot, DeltaQty, [Return], Action, TrnNum, TrnLine, TransNum, RsvdNum, Stat, Byprod, Workkey, PromptMsg, PromptButtons, Infobar, ImportDocId, CallForm)
            Dim Severity As Integer = result.ReturnCode.Value
            PromptMsg = result.PromptMsg
            PromptButtons = result.PromptButtons
            Infobar = result.Infobar
            CallForm = result.CallForm
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcAMatlmvSp(ByVal TTermId As String, ByVal TEmpNum As String, ByVal TTransDate As DateTime?, ByVal TItem As String, ByVal TCurWhse As String, ByVal TLoc1 As String, ByVal TLot1 As String, ByVal TLoc2 As String, ByVal TLot2 As String, ByVal TQty As Decimal?, ByVal TUM As String, ByVal DocumentNum As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim iDcAMatlmvExt As IDcAMatlmv = New DcAMatlmvFactory().Create(Me, True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iDcAMatlmvExt.DcAMatlmvSp(TTermId, TEmpNum, TTransDate, TItem, TCurWhse, TLoc1, TLot1, TLoc2, TLot2, TQty, TUM, DocumentNum, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcmoveLogErrorSp(ByVal PTransNum As Integer?, ByVal PCanOverride As Byte?, ByVal ErrorMsg As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim iDcmoveLogErrorExt As IDcmoveLogError = New DcmoveLogErrorFactory().Create(Me, True)
            Dim result As Integer? = iDcmoveLogErrorExt.DcmoveLogErrorSp(PTransNum, PCanOverride, ErrorMsg)
            Dim Severity As Integer = result.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcmovePostSp(
    <[Optional], DefaultParameterValue("M")> ByVal PType As String, ByVal PQty As Decimal?, ByVal PItem As String, ByVal FromWhse As String, ByVal FromLoc As String, ByVal FromLot As String, ByVal ToWhse As String, ByVal ToLoc As String, ByVal ToLot As String, ByVal SerNumList As String, ByRef Infobar As String) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iDcmovePostExt As IDcmovePost = New DcmovePostFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iDcmovePostExt.DcmovePostSp(PType, PQty, PItem, FromWhse, FromLoc, FromLot, ToWhse, ToLoc, ToLot, SerNumList, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcmovePSp(ByVal PTransNum As Integer?, ByRef PCanOverride As Byte?, ByRef Infobar As String) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iDcmovePExt As IDcmoveP = New DcmovePFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PCanOverride As Integer?, Infobar As String) = iDcmovePExt.DcmovePSp(PTransNum, PCanOverride, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            PCanOverride = result.PCanOverride
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcmoveValidateEmpNumSp(ByVal Connected As Byte?, ByRef EmpNum As String, ByRef EmpName As String, ByRef Infobar As String) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iDcmoveValidateEmpNumExt As IDcmoveValidateEmpNum = New DcmoveValidateEmpNumFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, EmpNum As String, EmpName As String, Infobar As String) = iDcmoveValidateEmpNumExt.DcmoveValidateEmpNumSp(Connected, EmpNum, EmpName, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            EmpNum = result.EmpNum
            EmpName = result.EmpName
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcValidateSerNumSp(ByVal Connected As Byte?, ByVal PInOut As Byte?, ByVal PType As String, ByVal PWhseType As String, ByVal PItem As String, ByVal PLocation As String, ByVal PLot As String, ByVal PCurWhse As String, ByVal PSerNum As String,
    <[Optional], DefaultParameterValue(0)> ByVal PRsvdInv As Decimal?, ByVal PDuplicate As Byte?, ByRef Completed As Byte?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iDcValidateSerNumExt As IDcValidateSerNum = New DcValidateSerNumFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Completed As Integer?, Infobar As String) = iDcValidateSerNumExt.DcValidateSerNumSp(Connected, PInOut, PType, PWhseType, PItem, PLocation, PLot, PCurWhse, PSerNum, PRsvdInv, PDuplicate, Completed, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Completed = result.Completed
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
