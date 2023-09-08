Option Explicit On
Option Strict On

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common

<IDOExtensionClass("SLMATLDELVnnns")> _
Public Class SLMATLDELVnnns
    Inherits ExtensionClassBase

    <IDOMethod(MethodFlags.None)> _
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
        Using db As AppDB = IDORuntime.Context.CreateAppDB()
            Dim altno As Integer = CType(db.GetSessionVariable("ApsAltern"), Integer)
            request.IDOName = "TABLE!" + "MATLDELV" + altno.ToString("000")
            args.ResponsePayload = Me.Context.Commands.LoadCollection(request)
        End Using
    End Sub

    Private Sub HandlePreUpdateCollection(ByVal sender As Object, ByVal args As IDOEventArgs)
        Dim request As UpdateCollectionRequestData = CType(args.RequestPayload, UpdateCollectionRequestData)
        Using db As AppDB = IDORuntime.Context.CreateAppDB()
            Dim altno As Integer = CType(db.GetSessionVariable("ApsAltern"), Integer)
            request.IDOName = "TABLE!" + "MATLDELV" + altno.ToString("000")
            args.ResponsePayload = Me.Context.Commands.UpdateCollection(request)
        End Using
    End Sub

End Class

