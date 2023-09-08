Option Explicit On
Option Strict On
Imports System.Xml

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common
Imports ERDB.Server
Imports CSI.Data.SQL.UDDT
Imports CSI.MG
Imports CSI.Production.APS
Imports IMessageProvider = Mongoose.IDO.IMessageProvider
Imports CSI.ExternalContracts.RhythmIntegration
Imports CSI.ExternalContracts.Portals

<IDOExtensionClass("SLCtps")>
Public Class SLCtps
    Inherits CSIExtensionClassBase
    Implements CSI.ExternalContracts.RhythmIntegration.ISLCtps
    Implements CSI.ExternalContracts.Portals.ISLCtps

    Private Const ERR_NOROOTNODE As Integer = -300
    Private Const ERR_BADLEAFINDEX As Integer = -301
    Private Const ERR_BADREQUESTXML As Integer = -302
    Private Const ERR_BADRESPONSEXML As Integer = -303
    Private Const ERR_VBRT As Integer = -304
    Private Const ERR_NODATA As Integer = -305

    Private Const MIN_DATE As Date = #1/1/1900#
    Private Const MAX_DATE As Date = #1/1/2028#
    Private Const CTP_BLOCKED_DATE As Date = #1/1/1970#
    Private Const CTP_RETRYMAX As Long = 3

    Private Const VAL_ALGSSITEFLAGS_NEWCRITPATH As Integer = 65536

    Private Const RES_USAGETYPE_BUSY As Integer = 1
    Private Const RES_USAGETYPE_OFFSHIFT As Integer = 2
    Private Const RES_USAGETYPE_MAINT As Integer = 3

    Private Const BAR_MAX As Integer = 25000

    Public TESTING_MODE As Boolean = False
    Public DEBUG_MODE As Boolean = True

    Private Structure ResrcPlanInfo
        Dim sDownCd As String
        Dim datStart As Date
        Dim datEnd As Date
        Dim sOrderID As String
    End Structure

    Private Structure uOrdDetailInv
        Dim lSchType As Integer
        Dim lSchFlags As Integer
        Dim datInvDate As Date
        Dim datReqDate As Date
        Dim datSupplyDate As Date
        Dim sOrderID As String
        Dim sSupplyID As String
        Dim dDemand As Double
        Dim dSupply As Double
        Dim dExpedited As Double
        Dim sRemoteSite As String
        Dim lSupMatlTag As Integer
        Dim dSupQty As Double
    End Structure

    Private Structure uOrdDetailOperGrpResUsage
        Dim lUsageType As Integer
        Dim datStartDate As Date
        Dim datEndDate As Date
    End Structure

    Private Structure uOrdDetailOperGrpRes
        Dim sResrcID As String
        Dim sResrcDescr As String
        Dim lUsageCount As Integer
        Dim uUsageList() As uOrdDetailOperGrpResUsage
        Dim sShift1 As String
        Dim sShift2 As String
        Dim sShift3 As String
        Dim sShift4 As String
    End Structure

    Private Structure uOrdDetailOperGrp
        Dim sGroupID As String
        Dim sGroupDescr As String
        Dim lResCount As Integer
        Dim uResList() As uOrdDetailOperGrpRes
        Dim bFiniteGroup As Boolean
        Dim bLaborGroup As Boolean
        Dim dWaitTime As Double
        Dim dPushWait As Double
        Dim lMembers As Integer
    End Structure

    Private Structure uOrdDetailOper
        Dim sOperID As String
        Dim sOperDescr As String
        Dim lSeqno As Integer
        Dim lFlags As Integer
        Dim datStartDate As Date
        Dim datEndDate As Date
        Dim lGrpCount As Integer
        Dim uGrpList() As uOrdDetailOperGrp
        Dim lPartCount As Integer
        Dim lPartList() As Integer
        Dim lGrpSort() As Integer
        Dim dQuantity As Double
        Dim dWIPQuantity As Double
        Dim bCritDelay As Boolean
        Dim bPushCritDelay As Boolean
        Dim bItemDelay As Boolean
        Dim bGroupDelay As Boolean
        Dim bFiniteGroupDelay As Boolean
        Dim sWorkcenter As String
        Dim dDuration As Double
    End Structure

    Private Structure uOrdDetailLeaf
        Dim lMatltag As Integer
        Dim lParentTag As Integer
        Dim lParentLeafIndex As Integer
        Dim lLoadID As Integer
        Dim sPartID As String
        Dim sPartDescr As String
        Dim lPartFlags As Integer
        Dim sBomID As String
        Dim sRouteID As String
        Dim datStartDate As Date
        Dim datEndDate As Date
        Dim dQuantity As Double
        Dim dInvQuantity As Double
        Dim dSupQuantity As Double
        Dim dPurchaseQuantity As Double
        Dim dUnconstrainedQuantity As Double
        Dim dMfgQuantity As Double
        Dim lMergeTo As Integer
        Dim lMergeIdx As Integer
        Dim sOperID As String
        Dim lOperCount As Integer
        Dim uOperList() As uOrdDetailOper
        Dim lOperSort() As Integer
        Dim lInvCount As Integer
        Dim uInvList() As uOrdDetailInv
        Dim lInvSort() As Integer
        Dim lChildCount As Integer
        Dim lChildList() As Integer
        Dim lChildSort() As Integer
        Dim dWaitTime As Double
        Dim dSlackTime As Double
        Dim bCritDelay As Boolean
        Dim bPushCritDelay As Boolean
        Dim bItemDelay As Boolean
        Dim bGroupDelay As Boolean
        Dim bFiniteGroupDelay As Boolean
        Dim dFLeadtime As Double
        Dim dVLeadtime As Double
        Dim dFExpLeadtime As Double
        Dim dVExpLeadtime As Double
        Dim dOrdMin As Double
        Dim dOrdMax As Double
        Dim dOrdMult As Double
        Dim dQtyOnhand As Double
        Dim lDaysSupply As Integer
        Dim lFlags As Integer
        Dim bSkip As Boolean
    End Structure

    Private Structure uOrdDetail
        Dim lAltNo As Integer
        Dim sSiteID As String
        Dim sOrderID As String
        Dim lMatlTag As Integer
        Dim sOrderDescr As String
        Dim sDemandID As String
        Dim datReqDate As Date
        Dim datPromDate As Date
        Dim datCalcDate As Date
        Dim datStartDate As Date
        Dim datPlannerStartDate As Date
        Dim dLateness As Double
        Dim sLateness As String
        Dim lLeafCount As Integer
        Dim uLeafList() As uOrdDetailLeaf
        Dim lLeafSort() As Integer
        Dim lHashCount As Integer
        Dim lMinimumMatlTag As Integer
        Dim lMaximumMatlTag As Integer
        Dim lHashList() As Integer
        Dim lRootCount As Integer
        Dim lRootList() As Integer
        Dim lParentOrderIndex As Integer
        Dim lParentOrderLeafIndex As Integer
        Dim lParentOrderEventIndex As Integer
        Dim bPushSlack As Boolean
    End Structure

    Private Structure uCTPLineItem
        Dim sSiteID As String
        Dim lAltNo As Integer
        Dim sWhseID As String
        Dim sOrderID As String
        Dim sRefOrderID As String
        Dim sItemid As String
        Dim dQuantity As Double
        Dim datRequestDate As Date
        Dim datDueDate As Date
        Dim lCategory As Integer
        Dim lOrdType As Integer
        Dim lFlags As Integer
        Dim lFlags2 As Integer
        Dim bProcessed As Boolean
    End Structure

    Private Structure uCTPRequest
        Dim lLineItemCount As Integer
        Dim uLineItemList() As uCTPLineItem
        Dim bDetails As Boolean
        Dim bQuantities As Boolean
        Dim bCTP As Boolean
        Dim bDisableExpedite As Boolean
    End Structure

    Private Structure uCTPQuantities
        Dim dQtyOnHand As Double
        Dim dQtyInv As Double
        Dim dQtyShip As Double
        Dim dQtyMfg As Double
    End Structure

    Private Structure uCTPLineItemResults
        Dim uRequest As uCTPLineItem
        Dim uQuantities As uCTPQuantities
        Dim uDetail As uOrdDetail
        Dim datCalcDate As Date
        Dim datStartDate As Date
        Dim lReturnCode As Integer
    End Structure

    Private Structure uCTPResponse
        Dim lLineItemCount As Integer
        Dim uLineItemList() As uCTPLineItemResults
        Dim bDetails As Boolean
        Dim bQuantities As Boolean
        Dim bCTP As Boolean
    End Structure

    ' Private variables
    Private muCon As rcon_s
    Private muOpn22Res As opn22res_s
    Private muOperation As operation_s
    Private muOpr22Cat As opr22cat_s
    Private muResource As resource_s
    Private muCategory As category_s
    Private muCat22Res As cat22res_s
    Private muPart As part_s
    Private muBOM22Prt As bom22prt_s
    Private muOrdWait As ordwaithrs_s
    Private muOrder As order_s
    Private muOrd22Mpn As ord22mpn_s
    Private muMpn22Ipn As mpn22ipn_s
    Private muMpn22Opn As mpn22opn_s
    Private muMatlplan As matlplan_s
    Private muMatlplanSup As matlplan_s
    Private muInvplan As invplan_s
    Private muInvplanSup As invplan_s
    Private muOperplan As operplan_s
    Private muRes22Shf As res22shf_s
    Private muOrdLineItem As ordlineitem_s
    Private muMisc As misc_s
    Private muErrormsg As errormsg_s
    Private msStatus As String
    Private mdatAPSNow As Date
    Private mbCtpDebug As Boolean
    Private mbComputeCritPath As Boolean
    Private ReadOnly msDebug As String

    Private Function GetApsServerInfo(ByVal lAltNo As Integer,
                                      ByVal sSite As String,
                                      ByRef sHost As String,
                                      ByRef lPort As Integer,
                                      ByRef sInfobar As String) As Integer
        Dim oCollection As LoadCollectionResponseData
        Dim sProperties As String
        Dim sFilter As String
        Dim hostIx, portIx As Integer

        Try
            ' Get host/port of APS server
            sProperties = "ApsHostName, ApsPortNo"
            sFilter = "AltNo = " & SqlLiteral.Format(lAltNo) & " AND ApsSite = " & SqlLiteral.Format(sSite)
            oCollection = Me.Context.Commands.LoadCollection("SL.SLApsSites",
                                                             sProperties, sFilter, "", 0)

            If oCollection.Items.Count = 0 Then
                sInfobar = CTPErrorMsg(Aps.ServerService.APS_ERR_SITEINFO)
                GetApsServerInfo = 16
                Exit Function
            End If

            hostIx = oCollection.PropertyList.IndexOf("ApsHostName")
            portIx = oCollection.PropertyList.IndexOf("ApsPortNo")

            For Each item As IDOItem In oCollection.Items
                sHost = item.PropertyValues(hostIx).ToString()
                lPort = item.PropertyValues(portIx).GetValue(Of Integer)()
                Exit For
            Next

        Catch ex As Exception
            sInfobar = "SLCtps.GetApsServerInfo(): " & ex.Message
            GetApsServerInfo = 16
            Exit Function

        End Try

        GetApsServerInfo = 0

    End Function

    Private Function GetErdbServerInfo(ByVal lAltNo As Integer,
                                  ByVal sSite As String,
                                  ByRef sHost As String,
                                  ByRef lPort As Integer,
                                  ByRef sInfobar As String) As Integer
        Dim oCollection As LoadCollectionResponseData
        Dim sProperties As String
        Dim sFilter As String
        Dim hostIx, portIx As Integer

        Try
            ' Get host/port of APS server
            sProperties = "ApsHostName, ApsPortNo"
            sFilter = "AltNo = " & SqlLiteral.Format(lAltNo) & " AND ApsSite = " & SqlLiteral.Format(sSite)
            oCollection = Me.Context.Commands.LoadCollection("SL.SLApsSites",
                                                             sProperties, sFilter, "", 0)

            If oCollection.Items.Count = 0 Then
                sInfobar = CTPErrorMsg(Aps.ServerService.APS_ERR_SITEINFO)
                GetErdbServerInfo = 16
                Exit Function
            End If

            hostIx = oCollection.PropertyList.IndexOf("ApsHostName")
            portIx = oCollection.PropertyList.IndexOf("ApsPortNo")

            For Each item As IDOItem In oCollection.Items
                sHost = item.PropertyValues(hostIx).ToString()
                lPort = item.PropertyValues(portIx).GetValue(Of Integer)()
                Exit For
            Next

        Catch ex As Exception
            sInfobar = "SLCtps.GetErdbServerInfo(): " & ex.Message
            GetErdbServerInfo = 16
            Exit Function

        End Try

        GetErdbServerInfo = 0

    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetPlannerLog(ByVal lAltNo As Integer,
                                  ByVal sSite As String,
                                  ByRef sLogText As String,
                                  ByRef Infobar As String) As Integer
        Dim lRC As Integer
        Dim sHost As String = ""
        Dim lPort As Integer = 0

        If DEBUG_MODE Then
            IDORuntime.LogUserMessage("SLCtps", UserDefinedMessageType.UserDefined1,
                                      "Begin GetPlannerLog")
        End If

        sLogText = String.Empty
        Infobar = String.Empty

        ' Get erdb host & port
        If GetErdbServerInfo(lAltNo, sSite, sHost, lPort, Infobar) <> 0 Then
            GetPlannerLog = 16
            GoTo GetPlannerLog_exit
        End If

        ' Get the log file text
        lRC = ApsServerInterface.GetPlannerLog(sHost, lPort, sLogText)
        If lRC <> ERDB.Server.ERR_OK Then
            Infobar = CTPErrorMsg(lRC)
            GetPlannerLog = 16
            GoTo GetPlannerLog_exit
        End If

        GetPlannerLog = 0

GetPlannerLog_exit:
        If DEBUG_MODE Then
            If GetPlannerLog = 0 Then
                IDORuntime.LogUserMessage("SLCtps", UserDefinedMessageType.UserDefined1,
                                          "End GetPlannerLog, ret=0")
            Else
                IDORuntime.LogUserMessage("SLCtps", UserDefinedMessageType.UserDefined1,
                                          "End GetPlannerLog, ret={0}, msg={1}",
                                          GetPlannerLog, Infobar)
            End If
        End If

    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetSchedulerLog(ByVal lAltNo As Integer,
                                    ByRef sLogText As String,
                                    ByRef Infobar As String) As Integer
        Dim lRC As Integer
        Dim sProperties As String
        Dim sFilter As String
        Dim sOrderBy As String
        Dim oData As LoadCollectionResponseData
        Dim msgIx As Integer

        If DEBUG_MODE Then
            IDORuntime.LogUserMessage("SLCtps", UserDefinedMessageType.UserDefined1,
                                      "Begin GetSchedulerLog")
        End If

        sLogText = String.Empty
        Infobar = String.Empty

        On Error GoTo GetSchedulerLog_exit

        ' Get summary record
        sProperties = "MSG"
        sFilter = ""
        sOrderBy = "SEQNUM"
        oData = Me.Context.Commands.LoadCollection("SL.SLTRACELOGs", sProperties, sFilter, sOrderBy, 0)
        If oData.Items.Count > 0 Then
            msgIx = oData.PropertyList.IndexOf("MSG")
            For Each item As IDOItem In oData.Items
                Dim propval As IDOPropertyValue
                propval = item.PropertyValues(msgIx)
                If Not propval.IsNull Then
                    sLogText = sLogText + item.PropertyValues(msgIx).GetValue(Of String)() + Environment.NewLine
                Else
                    sLogText = sLogText + Environment.NewLine
                End If
            Next
        End If
        oData = Nothing

        GetSchedulerLog = 0

GetSchedulerLog_exit:
        If DEBUG_MODE Then
            If GetSchedulerLog = 0 Then
                IDORuntime.LogUserMessage("SLCtps", UserDefinedMessageType.UserDefined1,
                                          "End GetSchedulerLog, ret=0")
            Else
                IDORuntime.LogUserMessage("SLCtps", UserDefinedMessageType.UserDefined1,
                                          "End GetSchedulerLog, ret={0}, msg={1}",
                                          GetSchedulerLog, Infobar)
            End If
        End If

    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PlanOrder(ByVal SiteID As String,
                              ByVal AltNo As Integer,
                              ByVal OrderID As String,
                              ByRef Infobar As String) As Integer

        Dim oResponse As Mongoose.IDO.Protocol.InvokeResponseData

        If DEBUG_MODE Then
            IDORuntime.LogUserMessage("SLCtps", UserDefinedMessageType.UserDefined1,
                                      "Begin PlanOrder")
        End If

        ' Plan order (asynchronously through ERDBGW)
        oResponse = Me.Context.Commands.Invoke(
                                "SLCtps",
                                "ApsCtpPlanOrderSp",
                                SiteID, OrderID, AltNo)

        Infobar = String.Empty

        PlanOrder = 0

        If DEBUG_MODE Then
            IDORuntime.LogUserMessage("SLCtps", UserDefinedMessageType.UserDefined1,
                                        "End PlanOrder, ret={0}",
                                        PlanOrder)

        End If

    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PlanOrders(ByVal sRequestXML As String,
                               ByRef sResponseXML As String,
                               ByRef Infobar As String) As Integer

        Dim uRequest As New uCTPRequest
        Dim uResponse As New uCTPResponse
        Dim iRC As Integer

        If DEBUG_MODE Then
            IDORuntime.LogUserMessage("SLCtps", UserDefinedMessageType.UserDefined1,
                                      "Begin PlanOrders")
        End If

        sResponseXML = String.Empty
        Infobar = String.Empty

        On Error GoTo PlanOrdersErrorHandler

        ' Initialize module variables
        msStatus = ""

        ' Convert input XML to user-defined type
        iRC = RequestXML2Request(sRequestXML, uRequest)
        If iRC <> ERR_OK Then
            Infobar = msStatus
            PlanOrders = 16
            GoTo PlanOrders_exit
        End If

        ' Calculate CTP results
        iRC = ProcessOrders(uRequest, uResponse)
        If iRC <> ERR_OK Then
            Infobar = msStatus
            PlanOrders = 16
            GoTo PlanOrders_exit
        End If

        ' Convert results to XML for transfer back to caller
        iRC = Response2ResponseXML(sResponseXML, uResponse)
        If iRC <> ERR_OK Then
            Infobar = msStatus
            PlanOrders = 16
            GoTo PlanOrders_exit
        End If

        ' Finished
        PlanOrders = 0

        GoTo PlanOrders_exit

PlanOrdersErrorHandler:
        Infobar = "SLCtps.PlanOrders():" & "  Internal error " & Err.Number & " - " & Err.Description
        PlanOrders = 16

PlanOrders_exit:
        If DEBUG_MODE Then
            If PlanOrders = 0 Then
                IDORuntime.LogUserMessage("SLCtps", UserDefinedMessageType.UserDefined1,
                                          "End PlanOrders, ret=0")
            Else
                IDORuntime.LogUserMessage("SLCtps", UserDefinedMessageType.UserDefined1,
                                          "End PlanOrders, ret={0}, msg={1}",
                                          PlanOrders, Infobar)
            End If
        End If

    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DeleteOrder(ByVal SiteID As String,
                                ByVal OrderID As String,
                                ByRef Infobar As String) As Integer

        Dim iRC As Integer
        Dim sApsHost As String = ""
        Dim lApsPort As Integer = 0

        If DEBUG_MODE Then
            IDORuntime.LogUserMessage("SLCtps", UserDefinedMessageType.UserDefined1,
                                      "Begin DeleteOrder")
        End If

        Infobar = String.Empty

        ' Get server host & port
        If GetApsServerInfo(0, SiteID, sApsHost, lApsPort, Infobar) <> 0 Then
            DeleteOrder = 16
            GoTo DeleteOrder_exit
        End If

        ' Plan the order
        iRC = ApsServerInterface.DeleteOrder(sApsHost, lApsPort, 0, OrderID, -1)
        If iRC <> Aps.ServerService.APS_ERR_OK Then
            Infobar = CTPErrorMsg(iRC)
            DeleteOrder = 16
            GoTo DeleteOrder_exit
        End If

        DeleteOrder = 0

DeleteOrder_exit:
        If DEBUG_MODE Then
            If DeleteOrder = 0 Then
                IDORuntime.LogUserMessage("SLCtps", UserDefinedMessageType.UserDefined1,
                                          "End DeleteOrder, ret=0")
            Else
                IDORuntime.LogUserMessage("SLCtps", UserDefinedMessageType.UserDefined1,
                                          "End DeleteOrder, ret={0}, msg={1}",
                                          DeleteOrder, Infobar)
            End If
        End If

    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function FlushGateway(ByVal SiteID As String,
                                 ByRef Infobar As String) As Integer

        Dim iRC As Integer
        Dim sApsHost As String = ""
        Dim lApsPort As Integer = 0
        Dim oCollection As LoadCollectionResponseData
        Dim sProperties As String
        Dim sFilter As String
        Dim hostIx, portIx As Integer

        If DEBUG_MODE Then
            IDORuntime.LogUserMessage("SLCtps", UserDefinedMessageType.UserDefined1,
                                      "Begin FlushGateway")
        End If

        Infobar = String.Empty

        Try
            ' Get host/port of APS server & planner
            sProperties = "ApsHostName, ApsPortNo"
            sFilter = "AltNo = 0 AND ApsSite = " & SqlLiteral.Format(SiteID)
            oCollection = Me.Context.Commands.LoadCollection("SL.SLApsSites",
                                                             sProperties, sFilter, "", 0)

            If oCollection.Items.Count = 0 Then
                'Infobar = CTPErrorMsg(ApsServerInterface.APS_ERR_SITEINFO)
                FlushGateway = 0
                GoTo FlushGateway_exit
            End If

            hostIx = oCollection.PropertyList.IndexOf("ApsHostName")
            portIx = oCollection.PropertyList.IndexOf("ApsPortNo")

            For Each item As IDOItem In oCollection.Items
                sApsHost = item.PropertyValues(hostIx).ToString()
                lApsPort = item.PropertyValues(portIx).GetValue(Of Integer)()
                Exit For
            Next

        Catch ex As Exception
            Infobar = "SLCtps.FlushGateway(): " & ex.Message
            FlushGateway = 16
            GoTo FlushGateway_exit

        End Try

        ' Connect to APS server
        iRC = ApsServerInterface.FlushGateway(sApsHost, lApsPort, 0)
        If iRC <> Aps.ServerService.APS_ERR_OK Then
            'Infobar = CTPErrorMsg(iRC)
            FlushGateway = 0
            GoTo FlushGateway_exit
        End If

        FlushGateway = 0

FlushGateway_exit:
        If DEBUG_MODE Then
            If FlushGateway = 0 Then
                IDORuntime.LogUserMessage("SLCtps", UserDefinedMessageType.UserDefined1,
                                          "End FlushGateway, ret=0")
            Else
                IDORuntime.LogUserMessage("SLCtps", UserDefinedMessageType.UserDefined1,
                                          "End FlushGateway, ret={0}, msg={1}",
                                          FlushGateway, Infobar)
            End If
        End If

    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetCTPOrderDetail(ByVal SiteID As String,
                                      ByVal OrderID As String,
                                      ByRef sDetailXML As String,
                                      ByRef Infobar As String) As Integer

        Dim uResponse As uCTPResponse
        Dim sApsHost As String = ""
        Dim lApsPort As Integer = 0
        Dim oCollection As LoadCollectionResponseData
        Dim sProperties As String
        Dim sFilter As String
        Dim iRC As Integer
        Dim hostIx, portIx As Integer
        Dim oERDB As New ERDB.Server

        If DEBUG_MODE Then
            IDORuntime.LogUserMessage("SLCtps", UserDefinedMessageType.UserDefined1,
                                      "Begin GetCTPOrderDetail")
        End If

        sDetailXML = String.Empty
        Infobar = String.Empty

        ' Initialize module variables
        msStatus = ""

        If TESTING_MODE Then
            sApsHost = "localhost"
            lApsPort = 6001
        Else
            Try
                ' Get host/port of APS planner
                sProperties = "ApsHostName, ApsPortNo"
                sFilter = "AltNo = 0 AND ApsSite = " & SqlLiteral.Format(SiteID)
                oCollection = Me.Context.Commands.LoadCollection("SL.SLApsSites",
                                                                 sProperties, sFilter, "", 0)

                If oCollection.Items.Count = 0 Then
                    Infobar = CTPErrorMsg(Aps.ServerService.APS_ERR_SITEINFO, SiteID)
                    GetCTPOrderDetail = 16
                    GoTo GetCTPOrderDetail_exit
                End If

                hostIx = oCollection.PropertyList.IndexOf("ApsHostName")
                portIx = oCollection.PropertyList.IndexOf("ApsPortNo")

                For Each item As IDOItem In oCollection.Items
                    sApsHost = item.PropertyValues(hostIx).ToString()
                    lApsPort = item.PropertyValues(portIx).GetValue(Of Integer)()
                    Exit For
                Next

            Catch ex As Exception
                Infobar = "SLCtps.GetCTPOrderDetail(): " & ex.Message
                GetCTPOrderDetail = 16
                GoTo GetCTPOrderDetail_exit
            End Try
        End If

        ' Connect to APS planner
        iRC = oERDB.cget_connection(muCon, sApsHost, lApsPort)
        If iRC <> ERR_OK Then
            Infobar = CTPErrorMsg(iRC, "cget_connection")
            GetCTPOrderDetail = 16
            GoTo GetCTPOrderDetail_exit
        End If

        ' Initialize planner structures
        iRC = InitCTP()
        If iRC <> ERR_OK Then
            Infobar = CTPErrorMsg(iRC, "InitCTP")
            GetCTPOrderDetail = iRC
            Call oERDB.cdel_connection(muCon)
            GoTo GetCTPOrderDetail_exit
        End If

        ' Get order details
        ReDim uResponse.uLineItemList(0)
        uResponse.lLineItemCount = 1
        uResponse.bDetails = True
        uResponse.bQuantities = False
        uResponse.bCTP = True
        uResponse.uLineItemList(0).uRequest.sSiteID = SiteID
        uResponse.uLineItemList(0).uRequest.sOrderID = OrderID
        muOrder.order = OrderID

        iRC = GetCTPResults(uResponse.uLineItemList(0), True)
        If iRC <> ERR_OK Then
            Infobar = msStatus
            GetCTPOrderDetail = 16
            Call oERDB.cdel_connection(muCon)
            GoTo GetCTPOrderDetail_exit
        End If

        ' Disconnect from APS planner
        iRC = oERDB.cdel_connection(muCon)
        If iRC <> ERR_OK Then
            Infobar = CTPErrorMsg(iRC, "cdel_connection")
            GetCTPOrderDetail = 16
            GoTo GetCTPOrderDetail_exit
        End If

        ' Get last synch date
        iRC = GetAltPlan(uResponse.uLineItemList(0).uDetail)
        If iRC <> ERR_OK Then
            Infobar = msStatus
            GetCTPOrderDetail = 16
            GoTo GetCTPOrderDetail_exit
        End If

        ' Convert CTP results to XML for transfer back to caller
        iRC = Detail2DetailXML(Nothing, Nothing, sDetailXML, uResponse.uLineItemList(0).uDetail)
        If iRC <> ERR_OK Then
            Infobar = msStatus
            GetCTPOrderDetail = 16
            GoTo GetCTPOrderDetail_exit
        End If

        ' Finished
        GetCTPOrderDetail = 0

GetCTPOrderDetail_exit:
        If DEBUG_MODE Then
            If GetCTPOrderDetail = 0 Then
                IDORuntime.LogUserMessage("SLCtps", UserDefinedMessageType.UserDefined1,
                                          "End GetCTPOrderDetail, ret=0")
            Else
                IDORuntime.LogUserMessage("SLCtps", UserDefinedMessageType.UserDefined1,
                                          "End GetCTPOrderDetail, ret={0}, msg={1}",
                                          GetCTPOrderDetail, Infobar)
            End If
        End If

    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetResrcPlan(ByVal lAltNo As Integer,
                                 ByVal ResrcID As String,
                                 ByVal OrderID As String,
                                 ByVal StartDate As Date,
                                 ByVal EndDate As Date,
                                 ByRef sResrcPlanXML As String,
                                 ByRef Infobar As String
                                 ) As Integer

        Dim oRequest1 As New LoadCollectionRequestData
        Dim oRequest2 As New LoadCollectionRequestData
        Dim oData As LoadCollectionResponseData
        Dim lIxDOWNCD As Integer
        Dim lIxSTARTDATE As Integer
        Dim lIxENDDATE As Integer
        Dim lIxDEMANDID As Integer
        Dim sFilter As String

        Infobar = String.Empty
        sResrcPlanXML = "<ListOfBlocks>"

        ' Get downtime plan
        oRequest1.IDOName = "TABLE!" + "DOWNPLAN" + lAltNo.ToString("000")
        oRequest1.PropertyList.Add("DOWNCD")
        oRequest1.PropertyList.Add("STARTDATE")
        oRequest1.PropertyList.Add("ENDDATE")
        sFilter = "DOWNCD <> 'W' AND RESID = " + SqlLiteral.Format(ResrcID) +
                  " AND STARTDATE < " + SqlLiteral.Format(EndDate) +
                  " AND ENDDATE > " + SqlLiteral.Format(StartDate)
        oRequest1.Filter = sFilter
        oRequest1.RecordCap = 0
        oRequest1.OrderBy = "STARTDATE"
        oData = Me.Context.Commands.LoadCollection(oRequest1)
        If oData.Items.Count > 0 Then
            lIxDOWNCD = oData.PropertyList.IndexOf("DOWNCD")
            lIxSTARTDATE = oData.PropertyList.IndexOf("STARTDATE")
            lIxENDDATE = oData.PropertyList.IndexOf("ENDDATE")
            For Each oItem As IDOItem In oData.Items
                sResrcPlanXML = sResrcPlanXML + "<Block>"
                If oItem.PropertyValues(lIxDOWNCD).GetValue(Of String)() = "S" Then
                    sResrcPlanXML = sResrcPlanXML + "<Type>S</Type>"
                Else
                    sResrcPlanXML = sResrcPlanXML + "<Type>M</Type>"
                End If
                sResrcPlanXML = sResrcPlanXML + "<StartDate>" + MGType.ToInternal(oItem.PropertyValues(lIxSTARTDATE).GetValue(Of Date)()) + "</StartDate>"
                sResrcPlanXML = sResrcPlanXML + "<EndDate>" + MGType.ToInternal(oItem.PropertyValues(lIxENDDATE).GetValue(Of Date)()) + "</EndDate>"
                sResrcPlanXML = sResrcPlanXML + "</Block>"
            Next
        End If

        ' Get resource plan
        oRequest2.IDOName = "SL.SLResourcePlans"
        oRequest2.PropertyList.SetProperties("STARTDATE, ENDDATE, DerApsRef")
        oRequest2.CustomLoadMethod = New CustomLoadMethod()
        oRequest2.RecordCap = 0
        oRequest2.CustomLoadMethod.Name = "CLM_ResourcePlanSp"
        oRequest2.CustomLoadMethod.Parameters.Add(lAltNo)

        Dim xmlFilterString As String = "<FilterString><Item><Property>RESID</Property>" +
            "<Operator>=</Operator>" +
            "<Value>" + ResrcID + "</Value>" +
            "<DataType>String</DataType></Item>" +
            "<Item><Property>STARTDATE</Property>" +
            "<Operator>&lt;</Operator>" +
            "<Value>" + EndDate.ToString() + "</Value>" +
            "<DataType>datetime</DataType></Item>" +
            "<Item><Property>ENDDATE</Property>" +
            "<Operator>&gt;</Operator>" +
            "<Value>" + StartDate.ToString() + "</Value>" +
            "<DataType>datetime</DataType></Item>" +
            "<Item><Property>ORDERID</Property>" +
            "<Operator>=</Operator>" +
            "<Value>" + OrderID + "</Value>" +
            "<DataType>String</DataType></Item></FilterString>"

        oRequest2.CustomLoadMethod.Parameters.Add(xmlFilterString)
        oData = Me.Context.Commands.LoadCollection(oRequest2)
        If oData.Items.Count > 0 Then
            lIxDEMANDID = oData.PropertyList.IndexOf("DerApsRef")
            lIxSTARTDATE = oData.PropertyList.IndexOf("STARTDATE")
            lIxENDDATE = oData.PropertyList.IndexOf("ENDDATE")
            For Each oItem As IDOItem In oData.Items
                sResrcPlanXML = sResrcPlanXML + "<Block>"
                sResrcPlanXML = sResrcPlanXML + "<Type>R</Type>"
                sResrcPlanXML = sResrcPlanXML + "<StartDate>" + MGType.ToInternal(oItem.PropertyValues(lIxSTARTDATE).GetValue(Of Date)()) + "</StartDate>"
                sResrcPlanXML = sResrcPlanXML + "<EndDate>" + MGType.ToInternal(oItem.PropertyValues(lIxENDDATE).GetValue(Of Date)()) + "</EndDate>"
                sResrcPlanXML = sResrcPlanXML + "<DemandID>" + oItem.PropertyValues(lIxDEMANDID).GetValue(Of String)() + "</DemandID>"
                sResrcPlanXML = sResrcPlanXML + "</Block>"
            Next
        End If
        sResrcPlanXML = sResrcPlanXML + "</ListOfBlocks>"

        GetResrcPlan = 0
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetOrderDetail(ByVal lAltNo As Integer,
                                   ByVal SiteID As String,
                                   ByVal OrderID As String,
                                   ByVal lMatlTag As Integer,
                                   ByRef sDetailXML As String,
                                   ByRef Infobar As String
                                   ) As Integer

        Dim uDetail As New uOrdDetail
        Dim lIndex As Integer
        Dim iRC As Integer

        If DEBUG_MODE Then
            IDORuntime.LogUserMessage("SLCtps", UserDefinedMessageType.UserDefined1,
                                      "Begin GetOrderDetail")
        End If

        GetOrderDetail = 0

        sDetailXML = String.Empty
        Infobar = String.Empty

        ' Set Alternative Number
        uDetail.lAltNo = lAltNo

        On Error GoTo GetOrderDetailErrorHandler

        ' Initialize module variables
        msStatus = ""

        ' Get last synch date
        iRC = GetAltPlan(uDetail)
        If iRC <> ERR_OK Then
            Infobar = msStatus
            GetOrderDetail = 16
            GoTo GetOrderDetail_exit
        End If

        ' Get order summary
        uDetail.sOrderID = OrderID
        uDetail.sSiteID = SiteID
        uDetail.lMatlTag = lMatlTag
        iRC = GetOrdSummary(uDetail)
        If iRC <> ERR_OK Then
            Infobar = msStatus
            GetOrderDetail = 16
            GoTo GetOrderDetail_exit
        End If

        ' Get leaves of order tree
        iRC = GetOrdLeaves(uDetail)
        If iRC <> ERR_OK Then
            Infobar = msStatus
            GetOrderDetail = 16
            GoTo GetOrderDetail_exit
        End If

        ' Set parent/child relationships
        iRC = ConnectLeaves(uDetail)
        If iRC <> ERR_OK Then
            Infobar = msStatus
            GetOrderDetail = 16
            GoTo GetOrderDetail_exit
        End If

        ' Check for no leaves...
        If uDetail.lLeafCount > 0 Then

            ' Get leaf operations
            iRC = GetLeafOperations(uDetail)
            If iRC <> ERR_OK Then
                Infobar = msStatus
                GetOrderDetail = 16
                GoTo GetOrderDetail_exit
            End If

            ' Get WIP usage
            iRC = GetLeafOperationWIP(uDetail)
            If iRC <> ERR_OK Then
                Infobar = msStatus
                GetOrderDetail = 16
                GoTo GetOrderDetail_exit
            End If

            ' Get leaf inventory events
            iRC = GetLeafEvents(uDetail)
            If iRC <> ERR_OK Then
                Infobar = msStatus
                GetOrderDetail = 16
                GoTo GetOrderDetail_exit
            End If

            ' Add children to correct operations
            iRC = GetOrdTree(uDetail)
            If iRC <> ERR_OK Then
                Infobar = msStatus
                GetOrderDetail = 16
                GoTo GetOrderDetail_exit
            End If

            ' Get leaf waiting times
            iRC = GetLeafWait(uDetail)
            If iRC <> ERR_OK Then
                Infobar = msStatus
                GoTo GetOrderDetail_exit
                Exit Function
            End If

            ' Mark critical path throughout tree
            For lIndex = 0 To uDetail.lRootCount - 1
                Call MarkCriticalOperations(uDetail, uDetail.lRootList(lIndex))
            Next

            ' Mark push critical path throughout tree
            For lIndex = 0 To uDetail.lRootCount - 1
                Call MarkPushCriticalOperations(uDetail, uDetail.lRootList(lIndex))
            Next

            ' Determine waiting time throughout tree
            For lIndex = 0 To uDetail.lRootCount - 1
                iRC = GetOrdTreeWait(uDetail, uDetail.lRootList(lIndex))
                If iRC <> ERR_OK Then
                    Infobar = msStatus
                    GetOrderDetail = 16
                    GoTo GetOrderDetail_exit
                End If
            Next

            ' Compute slack throughout the tree (if late)
            If uDetail.datCalcDate > uDetail.datPromDate Then
                For lIndex = 0 To uDetail.lRootCount - 1
                    iRC = GetOrdTreeSlack(uDetail, uDetail.lRootList(lIndex))
                    If iRC <> ERR_OK Then
                        Infobar = msStatus
                        GetOrderDetail = 16
                        GoTo GetOrderDetail_exit
                    End If
                Next
            End If
        End If
        ' Convert order detail to XML for transfer back to caller
        iRC = Detail2DetailXML(Nothing, Nothing, sDetailXML, uDetail)
        If iRC <> ERR_OK Then
            Infobar = msStatus
            GetOrderDetail = 16
            GoTo GetOrderDetail_exit
        End If

        ' Finished

        GoTo GetOrderDetail_exit

