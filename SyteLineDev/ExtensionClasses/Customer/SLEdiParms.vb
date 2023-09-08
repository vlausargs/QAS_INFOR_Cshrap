Option Explicit On
Option Strict On

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common
Imports System.Data.SqlClient
Imports CSI.Logistics.Customer
Imports CSI.MG

<IDOExtensionClass("SLEdiParms")> _
Public Class SLEdiParms
    Inherits CSIExtensionClassBase

    <IDOMethod(MethodFlags.None)> _
    Public Function GetParm(ByRef strParmValue As String, ByVal strParmName As String) As Integer


        Dim ResultSet As IDataReader
        Dim strParmNameWithQuote As String
        strParmNameWithQuote = strParmName.Replace("]", "]]")
        strParmNameWithQuote = "[" + strParmNameWithQuote + "]"

        Try
            GetParm = 0

            Using db As ApplicationDB = IDORuntime.Context.CreateAppDB()
                Using cmd As IDbCommand = db.CreateCommand()
                    cmd.CommandText = "SELECT " & strParmNameWithQuote & " FROM edi_parms"


                    ResultSet = cmd.ExecuteReader

                    If ResultSet.Read() Then
                        strParmValue = TextUtil.FormatNormalizedString(ResultSet.GetValue(0))
                    Else
                        MGException.Throw(Me.GetMessageProvider.GetMessage("E=NoExist1", "@!Parameters", "@edi_parms", strParmName))
                    End If
                    If ResultSet IsNot Nothing Then
                        ResultSet.Close()
                        ResultSet.Dispose()
                        ResultSet = Nothing
                    End If
                    If cmd IsNot Nothing Then
                        cmd.Connection.Dispose()
                    End If
                End Using
            End Using
            Return 0
        Catch ex As Exception
            MGException.Throw(MGException.ExtractMessages(ex))
        End Try
    End Function


    <IDOMethod(MethodFlags.None)> _
    Public Function EDIExport(ByRef pID As String, ByRef userName As String, ByRef siteName As String) As Integer
        Dim exporter As SLEdiExporter = New SLEdiExporter()
        Try
            exporter.ExportEDI(pID, userName, siteName)
        Catch ex As Exception
            MGException.Throw(MGException.ExtractMessages(ex))
        Finally
            If exporter IsNot Nothing Then
                If exporter.EdiFileOps IsNot Nothing Then
                    exporter.EdiFileOps.Dispose()
                End If
                If exporter.EdiServerOps.AppDBConnection IsNot Nothing And exporter.EdiServerOps IsNot Nothing Then
                    exporter.EdiServerOps.AppDBConnection.Dispose()
                    exporter.EdiServerOps.AppDBConnection = Nothing
                End If
                If exporter.EdiServerOps IsNot Nothing Then
                    exporter.EdiServerOps.Dispose()
                End If
            End If
        End Try
        Return 0
    End Function

    <IDOMethod(MethodFlags.None)> _
    Public Function EDIImport(ByRef pID As String, ByRef userName As String, ByRef siteName As String) As Integer
        Dim importer As SLEdiImporter = New SLEdiImporter()
        Try
            importer.ImportEDI(pID, userName, siteName)
        Catch ex As Exception
            Try
                importer.WriteBgTaskLog(pID, ex.InnerException.ToString(), 16)
            Catch ex2 As Exception
                MGException.Throw(MGException.ExtractMessages(ex))
            End Try
        Finally
            If importer IsNot Nothing Then
                If importer.EdiFileOps IsNot Nothing Then
                    importer.EdiFileOps.Dispose()
                End If
                If importer.EdiServerOps.AppDBConnection IsNot Nothing And importer.EdiServerOps IsNot Nothing Then
                    importer.EdiServerOps.AppDBConnection.Dispose()
                    importer.EdiServerOps.AppDBConnection = Nothing
                End If
                If importer.EdiServerOps IsNot Nothing Then
                    importer.EdiServerOps.Dispose()
                End If
            End If
        End Try

        Return 0
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function InsertEdiParmsSp() As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iInsertEdiParmsExt As IInsertEdiParms = New InsertEdiParmsFactory().Create(appDb)

            Dim Severity As Integer = iInsertEdiParmsExt.InsertEdiParmsSp()

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetEdiImportParmsSp(ByRef SupTpCode As String, ByRef SupIbDataDir As String, ByRef SupIbArchiveDir As String, ByRef SupEdiLogDir As String, ByRef TpCode As String, ByRef IbDataDir As String, ByRef IbArchiveDir As String, ByRef EdiLogDir As String, ByRef ArchiveFileExt As String) As Integer
        Dim iGetEdiImportParmsExt As IGetEdiImportParms = New GetEdiImportParmsFactory().Create(Me, True)
        Dim result As (ReturnCode As Integer?, SupTpCode As String, SupIbDataDir As String, SupIbArchiveDir As String, SupEdiLogDir As String, TpCode As String, IbDataDir As String, IbArchiveDir As String, EdiLogDir As String, ArchiveFileExt As String) = iGetEdiImportParmsExt.GetEdiImportParmsSp(SupTpCode, SupIbDataDir, SupIbArchiveDir, SupEdiLogDir, TpCode, IbDataDir, IbArchiveDir, EdiLogDir, ArchiveFileExt)
        Dim Severity As Integer = result.ReturnCode.Value
        SupTpCode = result.SupTpCode
        SupIbDataDir = result.SupIbDataDir
        SupIbArchiveDir = result.SupIbArchiveDir
        SupEdiLogDir = result.SupEdiLogDir
        TpCode = result.TpCode
        IbDataDir = result.IbDataDir
        IbArchiveDir = result.IbArchiveDir
        EdiLogDir = result.EdiLogDir
        ArchiveFileExt = result.ArchiveFileExt
        Return Severity
    End Function
End Class
