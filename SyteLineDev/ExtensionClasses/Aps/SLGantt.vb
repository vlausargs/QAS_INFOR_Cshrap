Option Explicit On
Option Strict On

Imports System
Imports System.Xml

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common
Imports CSI.MG
Imports CSI.Production.APS
Imports CSI.Data.SQL.UDDT
Imports IMessageProvider = Mongoose.IDO.IMessageProvider

<IDOExtensionClass("SLGantt")>
Public Class SLGantt
    Inherits ExtensionClassBase

    Private Const ERR_OK As Integer = 1
    Private Const ERR_NOROOTNODE As Integer = -300
    Private Const ERR_BADLEAFINDEX As Integer = -301
    Private Const ERR_BADREQUESTXML As Integer = -302
    Private Const ERR_BADRESPONSEXML As Integer = -303
    Private Const ERR_VBRT As Integer = -304
    Private Const ERR_NODATA As Integer = -305

    Private Const MIN_DATE As Date = #1/1/1900#
    Private Const MAX_DATE As Date = #1/1/2028#

    Public DEBUG_MODE As Boolean = True

    Private Function vntConvertDate(ByVal sDate As String) As Date

        ' Purpose:
        '    To convert a date string into a variant type, while limiting
        '    the year range to 1980-2079.
        ' Returns:
        '    The date converted into a variant.
        ' Inputs:
        '    sDate - The date to convert.

        Dim vntDate As Date
        Dim iYear As Integer

        vntDate = CDate(sDate)

        iYear = Year(vntDate)
        If iYear >= 1900 And iYear < 1980 Then
            vntDate = DateAdd(DateInterval.Year, 100, vntDate)
        End If

        vntConvertDate = vntDate

    End Function

    ' --------------------------------------------------------
    ' Highlights
    ' --------------------------------------------------------

    Private Const HLFLAG_INTEGER As Integer = 2
    Private Const HLFLAG_DOUBLE As Integer = 4
    Private Const HLFLAG_STRING As Integer = 8
    Private Const HLFLAG_DATE As Integer = 16

    Private Structure CriterionInfo
        Dim iType As Integer
        Dim iComparison As Integer
        Dim lSeqnum As Integer
        Dim lColor As UInteger
        Dim iCmpStart As Integer
        Dim iCmpLength As Integer
        Dim lFlags As Integer
        Dim lParam As Integer
        Dim dParam As Double
        Dim sParam As String
        Dim datParam As Date
    End Structure

    Private Structure HighlightInfo
        Dim sHighlightid As String
        Dim lColor As UInteger
        Dim lFlags As Integer
        Dim uCriteria() As CriterionInfo
        Dim lCriterionCount As Integer
    End Structure

    Private Const HL_NONE As Integer = -1

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function SaveGanttChanges(ByVal sChangeXML As String,
                                     ByRef sResponseXML As String,
                                     ByRef Infobar As String) As Integer

        Dim oDoc As New System.Xml.XmlDocument
        Dim oChangeNode As System.Xml.XmlNode
        Dim oChangeList As System.Xml.XmlNodeList
        Dim oNode As System.Xml.XmlNode
        Dim sAction As String
        Dim sResID As String
        Dim sGroupID As String
        Dim datStart As Date
        Dim sStartCd As String
        Dim datEnd As Date
        Dim sEndCd As String
        Dim nJobTag As Integer
        Dim nSeqNum As Integer
        Dim sStatusCd As String
        Dim sRowPointer As String
        Dim sOrderID As String
        Dim sOperation As String
        Dim nFrozenFg As Integer
        Dim oResponse As Mongoose.IDO.Protocol.InvokeResponseData

        On Error GoTo SaveGanttChanges_error

        ' Load document
        oDoc.LoadXml(sChangeXML)

        ' Get List of changes
        oChangeList = oDoc.SelectNodes("/SaveSchedule/Change")

        ' Execute changes
        For Each oChangeNode In oChangeList
            oNode = oChangeNode.SelectSingleNode("Action")
            If oNode Is Nothing Then
                GoTo SaveGanttChanges_error
            End If
            sAction = oNode.InnerText

            If sAction = "U" Or sAction = "I" Or sAction = "D" Then
                oNode = oChangeNode.SelectSingleNode("ResID")
                If oNode Is Nothing Then
                    GoTo SaveGanttChanges_error
                End If
                sResID = oNode.InnerText
                oNode = oChangeNode.SelectSingleNode("GroupID")
                If oNode Is Nothing Then
                    GoTo SaveGanttChanges_error
                End If
                sGroupID = oNode.InnerText
                oNode = oChangeNode.SelectSingleNode("StartDate")
                If oNode Is Nothing Then
                    GoTo SaveGanttChanges_error
                End If
                datStart = MGType.FromInternal(Of Date)(oNode.InnerText)
                oNode = oChangeNode.SelectSingleNode("StartCd")
                If oNode Is Nothing Then
                    GoTo SaveGanttChanges_error
                End If
                sStartCd = oNode.InnerText
                oNode = oChangeNode.SelectSingleNode("EndDate")
                If oNode Is Nothing Then
                    GoTo SaveGanttChanges_error
                End If
                datEnd = MGType.FromInternal(Of Date)(oNode.InnerText)
                oNode = oChangeNode.SelectSingleNode("EndCd")
                If oNode Is Nothing Then
                    GoTo SaveGanttChanges_error
                End If
                sEndCd = oNode.InnerText
                oNode = oChangeNode.SelectSingleNode("JobTag")
                If oNode Is Nothing Then
                    GoTo SaveGanttChanges_error
                End If
                nJobTag = MGType.FromInternal(Of Integer)(oNode.InnerText)
                oNode = oChangeNode.SelectSingleNode("SeqNum")
                If oNode Is Nothing Then
                    GoTo SaveGanttChanges_error
                End If
                nSeqNum = MGType.FromInternal(Of Integer)(oNode.InnerText)
                oNode = oChangeNode.SelectSingleNode("StatusCd")
                If oNode Is Nothing Then
                    GoTo SaveGanttChanges_error
                End If
                sStatusCd = oNode.InnerText
                oNode = oChangeNode.SelectSingleNode("RowPointer")
                If oNode Is Nothing Then
                    GoTo SaveGanttChanges_error
                End If
                sRowPointer = oNode.InnerText

                oResponse = Me.Context.Commands.Invoke(
                                        "ResourceSchedules",
                                        "ApsUpdateResSchedSp",
                                        sAction,
                                        sResID,
                                        sGroupID,
                                        datStart,
                                        sStartCd,
                                        datEnd,
                                        sEndCd,
                                        nJobTag,
                                        nSeqNum,
                                        sStatusCd,
                                        sRowPointer)
            ElseIf sAction = "F" Then
                oNode = oChangeNode.SelectSingleNode("OrderID")
                If oNode Is Nothing Then
                    GoTo SaveGanttChanges_error
                End If
                sOrderID = oNode.InnerText
                oNode = oChangeNode.SelectSingleNode("JobTag")
                If oNode Is Nothing Then
                    GoTo SaveGanttChanges_error
                End If
                nJobTag = MGType.FromInternal(Of Integer)(oNode.InnerText)
                oNode = oChangeNode.SelectSingleNode("FrozenFlag")
                If oNode Is Nothing Then
                    GoTo SaveGanttChanges_error
                End If
                nFrozenFg = MGType.FromInternal(Of Integer)(oNode.InnerText)
                oResponse = Me.Context.Commands.Invoke(
                                        "ResourceSchedules",
                                        "ApsFreezeSchedOpSp",
                                        sOrderID,
                                        nFrozenFg,
                                        nJobTag)
            End If
        Next

        ' Done
        SaveGanttChanges = 0
        sResponseXML = "<SaveScheduleResponse>0</SaveScheduleResponse>"
        Exit Function