GetOrderDetailErrorHandler:
        Infobar = "SLCtps.GetOrderDetail():" & "  Internal error " & Err.Number & " - " & Err.Description
        GetOrderDetail = 16

GetOrderDetail_exit:
        If DEBUG_MODE Then
            If GetOrderDetail = 0 Then
                IDORuntime.LogUserMessage("SLCtps", UserDefinedMessageType.UserDefined1,
                                          "End GetOrderDetail, ret=0")
            Else
                IDORuntime.LogUserMessage("SLCtps", UserDefinedMessageType.UserDefined1,
                                          "End GetOrderDetail, ret={0}, msg={1}",
                                          GetOrderDetail, Infobar)
            End If
        End If

    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetCTP(ByVal sRequestXML As String,
                           ByRef sResponseXML As String,
                           ByRef Infobar As String) As Integer Implements CSI.ExternalContracts.RhythmIntegration.ISLCtps.GetCTP

        Dim uRequest As New uCTPRequest
        Dim uResponse As New uCTPResponse
        Dim iRC As Integer

        If DEBUG_MODE Then
            IDORuntime.LogUserMessage("SLCtps", UserDefinedMessageType.UserDefined1,
                                      "Begin GetCTP")
        End If

        sResponseXML = String.Empty
        Infobar = String.Empty

        On Error GoTo GetCTPErrorHandler

        ' Initialize module variables
        msStatus = ""
        mbCtpDebug = False

        ' Convert input XML to user-defined type
        iRC = RequestXML2Request(sRequestXML, uRequest)
        If iRC <> ERR_OK Then
            Infobar = msStatus
            GetCTP = 16
            GoTo GetCTP_exit
        End If
        uRequest.bCTP = True

        ' Calculate CTP results
        iRC = ProcessCTP(uRequest, uResponse)
        If iRC <> ERR_OK Then
            Infobar = msStatus
            GetCTP = 16
            GoTo GetCTP_exit
        End If

        ' Convert CTP results to XML for transfer back to caller
        iRC = Response2ResponseXML(sResponseXML, uResponse)
        If iRC <> ERR_OK Then
            Infobar = msStatus
            GetCTP = 16
            GoTo GetCTP_exit
        End If

        ' Finished
        GetCTP = 0

        GoTo GetCTP_exit

GetCTPErrorHandler:
        Infobar = "SLCtps.GetCTP():" & "  Internal error " & Err.Number & " - " & Err.Description
        GetCTP = 16

GetCTP_exit:
        If DEBUG_MODE Then
            If GetCTP = 0 Then
                IDORuntime.LogUserMessage("SLCtps", UserDefinedMessageType.UserDefined1,
                                          "End GetCTP, ret=0")
            Else
                IDORuntime.LogUserMessage("SLCtps", UserDefinedMessageType.UserDefined1,
                                          "End GetCTP, ret={0}, msg={1}",
                                          GetCTP, Infobar)
            End If
        End If

    End Function

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

            Case ERR_NODATA, ERR_CONNECT_OPENDB, ERR_CONNECT_NOTEXIST
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

            Case Aps.ServerService.APS_ERR_GWFLUSH
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

    Private Function GetEarliestChild(ByRef ruOrdDetail As uOrdDetail,
                                      ByVal vlLeaf As Integer) As Date

        Dim datEarliest As Date
        Dim datChildStart As Date
        Dim lIndex As Integer
        Dim lChildLeafIndex As Integer

        ' Find earliest child
        datEarliest = ruOrdDetail.uLeafList(vlLeaf).datStartDate
        For lIndex = 0 To ruOrdDetail.uLeafList(vlLeaf).lChildCount - 1
            lChildLeafIndex = ruOrdDetail.uLeafList(vlLeaf).lChildList(lIndex)
            datChildStart = GetEarliestChild(ruOrdDetail, lChildLeafIndex)
            If datChildStart < datEarliest Then
                datEarliest = datChildStart
            End If
        Next lIndex

        GetEarliestChild = datEarliest

    End Function

    Private Function MarkCriticalPath(ByRef ruOrdDetail As uOrdDetail,
                                      ByVal vlLeaf As Integer,
                                      ByVal vdatEarliest As Date) As Boolean
        Dim lIndex As Integer
        Dim lChildLeafIndex As Integer

        ' Stop when at a terminal leaf
        If ruOrdDetail.uLeafList(vlLeaf).lChildCount = 0 Then
            If ruOrdDetail.uLeafList(vlLeaf).datStartDate = vdatEarliest Then
                ruOrdDetail.uLeafList(vlLeaf).bCritDelay = True
            End If
        Else ' Descend to children
            For lIndex = 0 To ruOrdDetail.uLeafList(vlLeaf).lChildCount - 1
                lChildLeafIndex = ruOrdDetail.uLeafList(vlLeaf).lChildList(lIndex)
                If MarkCriticalPath(ruOrdDetail, lChildLeafIndex, vdatEarliest) Then
                    ruOrdDetail.uLeafList(vlLeaf).bCritDelay = True
                End If
            Next lIndex
        End If

        MarkCriticalPath = ruOrdDetail.uLeafList(vlLeaf).bCritDelay

    End Function

    Private Function MarkCriticalOperations(ByRef ruOrdDetail As uOrdDetail,
                                            ByVal vlLeaf As Integer) As Boolean
        Dim lIndex As Integer
        Dim lChildLeafIndex As Integer
        Dim lMergeIdx As Integer

        MarkCriticalOperations = ruOrdDetail.uLeafList(vlLeaf).bCritDelay

        ' Exit if not on critical path
        If Not ruOrdDetail.uLeafList(vlLeaf).bCritDelay Then
            Exit Function
        End If

        ' Stop when at a terminal leaf
        If ruOrdDetail.uLeafList(vlLeaf).lChildCount = 0 Then
            lMergeIdx = 0
        Else ' Descend to children
            lMergeIdx = ruOrdDetail.uLeafList(vlLeaf).lOperCount
            For lIndex = 0 To ruOrdDetail.uLeafList(vlLeaf).lChildCount - 1
                lChildLeafIndex = ruOrdDetail.uLeafList(vlLeaf).lChildList(lIndex)
                If MarkCriticalOperations(ruOrdDetail, lChildLeafIndex) Then
                    If ruOrdDetail.uLeafList(lChildLeafIndex).lMergeIdx < lMergeIdx Then
                        lMergeIdx = ruOrdDetail.uLeafList(lChildLeafIndex).lMergeIdx
                    End If
                End If
            Next lIndex
        End If

        ' Mark critical operations
        For lIndex = lMergeIdx To ruOrdDetail.uLeafList(vlLeaf).lOperCount - 1
            Dim lSortIndex As Integer
            lSortIndex = ruOrdDetail.uLeafList(vlLeaf).lOperSort(lIndex)
            ruOrdDetail.uLeafList(vlLeaf).uOperList(lSortIndex).bCritDelay = True
        Next lIndex

    End Function

    Private Function MarkPushCriticalOperations(ByRef ruOrdDetail As uOrdDetail,
                                                ByVal vlLeaf As Integer) As Boolean
        Dim lIndex As Integer
        Dim lChildLeafIndex As Integer
        Dim lMergeIdx As Integer

        MarkPushCriticalOperations = ruOrdDetail.uLeafList(vlLeaf).bPushCritDelay

        ' Exit if not on push critical path
        If Not ruOrdDetail.uLeafList(vlLeaf).bPushCritDelay Then
            Exit Function
        End If

        ' Stop when at a terminal leaf
        If ruOrdDetail.uLeafList(vlLeaf).lChildCount = 0 Then
            lMergeIdx = 0
        Else ' Descend to children
            lMergeIdx = ruOrdDetail.uLeafList(vlLeaf).lOperCount
            For lIndex = 0 To ruOrdDetail.uLeafList(vlLeaf).lChildCount - 1
                lChildLeafIndex = ruOrdDetail.uLeafList(vlLeaf).lChildList(lIndex)
                If MarkPushCriticalOperations(ruOrdDetail, lChildLeafIndex) Then
                    If ruOrdDetail.uLeafList(lChildLeafIndex).lMergeIdx < lMergeIdx Then
                        lMergeIdx = ruOrdDetail.uLeafList(lChildLeafIndex).lMergeIdx
                    End If
                End If
            Next lIndex
        End If

        ' Mark push critical operations
        For lIndex = lMergeIdx To ruOrdDetail.uLeafList(vlLeaf).lOperCount - 1
            Dim lSortIndex As Integer
            lSortIndex = ruOrdDetail.uLeafList(vlLeaf).lOperSort(lIndex)
            ruOrdDetail.uLeafList(vlLeaf).uOperList(lSortIndex).bPushCritDelay = True
        Next lIndex

    End Function

    Private Function InitCTP() As Integer

        Dim iRC As Integer
        Dim oERDB As New ERDB.Server

        iRC = oERDB.cini_misc(muCon, muMisc)
        If iRC <> ERR_OK Then
            InitCTP = iRC
            Exit Function
        End If
        iRC = oERDB.cini_errormsg(muCon, muErrormsg)
        If iRC <> ERR_OK Then
            InitCTP = iRC
            Exit Function
        End If
        iRC = oERDB.cini_order(muCon, muOrder)
        If iRC <> ERR_OK Then
            InitCTP = iRC
            Exit Function
        End If
        iRC = oERDB.cini_ordlineitem(muCon, muOrdLineItem)
        If iRC <> ERR_OK Then
            InitCTP = iRC
            Exit Function
        End If
        iRC = oERDB.cini_ordwaithrs(muCon, muOrdWait)
        If iRC <> ERR_OK Then
            InitCTP = iRC
            Exit Function
        End If
        iRC = oERDB.cini_bom22prt(muCon, muBOM22Prt)
        If iRC <> ERR_OK Then
            InitCTP = iRC
            Exit Function
        End If
        iRC = oERDB.cini_ord22mpn(muCon, muOrd22Mpn)
        If iRC <> ERR_OK Then
            InitCTP = iRC
            Exit Function
        End If
        iRC = oERDB.cini_mpn22opn(muCon, muMpn22Opn)
        If iRC <> ERR_OK Then
            InitCTP = iRC
            Exit Function
        End If
        iRC = oERDB.cini_mpn22ipn(muCon, muMpn22Ipn)
        If iRC <> ERR_OK Then
            InitCTP = iRC
            Exit Function
        End If
        iRC = oERDB.cini_matlplan(muCon, muMatlplan)
        If iRC <> ERR_OK Then
            InitCTP = iRC
            Exit Function
        End If
        iRC = oERDB.cini_matlplan(muCon, muMatlplanSup)
        If iRC <> ERR_OK Then
            InitCTP = iRC
            Exit Function
        End If
        iRC = oERDB.cini_invplan(muCon, muInvplan)
        If iRC <> ERR_OK Then
            InitCTP = iRC
            Exit Function
        End If
        iRC = oERDB.cini_invplan(muCon, muInvplanSup)
        If iRC <> ERR_OK Then
            InitCTP = iRC
            Exit Function
        End If
        iRC = oERDB.cini_operplan(muCon, muOperplan)
        If iRC <> ERR_OK Then
            InitCTP = iRC
            Exit Function
        End If
        iRC = oERDB.cini_opn22res(muCon, muOpn22Res)
        If iRC <> ERR_OK Then
            InitCTP = iRC
            Exit Function
        End If
        iRC = oERDB.cini_operation(muCon, muOperation)
        If iRC <> ERR_OK Then
            InitCTP = iRC
            Exit Function
        End If
        iRC = oERDB.cini_part(muCon, muPart)
        If iRC <> ERR_OK Then
            InitCTP = iRC
            Exit Function
        End If
        iRC = oERDB.cini_resource(muCon, muResource)
        If iRC <> ERR_OK Then
            InitCTP = iRC
            Exit Function
        End If
        iRC = oERDB.cini_category(muCon, muCategory)
        If iRC <> ERR_OK Then
            InitCTP = iRC
            Exit Function
        End If
        iRC = oERDB.cini_opr22cat(muCon, muOpr22Cat)
        If iRC <> ERR_OK Then
            InitCTP = iRC
            Exit Function
        End If
        iRC = oERDB.cini_cat22res(muCon, muCat22Res)
        If iRC <> ERR_OK Then
            InitCTP = iRC
            Exit Function
        End If
        iRC = oERDB.cini_res22shf(muCon, muRes22Shf)
        If iRC <> ERR_OK Then
            InitCTP = iRC
            Exit Function
        End If

        InitCTP = ERR_OK

    End Function

    Private Function Detail2DetailXML(ByRef oRefNode As XmlNode,
                                      ByRef oRefDoc As XmlDocument,
                                      ByRef rsDetailXML As String,
                                      ByRef ruDetail As uOrdDetail) As Integer

        Dim oDetailDOM As New XmlDocument
        Dim oNode As XmlNode
        Dim oParentNode As XmlNode
        Dim oLeafNode As XmlNode
        Dim oOperDetailNode As XmlNode
        Dim oOperGrpNode As XmlNode
        Dim oGrpResNode As XmlNode
        Dim oInvDetailNode As XmlNode
        Dim oResUsageNode As XmlNode
        Dim oListOfLeavesNode As XmlNode
        Dim oListOfOperDetailNode As XmlNode
        Dim oListOfOperGrpNode As XmlNode
        Dim oListOfGrpResNode As XmlNode
        Dim oListOfInvDetailNode As XmlNode
        Dim oListOfResUsageNode As XmlNode
        Dim lIndex2 As Integer
        Dim lIndex3 As Integer
        Dim lIndex4 As Integer
        Dim lIndex5 As Integer
        Dim lIndex6 As Integer
        Dim lLeafIndex As Integer
        Dim lOperDetailIndex As Integer
        Dim lOperGrpIndex As Integer
        Dim lResUsageIndex As Integer
        Dim lInvDetailIndex As Integer

        On Error GoTo Detail2DetailXMLErrorHandler

        ' Create root tag
        If oRefDoc Is Nothing Or oRefNode Is Nothing Then
            oParentNode = oDetailDOM.CreateElement("Detail")
            oDetailDOM.AppendChild(oParentNode)
        Else
            oDetailDOM = oRefDoc
            oParentNode = oRefNode
        End If

        ' Add details elements
        oNode = oDetailDOM.CreateElement("SiteID")
        oNode.InnerText = ruDetail.sSiteID
        oParentNode.AppendChild(oNode)
        oNode = oDetailDOM.CreateElement("OrderID")
        oNode.InnerText = ruDetail.sOrderID
        oParentNode.AppendChild(oNode)
        oNode = oDetailDOM.CreateElement("OrderDescr")
        oNode.InnerText = ruDetail.sOrderDescr
        oParentNode.AppendChild(oNode)
        oNode = oDetailDOM.CreateElement("DemandID")
        oNode.InnerText = ruDetail.sDemandID
        oParentNode.AppendChild(oNode)
        oNode = oDetailDOM.CreateElement("ReqDate")
        oNode.InnerText = MGType.ToInternal(ruDetail.datReqDate)
        oParentNode.AppendChild(oNode)
        oNode = oDetailDOM.CreateElement("PromDate")
        oNode.InnerText = MGType.ToInternal(ruDetail.datPromDate)
        oParentNode.AppendChild(oNode)
        oNode = oDetailDOM.CreateElement("CalcDate")
        oNode.InnerText = MGType.ToInternal(ruDetail.datCalcDate)
        oParentNode.AppendChild(oNode)
        oNode = oDetailDOM.CreateElement("StartDate")
        oNode.InnerText = MGType.ToInternal(ruDetail.datStartDate)
        oParentNode.AppendChild(oNode)
        oNode = oDetailDOM.CreateElement("PlannerStartDate")
        oNode.InnerText = MGType.ToInternal(ruDetail.datPlannerStartDate)
        oParentNode.AppendChild(oNode)
        oNode = oDetailDOM.CreateElement("Lateness")
        oNode.InnerText = MGType.ToInternal(ruDetail.dLateness)
        oParentNode.AppendChild(oNode)
        oNode = oDetailDOM.CreateElement("MaxTag")
        oNode.InnerText = MGType.ToInternal(ruDetail.lMaximumMatlTag)
        oParentNode.AppendChild(oNode)
        oNode = oDetailDOM.CreateElement("Debug")
        oNode.InnerText = ""
        oParentNode.AppendChild(oNode)
        oNode = oDetailDOM.CreateElement("Version")
        oNode.InnerText = "8.03.10"
        oParentNode.AppendChild(oNode)

        ' Add list of leaves
        oNode = oDetailDOM.CreateElement("ListOfLeaves")
        oListOfLeavesNode = oParentNode.AppendChild(oNode)
        For lIndex2 = 1 To ruDetail.lLeafCount
            lLeafIndex = ruDetail.lLeafSort(lIndex2 - 1)
            If Not ruDetail.uLeafList(lLeafIndex).bSkip Then
                oLeafNode = oDetailDOM.CreateElement("Leaf")
                oListOfLeavesNode.AppendChild(oLeafNode)
                oNode = oDetailDOM.CreateElement("MatlTag")
                oNode.InnerText = MGType.ToInternal(ruDetail.uLeafList(lLeafIndex).lMatltag)
                oLeafNode.AppendChild(oNode)
                oNode = oDetailDOM.CreateElement("ParentTag")
                If ruDetail.uLeafList(lLeafIndex).lMatltag <> ruDetail.lMatlTag Then
                    oNode.InnerText = MGType.ToInternal(ruDetail.uLeafList(lLeafIndex).lParentTag)
                Else
                    oNode.InnerText = MGType.ToInternal(0)
                End If
                oLeafNode.AppendChild(oNode)
                oNode = oDetailDOM.CreateElement("LoadID")
                oNode.InnerText = MGType.ToInternal(ruDetail.uLeafList(lLeafIndex).lLoadID)
                oLeafNode.AppendChild(oNode)
                oNode = oDetailDOM.CreateElement("PartID")
                oNode.InnerText = ruDetail.uLeafList(lLeafIndex).sPartID
                oLeafNode.AppendChild(oNode)
                oNode = oDetailDOM.CreateElement("PartDescr")
                oNode.InnerText = ruDetail.uLeafList(lLeafIndex).sPartDescr
                oLeafNode.AppendChild(oNode)
                oNode = oDetailDOM.CreateElement("PartFlags")
                oNode.InnerText = MGType.ToInternal(ruDetail.uLeafList(lLeafIndex).lPartFlags)
                oLeafNode.AppendChild(oNode)
                oNode = oDetailDOM.CreateElement("BomID")
                oNode.InnerText = ruDetail.uLeafList(lLeafIndex).sBomID
                oLeafNode.AppendChild(oNode)
                oNode = oDetailDOM.CreateElement("RouteID")
                oNode.InnerText = ruDetail.uLeafList(lLeafIndex).sRouteID
                oLeafNode.AppendChild(oNode)
                oNode = oDetailDOM.CreateElement("StartDate")
                oNode.InnerText = MGType.ToInternal(ruDetail.uLeafList(lLeafIndex).datStartDate)
                oLeafNode.AppendChild(oNode)
                oNode = oDetailDOM.CreateElement("EndDate")
                oNode.InnerText = MGType.ToInternal(ruDetail.uLeafList(lLeafIndex).datEndDate)
                oLeafNode.AppendChild(oNode)
                oNode = oDetailDOM.CreateElement("Quantity")
                oNode.InnerText = MGType.ToInternal(ruDetail.uLeafList(lLeafIndex).dQuantity)
                oLeafNode.AppendChild(oNode)
                oNode = oDetailDOM.CreateElement("InvQuantity")
                oNode.InnerText = MGType.ToInternal(ruDetail.uLeafList(lLeafIndex).dInvQuantity)
                oLeafNode.AppendChild(oNode)
                oNode = oDetailDOM.CreateElement("SupQuantity")
                oNode.InnerText = MGType.ToInternal(ruDetail.uLeafList(lLeafIndex).dSupQuantity)
                oLeafNode.AppendChild(oNode)
                oNode = oDetailDOM.CreateElement("PurchaseQuantity")
                oNode.InnerText = MGType.ToInternal(ruDetail.uLeafList(lLeafIndex).dPurchaseQuantity)
                oLeafNode.AppendChild(oNode)
                oNode = oDetailDOM.CreateElement("UnconstrainedQuantity")
                oNode.InnerText = MGType.ToInternal(ruDetail.uLeafList(lLeafIndex).dUnconstrainedQuantity)
                oLeafNode.AppendChild(oNode)
                oNode = oDetailDOM.CreateElement("MfgQuantity")
                oNode.InnerText = MGType.ToInternal(ruDetail.uLeafList(lLeafIndex).dMfgQuantity)
                oLeafNode.AppendChild(oNode)
                oNode = oDetailDOM.CreateElement("MergeTo")
                oNode.InnerText = MGType.ToInternal(ruDetail.uLeafList(lLeafIndex).lMergeIdx)
                oLeafNode.AppendChild(oNode)
                oNode = oDetailDOM.CreateElement("WaitTime")
                oNode.InnerText = MGType.ToInternal(ruDetail.uLeafList(lLeafIndex).dWaitTime)
                oLeafNode.AppendChild(oNode)
                oNode = oDetailDOM.CreateElement("SlackTime")
                oNode.InnerText = MGType.ToInternal(ruDetail.uLeafList(lLeafIndex).dSlackTime)
                oLeafNode.AppendChild(oNode)
                oNode = oDetailDOM.CreateElement("Critical")
                If ruDetail.uLeafList(lLeafIndex).bCritDelay Then
                    oNode.InnerText = "True"
                Else
                    oNode.InnerText = "False"
                End If
                oLeafNode.AppendChild(oNode)
                oNode = oDetailDOM.CreateElement("PushCritical")
                If ruDetail.uLeafList(lLeafIndex).bPushCritDelay Then
                    oNode.InnerText = "True"
                Else
                    oNode.InnerText = "False"
                End If
                oLeafNode.AppendChild(oNode)
                oNode = oDetailDOM.CreateElement("ItemDelay")
                If ruDetail.uLeafList(lLeafIndex).bItemDelay Then
                    oNode.InnerText = "True"
                Else
                    oNode.InnerText = "False"
                End If
                oLeafNode.AppendChild(oNode)
                oNode = oDetailDOM.CreateElement("GroupDelay")
                If ruDetail.uLeafList(lLeafIndex).bGroupDelay Then
                    oNode.InnerText = "True"
                Else
                    oNode.InnerText = "False"
                End If
                oLeafNode.AppendChild(oNode)
                oNode = oDetailDOM.CreateElement("FiniteGroupDelay")
                If ruDetail.uLeafList(lLeafIndex).bFiniteGroupDelay Then
                    oNode.InnerText = "True"
                Else
                    oNode.InnerText = "False"
                End If
                oLeafNode.AppendChild(oNode)
                oNode = oDetailDOM.CreateElement("Flags")
                oNode.InnerText = MGType.ToInternal(ruDetail.uLeafList(lLeafIndex).lFlags)
                oLeafNode.AppendChild(oNode)
                oNode = oDetailDOM.CreateElement("FLeadtime")
                oNode.InnerText = MGType.ToInternal(ruDetail.uLeafList(lLeafIndex).dFLeadtime)
                oLeafNode.AppendChild(oNode)
                oNode = oDetailDOM.CreateElement("VLeadtime")
                oNode.InnerText = MGType.ToInternal(ruDetail.uLeafList(lLeafIndex).dVLeadtime)
                oLeafNode.AppendChild(oNode)
                oNode = oDetailDOM.CreateElement("FExpLeadtime")
                oNode.InnerText = MGType.ToInternal(ruDetail.uLeafList(lLeafIndex).dFExpLeadtime)
                oLeafNode.AppendChild(oNode)
                oNode = oDetailDOM.CreateElement("VExpLeadtime")
                oNode.InnerText = MGType.ToInternal(ruDetail.uLeafList(lLeafIndex).dVExpLeadtime)
                oLeafNode.AppendChild(oNode)
                oNode = oDetailDOM.CreateElement("OrdMin")
                oNode.InnerText = MGType.ToInternal(ruDetail.uLeafList(lLeafIndex).dOrdMin)
                oLeafNode.AppendChild(oNode)
                oNode = oDetailDOM.CreateElement("OrdMax")
                oNode.InnerText = MGType.ToInternal(ruDetail.uLeafList(lLeafIndex).dOrdMax)
                oLeafNode.AppendChild(oNode)
                oNode = oDetailDOM.CreateElement("OrdMult")
                oNode.InnerText = MGType.ToInternal(ruDetail.uLeafList(lLeafIndex).dOrdMult)
                oLeafNode.AppendChild(oNode)
                oNode = oDetailDOM.CreateElement("DaysSupply")
                oNode.InnerText = MGType.ToInternal(ruDetail.uLeafList(lLeafIndex).lDaysSupply)
                oLeafNode.AppendChild(oNode)

                ' Add list of inventory detail
                oNode = oDetailDOM.CreateElement("ListOfInvDetail")
                oListOfInvDetailNode = oLeafNode.AppendChild(oNode)
                For lIndex3 = 1 To ruDetail.uLeafList(lLeafIndex).lInvCount
                    lInvDetailIndex = ruDetail.uLeafList(lLeafIndex).lInvSort(lIndex3 - 1)
                    oInvDetailNode = oDetailDOM.CreateElement("InvDetail")
                    oListOfInvDetailNode.AppendChild(oInvDetailNode)
                    oNode = oDetailDOM.CreateElement("SchType")
                    oNode.InnerText = MGType.ToInternal(ruDetail.uLeafList(lLeafIndex).uInvList(lInvDetailIndex).lSchType)
                    oInvDetailNode.AppendChild(oNode)
                    oNode = oDetailDOM.CreateElement("SchFlags")
                    oNode.InnerText = MGType.ToInternal(ruDetail.uLeafList(lLeafIndex).uInvList(lInvDetailIndex).lSchFlags)
                    oInvDetailNode.AppendChild(oNode)
                    oNode = oDetailDOM.CreateElement("InvDate")
                    oNode.InnerText = MGType.ToInternal(ruDetail.uLeafList(lLeafIndex).uInvList(lInvDetailIndex).datInvDate)
                    oInvDetailNode.AppendChild(oNode)
                    oNode = oDetailDOM.CreateElement("ReqDate")
                    oNode.InnerText = MGType.ToInternal(ruDetail.uLeafList(lLeafIndex).uInvList(lInvDetailIndex).datReqDate)
                    oInvDetailNode.AppendChild(oNode)
                    oNode = oDetailDOM.CreateElement("SupplyDate")
                    oNode.InnerText = MGType.ToInternal(ruDetail.uLeafList(lLeafIndex).uInvList(lInvDetailIndex).datSupplyDate)
                    oInvDetailNode.AppendChild(oNode)
                    oNode = oDetailDOM.CreateElement("OrderID")
                    oNode.InnerText = ruDetail.uLeafList(lLeafIndex).uInvList(lInvDetailIndex).sOrderID
                    oInvDetailNode.AppendChild(oNode)
                    oNode = oDetailDOM.CreateElement("SupplyID")
                    oNode.InnerText = ruDetail.uLeafList(lLeafIndex).uInvList(lInvDetailIndex).sSupplyID
                    oInvDetailNode.AppendChild(oNode)
                    oNode = oDetailDOM.CreateElement("SupMatlTag")
                    oNode.InnerText = MGType.ToInternal(ruDetail.uLeafList(lLeafIndex).uInvList(lInvDetailIndex).lSupMatlTag)
                    oInvDetailNode.AppendChild(oNode)
                    oNode = oDetailDOM.CreateElement("Demand")
                    oNode.InnerText = MGType.ToInternal(ruDetail.uLeafList(lLeafIndex).uInvList(lInvDetailIndex).dDemand)
                    oInvDetailNode.AppendChild(oNode)
                    oNode = oDetailDOM.CreateElement("Supply")
                    oNode.InnerText = MGType.ToInternal(ruDetail.uLeafList(lLeafIndex).uInvList(lInvDetailIndex).dSupply)
                    oInvDetailNode.AppendChild(oNode)
                    oNode = oDetailDOM.CreateElement("Expedited")
                    oNode.InnerText = MGType.ToInternal(ruDetail.uLeafList(lLeafIndex).uInvList(lInvDetailIndex).dExpedited)
                    oInvDetailNode.AppendChild(oNode)
                    oNode = oDetailDOM.CreateElement("RemoteSite")
                    oNode.InnerText = ruDetail.uLeafList(lLeafIndex).uInvList(lInvDetailIndex).sRemoteSite
                    oInvDetailNode.AppendChild(oNode)
                    oNode = oDetailDOM.CreateElement("SupQty")
                    oNode.InnerText = MGType.ToInternal(ruDetail.uLeafList(lLeafIndex).uInvList(lInvDetailIndex).dSupQty)
                    oInvDetailNode.AppendChild(oNode)
                Next lIndex3

                ' Add list of operations
                oNode = oDetailDOM.CreateElement("ListOfOperDetail")
                oListOfOperDetailNode = oLeafNode.AppendChild(oNode)
                For lIndex3 = 1 To ruDetail.uLeafList(lLeafIndex).lOperCount
                    lOperDetailIndex = ruDetail.uLeafList(lLeafIndex).lOperSort(lIndex3 - 1)
                    oOperDetailNode = oDetailDOM.CreateElement("OperDetail")
                    oListOfOperDetailNode.AppendChild(oOperDetailNode)
                    oNode = oDetailDOM.CreateElement("OperID")
                    oNode.InnerText = ruDetail.uLeafList(lLeafIndex).uOperList(lOperDetailIndex).sOperID
                    oOperDetailNode.AppendChild(oNode)
                    oNode = oDetailDOM.CreateElement("OperDescr")
                    oNode.InnerText = ruDetail.uLeafList(lLeafIndex).uOperList(lOperDetailIndex).sOperDescr
                    oOperDetailNode.AppendChild(oNode)
                    oNode = oDetailDOM.CreateElement("Seqno")
                    oNode.InnerText = MGType.ToInternal(ruDetail.uLeafList(lLeafIndex).uOperList(lOperDetailIndex).lSeqno)
                    oOperDetailNode.AppendChild(oNode)
                    oNode = oDetailDOM.CreateElement("StartDate")
                    oNode.InnerText = MGType.ToInternal(ruDetail.uLeafList(lLeafIndex).uOperList(lOperDetailIndex).datStartDate)
                    oOperDetailNode.AppendChild(oNode)
                    oNode = oDetailDOM.CreateElement("EndDate")
                    oNode.InnerText = MGType.ToInternal(ruDetail.uLeafList(lLeafIndex).uOperList(lOperDetailIndex).datEndDate)
                    oOperDetailNode.AppendChild(oNode)
                    oNode = oDetailDOM.CreateElement("Quantity")
                    oNode.InnerText = MGType.ToInternal(ruDetail.uLeafList(lLeafIndex).uOperList(lOperDetailIndex).dQuantity)
                    oOperDetailNode.AppendChild(oNode)
                    oNode = oDetailDOM.CreateElement("WIPQuantity")
                    oNode.InnerText = MGType.ToInternal(ruDetail.uLeafList(lLeafIndex).uOperList(lOperDetailIndex).dWIPQuantity)
                    oOperDetailNode.AppendChild(oNode)
                    oNode = oDetailDOM.CreateElement("Critical")
                    If ruDetail.uLeafList(lLeafIndex).uOperList(lOperDetailIndex).bCritDelay Then
                        oNode.InnerText = "True"
                    Else
                        oNode.InnerText = "False"
                    End If
                    oOperDetailNode.AppendChild(oNode)
                    oNode = oDetailDOM.CreateElement("PushCritical")
                    If ruDetail.uLeafList(lLeafIndex).uOperList(lOperDetailIndex).bPushCritDelay Then
                        oNode.InnerText = "True"
                    Else
                        oNode.InnerText = "False"
                    End If
                    oOperDetailNode.AppendChild(oNode)
                    oNode = oDetailDOM.CreateElement("ItemDelay")
                    If ruDetail.uLeafList(lLeafIndex).uOperList(lOperDetailIndex).bItemDelay Then
                        oNode.InnerText = "True"
                    Else
                        oNode.InnerText = "False"
                    End If
                    oOperDetailNode.AppendChild(oNode)
                    oNode = oDetailDOM.CreateElement("GroupDelay")
                    If ruDetail.uLeafList(lLeafIndex).uOperList(lOperDetailIndex).bGroupDelay Then
                        oNode.InnerText = "True"
                    Else
                        oNode.InnerText = "False"
                    End If
                    oOperDetailNode.AppendChild(oNode)
                    oNode = oDetailDOM.CreateElement("FiniteGroupDelay")
                    If ruDetail.uLeafList(lLeafIndex).uOperList(lOperDetailIndex).bFiniteGroupDelay Then
                        oNode.InnerText = "True"
                    Else
                        oNode.InnerText = "False"
                    End If
                    oOperDetailNode.AppendChild(oNode)
                    oNode = oDetailDOM.CreateElement("Workcenter")
                    oNode.InnerText = ruDetail.uLeafList(lLeafIndex).uOperList(lOperDetailIndex).sWorkcenter
                    oOperDetailNode.AppendChild(oNode)
                    oNode = oDetailDOM.CreateElement("Duration")
                    oNode.InnerText = MGType.ToInternal(ruDetail.uLeafList(lLeafIndex).uOperList(lOperDetailIndex).dDuration)
                    oOperDetailNode.AppendChild(oNode)

                    ' Add list of resource groups
                    oNode = oDetailDOM.CreateElement("ListOfOperGrp")
                    oListOfOperGrpNode = oOperDetailNode.AppendChild(oNode)
                    For lIndex4 = 1 To ruDetail.uLeafList(lLeafIndex).uOperList(lOperDetailIndex).lGrpCount
                        lOperGrpIndex = ruDetail.uLeafList(lLeafIndex).uOperList(lOperDetailIndex).lGrpSort(lIndex4 - 1)
                        oOperGrpNode = oDetailDOM.CreateElement("OperGrp")
                        oListOfOperGrpNode.AppendChild(oOperGrpNode)
                        oNode = oDetailDOM.CreateElement("GroupID")
                        oNode.InnerText = ruDetail.uLeafList(lLeafIndex).uOperList(lOperDetailIndex).uGrpList(lOperGrpIndex).sGroupID
                        oOperGrpNode.AppendChild(oNode)
                        oNode = oDetailDOM.CreateElement("GroupDescr")
                        oNode.InnerText = ruDetail.uLeafList(lLeafIndex).uOperList(lOperDetailIndex).uGrpList(lOperGrpIndex).sGroupDescr
                        oOperGrpNode.AppendChild(oNode)
                        oNode = oDetailDOM.CreateElement("WaitTime")
                        oNode.InnerText = MGType.ToInternal(ruDetail.uLeafList(lLeafIndex).uOperList(lOperDetailIndex).uGrpList(lOperGrpIndex).dWaitTime)
                        oOperGrpNode.AppendChild(oNode)
                        oNode = oDetailDOM.CreateElement("PushWait")
                        oNode.InnerText = MGType.ToInternal(ruDetail.uLeafList(lLeafIndex).uOperList(lOperDetailIndex).uGrpList(lOperGrpIndex).dPushWait)
                        oOperGrpNode.AppendChild(oNode)
                        oNode = oDetailDOM.CreateElement("FiniteGroup")
                        If ruDetail.uLeafList(lLeafIndex).uOperList(lOperDetailIndex).uGrpList(lOperGrpIndex).bFiniteGroup Then
                            oNode.InnerText = "True"
                        Else
                            oNode.InnerText = "False"
                        End If
                        oOperGrpNode.AppendChild(oNode)
                        oNode = oDetailDOM.CreateElement("Labor")
                        If ruDetail.uLeafList(lLeafIndex).uOperList(lOperDetailIndex).uGrpList(lOperGrpIndex).bLaborGroup Then
                            oNode.InnerText = "True"
                        Else
                            oNode.InnerText = "False"
                        End If
                        oOperGrpNode.AppendChild(oNode)
                        oNode = oDetailDOM.CreateElement("Members")
                        oNode.InnerText = MGType.ToInternal(ruDetail.uLeafList(lLeafIndex).uOperList(lOperDetailIndex).uGrpList(lOperGrpIndex).lMembers)
                        oOperGrpNode.AppendChild(oNode)

                        oNode = oDetailDOM.CreateElement("ListOfGrpRes")
                        oListOfGrpResNode = oOperGrpNode.AppendChild(oNode)
                        For lIndex5 = 0 To ruDetail.uLeafList(lLeafIndex).uOperList(lOperDetailIndex).uGrpList(lOperGrpIndex).lResCount - 1
                            oGrpResNode = oDetailDOM.CreateElement("GrpRes")
                            oListOfGrpResNode.AppendChild(oGrpResNode)
                            oNode = oDetailDOM.CreateElement("ResrcID")
                            oNode.InnerText = ruDetail.uLeafList(lLeafIndex).uOperList(lOperDetailIndex).uGrpList(lOperGrpIndex).uResList(lIndex5).sResrcID
                            oGrpResNode.AppendChild(oNode)
                            oNode = oDetailDOM.CreateElement("ResrcDescr")
                            oNode.InnerText = ruDetail.uLeafList(lLeafIndex).uOperList(lOperDetailIndex).uGrpList(lOperGrpIndex).uResList(lIndex5).sResrcDescr
                            oGrpResNode.AppendChild(oNode)
                            oNode = oDetailDOM.CreateElement("ShiftID1")
                            oNode.InnerText = ruDetail.uLeafList(lLeafIndex).uOperList(lOperDetailIndex).uGrpList(lOperGrpIndex).uResList(lIndex5).sShift1
                            oGrpResNode.AppendChild(oNode)
                            oNode = oDetailDOM.CreateElement("ShiftID2")
                            oNode.InnerText = ruDetail.uLeafList(lLeafIndex).uOperList(lOperDetailIndex).uGrpList(lOperGrpIndex).uResList(lIndex5).sShift2
                            oGrpResNode.AppendChild(oNode)
                            oNode = oDetailDOM.CreateElement("ShiftID3")
                            oNode.InnerText = ruDetail.uLeafList(lLeafIndex).uOperList(lOperDetailIndex).uGrpList(lOperGrpIndex).uResList(lIndex5).sShift3
                            oGrpResNode.AppendChild(oNode)
                            oNode = oDetailDOM.CreateElement("ShiftID4")
                            oNode.InnerText = ruDetail.uLeafList(lLeafIndex).uOperList(lOperDetailIndex).uGrpList(lOperGrpIndex).uResList(lIndex5).sShift4
                            oGrpResNode.AppendChild(oNode)

                            oNode = oDetailDOM.CreateElement("ListOfResUsage")
                            oListOfResUsageNode = oGrpResNode.AppendChild(oNode)
                            For lIndex6 = 0 To ruDetail.uLeafList(lLeafIndex).uOperList(lOperDetailIndex).uGrpList(lOperGrpIndex).uResList(lIndex5).lUsageCount - 1
                                oResUsageNode = oDetailDOM.CreateElement("ResUsage")
                                oListOfResUsageNode.AppendChild(oResUsageNode)
                                oNode = oDetailDOM.CreateElement("UsageType")
                                oNode.InnerText = MGType.ToInternal(ruDetail.uLeafList(lLeafIndex).uOperList(lOperDetailIndex).uGrpList(lOperGrpIndex).uResList(lIndex5).uUsageList(lIndex6).lUsageType)
                                oResUsageNode.AppendChild(oNode)
                                oNode = oDetailDOM.CreateElement("StartDate")
                                oNode.InnerText = MGType.ToInternal(ruDetail.uLeafList(lLeafIndex).uOperList(lOperDetailIndex).uGrpList(lOperGrpIndex).uResList(lIndex5).uUsageList(lIndex6).datStartDate)
                                oResUsageNode.AppendChild(oNode)
                                oNode = oDetailDOM.CreateElement("EndDate")
                                oNode.InnerText = MGType.ToInternal(ruDetail.uLeafList(lLeafIndex).uOperList(lOperDetailIndex).uGrpList(lOperGrpIndex).uResList(lIndex5).uUsageList(lIndex6).datEndDate)
                                oResUsageNode.AppendChild(oNode)
                            Next lIndex6
                        Next lIndex5
                    Next lIndex4
                Next lIndex3
            End If
        Next lIndex2

        ' Return response XML
        If oRefDoc Is Nothing Or oRefNode Is Nothing Then
            rsDetailXML = oDetailDOM.OuterXml
        End If

        Detail2DetailXML = ERR_OK
        Exit Function

