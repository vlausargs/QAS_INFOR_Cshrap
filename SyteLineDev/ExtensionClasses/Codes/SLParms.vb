Option Explicit On
Option Strict On

Imports System.Data.SqlClient
Imports CSI.MG
Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common
Imports System.Text
Imports Mongoose.MGCore
Imports System.Xml
Imports System.Security.Cryptography
Imports System.IO
Imports System.Net
Imports CSI.Codes
Imports CSI.Logistics.Vendor
Imports System.Runtime.InteropServices
Imports CSI.Logistics.Customer

<IDOExtensionClass("SLParms")>
Public Class SLParms
    Inherits CSIExtensionClassBase

    Private _fse As FileServerExtension = New FileServerExtension()

    Private ReadOnly kn As String = "1234567800000000"
    Private ReadOnly ivString As String = "tu89geji340t89u2"
    ' this one always gets multisite...
    Public Function GetSystemParms(ByRef MultiSite As Integer) As Integer

        GetSystemParms = 0

        MultiSite = 1

        Exit Function

    End Function

    <IDOMethod(MethodFlags.None)>
    Public Function GenerateSystemStatisticReport(ByVal Site As String, ByVal Path As String, ByVal TaskID As Integer) As Boolean
        Dim xml As String = String.Empty
        Dim fileName As String = "SystemDiagnostics" + "_" + Site + "_" + TaskID.ToString() + ".xml"
        Dim fileServerName As String = ""
        Dim folderTemplate As String = ""
        Dim accessDepth As String = ""
        Dim fileSpec As String = ""
        Dim fileContentBytes As Byte() = New Byte() {}
        Dim errMsg As String = ""
        Dim saved As Integer = 0
        Dim success As Boolean = False

        Try
            Dim response As InvokeResponseData = Me.Context.Commands.Invoke("SLParms", "ServerInfoSp", Site, xml)
            If response.IsReturnValueStdError Then
                Return False
            End If
            xml = response.Parameters(1).Value

            GetFileServerInfoByLogicalFolderName(Path, fileServerName, folderTemplate, accessDepth, errMsg)
            fileSpec = GetFileSpec(folderTemplate, fileName, "", accessDepth, True)
            fileContentBytes = Encoding.ASCII.GetBytes(xml)
            _fse.SaveFileContent(errMsg, saved, fileContentBytes, fileSpec, fileServerName, Path)
            If saved = 1 Then
                success = True
            End If

        Catch ex As Exception
            success = False
        End Try

        Return success
    End Function

    <IDOMethod(MethodFlags.None)>
    Public Function GetSystemParm(ByRef strParmValue As String,
                                        ByVal strParmName As String) As Integer
        Dim dr As IDataReader = Nothing
        Dim messageProvider As Mongoose.IDO.IMessageProvider = Nothing
        dr = Nothing
        GetSystemParm = 0
        Dim strParmNameWithQuote As String
        strParmNameWithQuote = strParmName.Replace("]", "]]")
        strParmNameWithQuote = "[" + strParmNameWithQuote + "]"

        ' create an AppDB instance for our application database
        Using appDB As ApplicationDB = IDORuntime.Context.CreateApplicationDB()

            ' create a new SqlCommand
            Using cmd As IDbCommand = appDB.CreateCommand()
                ' create the dynamic query
                cmd.CommandText = String.Format("SELECT {0} FROM parms, coparms, currparms, invparms, poparms, sfcparms", strParmNameWithQuote)
                cmd.CommandType = CommandType.Text

                Try
                    ' execute the command through the framework
                    dr = appDB.ExecuteReader(cmd)

                Catch ex As Exception
                    GetSystemParm = 16
                    If dr IsNot Nothing AndAlso Not dr.IsClosed Then
                        dr.Close()
                    End If
                    MGException.Throw(Me.GetMessageProvider.GetMessage("E=NoExist1", "@!Parameters", "@!Parameters", strParmName))
                    Exit Function
                End Try
                messageProvider = Me.GetMessageProvider()

                If dr.Read() Then
                    ' return the parameter using the framework's internal format
                    ' NOTE:  starting with 6.0.0.2 version of framework you can 
                    '        convert to internal format using this equivalent API:
                    '
                    '        parmValue = MGType.ToInternal(dr.GetValue(0))

                    strParmValue = TextUtil.FormatNormalizedString(dr.GetValue(0))
                Else
                    GetSystemParm = 16
                    If Not dr Is Nothing AndAlso Not dr.IsClosed Then
                        dr.Close()
                    End If
                    MGException.Throw(Me.GetMessageProvider.GetMessage("E=NoExist1", "@!Parameters", "@!Parameters", strParmName))
                    Exit Function
                End If
                If Not dr Is Nothing AndAlso Not dr.IsClosed Then
                    dr.Close()
                End If
            End Using
        End Using
        Return 0

    End Function

    ' Get Capitalize parm in the form of "U" if capitalize is true
    <IDOMethod(MethodFlags.None)>
    Public Function GetCapitalizeParm(ByRef strParmValue As String) As Integer

        Dim dr As IDataReader = Nothing
        Dim messageProvider As Mongoose.IDO.IMessageProvider = Nothing
        dr = Nothing
        GetCapitalizeParm = 0

        ' create an AppDB instance for our application database
        Using appDB As ApplicationDB = IDORuntime.Context.CreateApplicationDB()

            ' create a new SqlCommand
            Using cmd As IDbCommand = appDB.CreateCommand()
                ' create the dynamic query
                cmd.CommandText = String.Format("SELECT capitalize FROM parms")
                cmd.CommandType = CommandType.Text

                Try
                    ' execute the command through the framework
                    dr = appDB.ExecuteReader(cmd)

                Catch ex As Exception
                    If dr IsNot Nothing AndAlso Not dr.IsClosed Then
                        dr.Close()
                    End If
                    GetCapitalizeParm = 16
                    MGException.Throw(Me.GetMessageProvider.GetMessage("E=NoExist1", "@!Parameters", "@parms", strParmValue))
                    Exit Function
                End Try
                messageProvider = Me.GetMessageProvider()
                If dr.Read() Then
                    ' return the parameter using the framework's internal format
                    ' NOTE:  starting with 6.0.0.2 version of framework you can 
                    '        convert to internal format using this equivalent API:
                    '
                    '        parmValue = MGType.ToInternal(dr.GetValue(0))

                    strParmValue = TextUtil.FormatNormalizedString(dr.GetValue(0))
                    If strParmValue = "1" Then
                        strParmValue = "U"
                    Else
                        strParmValue = ""
                    End If
                Else
                    GetCapitalizeParm = 16
                    If Not dr Is Nothing AndAlso Not dr.IsClosed Then
                        dr.Close()
                    End If
                    MGException.Throw(Me.GetMessageProvider.GetMessage("E=NoExist1", "@!Parameters", "@parms", strParmValue))
                    Exit Function
                End If
                If Not dr Is Nothing AndAlso Not dr.IsClosed Then
                    dr.Close()
                End If
            End Using
        End Using

        Return 0

    End Function

    ' This is "the" startup method for the Parms data...a moving target...
    <IDOMethod(MethodFlags.None)>
    Public Function GetStartupParms(ByRef vCapitalize As String,
                            ByRef vMultiWhse As String,
                            ByRef vDoLength As String,
                            ByRef vSerialLength As String,
                            ByRef vLotLength As String,
                            ByRef vCurrCode As String,
                            ByRef vAddr1 As String,
                            ByRef vAddr2 As String,
                            ByRef vAddr3 As String,
                            ByRef vAddr4 As String,
                            ByRef vCity As String,
                            ByRef vState As String,
                            ByRef vZip As String,
                            ByRef vCountry As String,
                            ByRef vPhone As String,
                            ByRef vCompany As String,
                            ByRef vDefWhse As String,
                            ByRef vSite As String,
                            ByRef vEcReporting As String,
                            ByRef vQtyUnitFormat As String,
                            ByRef vQtyPerFormat As String,
                            ByRef vQtyCumuFormat As String,
                            ByRef vQtyTotlFormat As String,
                            ByRef vLotGenExp As String,
                            ByRef vRetentionDays As String,
                            ByRef vUniqueLot As String,
                            ByRef vSiteGroup As String,
                            ByRef vDisplayReportHeaders As String) As Integer

        Dim ResultSet As IDataReader = Nothing
        Dim iResult As Integer

        GetStartupParms = 0

        iResult = GetCapitalizeParm(vCapitalize)

        If (iResult <> 0) Then
            GetStartupParms = iResult
            Exit Function
        End If

        Try
            Using appDB As ApplicationDB = IDORuntime.Context.CreateApplicationDB()

                Using cmd As IDbCommand = appDB.CreateCommand()

                    cmd.CommandText =
                       "SELECT prm.addr##1, prm.addr##2, prm.addr##3, prm.addr##4, prm.zip, prm.country, prm.phone, prm.company, prm.site, prm.ec_reporting, prm.site_group, prm.display_report_headers, " &
                               "inv.serial_length, inv.lot_length, inv.def_whse, inv.qty_unit_format, inv.qty_per_format, inv.qty_cumu_format, inv.qty_totl_format, inv.lot_gen_exp, inv.retention_days, inv.unique_lot, " &
                               "co.do_length , cur.curr_code" &
                       " FROM parms prm, invparms inv, coparms co, currparms cur"

                    cmd.CommandType = CommandType.Text
                    Try
                        ResultSet = appDB.ExecuteReader(cmd)
                    Catch ex As Exception
                        If ResultSet IsNot Nothing AndAlso Not ResultSet.IsClosed Then
                            ResultSet.Close()
                        End If
                        Throw New MGException(ex.Message)
                    End Try

                    If ResultSet.Read() Then
                        vMultiWhse = "1"
                        vDoLength = ResultSet.Item("do_length").ToString()
                        vSerialLength = ResultSet.Item("serial_length").ToString()
                        vLotLength = ResultSet.Item("lot_length").ToString()
                        vCurrCode = ResultSet.Item("curr_code").ToString()
                        vAddr1 = ResultSet.Item("addr##1").ToString()
                        vAddr2 = ResultSet.Item("addr##2").ToString()
                        vAddr3 = ResultSet.Item("addr##3").ToString()
                        vAddr4 = ResultSet.Item("addr##4").ToString()
                        vZip = ResultSet.Item("zip").ToString()
                        vCountry = ResultSet.Item("country").ToString()
                        vPhone = ResultSet.Item("phone").ToString()
                        vCompany = ResultSet.Item("company").ToString()
                        vDefWhse = ResultSet.Item("def_whse").ToString()
                        vSite = ResultSet.Item("site").ToString()
                        vEcReporting = ResultSet.Item("ec_reporting").ToString()
                        vSiteGroup = ResultSet.Item("site_group").ToString()
                        vQtyUnitFormat = ResultSet.Item("qty_unit_format").ToString()
                        vQtyPerFormat = ResultSet.Item("qty_per_format").ToString()
                        vQtyCumuFormat = ResultSet.Item("qty_cumu_format").ToString()
                        vQtyTotlFormat = ResultSet.Item("qty_totl_format").ToString()
                        vLotGenExp = ResultSet.Item("lot_gen_exp").ToString()
                        vRetentionDays = ResultSet.Item("retention_days").ToString()
                        vUniqueLot = ResultSet.Item("unique_lot").ToString()
                        vDisplayReportHeaders = ResultSet.Item("display_report_headers").ToString()
                    Else
                        If Not ResultSet Is Nothing AndAlso Not ResultSet.IsClosed Then
                            ResultSet.Close()
                        End If
                        MGException.Throw(Me.GetMessageProvider.GetMessage("E=NoExist0", "@!Parameters"))
                    End If
                    If Not ResultSet Is Nothing AndAlso Not ResultSet.IsClosed Then
                        ResultSet.Close()
                    End If
                End Using
            End Using

        Catch ex As Exception
            GetStartupParms = 16
            MGException.Throw(MGException.ExtractMessages(ex))
        End Try
    End Function
    ' Return 1 when is_enabled  is 1 AND a Modules row exists for the Module
    Public Function GetAvailValue(ByRef vstrModuleName As String,
                                 ByRef vUserName As String) As String
        Dim objLicenses As InvokeResponseData
        Dim oLoadResponseData As LoadCollectionResponseData
        Dim sIsEnabled As String = "0"
        Dim optionalModuleLicensed As InvokeResponseData
        Dim vIsModuleLicensedFlag As String = "0"

        Try
            objLicenses = Me.Context.Commands.Invoke("AccountAuthorizations", "IsUserLicensedForModule", vUserName, vstrModuleName)
            optionalModuleLicensed = Me.Context.Commands.Invoke("SLOptionalModules", "IsModuleLicensed", vstrModuleName, vIsModuleLicensedFlag)
            vIsModuleLicensedFlag = optionalModuleLicensed.Parameters(1).GetValue(Of String)()
            oLoadResponseData = Me.Context.Commands.LoadCollection(
                "SLOptionalModules",
                "IsEnabled",
                String.Format("ModuleName = {0}", SqlLiteral.Format(vstrModuleName)),
                String.Empty, -1)
            If vstrModuleName = "Automotive_Mfg" Or vstrModuleName = "MoldingPack" Or vstrModuleName = "PrintingPack" Then
                objLicenses.ReturnValue = "1"
            End If
            If oLoadResponseData.Items.Count > 0 Then
                sIsEnabled = oLoadResponseData(0, "IsEnabled").Value
            End If
            Return CStr(CInt(objLicenses.ReturnValue) * CInt(sIsEnabled) * CInt(vIsModuleLicensedFlag))

        Catch ex As Exception
            Throw New MGException(ex.Message)
        End Try
    End Function

    Public Function GetMergeredModuleAvailValue(ByRef vstrModuleName As String,
                             ByRef vUserName As String, ByRef vstrMergeredModuleName As String) As String
        Dim objLicenses As InvokeResponseData
        Dim oLoadResponseData As LoadCollectionResponseData
        Dim sIsEnabled As String = "0"

        Try
            objLicenses = Me.Context.Commands.Invoke("AccountAuthorizations", "IsUserLicensedForModule", vUserName, vstrModuleName)
            oLoadResponseData = Me.Context.Commands.LoadCollection(
                "SLOptionalModules",
                "IsEnabled",
                String.Format("ModuleName = {0}", SqlLiteral.Format(vstrMergeredModuleName)),
                String.Empty, -1)
            If oLoadResponseData.Items.Count > 0 Then
                sIsEnabled = oLoadResponseData(0, "IsEnabled").Value
            End If
            Return CStr(CInt(objLicenses.ReturnValue) * CInt(sIsEnabled))

        Catch ex As Exception
            Throw New MGException(ex.Message)
        End Try
    End Function
    ' This is the startup method that returns whether Add-On modules are licensed
    <IDOMethod(MethodFlags.None)>
    Public Function GetStartupAvailParms(ByRef vUserName As String,
                       ByRef vAvail_CCI As String,
                       ByRef vAvail_CN As String,
                       ByRef vAvail_JP As String,
                       ByRef AvailCfg As Integer,
                       ByRef AvailDc As Integer,
                       ByRef AltNo As Integer,
                       ByRef vAvail_PP As String,
                       ByRef vAvail_TH As String,
                       ByRef vAvail_FSP As String,
                       ByRef vAvail_MX As String,
                       ByRef vAvail_Tax As String,
                       ByRef vAvail_Wb As String,
                       ByRef AvailDocAuto As Integer,
                       ByRef vAvail_MO As String,
                       ByRef vAvail_AU As String,
                       ByRef vAvail_DE As String,
                       ByRef vAvail_QCS As String,
                       ByRef vAvail_SE As String,
                       ByRef vAvail_PL As String,
                       ByRef vAvail_LM As String,
                       ByRef vAvail_TMS As String,
                       ByRef vAvail_FR As String,
                       ByRef vAvail_ERS As String) As Integer


        Dim oDataReader As IDataReader = Nothing

        GetStartupAvailParms = 0
        vAvail_CCI = "0"
        vAvail_CN = "0"
        vAvail_JP = "0"
        vAvail_PP = "0"
        vAvail_TH = "0"
        vAvail_FSP = "0"
        vAvail_MX = "0"
        vAvail_Tax = "0"
        vAvail_Wb = "0"
        vAvail_MO = "0"
        vAvail_AU = "0"
        vAvail_DE = "0"
        vAvail_QCS = "0"
        vAvail_SE = "0"
        vAvail_PL = "0"
        vAvail_LM = "0"
        vAvail_FR = "0"
        vAvail_TMS = "0"
        vAvail_ERS = "0"


        Try

            'Credit Card Interface
            vAvail_CCI = GetAvailValue("CreditCardInterface", vUserName)

            'Chinese Country Pack
            vAvail_CN = GetAvailValue("ChinaCountryPack", vUserName)

            'Japanese Country Pack
            vAvail_JP = GetAvailValue("JapanCountryPack", vUserName)

            'Printing Pack
            vAvail_PP = GetAvailValue("PrintingPack", vUserName)

            'Thailand Pack
            vAvail_TH = GetAvailValue("ThailandCountryPack", vUserName)

            vAvail_FSP = CStr(CInt(GetMergeredModuleAvailValue("ServiceManagement", vUserName, "ServiceManagement")) _
            Or CInt(GetMergeredModuleAvailValue("AssetManagement", vUserName, "ServiceManagement")) _
            Or CInt(GetMergeredModuleAvailValue("ServiceManagement_MS", vUserName, "ServiceManagement")) _
            Or CInt(GetMergeredModuleAvailValue("AssetManagement_MS", vUserName, "ServiceManagement")) _
            Or CInt(GetMergeredModuleAvailValue("ServiceManagementLite", vUserName, "ServiceManagement")))

            'Maxico Pack
            vAvail_MX = GetAvailValue("MexicanCountryPack", vUserName)

            'SyteLine Tax
            vAvail_Tax = GetAvailValue("TaxInterface", vUserName)

            'SyteLine Workbench Suite
            vAvail_Wb = GetAvailValue("WorkBench", vUserName)

            'Molding Pack
            vAvail_MO = GetAvailValue("MoldingPack", vUserName)

            'Auto Industry Pack
            vAvail_AU = GetAvailValue("Automotive_Mfg", vUserName)

            'Germany Country Pack
            vAvail_DE = GetAvailValue("GermanyCountryPack", vUserName)

            'QCS
            vAvail_QCS = GetAvailValue("QualityControlSolution", vUserName)

            'Sweden Country Pack
            vAvail_SE = GetAvailValue("SwedenCountryPack", vUserName)

            'Poland Country Pack
            vAvail_PL = GetAvailValue("PolandCountryPack", vUserName)

            'DRI Lean Manufacturing 3rd Party
            vAvail_LM = GetAvailValue("LeanManufacturing", vUserName)

            'France Country Pack
            vAvail_FR = GetAvailValue("FranceCountryPack", vUserName)

            'Transportation Management
            vAvail_TMS = GetAvailValue("TransportationManagement", vUserName)

            'QuadKor Rental Industry Pack
            vAvail_ERS = GetAvailValue("EquipmentRentalService", vUserName)

            AvailDc = 1

            AvailCfg = 0
            AltNo = 0

            Using appDB As ApplicationDB = IDORuntime.Context.CreateApplicationDB()
                ' create a new SqlCommand
                Using cmd As IDbCommand = appDB.CreateCommand()
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT configurator,doc_configurator_server_id, doc_configurator_name_space FROM invparms WITH (READUNCOMMITTED)"
                    Try
                        ' execute the command through the framework
                        oDataReader = appDB.ExecuteReader(cmd)
                    Catch ex As Exception
                        If oDataReader IsNot Nothing AndAlso Not oDataReader.IsClosed Then
                            oDataReader.Close()
                        End If
                        MGException.Throw(MGException.ExtractMessages(ex))
                    End Try

                    If oDataReader.Read Then
                        AvailCfg = CInt(IIf(oDataReader.Item("configurator").ToString = "N", 0, 1))
                        AvailDocAuto = CInt(IIf(oDataReader.Item("doc_configurator_server_id").ToString = "" Or
                                                oDataReader.Item("doc_configurator_name_space").ToString = "", 0, 1))
                    Else
                        If Not oDataReader Is Nothing AndAlso Not oDataReader.IsClosed Then
                            oDataReader.Close()
                        End If
                        MGException.Throw(Me.GetMessageProvider.GetMessage("E=NoExist1", "@!Parameters", "@invparms", "configurator"))
                    End If
                    If Not oDataReader Is Nothing AndAlso Not oDataReader.IsClosed Then
                        oDataReader.Close()
                    End If
                End Using
            End Using
            Exit Function

            'Other possible upcoming add-ons
            'Workbenches
            'FSPlus
            'RFQ
            'Tax Interface
            'Thai Country Pack
            'Printing and Packageing Industry Pack

        Catch ex As Exception
            GetStartupAvailParms = 16
            MGException.Throw(MGException.ExtractMessages(ex))
        End Try
    End Function

    <IDOMethod(MethodFlags.None)>
    Public Function ImportWizardSetting(ByVal logicalFolderName As String, ByVal fileName As String, ByVal currentSite As String, ByRef Infobar As String) As Integer
        Dim xWizardFileDoc As XmlDocument
        Dim strFileName As String
        Dim strSiteId As String = String.Empty
        Dim fileContent As String = String.Empty
        Dim S3FilePrefix As String = String.Empty
        Dim errMsg As String = String.Empty
        xWizardFileDoc = New XmlDocument()

        If fileName <> String.Empty Then
            Try
                strFileName = fileName
                fileContent = LoadFileContent(fileName, logicalFolderName, errMsg)
                If (Not String.IsNullOrEmpty(errMsg)) Then
                    Infobar = errMsg
                    Return 16
                Else
                    If (Not String.IsNullOrEmpty(fileContent)) Then
                        xWizardFileDoc.LoadXml(fileContent)
                    End If
                End If
            Catch ex As Exception
                Infobar = ex.Message
                Return 16
            End Try
        End If

        Dim xDataArea As XmlNode
        Dim xData As XmlNode
        Dim xTableName As XmlNode
        Dim SQLScripts As String = String.Empty
        Dim TableSQLScripts As String = String.Empty
        Dim Response As InvokeResponseData
        Try
            For Each xDataArea In xWizardFileDoc.ChildNodes
                For Each xData In xDataArea.ChildNodes
                    If xData.Name = "SiteID" Then
                        If xData.InnerText <> currentSite Then
                            Response = Me.Context.Commands.Invoke("ApplicationMessages", "MsgAppSp",
                                Infobar, "mE=SiteNotMatch", "", "", "",
                                "", "", "", "", "", "", "", "", "", "", "", "")
                            Infobar = Response.Parameters(0).GetValue(Of String)()
                            Return 16
                        End If
                        strSiteId = xData.Value
                    ElseIf xData.Name = "Tables" Then
                        For Each xTableName In xData.ChildNodes
                            If Not xTableName.FirstChild Is Nothing Then
                                Response = Me.Context.Commands.Invoke("SLParms", "UpdateWizardSettingDataSP", xTableName.Name, xTableName.OuterXml, String.Empty)
                                If Not Response.Parameters(2).IsNull Then
                                    Infobar = Response.Parameters(2).Value
                                    Return 16
                                End If
                            End If
                        Next
                    End If
                Next
            Next
        Catch ex As Exception
            Infobar = ex.Message
            Return 16
        End Try

        Response = Me.Context.Commands.Invoke("ApplicationMessages", "MsgAppSp",
                                Infobar, "I=CmdSucceeded", "@Import", "", "",
                                "", "", "", "", "", "", "", "", "", "", "", "")
        Infobar = Response.Parameters(0).GetValue(Of String)()
        Return 0
    End Function


    Public Function LoadFileContent(ByVal FileName As String, ByVal LogicalFolderName As String, ByRef ErrMsg As String) As String
        LoadFileContent = ""

        Dim fileServerName As String = ""
        Dim folderTemplate As String = ""
        Dim accessDepth As String = ""
        Dim fileSpec As String = ""

        Dim fileContent As String = ""
        Dim parsedFileSpec As String = ""

        Try
            GetFileServerInfoByLogicalFolderName(LogicalFolderName, fileServerName, folderTemplate, accessDepth, ErrMsg)
            fileSpec = GetFileSpec(folderTemplate, FileName, "", accessDepth, True)
            _fse.GetFileContentAsBase64String(fileSpec, fileServerName, LogicalFolderName, fileContent, parsedFileSpec, ErrMsg)

            LoadFileContent = Base64StringToString(fileContent)
        Catch ex As Exception
            If (Not String.IsNullOrEmpty(ErrMsg)) Then
                ErrMsg = ex.InnerException.ToString()
            End If
            LoadFileContent = ""
        End Try
    End Function

    Function ByteArrayToString(ByVal byteArray As Byte()) As String
        Return Encoding.ASCII.GetString(byteArray)
    End Function

    Function StringToByteArray(ByVal stringText As String) As Byte()
        Return Encoding.ASCII.GetBytes(stringText)
    End Function

    Function TextToStringCollection(ByVal text As String) As Collection
        Dim stringCollection As Collection = New Collection()
        Dim textInLines As String() = text.Split(New String() {vbNewLine}, StringSplitOptions.RemoveEmptyEntries)
        For Each sLine As String In textInLines
            stringCollection.Add(sLine)
        Next
        Return stringCollection
    End Function

    Sub GetFileServerInfoByLogicalFolderName(ByVal logicalFolderName As String,
                                             ByRef fileServerName As String,
                                             ByRef folderTemplate As String,
                                             ByRef accessDepth As String,
                                             ByRef errMsg As String)
        Using appdb As ApplicationDB = IDORuntime.Context.CreateApplicationDB()
            Using sql As IDbCommand = appdb.CreateCommand()
                Dim execResult As AppDBExecResult = Nothing
                Try
                    sql.CommandType = CommandType.StoredProcedure
                    sql.CommandText = "GetFileServerInfoByLogicalFolderNameSp"
                    appdb.AddCommandParameterWithValue(sql, "LogicalFolderName", logicalFolderName, ParameterDirection.Input).Size = 100
                    appdb.AddCommandParameterWithValue(sql, "ServerName", fileServerName, ParameterDirection.InputOutput).Size = 100
                    appdb.AddCommandParameterWithValue(sql, "FolderTemplate", folderTemplate, ParameterDirection.InputOutput).Size = 100
                    appdb.AddCommandParameterWithValue(sql, "FolderAccessDepth", accessDepth, ParameterDirection.InputOutput).Size = 100
                    appdb.ExecuteNonQuery(sql)

                    fileServerName = CType(sql.Parameters(1), IDbDataParameter).Value.ToString()
                    folderTemplate = CType(sql.Parameters(2), IDbDataParameter).Value.ToString()
                    accessDepth = CType(sql.Parameters(3), IDbDataParameter).Value.ToString()

                Catch ex As Exception

                End Try
            End Using
        End Using
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

    Public Function Base64StringToString(ByVal Base64Str As String) As String
        Dim retStr As String = ""
        Dim bytes As Byte()
        Dim charBuffer As Char()

        If Base64Str <> "" Then
            charBuffer = Base64Str.ToCharArray()
            bytes = Convert.FromBase64CharArray(charBuffer, 0, charBuffer.Length)
            retStr = Encoding.Default.GetString(bytes)
        End If

        Return retStr

    End Function


    <IDOMethod(MethodFlags.None)>
    Public Function SiteMgmtProcessAction(ByRef Site As String,
                            ByRef SiteName As String,
                            ByRef SiteDescription As String,
                            ByRef SiteType As String,
                            ByRef SiteTimeZone As String,
                            ByRef SiteGroup As String,
                            ByRef NotificationEmailAddress As String,
                            ByRef SiteManagementAction As String,
                            ByRef IsCloud As String) As Integer

        Dim success As String = "0"
        Dim cloudSuccess As Boolean = False
        Dim errorMessage As String = String.Empty
        Dim Infobar As String = String.Empty
        Dim SiteMgmtProcessActionReturnValue As Integer
        Dim InvokeResponse As InvokeResponseData
        Dim SiteAddingActionValidationFailed As Boolean = True
        Dim Username As String = String.Empty
        Dim QueueSite As String = String.Empty

        Try
            InvokeResponse = Me.Context.Commands.Invoke("SLParms", "SiteMgmtValidateSp",
                        Site, NotificationEmailAddress, SiteManagementAction, Infobar, Username, QueueSite)
            SiteAddingActionValidationFailed = InvokeResponse.IsReturnValueStdError()
            If SiteAddingActionValidationFailed = True Then
                errorMessage = InvokeResponse.Parameters(3).Value
                SiteMgmtNotify(Site, 0, errorMessage, Username, NotificationEmailAddress, QueueSite)
                'validation failed, return directly. Don't need clear records action.
                Return 16
            End If
            Using AppDB As ApplicationDB = IDORuntime.Context.CreateApplicationDB()
                Using sql As IDbCommand = AppDB.CreateCommand()
                    Dim execResult As AppDBExecResult = Nothing
                    sql.CommandType = CommandType.StoredProcedure
                    sql.CommandText = "SiteMgmtProcessActionSp"
                    AppDB.AddCommandParameterWithValue(sql, "PSite", Site, ParameterDirection.Input).Size = 100
                    AppDB.AddCommandParameterWithValue(sql, "PSiteName", SiteName, ParameterDirection.Input).Size = 100
                    AppDB.AddCommandParameterWithValue(sql, "PSiteDescription", SiteDescription, ParameterDirection.Input).Size = 100
                    AppDB.AddCommandParameterWithValue(sql, "PSiteType", SiteType, ParameterDirection.Input).Size = 100
                    AppDB.AddCommandParameterWithValue(sql, "PSiteTimeZone", SiteTimeZone, ParameterDirection.Input).Size = 100
                    AppDB.AddCommandParameterWithValue(sql, "PSiteGroup", SiteGroup, ParameterDirection.Input).Size = 100
                    AppDB.AddCommandParameterWithValue(sql, "Infobar", Infobar, ParameterDirection.InputOutput).Size = 2800
                    AppDB.AddCommandParameterWithValue(sql, "Severity", SiteMgmtProcessActionReturnValue, ParameterDirection.ReturnValue)
                    AppDB.ExecuteNonQuery(sql)

                    Infobar = CType(sql.Parameters(6), IDbDataParameter).Value.ToString()
                    If SiteMgmtProcessActionReturnValue <> 0 Then
                        success = "0"
                        errorMessage = "Response: " + Infobar
                    Else
                        success = "1"
                    End If
                End Using
            End Using

        Catch ex As Exception
            success = "0"
            errorMessage = ex.Message
        End Try

        'if on-prem, the add site response will be triggered here instead of TMS
        'if on-cloud and fail to add site on SiteMgmtProcessActionSp, clear records here too.
        If IsCloud = "0" Or (IsCloud = "1" And success = "0") Then
            SiteMgmtAddSiteResponseAndNotify(Site, success, errorMessage)
        End If
        'only when add site succeed locally, post request to TMS for site adding.
        If IsCloud = "1" And success = "1" Then
            Dim sDNSHostName As String = String.Empty
            Dim sDNSZoneName As String = String.Empty
            Dim sTMSKey As String = String.Empty
            Dim sTMSSecret As String = String.Empty
            Dim sAddSiteReSTURL As String = String.Empty
            Dim normalizedUrl As String = String.Empty
            Dim normalizedRequestParameters As String = String.Empty
            Dim sJsonBody As String = String.Empty

            cloudSuccess = False
            Try
                sDNSHostName = Environment.GetEnvironmentVariable("cfDNSHostName")
                sDNSZoneName = Environment.GetEnvironmentVariable("cfDNSZoneName")
                sTMSKey = Decrypt(Environment.GetEnvironmentVariable("cfTMSOAuthKey"))
                sTMSSecret = Decrypt(Environment.GetEnvironmentVariable("cfTMSOAuthSecret"))
                If sDNSZoneName.ToLower().Contains("inforgov") Then
                    sAddSiteReSTURL = "https://" + sDNSHostName + "-" + sDNSZoneName + "/TM/api/provision/site/add"
                Else
                    sAddSiteReSTURL = "https://" + sDNSHostName + "." + sDNSZoneName + "/TM/api/provision/site/add"
                End If
                sJsonBody = BuildRequest(GetTenantID(Site), Site, NotificationEmailAddress)
            Catch ex As Exception
                success = "0"
                errorMessage = ex.Message
            End Try
            'decrypt might fail. So, need to check request post parameters' preparation status.
            If success = "1" Then
                cloudSuccess = PostRestAPI(sAddSiteReSTURL, sJsonBody, sTMSKey, sTMSSecret, errorMessage)
            End If
            'if request post failed, clear records directly.
            If cloudSuccess = False Then
                errorMessage = errorMessage & " " & sJsonBody
                SiteMgmtAddSiteResponseAndNotify(Site, "0", errorMessage)
            End If
        End If
    End Function

    Private Sub SiteMgmtAddSiteResponseAndNotify(ByVal Site As String, ByVal Success As String, ByVal ErrorMessage As String)
        Dim SiteManagementStatus As String
        Dim AddingResponse As InvokeResponseData
        SiteManagementStatus = "F"
        If Success = "1" Then
            SiteManagementStatus = "S"
        End If
        Try
            AddingResponse = Me.Context.Commands.Invoke("SLParms", "SiteMgmtAddSiteResponseSp", Site, SiteManagementStatus, ErrorMessage, 0)
        Catch ex As Exception
            'this is for SQL server timeout exception
            If (ex.Message.ToLower().Contains("timeout")) Then
                AddingResponse = Me.Context.Commands.Invoke("SLParms", "SiteMgmtAddSiteResponseSp", Site, SiteManagementStatus, ErrorMessage, 0)
            Else
                Throw ex
            End If
        End Try
    End Sub

    Private Function PostRestAPI(ByVal sURL As String, ByVal sBody As String, ByVal sKey As String, ByVal sSecret As String, ByRef sResponse As String) As Boolean
        Dim sSignatureMethod As String = "HMAC-SHA256"
        Dim sTimestamp As String = "1497559807"
        Dim sNonce As String = "xB5tsb"
        Dim sVersion As String = "1.0"
        Dim sHeaderFormat As String = "OAuth oauth_consumer_key=""{0}"",oauth_signature_method=""{1}"",oauth_timestamp=""{2}"",oauth_nonce=""{3}"",oauth_version=""{4}"",oauth_signature=""{5}"""
        Dim oauth As OAuthBase = New OAuthBase()
        Dim normalizedUrl As String = String.Empty
        Dim normalizedRequestParameters As String = String.Empty
        Dim sSignature As String = oauth.GenerateSignature(New Uri(sURL), sKey, sSecret, Nothing, Nothing, "POST", sTimestamp, sNonce, OAuthBase.SignatureTypes.HMACSHA256, normalizedUrl, normalizedRequestParameters)
        Dim authHeader As String = String.Format(sHeaderFormat, Uri.EscapeDataString(sKey), Uri.EscapeDataString(sSignatureMethod), Uri.EscapeDataString(sTimestamp), Uri.EscapeDataString(sNonce), Uri.EscapeDataString(sVersion), Uri.EscapeDataString(sSignature))
        'Dim request As HttpWebRequest = CType(WebRequest.Create(sURL), HttpWebRequest)
        Dim request As HttpWebRequest = DirectCast(WebRequest.Create(sURL), HttpWebRequest)
        Try
            request.Headers.Add("Authorization", authHeader)
            request.Method = "POST"
            request.ContentType = "application/json"
            request.ContentLength = sBody.Length
            Using webStream As Stream = request.GetRequestStream()
                Using requestWriter As StreamWriter = New StreamWriter(webStream, System.Text.Encoding.ASCII)
                    requestWriter.Write(sBody)
                End Using
            End Using

            Dim webResponse As WebResponse = request.GetResponse()
            Using webStream As Stream = webResponse.GetResponseStream()
                If webStream IsNot Nothing Then
                    Using responseReader As StreamReader = New StreamReader(webStream)
                        sResponse = responseReader.ReadToEnd()
                        Return True
                    End Using
                Else
                    sResponse = "PostRestAPI() ERROR; no response from web api url:" & sURL
                    Return False
                End If
            End Using
        Catch ex As Exception
            'sResponse = "PostRestAPI() EXCEPTION: " & ex.Message & " " & sURL & " " & sBody & " " & sKey & " " & sSecret & " " & sHeaderFormat & " " & sSignature & " " & authHeader
            sResponse = "PostRestAPI() EXCEPTION: " & ex.Message
            If ex.InnerException IsNot Nothing Then
                sResponse = sResponse & Environment.NewLine + ex.InnerException.Message
            End If
            Return False
        End Try
    End Function

    Private Sub SiteMgmtNotify(ByVal Site As String,
                               ByVal Success As Integer,
                               ByVal ErrorMessage As String,
                               ByVal Username As String,
                               ByVal NotificationEmailAddress As String,
                               ByVal QueueSite As String
                               )
        Dim Response As InvokeResponseData
        Response = Me.Context.Commands.Invoke("SLParms", "SiteMgmtNotifySp",
                Site, Success, ErrorMessage, Username, NotificationEmailAddress, QueueSite)
    End Sub

    Private Function Decrypt(ByVal cipherText As String) As String
        If String.IsNullOrEmpty(cipherText) Then
            Return ""
        End If
        Dim enc As System.Text.UTF8Encoding

        Dim salt(31) As Byte
        Dim keysize As Integer = 32
        Dim cypherTextBytes As Byte() = Convert.FromBase64String(cipherText)
        Dim ivStringBytes As Byte() = Encoding.ASCII.GetBytes(ivString)

        Using derivedByte As New Rfc2898DeriveBytes(kn, salt)
            Dim keyBytes() As Byte = derivedByte.GetBytes(keysize)
            Using symmetricKey As AesCryptoServiceProvider = New AesCryptoServiceProvider()
                symmetricKey.Mode = CipherMode.CBC
                enc = New System.Text.UTF8Encoding
                Using decryptor As ICryptoTransform = symmetricKey.CreateDecryptor(keyBytes, ivStringBytes)
                    Using memoryStream As MemoryStream = New MemoryStream(cypherTextBytes)
                        Using cryptoStream As CryptoStream = New CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read)
                            Dim plainTextBytes(cypherTextBytes.Length) As Byte
                            Dim decryptedByteCount As Integer = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length)
                            Decrypt = enc.GetString(plainTextBytes, 0, decryptedByteCount)
                        End Using
                    End Using
                End Using
            End Using
        End Using

    End Function

    Private Function BuildRequest(ByRef tenantid As String, ByRef siteid As String, ByRef NotificationEmailAddress As String) As String
        BuildRequest = "{""tenantid"": """ + tenantid + """, ""siteid"": """ + siteid + """, ""NotificationEmailAddress"": """ + NotificationEmailAddress + """}"
    End Function

    Private Function GetTenantID(ByVal sSite As String) As String
        Dim oLoadResponseData As LoadCollectionResponseData
        Try
            oLoadResponseData = Me.Context.Commands.LoadCollection(
                "SLSites",
                "TenantID",
                String.Format("Site <> {0} AND ISNULL(TenantID, N'') <> N'' ", SqlLiteral.Format(sSite)),
                String.Empty, 1)
            If oLoadResponseData.Items.Count > 0 Then
                GetTenantID = oLoadResponseData(0, "TenantID").Value
            Else
                GetTenantID = String.Empty
            End If
        Catch ex As Exception
            Throw New MGException(ex.Message)
        End Try
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetAgingBasisSp(ByRef ArparmInvDue As String, ByRef ApparmInvDue As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSI.MG.CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iGetAgingBasisExt As IGetAgingBasis = New GetAgingBasisFactory().Create(appDb)

            Dim Severity As Integer = iGetAgingBasisExt.GetAgingBasisSp(ArparmInvDue, ApparmInvDue)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetAPAgeDaysSP(ByRef AgeDays1 As Short?, ByRef AgeDesc1 As String, ByRef AgeDays2 As Short?, ByRef AgeDesc2 As String, ByRef AgeDays3 As Short?, ByRef AgeDesc3 As String, ByRef AgeDays4 As Short?, ByRef AgeDesc4 As String, ByRef AgeDays5 As Short?, ByRef AgeDesc5 As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSI.MG.CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iGetAPAgeDaysExt As IGetAPAgeDays = New GetAPAgeDaysFactory().Create(appDb)

            Dim Severity As Integer = iGetAPAgeDaysExt.GetAPAgeDaysSP(AgeDays1, AgeDesc1, AgeDays2, AgeDesc2, AgeDays3, AgeDesc3, AgeDays4, AgeDesc4, AgeDays5, AgeDesc5)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetARAgeDaysSP(ByRef AgeDays1 As Short?, ByRef AgeDesc1 As String, ByRef AgeDays2 As Short?, ByRef AgeDesc2 As String, ByRef AgeDays3 As Short?, ByRef AgeDesc3 As String, ByRef AgeDays4 As Short?, ByRef AgeDesc4 As String, ByRef AgeDays5 As Short?, ByRef AgeDesc5 As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSI.MG.CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iGetARAgeDaysExt As IGetARAgeDays = New GetARAgeDaysFactory().Create(appDb)

            Dim Severity As Integer = iGetARAgeDaysExt.GetARAgeDaysSP(AgeDays1, AgeDesc1, AgeDays2, AgeDesc2, AgeDays3, AgeDesc3, AgeDays4, AgeDesc4, AgeDays5, AgeDesc5)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetCompanyInfoSP(ByRef ReturnCompanyName As String, ByRef MailingAddress As String, ByRef City As String, ByRef State As String, ByRef Zip As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSI.MG.CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iGetCompanyInfoExt As IGetCompanyInfo = New GetCompanyInfoFactory().Create(appDb)

            Dim Severity As Integer = iGetCompanyInfoExt.GetCompanyInfoSP(ReturnCompanyName, MailingAddress, City, State, Zip)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetEmailAddressByUserIdSp(ByVal UserId As Decimal?, ByRef EmailAddress As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim iGetEmailAddressByUserIdExt As IGetEmailAddressByUserId = New GetEmailAddressByUserIdFactory().Create(Me, True)
            Dim result As (ReturnCode As Integer?, EmailAddress As String) = iGetEmailAddressByUserIdExt.GetEmailAddressByUserIdSp(UserId, EmailAddress)
            Dim Severity As Integer = result.ReturnCode.Value
            EmailAddress = result.EmailAddress

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetParmAnalyticalLedgerSp(ByRef AnalyticalLedger As Byte?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSI.MG.CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iGetParmAnalyticalLedgerExt As IGetParmAnalyticalLedger = New GetParmAnalyticalLedgerFactory().Create(appDb)

            Dim Severity As Integer = iGetParmAnalyticalLedgerExt.GetParmAnalyticalLedgerSp(AnalyticalLedger)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetParmCancellationSp(ByRef EnableCancellation As Integer?) As Integer
        Dim iGetParmCancellationExt As IGetParmCancellation = New GetParmCancellationFactory().Create(Me, True)

        Dim result As (ReturnCode As Integer?, EnableCancellation As Integer?) = iGetParmCancellationExt.GetParmCancellationSp(EnableCancellation)
        EnableCancellation = result.EnableCancellation

        Dim Severity As Integer = result.ReturnCode.Value

        Return Severity
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetSiteCompanyInfoSp(ByVal Site As String, ByRef ReturnCompanyName As String, ByRef MailingAddress As String, ByRef City As String, ByRef State As String, ByRef Zip As String, ByRef Country As String, ByRef CountryCode As String, ByRef EmailAddr As String, ByRef Phone As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSI.MG.CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iGetSiteCompanyInfoExt As IGetSiteCompanyInfo = New GetSiteCompanyInfoFactory().Create(appDb)

            Dim Severity As Integer = iGetSiteCompanyInfoExt.GetSiteCompanyInfoSp(Site, ReturnCompanyName, MailingAddress, City, State, Zip, Country, CountryCode, EmailAddr, Phone)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PostJourChangeQuestionSp(ByVal PostJour As Byte?, ByRef PromptMsg As String, ByRef Buttons As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSI.MG.CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iPostJourChangeQuestionExt As IPostJourChangeQuestion = New PostJourChangeQuestionFactory().Create(appDb)

            Dim Severity As Integer = iPostJourChangeQuestionExt.PostJourChangeQuestionSp(PostJour, PromptMsg, Buttons)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ValidateFiscalYearSp(ByVal FiscalYear As Short?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSI.MG.CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iValidateFiscalYearExt As IValidateFiscalYear = New ValidateFiscalYearFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iValidateFiscalYearExt.ValidateFiscalYearSp(FiscalYear, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ValidateTaxRegNum1Sp(ByVal FormType As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSI.MG.CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iValidateTaxRegNum1Ext As IValidateTaxRegNum1 = New ValidateTaxRegNum1Factory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iValidateTaxRegNum1Ext.ValidateTaxRegNum1Sp(FormType, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function VerifyStkLocAcctsSp(ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSI.MG.CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iVerifyStkLocAcctsExt As IVerifyStkLocAccts = New VerifyStkLocAcctsFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iVerifyStkLocAcctsExt.VerifyStkLocAcctsSp(Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CountTasksAndMessagesSp(ByRef NumberOfUserTasks As Integer?, ByRef NumberOfEventMessages As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSI.MG.CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCountTasksAndMessagesExt As ICountTasksAndMessages = New CountTasksAndMessagesFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, NumberOfUserTasks As Integer?, NumberOfEventMessages As Integer?) = iCountTasksAndMessagesExt.CountTasksAndMessagesSp(NumberOfUserTasks, NumberOfEventMessages)
            Dim Severity As Integer = result.ReturnCode.Value
            NumberOfUserTasks = result.NumberOfUserTasks
            NumberOfEventMessages = result.NumberOfEventMessages
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetDataTypeLengthSp(ByVal DataType As String, ByRef DataTypeLength As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSI.MG.CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iGetDataTypeLengthExt As IGetDataTypeLength = New GetDataTypeLengthFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, DataTypeLength As Integer?, Infobar As String) = iGetDataTypeLengthExt.GetDataTypeLengthSp(DataType, DataTypeLength, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            DataTypeLength = result.DataTypeLength
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetPrBankCodeSp(ByRef BankCode As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSI.MG.CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iGetPrBankCodeExt As IGetPrBankCode = New GetPrBankCodeFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, BankCode As String, Infobar As String) = iGetPrBankCodeExt.GetPrBankCodeSp(BankCode, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            BankCode = result.BankCode
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetSLStartupParms(ByVal UserName As String, ByRef CurWhse As String, ByRef CurUserCode As String, ByRef UserID As Decimal?, ByVal AcctType As String, ByRef Acct As String, ByRef UnitCode1 As String, ByRef UnitCode2 As String, ByRef UnitCode3 As String, ByRef UnitCode4 As String, ByRef Tax1_Enabled As Byte?, ByRef Tax1_DefTaxCode As String, ByRef Tax1_TaxCodeLabel As String, ByRef Tax1_TaxIdLabel As String, ByRef Tax1_PromptOnLine As Byte?, ByRef Tax1_TaxMode As String, ByRef TaxPromptForSystem1 As Byte?, ByRef TaxTwoExchRates As Byte?, ByRef TaxNmbrOfSystems As Byte?, ByRef Tax1_TaxAmtLabel As String, ByRef Tax1_TaxItemLabel As String, ByRef Tax1_ActiveForPurch As Byte?, ByRef Tax1_TaxIdPromptLoc As String, ByRef Tax1_DefItemTaxCode As String, ByRef Tax1_DefMiscTaxCode As String, ByRef Tax1_DefFrtTaxCode As String, ByRef Tax1_TaxCodeDescLabel As String, ByRef Tax1_TaxItemDescLabel As String, ByRef Tax1_FrtCodeLabel As String, ByRef Tax1_FrtCodeDescLabel As String, ByRef Tax1_MiscCodeLabel As String, ByRef Tax1_MiscCodeDescLabel As String, ByRef Tax1_TaxAmtAccumLabel As String, ByRef Tax2_Enabled As Byte?, ByRef Tax2_DefTaxCode As String, ByRef Tax2_TaxCodeLabel As String, ByRef Tax2_TaxIdLabel As String, ByRef Tax2_PromptOnLine As Byte?, ByRef Tax2_TaxMode As String, ByRef TaxPromptForSystem2 As Byte?, ByRef Tax2_TaxAmtLabel As String, ByRef Tax2_TaxItemLabel As String, ByRef Tax2_ActiveForPurch As Byte?, ByRef Tax2_TaxIdPromptLoc As String, ByRef Tax2_DefItemTaxCode As String, ByRef Tax2_DefMiscTaxCode As String, ByRef Tax2_DefFrtTaxCode As String, ByRef Tax2_TaxCodeDescLabel As String, ByRef Tax2_TaxItemDescLabel As String, ByRef Tax2_FrtCodeLabel As String, ByRef Tax2_FrtCodeDescLabel As String, ByRef Tax2_MiscCodeLabel As String, ByRef Tax2_MiscCodeDescLabel As String, ByRef Tax2_TaxAmtAccumLabel As String, ByVal ArAcctType As String, ByRef ArAcct As String, ByRef ArUnitCode1 As String, ByRef ArUnitCode2 As String, ByRef ArUnitCode3 As String, ByRef ArUnitCode4 As String, ByRef Capitalize As Byte?, ByRef MultiWhse As Byte?, ByRef DoLength As Byte?, ByRef SerialLength As Byte?, ByRef LotLength As Byte?, ByRef CurrCode As String, ByRef Addr1 As String, ByRef Addr2 As String, ByRef Addr3 As String, ByRef Addr4 As String, ByRef City As String, ByRef State As String, ByRef Zip As String, ByRef Country As String, ByRef Phone As String, ByRef Company As String, ByRef DefWhse As String, ByRef Site As String, ByRef EcReporting As Byte?, ByRef QtyUnitFormat As String, ByRef QtyPerFormat As String, ByRef QtyCumuFormat As String, ByRef QtyTotlFormat As String, ByRef LotGenExp As Byte?, ByRef RetentionDays As Short?, ByRef UniqueLot As Byte?, ByRef SiteGroup As String, ByRef Infobar As String,
<[Optional]> ByRef AmtFormat As String,
<[Optional]> ByRef AmtTotFormat As String,
<[Optional]> ByRef CstPrcFormat As String,
<[Optional]> ByRef LotDataType As String,
<[Optional]> ByRef SerNumDataType As String, ByRef InvNumLength As Byte?, ByRef AcctDataType As String, ByRef IntranetName As String, ByRef MasterSite As String, ByRef HideParentGridColumns As Byte?, ByRef BackflushLot As Byte?, ByRef BackflushSerial As Byte?, ByRef UniqueSerial As Byte?, ByRef EcnEst As String, ByRef EcnJob As String, ByRef EcnStd As String, ByRef NegFlag As Byte?,
<[Optional]> ByRef SecureCtrlAcct As Byte?,
<[Optional]> ByRef DefaultStartingToEnding As Byte?, ByRef MsgBusLogicalId As String, ByRef LanguageID As String, ByRef UseAlternateAddressReportFormat As Byte?, ByRef DocAutoAppId As String, ByRef DocAutoNameSpace As String, ByRef DocAutoRuleSet As String, ByRef ImplementCelergo As Byte?, ByRef AutoDisplayButtonBlock As Byte?, ByRef EcnItem As String, ByRef EcnItemManufacturer As String, ByRef CurPlant As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSI.MG.CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iGetStartupParmsExt As IGetStartupParms = New GetStartupParmsFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, CurWhse As String, CurUserCode As String, UserID As Decimal?, Acct As String, UnitCode1 As String, UnitCode2 As String, UnitCode3 As String, UnitCode4 As String, Tax1_Enabled As Byte?, Tax1_DefTaxCode As String, Tax1_TaxCodeLabel As String, Tax1_TaxIdLabel As String, Tax1_PromptOnLine As Byte?, Tax1_TaxMode As String, TaxPromptForSystem1 As Byte?, TaxTwoExchRates As Byte?, TaxNmbrOfSystems As Byte?, Tax1_TaxAmtLabel As String, Tax1_TaxItemLabel As String, Tax1_ActiveForPurch As Byte?, Tax1_TaxIdPromptLoc As String, Tax1_DefItemTaxCode As String, Tax1_DefMiscTaxCode As String, Tax1_DefFrtTaxCode As String, Tax1_TaxCodeDescLabel As String, Tax1_TaxItemDescLabel As String, Tax1_FrtCodeLabel As String, Tax1_FrtCodeDescLabel As String, Tax1_MiscCodeLabel As String, Tax1_MiscCodeDescLabel As String, Tax1_TaxAmtAccumLabel As String, Tax2_Enabled As Byte?, Tax2_DefTaxCode As String, Tax2_TaxCodeLabel As String, Tax2_TaxIdLabel As String, Tax2_PromptOnLine As Byte?, Tax2_TaxMode As String, TaxPromptForSystem2 As Byte?, Tax2_TaxAmtLabel As String, Tax2_TaxItemLabel As String, Tax2_ActiveForPurch As Byte?, Tax2_TaxIdPromptLoc As String, Tax2_DefItemTaxCode As String, Tax2_DefMiscTaxCode As String, Tax2_DefFrtTaxCode As String, Tax2_TaxCodeDescLabel As String, Tax2_TaxItemDescLabel As String, Tax2_FrtCodeLabel As String, Tax2_FrtCodeDescLabel As String, Tax2_MiscCodeLabel As String, Tax2_MiscCodeDescLabel As String, Tax2_TaxAmtAccumLabel As String, ArAcct As String, ArUnitCode1 As String, ArUnitCode2 As String, ArUnitCode3 As String, ArUnitCode4 As String, Capitalize As Byte?, MultiWhse As Byte?, DoLength As Byte?, SerialLength As Byte?, LotLength As Byte?, CurrCode As String, Addr1 As String, Addr2 As String, Addr3 As String, Addr4 As String, City As String, State As String, Zip As String, Country As String, Phone As String, Company As String, DefWhse As String, Site As String, EcReporting As Byte?, QtyUnitFormat As String, QtyPerFormat As String, QtyCumuFormat As String, QtyTotlFormat As String, LotGenExp As Byte?, RetentionDays As Short?, UniqueLot As Byte?, SiteGroup As String, Infobar As String, AmtFormat As String, AmtTotFormat As String, CstPrcFormat As String, LotDataType As String, SerNumDataType As String, InvNumLength As Byte?, AcctDataType As String, IntranetName As String, MasterSite As String, HideParentGridColumns As Byte?, BackflushLot As Byte?, BackflushSerial As Byte?, UniqueSerial As Byte?, EcnEst As String, EcnJob As String, EcnStd As String, NegFlag As Byte?, SecureCtrlAcct As Byte?, DefaultStartingToEnding As Byte?, MsgBusLogicalId As String, LanguageID As String, UseAlternateAddressReportFormat As Byte?, DocAutoAppId As String, DocAutoNameSpace As String, DocAutoRuleSet As String, ImplementCelergo As Byte?, AutoDisplayButtonBlock As Byte?, EcnItem As String, EcnItemManufacturer As String, CurPlant As String) = iGetStartupParmsExt.GetStartupParmsSp(UserName, CurWhse, CurUserCode, UserID, AcctType, Acct, UnitCode1, UnitCode2, UnitCode3, UnitCode4, Tax1_Enabled, Tax1_DefTaxCode, Tax1_TaxCodeLabel, Tax1_TaxIdLabel, Tax1_PromptOnLine, Tax1_TaxMode, TaxPromptForSystem1, TaxTwoExchRates, TaxNmbrOfSystems, Tax1_TaxAmtLabel, Tax1_TaxItemLabel, Tax1_ActiveForPurch, Tax1_TaxIdPromptLoc, Tax1_DefItemTaxCode, Tax1_DefMiscTaxCode, Tax1_DefFrtTaxCode, Tax1_TaxCodeDescLabel, Tax1_TaxItemDescLabel, Tax1_FrtCodeLabel, Tax1_FrtCodeDescLabel, Tax1_MiscCodeLabel, Tax1_MiscCodeDescLabel, Tax1_TaxAmtAccumLabel, Tax2_Enabled, Tax2_DefTaxCode, Tax2_TaxCodeLabel, Tax2_TaxIdLabel, Tax2_PromptOnLine, Tax2_TaxMode, TaxPromptForSystem2, Tax2_TaxAmtLabel, Tax2_TaxItemLabel, Tax2_ActiveForPurch, Tax2_TaxIdPromptLoc, Tax2_DefItemTaxCode, Tax2_DefMiscTaxCode, Tax2_DefFrtTaxCode, Tax2_TaxCodeDescLabel, Tax2_TaxItemDescLabel, Tax2_FrtCodeLabel, Tax2_FrtCodeDescLabel, Tax2_MiscCodeLabel, Tax2_MiscCodeDescLabel, Tax2_TaxAmtAccumLabel, ArAcctType, ArAcct, ArUnitCode1, ArUnitCode2, ArUnitCode3, ArUnitCode4, Capitalize, MultiWhse, DoLength, SerialLength, LotLength, CurrCode, Addr1, Addr2, Addr3, Addr4, City, State, Zip, Country, Phone, Company, DefWhse, Site, EcReporting, QtyUnitFormat, QtyPerFormat, QtyCumuFormat, QtyTotlFormat, LotGenExp, RetentionDays, UniqueLot, SiteGroup, Infobar, AmtFormat, AmtTotFormat, CstPrcFormat, LotDataType, SerNumDataType, InvNumLength, AcctDataType, IntranetName, MasterSite, HideParentGridColumns, BackflushLot, BackflushSerial, UniqueSerial, EcnEst, EcnJob, EcnStd, NegFlag, SecureCtrlAcct, DefaultStartingToEnding, MsgBusLogicalId, LanguageID, UseAlternateAddressReportFormat, DocAutoAppId, DocAutoNameSpace, DocAutoRuleSet, ImplementCelergo, AutoDisplayButtonBlock, EcnItem, EcnItemManufacturer, CurPlant)
            Dim Severity As Integer = result.ReturnCode.Value
            CurWhse = result.CurWhse
            CurUserCode = result.CurUserCode
            UserID = result.UserID
            Acct = result.Acct
            UnitCode1 = result.UnitCode1
            UnitCode2 = result.UnitCode2
            UnitCode3 = result.UnitCode3
            UnitCode4 = result.UnitCode4
            Tax1_Enabled = result.Tax1_Enabled
            Tax1_DefTaxCode = result.Tax1_DefTaxCode
            Tax1_TaxCodeLabel = result.Tax1_TaxCodeLabel
            Tax1_TaxIdLabel = result.Tax1_TaxIdLabel
            Tax1_PromptOnLine = result.Tax1_PromptOnLine
            Tax1_TaxMode = result.Tax1_TaxMode
            TaxPromptForSystem1 = result.TaxPromptForSystem1
            TaxTwoExchRates = result.TaxTwoExchRates
            TaxNmbrOfSystems = result.TaxNmbrOfSystems
            Tax1_TaxAmtLabel = result.Tax1_TaxAmtLabel
            Tax1_TaxItemLabel = result.Tax1_TaxItemLabel
            Tax1_ActiveForPurch = result.Tax1_ActiveForPurch
            Tax1_TaxIdPromptLoc = result.Tax1_TaxIdPromptLoc
            Tax1_DefItemTaxCode = result.Tax1_DefItemTaxCode
            Tax1_DefMiscTaxCode = result.Tax1_DefMiscTaxCode
            Tax1_DefFrtTaxCode = result.Tax1_DefFrtTaxCode
            Tax1_TaxCodeDescLabel = result.Tax1_TaxCodeDescLabel
            Tax1_TaxItemDescLabel = result.Tax1_TaxItemDescLabel
            Tax1_FrtCodeLabel = result.Tax1_FrtCodeLabel
            Tax1_FrtCodeDescLabel = result.Tax1_FrtCodeDescLabel
            Tax1_MiscCodeLabel = result.Tax1_MiscCodeLabel
            Tax1_MiscCodeDescLabel = result.Tax1_MiscCodeDescLabel
            Tax1_TaxAmtAccumLabel = result.Tax1_TaxAmtAccumLabel
            Tax2_Enabled = result.Tax2_Enabled
            Tax2_DefTaxCode = result.Tax2_DefTaxCode
            Tax2_TaxCodeLabel = result.Tax2_TaxCodeLabel
            Tax2_TaxIdLabel = result.Tax2_TaxIdLabel
            Tax2_PromptOnLine = result.Tax2_PromptOnLine
            Tax2_TaxMode = result.Tax2_TaxMode
            TaxPromptForSystem2 = result.TaxPromptForSystem2
            Tax2_TaxAmtLabel = result.Tax2_TaxAmtLabel
            Tax2_TaxItemLabel = result.Tax2_TaxItemLabel
            Tax2_ActiveForPurch = result.Tax2_ActiveForPurch
            Tax2_TaxIdPromptLoc = result.Tax2_TaxIdPromptLoc
            Tax2_DefItemTaxCode = result.Tax2_DefItemTaxCode
            Tax2_DefMiscTaxCode = result.Tax2_DefMiscTaxCode
            Tax2_DefFrtTaxCode = result.Tax2_DefFrtTaxCode
            Tax2_TaxCodeDescLabel = result.Tax2_TaxCodeDescLabel
            Tax2_TaxItemDescLabel = result.Tax2_TaxItemDescLabel
            Tax2_FrtCodeLabel = result.Tax2_FrtCodeLabel
            Tax2_FrtCodeDescLabel = result.Tax2_FrtCodeDescLabel
            Tax2_MiscCodeLabel = result.Tax2_MiscCodeLabel
            Tax2_MiscCodeDescLabel = result.Tax2_MiscCodeDescLabel
            Tax2_TaxAmtAccumLabel = result.Tax2_TaxAmtAccumLabel
            ArAcct = result.ArAcct
            ArUnitCode1 = result.ArUnitCode1
            ArUnitCode2 = result.ArUnitCode2
            ArUnitCode3 = result.ArUnitCode3
            ArUnitCode4 = result.ArUnitCode4
            Capitalize = result.Capitalize
            MultiWhse = result.MultiWhse
            DoLength = result.DoLength
            SerialLength = result.SerialLength
            LotLength = result.LotLength
            CurrCode = result.CurrCode
            Addr1 = result.Addr1
            Addr2 = result.Addr2
            Addr3 = result.Addr3
            Addr4 = result.Addr4
            City = result.City
            State = result.State
            Zip = result.Zip
            Country = result.Country
            Phone = result.Phone
            Company = result.Company
            DefWhse = result.DefWhse
            Site = result.Site
            EcReporting = result.EcReporting
            QtyUnitFormat = result.QtyUnitFormat
            QtyPerFormat = result.QtyPerFormat
            QtyCumuFormat = result.QtyCumuFormat
            QtyTotlFormat = result.QtyTotlFormat
            LotGenExp = result.LotGenExp
            RetentionDays = result.RetentionDays
            UniqueLot = result.UniqueLot
            SiteGroup = result.SiteGroup
            Infobar = result.Infobar
            AmtFormat = result.AmtFormat
            AmtTotFormat = result.AmtTotFormat
            CstPrcFormat = result.CstPrcFormat
            LotDataType = result.LotDataType
            SerNumDataType = result.SerNumDataType
            InvNumLength = result.InvNumLength
            AcctDataType = result.AcctDataType
            IntranetName = result.IntranetName
            MasterSite = result.MasterSite
            HideParentGridColumns = result.HideParentGridColumns
            BackflushLot = result.BackflushLot
            BackflushSerial = result.BackflushSerial
            UniqueSerial = result.UniqueSerial
            EcnEst = result.EcnEst
            EcnJob = result.EcnJob
            EcnStd = result.EcnStd
            NegFlag = result.NegFlag
            SecureCtrlAcct = result.SecureCtrlAcct
            DefaultStartingToEnding = result.DefaultStartingToEnding
            MsgBusLogicalId = result.MsgBusLogicalId
            LanguageID = result.LanguageID
            UseAlternateAddressReportFormat = result.UseAlternateAddressReportFormat
            DocAutoAppId = result.DocAutoAppId
            DocAutoNameSpace = result.DocAutoNameSpace
            DocAutoRuleSet = result.DocAutoRuleSet
            ImplementCelergo = result.ImplementCelergo
            AutoDisplayButtonBlock = result.AutoDisplayButtonBlock
            EcnItem = result.EcnItem
            EcnItemManufacturer = result.EcnItemManufacturer
            CurPlant = result.CurPlant
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function JourlockSp(ByVal Id As String, ByVal LockUserid As Decimal?, ByVal LockJournal As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSI.MG.CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iJourlockExt As IJourlock = New JourlockFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iJourlockExt.JourlockSp(Id, LockUserid, LockJournal, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function LasttranISp(ByVal LasttranKey As Integer?, ByVal Action As String, ByRef LasttranLastTran As Decimal?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSI.MG.CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iLasttranIExt As ILasttranI = New LasttranIFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, LasttranLastTran As Decimal?, Infobar As String) = iLasttranIExt.LasttranISp(LasttranKey, Action, LasttranLastTran, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            LasttranLastTran = result.LasttranLastTran
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function LasttranSp(ByVal Key As Integer?, ByVal LockUserid As Decimal?, ByVal TransLocked As Integer?, ByRef Success As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSI.MG.CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iLasttranExt As ILasttran = New LasttranFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Success As Integer?, Infobar As String) = iLasttranExt.LasttranSp(Key, LockUserid, TransLocked, Success, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Success = result.Success
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function SendCommentEmail(ByVal Comment As String, ByVal UserName As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSI.MG.CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iSendCommentEmailExt As ISendCommentEmail = New SendCommentEmailFactory().Create(appDb)
            Dim result As Integer? = iSendCommentEmailExt.SendCommentEmailSp(Comment, UserName)
            Return result.Value
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ServerInfoSp(
        <[Optional]> ByVal pSite As String, ByRef SystemStatistics As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSI.MG.CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iServerInfoExt As IServerInfo = New ServerInfoFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, SystemStatistics As String) = iServerInfoExt.ServerInfoSp(pSite, SystemStatistics)
            Dim Severity As Integer = result.ReturnCode.Value
            SystemStatistics = result.SystemStatistics
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function SiteAddValidateSp(ByVal PSite As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSI.MG.CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iSiteAddValidateExt As ISiteAddValidate = New SiteAddValidateFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iSiteAddValidateExt.SiteAddValidateSp(PSite, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function SiteMgmtAddSiteCleanupSp(ByVal PSite As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSI.MG.CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iSiteMgmtAddSiteCleanupExt As ISiteMgmtAddSiteCleanup = New SiteMgmtAddSiteCleanupFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iSiteMgmtAddSiteCleanupExt.SiteMgmtAddSiteCleanupSp(PSite, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function SiteMgmtAddSiteResponseSp(ByVal PSite As String, ByVal PStatus As String, ByRef Infobar As String,
    <[Optional], DefaultParameterValue(CByte(0))> ByVal CalledFromTMS As Byte?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSI.MG.CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iSiteMgmtAddSiteResponseExt As ISiteMgmtAddSiteResponse = New SiteMgmtAddSiteResponseFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iSiteMgmtAddSiteResponseExt.SiteMgmtAddSiteResponseSp(PSite, PStatus, Infobar, CalledFromTMS)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function SiteMgmtNotifySp(ByVal PSite As String, ByVal PSuccess As Byte?, ByVal PErrorMsg As String, ByVal PUsername As String, ByVal PNotificationEmailAddress As String, ByVal PQueueSite As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSI.MG.CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iSiteMgmtNotifyExt As ISiteMgmtNotify = New SiteMgmtNotifyFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iSiteMgmtNotifyExt.SiteMgmtNotifySp(PSite, PSuccess, PErrorMsg, PUsername, PNotificationEmailAddress, PQueueSite)
            Dim Severity As Integer = result.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function SiteMgmtProcessActionSp(ByVal PSite As String, ByVal PSiteName As String, ByVal PSiteDescription As String, ByVal PSiteType As String, ByVal PSiteTimeZone As String, ByVal PSiteGroup As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSI.MG.CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iSiteMgmtProcessActionExt As ISiteMgmtProcessAction = New SiteMgmtProcessActionFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iSiteMgmtProcessActionExt.SiteMgmtProcessActionSp(PSite, PSiteName, PSiteDescription, PSiteType, PSiteTimeZone, PSiteGroup, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function SiteMgmtValidateSp(ByVal PSite As String, ByVal PNotificationEmailAddress As String, ByVal SiteManagementAction As String, ByRef Infobar As String, ByRef PUsername As String, ByRef PQueueSite As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSI.MG.CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iSiteMgmtValidateExt As ISiteMgmtValidate = New SiteMgmtValidateFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String, PUsername As String, PQueueSite As String) = iSiteMgmtValidateExt.SiteMgmtValidateSp(PSite, PNotificationEmailAddress, SiteManagementAction, Infobar, PUsername, PQueueSite)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            PUsername = result.PUsername
            PQueueSite = result.PQueueSite
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function UpdateWizardSettingDataSP(ByVal TableName As String, ByVal RowData As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSI.MG.CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iUpdateWizardSettingDataExt As IUpdateWizardSettingData = New UpdateWizardSettingDataFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iUpdateWizardSettingDataExt.UpdateWizardSettingDataSP(TableName, RowData, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function UpdObalSp(ByVal CustNum As String, ByVal Adjust As Decimal?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim iUpdObalExt As IUpdObal = New UpdObalFactory().Create(Me, True)
            Dim result As Integer? = iUpdObalExt.UpdObalSp(CustNum, Adjust)
            Dim Severity As Integer = result.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetFileServerPropertySP(ByVal ServerName As String, ByRef ServerType As String, ByRef DomainName As String, ByRef Active As Integer?, ByRef SharedPath As String, ByRef UserName As String, ByRef UserPassword As String, ByRef Infobar As String) As Integer
        Dim iGetFileServerPropertyExt As IGetFileServerProperty = New GetFileServerPropertyFactory().Create(Me, True)
        Dim result As (ReturnCode As Integer?, ServerType As String, DomainName As String, Active As Integer?, SharedPath As String, UserName As String, UserPassword As String, Infobar As String) = iGetFileServerPropertyExt.GetFileServerPropertySP(ServerName, ServerType, DomainName, Active, SharedPath, UserName, UserPassword, Infobar)
        Dim Severity As Integer = result.ReturnCode.Value
        ServerType = result.ServerType
        DomainName = result.DomainName
        Active = result.Active
        SharedPath = result.SharedPath
        UserName = result.UserName
        UserPassword = result.UserPassword
        Infobar = result.Infobar
        Return Severity
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetFiscalYearSp(ByRef pFiscalYear As Integer?) As Integer
        Dim iGetFiscalYearExt As IGetFiscalYear = New GetFiscalYearFactory().Create(Me, True)
        Dim result As (ReturnCode As Integer?, pFiscalYear As Integer?) = iGetFiscalYearExt.GetFiscalYearSp(pFiscalYear)
        Dim Severity As Integer = result.ReturnCode.Value
        pFiscalYear = result.pFiscalYear
        Return Severity
    End Function
End Class

Public Class OAuthBase
    Public Enum SignatureTypes
        HMACSHA1
        HMACSHA256
        PLAINTEXT
        RSASHA1
    End Enum

    Protected Class QueryParameter
        Private ReadOnly m_name As String = Nothing
        Private ReadOnly m_value As String = Nothing

        Public Sub New(name As String, value As String)
            Me.m_name = name
            Me.m_value = value
        End Sub

        Public ReadOnly Property Name() As String
            Get
                Return m_name
            End Get
        End Property

        Public ReadOnly Property Value() As String
            Get
                Return m_value
            End Get
        End Property
    End Class

    Protected Class QueryParameterComparer
        Implements IComparer(Of QueryParameter)
        Public Function IComparer_Compare(x As QueryParameter, y As QueryParameter) As Integer Implements IComparer(Of QueryParameter).Compare
            If x.Name = y.Name Then
                Return String.Compare(x.Value, y.Value)
            Else
                Return String.Compare(x.Name, y.Name)
            End If
        End Function
    End Class

    Protected Const OAuthVersion As String = "1.0"
    Protected Const OAuthParameterPrefix As String = "oauth_"
    Protected Const OAuthConsumerKeyKey As String = "oauth_consumer_key"
    Protected Const OAuthCallbackKey As String = "oauth_callback"
    Protected Const OAuthVersionKey As String = "oauth_version"
    Protected Const OAuthSignatureMethodKey As String = "oauth_signature_method"
    Protected Const OAuthSignatureKey As String = "oauth_signature"
    Protected Const OAuthTimestampKey As String = "oauth_timestamp"
    Protected Const OAuthNonceKey As String = "oauth_nonce"
    Protected Const OAuthTokenKey As String = "oauth_token"
    Protected Const OAuthTokenSecretKey As String = "oauth_token_secret"

    Protected Const HMACSHA1SignatureType As String = "HMAC-SHA1"
    Protected Const HMACSHA256SignatureType As String = "HMAC-SHA256"
    Protected Const PlainTextSignatureType As String = "PLAINTEXT"
    Protected Const RSASHA1SignatureType As String = "RSA-SHA1"

    Protected random As New Random()

    Protected unreservedChars As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~"

    Private Function ComputeHash(hashAlgorithm As HashAlgorithm, data As String) As String
        If hashAlgorithm Is Nothing Then
            Throw New ArgumentNullException("hashAlgorithm")
        End If

        If String.IsNullOrEmpty(data) Then
            Throw New ArgumentNullException("data")
        End If

        Dim dataBuffer As Byte() = System.Text.Encoding.ASCII.GetBytes(data)
        Dim hashBytes As Byte() = hashAlgorithm.ComputeHash(dataBuffer)

        Return Convert.ToBase64String(hashBytes)
    End Function

    Private Function GetQueryParameters(parameters As String) As List(Of QueryParameter)
        If parameters.StartsWith("?") Then
            parameters = parameters.Remove(0, 1)
        End If

        Dim result As New List(Of QueryParameter)()

        If Not String.IsNullOrEmpty(parameters) Then
            Dim p As String() = parameters.Split("&"c)
            For Each s As String In p
                If Not String.IsNullOrEmpty(s) AndAlso Not s.StartsWith(OAuthParameterPrefix) Then
                    If s.IndexOf("="c) > -1 Then
                        Dim temp As String() = s.Split("="c)
                        result.Add(New QueryParameter(temp(0), temp(1)))
                    Else
                        result.Add(New QueryParameter(s, String.Empty))
                    End If
                End If
            Next
        End If

        Return result
    End Function

    Protected Function UrlEncode(value As String) As String
        Dim result As New StringBuilder()

        For Each symbol As Char In value
            If unreservedChars.IndexOf(symbol) <> -1 Then
                result.Append(symbol)
            Else
                result.Append("%" + [String].Format("{0:X2}", Asc(symbol.ToString())))
            End If
        Next
        Return result.ToString()
    End Function

    Protected Function NormalizeRequestParameters(parameters As IList(Of QueryParameter)) As String
        Dim sb As New StringBuilder()
        Dim p As QueryParameter = Nothing
        For i As Integer = 0 To parameters.Count - 1
            p = parameters(i)
            sb.AppendFormat("{0}={1}", p.Name, p.Value)

            If i < parameters.Count - 1 Then
                sb.Append("&")
            End If
        Next

        Return sb.ToString()
    End Function

    Public Function GenerateSignatureBase(url As Uri, consumerKey As String, token As String, tokenSecret As String, httpMethod As String, timeStamp As String,
        nonce As String, signatureType As String, ByRef normalizedUrl As String, ByRef normalizedRequestParameters As String) As String
        If token Is Nothing Then
            token = String.Empty
        End If

        If tokenSecret Is Nothing Then
            tokenSecret = String.Empty
        End If

        If String.IsNullOrEmpty(consumerKey) Then
            Throw New ArgumentNullException("consumerKey")
        End If

        If String.IsNullOrEmpty(httpMethod) Then
            Throw New ArgumentNullException("httpMethod")
        End If

        If String.IsNullOrEmpty(signatureType) Then
            Throw New ArgumentNullException("signatureType")
        End If

        normalizedUrl = Nothing
        normalizedRequestParameters = Nothing

        Dim parameters As List(Of QueryParameter) = GetQueryParameters(url.Query)
        parameters.Add(New QueryParameter(OAuthVersionKey, OAuthVersion))
        parameters.Add(New QueryParameter(OAuthNonceKey, nonce))
        parameters.Add(New QueryParameter(OAuthTimestampKey, timeStamp))
        parameters.Add(New QueryParameter(OAuthSignatureMethodKey, signatureType))
        parameters.Add(New QueryParameter(OAuthConsumerKeyKey, consumerKey))

        If Not String.IsNullOrEmpty(token) Then
            parameters.Add(New QueryParameter(OAuthTokenKey, token))
        End If

        parameters.Sort(New QueryParameterComparer())

        normalizedUrl = String.Format("{0}://{1}", url.Scheme, url.Host)
        If Not ((url.Scheme = "http" AndAlso url.Port = 80) OrElse (url.Scheme = "https" AndAlso url.Port = 443)) Then
            normalizedUrl += ":" + url.Port.ToString()
        End If
        normalizedUrl += url.AbsolutePath
        normalizedRequestParameters = NormalizeRequestParameters(parameters)

        Dim signatureBase As New StringBuilder()
        signatureBase.AppendFormat("{0}&", httpMethod.ToUpper())
        signatureBase.AppendFormat("{0}&", UrlEncode(normalizedUrl))
        signatureBase.AppendFormat("{0}", UrlEncode(normalizedRequestParameters))

        Return signatureBase.ToString()
    End Function

    Public Function GenerateSignatureUsingHash(signatureBase As String, hash As HashAlgorithm) As String
        Return ComputeHash(hash, signatureBase)
    End Function

    Public Function GenerateSignature(url As Uri, consumerKey As String, consumerSecret As String, token As String, tokenSecret As String, httpMethod As String,
        timeStamp As String, nonce As String, ByRef normalizedUrl As String, ByRef normalizedRequestParameters As String) As String
        Return GenerateSignature(url, consumerKey, consumerSecret, token, tokenSecret, httpMethod,
            timeStamp, nonce, SignatureTypes.HMACSHA1, normalizedUrl, normalizedRequestParameters)
    End Function

    Public Function GenerateSignature(url As Uri, consumerKey As String, consumerSecret As String, token As String, tokenSecret As String, httpMethod As String,
        timeStamp As String, nonce As String, signatureType As SignatureTypes, ByRef normalizedUrl As String, ByRef normalizedRequestParameters As String) As String
        Dim signatureBase As String
        Dim tokenSecretValue As String
        tokenSecretValue = ""
        If String.IsNullOrEmpty(tokenSecret) Then
            tokenSecretValue = ""
        Else
            tokenSecretValue = UrlEncode(tokenSecret)
        End If

        Dim keyBase As String = String.Format("{0}&{1}", UrlEncode(consumerSecret), tokenSecretValue)

        normalizedUrl = Nothing
        normalizedRequestParameters = Nothing

        Select Case signatureType
            Case SignatureTypes.HMACSHA1
                signatureBase = GenerateSignatureBase(url, consumerKey, token, tokenSecret, httpMethod, timeStamp,
                    nonce, HMACSHA1SignatureType, normalizedUrl, normalizedRequestParameters)
                Dim hmacsha1 As New HMACSHA1 With {
                    .Key = Encoding.ASCII.GetBytes(keyBase)
                }
                Return GenerateSignatureUsingHash(signatureBase, hmacsha1)
            Case SignatureTypes.HMACSHA256
                signatureBase = GenerateSignatureBase(url, consumerKey, token, tokenSecret, httpMethod, timeStamp,
                    nonce, HMACSHA256SignatureType, normalizedUrl, normalizedRequestParameters)
                Dim hmacsha256 As New HMACSHA256 With {
                    .Key = Encoding.ASCII.GetBytes(keyBase)
                }
                Return GenerateSignatureUsingHash(signatureBase, hmacsha256)
            Case SignatureTypes.RSASHA1
                Throw New NotImplementedException()
            Case Else
                Throw New ArgumentException("Unknown signature type", "signatureType")
        End Select
    End Function

    Public Overridable Function GenerateTimeStamp() As String
        Dim ts As TimeSpan = DateTime.UtcNow - New DateTime(1970, 1, 1, 0, 0, 0, 0)
        Return Convert.ToInt64(ts.TotalSeconds).ToString()
    End Function

    Public Overridable Function GenerateNonce() As String
        Return GetRandomNum(123400, 9999999)
    End Function

    Private Function GetRandomNum(ByVal startNum As Integer, ByVal endNum As Integer) As String
        Dim ranstring As String
        Dim gap As Integer
        Dim ranNum As Integer
        Dim milSecond As Integer = Now.Millisecond * 123456
        Dim i As Integer = 0

        gap = endNum - startNum
        While milSecond > endNum
            milSecond = CInt(milSecond / gap)
            i = i + 1
        End While

        ranNum = CInt(startNum + milSecond + (-1 ^ i))
        ranstring = ranNum.ToString()
        Return ranstring
    End Function
End Class