SaveGanttChanges_error:
        SaveGanttChanges = 16
        sResponseXML = "<SaveScheduleResponse>-1</SaveScheduleResponse>"

    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetHighlights(ByVal vsUserName As String,
                                  ByRef rsHighlightsXML As String,
                                  ByRef rsInfobar As String) As Integer

        Dim sProperties, sFilter As String
        Dim oData As LoadCollectionResponseData
        Dim iRC, lHighlightCount, lIndex, lCritIndex As Integer
        Dim iHIGHLIGHTID, iCOLOR, iFLAGS As Integer
        Dim iSEQNUM, iTYPE, iCOMPARISON, iPARAM, iCMPSTART, iCMPLENGTH As Integer
        Dim uHighlights(1) As HighlightInfo

        GetHighlights = 0

        rsHighlightsXML = String.Empty
        rsInfobar = String.Empty

        On Error GoTo GetHighlightsError

        If DEBUG_MODE Then
            IDORuntime.LogUserMessage("SLGantt", UserDefinedMessageType.UserDefined1,
                                      "Begin GetHighlights")
        End If

        ' Load highlights
        sProperties = "HIGHLIGHTID, COLOR, FLAGS"
        sFilter = "USERNAME = " & SqlLiteral.Format(vsUserName)
        oData = Me.Context.Commands.LoadCollection("SL.SLGNTHLCATs", sProperties, sFilter, "", 0)

        lHighlightCount = oData.Items.Count

        If lHighlightCount > 0 Then

            ReDim uHighlights(lHighlightCount)

            iHIGHLIGHTID = oData.PropertyList.IndexOf("HIGHLIGHTID")
            iCOLOR = oData.PropertyList.IndexOf("COLOR")
            iFLAGS = oData.PropertyList.IndexOf("FLAGS")

            lIndex = 0
            For Each item As IDOItem In oData.Items
                uHighlights(lIndex).sHighlightid = item.PropertyValues(iHIGHLIGHTID).ToString()
                uHighlights(lIndex).lColor = item.PropertyValues(iCOLOR).GetValue(Of UInteger)()
                uHighlights(lIndex).lFlags = item.PropertyValues(iFLAGS).GetValue(Of Integer)()
                lIndex = lIndex + 1
            Next

            oData = Nothing

            ' For each highlight, load criteria
            For lIndex = 0 To lHighlightCount - 1

                sProperties = "SEQNUM, TYPE, COMPARISON, PARAM, COLOR, CMPSTART, CMPLENGTH, FLAGS"
                sFilter = "USERNAME = " & SqlLiteral.Format(vsUserName) &
                          " AND HIGHLIGHTID = " & SqlLiteral.Format(uHighlights(lIndex).sHighlightid)
                oData = Me.Context.Commands.LoadCollection("SL.SLGNTHLCRITs", sProperties, sFilter, "", 0)

                uHighlights(lIndex).lCriterionCount = oData.Items.Count

                If uHighlights(lIndex).lCriterionCount > 0 Then

                    ReDim uHighlights(lIndex).uCriteria(uHighlights(lIndex).lCriterionCount)

                    iSEQNUM = oData.PropertyList.IndexOf("SEQNUM")
                    iTYPE = oData.PropertyList.IndexOf("TYPE")
                    iCOMPARISON = oData.PropertyList.IndexOf("COMPARISON")
                    iPARAM = oData.PropertyList.IndexOf("PARAM")
                    iCOLOR = oData.PropertyList.IndexOf("COLOR")
                    iCMPSTART = oData.PropertyList.IndexOf("CMPSTART")
                    iCMPLENGTH = oData.PropertyList.IndexOf("CMPLENGTH")
                    iFLAGS = oData.PropertyList.IndexOf("FLAGS")

                    lCritIndex = 0
                    For Each item As IDOItem In oData.Items
                        uHighlights(lIndex).uCriteria(lCritIndex).iType = item.PropertyValues(iTYPE).GetValue(Of Integer)()
                        uHighlights(lIndex).uCriteria(lCritIndex).lSeqnum = item.PropertyValues(iSEQNUM).GetValue(Of Integer)()
                        uHighlights(lIndex).uCriteria(lCritIndex).lColor = item.PropertyValues(iCOLOR).GetValue(Of UInteger)()
                        uHighlights(lIndex).uCriteria(lCritIndex).lFlags = item.PropertyValues(iFLAGS).GetValue(Of Integer)()
                        uHighlights(lIndex).uCriteria(lCritIndex).iComparison = item.PropertyValues(iCOMPARISON).GetValue(Of Integer)()
                        uHighlights(lIndex).uCriteria(lCritIndex).iCmpStart = item.PropertyValues(iCMPSTART).GetValue(Of Integer)()
                        uHighlights(lIndex).uCriteria(lCritIndex).iCmpLength = item.PropertyValues(iCMPLENGTH).GetValue(Of Integer)()

                        If (uHighlights(lIndex).uCriteria(lCritIndex).lFlags And HLFLAG_INTEGER) <> 0 Then
                            uHighlights(lIndex).uCriteria(lCritIndex).lParam = CInt(item.PropertyValues(iPARAM).ToString())
                        ElseIf (uHighlights(lIndex).uCriteria(lCritIndex).lFlags And HLFLAG_STRING) <> 0 Then
                            uHighlights(lIndex).uCriteria(lCritIndex).sParam = item.PropertyValues(iPARAM).ToString()
                        ElseIf (uHighlights(lIndex).uCriteria(lCritIndex).lFlags And HLFLAG_DOUBLE) <> 0 Then
                            uHighlights(lIndex).uCriteria(lCritIndex).dParam = CDbl(item.PropertyValues(iPARAM).ToString())
                        ElseIf (uHighlights(lIndex).uCriteria(lCritIndex).lFlags And HLFLAG_DATE) <> 0 Then
                            uHighlights(lIndex).uCriteria(lCritIndex).datParam = vntConvertDate(item.PropertyValues(iPARAM).ToString())
                        End If

                        lCritIndex = lCritIndex + 1
                    Next

                End If

                oData = Nothing

            Next lIndex

        End If

        iRC = GetHighlightsXML(Nothing, Nothing, rsHighlightsXML, lHighlightCount, uHighlights, rsInfobar)
        If iRC <> ERR_OK Then
            GetHighlights = 16
            GoTo GetHighlightsExit
        End If

        GetHighlights = 0
        GoTo GetHighlightsExit

GetHighlightsError:

        GetHighlights = 16
        rsInfobar = "SLGantt.GetHighlights(): Internal error " & Err.Number & " - " & Err.Description

GetHighlightsExit:

        oData = Nothing

        If DEBUG_MODE Then
            If GetHighlights = 0 Then
                IDORuntime.LogUserMessage("SLGantt", UserDefinedMessageType.UserDefined1,
                                          "End GetHighlights, ret=0")
            Else
                IDORuntime.LogUserMessage("SLGantt", UserDefinedMessageType.UserDefined1,
                                          "End GetHighlights, ret={0}, msg={1}",
                                          GetHighlights, rsInfobar)
            End If
        End If

    End Function

    Private Function GetHighlightsXML(ByRef oRefNode As XmlNode,
                                      ByRef oRefDoc As XmlDocument,
                                      ByRef rsHighlightsXML As String,
                                      ByVal vlHighlightCount As Integer,
                                      ByRef ruHighlights() As HighlightInfo,
                                      ByRef rsInfobar As String) As Integer

        Dim oDetailDOM As New XmlDocument
        Dim oNode, oParentNode As XmlNode
        Dim oListOfHighlights, oHighlightNode As XmlNode
        Dim oListOfCritera, oCriteronNode As XmlNode
        Dim lIndex, lCritIndex As Integer

        On Error GoTo GetHighlightsXMLError

        ' Create root tag
        If oRefDoc Is Nothing Or oRefNode Is Nothing Then
            oParentNode = oDetailDOM.CreateElement("HighlightInfo")
            oDetailDOM.AppendChild(oParentNode)
        Else
            oDetailDOM = oRefDoc
            oParentNode = oRefNode
        End If

        ' Add base elements
        oNode = oDetailDOM.CreateElement("Debug")
        oNode.InnerText = ""
        oParentNode.AppendChild(oNode)

        oNode = oDetailDOM.CreateElement("Version")
        oNode.InnerText = "9.00.00"
        oParentNode.AppendChild(oNode)

        ' Add list of highlights
        oNode = oDetailDOM.CreateElement("Highlights")
        oListOfHighlights = oParentNode.AppendChild(oNode)

        oNode = oDetailDOM.CreateElement("Count")
        oNode.InnerText = MGType.ToInternal(vlHighlightCount)
        oListOfHighlights.AppendChild(oNode)

        For lIndex = 0 To vlHighlightCount - 1

            oNode = oDetailDOM.CreateElement("Highlight")
            oHighlightNode = oListOfHighlights.AppendChild(oNode)

            oNode = oDetailDOM.CreateElement("HighlightID")
            oNode.InnerText = ruHighlights(lIndex).sHighlightid
            oHighlightNode.AppendChild(oNode)

            oNode = oDetailDOM.CreateElement("Color")
            oNode.InnerText = MGType.ToInternal(ruHighlights(lIndex).lColor)
            oHighlightNode.AppendChild(oNode)

            oNode = oDetailDOM.CreateElement("Flags")
            oNode.InnerText = MGType.ToInternal(ruHighlights(lIndex).lFlags)
            oHighlightNode.AppendChild(oNode)

            ' Add list of criteria
            oNode = oDetailDOM.CreateElement("Criteria")
            oListOfCritera = oHighlightNode.AppendChild(oNode)

            oNode = oDetailDOM.CreateElement("Count")
            oNode.InnerText = MGType.ToInternal(ruHighlights(lIndex).lCriterionCount)
            oListOfCritera.AppendChild(oNode)

            For lCritIndex = 0 To ruHighlights(lIndex).lCriterionCount - 1

                oCriteronNode = oDetailDOM.CreateElement("Criteron")
                oListOfCritera.AppendChild(oCriteronNode)

                oNode = oDetailDOM.CreateElement("Type")
                oNode.InnerText = MGType.ToInternal(ruHighlights(lIndex).uCriteria(lCritIndex).iType)
                oCriteronNode.AppendChild(oNode)

                oNode = oDetailDOM.CreateElement("Comparison")
                oNode.InnerText = MGType.ToInternal(ruHighlights(lIndex).uCriteria(lCritIndex).iComparison)
                oCriteronNode.AppendChild(oNode)

                oNode = oDetailDOM.CreateElement("SeqNum")
                oNode.InnerText = MGType.ToInternal(ruHighlights(lIndex).uCriteria(lCritIndex).lSeqnum)
                oCriteronNode.AppendChild(oNode)

                oNode = oDetailDOM.CreateElement("Color")
                oNode.InnerText = MGType.ToInternal(ruHighlights(lIndex).uCriteria(lCritIndex).lColor)
                oCriteronNode.AppendChild(oNode)

                oNode = oDetailDOM.CreateElement("CmpStart")
                oNode.InnerText = MGType.ToInternal(ruHighlights(lIndex).uCriteria(lCritIndex).iCmpStart)
                oCriteronNode.AppendChild(oNode)

                oNode = oDetailDOM.CreateElement("CmpLength")
                oNode.InnerText = MGType.ToInternal(ruHighlights(lIndex).uCriteria(lCritIndex).iCmpLength)
                oCriteronNode.AppendChild(oNode)

                oNode = oDetailDOM.CreateElement("Flags")
                oNode.InnerText = MGType.ToInternal(ruHighlights(lIndex).uCriteria(lCritIndex).lFlags)
                oCriteronNode.AppendChild(oNode)

                If (ruHighlights(lIndex).uCriteria(lCritIndex).lFlags And HLFLAG_INTEGER) <> 0 Then
                    oNode = oDetailDOM.CreateElement("lParam")
                    oNode.InnerText = MGType.ToInternal(ruHighlights(lIndex).uCriteria(lCritIndex).lParam)
                    oCriteronNode.AppendChild(oNode)
                ElseIf (ruHighlights(lIndex).uCriteria(lCritIndex).lFlags And HLFLAG_STRING) <> 0 Then
                    oNode = oDetailDOM.CreateElement("sParam")
                    oNode.InnerText = ruHighlights(lIndex).uCriteria(lCritIndex).sParam
                    oCriteronNode.AppendChild(oNode)
                ElseIf (ruHighlights(lIndex).uCriteria(lCritIndex).lFlags And HLFLAG_DOUBLE) <> 0 Then
                    oNode = oDetailDOM.CreateElement("dParam")
                    oNode.InnerText = MGType.ToInternal(ruHighlights(lIndex).uCriteria(lCritIndex).dParam)
                    oCriteronNode.AppendChild(oNode)
                ElseIf (ruHighlights(lIndex).uCriteria(lCritIndex).lFlags And HLFLAG_DATE) <> 0 Then
                    oNode = oDetailDOM.CreateElement("datParam")
                    oNode.InnerText = MGType.ToInternal(ruHighlights(lIndex).uCriteria(lCritIndex).datParam)
                    oCriteronNode.AppendChild(oNode)
                End If

            Next lCritIndex

        Next lIndex

        ' Return response XML
        If oRefDoc Is Nothing Or oRefNode Is Nothing Then
            rsHighlightsXML = oDetailDOM.OuterXml
        End If

        GetHighlightsXML = ERR_OK
        Exit Function