Detail2DetailXMLErrorHandler:
        Detail2DetailXML = ERR_VBRT
        msStatus = "SLCtps.Detail2DetailXML():" & "  Internal error " & Err.Number & " - " & Err.Description

    End Function

    Private Function Response2ResponseXML(ByRef rsResponseXML As String,
                                          ByRef ruResponse As uCTPResponse) As Integer
        Dim oResponseDOM As New XmlDocument
        Dim oNode As XmlNode
        Dim oParentNode As XmlNode
        Dim oListOfLineItemsNode As XmlNode
        Dim oLineItemNode As XmlNode
        Dim iRC As Integer
        Dim lIndex1 As Integer
        Dim sDetailXML As String = ""

        On Error GoTo Response2ResponseXMLErrorHandler

        ' Create root tags
        oNode = oResponseDOM.CreateElement("CTPResponse")
        oResponseDOM.AppendChild(oNode)
        oListOfLineItemsNode = oResponseDOM.CreateElement("ListOfLineItems")
        oResponseDOM.DocumentElement.AppendChild(oListOfLineItemsNode)

        ' Add line items
        For lIndex1 = 1 To ruResponse.lLineItemCount

            ' Add line item element
            oLineItemNode = oResponseDOM.CreateElement("LineItem")
            oListOfLineItemsNode.AppendChild(oLineItemNode)

            ' Add request element
            oNode = oResponseDOM.CreateElement("Request")
            oParentNode = oLineItemNode.AppendChild(oNode)
            oNode = oResponseDOM.CreateElement("SiteID")
            oNode.InnerText = ruResponse.uLineItemList(lIndex1 - 1).uRequest.sSiteID
            oParentNode.AppendChild(oNode)
            oNode = oResponseDOM.CreateElement("WhseID")
            oNode.InnerText = ruResponse.uLineItemList(lIndex1 - 1).uRequest.sWhseID
            oParentNode.AppendChild(oNode)
            oNode = oResponseDOM.CreateElement("OrderID")
            oNode.InnerText = ruResponse.uLineItemList(lIndex1 - 1).uRequest.sOrderID
            oParentNode.AppendChild(oNode)
            oNode = oResponseDOM.CreateElement("ItemID")
            oNode.InnerText = ruResponse.uLineItemList(lIndex1 - 1).uRequest.sItemid
            oParentNode.AppendChild(oNode)
            oNode = oResponseDOM.CreateElement("Quantity")
            oNode.InnerText = MGType.ToInternal(ruResponse.uLineItemList(lIndex1 - 1).uRequest.dQuantity)
            oParentNode.AppendChild(oNode)
            oNode = oResponseDOM.CreateElement("RequestDate")
            oNode.InnerText = MGType.ToInternal(ruResponse.uLineItemList(lIndex1 - 1).uRequest.datRequestDate)
            oParentNode.AppendChild(oNode)
            oNode = oResponseDOM.CreateElement("DueDate")
            oNode.InnerText = MGType.ToInternal(ruResponse.uLineItemList(lIndex1 - 1).uRequest.datDueDate)
            oParentNode.AppendChild(oNode)
            oNode = oResponseDOM.CreateElement("Category")
            oNode.InnerText = CStr(ruResponse.uLineItemList(lIndex1 - 1).uRequest.lCategory)
            oParentNode.AppendChild(oNode)
            oNode = oResponseDOM.CreateElement("Flags")
            oNode.InnerText = CStr(ruResponse.uLineItemList(lIndex1 - 1).uRequest.lFlags)
            oParentNode.AppendChild(oNode)
            oNode = oResponseDOM.CreateElement("Flags2")
            oNode.InnerText = CStr(ruResponse.uLineItemList(lIndex1 - 1).uRequest.lFlags2)
            oParentNode.AppendChild(oNode)

            ' Add quantities element
            If ruResponse.bQuantities And (lIndex1 = ruResponse.lLineItemCount) Then
                oNode = oResponseDOM.CreateElement("Quantities")
                oParentNode = oLineItemNode.AppendChild(oNode)
                oNode = oResponseDOM.CreateElement("QtyOnHand")
                oNode.InnerText = MGType.ToInternal(ruResponse.uLineItemList(lIndex1 - 1).uQuantities.dQtyOnHand)
                oParentNode.AppendChild(oNode)
                oNode = oResponseDOM.CreateElement("QtyInv")
                oNode.InnerText = MGType.ToInternal(ruResponse.uLineItemList(lIndex1 - 1).uQuantities.dQtyInv)
                oParentNode.AppendChild(oNode)
                oNode = oResponseDOM.CreateElement("QtyShip")
                oNode.InnerText = MGType.ToInternal(ruResponse.uLineItemList(lIndex1 - 1).uQuantities.dQtyShip)
                oParentNode.AppendChild(oNode)
                oNode = oResponseDOM.CreateElement("QtyMfg")
                oNode.InnerText = MGType.ToInternal(ruResponse.uLineItemList(lIndex1 - 1).uQuantities.dQtyMfg)
                oParentNode.AppendChild(oNode)
            End If

            ' Add details element
            If ruResponse.bDetails And (lIndex1 = ruResponse.lLineItemCount) Then
                oNode = oResponseDOM.CreateElement("Detail")
                oLineItemNode.AppendChild(oNode)
                iRC = Detail2DetailXML(oNode, oResponseDOM, sDetailXML, ruResponse.uLineItemList(lIndex1 - 1).uDetail)
                If iRC <> ERR_OK Then
                    Response2ResponseXML = iRC
                    Exit Function
                End If
            End If

            ' Add projected date
            oNode = oResponseDOM.CreateElement("CalcDate")
            oNode.InnerText = MGType.ToInternal(ruResponse.uLineItemList(lIndex1 - 1).datCalcDate)
            oLineItemNode.AppendChild(oNode)

            ' Add start date (used for Job Orders)
            oNode = oResponseDOM.CreateElement("StartDate")
            oNode.InnerText = MGType.ToInternal(ruResponse.uLineItemList(lIndex1 - 1).datStartDate)
            oLineItemNode.AppendChild(oNode)

            ' Add return code
            oNode = oResponseDOM.CreateElement("ReturnCode")
            oNode.InnerText = CStr(ruResponse.uLineItemList(lIndex1 - 1).lReturnCode)
            oLineItemNode.AppendChild(oNode)

        Next lIndex1

        ' Add flags
        oNode = oResponseDOM.CreateElement("Details")
        If ruResponse.bDetails Then
            oNode.InnerText = "True"
        Else
            oNode.InnerText = "False"
        End If
        oResponseDOM.DocumentElement.AppendChild(oNode)
        oNode = oResponseDOM.CreateElement("Quantities")
        If ruResponse.bQuantities Then
            oNode.InnerText = "True"
        Else
            oNode.InnerText = "False"
        End If
        oResponseDOM.DocumentElement.AppendChild(oNode)

        ' Return response XML
        rsResponseXML = oResponseDOM.OuterXml

        Response2ResponseXML = ERR_OK
        Exit Function

Response2ResponseXMLErrorHandler:
        Response2ResponseXML = ERR_VBRT
        msStatus = "SLCtps.Response2ResponseXML():" & "  Internal error " & Err.Number & " - " & Err.Description

    End Function

    Private Function RequestXML2Request(ByRef rsRequestXML As String,
                                        ByRef ruRequest As uCTPRequest) As Integer
        Dim oRequestDOM As New XmlDocument
        Dim oNode As XmlNode
        Dim oLineItemNode As XmlNode
        Dim oNodeList As XmlNodeList
        Dim iIndex As Integer

        ' Load DOM with request XML
        oRequestDOM.LoadXml(rsRequestXML)

        ' Check for flags
        ruRequest.bDetails = False
        oNode = oRequestDOM.SelectSingleNode("/CTPRequest/Details")
        If Not oNode Is Nothing Then
            If LCase(oNode.InnerText) = "true" Then
                ruRequest.bDetails = True
            End If
        End If
        ruRequest.bQuantities = False
        oNode = oRequestDOM.SelectSingleNode("/CTPRequest/Quantities")
        If Not oNode Is Nothing Then
            If LCase(oNode.InnerText) = "true" Then
                ruRequest.bQuantities = True
            End If
        End If
        ruRequest.bDisableExpedite = False
        oNode = oRequestDOM.SelectSingleNode("/CTPRequest/DisableExpedite")
        If Not oNode Is Nothing Then
            If LCase(oNode.InnerText) = "true" Then
                ruRequest.bDisableExpedite = True
            End If
        End If

        ' Get line items
        ruRequest.lLineItemCount = 0
        oNodeList = oRequestDOM.SelectNodes("/CTPRequest/ListOfLineItems/LineItem")
        If Not oNodeList Is Nothing Then
            ruRequest.lLineItemCount = oNodeList.Count
            If oNodeList.Count > 0 Then
                ReDim ruRequest.uLineItemList(ruRequest.lLineItemCount - 1)
            End If
            iIndex = 0
            For Each oLineItemNode In oNodeList
                oNode = oLineItemNode.SelectSingleNode("SiteID")
                If oNode Is Nothing Then
                    RequestXML2Request = ERR_BADREQUESTXML
                    msStatus = CTPErrorMsg(ERR_BADREQUESTXML)
                    Exit Function
                End If
                ruRequest.uLineItemList(iIndex).sSiteID = RTrim(oNode.InnerText)
                oNode = oLineItemNode.SelectSingleNode("AltNo")
                If oNode Is Nothing Then
                    ruRequest.uLineItemList(iIndex).lAltNo = 0
                Else
                    ruRequest.uLineItemList(iIndex).lAltNo = MGType.FromInternal(Of Integer)(oNode.InnerText)
                End If
                oNode = oLineItemNode.SelectSingleNode("WhseID")
                If oNode Is Nothing Then
                    ruRequest.uLineItemList(iIndex).sWhseID = ""
                Else
                    ruRequest.uLineItemList(iIndex).sWhseID = RTrim(oNode.InnerText)
                End If
                oNode = oLineItemNode.SelectSingleNode("OrderID")
                If oNode Is Nothing Then
                    RequestXML2Request = ERR_BADREQUESTXML
                    msStatus = CTPErrorMsg(ERR_BADREQUESTXML)
                    Exit Function
                End If
                ruRequest.uLineItemList(iIndex).sOrderID = RTrim(oNode.InnerText)
                oNode = oLineItemNode.SelectSingleNode("RefOrderID")
                If oNode Is Nothing Then
                    ruRequest.uLineItemList(iIndex).sRefOrderID = ""
                Else
                    ruRequest.uLineItemList(iIndex).sRefOrderID = RTrim(oNode.InnerText)
                End If
                oNode = oLineItemNode.SelectSingleNode("ItemID")
                If oNode Is Nothing Then
                    RequestXML2Request = ERR_BADREQUESTXML
                    msStatus = CTPErrorMsg(ERR_BADREQUESTXML)
                    Exit Function
                End If
                ruRequest.uLineItemList(iIndex).sItemid = RTrim(oNode.InnerText)
                oNode = oLineItemNode.SelectSingleNode("Quantity")
                If oNode Is Nothing Then
                    RequestXML2Request = ERR_BADREQUESTXML
                    msStatus = CTPErrorMsg(ERR_BADREQUESTXML)
                    Exit Function
                End If
                ruRequest.uLineItemList(iIndex).dQuantity = MGType.FromInternal(Of Double)(oNode.InnerText)
                oNode = oLineItemNode.SelectSingleNode("RequestDate")
                If oNode Is Nothing Then
                    RequestXML2Request = ERR_BADREQUESTXML
                    msStatus = CTPErrorMsg(ERR_BADREQUESTXML)
                    Exit Function
                End If
                ruRequest.uLineItemList(iIndex).datRequestDate = MGType.FromInternal(Of Date)(oNode.InnerText)
                oNode = oLineItemNode.SelectSingleNode("DueDate")
                If oNode Is Nothing Then
                    RequestXML2Request = ERR_BADREQUESTXML
                    msStatus = CTPErrorMsg(ERR_BADREQUESTXML)
                    Exit Function
                End If
                ruRequest.uLineItemList(iIndex).datDueDate = MGType.FromInternal(Of Date)(oNode.InnerText)
                oNode = oLineItemNode.SelectSingleNode("Category")
                If oNode Is Nothing Then
                    RequestXML2Request = ERR_BADREQUESTXML
                    msStatus = CTPErrorMsg(ERR_BADREQUESTXML)
                    Exit Function
                End If
                ruRequest.uLineItemList(iIndex).lCategory = MGType.FromInternal(Of Integer)(oNode.InnerText)
                oNode = oLineItemNode.SelectSingleNode("OrdType")
                If oNode Is Nothing Then
                    ruRequest.uLineItemList(iIndex).lOrdType = 0
                Else
                    ruRequest.uLineItemList(iIndex).lOrdType = MGType.FromInternal(Of Integer)(oNode.InnerText)
                End If
                oNode = oLineItemNode.SelectSingleNode("Flags")
                If oNode Is Nothing Then
                    RequestXML2Request = ERR_BADREQUESTXML
                    msStatus = CTPErrorMsg(ERR_BADREQUESTXML)
                    Exit Function
                End If
                ruRequest.uLineItemList(iIndex).lFlags = MGType.FromInternal(Of Integer)(oNode.InnerText)
                oNode = oLineItemNode.SelectSingleNode("Flags2")
                If oNode Is Nothing Then
                    ruRequest.uLineItemList(iIndex).lFlags2 = 0 ' Make this element optional
                Else
                    ruRequest.uLineItemList(iIndex).lFlags2 = MGType.FromInternal(Of Integer)(oNode.InnerText)
                End If
                iIndex = iIndex + 1
            Next
        End If

        RequestXML2Request = ERR_OK

    End Function

    Private Function ProcessCTP(ByRef ruRequest As uCTPRequest,
                                ByRef ruResponse As uCTPResponse) As Integer
        Dim iRC As Integer
        Dim lProcessedLines As Integer
        Dim lLineIndex As Integer
        Dim lIndex As Integer
        Dim sCurrentSite As String
        Dim sApsHost As String = ""
        Dim lApsPort As Integer = 0
        Dim oCollection As LoadCollectionResponseData
        Dim sProperties As String
        Dim sFilter As String
        Dim datRequestDate As Date
        Dim ApsHostIx As Integer
        Dim ApsPortIx As Integer
        Dim oERDB As New ERDB.Server
        Dim uCtpQty As ctpdetail_s = New ctpdetail_s()
        Dim lRetryCount As Integer

        On Error GoTo ProcessCTPErrorHandler

        ' Mark all lines as unprocessed
        For lLineIndex = 1 To ruRequest.lLineItemCount
            ruRequest.uLineItemList(lLineIndex - 1).bProcessed = False
        Next lLineIndex

        ' Initialize response
        ReDim ruResponse.uLineItemList(ruRequest.lLineItemCount)
        ruResponse.lLineItemCount = ruRequest.lLineItemCount
        ruResponse.bDetails = ruRequest.bDetails
        ruResponse.bQuantities = ruRequest.bQuantities

        ' Treat lines with zero quantity as special cases
        lProcessedLines = 0
        For lLineIndex = 1 To ruRequest.lLineItemCount
            If ruRequest.uLineItemList(lLineIndex - 1).dQuantity <= 0 Then
                ruResponse.uLineItemList(lLineIndex - 1).datCalcDate = ruRequest.uLineItemList(lLineIndex - 1).datDueDate
                ruResponse.uLineItemList(lLineIndex - 1).datStartDate = ruRequest.uLineItemList(lLineIndex - 1).datDueDate
                ruRequest.uLineItemList(lLineIndex - 1).bProcessed = True
                lProcessedLines = lProcessedLines + 1
            End If
        Next lLineIndex

        ' - Line items may be from different sites
        ' - All lines from the same site must be processed together
        ' - Loop until no lines are left unprocessed
        lLineIndex = 0
        sCurrentSite = ""
        Do While lProcessedLines < ruRequest.lLineItemCount

            ' Skip past sites that are already processed
            If Not ruRequest.uLineItemList(lLineIndex).bProcessed Then

                ' New site
                If sCurrentSite = "" Then
                    sCurrentSite = ruRequest.uLineItemList(lLineIndex).sSiteID

                    If TESTING_MODE Then
                        sApsHost = "localhost"
                        lApsPort = 6001
                    Else
                        ' Get host/port of APS server & planner
                        sProperties = "ApsHostName, ApsPortNo"
                        sFilter = "AltNo = " & ruRequest.uLineItemList(lLineIndex).lAltNo & " AND ApsSite = " & SqlLiteral.Format(sCurrentSite)
                        oCollection = Me.Context.Commands.LoadCollection("SL.SLApsSites", sProperties, sFilter, "", 0)
                        If oCollection.Items.Count = 0 Then
                            ProcessCTP = Aps.ServerService.APS_ERR_SITEINFO
                            msStatus = CTPErrorMsg(Aps.ServerService.APS_ERR_SITEINFO, sCurrentSite)
                            Exit Function
                        End If

                        ApsHostIx = oCollection.PropertyList.IndexOf("ApsHostName")
                        ApsPortIx = oCollection.PropertyList.IndexOf("ApsPortNo")

                        For Each item As IDOItem In oCollection.Items
                            sApsHost = item.PropertyValues(ApsHostIx).ToString()
                            lApsPort = item.PropertyValues(ApsPortIx).GetValue(Of Integer)()
                            Exit For
                        Next
                    End If

                    ' Flush ERDB gateway
                    lRetryCount = 0
                    Do
                        iRC = ApsServerInterface.FlushGateway(sApsHost, lApsPort, ruRequest.uLineItemList(lLineIndex).lAltNo)
                        If (iRC = Aps.ServerService.APS_ERR_GWFLUSH Or iRC = Aps.ServerService.APS_ERR_PLANBUSY) And (lRetryCount < CTP_RETRYMAX) Then
                            MGLog.LogMessage("SLCtps.ProcessCTP", LogMessageTypes.Trace, String.Format("FlushGateway() returned status of {0}. Retrying...", iRC))
                            lRetryCount = lRetryCount + 1
                            Threading.Thread.Sleep(5000)
                        Else
                            Exit Do
                        End If
                    Loop
                    If (iRC <> Aps.ServerService.APS_ERR_OK) And (iRC <> Aps.ServerService.APS_ERR_FLUSH) Then
                        ProcessCTP = iRC
                        msStatus = CTPErrorMsg(iRC, "aps_flush_gateway")
                        Exit Function
                    End If

                    ' Connect to APS planner
                    iRC = oERDB.cget_connection(muCon, sApsHost, lApsPort)
                    If iRC <> ERR_OK Then
                        ProcessCTP = iRC
                        msStatus = CTPErrorMsg(iRC, "cget_connection")
                        Exit Function
                    End If

                    ' Create a test database
                    lRetryCount = 0
                    Do
                        iRC = oERDB.cnew_testdb(muCon)
                        If (iRC = ERDB.Server.ERR_APSSTATUS_DOWNLOADING Or iRC = ERDB.Server.ERR_APSSTATUS_INCRPLAN) And (lRetryCount < CTP_RETRYMAX) Then
                            MGLog.LogMessage("SLCtps.ProcessCTP", LogMessageTypes.Trace, String.Format("cnew_testdb() returned status of {0}. Retrying...", iRC))
                            lRetryCount = lRetryCount + 1
                            Threading.Thread.Sleep(5000)
                        Else
                            Exit Do
                        End If
                    Loop
                    If iRC <> ERDB.Server.ERR_OK Then
                        If iRC = ERDB.Server.ERR_PUSHMAX Then
                            Dim iRC2 As Integer
                            iRC2 = oERDB.cini_order(muCon, muOrder)
                            If muOrder.inuse = 0 Then
                                ' If PDB empty, don't report PUSHMAX error
                                iRC = Aps.ServerService.APS_ERR_PDBCONNECT
                            End If
                        End If
                        ProcessCTP = iRC
                        msStatus = CTPErrorMsg(iRC, "cnew_testdb")
                        GoTo ProcessCTPEndConnection
                    End If

                    ' Initialize planner structures
                    iRC = InitCTP()
                    If iRC <> ERR_OK Then
                        ProcessCTP = iRC
                        msStatus = CTPErrorMsg(iRC, "InitCTP")
                        GoTo ProcessCTPEndConnection
                    End If

                    ' Configure miscellaneous flags
                    iRC = oERDB.cget_misc(muCon, muMisc)
                    If iRC <> ERR_OK Then
                        ProcessCTP = iRC
                        msStatus = CTPErrorMsg(iRC, "GetMisc")
                        GoTo ProcessCTPEndConnection
                    End If
                    If mbCtpDebug Then
                        muMisc.algdebuglevel = 65535
                    End If
                    If ruRequest.bDetails Then
                        muMisc.algssiteflags = muMisc.algssiteflags Or ERDB.Server.VAL_ALGSSITEFLAGS_WAITTIMES
                    End If
                    If ruRequest.bDisableExpedite Then
                        muMisc.algssiteflags = muMisc.algssiteflags And (Not ERDB.Server.VAL_ALGSSITEFLAGS_EXPLEADTIME)
                    Else
                        muMisc.algssiteflags = muMisc.algssiteflags Or ERDB.Server.VAL_ALGSSITEFLAGS_EXPLEADTIME
                    End If

                    ' Disable topdown flags for CTP only
                    muMisc.algssiteflags = muMisc.algssiteflags And (Not ERDB.Server.VAL_ALGSSITEFLAGS_TOPDOWNSUBJOBFIRM)
                    muMisc.algssiteflags = muMisc.algssiteflags And (Not ERDB.Server.VAL_ALGSSITEFLAGS_TOPDOWNSUBJOBREL)

                    muMisc.algssiteflags = muMisc.algssiteflags Or ERDB.Server.VAL_ALGSSITEFLAGS_ISATPCTP

                    iRC = oERDB.cedt_misc(muCon, muMisc)
                    If iRC <> ERR_OK Then
                        ProcessCTP = iRC
                        msStatus = CTPErrorMsg(iRC, "cedt_misc")
                        GoTo ProcessCTPEndConnection
                    End If

                    ' If these orders already exist at the site, delete them
                    For lIndex = 1 To ruRequest.lLineItemCount
                        If ruRequest.uLineItemList(lIndex - 1).sSiteID = sCurrentSite Then
                            muOrder.order = Trim$(ruRequest.uLineItemList(lIndex - 1).sOrderID)
                            muOrder.sort = 0
                            iRC = oERDB.cget_order(muCon, muOrder)
                            If iRC = ERR_OK Then
                                ' If the existing order is not a job, but is xref'd to a job, CTP using that xref ID
                                If (Not muOrder.order.EndsWith(".JOB")) And muOrder.ordreforder.EndsWith(".JOB") Then
                                    muOrder.order = muOrder.ordreforder
                                    muOrder.sort = 0
                                    iRC = oERDB.cget_order(muCon, muOrder)
                                    If iRC = ERR_OK Then
                                        ruRequest.uLineItemList(lIndex - 1).sOrderID = muOrder.order
                                        ruRequest.uLineItemList(lIndex - 1).sRefOrderID = ""
                                        ruRequest.uLineItemList(lIndex - 1).lFlags = muOrder.ordflags
                                        iRC = oERDB.cdel_order(muCon, muOrder)
                                        If iRC <> ERR_OK Then
                                            ProcessCTP = iRC
                                            msStatus = CTPErrorMsg(iRC, "cdel_order")
                                            GoTo ProcessCTPEndConnection
                                        End If
                                    End If
                                Else
                                    iRC = oERDB.cdel_order(muCon, muOrder)
                                    If iRC <> ERR_OK Then
                                        ProcessCTP = iRC
                                        msStatus = CTPErrorMsg(iRC, "cdel_order")
                                        GoTo ProcessCTPEndConnection
                                    End If
                                End If
                            End If
                        End If
                    Next lIndex

                End If

                If sCurrentSite = ruRequest.uLineItemList(lLineIndex).sSiteID Then
                    ' Copy request info to response
                    ruResponse.uLineItemList(lLineIndex).uRequest.sSiteID = ruRequest.uLineItemList(lLineIndex).sSiteID
                    ruResponse.uLineItemList(lLineIndex).uRequest.sWhseID = ruRequest.uLineItemList(lLineIndex).sWhseID
                    ruResponse.uLineItemList(lLineIndex).uRequest.sOrderID = ruRequest.uLineItemList(lLineIndex).sOrderID
                    ruResponse.uLineItemList(lLineIndex).uRequest.sItemid = ruRequest.uLineItemList(lLineIndex).sItemid
                    ruResponse.uLineItemList(lLineIndex).uRequest.datRequestDate = ruRequest.uLineItemList(lLineIndex).datRequestDate
                    ruResponse.uLineItemList(lLineIndex).uRequest.datDueDate = ruRequest.uLineItemList(lLineIndex).datDueDate
                    ruResponse.uLineItemList(lLineIndex).uRequest.dQuantity = ruRequest.uLineItemList(lLineIndex).dQuantity
                    ruResponse.uLineItemList(lLineIndex).uRequest.lCategory = ruRequest.uLineItemList(lLineIndex).lCategory
                    ruResponse.uLineItemList(lLineIndex).uRequest.lFlags = ruRequest.uLineItemList(lLineIndex).lFlags
                    ruResponse.uLineItemList(lLineIndex).uRequest.lFlags2 = ruRequest.uLineItemList(lLineIndex).lFlags2

                    ' Set order fields
                    muOrder.order = ruRequest.uLineItemList(lLineIndex).sOrderID
                    muOrder.ordcategory = ruRequest.uLineItemList(lLineIndex).lCategory
                    muOrder.ordtype = ruRequest.uLineItemList(lLineIndex).lOrdType
                    muOrder.ordflags = ruRequest.uLineItemList(lLineIndex).lFlags And (Not ERDB.Server.VAL_ORDFLAGS_NOCTPDUEDATE)
                    muOrder.ordflags2 = ruRequest.uLineItemList(lLineIndex).lFlags2
                    If (ruRequest.uLineItemList(lLineIndex).lFlags And ERDB.Server.VAL_ORDFLAGS_NOCTPDUEDATE) > 0 Then
                        muOrder.ordrequdate = PlannerInterface.iVBDate2OLDate(ruRequest.uLineItemList(lLineIndex).datDueDate)
                        muOrder.ordpromdate = 0
                    Else
                        muOrder.ordrequdate = PlannerInterface.iVBDate2OLDate(ruRequest.uLineItemList(lLineIndex).datRequestDate)
                        muOrder.ordpromdate = PlannerInterface.iVBDate2OLDate(ruRequest.uLineItemList(lLineIndex).datDueDate)
                    End If
                    muOrder.ordarivdate = muOrder.ordrequdate
                    muOrder.ordreforder = ruRequest.uLineItemList(lLineIndex).sRefOrderID
                    muOrder.whse = ruRequest.uLineItemList(lLineIndex).sWhseID

                    ' Add order
                    iRC = oERDB.cadd_order(muCon, muOrder)
                    If iRC <> ERR_OK Then
                        ProcessCTP = iRC
                        msStatus = CTPErrorMsg(iRC, "cadd_order")
                        GoTo ProcessCTPEndConnection
                    End If

                    ' Add lineitem
                    muOrdLineItem.order = muOrder.order
                    muOrdLineItem.ordlineitemidx = 0
                    muOrdLineItem.part = ruRequest.uLineItemList(lLineIndex).sItemid
                    muOrdLineItem.ordlinquantity = ruRequest.uLineItemList(lLineIndex).dQuantity
                    muOrdLineItem.ordlinpromdate = 0
                    muOrdLineItem.ordlincalcdate = 0
                    iRC = oERDB.cadd_ordlineitem(muCon, muOrdLineItem)
                    If iRC <> ERR_OK Then
                        ProcessCTP = iRC
                        msStatus = CTPErrorMsg(iRC, "cadd_ordlineitem")
                        GoTo ProcessCTPEndConnection
                    End If

                    ' Plan order
                    iRC = oERDB.csch_order(muCon, muOrder)
                    If iRC <> ERR_OK Then
                        ProcessCTP = iRC
                        msStatus = CTPErrorMsg(iRC, "csch_order")
                        Call AddErrormsg(msStatus)
                        GoTo ProcessCTPEndConnection
                    End If

                    ' Get planning results (ignore detail flag except on final item)
                    If (lLineIndex = ruRequest.lLineItemCount - 1) Then
                        iRC = GetCTPResults(ruResponse.uLineItemList(lLineIndex), ruRequest.bDetails)
                    Else
                        iRC = GetCTPResults(ruResponse.uLineItemList(lLineIndex), False)
                    End If
                    If iRC <> ERR_OK Then
                        If msStatus = "" Then
                            msStatus = "GetCTPResults() = " & iRC
                        End If
                        ProcessCTP = iRC
                        GoTo ProcessCTPEndConnection
                    End If

                    ' Mark line as processed
                    ruRequest.uLineItemList(lLineIndex).bProcessed = True
                    lProcessedLines = lProcessedLines + 1
                End If

                ' If we've looped back to the first line of a particular site, we're ready for the next site
            ElseIf sCurrentSite = ruRequest.uLineItemList(lLineIndex).sSiteID Then
                sCurrentSite = ""
                iRC = oERDB.cdel_testdb(muCon)
                If iRC <> ERR_OK Then
                    ProcessCTP = iRC
                    msStatus = CTPErrorMsg(iRC, "cdel_testdb")
                    GoTo ProcessCTPEndConnection
                End If
                iRC = oERDB.cdel_connection(muCon)
                If iRC <> ERR_OK Then
                    ProcessCTP = iRC
                    msStatus = CTPErrorMsg(iRC, "cdel_connection")
                    Exit Function
                End If
            End If

            ' Bump loop counter
            lLineIndex = lLineIndex + 1
            If lLineIndex = ruRequest.lLineItemCount Then
                lLineIndex = 0
            End If
        Loop

        ' Delete test database
        iRC = oERDB.cdel_testdb(muCon)
        If iRC <> ERR_OK Then
            ProcessCTP = iRC
            msStatus = CTPErrorMsg(iRC, "cdel_testdb")
            GoTo ProcessCTPEndConnection
        End If

        ' Get quantities available
        If ruRequest.bQuantities Then
            lLineIndex = ruRequest.lLineItemCount - 1
            muPart.part = ruRequest.uLineItemList(lLineIndex).sItemid
            muPart.sort = 0
            iRC = oERDB.cget_part(muCon, muPart)
            If iRC <> ERR_OK Then
                ProcessCTP = iRC
                msStatus = CTPErrorMsg(iRC, "GetPart")
                GoTo ProcessCTPEndConnection
            End If
            ruResponse.uLineItemList(lLineIndex).uQuantities.dQtyOnHand = Math.Max(0.0, muPart.prtinitinventory)

            ' Reset Due Date / Request Date
            If (ruRequest.uLineItemList(lLineIndex).lFlags And ERDB.Server.VAL_ORDFLAGS_NOCTPDUEDATE) > 0 Then
                muOrder.ordrequdate = PlannerInterface.iVBDate2OLDate(ruRequest.uLineItemList(lLineIndex).datDueDate)
                muOrder.ordpromdate = 0
            Else
                muOrder.ordrequdate = PlannerInterface.iVBDate2OLDate(ruRequest.uLineItemList(lLineIndex).datRequestDate)
                muOrder.ordpromdate = PlannerInterface.iVBDate2OLDate(ruRequest.uLineItemList(lLineIndex).datDueDate)
            End If
            muOrdLineItem.ordlinpromdate = 0
            muOrdLineItem.ordlincalcdate = 0

            ' Get quantities available
            iRC = oERDB.csch_orderctp(muCon, muOrder, muOrdLineItem, muMisc, uCtpQty)
            If iRC <> ERR_OK Then
                ProcessCTP = iRC
                msStatus = CTPErrorMsg(iRC, "csch_orderctp")
                GoTo ProcessCTPEndConnection
            End If
            ruResponse.uLineItemList(lLineIndex).uQuantities.dQtyInv = Math.Max(0.0, uCtpQty.qtyinv)
            ruResponse.uLineItemList(lLineIndex).uQuantities.dQtyShip = Math.Max(0.0, uCtpQty.qtysup)
            ruResponse.uLineItemList(lLineIndex).uQuantities.dQtyMfg = Math.Max(0.0, uCtpQty.qtymfg)
        End If

        ' Delete connection
        iRC = oERDB.cdel_connection(muCon)
        If iRC <> ERR_OK Then
            ProcessCTP = iRC
            msStatus = CTPErrorMsg(iRC, "cdel_connection")
            Exit Function
        End If

        ' Finished
        ProcessCTP = ERR_OK
        Exit Function

