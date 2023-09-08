Option Explicit On
Option Strict On

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.Core.Common
Imports CSI.MG
Imports CSI.Codes
Imports Mongoose.IDO.DataAccess

<IDOExtensionClass("SLHorizons")> _
Public Class SLHorizons
    Inherits CSIExtensionClassBase

    Public Overrides Sub SetContext(ByVal context As Mongoose.IDO.IIDOExtensionClassContext)
        MyBase.SetContext(context)
        ' Add event handlers for pre and post UpdateCollection
        AddHandler Me.Context.IDO.PreUpdateCollection, AddressOf Me.PreUpdateCollection
        AddHandler Me.Context.IDO.PostUpdateCollection, AddressOf Me.PostUpdateCollection
    End Sub

    Private Sub PreUpdateCollection(ByVal sender As Object, ByVal args As IDOEventArgs)
        Me.Context.Commands.Invoke("DefineVariables", "DefineVariableSp", "BufferHorizon", "1", IDONull.Value)
    End Sub

    Private Sub PostUpdateCollection(ByVal sender As Object, ByVal args As IDOEventArgs)
        Dim PInfobar As String = IDONull.Value.ToString
        Dim resp As InvokeResponseData

        resp = Me.Invoke("HorizonPostSaveSp", PInfobar)
        If resp.ReturnValue <> "0" Then
            MGException.Throw(resp.Parameters(0).GetValue(Of String)())
        End If
    End Sub

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function HorizonValidStartDateSp(ByVal PStartDate As DateTime?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iHorizonValidStartDateExt As IHorizonValidStartDate = New HorizonValidStartDateFactory().Create(appDb)

            Dim Severity As Integer = iHorizonValidStartDateExt.HorizonValidStartDateSp(PStartDate, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function HorizonPostSaveSp(ByRef Infobar As String) As Integer
        Dim iHorizonPostSaveExt As IHorizonPostSave = New HorizonPostSaveFactory().Create(Me, True)
        Dim result As (ReturnCode As Integer?, Infobar As String) = iHorizonPostSaveExt.HorizonPostSaveSp(Infobar)
        Dim Severity As Integer = result.ReturnCode.Value
        Infobar = result.Infobar
        Return Severity
    End Function
End Class