GetHighlightsXMLError:
        GetHighlightsXML = ERR_VBRT
        rsInfobar = "SLGantt.GetHighlightsXML(): Internal error " & Err.Number & " - " & Err.Description

    End Function

    ' --------------------------------------------------------
    ' Gantt Data
    ' --------------------------------------------------------
    Private Const NULL_DATE As Date = #1/1/1753#

    Private Const BAR_MAX As Integer = 25000

    Private Const BAR_DOWN As Integer = 0
    Private Const BAR_OPER_PLAN As Integer = 1
    Private Const BAR_OPER_FROZEN As Integer = 2
    Private Const BAR_FAIL_PLAN As Integer = 4

    Private Const STATUS_UNKNOWN As Integer = 0
    Private Const STATUS_INPROCESS As Integer = 1
    Private Const STATUS_ALLOCATE As Integer = 2
    Private Const STATUS_RESUME As Integer = 3
    Private Const STATUS_KEEP As Integer = 4
    Private Const STATUS_RESUMEX As Integer = 5
    Private Const STATUS_FREE As Integer = 6
    Private Const STATUS_INTERRUPT As Integer = 7
    Private Const STATUS_HOLD As Integer = 8
    Private Const STATUS_BEFORE As Integer = 9
    Private Const STATUS_AFTER As Integer = 10
    Private Const STATUS_FAIL As Integer = 11
    Private Const STATUS_REPAIR As Integer = 12
    Private Const STATUS_NEVER As Integer = 13
    Private Const STATUS_START As Integer = 15
    Private Const STATUS_END As Integer = 16
    Private Const STATUS_WAIT As Integer = 17
    Private Const STATUS_RELEASE As Integer = 18
    Private Const STATUS_DUE As Integer = 19
    Private Const STATUS_SETUPEND As Integer = 20
    Private Const STATUS_OPERSTART As Integer = 21

    Private Structure RowInfo
        Dim sResource As String
        Dim sDescr As String
        Dim sResType As String
        Dim sShift1 As String
        Dim sShift2 As String
        Dim sShift3 As String
        Dim sShift4 As String
        Dim uBlocks() As BlockInfo
        Dim lBlockCount As Integer
    End Structure

    Private Structure BlockInfo
        Dim iBarType As Integer
        Dim iStartCd As Integer
        Dim iEndCd As Integer
        Dim bFrozen As Boolean
        Dim datStart As Date
        Dim datEnd As Date
        Dim sStatusCd As String
        Dim datDate1 As Date
        Dim datDate2 As Date
        Dim datDate3 As Date
        Dim sOrderID As String
        Dim iInt1 As Integer
        Dim iInt2 As Integer
        Dim iInt3 As Integer
        Dim sString1 As String
        Dim sString2 As String
        Dim sString3 As String
        Dim sString4 As String
        Dim sString5 As String
        Dim sString6 As String
        Dim sString7 As String
        Dim sString8 As String
        Dim sString9 As String
        Dim dDbl1 As Double
        Dim dDbl2 As Double
        Dim dDbl3 As Double
        Dim dDbl4 As Double
        Dim RowPointer As Guid
        Dim bUnderProd As Boolean
        Dim bOverScrap As Boolean
        Dim sJobSufOper As String

    End Structure

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetGanttData(ByVal vsAltno As String,
                                 ByVal vsUserName As String,
                                 ByVal vsResourceID As String,
                                 ByVal vsGroupID As String,
                                 ByVal vsSelection As String,
                                 ByVal vsStartDate As String,
                                 ByVal vsEndDate As String,
                                 ByVal vsPlan0Sched1 As String,
                                 ByRef rsGanttDataXML As String,
                                 ByRef rsInfobar As String,
                                 ByVal vsCustomer As String,
                                 ByVal vsItem As String,
                                 ByVal vsMaterial As String,
                                 ByVal vsShift As String) As Integer

        Dim sProperties, sFilter As String
        Dim datStartDate, datEndDate As Date
        Dim iAltno, iPlan0Sched1 As Integer
        Dim oData As LoadCollectionResponseData
        Dim iRC, lRowCount, lIndex, lCritIndex As Integer
        Dim iHIGHLIGHTID, iCOLOR, iFLAGS As Integer
        Dim iSEQNUM, iTYPE, iCOMPARISON, iPARAM, iCMPSTART, iCMPLENGTH As Integer
        Dim sSelectionList() As String
        Dim bUsePlanOutputForSched As Boolean
        Dim uRows(1) As RowInfo

        GetGanttData = 0

        rsGanttDataXML = String.Empty
        rsInfobar = String.Empty

        iAltno = MGType.FromInternal(Of Integer)(vsAltno)
        iPlan0Sched1 = MGType.FromInternal(Of Integer)(vsPlan0Sched1)
        datStartDate = MGType.FromInternal(Of Date)(vsStartDate)
        datEndDate = MGType.FromInternal(Of Date)(vsEndDate)

        On Error GoTo GetGanttDataError

        If DEBUG_MODE Then
            IDORuntime.LogUserMessage("SLGantt", UserDefinedMessageType.UserDefined1,
                                      "Begin GetGanttData")
        End If

        ' Populate selection list
        If vsResourceID <> "" Then

            lRowCount = 1

            ReDim uRows(lRowCount)

            iRC = AddRow(iAltno, vsResourceID, 0, uRows, rsInfobar)
            If iRC <> 0 Then
                GetGanttData = 16
                GoTo GetGanttDataExit
            End If

        ElseIf vsGroupID <> "" Then

            iRC = GetGroupMembers(iAltno, vsGroupID, uRows, lRowCount, rsInfobar)
            If iRC <> 0 Then
                GetGanttData = 16
                GoTo GetGanttDataExit
            End If

            ReDim uRows(lRowCount)

        ElseIf vsSelection <> "" Then

            iRC = GetSelectionMembers(iAltno, vsUserName, vsSelection, uRows, lRowCount, rsInfobar, vsShift)
            If iRC <> 0 Then
                GetGanttData = 16
                GoTo GetGanttDataExit
            End If

        Else

            iRC = GetAllResources(iAltno, uRows, lRowCount, iPlan0Sched1, datStartDate, datEndDate, rsInfobar, vsShift)
            If iRC <> 0 Then
                GetGanttData = 16
                GoTo GetGanttDataExit
            End If

        End If

        If lRowCount > 0 Then

            For lIndex = 0 To lRowCount - 1

                iRC = AddDownBlocks(iAltno, uRows(lIndex).sResource, iPlan0Sched1, datStartDate, datEndDate,
                                    uRows(lIndex).lBlockCount, uRows(lIndex).uBlocks, rsInfobar)
                If iRC <> 0 Then
                    GetGanttData = 16
                    GoTo GetGanttDataExit
                End If

                iRC = AddBlocks(iAltno, uRows(lIndex).sResource, iPlan0Sched1, datStartDate, datEndDate,
                                uRows(lIndex).lBlockCount, uRows(lIndex).uBlocks, rsInfobar, vsCustomer, vsItem, vsMaterial)
                If iRC <> 0 Then
                    GetGanttData = 16
                    GoTo GetGanttDataExit
                End If

            Next

        End If

        iRC = GetUsePlanOutputForSched(iAltno, bUsePlanOutputForSched, rsInfobar)
        If iRC <> 0 Then
            GetGanttData = 16
            GoTo GetGanttDataExit
        End If

        iRC = GetGanttDataXML(Nothing, Nothing, rsGanttDataXML, lRowCount, uRows, iAltno,
                              bUsePlanOutputForSched, iPlan0Sched1, datStartDate, datEndDate, rsInfobar, vsCustomer, vsItem, vsMaterial, vsShift)
        If iRC <> ERR_OK Then
            GetGanttData = 16
            GoTo GetGanttDataExit
        End If

        GetGanttData = 0
        GoTo GetGanttDataExit

GetGanttDataError:

        GetGanttData = 16
        rsInfobar = "SLGantt.GetGanttData(): Internal error " & Err.Number & " - " & Err.Description

GetGanttDataExit:

        oData = Nothing

        If DEBUG_MODE Then
            If GetGanttData = 0 Then
                IDORuntime.LogUserMessage("SLGantt", UserDefinedMessageType.UserDefined1,
                                          "End GetGanttData, ret=0")
            Else
                IDORuntime.LogUserMessage("SLGantt", UserDefinedMessageType.UserDefined1,
                                          "End GetGanttData, ret={0}, msg={1}",
                                          GetGanttData, rsInfobar)
            End If
        End If

    End Function

    Private Function GetUsePlanOutputForSched(ByVal viAltno As Integer,
                                              ByRef rbUsePlanOutputForSched As Boolean,
                                              ByRef rsInfobar As String) As Integer

        Dim sProperties, sFilter As String
        Dim oData As LoadCollectionResponseData
        Dim iUsePlanOutput As Integer

        rbUsePlanOutputForSched = False

        GetUsePlanOutputForSched = 0

        On Error GoTo GetUsePlanOutputForSchedError

        If DEBUG_MODE Then
            IDORuntime.LogUserMessage("SLGantt", UserDefinedMessageType.UserDefined1,
                                      "Begin GetUsePlanOutputForSched")
        End If

        sProperties = "UsePlanOutputForSched"
        sFilter = "ALTNO = " & viAltno.ToString
        oData = Me.Context.Commands.LoadCollection("SL.SLAltscheds", sProperties, sFilter, "", 0)

        If oData.Items.Count > 0 Then

            iUsePlanOutput = oData.PropertyList.IndexOf("UsePlanOutputForSched")

            For Each item As IDOItem In oData.Items
                If item.PropertyValues(iUsePlanOutput).GetValue(Of Integer)() = 0 Then
                    rbUsePlanOutputForSched = False
                Else
                    rbUsePlanOutputForSched = True
                End If
                Exit For
            Next

            oData = Nothing

        End If

        GetUsePlanOutputForSched = 0
        GoTo GetUsePlanOutputForSchedExit

GetUsePlanOutputForSchedError:

        GetUsePlanOutputForSched = 16
        rsInfobar = "SLGantt.GetUsePlanOutputForSched(): Internal error " & Err.Number & " - " & Err.Description