ProcessCTPEndConnection:
        Call oERDB.cdel_connection(muCon)
        Exit Function

ProcessCTPErrorHandler:
        ProcessCTP = Err.Number
        msStatus = "SLCtps.ProcessCTP():" & "  Internal error " & Err.Number & " - " & Err.Description

    End Function

    Private Function ProcessOrders(ByRef ruRequest As uCTPRequest,
                                   ByRef ruResponse As uCTPResponse) As Integer
        Dim iRC As Integer
        Dim lProcessedLines As Integer
        Dim lLineIndex As Integer
        Dim lIndex As Integer
        Dim sCurrentSite As String
        Dim sApsHost As String = ""
        Dim lApsPort As Integer = 0
        Dim oCollection As LoadCollectionResponseData
        Dim sProperties As String
        Dim sFilter As String
        Dim datRequestDate As Date
        Dim ApsHostIx As Integer
        Dim ApsPortIx As Integer
        Dim oERDB As New ERDB.Server

        On Error GoTo ProcessOrdersErrorHandler

        ' Mark all lines as unprocessed
        For lLineIndex = 1 To ruRequest.lLineItemCount
            ruRequest.uLineItemList(lLineIndex - 1).bProcessed = False
        Next lLineIndex
        ruRequest.bDetails = False
        ruRequest.bQuantities = False

        ' Initialize response
        ReDim ruResponse.uLineItemList(ruRequest.lLineItemCount)
        ruResponse.lLineItemCount = ruRequest.lLineItemCount
        ruResponse.bDetails = ruRequest.bDetails
        ruResponse.bQuantities = ruRequest.bQuantities

        ' Treat lines with zero quantity as special cases
        lProcessedLines = 0
        For lLineIndex = 1 To ruRequest.lLineItemCount
            If ruRequest.uLineItemList(lLineIndex - 1).dQuantity <= 0 Then
                ruResponse.uLineItemList(lLineIndex - 1).datCalcDate = ruRequest.uLineItemList(lLineIndex - 1).datDueDate
                ruResponse.uLineItemList(lLineIndex - 1).datStartDate = ruRequest.uLineItemList(lLineIndex - 1).datDueDate
                ruRequest.uLineItemList(lLineIndex - 1).bProcessed = True
                lProcessedLines = lProcessedLines + 1
            End If
        Next lLineIndex

        ' - Line items may be from different sites
        ' - All lines from the same site must be processed together
        ' - Loop until no lines are left unprocessed
        lLineIndex = 0
        sCurrentSite = ""
        Do While lProcessedLines < ruRequest.lLineItemCount

            ' Skip past sites that are already processed
            If Not ruRequest.uLineItemList(lLineIndex).bProcessed Then

                ' New site
                If sCurrentSite = "" Then
                    sCurrentSite = ruRequest.uLineItemList(lLineIndex).sSiteID

                    If TESTING_MODE Then
                        sApsHost = "localhost"
                        lApsPort = 6001
                    Else
                        ' Get host/port of APS server & planner
                        sProperties = "ApsHostName, ApsPortNo"
                        sFilter = "AltNo = 0 AND ApsSite = " & SqlLiteral.Format(sCurrentSite)
                        oCollection = Me.Context.Commands.LoadCollection("SL.SLApsSites", sProperties, sFilter, "", 0)
                        If oCollection.Items.Count = 0 Then
                            ProcessOrders = Aps.ServerService.APS_ERR_SITEINFO
                            msStatus = CTPErrorMsg(Aps.ServerService.APS_ERR_SITEINFO, sCurrentSite)
                            Exit Function
                        End If

                        ApsHostIx = oCollection.PropertyList.IndexOf("ApsHostName")
                        ApsPortIx = oCollection.PropertyList.IndexOf("ApsPortNo")

                        For Each item As IDOItem In oCollection.Items
                            sApsHost = item.PropertyValues(ApsHostIx).ToString()
                            lApsPort = item.PropertyValues(ApsPortIx).GetValue(Of Integer)()
                            Exit For
                        Next
                    End If

                    ' Flush ERDB gateway
                    iRC = ApsServerInterface.FlushGateway(sApsHost, lApsPort, 0)
                    If (iRC <> Aps.ServerService.APS_ERR_OK) And
                       (iRC <> Aps.ServerService.APS_ERR_FLUSH) Then
                        ProcessOrders = iRC
                        msStatus = CTPErrorMsg(iRC, "aps_flush_gateway")
                        Exit Function
                    End If

                    ' Connect to APS planner
                    iRC = oERDB.cget_connection(muCon, sApsHost, lApsPort)
                    If iRC <> ERR_OK Then
                        ProcessOrders = iRC
                        msStatus = CTPErrorMsg(iRC, "cget_connection")
                        Exit Function
                    End If

                    ' Initialize planner structures
                    iRC = InitCTP()
                    If iRC <> ERR_OK Then
                        ProcessOrders = iRC
                        msStatus = CTPErrorMsg(iRC, "InitCTP")
                        GoTo ProcessOrdersEndConnection
                    End If

                    ' If these orders already exist at the site, delete them
                    For lIndex = 1 To ruRequest.lLineItemCount
                        If ruRequest.uLineItemList(lIndex - 1).sSiteID = sCurrentSite Then
                            muOrder.order = Trim$(ruRequest.uLineItemList(lIndex - 1).sOrderID)
                            muOrder.sort = 0
                            iRC = oERDB.cget_order(muCon, muOrder)
                            If iRC = ERR_OK Then
                                iRC = oERDB.cdel_order(muCon, muOrder)
                                If iRC <> ERR_OK Then
                                    ProcessOrders = iRC
                                    msStatus = CTPErrorMsg(iRC, "cdel_order")
                                    GoTo ProcessOrdersEndConnection
                                End If
                            End If
                        End If
                    Next lIndex

                End If

                ' Copy request info to response
                ruResponse.uLineItemList(lLineIndex).uRequest.sSiteID = ruRequest.uLineItemList(lLineIndex).sSiteID
                ruResponse.uLineItemList(lLineIndex).uRequest.sOrderID = ruRequest.uLineItemList(lLineIndex).sOrderID
                ruResponse.uLineItemList(lLineIndex).uRequest.sItemid = ruRequest.uLineItemList(lLineIndex).sItemid
                ruResponse.uLineItemList(lLineIndex).uRequest.datRequestDate = ruRequest.uLineItemList(lLineIndex).datRequestDate
                ruResponse.uLineItemList(lLineIndex).uRequest.datDueDate = ruRequest.uLineItemList(lLineIndex).datDueDate
                ruResponse.uLineItemList(lLineIndex).uRequest.dQuantity = ruRequest.uLineItemList(lLineIndex).dQuantity
                ruResponse.uLineItemList(lLineIndex).uRequest.lCategory = ruRequest.uLineItemList(lLineIndex).lCategory
                ruResponse.uLineItemList(lLineIndex).uRequest.lFlags = ruRequest.uLineItemList(lLineIndex).lFlags
                ruResponse.uLineItemList(lLineIndex).uRequest.lFlags2 = ruRequest.uLineItemList(lLineIndex).lFlags2

                ' Set order fields
                muOrder.order = ruRequest.uLineItemList(lLineIndex).sOrderID
                muOrder.ordcategory = ruRequest.uLineItemList(lLineIndex).lCategory
                muOrder.ordtype = ruRequest.uLineItemList(lLineIndex).lOrdType
                muOrder.ordflags = ruRequest.uLineItemList(lLineIndex).lFlags And (Not ERDB.Server.VAL_ORDFLAGS_NOCTPDUEDATE)
                muOrder.ordflags2 = ruRequest.uLineItemList(lLineIndex).lFlags2
                If (ruRequest.uLineItemList(lLineIndex).lFlags And ERDB.Server.VAL_ORDFLAGS_NOCTPDUEDATE) > 0 Then
                    muOrder.ordrequdate = PlannerInterface.iVBDate2OLDate(ruRequest.uLineItemList(lLineIndex).datDueDate)
                    muOrder.ordpromdate = 0
                Else
                    muOrder.ordrequdate = PlannerInterface.iVBDate2OLDate(ruRequest.uLineItemList(lLineIndex).datRequestDate)
                    muOrder.ordpromdate = PlannerInterface.iVBDate2OLDate(ruRequest.uLineItemList(lLineIndex).datDueDate)
                End If
                muOrder.ordarivdate = muOrder.ordrequdate
                muOrder.ordreforder = ""

                ' Add order
                iRC = oERDB.cadd_order(muCon, muOrder)
                If iRC <> ERR_OK Then
                    ProcessOrders = iRC
                    msStatus = CTPErrorMsg(iRC, "cadd_order")
                    GoTo ProcessOrdersEndConnection
                End If

                ' Add lineitem
                muOrdLineItem.order = muOrder.order
                muOrdLineItem.ordlineitemidx = 0
                muOrdLineItem.part = ruRequest.uLineItemList(lLineIndex).sItemid
                muOrdLineItem.ordlinquantity = ruRequest.uLineItemList(lLineIndex).dQuantity
                muOrdLineItem.ordlinpromdate = 0
                muOrdLineItem.ordlincalcdate = 0
                iRC = oERDB.cadd_ordlineitem(muCon, muOrdLineItem)
                If iRC <> ERR_OK Then
                    ProcessOrders = iRC
                    msStatus = CTPErrorMsg(iRC, "cadd_ordlineitem")
                    GoTo ProcessOrdersEndConnection
                End If

                ' Plan order
                iRC = oERDB.csch_order(muCon, muOrder)
                If iRC <> ERR_OK Then
                    ProcessOrders = iRC
                    msStatus = CTPErrorMsg(iRC, "csch_order")
                    Call AddErrormsg(msStatus)
                    GoTo ProcessOrdersEndConnection
                End If

                ' Get planning results
                iRC = GetCTPResults(ruResponse.uLineItemList(lLineIndex), False)
                If iRC <> ERR_OK Then
                    If msStatus = "" Then
                        msStatus = "GetCTPResults() = " & iRC
                    End If
                    ProcessOrders = iRC
                    GoTo ProcessOrdersEndConnection
                End If

                ' Mark line as processed
                ruRequest.uLineItemList(lLineIndex).bProcessed = True
                lProcessedLines = lProcessedLines + 1

                ' If we've looped back to the first line of a particular site, we're ready for the next site
            ElseIf sCurrentSite = ruRequest.uLineItemList(lLineIndex).sSiteID Then
                sCurrentSite = ""
                iRC = oERDB.cdel_connection(muCon)
                If iRC <> ERR_OK Then
                    ProcessOrders = iRC
                    msStatus = CTPErrorMsg(iRC, "cdel_connection")
                    Exit Function
                End If
            End If

            ' Bump loop counter
            lLineIndex = lLineIndex + 1
            If lLineIndex = ruRequest.lLineItemCount Then
                lLineIndex = 0
            End If
        Loop

        ' Delete planner connection
        If sCurrentSite <> "" Then
            iRC = oERDB.cdel_connection(muCon)
            If iRC <> ERR_OK Then
                ProcessOrders = iRC
                msStatus = CTPErrorMsg(iRC, "cdel_connection")
                Exit Function
            End If
        End If

        ' Finished
        ProcessOrders = ERR_OK
        Exit Function

ProcessOrdersEndConnection:
        Call oERDB.cdel_connection(muCon)
        Exit Function

