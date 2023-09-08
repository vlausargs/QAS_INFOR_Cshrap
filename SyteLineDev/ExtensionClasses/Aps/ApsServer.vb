Option Explicit On
Option Strict On

Imports Aps.ServerService

Public Class ApsServerInterface

    Public Shared Function RunPlanner(ByVal sApsHost As String, _
                                      ByVal iApsPort As Integer, _
                                      ByVal iAltNo As Integer, _
                                      ByVal sOrderID As String, _
                                      ByVal bReload As Boolean, _
                                      ByVal iScope As Integer, _
                                      ByVal iTaskID As Integer) As Integer

        Dim uApsCon As New apscon_s
        Dim uRunPlan As New runplan_s
        Dim iRC As Integer
        Dim oAps As New Aps.ServerService

        ' Connect to APS server
        iRC = oAps.cget_connection(uApsCon, sApsHost, iApsPort)
        If iRC <> APS_ERR_OK Then
            RunPlanner = iRC
            Exit Function
        End If

        ' Plan order
        uRunPlan.altno = iAltNo
        uRunPlan.item = sOrderID
        If (bReload) Then
            uRunPlan.reload = APS_RUNPLAN_RELOAD_TRUE
        Else
            uRunPlan.reload = APS_RUNPLAN_RELOAD_FALSE
        End If
        uRunPlan.scope = iScope
        uRunPlan.taskid = iTaskID

        iRC = oAps.crun_planner(uApsCon, uRunPlan)
        If iRC <> APS_ERR_OK Then
            RunPlanner = iRC
            iRC = oAps.cdel_connection(uApsCon)
            Exit Function
        End If

        ' Disconnect from APS server
        iRC = oAps.cdel_connection(uApsCon)
        If iRC <> APS_ERR_OK Then
            RunPlanner = iRC
            Exit Function
        End If

        RunPlanner = APS_ERR_OK

    End Function

    Public Shared Function FlushGateway(ByVal sApsHost As String, _
                                        ByVal iApsPort As Integer, _
                                        ByVal iAltNo As Integer) As Integer

        Dim uApsCon As New apscon_s
        Dim uFlushGateway As New flushgateway_s
        Dim iRC As Integer
        Dim oAps As New Aps.ServerService

        ' Connect to APS server
        iRC = oAps.cget_connection(uApsCon, sApsHost, iApsPort)
        If iRC <> APS_ERR_OK Then
            FlushGateway = iRC
            Exit Function
        End If

        ' Flush the gateway
        uFlushGateway.AltNo = iAltNo

        iRC = oAps.cflush_gateway(uApsCon, uFlushGateway)
        If iRC <> APS_ERR_OK Then
            FlushGateway = iRC
            iRC = oAps.cdel_connection(uApsCon)
            Exit Function
        End If

        ' Disconnect from APS server
        iRC = oAps.cdel_connection(uApsCon)
        If iRC <> APS_ERR_OK Then
            FlushGateway = iRC
            Exit Function
        End If

        FlushGateway = APS_ERR_OK

    End Function

    Public Shared Function GetPlannerLog(ByVal sHost As String, _
                                         ByVal iPort As Integer, _
                                         ByRef sLogText As String) As Integer

        Dim uCon As New ERDB.Server.rcon_s
        Dim iRC As Integer
        Dim oAps As New ERDB.Server

        ' Connect to APS server
        iRC = oAps.cget_connection(uCon, sHost, iPort)
        If iRC <> ERDB.Server.ERR_OK Then
            GetPlannerLog = iRC
            Exit Function
        End If

        ' Get the log file text
        iRC = oAps.cget_logfile(uCon, sLogText)
        If iRC <> ERDB.Server.ERR_OK Then
            GetPlannerLog = iRC
            iRC = oAps.cdel_connection(uCon)
            Exit Function
        End If

        ' Disconnect from APS server
        iRC = oAps.cdel_connection(uCon)
        If iRC <> ERDB.Server.ERR_OK Then
            GetPlannerLog = iRC
            Exit Function
        End If

        GetPlannerLog = ERDB.Server.ERR_OK

    End Function

    Public Shared Function DeleteOrder(ByVal sApsHost As String, _
                                       ByVal iApsPort As Integer, _
                                       ByVal iAltNo As Integer, _
                                       ByVal sOrderID As String, _
                                       ByVal iTaskID As Integer) As Integer

        Dim uApsCon As New apscon_s
        Dim uDelOrder As New delorder_s
        Dim iRC As Integer
        Dim oAps As New Aps.ServerService

        ' Connect to APS server
        iRC = oAps.cget_connection(uApsCon, sApsHost, iApsPort)
        If iRC <> APS_ERR_OK Then
            DeleteOrder = iRC
            Exit Function
        End If

        ' Plan order
        uDelOrder.altno = iAltNo
        uDelOrder.order = sOrderID
        uDelOrder.taskid = iTaskID

        iRC = oAps.cdelete_order(uApsCon, uDelOrder)
        If iRC <> APS_ERR_OK Then
            DeleteOrder = iRC
            iRC = oAps.cdel_connection(uApsCon)
            Exit Function
        End If

        ' Disconnect from APS server
        iRC = oAps.cdel_connection(uApsCon)
        If iRC <> APS_ERR_OK Then
            DeleteOrder = iRC
            Exit Function
        End If

        DeleteOrder = APS_ERR_OK

    End Function


End Class
