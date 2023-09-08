Option Explicit On
Option Strict On

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common

<IDOExtensionClass("SLEcnhitems")> _
Public Class SLEcnhitems
    Inherits ExtensionClassBase

    Public Function AdjustValuesPQ(ByRef EcnitemType As String, ByRef Job As String, ByRef Suffix As String) As Integer
        Dim vEcnitemTypeL As String
        Try
            vEcnitemTypeL = Left(EcnitemType, 1)
            If vEcnitemTypeL = "C" Then
                Job = ""
                Suffix = ""
            End If
            Exit Function
        Catch ex As Exception
            AdjustValuesPQ = 16
            MGException.Throw(MGException.ExtractMessages(ex))
        End Try
    End Function
End Class