ProcessOrdersErrorHandler:
        ProcessOrders = Err.Number
        msStatus = "SLCtps.ProcessOrders():" & "  Internal error " & Err.Number & " - " & Err.Description

    End Function

    Private Function GetLeafOperationWIPCTP(ByRef ruOrdDetail As uOrdDetail) As Integer

        Dim iRC As Integer
        Dim lOperIndex As Integer
        Dim lMatltag As Integer
        Dim lLeafIndex As Integer
        Dim lIndex As Integer
        Dim lIndex2 As Integer
        Dim oERDB As New ERDB.Server

        ' Loop through matlplan records
        muOrd22Mpn.order = RTrim$(ruOrdDetail.sOrderID)
        muOrd22Mpn.ord22mpnidx = 1
        Do While oERDB.cget_ord22mpn(muCon, muOrd22Mpn) = ERR_OK
            muMatlplan.matlplan = muOrd22Mpn.matlplan
            muMatlplan.sort = 0
            iRC = oERDB.cget_matlplan(muCon, muMatlplan)
            If iRC <> ERR_OK Then
                GetLeafOperationWIPCTP = iRC
                Exit Function
            End If
            lMatltag = muMatlplan.matlplan
            lLeafIndex = ruOrdDetail.lHashList(lMatltag - ruOrdDetail.lMinimumMatlTag)

            ' Loop through invplan records
            muMpn22Ipn.matlplan = muMatlplan.matlplan
            muMpn22Ipn.mpn22ipnidx = 1
            Do While oERDB.cget_mpn22ipn(muCon, muMpn22Ipn) = ERR_OK
                muInvplan.invplan(0) = muMpn22Ipn.invplan(0)
                muInvplan.invplan(1) = muMpn22Ipn.invplan(1)
                muInvplan.sort = 0
                iRC = oERDB.cget_invplan(muCon, muInvplan)
                If iRC <> ERR_OK Then
                    GetLeafOperationWIPCTP = iRC
                    Exit Function
                End If

                If muInvplan.ipntype = ERDB.Server.VAL_IPNTYPE_USEWIP Then

                    ' Find operation
                    lOperIndex = -1
                    For lIndex = 0 To ruOrdDetail.uLeafList(lLeafIndex).lOperCount - 1
                        If muInvplan.ipnstep = ruOrdDetail.uLeafList(lLeafIndex).uOperList(lIndex).lSeqno Then
                            lOperIndex = lIndex
                            Exit For
                        End If
                    Next

                    ' Create WIP usage operation if needed
                    If lOperIndex = -1 Then
                        muOperation.operation = muInvplan.operation
                        muOperation.sort = 0
                        iRC = oERDB.cget_operation(muCon, muOperation)
                        If iRC <> ERR_OK Then
                            GetLeafOperationWIPCTP = iRC
                            Exit Function
                        End If

                        lOperIndex = ruOrdDetail.uLeafList(lLeafIndex).lOperCount
                        ReDim Preserve ruOrdDetail.uLeafList(lLeafIndex).lOperSort(lOperIndex)
                        ReDim Preserve ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex)
                        ruOrdDetail.uLeafList(lLeafIndex).lOperSort(lOperIndex) = lOperIndex
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).sOperID = Mid(muInvplan.operation, muMatlplan.routewidth + 1)
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).sOperDescr = "" 'muOperation.oprcom
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).datStartDate = PlannerInterface.datOLDate2VBDate(muInvplan.ipnstartdate)
                        If ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).datStartDate < ruOrdDetail.datStartDate Then
                            ruOrdDetail.datStartDate = ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).datStartDate
                        End If
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).datEndDate = PlannerInterface.datOLDate2VBDate(muInvplan.invplan(0))
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).dQuantity = muInvplan.ipndemandqty
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).dWIPQuantity = muInvplan.ipndemandqty
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).lSeqno = 1
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).lPartCount = 0
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).lGrpCount = 0
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).bCritDelay = False
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).bPushCritDelay = False
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).bItemDelay = False
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).bGroupDelay = False
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).bFiniteGroupDelay = False
                        ruOrdDetail.uLeafList(lLeafIndex).lOperCount = lOperIndex + 1

                        ' Insert WIP operation at beginning of operation list
                        For lIndex2 = ruOrdDetail.uLeafList(lLeafIndex).lOperCount - 1 To 1 Step -1
                            ruOrdDetail.uLeafList(lLeafIndex).lOperSort(lIndex2) = ruOrdDetail.uLeafList(lLeafIndex).lOperSort(lIndex2 - 1)
                        Next lIndex2
                        ruOrdDetail.uLeafList(lLeafIndex).lOperSort(0) = lOperIndex
                    Else
                        ' If WIP usage belongs to existing operation, update record
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).dWIPQuantity = muInvplan.ipndemandqty
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).dQuantity = ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).dQuantity _
                                                             + muInvplan.ipndemandqty
                    End If
                End If

                muMpn22Ipn.mpn22ipnidx = muMpn22Ipn.mpn22ipnidx + 1
            Loop

            muOrd22Mpn.ord22mpnidx = muOrd22Mpn.ord22mpnidx + 1
        Loop

        GetLeafOperationWIPCTP = ERR_OK

    End Function

    Private Function GetLeafOperationsCTP(ByRef ruOrdDetail As uOrdDetail) As Integer

        Dim iRC As Integer
        Dim lLeafIndex As Integer
        Dim lOperIndex As Integer
        Dim lIndex As Integer
        Dim datStartDate As Date
        Dim datEndDate As Date
        Dim lGrpIndex As Integer
        Dim lResIndex As Integer
        Dim lUsageIndex As Integer
        Dim oERDB As New ERDB.Server
        Dim lGap As Integer
        Dim lSort1 As Integer
        Dim lSort2 As Integer
        Dim lIndex1 As Integer
        Dim lIndex2 As Integer
        Dim bFound As Boolean

        ' Assign operations to leaves
        muOrd22Mpn.order = RTrim$(ruOrdDetail.sOrderID)
        muOrd22Mpn.ord22mpnidx = 1
        Do While oERDB.cget_ord22mpn(muCon, muOrd22Mpn) = ERR_OK
            muMatlplan.matlplan = muOrd22Mpn.matlplan
            muMatlplan.sort = 0
            iRC = oERDB.cget_matlplan(muCon, muMatlplan)
            If iRC <> ERR_OK Then
                GetLeafOperationsCTP = iRC
                Exit Function
            End If
            lLeafIndex = ruOrdDetail.lHashList(muMatlplan.matlplan - ruOrdDetail.lMinimumMatlTag)

            muMpn22Opn.matlplan = muMatlplan.matlplan
            muMpn22Opn.mpn22opnidx = 1
            Do While oERDB.cget_mpn22opn(muCon, muMpn22Opn) = ERR_OK
                muOperplan.operplan(0) = muMpn22Opn.operplan(0)
                muOperplan.operplan(1) = muMpn22Opn.operplan(1)
                muOperplan.sort = 0
                iRC = oERDB.cget_operplan(muCon, muOperplan)
                If iRC <> ERR_OK Then
                    GetLeafOperationsCTP = iRC
                    Exit Function
                End If

                datStartDate = PlannerInterface.datOLDate2VBDate(muOperplan.operplan(0))
                datEndDate = PlannerInterface.datOLDate2VBDate(muOperplan.opnenddate)
                If ruOrdDetail.uLeafList(lLeafIndex).datStartDate > datStartDate Then
                    ruOrdDetail.uLeafList(lLeafIndex).datStartDate = datStartDate
                End If
                If ruOrdDetail.uLeafList(lLeafIndex).datEndDate < datEndDate Then
                    ruOrdDetail.uLeafList(lLeafIndex).datEndDate = datEndDate
                End If

                lOperIndex = -1
                For lIndex = 0 To ruOrdDetail.uLeafList(lLeafIndex).lOperCount - 1
                    If ruOrdDetail.uLeafList(lLeafIndex).uOperList(lIndex).sOperID = Mid(muOperplan.operation, muMatlplan.routewidth + 1) Then
                        lOperIndex = lIndex
                        Exit For
                    End If
                Next

                If lOperIndex >= 0 Then
                    If ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).datStartDate > datStartDate Then
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).datStartDate = datStartDate
                    End If
                    If ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).datEndDate < datEndDate Then
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).datEndDate = datEndDate
                    End If
                Else
                    lOperIndex = ruOrdDetail.uLeafList(lLeafIndex).lOperCount
                    ReDim Preserve ruOrdDetail.uLeafList(lLeafIndex).lOperSort(lOperIndex)
                    ReDim Preserve ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex)
                    ruOrdDetail.uLeafList(lLeafIndex).lOperSort(lOperIndex) = lOperIndex
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).sOperID = Mid(muOperplan.operation, muMatlplan.routewidth + 1)
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).sOperDescr = ""
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).datStartDate = datStartDate
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).datEndDate = datEndDate
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).dQuantity = muOperplan.opnquantity
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).lSeqno = muOperplan.opnstep
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).lPartCount = 0
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).lGrpCount = 0
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).dWIPQuantity = 0
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).bCritDelay = False
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).bPushCritDelay = False
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).bItemDelay = False
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).bGroupDelay = False
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).bFiniteGroupDelay = False
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).lFlags = muOperplan.opnflags
                    ruOrdDetail.uLeafList(lLeafIndex).lOperCount = lOperIndex + 1
                End If

                muOpr22Cat.operation = muOperplan.operation
                muOpr22Cat.opr22catidx = 1
                Do While oERDB.cget_opr22cat(muCon, muOpr22Cat) = ERR_OK
                    muOpn22Res.operplan(0) = muOperplan.operplan(0)
                    muOpn22Res.operplan(1) = muOperplan.operplan(1)
                    muOpn22Res.opn22residx = muOpr22Cat.opr22catidx
                    iRC = oERDB.cget_opn22res(muCon, muOpn22Res)
                    If iRC = ERDB.Server.ERR_IDX Then
                        Exit Do
                    ElseIf iRC <> ERR_OK Then
                        GetLeafOperationsCTP = iRC
                        Exit Function
                    End If

                    bFound = False
                    For lGrpIndex = 0 To ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).lGrpCount - 1
                        If muOpr22Cat.category = ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).sGroupID Then
                            bFound = True
                            Exit For
                        End If
                    Next
                    If Not bFound Then
                        muCategory.category = muOpr22Cat.category
                        muCategory.sort = 0
                        iRC = oERDB.cget_category(muCon, muCategory)
                        If iRC <> ERR_OK Then
                            GetLeafOperationsCTP = iRC
                            Exit Function
                        End If
                        lGrpIndex = ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).lGrpCount
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).lGrpCount = lGrpIndex + 1
                        ReDim Preserve ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).lGrpSort(lGrpIndex)
                        ReDim Preserve ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex)
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).lGrpSort(lGrpIndex) = lGrpIndex
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).sGroupID = muCategory.category
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).sGroupDescr = ""
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).bLaborGroup = False
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).lMembers = muCategory.cat22res_l
                        If muCategory.catinfcapafter > 0 Then
                            ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).bFiniteGroup = True
                        Else
                            ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).bFiniteGroup = False
                        End If
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).dWaitTime = 0
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).dPushWait = 0
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).lResCount = 0
                    End If

                    bFound = False
                    For lResIndex = 0 To ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).lResCount - 1
                        If muOpn22Res.resource = ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).uResList(lResIndex).sResrcID Then
                            bFound = True
                            Exit For
                        End If
                    Next
                    If Not bFound Then
                        lResIndex = ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).lResCount
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).lResCount = lResIndex + 1
                        ReDim Preserve ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).uResList(lResIndex)
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).uResList(lResIndex).sResrcID = muOpn22Res.resource
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).uResList(lResIndex).sResrcDescr = ""
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).uResList(lResIndex).sShift1 = ""
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).uResList(lResIndex).sShift2 = ""
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).uResList(lResIndex).sShift3 = ""
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).uResList(lResIndex).sShift4 = ""
                        muRes22Shf.resource = muOpn22Res.resource
                        muRes22Shf.res22shfidx = 1
                        iRC = oERDB.cget_res22shf(muCon, muRes22Shf)
                        If iRC = ERR_OK Then
                            ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).uResList(lResIndex).sShift1 = muRes22Shf.shift
                            muRes22Shf.res22shfidx = 2
                            iRC = oERDB.cget_res22shf(muCon, muRes22Shf)
                            If iRC = ERR_OK Then
                                ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).uResList(lResIndex).sShift2 = muRes22Shf.shift
                                muRes22Shf.res22shfidx = 3
                                iRC = oERDB.cget_res22shf(muCon, muRes22Shf)
                                If iRC = ERR_OK Then
                                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).uResList(lResIndex).sShift3 = muRes22Shf.shift
                                    muRes22Shf.res22shfidx = 4
                                    iRC = oERDB.cget_res22shf(muCon, muRes22Shf)
                                    If iRC = ERR_OK Then
                                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).uResList(lResIndex).sShift4 = muRes22Shf.shift
                                    End If
                                End If
                            End If
                        End If
                    End If
                    lUsageIndex = ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).uResList(lResIndex).lUsageCount
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).uResList(lResIndex).lUsageCount = lUsageIndex + 1
                    ReDim Preserve ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).uResList(lResIndex).uUsageList(lUsageIndex)
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).uResList(lResIndex).uUsageList(lUsageIndex).lUsageType = RES_USAGETYPE_BUSY
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).uResList(lResIndex).uUsageList(lUsageIndex).datStartDate = datStartDate
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).uResList(lResIndex).uUsageList(lUsageIndex).datEndDate = datEndDate

                    muOpr22Cat.opr22catidx = muOpr22Cat.opr22catidx + 1
                Loop

                muMpn22Opn.mpn22opnidx = muMpn22Opn.mpn22opnidx + 1
            Loop

            muOrd22Mpn.ord22mpnidx = muOrd22Mpn.ord22mpnidx + 1
        Loop

        ' Assign a dummy operation to MRP parts with no operations
        For lIndex = 0 To ruOrdDetail.lLeafCount - 1
            If ((ruOrdDetail.uLeafList(lLeafIndex).lPartFlags And ERDB.Server.VAL_PRTFLAGS_MRPPART) > 0) And
                (ruOrdDetail.uLeafList(lLeafIndex).lOperCount = 0) Then
                ruOrdDetail.uLeafList(lLeafIndex).sRouteID = ""
                ReDim Preserve ruOrdDetail.uLeafList(lLeafIndex).lOperSort(0)
                ReDim Preserve ruOrdDetail.uLeafList(lLeafIndex).uOperList(0)
                ruOrdDetail.uLeafList(lLeafIndex).lOperSort(0) = 0
                ruOrdDetail.uLeafList(lLeafIndex).uOperList(0).sOperID = ""
                ruOrdDetail.uLeafList(lLeafIndex).uOperList(0).sOperDescr = ""
                ruOrdDetail.uLeafList(lLeafIndex).uOperList(0).datStartDate = ruOrdDetail.uLeafList(lLeafIndex).datStartDate
                ruOrdDetail.uLeafList(lLeafIndex).uOperList(0).datEndDate = ruOrdDetail.uLeafList(lLeafIndex).datEndDate
                ruOrdDetail.uLeafList(lLeafIndex).uOperList(0).dQuantity = ruOrdDetail.uLeafList(lLeafIndex).dQuantity
                ruOrdDetail.uLeafList(lLeafIndex).uOperList(0).lSeqno = 1
                ruOrdDetail.uLeafList(lLeafIndex).uOperList(0).lPartCount = 0
                ruOrdDetail.uLeafList(lLeafIndex).uOperList(0).lGrpCount = 0
                ruOrdDetail.uLeafList(lLeafIndex).uOperList(0).dWIPQuantity = 0
                ruOrdDetail.uLeafList(lLeafIndex).uOperList(0).bCritDelay = False
                ruOrdDetail.uLeafList(lLeafIndex).uOperList(0).bPushCritDelay = False
                ruOrdDetail.uLeafList(lLeafIndex).uOperList(0).bItemDelay = False
                ruOrdDetail.uLeafList(lLeafIndex).uOperList(0).bGroupDelay = False
                ruOrdDetail.uLeafList(lLeafIndex).uOperList(0).bFiniteGroupDelay = False
                ruOrdDetail.uLeafList(lLeafIndex).uOperList(0).dDuration = 0
                ruOrdDetail.uLeafList(lLeafIndex).uOperList(0).sWorkcenter = ""
                ruOrdDetail.uLeafList(lLeafIndex).lOperCount = 1
            End If
        Next lIndex

        ' Sort operations by SEQNO
        For lIndex = 0 To ruOrdDetail.lLeafCount - 1
            ReDim ruOrdDetail.uLeafList(lIndex).lOperSort(ruOrdDetail.uLeafList(lIndex).lOperCount)
            For lIndex2 = 0 To ruOrdDetail.uLeafList(lIndex).lOperCount - 1
                ruOrdDetail.uLeafList(lIndex).lOperSort(lIndex2) = lIndex2
            Next
            lGap = ruOrdDetail.uLeafList(lIndex).lOperCount \ 2
            Do While lGap > 0
                For lSort1 = lGap To ruOrdDetail.uLeafList(lIndex).lOperCount - 1
                    lSort2 = lSort1 - lGap
                    Do While lSort2 >= 0
                        lIndex1 = ruOrdDetail.uLeafList(lIndex).lOperSort(lSort2)
                        lIndex2 = ruOrdDetail.uLeafList(lIndex).lOperSort(lSort2 + lGap)
                        If ruOrdDetail.uLeafList(lIndex).uOperList(lIndex1).lSeqno > ruOrdDetail.uLeafList(lIndex).uOperList(lIndex2).lSeqno Then
                            ruOrdDetail.uLeafList(lIndex).lOperSort(lSort2) = lIndex2
                            ruOrdDetail.uLeafList(lIndex).lOperSort(lSort2 + lGap) = lIndex1
                        Else
                            Exit Do
                        End If
                        lSort2 = lSort2 - lGap
                    Loop
                Next lSort1
                lGap = lGap \ 2
            Loop
        Next lIndex

        GetLeafOperationsCTP = ERR_OK

    End Function

    Private Function GetLeafWaitCTP(ByRef ruOrdDetail As uOrdDetail) As Integer

        Dim lLeafIndex As Integer
        Dim lIndex As Integer
        Dim sJsid As String
        Dim sPartID As String
        Dim sGroupID As String
        Dim lOperIndex As Integer
        Dim lGrpIndex As Integer
        Dim lChildLeafIndex As Integer
        Dim lChildIndex As Integer
        Dim oERDB As New ERDB.Server

        ' Get order waiting time
        muOrdWait.order = RTrim$(ruOrdDetail.sOrderID)
        muOrdWait.ordwaithrsidx = 1
        Do While oERDB.cget_ordwaithrs(muCon, muOrdWait) = ERR_OK
            lLeafIndex = ruOrdDetail.lHashList(muOrdWait.ordwaittag - ruOrdDetail.lMinimumMatlTag)
            If lLeafIndex < 0 Then
                ' Skip this wait time (belongs to orphaned push matltag)
            Else
                sJsid = RTrim(Mid(muOrdWait.ordwaitoper, muMatlplan.routewidth + 1))
                sPartID = RTrim(muOrdWait.ordwaitmtl)
                sGroupID = RTrim(muOrdWait.ordwaitcat)
                If muOrdWait.ordwaitflags = ERDB.Server.ORDWAITFLAGS_CAT Or muOrdWait.ordwaitflags = ERDB.Server.ORDWAITFLAGS_PUSHCAT Then
                    For lOperIndex = 0 To ruOrdDetail.uLeafList(lLeafIndex).lOperCount - 1
                        If sJsid = ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).sOperID Then
                            For lGrpIndex = 0 To ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).lGrpCount - 1
                                If sGroupID = ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).sGroupID Then
                                    If muOrdWait.ordwaitflags = ERDB.Server.ORDWAITFLAGS_CAT Then
                                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).dWaitTime = muOrdWait.ordwaithrs
                                    Else
                                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).dPushWait = muOrdWait.ordwaithrs
                                    End If
                                    Exit For
                                End If
                            Next lGrpIndex
                            Exit For
                        End If
                    Next lOperIndex
                ElseIf muOrdWait.ordwaitflags = ERDB.Server.ORDWAITFLAGS_MTL Then
                    lIndex = -1
                    For lChildIndex = 0 To ruOrdDetail.uLeafList(lLeafIndex).lChildCount - 1
                        lChildLeafIndex = ruOrdDetail.uLeafList(lLeafIndex).lChildList(lChildIndex)
                        If sPartID = ruOrdDetail.uLeafList(lChildLeafIndex).sPartID Then
                            If (ruOrdDetail.uLeafList(lChildLeafIndex).lFlags And ERDB.Server.VAL_MPNFLAGS_CRITPATH) <> 0 Then
                                lIndex = lChildLeafIndex
                                Exit For
                            ElseIf lIndex < 0 Then
                                lIndex = lChildLeafIndex
                            End If
                        End If
                    Next lChildIndex

                    If lIndex >= 0 Then
                        ruOrdDetail.uLeafList(lIndex).dWaitTime = muOrdWait.ordwaithrs
                    ElseIf sPartID = ruOrdDetail.uLeafList(lLeafIndex).sPartID Then
                        ruOrdDetail.uLeafList(lLeafIndex).dWaitTime = muOrdWait.ordwaithrs
                    End If
                End If
            End If
            muOrdWait.ordwaithrsidx = muOrdWait.ordwaithrsidx + 1
        Loop

        GetLeafWaitCTP = ERR_OK

    End Function

    Private Function GetLeafEventsCTP(ByRef ruOrdDetail As uOrdDetail) As Integer

        Dim iRC As Integer
        Dim sSupOrderid As String
        Dim sOrderid As String
        Dim datSupplyDate As Date
        Dim lLeafIndex As Integer
        Dim lEventIndex As Integer
        Dim lSupMatlTag As Integer
        Dim datStartDate As Date
        Dim datEndDate As Date
        Dim dSupplyQty As Double
        Dim oERDB As New ERDB.Server

        ' Assign inventory events to leaves
        muOrd22Mpn.order = RTrim$(ruOrdDetail.sOrderID)
        muOrd22Mpn.ord22mpnidx = 1
        Do While oERDB.cget_ord22mpn(muCon, muOrd22Mpn) = ERR_OK
            muMatlplan.matlplan = muOrd22Mpn.matlplan
            muMatlplan.sort = 0
            iRC = oERDB.cget_matlplan(muCon, muMatlplan)
            If iRC <> ERR_OK Then
                GetLeafEventsCTP = iRC
                Exit Function
            End If
            lLeafIndex = ruOrdDetail.lHashList(muMatlplan.matlplan - ruOrdDetail.lMinimumMatlTag)

            muMpn22Ipn.matlplan = muMatlplan.matlplan
            muMpn22Ipn.mpn22ipnidx = 1
            Do While oERDB.cget_mpn22ipn(muCon, muMpn22Ipn) = ERR_OK
                muInvplan.invplan(0) = muMpn22Ipn.invplan(0)
                muInvplan.invplan(1) = muMpn22Ipn.invplan(1)
                muInvplan.sort = 0
                iRC = oERDB.cget_invplan(muCon, muInvplan)
                If iRC <> ERR_OK Then
                    GetLeafEventsCTP = iRC
                    Exit Function
                End If

                If muInvplan.ipntype = ERDB.Server.VAL_IPNTYPE_RESERVEDSUPPLY Or
                   muInvplan.ipntype = ERDB.Server.VAL_IPNTYPE_FORECASTSUPPLY Or
                   (muInvplan.ipnflags And ERDB.Server.VAL_IPNFLAGS_NOPUTBACK) <> 0 Then
                    GoTo SkipRecord
                End If

                datStartDate = PlannerInterface.datOLDate2VBDate(muInvplan.ipnstartdate)
                datEndDate = PlannerInterface.datOLDate2VBDate(muInvplan.invplan(0))
                If muInvplan.ipntype <> ERDB.Server.VAL_IPNTYPE_USEMFG Then
                    If ruOrdDetail.uLeafList(lLeafIndex).datStartDate > datStartDate Then
                        ruOrdDetail.uLeafList(lLeafIndex).datStartDate = datStartDate
                    End If
                    If ruOrdDetail.uLeafList(lLeafIndex).datEndDate < datEndDate Then
                        ruOrdDetail.uLeafList(lLeafIndex).datEndDate = datEndDate
                    End If
                End If

                If muInvplan.ipn2supply(0) > 0 Then
                    muInvplanSup.invplan(0) = muInvplan.ipn2supply(0)
                    muInvplanSup.invplan(1) = muInvplan.ipn2supply(1)
                    muInvplanSup.sort = 0
                    iRC = oERDB.cget_invplan(muCon, muInvplanSup)
                    If iRC <> ERR_OK Then
                        GetLeafEventsCTP = iRC
                        Exit Function
                    End If
                    muMatlplanSup.matlplan = muInvplanSup.matlplan
                    lSupMatlTag = muInvplanSup.matlplan
                    muMatlplanSup.sort = 0
                    iRC = oERDB.cget_matlplan(muCon, muMatlplanSup)
                    If iRC <> ERR_OK Then
                        GetLeafEventsCTP = iRC
                        Exit Function
                    End If
                    If muMatlplanSup.mpnparenttag > 0 Then
                        If (muMatlplanSup.mpnflags And 512) <> 0 Then
                            sSupOrderid = "Consolidated PLN " + CStr(lSupMatlTag)
                        Else
                            sSupOrderid = "PLN " + CStr(lSupMatlTag)
                        End If
                    Else
                        sSupOrderid = muMatlplanSup.order
                    End If
                    sOrderid = muMatlplanSup.order
                    datSupplyDate = PlannerInterface.datOLDate2VBDate(muInvplanSup.invplan(0))
                    dSupplyQty = muInvplanSup.ipnorigqty
                Else
                    sSupOrderid = ""
                    sOrderid = ""
                    datSupplyDate = datEndDate
                    If muInvplan.ipntype = ERDB.Server.VAL_IPNTYPE_PURCHASE Then
                        dSupplyQty = muInvplan.ipndemandqty
                    Else
                        dSupplyQty = ruOrdDetail.uLeafList(lLeafIndex).dQtyOnhand
                    End If
                End If
                If datSupplyDate < mdatAPSNow Then
                    datSupplyDate = mdatAPSNow
                End If

                If muInvplan.ipntype = ERDB.Server.VAL_IPNTYPE_MFG Then
                    ruOrdDetail.uLeafList(lLeafIndex).dMfgQuantity = ruOrdDetail.uLeafList(lLeafIndex).dMfgQuantity + muInvplan.ipndemandqty
                ElseIf muInvplan.ipntype = ERDB.Server.VAL_IPNTYPE_USEFIN Or
                       muInvplan.ipntype = ERDB.Server.VAL_IPNTYPE_USESUP Or
                       muInvplan.ipntype = ERDB.Server.VAL_IPNTYPE_PURCHASE Or
                       muInvplan.ipntype = ERDB.Server.VAL_IPNTYPE_UNCONSTRAINED Or
                       muInvplan.ipntype = ERDB.Server.VAL_IPNTYPE_FORCEFIN Or
                       muInvplan.ipntype = ERDB.Server.VAL_IPNTYPE_BYPRODUCT Then

                    lEventIndex = ruOrdDetail.uLeafList(lLeafIndex).lInvCount
                    ReDim Preserve ruOrdDetail.uLeafList(lLeafIndex).lInvSort(lEventIndex)
                    ReDim Preserve ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex)
                    ruOrdDetail.uLeafList(lLeafIndex).lInvSort(lEventIndex) = lEventIndex
                    ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).datInvDate = PlannerInterface.datOLDate2VBDate(muInvplan.invplan(0))
                    ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).datReqDate = PlannerInterface.datOLDate2VBDate(muInvplan.ipnstartdate)
                    ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).datSupplyDate = datSupplyDate
                    ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).dSupQty = dSupplyQty
                    If ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).datInvDate < ruOrdDetail.datStartDate Then
                        ruOrdDetail.datStartDate = ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).datInvDate
                    End If
                    ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).dDemand = muInvplan.ipndemandqty
                    ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).dSupply = muInvplan.ipnsupplyqty
                    ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).lSchFlags = muInvplan.ipnflags
                    ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).lSchType = muInvplan.ipntype
                    ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).sOrderID = sOrderid
                    ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).sSupplyID = sSupOrderid
                    ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).lSupMatlTag = lSupMatlTag
                    ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).sRemoteSite = ""
                    ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).dExpedited = 0

                    ' If demand = supply, this must be a safety stock or replenishment order.
                    ' In such a case, we want to show the demand quantity (even though it isn't being used)
                    If ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).dDemand = ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).dSupply Then
                        ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).dSupply = 0
                    End If

                    If ((ruOrdDetail.uLeafList(lLeafIndex).lPartFlags And ERDB.Server.VAL_PRTFLAGS_PURCHASED) = 0) And
                       (ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).sSupplyID <> "" And
                       lSupMatlTag <> muMatlplan.matlplan) Then
                        ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).lSchFlags = ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).lSchFlags _
                                                                                            Or ERDB.Server.VAL_IPNFLAGS_DRILLDOWNOK
                    End If

                    ' Pre-compute slack for use of purchased part supplies
                    If ((ruOrdDetail.uLeafList(lLeafIndex).lPartFlags And ERDB.Server.VAL_PRTFLAGS_PURCHASED) > 0) And
                       (ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).sSupplyID <> "") Then
                        ruOrdDetail.uLeafList(lLeafIndex).dSlackTime = DateDiff("n", datSupplyDate, ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).datInvDate) / 60.0#
                        If ruOrdDetail.uLeafList(lLeafIndex).dSlackTime < 0.0# Then
                            ruOrdDetail.uLeafList(lLeafIndex).dSlackTime = 0.0#
                        End If
                    End If

                    Select Case (muInvplan.ipntype)
                        Case ERDB.Server.VAL_IPNTYPE_USEFIN
                            ruOrdDetail.uLeafList(lLeafIndex).dInvQuantity = ruOrdDetail.uLeafList(lLeafIndex).dInvQuantity _
                                                                             + ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).dDemand
                        Case ERDB.Server.VAL_IPNTYPE_USESUP
                            ruOrdDetail.uLeafList(lLeafIndex).dSupQuantity = ruOrdDetail.uLeafList(lLeafIndex).dSupQuantity _
                                                                             + ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).dDemand
                        Case ERDB.Server.VAL_IPNTYPE_PURCHASE
                            ruOrdDetail.uLeafList(lLeafIndex).dPurchaseQuantity = ruOrdDetail.uLeafList(lLeafIndex).dPurchaseQuantity _
                                                                             + ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).dDemand _
                                                                             - ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).dSupply
                        Case ERDB.Server.VAL_IPNTYPE_UNCONSTRAINED
                            ruOrdDetail.uLeafList(lLeafIndex).dUnconstrainedQuantity = ruOrdDetail.uLeafList(lLeafIndex).dUnconstrainedQuantity _
                                                                             + ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).dDemand _
                                                                             - ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).dSupply
                        Case ERDB.Server.VAL_IPNTYPE_FORCEFIN
                            ruOrdDetail.uLeafList(lLeafIndex).dUnconstrainedQuantity = ruOrdDetail.uLeafList(lLeafIndex).dUnconstrainedQuantity _
                                                                             + ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).dDemand
                        Case ERDB.Server.VAL_IPNTYPE_BYPRODUCT
                            ruOrdDetail.uLeafList(lLeafIndex).dSupQuantity = ruOrdDetail.uLeafList(lLeafIndex).dSupQuantity _
                                                                           + ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).dSupply
                    End Select

                    ruOrdDetail.uLeafList(lLeafIndex).lInvCount = lEventIndex + 1
                End If

SkipRecord:     muMpn22Ipn.mpn22ipnidx = muMpn22Ipn.mpn22ipnidx + 1
            Loop

            muOrd22Mpn.ord22mpnidx = muOrd22Mpn.ord22mpnidx + 1
        Loop

        ' Compute demand quantity for each leaf
        For lLeafIndex = 0 To ruOrdDetail.lLeafCount - 1
            ruOrdDetail.uLeafList(lLeafIndex).dQuantity = ruOrdDetail.uLeafList(lLeafIndex).dInvQuantity _
                                                        + ruOrdDetail.uLeafList(lLeafIndex).dSupQuantity _
                                                        + ruOrdDetail.uLeafList(lLeafIndex).dPurchaseQuantity _
                                                        + ruOrdDetail.uLeafList(lLeafIndex).dUnconstrainedQuantity _
                                                        + ruOrdDetail.uLeafList(lLeafIndex).dMfgQuantity

        Next lLeafIndex

        GetLeafEventsCTP = ERR_OK

    End Function

    Private Function GetOrdLeavesCTP(ByRef ruOrdDetail As uOrdDetail) As Integer

        Dim lIndex As Integer
        Dim lLeafIndex As Integer
        Dim iRC As Integer
        Dim oERDB As New ERDB.Server

        ruOrdDetail.lMinimumMatlTag = Integer.MaxValue
        ruOrdDetail.lMaximumMatlTag = Integer.MinValue

        ' Initialize root count
        ruOrdDetail.lRootCount = 0

        ' Create leaves
        lLeafIndex = 0
        muOrd22Mpn.order = RTrim$(ruOrdDetail.sOrderID)
        muOrd22Mpn.ord22mpnidx = lLeafIndex + 1
        Do While oERDB.cget_ord22mpn(muCon, muOrd22Mpn) = ERR_OK
            muMatlplan.matlplan = muOrd22Mpn.matlplan
            muMatlplan.sort = 0
            iRC = oERDB.cget_matlplan(muCon, muMatlplan)
            If iRC <> ERR_OK Then
                GetOrdLeavesCTP = iRC
                Exit Function
            End If
            muPart.part = RTrim$(muMatlplan.part)
            muPart.sort = 0
            iRC = oERDB.cget_part(muCon, muPart)
            If iRC <> ERR_OK Then
                GetOrdLeavesCTP = iRC
                Exit Function
            End If
            ReDim Preserve ruOrdDetail.uLeafList(lLeafIndex)
            If muMatlplan.mpnparenttag = 0 Then
                ReDim Preserve ruOrdDetail.lRootList(ruOrdDetail.lRootCount + 1)
                ruOrdDetail.lRootList(ruOrdDetail.lRootCount) = lLeafIndex
                ruOrdDetail.lRootCount = ruOrdDetail.lRootCount + 1
            End If
            ruOrdDetail.uLeafList(lLeafIndex).sPartID = muMatlplan.part
            ruOrdDetail.uLeafList(lLeafIndex).sPartDescr = "" 'muPart.prtcom
            ruOrdDetail.uLeafList(lLeafIndex).lPartFlags = muPart.prtflags
            ruOrdDetail.uLeafList(lLeafIndex).lMatltag = muMatlplan.matlplan
            ruOrdDetail.uLeafList(lLeafIndex).lParentTag = muMatlplan.mpnparenttag
            ruOrdDetail.uLeafList(lLeafIndex).lLoadID = 0
            ruOrdDetail.uLeafList(lLeafIndex).sBomID = muMatlplan.bom
            ruOrdDetail.uLeafList(lLeafIndex).lMergeTo = muMatlplan.mpnparentstep
            ruOrdDetail.uLeafList(lLeafIndex).datStartDate = MAX_DATE
            ruOrdDetail.uLeafList(lLeafIndex).datEndDate = MIN_DATE
            ruOrdDetail.uLeafList(lLeafIndex).lFlags = muMatlplan.mpnflags
            If (ruOrdDetail.uLeafList(lLeafIndex).lFlags And ERDB.Server.VAL_MPNFLAGS_CRITPATH) <> 0 Then
                ruOrdDetail.uLeafList(lLeafIndex).bCritDelay = True
            Else
                ruOrdDetail.uLeafList(lLeafIndex).bCritDelay = False
            End If
            If (ruOrdDetail.uLeafList(lLeafIndex).lFlags And ERDB.Server.VAL_MPNFLAGS_PUSHCRITPATH) <> 0 Then
                ruOrdDetail.uLeafList(lLeafIndex).bPushCritDelay = True
            Else
                ruOrdDetail.uLeafList(lLeafIndex).bPushCritDelay = False
            End If
            ruOrdDetail.uLeafList(lLeafIndex).bItemDelay = False
            ruOrdDetail.uLeafList(lLeafIndex).bGroupDelay = False
            ruOrdDetail.uLeafList(lLeafIndex).bFiniteGroupDelay = False
            If (ruOrdDetail.uLeafList(lLeafIndex).lFlags And ERDB.Server.VAL_MPNFLAGS_ALTPART) <> 0 Then
                ruOrdDetail.uLeafList(lLeafIndex).lPartFlags = ruOrdDetail.uLeafList(lLeafIndex).lPartFlags Or ERDB.Server.VAL_PRTFLAGS_ALTPART
            End If
            ruOrdDetail.uLeafList(lLeafIndex).dOrdMin = muPart.prtminimum
            ruOrdDetail.uLeafList(lLeafIndex).dOrdMax = muPart.prtmax
            ruOrdDetail.uLeafList(lLeafIndex).dOrdMult = muPart.prtmultiple
            ruOrdDetail.uLeafList(lLeafIndex).lDaysSupply = muPart.prtdayssupply
            ruOrdDetail.uLeafList(lLeafIndex).dQtyOnhand = muPart.prtinitinventory
            ruOrdDetail.uLeafList(lLeafIndex).dFLeadtime = muPart.prtfleadtime
            ruOrdDetail.uLeafList(lLeafIndex).dFExpLeadtime = muPart.prtexpfleadtime
            ruOrdDetail.uLeafList(lLeafIndex).dVLeadtime = muPart.prtvleadtime
            ruOrdDetail.uLeafList(lLeafIndex).dVExpLeadtime = muPart.prtexpvleadtime

            If muMatlplan.matlplan > ruOrdDetail.lMaximumMatlTag Then
                ruOrdDetail.lMaximumMatlTag = muMatlplan.matlplan
            End If

            If muMatlplan.matlplan < ruOrdDetail.lMinimumMatlTag Then
                ruOrdDetail.lMinimumMatlTag = muMatlplan.matlplan
            End If

            lLeafIndex = lLeafIndex + 1
            muOrd22Mpn.ord22mpnidx = lLeafIndex + 1
        Loop
        ruOrdDetail.lLeafCount = lLeafIndex
        ruOrdDetail.lHashCount = ruOrdDetail.lMaximumMatlTag - ruOrdDetail.lMinimumMatlTag + 1

        ' Initialize hash list
        ReDim ruOrdDetail.lHashList(ruOrdDetail.lHashCount)
        For lIndex = 0 To ruOrdDetail.lHashCount - 1
            ruOrdDetail.lHashList(lIndex) = -1
        Next lIndex

        For lLeafIndex = 0 To ruOrdDetail.lLeafCount - 1
            ruOrdDetail.lHashList(ruOrdDetail.uLeafList(lLeafIndex).lMatltag - ruOrdDetail.lMinimumMatlTag) = lLeafIndex
        Next

        ' Initialize leaf info
        Call InitializeLeafInfo(ruOrdDetail)

        GetOrdLeavesCTP = ERR_OK

    End Function

    Private Function GetOrdSummary(ByRef ruOrdDetail As uOrdDetail) As Integer

        Dim sProperties As String
        Dim loadRequest As New LoadCollectionRequestData
        Dim oData As LoadCollectionResponseData
        Dim requdateIx, duedateIx, calcdateIx, derdemandidIx As Integer

        On Error GoTo GetOrdSummaryErr

        ' Get summary record
        sProperties = "REQUDATE, DUEDATE, CALCDATE, DerDemandID"
        loadRequest.IDOName = "SL.SLOrdplan000s"
        loadRequest.PropertyList = New PropertyList(sProperties)
        loadRequest.CustomLoadMethod = New CustomLoadMethod With {
            .Name = "CLM_ApsGetOrdplanSp"
        }
        loadRequest.CustomLoadMethod.Parameters.Add(ruOrdDetail.sSiteID)
        loadRequest.CustomLoadMethod.Parameters.Add(ruOrdDetail.sOrderID)
        loadRequest.CustomLoadMethod.Parameters.Add(ruOrdDetail.lAltNo)
        loadRequest.RecordCap = 0
        oData = Me.Context.Commands.LoadCollection(loadRequest)

        If oData.Items.Count = 0 Then
            GetOrdSummary = ERR_NODATA
            msStatus = CTPErrorMsg(GetOrdSummary)
            Exit Function
        End If

        ' Save order summary information
        requdateIx = oData.PropertyList.IndexOf("REQUDATE")
        duedateIx = oData.PropertyList.IndexOf("DUEDATE")
        calcdateIx = oData.PropertyList.IndexOf("CALCDATE")
        derdemandidIx = oData.PropertyList.IndexOf("DerDemandID")

        For Each item As IDOItem In oData.Items
            ruOrdDetail.sDemandID = item.PropertyValues(derdemandidIx).ToString()
            ruOrdDetail.datReqDate = item.PropertyValues(requdateIx).GetValue(Of Date)()
            ruOrdDetail.datPromDate = item.PropertyValues(duedateIx).GetValue(Of Date)()
            ruOrdDetail.datCalcDate = item.PropertyValues(calcdateIx).GetValue(Of Date)()
            Exit For
        Next
        If ruOrdDetail.lMatlTag > 0 Then
            ruOrdDetail.sDemandID = ruOrdDetail.sDemandID + " (PLN " + ruOrdDetail.lMatlTag.ToString() + ")"
        End If

        If ruOrdDetail.datCalcDate > MIN_DATE Then
            ruOrdDetail.dLateness = DateDiff("n", ruOrdDetail.datPromDate, ruOrdDetail.datCalcDate) / 1440.0#
        Else
            ruOrdDetail.dLateness = 0.0#
        End If

        oData = Nothing

        ' Success
        GetOrdSummary = ERR_OK
        Exit Function

GetOrdSummaryErr:
        GetOrdSummary = ERR_VBRT
        msStatus = "GetOrdSummary:  " & Err.Number & " - " & Err.Description & " " & Err.Source

    End Function

    Private Function GetAltPlan(ByRef ruOrdDetail As uOrdDetail) As Integer

        Dim sProperties As String
        Dim sFilter As String
        Dim oData As LoadCollectionResponseData
        Dim lastsynchIx As Integer

        On Error GoTo GetAltPlanErr

        ' Get summary record
        sProperties = "Lastsynch"
        sFilter = "Altno = " & ruOrdDetail.lAltNo.ToString
        oData = Me.Context.Commands.LoadCollection("SL.SLAltplans", sProperties, sFilter, "", 0)
        If oData.Items.Count = 0 Then
            mdatAPSNow = Now
        Else
            lastsynchIx = oData.PropertyList.IndexOf("Lastsynch")
            For Each item As IDOItem In oData.Items
                mdatAPSNow = item.PropertyValues(lastsynchIx).GetValue(Of Date)()
                Exit For
            Next
        End If
        oData = Nothing
        ruOrdDetail.datPlannerStartDate = mdatAPSNow

        ' Success
        GetAltPlan = ERR_OK
        Exit Function

GetAltPlanErr:
        GetAltPlan = ERR_VBRT
        msStatus = "GetAltPlan:  " & Err.Number & " - " & Err.Description & " " & Err.Source

    End Function

    Private Function GetOrdLeaves(ByRef ruOrdDetail As uOrdDetail) As Integer

        Dim sProperties As String
        Dim loadRequest As New LoadCollectionRequestData
        Dim oData As LoadCollectionResponseData
        Dim lIndex As Integer
        Dim matltag, pmatltag As Integer
        Dim matltagIx, loadidIx, pmatltagIx, materialidIx, startdateIx, enddateIx As Integer
        Dim pbomidIx, mpnflagsIx, pjsidIx, matlflagsIx, matldescrIx As Integer
        Dim fleadtimeIx, vleadtimeIx, fexpltimeIx, vexpltimeIx As Integer
        Dim ordminIx, ordmaxIx, ordmultIx, dayssupplyIx As Integer
        Dim lTags() As Integer

        On Error GoTo GetOrdLeavesErr

        ' Get MATLPLAN records
        sProperties = "MATLTAG, LOADID, PMATLTAG, MATERIALID, STARTDATE, ENDDATE, " &
                      "PBOMID, MATLPLANFLAGS, MATLFLAGS, MATLDESCR, PJSID, " &
                      "FLEADTIME, VLEADTIME, FEXPLTIME, VEXPLTIME, ORDMIN, ORDMAX, ORDMULT, DAYSSUPPLY"
        loadRequest.IDOName = "SL.SLMatlplan000s"
        loadRequest.PropertyList = New PropertyList(sProperties)
        loadRequest.CustomLoadMethod = New CustomLoadMethod With {
            .Name = "CLM_ApsGetMatlplanSp"
        }
        loadRequest.CustomLoadMethod.Parameters.Add(ruOrdDetail.sSiteID)
        loadRequest.CustomLoadMethod.Parameters.Add(ruOrdDetail.sOrderID)
        loadRequest.CustomLoadMethod.Parameters.Add(ruOrdDetail.lAltNo)
        loadRequest.RecordCap = 0
        oData = Me.Context.Commands.LoadCollection(loadRequest)

        matltagIx = oData.PropertyList.IndexOf("MATLTAG")
        loadidIx = oData.PropertyList.IndexOf("LOADID")
        pmatltagIx = oData.PropertyList.IndexOf("PMATLTAG")
        materialidIx = oData.PropertyList.IndexOf("MATERIALID")
        startdateIx = oData.PropertyList.IndexOf("STARTDATE")
        enddateIx = oData.PropertyList.IndexOf("ENDDATE")
        pbomidIx = oData.PropertyList.IndexOf("PBOMID")
        mpnflagsIx = oData.PropertyList.IndexOf("MATLPLANFLAGS")
        pjsidIx = oData.PropertyList.IndexOf("PJSID")
        matlflagsIx = oData.PropertyList.IndexOf("MATLFLAGS")
        matldescrIx = oData.PropertyList.IndexOf("MATLDESCR")
        fleadtimeIx = oData.PropertyList.IndexOf("FLEADTIME")
        vleadtimeIx = oData.PropertyList.IndexOf("VLEADTIME")
        fexpltimeIx = oData.PropertyList.IndexOf("FEXPLTIME")
        vexpltimeIx = oData.PropertyList.IndexOf("VEXPLTIME")
        ordminIx = oData.PropertyList.IndexOf("ORDMIN")
        ordmaxIx = oData.PropertyList.IndexOf("ORDMAX")
        ordmultIx = oData.PropertyList.IndexOf("ORDMULT")
        dayssupplyIx = oData.PropertyList.IndexOf("DAYSSUPPLY")

        ' Find smallest/largest MATLTAG
        ruOrdDetail.lHashCount = 0
        ruOrdDetail.lLeafCount = 0
        ruOrdDetail.lMinimumMatlTag = Integer.MaxValue
        ruOrdDetail.lMaximumMatlTag = Integer.MinValue
        For Each item As IDOItem In oData.Items
            matltag = item.PropertyValues(matltagIx).GetValue(Of Integer)()
            If matltag > ruOrdDetail.lMaximumMatlTag Then
                ruOrdDetail.lMaximumMatlTag = matltag
            End If
            If matltag < ruOrdDetail.lMinimumMatlTag Then
                ruOrdDetail.lMinimumMatlTag = matltag
            End If
            If matltag = ruOrdDetail.lMatlTag Then
                pmatltag = item.PropertyValues(pmatltagIx).GetValue(Of Integer)()
                If pmatltag = 0 Then
                    ruOrdDetail.lMatlTag = 0
                End If
            End If
            ruOrdDetail.lLeafCount = ruOrdDetail.lLeafCount + 1
        Next
        ruOrdDetail.lHashCount = ruOrdDetail.lMaximumMatlTag - ruOrdDetail.lMinimumMatlTag + 1

        ' Allocate storage for leaves
        ReDim ruOrdDetail.lHashList(ruOrdDetail.lHashCount)
        ReDim ruOrdDetail.uLeafList(ruOrdDetail.lLeafCount)

        ' Save leaf information
        lIndex = 0
        For Each item As IDOItem In oData.Items

            ' Initialize leaf info
            ruOrdDetail.uLeafList(lIndex).sPartID = item.PropertyValues(materialidIx).ToString()
            ruOrdDetail.uLeafList(lIndex).sPartDescr = item.PropertyValues(matldescrIx).ToString()
            ruOrdDetail.uLeafList(lIndex).lPartFlags = item.PropertyValues(matlflagsIx).GetValue(Of Integer)()
            ruOrdDetail.uLeafList(lIndex).lMatltag = item.PropertyValues(matltagIx).GetValue(Of Integer)()
            ruOrdDetail.uLeafList(lIndex).lParentTag = item.PropertyValues(pmatltagIx).GetValue(Of Integer)()
            ruOrdDetail.uLeafList(lIndex).lLoadID = item.PropertyValues(loadidIx).GetValue(Of Integer)()
            ruOrdDetail.uLeafList(lIndex).sBomID = item.PropertyValues(pbomidIx).ToString()
            ruOrdDetail.uLeafList(lIndex).datStartDate = item.PropertyValues(startdateIx).GetValue(Of Date)()
            ruOrdDetail.uLeafList(lIndex).datEndDate = item.PropertyValues(enddateIx).GetValue(Of Date)()
            If (item.PropertyValues(mpnflagsIx).GetValue(Of Integer)() And ERDB.Server.VAL_MPNFLAGS_CRITPATH) <> 0 Then
                ruOrdDetail.uLeafList(lIndex).bCritDelay = True
            Else
                ruOrdDetail.uLeafList(lIndex).bCritDelay = False
            End If
            If (item.PropertyValues(mpnflagsIx).GetValue(Of Integer)() And ERDB.Server.VAL_MPNFLAGS_PUSHCRITPATH) <> 0 Then
                ruOrdDetail.uLeafList(lIndex).bPushCritDelay = True
            Else
                ruOrdDetail.uLeafList(lIndex).bPushCritDelay = False
            End If
            ruOrdDetail.uLeafList(lIndex).bItemDelay = False
            ruOrdDetail.uLeafList(lIndex).bGroupDelay = False
            ruOrdDetail.uLeafList(lIndex).bFiniteGroupDelay = False
            ruOrdDetail.lHashList(ruOrdDetail.uLeafList(lIndex).lMatltag - ruOrdDetail.lMinimumMatlTag) = lIndex
            ruOrdDetail.uLeafList(lIndex).sOperID = item.PropertyValues(pjsidIx).ToString()
            ruOrdDetail.uLeafList(lIndex).lMergeTo = -1
            ruOrdDetail.uLeafList(lIndex).lMergeIdx = -1
            ruOrdDetail.uLeafList(lIndex).lFlags = item.PropertyValues(mpnflagsIx).GetValue(Of Integer)()
            If (ruOrdDetail.uLeafList(lIndex).lFlags And ERDB.Server.VAL_MPNFLAGS_ALTPART) <> 0 Then
                ruOrdDetail.uLeafList(lIndex).lPartFlags = ruOrdDetail.uLeafList(lIndex).lPartFlags Or ERDB.Server.VAL_PRTFLAGS_ALTPART
            End If
            ruOrdDetail.uLeafList(lIndex).dFLeadtime = item.PropertyValues(fleadtimeIx).GetValue(Of Double)()
            ruOrdDetail.uLeafList(lIndex).dVLeadtime = item.PropertyValues(vleadtimeIx).GetValue(Of Double)()
            ruOrdDetail.uLeafList(lIndex).dFExpLeadtime = item.PropertyValues(fexpltimeIx).GetValue(Of Double)()
            ruOrdDetail.uLeafList(lIndex).dVExpLeadtime = item.PropertyValues(vexpltimeIx).GetValue(Of Double)()
            ruOrdDetail.uLeafList(lIndex).dOrdMin = item.PropertyValues(ordminIx).GetValue(Of Double)()
            ruOrdDetail.uLeafList(lIndex).dOrdMax = item.PropertyValues(ordmaxIx).GetValue(Of Double)()
            ruOrdDetail.uLeafList(lIndex).dOrdMult = item.PropertyValues(ordmultIx).GetValue(Of Double)()
            ruOrdDetail.uLeafList(lIndex).lDaysSupply = item.PropertyValues(dayssupplyIx).GetValue(Of Integer)()

            lIndex = lIndex + 1
        Next
        oData = Nothing

        Call InitializeLeafInfo(ruOrdDetail)

        ' Success
        GetOrdLeaves = ERR_OK
        Exit Function