GetUsePlanOutputForSchedExit:

        oData = Nothing

        If DEBUG_MODE Then
            If GetUsePlanOutputForSched = 0 Then
                IDORuntime.LogUserMessage("SLGantt", UserDefinedMessageType.UserDefined1,
                                          "End GetUsePlanOutputForSched, ret=0")
            Else
                IDORuntime.LogUserMessage("SLGantt", UserDefinedMessageType.UserDefined1,
                                          "End GetUsePlanOutputForSched, ret={0}, msg={1}",
                                          GetUsePlanOutputForSched, rsInfobar)
            End If
        End If

    End Function

    Private Function GetGroupMembers(ByVal viAltno As Integer,
                                     ByVal vsGroupID As String,
                                     ByRef ruRows() As RowInfo,
                                     ByRef rlRowCount As Integer,
                                     ByRef rsInfobar As String) As Integer


        Dim sProperties As String
        Dim oLoadRequest As New LoadCollectionRequestData
        Dim oData As LoadCollectionResponseData
        Dim iRC, lIndex, lSelectionCount As Integer
        Dim iRESID As Integer
        Dim sSelectionList() As String

        GetGroupMembers = 0
        rlRowCount = 0

        On Error GoTo GetGroupMembersError

        If DEBUG_MODE Then
            IDORuntime.LogUserMessage("SLGantt", UserDefinedMessageType.UserDefined1,
                                      "Begin GetGroupMembers")
        End If

        sProperties = "RESID"
        oLoadRequest.IDOName = "SL.SLRGRPMBRnnns"
        oLoadRequest.PropertyList = New PropertyList(sProperties)
        oLoadRequest.CustomLoadMethod = New CustomLoadMethod With {
            .Name = "CLM_ApsGetRGRPMBRSp"
        }
        oLoadRequest.CustomLoadMethod.Parameters.Add(vsGroupID)
        oLoadRequest.CustomLoadMethod.Parameters.Add(viAltno)
        oLoadRequest.RecordCap = 0
        oData = Me.Context.Commands.LoadCollection(oLoadRequest)

        lSelectionCount = oData.Items.Count

        If lSelectionCount > 0 Then

            ReDim sSelectionList(lSelectionCount)

            iRESID = oData.PropertyList.IndexOf("RESID")

            lIndex = 0
            For Each item As IDOItem In oData.Items
                sSelectionList(lIndex) = item.PropertyValues(iRESID).ToString()
                lIndex = lIndex + 1
            Next

            oData = Nothing

            rlRowCount = lSelectionCount
            ReDim ruRows(rlRowCount)

            For lIndex = 0 To rlRowCount - 1

                iRC = AddRow(viAltno, sSelectionList(lIndex), lIndex, ruRows, rsInfobar)
                If iRC <> 0 Then
                    GetGroupMembers = 16
                    GoTo GetGroupMembersExit
                End If

            Next

        End If

        GetGroupMembers = 0
        GoTo GetGroupMembersExit

GetGroupMembersError:

        GetGroupMembers = 16
        rsInfobar = "SLGantt.GetGroupMembers(): Internal error " & Err.Number & " - " & Err.Description

GetGroupMembersExit:

        oData = Nothing

        If DEBUG_MODE Then
            If GetGroupMembers = 0 Then
                IDORuntime.LogUserMessage("SLGantt", UserDefinedMessageType.UserDefined1,
                                          "End GetGroupMembers, ret=0")
            Else
                IDORuntime.LogUserMessage("SLGantt", UserDefinedMessageType.UserDefined1,
                                          "End GetGroupMembers, ret={0}, msg={1}",
                                          GetGroupMembers, rsInfobar)
            End If
        End If

    End Function

    Private Function GetSelectionMembers(ByVal viAltno As Integer,
                                         ByVal vsUserName As String,
                                         ByVal vsSelection As String,
                                         ByRef ruRows() As RowInfo,
                                         ByRef rlRowCount As Integer,
                                         ByRef rsInfobar As String,
                                         ByVal vsShift As String) As Integer

        Dim sProperties, sFilter, sOrderBy As String
        Dim oLoadRequest As New LoadCollectionRequestData
        Dim oData As LoadCollectionResponseData
        Dim iRC, lIndex, lSelectionCount As Integer
        Dim iRESID As Integer
        Dim sSelectionList() As String

        GetSelectionMembers = 0
        rlRowCount = 0

        On Error GoTo GetSelectionMembersError

        If DEBUG_MODE Then
            IDORuntime.LogUserMessage("SLGantt", UserDefinedMessageType.UserDefined1,
                                      "Begin GetSelectionMembers")
        End If

        Dim NULL_Shift As String = " "
        sProperties = "USERNAME, SELECTIONID, RESID, SEQNUM, SHIFTID1, SHIFTID2, SHIFTID3, SHIFTID4"

        If vsShift <> "" Then
            sFilter = "USERNAME = " & SqlLiteral.Format(vsUserName) &
                      " AND SELECTIONID = " & SqlLiteral.Format(vsSelection) &
                      " AND ((SHIFTID1 = " & SqlLiteral.Format(NULL_Shift) & " AND SHIFTID2 = " & SqlLiteral.Format(NULL_Shift) &
                        " AND SHIFTID3 = " & SqlLiteral.Format(NULL_Shift) & " AND SHIFTID4 = " & SqlLiteral.Format(NULL_Shift) &
                        " ) OR (SHIFTID1 = " & SqlLiteral.Format(vsShift) & " OR SHIFTID2 = " & SqlLiteral.Format(vsShift) &
                           " OR SHIFTID3 = " & SqlLiteral.Format(vsShift) & " OR SHIFTID4 = " & SqlLiteral.Format(vsShift) &
                           " )) "
        Else
            sFilter = "USERNAME = " & SqlLiteral.Format(vsUserName) &
                      " AND SELECTIONID = " & SqlLiteral.Format(vsSelection)
        End If

        sOrderBy = "SEQNUM"
        oData = Me.Context.Commands.LoadCollection("SL.SLGNTSELMBRs", sProperties, sFilter, sOrderBy, 0)

        lSelectionCount = oData.Items.Count

        If lSelectionCount > 0 Then

            ReDim sSelectionList(lSelectionCount)

            iRESID = oData.PropertyList.IndexOf("RESID")

            lIndex = 0
            For Each item As IDOItem In oData.Items
                sSelectionList(lIndex) = item.PropertyValues(iRESID).ToString()
                lIndex = lIndex + 1
            Next

            oData = Nothing

            rlRowCount = lSelectionCount
            ReDim ruRows(rlRowCount)

            For lIndex = 0 To rlRowCount - 1

                iRC = AddRow(viAltno, sSelectionList(lIndex), lIndex, ruRows, rsInfobar)
                If iRC <> 0 Then
                    GetSelectionMembers = 16
                    GoTo GetSelectionMembersExit
                End If

            Next

        End If

        GetSelectionMembers = 0
        GoTo GetSelectionMembersExit

GetSelectionMembersError:

        GetSelectionMembers = 16
        rsInfobar = "SLGantt.GetSelectionMembers(): Internal error " & Err.Number & " - " & Err.Description

GetSelectionMembersExit:

        oData = Nothing

        If DEBUG_MODE Then
            If GetSelectionMembers = 0 Then
                IDORuntime.LogUserMessage("SLGantt", UserDefinedMessageType.UserDefined1,
                                          "End GetSelectionMembers, ret=0")
            Else
                IDORuntime.LogUserMessage("SLGantt", UserDefinedMessageType.UserDefined1,
                                          "End GetSelectionMembers, ret={0}, msg={1}",
                                          GetSelectionMembers, rsInfobar)
            End If
        End If

    End Function

    Private Function GetAllResources(ByVal viAltno As Integer,
                                     ByRef ruRows() As RowInfo,
                                     ByRef rlRowCount As Integer,
                                     ByVal viPlan0Sched1 As Integer,
                                     ByVal vdatStartDate As Date,
                                     ByVal vdatEndDate As Date,
                                     ByRef rsInfobar As String,
                                     ByVal vsShift As String) As Integer

        Dim sProperties As String
        Dim oLoadRequest As New LoadCollectionRequestData
        Dim oData As LoadCollectionResponseData
        Dim lIndex As Integer
        Dim iRESID, iDESCR, iRESTYPE, iSHIFTID1, iSHIFTID2, iSHIFTID3, iSHIFTID4 As Integer


        Dim sShiftId1, sShiftId2, sShiftId3, sShiftId4 As String
        Dim FoundShiftMatch As Boolean = False

        GetAllResources = 0
        rlRowCount = 0

        On Error GoTo GetAllResourcesError

        If DEBUG_MODE Then
            IDORuntime.LogUserMessage("SLGantt", UserDefinedMessageType.UserDefined1,
                                      "Begin GetAllResources")
        End If

        sProperties = "RESID, DESCR, RESTYPE, SHIFTID1, SHIFTID2, SHIFTID3, SHIFTID4"
        oLoadRequest.PropertyList = New PropertyList(sProperties)
        oLoadRequest.IDOName = "SL.SLResourcePlans"
        oLoadRequest.CustomLoadMethod = New CustomLoadMethod With {
            .Name = "CLM_ApsGetGanttResourcesSp"
        }
        oLoadRequest.CustomLoadMethod.Parameters.Add(vdatStartDate)
        oLoadRequest.CustomLoadMethod.Parameters.Add(vdatEndDate)
        oLoadRequest.CustomLoadMethod.Parameters.Add(viPlan0Sched1)
        oLoadRequest.CustomLoadMethod.Parameters.Add(viAltno)
        oLoadRequest.RecordCap = 0
        oData = Me.Context.Commands.LoadCollection(oLoadRequest)

        iRESID = oData.PropertyList.IndexOf("RESID")
        iDESCR = oData.PropertyList.IndexOf("DESCR")
        iRESTYPE = oData.PropertyList.IndexOf("RESTYPE")
        iSHIFTID1 = oData.PropertyList.IndexOf("SHIFTID1")
        iSHIFTID2 = oData.PropertyList.IndexOf("SHIFTID2")
        iSHIFTID3 = oData.PropertyList.IndexOf("SHIFTID3")
        iSHIFTID4 = oData.PropertyList.IndexOf("SHIFTID4")

        rlRowCount = oData.Items.Count
        ReDim ruRows(rlRowCount)

        lIndex = 0
        For Each item As IDOItem In oData.Items


            If vsShift <> "" Then
                sShiftId1 = item.PropertyValues(iSHIFTID1).ToString()
                sShiftId2 = item.PropertyValues(iSHIFTID2).ToString()
                sShiftId3 = item.PropertyValues(iSHIFTID3).ToString()
                sShiftId4 = item.PropertyValues(iSHIFTID4).ToString()

                FoundShiftMatch = False
                ' If all 4 Shift ID's are blank, the resource is considered available 24x7 and so include in the result set.

                ' If atleast one ShiftID is selected on the Resources form match it with the Shift filter 
                If sShiftId1 <> "" Or sShiftId2 <> "" Or sShiftId3 <> "" Or sShiftId4 <> "" Then
                    If (sShiftId1 = vsShift Or sShiftId2 = vsShift Or sShiftId3 = vsShift Or sShiftId4 = vsShift) Then
                        FoundShiftMatch = True
                    End If
                End If

                If FoundShiftMatch = False Then Continue For
            End If


            ruRows(lIndex).sResource = RTrim(item.PropertyValues(iRESID).ToString())
            ruRows(lIndex).sDescr = RTrim(item.PropertyValues(iDESCR).ToString())
            ruRows(lIndex).sResType = RTrim(item.PropertyValues(iRESTYPE).ToString())
            ruRows(lIndex).sShift1 = RTrim(item.PropertyValues(iSHIFTID1).ToString())
            ruRows(lIndex).sShift2 = RTrim(item.PropertyValues(iSHIFTID2).ToString())
            ruRows(lIndex).sShift3 = RTrim(item.PropertyValues(iSHIFTID3).ToString())
            ruRows(lIndex).sShift4 = RTrim(item.PropertyValues(iSHIFTID4).ToString())
            ruRows(lIndex).lBlockCount = 0
            lIndex = lIndex + 1
        Next

        rlRowCount = lIndex

        GetAllResources = 0
        GoTo GetAllResourcesExit

