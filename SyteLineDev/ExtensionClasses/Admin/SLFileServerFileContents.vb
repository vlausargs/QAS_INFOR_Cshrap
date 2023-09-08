Option Explicit On
Option Strict On

Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Collections
Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.Core.Common
Imports Mongoose.MGCore

<IDOExtensionClass("SLFileServerFileContents")> _
Public Class SLFileServerFileContents
    Inherits ExtensionClassBase

    <IDOMethod(MethodFlags.None, "Infobar")> _
    Public Function SaveFile(ByRef Infobar As String, ByRef saved As Integer, fileSpec As String, _
                                servername As String, logicalFolderName As String, overwrite As Integer, _
                                IdoName As String, IdoMethod As String, IdoMethodParams As String) As Integer
        Dim fileServer As FileServerExtension = New FileServerExtension()
        Dim response As InvokeResponseData
        Dim ParmArry As String()
        Dim strFileName, strContent As String
        Dim requestData As InvokeRequestData = New InvokeRequestData()
        Dim byteSrcStr() As Byte = Nothing

        ParmArry = IdoMethodParams.Split("|"c)

        requestData.IDOName = IdoName
        requestData.MethodName = IdoMethod
        For i = 0 To ParmArry.Length - 1
            requestData.Parameters.Add(ParmArry(i))
        Next

        response = Me.Context.Commands.Invoke(requestData)

        strFileName = response.Parameters(0).ToString()
        strContent = response.Parameters(1).ToString()

        byteSrcStr = System.Text.Encoding.Default.GetBytes(strContent)
        strContent = Convert.ToBase64String(byteSrcStr)

        Return fileServer.SaveFileContentFromBase64String(Infobar, saved, strContent, fileSpec, servername, logicalFolderName, overwrite, strFileName)

    End Function
End Class