GetOrdLeavesErr:
        GetOrdLeaves = ERR_VBRT
        msStatus = "GetOrdLeaves:  " & Err.Number & " - " & Err.Description & " " & Err.Source

    End Function

    Private Function GetLeafEvents(ByRef ruOrdDetail As uOrdDetail) As Integer

        Dim sProperties As String
        Dim loadRequest As New LoadCollectionRequestData
        Dim oData As LoadCollectionResponseData
        Dim iFlags As Integer
        Dim lSchType As Integer
        Dim lSchFlags As Integer
        Dim lLeafIndex As Integer
        Dim lParentLeaf As Integer
        Dim lParentTag As Integer
        Dim lEventIndex As Integer
        Dim lMatltag As Integer
        Dim sJsid As String
        Dim lIndex As Integer
        Dim datRequestDate As Date
        Dim datSupplyDate As Date
        Dim dSlack As Double
        Dim matltagIx, schdateIx, demandIx, supplyIx, schtypeIx, schflagsIx As Integer
        Dim suporderIx, startdateIx, orderidIx, demorderidIx, rsiteidIx As Integer
        Dim dersupplyidIx, dersupplydateIx, flagsIx, supmatltagIx, supqtyIx As Integer

        On Error GoTo GetLeafEventsErr

        ' Get MATLPLAN records
        iFlags = 1
        sProperties = "MATLTAG, SCHDATE, DEMAND, SUPPLY, SCHTYPE, SCHFLAGS, " &
                      "SUPORDER, STARTDATE, ORDERID, DEMORDERID, RSITEID, " &
                      "DerSupplyID, DerSupplyDate, FLAGS, SUPMATLTAG, SUPQTY "
        loadRequest.IDOName = "SL.SLInvplan000s"
        loadRequest.PropertyList = New PropertyList(sProperties)
        loadRequest.CustomLoadMethod = New CustomLoadMethod With {
            .Name = "CLM_ApsGetInvplanSp"
        }
        loadRequest.CustomLoadMethod.Parameters.Add(ruOrdDetail.sSiteID)
        loadRequest.CustomLoadMethod.Parameters.Add(ruOrdDetail.sOrderID)
        loadRequest.CustomLoadMethod.Parameters.Add(iFlags)
        loadRequest.CustomLoadMethod.Parameters.Add(ruOrdDetail.lAltNo)

        loadRequest.RecordCap = 0
        oData = Me.Context.Commands.LoadCollection(loadRequest)

        matltagIx = oData.PropertyList.IndexOf("MATLTAG")
        schdateIx = oData.PropertyList.IndexOf("SCHDATE")
        demandIx = oData.PropertyList.IndexOf("DEMAND")
        supplyIx = oData.PropertyList.IndexOf("SUPPLY")
        schtypeIx = oData.PropertyList.IndexOf("SCHTYPE")
        schflagsIx = oData.PropertyList.IndexOf("SCHFLAGS")
        suporderIx = oData.PropertyList.IndexOf("SUPORDER")
        startdateIx = oData.PropertyList.IndexOf("STARTDATE")
        orderidIx = oData.PropertyList.IndexOf("ORDERID")
        demorderidIx = oData.PropertyList.IndexOf("DEMORDERID")
        rsiteidIx = oData.PropertyList.IndexOf("RSITEID")
        dersupplyidIx = oData.PropertyList.IndexOf("DerSupplyID")
        dersupplydateIx = oData.PropertyList.IndexOf("DerSupplyDate")
        flagsIx = oData.PropertyList.IndexOf("FLAGS")
        supmatltagIx = oData.PropertyList.IndexOf("SUPMATLTAG")
        supqtyIx = oData.PropertyList.IndexOf("SUPQTY")

        For Each item As IDOItem In oData.Items

            lMatltag = item.PropertyValues(matltagIx).GetValue(Of Integer)()
            lLeafIndex = ruOrdDetail.lHashList(lMatltag - ruOrdDetail.lMinimumMatlTag)
            If Not ruOrdDetail.uLeafList(lLeafIndex).bSkip Then
                lSchType = item.PropertyValues(schtypeIx).GetValue(Of Integer)()
                lSchFlags = item.PropertyValues(schflagsIx).GetValue(Of Integer)()

                If lSchType = ERDB.Server.VAL_IPNTYPE_MFG Then
                    ruOrdDetail.uLeafList(lLeafIndex).dMfgQuantity = ruOrdDetail.uLeafList(lLeafIndex).dMfgQuantity _
                                                                         + item.PropertyValues(supplyIx).GetValue(Of Double)()
                Else
                    lEventIndex = ruOrdDetail.uLeafList(lLeafIndex).lInvCount
                    ReDim Preserve ruOrdDetail.uLeafList(lLeafIndex).lInvSort(lEventIndex)
                    ReDim Preserve ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex)
                    ruOrdDetail.uLeafList(lLeafIndex).lInvSort(lEventIndex) = lEventIndex
                    ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).datInvDate = item.PropertyValues(schdateIx).GetValue(Of Date)()
                    ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).datReqDate = item.PropertyValues(startdateIx).GetValue(Of Date)()
                    If Not item.PropertyValues(dersupplydateIx).IsNull Then
                        datSupplyDate = item.PropertyValues(dersupplydateIx).GetValue(Of Date)()
                    Else
                        datSupplyDate = ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).datInvDate
                    End If
                    If datSupplyDate < mdatAPSNow Then
                        datSupplyDate = mdatAPSNow
                    End If
                    ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).datSupplyDate = datSupplyDate
                    If ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).datInvDate < ruOrdDetail.datStartDate Then
                        ruOrdDetail.datStartDate = ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).datInvDate
                    End If
                    If item.PropertyValues(supqtyIx).IsNull Then
                        ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).dSupQty = 0.0
                    Else
                        ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).dSupQty = item.PropertyValues(supqtyIx).GetValue(Of Double)()
                    End If

                    ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).dDemand = item.PropertyValues(demandIx).GetValue(Of Double)()
                    ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).dSupply = item.PropertyValues(supplyIx).GetValue(Of Double)()
                    ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).lSchFlags = lSchFlags
                    ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).lSchType = lSchType
                    ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).dExpedited = 0
                    ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).lSupMatlTag = -1

                    ' If demand = supply, this must be a safety stock or replenishment order.
                    ' In such a case, we want to show the demand quantity (even though it isn't being used)
                    If ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).dDemand = ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).dSupply Then
                        ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).dSupply = 0
                    End If

                    If Not item.PropertyValues(suporderIx).IsNull Then
                        If Not item.PropertyValues(orderidIx).IsNull Or
                           Not item.PropertyValues(demorderidIx).IsNull Then
                            ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).sOrderID = item.PropertyValues(suporderIx).ToString()
                            ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).sSupplyID = item.PropertyValues(dersupplyidIx).ToString()
                            If item.PropertyValues(demorderidIx).IsNull Then
                                ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).sSupplyID = item.PropertyValues(suporderIx).ToString()
                            End If
                            If Not item.PropertyValues(demorderidIx).IsNull Then
                                If ((item.PropertyValues(flagsIx).GetValue(Of Integer)() And ERDB.Server.VAL_ORDFLAGS_SUPPLY) = 0) And (item.PropertyValues(supmatltagIx).GetValue(Of Integer)() <> lMatltag) Then
                                    ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).lSchFlags = lSchFlags + ERDB.Server.VAL_IPNFLAGS_DRILLDOWNOK
                                    ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).lSupMatlTag = item.PropertyValues(supmatltagIx).GetValue(Of Integer)()
                                End If
                            ElseIf Not item.PropertyValues(rsiteidIx).IsNull Then
                                ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).lSchFlags = lSchFlags + ERDB.Server.VAL_IPNFLAGS_DRILLDOWNOK
                            End If
                        Else
                            ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).sOrderID = item.PropertyValues(suporderIx).ToString()
                            ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).sSupplyID = item.PropertyValues(dersupplyidIx).ToString()
                        End If

                        ' Purchased part supply usage calculations
                        If (ruOrdDetail.uLeafList(lLeafIndex).lPartFlags And ERDB.Server.VAL_PRTFLAGS_PURCHASED) <> 0 Then

                            ' Pre-compute slack for use of purchased part supplies
                            dSlack = DateDiff("n", ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).datSupplyDate, ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).datInvDate) / 60.0#
                            If dSlack < 0.0# Then
                                dSlack = 0.0#
                            End If
                            If (ruOrdDetail.uLeafList(lLeafIndex).dSlackTime = -1.0#) Or (dSlack < ruOrdDetail.uLeafList(lLeafIndex).dSlackTime) Then
                                ruOrdDetail.uLeafList(lLeafIndex).dSlackTime = dSlack
                            End If

                            ' Update leaf startdate based on leadtime for the purchased part
                            datRequestDate = item.PropertyValues(startdateIx).GetValue(Of Date)()
                            If datRequestDate < ruOrdDetail.uLeafList(lLeafIndex).datStartDate Then
                                ruOrdDetail.uLeafList(lLeafIndex).datStartDate = datRequestDate
                            End If
                        End If

                    Else
                        ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).sOrderID = ""
                        ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).sSupplyID = ""
                    End If

                    If Not item.PropertyValues(rsiteidIx).IsNull Then
                        ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).sRemoteSite = item.PropertyValues(rsiteidIx).ToString()
                    Else
                        ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).sRemoteSite = ""
                    End If
                    ruOrdDetail.uLeafList(lLeafIndex).lInvCount = lEventIndex + 1

                    Select Case (lSchType)
                        Case ERDB.Server.VAL_IPNTYPE_USEFIN
                            ruOrdDetail.uLeafList(lLeafIndex).dInvQuantity = ruOrdDetail.uLeafList(lLeafIndex).dInvQuantity _
                                                                             + ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).dDemand
                        Case ERDB.Server.VAL_IPNTYPE_USESUP
                            ruOrdDetail.uLeafList(lLeafIndex).dSupQuantity = ruOrdDetail.uLeafList(lLeafIndex).dSupQuantity _
                                                                             + ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).dDemand
                        Case ERDB.Server.VAL_IPNTYPE_PURCHASE
                            ruOrdDetail.uLeafList(lLeafIndex).dPurchaseQuantity = ruOrdDetail.uLeafList(lLeafIndex).dPurchaseQuantity _
                                                                             + ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).dDemand _
                                                                             - ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).dSupply
                        Case ERDB.Server.VAL_IPNTYPE_UNCONSTRAINED
                            ruOrdDetail.uLeafList(lLeafIndex).dUnconstrainedQuantity = ruOrdDetail.uLeafList(lLeafIndex).dUnconstrainedQuantity _
                                                                             + ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).dDemand _
                                                                             - ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).dSupply
                        Case ERDB.Server.VAL_IPNTYPE_FORCEFIN
                            ruOrdDetail.uLeafList(lLeafIndex).dUnconstrainedQuantity = ruOrdDetail.uLeafList(lLeafIndex).dUnconstrainedQuantity _
                                                                             + ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).dDemand
                        Case ERDB.Server.VAL_IPNTYPE_BYPRODUCT
                            ruOrdDetail.uLeafList(lLeafIndex).dSupQuantity = ruOrdDetail.uLeafList(lLeafIndex).dSupQuantity _
                                                                             + ruOrdDetail.uLeafList(lLeafIndex).uInvList(lEventIndex).dSupply
                    End Select
                End If
            End If
        Next
        oData = Nothing

        ' Compute demand quantity for each leaf
        For lLeafIndex = 0 To ruOrdDetail.lLeafCount - 1
            If Not ruOrdDetail.uLeafList(lLeafIndex).bSkip Then
                ruOrdDetail.uLeafList(lLeafIndex).dQuantity = ruOrdDetail.uLeafList(lLeafIndex).dInvQuantity _
                                                          + ruOrdDetail.uLeafList(lLeafIndex).dSupQuantity _
                                                          + ruOrdDetail.uLeafList(lLeafIndex).dPurchaseQuantity _
                                                          + ruOrdDetail.uLeafList(lLeafIndex).dUnconstrainedQuantity _
                                                          + ruOrdDetail.uLeafList(lLeafIndex).dMfgQuantity
            End If
        Next lLeafIndex

        ' Success
        GetLeafEvents = ERR_OK
        Exit Function

GetLeafEventsErr:
        GetLeafEvents = ERR_VBRT
        msStatus = "GetLeafEvents:  " & Err.Number & " - " & Err.Description & " " & Err.Source

    End Function

    Private Function GetLeafOperations(ByRef ruOrdDetail As uOrdDetail) As Integer

        Dim sProperties As String
        Dim iFlags As Integer
        Dim loadRequest As New LoadCollectionRequestData
        Dim oData As LoadCollectionResponseData
        Dim lLastJobtag As Integer
        Dim lJobtag As Integer
        Dim lMatltag As Integer
        Dim lLeafIndex As Integer
        Dim lOperIndex As Integer
        Dim lGrpIndex As Integer
        Dim lResIndex As Integer
        Dim lUsageIndex As Integer
        Dim matltagIx, jobtagIx, seqnoIx, procplanidIx, jsidIx, operdescrIx As Integer
        Dim startdateIx, enddateIx, quantityIx, residIx, groupidIx As Integer
        Dim groupdescrIx, sltypeIx, flagsIx, infcapIx As Integer
        Dim resdescrIx, shift1Ix, shift2Ix, shift3Ix, shift4Ix As Integer
        Dim schflagsIx, demandIx, resstartdateIx, resenddateIx As Integer
        Dim wcIx, durationIx, nummbrsIx As Integer
        Dim datStartDate, datEndDate As Date
        Dim dInfcap As Double
        Dim sGroupID As String
        Dim sResrcID As String
        Dim bFound As Boolean

        On Error GoTo GetLeafOperationsErr

        ' Get JOBPLAN/RESPLAN records
        sProperties = "MATLTAG, JOBTAG, SEQNO, PROCPLANID, JSID, OPERDESCR, " &
                      "STARTDATE, ENDDATE, QUANTITY, RESID, RESDESCR, GROUPID, " &
                      "GROUPDESCR, FLAGS, INFCAP, SLTYPE, SHIFTID1, SHIFTID2, SHIFTID3, SHIFTID4, " &
                      "wc, DURATION, NUMMBRS, RESSTARTDATE, RESENDDATE"
        loadRequest.IDOName = "SL.SLJobplan000s"
        loadRequest.PropertyList = New PropertyList(sProperties)
        loadRequest.CustomLoadMethod = New CustomLoadMethod With {
            .Name = "CLM_ApsGetJobplanSp"
        }
        loadRequest.CustomLoadMethod.Parameters.Add(ruOrdDetail.sSiteID)
        loadRequest.CustomLoadMethod.Parameters.Add(ruOrdDetail.sOrderID)
        loadRequest.CustomLoadMethod.Parameters.Add(ruOrdDetail.lAltNo)
        loadRequest.RecordCap = 0
        oData = Me.Context.Commands.LoadCollection(loadRequest)

        matltagIx = oData.PropertyList.IndexOf("MATLTAG")
        jobtagIx = oData.PropertyList.IndexOf("JOBTAG")
        seqnoIx = oData.PropertyList.IndexOf("SEQNO")
        procplanidIx = oData.PropertyList.IndexOf("PROCPLANID")
        jsidIx = oData.PropertyList.IndexOf("JSID")
        operdescrIx = oData.PropertyList.IndexOf("OPERDESCR")
        startdateIx = oData.PropertyList.IndexOf("STARTDATE")
        enddateIx = oData.PropertyList.IndexOf("ENDDATE")
        quantityIx = oData.PropertyList.IndexOf("QUANTITY")
        residIx = oData.PropertyList.IndexOf("RESID")
        resdescrIx = oData.PropertyList.IndexOf("RESDESCR")
        groupidIx = oData.PropertyList.IndexOf("GROUPID")
        groupdescrIx = oData.PropertyList.IndexOf("GROUPDESCR")
        flagsIx = oData.PropertyList.IndexOf("FLAGS")
        infcapIx = oData.PropertyList.IndexOf("INFCAP")
        sltypeIx = oData.PropertyList.IndexOf("SLTYPE")
        shift1Ix = oData.PropertyList.IndexOf("SHIFTID1")
        shift2Ix = oData.PropertyList.IndexOf("SHIFTID2")
        shift3Ix = oData.PropertyList.IndexOf("SHIFTID3")
        shift4Ix = oData.PropertyList.IndexOf("SHIFTID4")
        wcIx = oData.PropertyList.IndexOf("wc")
        durationIx = oData.PropertyList.IndexOf("DURATION")
        nummbrsIx = oData.PropertyList.IndexOf("NUMMBRS")
        resstartdateIx = oData.PropertyList.IndexOf("RESSTARTDATE")
        resenddateIx = oData.PropertyList.IndexOf("RESENDDATE")

        lLastJobtag = -1
        For Each item As IDOItem In oData.Items
            lMatltag = item.PropertyValues(matltagIx).GetValue(Of Integer)()
            lLeafIndex = ruOrdDetail.lHashList(lMatltag - ruOrdDetail.lMinimumMatlTag)
            If Not ruOrdDetail.uLeafList(lLeafIndex).bSkip Then
                lJobtag = item.PropertyValues(jobtagIx).GetValue(Of Integer)()
                If lJobtag <> lLastJobtag Then
                    lLastJobtag = lJobtag
                    lOperIndex = ruOrdDetail.uLeafList(lLeafIndex).lOperCount
                    If lOperIndex = 0 Then
                        ruOrdDetail.uLeafList(lLeafIndex).sRouteID = item.PropertyValues(procplanidIx).ToString()
                    End If

                    ReDim Preserve ruOrdDetail.uLeafList(lLeafIndex).lOperSort(lOperIndex)
                    ReDim Preserve ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex)
                    ruOrdDetail.uLeafList(lLeafIndex).lOperSort(lOperIndex) = lOperIndex
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).sOperID = item.PropertyValues(jsidIx).ToString()
                    If item.PropertyValues(operdescrIx).IsNull Then
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).sOperDescr = ""
                    Else
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).sOperDescr = item.PropertyValues(operdescrIx).ToString()
                    End If
                    If item.PropertyValues(seqnoIx).GetValue(Of Integer)() > 0 Then
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).lSeqno = item.PropertyValues(seqnoIx).GetValue(Of Integer)()
                    Else
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).lSeqno = lOperIndex + 1
                    End If
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).lFlags = item.PropertyValues(flagsIx).GetValue(Of Integer)()

                    datStartDate = item.PropertyValues(startdateIx).GetValue(Of Date)()
                    datEndDate = item.PropertyValues(enddateIx).GetValue(Of Date)()
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).datStartDate = datStartDate
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).datEndDate = datEndDate
                    If datStartDate < ruOrdDetail.datStartDate Then
                        ruOrdDetail.datStartDate = datStartDate
                    End If

                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).dQuantity = item.PropertyValues(quantityIx).GetValue(Of Double)()
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).dWIPQuantity = 0.0#
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).lGrpCount = 0
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).lPartCount = 0
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).bCritDelay = False
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).bPushCritDelay = False
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).bItemDelay = False
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).bGroupDelay = False
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).bFiniteGroupDelay = False
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).sWorkcenter = item.PropertyValues(wcIx).ToString()
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).dDuration = item.PropertyValues(durationIx).GetValue(Of Double)()
                    ruOrdDetail.uLeafList(lLeafIndex).lOperCount = lOperIndex + 1
                Else
                    lOperIndex = ruOrdDetail.uLeafList(lLeafIndex).lOperCount - 1
                End If

                If Not item.PropertyValues(residIx).IsNull Then
                    'If (item.PropertyValues(flagsIx).GetValue(Of Integer)() And ERDB.Server.VAL_OPNFLAGS_START) <> 0 Then
                    sGroupID = item.PropertyValues(groupidIx).ToString()
                    bFound = False
                    For lGrpIndex = 0 To ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).lGrpCount - 1
                        If sGroupID = ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).sGroupID Then
                            bFound = True
                            Exit For
                        End If
                    Next
                    If Not bFound Then
                        lGrpIndex = ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).lGrpCount
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).lGrpCount = lGrpIndex + 1
                        ReDim Preserve ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).lGrpSort(lGrpIndex)
                        ReDim Preserve ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex)
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).lGrpSort(lGrpIndex) = lGrpIndex
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).sGroupID = sGroupID
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).sGroupDescr = item.PropertyValues(groupdescrIx).ToString()
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).lMembers = item.PropertyValues(nummbrsIx).GetValue(Of Integer)()
                        dInfcap = item.PropertyValues(infcapIx).GetValue(Of Double)()
                        If dInfcap > 0 Then
                            ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).bFiniteGroup = True
                        Else
                            ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).bFiniteGroup = False
                        End If
                        If item.PropertyValues(sltypeIx).ToString() = "L" Then
                            ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).bLaborGroup = True
                        Else
                            ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).bLaborGroup = False
                        End If
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).dWaitTime = 0
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).dPushWait = 0
                    End If
                    sResrcID = item.PropertyValues(residIx).ToString()
                    bFound = False
                    For lResIndex = 0 To ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).lResCount - 1
                        If sResrcID = ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).uResList(lResIndex).sResrcID Then
                            bFound = True
                            Exit For
                        End If
                    Next
                    If Not bFound Then
                        lResIndex = ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).lResCount
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).lResCount = lResIndex + 1
                        ReDim Preserve ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).uResList(lResIndex)
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).uResList(lResIndex).sResrcID = item.PropertyValues(residIx).ToString()
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).uResList(lResIndex).sResrcDescr = item.PropertyValues(resdescrIx).ToString()
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).uResList(lResIndex).sShift1 = item.PropertyValues(shift1Ix).ToString()
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).uResList(lResIndex).sShift2 = item.PropertyValues(shift2Ix).ToString()
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).uResList(lResIndex).sShift3 = item.PropertyValues(shift3Ix).ToString()
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).uResList(lResIndex).sShift4 = item.PropertyValues(shift4Ix).ToString()
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).uResList(lResIndex).lUsageCount = 0
                    End If
                    lUsageIndex = ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).uResList(lResIndex).lUsageCount
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).uResList(lResIndex).lUsageCount = lUsageIndex + 1
                    ReDim Preserve ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).uResList(lResIndex).uUsageList(lUsageIndex)
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).uResList(lResIndex).uUsageList(lUsageIndex).lUsageType = RES_USAGETYPE_BUSY
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).uResList(lResIndex).uUsageList(lUsageIndex).datStartDate = item.PropertyValues(resstartdateIx).GetValue(Of Date)()
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).uResList(lResIndex).uUsageList(lUsageIndex).datEndDate = item.PropertyValues(resenddateIx).GetValue(Of Date)()
                End If
            End If
            'End If
        Next
        oData = Nothing

        ' Create dummy operation for MRP parts
        iFlags = 2
        sProperties = "MATLTAG, SCHFLAGS, DEMAND"
        loadRequest.IDOName = "SL.SLInvplan000s"
        loadRequest.PropertyList = New PropertyList(sProperties)
        loadRequest.CustomLoadMethod = New CustomLoadMethod With {
            .Name = "CLM_ApsGetInvplanSp"
        }
        loadRequest.CustomLoadMethod.Parameters.Add(ruOrdDetail.sSiteID)
        loadRequest.CustomLoadMethod.Parameters.Add(ruOrdDetail.sOrderID)
        loadRequest.CustomLoadMethod.Parameters.Add(iFlags)
        loadRequest.CustomLoadMethod.Parameters.Add(ruOrdDetail.lAltNo)

        loadRequest.RecordCap = 0
        oData = Me.Context.Commands.LoadCollection(loadRequest)

        matltagIx = oData.PropertyList.IndexOf("MATLTAG")
        schflagsIx = oData.PropertyList.IndexOf("SCHFLAGS")
        demandIx = oData.PropertyList.IndexOf("DEMAND")

        For Each item As IDOItem In oData.Items
            lMatltag = item.PropertyValues(matltagIx).GetValue(Of Integer)()
            lLeafIndex = ruOrdDetail.lHashList(lMatltag - ruOrdDetail.lMinimumMatlTag)
            If Not ruOrdDetail.uLeafList(lLeafIndex).bSkip Then
                If (ruOrdDetail.uLeafList(lLeafIndex).lOperCount = 0) Then
                    ruOrdDetail.uLeafList(lLeafIndex).sRouteID = ""
                    ReDim Preserve ruOrdDetail.uLeafList(lLeafIndex).lOperSort(0)
                    ReDim Preserve ruOrdDetail.uLeafList(lLeafIndex).uOperList(0)
                    ruOrdDetail.uLeafList(lLeafIndex).lOperSort(0) = 0
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(0).sOperID = ""
                    If (item.PropertyValues(schflagsIx).GetValue(Of Integer)() And ERDB.Server.VAL_IPNFLAGS_EXPEDITED) <> 0 Then
                        ' Using this as an indication that the MRP part is expedited - didn't want to break compatibility
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(0).sOperDescr = "X"
                    Else
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(0).sOperDescr = ""
                    End If
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(0).datStartDate = ruOrdDetail.uLeafList(lLeafIndex).datStartDate
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(0).datEndDate = ruOrdDetail.uLeafList(lLeafIndex).datEndDate
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(0).dQuantity = item.PropertyValues(demandIx).GetValue(Of Double)()
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(0).lSeqno = 1
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(0).lGrpCount = 0
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(0).lPartCount = 0
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(0).dWIPQuantity = 0
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(0).bCritDelay = False
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(0).bPushCritDelay = False
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(0).bItemDelay = False
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(0).bGroupDelay = False
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(0).bFiniteGroupDelay = False
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(0).dDuration = 0
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(0).sWorkcenter = ""
                    ruOrdDetail.uLeafList(lLeafIndex).lOperCount = 1
                End If
            End If
        Next
        oData = Nothing

        ' Success
        GetLeafOperations = ERR_OK
        Exit Function

GetLeafOperationsErr:
        GetLeafOperations = ERR_VBRT
        msStatus = "GetLeafOperations:  " & Err.Number & " - " & Err.Description & " " & Err.Source

    End Function

    Private Function GetLeafOperationWIP(ByRef ruOrdDetail As uOrdDetail) As Integer

        Dim sProperties As String
        Dim iFlags As Integer
        Dim loadRequest As New LoadCollectionRequestData
        Dim oData As LoadCollectionResponseData
        Dim lMatltag As Integer
        Dim sOperID As String
        Dim lLeafIndex As Integer
        Dim lOperIndex As Integer
        Dim lIndex As Integer
        Dim matltagIx, wipjsidIx, schdateIx, demandIx, procplanidIx, wipjsdescrIx As Integer

        On Error GoTo GetLeafOperationWIPErr

        ' Get WIP records
        iFlags = 3
        sProperties = "MATLTAG, WIPJSID, SCHDATE, DEMAND, PROCPLANID, WIPJSDESCR"
        loadRequest.IDOName = "SL.SLInvplan000s"
        loadRequest.PropertyList = New PropertyList(sProperties)
        loadRequest.CustomLoadMethod = New CustomLoadMethod With {
            .Name = "CLM_ApsGetInvplanSp"
        }
        loadRequest.CustomLoadMethod.Parameters.Add(ruOrdDetail.sSiteID)
        loadRequest.CustomLoadMethod.Parameters.Add(ruOrdDetail.sOrderID)
        loadRequest.CustomLoadMethod.Parameters.Add(iFlags)
        loadRequest.CustomLoadMethod.Parameters.Add(ruOrdDetail.lAltNo)
        loadRequest.RecordCap = 0
        oData = Me.Context.Commands.LoadCollection(loadRequest)

        matltagIx = oData.PropertyList.IndexOf("MATLTAG")
        wipjsidIx = oData.PropertyList.IndexOf("WIPJSID")
        schdateIx = oData.PropertyList.IndexOf("SCHDATE")
        demandIx = oData.PropertyList.IndexOf("DEMAND")
        procplanidIx = oData.PropertyList.IndexOf("PROCPLANID")
        wipjsdescrIx = oData.PropertyList.IndexOf("WIPJSDESCR")

        For Each item As IDOItem In oData.Items
            lMatltag = item.PropertyValues(matltagIx).GetValue(Of Integer)()
            lLeafIndex = ruOrdDetail.lHashList(lMatltag - ruOrdDetail.lMinimumMatlTag)
            sOperID = item.PropertyValues(wipjsidIx).ToString()

            If Not ruOrdDetail.uLeafList(lLeafIndex).bSkip Then

                ' Find operation at which WIP is used
                lOperIndex = -1
                For lIndex = 0 To ruOrdDetail.uLeafList(lLeafIndex).lOperCount - 1
                    If ruOrdDetail.uLeafList(lLeafIndex).uOperList(lIndex).sOperID = sOperID Then
                        lOperIndex = lIndex
                        Exit For
                    End If
                Next lIndex

                ' Create WIP usage operation if needed
                If lOperIndex = -1 Then
                    lOperIndex = ruOrdDetail.uLeafList(lLeafIndex).lOperCount
                    If lOperIndex = 0 Then
                        ruOrdDetail.uLeafList(lLeafIndex).sRouteID = item.PropertyValues(procplanidIx).ToString()
                    End If
                    ReDim Preserve ruOrdDetail.uLeafList(lLeafIndex).lOperSort(lOperIndex)
                    ReDim Preserve ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex)

                    ruOrdDetail.uLeafList(lLeafIndex).lOperSort(lOperIndex) = lOperIndex
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).sOperID = sOperID
                    If item.PropertyValues(wipjsdescrIx).IsNull Then
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).sOperDescr = ""
                    Else
                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).sOperDescr = item.PropertyValues(wipjsdescrIx).ToString()
                    End If
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).datStartDate = item.PropertyValues(schdateIx).GetValue(Of Date)()
                    If ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).datStartDate < ruOrdDetail.datStartDate Then
                        ruOrdDetail.datStartDate = ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).datStartDate
                    End If
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).datEndDate = item.PropertyValues(schdateIx).GetValue(Of Date)()
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).dQuantity = item.PropertyValues(demandIx).GetValue(Of Double)()
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).dWIPQuantity = item.PropertyValues(demandIx).GetValue(Of Double)()
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).lSeqno = 1
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).lGrpCount = 0
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).lPartCount = 0
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).bCritDelay = False
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).bPushCritDelay = False
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).bItemDelay = False
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).bGroupDelay = False
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).bFiniteGroupDelay = False
                    ruOrdDetail.uLeafList(lLeafIndex).lOperCount = lOperIndex + 1

                    ' Insert WIP operation at beginning of operation list
                    For lIndex = ruOrdDetail.uLeafList(lLeafIndex).lOperCount - 1 To 1 Step -1
                        ruOrdDetail.uLeafList(lLeafIndex).lOperSort(lIndex) = ruOrdDetail.uLeafList(lLeafIndex).lOperSort(lIndex - 1)
                    Next lIndex
                    ruOrdDetail.uLeafList(lLeafIndex).lOperSort(0) = lOperIndex

                Else
                    ' If WIP usage belongs to existing operation, update record
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).dWIPQuantity = item.PropertyValues(demandIx).GetValue(Of Double)()
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).dQuantity = ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).dQuantity _
                                                                     + item.PropertyValues(demandIx).GetValue(Of Double)()
                End If
            End If
        Next
        oData = Nothing

        ' Success
        GetLeafOperationWIP = ERR_OK
        Exit Function

