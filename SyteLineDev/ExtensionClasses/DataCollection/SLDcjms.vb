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

<IDOExtensionClass("SLDcjms")> _
Public Class SLDcjms
    Inherits ExtensionClassBase

    <IDOMethod(MethodFlags.None, "Infobar")> _
    Public Function DcjmPVb(ByVal PPostDate As Nullable(Of DateTime), ByRef Infobar As String) As Integer

        Dim oCollection As LoadCollectionResponseData
        Dim Filter As String
        Dim TransNum As Integer
        Dim DocumentNum As String
        Dim ResponseData As New InvokeResponseData
        Dim iErrorFlag As Integer
        Dim dDerSiteDate As DateTime

        Try
            DcjmPVb = 0
            iErrorFlag = 0

            oCollection = Me.Context.Commands.LoadCollection("SLDcparms", "DerSiteDate", "", "", 0)
            If oCollection.Items.Count > 0 Then
                dDerSiteDate = oCollection.Item(0, "DerSiteDate").GetValue(Of DateTime)()
            End If

            If IDONull.IsNull(PPostDate) Then
                PPostDate = dDerSiteDate
            End If

            Filter = "CHARINDEX(Stat, 'UP') > 0 AND CHARINDEX(TransType, '12')  > 0 "
            Filter = Filter & " AND TransDate <= dbo.DayEndOf(" & SqlLiteral.Format(PPostDate) & ")"
            oCollection = Me.LoadCollection("TransNum, DocumentNum", Filter, String.Empty, 0)
            For index As Integer = 0 To oCollection.Items.Count - 1
                TransNum = oCollection(index, "TransNum").GetValue(Of Integer)(-1)
                DocumentNum = oCollection(index, "DocumentNum").Value
                Try
                    ResponseData = Me.Invoke("DcjmPSp", TransNum, Infobar, DocumentNum)
                    Infobar = ResponseData.Parameters(1).Value
                Catch ex As Exception
                    Infobar = MGException.ExtractMessages(ex)
                    iErrorFlag = 1
                End Try
                If ResponseData.IsReturnValueStdError Or iErrorFlag = 1 Then
                    ResponseData = Me.Invoke("DcjmLogErrorSp", TransNum, 0, Infobar)
                    If ResponseData.IsReturnValueStdError Then
                        Infobar = "UNKNOWN ERROR CALLING DcjmLogErrorSp"
                        DcjmPVb = 16
                        oCollection = Nothing
                        ResponseData = Nothing
                        Exit Function
                    End If
                End If
            Next
        Catch ex As Exception
            Infobar = Infobar & ":" & MGException.ExtractMessages(ex)
            DcjmPVb = 16
        End Try
        oCollection = Nothing
        ResponseData = Nothing
    End Function
    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcjrPVb(ByVal PPostDate As Nullable(Of DateTime), ByRef Infobar As String) As Integer

        Dim oCollection As LoadCollectionResponseData

        Dim Filter As String
        Dim TransNum As Integer
        Dim CanOverride As Integer
        Dim ResponseData As New InvokeResponseData
        Dim iErrorFlag As Integer
        Dim dDerSiteDate As DateTime

        Try
            DcjrPVb = 0
            iErrorFlag = 0
            CanOverride = 0

            oCollection = Me.Context.Commands.LoadCollection("SLDcparms", "DerSiteDate", "", "", 0)
            If oCollection.Items.Count > 0 Then
                dDerSiteDate = oCollection.Item(0, "DerSiteDate").GetValue(Of DateTime)()
            End If

            If IDONull.IsNull(PPostDate) Then
                PPostDate = dDerSiteDate
            End If

            Filter = "CHARINDEX(Stat, 'UP') > 0 AND TransType = '3' "
            Filter = Filter & " AND TransDate <= dbo.DayEndOf(" & SqlLiteral.Format(PPostDate) & ")"

            oCollection = Me.LoadCollection("TransNum", Filter, String.Empty, 0)
            For index As Integer = 0 To oCollection.Items.Count - 1
                Infobar = ""
                TransNum = oCollection(index, "TransNum").GetValue(Of Integer)(0)
                Try
                    ResponseData = Me.Invoke("DcjrPSp", TransNum, CanOverride, Infobar)
                    CanOverride = CInt(ResponseData.Parameters(1).Value)
                    Infobar = ResponseData.Parameters(2).Value
                Catch ex As Exception
                    Infobar = MGException.ExtractMessages(ex)
                    iErrorFlag = 1
                End Try
                If ResponseData.IsReturnValueStdError Then
                    ResponseData = Me.Invoke("DcjmLogErrorSp", TransNum, CanOverride, Infobar)
                    If ResponseData.IsReturnValueStdError Then
                        Infobar = "UNKNOWN ERROR CALLING DcjmLogErrorSp"
                        DcjrPVb = 16
                        oCollection = Nothing
                        ResponseData = Nothing
                        Exit Function
                    End If
                End If
            Next
        Catch ex As Exception
            Infobar = Infobar & ":" & MGException.ExtractMessages(ex)
            DcjrPVb = 16
        End Try
        oCollection = Nothing
        ResponseData = Nothing
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcjmDSp(ByVal Status As String, ByVal TransType As String, ByVal FromTransNum As Decimal?, ByVal ToTransNum As Decimal?, ByVal FromTransDate As DateTime?, ByVal ToTransDate As DateTime?, ByRef Infobar As String,
<[Optional]> ByVal StartingTransDateOffset As Short?,
<[Optional]> ByVal EndingTransDateOffset As Short?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iDcjmDExt As IDcjmD = New DcjmDFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iDcjmDExt.DcjmDSp(Status, TransType, FromTransNum, ToTransNum, FromTransDate, ToTransDate, Infobar, StartingTransDateOffset, EndingTransDateOffset)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcjrDSp(ByVal Status As String, ByVal FromTransNum As Decimal?, ByVal ToTransNum As Decimal?, ByVal FromTransDate As DateTime?, ByVal ToTransDate As DateTime?, ByRef Infobar As String,
<[Optional]> ByVal StartingTransDateOffset As Short?,
<[Optional]> ByVal EndingTransDateOffset As Short?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iDcjrDExt As IDcjrD = New DcjrDFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iDcjrDExt.DcjrDSp(Status, FromTransNum, ToTransNum, FromTransDate, ToTransDate, Infobar, StartingTransDateOffset, EndingTransDateOffset)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcAJobmatSp(ByVal TermId As String, ByVal EmpNum As String, ByVal TTransDate As DateTime?, ByVal TransType As String, ByVal JobNum As String,
    <[Optional], DefaultParameterValue(0)> ByVal JobSuffix As Short?, ByVal OperNum As Integer?, ByVal Item As String, ByVal UM As String, ByVal CurWhse As String, ByVal TcQtuQty As Decimal?, ByVal Location As String, ByVal Lot As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iDcAJobmatExt As IDcAJobmat = New DcAJobmatFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iDcAJobmatExt.DcAJobmatSp(TermId, EmpNum, TTransDate, TransType, JobNum, JobSuffix, OperNum, Item, UM, CurWhse, TcQtuQty, Location, Lot, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcAJobrcvSp(ByVal TermId As String, ByVal EmpNum As String, ByVal TTransDate As DateTime?, ByVal JobNum As String,
    <[Optional], DefaultParameterValue(0)> ByVal JobSuffix As Short?, ByVal OperNum As Integer?, ByVal TcQtuQty As Decimal?, ByVal Location As String, ByVal Lot As String, ByVal DocumentNum As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iDcAJobrcvExt As IDcAJobrcv = New DcAJobrcvFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iDcAJobrcvExt.DcAJobrcvSp(TermId, EmpNum, TTransDate, JobNum, JobSuffix, OperNum, TcQtuQty, Location, Lot, DocumentNum, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcJmcValidateEmpNumSp(ByVal Connected As Byte?, ByRef EmpNum As String, ByRef EmpName As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iDcJmcValidateEmpNumExt As IDcJmcValidateEmpNum = New DcJmcValidateEmpNumFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, EmpNum As String, EmpName As String, Infobar As String) = iDcJmcValidateEmpNumExt.DcJmcValidateEmpNumSp(Connected, EmpNum, EmpName, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            EmpNum = result.EmpNum
            EmpName = result.EmpName
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcjmLogErrorSp(ByVal PTransNum As Integer?, ByVal pCanOverride As Integer?, ByVal ErrorMsg As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iDcjmLogErrorExt As IDcjmLogError = New DcjmLogErrorFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iDcjmLogErrorExt.DcjmLogErrorSp(PTransNum, pCanOverride, ErrorMsg)
            Dim Severity As Integer = result.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcjmPSp(ByVal PTransNum As Integer?, ByRef Infobar As String,
<[Optional]> ByVal DocumentNum As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iDcjmPExt As IDcjmP = New DcjmPFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iDcjmPExt.DcjmPSp(PTransNum, Infobar, DocumentNum)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcjrPSp(ByVal PTransNum As Integer?, ByRef pCanOverride As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iDcjrPExt As IDcjrP = New DcjrPFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, pCanOverride As Integer?, Infobar As String) = iDcjrPExt.DcjrPSp(PTransNum, pCanOverride, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            pCanOverride = result.pCanOverride
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcValidateSerNumSp(ByVal Connected As Byte?, ByVal PInOut As Byte?, ByVal PType As String, ByVal PWhseType As String, ByVal PItem As String, ByVal PLocation As String, ByVal PLot As String, ByVal PCurWhse As String, ByVal PSerNum As String,
    <[Optional], DefaultParameterValue(0)> ByVal PRsvdInv As Decimal?, ByVal PDuplicate As Byte?, ByRef Completed As Integer?, ByRef Infobar As String) As Integer
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
