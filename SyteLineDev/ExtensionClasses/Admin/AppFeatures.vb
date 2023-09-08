Option Explicit On

Imports Mongoose.IDO
Imports Mongoose.Core.Common
Imports Mongoose.IDO.DataAccess
Imports CSI.Admin
Imports System.Runtime.InteropServices
Imports CSI.MG

<IDOExtensionClass("AppFeatures")>
Public Class AppFeatures
    Inherits CSIExtensionClassBase

    Public Enum Status
        StatError = 16
    End Enum

    Private Const HashKey As String = "sS@P,Q%P<*c];jk.#Vaew|R02w$R07egE[<b8"
    Private Const DevKeyMatch As String = "R02w$R07"
    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EncryptPreReleaseFeatureId(
                 ByVal ProductName As String _
               , ByVal FeatureID As String _
               , ByVal DevKey As String _
               , ByRef EncFeatureID As String _
               , ByRef InfoBar As String) As String

        'If the function is NOT called from 'Pre-release Feature Keys - Internal' form (which passses the proper DevKey)
        'or ValidatePreReleaseFeatureKey function below, do not send the encrypted value.

        If StrComp(DevKey, DevKeyMatch) <> 0 Then
            InfoBar = InfoBar & Space(1) & "Error: Invalid Development Key"
            Return Status.StatError
        End If
        Dim sBuffer As String = ""

        Try
            sBuffer = ProductName
            sBuffer = sBuffer & HashKey
            sBuffer = sBuffer & FeatureID

            ' Get Hash Code
            EncryptPreReleaseFeatureId = Crypto.GenerateMD5Hash(sBuffer)
            EncFeatureID = EncryptPreReleaseFeatureId
        Catch ex As Exception
            InfoBar = InfoBar & Space(1) & ex.Message
            Return Status.StatError
        End Try

    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ValidatePreReleaseFeatureKey(
                  ByVal ProductName As String _
                , ByVal FeatureID As String _
                , ByVal PreReleaseKey As String _
                , ByRef CheckSumOkay As Integer _
                , ByRef InfoBar As String) As Integer

        Dim EncFeatureID As String = ""
        ' Get Hash Code
        Dim HashValue As String = EncryptPreReleaseFeatureId(ProductName, FeatureID, DevKeyMatch, EncFeatureID, InfoBar)

        ' Assume Failure
        ValidatePreReleaseFeatureKey = 16
        CheckSumOkay = 0
        Try
            If StrComp(PreReleaseKey, HashValue) = 0 Then
                CheckSumOkay = 1
            End If
            ValidatePreReleaseFeatureKey = 0
        Catch ex As Exception
            InfoBar = InfoBar & Space(1) & ex.Message
            Return ValidatePreReleaseFeatureKey
        End Try
        Return ValidatePreReleaseFeatureKey
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function LoadActiveFeatureListSp(
        <[Optional], DefaultParameterValue("CSI")> ByVal ProductName As String, ByRef ActiveFeatureList As String) As Integer
        Dim iLoadActiveFeatureListExt = New LoadActiveFeatureListFactory().Create(Me, True)
        Dim result As (ReturnCode As Integer?, ActiveFeatureList As String) = iLoadActiveFeatureListExt.LoadActiveFeatureListSp(ProductName, ActiveFeatureList)
        Dim Severity As Integer = result.ReturnCode.Value
        ActiveFeatureList = result.ActiveFeatureList
        Return Severity
    End Function
End Class