GetLeafOperationWIPErr:
        GetLeafOperationWIP = ERR_VBRT
        msStatus = "GetLeafOperations:  " & Err.Number & " - " & Err.Description & " " & Err.Source

    End Function

    Private Function GetLeafWait(ByRef ruOrdDetail As uOrdDetail) As Integer

        Dim sProperties As String
        Dim loadRequest As New LoadCollectionRequestData
        Dim oData As LoadCollectionResponseData
        Dim lLeafIndex As Integer
        Dim lChildLeafIndex As Integer
        Dim lIndex As Integer
        Dim lOperIndex As Integer
        Dim lGrpIndex As Integer
        Dim lChildIndex As Integer
        Dim lMatltag As Integer
        Dim sItemcd As String
        Dim sItemid As String
        Dim sJsid As String
        Dim dWait As Double
        Dim matltagIx, jsidIx, itemidIx, itemcdIx, delayIx As Integer

        On Error GoTo GetLeafWaitErr

        ' Get WAIT records
        sProperties = "MATLTAG, JSID, ITEMID, ITEMCD, DELAY"
        loadRequest.IDOName = "SL.SLWait000s"
        loadRequest.PropertyList = New PropertyList(sProperties)
        loadRequest.CustomLoadMethod = New CustomLoadMethod With {
            .Name = "CLM_ApsGetWaitSp"
        }
        loadRequest.CustomLoadMethod.Parameters.Add(ruOrdDetail.sSiteID)
        loadRequest.CustomLoadMethod.Parameters.Add(ruOrdDetail.sOrderID)
        loadRequest.CustomLoadMethod.Parameters.Add(ruOrdDetail.lAltNo)
        loadRequest.RecordCap = 0
        oData = Me.Context.Commands.LoadCollection(loadRequest)

        matltagIx = oData.PropertyList.IndexOf("MATLTAG")
        jsidIx = oData.PropertyList.IndexOf("JSID")
        itemidIx = oData.PropertyList.IndexOf("ITEMID")
        itemcdIx = oData.PropertyList.IndexOf("ITEMCD")
        delayIx = oData.PropertyList.IndexOf("DELAY")

        For Each item As IDOItem In oData.Items
            lMatltag = item.PropertyValues(matltagIx).GetValue(Of Integer)()
            lLeafIndex = ruOrdDetail.lHashList(lMatltag - ruOrdDetail.lMinimumMatlTag)

            If (lLeafIndex >= 0) And Not ruOrdDetail.uLeafList(lLeafIndex).bSkip Then
                sItemcd = item.PropertyValues(itemcdIx).ToString()
                sItemid = item.PropertyValues(itemidIx).ToString()
                sJsid = item.PropertyValues(jsidIx).ToString()
                dWait = item.PropertyValues(delayIx).GetValue(Of Double)()
                If sItemcd = "G" Or sItemcd = "S" Then
                    For lOperIndex = 0 To ruOrdDetail.uLeafList(lLeafIndex).lOperCount - 1
                        If sJsid = ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).sOperID Then
                            For lGrpIndex = 0 To ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).lGrpCount - 1
                                If sItemid = ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).sGroupID Then
                                    If sItemcd = "G" Then
                                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).dWaitTime = dWait
                                    Else
                                        ruOrdDetail.uLeafList(lLeafIndex).uOperList(lOperIndex).uGrpList(lGrpIndex).dPushWait = dWait
                                    End If
                                    Exit For
                                End If
                            Next lGrpIndex
                            Exit For
                        End If
                    Next lOperIndex
                Else
                    lIndex = -1
                    For lChildIndex = 0 To ruOrdDetail.uLeafList(lLeafIndex).lChildCount - 1
                        lChildLeafIndex = ruOrdDetail.uLeafList(lLeafIndex).lChildList(lChildIndex)
                        If sItemid = ruOrdDetail.uLeafList(lChildLeafIndex).sPartID Then
                            If (ruOrdDetail.uLeafList(lChildLeafIndex).lFlags And ERDB.Server.VAL_MPNFLAGS_CRITPATH) <> 0 Then
                                lIndex = lChildLeafIndex
                                Exit For
                            ElseIf lIndex < 0 Then
                                lIndex = lChildLeafIndex
                            End If
                        End If
                    Next lChildIndex

                    If lIndex >= 0 Then
                        ruOrdDetail.uLeafList(lIndex).dWaitTime = dWait
                    ElseIf sItemid = ruOrdDetail.uLeafList(lLeafIndex).sPartID Then
                        ruOrdDetail.uLeafList(lLeafIndex).dWaitTime = dWait
                    End If
                End If
            End If
        Next
        oData = Nothing

        ' Success
        GetLeafWait = ERR_OK

        Exit Function

GetLeafWaitErr:
        GetLeafWait = ERR_VBRT
        msStatus = "GetLeafWait:  " & Err.Number & " - " & Err.Description & " " & Err.Source

    End Function

    Private Function InitializeLeafInfo(ByRef ruOrdDetail As uOrdDetail) As Integer

        Dim lIndex As Integer
        Dim bSkip As Boolean

        On Error GoTo InitializeLeafInfoErr
        If ruOrdDetail.lMatlTag > 0 Then
            bSkip = True
        Else
            bSkip = False
        End If
        For lIndex = 0 To ruOrdDetail.lLeafCount - 1
            ruOrdDetail.uLeafList(lIndex).lParentLeafIndex = -1
            ruOrdDetail.uLeafList(lIndex).lInvCount = 0
            ruOrdDetail.uLeafList(lIndex).lOperCount = 0
            ruOrdDetail.uLeafList(lIndex).lChildCount = 0
            ruOrdDetail.uLeafList(lIndex).dMfgQuantity = 0.0#
            ruOrdDetail.uLeafList(lIndex).dInvQuantity = 0.0#
            ruOrdDetail.uLeafList(lIndex).dSupQuantity = 0.0#
            ruOrdDetail.uLeafList(lIndex).dPurchaseQuantity = 0.0#
            ruOrdDetail.uLeafList(lIndex).dUnconstrainedQuantity = 0.0#
            ruOrdDetail.uLeafList(lIndex).dQuantity = 0.0#
            ruOrdDetail.uLeafList(lIndex).dWaitTime = 0.0#
            ruOrdDetail.uLeafList(lIndex).dSlackTime = -1.0#
            ruOrdDetail.uLeafList(lIndex).sRouteID = ""
            ruOrdDetail.uLeafList(lIndex).bSkip = bSkip
        Next lIndex

        ' Success
        InitializeLeafInfo = ERR_OK
        Exit Function

InitializeLeafInfoErr:
        InitializeLeafInfo = ERR_VBRT
        msStatus = "InitializeLeafInfo:  " & Err.Number & " - " & Err.Description & " " & Err.Source

    End Function

    Private Function ConnectLeaves(ByRef ruOrdDetail As uOrdDetail) As Integer
        Dim lIndex As Integer
        Dim lLeafIndex As Integer
        Dim lParentIndex As Integer
        Dim lChildIndex As Integer
        Dim lGap As Integer
        Dim lSort1 As Integer
        Dim lSort2 As Integer
        Dim lIndex1 As Integer
        Dim lIndex2 As Integer


        ' Sort leaves by ID
        ReDim ruOrdDetail.lLeafSort(ruOrdDetail.lLeafCount)
        For lIndex = 0 To ruOrdDetail.lLeafCount - 1
            ruOrdDetail.lLeafSort(lIndex) = lIndex
        Next lIndex
        lGap = ruOrdDetail.lLeafCount \ 2
        Do While lGap > 0
            For lSort1 = lGap To ruOrdDetail.lLeafCount - 1
                lSort2 = lSort1 - lGap
                Do While lSort2 >= 0
                    lIndex1 = ruOrdDetail.lLeafSort(lSort2)
                    lIndex2 = ruOrdDetail.lLeafSort(lSort2 + lGap)
                    If ruOrdDetail.uLeafList(lIndex1).sPartID > ruOrdDetail.uLeafList(lIndex2).sPartID Then
                        ruOrdDetail.lLeafSort(lSort2) = lIndex2
                        ruOrdDetail.lLeafSort(lSort2 + lGap) = lIndex1
                    Else
                        Exit Do
                    End If
                    lSort2 = lSort2 - lGap
                Loop
            Next lSort1
            lGap = lGap \ 2
        Loop

        ' Add children to parent lists
        For lIndex = 0 To ruOrdDetail.lLeafCount - 1
            lLeafIndex = ruOrdDetail.lLeafSort(lIndex)
            If ruOrdDetail.uLeafList(lLeafIndex).lParentTag <> 0 Then
                lParentIndex = ruOrdDetail.lHashList(ruOrdDetail.uLeafList(lLeafIndex).lParentTag - ruOrdDetail.lMinimumMatlTag)
                ruOrdDetail.uLeafList(lLeafIndex).lParentLeafIndex = lParentIndex
                lChildIndex = ruOrdDetail.uLeafList(lParentIndex).lChildCount
                ReDim Preserve ruOrdDetail.uLeafList(lParentIndex).lChildSort(lChildIndex)
                ReDim Preserve ruOrdDetail.uLeafList(lParentIndex).lChildList(lChildIndex)
                ruOrdDetail.uLeafList(lParentIndex).lChildSort(lChildIndex) = lChildIndex
                ruOrdDetail.uLeafList(lParentIndex).lChildList(lChildIndex) = lLeafIndex
                ruOrdDetail.uLeafList(lParentIndex).lChildCount = lChildIndex + 1
            Else
                ruOrdDetail.uLeafList(lLeafIndex).lParentLeafIndex = -1
            End If
        Next lIndex

        ' Find root(s) of order tree
        ruOrdDetail.lRootCount = 0
        For lIndex = 0 To ruOrdDetail.lLeafCount - 1
            lLeafIndex = ruOrdDetail.lLeafSort(lIndex)
            If ((ruOrdDetail.uLeafList(lLeafIndex).lParentTag = 0) And (ruOrdDetail.lMatlTag = 0)) Or (ruOrdDetail.uLeafList(lLeafIndex).lMatltag = ruOrdDetail.lMatlTag) Then
                ReDim Preserve ruOrdDetail.lRootList(ruOrdDetail.lRootCount + 1)
                ruOrdDetail.lRootList(ruOrdDetail.lRootCount) = lLeafIndex
                ruOrdDetail.lRootCount = ruOrdDetail.lRootCount + 1
            End If
        Next lIndex

        ' Prune tree of unneeded leaves
        If ruOrdDetail.lMatlTag > 0 Then
            For lIndex = 0 To ruOrdDetail.lRootCount - 1
                MarkLeaf(ruOrdDetail, ruOrdDetail.lRootList(lIndex))
            Next lIndex
        End If

        ConnectLeaves = ERR_OK

    End Function

    Private Sub MarkLeaf(ByRef ruOrdDetail As uOrdDetail, ByVal lLeafIndex As Integer)
        Dim lIndex As Integer

        ruOrdDetail.uLeafList(lLeafIndex).bSkip = False
        For lIndex = 0 To ruOrdDetail.uLeafList(lLeafIndex).lChildCount - 1
            Call MarkLeaf(ruOrdDetail, ruOrdDetail.uLeafList(lLeafIndex).lChildList(lIndex))
        Next lIndex

    End Sub

    Private Function GetOrdTree(ByRef ruOrdDetail As uOrdDetail) As Integer

        Dim lIndex As Integer
        Dim lLeafIndex As Integer
        Dim lMergeIndex As Integer
        Dim lSortedMergeIndex As Integer
        Dim lParentIndex As Integer
        Dim lChildLeaf As Integer
        Dim lChildIndex As Integer
        Dim lOperIndex As Integer
        Dim lPartIndex As Integer


        ' Make sure each parent has at least one operation
        For lIndex = 0 To ruOrdDetail.lLeafCount - 1
            lLeafIndex = ruOrdDetail.lLeafSort(lIndex)
            'If Not ruOrdDetail.uLeafList(lLeafIndex).bSkip Then
            If (ruOrdDetail.uLeafList(lLeafIndex).lChildCount > 0) And (ruOrdDetail.uLeafList(lLeafIndex).lOperCount = 0) Then
                ruOrdDetail.uLeafList(lLeafIndex).sRouteID = ""
                ReDim Preserve ruOrdDetail.uLeafList(lLeafIndex).lOperSort(0)
                ReDim Preserve ruOrdDetail.uLeafList(lLeafIndex).uOperList(0)
                ruOrdDetail.uLeafList(lLeafIndex).lOperSort(0) = 0
                ruOrdDetail.uLeafList(lLeafIndex).uOperList(0).sOperID = ""
                ruOrdDetail.uLeafList(lLeafIndex).uOperList(0).sOperDescr = ""
                ruOrdDetail.uLeafList(lLeafIndex).uOperList(0).datStartDate = ruOrdDetail.uLeafList(lLeafIndex).datStartDate
                ruOrdDetail.uLeafList(lLeafIndex).uOperList(0).datEndDate = ruOrdDetail.uLeafList(lLeafIndex).datEndDate
                ruOrdDetail.uLeafList(lLeafIndex).uOperList(0).dQuantity = ruOrdDetail.uLeafList(lLeafIndex).dQuantity
                ruOrdDetail.uLeafList(lLeafIndex).uOperList(0).dWIPQuantity = 0
                ruOrdDetail.uLeafList(lLeafIndex).uOperList(0).lSeqno = 1

                ruOrdDetail.uLeafList(lLeafIndex).uOperList(0).lGrpCount = 0
                ruOrdDetail.uLeafList(lLeafIndex).uOperList(0).lPartCount = 0
                ruOrdDetail.uLeafList(lLeafIndex).uOperList(0).bCritDelay = False
                ruOrdDetail.uLeafList(lLeafIndex).uOperList(0).bPushCritDelay = False
                ruOrdDetail.uLeafList(lLeafIndex).uOperList(0).dDuration = 0
                ruOrdDetail.uLeafList(lLeafIndex).uOperList(0).sWorkcenter = ""
                ruOrdDetail.uLeafList(lLeafIndex).lOperCount = 1
                For lChildIndex = 0 To ruOrdDetail.uLeafList(lLeafIndex).lChildCount - 1
                    lChildLeaf = ruOrdDetail.uLeafList(lLeafIndex).lChildList(lChildIndex)
                    lPartIndex = ruOrdDetail.uLeafList(lLeafIndex).uOperList(0).lPartCount
                    ReDim Preserve ruOrdDetail.uLeafList(lLeafIndex).uOperList(0).lPartList(lPartIndex)
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(0).lPartList(lPartIndex) = lChildLeaf
                    ruOrdDetail.uLeafList(lLeafIndex).uOperList(0).lPartCount = lPartIndex + 1
                Next lChildIndex
            End If
            'End If
        Next lIndex

        ' Add children to correct operation in parent
        Dim lSortedOperIndex As Integer
        For lIndex = 0 To ruOrdDetail.lLeafCount - 1
            lLeafIndex = ruOrdDetail.lLeafSort(lIndex)
            If Not ruOrdDetail.uLeafList(lLeafIndex).bSkip Then
                If ruOrdDetail.uLeafList(lLeafIndex).lParentTag <> 0 Then
                    lParentIndex = ruOrdDetail.lHashList(ruOrdDetail.uLeafList(lLeafIndex).lParentTag - ruOrdDetail.lMinimumMatlTag)
                    lMergeIndex = 0
                    lSortedMergeIndex = 0

                    For lOperIndex = 0 To ruOrdDetail.uLeafList(lParentIndex).lOperCount - 1
                        lSortedOperIndex = ruOrdDetail.uLeafList(lParentIndex).lOperSort(lOperIndex)
                        If ruOrdDetail.uLeafList(lLeafIndex).lMergeTo = -1 Then
                            If ruOrdDetail.uLeafList(lLeafIndex).sOperID = ruOrdDetail.uLeafList(lParentIndex).uOperList(lSortedOperIndex).sOperID Then
                                lSortedMergeIndex = lSortedOperIndex
                                lMergeIndex = lOperIndex
                                Exit For
                            End If
                        Else
                            If ruOrdDetail.uLeafList(lLeafIndex).lMergeTo < ruOrdDetail.uLeafList(lParentIndex).uOperList(lSortedOperIndex).lSeqno Then
                                Exit For
                            End If
                            lSortedMergeIndex = lSortedOperIndex
                            lMergeIndex = lOperIndex
                        End If
                    Next lOperIndex
                    lPartIndex = ruOrdDetail.uLeafList(lParentIndex).uOperList(lSortedMergeIndex).lPartCount
                    ReDim Preserve ruOrdDetail.uLeafList(lParentIndex).uOperList(lSortedMergeIndex).lPartList(lPartIndex)
                    ruOrdDetail.uLeafList(lParentIndex).uOperList(lSortedMergeIndex).lPartList(lPartIndex) = lLeafIndex
                    ruOrdDetail.uLeafList(lParentIndex).uOperList(lSortedMergeIndex).lPartCount = lPartIndex + 1
                    ruOrdDetail.uLeafList(lLeafIndex).lMergeTo = lSortedMergeIndex
                    ruOrdDetail.uLeafList(lLeafIndex).lMergeIdx = lMergeIndex
                End If
            End If
        Next lIndex
        GetOrdTree = ERR_OK

    End Function

    Private Function GetCTPResults(ByRef ruResults As uCTPLineItemResults,
                                   ByVal vbDetails As Boolean) As Integer
        Dim sOrderID As String
        Dim lIndex As Integer
        Dim lStartDate As Integer
        Dim iRC As Integer
        Dim uMiscout As New miscout_s
        Dim uMisc As New misc_s
        Dim oERDB As New ERDB.Server

        ' Get date of last full planning run
        iRC = oERDB.cini_miscout(muCon, uMiscout)
        If iRC <> ERR_OK Then
            msStatus = CTPErrorMsg(iRC, "cini_miscout")
            GetCTPResults = iRC
            Exit Function
        End If
        iRC = oERDB.cget_miscout(muCon, uMiscout)
        If iRC <> ERR_OK Then
            msStatus = CTPErrorMsg(iRC, "cget_miscout")
            GetCTPResults = iRC
            Exit Function
        End If
        If uMiscout.algfullbeg > 0 Then
            mdatAPSNow = PlannerInterface.datOLDate2VBDate(uMiscout.algfullbeg)
        Else
            mdatAPSNow = Now
        End If

        ' Get status of critical path computation
        iRC = oERDB.cini_misc(muCon, uMisc)
        If iRC <> ERR_OK Then
            msStatus = CTPErrorMsg(iRC, "cini_misc")
            GetCTPResults = iRC
            Exit Function
        End If
        iRC = oERDB.cget_misc(muCon, uMisc)
        If iRC <> ERR_OK Then
            msStatus = CTPErrorMsg(iRC, "cget_misc")
            GetCTPResults = iRC
            Exit Function
        End If
        If (uMisc.algssiteflags And VAL_ALGSSITEFLAGS_NEWCRITPATH) > 0 Then
            mbComputeCritPath = False
        Else
            mbComputeCritPath = True
        End If

        ' Get order completion date
        sOrderID = RTrim(muOrder.order)
        ruResults.uDetail.sSiteID = ruResults.uRequest.sSiteID
        ruResults.uDetail.sOrderID = sOrderID
        ruResults.uDetail.sDemandID = sOrderID
        ruResults.uDetail.lMatlTag = 0
        ruResults.uDetail.lLeafCount = 0
        muOrder.order = Trim$(sOrderID)
        muOrder.sort = 0
        iRC = oERDB.cget_order(muCon, muOrder)
        If iRC <> ERR_OK Then
            msStatus = CTPErrorMsg(iRC, "GetOrder")
            GetCTPResults = iRC
            Exit Function
        End If
        If muOrder.ordcalcdate > 0 Then
            ruResults.datCalcDate = PlannerInterface.datOLDate2VBDate(muOrder.ordcalcdate)
            ruResults.lReturnCode = muOrder.ordflags
        Else
            ruResults.datCalcDate = CTP_BLOCKED_DATE
            ruResults.lReturnCode = muOrder.ordflags Or ERDB.Server.VAL_ORDFLAGS_BLOCKED
        End If

        ' Get order start date (earliest schedule record associated with end-item)
        If ruResults.datCalcDate = CTP_BLOCKED_DATE Then
            ruResults.datStartDate = CTP_BLOCKED_DATE
        Else
            lStartDate = muOrder.ordcalcdate
            muOrd22Mpn.order = RTrim$(sOrderID)
            muOrd22Mpn.ord22mpnidx = 1
            Do While oERDB.cget_ord22mpn(muCon, muOrd22Mpn) = ERR_OK
                muMatlplan.matlplan = muOrd22Mpn.matlplan
                muMatlplan.sort = 0
                iRC = oERDB.cget_matlplan(muCon, muMatlplan)
                If iRC <> ERR_OK Then
                    GetCTPResults = iRC
                    Exit Function
                End If
                If (muMatlplan.mpnparenttag = 0) Then
                    muMpn22Ipn.matlplan = muMatlplan.matlplan
                    muMpn22Ipn.mpn22ipnidx = 1
                    Do While oERDB.cget_mpn22ipn(muCon, muMpn22Ipn) = ERR_OK
                        muInvplan.invplan(0) = muMpn22Ipn.invplan(0)
                        muInvplan.invplan(1) = muMpn22Ipn.invplan(1)
                        muInvplan.sort = 0
                        iRC = oERDB.cget_invplan(muCon, muInvplan)
                        If iRC <> ERR_OK Then
                            GetCTPResults = iRC
                            Exit Function
                        End If
                        If muInvplan.ipnstartdate < lStartDate Then
                            lStartDate = muInvplan.ipnstartdate
                        End If
                        muMpn22Ipn.mpn22ipnidx = muMpn22Ipn.mpn22ipnidx + 1
                    Loop
                    muMpn22Opn.matlplan = muMatlplan.matlplan
                    muMpn22Opn.mpn22opnidx = 1
                    Do While oERDB.cget_mpn22opn(muCon, muMpn22Opn) = ERR_OK
                        muOperplan.operplan(0) = muMpn22Opn.operplan(0)
                        muOperplan.operplan(1) = muMpn22Opn.operplan(1)
                        muOperplan.sort = 0
                        iRC = oERDB.cget_operplan(muCon, muOperplan)
                        If iRC <> ERR_OK Then
                            GetCTPResults = iRC
                            Exit Function
                        End If
                        If muOperplan.operplan(0) < lStartDate Then
                            lStartDate = muOperplan.operplan(0)
                        End If
                        muMpn22Opn.mpn22opnidx = muMpn22Opn.mpn22opnidx + 1
                    Loop
                End If
                muOrd22Mpn.ord22mpnidx = muOrd22Mpn.ord22mpnidx + 1
            Loop
            ruResults.datStartDate = PlannerInterface.datOLDate2VBDate(lStartDate)
        End If

        ' Only continue if retrieving detailed information
        If Not vbDetails Then
            GetCTPResults = ERR_OK
            Exit Function
        End If

        ' Set detail info
        ruResults.uDetail.datCalcDate = PlannerInterface.datOLDate2VBDate(muOrder.ordcalcdate)
        ruResults.uDetail.datPromDate = PlannerInterface.datOLDate2VBDate(muOrder.ordpromdate)
        ruResults.uDetail.datReqDate = PlannerInterface.datOLDate2VBDate(muOrder.ordrequdate)
        ruResults.uDetail.datStartDate = ruResults.uDetail.datCalcDate
        ruResults.uDetail.datPlannerStartDate = mdatAPSNow

        ' Get leaves of order "tree"
        iRC = GetOrdLeavesCTP(ruResults.uDetail)
        If iRC <> ERR_OK Then
            msStatus = CTPErrorMsg(iRC, "GetOrdLeavesCTP")
            GetCTPResults = iRC
            Exit Function
        End If

        ' Set parent/child relationships
        iRC = ConnectLeaves(ruResults.uDetail)
        If iRC <> ERR_OK Then
            msStatus = CTPErrorMsg(iRC, "ConnectLeaves")
            GetCTPResults = iRC
            Exit Function
        End If

        ' Check for no leaves...
        If ruResults.uDetail.lLeafCount = 0 Then
            GetCTPResults = ERR_OK
            Exit Function
        End If

        ' Get leaf operations
        iRC = GetLeafOperationsCTP(ruResults.uDetail)
        If iRC <> ERR_OK Then
            msStatus = CTPErrorMsg(iRC, "GetLeafOperationsCTP")
            GetCTPResults = iRC
            Exit Function
        End If

        ' Get WIP usage
        iRC = GetLeafOperationWIPCTP(ruResults.uDetail)
        If iRC <> ERR_OK Then
            msStatus = CTPErrorMsg(iRC, "GetLeafOperationWIPCTP")
            GetCTPResults = iRC
            Exit Function
        End If

        ' Get leaf inventory events
        iRC = GetLeafEventsCTP(ruResults.uDetail)
        If iRC <> ERR_OK Then
            msStatus = CTPErrorMsg(iRC, "GetLeafEventsCTP")
            GetCTPResults = iRC
            Exit Function
        End If

        ' Add children to correct operations
        iRC = GetOrdTree(ruResults.uDetail)
        If iRC <> ERR_OK Then
            msStatus = CTPErrorMsg(iRC, "GetOrdTree")
            GetCTPResults = iRC
            Exit Function
        End If

        ' Get leaf waiting times
        iRC = GetLeafWaitCTP(ruResults.uDetail)
        If iRC <> ERR_OK Then
            msStatus = CTPErrorMsg(iRC, "GetLeafWaitCTP")
            GetCTPResults = iRC
            Exit Function
        End If

        ' Determine critical path
        If mbComputeCritPath Then
            For lIndex = 0 To ruResults.uDetail.lRootCount - 1
                iRC = GetCriticalPath(ruResults.uDetail, ruResults.uDetail.lRootList(lIndex))
                If iRC <> ERR_OK Then
                    msStatus = CTPErrorMsg(iRC, "GetCriticalPath")
                    GetCTPResults = iRC
                    Exit Function
                End If
            Next
        End If

        ' Mark critical path throughout tree
        For lIndex = 0 To ruResults.uDetail.lRootCount - 1
            Call MarkCriticalOperations(ruResults.uDetail, ruResults.uDetail.lRootList(lIndex))
        Next

        ' Mark push critical path throughout tree
        For lIndex = 0 To ruResults.uDetail.lRootCount - 1
            Call MarkPushCriticalOperations(ruResults.uDetail, ruResults.uDetail.lRootList(lIndex))
        Next

        ' Determine waiting time throughout tree
        For lIndex = 0 To ruResults.uDetail.lRootCount - 1
            iRC = GetOrdTreeWait(ruResults.uDetail, ruResults.uDetail.lRootList(lIndex))
            If iRC <> ERR_OK Then
                msStatus = CTPErrorMsg(iRC, "GetOrdTreeWait")
                GetCTPResults = iRC
                Exit Function
            End If
        Next

        ' Compute slack throughout the tree (if late)
        If ruResults.uDetail.datCalcDate > ruResults.uDetail.datPromDate Then
            For lIndex = 0 To ruResults.uDetail.lRootCount - 1
                iRC = GetOrdTreeSlack(ruResults.uDetail, ruResults.uDetail.lRootList(lIndex))
                If iRC <> ERR_OK Then
                    msStatus = CTPErrorMsg(iRC, "GetOrdTreeSlack")
                    GetCTPResults = iRC
                    Exit Function
                End If
            Next
        End If

        GetCTPResults = ERR_OK

    End Function

    Private Function GetOrdTreeWait(ByRef ruOrdDetail As uOrdDetail,
                                    ByVal vlLeaf As Integer) As Integer
        Dim lIndex As Integer
        Dim lOperIndex As Integer
        Dim lSortOperIndex As Integer
        Dim lGrpIndex As Integer
        Dim lChildLeafIndex As Integer
        Dim dResWait As Double

        ' Process children first
        For lIndex = 0 To ruOrdDetail.uLeafList(vlLeaf).lChildCount - 1
            lChildLeafIndex = ruOrdDetail.uLeafList(vlLeaf).lChildList(lIndex)
            lOperIndex = ruOrdDetail.uLeafList(lChildLeafIndex).lMergeIdx
            Call GetOrdTreeWait(ruOrdDetail, lChildLeafIndex)
            If ruOrdDetail.uLeafList(lChildLeafIndex).bItemDelay Then
                ruOrdDetail.uLeafList(vlLeaf).bItemDelay = True
                ruOrdDetail.uLeafList(vlLeaf).uOperList(lOperIndex).bItemDelay = True
            End If
            If ruOrdDetail.uLeafList(lChildLeafIndex).bGroupDelay Then
                ruOrdDetail.uLeafList(vlLeaf).bGroupDelay = True
                ruOrdDetail.uLeafList(vlLeaf).uOperList(lOperIndex).bGroupDelay = True
            End If
            If ruOrdDetail.uLeafList(lChildLeafIndex).bFiniteGroupDelay Then
                ruOrdDetail.uLeafList(vlLeaf).bFiniteGroupDelay = True
                ruOrdDetail.uLeafList(vlLeaf).uOperList(lOperIndex).bFiniteGroupDelay = True
            End If
        Next lIndex

        If ruOrdDetail.uLeafList(vlLeaf).dWaitTime > 0 Then
            ruOrdDetail.uLeafList(vlLeaf).bItemDelay = True
        End If

        ' Process purchased parts
        If (ruOrdDetail.uLeafList(vlLeaf).lPartFlags And ERDB.Server.VAL_PRTFLAGS_PURCHASED) > 0 Then
            GetOrdTreeWait = ERR_OK
            Exit Function
        End If

        ' Process phantoms
        If (((ruOrdDetail.uLeafList(vlLeaf).lPartFlags And ERDB.Server.VAL_PRTFLAGS_SKIPBLOTHRU) > 0) Or
           (((ruOrdDetail.uLeafList(vlLeaf).lPartFlags And ERDB.Server.VAL_PRTFLAGS_SKIPPHANTOM) > 0) And (ruOrdDetail.uLeafList(vlLeaf).lParentLeafIndex >= 0))) Then
            GetOrdTreeWait = ERR_OK
            Exit Function
        End If

        ' For manufactured parts, flag delayed operations
        For lOperIndex = 0 To ruOrdDetail.uLeafList(vlLeaf).lOperCount - 1
            lSortOperIndex = ruOrdDetail.uLeafList(vlLeaf).lOperSort(lOperIndex)
            For lGrpIndex = 0 To ruOrdDetail.uLeafList(vlLeaf).uOperList(lSortOperIndex).lGrpCount - 1
                dResWait = Math.Max(ruOrdDetail.uLeafList(vlLeaf).uOperList(lSortOperIndex).uGrpList(lGrpIndex).dWaitTime,
                                    ruOrdDetail.uLeafList(vlLeaf).uOperList(lSortOperIndex).uGrpList(lGrpIndex).dPushWait)
                If dResWait > 0.0# Then
                    ruOrdDetail.uLeafList(vlLeaf).bGroupDelay = True
                    ruOrdDetail.uLeafList(vlLeaf).uOperList(lSortOperIndex).bGroupDelay = True
                    If ruOrdDetail.uLeafList(vlLeaf).uOperList(lSortOperIndex).uGrpList(lGrpIndex).bFiniteGroup Then
                        ruOrdDetail.uLeafList(vlLeaf).bFiniteGroupDelay = True
                        ruOrdDetail.uLeafList(vlLeaf).uOperList(lSortOperIndex).bFiniteGroupDelay = True
                    End If
                End If
            Next lGrpIndex
        Next lOperIndex

        GetOrdTreeWait = ERR_OK

    End Function

    Private Function GetOrdTreeSlack(ByRef ruOrdDetail As uOrdDetail,
                                     ByVal vlLeaf As Integer) As Integer
        Dim lIndex As Integer
        Dim lChildLeafIndex As Integer
        Dim datEarliestChild As Date
        Dim datChildStart As Date
        Dim dSlack As Double

        ' Depth first
        datEarliestChild = ruOrdDetail.uLeafList(vlLeaf).datEndDate
        For lIndex = 0 To ruOrdDetail.uLeafList(vlLeaf).lChildCount - 1
            lChildLeafIndex = ruOrdDetail.uLeafList(vlLeaf).lChildList(lIndex)
            Call GetOrdTreeSlack(ruOrdDetail, lChildLeafIndex)
            datChildStart = GetEarliestChild(ruOrdDetail, lChildLeafIndex)
            If datChildStart < datEarliestChild Then
                datEarliestChild = datChildStart
            End If
        Next lIndex

        ' Only nodes with no earlier starting children have slack
        If datEarliestChild >= ruOrdDetail.uLeafList(vlLeaf).datStartDate Then
            dSlack = CDbl(DateDiff("n", mdatAPSNow, ruOrdDetail.uLeafList(vlLeaf).datStartDate)) / 60.0#
            If ruOrdDetail.uLeafList(vlLeaf).dSlackTime = -1.0# Then ' No slack from existing supply usage
                ruOrdDetail.uLeafList(vlLeaf).dSlackTime = dSlack
            ElseIf dSlack < ruOrdDetail.uLeafList(vlLeaf).dSlackTime Then ' Slack from existing supply usage is not limiting
                ruOrdDetail.uLeafList(vlLeaf).dSlackTime = dSlack
            End If
        End If

        ' Success
        GetOrdTreeSlack = ERR_OK

    End Function

    Private Function GetCriticalPath(ByRef ruOrdDetail As uOrdDetail,
                                     ByVal vlLeaf As Integer) As Integer
        Dim datEarliest As Date

        ' Get earliest child start date
        datEarliest = GetEarliestChild(ruOrdDetail, vlLeaf)

        ' Mark critical path
        Call MarkCriticalPath(ruOrdDetail, vlLeaf, datEarliest)

        ' Success
        GetCriticalPath = ERR_OK

    End Function

    Private Function dHours(ByVal vdatStartDate As Date,
                            ByVal vdatEndDate As Date) As Double

        dHours = DateDiff("s", vdatStartDate, vdatEndDate) / 3600.0#

    End Function

    Private Sub AddErrormsg(ByRef rsStatus As String)

        Dim iRC As Integer
        Dim oERDB As New ERDB.Server

        iRC = oERDB.cget_errormsg(muCon, muErrormsg)
        If iRC = ERR_OK Then
            If Len(muErrormsg.msg1) > 0 Then
                rsStatus = rsStatus & vbCrLf & muErrormsg.msg1
            End If
            If Len(muErrormsg.msg2) > 0 Then
                rsStatus = rsStatus & vbCrLf & muErrormsg.msg2
            End If
            If Len(muErrormsg.msg3) > 0 Then
                rsStatus = rsStatus & vbCrLf & muErrormsg.msg3
            End If
            If Len(muErrormsg.msg4) > 0 Then
                rsStatus = rsStatus & vbCrLf & muErrormsg.msg4
            End If
        End If

    End Sub

    '*******************************************************************************
    ' Function: PortalGetCTP
    ' Inputs:
    '       SiteID        - the SyteLine site to receive the CTP request
    '       ItemID        - the requested item 
    '       Quantity      - the requested quantity
    '       DueDate       - the requested due date
    ' Outputs:
    '       ProjectedDate - the planned completion date
    '       ErrorMsg      - error message
    ' Returns:
    '       0             - no error
    '       16            - an error occurred during the CTP process (see ErrorMsg)
    '*******************************************************************************
    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PortalGetCTP(
        ByVal sSiteID As String,
        ByVal sItemID As String,
        ByVal dQuantity As Double,
        ByVal datDueDate As Date,
        ByRef datProjectedDate As Date,
        ByRef Infobar As String) As Long Implements CSI.ExternalContracts.Portals.ISLCtps.PortalGetCTP

        Dim oXMLRequest As New System.Xml.XmlDocument
        Dim oXMLResponse As New System.Xml.XmlDocument
        Dim sXMLResponse As String = Nothing
        Dim oResponse As Mongoose.IDO.Protocol.InvokeResponseData
        Dim oNode As System.Xml.XmlNode
        Dim oListOfLineItemsNode As System.Xml.XmlNode
        Dim oLineItemNode As System.Xml.XmlNode

        ' Create request XML
        oNode = oXMLRequest.CreateElement("CTPRequest")
        oXMLRequest.AppendChild(oNode)
        oListOfLineItemsNode = oXMLRequest.CreateElement("ListOfLineItems")
        oXMLRequest.DocumentElement.AppendChild(oListOfLineItemsNode)
        oLineItemNode = oXMLRequest.CreateElement("LineItem")
        oListOfLineItemsNode.AppendChild(oLineItemNode)
        oNode = oXMLRequest.CreateElement("SiteID")
        oNode.InnerText = sSiteID
        oLineItemNode.AppendChild(oNode)
        oNode = oXMLRequest.CreateElement("OrderID")
        oNode.InnerText = "__CTP_ORDER"  ' an arbitrary (unique) name for the CTP order
        oLineItemNode.AppendChild(oNode)
        oNode = oXMLRequest.CreateElement("ItemID")
        oNode.InnerText = sItemID
        oLineItemNode.AppendChild(oNode)
        oNode = oXMLRequest.CreateElement("Quantity")
        oNode.InnerText = Mongoose.Core.Common.MGType.ToInternal(dQuantity)
        oLineItemNode.AppendChild(oNode)
        oNode = oXMLRequest.CreateElement("RequestDate")
        oNode.InnerText = Mongoose.Core.Common.MGType.ToInternal(datDueDate)
        oLineItemNode.AppendChild(oNode)
        oNode = oXMLRequest.CreateElement("DueDate")
        oNode.InnerText = Mongoose.Core.Common.MGType.ToInternal(datDueDate)
        oLineItemNode.AppendChild(oNode)
        oNode = oXMLRequest.CreateElement("Category")
        oNode.InnerText = Mongoose.Core.Common.MGType.ToInternal(0)
        oLineItemNode.AppendChild(oNode)
        oNode = oXMLRequest.CreateElement("Flags")
        oNode.InnerText = Mongoose.Core.Common.MGType.ToInternal(0)
        oLineItemNode.AppendChild(oNode)
        oNode = oXMLRequest.CreateElement("Details")
        oNode.InnerText = "False"
        oXMLRequest.DocumentElement.AppendChild(oNode)
        oNode = oXMLRequest.CreateElement("Quantities")
        oNode.InnerText = "False"
        oXMLRequest.DocumentElement.AppendChild(oNode)
        oNode = oXMLRequest.CreateElement("DisableExpedite")
        oNode.InnerText = "False"
        oXMLRequest.DocumentElement.AppendChild(oNode)

        ' Call CTP method       
        oResponse = Me.Context.Commands.Invoke("SLCtps", "GetCTP", oXMLRequest.InnerXml, sXMLResponse, Infobar)
        sXMLResponse = oResponse.Parameters(1).Value
        Infobar = oResponse.Parameters(2).Value
        If Infobar <> "" Then
            PortalGetCTP = 16
            Exit Function
        End If

        ' Get projected date from response XML
        oXMLResponse.LoadXml(sXMLResponse)
        oNode = oXMLResponse.SelectSingleNode("/CTPResponse/ListOfLineItems/LineItem/CalcDate")
        datProjectedDate = Mongoose.Core.Common.MGType.FromInternal(Of Date)(oNode.InnerText)

        PortalGetCTP = 0

    End Function

    Private Function LoadResrcPlan(ByVal viAltno As Integer,
                                   ByVal vsResourceID As String,
                                   ByVal vdatStartDate As Date,
                                   ByVal vdatEndDate As Date,
                                   ByVal vsOrderID As String,
                                   ByRef rsResrcPlanXML As String,
                                   ByRef rsInfobar As String) As Integer

        Dim sProperties, sFilter As String
        Dim oRequest1 As New LoadCollectionRequestData
        Dim oRequest2 As New LoadCollectionRequestData
        Dim oData As LoadCollectionResponseData
        Dim lIndex, lBlockIndex, lCount As Integer
        Dim iDOWNCD, iSTARTDATE, iENDDATE, iDEMANDID As Integer
        Dim uBlocks() As ResrcPlanInfo = Nothing
        Dim oDOM As New XmlDocument
        Dim oNode, oParentNode As XmlNode
        Dim oListOfBlocks, oBlockNode As XmlNode

        LoadResrcPlan = 0

        On Error GoTo LoadResrcPlanError

        If DEBUG_MODE Then
            IDORuntime.LogUserMessage("SLCtps", UserDefinedMessageType.UserDefined1,
                                      "Begin LoadResrcPlan")
        End If

        ' Get downtime plan
        sProperties = "DOWNCD, STARTDATE, ENDDATE"
        oRequest1.PropertyList = New PropertyList(sProperties)
        oRequest1.Filter = "DOWNCD <> 'W' AND RESID = " & SqlLiteral.Format(vsResourceID) &
                           " AND STARTDATE < " & SqlLiteral.Format(vdatEndDate) &
                           " AND ENDDATE > " & SqlLiteral.Format(vdatStartDate)
        oRequest1.OrderBy = "STARTDATE"
        oRequest1.IDOName = "TABLE!" + "DOWNPLAN" + viAltno.ToString("000")
        oRequest1.RecordCap = BAR_MAX
        oData = Me.Context.Commands.LoadCollection(oRequest1)

        lBlockIndex = 0
        lCount = oData.Items.Count

        If lCount > 0 Then

            iDOWNCD = oData.PropertyList.IndexOf("DOWNCD")
            iSTARTDATE = oData.PropertyList.IndexOf("STARTDATE")
            iENDDATE = oData.PropertyList.IndexOf("ENDDATE")

            ReDim Preserve uBlocks(lBlockIndex + lCount)

            For Each item As IDOItem In oData.Items

                uBlocks(lBlockIndex).sDownCd = item.PropertyValues(iDOWNCD).ToString()
                uBlocks(lBlockIndex).datStart = item.PropertyValues(iSTARTDATE).GetValue(Of Date)()
                uBlocks(lBlockIndex).datEnd = item.PropertyValues(iENDDATE).GetValue(Of Date)()
                uBlocks(lBlockIndex).sOrderID = ""

                lBlockIndex = lBlockIndex + 1

            Next

        End If

        ' Get resource plan
        sProperties = "STARTDATE, ENDDATE, DerApsRef"
        oRequest2.IDOName = "SL.SLResourcePlans"
        oRequest2.PropertyList.SetProperties(sProperties)
        oRequest2.CustomLoadMethod = New CustomLoadMethod()
        oRequest2.RecordCap = 0
        oRequest2.CustomLoadMethod.Name = "CLM_ResourcePlanSp"
        oRequest2.CustomLoadMethod.Parameters.Add(viAltno)
        sFilter = "RESID = " + SqlLiteral.Format(vsResourceID) +
                  " AND STARTDATE < " + SqlLiteral.Format(vdatEndDate) +
                  " AND ENDDATE > " + SqlLiteral.Format(vdatStartDate) +
                  " AND ORDERID <> " + SqlLiteral.Format(vsOrderID)
        oRequest2.CustomLoadMethod.Parameters.Add(sFilter)
        oData = Me.Context.Commands.LoadCollection(oRequest2)

        lCount = oData.Items.Count

        If lCount > 0 Then

            iSTARTDATE = oData.PropertyList.IndexOf("STARTDATE")
            iENDDATE = oData.PropertyList.IndexOf("ENDDATE")
            iDEMANDID = oData.PropertyList.IndexOf("DerApsRef")

            ReDim Preserve uBlocks(lBlockIndex + lCount)

            For Each item As IDOItem In oData.Items

                uBlocks(lBlockIndex).sDownCd = ""
                uBlocks(lBlockIndex).datStart = item.PropertyValues(iSTARTDATE).GetValue(Of Date)()
                uBlocks(lBlockIndex).datEnd = item.PropertyValues(iENDDATE).GetValue(Of Date)()
                uBlocks(lBlockIndex).sOrderID = item.PropertyValues(iDEMANDID).GetValue(Of String)()

                lBlockIndex = lBlockIndex + 1

            Next

        End If

        ' Build XML - Create root tag
        oParentNode = oDOM.CreateElement("ResrcPlanInfo")
        oDOM.AppendChild(oParentNode)

        ' Add base elements
        oNode = oDOM.CreateElement("Debug")
        oNode.InnerText = ""
        oParentNode.AppendChild(oNode)

        oNode = oDOM.CreateElement("Version")
        oNode.InnerText = "9.00.00"
        oParentNode.AppendChild(oNode)

        ' Add list of highlights
        oNode = oDOM.CreateElement("Blocks")
        oListOfBlocks = oParentNode.AppendChild(oNode)

        oNode = oDOM.CreateElement("Count")
        oNode.InnerText = MGType.ToInternal(lBlockIndex)
        oListOfBlocks.AppendChild(oNode)

        For lIndex = 0 To lBlockIndex - 1

            oNode = oDOM.CreateElement("Block")
            oBlockNode = oListOfBlocks.AppendChild(oNode)

            oNode = oDOM.CreateElement("DownCd")
            oNode.InnerText = uBlocks(lIndex).sDownCd
            oBlockNode.AppendChild(oNode)

            oNode = oDOM.CreateElement("StartDate")
            oNode.InnerText = MGType.ToInternal(uBlocks(lIndex).datStart)
            oBlockNode.AppendChild(oNode)

            oNode = oDOM.CreateElement("EndDate")
            oNode.InnerText = MGType.ToInternal(uBlocks(lIndex).datEnd)
            oBlockNode.AppendChild(oNode)

            oNode = oDOM.CreateElement("OrderID")
            oNode.InnerText = uBlocks(lIndex).sOrderID
            oBlockNode.AppendChild(oNode)

        Next lIndex

        ' Return response XML
        rsResrcPlanXML = oDOM.OuterXml

        LoadResrcPlan = 0
        GoTo LoadResrcPlanExit

