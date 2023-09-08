'Public Class ESBQuoteLineViews

'End Class

Option Explicit On


Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.Core.Common
Imports Mongoose.Core.Configuration
Imports Mongoose.Scripting
Imports System.Data.SqlClient
Imports Mongoose.IDO.DataAccess
Imports System.Management
Imports System.Security.Cryptography
Imports System.IO
Imports System.Text
Imports TDCI.BuyDesign.Configurator.Integration.Win






'ADDED FOR POST CONFIGURATION PURPOSES
Imports System
Imports System.Data
Imports Microsoft.VisualBasic
Imports CSI.MG
Imports CSI.BusInterface
Imports CSI.Data.RecordSets
'ADDED FOR POST CONFIGURATION PURPOSES

'Namespace BusInterface
<IDOExtensionClass("ESBQuoteLineViews")>
Public Class ESBQuoteLineViews

    Inherits ExtensionClassBase

    Public Function LoadProcessQuoteLineWrapper(ByVal pCoNum As String, ByVal pCoLine As String, ByVal pConfirmationRef As String, ByVal pActionCode As String,
            ByVal pStat As String, ByVal pItem As String, ByVal pQtyOrderedConv As String, ByVal pISOUM As String, ByVal pFixedPriceItemIndicator As String, ByVal pUnitPriceConv As String,
            ByVal pCurrCode As String, ByVal pExtPrice As String, ByVal pTotPretaxAmt As String, ByVal pDesc As String, ByVal pReservationRef As String, ByVal pWhse As String,
            ByVal pRequiredDeliveryDateTime As String, ByVal pDropShipCustNum As String, ByVal pHeaderID As String, ByVal pConfigurationID As String,
            ByRef opRowPointer As String, ByRef opInfoBar As String) As Integer

        Dim response As InvokeResponseData
        Dim oDataReader As IDataReader = Nothing
        Dim GetSystemParm1 As Integer
        Dim strParmName1 As String
        Dim strParmName2 As String
        Dim strParmName3 As String
        Dim strParmName4 As String
        Dim strParmName5 As String
        Dim strParmName6 As String
        Dim strParmName7 As String
        Dim strParmName8 As String
        Dim strParmName9 As String
        Dim strParmName10 As String
        Dim sSourceType As String
        Dim sSourceKey As String
        Dim sSourceDetailId As String
        Dim sDestType As String
        Dim sDestKey As String
        Dim sTargetDetailId As String
        Dim sSourceHeaderId As String
        Dim sTargetHeaderId As String
        Dim sHeaderType As String

        Dim sApplID As String = ""
        Dim sConfigHdrNameSpace As String = ""
        Dim sConfigurator As String = ""
        Dim sConfiguratorURL As String = ""
        Dim sMetadataInstance As String = ""
        Dim sAuthenticationKey As String = ""
        Dim sOrderType As String
        Dim sKey1 As String
        Dim sKey2 As String
        Dim sConfigID As String
        sConfigID = Nothing
        Dim sInfobar As String = ""
        Dim sSessionID As String
        Dim SMsg As String = ""
        Dim sSite As String
        sSite = Nothing
        Dim sCEP As String   ' CEP = Config Entry Point
        Dim sJob As String = ""
        Dim sSuffix As String = "0"
        Dim sCreateJob As String = "1"
        Dim sUpdatePrice As String = "0"
        Dim sDoRefresh As String = "0"
        Dim sEstatusJobProcess As String = ""
        Dim sEstatusJPDoRefresh As String = ""
        Dim sEstatusJPInfobar As String = ""
        Dim sReconfiguration As String = "0"
        Dim bXref As Boolean = False
        Dim vCoFromExternalNumber As String = ""
        Dim sCoFromExternalNumber As String = ""

        Dim message_coitem As String = ""
        Dim success_coitem As Boolean = False

        Dim JobInfobar As String = ""

        Dim hostServices As TDCI.BuyDesign.Configurator.Integration.Win.HostServices

        strParmName1 = "configurator_server_id"
        strParmName2 = "config_header_name_space"
        strParmName3 = "configurator"
        strParmName4 = "configurator_url"
        strParmName5 = "site"
        strParmName6 = "config_id"
        strParmName7 = "auto_job"
        strParmName8 = "co_num"
        strParmName9 = "config_metadata_instance_filename"
        strParmName10 = "config_authentication_key"

        'Here we got the real co_num value related from the ExternalConfirmatioRef
        IDORuntime.LogUserMessage("Inbound BOD Debug Process", UserDefinedMessageType.UserDefined0, "pConfirmationRef {0}", pConfirmationRef)

        Dim coColResponse As LoadCollectionResponseData
        If IsNothing(pConfirmationRef) = False Then
            Dim strFilter As String = String.Format("external_confirmation_ref = '{0}'", pConfirmationRef)
            coColResponse = Me.Context.Commands.LoadCollection("SLCos", "CoNum", strFilter, "", 1)

            IDORuntime.LogUserMessage("Inbound BOD Debug Process", UserDefinedMessageType.UserDefined0, "vCoFromExternalNumber {0}", vCoFromExternalNumber)
            IDORuntime.LogUserMessage("Inbound BOD Debug Process", UserDefinedMessageType.UserDefined0, "sCoFromExternalNumber {0}", sCoFromExternalNumber)

            pCoNum = coColResponse.Items(0).PropertyValues(0).Value
        End If

        IDORuntime.LogUserMessage("Inbound BOD Debug Process", UserDefinedMessageType.UserDefined0, "CoNum {0}", pCoNum)
        IDORuntime.LogUserMessage("Inbound BOD Debug Process", UserDefinedMessageType.UserDefined0, "CoLine {0}", pCoLine)
        IDORuntime.LogUserMessage("Inbound BOD Debug Process", UserDefinedMessageType.UserDefined0, "HeaderID {0}", pHeaderID)
        IDORuntime.LogUserMessage("Inbound BOD Debug Process", UserDefinedMessageType.UserDefined0, "ConfigurationID {0}", pConfigurationID)

        'Standard call to LoadProcessQuoteLineSp Method to create coitem lines
        Try
            response = Me.Context.Commands.Invoke("ESBQuoteLineViews", "LoadProcessQuoteLineSp", pCoNum, pCoLine, pConfirmationRef, pActionCode, pStat, pItem, pQtyOrderedConv, pISOUM, pUnitPriceConv,
                                                  pCurrCode, pExtPrice, pTotPretaxAmt, pDesc, pReservationRef, pFixedPriceItemIndicator, opRowPointer, opInfoBar)
            IDORuntime.LogUserMessage("Inbound BOD Debug Process", UserDefinedMessageType.UserDefined0, "After LoadProcessQuoteLineSp{0}", response)

            opRowPointer = response.Parameters(15).ToString
            opInfoBar = response.Parameters(16).ToString

            If Not response.IsReturnValueStdError() Then
                success_coitem = True
            Else
                Return 16
            End If

        Catch ex As Exception
            message_coitem = MGException.ExtractMessages(ex)
            IDORuntime.LogUserMessage("LoadProcessQuoteLineSp exception", UserDefinedMessageType.UserDefined0, ex.Message)
            opInfoBar = ex.Message
            Return 16
        End Try

        IDORuntime.LogUserMessage("Inbound BOD Debug Process", UserDefinedMessageType.UserDefined0, "After LoadProcessSalesOrderLineSp success_coitem value{0}", success_coitem)
        IDORuntime.LogUserMessage("Inbound BOD Debug Process", UserDefinedMessageType.UserDefined0, "After LoadProcessSalesOrderLineSp message_coitem value{0}", message_coitem)

        Dim invColResponse As LoadCollectionResponseData
        invColResponse = Me.Context.Commands.LoadCollection("SLInvparms", "ConfiguratorServerId,ConfigHeaderNameSpace,Configurator,ConfiguratorUrl,MetaInstance,AuthKey", "", "", 1)

        sApplID = invColResponse.Items(0).PropertyValues(0).Value
        sConfigHdrNameSpace = invColResponse.Items(0).PropertyValues(1).Value
        sConfigurator = invColResponse.Items(0).PropertyValues(2).Value
        sConfiguratorURL = invColResponse.Items(0).PropertyValues(3).Value
        sMetadataInstance = invColResponse.Items(0).PropertyValues(4).Value
        sAuthenticationKey = invColResponse.Items(0).PropertyValues(5).Value

        'Get site from parms table
        'OR invparms configuration parameters
        'Dim parmColResponse As LoadCollectionResponseData
        coColResponse = Me.Context.Commands.LoadCollection("SLParms", "Site", "", "", 1)
        sSite = coColResponse.Items(0).PropertyValues(0).Value
        IDORuntime.LogUserMessage("Inbound BOD Debug Process", UserDefinedMessageType.UserDefined0, "sSite {0}", sSite)

        'Prepare to call CPQ's HostServices.Copy API to copy the configuration
        sSourceKey = pHeaderID
        sSourceType = "CO"
        If IsNumeric(sSourceKey) Then
            While Len(sSourceKey) < 10
                sSourceKey = " " + sSourceKey
            End While
        End If
        If sSourceType = "CO" Or sSourceType = "COLINE" Then
            sHeaderType = "1"
        ElseIf sSourceType = "COBLN" Then
            sHeaderType = "105"
        ElseIf sSourceType = "EST" Or sSourceType = "ESTLINE" Then
            sHeaderType = "2"
        ElseIf sSourceType = "JOB" Then
            sHeaderType = "101"
        ElseIf sSourceType = "EstimateJob" Then
            sHeaderType = "102"
        Else
            sHeaderType = "0"  ' This should never happen
        End If
        'sHeaderType has always a 1 value
        sHeaderType = "1"


        IDORuntime.LogUserMessage("PCM Debug process", UserDefinedMessageType.UserDefined0, "pConfigurationID: {0}", pConfigurationID)
        IDORuntime.LogUserMessage("PCM Debug process", UserDefinedMessageType.UserDefined0, "pHeaderID: {0}", pHeaderID)


        If IsNothing(pConfigurationID) = False And IsNothing(pHeaderID) = False Then

            sSourceHeaderId = sSourceKey
            sSourceDetailId = pConfigurationID

            'Here is where we build the sDestKey based on the CoNum and CoLine values 
            sDestKey = pCoNum
            sDestType = "EST"
            If IsNumeric(sDestKey) Then
                While Len(sDestKey) < 10
                    sDestKey = " " + sDestKey
                End While
            End If
            If sDestType = "CO" Or sDestType = "COLINE" Then
                sHeaderType = "1"
            ElseIf sDestType = "COBLN" Then
                sHeaderType = "105"
            ElseIf sDestType = "EST" Or sDestType = "ESTLINE" Then
                sHeaderType = "2"
            ElseIf sDestType = "JOB" Then
                sHeaderType = "101"
            ElseIf sDestType = "EstimateJob" Then
                sHeaderType = "102"
            Else
                sHeaderType = "0"  ' This should never happen
            End If

            sTargetHeaderId = sDestKey + "-" + CStr(sHeaderType) + "-" + sSite
            sTargetDetailId = pCoLine

            IDORuntime.LogUserMessage("PCM Debug process", UserDefinedMessageType.UserDefined0, "Before TDCI.BuyDesign.Configurator.Integration.Win.HostServices - sApplID: {0}", sApplID)
            IDORuntime.LogUserMessage("PCM Debug process", UserDefinedMessageType.UserDefined0, "Before TDCI.BuyDesign.Configurator.Integration.Win.HostServices - sConfiguratorURL: {0}", sConfiguratorURL)

            Try
                If IDONull.IsNull(sAuthenticationKey) Or sAuthenticationKey = "" Then
                    hostServices = New TDCI.BuyDesign.Configurator.Integration.Win.HostServices(sMetadataInstance, sApplID, sConfiguratorURL)
                Else
                    hostServices = New TDCI.BuyDesign.Configurator.Integration.Win.HostServices(sMetadataInstance, sApplID, sConfiguratorURL, sAuthenticationKey)
                End If

                IDORuntime.LogUserMessage("PCM Debug process", UserDefinedMessageType.UserDefined0, "Before hostServices.Copy - sSourceHeaderId: {0}", sSourceHeaderId)
                IDORuntime.LogUserMessage("PCM Debug process", UserDefinedMessageType.UserDefined0, "Before hostServices.Copy - sSourceDetailId: {0}", sSourceDetailId)
                IDORuntime.LogUserMessage("PCM Debug process", UserDefinedMessageType.UserDefined0, "Before hostServices.Copy - sTargetHeaderId: {0}", sTargetHeaderId)
                IDORuntime.LogUserMessage("PCM Debug process", UserDefinedMessageType.UserDefined0, "Before hostServices.Copy - sTargetDetailId: {0}", sTargetDetailId)

                Try
                    hostServices.Copy(sSourceHeaderId, sSourceDetailId, sTargetHeaderId, sTargetDetailId, False, True)
                Catch ex As Exception
                    IDORuntime.LogUserMessage("PCM Debug process", UserDefinedMessageType.UserDefined0, "Error calling HostServices.Copy: {0}", ex.Message)
                    hostServices = Nothing
                    opInfoBar = ex.Message
                    Return 16
                End Try

                'hostServices.Copy(sSourceHeaderId, sSourceDetailId, sTargetHeaderId, sTargetDetailId, False, True)
                ' Map data from BuyDesign Configuration to CFG Tables

                'BDC SL9MAP CONFIGURATION PROCESS
                GetSystemParm1 = 0
                Try
                    Dim response_cid As InvokeResponseData
                    Dim mapInfobar As String = ""

                    IDORuntime.LogUserMessage("PCM Debug process", UserDefinedMessageType.UserDefined0, "Before SL.SLCfgMains CfgNextCfgIdSp - sHeaderType: {0}", sHeaderType)
                    IDORuntime.LogUserMessage("PCM Debug process", UserDefinedMessageType.UserDefined0, "Before SL.SLCfgMains CfgNextCfgIdSp - mapInfobar: {0}", mapInfobar)

                    Try
                        response_cid = Me.Context.Commands.Invoke("SL.SLCfgMains", "CfgNextCfgIdSp", sHeaderType, mapInfobar)
                        sConfigID = response_cid.Parameters(0).ToString()
                    Catch ex As Exception
                        IDORuntime.LogUserMessage("response_cid exception", UserDefinedMessageType.UserDefined0, ex.Message)
                    End Try
                Catch ex As Exception
                    GetSystemParm1 = 16
                    IDORuntime.LogUserMessage("GetSystemParm1 exception", UserDefinedMessageType.UserDefined0, ex.Message)

                End Try
                'BDC SL9 MAP CONFIGURATION PROCESS
                IDORuntime.LogUserMessage("PCM Debug process", UserDefinedMessageType.UserDefined0, "After SL.SLCfgMains CfgNextCfgIdSp - sConfigID: {0}", sConfigID)

                sKey1 = pCoNum
                sOrderType = sHeaderType
                sKey2 = pCoLine
                sSessionID = sKey1 + "-" + CStr(sOrderType) + "-" + sSite

                If IsNumeric(sKey1) Then
                    While Len(sKey1) < 10
                        sKey1 = " " + sKey1
                    End While
                End If

                Try
                    IDORuntime.LogUserMessage("PCM Debug process", UserDefinedMessageType.UserDefined0, "Check Point 1 before MapConfigurationData")
                    IDORuntime.LogUserMessage("PCM Debug process", UserDefinedMessageType.UserDefined0, "Starting method at {0}", DateTime.Now)
                    IDORuntime.LogUserMessage("PCM Debug process", UserDefinedMessageType.UserDefined0, "sKey1: {0}", sKey1)
                    IDORuntime.LogUserMessage("PCM Debug process", UserDefinedMessageType.UserDefined0, "sOrderType: {0}", sOrderType)
                    IDORuntime.LogUserMessage("PCM Debug process", UserDefinedMessageType.UserDefined0, "sKey2: {0}", sKey2)
                    IDORuntime.LogUserMessage("PCM Debug process", UserDefinedMessageType.UserDefined0, "sConfigID: {0}", sConfigID)
                    IDORuntime.LogUserMessage("PCM Debug process", UserDefinedMessageType.UserDefined0, "sSessionID: {0}", sSessionID)
                    IDORuntime.LogUserMessage("PCM Debug process", UserDefinedMessageType.UserDefined0, "sSite: {0}", sSite)

                    ' hostServices.ExecuteExtension("MapConfigurationData", New String() {sKey1, sOrderType, sKey2, sConfigID, sSessionID, sSite})
                    Me.Context.Commands.Invoke("SLCfgMains", "CfgMapConfigurationData",
                                            sKey1,
                                            sKey2,
                                            sOrderType,
                                            sConfigID,
                                            sKey2,
                                            sApplID,
                                            sConfigurator, sSite,
                                            sConfiguratorURL, JobInfobar, sSessionID)
                Catch ex As Exception
                    IDORuntime.LogUserMessage("PCM Debug process", UserDefinedMessageType.UserDefined0, "Check Point 3 Exception on MapConfigurationData")
                    IDORuntime.LogUserMessage("PCM Debug process", UserDefinedMessageType.UserDefined0, "Starting method at {0}", DateTime.Now)
                    IDORuntime.LogUserMessage("PCM Debug process", UserDefinedMessageType.UserDefined0, "Caught exception: {0}", ex.Message)
                    opInfoBar = "Wrapper Results: " & sKey1 & Space(1) & sOrderType & Space(1) & sKey2 & Space(1) & sConfigID & Space(1) & sSessionID & Space(1) & sSite
                    IDORuntime.LogUserMessage("PCM Debug process", UserDefinedMessageType.UserDefined0, "opInfoBar: {0}", opInfoBar)
                End Try

                IDORuntime.LogUserMessage("PCM Debug process", UserDefinedMessageType.UserDefined0, "Check Point 2 after MapConfigurationData")
                IDORuntime.LogUserMessage("PCM Debug process", UserDefinedMessageType.UserDefined0, "Starting method at {0}", DateTime.Now)
                IDORuntime.LogUserMessage("PCM Debug process", UserDefinedMessageType.UserDefined0, "sKey1: {0}", sKey1)
                IDORuntime.LogUserMessage("PCM Debug process", UserDefinedMessageType.UserDefined0, "sOrderType: {0}", sOrderType)
                IDORuntime.LogUserMessage("PCM Debug process", UserDefinedMessageType.UserDefined0, "sKey2: {0}", sKey2)
                IDORuntime.LogUserMessage("PCM Debug process", UserDefinedMessageType.UserDefined0, "sConfigID: {0}", sConfigID)
                IDORuntime.LogUserMessage("PCM Debug process", UserDefinedMessageType.UserDefined0, "sSessionID: {0}", sSessionID)
                IDORuntime.LogUserMessage("PCM Debug process", UserDefinedMessageType.UserDefined0, "sSite: {0}", sSite)

                Try
                    'Set sDestType to EstimateLine
                    sDestType = "ESTLINE"

                    ' Map sSource to sCEP
                    If sDestType = "EST" Then
                        sCEP = "Estimate"
                    ElseIf sDestType = "ESTLINE" Then
                        sCEP = "EstimateLine"
                    ElseIf sDestType = "CO" Then
                        sCEP = "CustomerOrder"
                    ElseIf sDestType = "COLINE" Then
                        sCEP = "COLine"
                    ElseIf sDestType = "COBLN" Then
                        sCEP = "COBlanketLine"
                    ElseIf sDestType = "EstimateJob" Then
                        sCEP = "EstimateJob"
                    ElseIf sDestType = "JOB" Then
                        sCEP = "Job"
                    Else
                        sCEP = "UNKNOWN"   ' Should never happen
                    End If

                    ' set coitem.config_id
                    response = Me.Context.Commands.Invoke("SL.SLCfgMains", "CfgSetConfigIdSp", sCEP, sKey1, sKey2, 0, sConfigID, IDONull.Value, 0)
                Catch ex As Exception
                    MGException.Throw(MGException.ExtractMessages(ex))
                End Try

            Catch Ex As Exception
                IDORuntime.LogUserMessage("PCM Debug process ", UserDefinedMessageType.UserDefined0, "Error calling Host Services: {0}", Ex.Message)
            Finally
                hostServices = Nothing
            End Try
        End If
        Return 0
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_ESBQuoteLineSp(ByVal DocumentID As String, ByVal DocumentIDNum As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker = New MGInvoker(Me.Context)
            Dim iCLM_ESBQuoteLineExt = New CLM_ESBQuoteLineFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result = iCLM_ESBQuoteLineExt.CLM_ESBQuoteLineSp(DocumentID, DocumentIDNum)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_ESBSp() As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iCLM_ESBExt As ICLM_ESB = New CLM_ESBFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (Data As CSI.Data.CRUD.ICollectionLoadResponse, ReturnCode As Integer?) = iCLM_ESBExt.CLM_ESBSp()
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function LoadProcessQuoteLinePostSp(ByVal ExternalConfirmationRef As String, ByRef Infobar As String) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iLoadProcessQuoteLinePostExt = New LoadProcessQuoteLinePostFactory().Create(appDb)

            Dim Severity As Integer = iLoadProcessQuoteLinePostExt.LoadProcessQuoteLinePostSp(ExternalConfirmationRef, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function LoadProcessQuoteLineSp(ByVal pCoNum As String, ByVal pCoLine As Short?, ByVal pConfirmationRef As String, ByVal pActionCode As String, ByVal pStat As String, ByVal pItem As String, ByVal pQtyOrderedConv As Decimal?, ByVal pISOUM As String, ByVal pUnitPriceConv As Decimal?, ByVal pCurrCode As String, ByVal pExtPrice As Decimal?, ByVal pTotPretaxAmt As Decimal?, ByVal pDesc As String, ByVal pReservationRef As String, ByVal pFixedPriceItemIndicator As String, ByRef RowPointer As Guid?, ByRef Infobar As String) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iLoadProcessQuoteLineExt = New LoadProcessQuoteLineFactory().Create(appDb)

            Dim Severity As Integer = iLoadProcessQuoteLineExt.LoadProcessQuoteLineSp(pCoNum, pCoLine, pConfirmationRef, pActionCode, pStat, pItem, pQtyOrderedConv, pISOUM, pUnitPriceConv, pCurrCode, pExtPrice, pTotPretaxAmt, pDesc, pReservationRef, pFixedPriceItemIndicator, RowPointer, Infobar)

            Return Severity
        End Using
    End Function
End Class





