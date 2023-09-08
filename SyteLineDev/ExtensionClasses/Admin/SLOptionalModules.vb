Option Explicit On

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports System.Collections

<IDOExtensionClass("SLOptionalModules")> _
Public Class SLOptionalModules

    Inherits ExtensionClassBase

    Public Enum Status
        StatError = 16
    End Enum

    <IDOMethod(MethodFlags.None)> _
    Public Function IsModuleLicensed(ByVal ModuleName As String _
                                  , ByRef IsModuleLicensedFlag As String) As String
        Dim objLicenses As InvokeResponseData = Nothing
        Try
            If ModuleName.Contains("ServiceManagement") Then
                Dim objectLicensesList As New List(Of InvokeResponseData) From {
                    Me.Context.Commands.Invoke("Licenses", "IsModuleLicensed", "ServiceManagement", IsModuleLicensedFlag),
                    Me.Context.Commands.Invoke("Licenses", "IsModuleLicensed", "ServiceManagementLite", IsModuleLicensedFlag),
                    Me.Context.Commands.Invoke("Licenses", "IsModuleLicensed", "ServiceManagement_MS", IsModuleLicensedFlag),
                    Me.Context.Commands.Invoke("Licenses", "IsModuleLicensed", "AssetManagement", IsModuleLicensedFlag),
                    Me.Context.Commands.Invoke("Licenses", "IsModuleLicensed", "AssetManagement_MS", IsModuleLicensedFlag)
                }

                If objectLicensesList.Exists(Function(x) x.Parameters(1).GetValue(Of String)() = "1") Then
                    IsModuleLicensedFlag = "1"
                End If
            Else
                objLicenses = Me.Context.Commands.Invoke("Licenses", "IsModuleLicensed", ModuleName, IsModuleLicensedFlag)
                IsModuleLicensedFlag = objLicenses.Parameters(1).GetValue(Of String)()
            End If

            If ModuleName = "Automotive_Mfg" Or ModuleName = "MoldingPack" Or ModuleName = "PrintingPack" Then
                IsModuleLicensedFlag = "1"
            End If

            Return objLicenses.ReturnValue
        Catch ex As Exception
            Return Status.StatError
        End Try
    End Function

End Class