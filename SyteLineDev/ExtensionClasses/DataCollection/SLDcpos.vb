Option Explicit On
Option Strict On

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common
Imports Microsoft.VisualBasic
Imports CSI.Data.SQL.UDDT
Imports System
Imports System.Data
Imports CSI.DataCollection
Imports CSI.MG
Imports System.Runtime.InteropServices

<IDOExtensionClass("SLDcpos")> _
Public Class SLDcpos
    Inherits ExtensionClassBase
    <IDOMethod(MethodFlags.None, "Infobar")> _
    Public Function DcpoPVb(ByVal PPostDate As Nullable(Of DateTime), ByRef Infobar As String) As Integer

        Dim oCollection As LoadCollectionResponseData
        Dim ResponseData As InvokeResponseData = Nothing
        Dim Filter As String
        Dim TransNum As Integer
        Dim DocumentNum As String
        Dim iErrorFlag As Integer
        Dim dDerSiteDate As DateTime

        DcpoPVb = 0

        oCollection = Me.Context.Commands.LoadCollection("SLDcparms", "DerSiteDate", "", "", 0)
        If oCollection.Items.Count > 0 Then
            dDerSiteDate = oCollection.Item(0, "DerSiteDate").GetValue(Of DateTime)()
        End If

        If IDONull.IsNull(PPostDate) Then
            PPostDate = dDerSiteDate
        End If

        Filter = "CHARINDEX(Stat, 'UP') > 0 AND TransNum > 0 "
        Filter = Filter & " AND TransDate <= dbo.DayEndOf(" & SqlLiteral.Format(PPostDate) & ")"

        Try
            oCollection = Me.LoadCollection("TransNum, DocumentNum", Filter, String.Empty, 0)
            For index As Integer = 0 To oCollection.Items.Count - 1
                TransNum = oCollection(index, "TransNum").GetValue(Of Integer)(-1)
                DocumentNum = oCollection(index, "DocumentNum").Value
                Try
                    ResponseData = Me.Invoke("DcpoPSp", TransNum, Infobar, DocumentNum)
                    Infobar = ResponseData.Parameters(1).Value
                Catch ex As Exception
                    Infobar = MGException.ExtractMessages(ex)
                    iErrorFlag = 1
                End Try
                If ResponseData.IsReturnValueStdError Or iErrorFlag = 1 Then
                    ResponseData = Me.Invoke("DcpoLogErrorSp", TransNum, Infobar)
                    If ResponseData.IsReturnValueStdError Then
                        Infobar = "UNKNOWN ERROR CALLING DcpoLogErrorSp"
                        DcpoPVb = 16
                        Exit Function
                    End If
                End If
            Next
        Catch ex As Exception
            Infobar = Infobar & ":" & MGException.ExtractMessages(ex)
            DcpoPVb = 16
        Finally
            oCollection = Nothing
            ResponseData = Nothing
        End Try

    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcpoDSp(ByVal Status As String, ByVal TransType As String, ByVal FromTransNum As Decimal?, ByVal ToTransNum As Decimal?, ByVal FromTransDate As DateTime?, ByVal ToTransDate As DateTime?, ByRef Infobar As String,
<[Optional]> ByVal StartingTransDateOffset As Short?,
<[Optional]> ByVal EndingTransDateOffset As Short?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iDcpoDExt As IDcpoD = New DcpoDFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iDcpoDExt.DcpoDSp(Status, TransType, FromTransNum, ToTransNum, FromTransDate, ToTransDate, Infobar, StartingTransDateOffset, EndingTransDateOffset)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcAPorcvSp(ByVal TTermId As String, ByVal TTransType As Integer?, ByVal TEmpNum As String, ByVal TTransDate As DateTime?, ByVal TPoNum As String, ByVal TPoLine As Short?, ByVal TPoRelease As Short?, ByVal TItem As String, ByVal TLocation As String, ByVal TLot As String, ByVal TCurWhse As String, ByVal TReasonCode As String, ByVal TUM As String, ByVal TQty As Decimal?, ByVal TQtyRejected As Decimal?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iDcAPorcvExt As IDcAPorcv = New DcAPorcvFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iDcAPorcvExt.DcAPorcvSp(TTermId, TTransType, TEmpNum, TTransDate, TPoNum, TPoLine, TPoRelease, TItem, TLocation, TLot, TCurWhse, TReasonCode, TUM, TQty, TQtyRejected, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcpoLogErrorSp(ByVal PTransNum As Integer?, ByVal ErrorMsg As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iDcpoLogErrorExt As IDcpoLogError = New DcpoLogErrorFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iDcpoLogErrorExt.DcpoLogErrorSp(PTransNum, ErrorMsg)
            Dim Severity As Integer = result.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcpoPSp(ByVal PTransNum As Integer?, ByRef Infobar As String,
<[Optional]> ByVal DocumentNum As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iDcpoPExt As IDcpoP = New DcpoPFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iDcpoPExt.DcpoPSp(PTransNum, Infobar, DocumentNum)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcPoUpdateSp(ByVal TTermId As String, ByVal TTransType As Integer?, ByVal TEmpNum As String, ByVal TPoNum As String, ByVal TPoLine As Short?, ByVal TPoRelease As Short?, ByVal TItem As String, ByVal TLocation As String, ByVal TLot As String, ByVal TCurWhse As String, ByVal TReasonCode As String, ByVal TUM As String, ByVal TQtyReceived As Decimal?, ByVal TQtyRejected As Decimal?, ByVal TQtyReturned As Decimal?, ByVal SerNumList As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iDcPoUpdateExt As IDcPoUpdate = New DcPoUpdateFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iDcPoUpdateExt.DcPoUpdateSp(TTermId, TTransType, TEmpNum, TPoNum, TPoLine, TPoRelease, TItem, TLocation, TLot, TCurWhse, TReasonCode, TUM, TQtyReceived, TQtyRejected, TQtyReturned, SerNumList, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcPoValidateEmpNumSp(ByVal Connected As Byte?, ByRef EmpNum As String, ByRef EmpName As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iDcPoValidateEmpNumExt As IDcPoValidateEmpNum = New DcPoValidateEmpNumFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, EmpNum As String, EmpName As String, Infobar As String) = iDcPoValidateEmpNumExt.DcPoValidateEmpNumSp(Connected, EmpNum, EmpName, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            EmpNum = result.EmpNum
            EmpName = result.EmpName
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetDcparmAutopostEscFlagSp(ByVal AutoPostFieldName As String, ByRef AutoPostFlag As Integer?, ByRef EscFlag As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
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

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetInvparmAutoGenSp(ByVal AutoGenFieldName As String, ByRef AutoGenFlag As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iGetInvparmAutoGenExt As IGetInvparmAutoGen = New GetInvparmAutoGenFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, AutoGenFlag As Integer?, Infobar As String) = iGetInvparmAutoGenExt.GetInvparmAutoGenSp(AutoGenFieldName, AutoGenFlag, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            AutoGenFlag = result.AutoGenFlag
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function
End Class
