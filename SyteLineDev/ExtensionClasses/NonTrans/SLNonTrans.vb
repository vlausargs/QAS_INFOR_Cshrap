Option Explicit On
Option Strict On

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common
Imports System.Runtime.InteropServices
Imports CSI.Material
Imports CSI.MG
Imports CSI.NonTrans
Imports CSI.Data.RecordSets
Imports CSI.Data.CRUD
Imports CSI.Production

<IDOExtensionClass("SLNonTrans")>
Public Class SLNonTrans
    Inherits CSIExtensionClassBase

    ' Dead code as of MSF 222277.  Should've been cleaned up by MSF 222278.
    '' Delete any alternatives that have been removed
    '<IDOMethod(MethodFlags.None, "Infobar")>
    'Public Function DeleteAlternative(ByRef Infobar As String) As Integer
    '    Dim Script As String = String.Empty
    '    Dim oDataReader As IDataReader
    '    Dim AlternativeList As ArrayList
    '    Dim AlternativeCount As Integer
    '    Dim TableCount As Integer
    '    Dim I As Integer
    '    Dim Tables(104) As String
    '    Dim strView As String
    '    Dim altNo As Integer
    '    Dim altNoStr As String
    '    Dim sqlParms As Dictionary(Of String, Object)

    '    Try
    '        Using appDB As ApplicationDB = Me.CreateApplicationDB()
    '            DeleteAlternative = 0
    '            'Filling Table Array    
    '            I = 0
    '            Tables(I) = "ATTRIB000_mst"
    '            I = I + 1
    '            Tables(I) = "APSOPTIONS000_mst"
    '            I = I + 1
    '            Tables(I) = "BATCH000_mst"
    '            I = I + 1
    '            Tables(I) = "BATPROD000_mst"
    '            I = I + 1
    '            Tables(I) = "BATPRODORD000_mst"
    '            I = I + 1
    '            Tables(I) = "BATRL000_mst"
    '            I = I + 1
    '            Tables(I) = "BATSUM000_mst"
    '            I = I + 1
    '            Tables(I) = "BATTIME000_mst"
    '            I = I + 1
    '            Tables(I) = "BATWAIT000_mst"
    '            I = I + 1
    '            Tables(I) = "BOM000_mst"
    '            I = I + 1
    '            Tables(I) = "CAL000_mst"
    '            I = I + 1
    '            Tables(I) = "CONSPLAN000_mst"
    '            I = I + 1
    '            Tables(I) = "DOWN000_mst"
    '            I = I + 1
    '            Tables(I) = "DOWNPLAN000_mst"
    '            I = I + 1
    '            Tables(I) = "EFFECT000_mst"
    '            I = I + 1
    '            Tables(I) = "EXRCPT000_mst"
    '            I = I + 1
    '            Tables(I) = "INVPLAN000_mst"
    '            I = I + 1
    '            Tables(I) = "JOB000_mst"
    '            I = I + 1
    '            Tables(I) = "JOBLNKS000_mst"
    '            I = I + 1
    '            Tables(I) = "JOBPLAN000_mst"
    '            I = I + 1
    '            Tables(I) = "JOBSTEP000_mst"
    '            I = I + 1
    '            Tables(I) = "JSATTR000_mst"
    '            I = I + 1
    '            Tables(I) = "JS10VR000_mst"
    '            I = I + 1
    '            Tables(I) = "JS11VR000_mst"
    '            I = I + 1
    '            Tables(I) = "JS12VR000_mst"
    '            I = I + 1
    '            Tables(I) = "JS13VR000_mst"
    '            I = I + 1
    '            Tables(I) = "JS14VR000_mst"
    '            I = I + 1
    '            Tables(I) = "JS15VR000_mst"
    '            I = I + 1
    '            Tables(I) = "JS16VR000_mst"
    '            I = I + 1
    '            Tables(I) = "JS17VR000_mst"
    '            I = I + 1
    '            Tables(I) = "JS18VR000_mst"
    '            I = I + 1
    '            Tables(I) = "JS19VR000_mst"
    '            I = I + 1
    '            Tables(I) = "JS2VR000_mst"
    '            I = I + 1
    '            Tables(I) = "JS3VR000_mst"
    '            I = I + 1
    '            Tables(I) = "JS4VR000_mst"
    '            I = I + 1
    '            Tables(I) = "JS6VR000_mst"
    '            I = I + 1
    '            Tables(I) = "JS7VR000_mst"
    '            I = I + 1
    '            Tables(I) = "JS8VR000_mst"
    '            I = I + 1
    '            Tables(I) = "JS9VR000_mst"
    '            I = I + 1
    '            Tables(I) = "LOADPERF000_mst"
    '            I = I + 1
    '            Tables(I) = "LOADSUM000_mst"
    '            I = I + 1
    '            Tables(I) = "LOOKUP000_mst"
    '            I = I + 1
    '            Tables(I) = "LSTATUS000_mst"
    '            I = I + 1
    '            Tables(I) = "MATADDQ000_mst"
    '            I = I + 1
    '            Tables(I) = "MATDELOUT000_mst"
    '            I = I + 1
    '            Tables(I) = "MATL000_mst"
    '            I = I + 1
    '            Tables(I) = "MATLALT000_mst"
    '            I = I + 1
    '            Tables(I) = "MATLATTR000_mst"
    '            I = I + 1
    '            Tables(I) = "MATLDELV000_mst"
    '            I = I + 1
    '            Tables(I) = "MATLGRP000_mst"
    '            I = I + 1
    '            Tables(I) = "MATLPBOMS000_mst"
    '            I = I + 1
    '            Tables(I) = "MATLPLAN000_mst"
    '            I = I + 1
    '            Tables(I) = "MATLPPS000_mst"
    '            I = I + 1
    '            Tables(I) = "MATLRULE000_mst"
    '            I = I + 1
    '            Tables(I) = "MATLWHSE000_mst"
    '            I = I + 1
    '            Tables(I) = "MATREMQ000_mst"
    '            I = I + 1
    '            Tables(I) = "MATSCHD000_mst"
    '            I = I + 1
    '            Tables(I) = "MATSUM000_mst"
    '            I = I + 1
    '            Tables(I) = "MSLPLAN000_mst"
    '            I = I + 1
    '            Tables(I) = "OPRULE000_mst"
    '            I = I + 1
    '            Tables(I) = "ORDATTR000_mst"
    '            I = I + 1
    '            Tables(I) = "ORDER000_mst"
    '            I = I + 1
    '            Tables(I) = "ORDGRP000_mst"
    '            I = I + 1
    '            Tables(I) = "ORDIND000_mst"
    '            I = I + 1
    '            Tables(I) = "ORDPERF000_mst"
    '            I = I + 1
    '            Tables(I) = "ORDPLAN000_mst"
    '            I = I + 1
    '            Tables(I) = "ORDSUM000_mst"
    '            I = I + 1
    '            Tables(I) = "OSMATL000_mst"
    '            I = I + 1
    '            Tables(I) = "PART000_mst"
    '            I = I + 1
    '            Tables(I) = "PARTSUM000_mst"
    '            I = I + 1
    '            Tables(I) = "PBOM000_mst"
    '            I = I + 1
    '            Tables(I) = "PBOMMATLS000_mst"
    '            I = I + 1
    '            Tables(I) = "PDBSIZES000_mst"
    '            I = I + 1
    '            Tables(I) = "PLANINT000_mst"
    '            I = I + 1
    '            Tables(I) = "POEXCEPT000_mst"
    '            I = I + 1
    '            Tables(I) = "POLSCHD000_mst"
    '            I = I + 1
    '            Tables(I) = "POOL000_mst"
    '            I = I + 1
    '            Tables(I) = "POOLQ000_mst"
    '            I = I + 1
    '            Tables(I) = "POOLSUM000_mst"
    '            I = I + 1
    '            Tables(I) = "PROCPLN000_mst"
    '            I = I + 1
    '            Tables(I) = "RESRC000_mst"
    '            I = I + 1
    '            Tables(I) = "RESSCHD000_mst"
    '            I = I + 1
    '            Tables(I) = "RESSEND000_mst"
    '            I = I + 1
    '            Tables(I) = "RESSUM000_mst"
    '            I = I + 1
    '            Tables(I) = "RESATTR000_mst"
    '            I = I + 1
    '            Tables(I) = "RGRP000_mst"
    '            I = I + 1
    '            Tables(I) = "RGRPMBR000_mst"
    '            I = I + 1
    '            Tables(I) = "RESLOAD000_mst"
    '            I = I + 1
    '            Tables(I) = "RESMNT000_mst"
    '            I = I + 1
    '            Tables(I) = "RESPAIR000_mst"
    '            I = I + 1
    '            Tables(I) = "RESPLAN000_mst"
    '            I = I + 1
    '            Tables(I) = "RESQ000_mst"
    '            I = I + 1
    '            Tables(I) = "RGATTR000_mst"
    '            I = I + 1
    '            Tables(I) = "RGLOAD000_mst"
    '            I = I + 1
    '            Tables(I) = "RGRPSUM000_mst"
    '            I = I + 1
    '            Tables(I) = "SCHEDOP000_mst"
    '            I = I + 1
    '            Tables(I) = "SHIFT000_mst"
    '            I = I + 1
    '            Tables(I) = "SHIFTEXDI000_mst"
    '            I = I + 1
    '            Tables(I) = "TBLLIST000_mst"
    '            I = I + 1
    '            Tables(I) = "TODEMAND000_mst"
    '            I = I + 1
    '            Tables(I) = "TOODP000_mst"
    '            I = I + 1
    '            Tables(I) = "TOSUPPLY000_mst"
    '            I = I + 1
    '            Tables(I) = "TRACELOG000_mst"
    '            I = I + 1
    '            Tables(I) = "WAIT000_mst"
    '            I = I + 1
    '            Tables(I) = "WHSE000_mst"


    '            Using cmd As IDbCommand = appDB.CreateCommand()
    '                cmd.CommandType = CommandType.Text

    '                ' Get list of alternatives for this tenant that are no longer in use by any tenant in SL database 
    '                Script = "SELECT ALTNO FROM ALTERN WHERE ALTNO NOT IN (SELECT alt_no FROM aps_site_mst WHERE type ='L' AND alt_no <> 0) AND ALTNO <> 0"
    '                cmd.CommandText = Script
    '                oDataReader = appDB.ExecuteReader(cmd)
    '                AlternativeList = New ArrayList
    '                While oDataReader.Read()
    '                    AlternativeList.Add(oDataReader.Item("ALTNO"))
    '                End While
    '                oDataReader.Close()
    '                oDataReader = Nothing   ' release the result set
    '            End Using
    '            ' Delete the tables/views for these alternatives
    '            For AlternativeCount = 0 To AlternativeList.Count - 1
    '                Script = ""
    '                sqlParms = New Dictionary(Of String, Object)
    '                altNo = CInt(AlternativeList.Item(AlternativeCount))
    '                altNoStr = New String(Convert.ToChar("0"), 3 - Len(CStr(altNo))) & CStr(altNo)
    '                For TableCount = 0 To I
    '                    strView = Left(Tables(TableCount), Tables(TableCount).Length - 4)
    '                    Script &= "EXEC dbo.DeleteTableMessagesSp '" & Tables(TableCount) & "'" & vbCrLf
    '                    Script &= "IF OBJECT_ID('" & Tables(TableCount) & "') IS NOT NULL DROP TABLE " & Tables(TableCount) & "" & vbCrLf
    '                    Script &= "IF OBJECT_ID('" & strView & "') IS NOT NULL DROP VIEW " & strView & "" & vbCrLf
    '                    Script &= "DELETE FROM AppTable WHERE TableName = @TableName" & TableCount & vbCrLf
    '                    sqlParms.Add("@TableName" & TableCount, Tables(TableCount))
    '                Next

    '                Script = Replace(Script, "000", altNoStr)
    '                Using cmd As IDbCommand = appDB.CreateCommand()
    '                    Dim param As IDbDataParameter = Nothing
    '                    cmd.CommandType = CommandType.Text
    '                    cmd.CommandText = Script
    '                    If Not sqlParms Is Nothing Then
    '                        For Each kvp As KeyValuePair(Of String, Object) In sqlParms
    '                            param = cmd.CreateParameter()
    '                            param.ParameterName = kvp.Key
    '                            param.Value = kvp.Value
    '                            cmd.Parameters.Add(param)
    '                        Next
    '                    End If

    '                    appDB.ExecuteNonQuery(cmd)
    '                End Using
    '            Next

    '            ' Get list of alternatives unused by this tenant only (may still be in use by other tenants)
    '            Using cmd As IDbCommand = appDB.CreateCommand()
    '                Script = "SELECT ALTNO FROM ALTERN WHERE ALTNO NOT IN (SELECT alt_no FROM aps_site WHERE type ='L' AND alt_no <> 0) AND ALTNO <> 0"
    '                cmd.CommandText = Script
    '                oDataReader = appDB.ExecuteReader(cmd)
    '                AlternativeList = New ArrayList
    '                While oDataReader.Read()
    '                    AlternativeList.Add(oDataReader.Item("ALTNO"))
    '                End While
    '                oDataReader.Close()
    '                oDataReader = Nothing   ' release the result set
    '            End Using
    '            ' Delete this tenants APS data for these alternatives
    '            For AlternativeCount = 0 To AlternativeList.Count - 1
    '                altNo = CInt(AlternativeList.Item(AlternativeCount))
    '                Script = "DELETE FROM ALTERN WHERE ALTNO = @AltNo" & vbCrLf
    '                Script &= "DELETE FROM ALTPLAN WHERE ALTNO =  @AltNo" & vbCrLf
    '                Script &= "DELETE FROM ALTSCHED WHERE ALTNO =  @AltNo" & vbCrLf
    '                Script &= "DELETE FROM ABOPTS WHERE ALTNO =  @AltNo" & vbCrLf
    '                Script &= "DELETE acd FROM ALTCHGDTL AS acd INNER JOIN ALTCHG ON ALTCHG.ALTCHGID = acd.ALTCHGID WHERE ALTCHG.DSNUM =  @AltNo" & vbCrLf
    '                Script &= "DELETE FROM ALTCHG WHERE ALTCHG.DSNUM =  @AltNo" & vbCrLf
    '                Script &= "DELETE FROM APSMSGS WHERE APSMSGS.MSGALTNO =  @AltNo" & vbCrLf

    '                Using cmd As IDbCommand = appDB.CreateCommand()
    '                    Dim param As IDbDataParameter = Nothing
    '                    cmd.CommandType = CommandType.Text
    '                    cmd.CommandText = Script
    '                    param = cmd.CreateParameter()
    '                    param.ParameterName = "@AltNo"
    '                    param.Value = altNo
    '                    cmd.Parameters.Add(param)
    '                    appDB.ExecuteNonQuery(cmd)
    '                End Using
    '            Next

    '        End Using
    '    Catch ex As Exception
    '        DeleteAlternative = 16
    '        Infobar = MGException.ExtractMessages(ex) & Script
    '    End Try

    'End Function

    ' Dead code as of MSF 222277.  Should've been cleaned up by 222278.
    '' Create Schema to support the Aps alternative
    '<IDOMethod(MethodFlags.None, "Infobar")>
    'Public Function CreateAlternative(ByVal pAltNo As Integer, ByRef Infobar As String) As Integer
    '    Dim Tables(104) As String
    '    Dim Table As String
    '    Dim TableAlt As String
    '    Dim I As Integer
    '    Dim Script As String = String.Empty
    '    Dim Triggers(3) As String
    '    Dim Trigger As String
    '    Dim altNoStr As String
    '    Dim altNo As Integer
    '    Dim oDataReader As IDataReader
    '    Dim strView As String
    '    Dim strDescr As String
    '    Dim sqlParms As Dictionary(Of String, Object)

    '    Try
    '        CreateAlternative = 0
    '        'Filling Table Array    
    '        I = 0
    '        Tables(I) = "ATTRIB000_mst"
    '        I = I + 1
    '        Tables(I) = "APSOPTIONS000_mst"
    '        I = I + 1
    '        Tables(I) = "BATCH000_mst"
    '        I = I + 1
    '        Tables(I) = "BATPROD000_mst"
    '        I = I + 1
    '        Tables(I) = "BATPRODORD000_mst"
    '        I = I + 1
    '        Tables(I) = "BATRL000_mst"
    '        I = I + 1
    '        Tables(I) = "BATSUM000_mst"
    '        I = I + 1
    '        Tables(I) = "BATTIME000_mst"
    '        I = I + 1
    '        Tables(I) = "BATWAIT000_mst"
    '        I = I + 1
    '        Tables(I) = "BOM000_mst"
    '        I = I + 1
    '        Tables(I) = "CAL000_mst"
    '        I = I + 1
    '        Tables(I) = "CONSPLAN000_mst"
    '        I = I + 1
    '        Tables(I) = "DOWN000_mst"
    '        I = I + 1
    '        Tables(I) = "DOWNPLAN000_mst"
    '        I = I + 1
    '        Tables(I) = "EFFECT000_mst"
    '        I = I + 1
    '        Tables(I) = "EXRCPT000_mst"
    '        I = I + 1
    '        Tables(I) = "INVPLAN000_mst"
    '        I = I + 1
    '        Tables(I) = "JOB000_mst"
    '        I = I + 1
    '        Tables(I) = "JOBLNKS000_mst"
    '        I = I + 1
    '        Tables(I) = "JOBPLAN000_mst"
    '        I = I + 1
    '        Tables(I) = "JOBSTEP000_mst"
    '        I = I + 1
    '        Tables(I) = "JSATTR000_mst"
    '        I = I + 1
    '        Tables(I) = "JS10VR000_mst"
    '        I = I + 1
    '        Tables(I) = "JS11VR000_mst"
    '        I = I + 1
    '        Tables(I) = "JS12VR000_mst"
    '        I = I + 1
    '        Tables(I) = "JS13VR000_mst"
    '        I = I + 1
    '        Tables(I) = "JS14VR000_mst"
    '        I = I + 1
    '        Tables(I) = "JS15VR000_mst"
    '        I = I + 1
    '        Tables(I) = "JS16VR000_mst"
    '        I = I + 1
    '        Tables(I) = "JS17VR000_mst"
    '        I = I + 1
    '        Tables(I) = "JS18VR000_mst"
    '        I = I + 1
    '        Tables(I) = "JS19VR000_mst"
    '        I = I + 1
    '        Tables(I) = "JS2VR000_mst"
    '        I = I + 1
    '        Tables(I) = "JS3VR000_mst"
    '        I = I + 1
    '        Tables(I) = "JS4VR000_mst"
    '        I = I + 1
    '        Tables(I) = "JS6VR000_mst"
    '        I = I + 1
    '        Tables(I) = "JS7VR000_mst"
    '        I = I + 1
    '        Tables(I) = "JS8VR000_mst"
    '        I = I + 1
    '        Tables(I) = "JS9VR000_mst"
    '        I = I + 1
    '        Tables(I) = "LOADPERF000_mst"
    '        I = I + 1
    '        Tables(I) = "LOADSUM000_mst"
    '        I = I + 1
    '        Tables(I) = "LOOKUP000_mst"
    '        I = I + 1
    '        Tables(I) = "LSTATUS000_mst"
    '        I = I + 1
    '        Tables(I) = "MATADDQ000_mst"
    '        I = I + 1
    '        Tables(I) = "MATDELOUT000_mst"
    '        I = I + 1
    '        Tables(I) = "MATL000_mst"
    '        I = I + 1
    '        Tables(I) = "MATLALT000_mst"
    '        I = I + 1
    '        Tables(I) = "MATLATTR000_mst"
    '        I = I + 1
    '        Tables(I) = "MATLDELV000_mst"
    '        I = I + 1
    '        Tables(I) = "MATLGRP000_mst"
    '        I = I + 1
    '        Tables(I) = "MATLPBOMS000_mst"
    '        I = I + 1
    '        Tables(I) = "MATLPLAN000_mst"
    '        I = I + 1
    '        Tables(I) = "MATLPPS000_mst"
    '        I = I + 1
    '        Tables(I) = "MATLRULE000_mst"
    '        I = I + 1
    '        Tables(I) = "MATLWHSE000_mst"
    '        I = I + 1
    '        Tables(I) = "MATREMQ000_mst"
    '        I = I + 1
    '        Tables(I) = "MATSCHD000_mst"
    '        I = I + 1
    '        Tables(I) = "MATSUM000_mst"
    '        I = I + 1
    '        Tables(I) = "MSLPLAN000_mst"
    '        I = I + 1
    '        Tables(I) = "OPRULE000_mst"
    '        I = I + 1
    '        Tables(I) = "ORDATTR000_mst"
    '        I = I + 1
    '        Tables(I) = "ORDER000_mst"
    '        I = I + 1
    '        Tables(I) = "ORDGRP000_mst"
    '        I = I + 1
    '        Tables(I) = "ORDIND000_mst"
    '        I = I + 1
    '        Tables(I) = "ORDPERF000_mst"
    '        I = I + 1
    '        Tables(I) = "ORDPLAN000_mst"
    '        I = I + 1
    '        Tables(I) = "ORDSUM000_mst"
    '        I = I + 1
    '        Tables(I) = "OSMATL000_mst"
    '        I = I + 1
    '        Tables(I) = "PART000_mst"
    '        I = I + 1
    '        Tables(I) = "PARTSUM000_mst"
    '        I = I + 1
    '        Tables(I) = "PBOM000_mst"
    '        I = I + 1
    '        Tables(I) = "PBOMMATLS000_mst"
    '        I = I + 1
    '        Tables(I) = "PDBSIZES000_mst"
    '        I = I + 1
    '        Tables(I) = "PLANINT000_mst"
    '        I = I + 1
    '        Tables(I) = "POEXCEPT000_mst"
    '        I = I + 1
    '        Tables(I) = "POLSCHD000_mst"
    '        I = I + 1
    '        Tables(I) = "POOL000_mst"
    '        I = I + 1
    '        Tables(I) = "POOLQ000_mst"
    '        I = I + 1
    '        Tables(I) = "POOLSUM000_mst"
    '        I = I + 1
    '        Tables(I) = "PROCPLN000_mst"
    '        I = I + 1
    '        Tables(I) = "RESRC000_mst"
    '        I = I + 1
    '        Tables(I) = "RESSCHD000_mst"
    '        I = I + 1
    '        Tables(I) = "RESSEND000_mst"
    '        I = I + 1
    '        Tables(I) = "RESSUM000_mst"
    '        I = I + 1
    '        Tables(I) = "RESATTR000_mst"
    '        I = I + 1
    '        Tables(I) = "RGRP000_mst"
    '        I = I + 1
    '        Tables(I) = "RGRPMBR000_mst"
    '        I = I + 1
    '        Tables(I) = "RESLOAD000_mst"
    '        I = I + 1
    '        Tables(I) = "RESMNT000_mst"
    '        I = I + 1
    '        Tables(I) = "RESPAIR000_mst"
    '        I = I + 1
    '        Tables(I) = "RESPLAN000_mst"
    '        I = I + 1
    '        Tables(I) = "RESQ000_mst"
    '        I = I + 1
    '        Tables(I) = "RGATTR000_mst"
    '        I = I + 1
    '        Tables(I) = "RGLOAD000_mst"
    '        I = I + 1
    '        Tables(I) = "RGRPSUM000_mst"
    '        I = I + 1
    '        Tables(I) = "SCHEDOP000_mst"
    '        I = I + 1
    '        Tables(I) = "SHIFT000_mst"
    '        I = I + 1
    '        Tables(I) = "SHIFTEXDI000_mst"
    '        I = I + 1
    '        Tables(I) = "TBLLIST000_mst"
    '        I = I + 1
    '        Tables(I) = "TODEMAND000_mst"
    '        I = I + 1
    '        Tables(I) = "TOODP000_mst"
    '        I = I + 1
    '        Tables(I) = "TOSUPPLY000_mst"
    '        I = I + 1
    '        Tables(I) = "TRACELOG000_mst"
    '        I = I + 1
    '        Tables(I) = "WAIT000_mst"
    '        I = I + 1
    '        Tables(I) = "WHSE000_mst"

    '        Triggers(0) = "Del"
    '        Triggers(1) = "Iup"
    '        Triggers(2) = "Insert"
    '        Triggers(3) = "UpdatePenultimate"

    '        Using appDB As ApplicationDB = Me.CreateApplicationDB()

    '            altNo = pAltNo
    '            altNoStr = New String(Convert.ToChar("0"), 3 - Len(CStr(altNo))) & CStr(altNo)

    '            ' See if the alternative already exists
    '            Using cmd As IDbCommand = appDB.CreateCommand()
    '                Dim param As IDbDataParameter = Nothing
    '                cmd.CommandType = CommandType.Text
    '                cmd.CommandText = "SELECT CASE WHEN object_id(@AttribName) IS NULL THEN 0 ELSE 1 END"
    '                param = cmd.CreateParameter()
    '                param.ParameterName = "@AttribName"
    '                param.Value = "ATTRIB" & altNoStr
    '                cmd.Parameters.Add(param)
    '                oDataReader = appDB.ExecuteReader(cmd)
    '            End Using
    '            If oDataReader.Read() Then
    '                If CInt(oDataReader.Item(0)) = 0 Then

    '                    oDataReader.Close()
    '                    oDataReader = Nothing

    '                    'Duplicate the tables
    '                    For Each Table In Tables
    '                        Using cmd As IDbCommand = appDB.CreateCommand()
    '                            cmd.CommandType = CommandType.StoredProcedure
    '                            cmd.CommandText = "TableScriptSp"

    '                            appDB.AddCommandParameterWithValue(cmd, "TableName", Table).Size = 100
    '                            appDB.AddCommandParameterWithValue(cmd, "GetForeignKeys", 0).Size = 100

    '                            oDataReader = appDB.ExecuteReader(cmd)

    '                            Script = ""
    '                            While oDataReader.Read()
    '                                Script = Script & oDataReader.Item(0).ToString
    '                            End While
    '                            oDataReader.Close()
    '                            oDataReader = Nothing

    '                            Script = Replace(Script, "000", altNoStr)
    '                        End Using
    '                        Using cmd As IDbCommand = appDB.CreateCommand()
    '                            cmd.CommandType = CommandType.Text
    '                            cmd.CommandText = Script

    '                            appDB.ExecuteNonQuery(cmd)
    '                        End Using
    '                        Using cmd As IDbCommand = appDB.CreateCommand()
    '                            sqlParms = New Dictionary(Of String, Object)
    '                            cmd.CommandType = CommandType.StoredProcedure
    '                            cmd.CommandText = "CopyTableMessagesSp"

    '                            appDB.AddCommandParameterWithValue(cmd, "TableName", Table).Size = 100
    '                            appDB.AddCommandParameterWithValue(cmd, "NewAltNo", altNoStr).Size = 100

    '                            appDB.ExecuteNonQuery(cmd)

    '                            'Populate AppTable
    '                            strView = Left(Table, Table.Length - 4)
    '                            If Table = "BATCH000_mst" Or Table = "CAL000_mst" Or Table = "LOOKUP000_mst" Or Table = "RESRC000_mst" Or
    '                               Table = "RGRP000_mst" Or Table = "RGRPMBR000_mst" Or Table = "SHIFT000_mst" Or Table = "SHIFTEXDI000_mst" Then
    '                                strDescr = "APS With UETs"
    '                            Else
    '                                strDescr = "APS"
    '                            End If
    '                            Script =
    '                                   "INSERT INTO AppTable (TableName, IgnoreInsert, IgnoreUpdate, DisallowUpdate," & vbCrLf &
    '                                   "     KeepClusteringKeys, UseRPOnInsert, UseRPOnUpdate, IupTriggerModifiesNewRows," & vbCrLf &
    '                                   "     RememberIdentity, RegisterNewKey, TestOutsideLockForNewKey, NextKeyReverseKeyOrder," & vbCrLf &
    '                                   "     ModuleName, Update_AllRegardlessOfBaseTableChanges, AppViewName, SiteColumnName)" & vbCrLf &
    '                                   "VALUES (@TableName, 0, 0, 0," & vbCrLf &
    '                                   "     0, 0, 0, 0," & vbCrLf &
    '                                   "     0, 0, 0, 0," & vbCrLf &
    '                                   "     @Descr, 0, @ViewName, 'site_ref' ) " & vbCrLf
    '                            'Script = Replace(Script, "000", altNoStr)
    '                            sqlParms.Add("@TableName", Replace(Table, "000", altNoStr))
    '                            sqlParms.Add("@Descr", strDescr)
    '                            sqlParms.Add("@ViewName", Replace(strView, "000", altNoStr))
    '                        End Using
    '                        Using cmd As IDbCommand = appDB.CreateCommand()
    '                            Dim param As IDbDataParameter = Nothing
    '                            cmd.CommandType = CommandType.Text
    '                            cmd.CommandText = Script
    '                            If Not sqlParms Is Nothing Then
    '                                For Each kvp As KeyValuePair(Of String, Object) In sqlParms
    '                                    param = cmd.CreateParameter()
    '                                    param.ParameterName = kvp.Key
    '                                    param.Value = kvp.Value
    '                                    cmd.Parameters.Add(param)
    '                                Next
    '                            End If

    '                            appDB.ExecuteNonQuery(cmd)

    '                            'Create View
    '                            Infobar = ""
    '                        End Using
    '                        Using cmd As IDbCommand = appDB.CreateCommand()
    '                            cmd.CommandType = CommandType.StoredProcedure
    '                            cmd.CommandText = "CreateViewsOverMultiSiteTablesSp"
    '                            TableAlt = Table
    '                            TableAlt = Replace(TableAlt, "000", altNoStr)

    '                            appDB.AddCommandParameterWithValue(cmd, "StartingTable", TableAlt).Size = 100
    '                            appDB.AddCommandParameterWithValue(cmd, "EndingTable", TableAlt).Size = 100
    '                            appDB.AddCommandParameterWithValue(cmd, "Infobar", Infobar).Size = 4000

    '                            appDB.ExecuteNonQuery(cmd)
    '                        End Using
    '                    Next

    '                    'Duplicate the triggers
    '                    For Each Table In Tables
    '                        For Each Trigger In Triggers

    '                            ' See if the trigger exists                                
    '                            Using cmd As IDbCommand = appDB.CreateCommand()
    '                                Dim param As IDbDataParameter = Nothing
    '                                cmd.CommandType = CommandType.Text
    '                                Script = "SELECT CASE WHEN object_id(@TriggerName) IS NULL THEN 0 ELSE 1 END"
    '                                cmd.CommandText = Script
    '                                param = cmd.CreateParameter()
    '                                param.ParameterName = "@TriggerName"
    '                                param.Value = Table & Trigger
    '                                cmd.Parameters.Add(param)

    '                                oDataReader = appDB.ExecuteReader(cmd)
    '                            End Using
    '                            If oDataReader.Read() Then
    '                                If CInt(oDataReader.Item(0)) = 1 Then
    '                                    oDataReader.Close()
    '                                    oDataReader = Nothing
    '                                    Using cmd As IDbCommand = appDB.CreateCommand()
    '                                        cmd.CommandType = CommandType.StoredProcedure
    '                                        cmd.CommandText = "sp_helptext"
    '                                        appDB.AddCommandParameterWithValue(cmd, "objname", Table & Trigger).Size = 100
    '                                        Script = "sp_helptext " & Table & Trigger

    '                                        oDataReader = appDB.ExecuteReader(cmd)

    '                                        Script = ""
    '                                        While oDataReader.Read()
    '                                            Script = Script & oDataReader.Item(0).ToString
    '                                        End While
    '                                        oDataReader.Close()
    '                                    End Using

    '                                    Script = Replace(Script, "000", altNoStr)
    '                                    Using cmd As IDbCommand = appDB.CreateCommand()
    '                                        cmd.CommandType = CommandType.Text
    '                                        cmd.CommandText = Script

    '                                        appDB.ExecuteNonQuery(cmd)
    '                                    End Using
    '                                Else
    '                                    oDataReader.Close()
    '                                    oDataReader = Nothing
    '                                End If
    '                            Else
    '                                oDataReader.Close()
    '                                oDataReader = Nothing
    '                            End If
    '                        Next
    '                    Next
    '                End If
    '            End If

    '            If Not IsNothing(oDataReader) AndAlso Not oDataReader.IsClosed Then
    '                oDataReader.Close()
    '                oDataReader = Nothing
    '            End If

    '            ' Update ALTERN, ALTSCHED, ALTPLAN, ABOPTS, and PLANINTnnn
    '            Script =
    '                "INSERT INTO ALTERN (ALTNO, AGVCNUM, AGVFNUM, ATRIBNUM, AUXNUM, BATNUM," & vbCrLf &
    '                "     BREAKNUM, CALNUM, CONNUM, CONVNUM, DEMNUM, LOOKTABNUM, MATLNUM, OBSNUM," & vbCrLf &
    '                "     ORDNUM, PARTNUM, POOLNUM, PROCNUM, PULLNUM, RESNUM, RGRPNUM, RMNTNUM," & vbCrLf &
    '                "     SHIFTNUM, STATUSNUM, TPSNUM, TRNCNUM, TRNFNUM, UINSNUM, USYMNUM, VARNUM)" & vbCrLf &
    '                "SELECT 000, 000, 000, 000, 000, 000," & vbCrLf &
    '                "     000, 000, 000, 000, 000, 000, 000, 000," & vbCrLf &
    '                "     000, 000, 000, 000, 000, 000, 000, 000," & vbCrLf &
    '                "     000, 000, 000, 000, 000, 000, 000, 000 " & vbCrLf &
    '                "WHERE NOT EXISTS (SELECT 1 FROM ALTERN WHERE ALTNO = 000) " & vbCrLf &
    '                "INSERT INTO ALTSCHED (ALTNO, CLEARDATE, STARTDATE, ENDDATE, TRACDATE," & vbCrLf &
    '                "     TREDATE, ACTCLDATE, ACTSTDATE)" & vbCrLf &
    '                "SELECT 000, dbo.GetSiteDate(getdate()), dbo.GetSiteDate(getdate()), dbo.GetSiteDate(getdate()), dbo.GetSiteDate(getdate())," & vbCrLf &
    '                "    dbo.GetSiteDate(getdate()), dbo.GetSiteDate(getdate()), dbo.GetSiteDate(getdate()) " & vbCrLf &
    '                "WHERE NOT EXISTS (SELECT 1 FROM ALTSCHED WHERE ALTNO = 000) " & vbCrLf &
    '                "INSERT INTO ABOPTS (ALTNO) " & vbCrLf &
    '                "SELECT 000 " & vbCrLf &
    '                "WHERE NOT EXISTS (SELECT 1 FROM ABOPTS WHERE ALTNO = 000) " & vbCrLf &
    '                "INSERT INTO ALTPLAN (ALTNO, PLANGRAN) " & vbCrLf &
    '                "SELECT 000, 1 " & vbCrLf &
    '                "WHERE NOT EXISTS (SELECT 1 FROM ALTPLAN WHERE ALTNO = 000) " & vbCrLf &
    '                "INSERT INTO PLANINT000 (DESCR, NUMUNITS, SEQNUM, UNITCD)" & vbCrLf &
    '                "SELECT 'Default Planning Interval', 1, 0, 'W' " & vbCrLf &
    '                "WHERE NOT EXISTS (SELECT 1 FROM PLANINT000 WHERE SEQNUM = 0) " & vbCrLf
    '            Script = Replace(Script, "000", altNoStr)
    '            Using cmd As IDbCommand = appDB.CreateCommand()
    '                cmd.CommandType = CommandType.Text
    '                cmd.CommandText = Script

    '                appDB.ExecuteNonQuery(cmd)
    '            End Using
    '        End Using

    '    Catch ex As Exception
    '        CreateAlternative = 16
    '        Infobar = MGException.ExtractMessages(ex) & Script
    '    End Try
    'End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function MrpWbGenerateOrderSp(ByVal UserID As Decimal?, ByVal RefTab As String,