GetAllResourcesError:

        GetAllResources = 16
        rsInfobar = "SLGantt.GetAllResources(): Internal error " & Err.Number & " - " & Err.Description

GetAllResourcesExit:

        oData = Nothing

        If DEBUG_MODE Then
            If GetAllResources = 0 Then
                IDORuntime.LogUserMessage("SLGantt", UserDefinedMessageType.UserDefined1,
                                          "End GetAllResources, ret=0")
            Else
                IDORuntime.LogUserMessage("SLGantt", UserDefinedMessageType.UserDefined1,
                                          "End GetAllResources, ret={0}, msg={1}",
                                          GetAllResources, rsInfobar)
            End If
        End If

    End Function

    Private Function AddRow(ByVal viAltno As Integer,
                            ByVal vsResourceID As String,
                            ByVal vlRowIndex As Integer,
                            ByRef ruRows() As RowInfo,
                            ByRef rsInfobar As String) As Integer

        Dim sProperties As String
        Dim oLoadRequest As New LoadCollectionRequestData
        Dim oData As LoadCollectionResponseData
        Dim iDESCR, iRESTYPE, iSHIFTID1, iSHIFTID2, iSHIFTID3, iSHIFTID4 As Integer

        AddRow = 0

        On Error GoTo AddRowError

        If DEBUG_MODE Then
            IDORuntime.LogUserMessage("SLGantt", UserDefinedMessageType.UserDefined1,
                                      "Begin AddRow")
        End If

        sProperties = "DESCR, RESTYPE, SHIFTID1, SHIFTID2, SHIFTID3, SHIFTID4"
        oLoadRequest.PropertyList = New PropertyList(sProperties)
        oLoadRequest.Filter = "RESID = " & SqlLiteral.Format(vsResourceID)
        oLoadRequest.OrderBy = ""
        oLoadRequest.IDOName = "TABLE!" + "RESRC" + viAltno.ToString("000")
        oLoadRequest.RecordCap = 1
        oData = Me.Context.Commands.LoadCollection(oLoadRequest)

        iDESCR = oData.PropertyList.IndexOf("DESCR")
        iRESTYPE = oData.PropertyList.IndexOf("RESTYPE")
        iSHIFTID1 = oData.PropertyList.IndexOf("SHIFTID1")
        iSHIFTID2 = oData.PropertyList.IndexOf("SHIFTID2")
        iSHIFTID3 = oData.PropertyList.IndexOf("SHIFTID3")
        iSHIFTID4 = oData.PropertyList.IndexOf("SHIFTID4")

        ' Add row
        ruRows(vlRowIndex).sResource = vsResourceID
        ruRows(vlRowIndex).sDescr = ""
        ruRows(vlRowIndex).sResType = ""
        ruRows(vlRowIndex).sShift1 = ""
        ruRows(vlRowIndex).sShift2 = ""
        ruRows(vlRowIndex).sShift3 = ""
        ruRows(vlRowIndex).sShift4 = ""
        ruRows(vlRowIndex).lBlockCount = 0

        For Each item As IDOItem In oData.Items
            ruRows(vlRowIndex).sDescr = RTrim(item.PropertyValues(iDESCR).ToString())
            ruRows(vlRowIndex).sResType = RTrim(item.PropertyValues(iRESTYPE).ToString())
            ruRows(vlRowIndex).sShift1 = RTrim(item.PropertyValues(iSHIFTID1).ToString())
            ruRows(vlRowIndex).sShift2 = RTrim(item.PropertyValues(iSHIFTID2).ToString())
            ruRows(vlRowIndex).sShift3 = RTrim(item.PropertyValues(iSHIFTID3).ToString())
            ruRows(vlRowIndex).sShift4 = RTrim(item.PropertyValues(iSHIFTID4).ToString())
            Exit For
        Next

        AddRow = 0
        GoTo AddRowExit

AddRowError:

        AddRow = 16
        rsInfobar = "SLGantt.AddRow(): Internal error " & Err.Number & " - " & Err.Description

AddRowExit:

        oData = Nothing

        If DEBUG_MODE Then
            If AddRow = 0 Then
                IDORuntime.LogUserMessage("SLGantt", UserDefinedMessageType.UserDefined1,
                                          "End AddRow, ret=0")
            Else
                IDORuntime.LogUserMessage("SLGantt", UserDefinedMessageType.UserDefined1,
                                          "End AddRow, ret={0}, msg={1}",
                                          AddRow, rsInfobar)
            End If
        End If

    End Function

    Private Function AddDownBlocks(ByVal viAltno As Integer,
                                   ByVal vsResourceID As String,
                                   ByVal viPlan0Sched1 As Integer,
                                   ByVal vdatStartDate As Date,
                                   ByVal vdatEndDate As Date,
                                   ByRef rlBlockCount As Integer,
                                   ByRef ruBlocks() As BlockInfo,
                                   ByRef rsInfobar As String) As Integer

        Dim sProperties As String
        Dim oLoadRequest As New LoadCollectionRequestData
        Dim oData As LoadCollectionResponseData
        Dim lIndex, lDownBlocks As Integer
        Dim iDOWNCD, iSTARTDATE, iENDDATE As Integer

        AddDownBlocks = 0

        On Error GoTo AddDownBlocksError

        If DEBUG_MODE Then
            IDORuntime.LogUserMessage("SLGantt", UserDefinedMessageType.UserDefined1,
                                      "Begin AddDownBlocks")
        End If

        sProperties = "DOWNCD, STARTDATE, ENDDATE"
        oLoadRequest.PropertyList = New PropertyList(sProperties)
        oLoadRequest.Filter = "DOWNCD <> 'W' AND RESID = " & SqlLiteral.Format(vsResourceID)
        'If gdatSelStart <> DATE_PAST Then
        oLoadRequest.Filter = oLoadRequest.Filter &
                              " AND STARTDATE < " & SqlLiteral.Format(vdatEndDate) &
                              " AND ENDDATE > " & SqlLiteral.Format(vdatStartDate)
        'End If
        oLoadRequest.OrderBy = ""
        If viPlan0Sched1 = 0 Then
            oLoadRequest.IDOName = "TABLE!" + "DOWNPLAN" + viAltno.ToString("000")
        Else
            oLoadRequest.IDOName = "TABLE!" + "DOWN" + viAltno.ToString("000")
        End If
        oLoadRequest.RecordCap = BAR_MAX
        oData = Me.Context.Commands.LoadCollection(oLoadRequest)

        lDownBlocks = oData.Items.Count

        If lDownBlocks > 0 Then

            iDOWNCD = oData.PropertyList.IndexOf("DOWNCD")
            iSTARTDATE = oData.PropertyList.IndexOf("STARTDATE")
            iENDDATE = oData.PropertyList.IndexOf("ENDDATE")

            lIndex = rlBlockCount

            rlBlockCount = rlBlockCount + lDownBlocks
            ReDim Preserve ruBlocks(rlBlockCount)

            For Each item As IDOItem In oData.Items

                If item.PropertyValues(iDOWNCD).ToString() <> "D" Then
                    ruBlocks(lIndex).iBarType = BAR_DOWN
                Else
                    ruBlocks(lIndex).iBarType = BAR_FAIL_PLAN
                End If
                ruBlocks(lIndex).iStartCd = STATUS_FAIL
                ruBlocks(lIndex).iEndCd = STATUS_REPAIR
                ruBlocks(lIndex).datStart = item.PropertyValues(iSTARTDATE).GetValue(Of Date)()
                ruBlocks(lIndex).datEnd = item.PropertyValues(iENDDATE).GetValue(Of Date)()

                lIndex = lIndex + 1

            Next

        End If

        AddDownBlocks = 0
        GoTo AddDownBlocksExit

AddDownBlocksError:

        AddDownBlocks = 16
        rsInfobar = "SLGantt.AddDownBlocks(): Internal error " & Err.Number & " - " & Err.Description

