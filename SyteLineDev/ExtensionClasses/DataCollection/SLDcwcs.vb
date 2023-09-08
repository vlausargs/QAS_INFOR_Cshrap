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

<IDOExtensionClass("SLDcwcs")> _
Public Class SLDcwcs
    Inherits ExtensionClassBase
    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcwcPVb(ByVal PPostDate As Nullable(Of DateTime), ByRef Infobar As String) As Integer

        Dim oCollection As LoadCollectionResponseData
        Dim ResponseData As InvokeResponseData = Nothing

        Dim Filter As String
        Dim TransNum As Integer
        Dim DocumentNum As String
        Dim iErrorFlag As Integer
        Dim dDerSiteDate As DateTime

        DcwcPVb = 0
        Try
            oCollection = Me.Context.Commands.LoadCollection("SLDcparms", "DerSiteDate", "", "", 0)
            If oCollection.Items.Count > 0 Then
                dDerSiteDate = oCollection.Item(0, "DerSiteDate").GetValue(Of DateTime)()
            End If

            If IDONull.IsNull(PPostDate) Then
                PPostDate = dDerSiteDate
            End If

            Filter = "CHARINDEX(Stat, 'UP') > 0 AND TransNum > 0 "
            Filter = Filter & " AND TransDate <= dbo.DayEndOf(" & SqlLiteral.Format(PPostDate) & ")"

            oCollection = Me.LoadCollection("TransNum, DocumentNum", Filter, String.Empty, 0)

            For index As Integer = 0 To oCollection.Items.Count - 1
                TransNum = oCollection(index, "TransNum").GetValue(Of Integer)(-1)
                DocumentNum = oCollection(index, "DocumentNum").Value
                Try
                    ResponseData = Me.Invoke("DcwcPSp", TransNum, Infobar, DocumentNum)
                    Infobar = ResponseData.Parameters(1).Value
                Catch ex As Exception
                    Infobar = MGException.ExtractMessages(ex)
                    iErrorFlag = 1
                End Try

                If ResponseData.IsReturnValueStdError Or iErrorFlag = 1 Then
                    ResponseData = Me.Invoke("DcwcLogErrorSp", TransNum, Infobar)
                    If ResponseData.IsReturnValueStdError Then
                        Infobar = "UNKNOWN ERROR CALLING DcwcLogErrorSp"
                        DcwcPVb = 16
                        Exit Function
                    End If
                End If
            Next
        Catch ex As Exception
            Infobar = Infobar & ":" & MGException.ExtractMessages(ex)
            DcwcPVb = 16
        Finally
            oCollection = Nothing
            ResponseData = Nothing
        End Try
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcwcDSp(ByVal Status As String, ByVal FromTransNum As Decimal?, ByVal ToTransNum As Decimal?, ByVal FromEmpNum As String, ByVal ToEmpNum As String, ByVal FromTransDate As DateTime?, ByVal ToTransDate As DateTime?, ByRef Infobar As String,
<[Optional]> ByVal StartingTransDateOffset As Short?,
<[Optional]> ByVal EndingTransDateOffset As Short?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iDcwcDExt As IDcwcD = New DcwcDFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iDcwcDExt.DcwcDSp(Status, FromTransNum, ToTransNum, FromEmpNum, ToEmpNum, FromTransDate, ToTransDate, Infobar, StartingTransDateOffset, EndingTransDateOffset)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcwcLogErrorSp(ByVal PTransNum As Integer?, ByVal ErrorMsg As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iDcwcLogErrorExt As IDcwcLogError = New DcwcLogErrorFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iDcwcLogErrorExt.DcwcLogErrorSp(PTransNum, ErrorMsg)
            Dim Severity As Integer = result.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcwcPSp(ByVal PTransNum As Integer?, ByRef Infobar As String,
<[Optional]> ByVal DocumentNum As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iDcwcPExt As IDcwcP = New DcwcPFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iDcwcPExt.DcwcPSp(PTransNum, Infobar, DocumentNum)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcwcChkWhseSp(ByVal DCitemItem As String, ByVal DcWhse As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iDcwcChkWhseExt As IDcwcChkWhse = New DcwcChkWhseFactory().Create(appDb)

            Dim Severity As Integer = iDcwcChkWhseExt.DcwcChkWhseSp(DCitemItem, DcWhse, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetDcparmAutopostEscFlagSp(ByVal AutoPostFieldName As String, ByRef AutoPostFlag As Integer?, ByRef EscFlag As String, ByRef Infobar As String) As Integer
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

