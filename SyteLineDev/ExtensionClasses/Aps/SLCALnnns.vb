Option Explicit On
Option Strict On

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common

Imports CSI.Data.SQL.UDDT
Imports CSI.Production.APS
Imports CSI.Production
Imports CSI.MG
Imports System.Runtime.InteropServices

<IDOExtensionClass("SLCALnnns")>
Public Class SLCALnnns
    Inherits ExtensionClassBase

    <IDOMethod(MethodFlags.None)>
    Public Sub SetAlternative(ByVal altno As String)
        Using db As AppDB = IDORuntime.Context.CreateAppDB()
            db.SetSessionVariable("ApsAltern", altno)
        End Using
    End Sub

    Public Overrides Sub SetContext(ByVal context As Mongoose.IDO.IIDOExtensionClassContext)
        MyBase.SetContext(context)
        AddHandler Me.Context.IDO.PreLoadCollection, AddressOf Me.HandlePreLoadCollection
        AddHandler Me.Context.IDO.PreUpdateCollection, AddressOf Me.HandlePreUpdateCollection
    End Sub

    Private Sub HandlePreLoadCollection(ByVal sender As Object, ByVal args As IDOEventArgs)
        Dim request As LoadCollectionRequestData = CType(args.RequestPayload, LoadCollectionRequestData)

        'Dim store the original names of the fields in a dictionary 
        Dim fieldNames As Dictionary(Of String, String) = New Dictionary(Of String, String)

        For a As Integer = 0 To request.PropertyList.Count - 1
            Dim ix As Integer = request.PropertyList(a).ToUpper().IndexOf("UF_")
            If ix <> -1 Then
                Dim newFieldName As String = request.PropertyList(a).Substring(ix)
                fieldNames(newFieldName) = request.PropertyList(a)
                request.PropertyList(a) = newFieldName
            End If

        Next


        Using db As AppDB = IDORuntime.Context.CreateAppDB()
            Dim altno As Integer = CType(db.GetSessionVariable("ApsAltern"), Integer)
            request.IDOName = "TABLE!" + "CAL" + altno.ToString("000")
            args.ResponsePayload = Me.Context.Commands.LoadCollection(request)
        End Using

        'Then rename the properties back to their original names
        Dim response As LoadCollectionResponseData = TryCast(args.ResponsePayload, LoadCollectionResponseData)
        For a As Integer = 0 To response.PropertyList.Count - 1

            If fieldNames.ContainsKey(response.PropertyList(a)) Then
                response.PropertyList(a) = fieldNames(response.PropertyList(a))
            End If

        Next
    End Sub

    Private Sub HandlePreUpdateCollection(ByVal sender As Object, ByVal args As IDOEventArgs)
        Dim request As UpdateCollectionRequestData = CType(args.RequestPayload, UpdateCollectionRequestData)

        'Dim store the original names of the fields in a dictionary 
        Dim fieldNames As Dictionary(Of String, String) = New Dictionary(Of String, String)

        For Each itm As IDOUpdateItem In request.Items
            For p As Integer = 0 To itm.Properties.Count - 1
                Dim ix As Integer = itm.Properties(p).Name.ToUpper().IndexOf("UF_")

                If ix <> -1 Then
                    Dim newFieldName As String = itm.Properties(p).Name.Substring(ix)
                    fieldNames(newFieldName) = itm.Properties(p).Name
                    itm.Properties(p).Name = newFieldName
                End If
            Next

        Next

        Using db As AppDB = IDORuntime.Context.CreateAppDB()
            Dim altno As Integer = CType(db.GetSessionVariable("ApsAltern"), Integer)
            request.IDOName = "TABLE!" + "CAL" + altno.ToString("000")
            args.ResponsePayload = Me.Context.Commands.UpdateCollection(request)
        End Using

    End Sub

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function Cal000BldHldyMcalSp(ByVal PTSfcFlag As Byte?, ByVal PTMdayDate As DateTime?, ByVal AltNo As Short?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iCal000BldHldyMcalExt As ICal000BldHldyMcal = New Cal000BldHldyMcalFactory().Create(appDb, MGInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iCal000BldHldyMcalExt.Cal000BldHldyMcalSp(PTSfcFlag, PTMdayDate, AltNo, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function Cal000MrpDatesSp(ByVal AltNo As Short?, ByRef PStartDate As DateTime?, ByRef PEndDate As DateTime?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iCal000MrpDatesExt As ICal000MrpDates = New Cal000MrpDatesFactory().Create(appDb)

            Dim oPStartDate As DateType = PStartDate
            Dim oPEndDate As DateType = PEndDate

            Dim Severity As Integer = iCal000MrpDatesExt.Cal000MrpDatesSp(AltNo, oPStartDate, oPEndDate)

            PStartDate = oPStartDate
            PEndDate = oPEndDate

            Return Severity
        End Using
    End Function
End Class