AddDownBlocksExit:

        oData = Nothing

        If DEBUG_MODE Then
            If AddDownBlocks = 0 Then
                IDORuntime.LogUserMessage("SLGantt", UserDefinedMessageType.UserDefined1,
                                          "End AddDownBlocks, ret=0")
            Else
                IDORuntime.LogUserMessage("SLGantt", UserDefinedMessageType.UserDefined1,
                                          "End AddDownBlocks, ret={0}, msg={1}",
                                          AddDownBlocks, rsInfobar)
            End If
        End If

    End Function

    Private Function AddBlocks(ByVal viAltno As Integer,
                               ByVal vsResourceID As String,
                               ByVal viPlan0Sched1 As Integer,
                               ByVal vdatStartDate As Date,
                               ByVal vdatEndDate As Date,
                               ByRef rlBlockCount As Integer,
                               ByRef ruBlocks() As BlockInfo,
                               ByRef rsInfobar As String,
                               ByVal vsCustomer As String,
                               ByVal vsItem As String,
                               ByVal vsMaterial As String) As Integer

        Dim sProperties As String
        Dim oLoadRequest As New LoadCollectionRequestData
        Dim oData As LoadCollectionResponseData
        Dim lIndex, lBlocks As Integer
        Dim iGROUPID, iSTARTDATE, iSTARTCD, iENDDATE, iENDCD, iJSID As Integer
        Dim iJobstepTYPE, iJOBTAG, iPROCPLANID, iDerDemandId, iDerDemandType, iDerOperNum As Integer
        Dim iLOADID, iLOADSIZE, iORDERTAG, iOrdperfSTARTDATE, iOrdperfCOMPDATE As Integer
        Dim iSEQNUM, iCOMPDATE, iDUEDATE, iMATERIALID, iOrderDESCR As Integer
        Dim iDerRemainingRun, iDerRemainingSetup, iDerQtyReleased, iJobSchStartDate As Integer
        Dim iJobSchEndDate, iJobSchCompdate, iJobItem, iJobDescription, iDaysLate As Integer
        Dim iDerTypeCode, iDerStatus, iDerIsFrozen, iSTATUSCD, iORDERID, iRowPointer As Integer
        Dim iDerUnderProd, iDerOverScrap As Integer

        AddBlocks = 0

        On Error GoTo AddBlocksError

        If DEBUG_MODE Then
            IDORuntime.LogUserMessage("SLGantt", UserDefinedMessageType.UserDefined1,
                                      "Begin AddBlocks")
        End If

        sProperties = "GROUPID, STARTDATE, STARTCD, ENDDATE, ENDCD, JSID, " &
                      "JobstepTYPE, JOBTAG, PROCPLANID, DerDemandId, DerDemandType, DerOperNum, " &
                      "LOADID, LOADSIZE, ORDERTAG, OrdperfSTARTDATE, OrdperfCOMPDATE, " &
                      "SEQNUM, COMPDATE, DUEDATE, MATERIALID, OrderDESCR, " &
                      "DerRemainingRun, DerRemainingSetup, DerQtyReleased, JobSchStartDate, " &
                      "JobSchEndDate, JobSchCompdate, JobItem, JobDescription, DaysLate, " &
                      "DerTypeCode, DerStatus, DerIsFrozen, STATUSCD, ORDERID, RowPointer, DerUnderProd, DerOverScrap"
        oLoadRequest.PropertyList = New PropertyList(sProperties)
        If viPlan0Sched1 = 0 Then
            oLoadRequest.IDOName = "SL.SLResourcePlans"
        Else
            oLoadRequest.IDOName = "SL.ResourceSchedules"
        End If
        oLoadRequest.CustomLoadMethod = New CustomLoadMethod()
        If viPlan0Sched1 = 0 Then
            oLoadRequest.CustomLoadMethod.Name = "CLM_ResGanttPlanSp"
        Else
            oLoadRequest.CustomLoadMethod.Name = "CLM_ResGanttScheduleSp"
        End If
        oLoadRequest.CustomLoadMethod.Parameters.Add(vdatStartDate)
        oLoadRequest.CustomLoadMethod.Parameters.Add(vdatEndDate)
        oLoadRequest.CustomLoadMethod.Parameters.Add(viAltno)
        oLoadRequest.CustomLoadMethod.Parameters.Add("RESID = " & SqlLiteral.Format(vsResourceID))

        oLoadRequest.CustomLoadMethod.Parameters.Add(vsCustomer)
        oLoadRequest.CustomLoadMethod.Parameters.Add(vsItem)
        oLoadRequest.CustomLoadMethod.Parameters.Add(vsMaterial)

        oLoadRequest.RecordCap = BAR_MAX
        oData = Me.Context.Commands.LoadCollection(oLoadRequest)

        lBlocks = oData.Items.Count

        If lBlocks > 0 Then

            iGROUPID = oData.PropertyList.IndexOf("GROUPID")
            iSTARTDATE = oData.PropertyList.IndexOf("STARTDATE")
            iSTARTCD = oData.PropertyList.IndexOf("STARTCD")
            iENDDATE = oData.PropertyList.IndexOf("ENDDATE")
            iENDCD = oData.PropertyList.IndexOf("ENDCD")
            iJSID = oData.PropertyList.IndexOf("JSID")
            iJobstepTYPE = oData.PropertyList.IndexOf("JobstepTYPE")
            iJOBTAG = oData.PropertyList.IndexOf("JOBTAG")
            iPROCPLANID = oData.PropertyList.IndexOf("PROCPLANID")
            iDerDemandId = oData.PropertyList.IndexOf("DerDemandId")
            iDerDemandType = oData.PropertyList.IndexOf("DerDemandType")
            iDerOperNum = oData.PropertyList.IndexOf("DerOperNum")
            iLOADID = oData.PropertyList.IndexOf("LOADID")
            iLOADSIZE = oData.PropertyList.IndexOf("LOADSIZE")
            iORDERTAG = oData.PropertyList.IndexOf("ORDERTAG")
            iOrdperfSTARTDATE = oData.PropertyList.IndexOf("OrdperfSTARTDATE")
            iOrdperfCOMPDATE = oData.PropertyList.IndexOf("OrdperfCOMPDATE")
            iSEQNUM = oData.PropertyList.IndexOf("SEQNUM")
            iCOMPDATE = oData.PropertyList.IndexOf("COMPDATE")
            iDUEDATE = oData.PropertyList.IndexOf("DUEDATE")
            iMATERIALID = oData.PropertyList.IndexOf("MATERIALID")
            iOrderDESCR = oData.PropertyList.IndexOf("OrderDESCR")
            iDerRemainingRun = oData.PropertyList.IndexOf("DerRemainingRun")
            iDerRemainingSetup = oData.PropertyList.IndexOf("DerRemainingSetup")
            iDerQtyReleased = oData.PropertyList.IndexOf("DerQtyReleased")
            iJobSchStartDate = oData.PropertyList.IndexOf("JobSchStartDate")
            iJobSchEndDate = oData.PropertyList.IndexOf("JobSchEndDate")
            iJobSchCompdate = oData.PropertyList.IndexOf("JobSchCompdate")
            iJobItem = oData.PropertyList.IndexOf("JobItem")
            iJobDescription = oData.PropertyList.IndexOf("JobDescription")
            iDaysLate = oData.PropertyList.IndexOf("DaysLate")
            iDerTypeCode = oData.PropertyList.IndexOf("DerTypeCode")
            iDerStatus = oData.PropertyList.IndexOf("DerStatus")
            iDerIsFrozen = oData.PropertyList.IndexOf("DerIsFrozen")
            iSTATUSCD = oData.PropertyList.IndexOf("STATUSCD")
            iORDERID = oData.PropertyList.IndexOf("ORDERID")
            iRowPointer = oData.PropertyList.IndexOf("RowPointer")
            iDerUnderProd = oData.PropertyList.IndexOf("DerUnderProd")
            iDerOverScrap = oData.PropertyList.IndexOf("DerOverScrap")

            lIndex = rlBlockCount

            rlBlockCount = rlBlockCount + lBlocks
            ReDim Preserve ruBlocks(rlBlockCount)

            For Each item As IDOItem In oData.Items

                ruBlocks(lIndex).sStatusCd = item.PropertyValues(iSTATUSCD).ToString()
                ruBlocks(lIndex).iStartCd = Startcd2Num(RTrim(item.PropertyValues(iSTARTCD).ToString()))
                ruBlocks(lIndex).iEndCd = Endcd2Num(RTrim(item.PropertyValues(iENDCD).ToString()))
                If item.PropertyValues(iDerIsFrozen).GetValue(Of Integer)() = 1 Then
                    ruBlocks(lIndex).bFrozen = True
                    ruBlocks(lIndex).iBarType = BAR_OPER_FROZEN
                Else
                    ruBlocks(lIndex).bFrozen = False
                    ruBlocks(lIndex).iBarType = BAR_OPER_PLAN
                End If
                ruBlocks(lIndex).sOrderID = RTrim(item.PropertyValues(iORDERID).ToString())

                ruBlocks(lIndex).sString1 = RTrim(item.PropertyValues(iDerDemandId).ToString())
                ruBlocks(lIndex).sString2 = RTrim(item.PropertyValues(iDerOperNum).ToString())
                If ruBlocks(lIndex).sString2 = "" Then
                    ruBlocks(lIndex).sString2 = RTrim(item.PropertyValues(iJSID).ToString())
                End If
                ruBlocks(lIndex).sString3 = RTrim(item.PropertyValues(iMATERIALID).ToString())
                ruBlocks(lIndex).sString4 = RTrim(item.PropertyValues(iDerTypeCode).ToString())
                ruBlocks(lIndex).sString5 = RTrim(item.PropertyValues(iPROCPLANID).ToString())
                ruBlocks(lIndex).sString6 = RTrim(item.PropertyValues(iJobDescription).ToString())
                If (ruBlocks(lIndex).sString6 = "") And (viPlan0Sched1 = 1) Then
                    ruBlocks(lIndex).sString6 = RTrim(item.PropertyValues(iOrderDESCR).ToString())
                End If
                ruBlocks(lIndex).sString7 = RTrim(item.PropertyValues(iGROUPID).ToString())
                ruBlocks(lIndex).sString8 = RTrim(item.PropertyValues(iDerDemandType).ToString())
                ruBlocks(lIndex).sString9 = RTrim(item.PropertyValues(iDerStatus).ToString())

                ruBlocks(lIndex).dDbl1 = item.PropertyValues(iDaysLate).GetValue(Of Double)()
                ruBlocks(lIndex).dDbl2 = item.PropertyValues(iDerRemainingRun).GetValue(Of Double)()
                ruBlocks(lIndex).dDbl3 = item.PropertyValues(iDerRemainingSetup).GetValue(Of Double)()
                ruBlocks(lIndex).dDbl4 = item.PropertyValues(iLOADSIZE).GetValue(Of Double)()

                If RTrim(item.PropertyValues(iDerOperNum).ToString()) = "" Then
                    ruBlocks(lIndex).datDate1 = item.PropertyValues(iOrdperfSTARTDATE).GetValue(Of Date)()
                    ruBlocks(lIndex).datDate2 = item.PropertyValues(iOrdperfCOMPDATE).GetValue(Of Date)()
                    ruBlocks(lIndex).datDate3 = item.PropertyValues(iOrdperfCOMPDATE).GetValue(Of Date)()
                Else
                    If item.PropertyValues(iJobSchStartDate).IsNull Then
                        ruBlocks(lIndex).datDate1 = NULL_DATE
                    Else
                        ruBlocks(lIndex).datDate1 = item.PropertyValues(iJobSchStartDate).GetValue(Of Date)()
                    End If
                    If item.PropertyValues(iJobSchEndDate).IsNull Then
                        ruBlocks(lIndex).datDate2 = NULL_DATE
                    Else
                        ruBlocks(lIndex).datDate2 = item.PropertyValues(iJobSchEndDate).GetValue(Of Date)()
                    End If
                    If item.PropertyValues(iJobSchCompdate).IsNull Then
                        ruBlocks(lIndex).datDate3 = NULL_DATE
                    Else
                        ruBlocks(lIndex).datDate3 = item.PropertyValues(iJobSchCompdate).GetValue(Of Date)()
                    End If
                End If

                ruBlocks(lIndex).iInt1 = item.PropertyValues(iLOADID).GetValue(Of Integer)()
                ruBlocks(lIndex).iInt2 = item.PropertyValues(iJOBTAG).GetValue(Of Integer)()
                If viPlan0Sched1 = 1 Then
                    ruBlocks(lIndex).iInt3 = item.PropertyValues(iSEQNUM).GetValue(Of Integer)()
                End If

                ruBlocks(lIndex).datStart = item.PropertyValues(iSTARTDATE).GetValue(Of Date)()
                ruBlocks(lIndex).datEnd = item.PropertyValues(iENDDATE).GetValue(Of Date)()
                ruBlocks(lIndex).RowPointer = item.PropertyValues(iRowPointer).GetValue(Of Guid)()

                If item.PropertyValues(iDerUnderProd).GetValue(Of Integer)() = 1 Then
                    ruBlocks(lIndex).bUnderProd = True
                Else
                    ruBlocks(lIndex).bUnderProd = False
                End If

                If item.PropertyValues(iDerOverScrap).GetValue(Of Integer)() = 1 Then
                    ruBlocks(lIndex).bOverScrap = True
                Else
                    ruBlocks(lIndex).bOverScrap = False
                End If

                ruBlocks(lIndex).sJobSufOper = RTrim(item.PropertyValues(iJSID).ToString())

                lIndex = lIndex + 1

            Next

        End If

        AddBlocks = 0
        GoTo AddBlocksExit