<[Optional]> ByVal PoparmsPoPrefix As String,
<[Optional]> ByVal PoChange As String,
<[Optional]> ByVal BlanketQtyOver As Byte?,
<[Optional]> ByVal PurchReqNotes As Byte?,
<[Optional]> ByVal PoparmsPrqPrefix As String,
<[Optional]> ByVal SfcparmsWoPrefix As String,
<[Optional]> ByVal CopyCurrentBOM As Byte?,
<[Optional]> ByVal CopyIndentedBOM As Byte?,
<[Optional]> ByVal SfcparmsPsPrefix As String,
<[Optional]> ByVal SingleOrder As Byte?,
<[Optional]> ByVal InvparmsTrnPrefix As String,
<[Optional]> ByVal SessionID As Guid?,
<[Optional]> ByVal CopyToPSItemBOM As Byte?, ByRef Infobar As String,
<[Optional], DefaultParameterValue(CByte(0))> ByVal CreateTransitLoc As Byte?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iMrpWbGenerateOrderExt As IMrpWbGenerateOrder = New MrpWbGenerateOrderFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iMrpWbGenerateOrderExt.MrpWbGenerateOrderSp(UserID, RefTab, PoparmsPoPrefix, PoChange, BlanketQtyOver, PurchReqNotes, PoparmsPrqPrefix, SfcparmsWoPrefix, CopyCurrentBOM, CopyIndentedBOM, SfcparmsPsPrefix, SingleOrder, InvparmsTrnPrefix, SessionID, CopyToPSItemBOM, Infobar, CreateTransitLoc)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CreateAlternative(ByVal AltNo As Short?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iCreateAlternativeExt As ICreateAlternative = New CreateAlternativeFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iCreateAlternativeExt.CreateAlternativeSp(AltNo, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DeleteAlternative(ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iDeleteAlternativeExt As IDeleteAlternative = New DeleteAlternativeFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iDeleteAlternativeExt.DeleteAlternativeSp(Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetXmlReportingDetailsSp(ByVal SiteID As String, ByRef IntranetName As String, ByRef XMLReportingURL As String, ByRef XMLReportingFolder As String, ByRef XMLReportingDatasetURL As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iGetXmlReportingDetailsExt As IGetXmlReportingDetails = New GetXmlReportingDetailsFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, IntranetName As String, XMLReportingURL As String, XMLReportingFolder As String, XMLReportingDatasetURL As String, Infobar As String) = iGetXmlReportingDetailsExt.GetXmlReportingDetailsSp(SiteID, IntranetName, XMLReportingURL, XMLReportingFolder, XMLReportingDatasetURL, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            IntranetName = result.IntranetName
            XMLReportingURL = result.XMLReportingURL
            XMLReportingFolder = result.XMLReportingFolder
            XMLReportingDatasetURL = result.XMLReportingDatasetURL
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ItemLocMassCreation(ByVal PBegItem As String, ByVal PEndItem As String, ByVal PWhse As String, ByVal PLoc As String, ByVal PMrbFlag As Byte?, ByVal PPermFlag As Byte?, ByRef RecordProcessed As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iItemWhstkExt As IItemWhstk = New ItemWhstkFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, RecordProcessed As Integer?, Infobar As String) = iItemWhstkExt.ItemWhstkSp(PBegItem, PEndItem, PWhse, PLoc, PMrbFlag, PPermFlag, RecordProcessed, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            RecordProcessed = result.RecordProcessed
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ShrinkDatabaseSp(
        <[Optional]> ByVal DatabaseName As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iShrinkDatabaseExt As IShrinkDatabase = New ShrinkDatabaseFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iShrinkDatabaseExt.ShrinkDatabaseSp(DatabaseName)
            Dim Severity As Integer = result.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function MatlPlannerWorkbenchGenSp(ByVal DelPwbBatch As Byte?, ByVal UsePln As Byte?, ByVal EndDate As DateTime?, ByVal Source As String, ByVal PlannerCode As String, ByVal Buyer As String, ByVal Whse As String, ByVal Replenishment As String, ByVal ThingsToProcess As String, ByVal StartingItem As String, ByVal EndingItem As String, ByVal StartingOrder As String, ByVal EndingOrder As String, ByVal StartingProject As String, ByVal EndingProject As String, ByVal StartingTransfer As String, ByVal EndingTransfer As String, ByVal StartingJob As String, ByVal EndingJob As String, ByVal StartingJobSuf As Short?, ByVal EndingJobSuf As Short?, ByVal UserId As Decimal?) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim iMatlPlannerWorkbenchGenExt As IMatlPlannerWorkbenchGen = New MatlPlannerWorkbenchGenFactory().Create(appDb, bunchedLoadCollection)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iMatlPlannerWorkbenchGenExt.MatlPlannerWorkbenchGenSp(DelPwbBatch, UsePln, EndDate, Source, PlannerCode, Buyer, Whse, Replenishment, ThingsToProcess, StartingItem, EndingItem, StartingOrder, EndingOrder, StartingProject, EndingProject, StartingTransfer, EndingTransfer, StartingJob, EndingJob, StartingJobSuf, EndingJobSuf, UserId)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function
End Class
