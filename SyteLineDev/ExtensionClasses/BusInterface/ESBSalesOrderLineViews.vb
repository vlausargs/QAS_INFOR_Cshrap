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
Imports System.Runtime.InteropServices
Imports CSI.Data.RecordSets
'ADDED FOR POST CONFIGURATION PURPOSES

'Namespace BusInterface
<IDOExtensionClass("ESBSalesOrderLineViews")>
Public Class ESBSalesOrderLineView

    Inherits ExtensionClassBase

    Public Enum Status
        Yes = 1
        No = 0
        StatError = -1
    End Enum



    Private ReadOnly PassPhrase = "sLI)hrase"
    Private ReadOnly InitVector = "@H81B2c3D4e5F6g7"
    ReadOnly a() As String = {"a", "a"}

    ReadOnly ServiceActionStatus() As String = {
        "Success",
        "Not Supported",
        "Access Denied",
        "Dependent Services Running",
        "Invalid Service Control",
        "Service Cannot Accept Control",
        "Service Not Active",
        "Service Request timeout",
        "Unknown Failure",
        "Path Not Found",
        "Service Already Running",
        "Service Database Locked",
        "Service Dependency Deleted",
        "Service Dependency Failure",
        "Service Disabled",
        "Service Logon Failed",
        "Service Marked For Deletion",
        "Service No Thread",
        "Status Circular Dependency",
        "Status Duplicate Name",
        "Status - Invalid Name",
        "Status - Invalid Parameter",
        "Status - Invalid Service Account",
        "Status - Service Exists",
        "Service Already Paused"}

    Public Function LoadProcessSalesOrderLineWrapper(ByVal pCoNum As String, ByVal pCoLine As String, ByVal pConfirmationRef As String, ByVal pActionCode As String,
           ByVal pStat As String, ByVal pItem As String, ByVal pQtyOrderedConv As String, ByVal pISOUM As String, ByVal pFixedPriceItemIndicator As String, ByVal pUnitPriceConv As String,
           ByVal pCurrCode As String, ByVal pExtPrice As String, ByVal pTotPretaxAmt As String, ByVal pDesc As String, ByVal pReservationRef As String, ByVal pWhse As String,
           ByVal pRequiredDeliveryDateTime As String, ByVal pDropShipCustNum As String, ByVal pHeaderID As String, ByVal pConfigurationID As String,
           ByRef opRowPointer As String, ByRef opInfoBar As String) As Integer

        Dim response As InvokeResponseData
        Dim oDataReader As IDataReader = Nothing
        Dim cmd As SqlClient.SqlCommand
        Dim vConfigServerId As String
        Dim vConfigHdrNameSpace As String
        Dim vConfigurator As String
        Dim vConfiguratorURL As String
        Dim GetSystemParm1 As Integer
        Dim GetSystemParm2 As Integer
        Dim GetSystemParm3 As Integer
        Dim GetSystemParm4 As Integer
        Dim GetSystemParm5 As Integer
        Dim GetSystemParm6 As Integer
        Dim GetSystemParm7 As Integer
        Dim GetSystemParm8 As Integer
        Dim GetSystemParm9 As Integer
        Dim strParmName1 As String
        Dim strParmName2 As String
        Dim strParmName3 As String
        Dim strParmName4 As String
        Dim strParmName5 As String
        Dim strParmName6 As String
        Dim strParmName7 As String
        Dim strParmName8 As String
        Dim strParmName9 As String
        Dim strParmValue1 As String
        Dim strParmValue2 As String
        Dim strParmValue3 As String
        Dim strParmValue4 As String
        Dim strParmValue5 As String
        Dim strParmValue8 As String
        Dim strParmValue9 As String
        'Dim strParmValue6 As String
        'Dim strParmValue7 As String
        Dim sSourceType As String
        Dim sSourceKey As String
        Dim sSourceDetailId As String
        Dim sDestType As String
        Dim sDestKey As String
        Dim sTargetDetailId As String
        Dim sSourceHeaderId As String
        Dim sTargetHeaderId As String
        Dim sHeaderType As String
        'Dim sAutoJob As String
        Dim hostServices As TDCI.BuyDesign.Configurator.Integration.Win.HostServices
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

        Dim JobInfobar As String = ""
        strParmName1 = "configurator_server_id" ' inv_parms
        strParmName2 = "config_header_name_space" ' inv_parms
        strParmName3 = "configurator" ' inv_parms
        strParmName4 = "configurator_url" ' inv_parms
        strParmName5 = "site" ' parms
        strParmName6 = "config_id" ' coitem
        strParmName7 = "auto_job" ' item
        strParmName8 = "config_metadata_instance_filename" ' item
        strParmName9 = "config_authentication_key" ' item

        IDORuntime.LogUserMessage("Inbound Form Debug Process", UserDefinedMessageType.UserDefined0, "CoNum {0}", pCoNum)
        IDORuntime.LogUserMessage("Inbound Form Debug Process", UserDefinedMessageType.UserDefined0, "CoLine {0}", pCoLine)
        IDORuntime.LogUserMessage("Inbound Form Debug Process", UserDefinedMessageType.UserDefined0, "HeaderID {0}", pHeaderID)
        IDORuntime.LogUserMessage("Inbound Form Debug Process", UserDefinedMessageType.UserDefined0, "ConfigurationID {0}", pConfigurationID)

        Try
            'Standard call to LoadProcessSalesOrderLineSp Method to create coitem lines
            response = Me.Context.Commands.Invoke("ESBSalesOrderLineViews", "LoadProcessSalesOrderLineSp", pCoNum, pCoLine, pConfirmationRef, pActionCode, pStat, pItem, pQtyOrderedConv, pISOUM, pFixedPriceItemIndicator, pUnitPriceConv,
              pCurrCode, pExtPrice, pTotPretaxAmt, pDesc, pReservationRef, pWhse, pRequiredDeliveryDateTime, pDropShipCustNum, opRowPointer, opInfoBar)

            'HARD CODE TEST 
            'response = Me.Context.Commands.Invoke("ESBSalesOrderLineViews", "LoadProcessSalesOrderLineSp", "Z0000050_1", "19", "PCM_OGRM1", "Add", "Open", "BIKE", "10", "EA", "True", "100", _
            '    "USD", "1000", "0", "Configured Bicycle from eCommerce", vbNullString, "zzz", "2014-11-13", vbNullString, opRowPointer, opInfoBar)

            opRowPointer = response.Parameters(18).ToString
            opInfoBar = response.Parameters(19).ToString

            If response.IsReturnValueStdError() Then
                Return 16
            End If
        Catch ex As Exception
            opInfoBar = ex.Message
            Return 16
        End Try

        'OR invparms configuration parameters
        GetSystemParm1 = 0
        Try
            Using appDB As AppDB = Me.CreateAppDB()
                ' create a new SqlCommand
                cmd = New SqlClient.SqlCommand With {
                    .CommandType = CommandType.Text,
                    .CommandText = "SELECT " & strParmName1 & " FROM invparms"
                }
                Try
                    ' execute the command through the framework
                    oDataReader = appDB.ExecuteReader(cmd)
                Catch ex As Exception
                    GetSystemParm1 = 16
                    MGException.Throw(MGException.ExtractMessages(ex))
                End Try

                If oDataReader.Read Then
                    strParmValue1 = oDataReader.Item(strParmName1).ToString
                    vConfigServerId = strParmValue1
                    sApplID = vConfigServerId
                Else
                    GetSystemParm1 = 16
                    MGException.Throw(Me.CreateAppDB.GetMessageProvider.GetMessage("E=NoExist1", "@!Parameters", "@invparms", strParmName1))
                    '("PCM" & ":" & "No system parms have been defined, or " & strParmName & " is not a valid system parm.")
                End If
                oDataReader.Close()
                'OR Exit Function
            End Using
        Catch ex As Exception
            GetSystemParm1 = 16
            MGException.Throw(MGException.ExtractMessages(ex))
        End Try

        GetSystemParm2 = 0
        Try
            Using appDB As AppDB = Me.CreateAppDB()
                ' create a new SqlCommand
                cmd = New SqlClient.SqlCommand With {
                    .CommandType = CommandType.Text,
                    .CommandText = "SELECT " & strParmName2 & " FROM invparms"
                }
                Try
                    ' execute the command through the framework
                    oDataReader = appDB.ExecuteReader(cmd)
                Catch ex As Exception
                    GetSystemParm2 = 16
                    MGException.Throw(MGException.ExtractMessages(ex))
                End Try

                If oDataReader.Read Then
                    strParmValue2 = oDataReader.Item(strParmName2).ToString
                    vConfigHdrNameSpace = strParmValue2
                    sConfigHdrNameSpace = vConfigHdrNameSpace
                Else
                    GetSystemParm2 = 16
                    MGException.Throw(Me.CreateAppDB.GetMessageProvider.GetMessage("E=NoExist1", "@!Parameters", "@invparms", strParmName2))
                    '("PCM" & ":" & "No system parms have been defined, or " & strParmName & " is not a valid system parm.")
                End If
                oDataReader.Close()
                'OR Exit Function
            End Using
        Catch ex As Exception
            GetSystemParm2 = 16
            MGException.Throw(MGException.ExtractMessages(ex))
        End Try

        GetSystemParm3 = 0
        Try
            Using appDB As AppDB = Me.CreateAppDB()
                ' create a new SqlCommand
                cmd = New SqlClient.SqlCommand With {
                    .CommandType = CommandType.Text,
                    .CommandText = "SELECT " & strParmName3 & " FROM invparms"
                }
                Try
                    ' execute the command through the framework
                    oDataReader = appDB.ExecuteReader(cmd)
                Catch ex As Exception
                    GetSystemParm3 = 16
                    MGException.Throw(MGException.ExtractMessages(ex))
                End Try

                If oDataReader.Read Then
                    strParmValue3 = oDataReader.Item(strParmName3).ToString
                    vConfigurator = strParmValue3
                    sConfigurator = vConfigurator
                Else
                    GetSystemParm3 = 16
                    MGException.Throw(Me.CreateAppDB.GetMessageProvider.GetMessage("E=NoExist1", "@!Parameters", "@invparms", strParmName3))
                    '("PCM" & ":" & "No system parms have been defined, or " & strParmName & " is not a valid system parm.")
                End If
                oDataReader.Close()
                'OR Exit Function
            End Using
        Catch ex As Exception
            GetSystemParm3 = 16
            MGException.Throw(MGException.ExtractMessages(ex))
        End Try

        GetSystemParm4 = 0
        Try
            Using appDB As AppDB = Me.CreateAppDB()
                ' create a new SqlCommand
                cmd = New SqlClient.SqlCommand With {
                    .CommandType = CommandType.Text,
                    .CommandText = "SELECT " & strParmName4 & " FROM invparms"
                }
                Try
                    ' execute the command through the framework
                    oDataReader = appDB.ExecuteReader(cmd)
                Catch ex As Exception
                    GetSystemParm4 = 16
                    MGException.Throw(MGException.ExtractMessages(ex))
                End Try

                If oDataReader.Read Then
                    strParmValue4 = oDataReader.Item(strParmName4).ToString
                    vConfiguratorURL = strParmValue4
                    sConfiguratorURL = vConfiguratorURL
                Else
                    GetSystemParm4 = 16
                    MGException.Throw(Me.CreateAppDB.GetMessageProvider.GetMessage("E=NoExist1", "@!Parameters", "@invparms", strParmName4))
                    '("PCM" & ":" & "No system parms have been defined, or " & strParmName & " is not a valid system parm.")
                End If
                oDataReader.Close()
                'OR Exit Function
            End Using
        Catch ex As Exception
            GetSystemParm4 = 16
            MGException.Throw(MGException.ExtractMessages(ex))
        End Try

        GetSystemParm5 = 0
        Try
            Using appDB As AppDB = Me.CreateAppDB()
                ' create a new SqlCommand
                cmd = New SqlClient.SqlCommand With {
                    .CommandType = CommandType.Text,
                    .CommandText = "SELECT " & strParmName5 & " FROM parms"
                }
                Try
                    ' execute the command through the framework
                    oDataReader = appDB.ExecuteReader(cmd)
                Catch ex As Exception
                    GetSystemParm5 = 16
                    MGException.Throw(MGException.ExtractMessages(ex))
                End Try

                If oDataReader.Read Then
                    strParmValue5 = oDataReader.Item(strParmName5).ToString
                    sSite = strParmValue5

                Else
                    GetSystemParm5 = 16
                    MGException.Throw(Me.CreateAppDB.GetMessageProvider.GetMessage("E=NoExist1", "@!Parameters", "@parms", strParmName5))
                    '("PCM" & ":" & "No system parms have been defined, or " & strParmName & " is not a valid system parm.")
                End If
                oDataReader.Close()
                'OR Exit Function
            End Using
        Catch ex As Exception
            GetSystemParm5 = 16
            MGException.Throw(MGException.ExtractMessages(ex))
        End Try

        GetSystemParm8 = 0
        Try
            Using appDB As AppDB = Me.CreateAppDB()
                ' create a new SqlCommand
                cmd = New SqlClient.SqlCommand With {
                    .CommandType = CommandType.Text,
                    .CommandText = "SELECT " & strParmName8 & " FROM invparms"
                }
                Try
                    ' execute the command through the framework
                    oDataReader = appDB.ExecuteReader(cmd)
                Catch ex As Exception
                    GetSystemParm8 = 16
                    MGException.Throw(MGException.ExtractMessages(ex))
                End Try

                If oDataReader.Read Then
                    strParmValue8 = oDataReader.Item(strParmName8).ToString
                    sMetadataInstance = strParmValue8

                Else
                    GetSystemParm8 = 16
                    MGException.Throw(Me.CreateAppDB.GetMessageProvider.GetMessage("E=NoExist1", "@!Parameters", "@parms", strParmName8))
                    '("PCM" & ":" & "No system parms have been defined, or " & strParmName & " is not a valid system parm.")
                End If
                oDataReader.Close()
                'OR Exit Function
            End Using
        Catch ex As Exception
            GetSystemParm8 = 16
            MGException.Throw(MGException.ExtractMessages(ex))
        End Try

        GetSystemParm9 = 0
        Try
            Using appDB As AppDB = Me.CreateAppDB()
                ' create a new SqlCommand
                cmd = New SqlClient.SqlCommand With {
                    .CommandType = CommandType.Text,
                    .CommandText = "SELECT " & strParmName9 & " FROM invparms"
                }
                Try
                    ' execute the command through the framework
                    oDataReader = appDB.ExecuteReader(cmd)
                Catch ex As Exception
                    GetSystemParm9 = 16
                    MGException.Throw(MGException.ExtractMessages(ex))
                End Try

                If oDataReader.Read Then
                    strParmValue9 = oDataReader.Item(strParmName9).ToString
                    sAuthenticationKey = strParmValue9

                Else
                    GetSystemParm9 = 16
                    MGException.Throw(Me.CreateAppDB.GetMessageProvider.GetMessage("E=NoExist1", "@!Parameters", "@parms", strParmName9))
                    '("PCM" & ":" & "No system parms have been defined, or " & strParmName & " is not a valid system parm.")
                End If
                oDataReader.Close()
                'OR Exit Function
            End Using
        Catch ex As Exception
            GetSystemParm9 = 16
            MGException.Throw(MGException.ExtractMessages(ex))
        End Try

        Try

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


            If IsNothing(pConfigurationID) = False And IsNothing(pHeaderID) = False Then

                sSourceHeaderId = sSourceKey
                sSourceDetailId = pConfigurationID

                'Here is where we build the sDestKey based on the CoNum and CoLine values 
                sDestKey = pCoNum
                sDestType = "CO"
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

                If IDONull.IsNull(sAuthenticationKey) Or sAuthenticationKey = "" Then
                    hostServices = New TDCI.BuyDesign.Configurator.Integration.Win.HostServices(sMetadataInstance, sApplID, sConfiguratorURL)
                Else
                    hostServices = New TDCI.BuyDesign.Configurator.Integration.Win.HostServices(sMetadataInstance, sApplID, sConfiguratorURL, sAuthenticationKey)
                End If

                Try
                    hostServices.Copy(sSourceHeaderId, sSourceDetailId, sTargetHeaderId, sTargetDetailId, False, True)
                Catch ex As Exception
                    IDORuntime.LogUserMessage("PCM Debug process", UserDefinedMessageType.UserDefined0, "Error calling HostServices.Copy: {0}", ex.Message)
                    hostServices = Nothing
                    opInfoBar = ex.Message
                    Return 16
                End Try

                'BDC SL9MAP CONFIGURATION PROCESS
                GetSystemParm6 = 0
                Try
                    Using appDB As AppDB = Me.CreateAppDB()
                        Dim response_cid As InvokeResponseData
                        Dim mapInfobar As String = ""
                        response_cid = Me.Context.Commands.Invoke("SL.SLCfgMains", "CfgNextCfgIdSp", sHeaderType, mapInfobar)
                        sConfigID = response_cid.Parameters(0).ToString()

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
                                            CInt(sKey2),
                                            sOrderType,
                                            sConfigID,
                                            sKey2,
                                            sApplID,
                                            sConfigurator, sSite,
                                            sConfiguratorURL, JobInfobar, sSessionID)

                            IDORuntime.LogUserMessage("PCM Debug process", UserDefinedMessageType.UserDefined0, "Check Point 2 after MapConfigurationData")
                            IDORuntime.LogUserMessage("PCM Debug process", UserDefinedMessageType.UserDefined0, "Starting method at {0}", DateTime.Now)
                            IDORuntime.LogUserMessage("PCM Debug process", UserDefinedMessageType.UserDefined0, "sKey1: {0}", sKey1)
                            IDORuntime.LogUserMessage("PCM Debug process", UserDefinedMessageType.UserDefined0, "sOrderType: {0}", sOrderType)
                            IDORuntime.LogUserMessage("PCM Debug process", UserDefinedMessageType.UserDefined0, "sKey2: {0}", sKey2)
                            IDORuntime.LogUserMessage("PCM Debug process", UserDefinedMessageType.UserDefined0, "sConfigID: {0}", sConfigID)
                            IDORuntime.LogUserMessage("PCM Debug process", UserDefinedMessageType.UserDefined0, "sSessionID: {0}", sSessionID)
                            IDORuntime.LogUserMessage("PCM Debug process", UserDefinedMessageType.UserDefined0, "sSite: {0}", sSite)


                        Catch ex As Exception
                            IDORuntime.LogUserMessage("PCM Debug process", UserDefinedMessageType.UserDefined0, "Check Point 3.1 Exception on MapConfigurationData")
                            IDORuntime.LogUserMessage("PCM Debug process", UserDefinedMessageType.UserDefined0, "Starting method at {0}", DateTime.Now)
                            IDORuntime.LogUserMessage("PCM Debug process", UserDefinedMessageType.UserDefined0, "Caught exception: {0}", ex.Message)
                            opInfoBar = "Wrapper Results: " & sKey1 & Space(1) & sOrderType & Space(1) & sKey2 & Space(1) & sConfigID & Space(1) & sSessionID & Space(1) & sSite
                            IDORuntime.LogUserMessage("PCM Debug process", UserDefinedMessageType.UserDefined0, "opInfoBar: {0}", opInfoBar)

                        End Try

                        'IF COPY JOB IS REQUIRED 
                        GetSystemParm7 = 0
                        Try
                            Using appDB1 As AppDB = Me.CreateAppDB()
                                ' create a new SqlCommand
                                cmd = New SqlClient.SqlCommand With {
                                    .CommandType = CommandType.Text,
                                    .CommandText = "SELECT " & strParmName7 & " FROM item WHERE item.item = " & "'" & pItem & "'"
                                }
                                Try
                                    ' execute the command through the framework
                                    oDataReader = appDB1.ExecuteReader(cmd)
                                Catch ex As Exception
                                    GetSystemParm7 = 16
                                    MGException.Throw(MGException.ExtractMessages(ex))
                                End Try

                                'Dim response_autojob As InvokeResponseData
                                'Set sDestType to COLINE
                                sDestType = "COLINE"

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

                            End Using
                        Catch ex As Exception
                            GetSystemParm7 = 16
                            MGException.Throw(MGException.ExtractMessages(ex))
                        End Try
                        'IF COPY JOB IS REQUIRED 

                    End Using
                Catch ex As Exception
                    GetSystemParm6 = 16
                    MGException.Throw(MGException.ExtractMessages(ex))
                End Try
                'BDC SL9 MAP CONFIGURATION PROCESS

            End If



        Finally
            hostServices = Nothing
        End Try

        'opInfoBar = "Wrapper Results: " & sApplID & Space(1) & sConfigHdrNameSpace & Space(1) & sConfigurator & Space(1) & sConfiguratorURL & Space(1) & _
        '    sSite & Space(1) & pHeaderID & Space(1) & pConfigurationID & Space(1) & sSourceHeaderId & Space(1) & sSourceDetailId & Space(1) & _
        '    sTargetHeaderId & Space(1) & sTargetDetailId & Space(1) & sConfigID & Space(1) & sEstatusJobProcess & Space(1) & _
        '    sEstatusJPDoRefresh & Space(1) & sEstatusJPInfobar

        Return 0

    End Function

    Public Function LoadProcessSalesOrderLineWrapperAsync(ByVal pCoNum As String, ByVal pCoLine As String, ByVal pConfirmationRef As String, ByVal pActionCode As String,
            ByVal pStat As String, ByVal pItem As String, ByVal pQtyOrderedConv As String, ByVal pISOUM As String, ByVal pFixedPriceItemIndicator As String, ByVal pUnitPriceConv As String,
            ByVal pCurrCode As String, ByVal pExtPrice As String, ByVal pTotPretaxAmt As String, ByVal pDesc As String, ByVal pReservationRef As String, ByVal pWhse As String,
            ByVal pRequiredDeliveryDateTime As String, ByVal pDropShipCustNum As String, ByVal pHeaderID As String, ByVal pConfigurationID As String,
            ByRef opRowPointer As String, ByRef opInfoBar As String) As Integer

        Dim response As InvokeResponseData
        Dim oDataReader As IDataReader = Nothing
        Dim cmd As SqlClient.SqlCommand
        Dim vConfigServerId As String
        Dim vConfigHdrNameSpace As String
        Dim vConfigurator As String
        Dim vConfiguratorURL As String
        Dim GetSystemParm1 As Integer
        Dim GetSystemParm2 As Integer
        Dim GetSystemParm3 As Integer
        Dim GetSystemParm4 As Integer
        Dim GetSystemParm5 As Integer
        Dim GetSystemParm6 As Integer
        Dim GetSystemParm7 As Integer
        Dim GetSystemParm8 As Integer
        Dim GetSystemParm9 As Integer
        Dim GetSystemParm10 As Integer
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
        Dim strParmValue1 As String
        Dim strParmValue2 As String
        Dim strParmValue3 As String
        Dim strParmValue4 As String
        Dim strParmValue5 As String
        'Dim strParmValue7 As String
        Dim strParmValue8 As String
        Dim strParmValue9 As String
        Dim strParmValue10 As String
        Dim sSourceType As String
        Dim sSourceKey As String
        Dim sSourceDetailId As String
        Dim sDestType As String
        Dim sDestKey As String
        Dim sTargetDetailId As String
        Dim sSourceHeaderId As String
        Dim sTargetHeaderId As String
        Dim sHeaderType As String
        'Dim sAutoJob As String

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

        strParmName1 = "configurator_server_id" ' inv_parms
        strParmName2 = "config_header_name_space" ' inv_parms
        strParmName3 = "configurator" ' inv_parms
        strParmName4 = "configurator_url" ' inv_parms
        strParmName5 = "site" ' parms
        strParmName6 = "config_id" ' coitem
        strParmName7 = "auto_job" ' item
        strParmName8 = "co_num" ' co_num
        strParmName9 = "config_metadata_instance_filename" ' metadata instance
        strParmName10 = "config_authentication_key" ' authentication key

        'Here we got the real co_num value related from the ExternalConfirmatioRef
        IDORuntime.LogUserMessage("Inbound BOD Debug Process", UserDefinedMessageType.UserDefined0, "pConfirmationRef {0}", pConfirmationRef)

        If IsNothing(pConfirmationRef) = False Then
            GetSystemParm8 = 0
            Try
                Using appDB As AppDB = Me.CreateAppDB()
                    ' create a new SqlCommand
                    cmd = New SqlClient.SqlCommand With {
                        .CommandType = CommandType.Text,
                        .CommandText = "SELECT " & strParmName8 & " FROM co WHERE co.external_confirmation_ref = " & "'" & pConfirmationRef & "'"
                    }

                    Try
                        ' execute the command through the framework
                        oDataReader = appDB.ExecuteReader(cmd)
                    Catch ex As Exception
                        GetSystemParm8 = 16
                        MGException.Throw(MGException.ExtractMessages(ex))
                    End Try

                    If oDataReader.Read Then
                        strParmValue8 = oDataReader.Item(strParmName8).ToString
                        vCoFromExternalNumber = strParmValue8
                        sCoFromExternalNumber = vCoFromExternalNumber

                        IDORuntime.LogUserMessage("Inbound BOD Debug Process", UserDefinedMessageType.UserDefined0, "vCoFromExternalNumber {0}", vCoFromExternalNumber)
                        IDORuntime.LogUserMessage("Inbound BOD Debug Process", UserDefinedMessageType.UserDefined0, "sCoFromExternalNumber {0}", sCoFromExternalNumber)

                        pCoNum = sCoFromExternalNumber

                    Else
                        GetSystemParm8 = 16
                        MGException.Throw(Me.CreateAppDB.GetMessageProvider.GetMessage("E=NoExist1", "@!Parameters", "@invparms", strParmName8))
                        '("PCM" & ":" & "No system parms have been defined, or " & strParmName & " is not a valid system parm.")
                    End If
                    oDataReader.Close()
                    'OR Exit Function
                End Using
            Catch ex As Exception
                GetSystemParm8 = 16
                IDORuntime.LogUserMessage("GetSystemParm8 exception", UserDefinedMessageType.UserDefined0, ex.Message)
            End Try
        End If

        IDORuntime.LogUserMessage("Inbound BOD Debug Process", UserDefinedMessageType.UserDefined0, "CoNum {0}", pCoNum)
        IDORuntime.LogUserMessage("Inbound BOD Debug Process", UserDefinedMessageType.UserDefined0, "CoLine {0}", pCoLine)
        IDORuntime.LogUserMessage("Inbound BOD Debug Process", UserDefinedMessageType.UserDefined0, "HeaderID {0}", pHeaderID)
        IDORuntime.LogUserMessage("Inbound BOD Debug Process", UserDefinedMessageType.UserDefined0, "ConfigurationID {0}", pConfigurationID)

        'Standard call to LoadProcessSalesOrderLineSp Method to create coitem lines
        Try
            response = Me.Context.Commands.Invoke("ESBSalesOrderLineViews", "LoadProcessSalesOrderLineSp", pCoNum, pCoLine, pConfirmationRef, pActionCode, pStat, pItem, pQtyOrderedConv, pISOUM, pFixedPriceItemIndicator, pUnitPriceConv,
                          pCurrCode, pExtPrice, pTotPretaxAmt, pDesc, pReservationRef, pWhse, pRequiredDeliveryDateTime, pDropShipCustNum, opRowPointer, opInfoBar)
            IDORuntime.LogUserMessage("Inbound BOD Debug Process", UserDefinedMessageType.UserDefined0, "After LoadProcessSalesOrderLineSp{0}", response)
            opRowPointer = response.Parameters(18).ToString
            opInfoBar = response.Parameters(19).ToString

            If Not response.IsReturnValueStdError() Then
                success_coitem = True
            Else
                Return 16
            End If

        Catch ex As Exception
            message_coitem = MGException.ExtractMessages(ex)
            IDORuntime.LogUserMessage("LoadProcessSalesOrderLineSp exception", UserDefinedMessageType.UserDefined0, ex.Message)
            opInfoBar = ex.Message
            Return 16
        End Try

        IDORuntime.LogUserMessage("Inbound BOD Debug Process", UserDefinedMessageType.UserDefined0, "After LoadProcessSalesOrderLineSp success_coitem value{0}", success_coitem)
        IDORuntime.LogUserMessage("Inbound BOD Debug Process", UserDefinedMessageType.UserDefined0, "After LoadProcessSalesOrderLineSp message_coitem value{0}", message_coitem)


        'OR invparms configuration parameters
        GetSystemParm1 = 0
        Try
            Using appDB As AppDB = Me.CreateAppDB()
                ' create a new SqlCommand
                cmd = New SqlClient.SqlCommand With {
                    .CommandType = CommandType.Text,
                    .CommandText = "SELECT " & strParmName1 & " FROM invparms"
                }
                Try
                    ' execute the command through the framework
                    oDataReader = appDB.ExecuteReader(cmd)
                Catch ex As Exception
                    GetSystemParm1 = 16
                    IDORuntime.LogUserMessage("GetSystemParm1 Part 1 exception", UserDefinedMessageType.UserDefined0, ex.Message)
                End Try

                If oDataReader.Read Then
                    strParmValue1 = oDataReader.Item(strParmName1).ToString
                    vConfigServerId = strParmValue1
                    sApplID = vConfigServerId
                Else
                    GetSystemParm1 = 16
                    MGException.Throw(Me.CreateAppDB.GetMessageProvider.GetMessage("E=NoExist1", "@!Parameters", "@invparms", strParmName1))
                    '("PCM" & ":" & "No system parms have been defined, or " & strParmName & " is not a valid system parm.")
                End If
                oDataReader.Close()
                'OR Exit Function
            End Using
        Catch ex As Exception
            GetSystemParm1 = 16
            IDORuntime.LogUserMessage("GetSystemParm1 Part 2 exception", UserDefinedMessageType.UserDefined0, ex.Message)
        End Try

        GetSystemParm2 = 0
        Try
            Using appDB As AppDB = Me.CreateAppDB()
                ' create a new SqlCommand
                cmd = New SqlClient.SqlCommand With {
                    .CommandType = CommandType.Text,
                    .CommandText = "SELECT " & strParmName2 & " FROM invparms"
                }
                Try
                    ' execute the command through the framework
                    oDataReader = appDB.ExecuteReader(cmd)
                Catch ex As Exception
                    GetSystemParm2 = 16
                    IDORuntime.LogUserMessage("GetSystemParm2 Part 1 exception", UserDefinedMessageType.UserDefined0, ex.Message)
                End Try

                If oDataReader.Read Then
                    strParmValue2 = oDataReader.Item(strParmName2).ToString
                    vConfigHdrNameSpace = strParmValue2
                    sConfigHdrNameSpace = vConfigHdrNameSpace
                Else
                    GetSystemParm2 = 16
                    MGException.Throw(Me.CreateAppDB.GetMessageProvider.GetMessage("E=NoExist1", "@!Parameters", "@invparms", strParmName2))
                    '("PCM" & ":" & "No system parms have been defined, or " & strParmName & " is not a valid system parm.")
                End If
                oDataReader.Close()
                'OR Exit Function
            End Using
        Catch ex As Exception
            GetSystemParm2 = 16
            IDORuntime.LogUserMessage("GetSystemParm2 Part 2 exception", UserDefinedMessageType.UserDefined0, ex.Message)

        End Try

        GetSystemParm3 = 0
        Try
            Using appDB As AppDB = Me.CreateAppDB()
                ' create a new SqlCommand
                cmd = New SqlClient.SqlCommand With {
                    .CommandType = CommandType.Text,
                    .CommandText = "SELECT " & strParmName3 & " FROM invparms"
                }
                Try
                    ' execute the command through the framework
                    oDataReader = appDB.ExecuteReader(cmd)
                Catch ex As Exception
                    GetSystemParm3 = 16
                    IDORuntime.LogUserMessage("GetSystemParm3 Part 1 exception", UserDefinedMessageType.UserDefined0, ex.Message)
                End Try

                If oDataReader.Read Then
                    strParmValue3 = oDataReader.Item(strParmName3).ToString
                    vConfigurator = strParmValue3
                    sConfigurator = vConfigurator
                Else
                    GetSystemParm3 = 16
                    MGException.Throw(Me.CreateAppDB.GetMessageProvider.GetMessage("E=NoExist1", "@!Parameters", "@invparms", strParmName3))
                    '("PCM" & ":" & "No system parms have been defined, or " & strParmName & " is not a valid system parm.")
                End If
                oDataReader.Close()
                'OR Exit Function
            End Using
        Catch ex As Exception
            GetSystemParm3 = 16
            IDORuntime.LogUserMessage("GetSystemParm3 Part 2 exception", UserDefinedMessageType.UserDefined0, ex.Message)

        End Try

        GetSystemParm4 = 0
        Try
            Using appDB As AppDB = Me.CreateAppDB()
                ' create a new SqlCommand
                cmd = New SqlClient.SqlCommand With {
                    .CommandType = CommandType.Text,
                    .CommandText = "SELECT " & strParmName4 & " FROM invparms"
                }
                Try
                    ' execute the command through the framework
                    oDataReader = appDB.ExecuteReader(cmd)
                Catch ex As Exception
                    GetSystemParm4 = 16
                    IDORuntime.LogUserMessage("GetSystemParm4 Part 1 exception", UserDefinedMessageType.UserDefined0, ex.Message)
                End Try

                If oDataReader.Read Then
                    strParmValue4 = oDataReader.Item(strParmName4).ToString
                    vConfiguratorURL = strParmValue4
                    sConfiguratorURL = vConfiguratorURL
                Else
                    GetSystemParm4 = 16
                    MGException.Throw(Me.CreateAppDB.GetMessageProvider.GetMessage("E=NoExist1", "@!Parameters", "@invparms", strParmName4))
                    '("PCM" & ":" & "No system parms have been defined, or " & strParmName & " is not a valid system parm.")
                End If
                oDataReader.Close()
                'OR Exit Function
            End Using
        Catch ex As Exception
            GetSystemParm4 = 16
            IDORuntime.LogUserMessage("GetSystemParm4 Part 2 exception", UserDefinedMessageType.UserDefined0, ex.Message)

        End Try

        GetSystemParm5 = 0
        Try
            Using appDB As AppDB = Me.CreateAppDB()
                ' create a new SqlCommand
                cmd = New SqlClient.SqlCommand With {
                    .CommandType = CommandType.Text,
                    .CommandText = "SELECT " & strParmName5 & " FROM parms"
                }
                Try
                    ' execute the command through the framework
                    oDataReader = appDB.ExecuteReader(cmd)
                Catch ex As Exception
                    GetSystemParm5 = 16
                    IDORuntime.LogUserMessage("GetSystemParm5 Part 1 exception", UserDefinedMessageType.UserDefined0, ex.Message)
                End Try

                If oDataReader.Read Then
                    strParmValue5 = oDataReader.Item(strParmName5).ToString
                    sSite = strParmValue5

                Else
                    GetSystemParm5 = 16
                    MGException.Throw(Me.CreateAppDB.GetMessageProvider.GetMessage("E=NoExist1", "@!Parameters", "@parms", strParmName5))
                End If
                oDataReader.Close()
                'OR Exit Function
            End Using
        Catch ex As Exception
            GetSystemParm5 = 16
            IDORuntime.LogUserMessage("GetSystemParm5 Part 2 exception", UserDefinedMessageType.UserDefined0, ex.Message)

        End Try

        GetSystemParm9 = 0
        Try
            Using appDB As AppDB = Me.CreateAppDB()
                ' create a new SqlCommand
                cmd = New SqlClient.SqlCommand With {
                    .CommandType = CommandType.Text,
                    .CommandText = "SELECT " & strParmName9 & " FROM invparms"
                }
                Try
                    ' execute the command through the framework
                    oDataReader = appDB.ExecuteReader(cmd)
                Catch ex As Exception
                    GetSystemParm9 = 16
                    IDORuntime.LogUserMessage("GetSystemParm9 Part 1 exception", UserDefinedMessageType.UserDefined0, ex.Message)
                End Try

                If oDataReader.Read Then
                    strParmValue9 = oDataReader.Item(strParmName9).ToString
                    sMetadataInstance = strParmValue9

                Else
                    GetSystemParm9 = 16
                    MGException.Throw(Me.CreateAppDB.GetMessageProvider.GetMessage("E=NoExist1", "@!Parameters", "@parms", strParmName9))
                End If
                oDataReader.Close()
                'OR Exit Function
            End Using
        Catch ex As Exception
            GetSystemParm9 = 16
            IDORuntime.LogUserMessage("GetSystemParm9 Part 2 exception", UserDefinedMessageType.UserDefined0, ex.Message)

        End Try

        GetSystemParm10 = 0
        Try
            Using appDB As AppDB = Me.CreateAppDB()
                ' create a new SqlCommand
                cmd = New SqlClient.SqlCommand With {
                    .CommandType = CommandType.Text,
                    .CommandText = "SELECT " & strParmName10 & " FROM invparms"
                }
                Try
                    ' execute the command through the framework
                    oDataReader = appDB.ExecuteReader(cmd)
                Catch ex As Exception
                    GetSystemParm10 = 16
                    IDORuntime.LogUserMessage("GetSystemParm10 Part 1 exception", UserDefinedMessageType.UserDefined0, ex.Message)
                End Try

                If oDataReader.Read Then
                    strParmValue10 = oDataReader.Item(strParmName10).ToString
                    sAuthenticationKey = strParmValue10

                Else
                    GetSystemParm10 = 16
                    MGException.Throw(Me.CreateAppDB.GetMessageProvider.GetMessage("E=NoExist1", "@!Parameters", "@parms", strParmName10))
                End If
                oDataReader.Close()
                'OR Exit Function
            End Using
        Catch ex As Exception
            GetSystemParm5 = 16
            IDORuntime.LogUserMessage("GetSystemParm5 Part 2 exception", UserDefinedMessageType.UserDefined0, ex.Message)

        End Try

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
            sDestType = "CO"
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
                    'hostServices.Copy(sSourceHeaderId, sSourceDetailId, sTargetHeaderId, sTargetDetailId, False, True)
                    ' Map data from BuyDesign Configuration to CFG Tables
                Catch ex As Exception
                    IDORuntime.LogUserMessage("PCM Debug process", UserDefinedMessageType.UserDefined0, "Error calling HostServices.Copy: {0}", ex.Message)
                    hostServices = Nothing
                    opInfoBar = ex.Message
                    Return 16
                End Try


                'BDC SL9MAP CONFIGURATION PROCESS
                GetSystemParm6 = 0
                Try
                    Using appDB As AppDB = Me.CreateAppDB()
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
                    End Using
                Catch ex As Exception
                    GetSystemParm6 = 16
                    IDORuntime.LogUserMessage("GetSystemParm6 exception", UserDefinedMessageType.UserDefined0, ex.Message)

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

                'IF COPY JOB IS REQUIRED 
                GetSystemParm7 = 0
                Try
                    Using appDB1 As AppDB = Me.CreateAppDB()
                        ' create a new SqlCommand
                        cmd = New SqlClient.SqlCommand With {
                            .CommandType = CommandType.Text,
                            .CommandText = "SELECT " & strParmName7 & " FROM item WHERE item.item = " & "'" & pItem & "'"
                        }
                        Try
                            ' execute the command through the framework
                            oDataReader = appDB1.ExecuteReader(cmd)

                        Catch ex As Exception
                            GetSystemParm7 = 16
                            IDORuntime.LogUserMessage("GetSystemParm7 Part 1 exception", UserDefinedMessageType.UserDefined0, ex.Message)

                        End Try
                        oDataReader.Close()
                        'Dim response_autojob As InvokeResponseData
                        'Set sDestType to COLINE
                        sDestType = "COLINE"


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
                    End Using
                Catch ex As Exception
                    GetSystemParm7 = 16
                    MGException.Throw(MGException.ExtractMessages(ex))
                End Try
                'IF COPY JOB IS REQUIRED 

            Catch Ex As Exception
                IDORuntime.LogUserMessage("PCM Debug process ", UserDefinedMessageType.UserDefined0, "Error calling Host Services: {0}", Ex.Message)

            End Try



        End If

        Return 0

    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_ESBSalesOrderLineSp(ByVal CoNum As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iCLM_ESBSalesOrderLineExt = New CLM_ESBSalesOrderLineFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result = iCLM_ESBSalesOrderLineExt.CLM_ESBSalesOrderLineSp(CoNum)
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
    Public Function LoadProcessSalesOrderLinePostSp(ByVal ExternalConfirmationRef As String, ByRef Infobar As String) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iLoadProcessSalesOrderLinePostExt = New LoadProcessSalesOrderLinePostFactory().Create(appDb)

            Dim Severity As Integer = iLoadProcessSalesOrderLinePostExt.LoadProcessSalesOrderLinePostSp(ExternalConfirmationRef, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function LoadProcessSalesOrderLineSp(ByVal pCoNum As String, ByVal pCoLine As Short?, ByVal pConfirmationRef As String, ByVal pActionCode As String, ByVal pStat As String, ByVal pItem As String, ByVal pQtyOrderedConv As Decimal?, ByVal pISOUM As String, ByVal pFixedPriceItemIndicator As String, ByVal pUnitPriceConv As Decimal?, ByVal pCurrCode As String, ByVal pExtPrice As Decimal?, ByVal pTotPretaxAmt As Decimal?, ByVal pDesc As String, ByVal pReservationRef As String, ByVal pWhse As String, ByVal pRequiredDeliveryDateTime As DateTime?,
<[Optional]> ByVal pDropShipCustNum As String, ByRef RowPointer As Guid?, ByRef Infobar As String) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iLoadProcessSalesOrderLineExt As ILoadProcessSalesOrderLine = New LoadProcessSalesOrderLineFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, RowPointer As Guid?, Infobar As String) = iLoadProcessSalesOrderLineExt.LoadProcessSalesOrderLineSp(pCoNum, pCoLine, pConfirmationRef, pActionCode, pStat, pItem, pQtyOrderedConv, pISOUM, pFixedPriceItemIndicator, pUnitPriceConv, pCurrCode, pExtPrice, pTotPretaxAmt, pDesc, pReservationRef, pWhse, pRequiredDeliveryDateTime, pDropShipCustNum, RowPointer, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            RowPointer = result.RowPointer
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function
End Class