AddBlocksError:

        AddBlocks = 16
        rsInfobar = "SLGantt.AddBlocks(): Internal error " & Err.Number & " - " & Err.Description

AddBlocksExit:

        oData = Nothing

        If DEBUG_MODE Then
            If AddBlocks = 0 Then
                IDORuntime.LogUserMessage("SLGantt", UserDefinedMessageType.UserDefined1,
                                          "End AddBlocks, ret=0")
            Else
                IDORuntime.LogUserMessage("SLGantt", UserDefinedMessageType.UserDefined1,
                                          "End AddBlocks, ret={0}, msg={1}",
                                          AddBlocks, rsInfobar)
            End If
        End If

    End Function

    Private Function GetGanttDataXML(ByRef oRefNode As XmlNode,
                                     ByRef oRefDoc As XmlDocument,
                                     ByRef rsGanttDataXML As String,
                                     ByVal vlRowCount As Integer,
                                     ByRef ruRows() As RowInfo,
                                     ByVal viAltno As Integer,
                                     ByVal vbUsePlanOutputForSched As Boolean,
                                     ByVal viPlan0Sched1 As Integer,
                                     ByVal vdatStartDate As Date,
                                     ByVal vdatEndDate As Date,
                                     ByRef rsInfobar As String,
                                     ByVal vsCustomer As String,
                                     ByVal vsItem As String,
                                     ByVal vsMaterial As String,
                                     ByVal vsShift As String) As Integer

        Dim oDetailDOM As New XmlDocument
        Dim oNode, oParentNode As XmlNode
        Dim oListOfRows, oRowNode As XmlNode
        Dim oListOfBlocks, oBlockNode As XmlNode
        Dim lIndex, lBlockIndex As Integer

        On Error GoTo GetGanttDataXMLError

        ' Create root tag
        If oRefDoc Is Nothing Or oRefNode Is Nothing Then
            oParentNode = oDetailDOM.CreateElement("GanttData")
            oDetailDOM.AppendChild(oParentNode)
        Else
            oDetailDOM = oRefDoc
            oParentNode = oRefNode
        End If

        ' Add base elements
        oNode = oDetailDOM.CreateElement("Debug")
        oNode.InnerText = ""
        oParentNode.AppendChild(oNode)

        oNode = oDetailDOM.CreateElement("Version")
        oNode.InnerText = "9.00.00"
        oParentNode.AppendChild(oNode)

        oNode = oDetailDOM.CreateElement("StartDate")
        oNode.InnerText = MGType.ToInternal(vdatStartDate)
        oParentNode.AppendChild(oNode)

        oNode = oDetailDOM.CreateElement("EndDate")
        oNode.InnerText = MGType.ToInternal(vdatEndDate)
        oParentNode.AppendChild(oNode)

        oNode = oDetailDOM.CreateElement("UserType")
        oNode.InnerText = MGType.ToInternal(viPlan0Sched1)
        oParentNode.AppendChild(oNode)

        oNode = oDetailDOM.CreateElement("AltNo")
        oNode.InnerText = MGType.ToInternal(viAltno)
        oParentNode.AppendChild(oNode)

        oNode = oDetailDOM.CreateElement("UsePlanOutputForSched")
        oNode.InnerText = MGType.ToInternal(vbUsePlanOutputForSched)
        oParentNode.AppendChild(oNode)

        oNode = oDetailDOM.CreateElement("FilterCustomer")
        oNode.InnerText = MGType.ToInternal(vsCustomer)
        oParentNode.AppendChild(oNode)

        oNode = oDetailDOM.CreateElement("FilterItem")
        oNode.InnerText = MGType.ToInternal(vsItem)
        oParentNode.AppendChild(oNode)

        oNode = oDetailDOM.CreateElement("FilterMaterial")
        oNode.InnerText = MGType.ToInternal(vsMaterial)
        oParentNode.AppendChild(oNode)

        oNode = oDetailDOM.CreateElement("FilterShift")
        oNode.InnerText = MGType.ToInternal(vsShift)
        oParentNode.AppendChild(oNode)

        ' Add list of resources
        oNode = oDetailDOM.CreateElement("Resources")
        oListOfRows = oParentNode.AppendChild(oNode)

        oNode = oDetailDOM.CreateElement("Count")
        oNode.InnerText = MGType.ToInternal(vlRowCount)
        oListOfRows.AppendChild(oNode)

        For lIndex = 0 To vlRowCount - 1

            oNode = oDetailDOM.CreateElement("Resource")
            oRowNode = oListOfRows.AppendChild(oNode)

            oNode = oDetailDOM.CreateElement("ResID")
            oNode.InnerText = ruRows(lIndex).sResource
            oRowNode.AppendChild(oNode)

            oNode = oDetailDOM.CreateElement("Descr")
            oNode.InnerText = ruRows(lIndex).sDescr
            oRowNode.AppendChild(oNode)

            oNode = oDetailDOM.CreateElement("ResType")
            oNode.InnerText = ruRows(lIndex).sResType
            oRowNode.AppendChild(oNode)

            oNode = oDetailDOM.CreateElement("Shift1")
            oNode.InnerText = ruRows(lIndex).sShift1
            oRowNode.AppendChild(oNode)

            oNode = oDetailDOM.CreateElement("Shift2")
            oNode.InnerText = ruRows(lIndex).sShift2
            oRowNode.AppendChild(oNode)

            oNode = oDetailDOM.CreateElement("Shift3")
            oNode.InnerText = ruRows(lIndex).sShift3
            oRowNode.AppendChild(oNode)

            oNode = oDetailDOM.CreateElement("Shift4")
            oNode.InnerText = ruRows(lIndex).sShift4
            oRowNode.AppendChild(oNode)

            ' Add list of blocks
            oNode = oDetailDOM.CreateElement("Blocks")
            oListOfBlocks = oRowNode.AppendChild(oNode)

            oNode = oDetailDOM.CreateElement("Count")
            oNode.InnerText = MGType.ToInternal(ruRows(lIndex).lBlockCount)
            oListOfBlocks.AppendChild(oNode)

            For lBlockIndex = 0 To ruRows(lIndex).lBlockCount - 1

                oBlockNode = oDetailDOM.CreateElement("Block")
                oListOfBlocks.AppendChild(oBlockNode)

                oNode = oDetailDOM.CreateElement("BarType")
                oNode.InnerText = MGType.ToInternal(ruRows(lIndex).uBlocks(lBlockIndex).iBarType)
                oBlockNode.AppendChild(oNode)

                oNode = oDetailDOM.CreateElement("StartCd")
                oNode.InnerText = MGType.ToInternal(ruRows(lIndex).uBlocks(lBlockIndex).iStartCd)
                oBlockNode.AppendChild(oNode)

                oNode = oDetailDOM.CreateElement("EndCd")
                oNode.InnerText = MGType.ToInternal(ruRows(lIndex).uBlocks(lBlockIndex).iEndCd)
                oBlockNode.AppendChild(oNode)

                oNode = oDetailDOM.CreateElement("Frozen")
                oNode.InnerText = MGType.ToInternal(ruRows(lIndex).uBlocks(lBlockIndex).bFrozen)
                oBlockNode.AppendChild(oNode)

                oNode = oDetailDOM.CreateElement("Start")
                oNode.InnerText = MGType.ToInternal(ruRows(lIndex).uBlocks(lBlockIndex).datStart)
                oBlockNode.AppendChild(oNode)

                oNode = oDetailDOM.CreateElement("End")
                oNode.InnerText = MGType.ToInternal(ruRows(lIndex).uBlocks(lBlockIndex).datEnd)
                oBlockNode.AppendChild(oNode)

                oNode = oDetailDOM.CreateElement("StatusCd")
                oNode.InnerText = ruRows(lIndex).uBlocks(lBlockIndex).sStatusCd
                oBlockNode.AppendChild(oNode)

                oNode = oDetailDOM.CreateElement("Date1")
                oNode.InnerText = MGType.ToInternal(ruRows(lIndex).uBlocks(lBlockIndex).datDate1)
                oBlockNode.AppendChild(oNode)

                oNode = oDetailDOM.CreateElement("Date2")
                oNode.InnerText = MGType.ToInternal(ruRows(lIndex).uBlocks(lBlockIndex).datDate2)
                oBlockNode.AppendChild(oNode)

                oNode = oDetailDOM.CreateElement("Date3")
                oNode.InnerText = MGType.ToInternal(ruRows(lIndex).uBlocks(lBlockIndex).datDate3)
                oBlockNode.AppendChild(oNode)

                oNode = oDetailDOM.CreateElement("OrderID")
                oNode.InnerText = ruRows(lIndex).uBlocks(lBlockIndex).sOrderID
                oBlockNode.AppendChild(oNode)

                oNode = oDetailDOM.CreateElement("Int1")
                oNode.InnerText = MGType.ToInternal(ruRows(lIndex).uBlocks(lBlockIndex).iInt1)
                oBlockNode.AppendChild(oNode)

                oNode = oDetailDOM.CreateElement("Int2")
                oNode.InnerText = MGType.ToInternal(ruRows(lIndex).uBlocks(lBlockIndex).iInt2)
                oBlockNode.AppendChild(oNode)

                oNode = oDetailDOM.CreateElement("Int3")
                oNode.InnerText = MGType.ToInternal(ruRows(lIndex).uBlocks(lBlockIndex).iInt3)
                oBlockNode.AppendChild(oNode)

                oNode = oDetailDOM.CreateElement("String1")
                oNode.InnerText = ruRows(lIndex).uBlocks(lBlockIndex).sString1
                oBlockNode.AppendChild(oNode)

                oNode = oDetailDOM.CreateElement("String2")
                oNode.InnerText = ruRows(lIndex).uBlocks(lBlockIndex).sString2
                oBlockNode.AppendChild(oNode)

                oNode = oDetailDOM.CreateElement("String3")
                oNode.InnerText = ruRows(lIndex).uBlocks(lBlockIndex).sString3
                oBlockNode.AppendChild(oNode)

                oNode = oDetailDOM.CreateElement("String4")
                oNode.InnerText = ruRows(lIndex).uBlocks(lBlockIndex).sString4
                oBlockNode.AppendChild(oNode)

                oNode = oDetailDOM.CreateElement("String5")
                oNode.InnerText = ruRows(lIndex).uBlocks(lBlockIndex).sString5
                oBlockNode.AppendChild(oNode)

                oNode = oDetailDOM.CreateElement("String6")
                oNode.InnerText = ruRows(lIndex).uBlocks(lBlockIndex).sString6
                oBlockNode.AppendChild(oNode)

                oNode = oDetailDOM.CreateElement("String7")
                oNode.InnerText = ruRows(lIndex).uBlocks(lBlockIndex).sString7
                oBlockNode.AppendChild(oNode)

                oNode = oDetailDOM.CreateElement("String8")
                oNode.InnerText = ruRows(lIndex).uBlocks(lBlockIndex).sString8
                oBlockNode.AppendChild(oNode)

                oNode = oDetailDOM.CreateElement("String9")
                oNode.InnerText = ruRows(lIndex).uBlocks(lBlockIndex).sString9
                oBlockNode.AppendChild(oNode)

                oNode = oDetailDOM.CreateElement("Dbl1")
                oNode.InnerText = MGType.ToInternal(ruRows(lIndex).uBlocks(lBlockIndex).dDbl1)
                oBlockNode.AppendChild(oNode)

                oNode = oDetailDOM.CreateElement("Dbl2")
                oNode.InnerText = MGType.ToInternal(ruRows(lIndex).uBlocks(lBlockIndex).dDbl2)
                oBlockNode.AppendChild(oNode)

                oNode = oDetailDOM.CreateElement("Dbl3")
                oNode.InnerText = MGType.ToInternal(ruRows(lIndex).uBlocks(lBlockIndex).dDbl3)
                oBlockNode.AppendChild(oNode)

                oNode = oDetailDOM.CreateElement("Dbl4")
                oNode.InnerText = MGType.ToInternal(ruRows(lIndex).uBlocks(lBlockIndex).dDbl4)
                oBlockNode.AppendChild(oNode)

                oNode = oDetailDOM.CreateElement("RowPointer")
                oNode.InnerText = MGType.ToInternal(ruRows(lIndex).uBlocks(lBlockIndex).RowPointer)
                oBlockNode.AppendChild(oNode)

                oNode = oDetailDOM.CreateElement("UnderProd")
                oNode.InnerText = MGType.ToInternal(ruRows(lIndex).uBlocks(lBlockIndex).bUnderProd)
                oBlockNode.AppendChild(oNode)

                oNode = oDetailDOM.CreateElement("OverScrap")
                oNode.InnerText = MGType.ToInternal(ruRows(lIndex).uBlocks(lBlockIndex).bOverScrap)
                oBlockNode.AppendChild(oNode)

                oNode = oDetailDOM.CreateElement("JobSufOper")
                oNode.InnerText = ruRows(lIndex).uBlocks(lBlockIndex).sJobSufOper
                oBlockNode.AppendChild(oNode)

            Next lBlockIndex

        Next lIndex

        ' Return response XML
        If oRefDoc Is Nothing Or oRefNode Is Nothing Then
            rsGanttDataXML = oDetailDOM.OuterXml
        End If

        GetGanttDataXML = ERR_OK
        Exit Function

