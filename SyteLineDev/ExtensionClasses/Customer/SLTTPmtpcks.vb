Option Explicit On
Option Strict On

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.Core.Common



<IDOExtensionClass("SLTTPmtpcks")> _
Public Class SLTTPmtpcks
    Inherits Mongoose.IDO.ExtensionClassBase

    Public bRunQuickPaymentsApply As Boolean
    Public Overrides Sub SetContext(ByVal context As Mongoose.IDO.IIDOExtensionClassContext)
        MyBase.SetContext(context)
        ' Add event handlers for pre and post UpdateCollection
        AddHandler Me.Context.IDO.PreUpdateCollection, AddressOf Me.PreUpdateCollection
        AddHandler Me.Context.IDO.PostUpdateCollection, AddressOf Me.PostUpdateCollection
    End Sub
    Private Sub PreUpdateCollection(ByVal sender As Object, ByVal args As IDOEventArgs)
        Dim bCustomUpdate As Boolean
        Dim request As UpdateCollectionRequestData

        request = CType(args.RequestPayload, UpdateCollectionRequestData)
        bCustomUpdate = (Len(request.CustomUpdate) > 0)
        If bCustomUpdate Then
            bRunQuickPaymentsApply = True
        Else
            bRunQuickPaymentsApply = False
        End If
    End Sub
    '******************************************************************************
    'Perform PostUpdateCollection processing. This actually performs all of the
    '"Apply" processing using records inserted in the temp table by the
    'custom update. After executing the process, delete the temp table.
    '******************************************************************************
    Private Sub PostUpdateCollection(ByVal sender As Object, ByVal args As IDOEventArgs)
        Dim ocmd As SqlClient.SqlCommand
        Dim session_id As String
        Dim request As UpdateCollectionRequestData
        request = CType(args.RequestPayload, UpdateCollectionRequestData)
        If request.Items.Count > 0 Then
            session_id = request.Items(0).Properties("UBSessionId").ToString
            Try
                If bRunQuickPaymentsApply Then
                    Me.Invoke("PmtpckPostUpdSp", session_id)
                End If
            Catch Ex As Exception
                Dim Test As String
                Test = Ex.ToString
            End Try
        End If
    End Sub
End Class