LoadResrcPlanError:

        LoadResrcPlan = 16
        rsInfobar = "SLCtps.LoadResrcPlan(): Internal error " & Err.Number & " - " & Err.Description

LoadResrcPlanExit:

        oData = Nothing

        If DEBUG_MODE Then
            If LoadResrcPlan = 0 Then
                IDORuntime.LogUserMessage("SLCtps", UserDefinedMessageType.UserDefined1,
                                          "End LoadResrcPlan, ret=0")
            Else
                IDORuntime.LogUserMessage("SLCtps", UserDefinedMessageType.UserDefined1,
                                          "End LoadResrcPlan, ret={0}, msg={1}",
                                          LoadResrcPlan, rsInfobar)
            End If
        End If

    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ApsCtpConfigurableSp(ByVal PItem As String, ByRef PConfigurable As Byte?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iApsCtpConfigurableExt As IApsCtpConfigurable = New ApsCtpConfigurableFactory().Create(appDb)
            Dim oPConfigurable As ListYesNoType = PConfigurable
            Dim Severity As Integer = iApsCtpConfigurableExt.ApsCtpConfigurableSp(PItem, oPConfigurable)
            PConfigurable = oPConfigurable
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ApsCtpCustomerOrderInfoSp(ByVal PCoNum As String, ByVal PCoLine As Short?, ByVal PCoRelease As Short?, ByVal PRequestDate As DateTime?, ByVal PDueDate As DateTime?, ByVal PRefType As String, ByVal PRefNum As String, ByVal PRefLineSuf As Short?, ByVal PShipSite As String, ByVal PStat As String, ByVal PItem As String, ByRef PApsOrderId As String, ByRef PCategory As Integer?, ByRef PFlags As Integer?, ByRef PFlags2 As Integer?, ByRef PApsRequestDate As DateTime?, ByRef PApsDueDate As DateTime?, ByRef PApsItem As String, ByRef PWhse As String, ByRef POrdType As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iApsCtpCustomerOrderInfoExt As IApsCtpCustomerOrderInfo = New ApsCtpCustomerOrderInfoFactory().Create(appDb)
            Dim oPApsOrderId As ApsOrderType = PApsOrderId
            Dim oPCategory As ApsCategoryType = PCategory
            Dim oPFlags As ApsBitFlagsType = PFlags
            Dim oPFlags2 As ApsBitFlagsType = PFlags2
            Dim oPApsRequestDate As DateTimeType = PApsRequestDate
            Dim oPApsDueDate As DateTimeType = PApsDueDate
            Dim oPApsItem As ApsMaterialType = PApsItem
            Dim oPWhse As WhseType = PWhse
            Dim oPOrdType As ApsOrdTypeType = POrdType
            Dim Severity As Integer = iApsCtpCustomerOrderInfoExt.ApsCtpCustomerOrderInfoSp(PCoNum, PCoLine, PCoRelease, PRequestDate, PDueDate, PRefType, PRefNum, PRefLineSuf, PShipSite, PStat, PItem, oPApsOrderId, oPCategory, oPFlags, oPFlags2, oPApsRequestDate, oPApsDueDate, oPApsItem, oPWhse, oPOrdType)
            PApsOrderId = oPApsOrderId
            PCategory = oPCategory
            PFlags = oPFlags
            PFlags2 = oPFlags2
            PApsRequestDate = oPApsRequestDate
            PApsDueDate = oPApsDueDate
            PApsItem = oPApsItem
            PWhse = oPWhse
            POrdType = oPOrdType
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ApsCtpDisableExpediteSp(ByRef PDisableExpedite As Byte?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iApsCtpDisableExpediteExt As IApsCtpDisableExpedite = New ApsCtpDisableExpediteFactory().Create(appDb)
            Dim oPDisableExpedite As ListYesNoType = PDisableExpedite
            Dim Severity As Integer = iApsCtpDisableExpediteExt.ApsCtpDisableExpediteSp(oPDisableExpedite)
            PDisableExpedite = oPDisableExpedite
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ApsCtpForecastIDSp(ByVal PItem As String, ByVal PWhse As String, ByVal PCustNum As String, ByVal PDate As DateTime?, ByRef POrderID As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iApsCtpForecastIDExt As IApsCtpForecastID = New ApsCtpForecastIDFactory().Create(appDb)
            Dim oPOrderID As ApsOrderType = POrderID
            Dim Severity As Integer = iApsCtpForecastIDExt.ApsCtpForecastIDSp(PItem, PWhse, PCustNum, PDate, oPOrderID)
            POrderID = oPOrderID
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ApsCtpForecastOrderInfoSp(ByVal PItem As String, ByRef PWhse As String, ByVal PCustNum As String, ByVal PDate As DateTime?, ByRef PApsOrderId As String, ByRef PCategory As Integer?, ByRef PFlags As Integer?, ByRef PApsDueDate As DateTime?, ByRef PApsItem As String, ByRef POrdType As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iApsCtpForecastOrderInfoExt As IApsCtpForecastOrderInfo = New ApsCtpForecastOrderInfoFactory().Create(appDb)
            Dim oPWhse As WhseType = PWhse
            Dim oPApsOrderId As ApsOrderType = PApsOrderId
            Dim oPCategory As ApsCategoryType = PCategory
            Dim oPFlags As ApsBitFlagsType = PFlags
            Dim oPApsDueDate As DateTimeType = PApsDueDate
            Dim oPApsItem As ApsMaterialType = PApsItem
            Dim oPOrdType As ApsOrdTypeType = POrdType
            Dim Severity As Integer = iApsCtpForecastOrderInfoExt.ApsCtpForecastOrderInfoSp(PItem, oPWhse, PCustNum, PDate, oPApsOrderId, oPCategory, oPFlags, oPApsDueDate, oPApsItem, oPOrdType)
            PWhse = oPWhse
            PApsOrderId = oPApsOrderId
            PCategory = oPCategory
            PFlags = oPFlags
            PApsDueDate = oPApsDueDate
            PApsItem = oPApsItem
            POrdType = oPOrdType
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ApsCtpIsMPSItemSp(ByVal PItem As String, ByRef PIsMPSItem As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iApsCtpIsMPSItemExt As IApsCtpIsMPSItem = New ApsCtpIsMPSItemFactory().Create(appDb)
            Dim oPIsMPSItem As IntType = PIsMPSItem
            Dim Severity As Integer = iApsCtpIsMPSItemExt.ApsCtpIsMPSItemSp(PItem, oPIsMPSItem)
            PIsMPSItem = oPIsMPSItem
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ApsCtpIsNonInvItemSp(ByVal PItem As String, ByRef PIsNonInvItem As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iApsCtpIsNonInvItemExt As IApsCtpIsNonInvItem = New ApsCtpIsNonInvItemFactory().Create(appDb)
            Dim oPIsNonInvItem As IntType = PIsNonInvItem
            Dim Severity As Integer = iApsCtpIsNonInvItemExt.ApsCtpIsNonInvItemSp(PItem, oPIsNonInvItem)
            PIsNonInvItem = oPIsNonInvItem
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ApsCtpIsRemoteWhseSp(ByVal PWhse As String, ByRef PIsRemote As Byte?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iApsCtpIsRemoteWhseExt As IApsCtpIsRemoteWhse = New ApsCtpIsRemoteWhseFactory().Create(appDb)
            Dim oPIsRemote As FlagNyType = PIsRemote
            Dim Severity As Integer = iApsCtpIsRemoteWhseExt.ApsCtpIsRemoteWhseSp(PWhse, oPIsRemote)
            PIsRemote = oPIsRemote
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ApsCtpIsReorderPointSp(ByVal PItem As String, ByRef PReorderPoint As Byte?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iApsCtpIsReorderPointExt As IApsCtpIsReorderPoint = New ApsCtpIsReorderPointFactory().Create(appDb)
            Dim oPReorderPoint As ListYesNoType = PReorderPoint
            Dim Severity As Integer = iApsCtpIsReorderPointExt.ApsCtpIsReorderPointSp(PItem, oPReorderPoint)
            PReorderPoint = oPReorderPoint
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ApsCtpIsScheduledSp(ByVal PJob As String, ByVal PSuffix As Short?, ByRef PFlag As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iApsCtpIsScheduledExt As IApsCtpIsScheduled = New ApsCtpIsScheduledFactory().Create(appDb)
            Dim oPFlag As IntType = PFlag
            Dim Severity As Integer = iApsCtpIsScheduledExt.ApsCtpIsScheduledSp(PJob, PSuffix, oPFlag)
            PFlag = oPFlag
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ApsCtpJobOrderInfoSp(ByVal PJob As String, ByVal PSuffix As Short?, ByVal PJobStat As String, ByVal PEndDate As DateTime?, ByVal PItem As String, ByVal PJobType As String, ByVal PJobOrdType As String, ByVal PJobOrdNum As String, ByVal PJobOrdLine As Short?, ByVal PJobOrdRel As Short?, ByVal PJobRefJob As String, ByVal PJobRefSuf As Short?, ByVal PJobRefOper As Integer?, ByVal PJobRefSeq As Short?, ByVal PCoProductMix As Byte?, ByRef PApsOrderId As String, ByRef PCategory As Integer?, ByRef PFlags As Integer?, ByRef PApsDueDate As DateTime?, ByRef PApsItem As String, ByRef PWhse As String, ByRef POrdType As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iApsCtpJobOrderInfoExt As IApsCtpJobOrderInfo = New ApsCtpJobOrderInfoFactory().Create(appDb)
            Dim oPApsOrderId As ApsOrderType = PApsOrderId
            Dim oPCategory As ApsCategoryType = PCategory
            Dim oPFlags As ApsBitFlagsType = PFlags
            Dim oPApsDueDate As DateTimeType = PApsDueDate
            Dim oPApsItem As ApsMaterialType = PApsItem
            Dim oPWhse As WhseType = PWhse
            Dim oPOrdType As ApsOrdTypeType = POrdType
            Dim Severity As Integer = iApsCtpJobOrderInfoExt.ApsCtpJobOrderInfoSp(PJob, PSuffix, PJobStat, PEndDate, PItem, PJobType, PJobOrdType, PJobOrdNum, PJobOrdLine, PJobOrdRel, PJobRefJob, PJobRefSuf, PJobRefOper, PJobRefSeq, PCoProductMix, oPApsOrderId, oPCategory, oPFlags, oPApsDueDate, oPApsItem, oPWhse, oPOrdType)
            PApsOrderId = oPApsOrderId
            PCategory = oPCategory
            PFlags = oPFlags
            PApsDueDate = oPApsDueDate
            PApsItem = oPApsItem
            PWhse = oPWhse
            POrdType = oPOrdType
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ApsCtpMpsOrderInfoSp(ByVal PItem As String, ByVal PRefNum As String, ByVal PDate As DateTime?, ByRef PApsOrderId As String, ByRef PCategory As Integer?, ByRef PFlags As Integer?, ByRef PApsDueDate As DateTime?, ByRef PApsItem As String, ByRef POrdType As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iApsCtpMpsOrderInfoExt As IApsCtpMpsOrderInfo = New ApsCtpMpsOrderInfoFactory().Create(appDb)
            Dim oPApsOrderId As ApsOrderType = PApsOrderId
            Dim oPCategory As ApsCategoryType = PCategory
            Dim oPFlags As ApsBitFlagsType = PFlags
            Dim oPApsDueDate As DateTimeType = PApsDueDate
            Dim oPApsItem As ApsMaterialType = PApsItem
            Dim oPOrdType As ApsOrdTypeType = POrdType
            Dim Severity As Integer = iApsCtpMpsOrderInfoExt.ApsCtpMpsOrderInfoSp(PItem, PRefNum, PDate, oPApsOrderId, oPCategory, oPFlags, oPApsDueDate, oPApsItem, oPOrdType)
            PApsOrderId = oPApsOrderId
            PCategory = oPCategory
            PFlags = oPFlags
            PApsDueDate = oPApsDueDate
            PApsItem = oPApsItem
            POrdType = oPOrdType
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ApsCtpOrderSp(ByVal PCoNum As String, ByVal PShipPartial As Byte?, ByRef PProjDate As DateTime?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iApsCtpOrderExt As IApsCtpOrder = New ApsCtpOrderFactory().Create(appDb)
            Dim oPProjDate As DateTimeType = PProjDate
            Dim Severity As Integer = iApsCtpOrderExt.ApsCtpOrderSp(PCoNum, PShipPartial, oPProjDate)
            PProjDate = oPProjDate
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ApsCtpProjectOrderInfoSp(ByVal PProjNum As String, ByVal PTaskNum As Integer?, ByVal PSeq As Integer?, ByVal PDueDate As DateTime?, ByVal PRefType As String, ByVal PRefNum As String, ByVal PRefLineSuf As Short?, ByVal PItem As String, ByRef PApsOrderId As String, ByRef PCategory As Integer?, ByRef PFlags As Integer?, ByRef PApsDueDate As DateTime?, ByRef PApsItem As String, ByRef PWhse As String, ByRef POrdType As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iApsCtpProjectOrderInfoExt As IApsCtpProjectOrderInfo = New ApsCtpProjectOrderInfoFactory().Create(appDb)
            Dim oPApsOrderId As ApsOrderType = PApsOrderId
            Dim oPCategory As ApsCategoryType = PCategory
            Dim oPFlags As ApsBitFlagsType = PFlags
            Dim oPApsDueDate As DateTimeType = PApsDueDate
            Dim oPApsItem As ApsMaterialType = PApsItem
            Dim oPWhse As WhseType = PWhse
            Dim oPOrdType As ApsOrdTypeType = POrdType
            Dim Severity As Integer = iApsCtpProjectOrderInfoExt.ApsCtpProjectOrderInfoSp(PProjNum, PTaskNum, PSeq, PDueDate, PRefType, PRefNum, PRefLineSuf, PItem, oPApsOrderId, oPCategory, oPFlags, oPApsDueDate, oPApsItem, oPWhse, oPOrdType)
            PApsOrderId = oPApsOrderId
            PCategory = oPCategory
            PFlags = oPFlags
            PApsDueDate = oPApsDueDate
            PApsItem = oPApsItem
            PWhse = oPWhse
            POrdType = oPOrdType
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ApsCtpTransferOrderInfoSp(ByVal PTrnNum As String, ByVal PTrnLine As Short?, ByVal PFromSite As String, ByVal PToSite As String, ByRef PFromWhse As String, ByRef PToWhse As String, ByVal PSchShipDate As DateTime?, ByVal PSchRcvDate As DateTime?, ByVal PItem As String, ByVal PRefType As String, ByVal PRefNum As String, ByVal PRefLineSuf As Short?, ByRef PApsOrderId As String, ByRef PCategory As Integer?, ByRef PFlags As Integer?, ByRef PFlags2 As Integer?, ByRef PApsDueDate As DateTime?, ByRef PApsSite As String, ByRef PApsItem As String, ByRef PIsTransferOut As Integer?, ByRef POrdType As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iApsCtpTransferOrderInfoExt As IApsCtpTransferOrderInfo = New ApsCtpTransferOrderInfoFactory().Create(appDb)
            Dim oPFromWhse As WhseType = PFromWhse
            Dim oPToWhse As WhseType = PToWhse
            Dim oPApsOrderId As ApsOrderType = PApsOrderId
            Dim oPCategory As ApsCategoryType = PCategory
            Dim oPFlags As ApsBitFlagsType = PFlags
            Dim oPFlags2 As ApsBitFlagsType = PFlags2
            Dim oPApsDueDate As DateTimeType = PApsDueDate
            Dim oPApsSite As SiteType = PApsSite
            Dim oPApsItem As ApsMaterialType = PApsItem
            Dim oPIsTransferOut As IntType = PIsTransferOut
            Dim oPOrdType As ApsOrdTypeType = POrdType
            Dim Severity As Integer = iApsCtpTransferOrderInfoExt.ApsCtpTransferOrderInfoSp(PTrnNum, PTrnLine, PFromSite, PToSite, oPFromWhse, oPToWhse, PSchShipDate, PSchRcvDate, PItem, PRefType, PRefNum, PRefLineSuf, oPApsOrderId, oPCategory, oPFlags, oPFlags2, oPApsDueDate, oPApsSite, oPApsItem, oPIsTransferOut, oPOrdType)
            PFromWhse = oPFromWhse
            PToWhse = oPToWhse
            PApsOrderId = oPApsOrderId
            PCategory = oPCategory
            PFlags = oPFlags
            PFlags2 = oPFlags2
            PApsDueDate = oPApsDueDate
            PApsSite = oPApsSite
            PApsItem = oPApsItem
            PIsTransferOut = oPIsTransferOut
            POrdType = oPOrdType
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ApsCtpUomConvQtySp(ByVal QtyToBeConverted As Decimal?, ByVal UM As String, ByVal Item As String, ByVal FROMBase As String, ByRef ConvertedQty As Decimal?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iApsCtpUomConvQtyExt As IApsCtpUomConvQty = New ApsCtpUomConvQtyFactory().Create(appDb)
            Dim oConvertedQty As QtyUnitType = ConvertedQty
            Dim Severity As Integer = iApsCtpUomConvQtyExt.ApsCtpUomConvQtySp(QtyToBeConverted, UM, Item, FROMBase, oConvertedQty)
            ConvertedQty = oConvertedQty
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ApsCtpUpdateDueDateSp(ByVal PCoNum As String, ByVal PCoLine As Short?, ByVal PDueDate As DateTime?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iApsCtpUpdateDueDateExt As IApsCtpUpdateDueDate = New ApsCtpUpdateDueDateFactory().Create(appDb)
            Dim Severity As Integer = iApsCtpUpdateDueDateExt.ApsCtpUpdateDueDateSp(PCoNum, PCoLine, PDueDate)
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ApsGetXRefOrderIDSp(ByVal SupplyRefType As String, ByVal SupplyRefNum As String, ByVal SupplyRefLineSuf As Short?, ByVal SupplyRefRelease As Short?, ByVal DemandRefType As String, ByVal DemandRefNum As String, ByVal DemandRefLineSuf As Short?, ByVal DemandRefRelease As Short?, ByVal DemandSequence As Short?, ByVal Item As String, ByRef XRefOrderID As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iApsGetXRefOrderIDExt As IApsGetXRefOrderID = New ApsGetXRefOrderIDFactory().Create(appDb)
            Dim oXRefOrderID As ApsOrderType = XRefOrderID
            Dim Severity As Integer = iApsGetXRefOrderIDExt.ApsGetXRefOrderIDSp(SupplyRefType, SupplyRefNum, SupplyRefLineSuf, SupplyRefRelease, DemandRefType, DemandRefNum, DemandRefLineSuf, DemandRefRelease, DemandSequence, Item, oXRefOrderID)
            XRefOrderID = oXRefOrderID
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ApsJobOrderExistsSp(ByVal Job As String, ByVal Suffix As Short?, ByRef CTPAllowed As Byte?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iApsJobOrderExistsExt As IApsJobOrderExists = New ApsJobOrderExistsFactory().Create(appDb)
            Dim oCTPAllowed As ListYesNoType = CTPAllowed
            Dim Severity As Integer = iApsJobOrderExistsExt.ApsJobOrderExistsSp(Job, Suffix, oCTPAllowed)
            CTPAllowed = oCTPAllowed
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ApsJobOrderIdSp(ByVal PJob As String, ByVal PSuffix As Short?, ByRef PApsOrderId As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iApsJobOrderIdExt As IApsJobOrderId = New ApsJobOrderIdFactory().Create(appDb)
            Dim oPApsOrderId As ApsOrderType = PApsOrderId
            Dim Severity As Integer = iApsJobOrderIdExt.ApsJobOrderIdSp(PJob, PSuffix, oPApsOrderId)
            PApsOrderId = oPApsOrderId
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function IsApsSiteRecordExistSp(ByRef IsExist As Integer?, ByRef Infobar As String) As Integer
        Dim iIsApsSiteRecordExistExt As IIsApsSiteRecordExist = New IsApsSiteRecordExistFactory().Create(Me, True)
        Dim result As (ReturnCode As Integer?, IsExist As Integer?, Infobar As String) = iIsApsSiteRecordExistExt.IsApsSiteRecordExistSp(IsExist, Infobar)
        IsExist = result.IsExist
        Infobar = result.Infobar
        Dim Severity As Integer = result.ReturnCode.Value
        Return Severity
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ApsCtpPlanOrderSp(ByVal PSite As String, ByVal POrder As String, ByVal AltNo As Short?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iApsCtpPlanOrderExt As IApsCtpPlanOrder = New ApsCtpPlanOrderFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iApsCtpPlanOrderExt.ApsCtpPlanOrderSp(PSite, POrder, AltNo)
            Dim Severity As Integer = result.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ApsCtpXRefSp(ByVal PJob As String, ByVal PSuffix As Short?, ByRef PAllowCtp As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iApsCtpXRefExt As IApsCtpXRef = New ApsCtpXRefFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PAllowCtp As Integer?) = iApsCtpXRefExt.ApsCtpXRefSp(PJob, PSuffix, PAllowCtp)
            Dim Severity As Integer = result.PAllowCtp.Value
            PAllowCtp = result.PAllowCtp
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ApsJobOrderStatusSp(ByVal PJob As String, ByVal PSuffix As Short?, ByRef PStatus As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iApsJobOrderStatusExt As IApsJobOrderStatus = New ApsJobOrderStatusFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Pstatus As Integer?) = iApsJobOrderStatusExt.ApsJobOrderStatusSp(PJob, PSuffix, PStatus)
            Dim Severity As Integer = result.ReturnCode.Value
            PStatus = result.Pstatus
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function MpsNextSp(ByRef PLastTran As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iMpsNextExt As IMpsNext = New MpsNextFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PLastTran As String) = iMpsNextExt.MpsNextSp(PLastTran)
            Dim Severity As Integer = result.ReturnCode.Value
            PLastTran = result.PLastTran
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function NextWoSp(ByVal PContext As String, ByVal PPrefix As String, ByVal PKeyLength As Integer?, ByRef PKey As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iNextWoExt As INextWo = New NextWoFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PKey As String, Infobar As String) = iNextWoExt.NextWoSp(PContext, PPrefix, PKeyLength, PKey, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            PKey = result.PKey
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

End Class