GetGanttDataXMLError:
        GetGanttDataXML = ERR_VBRT
        rsInfobar = "SLGantt.GetGanttDataXML(): Internal error " & Err.Number & " - " & Err.Description

    End Function

    ' --------------------------------------------------------
    ' xxx
    ' --------------------------------------------------------

    Private Function CTPErrorMsg(ByVal vlErrorNumber As Integer,
                                 Optional ByVal vParm1 As String = "",
                                 Optional ByVal vParm2 As String = "") As String

        Dim vBaseMsg As String = ""
        Dim messageProvider As IMessageProvider = Nothing

        CTPErrorMsg = ""

        On Error GoTo CTPErrorMsgErrorHandler

        Select Case vlErrorNumber
            Case ERR_BADREQUESTXML
                CTPErrorMsg = "Invalid request XML."
                Exit Function

            Case ERR_BADRESPONSEXML
                CTPErrorMsg = "Invalid response XML."
                Exit Function

            Case ERR_NODATA
                vBaseMsg = "E=NoPlanningData"

            Case ERDB.Server.ERR_PUSHMAX
                vBaseMsg = "E=CtpPushMax"

            Case Aps.ServerService.APS_ERR_NETWORK
                vBaseMsg = "E=CtpNetwork"

            Case Aps.ServerService.APS_ERR_NETWORKSETUP
                vBaseMsg = "E=CtpNetworkSetup"

            Case Aps.ServerService.APS_ERR_HOSTADDR
                vBaseMsg = "E=CtpHostAddr"

            Case Aps.ServerService.APS_ERR_VERSION
                vBaseMsg = "E=CtpVersion"

            Case Aps.ServerService.APS_ERR_REGISTRY
                vBaseMsg = "E=CtpRegistry"

            Case Aps.ServerService.APS_ERR_SQLCONNECT
                vBaseMsg = "E=CtpSQLConnect"

            Case Aps.ServerService.APS_ERR_SQLQUERY
                vBaseMsg = "E=CtpSQLQuery"

            Case Aps.ServerService.APS_ERR_ALTNO
                vBaseMsg = "E=CtpAltno"

            Case Aps.ServerService.APS_ERR_EXEC
                vBaseMsg = "E=CtpExec"

            Case Aps.ServerService.APS_ERR_WAIT
                vBaseMsg = "E=CtpWait"

            Case Aps.ServerService.APS_ERR_PDBINFO
                vBaseMsg = "E=CtpErdbInfo"

            Case Aps.ServerService.APS_ERR_PDBCONNECT
                vBaseMsg = "E=CtpErdbConnect"

            Case Aps.ServerService.APS_ERR_PLANNERAPI
                vBaseMsg = "E=CtpErdbApi"

            Case Aps.ServerService.APS_ERR_RELOAD
                vBaseMsg = "E=CtpReload"

            Case Aps.ServerService.APS_ERR_PDBDOWN
                vBaseMsg = "E=CtpErdbDown"

            Case Aps.ServerService.APS_ERR_GETEXIT
                vBaseMsg = "E=CtpGetExit"

            Case Aps.ServerService.APS_ERR_RELOADERRS
                vBaseMsg = "E=CtpReloadErrs"

            Case Aps.ServerService.APS_ERR_PLANBUSY,
                ERDB.Server.ERR_APSSTATUS_INCRPLAN,
                ERDB.Server.ERR_APSSTATUS_FULLPLAN,
                ERDB.Server.ERR_APSSTATUS_GLBLPLAN
                vBaseMsg = "E=CtpPlanBusy"

            Case Aps.ServerService.APS_ERR_GENPLANORD
                vBaseMsg = "E=CtpGenPlanOrd"

            Case Aps.ServerService.APS_ERR_FLUSH
                vBaseMsg = "E=CtpFlush"

            Case Aps.ServerService.APS_ERR_FLUSH
                vBaseMsg = "E=CtpErdbFlush"

            Case Aps.ServerService.APS_ERR_NOSITES
                vBaseMsg = "E=CtpNoSites"

            Case Aps.ServerService.APS_ERR_SITEINFO
                vBaseMsg = "E=CtpSiteInfo"

            Case Aps.ServerService.APS_ERR_APSCONNECT
                vBaseMsg = "E=CtpApsConnect"

            Case Aps.ServerService.APS_ERR_OUTOFMEMORY
                vBaseMsg = "E=CtpOutOfMemory"

            Case Aps.ServerService.APS_ERR_HPMATCH
                vBaseMsg = "E=CtpErdbMatch"

            Case ERDB.Server.ERR_PNF
                vBaseMsg = "E=CtpPNF"

            Case ERDB.Server.ERR_FULL
                vBaseMsg = "E=CtpErdbFull"

            Case ERDB.Server.ERR_DUP
                vBaseMsg = "E=CtpErdbDup"

            Case ERDB.Server.ERR_FILE
                vBaseMsg = "E=CtpFile"

            Case ERDB.Server.ERR_LOGIC
                If vParm1 = "cdel_order" Then
                    vBaseMsg = "E=CtpLogic"
                Else
                    CTPErrorMsg = "Error " & vlErrorNumber & " in " & vParm1
                    Exit Function
                End If

            Case Else
                CTPErrorMsg = "Error " & vlErrorNumber & " in " & vParm1
                Exit Function

        End Select

        If vBaseMsg <> "" Then
            messageProvider = Me.GetMessageProvider()
            CTPErrorMsg = messageProvider.GetMessage(vBaseMsg, vParm1)
        End If

        If Trim(CTPErrorMsg) = "" Then
            CTPErrorMsg = "Error " & CStr(vlErrorNumber) & " in " & vParm1
        End If

        Exit Function

CTPErrorMsgErrorHandler:
        CTPErrorMsg = "CTPErrorMsg: " & Err.Number & " - " & Err.Description

    End Function

    Private Function Startcd2Num(ByVal vsStartcd As String) As Integer

        Select Case vsStartcd
            Case "P"
                Startcd2Num = STATUS_INPROCESS
            Case "A"
                Startcd2Num = STATUS_ALLOCATE
            Case "R"
                Startcd2Num = STATUS_RESUME
            Case "K"
                Startcd2Num = STATUS_KEEP
            Case "X"
                Startcd2Num = STATUS_RESUMEX
            Case "F"
                Startcd2Num = STATUS_FAIL
            Case "U"
                Startcd2Num = STATUS_OPERSTART
            Case Else
                Startcd2Num = STATUS_UNKNOWN
        End Select

    End Function

    Private Function Endcd2Num(ByVal vsEndcd As String) As Integer

        Select Case vsEndcd
            Case "P"
                Endcd2Num = STATUS_INPROCESS
            Case "F"
                Endcd2Num = STATUS_FREE
            Case "I"
                Endcd2Num = STATUS_INTERRUPT
            Case "H"
                Endcd2Num = STATUS_HOLD
            Case "B"
                Endcd2Num = STATUS_BEFORE
            Case "A"
                Endcd2Num = STATUS_AFTER
            Case "U"
                Endcd2Num = STATUS_SETUPEND
            Case Else
                Endcd2Num = STATUS_UNKNOWN
        End Select

    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ApsGetGanttDatesSp(ByVal AltNo As Short?, ByVal DataType As Integer?, ByRef StartDate As DateTime?, ByRef EndDate As DateTime?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iApsGetGanttDatesExt As IApsGetGanttDates = New ApsGetGanttDatesFactory().Create(appDb)
            Dim oStartDate As GenericDateType = StartDate
            Dim oEndDate As GenericDateType = EndDate
            Dim Severity As Integer = iApsGetGanttDatesExt.ApsGetGanttDatesSp(AltNo, DataType, oStartDate, oEndDate)
            StartDate = oStartDate
            EndDate = oEndDate
            Return Severity
        End Using
    End Function

End Class
