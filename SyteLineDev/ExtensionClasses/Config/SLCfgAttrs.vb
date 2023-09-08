Option Explicit On
Option Strict On

Imports TDCI.BuyDesign.Configurator.Integration.Data

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.Core.Common

Imports System
Imports System.Data
Imports System.Xml
Imports Mongoose.IDO.DataAccess

<IDOExtensionClass("SLCfgAttrs")> _
Public Class SLCfgAttrs
    Inherits ExtensionClassBase

    Public hostServices As TDCI.BuyDesign.Configurator.Integration.Win.HostServices
    <IDOMethod(MethodFlags.CustomLoad, "Infobar")> _
    Public Function CfgGetGlobalValueList(ByVal sSiteId As String, ByVal sConfigId As String, ByRef Infobar As String) As DataTable

        Dim dtAttr As DataTable
        dtAttr = Me.ConstructDataTable()

        Dim response As InvokeResponseData
        Dim hostServices As TDCI.BuyDesign.Configurator.Integration.Win.HostServices
        Dim theConfiguration As TDCI.BuyDesign.Configurator.Integration.Data.Outputs.Configuration

        Dim sCoNum As String = ""
        Dim iCoLine As Integer = 0
        Dim sJob As String = ""
        Dim iSuffix As Integer = 0
        Dim sConfigType As String = ""

        Dim sParentId As String = ""
        Dim sDetailId As String = ""
        Dim sHeaderId As String = ""
        Dim sType As String = ""

        Dim iSequence As Integer = 0
        Dim sDataType As String = ""
        Dim sAttrName As String = ""
        Dim sAttrValue As String = ""

        Dim sAppId As String = ""
        Dim sConfigHdrNameSpace As String = ""
        Dim sConfigurator As String = ""
        Dim sConfiguratorURL As String = ""

        Dim sMetadataInstance As String = GetMetadataInstance()
        Dim sAuthenticationKey As String = GetAuthenticationKey()

        ' Build the Header ID and Detail ID
        Dim cfgMain As New LoadCollectionResponseData
        Dim cfgMainProp As New PropertyList
        Dim filter As String = "ConfigId = " + SqlLiteral.Format(sConfigId, SqlLiteralFormatFlags.UseQuotes)
        cfgMainProp.Add("CoNum")
        cfgMainProp.Add("CoLine")
        cfgMainProp.Add("Job")
        cfgMainProp.Add("Suffix")
        cfgMainProp.Add("ConfigType")
        cfgMain = Me.Context.Commands.LoadCollection("SLCfgMains", cfgMainProp, filter, String.Empty, 1)

        If cfgMain.Items.Count > 0 Then
            sCoNum = cfgMain.Item(0, "CoNum").GetValue("")
            iCoLine = CInt(cfgMain.Item(0, "CoLine").GetValue("0"))
            sJob = cfgMain.Item(0, "Job").GetValue("")
            iSuffix = CInt(cfgMain.Item(0, "Suffix").GetValue("0"))
            sConfigType = cfgMain.Item(0, "ConfigType").GetValue("")
        End If

        Select Case sConfigType
            Case "COLine"
                sType = "1"
            Case "EstimateLine"
                sType = "2"
            Case "Job"
                sType = "101"
            Case "EstimateJob"
                sType = "102"
            Case "CustomerOrder"
                sType = "103"
            Case "Estimate"
                sType = "104"
            Case "COBlanketLine"
                sType = "105"
            Case Else
                sType = ""
        End Select

        If sCoNum <> "" Then
            sParentId = sCoNum
            sDetailId = CStr(iCoLine)
        Else
            sParentId = sJob
            sDetailId = CStr(iSuffix)
        End If

        If IsNumeric(sParentId) Then
            While Len(sParentId) < 10
                sParentId = " " + sParentId
            End While
        End If

        sHeaderId = sParentId + "-" + sType + "-" + sSiteId
        sDetailId = CStr(iCoLine)

        ' Get Configuration Parameters
        response = Me.Context.Commands.Invoke("SL.SLCfgMains", "GetCfgParmsSp", _
                       sAppId, sConfigHdrNameSpace, sConfigurator, sConfiguratorURL, sMetadataInstance, sAuthenticationKey, sSiteId)

        If response.Parameters(0).IsNull Then
            sAppId = ""
        Else
            sAppId = response.Parameters(0).GetValue(Of String)()
        End If
        If response.Parameters(1).IsNull Then
            sConfigHdrNameSpace = ""
        Else
            sConfigHdrNameSpace = response.Parameters(1).GetValue(Of String)()
        End If
        If response.Parameters(2).IsNull Then
            sConfigurator = "N"
        Else
            sConfigurator = response.Parameters(2).GetValue(Of String)()
        End If
        If response.Parameters(3).IsNull Then
            sConfiguratorURL = ""
        Else
            sConfiguratorURL = response.Parameters(3).GetValue(Of String)()
        End If
        If response.Parameters(4).IsNull Then
            sMetadataInstance = ""
        Else
            sMetadataInstance = response.Parameters(4).GetValue(Of String)()
        End If
        If response.Parameters(5).IsNull Then
            sAuthenticationKey = ""
        Else
            sAuthenticationKey = response.Parameters(5).GetValue(Of String)()
        End If

        ' Hard-code this for test
        'sConfiguratorURL = "http://USCOWSLU7.infor.com/PCM/ConfiguratorService/v2/ProductConfigurator.svc"

        ' Start the test
        Try
            If IDONull.IsNull(sAuthenticationKey) Or sAuthenticationKey = "" Then
                hostServices = New TDCI.BuyDesign.Configurator.Integration.Win.HostServices(sMetadataInstance, sAppId, sConfiguratorURL)
            Else
                hostServices = New TDCI.BuyDesign.Configurator.Integration.Win.HostServices(sMetadataInstance, sAppId, sConfiguratorURL, sAuthenticationKey)
            End If
            theConfiguration = New TDCI.BuyDesign.Configurator.Integration.Data.Outputs.Configuration()

            ' Use PCM LoadFullConfiguration API to get Configuration Object for a specific Configuration
            If hostServices.Exists(sHeaderId, sDetailId) = True Then
                theConfiguration = hostServices.LoadFullConfiguration(sHeaderId, sDetailId)
            Else
                theConfiguration = Nothing
            End If

            Dim theComp As TDCI.BuyDesign.Configurator.Integration.Data.Outputs.Component
            Dim theCompAttr As TDCI.BuyDesign.Configurator.Integration.Data.Outputs.ComponentAttribute

            ' Loop through the components to find those with the "Global Defaults" Attribute Classification
            For Each theComp In theConfiguration.Components

                For Each theCompAttr In theComp.ComponentAttributes
                    For Each theComAttrClassification As String In theCompAttr.Classifications
                        If theComAttrClassification = "Global Defaults" And theComp.ComponentSequence = 1 Then
                            Dim drAttr As DataRow = dtAttr.NewRow()
                            iSequence = theComp.ComponentSequence
                            sDataType = CStr(theCompAttr.Value.Type)
                            sAttrName = CStr(theCompAttr.Name)
                            sAttrValue = CStr(theCompAttr.Value.ValueAsString)
                            drAttr("UbCompSequence") = iSequence
                            drAttr("AttrType") = sDataType
                            drAttr("AttrName") = sAttrName
                            drAttr("AttrValue") = sAttrValue
                            dtAttr.Rows.Add(drAttr)
                        End If
                    Next
                Next
            Next

            theComp = Nothing
            theCompAttr = Nothing

        Catch Ex As Exception
            Infobar = Ex.Message
        Finally
            theConfiguration = Nothing
            hostServices = Nothing
        End Try

        Return dtAttr
    End Function

    Private Function ConstructDataTable() As DataTable
        Dim dt As New DataTable

        Dim dc1 As New DataColumn With {
            .ColumnName = "UbCompSequence",
            .DataType = GetType(Integer)
        }
        dt.Columns.Add(dc1)

        Dim dc2 As New DataColumn With {
            .ColumnName = "AttrType",
            .DataType = GetType(String)
        }
        dt.Columns.Add(dc2)

        Dim dc3 As New DataColumn With {
            .ColumnName = "AttrName",
            .DataType = GetType(String)
        }
        dt.Columns.Add(dc3)

        Dim dc4 As New DataColumn With {
            .ColumnName = "AttrValue",
            .DataType = GetType(String)
        }
        dt.Columns.Add(dc4)

        Return dt
    End Function

    Public Function GetMetadataInstance() As String


        Dim oDataReader As IDataReader = Nothing

        GetMetadataInstance = ""
        Try
            Using appDB As ApplicationDB = IDORuntime.Context.CreateApplicationDB()
                ' create a new SqlCommand
                Using cmd As IDbCommand = appDB.CreateCommand()
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT config_metadata_instance_filename FROM invparms"

                    Try
                        ' execute the command through the framework
                        oDataReader = appDB.ExecuteReader(cmd)
                    Catch ex As Exception
                        If Not oDataReader Is Nothing AndAlso Not oDataReader.IsClosed Then
                            oDataReader.Close()
                        End If
                        GetMetadataInstance = "ERROR"
                        MGException.Throw(MGException.ExtractMessages(ex))
                    End Try

                    If oDataReader.Read Then
                        GetMetadataInstance = oDataReader.Item("config_metadata_instance_filename").ToString
                    Else
                        If Not oDataReader Is Nothing AndAlso Not oDataReader.IsClosed Then
                            oDataReader.Close()
                        End If
                        GetMetadataInstance = "ERROR"
                        MGException.Throw(Me.GetMessageProvider.GetMessage("E=NoExist1", "@!Parameters", "@invparms", "config_metadata_instance_filename"))
                    End If
                    If Not oDataReader Is Nothing AndAlso Not oDataReader.IsClosed Then
                        oDataReader.Close()
                    End If
                End Using
            End Using
            Exit Function
        Catch ex As Exception
            GetMetadataInstance = "ERROR"
            MGException.Throw(MGException.ExtractMessages(ex))

        End Try

    End Function

    Public Function GetAuthenticationKey() As String


        Dim oDataReader As IDataReader = Nothing

        GetAuthenticationKey = ""
        Try
            Using appDB As ApplicationDB = IDORuntime.Context.CreateApplicationDB()
                ' create a new SqlCommand
                Using cmd As IDbCommand = appDB.CreateCommand()
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT config_authentication_key FROM invparms"

                    Try
                        ' execute the command through the framework
                        oDataReader = appDB.ExecuteReader(cmd)

                    Catch ex As Exception
                        If Not oDataReader Is Nothing AndAlso Not oDataReader.IsClosed Then
                            oDataReader.Close()
                        End If
                        GetAuthenticationKey = "ERROR"
                        MGException.Throw(MGException.ExtractMessages(ex))
                    End Try

                    If oDataReader.Read Then
                        GetAuthenticationKey = oDataReader.Item("config_authentication_key").ToString
                    Else
                        If Not oDataReader Is Nothing AndAlso Not oDataReader.IsClosed Then
                            oDataReader.Close()
                        End If
                        GetAuthenticationKey = "ERROR"
                        MGException.Throw(Me.GetMessageProvider.GetMessage("E=NoExist1", "@!Parameters", "@invparms", "config_authentication_key"))
                    End If
                    If Not oDataReader Is Nothing AndAlso Not oDataReader.IsClosed Then
                        oDataReader.Close()
                    End If
                End Using
            End Using
            Exit Function
        Catch ex As Exception
            GetAuthenticationKey = "ERROR"
            MGException.Throw(MGException.ExtractMessages(ex))

        End Try

    End Function
End Class
