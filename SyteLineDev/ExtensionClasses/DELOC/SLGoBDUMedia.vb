Option Explicit On
Option Strict On

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common
Imports Mongoose.MGCore
Imports System.Text
Imports CSI.Data.SQL.UDDT
Imports System
Imports System.Data
Imports CSI.MG
Imports System.Runtime.InteropServices
Imports CSI.Reporting.Germany
Imports Microsoft.Extensions.DependencyInjection
Imports CSI.Data.CRUD
Imports CSI.Data.RecordSets
Imports System.Data.SqlTypes

<IDOExtensionClass("SLGoBDUMedia")>
Public Class SLGoBDUMedia
    Inherits CSIExtensionClassBase

    Private _fse As FileServerExtension = New FileServerExtension()

    Public Overrides Sub SetContext(context As IIDOExtensionClassContext)
        MyBase.SetContext(context)
    End Sub

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Sub SLGoBDUMediaGenerateCsv(
        ByVal TranDateBeg As String,
        ByVal TranDateEnd As String,
        ByVal SiteID As String,
        ByVal LogicalFolder As String,
        ByVal FileName As String,
        ByVal SpName As String)

        Dim TranDateBegConvert As DateTime = CDate(IIf(IsNothing(TranDateBeg), SqlDateTime.MinValue.Value, Convert.ToDateTime(TranDateBeg)))
        Dim TranDateEndConvert As DateTime = CDate(IIf(IsNothing(TranDateEnd), SqlDateTime.MaxValue.Value, Convert.ToDateTime(TranDateEnd)))

        Dim iGoBDUMediaService = Me.GetService(Of IRpt_GOBDUMediaService)()
        Dim getResult = iGoBDUMediaService.Rpt_GetBDTransferData(SpName, TranDateBegConvert, TranDateEndConvert, SiteID)

        Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
        Dim resultTable = recordCollectionToDataTable.ToDataTable(getResult.Data.Items)

        SaveFileToFileServer(LogicalFolder, FileName, DataTableToCSV(resultTable), "")

    End Sub

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Sub SLGoBDUMediaGenerateIndexCsv(
        ByVal ProcessID As String,
        ByVal LogicalFolder As String,
        ByVal FileName As String,
        ByVal SpName As String)

        Dim resultTable As New DataTable()
        Dim iGetGoBDUMediaService = Me.GetService(Of IRpt_GetGoBDMediaData)()
        Dim getResult = iGetGoBDUMediaService.Rpt_GetGoBDMediaDataSp(Guid.Parse(ProcessID))

        Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
        resultTable = recordCollectionToDataTable.ToDataTable(getResult.Data.Items)

        SaveFileToFileServer(LogicalFolder, FileName, DataTableToXML(resultTable), "")

    End Sub

    Public Shared Function DataTableToXML(dTable As DataTable) As String

        'Do not need the Columns
        'Otherewise this was copied from DataTableToCSV()

        Dim sb As StringBuilder = New StringBuilder()
        Dim intClmn As Integer = dTable.Columns.Count

        Dim row As DataRow
        For Each row In dTable.Rows

            Dim ir As Integer = 0
            For ir = 0 To intClmn - 1 Step ir + 1
                sb.Append(row(ir).ToString())
            Next
        Next

        Return sb.ToString()
    End Function


    Public Shared Function DataTableToCSV(dTable As DataTable) As String

        '--------Columns Name---------------------------------------------------------------------------

        Dim sb As StringBuilder = New StringBuilder()
        Dim intClmn As Integer = dTable.Columns.Count

        Dim i As Integer = 0
        For i = 0 To intClmn - 1 Step i + 1
            sb.Append("""" + dTable.Columns(i).ColumnName.ToString() + """")
            If i = intClmn - 1 Then
                sb.Append(" ")
            Else
                sb.Append(",")
            End If
        Next
        sb.Append(vbNewLine)

        '--------Data By  Columns---------------------------------------------------------------------------

        Dim row As DataRow
        For Each row In dTable.Rows

            Dim ir As Integer = 0
            For ir = 0 To intClmn - 1 Step ir + 1
                sb.Append("""" + row(ir).ToString().Replace("""", """""") + """")
                If ir = intClmn - 1 Then
                    sb.Append(" ")
                Else
                    sb.Append(",")
                End If

            Next
            sb.Append(vbNewLine)
        Next

        Return sb.ToString()
    End Function


    Public Sub SaveFileToFileServer(ByVal logicalFolderName As String, ByVal fileName As String,
                                         ByVal fileContent As String, ByRef errMsg As String)


        Dim fileServerName As String = ""
        Dim folderTemplate As String = ""
        Dim accessDepth As String = ""
        Dim fileSpec As String = ""

        Dim fileContentBytes As Byte() = New Byte() {}
        Dim parsedFileSpec As String = ""
        Dim saved As Integer = 0
        Dim success As Boolean = False

        Try
            GetFileServerInfoByLogicalFolderName(logicalFolderName, fileServerName, folderTemplate, accessDepth, errMsg, fileName)
            fileSpec = GetFileSpec(folderTemplate, fileName, "", accessDepth, True)
            fileContentBytes = Encoding.ASCII.GetBytes(fileContent)
            _fse.SaveFileContent(errMsg, saved, fileContentBytes, fileSpec, fileServerName, logicalFolderName)
            If saved = 1 Then
                success = True
            Else
                MGException.Throw(errMsg)
            End If

        Catch ex As Exception
            success = False
            errMsg = ex.Message
            MGException.Throw(errMsg)
        End Try

    End Sub

    Sub GetFileServerInfoByLogicalFolderName(ByVal logicalFolderName As String,
                                             ByRef fileServerName As String,
                                             ByRef folderTemplate As String,
                                             ByRef accessDepth As String,
                                             ByRef errMsg As String,
                                             ByVal fileName As String)
        Try
            Dim req As New LoadCollectionRequestData
            Dim res As New LoadCollectionResponseData

            req.IDOName = "FileServerLogicalFolders"
            req.Filter = ""
            res = Context.Commands.LoadCollection("FileServerLogicalFolders", "LogicalFolderName,ServerName,FolderTemplate,FolderAccessDepth", "LogicalFolderName = '" + logicalFolderName + "'", "", 0)

            fileServerName = res(0, "ServerName").Value
            folderTemplate = res(0, "FolderTemplate").Value
            accessDepth = res(0, "FolderAccessDepth").Value

        Catch ex As Exception
            errMsg = ex.Message
            MGException.Throw(errMsg)
        End Try
    End Sub

    Function GetFileSpec(ByVal folderTemplate As String, ByVal fileName As String,
                             ByVal fileExtension As String, ByVal accessDepth As String,
                             ByVal useServerCheck As Boolean) As String
        Dim useServerCheckStr As String
        Dim fileSpec As String = String.Empty

        If useServerCheck Then
            useServerCheckStr = "1"
        Else
            useServerCheckStr = "0"
        End If

        If fileName.LastIndexOf("\") >= 0 Then
            fileName = fileName.Substring(fileName.LastIndexOf("\")).TrimStart("\"c)
        End If

        fileSpec = folderTemplate.TrimEnd("/"c) + "\" + fileName + "|" + fileExtension + "|" + accessDepth + "|" + useServerCheckStr

        Return fileSpec
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_GoBDUMediaSp(ByVal MediaName As String, ByVal TransDateBeg As DateTime?, ByVal TransDateEnd As DateTime?, ByVal CollectionsList As String) As DataTable
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim iCLM_GoBDUMediaExt = New CLM_GoBDUMediaFactory().Create(appDb, bunchedLoadCollection)
            Dim dt As DataTable = iCLM_GoBDUMediaExt.CLM_GoBDUMediaSp(MediaName, TransDateBeg, TransDateEnd, CollectionsList)
            Return dt
        End Using
    End Function

End Class
