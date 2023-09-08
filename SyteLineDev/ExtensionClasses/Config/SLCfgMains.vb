Option Explicit On

Imports TDCI.BuyDesign.Configurator.Integration.Data
Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.Core.Common
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Net
Imports System
Imports System.IO
Imports System.Data
Imports System.Xml
Imports Mongoose.IDO.DataAccess
Imports System.Globalization
Imports CSI.MG
Imports CSI.Config
Imports System.Runtime.InteropServices
Imports CSI.Data.RecordSets
Imports CSI.ExternalContracts.Portals

<IDOExtensionClass("SLCfgMains")>
Public Class SLCfgMains
    Inherits CSIExtensionClassBase
    Implements ISLCfgMains

    'Public oHostApp As TDCI.BuyDesign.Configuration.Services.Application
    Public hostServices As TDCI.BuyDesign.Configurator.Integration.Win.HostServices

    Public targetConfigId As String
    Public sConfig_type As String
    Public sConfig_status As String
    Public sJob As String
    Public iSuffix As Integer
    Public sCoNum As String
    Public iCoLine As Integer
    Public dBasePrice As Decimal
    Public lParentConfigurationID As Long
    Public sItem As String
    Public sSite As String
    Dim subConfigList As List(Of KeyValuePair(Of String, String))
    Dim subConfigurationMapList As List(Of SubConfigurationMap)
    Dim dtCfgSchemaAttributeFields As DataTable = New DataTable()

    <IDOMethod(MethodFlags.None)>
    Public Function CfgLoadRulesets _
       (ByVal sApplID As String,
        ByVal sHdrNamespace As String,
        ByRef sRulesetList As String) As Integer

        Dim ds As DataSet
        Dim sDelim As String = ","
        Dim i As Integer = 0

        Dim sMetadataInstance As String = GetMetadataInstance()
        Dim sAuthenticationKey As String = GetAuthenticationKey()

        If IDONull.IsNull(sAuthenticationKey) Or sAuthenticationKey = "" Then
            hostServices = New TDCI.BuyDesign.Configurator.Integration.Win.HostServices(sMetadataInstance, sApplID, GetConfiguratorURL())
        Else
            hostServices = New TDCI.BuyDesign.Configurator.Integration.Win.HostServices(sMetadataInstance, sApplID, GetConfiguratorURL(), sAuthenticationKey)
        End If

        Try
            ds = hostServices.ExecuteExtension("GetRulesets", New String() {sHdrNamespace})
            For Each drRuleset As DataRow In ds.Tables(0).Rows
                If sRulesetList <> "" Then sRulesetList = sRulesetList + sDelim
                sRulesetList = sRulesetList + CStr(drRuleset(0))
            Next
            ''This is as part of note given in RS6931
            sRulesetList = ""
        Catch ex As Exception
            sRulesetList = "CfgLoadRulesets Exception: " & ex.Message
            Return -1

        Finally
            hostServices = Nothing

        End Try
        Return 0
    End Function

    <IDOMethod(MethodFlags.None)>
    Public Function CfgLoadNameSpaces _
        (ByVal sApplID As String, ByVal sConfiguratorURL As String,
         ByRef sModelList As String) As Integer

        Dim dsModels As DataSet
        Dim sDelim As String = ","
        'Dim s As String = ""

        Dim sMetadataInstance As String = GetMetadataInstance()
        Dim sAuthenticationKey As String = GetAuthenticationKey()

        If IDONull.IsNull(sConfiguratorURL) Or sConfiguratorURL = "" _
        Or IDONull.IsNull(sApplID) Or sApplID = "" Then
            Return 0
        End If

        Try
            If IDONull.IsNull(sAuthenticationKey) Or sAuthenticationKey = "" Then
                hostServices = New TDCI.BuyDesign.Configurator.Integration.Win.HostServices(sMetadataInstance, sApplID, sConfiguratorURL)
            Else
                hostServices = New TDCI.BuyDesign.Configurator.Integration.Win.HostServices(sMetadataInstance, sApplID, sConfiguratorURL, sAuthenticationKey)
            End If
            dsModels = hostServices.ExecuteExtension("GetNamespaces", New String() {})

            For Each drNamespace As DataRow In dsModels.Tables(0).Rows
                If sModelList <> "" Then sModelList = sModelList + sDelim
                sModelList = sModelList + CStr(drNamespace(0))
            Next
            ''This is as part of note given in RS6931
            sModelList = ""
            Return 0

        Catch ex As Exception

            sModelList = "CfgLoadNameSpaces Exception: " & Err.Description
            Return -1

        Finally
            hostServices = Nothing

        End Try

    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CfgTestConnection _
        (ByVal sMetaInstance As String,
         ByVal sApplID As String,
         ByVal sURL As String,
         ByVal sAuthKey As String,
         ByRef Infobar As String) As Integer

        If IDONull.IsNull(sURL) Or sURL = "" _
        Or IDONull.IsNull(sApplID) Or sApplID = "" _
        Or IDONull.IsNull(sMetaInstance) Or sMetaInstance = "" Then
            Return 0
        End If

        Dim testConfiguration As TDCI.BuyDesign.Configurator.Integration.Data.ConfigurationSummary
        Dim retInteger As Integer = 0
        Try

            ' If Authentication Key is not null then include it as a parameter in creating of instance.
            If IDONull.IsNull(sAuthKey) Or sAuthKey = "" Then
                hostServices = New TDCI.BuyDesign.Configurator.Integration.Win.HostServices(sMetaInstance, sApplID, sURL)
            Else
                hostServices = New TDCI.BuyDesign.Configurator.Integration.Win.HostServices(sMetaInstance, sApplID, sURL, sAuthKey)
            End If

            ' Attempt to get a configuration object for a configuration that does not exist.
            '   If the PCM Connection data is bad, this trips an error.
            If hostServices.Exists("TestConfiguration", "1") = True Then
                testConfiguration = hostServices.Load("TestConfiguration", "1")
            Else
                testConfiguration = Nothing
            End If

            Infobar = "Test Connection: Success!"
        Catch Ex As Exception
            Infobar = "PCM Global Default Test Error: " & Ex.Message
            retInteger = 16

        Finally
            testConfiguration = Nothing
            hostServices = Nothing
        End Try
        Return retInteger
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CfgInitializeConfiguration _
        (ByVal sMetaInstance As String,
         ByVal sConfiguratorApplID As String,
         ByVal sDocAutomationApplID As String,
         ByVal sURL As String,
         ByVal sAuthKey As String,
         ByRef Infobar As String) As Integer

        Dim tempAttrList As IList(Of TDCI.BuyDesign.Configurator.Integration.Data.MfgTemplateAttribute)
        Try

            ' If Authentication Key is not null then include it as a parameter in creating of instance.
            If IDONull.IsNull(sAuthKey) Or sAuthKey = "" Then
                hostServices = New TDCI.BuyDesign.Configurator.Integration.Win.HostServices(sMetaInstance, sConfiguratorApplID, sURL)
            Else
                hostServices = New TDCI.BuyDesign.Configurator.Integration.Win.HostServices(sMetaInstance, sConfiguratorApplID, sURL, sAuthKey)
            End If

        Catch Ex As Exception
            Infobar = "PCM Global Default Test Error: " & Ex.Message
            Return -1
        End Try

        Try
            'Initialize PCM Model - RuleTypeMFGComponentDescription
            Infobar &= vbNewLine & "Initialize PCM Model - RuleTypeMFGComponentDescription.."
            tempAttrList = {
                    New MfgTemplateAttribute With {
                            .Name = "Print Code",
                            .DataType = DataType.String,
                            .DefaultValue = "I",
                            .IsRequired = True,
                            .Description = "I for Internal, E for External"
                       },
                    New MfgTemplateAttribute With {
                            .Name = "Config Component Sequence",
                            .DataType = DataType.String,
                            .DefaultValue = "=ToString(ComponentSequence)"
                        },
                    New MfgTemplateAttribute With {
                            .Name = "Part Number",
                            .DataType = DataType.String,
                            .Description = "Required for Sub Jobs. Part Number must exist in SyteLine."
                        },
                    New MfgTemplateAttribute With {
                            .Name = "Quantity",
                            .DataType = DataType.Number,
                            .DefaultValue = "=null",
                            .Description = "Required for SubJobs"
                        },
                    New MfgTemplateAttribute With {
                            .Name = "job.contains_tax_free_matl",
                            .DataType = DataType.Number,
                            .DefaultValue = "=null",
                            .Description = "SyteLine Schema Mapping to job. contains_tax_free_matl field."
                        },
                    New MfgTemplateAttribute With {
                            .Name = "job.description",
                            .DataType = DataType.String,
                            .Description = "SyteLine Schema Mapping to job. description field"
                       },
                    New MfgTemplateAttribute With {
                            .Name = "job.export_type",
                            .DataType = DataType.String,
                            .Description = "SyteLine Schema Mapping to job. export_type field."
                        },
                    New MfgTemplateAttribute With {
                            .Name = "job.midnight_of_job_sch_compdate",
                            .DataType = DataType.String,
                            .Description = "SyteLine Schema Mapping to job. midnight_of_job_sch_compdate field."
                        },
                    New MfgTemplateAttribute With {
                            .Name = "job.midnight_of_job_sch_end_date",
                            .DataType = DataType.String,
                            .Description = "SyteLine Schema Mapping to job. midnight_of_job_sch_end_date field."
                        },
                    New MfgTemplateAttribute With {
                            .Name = "job.rcpt_rqmt",
                            .DataType = DataType.String,
                            .Description = "SyteLine Schema Mapping to job. rcpt_rqmt field."
                        },
                    New MfgTemplateAttribute With {
                            .Name = "job.rework",
                            .DataType = DataType.String,
                            .DefaultValue = "=null",
                            .Description = "SyteLine Schema Mapping to job. rework field."
                        },
                    New MfgTemplateAttribute With {
                            .Name = "job.scheduled",
                            .DataType = DataType.String,
                            .DefaultValue = "=null",
                            .Description = "SyteLine Schema Mapping to job. scheduled field."
                        },
                    New MfgTemplateAttribute With {
                            .Name = "job.unlinked_xref",
                            .DataType = DataType.String,
                            .DefaultValue = "=null",
                            .Description = "SyteLine Schema Mapping to job. unlinked_xref field."
                        },
                    New MfgTemplateAttribute With {
                            .Name = "job.whse",
                            .DataType = DataType.String,
                            .Description = "SyteLine Schema Mapping to job. whse field."
                        },
                    New MfgTemplateAttribute With {
                            .Name = "job.text",
                            .DataType = DataType.String,
                            .Description = "SyteLine Schema Mapping to job. text field."
                        },
                    New MfgTemplateAttribute With {
                            .Name = "ConfigurationCode",
                            .DataType = DataType.String,
                            .Description = "SyteLine Schema Mapping to IPN field."
                        },
                    New MfgTemplateAttribute With {
                            .Name = "Material Sequence",
                            .DataType = DataType.String
                        }
                }
            hostServices.SetMfgTemplate("MFG Component", tempAttrList)
        Catch Ex As Exception
            Infobar = "PCM Global Default Test Error: " & Ex.Message
        End Try

        Try

            'Initialize PCM Model - RuleTypeMFGWorkInstructionDescription
            Infobar &= vbNewLine & "Initialize PCM Model - RuleTypeMFGWorkInstructionDescription.."
            tempAttrList = {
                    New MfgTemplateAttribute With {
                      .Name = "Description",
                      .DataType = DataType.String,
                      .IsRequired = True,
                      .Description = "Operation note text"
                     }
                }
            hostServices.SetMfgTemplate("MFG Work Instruction", tempAttrList)
        Catch Ex As Exception
            Infobar = "PCM Global Default Test Error: " & Ex.Message
        End Try

        Try

            'Initialize PCM Model - RuleTypeMFGOperationDescription
            Infobar &= vbNewLine & "Initialize PCM Model - RuleTypeMFGOperationDescription.."
            tempAttrList = {
                    New MfgTemplateAttribute With {
                      .Name = "Operation Name",
                      .DataType = DataType.String,
                      .Description = "Operation Name or Work Center ID"
                     },
                    New MfgTemplateAttribute With {
                      .Name = "Operation Description",
                      .DataType = DataType.String,
                      .Description = "Description of the Operation"
                     },
                    New MfgTemplateAttribute With {
                      .Name = "Work Center ID",
                      .DataType = DataType.String,
                      .IsRequired = True,
                      .Description = "Valid Work Center ID.  Parent Material or Component"
                     },
                    New MfgTemplateAttribute With {
                      .Name = "Print Code",
                      .DataType = DataType.String,
                      .DefaultValue = "I",
                      .IsRequired = True,
                      .Description = "I for Internal, E for External"
                     },
                    New MfgTemplateAttribute With {
                      .Name = "jrt_sch.run_lbr_hrs",
                      .DataType = DataType.Number,
                      .DefaultValue = "=0",
                      .Description = "Used for ""H"" Hours/Piece --- Enter Hours"
                     },
                    New MfgTemplateAttribute With {
                      .Name = "jrt_sch.pcs_per_lbr_hr",
                      .DataType = DataType.Number,
                      .DefaultValue = "=0",
                      .Description = "Used for ""P"" Piece/Hour --- Enter Pieces"
                     },
                    New MfgTemplateAttribute With {
                      .Name = "jobroute.bflush_type",
                      .DataType = DataType.String,
                      .Description = "Syteline Schema Mapping to jobroute. bflush_type field."
                     },
                    New MfgTemplateAttribute With {
                      .Name = "jobroute.cntrl_point",
                      .DataType = DataType.Number,
                      .DefaultValue = "=null",
                      .Description = "Syteline Schema Mapping to jobroute. cntrl_point field."
                     },
                    New MfgTemplateAttribute With {
                      .Name = "jobroute.efficiency",
                      .DataType = DataType.Number,
                      .DefaultValue = "=null",
                      .Description = "Syteline Schema Mapping to jobroute. efficiency field."
                     },
                    New MfgTemplateAttribute With {
                      .Name = "jobroute.fixovhd_rate",
                      .DataType = DataType.Number,
                      .DefaultValue = "=null",
                      .Description = "Syteline Schema Mapping to jobroute. fixovhd_rate field."
                     },
                    New MfgTemplateAttribute With {
                      .Name = "jobroute.fovhd_rate_mch",
                      .DataType = DataType.Number,
                      .DefaultValue = "=null",
                      .Description = "Syteline Schema Mapping to jobroute. fovhd_rate_mch field."
                     },
                    New MfgTemplateAttribute With {
                      .Name = "jobroute.run_basis_lbr",
                      .DataType = DataType.String,
                      .Description = "P = Pieces/Hour or H = Hours/Piece"
                     },
                    New MfgTemplateAttribute With {
                      .Name = "jobroute.run_basis_mch",
                      .DataType = DataType.String,
                      .Description = "Syteline Schema Mapping to jobroute. run_basis_mch field."
                     },
                    New MfgTemplateAttribute With {
                      .Name = "jobroute.run_rate_lbr",
                      .DataType = DataType.Number,
                      .DefaultValue = "=null",
                      .Description = "Syteline Schema Mapping to jobroute. run_rate_lbr field."
                     },
                    New MfgTemplateAttribute With {
                      .Name = "jobroute.setup_rate",
                      .DataType = DataType.Number,
                      .DefaultValue = "=null",
                      .Description = "Syteline Schema Mapping to jobroute. setup_rate field."
                     },
                    New MfgTemplateAttribute With {
                      .Name = "jobroute.varovhd_rate",
                      .DataType = DataType.Number,
                      .DefaultValue = "=null",
                      .Description = "Syteline Schema Mapping to jobroute. varovhd_rate field."
                     },
                    New MfgTemplateAttribute With {
                      .Name = "jobroute.vovhd_rate_mch",
                      .DataType = DataType.Number,
                      .DefaultValue = "=null",
                      .Description = "Syteline Schema Mapping to jobroute. vovhd_rate_mch field."
                     },
                    New MfgTemplateAttribute With {
                      .Name = "jrt_sch.finish_hrs",
                      .DataType = DataType.Number,
                      .DefaultValue = "=null",
                      .Description = "Syteline Schema Mapping to jrt_sch. finish_hrs field."
                     },
                    New MfgTemplateAttribute With {
                      .Name = "jrt_sch.move_hrs",
                      .DataType = DataType.Number,
                      .DefaultValue = "=null",
                      .Description = "Syteline Schema Mapping to jrt_sch. move_hrs field."
                     },
                    New MfgTemplateAttribute With {
                      .Name = "jrt_sch.offset_hrs",
                      .DataType = DataType.Number,
                      .DefaultValue = "=null",
                      .Description = "Syteline Schema Mapping to jrt_sch. offset_hrs field."
                     },
                    New MfgTemplateAttribute With {
                      .Name = "jrt_sch.pcs_per_mch_hr",
                      .DataType = DataType.Number,
                      .DefaultValue = "=null",
                      .Description = "Syteline Schema Mapping to jrt_sch. pcs_per_mch_hr field."
                     },
                    New MfgTemplateAttribute With {
                      .Name = "jrt_sch.queue_hrs",
                      .DataType = DataType.Number,
                      .DefaultValue = "=null",
                      .Description = "Syteline Schema Mapping to jrt_sch. queue_hrs field."
                     },
                    New MfgTemplateAttribute With {
                      .Name = "jrt_sch.run_mch_hrs",
                      .DataType = DataType.Number,
                      .DefaultValue = "=null",
                      .Description = "Syteline Schema Mapping to jrt_sch. run_mch_hrs field."
                     },
                    New MfgTemplateAttribute With {
                      .Name = "jrt_sch.sched_hrs",
                      .DataType = DataType.Number,
                      .DefaultValue = "=null",
                      .Description = "Syteline Schema Mapping to jrt_sch. sched_hrs field."
                     },
                    New MfgTemplateAttribute With {
                      .Name = "jrt_sch.setup_hrs",
                      .DataType = DataType.Number,
                      .DefaultValue = "=null",
                      .Description = "Syteline Schema Mapping to jrt_sch. setup_hrs field."
                     },
                    New MfgTemplateAttribute With {
                      .Name = "jrt_sch.whenrule",
                      .DataType = DataType.Number,
                      .DefaultValue = "=null",
                      .Description = "Syteline Schema Mapping to jrt_sch. whenrule field."
                     },
                    New MfgTemplateAttribute With {
                      .Name = "jobroute.text",
                      .DataType = DataType.String,
                      .Description = "Syteline Schema Mapping to jobroute. text field."
                     }
                }
            hostServices.SetMfgTemplate("MFG Operation", tempAttrList)
        Catch Ex As Exception
            Infobar = "PCM Global Default Test Error: " & Ex.Message
        End Try

        Try

            'Initialize PCM Model - RuleTypeMFGMaterialDescription
            Infobar &= vbNewLine & "Initialize PCM Model - RuleTypeMFGMaterialDescription.."
            tempAttrList = {
                    New MfgTemplateAttribute With {
                      .Name = "Part Number",
                      .DataType = DataType.String,
                      .Description = "Material Part Number"
                     },
                    New MfgTemplateAttribute With {
                      .Name = "Quantity",
                      .DataType = DataType.Number,
                      .DefaultValue = "=null",
                      .Description = "Material Qty"
                     },
                    New MfgTemplateAttribute With {
                      .Name = "Price",
                      .DataType = DataType.String,
                      .Description = "Material Price will be returned to SyteLine when Create New Line is Enabled"
                     },
                    New MfgTemplateAttribute With {
                      .Name = "Create New Line",
                      .DataType = DataType.Number,
                      .DefaultValue = "=0",
                      .Description = "=0 to Disable, =1 to Enable"
                     },
                    New MfgTemplateAttribute With {
                      .Name = "Print Code",
                      .DataType = DataType.String,
                      .DefaultValue = "I",
                      .IsRequired = True,
                      .Description = "I for Internal, E for External"
                     },
                    New MfgTemplateAttribute With {
                     .Name = "job_ref.assy_seq",
                      .DataType = DataType.String,
                      .Description = "Syteline Schema Mapping to job_ref.assy_seq field."
                     },
                    New MfgTemplateAttribute With {
                      .Name = "job_ref.bubble",
                      .DataType = DataType.String,
                      .Description = "Syteline Schema Mapping to job_ref.bubble field."
                     },
                    New MfgTemplateAttribute With {
                      .Name = "job_ref.ref_des",
                      .DataType = DataType.String,
                      .Description = "Syteline Schema Mapping to job_ref.ref_des field."
                     },
                    New MfgTemplateAttribute With {
                      .Name = "job_ref.ref_seq",
                      .DataType = DataType.Number,
                      .DefaultValue = "=null",
                      .Description = "Syteline Schema Mapping to job_ref.ref_seq field."
                     },
                   New MfgTemplateAttribute With {
                      .Name = "jobmatl.backflush",
                      .DataType = DataType.Number,
                      .DefaultValue = "=null",
                                .Description = "Syteline Schema Mapping to jobmatl.backflush field."
                     },
                    New MfgTemplateAttribute With {
                      .Name = "jobmatl.bflush_loc",
                      .DataType = DataType.String,
                            .Description = "Syteline Schema Mapping to jobmatl.bflush_loc field."
                     },
                    New MfgTemplateAttribute With {
                      .Name = "jobmatl.bom_seq",
                      .DataType = DataType.Number,
                      .DefaultValue = "=null",
                            .Description = "Syteline Schema Mapping to jobmatl.bom_seq field."
                     },
                    New MfgTemplateAttribute With {
                      .Name = "jobmatl.fmatlovhd",
                      .DataType = DataType.Number,
                      .DefaultValue = "=null",
                            .Description = "Syteline Schema Mapping to jobmatl.fmatlovhd field."
                     },
                    New MfgTemplateAttribute With {
                      .Name = "jobmatl.matl_qty",
                      .DataType = DataType.Number,
                      .DefaultValue = "=null",
                            .Description = "Syteline Schema Mapping to jobmatl.matl_qty field."
                     },
                    New MfgTemplateAttribute With {
                      .Name = "jobmatl.matl_type",
                      .DataType = DataType.String,
                            .Description = "Syteline Schema Mapping to jobmatl.matl_type field."
                     },
                    New MfgTemplateAttribute With {
                      .Name = "jobmatl.new_sequence",
                      .DataType = DataType.Number,
                      .DefaultValue = "=null",
                            .Description = "Syteline Schema Mapping to jobmatl.new_sequence field."
                     },
                    New MfgTemplateAttribute With {
                      .Name = "jobmatl.ref_type",
                      .DataType = DataType.String,
                            .Description = "Syteline Schema Mapping to jobmatl.ref_type field."
                     },
                    New MfgTemplateAttribute With {
                      .Name = "jobmatl.scrap_fact",
                      .DataType = DataType.Number,
                      .DefaultValue = "=null",
                            .Description = "Syteline Schema Mapping to jobmatl.scrap_fact field."
                     },
                    New MfgTemplateAttribute With {
                      .Name = "jobmatl.u_m",
                      .DataType = DataType.String,
                            .Description = "Syteline Schema Mapping to jobmatl.u_m field."
                     },
                    New MfgTemplateAttribute With {
                      .Name = "jobmatl.units",
                      .DataType = DataType.String,
                      .DefaultValue = "=null",
                            .Description = "Syteline Schema Mapping to jobmatl.units field."
                     },
                    New MfgTemplateAttribute With {
                      .Name = "jobmatl.vmatlovhd",
                      .DataType = DataType.Number,
                      .DefaultValue = "=null",
                            .Description = "Syteline Schema Mapping to jobmatl.vmatlovhd field."
                     },
                    New MfgTemplateAttribute With {
                      .Name = "jobmatl.text",
                      .DataType = DataType.String,
                            .Description = "Syteline Schema Mapping to jobmatl.text field."
                     },
                    New MfgTemplateAttribute With {
                      .Name = "jobmatl.description",
                      .DataType = DataType.String,
                            .Description = "Syteline Schema Mapping to jobmatl.desctiption field."
                     },
                    New MfgTemplateAttribute With {
                      .Name = "Material Sequence",
                      .DataType = DataType.String
                     }
                }
            hostServices.SetMfgTemplate("MFG Material", tempAttrList)
        Catch Ex As Exception
            Infobar = "PCM Global Default Test Error: " & Ex.Message
        End Try

        Try
            'Initialize PCM Model - RuleTypeMFGDetailDescription
            Infobar &= vbNewLine & "Initialize PCM Model - RuleTypeMFGDetailDescription.."
            tempAttrList = {
                    New MfgTemplateAttribute With {
                      .Name = "OperationNo",
                      .DataType = DataType.String,
                      .Description = "Operation Number"
                     },
                    New MfgTemplateAttribute With {
                      .Name = "SequenceNo",
                      .DataType = DataType.String,
                      .Description = "Document Sequence Number (1, 2, 3?"
                     },
                    New MfgTemplateAttribute With {
                      .Name = "DocumentName",
                      .DataType = DataType.String,
                      .Description = "SyteLine Document Name"
                     },
                    New MfgTemplateAttribute With {
                      .Name = "Description",
                      .DataType = DataType.String,
                      .Description = "SyteLine Document Description"
                     },
                    New MfgTemplateAttribute With {
                      .Name = "URL",
                      .DataType = DataType.String,
                      .Description = "Document URL or UNC Path"
                     },
                    New MfgTemplateAttribute With {
                      .Name = "InternalFlag",
                      .DataType = DataType.Boolean,
                      .DefaultValue = "=False",
                      .Description = "SyteLine Internal Flag"
                     },
                    New MfgTemplateAttribute With {
                      .Name = "Revision",
                      .DataType = DataType.String,
                      .Description = "SyteLine Document Revision"
                     },
                    New MfgTemplateAttribute With {
                      .Name = "Status",
                      .DataType = DataType.String,
                      .Description = "SyteLine Document Status (Approved, Pending, Rejected)"
                     },
                    New MfgTemplateAttribute With {
                      .Name = "StartDate",
                      .DataType = DataType.String,
                      .Description = "SyteLine Document Effectivity Start Date (MM/DD/YYYY)"
                     },
                    New MfgTemplateAttribute With {
                      .Name = "EndDate",
                      .DataType = DataType.String,
                      .Description = "SyteLine Document Effectivity End Date (MM/DD/YYYY)"
                     },
                    New MfgTemplateAttribute With {
                      .Name = "AttachTo",
                      .DataType = DataType.String,
                      .Description = "Attached Document To (job, Material, operation)"
                     }
                }
            hostServices.SetMfgTemplate("MFG Detail", tempAttrList)
        Catch Ex As Exception
            Infobar = "PCM Global Default Test Error: " & Ex.Message
        End Try
        Try

            Dim integAttrList As IList(Of IntegrationTemplateAttribute)
            'Initialize PCM Model - SyteLineDocument
            Infobar &= vbNewLine & "Initialize PCM Model - SyteLineDocument.."
            If IDONull.IsNull(sAuthKey) Or sAuthKey = "" Then
                hostServices = New TDCI.BuyDesign.Configurator.Integration.Win.HostServices(sMetaInstance, sDocAutomationApplID, sURL)
            Else
                hostServices = New TDCI.BuyDesign.Configurator.Integration.Win.HostServices(sMetaInstance, sDocAutomationApplID, sURL, sAuthKey)
            End If
            integAttrList = {
                    New IntegrationTemplateAttribute With {
                      .Name = "SequenceNo",
                      .DataType = DataType.String,
                      .Description = "Document Sequence Number (1, 2, 3...)"
                     },
                    New IntegrationTemplateAttribute With {
                      .Name = "DocumentName",
                      .DataType = DataType.String,
                      .Description = "SyteLine Document Name"
                     },
                    New IntegrationTemplateAttribute With {
                      .Name = "Description",
                      .DataType = DataType.String,
                      .Description = "SyteLine Document Description "
                     },
                    New IntegrationTemplateAttribute With {
                      .Name = "URL",
                      .DataType = DataType.String,
                      .Description = "Document URL or UNC Path"
                     },
                    New IntegrationTemplateAttribute With {
                      .Name = "InternalFlag",
                      .DataType = DataType.Boolean,
                      .DefaultValue = "=False",
                      .Description = "SyteLine Document Internal Flag"
                     },
                    New IntegrationTemplateAttribute With {
                      .Name = "Revision",
                      .DataType = DataType.String,
                      .Description = "SyteLine Document Revision"
                     },
                    New IntegrationTemplateAttribute With {
                      .Name = "Status",
                      .DataType = DataType.String,
                      .Description = "SyteLine Document Status (Approved, Pending, Rejected) "
                     },
                    New IntegrationTemplateAttribute With {
                      .Name = "StartDate",
                      .DataType = DataType.String,
                      .Description = "SyteLine Document Effectivity State Date ( MM/DD/YYYY)"
                     },
                    New IntegrationTemplateAttribute With {
                      .Name = "EndDate",
                      .DataType = DataType.String,
                      .Description = "SyteLine Document Effectivity End Date (MM/DD/YYYY)"
                     }
                }
            hostServices.SetIntegrationTemplate("SyteLineDocument", "This data is send back to SyteLine and is used to populate the fields on the Documents form.", integAttrList)
        Catch Ex As Exception
            Infobar = "PCM Global Default Test Error: " & Ex.Message
        End Try

        Try

            'PreDefined Component Attributes
            If IDONull.IsNull(sAuthKey) Or sAuthKey = "" Then
                hostServices = New TDCI.BuyDesign.Configurator.Integration.Win.HostServices(sMetaInstance, sConfiguratorApplID, sURL)
            Else
                hostServices = New TDCI.BuyDesign.Configurator.Integration.Win.HostServices(sMetaInstance, sConfiguratorApplID, sURL, sAuthKey)
            End If

            Infobar &= vbNewLine & "PreDefined Component Attributes.."
            hostServices.SetPredefinedComponentAttribute("QueuePostConfiguration", "Queue Post Configuration", True, DataType.Boolean)
            hostServices.SetPredefinedComponentAttribute("QueueType", "Queue Type", True, DataType.String)
            hostServices.SetPredefinedComponentAttribute("SyteLine_Hold", "SyteLine Hold", True, DataType.Boolean)
            hostServices.SetPredefinedComponentAttribute("CSI_BackgroundJobCreation", "Background Job Creation", True, DataType.Boolean)

        Catch Ex As Exception
            Infobar = "PCM Global Default Test Error: " & Ex.Message
        Finally
            hostServices = Nothing
        End Try
        Return 0
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CloneConfiguration _
        (ByVal sApplID As String,
         ByVal vaFromOrderNumber As String,
         ByVal vaFromOrderType As Integer,
         ByVal vaToOrderNumber As String,
         ByVal vaToOrderType As Integer,
         ByRef Infobar As String) As Integer


        Dim sMetadataInstance As String = GetMetadataInstance()
        Dim sAuthenticationKey As String = GetAuthenticationKey()

        If IDONull.IsNull(sAuthenticationKey) Or sAuthenticationKey = "" Then
            hostServices = New TDCI.BuyDesign.Configurator.Integration.Win.HostServices(sMetadataInstance, sApplID, GetConfiguratorURL())
        Else
            hostServices = New TDCI.BuyDesign.Configurator.Integration.Win.HostServices(sMetadataInstance, sApplID, GetConfiguratorURL(), sAuthenticationKey)
        End If

        Try
            hostServices.Copy(vaFromOrderNumber, CStr(vaFromOrderType),
                              vaToOrderNumber, CStr(vaToOrderType), False, False)
        Catch ex As Exception
            IDORuntime.LogUserMessage("CloneConfiguration Exception:",
                                        UserDefinedMessageType.UserDefined0, ex.Message)
            Infobar = ex.Message

        Finally
            hostServices = Nothing

        End Try
        Return 0
    End Function

    '' // This is being called from Portal Configurator UI
    '' // Portal Web Service call to export imports return errors hence created this IDO extension

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ImportConfigurationToShipFromSite _
        (ByVal sInstanceName As String,
         ByVal sApplID As String,
         ByVal sApplIDShipSite As String,
         ByVal sHeaderId As String,
         ByVal sDetailId As String,
         ByRef Infobar As String) As Integer Implements ISLCfgMains.ImportConfigurationToShipFromSite

        Dim origServices As TDCI.BuyDesign.Configurator.Integration.Win.HostServices
        Dim shipFromServices As TDCI.BuyDesign.Configurator.Integration.Win.HostServices
        Dim sXML As String
        Dim sConfigUrl As String = GetConfiguratorURL()
        Dim sAuthenticationKey As String = GetAuthenticationKey()

        If IDONull.IsNull(sAuthenticationKey) Or sAuthenticationKey = "" Then
            origServices = New TDCI.BuyDesign.Configurator.Integration.Win.HostServices(sInstanceName, sApplID, sConfigUrl)
            shipFromServices = New TDCI.BuyDesign.Configurator.Integration.Win.HostServices(sInstanceName, sApplIDShipSite, sConfigUrl)
        Else
            origServices = New TDCI.BuyDesign.Configurator.Integration.Win.HostServices(sInstanceName, sApplID, sConfigUrl, sAuthenticationKey)
            shipFromServices = New TDCI.BuyDesign.Configurator.Integration.Win.HostServices(sInstanceName, sApplIDShipSite, sConfigUrl, sAuthenticationKey)
        End If


        Try

            sXML = origServices.Export(sHeaderId, sDetailId)
            shipFromServices.Delete(sHeaderId, sDetailId)
            shipFromServices.Import(sHeaderId, sDetailId, sXML)
            shipFromServices = Nothing
            origServices = Nothing

        Catch ex As Exception
            Infobar = ex.Message
        End Try
        Return 0
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
        Catch ex As Exception
            GetAuthenticationKey = "ERROR"
            MGException.Throw(MGException.ExtractMessages(ex))
        End Try

    End Function

    Public Function GetDocConfigServer() As String


        Dim oDataReader As IDataReader = Nothing

        GetDocConfigServer = ""
        Try
            Using appDB As ApplicationDB = IDORuntime.Context.CreateApplicationDB()
                ' create a new SqlCommand
                Using cmd As IDbCommand = appDB.CreateCommand()
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT doc_configurator_server_id FROM invparms"

                    Try
                        ' execute the command through the framework
                        oDataReader = appDB.ExecuteReader(cmd)

                    Catch ex As Exception
                        If Not oDataReader Is Nothing AndAlso Not oDataReader.IsClosed Then
                            oDataReader.Close()
                        End If
                        GetDocConfigServer = "ERROR"
                        MGException.Throw(MGException.ExtractMessages(ex))
                    End Try

                    If oDataReader.Read Then
                        GetDocConfigServer = oDataReader.Item("doc_configurator_server_id").ToString
                    Else
                        If Not oDataReader Is Nothing AndAlso Not oDataReader.IsClosed Then
                            oDataReader.Close()
                        End If
                        GetDocConfigServer = "ERROR"
                        MGException.Throw(Me.GetMessageProvider.GetMessage("E=NoExist1", "@!Parameters", "@invparms", "doc_configurator_server_id"))
                    End If
                    If Not oDataReader Is Nothing AndAlso Not oDataReader.IsClosed Then
                        oDataReader.Close()
                    End If
                End Using
            End Using
        Catch ex As Exception
            GetDocConfigServer = "ERROR"
            MGException.Throw(MGException.ExtractMessages(ex))

        End Try

    End Function

    Public Function GetConfiguratorURL() As String


        Dim oDataReader As IDataReader = Nothing

        GetConfiguratorURL = ""
        Try
            Using appDB As ApplicationDB = IDORuntime.Context.CreateApplicationDB()
                ' create a new SqlCommand
                Using cmd As IDbCommand = appDB.CreateCommand()
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT configurator_url FROM invparms"

                    Try
                        ' execute the command through the framework
                        oDataReader = appDB.ExecuteReader(cmd)

                    Catch ex As Exception
                        If Not oDataReader Is Nothing AndAlso Not oDataReader.IsClosed Then
                            oDataReader.Close()
                        End If
                        GetConfiguratorURL = "ERROR"
                        MGException.Throw(MGException.ExtractMessages(ex))
                    End Try

                    If oDataReader.Read Then
                        GetConfiguratorURL = oDataReader.Item("configurator_url").ToString
                    Else
                        If Not oDataReader Is Nothing AndAlso Not oDataReader.IsClosed Then
                            oDataReader.Close()
                        End If
                        GetConfiguratorURL = "ERROR"
                        MGException.Throw(Me.GetMessageProvider.GetMessage("E=NoExist1", "@!Parameters", "@invparms", "configurator_url"))
                    End If
                    If Not oDataReader Is Nothing AndAlso Not oDataReader.IsClosed Then
                        oDataReader.Close()
                    End If
                End Using
            End Using
        Catch ex As Exception
            GetConfiguratorURL = "ERROR"
            MGException.Throw(MGException.ExtractMessages(ex))

        End Try

    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function BDCGetQueuedStatus(
                                  ByVal sApplID As String _
                                , ByVal sKey1 As String _
                                , ByVal sOrderType As String _
                                , ByVal sKey2 As String _
                                , ByVal sConfigID As String _
                                , ByVal sSessionID As String _
                                , ByVal sSite As String _
                                , ByVal sQueuePostProcess As String _
                                , ByRef sReturnValue As String) As Integer Implements ISLCfgMains.BDCGetQueuedStatus

        Dim vStatusID As Integer = 3
        Dim vInfobar As String = ""
        Dim vStatus As String = ""
        Dim ConfigurationSummary As TDCI.BuyDesign.Configurator.Integration.Data.ConfigurationSummary
        Dim Response As InvokeResponseData

        If IsNumeric(sKey1) Then
            While Len(sKey1) < 10
                sKey1 = " " + sKey1
                sSessionID = " " + sSessionID
            End While
        End If

        Dim sMetadataInstance As String = GetMetadataInstance()
        Dim sAuthenticationKey As String = GetAuthenticationKey()
        If IDONull.IsNull(sReturnValue) Or sReturnValue = "" Then
            sReturnValue = "0"
        End If
        If IDONull.IsNull(sAuthenticationKey) Or sAuthenticationKey = "" Then
            hostServices = New TDCI.BuyDesign.Configurator.Integration.Win.HostServices(sMetadataInstance, sApplID, GetConfiguratorURL())
        Else
            hostServices = New TDCI.BuyDesign.Configurator.Integration.Win.HostServices(sMetadataInstance, sApplID, GetConfiguratorURL(), sAuthenticationKey)
        End If

        Try
            vStatusID = hostServices.GetQueuedStatus(sQueuePostProcess)

        Catch ex As Exception
            vInfobar = ex.Message
        End Try

        Select Case vStatusID
            Case 0 : vStatus = "P"
            Case 1 : vStatus = "R"
            Case 2 : vStatus = "C"
            Case 3 : vStatus = "E"
            Case 4 : vStatus = "H"
            Case 5 : vStatus = "N"
        End Select

        'Updated
        Try

            If vStatus = "E" Then
                If hostServices.Exists(sSessionID, CStr(sKey2)) = True Then
                    ConfigurationSummary = hostServices.Load(sSessionID, CStr(sKey2))
                Else
                    ConfigurationSummary = Nothing
                End If

                vInfobar = ConfigurationSummary.Message
            End If

            Me.Context.Commands.Invoke("SLCfgMains", "UpdateCfgStatusSp", sConfigID, vStatus, vInfobar, "")

            If vStatusID = 2 Then
                'hostServices.ExecuteExtension _
                '            ("MapConfigurationData", New String() {sKey1, sOrderType, sKey2, sConfigID, sSessionID, sSite})
                Response = Me.Context.Commands.Invoke("SLCfgMains", "CfgMapConfigurationData",
                    sKey1, CInt(sKey2), sOrderType, sConfigID, sKey2, sApplID,
                    GetConfigurator(), sSite,
                    GetConfiguratorURL(), vInfobar, sSessionID)

                ' testing shows that Response.IsReturnValueStdError() = True fires the catch and this never executes.
                If Response.IsReturnValueStdError() = True Then
                    vStatus = "E"
                    If Response.Parameters(9).IsNull Then
                        vInfobar = "ERROR: SLCfgMains.MapConfigurationData, Infobar IS NULL"
                    Else
                        vInfobar = "MapConfigurationData Error: " + Response.Parameters(9).GetValue(Of String)()
                    End If

                    Me.Context.Commands.Invoke("SLCfgMains", "UpdateCfgStatusSp", sConfigID, vStatus, vInfobar, "")
                    sReturnValue = "1" 'skip BDCCreateJobSp call
                End If

                If Not Response.Parameters(9).IsNull Then
                    vInfobar = Response.Parameters(9).GetValue(Of String)()
                    Me.Context.Commands.Invoke("SLCfgMains", "UpdateCfgStatusSp", sConfigID, vStatus, vInfobar, "")
                    Return -1
                End If

                If sReturnValue = "0" Then
                    ' skip any IPN's
                    Response = Me.Context.Commands.Invoke("SLCfgMains", "BDCCreateJobSp", sConfigID, sOrderType, vInfobar)

                    If Response.IsReturnValueStdError() = True Then
                        vStatus = "E"
                        If Response.Parameters(2).IsNull Then
                            vInfobar = "ERROR: SLCfgMains.BDCCreateJobSp, Infobar IS NULL"
                        Else
                            vInfobar = "BDCCreateJobSp Error: " + Response.Parameters(2).GetValue(Of String)()
                        End If

                        Me.Context.Commands.Invoke("SLCfgMains", "UpdateCfgStatusSp", sConfigID, vStatus, vInfobar, "")
                    End If
                End If

                sReturnValue = "1"
            End If
        Catch ex As Exception
            vInfobar = Err.Description.ToString
            If vInfobar.Length = 0 Then
                vInfobar = "Exception: BDCGetQueuedStatus Failed"
            Else
                vInfobar = "Exception in BDCGetQueuedStatus: " + vInfobar
            End If
            Me.Context.Commands.Invoke("SLCfgMains", "UpdateCfgStatusSp", sConfigID, "E", vInfobar, "")

            Return -1
        Finally
            If Not hostServices Is Nothing Then hostServices = Nothing
        End Try
        Return 0
    End Function


#Region "MapConfiguration"

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Sub CfgMapConfigurationData(ByVal sOrderNum As String,
                                       ByVal sOrderLine As Integer,
                                       ByVal sOrderType As String,
                                       ByVal sTargetConfigId As String,
                                       ByVal sDetailId As String,
                                       ByVal sGlobalConfigServerId As String,
                                       ByVal sGlobalConfigurator As String,
                                       ByVal sGlobalParmSite As String,
                                       ByVal sGlobalConfiguratorURL As String,
                                       ByRef InfoBar As String,
                                       ByVal sSessionId As String) Implements ISLCfgMains.CfgMapConfigurationData

        If sGlobalConfigServerId Is Nothing Then sGlobalConfigServerId = ""
        If sGlobalConfigurator Is Nothing Then sGlobalConfigurator = ""

        ' Configuration Parameters
        targetConfigId = sTargetConfigId
        'Dim sHeaderId As String = sOrderNum & "-" & sOrderType & "-" & sGlobalParmSite
        Dim sHeaderId As String = sSessionId
        Dim sConfigHdrNameSpace As String = ""
        Dim sConfigurator As String = ""
        Dim sConfiguratorURL As String = ""
        Dim sMetadataInstance As String = ""
        Dim sAuthenticationKey As String = ""
        Dim Response As InvokeResponseData
        Dim sApplID As String = ""
        sSite = sGlobalParmSite
        subConfigList = New List(Of KeyValuePair(Of String, String))
        Dim errTrk As String

        errTrk = "Start Try"

        Try
            errTrk = "GetMetadataInstance"
            sMetadataInstance = GetMetadataInstance()
            errTrk = "GetAuthenticationKey"
            sAuthenticationKey = GetAuthenticationKey()

            errTrk = "TDCI.BuyDesign.Configurator.Integration.Win.HostServices"
            Dim hostServices As TDCI.BuyDesign.Configurator.Integration.Win.HostServices
            errTrk = "TDCI.BuyDesign.Configurator.Integration.Data.Outputs.Configuration"
            Dim theConfiguration As TDCI.BuyDesign.Configurator.Integration.Data.Outputs.Configuration

            errTrk = "theConfigurationSummary"
            Dim theConfigurationSummary As TDCI.BuyDesign.Configurator.Integration.Data.ConfigurationSummary

            errTrk = "GetCfgParmsSp"
            ' Get Configuration Parameters
            If sGlobalConfigurator = "" Then
                Response = Me.Context.Commands.Invoke("SL.SLCfgMains", "GetCfgParmsSp",
                               sApplID, sConfigHdrNameSpace, sConfigurator, sConfiguratorURL, sMetadataInstance, sAuthenticationKey, sGlobalParmSite)

                If Response.Parameters(0).IsNull Then
                    sApplID = ""
                Else
                    sApplID = Response.Parameters(0).GetValue(Of String)()
                End If
                If Response.Parameters(1).IsNull Then
                    sConfigHdrNameSpace = ""
                Else
                    sConfigHdrNameSpace = Response.Parameters(1).GetValue(Of String)()
                End If
                If Response.Parameters(2).IsNull Then
                    sConfigurator = "N"
                Else
                    sConfigurator = Response.Parameters(2).GetValue(Of String)()
                End If
                If Response.Parameters(3).IsNull Then
                    sConfiguratorURL = ""
                Else
                    sConfiguratorURL = Response.Parameters(3).GetValue(Of String)()
                End If
                If Response.Parameters(4).IsNull Then
                    sMetadataInstance = ""
                Else
                    sMetadataInstance = Response.Parameters(4).GetValue(Of String)()
                End If
                If Response.Parameters(5).IsNull Then
                    sAuthenticationKey = ""
                Else
                    sAuthenticationKey = Response.Parameters(5).GetValue(Of String)()
                End If

            Else
                sApplID = sGlobalConfigServerId
                sConfiguratorURL = sGlobalConfiguratorURL
            End If

            errTrk = "hostServices"
            If IDONull.IsNull(sAuthenticationKey) Or sAuthenticationKey = "" Then
                hostServices = New TDCI.BuyDesign.Configurator.Integration.Win.HostServices(sMetadataInstance, sApplID, sConfiguratorURL)
            Else
                hostServices = New TDCI.BuyDesign.Configurator.Integration.Win.HostServices(sMetadataInstance, sApplID, sConfiguratorURL, sAuthenticationKey)
            End If

            errTrk = "hostServices.Exists"
            theConfiguration = New TDCI.BuyDesign.Configurator.Integration.Data.Outputs.Configuration()
            If hostServices.Exists(sHeaderId, sDetailId) = True Then
                theConfiguration = hostServices.LoadFullConfiguration(sHeaderId, sDetailId)
                theConfigurationSummary = hostServices.Load(sHeaderId, sDetailId)
            Else
                theConfiguration = Nothing
                theConfigurationSummary = Nothing
                InfoBar = "Programmer Error: theConfiguration Is Nothing, Abort CfgMapConfigurationData.  Check HeaderId and DetailId."
                Return
            End If

            errTrk = "SetupParams"
            SetupParams(theConfiguration, theConfigurationSummary, sOrderType, sOrderNum, sOrderLine)

            errTrk = "DeleteCfgDataIfExists"
            DeleteCfgDataIfExists(InfoBar)

            errTrk = "CfgSchemaAttributeFields"
            'Load the contents of the CfgSchemaAttributeFields view into a DataTable 
            ' to be used later in CheckCfgSchemaAttributeFields procedure
            dtCfgSchemaAttributeFields.Dispose()
            Using appDB As ApplicationDB = IDORuntime.Context.CreateApplicationDB() 'get appDb class
                Using cmd As IDbCommand = appDB.CreateCommand()
                    cmd.CommandText = "SELECT [TableName]" & "+ '.' +" & "[FieldName] AS ValidAttributeEntry FROM [dbo].[CfgSchemaAttributeFields]"
                    Dim dr As IDataReader = appDB.ExecuteReader(cmd)
                    dtCfgSchemaAttributeFields = ConvertDataReaderToDataTable(dr)
                    If dr IsNot Nothing AndAlso Not dr.IsClosed Then
                        dr.Close()
                        dr.Dispose()
                    End If
                End Using
            End Using

            errTrk = "InsertTopLevelComponentIntoCfgMain"
            InsertTopLevelComponentIntoCfgMain(theConfigurationSummary,
                                               theConfiguration.ConfigurationId,
                                               sOrderType)

            errTrk = "PopulateSubComponents"
            subConfigurationMapList = New List(Of SubConfigurationMap)
            PopulateSubComponents(theConfiguration)

            errTrk = "InsertConfiguredComponentsIntoCfgMain"
            If sOrderType = "1" Or sOrderType = "2" Or sOrderType = "101" Or sOrderType = "102" Then
                InsertConfiguredComponentsIntoCfgMain(theConfiguration, sOrderType)
            End If

            errTrk = "InsertIntoCfgRef"
            InsertIntoCfgRef(theConfiguration)

            errTrk = "InsertMaterialsIntoCfgComp"
            InsertMaterialsIntoCfgComp(theConfiguration)

            errTrk = "InsertMaterialAttributes"
            InsertMaterialAttributes(theConfiguration)

            errTrk = "InsertRoutings"
            InsertRoutings(theConfiguration)

            errTrk = "InsertPricingAndOrderDetails"
            InsertPricingAndOrderDetails(theConfiguration)

            errTrk = "InsertConfigurationCode"
            InsertConfigurationCode(theConfiguration)

            errTrk = "InsertTotalPrice"
            InsertTotalPrice(theConfiguration)

            errTrk = "InsertDocumentInfofromPCMIntegrationRule"
            InsertDocumentInfofromPCMIntegrationRule(theConfiguration)

            errTrk = "InsertDocumentInfoForMfgDetailRule"
            InsertDocumentInfoForMfgDetailRule(theConfiguration)

            errTrk = "InsertSytelineHold"
            InsertSytelineHold(theConfiguration)

            errTrk = "InsertQueuePostConfiguration"
            InsertQueuePostConfiguration(theConfiguration)

            errTrk = "InsertShipSite"
            InsertShipSite(sOrderNum, sOrderLine, sConfig_type, "", InfoBar)

            errTrk = "InsertCSIBackgroundJobCreationControl"
            InsertCSIBackgroundJobCreationControl(theConfiguration)

            errTrk = "PostInsertCSIBackgroundJobCreationControl"

        Catch Ex As Exception
            InfoBar = ""
            Response = Me.Context.Commands.Invoke("ApplicationMessages", "MsgAppSp",
                       InfoBar, "E=CmdFailed", "CfgMapConfigurationData." & errTrk, "",
                       "", "", "", "", "", "", "", "", "", "", "", "", "")
            InfoBar = Response.Parameters(0).Value & Chr(13) & Ex.Message
            Throw New MGException(InfoBar)

        End Try

    End Sub

    Private Sub InsertCSIBackgroundJobCreationControl(ByVal theConfiguration As Outputs.Configuration)
        Dim sBackgroundJobCreation As String = String.Empty
        Dim sBackgroundJobCreationValue As String = "0"
        Dim sCfgCompXMLString As String = String.Empty
        Dim sCfgAttrXMLString As String = String.Empty
        Dim vInfobar As String = String.Empty
        Dim sCompId As String = String.Empty
        Dim oCult As CultureInfo = CultureInfo.CurrentUICulture

        For Each mco As Outputs.Component In theConfiguration.Components
            For Each v As Outputs.ComponentAttribute In mco.ComponentAttributes
                If v.Name = "CSI_BackgroundJobCreation" Then
                    sBackgroundJobCreation = targetConfigId
                    sCompId = mco.Id
                    If v.Value.ValueAsBool = True Then
                        sBackgroundJobCreationValue = "1"
                    End If
                    Exit For
                End If
            Next
        Next

        If Not String.IsNullOrEmpty(sBackgroundJobCreation) Then
            InsertCfgCompRecord(targetConfigId, "BG" & sCompId, "BackgroundJobCreation", "Cntrl", "", 0, 0, targetConfigId, "I", 0, 0, 0, sCfgCompXMLString, oCult)
            InsertCfgAttrRecord(targetConfigId, "BG" & sCompId, "BackgroundJobCreation", sBackgroundJobCreationValue, "String", "", targetConfigId, "I", sCfgAttrXMLString)
        End If

        If Not String.IsNullOrEmpty(sCfgCompXMLString) Then
            Me.Context.Commands.Invoke("SLCfgMains", "CfgMapConfigurationDataWriteXMLSp", "cfg_comp", sCfgCompXMLString, vInfobar)
        End If
        If Not String.IsNullOrEmpty(sCfgAttrXMLString) Then
            Me.Context.Commands.Invoke("SLCfgMains", "CfgMapConfigurationDataWriteXMLSp", "cfg_attr", sCfgAttrXMLString, vInfobar)
        End If

    End Sub

    Private Function ConvertDataReaderToDataTable(ByVal reader As IDataReader) As DataTable
        Dim objDataTable As New DataTable
        Dim intFieldCount As Integer = reader.FieldCount
        Dim intCounter As Integer
        For intCounter = 0 To intFieldCount - 1
            objDataTable.Columns.Add(reader.GetName(intCounter), reader.GetFieldType(intCounter))
        Next intCounter

        objDataTable.BeginLoadData()
        Dim objValues(intFieldCount - 1) As Object
        While reader.Read()
            reader.GetValues(objValues)
            objDataTable.LoadDataRow(objValues, True)
        End While
        reader.Close()
        objDataTable.EndLoadData()

        Return objDataTable

    End Function

    Private Sub SetupParams(ByVal theConfiguration As Outputs.Configuration,
                            ByVal theConfigurationSummary As ConfigurationSummary,
                            ByVal sOrderType As String,
                            ByVal sOrderNum As String,
                            ByVal sOrderLine As Integer)

        sConfig_type = ""
        sJob = ""
        iSuffix = 0
        sCoNum = ""
        iCoLine = 0
        Dim oCult As New CultureInfo("en-US")
        dBasePrice = Convert.ToDecimal("0", oCult)

        Dim theBomComp As TDCI.BuyDesign.Configurator.Integration.Data.Outputs.BomComponent

        sConfig_status = "C"

        Select Case sOrderType
            Case "1"
                sConfig_type = "COLine"
                sCoNum = sOrderNum
                iCoLine = sOrderLine
            Case "2"
                sConfig_type = "EstimateLine"
                sCoNum = sOrderNum
                iCoLine = sOrderLine
            Case "101"
                sConfig_type = "Job"
                sJob = sOrderNum
                iSuffix = sOrderLine
            Case "102"
                sConfig_type = "EstimateJob"
                sJob = sOrderNum
                iSuffix = sOrderLine
            Case "103"
                sConfig_type = "CustomerOrder"
                sCoNum = sOrderNum
                iCoLine = sOrderLine
            Case "104"
                sConfig_type = "Estimate"
                sCoNum = sOrderNum
                iCoLine = sOrderLine
            Case "105"
                sConfig_type = "COBlanketLine"
                sCoNum = sOrderNum
                iCoLine = sOrderLine
        End Select

        dBasePrice = GetConfiguredPrice(theConfigurationSummary, oCult)

        If theConfiguration.BomComponents.Count() > 0 Then
            For Each theBomComp In theConfiguration.BomComponents
                If theBomComp.ParentId.ToString = "" Then
                    lParentConfigurationID = theBomComp.Id
                    Exit For
                End If
            Next
        End If

        sItem = theConfigurationSummary.InputParameters.PartNumber

    End Sub

    Private Function GetConfiguredPrice(ByVal configurationSummary As ConfigurationSummary, ByRef oCult As CultureInfo) As Decimal
        Dim parameter As CommitParameter = Nothing
        Dim suceed As Boolean = False

        suceed = configurationSummary.CommitParameters.TryGetValue("ConfiguredPrice", parameter)
        If suceed = False Then
            GetConfiguredPrice = Convert.ToDecimal("0", oCult)
        Else
            ' convert.todecimal(parameter, ocult) fails with the following error:
            ' unable to cast object of type 'tdci.buydesign.configurator.integration.data.commitparameter' 
            ' to type 'system.iconvertible'.
            GetConfiguredPrice = Convert.ToDecimal(parameter.ValueAsDecimal, oCult)
        End If
    End Function

    Private Sub InsertConfiguredComponentsIntoCfgMain(ByVal theConfiguration As Outputs.Configuration,
                                                      ByVal sOrderType As String)

        Dim updateRequest As UpdateCollectionRequestData
        Dim updateItem As IDOUpdateItem

        For Each scm In subConfigurationMapList
            If scm.ComponentId <> lParentConfigurationID Then
                updateRequest = New UpdateCollectionRequestData With {
                    .IDOName = "SLCfgMains",
                    .RefreshAfterUpdate = True
                }

                updateItem = New IDOUpdateItem With {
                    .Action = UpdateAction.Insert,
                    .ItemNumber = 1
                }

                updateItem.Properties.Add("ConfigId", scm.ConfigId)
                updateItem.Properties.Add("ConfigType", GetConfigTypeForCfgMainConfiguredComponents(sOrderType))
                updateItem.Properties.Add("ConfigStatus", sConfig_status)
                updateItem.Properties.Add("ConfigGid", targetConfigId)
                updateItem.Properties.Add("ConfigModel", scm.ConfigModel)
                updateItem.Properties.Add("ConfigDate", DateTime.Now)
                updateItem.Properties.Add("Item", scm.Item)
                'updateItem.Properties.Add("Job", Job)
                updateItem.Properties.Add("Suffix", 0)
                'updateItem.Properties.Add("CoNum", CoNum)
                updateItem.Properties.Add("CoLine", 0)
                updateItem.Properties.Add("CoRelease", 0)
                updateItem.Properties.Add("TrnNum", "")
                updateItem.Properties.Add("TrnLine", 0)
                updateItem.Properties.Add("DoPricing", 0)
                updateItem.Properties.Add("UseModelPrice", 0)
                updateItem.Properties.Add("BasePrice", 0)

                updateRequest.Items.Add(updateItem)
                Me.Context.Commands.UpdateCollection(updateRequest)
                updateRequest = Nothing
                updateItem = Nothing
            End If
        Next
    End Sub

    Public Function NextCfgId() As String
        Dim tempResult As String = String.Empty

        Dim invokeRequest As New InvokeRequestData()
        Dim invokeResponse As New InvokeResponseData()

        invokeRequest.IDOName = "SlCfgMains"
        invokeRequest.MethodName = "CfgNextCfgIdSp"
        invokeRequest.Parameters = New InvokeParameterList From {
            New InvokeParameter(tempResult),
            New InvokeParameter(String.Empty)
        }

        invokeResponse = Me.Context.Commands.Invoke(invokeRequest)

        Try
            If invokeResponse.IsReturnValueStdError() = False Then
                tempResult = invokeResponse.Parameters.Item(0).GetValue(Of String)()
            End If
        Catch ex As Exception
            tempResult = ""
        End Try

        NextCfgId = tempResult
        invokeRequest = Nothing
        invokeResponse = Nothing
    End Function

    Private Sub InsertIntoCfgRef(ByVal theConfiguration As Outputs.Configuration)

        'Dim theBomComp As TDCI.BuyDesign.Configurator.Integration.Data.Outputs.BomComponent
        'Dim theBomCompMCO As TDCI.BuyDesign.Configurator.Integration.Data.Outputs.BomComponent
        Dim sConfigId As String = ""
        'Dim sCompNum As String

        Dim sCfgRefXMLString As String = ""
        Dim vInfobar As String = ""

        ' Find BOM components with an attribute of "Part Number"
        For Each M In theConfiguration.BomComponents
            If M.IsComponent = True And M.ParentId.ToString() <> "" Then
                For Each MCO In theConfiguration.BomComponents
                    If M.ParentId = MCO.Id Then
                        For Each scMap In subConfigurationMapList
                            If scMap.ComponentId = M.Id Then
                                If M.ParentId = lParentConfigurationID Then
                                    sConfigId = targetConfigId
                                Else
                                    Dim scParent As SubConfigurationMap = subConfigurationMapList.Where(Function(x) x.ComponentId = MCO.Id).FirstOrDefault()
                                    If IsNothing(scParent) = False Then
                                        sConfigId = scParent.ConfigId
                                    End If
                                End If

                                InsertCfgRefRecord(sConfigId, scMap.ConfigId, sCfgRefXMLString)
                            End If
                        Next
                    End If
                Next
            End If
        Next

        If sCfgRefXMLString <> "" Then
            Me.Context.Commands.Invoke("SLCfgMains", "CfgMapConfigurationDataWriteXMLSp", "cfg_ref", sCfgRefXMLString, vInfobar)
        End If
    End Sub

    Private Sub InsertMaterialsIntoCfgComp(ByVal theConfiguration As Outputs.Configuration)

        Dim sConfigId As String = ""
        Dim sCompId As String = ""
        Dim sCompName As String = ""
        Dim sCompType As String = ""
        Dim sCompNum As String = ""
        Dim dQuantity As Decimal = 0
        Dim dPrice As Decimal = 0
        Dim sPrintFlag As String = ""
        Dim sOperNum As String = ""
        Dim sSequence As String = ""
        Dim sNewLine As String = ""
        Dim sub_cfg_gid As String = ""

        Dim sCfgCompXMLString As String = ""
        Dim sCfgAttrXMLString As String = ""
        Dim vInfobar As String = ""
        Dim oCult As New CultureInfo("en-US")

        If theConfiguration.BomComponents.Count > 0 Then
            For Each M As Outputs.BomComponent In theConfiguration.BomComponents
                If M.ParentId <> 0 Or IsNothing(M.ParentId) = False Then
                    For Each MCO As Outputs.BomComponent In theConfiguration.BomComponents
                        If M.ParentId = MCO.Id Then
                            sConfigId = MCO.Id.ToString()
                            sub_cfg_gid = MCO.Id
                            If sConfigId = lParentConfigurationID.ToString() Then
                                sConfigId = targetConfigId
                            Else
                                Dim sc As SubConfigurationMap = subConfigurationMapList.Where(Function(x) x.ComponentId = MCO.Id).FirstOrDefault()
                                If IsNothing(sc) = False Then
                                    sConfigId = sc.ConfigId
                                End If
                            End If
                            Exit For
                        Else
                        End If
                    Next

                    sCompId = "M" & M.Id.ToString()

                    sNewLine = "0"
                    For Each MAC As Outputs.Attribute In M.Attributes
                        If MAC.Name = "Create New Line" Then
                            sNewLine = MAC.Value.ValueAsString()
                            If sNewLine = "" Then
                                sNewLine = "0"
                            End If
                            Exit For
                        End If
                    Next

                    sCompName = ""
                    For Each MAC7 As Outputs.Attribute In M.Attributes
                        If MAC7.Name = "Description" Then
                            sCompName = MAC7.Value.ValueAsString()
                            Exit For
                        End If
                    Next

                    sCompNum = ""
                    For Each MAC2 As Outputs.Attribute In M.Attributes
                        If MAC2.Name = "Part Number" Then
                            sCompNum = MAC2.Value.ValueAsString()
                            Exit For
                        End If
                    Next

                    sCompType = "Matl"

                    If sCompName = "" Or IsNothing(sCompName) Then
                        sCompName = sCompNum
                    End If

                    dQuantity = Convert.ToDecimal("0", oCult)
                    For Each MAC3 As Outputs.Attribute In M.Attributes
                        If MAC3.Name = "Quantity" Then
                            If MAC3.Value.IsNull = True Or MAC3.Value.ValueAsString() = "" Then
                                dQuantity = Convert.ToDecimal("0", oCult)
                            Else
                                dQuantity = Convert.ToDecimal(MAC3.Value.ValueAsString(), oCult)
                            End If
                            Exit For
                        End If
                    Next

                    dPrice = Convert.ToDecimal("0", oCult)
                    For Each MAP As Outputs.Attribute In M.Attributes
                        If MAP.Name = "Price" Then
                            If MAP.Value.IsNull = True Or MAP.Value.ValueAsString() = "" Then
                                dPrice = Convert.ToDecimal("0", oCult)
                            Else
                                dPrice = Convert.ToDecimal(MAP.Value.ValueAsString(), oCult)
                            End If
                            Exit For
                        End If
                    Next

                    sPrintFlag = ""
                    For Each MAC4 As Outputs.Attribute In M.Attributes
                        If MAC4.Name = "Print Code" Then
                            sPrintFlag = MAC4.Value.ValueAsString()
                            Exit For
                        End If
                    Next

                    If sPrintFlag <> "I" Then
                        sPrintFlag = "E"
                    End If

                    sOperNum = M.ConsumedOperationNo

                    sSequence = ""
                    For Each MAC5 As Outputs.Attribute In M.Attributes
                        If MAC5.Name = "Material Sequence" Then
                            sSequence = MAC5.Value.ValueAsString()
                            Exit For
                        End If
                    Next
                    If sSequence = "" Or IsNothing(sSequence) Then
                        For Each MAC6 As Outputs.Attribute In M.Attributes
                            If MAC6.Name = "Material Sequence" Then
                                sSequence = MAC6.Value.ValueAsString()
                                Exit For
                            End If
                        Next
                    End If
                    If sSequence = "" Or IsNothing(sSequence) Then
                        sSequence = "0"
                    End If

                    For Each MAC As Outputs.Attribute In M.Attributes
                        If MAC.Name = "Create New Line" Then
                            sNewLine = MAC.Value.ValueAsString()
                            Exit For
                        End If
                    Next

                    sub_cfg_gid = ""
                    For Each scScfg As SubConfigurationMap In subConfigurationMapList
                        If scScfg.ComponentId = M.Id Then
                            sub_cfg_gid = scScfg.ConfigId
                        End If
                    Next

                    InsertCfgCompRecordMat(sConfigId _
                                        , sCompId _
                                        , sCompName _
                                        , sCompNum _
                                        , dQuantity _
                                        , dPrice _
                                        , sPrintFlag _
                                        , sOperNum _
                                        , CInt(sSequence) _
                                        , sNewLine _
                                        , sub_cfg_gid _
                                        , sCfgCompXMLString _
                                        , oCult)

                End If
            Next

            sConfigId = ""
            sCompId = ""
            sPrintFlag = ""
            Dim sAttrName As String = ""
            Dim sAttrValue As String = ""
            Dim sAttrType As String = ""
            Dim slField As String = ""

            'description
            For Each M As Outputs.BomComponent In theConfiguration.BomComponents
                If M.ParentId <> 0 Or IsNothing(M.ParentId) = False Then
                    sConfigId = ""
                    For Each MCO As Outputs.BomComponent In theConfiguration.BomComponents
                        If M.ParentId = MCO.Id Then
                            sConfigId = MCO.Id.ToString()
                            sub_cfg_gid = MCO.Id

                            If sConfigId = lParentConfigurationID.ToString() Then
                                sConfigId = targetConfigId
                            Else
                                Dim sc As SubConfigurationMap = subConfigurationMapList.Where(Function(x) x.ComponentId = M.Id).FirstOrDefault()
                                If IsNothing(sc) = False Then
                                    sConfigId = sc.ConfigId
                                Else
                                    sc = subConfigurationMapList.Where(Function(x) x.ComponentId = M.ParentId).FirstOrDefault()
                                    If IsNothing(sc) = False Then
                                        sConfigId = sc.ConfigId
                                    End If
                                End If
                            End If

                            Exit For
                        End If
                    Next

                    sCompId = "M" & M.Id.ToString()

                    sAttrName = "Description"

                    sAttrValue = ""
                    For Each MAC As Outputs.Attribute In M.Attributes
                        If MAC.Name = "Description" Then
                            sAttrValue = MAC.Value.ValueAsString()
                            Exit For
                        End If
                    Next

                    If sAttrValue = "" Or IsNothing(sAttrName) Then
                        'sAttrValue = M.ComponentName
                        ' Value must be loaded from item using MAC3.PartNumber.Value
                        Dim sPartNumber As String = ""
                        For Each MAC3 As Outputs.Attribute In M.Attributes
                            If MAC3.Name = "Part Number" Then
                                sPartNumber = MAC3.Value.ValueAsString()
                                Exit For
                            End If
                        Next
                        sAttrValue = GetCorrespondingItem(sPartNumber)
                    End If

                    sAttrType = "Schema"
                    slField = "jobmatl.description"

                    For Each MAC2 As Outputs.Attribute In M.Attributes
                        If MAC2.Name = "Print Code" Then
                            sPrintFlag = MAC2.Value.ValueAsString()
                            Exit For
                        End If
                    Next

                    InsertCfgAttrRecord(sConfigId _
                                        , sCompId _
                                        , sAttrName _
                                        , sAttrValue _
                                        , sAttrType _
                                        , slField _
                                        , targetConfigId _
                                        , sPrintFlag _
                                        , sCfgAttrXMLString)
                End If
            Next

            'price type
            sConfigId = ""
            sCompId = ""
            For Each M As Outputs.BomComponent In theConfiguration.BomComponents
                If M.ParentId <> 0 Or IsNothing(M.ParentId) = False Then
                    sConfigId = ""
                    For Each MCO As Outputs.BomComponent In theConfiguration.BomComponents
                        If M.ParentId = MCO.Id Then
                            sConfigId = MCO.Id.ToString()

                            If sConfigId = lParentConfigurationID.ToString() Then
                                sConfigId = targetConfigId
                            Else
                                Dim sc As SubConfigurationMap = subConfigurationMapList.Where(Function(x) x.ComponentId = MCO.Id).FirstOrDefault()
                                If IsNothing(sc) = False Then
                                    sConfigId = sc.ConfigId
                                End If
                            End If
                            Exit For
                        End If
                    Next

                    sCompId = "M" & M.Id.ToString()

                    InsertCfgAttrRecord(sConfigId _
                                        , sCompId _
                                        , "PriceType" _
                                        , "Amount" _
                                        , "String" _
                                        , "" _
                                        , targetConfigId _
                                        , "I" _
                                        , sCfgAttrXMLString)
                End If
            Next
        End If

        If sCfgCompXMLString <> "" Then
            Me.Context.Commands.Invoke("SLCfgMains", "CfgMapConfigurationDataWriteXMLSp", "cfg_comp", sCfgCompXMLString, vInfobar)
        End If
        If sCfgAttrXMLString <> "" Then
            Me.Context.Commands.Invoke("SLCfgMains", "CfgMapConfigurationDataWriteXMLSp", "cfg_attr", sCfgAttrXMLString, vInfobar)
        End If
    End Sub

    Private Sub InsertRoutings(ByVal theConfiguration As Outputs.Configuration)

        Dim O As Outputs.Operation
        Dim MCO As Outputs.BomComponent

        Dim sConfigId As String
        Dim sCompId As String
        Dim sPrintFlag As String
        Dim sAttrGid As String
        Dim sAttrName As String
        Dim sAttrValue As String
        Dim sAttrType As String
        Dim sSlField As String

        Dim sCfgCompXMLString As String = ""
        Dim sCfgAttrXMLString As String = ""
        Dim vInfobar As String = ""
        Dim oCult As New CultureInfo("en-US")

        If theConfiguration.BomComponents.Count > 0 Then
            For Each MCO In theConfiguration.BomComponents
                For Each O In MCO.Operations
                    If O.BomComponenetId = MCO.Id Then

                        If MCO.Id = lParentConfigurationID Then
                            sConfigId = targetConfigId
                        Else
                            ' subconfig
                            sConfigId = ""
                            Dim sc As SubConfigurationMap = subConfigurationMapList.Where(Function(x) x.ComponentId = MCO.Id).FirstOrDefault()
                            If IsNothing(sc) = False Then
                                sConfigId = sc.ConfigId
                            End If
                        End If

                        sCompId = "R" & O.Id.ToString()

                        sAttrName = "Description"

                        sAttrValue = ""
                        For Each OA As Outputs.Attribute In O.Attributes
                            If OA.Name = "Operation Description" Then
                                sAttrValue = OA.Value.ValueAsString
                                Exit For
                            End If
                        Next
                        If sAttrValue = "" Then
                            For Each OA As Outputs.Attribute In O.Attributes
                                If OA.Name = "Operation Name" Then
                                    sAttrValue = OA.Value.ValueAsString
                                    Exit For
                                End If
                            Next
                        End If


                        sAttrType = "String"
                        sSlField = "jobroute.description"
                        sAttrGid = targetConfigId.ToString()

                        sPrintFlag = "I"
                        For Each OA As Outputs.Attribute In O.Attributes
                            If OA.Name = "Print Code" Then
                                If OA.Value.ValueAsString = "E" Then
                                    sPrintFlag = OA.Value.ValueAsString
                                End If
                                Exit For
                            End If
                        Next

                        InsertCfgCompRecord(sConfigId _
                                            , sCompId _
                                            , sAttrValue _
                                            , "Oper" _
                                            , O.OperationNo _
                                            , Convert.ToDecimal("1", oCult) _
                                            , Convert.ToDecimal("0", oCult) _
                                            , targetConfigId _
                                            , sPrintFlag _
                                            , O.OperationNo _
                                            , 0 _
                                            , "0" _
                                            , sCfgCompXMLString _
                                            , oCult)

                        ' Description
                        InsertCfgAttrRecord(sConfigId _
                                            , sCompId _
                                            , sAttrName _
                                            , sAttrValue _
                                            , sAttrType _
                                            , sSlField _
                                            , targetConfigId _
                                            , sPrintFlag _
                                            , sCfgAttrXMLString)
                        ' Setup
                        sAttrValue = ""
                        For Each OA As Outputs.Attribute In O.Attributes
                            If OA.Name = "Setup Time" And OA.Value.IsNull = False Then
                                sAttrValue = OA.Value.ValueAsString
                                Exit For
                            End If
                        Next
                        If sAttrValue <> "" Then
                            InsertCfgAttrRecord(sConfigId _
                                                , sCompId _
                                                , "Setup" _
                                                , sAttrValue _
                                                , "Schema" _
                                                , "jobroute.setup_hrs_v" _
                                                , targetConfigId _
                                                , sPrintFlag _
                                                , sCfgAttrXMLString)
                        End If
                        ' Work Center
                        sAttrValue = ""
                        For Each OA As Outputs.Attribute In O.Attributes
                            If OA.Name = "Work Center ID" And OA.Value.IsNull = False Then
                                sAttrValue = OA.Value.ValueAsString
                                Exit For
                            End If
                        Next
                        InsertCfgAttrRecord(sConfigId _
                                            , sCompId _
                                            , "WorkCenter" _
                                            , sAttrValue _
                                            , "String" _
                                            , "" _
                                            , targetConfigId _
                                            , sPrintFlag _
                                            , sCfgAttrXMLString)

                        ' Work Instruction
                        If O.WorkInstructions.Count > 0 Then
                            For Each W As Outputs.WorkInstruction In O.WorkInstructions
                                For Each WIA As Outputs.Attribute In W.Attributes
                                    If WIA.Name = "Description" And WIA.Value.IsNull = False Then
                                        Dim sWPrintFlag As String = ""
                                        For Each WIA2 As Outputs.Attribute In W.Attributes
                                            If WIA2.Name = "Print Code" Then
                                                sWPrintFlag = WIA2.Value.ValueAsString()
                                                Exit For
                                            End If
                                        Next
                                        If sWPrintFlag = "" Then
                                            sWPrintFlag = "E"
                                        End If
                                        InsertCfgAttrRecord(sConfigId _
                                                            , "R" & O.Id.ToString() _
                                                            , "Text" & W.InstructionNo _
                                                            , WIA.Value.ValueAsString _
                                                            , "Schema" _
                                                            , "jobroute.text" _
                                                            , targetConfigId _
                                                            , sWPrintFlag _
                                                            , sCfgAttrXMLString)
                                    End If
                                Next
                            Next
                        End If

                        ' Routing Attributes
                        For Each OA As Outputs.Attribute In O.Attributes
                            If Len(OA.Value.ValueAsString) <> 0 Then
                                If CheckCfgSchemaAttributeFields(OA.Name) = True Then
                                    InsertCfgAttrRecord(sConfigId _
                                                        , "R" & O.Id.ToString() _
                                                        , OA.Name _
                                                        , OA.Value.ValueAsString _
                                                        , "Schema" _
                                                        , OA.Name _
                                                        , targetConfigId _
                                                        , sPrintFlag _
                                                        , sCfgAttrXMLString)
                                End If
                            End If
                        Next
                    End If
                Next
            Next
        End If

        If sCfgCompXMLString <> "" Then
            Me.Context.Commands.Invoke("SLCfgMains", "CfgMapConfigurationDataWriteXMLSp", "cfg_comp", sCfgCompXMLString, vInfobar)
        End If
        If sCfgAttrXMLString <> "" Then
            Me.Context.Commands.Invoke("SLCfgMains", "CfgMapConfigurationDataWriteXMLSp", "cfg_attr", sCfgAttrXMLString, vInfobar)
        End If
    End Sub

    Private Sub InsertPricingAndOrderDetails(ByVal theConfiguration As Outputs.Configuration)

        Dim handledPricing As List(Of String) = New List(Of String)
        Dim handledOrder As List(Of String) = New List(Of String)
        Dim Infobar As String
        Dim Response As InvokeResponseData

        Dim sCfgCompXMLString As String = ""
        Dim sCfgAttrXMLString As String = ""
        Dim vInfobar As String = ""
        Dim sFoundOdI As String = ""
        Dim oCult As New CultureInfo("en-US")

        Try
            If theConfiguration.Components.Count > 0 Then
                For Each CO As Outputs.Component In theConfiguration.Components
                    For Each h As String In handledPricing
                        If h = CO.ComponentSequence.ToString() & "-" & CO.ComponentName Then
                            GoTo canceladd1
                        End If
                    Next
                    For Each D As Outputs.Detail In CO.Details.OrderBy(Of String)(Function(c As Outputs.Detail) c.PrintCode).ToList()
                        If D.Type.ToString() = "Pricing" And (D.PrintCode = "I" Or D.PrintCode = "E") Then
                            handledPricing.Add(CO.ComponentSequence.ToString() & "-" & CO.ComponentName)
                            InsertCfgCompRecord(targetConfigId _
                                                , "PD" & CO.ComponentSequence.ToString() _
                                                , "Pricing Details for " & CO.ComponentName _
                                                , "Cntrl" _
                                                , "" _
                                                , Convert.ToDecimal("1", oCult) _
                                                , Convert.ToDecimal("0", oCult) _
                                                , targetConfigId _
                                                , D.PrintCode _
                                                , 0 _
                                                , 200 _
                                                , 0 _
                                                , sCfgCompXMLString _
                                                , oCult)
                            GoTo canceladd1
                        End If
                    Next
canceladd1:
                    For Each h As String In handledOrder
                        If h = CO.Id.ToString() Then
                            GoTo canceladd2
                        End If
                    Next
                    sFoundOdI = ""
                    For Each D As Outputs.Detail In CO.Details
                        If D.Type.ToString() = "Order" And (D.PrintCode = "E") Then
                            handledOrder.Add(CO.Id.ToString())
                            InsertCfgCompRecord(targetConfigId _
                                                , "OD" & CO.ComponentSequence.ToString() _
                                                , "Order Details" _
                                                , "Cntrl" _
                                                , "" _
                                                , Convert.ToDecimal("1", oCult) _
                                                , Convert.ToDecimal("0", oCult) _
                                                , targetConfigId _
                                                , D.PrintCode _
                                                , 0 _
                                                , 100 _
                                                , 0 _
                                                , sCfgCompXMLString _
                                                , oCult)
                            GoTo canceladd2
                        End If
                        If D.Type.ToString() = "Order" And (D.PrintCode = "I") Then
                            sFoundOdI = "I"
                        End If
                    Next
                    If sFoundOdI = "I" Then
                        handledOrder.Add(CO.Id.ToString())
                        InsertCfgCompRecord(targetConfigId _
                                            , "OD" & CO.ComponentSequence.ToString() _
                                            , "Order Details" _
                                            , "Cntrl" _
                                            , "" _
                                            , Convert.ToDecimal("1", oCult) _
                                            , Convert.ToDecimal("0", oCult) _
                                            , targetConfigId _
                                            , sFoundOdI _
                                            , 0 _
                                            , 100 _
                                            , 0 _
                                            , sCfgCompXMLString _
                                            , oCult)
                    End If
canceladd2:
                Next

                For Each CO As Outputs.Component In theConfiguration.Components
                    For Each D As Outputs.Detail In CO.Details
                        If D.Type.ToString() = "Pricing" And (D.PrintCode = "I" Or D.PrintCode = "E") Then
                            ' Price Description
                            InsertCfgAttrRecord(targetConfigId _
                                                , "PD" & CO.ComponentSequence _
                                                , D.Description _
                                                , D.Value.ValueAsString _
                                                , "String" _
                                                , "" _
                                                , targetConfigId _
                                                , D.PrintCode _
                                                , sCfgAttrXMLString)
                        End If

                        If D.Type.ToString() = "Order" And (D.PrintCode = "I" Or D.PrintCode = "E") Then
                            ' Order Description
                            InsertCfgAttrRecord(targetConfigId _
                                                , "OD" & CO.ComponentSequence _
                                                , D.Description _
                                                , D.Value.ValueAsString _
                                                , "String" _
                                                , "" _
                                                , targetConfigId _
                                                , D.PrintCode _
                                                , sCfgAttrXMLString)
                        End If
                    Next
                Next
            End If

            If sCfgCompXMLString <> "" Then
                Me.Context.Commands.Invoke("SLCfgMains", "CfgMapConfigurationDataWriteXMLSp", "cfg_comp", sCfgCompXMLString, vInfobar)
            End If
            If sCfgAttrXMLString <> "" Then
                Me.Context.Commands.Invoke("SLCfgMains", "CfgMapConfigurationDataWriteXMLSp", "cfg_attr", sCfgAttrXMLString, vInfobar)
            End If

        Catch Ex As Exception
            Infobar = ""
            Response = Me.Context.Commands.Invoke("ApplicationMessages", "MsgAppSp",
                       Infobar, "E=CmdFailed", "InsertPricingAndOrderDetails", "",
                       "", "", "", "", "", "", "", "", "", "", "", "", "")
            Infobar = Response.Parameters(0).Value & Chr(13) & Ex.Message
            Throw New MGException(Infobar)

        End Try

    End Sub

    Private Sub PopulateSubComponents(theConfiguration As Outputs.Configuration)
        'subConfigurationMapList = New List(Of SubConfigurationMap)

        Dim scm As SubConfigurationMap = New SubConfigurationMap With {
            .ComponentId = lParentConfigurationID,
            .ConfigId = targetConfigId
        }

        subConfigurationMapList.Add(scm)

        For Each MC In theConfiguration.BomComponents
            If MC.IsComponent = True And MC.ParentId > 0 Then
                For Each MAC In MC.Attributes
                    If MAC.Name = "Part Number" Then
                        Dim sc As SubConfigurationMap = New SubConfigurationMap With {
                            .ComponentId = MC.Id,
                            .ConfigModel = MC.ComponentName,
                            .Item = MAC.Value.ValueAsString,
                            .ParentComponentId = MC.ParentId
                        }
                        subConfigurationMapList.Add(sc)
                    End If
                Next
            End If
        Next

        For Each sc In subConfigurationMapList
            If IsNothing(sc.ConfigId) = True Then
                Dim nextId As String = NextCfgId()
                sc.ConfigId = nextId
            End If
        Next

    End Sub

    Private Sub InsertConfigurationCode(ByVal theConfiguration As Outputs.Configuration)

        Dim sCfgCompXMLString As String = ""
        Dim sCfgAttrXMLString As String = ""
        Dim vInfobar As String = ""
        Dim oCult As New CultureInfo("en-US")

        If theConfiguration.BomComponents.Count > 0 Then
            For Each MCO As Outputs.BomComponent In theConfiguration.BomComponents
                For Each V In MCO.Attributes
                    If V.Name = "ConfigurationCode" And Len(V.Value.ValueAsString) >= 5 Then
                        If StrConv(V.Value.ValueAsString.Substring(0, 5), VbStrConv.Uppercase) = "SMART" _
                            Or StrConv(V.Value.ValueAsString.Substring(0, 5), VbStrConv.Uppercase) = "SEQNT" _
                            Or StrConv(V.Value.ValueAsString.Substring(0, 5), VbStrConv.Uppercase) = "CEPKY" Then

                            Dim sConfigId As String = ""
                            If MCO.Id = lParentConfigurationID Then
                                sConfigId = targetConfigId
                            Else
                                ' subconfig
                                Dim sc As SubConfigurationMap = subConfigurationMapList.Where(Function(x) x.ComponentId = MCO.Id).FirstOrDefault()
                                If IsNothing(sc) = False Then
                                    sConfigId = sc.ConfigId
                                End If
                            End If

                            InsertCfgCompRecord(sConfigId _
                                                , "CC" & MCO.Id.ToString() _
                                                , "IPN" _
                                                , "Cntrl" _
                                                , "" _
                                                , Convert.ToDecimal("1", oCult) _
                                                , Convert.ToDecimal("0", oCult) _
                                                , targetConfigId _
                                                , "I" _
                                                , 0 _
                                                , 0 _
                                                , 0 _
                                                , sCfgCompXMLString _
                                                , oCult)

                            InsertCfgAttrRecord(sConfigId _
                                                , "CC" & MCO.Id.ToString _
                                                , "IPN" _
                                                , V.Value.ValueAsString _
                                                , "IPNType" _
                                                , "" _
                                                , targetConfigId _
                                                , "I" _
                                                , sCfgAttrXMLString)

                        End If
                    End If
                Next
            Next
        End If

        If sCfgCompXMLString <> "" Then
            Me.Context.Commands.Invoke("SLCfgMains", "CfgMapConfigurationDataWriteXMLSp", "cfg_comp", sCfgCompXMLString, vInfobar)
        End If
        If sCfgAttrXMLString <> "" Then
            Me.Context.Commands.Invoke("SLCfgMains", "CfgMapConfigurationDataWriteXMLSp", "cfg_attr", sCfgAttrXMLString, vInfobar)
        End If

    End Sub

    Private Sub InsertTotalPrice(ByVal theConfiguration As Outputs.Configuration)
        Dim sCfgCompXMLString As String = ""
        Dim vInfobar As String = ""
        Dim oCult As New CultureInfo("en-US")

        InsertCfgCompRecord(targetConfigId _
                            , "PRICE" _
                            , "Pricing" _
                            , "Cntrl" _
                            , "" _
                            , Convert.ToDecimal("1", oCult) _
                            , Convert.ToDecimal(dBasePrice, oCult) _
                            , targetConfigId _
                            , "I" _
                            , 0 _
                            , 0 _
                            , 0 _
                            , sCfgCompXMLString _
                            , oCult)

        If sCfgCompXMLString <> "" Then
            Me.Context.Commands.Invoke("SLCfgMains", "CfgMapConfigurationDataWriteXMLSp", "cfg_comp", sCfgCompXMLString, vInfobar)
        End If

    End Sub

    Private Sub InsertMaterialAttributes(ByVal theConfiguration As Outputs.Configuration)

        Dim M As TDCI.BuyDesign.Configurator.Integration.Data.Outputs.BomComponent
        Dim MA As TDCI.BuyDesign.Configurator.Integration.Data.Outputs.Attribute
        Dim MAC As TDCI.BuyDesign.Configurator.Integration.Data.Outputs.Attribute

        Dim sConfigId As String
        Dim sCompId As String
        Dim sAttrValue As String
        'Dim sAttrGid As String
        Dim sPrintFlag As String

        Dim sCfgAttrXMLString As String = ""
        Dim vInfobar As String = ""

        If theConfiguration.BomComponents.Count > 0 Then

            ' Insert isComponent = 0 first
            For Each M In theConfiguration.BomComponents
                If M.ParentId.ToString() <> "" Then
                    For Each MA In M.Attributes
                        If M.IsComponent = False And Len(MA.Value.ValueAsString) <> 0 Then
                            'If M.Id = MA.Id And M.IsComponent = False And Len(MA.Value.ValueAsString) <> 0 Then
                            If CheckCfgSchemaAttributeFields(MA.Name) = True Then

                                If M.ParentId = lParentConfigurationID Then
                                    sConfigId = targetConfigId
                                Else
                                    sConfigId = ""
                                    Dim sc As SubConfigurationMap = subConfigurationMapList.Where(Function(x) x.ComponentId = M.ParentId).FirstOrDefault()
                                    If IsNothing(sc) = False Then
                                        sConfigId = sc.ConfigId
                                    End If
                                End If

                                If MA.Value.ValueAsString = "SLBLANK" Then
                                    sAttrValue = ""
                                Else
                                    sAttrValue = MA.Value.ValueAsString
                                End If

                                sPrintFlag = "I"
                                For Each MAC In M.Attributes
                                    If MAC.Id = M.Id And MAC.Name = "Print Code" Then
                                        If MAC.Value.ValueAsString = "E" Then
                                            sPrintFlag = MAC.Value.ValueAsString
                                            Exit For
                                        End If
                                    End If
                                Next

                                If IsCompIdValid(sConfigId, "M" & M.Id.ToString()) = True Then
                                    InsertCfgAttrRecord(sConfigId _
                                                        , "M" & M.Id.ToString() _
                                                        , MA.Name _
                                                        , sAttrValue _
                                                        , "Schema" _
                                                        , MA.Name _
                                                        , targetConfigId _
                                                        , sPrintFlag _
                                                        , sCfgAttrXMLString)
                                End If
                                'Exit For
                            End If
                        End If
                    Next
                End If
            Next

            For Each M In theConfiguration.BomComponents
                For Each MA In M.Attributes
                    If Len(MA.Value.ValueAsString) <> 0 Then
                        If CheckCfgSchemaAttributeFields(MA.Name) = True Then
                            For Each scmap In subConfigurationMapList
                                If scmap.ComponentId = M.Id Then
                                    sConfigId = ""
                                    If M.Id = lParentConfigurationID Then
                                        sConfigId = targetConfigId
                                    Else
                                        sConfigId = scmap.ConfigId
                                    End If


                                    sCompId = "M" & M.Id.ToString()

                                    If MA.Value.ValueAsString = "SLBLANK" Then
                                        sAttrValue = ""
                                    Else
                                        sAttrValue = MA.Value.ValueAsString
                                    End If

                                    sPrintFlag = "E"
                                    For Each MAC In M.Attributes
                                        If MAC.Name = "Print Code" Then
                                            If MAC.Value.ValueAsString = "I" Then
                                                sPrintFlag = "I"
                                            Else
                                                sPrintFlag = "E"
                                            End If
                                        End If
                                    Next

                                    InsertCfgAttrRecord(sConfigId,
                                                        sCompId,
                                                        MA.Name,
                                                        sAttrValue,
                                                        "Schema",
                                                        MA.Name,
                                                        targetConfigId,
                                                        sPrintFlag,
                                                        sCfgAttrXMLString)

                                End If
                            Next
                        End If
                    End If
                Next
            Next

        End If

        If sCfgAttrXMLString <> "" Then
            Me.Context.Commands.Invoke("SLCfgMains", "CfgMapConfigurationDataWriteXMLSp", "cfg_attr", sCfgAttrXMLString, vInfobar)
        End If
    End Sub

    Private Function IsCompIdValid(ByVal sConfigID As String, ByVal sCompID As String) As Boolean
        Dim bValid As Boolean = False

        Dim cfgComp As New LoadCollectionResponseData
        Dim cfgCompProp As New PropertyList
        Dim filter As String = "ConfigId = " + SqlLiteral.Format(sConfigID, SqlLiteralFormatFlags.UseQuotes) _
                               + " AND CompId = " + SqlLiteral.Format(sCompID, SqlLiteralFormatFlags.UseQuotes)
        cfgCompProp.Add("ConfigId")
        cfgCompProp.Add("CompId")
        cfgComp = Me.Context.Commands.LoadCollection("SLCfgComps", cfgCompProp, filter, String.Empty, 0)

        If cfgComp.Items.Count > 0 Then
            bValid = True
        End If

        Return bValid
    End Function

    Private Sub InsertDocumentInfofromPCMIntegrationRule(ByVal theConfiguration As Outputs.Configuration)

        Dim sCfgAttrXMLString As String = ""
        Dim vInfobar As String = ""

        For i As Integer = 0 To theConfiguration.IntegrationOutputs.Count - 1
            If theConfiguration.IntegrationOutputs(i).TemplateName = "SyteLineDocument" Then
                Dim sValue As String = "<DocumentDetails><ID>" & theConfiguration.IntegrationOutputs(i).IntegrationOutputId.ToString() & "</ID>"
                sValue = sValue & GetIntegrationOutputAttributeValue(theConfiguration.IntegrationOutputs(i).Attributes, "SequenceNo")
                sValue = sValue & GetIntegrationOutputAttributeValue(theConfiguration.IntegrationOutputs(i).Attributes, "DocumentName")
                sValue = sValue & GetIntegrationOutputAttributeValue(theConfiguration.IntegrationOutputs(i).Attributes, "Description")
                sValue = sValue & GetIntegrationOutputAttributeValue(theConfiguration.IntegrationOutputs(i).Attributes, "URL")
                sValue = sValue & GetIntegrationOutputAttributeValue(theConfiguration.IntegrationOutputs(i).Attributes, "InternalFlag")
                sValue = sValue & GetIntegrationOutputAttributeValue(theConfiguration.IntegrationOutputs(i).Attributes, "Revision")
                sValue = sValue & GetIntegrationOutputAttributeValue(theConfiguration.IntegrationOutputs(i).Attributes, "Status")
                sValue = sValue & GetIntegrationOutputAttributeValue(theConfiguration.IntegrationOutputs(i).Attributes, "StartDate")
                sValue = sValue & GetIntegrationOutputAttributeValue(theConfiguration.IntegrationOutputs(i).Attributes, "EndDate")
                sValue = sValue & GetIntegrationOutputAttributeValue(theConfiguration.IntegrationOutputs(i).Attributes, "AttachTo")
                sValue = sValue & "</DocumentDetails>"

                InsertCfgAttrRecord(targetConfigId _
                                    , "CD" & theConfiguration.IntegrationOutputs(i).Id.ToString() _
                                    , "SyteLineDocument_" & (i + 1).ToString() _
                                    , sValue _
                                    , "String" _
                                    , "" _
                                    , targetConfigId _
                                    , "E" _
                                    , sCfgAttrXMLString)
            End If
        Next

        If sCfgAttrXMLString <> "" Then
            Me.Context.Commands.Invoke("SLCfgMains", "CfgMapConfigurationDataWriteXMLSp", "cfg_attr", sCfgAttrXMLString, vInfobar)
        End If
    End Sub

    Private Sub InsertDocumentInfoForMfgDetailRule(ByVal theConfiguration As Outputs.Configuration)

        Dim sConfigId As String = ""
        Dim sOperationNo As String = ""
        Dim sOperationId As String = ""
        Dim sAttrName As String = ""
        Dim sAttrValue As String = ""

        Dim sCfgAttrXMLString As String = ""
        Dim vInfobar As String = ""

        If theConfiguration.BomComponents.Count > 0 Then
            For Each comp As Outputs.BomComponent In theConfiguration.BomComponents
                For i As Integer = 0 To comp.MfgDetails.Count - 1

                    If comp.IsComponent = True Then
                        If comp.Id = lParentConfigurationID Then
                            sConfigId = targetConfigId
                        Else
                            ' subconfig
                            Dim sc As SubConfigurationMap = subConfigurationMapList.Where(Function(x) x.ComponentId = comp.Id).FirstOrDefault()
                            sConfigId = ""
                            If IsNothing(sc) = False Then
                                sConfigId = sc.ConfigId
                            End If
                        End If
                    Else
                        If comp.ParentId = lParentConfigurationID Then
                            sConfigId = targetConfigId
                        Else
                            If comp.ParentId.ToString() = "" Then
                                sConfigId = comp.Id.ToString()
                            Else
                                Dim sc As SubConfigurationMap = subConfigurationMapList.Where(Function(x) x.ComponentId = comp.ParentId).FirstOrDefault()
                                sConfigId = ""
                                If IsNothing(sc) = False Then
                                    sConfigId = sc.ConfigId
                                End If
                            End If
                        End If
                    End If

                    For Each attr As Outputs.Attribute In comp.MfgDetails(i).Attributes.OrderBy(Of String)(Function(c As Outputs.Attribute) c.Value.ValueAsString).ToList()
                        If attr.Name = "OperationNo" Then
                            sOperationNo = attr.Value.ValueAsString
                            Exit For
                        End If
                    Next

                    For Each attr As Outputs.Attribute In comp.MfgDetails(i).Attributes.OrderBy(Of String)(Function(c As Outputs.Attribute) c.Value.ValueAsString).ToList()
                        If attr.Name = "AttachTo" Then
                            sOperationId = attr.Value.ValueAsString
                            Exit For
                        End If
                    Next

                    If sOperationId = "operation" Then
                        sOperationId = ""
                        For Each operation As Outputs.Operation In comp.Operations
                            If operation.OperationNo = sOperationNo Then
                                If operation.BomComponenetId = comp.MfgDetails(i).BomComponentId Then
                                    sOperationId = operation.Id.ToString()
                                End If
                            End If
                        Next
                    Else
                        sOperationId = ""
                    End If

                    sAttrName = "BDCMfgDetails_Document_" & (i + 1).ToString()

                    sAttrValue = "<DocumentDetails><ID>" & comp.ComponentName & "</ID><CommentNo>" & comp.MfgDetails(i).CommentNo & "</CommentNo>"
                    sAttrValue = sAttrValue & GetAttributeValue(comp.MfgDetails(i).Attributes, "OperationNo")
                    sAttrValue = sAttrValue & GetAttributeValue(comp.MfgDetails(i).Attributes, "SequenceNo")
                    sAttrValue = sAttrValue & GetAttributeValue(comp.MfgDetails(i).Attributes, "DocumentName")
                    sAttrValue = sAttrValue & GetAttributeValue(comp.MfgDetails(i).Attributes, "Description")
                    sAttrValue = sAttrValue & GetAttributeValue(comp.MfgDetails(i).Attributes, "URL")
                    sAttrValue = sAttrValue & GetAttributeValue(comp.MfgDetails(i).Attributes, "InternalFlag")
                    sAttrValue = sAttrValue & GetAttributeValue(comp.MfgDetails(i).Attributes, "Revision")
                    sAttrValue = sAttrValue & GetAttributeValue(comp.MfgDetails(i).Attributes, "Status")
                    sAttrValue = sAttrValue & GetAttributeValue(comp.MfgDetails(i).Attributes, "StartDate")
                    sAttrValue = sAttrValue & GetAttributeValue(comp.MfgDetails(i).Attributes, "EndDate")
                    sAttrValue = sAttrValue & GetAttributeValue(comp.MfgDetails(i).Attributes, "AttachTo")
                    sAttrValue = sAttrValue & "</DocumentDetails>"

                    If sOperationId <> "" Then
                        InsertCfgAttrRecord(sConfigId, "R" & sOperationId, sAttrName, sAttrValue, "String", "", targetConfigId, "E", sCfgAttrXMLString)
                    Else
                        InsertCfgAttrRecord(sConfigId, "M" & comp.Id.ToString(), sAttrName, sAttrValue, "String", "", targetConfigId, "E", sCfgAttrXMLString)
                    End If

                Next
            Next
        End If

        If sCfgAttrXMLString <> "" Then
            Me.Context.Commands.Invoke("SLCfgMains", "CfgMapConfigurationDataWriteXMLSp", "cfg_attr", sCfgAttrXMLString, vInfobar)
        End If

    End Sub

    Private Sub InsertSytelineHold(ByVal theConfiguration As Outputs.Configuration)
        Dim sCompIdForHold As String = ""
        Dim sCompHoldValue As String = "0"

        Dim sCfgCompXMLString As String = ""
        Dim sCfgAttrXMLString As String = ""
        Dim vInfobar As String = ""
        Dim oCult As New CultureInfo("en-US")

        For Each mco As Outputs.Component In theConfiguration.Components
            For Each v As Outputs.ComponentAttribute In mco.ComponentAttributes
                If v.Name = "SyteLine_Hold" Then
                    If mco.ParentId = 0 Or IsNothing(mco.ParentId) = True Then
                        If mco.Id = lParentConfigurationID Then
                            sCompIdForHold = targetConfigId
                        Else
                            'Dim subConfigId As String = subConfigList.Where(Function(x) x.Value = sSite & mco.Id).FirstOrDefault().Key
                            'If subConfigId = Nothing Then
                            '    sCompIdForHold = subConfigList.First().Key.ToString()
                            'Else
                            '    sCompIdForHold = subConfigId
                            'End If
                            sCompIdForHold = mco.Id
                        End If
                        If v.Value.IsNull = True Then
                            sCompHoldValue = "0"
                        Else
                            sCompHoldValue = v.Value.ValueAsString.ToLower()
                            If sCompHoldValue = "true" Then
                                sCompHoldValue = "1"
                            Else
                                sCompHoldValue = "0"
                            End If
                        End If
                        Exit For
                    End If
                End If
            Next
        Next

        If sCompIdForHold <> "" Or sCompIdForHold = "0" Then
            InsertCfgCompRecord(targetConfigId, "CC" & sCompIdForHold, "SLCFG_Hold", "Cntrl", "", 1, 0, targetConfigId, "I", 0, 0, 0, sCfgCompXMLString, oCult)
            InsertCfgAttrRecord(targetConfigId, "CC" & sCompIdForHold, "HOLD", sCompHoldValue, "String", "", targetConfigId, "I", sCfgAttrXMLString)
        End If

        If sCfgCompXMLString <> "" Then
            Me.Context.Commands.Invoke("SLCfgMains", "CfgMapConfigurationDataWriteXMLSp", "cfg_comp", sCfgCompXMLString, vInfobar)
        End If
        If sCfgAttrXMLString <> "" Then
            Me.Context.Commands.Invoke("SLCfgMains", "CfgMapConfigurationDataWriteXMLSp", "cfg_attr", sCfgAttrXMLString, vInfobar)
        End If

    End Sub

    Private Sub InsertQueuePostConfiguration(ByVal theConfiguration As Outputs.Configuration)

        Dim sCompIdQueuePC As String = ""
        Dim sCompValueQueuePC As String = ""
        Dim sCompIdQueueType As String = ""
        Dim sCompValueQueueType As String = ""

        Dim sCfgCompXMLString As String = ""
        Dim sCfgAttrXMLString As String = ""
        Dim vInfobar As String = ""
        Dim oCult As New CultureInfo("en-US")

        sCompValueQueueType = "0"

        For Each mco As Outputs.Component In theConfiguration.Components
            For Each v As Outputs.ComponentAttribute In mco.ComponentAttributes
                If v.Name = "QueuePostConfiguration" Then
                    If mco.ParentId = 0 Or IsNothing(mco.ParentId) = True Then
                        If mco.Id = lParentConfigurationID Then
                            sCompIdQueuePC = targetConfigId
                        Else
                            'Dim subConfigId As String = subConfigList.Where(Function(x) x.Value = sSite & mco.Id).FirstOrDefault().Key
                            'If subConfigId = Nothing Then
                            '    sCompIdQueuePC = subConfigList.First().Key.ToString()
                            'Else
                            '    sCompIdQueuePC = subConfigId
                            'End If
                            sCompIdQueuePC = mco.Id
                        End If
                        If v.Value.IsNull Then
                            sCompValueQueuePC = "0"
                        Else
                            sCompValueQueuePC = v.Value.ValueAsString.ToLower()
                            If sCompValueQueuePC = "true" Then
                                sCompValueQueuePC = "1"
                            Else
                                sCompValueQueuePC = "0"
                            End If
                        End If
                        Exit For
                    End If
                End If
            Next

            '  Set @CompIDForQueueType = (SELECT CASE MCO.ComponentID WHEN @ParentComponentID THEN @TargetConfigID ELSE LTRIM(STR(MCO.ComponentID)) END
            'FROM #Components MCO
            'INNER JOIN #ComponentAttributes V ON MCO.ComponentID = V.ComponentID 
            ' AND V.ComponentAttributeName = 'QueueType' AND MCO.ParentComponentID is null)

            For Each v As Outputs.ComponentAttribute In mco.ComponentAttributes
                If v.Name = "QueueType" Then
                    If mco.Id = v.ComponentId Then
                        If mco.ParentId = 0 Or IsNothing(mco.ParentId) = True Then
                            If mco.Id = lParentConfigurationID Then
                                sCompIdQueueType = targetConfigId
                            Else
                                'Dim subConfigId As String = subConfigList.Where(Function(x) x.Value = sSite & mco.Id).FirstOrDefault().Key
                                'If subConfigId = Nothing Then
                                '    sCompIdQueueType = subConfigList.First().Key.ToString()
                                'Else
                                '    sCompIdQueueType = subConfigId
                                'End If
                                sCompIdQueueType = mco.Id.ToString
                            End If
                        End If
                        Exit For
                    End If
                End If
            Next

            For Each v As Outputs.ComponentAttribute In mco.ComponentAttributes
                If v.Name = "QueueType" Then
                    If v.ComponentId.ToString() = sCompIdQueueType Then
                        If Not v.Value.IsNull Then
                            sCompValueQueueType = v.Value.ValueAsString.ToLower()
                            If v.Value.ValueAsString.ToLower() <> "" Then
                                sCompValueQueueType = v.Value.ValueAsString.ToLower()
                                Exit For
                            End If
                        End If
                    End If
                End If
            Next
        Next

        If sCompIdQueuePC <> "" Then
            InsertCfgCompRecord(targetConfigId, "QC" & sCompIdQueuePC, "QueuePostConfiguration", "Cntrl", "", 1, 0, targetConfigId, "I", 0, 0, 0, sCfgCompXMLString, oCult)

            InsertCfgAttrRecord(targetConfigId, "QC" & sCompIdQueuePC, "QueuePostConfiguration", sCompValueQueuePC, "String", "", targetConfigId, "I", sCfgAttrXMLString)

            Dim sQCRAttr As String = GetValueFromCfgAttrs("QueueRequestID")
            Dim sQCRComp As String = GetValueFromCfgComps("QueueRequestID")
            Dim sQCMAttr As String = GetValueFromCfgAttrs("QueuePostConfigurationMessage")
            Dim sQCMComp As String = GetValueFromCfgComps("QueuePostConfigurationMessage")
            Dim sQCSAttr As String = GetValueFromCfgAttrs("QueueStatus")
            Dim sQCSComp As String = GetValueFromCfgComps("QueueStatus")
            If sCompValueQueuePC = "" Or sCompValueQueuePC = "false" Or sCompValueQueuePC = "0" Then
                sQCRAttr = ""
                'sQCRComp = "0"
                sQCMAttr = ""
                'sQCMComp = "0"
                sQCSAttr = ""
                'sQCSComp = "0"
            End If

            If IsNothing(sQCSComp) = False And sQCSComp <> "" Then
                sQCSComp = CStr(CInt(sQCSComp))
            End If
            If IsNothing(sQCMComp) = False And sQCMComp <> "" Then
                sQCMComp = CStr(CInt(sQCMComp))
            End If
            If IsNothing(sQCRComp) = False And sQCRComp <> "" Then
                sQCRComp = CStr(CInt(sQCRComp))
            End If

            InsertCfgCompRecord(targetConfigId, "QCT" & sCompIdQueueType, "QueueType", "Cntrl", "", 1, 0, targetConfigId, "I", 0, 0, 0, sCfgCompXMLString, oCult)
            InsertCfgAttrRecord(targetConfigId, "QCT" & sCompIdQueueType, "QueueType", sCompValueQueueType, "String", "", targetConfigId, "I", sCfgAttrXMLString)

            InsertCfgCompRecord(targetConfigId, "QCS" & sCompIdQueueType, "QueueStatus", "Cntrl", sQCSComp, 1, 0, targetConfigId, "I", 0, 0, 0, sCfgCompXMLString, oCult)
            InsertCfgAttrRecord(targetConfigId, "QCS" & sCompIdQueueType, "QueueStatus", sQCSAttr, "String", "", targetConfigId, "I", sCfgAttrXMLString)

            InsertCfgCompRecord(targetConfigId, "QCM" & sCompIdQueueType, "QueuePostConfigurationMessage", "Cntrl", sQCMComp, 1, 0, targetConfigId, "I", 0, 0, 0, sCfgCompXMLString, oCult)
            InsertCfgAttrRecord(targetConfigId, "QCM" & sCompIdQueueType, "QueuePostConfigurationMessage", sQCMAttr, "String", "", targetConfigId, "I", sCfgAttrXMLString)

            InsertCfgCompRecord(targetConfigId, "QCR" & sCompIdQueueType, "QueueRequestID", "Cntrl", sQCRComp, 1, 0, targetConfigId, "I", 0, 0, 0, sCfgCompXMLString, oCult)
            InsertCfgAttrRecord(targetConfigId, "QCR" & sCompIdQueueType, "QueueRequestID", sQCRAttr, "String", "", targetConfigId, "I", sCfgAttrXMLString)

        End If

        If sCfgCompXMLString <> "" Then
            Me.Context.Commands.Invoke("SLCfgMains", "CfgMapConfigurationDataWriteXMLSp", "cfg_comp", sCfgCompXMLString, vInfobar)
        End If
        If sCfgAttrXMLString <> "" Then
            Me.Context.Commands.Invoke("SLCfgMains", "CfgMapConfigurationDataWriteXMLSp", "cfg_attr", sCfgAttrXMLString, vInfobar)
        End If
    End Sub

    Private Function GetValueFromCfgAttrs(ByVal sAttrName As String) As String
        Dim handler As String = ""

        Dim collectionResponse As LoadCollectionResponseData = New LoadCollectionResponseData()
        Dim idoPropertylist As PropertyList = New PropertyList()
        idoPropertylist.Add("AttrValue")
        Dim sFilter As String = "config_id = '" & targetConfigId.ToString() & "' and attr_name = '" & sAttrName & "'"
        collectionResponse = Me.Context.Commands.LoadCollection("SLCfgAttrs", idoPropertylist, sFilter, String.Empty, 0)

        If collectionResponse.Items.Count > 0 Then
            handler = collectionResponse.Items(0).PropertyValues(0).Value.ToString()
        End If

        collectionResponse = Nothing
        idoPropertylist = Nothing

        Return handler
    End Function

    Private Function GetValueFromCfgComps(ByVal sCompName As String) As String
        Dim handler As String = Nothing

        Dim collectionResponse As LoadCollectionResponseData = New LoadCollectionResponseData()
        Dim idoPropertylist As PropertyList = New PropertyList()
        idoPropertylist.Add("Qty")
        Dim sFilter As String = "config_id = '" & targetConfigId.ToString() & "' and comp_name = '" & sCompName & "'"
        collectionResponse = Me.Context.Commands.LoadCollection("SLCfgComps", idoPropertylist, sFilter, String.Empty, 0)

        If collectionResponse.Items.Count > 0 Then
            handler = collectionResponse.Items(0).PropertyValues(0).Value.ToString()
        End If

        collectionResponse = Nothing
        idoPropertylist = Nothing
        If handler = "" Then
            handler = Nothing
        End If
        Return handler
    End Function

    Private Function GetAttributeValue(ByVal list As IList(Of Outputs.Attribute) _
                                                        , ByVal sAttrName As String) As String
        Dim handler As String = ""
        For Each c As Outputs.Attribute In list
            If c.Name = sAttrName Then
                If c.Value.IsNull = False Then
                    handler = "<" & c.Name & ">" & c.Value.ValueAsString() & "</" & c.Name & ">"
                Else
                    handler = "<" & c.Name & "></" & c.Name & ">"
                End If
                Exit For
            End If
        Next
        Return handler
    End Function

    Private Function GetIntegrationOutputAttributeValue(ByVal list As IList(Of Outputs.IntegrationOutputAttribute) _
                                                        , ByVal sAttrName As String) As String
        Dim handler As String = ""
        For Each c As Outputs.IntegrationOutputAttribute In list
            If c.Name = sAttrName Then
                If c.Value.IsNull = False Then
                    handler = "<" & c.Name & ">" & c.Value.ValueAsString() & "</" & c.Name & ">"
                Else
                    handler = "<" & c.Name & "></" & c.Name & ">"
                End If
                Exit For
            End If
        Next
        Return handler
    End Function

    Private Function CheckCfgSchemaAttributeFields(ByVal sName As String) As Boolean
        Dim handler As Boolean = False

        'Check the previously loaded DataTable named dtCfgSchemaAttributeFields
        Dim validCfgSchemaAttributeFields() As DataRow = dtCfgSchemaAttributeFields.Select(String.Format("'{0}' = ValidAttributeEntry", sName.ToString()), "ValidAttributeEntry", DataViewRowState.CurrentRows)
        If validCfgSchemaAttributeFields.Length = 0 Then
            handler = False
        Else
            handler = True
        End If

        Return handler
    End Function

    Private Sub DeleteCfgDataIfExists(ByRef Infobar As String)

        Me.Context.Commands.Invoke("SlCfgMains", "CfgMapConfiguration_DeleteSp", targetConfigId, Infobar)

    End Sub

    Private Sub InsertTopLevelComponentIntoCfgMain(ByVal theConfigurationSummary As ConfigurationSummary,
                                                   ByVal sConfigurationId As String,
                                                   ByRef sOrderType As String)

        Dim collectionResponse As New LoadCollectionResponseData()
        Dim propertyList As New PropertyList()
        Dim sFilter = "ConfigId = '" & targetConfigId & "'"

        'Try
        collectionResponse = Me.Context.Commands.LoadCollection("SLCfgMains", propertyList, sFilter, String.Empty, 0)
        If collectionResponse.Items.Count > 0 Then
            UpdateCfgMainRecord(targetConfigId,
                            theConfigurationSummary.InputParameters.PartNumber,
                            GetItemForCfgMain(theConfigurationSummary, sOrderType),
                            0,
                            DoPricing(dBasePrice),
                            DoPricing(dBasePrice))
        Else
            InsertCfgMainRecord(targetConfigId,
                            theConfigurationSummary.InputParameters.PartNumber,
                            GetItemForCfgMain(theConfigurationSummary, sOrderType),
                            0,
                            DoPricing(dBasePrice),
                            DoPricing(dBasePrice))
        End If
        'Catch ex As Exception
        '    Throw New Exception("PCM Integration Error: " & ex.Message)
        'Finally
        '    collectionResponse = Nothing
        '    propertyList = Nothing
        'End Try

    End Sub

    Public Function GetItemForCfgMain(ByVal configurationSummary As ConfigurationSummary, ByVal sOrderType As String) As String

        Dim sPartNumber As String = ""

        If Not (sOrderType = "103" Or sOrderType = "104") Then
            sPartNumber = configurationSummary.InputParameters.PartNumber
        End If

        Return sPartNumber

    End Function

    Function DoPricing(ByVal sBasePrice As Decimal) As Integer
        If sBasePrice = 0 Then
            Return 0
        Else
            Return 1
        End If
    End Function

    Private Sub InsertCfgMainRecord(ByRef sConfigurationId As String,
                                    ByRef sConfigurationModel As String,
                                    ByRef ItemFromCfgMain As String,
                                    ByRef CoRelease As Integer,
                                    ByVal doPricing As Integer,
                                    ByVal useModelPrice As Integer)

        Dim updateRequest As UpdateCollectionRequestData
        Dim updateItem As IDOUpdateItem

        updateRequest = New UpdateCollectionRequestData With {
            .IDOName = "SLCfgMains",
            .RefreshAfterUpdate = True
        }

        updateItem = New IDOUpdateItem With {
            .Action = UpdateAction.Insert,
            .ItemNumber = 1
        }

        updateItem.Properties.Add("ConfigId", sConfigurationId)
        updateItem.Properties.Add("ConfigType", sConfig_type)
        updateItem.Properties.Add("ConfigStatus", sConfig_status)
        updateItem.Properties.Add("ConfigGid", sConfigurationId)
        updateItem.Properties.Add("ConfigModel", sConfigurationModel)
        updateItem.Properties.Add("ConfigDate", DateTime.Now)
        updateItem.Properties.Add("Item", ItemFromCfgMain)
        updateItem.Properties.Add("Job", sJob)
        updateItem.Properties.Add("Suffix", iSuffix)
        updateItem.Properties.Add("CoNum", sCoNum)
        updateItem.Properties.Add("CoLine", iCoLine)
        updateItem.Properties.Add("CoRelease", CoRelease)
        updateItem.Properties.Add("TrnNum", "")
        updateItem.Properties.Add("TrnLine", 0)
        updateItem.Properties.Add("DoPricing", doPricing)
        updateItem.Properties.Add("UseModelPrice", useModelPrice)
        updateItem.Properties.Add("BasePrice", dBasePrice)

        updateRequest.Items.Add(updateItem)
        Me.Context.Commands.UpdateCollection(updateRequest)

    End Sub

    Private Sub UpdateCfgMainRecord(ByRef sConfigurationId As String,
                                    ByRef sConfigurationModel As String,
                                    ByRef ItemFromCfgMain As String,
                                    ByRef CoRelease As Integer,
                                    ByVal doPricing As Integer,
                                    ByVal useModelPrice As Integer)

        Dim collectionResponse As LoadCollectionResponseData = New LoadCollectionResponseData()
        Dim idoProperties As GetPropertyInfoResponseData
        idoProperties = Me.Context.Commands.GetPropertyInfo("SLCfgMains")
        Dim idoPropertylist As PropertyList = New PropertyList()
        For Each p In idoProperties.Properties
            If p.IsContainsRelationship = False Then
                idoPropertylist.Add(p.Name)
            End If
        Next
        Dim sFilter = "ConfigId = '" & sConfigurationId & "'"

        collectionResponse = Me.Context.Commands.LoadCollection("SLCfgMains", idoPropertylist, sFilter, String.Empty, 0)

        If collectionResponse.Items.Count > 0 Then

            For i As Integer = 0 To collectionResponse.Items.Count - 1 Step 1
                Dim updateRequest As UpdateCollectionRequestData = New UpdateCollectionRequestData("SLCfgMains")
                Dim updateItem As IDOUpdateItem = New IDOUpdateItem With {
                    .Action = UpdateAction.Update,
                    .ItemNumber = 1
                }

                updateItem.Properties.Add("ConfigType", sConfig_type)
                updateItem.Properties.Add("ConfigStatus", sConfig_status)
                updateItem.Properties.Add("ConfigGid", sConfigurationId)
                updateItem.Properties.Add("ConfigModel", sConfigurationModel)
                updateItem.Properties.Add("ConfigDate", DateTime.Now)
                updateItem.Properties.Add("Item", ItemFromCfgMain)
                updateItem.Properties.Add("Job", sJob)
                updateItem.Properties.Add("Suffix", iSuffix)
                updateItem.Properties.Add("CoNum", sCoNum)
                updateItem.Properties.Add("CoLine", iCoLine)
                updateItem.Properties.Add("CoRelease", CoRelease)
                updateItem.Properties.Add("TrnNum", "")
                updateItem.Properties.Add("TrnLine", 0)
                updateItem.Properties.Add("DoPricing", doPricing)
                updateItem.Properties.Add("UseModelPrice", useModelPrice)
                updateItem.Properties.Add("BasePrice", dBasePrice)

                updateItem.ItemID = collectionResponse.Items(i).ItemID

                updateRequest.Items.Add(updateItem)
                Me.Context.Commands.UpdateCollection(updateRequest)
            Next
        End If

    End Sub

    Private Sub InsertCfgMainRecord(ByRef sConfigurationId As String,
                                    ByRef sGlobalConfig_Type As String,
                                    ByVal sConfigurationModel As String,
                                    ByVal ItemFromCfgMain As String,
                                    ByRef Job As String,
                                    ByRef Suffix As String,
                                    ByRef CoNum As String,
                                    ByRef CoLine As String,
                                    ByRef CoRelease As Integer,
                                    ByVal doPricing As Decimal,
                                    ByVal useModelPrice As Decimal,
                                    ByRef sGlobalBasePrice As Decimal)

        Dim updateRequest As UpdateCollectionRequestData
        Dim updateItem As IDOUpdateItem

        updateRequest = New UpdateCollectionRequestData With {
            .IDOName = "SLCfgMains",
            .RefreshAfterUpdate = True
        }

        updateItem = New IDOUpdateItem With {
            .Action = UpdateAction.Insert,
            .ItemNumber = 1
        }

        updateItem.Properties.Add("ConfigId", sConfigurationId)
        updateItem.Properties.Add("ConfigType", sGlobalConfig_Type)
        updateItem.Properties.Add("ConfigStatus", sConfig_status)
        updateItem.Properties.Add("ConfigGid", targetConfigId)
        updateItem.Properties.Add("ConfigModel", sConfigurationModel)
        updateItem.Properties.Add("ConfigDate", DateTime.Now)
        updateItem.Properties.Add("Item", ItemFromCfgMain)
        updateItem.Properties.Add("Job", Job)
        updateItem.Properties.Add("Suffix", Suffix)
        updateItem.Properties.Add("CoNum", CoNum)
        updateItem.Properties.Add("CoLine", CoLine)
        updateItem.Properties.Add("CoRelease", CoRelease)
        updateItem.Properties.Add("TrnNum", "")
        updateItem.Properties.Add("TrnLine", 0)
        updateItem.Properties.Add("DoPricing", doPricing)
        updateItem.Properties.Add("UseModelPrice", useModelPrice)
        updateItem.Properties.Add("BasePrice", sGlobalBasePrice)

        updateRequest.Items.Add(updateItem)
        Me.Context.Commands.UpdateCollection(updateRequest)

    End Sub

    Private Function GetConfigTypeForCfgMainConfiguredComponents(ByVal sOrderType As String) As String

        Select Case sOrderType
            Case "1", "101"
                Return "Job"
            Case "2", "102"
                Return "EstimateJob"
            Case Else
                Return ""
        End Select

    End Function
    Private Sub InsertCfgRefRecord(ByVal sConfigId As String, ByVal sComponentId As String, ByRef sCfgRefXMLString As String)

        ' This function puts the data for a new cfg_attr row into XML format, and concatentates to an XML string.
        '   This string is later passed to a backend SQL stored procedure to add to the tables.

        Dim sRefType As String = "C"
        Dim sRefLineSuf As String = "0"
        Dim sRefRelease As String = "0"
        Dim sCfgRefNewXMLRow As String = ""

        sCfgRefNewXMLRow = "<cfg_ref" _
            & " config_id=" & """" & sConfigId & """" _
            & " ref_type=" & """" & sRefType & """" _
            & " ref_num=" & """" & sComponentId & """" _
            & " ref_line_suf=" & """" & sRefLineSuf & """" _
            & " ref_release=" & """" & sRefRelease & """" _
            & "/>"

        sCfgRefXMLString = sCfgRefXMLString + sCfgRefNewXMLRow

    End Sub


    Private Sub InsertCfgCompRecordMat(ByVal sConfigId As String,
                                ByVal sCompId As String,
                                ByVal sCompName As String,
                                ByVal sCompNum As String,
                                ByVal dQuantity As Decimal,
                                ByVal dPrice As Decimal,
                                ByVal sPrintFlag As String,
                                ByVal sOperation As String,
                                ByVal iMaterialSequence As Integer,
                                ByVal sNewLine As String,
                                ByVal sSubConfigId As String,
                                ByRef sCfgCompXMLString As String,
                                ByRef oCult As CultureInfo)

        ' This function puts the data for a new cfg_attr row into XML format, and concatentates to an XML string.
        '   This string is later passed to a backend SQL stored procedure to add to the tables.

        Dim sCfgCompNewXMLRow As String = ""
        Dim sVisible As String = "1"
        Dim sCompType As String = "Matl"

        sCompName = PrepValueForXML(sCompName)
        If sCompNum <> "" Then
            sCompNum = PrepValueForXML(sCompNum)
        End If

        sCfgCompNewXMLRow = "<cfg_comp" _
            & " config_id=" & """" & sConfigId & """" _
            & " comp_id=" & """" & sCompId & """" _
            & " visible=" & """" & sVisible & """" _
            & " comp_name=" & """" & sCompName & """" _
            & " comp_type=" & """" & sCompType & """" _
            & " comp_num=" & """" & sCompNum & """" _
            & " qty=" & """" & Convert.ToString(dQuantity, oCult) & """" _
            & " price=" & """" & Convert.ToString(dPrice, oCult) & """" _
            & " comp_gid=" & """" & targetConfigId & """" _
            & " print_flag=" & """" & sPrintFlag & """" _
            & " sub_cfg_gid=" & """" & sSubConfigId & """" _
            & " oper_num=" & """" & sOperation & """" _
            & " sequence=" & """" & iMaterialSequence & """" _
            & " new_line=" & """" & sNewLine & """" _
            & "/>"

        sCfgCompXMLString = sCfgCompXMLString + sCfgCompNewXMLRow

    End Sub

    Private Sub InsertCfgCompRecord(ByVal sConfigId As String,
                                    ByVal sCompId As String,
                                    ByVal sCompName As String,
                                    ByVal sCompType As String,
                                    ByVal sCompNum As String,
                                    ByVal dQuantity As Decimal,
                                    ByVal dPrice As Decimal,
                                    ByVal sCompGid As String,
                                    ByVal sPrintFlag As String,
                                    ByVal sOperation As String,
                                    ByVal iMaterialSequence As Integer,
                                    ByVal sNewLine As String,
                                    ByRef sCfgCompXMLString As String,
                                    ByRef oCult As CultureInfo)

        ' This function puts the data for a new cfg_attr row into XML format, and concatentates to an XML string.
        '   This string is later passed to a backend SQL stored procedure to add to the tables.

        Dim sCfgCompNewXMLRow As String = ""
        Dim sVisible As String = "1"

        sCompName = PrepValueForXML(sCompName)
        If sCompNum <> "" Then
            sCompNum = PrepValueForXML(sCompNum)
        End If

        sCfgCompNewXMLRow = "<cfg_comp" _
            & " config_id=" & """" & sConfigId & """" _
            & " comp_id=" & """" & sCompId & """" _
            & " visible=" & """" & sVisible & """" _
            & " comp_name=" & """" & sCompName & """" _
            & " comp_type=" & """" & sCompType & """" _
            & " comp_num=" & """" & sCompNum & """" _
            & " qty=" & """" & Convert.ToString(dQuantity, oCult) & """" _
            & " price=" & """" & Convert.ToString(dPrice, oCult) & """" _
            & " comp_gid=" & """" & targetConfigId & """" _
            & " print_flag=" & """" & sPrintFlag & """" _
            & " oper_num=" & """" & sOperation & """" _
            & " sequence=" & """" & iMaterialSequence & """" _
            & " new_line=" & """" & sNewLine & """" _
            & "/>"

        sCfgCompXMLString = sCfgCompXMLString + sCfgCompNewXMLRow

    End Sub

    Private Sub InsertCfgAttrRecord(ByVal sConfigId As String,
                                        ByVal sCompId As String,
                                        ByVal sAttrName As String,
                                        ByVal sAttrValue As String,
                                        ByVal sAttrType As String,
                                        ByVal sl_field As String,
                                        ByVal targetConfigId As String,
                                        ByVal sPrintFlag As String,
                                        ByRef sCfgAttrXMLString As String)

        ' This function puts the data for a new cfg_attr row into XML format, and concatentates to an XML string.
        '   This string is later passed to a backend SQL stored procedure to add to the tables.

        Dim sCfgAttrNewXMLRow As String = ""

        sAttrName = PrepValueForXML(sAttrName)
        If sAttrValue <> "" Then
            sAttrValue = PrepValueForXML(sAttrValue)
        End If

        sCfgAttrNewXMLRow = "<cfg_attr" _
            & " config_id=" & """" & sConfigId & """" _
            & " comp_id=" & """" & sCompId & """" _
            & " attr_name=" & """" & sAttrName & """" _
            & " attr_value=" & """" & sAttrValue & """" _
            & " attr_type=" & """" & sAttrType & """" _
            & " sl_field=" & """" & sl_field & """" _
            & " attr_gid=" & """" & targetConfigId & """" _
            & " print_flag=" & """" & sPrintFlag & """" _
            & "/>"

        sCfgAttrXMLString = sCfgAttrXMLString + sCfgAttrNewXMLRow

    End Sub

    Public Function PrepValueForXML(ByVal sValue As String) As String

        'This function replaces XML special characters with their excape substitutions

        Dim sLocalValue As String
        sLocalValue = sValue

        sLocalValue = sLocalValue.Replace("&", "&amp;")
        sLocalValue = sLocalValue.Replace("""", "&quot;")
        sLocalValue = sLocalValue.Replace("'", "&apos;")
        sLocalValue = sLocalValue.Replace("<", "&lt;")
        sLocalValue = sLocalValue.Replace(">", "&gt;")

        sLocalValue = sLocalValue.Replace(vbCr, "&#13;")
        sLocalValue = sLocalValue.Replace(vbLf, "&#10;")

        Return sLocalValue

    End Function


    Public Function GetConfigurator() As String


        Dim oDataReader As IDataReader = Nothing

        GetConfigurator = ""
        Try
            Using appDB As ApplicationDB = IDORuntime.Context.CreateApplicationDB()
                ' create a new SqlCommand
                Using cmd As IDbCommand = appDB.CreateCommand()
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT configurator FROM invparms"

                    Try
                        ' execute the command through the framework
                        oDataReader = appDB.ExecuteReader(cmd)

                    Catch ex As Exception
                        If Not oDataReader Is Nothing AndAlso Not oDataReader.IsClosed Then
                            oDataReader.Close()
                        End If
                        GetConfigurator = "ERROR"
                        MGException.Throw(MGException.ExtractMessages(ex))
                    End Try

                    If oDataReader.Read Then
                        GetConfigurator = oDataReader.Item("configurator").ToString
                    Else
                        If Not oDataReader Is Nothing AndAlso Not oDataReader.IsClosed Then
                            oDataReader.Close()
                        End If
                        GetConfigurator = "ERROR"
                        MGException.Throw(Me.GetMessageProvider.GetMessage("E=NoExist1", "@!Parameters", "@invparms", "configurator"))
                    End If
                    If Not oDataReader Is Nothing AndAlso Not oDataReader.IsClosed Then
                        oDataReader.Close()
                    End If
                End Using
            End Using
        Catch ex As Exception
            GetConfigurator = "ERROR"
            MGException.Throw(MGException.ExtractMessages(ex))

        End Try

    End Function

    Private Function GetCorrespondingItem(ByVal sPartNumber As String) As String
        Dim handler As String = ""

        Dim collectionResponse As LoadCollectionResponseData = New LoadCollectionResponseData()
        Dim idoPropertylist As PropertyList = New PropertyList()
        idoPropertylist.Add("Description")
        Dim sFilter As String = "Item = '" & sPartNumber & "'"
        collectionResponse = Me.Context.Commands.LoadCollection("SLItems", idoPropertylist, sFilter, String.Empty, 0)

        If collectionResponse.Items.Count > 0 Then
            handler = collectionResponse.Items(0).PropertyValues(0).Value.ToString()
        End If

        collectionResponse = Nothing
        idoPropertylist = Nothing

        Return handler
    End Function

    Private Sub InsertShipSite(ByVal sOrderNum As String, ByVal sOrderLine As Integer, ByVal sConfig_type As String, ByVal sSite As String, ByVal InfoBar As String)
        Me.Context.Commands.Invoke("SlCfgMains", "CfgShipSiteInsertSp", sOrderNum, sOrderLine, sConfig_type, sSite, InfoBar)
    End Sub

#End Region
    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function HandleDocumentAuto(
                                ByVal sConfigId As String _
                              , ByVal sRefRowPointer As String _
                              , ByVal sSourceType As String _
                              , ByVal sRuleSetType As String _
                              , ByRef Infobar As String) As Integer

        Dim sDocumentXMLContent As String
        Dim sCompId As String
        Dim sCompName As String
        Dim sDocumentURL As String
        Dim sNewRefPointer As String

        Dim sDocumentName As String
        Dim sTableName As String
        Dim sAttachTo As String
        Dim iOperationNo As Integer
        Dim iSequenceNo As Integer
        Dim sDocumentDescr As String
        Dim bInternal As Byte
        Dim sRevision As String
        Dim sStatus As String
        Dim dtEffStartDate As DateTime
        Dim dtEffEndDate As DateTime
        Dim bFileContent As Byte
        Dim GetCfgDbFile As Boolean
        Dim ResponseData As New InvokeResponseData

        sNewRefPointer = sRefRowPointer

        ' When ruleset is MFG Detail rule, there would be more records in cfg_attr.
        Dim cfgAttr As New LoadCollectionResponseData
        Dim cfgAttrProp As New PropertyList

        If IsNothing(sConfigId) Then
            sConfigId = String.Empty
        End If

        Dim sFilter As String = "ConfigId = " + SqlLiteral.Format(sConfigId, SqlLiteralFormatFlags.UseQuotes) _
                               + " AND AttrName LIKE '%" + sRuleSetType + "_%'"
        cfgAttrProp.Add("AttrValue")
        cfgAttrProp.Add("CompId")

        cfgAttr = Me.Context.Commands.LoadCollection("SLCfgAttrs", cfgAttrProp, sFilter, String.Empty, 0)

        For iCtr As Integer = 0 To (cfgAttr.Items.Count - 1)
            sDocumentXMLContent = cfgAttr.Item(iCtr, "AttrValue").GetValue("")
            sCompId = cfgAttr.Item(iCtr, "CompId").GetValue("")

            Dim xDocumentXML As XDocument
            Try
                xDocumentXML = XDocument.Parse(sDocumentXMLContent)
            Catch
                xDocumentXML = Nothing
            End Try

            ' Here will parse document url to get document name, type, extension, media type.
            sDocumentName = Nothing
            sTableName = Nothing
            sAttachTo = Nothing
            iOperationNo = Nothing
            iSequenceNo = Nothing
            sDocumentDescr = Nothing
            bInternal = Nothing
            sRevision = Nothing
            sStatus = Nothing
            dtEffStartDate = Nothing
            dtEffEndDate = Nothing

            Dim xElement = xDocumentXML.Root

            If Not IsNothing(xDocumentXML) And Not IsNothing(xElement.Element("URL")) Then
                sDocumentURL = xDocumentXML.Root.Element("URL").Value

                If Not IsNothing(xDocumentXML.Root.Element("DocumentName")) Then
                    sDocumentName = xDocumentXML.Root.Element("DocumentName").Value
                Else
                    sDocumentName = "Document Name may not be blank."
                End If


                sDocumentDescr = xDocumentXML.Root.Element("Description").Value
                sRevision = xDocumentXML.Root.Element("Revision").Value
                sStatus = xDocumentXML.Root.Element("Status").Value
                If xDocumentXML.Root.Element("StartDate").Value <> "" Then
                    dtEffStartDate = Convert.ToDateTime(xDocumentXML.Root.Element("StartDate").Value)
                End If
                If xDocumentXML.Root.Element("EndDate").Value <> "" Then
                    dtEffEndDate = Convert.ToDateTime(xDocumentXML.Root.Element("EndDate").Value)
                    If xDocumentXML.Root.Element("InternalFlag").Value = "False" Then
                        bInternal = 0
                    ElseIf xDocumentXML.Root.Element("InternalFlag").Value = "True" Then
                        bInternal = 1
                    End If
                Else
                    bInternal = 0
                End If

                ' Here can add more fields such as status, revision, start date, end date... variable value from XML document of Document object.
                If sRuleSetType = "BDCMfgDetails_Document" Then
                    sAttachTo = xDocumentXML.Root.Element("AttachTo").Value
                    If IsNothing(sAttachTo) = True Then
                        sAttachTo = ""
                    Else
                        sAttachTo = sAttachTo.ToLower()
                    End If

                    If sAttachTo = "material" Then
                        If IsNothing(xDocumentXML.Root.Element("SequenceNo")) = False Then
                            iSequenceNo = CInt(xDocumentXML.Root.Element("SequenceNo").Value)
                        Else
                            iSequenceNo = 0
                        End If
                    End If

                    ' Get Oper_num, and in the case of material, get the sequence number    
                    ' Get these values based on the associated cfg_comp row
                    If sAttachTo = "operation" Or sAttachTo = "material" Then
                        Dim cfgComp As New LoadCollectionResponseData
                        Dim cfgCompProp As New PropertyList
                        sFilter = "ConfigId = " + SqlLiteral.Format(sConfigId, SqlLiteralFormatFlags.UseQuotes) _
                                      + " AND CompId = " + SqlLiteral.Format(sCompId, SqlLiteralFormatFlags.UseQuotes)
                        cfgCompProp.Add("OperNum")
                        cfgCompProp.Add("Sequence")
                        cfgCompProp.Add("CompName")
                        cfgComp = Me.Context.Commands.LoadCollection("SLCfgComps", cfgCompProp, sFilter, String.Empty, 1)

                        If cfgComp.Items.Count > 0 Then
                            iSequenceNo = cfgComp.Item(0, "Sequence").GetValue(Of Integer)(0)
                            iOperationNo = cfgComp.Item(0, "OperNum").GetValue(Of Integer)(0)
                            sCompName = cfgComp.Item(0, "CompName").Value
                        Else
                            sCompName = ""
                        End If
                        ' If Config did not supply a sequence number, get it from jobmatl    
                        ' based on the job, suffix, oper_num and material item
                        If IsNothing(iSequenceNo) = True Or iSequenceNo = 0 Then
                            Dim job As New LoadCollectionResponseData
                            Dim jobProp As New PropertyList
                            sFilter = "JobRowPointer = " + SqlLiteral.Format(sRefRowPointer, SqlLiteralFormatFlags.UseQuotes) _
                                        + " AND OperNum = " + CStr(iOperationNo) _
                                        + " AND Item = " + SqlLiteral.Format(sCompName, SqlLiteralFormatFlags.UseQuotes)
                            jobProp.Add("Sequence")
                            job = Me.Context.Commands.LoadCollection("SLJobmatlCompliances", jobProp, sFilter, String.Empty, 1)

                            If job.Items.Count > 0 Then
                                iSequenceNo = job.Item(0, "Sequence").GetValue(Of Integer)(0)
                            End If

                            job = Nothing
                            jobProp = Nothing
                        End If

                        cfgComp = Nothing
                        cfgCompProp = Nothing
                    End If
                End If
            Else
                Exit For
            End If

            If IsNothing(sAttachTo) = True Then
                sAttachTo = ""
            Else
                sAttachTo = sAttachTo.ToLower()
            End If
            ' According OrderType to list table name out:
            If sAttachTo.ToLower() = "material" Or sAttachTo.ToLower() = "operation" Or sAttachTo.ToLower() = "job" Then
                Select Case sAttachTo
                    Case "material"
                        sSourceType = "JOBMATERIAL"
                    Case "operation"
                        sSourceType = "JOBOPERATION"
                    Case "job"
                        sSourceType = "JOB"
                    Case Else
                        sSourceType = String.Empty
                End Select

                If sAttachTo = "job" Then
                    sNewRefPointer = sRefRowPointer
                ElseIf sAttachTo = "material" Then
                    Dim job As New LoadCollectionResponseData
                    Dim jobProp As New PropertyList
                    sFilter = "JobRowPointer = " + SqlLiteral.Format(sRefRowPointer, SqlLiteralFormatFlags.UseQuotes) _
                        + " AND OperNum = " + CStr(iOperationNo) _
                        + " AND Sequence = " + CStr(iSequenceNo)
                    jobProp.Add("RowPointer")
                    job = Me.Context.Commands.LoadCollection("SLJobmatlCompliances", jobProp, sFilter, String.Empty, 1)

                    If job.Items.Count > 0 Then
                        sNewRefPointer = job.Item(0, "RowPointer").Value
                    Else
                        sNewRefPointer = String.Empty
                    End If

                    job = Nothing
                    jobProp = Nothing

                ElseIf sAttachTo = "operation" Then
                    If IsNothing(xDocumentXML.Root.Element("OperationNo")) = False Then
                        iOperationNo = CInt(xDocumentXML.Root.Element("OperationNo").Value)
                    Else
                        iOperationNo = 0
                    End If

                    Dim job As New LoadCollectionResponseData
                    Dim jobProp As New PropertyList
                    sFilter = "RowPointer = " + SqlLiteral.Format(sRefRowPointer, SqlLiteralFormatFlags.UseQuotes) _
                        + " And RouteOperNum = " + CStr(iOperationNo)
                    jobProp.Add("RouteRowPointer")
                    job = Me.Context.Commands.LoadCollection("SLJobRouteJobs", jobProp, sFilter, String.Empty, 1)

                    If job.Items.Count > 0 Then
                        sNewRefPointer = job.Item(0, "RouteRowPointer").Value
                    Else
                        sNewRefPointer = String.Empty
                    End If

                    job = Nothing
                    jobProp = Nothing
                End If
            End If

            Select Case sSourceType.ToUpper()
                Case "CO"
                    sTableName = "co"
                Case "COLINE"
                    sTableName = "coitem"
                Case "COQUICKENTRY"
                    sTableName = "co"
                Case "JOB"
                    sTableName = "job"
                Case "COBLN"
                    sTableName = "co"
                Case "EST"
                    sTableName = "co"
                Case "ESTLINE"
                    sTableName = "coitem"
                Case "ESTIMATEJOB"
                    sTableName = "job"
                Case "ESTQUICKENTRY"
                    sTableName = "co"
                Case "JOBOPERATION"
                    sTableName = "jobroute"
                Case "JOBMATERIAL"
                    sTableName = "jobmatl"
                Case Else
                    sTableName = ""
            End Select

            ' Here parse Document URL to get name, extension, type.
            Dim sFileName As String
            Dim sDocumentExtension As String
            Dim sDocumentType As String
            Dim sMediaType As String
            Dim iLastDotPosition As Integer
            Dim iLastCharPosition As Integer
            Dim iLastBackSlashPosition As Integer
            Dim iCount As Integer
            Dim sSlash As String

            iLastDotPosition = 0
            iLastBackSlashPosition = 0
            iLastCharPosition = sDocumentURL.Length - 1


            If IsValidUrl(sDocumentURL) = True Then
                sSlash = "/"
            Else
                sSlash = "\"
            End If

            For iCount = 0 To iLastCharPosition
                If sDocumentURL.Substring(iCount, 1) = sSlash Then
                    iLastBackSlashPosition = iCount
                End If
            Next

            sFileName = sDocumentURL.Substring(iLastBackSlashPosition + 1, iLastCharPosition - iLastBackSlashPosition)
            iCount = 0
            iLastCharPosition = sFileName.Length - 1

            For iCount = 0 To iLastCharPosition
                If sFileName.Substring(iCount, 1) = "." Then
                    iLastDotPosition = iCount
                End If
            Next

            sDocumentType = sFileName.Substring(iLastDotPosition + 1, iLastCharPosition - iLastDotPosition)
            sDocumentExtension = sDocumentType
            sFileName = sFileName.Substring(0, iLastDotPosition)

            Dim docType As New LoadCollectionResponseData
            Dim docTypeProp As New PropertyList
            sFilter = "DocumentType = " + SqlLiteral.Format(sDocumentType, SqlLiteralFormatFlags.UseQuotes)
            docTypeProp.Add("MediaType")
            docType = Me.Context.Commands.LoadCollection("DocumentTypes", docTypeProp, sFilter, String.Empty, 1)

            sMediaType = String.Empty
            GetCfgDbFile = False
            If docType.Items.Count = 0 Then
                sFilter = "DocumentType = 'CfgDbFile' AND StorageMethod = 'D'"
                GetCfgDbFile = True
                docType = Me.Context.Commands.LoadCollection("DocumentTypes", docTypeProp, sFilter, String.Empty, 1)
            End If

            If docType.Items.Count > 0 Then
                sMediaType = docType.Item(0, "MediaType").Value
                If GetCfgDbFile Then
                    sDocumentType = "CfgDbFile"
                    Try
                        ResponseData = Me.Context.Commands.Invoke("FileServerExtension", "GetMediaTypeAndBlobFormat", sDocumentExtension, String.Empty, String.Empty, String.Empty)

                        If Not ResponseData.Parameters(1).IsNull Then
                            sMediaType = ResponseData.Parameters(1).GetValue(Of String)()
                        End If
                    Catch ex As Exception
                        Infobar = "Error HandleDocumentAuto: Invoke FileServerExtension.GetMediaTypeAndBlobFormat Failed.   " + ex.Message.ToString()
                        Throw New MGException(Infobar)
                    End Try
                End If
            ElseIf GetCfgDbFile Then
                Infobar = "Error HandleDocumentAuto: DocumentType: CfgDbFile And StorageMethod: Database not found."
                Throw New MGException(Infobar)
            End If

            ' Here will call CU_DocumentsSp to store Document Auto
            Me.CU_DocumentsCa(sTableName _
                            , sNewRefPointer _
                            , sDocumentName _
                            , sDocumentDescr _
                            , sDocumentType _
                            , sDocumentExtension _
                            , sMediaType _
                            , bInternal _
                            , sDocumentURL _
                            , bFileContent _
                            , sRevision _
                            , sStatus _
                            , dtEffStartDate _
                            , dtEffEndDate _
                            , 1 _
                            , Infobar)

        Next

        cfgAttr = Nothing
        cfgAttrProp = Nothing

        Return 0

    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CU_DocumentsCa(
            ByVal TableName As String,
            ByVal RefRowPointer As String,
            ByVal DocumentName As String,
            ByVal DocumentDescr As String,
            ByVal DocumentType As String,
            ByVal DocumentExtension As String,
            ByVal MediaType As String,
            ByVal Internal As Byte,
            ByVal FileURL As String,
            ByVal FileContent As Byte?,
            ByVal Revision As String,
            ByVal Status As String,
            ByVal EffStartDate As DateTime?,
            ByVal EffEndDate As DateTime?,
            ByVal IsExternal As Byte,
            ByRef InfoBar As String) As Integer

        Dim Severity As String = String.Empty
        Dim InsertFlag As String = String.Empty
        Dim DocObjRowPointer As String = String.Empty
        Dim NewRowPointer As String = String.Empty
        Dim DocumentObject As Object = Nothing
        Dim FileBinary As Byte() = Nothing

        DocObjRowPointer = GetDocObjectRowPointer(TableName, RefRowPointer)


        If String.IsNullOrEmpty(DocObjRowPointer) Then
            InsertFlag = "1"
        Else
            InsertFlag = "0"
        End If

        If String.IsNullOrEmpty(DocumentName) Then
            InfoBar = Me.CreateAppDB.GetMessageProvider.GetMessage("E=NoCompare", "@DocumentObject.DocumentName", "@!blank")
            Throw New MGException(InfoBar)
        End If

        If String.IsNullOrEmpty(DocumentType) Then
            InfoBar = Me.CreateAppDB.GetMessageProvider.GetMessage("E=NoCompare", "@DocumentObject.DocumentType", "@!blank")
            Throw New MGException(InfoBar)
        End If

        If FileURL <> String.Empty Then
            FileBinary = GetFile(FileURL)
        ElseIf FileContent.HasValue Then
            FileBinary = New Byte(FileContent - 1) {}
        End If

        ' Perform INSERT OR UPDATE
        If InsertFlag = "1" Then
            Dim Sequence As Integer
            Dim RefSequence As Integer

            If IsObjectDocumentExist(DocumentName) = True Then
                Sequence = GetObjectSequence(DocumentName)
            Else
                Sequence = 1
            End If

            If IsObjectDocumentReferenceExist(TableName, RefRowPointer) = True Then
                RefSequence = GetObjectRefSequence(TableName, RefRowPointer)
            Else
                RefSequence = 1
            End If

            NewRowPointer = GetNewID()

            Try
                'Insert Into SLDocumentObjects 
                Dim insertItem3 As New IDOUpdateItem With {
                    .Action = UpdateAction.Insert,
                    .ItemNumber = 1
                }
                insertItem3.Properties.Add("DocumentName", DocumentName, True)
                insertItem3.Properties.Add("Sequence", Sequence, True)
                insertItem3.Properties.Add("Description", DocumentDescr, True)
                insertItem3.Properties.Add("DocumentType", DocumentType, True)
                insertItem3.Properties.Add("DocumentExtension", DocumentExtension, True)
                insertItem3.Properties.Add("Internal", Internal, True)
                insertItem3.Properties.Add("DocumentObject", FileBinary, True)
                insertItem3.Properties.Add("MediaType", MediaType, True)
                insertItem3.Properties.Add("RowPointer", NewRowPointer, True)

                'Insert Into SLDocumentObjectExts
                Dim insertItem5 As New IDOUpdateItem With {
                    .Action = UpdateAction.Insert,
                    .ItemNumber = 2
                }
                insertItem5.Properties.Add("DocumentObjectRowPointer", NewRowPointer, True)
                insertItem5.Properties.Add("Revision", Revision, True)
                insertItem5.Properties.Add("Status", Status.Substring(0, 1), True)
                insertItem5.Properties.Add("EffectiveStartDate", EffStartDate, True)
                insertItem5.Properties.Add("EffectiveEndDate", EffEndDate, True)
                insertItem5.Properties.Add("IsExternal", IsExternal, True)

                Dim insertRequestData5 As New UpdateCollectionRequestData("SLDocumentObjectExts")
                insertRequestData5.Items.Add(insertItem5)
                insertRequestData5.SetLinkBy("RowPointer", "DocumentObjectRowPointer")

                Dim insertRequestData3 As New UpdateCollectionRequestData("SLDocumentObjects")
                insertRequestData3.Items.Add(insertItem3)
                insertRequestData3.Items(0).AddNestedUpdate(insertRequestData5)
                Me.Context.Commands.UpdateCollection(insertRequestData3)

                'Insert Into SLDocumentObjectReferences 
                Dim insertItem2 As New IDOUpdateItem With {
                    .Action = UpdateAction.Insert,
                    .ItemNumber = 1
                }
                insertItem2.Properties.Add("TableName", TableName)
                insertItem2.Properties.Add("TableRowPointer", RefRowPointer)
                insertItem2.Properties.Add("RefSequence", RefSequence)
                insertItem2.Properties.Add("DocumentObjectRowPointer", NewRowPointer)
                Dim insertRequestData2 As New UpdateCollectionRequestData("SLDocumentObjectReferences")
                insertRequestData2.Items.Add(insertItem2)
                Me.Context.Commands.UpdateCollection(insertRequestData2)

                insertItem3 = Nothing
                insertItem5 = Nothing
                insertRequestData5 = Nothing
                insertRequestData3 = Nothing
                insertItem2 = Nothing
                insertRequestData2 = Nothing

            Catch ex As Exception
                InfoBar = ex.Message.ToString() + " Failed to Insert to SLDocumentObjectExts and SLDocumentObjects"
                Throw New MGException(InfoBar)
            End Try
        Else
            'Perform Update
            Try

                Dim loadResponseCollection As New LoadCollectionResponseData()
                Dim propertyList1 As New PropertyList()
                propertyList1.Add("RowPointer")
                Dim loadResponseCollection5 As New LoadCollectionResponseData()
                Dim propertyList5 As New PropertyList()
                propertyList5.Add("DocumentObjectRowPointer")

                Dim filter As String = String.Format("RowPointer = '{0}'", DocObjRowPointer)
                Dim filter5 As String = String.Format("DocumentObjectRowPointer = '{0}'", DocObjRowPointer)

                loadResponseCollection = Me.Context.Commands.LoadCollection("SLDocumentObjects", propertyList1, filter, String.Empty, 0)
                loadResponseCollection5 = Me.Context.Commands.LoadCollection("SLDocumentObjectExts", propertyList5, filter5, String.Empty, 0)

                Dim updateRequest As New UpdateCollectionRequestData("SLDocumentObjects")
                Dim updateRequest5 As New UpdateCollectionRequestData("SLDocumentObjectExts")

                For Each item As IDOItem In loadResponseCollection.Items

                    Dim updateItem As New IDOUpdateItem With {
                        .Action = UpdateAction.Update,
                        .ItemNumber = 1,
                        .ItemID = item.ItemID
                    }
                    'updateItem.Properties.Add("DocumentName", DocumentName); //may not be modified
                    updateItem.Properties.Add("DocumentType", DocumentType)
                    updateItem.Properties.Add("DocumentExtension", DocumentExtension)
                    updateItem.Properties.Add("DocumentObject", FileBinary)
                    updateRequest.Items.Add(updateItem)

                    Me.Context.Commands.UpdateCollection(updateRequest)
                Next
                ' flush now because SLDocumentObjectExts is a sub collection of SLDocumentObjects 
                ' and might overwrite the next code with delayed garbage collection.
                updateRequest = Nothing
                loadResponseCollection = Nothing
                propertyList1 = Nothing

                For Each item As IDOItem In loadResponseCollection5.Items

                    Dim updateItem5 As New IDOUpdateItem With {
                        .Action = UpdateAction.Update,
                        .ItemNumber = 1,
                        .ItemID = item.ItemID
                    }
                    updateItem5.Properties.Add("Revision", Revision)

                    updateRequest5.Items.Add(updateItem5)

                    Me.Context.Commands.UpdateCollection(updateRequest5)
                Next

                updateRequest5 = Nothing
                loadResponseCollection5 = Nothing
                propertyList5 = Nothing

            Catch ex As Exception
                InfoBar = ex.Message.ToString() + " Failed To Update SLDocumentObjects/SLDocumentObjectExts"
                Throw New MGException(InfoBar)
            End Try
        End If
        Return 0
    End Function
    Private Function ExecuteSingleQuery(ByVal CollectionName As String, ByVal Filter As String, ByVal Prop As String) As String


        Dim job As New LoadCollectionResponseData
        Dim jobProp As New PropertyList
        Dim tempString As String = ""

        jobProp.Add(Prop)

        job = Context.Commands.LoadCollection(CollectionName, jobProp, Filter, String.Empty, 1)

        If job.Items.Count > 0 Then
            tempString = job.Item(0, Prop).Value
        Else
            tempString = ""
        End If

        job = Nothing
        jobProp = Nothing

        Return tempString
    End Function
    Private Shared Function IsValidUrl(ByVal urlString As String) As Boolean
        Dim uri__1 As Uri = Nothing
        Return Uri.TryCreate(urlString, UriKind.Absolute, uri__1) AndAlso (uri__1.Scheme = Uri.UriSchemeHttp OrElse uri__1.Scheme = Uri.UriSchemeHttps OrElse uri__1.Scheme = Uri.UriSchemeFtp OrElse uri__1.Scheme = Uri.UriSchemeMailto)

    End Function

    Public Function GetNewID() As String
        Dim NewGuid As Guid
        NewGuid = Guid.NewGuid()
        Return NewGuid.ToString()
    End Function

    Public Function GetObjectSequence(ByVal DocumentName As String) As Integer
        Dim TempValue As Integer = 1
        Dim IsParsed As Boolean = False

        Dim propList As New PropertyList(New [String]() {"Sequence"})
        Dim idoName As String = "SLDocumentObjects"
        Dim filter As String = String.Format("DocumentName = '{0}'", DocumentName)
        Dim recordCap As Integer = 1

        Dim DocumentObjectRefView As LoadCollectionResponseData = Me.Context.Commands.LoadCollection(idoName, propList, filter, "Sequence desc", recordCap)

        If DocumentObjectRefView.Items.Count > 0 Then
            IsParsed = Integer.TryParse(DocumentObjectRefView.Items(0).PropertyValues(0).GetValue(Of String)(), TempValue)
        End If

        If IsParsed Then
            TempValue += 1
        Else
            TempValue = 1
        End If

        Return TempValue
    End Function

    Public Function GetObjectRefSequence(ByVal TableName As String, ByVal RefRowPointer As String) As Integer
        Dim TempValue As Integer = 1
        Dim IsParsed As Boolean = False

        Dim propList As New PropertyList(New [String]() {"RefSequence"})
        Dim idoName As String = "SLDocumentObjectReferences"
        Dim filter As String = String.Format("TableName = '{0}' and TableRowPointer = '{1}'", TableName, RefRowPointer)
        Dim recordCap As Integer = 1
        Dim orderby As String = "TableName, TableRowPointer, RefSequence DESC"

        Dim DocumentObjectRefView As LoadCollectionResponseData = Me.Context.Commands.LoadCollection(idoName, propList, filter, orderby, recordCap)

        If DocumentObjectRefView.Items.Count > 0 Then
            IsParsed = Integer.TryParse(DocumentObjectRefView.Items(0).PropertyValues(0).GetValue(Of String)(), TempValue)
        End If

        If IsParsed Then
            TempValue += 1
        Else
            TempValue = 1
        End If

        Return TempValue
    End Function

    Public Function IsObjectDocumentExist(ByVal DocumentName As String) As Boolean
        Dim ReturnValue As Boolean = False

        Dim propList As New PropertyList(New [String]() {"DocumentName"})
        Dim idoName As String = "SLDocumentObjects"
        Dim filter As String = String.Format("DocumentName = '{0}'", DocumentName)
        Dim recordCap As Integer = 1

        Dim DocumentObjectRefView As LoadCollectionResponseData = Me.Context.Commands.LoadCollection(idoName, propList, filter, String.Empty, recordCap)

        If DocumentObjectRefView.Items.Count > 0 Then
            ReturnValue = True
        End If

        Return ReturnValue
    End Function

    Public Function IsObjectDocumentReferenceExist(ByVal TableName As String, ByVal RefRowPointer As String) As Boolean
        Dim ReturnValue As Boolean = False

        Dim propList As New PropertyList(New [String]() {"TableName", "TableRowPointer"})
        Dim idoName As String = "SLDocumentObjectReferences"
        Dim filter As String = String.Format("TableName = '{0}' and TableRowPointer = '{1}'", TableName, RefRowPointer)
        Dim recordCap As Integer = 1

        Dim DocumentObjectRefView As LoadCollectionResponseData = Me.Context.Commands.LoadCollection(idoName, propList, filter, String.Empty, recordCap)

        If DocumentObjectRefView.Items.Count > 0 Then
            ReturnValue = True
        End If

        Return ReturnValue
    End Function

    Public Function GetDocObjectRowPointer(ByVal TableName As String, ByVal TableRowPointer As String) As String
        Dim tempString As String = String.Empty
        Try
            Dim propList As New PropertyList(New [String]() {"RowPointer"})
            Dim idoName As String = "SLDocumentObjectAndReferences"
            Dim filter As String = String.Format("TableName = '{0}' and TableRowPointer = '{1}'", TableName, TableRowPointer)

            Dim recordCap As Integer = 1

            Dim DocumentObjectRefView As LoadCollectionResponseData = Me.Context.Commands.LoadCollection(idoName, propList, filter, String.Empty, recordCap)

            If DocumentObjectRefView.Items.Count > 0 Then
                tempString = DocumentObjectRefView.Items(0).PropertyValues(0).GetValue(Of String)()
            End If
        Catch generatedExceptionName As Exception
            tempString = String.Empty
        End Try
        Return tempString
    End Function

    Public Function GetFile(ByVal path As String) As Byte()
        Dim IsURL As Boolean = False
        Dim b As Byte() = Nothing

        IsURL = IsValidUrl(path)

        If IsURL = True Then
            Dim sMetadataInstance As String = GetMetadataInstance()
            Dim sAuthenticationKey As String = GetAuthenticationKey()
            Dim sApplID As String = GetDocConfigServer()
            Dim sConfiguratorURL As String = GetConfiguratorURL()
            Dim hostServices As TDCI.BuyDesign.Configurator.Integration.Win.HostServices
            Dim file As New TDCI.BuyDesign.Configurator.Integration.Data.Outputs.FileContent()

            If IDONull.IsNull(sAuthenticationKey) Or sAuthenticationKey = "" Then
                hostServices = New TDCI.BuyDesign.Configurator.Integration.Win.HostServices(sMetadataInstance, sApplID, sConfiguratorURL)
            Else
                hostServices = New TDCI.BuyDesign.Configurator.Integration.Win.HostServices(sMetadataInstance, sApplID, sConfiguratorURL, sAuthenticationKey)
            End If

            file = hostServices.GetContent(path)
            b = file.Blob()
        Else
            b = file.ReadAllBytes(path)
        End If

        Return b
    End Function



    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CfgPurgeUtilitySp(ByVal pDelSymcfg As Byte?, ByVal pBegDate As DateTime?, ByVal pEndDate As DateTime?, ByRef pRecCnt As Integer?, ByRef Infobar As String,
<[Optional]> ByVal StartingDateOffset As Short?,
<[Optional]> ByVal EndingDateOffset As Short?, ByVal ListConfigs As Byte?) As DataTable
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim iCfgPurgeUtilityExt = New CfgPurgeUtilityFactory().Create(appDb, bunchedLoadCollection)
            Dim result = iCfgPurgeUtilityExt.CfgPurgeUtilitySp(pDelSymcfg, pBegDate, pEndDate, pRecCnt, Infobar, StartingDateOffset, EndingDateOffset, ListConfigs)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            pRecCnt = result.pRecCnt
            Infobar = result.Infobar
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_GetCfgInfor(ByVal ConfigId As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))

            Dim iCLM_GetCfgInfExt As ICLM_GetCfgInf = New CLM_GetCfgInfFactory().Create(appDb, bunchedLoadCollection)

            Dim dt As DataTable = iCLM_GetCfgInfExt.CLM_GetCfgInfor(ConfigId)

            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CopyRoutingBOMPredisplaySp(ByVal pOldConfigID As String, ByVal pNewCoNum As String, ByVal pNewCoLine As Short?, ByVal pNewCoRelease As Short?, ByVal pNewJob As String, ByVal pNewSuffix As Short?, ByVal pNewItem As String, ByVal pRecType As String, ByVal pKey1 As String, ByVal pKey2 As String, ByVal pKey3 As String, ByVal pNewConfigGid As String, ByVal pConfigurator As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim MGInvoker = New MGInvoker(Me.Context)
            Dim iCopyRoutingBOMPredisplayExt = New CopyRoutingBOMPredisplayFactory().Create(Me, True)
            Dim result = iCopyRoutingBOMPredisplayExt.CopyRoutingBOMPredisplaySp(pOldConfigID, pNewCoNum, pNewCoLine, pNewCoRelease, pNewJob, pNewSuffix, pNewItem, pRecType, pKey1, pKey2, pKey3, pNewConfigGid, pConfigurator, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CfgClearRefsSp(ByVal pConfigId As String, ByVal pJobFlag As Byte?, ByVal pJob As String, ByVal pSuffix As Short?, ByRef Infobar As String) As Integer Implements ISLCfgMains.CfgClearRefsSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iCfgClearRefsExt As ICfgClearRefs = New CfgClearRefsFactory().Create(appDb)

            Dim Severity As Integer = iCfgClearRefsExt.CfgClearRefsSp(pConfigId, pJobFlag, pJob, pSuffix, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CfgCopyConfigSp(ByVal pOldConfigID As String, ByVal pNewCoNum As String, ByVal pNewCoLine As Short?, ByVal pNewCoRelease As Short?, ByVal pNewJob As String, ByVal pNewSuffix As Short?, ByVal pNewItem As String, ByVal pNewConfigGid As String, ByVal pConfigurator As String, ByRef Infobar As String) As Integer Implements ISLCfgMains.CfgCopyConfigSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker = New MGInvoker(Me.Context)
            Dim iCfgCopyConfigExt = New CfgCopyConfigFactory().Create(Me, True)
            Dim result = iCfgCopyConfigExt.CfgCopyConfigSp(pOldConfigID, pNewCoNum, pNewCoLine, pNewCoRelease, pNewJob, pNewSuffix, pNewItem, pNewConfigGid, pConfigurator, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CfgDeleteRefsSp(ByVal pConfigId As String, ByVal pJobFlag As Byte?, ByVal pJob As String, ByVal pSuffix As Short?, ByRef Infobar As String) As Integer Implements ISLCfgMains.CfgDeleteRefsSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iCfgDeleteRefsExt As ICfgDeleteRefs = New CfgDeleteRefsFactory().Create(appDb)

            Dim Severity As Integer = iCfgDeleteRefsExt.CfgDeleteRefsSp(pConfigId, pJobFlag, pJob, pSuffix, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CfgIPNCheckSp(ByVal pConfigId As String, ByVal pCEP As String, ByRef pIpn As Byte?, ByRef pNewItem As String, ByVal CloneSite As String, ByRef Infobar As String) As Integer Implements ISLCfgMains.CfgIPNCheckSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker = New MGInvoker(Me.Context)
            Dim iCfgIPNCheckExt = New CfgIPNCheckFactory().Create(Me, True)
            Dim result = iCfgIPNCheckExt.CfgIPNCheckSp(pConfigId, pCEP, pIpn, pNewItem, CloneSite, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            pIpn = result.pIpn
            pNewItem = result.pNewItem
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CfgNextCfgIdSp(ByRef Key As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iCfgNextCfgIdExt As ICfgNextCfgId = New CfgNextCfgIdFactory().Create(appDb)

            Dim Severity As Integer = iCfgNextCfgIdExt.CfgNextCfgIdSp(Key, Infobar)

            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CfgSetConfigIdSp(ByVal ConfigEntryPoint As String, ByVal Key1 As String, ByVal Key2 As String, ByVal Key3 As String, ByVal ConfigId As String, ByRef ConfigGid As String,
<[Optional], DefaultParameterValue(CByte(0))> ByVal IsDocId As Byte?) As Integer Implements ISLCfgMains.CfgSetConfigIdSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iCfgSetConfigIdExt = New CfgSetConfigIdFactory().Create(appDb)
            Dim result = iCfgSetConfigIdExt.CfgSetConfigIdSp(ConfigEntryPoint, Key1, Key2, Key3, ConfigId, ConfigGid, IsDocId)
            Dim Severity As Integer = result.ReturnCode.Value
            ConfigGid = result.ConfigGid
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetCfgParmsSp(
<[Optional], DefaultParameterValue("")> ByRef ConfigServerId As String,
<[Optional], DefaultParameterValue("")> ByRef ConfigHeaderNameSpace As String,
<[Optional], DefaultParameterValue("")> ByRef Configurator As String,
<[Optional], DefaultParameterValue("")> ByRef ConfiguratorURL As String,
<[Optional], DefaultParameterValue("")> ByRef MetadataInstance As String,
<[Optional], DefaultParameterValue("")> ByRef AuthenticationKey As String,
<[Optional]> ByVal Site As String) As Integer Implements ISLCfgMains.GetCfgParmsSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iGetCfgParmsExt As IGetCfgParms = New GetCfgParmsFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, ConfigServerId As String, ConfigHeaderNameSpace As String, Configurator As String, ConfiguratorURL As String, MetadataInstance As String, AuthenticationKey As String) = iGetCfgParmsExt.GetCfgParmsSp(ConfigServerId, ConfigHeaderNameSpace, Configurator, ConfiguratorURL, MetadataInstance, AuthenticationKey, Site)
            Dim Severity As Integer = result.ReturnCode.Value
            ConfigServerId = result.ConfigServerId
            ConfigHeaderNameSpace = result.ConfigHeaderNameSpace
            Configurator = result.Configurator
            ConfiguratorURL = result.ConfiguratorURL
            MetadataInstance = result.MetadataInstance
            AuthenticationKey = result.AuthenticationKey
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetQueueConfigurationSp(ByVal ConfigId As String, ByRef QueuePostConfiguration As String, ByRef QueuePostConfigurationMessage As String, ByRef QueueRequestID As String, ByRef QueueStatus As String, ByRef QueueType As String) As Integer Implements ISLCfgMains.GetQueueConfigurationSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iGetQueueConfigurationExt As IGetQueueConfiguration = New GetQueueConfigurationFactory().Create(appDb)

            Dim Severity As Integer = iGetQueueConfigurationExt.GetQueueConfigurationSp(ConfigId, QueuePostConfiguration, QueuePostConfigurationMessage, QueueRequestID, QueueStatus, QueueType)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PortalCfgDoConfigSp(ByVal pConfigId As String, ByVal pCep As String, ByVal pCreateJob As Byte?, ByVal pRunFrom As String, ByVal pRunMode As String, ByVal pUpdatePrice As Byte?, ByRef DoRefresh As Byte?, ByRef Infobar As String, ByRef Warning As Byte?, ByRef SessionID As Guid?) As Integer Implements ISLCfgMains.PortalCfgDoConfigSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iPortalCfgDoConfigExt As IPortalCfgDoConfig = New PortalCfgDoConfigFactory().Create(appDb)

            Dim Severity As Integer = iPortalCfgDoConfigExt.PortalCfgDoConfigSp(pConfigId, pCep, pCreateJob, pRunFrom, pRunMode, pUpdatePrice, DoRefresh, Infobar, Warning, SessionID)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function UpdateCfgStatusSp(ByVal ConfigId As String, ByVal StatusAttrValue As String, ByVal MsgAttrValue As String, ByVal QueueIDValue As String) As Integer Implements ISLCfgMains.UpdateCfgStatusSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iUpdateCfgStatusExt As IUpdateCfgStatus = New UpdateCfgStatusFactory().Create(appDb)

            Dim Severity As Integer = iUpdateCfgStatusExt.UpdateCfgStatusSp(ConfigId, StatusAttrValue, MsgAttrValue, QueueIDValue)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function BDCCreateJobSp(ByVal sConfigID As String, ByVal sOrderType As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker = New MGInvoker(Me.Context)
            Dim iBDCCreateJobExt = New BDCCreateJobFactory().Create(Me, True)
            Dim result = iBDCCreateJobExt.BDCCreateJobSp(sConfigID, sOrderType, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CfgConfigurationForBGJobCreationSp(ByVal pConfigId As String, ByRef CreateBGFlag As Integer?) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCfgConfigurationForBGJobCreationExt As ICfgConfigurationForBGJobCreation = New CfgConfigurationForBGJobCreationFactory().Create(Me, True)
            Dim result As (ReturnCode As Integer?, CreateBGFlag As Integer?) = iCfgConfigurationForBGJobCreationExt.CfgConfigurationForBGJobCreationSp(pConfigId, CreateBGFlag)
            Dim Severity As Integer = result.ReturnCode.Value
            CreateBGFlag = result.CreateBGFlag
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CfgDoConfigSp(ByVal pConfigId As String, ByVal pCep As String, ByVal pCreateJob As Byte?, ByVal pRunFrom As String, ByVal pRunMode As String, ByVal pUpdatePrice As Byte?, ByRef DoRefresh As Byte?, ByRef Infobar As String, ByRef Warning As Byte?) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCfgDoConfigExt As ICfgDoConfig = New CfgDoConfigFactory().Create(Me, True)
            Dim result As (ReturnCode As Integer?, DoRefresh As Integer?, Infobar As String, Warning As Integer?) = iCfgDoConfigExt.CfgDoConfigSp(pConfigId, pCep, pCreateJob, pRunFrom, pRunMode, pUpdatePrice, DoRefresh, Infobar, Warning)
            Dim Severity As Integer = result.ReturnCode.Value
            DoRefresh = result.DoRefresh
            Infobar = result.Infobar
            Warning = result.Warning
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetCfgGroupNameSp(ByVal UserName As String, ByRef GroupName As String, ByRef Infobar As String) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim iGetCfgGroupNameExt As IGetCfgGroupName = New GetCfgGroupNameFactory().Create(Me, True)
            Dim result As (ReturnCode As Integer?, GroupName As String, Infobar As String) = iGetCfgGroupNameExt.GetCfgGroupNameSp(UserName, GroupName, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            GroupName = result.GroupName
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetDocCfgParmsSp(
        <[Optional], DefaultParameterValue("")> ByRef DocConfigServerId As String,
        <[Optional], DefaultParameterValue("")> ByRef DocConfigNameSpace As String,
        <[Optional], DefaultParameterValue("")> ByRef Configurator As String,
        <[Optional], DefaultParameterValue("")> ByRef ConfiguratorURL As String,
        <[Optional], DefaultParameterValue("")> ByRef MetadataInstance As String,
        <[Optional], DefaultParameterValue("")> ByRef AuthenticationKey As String,
        <[Optional]> ByVal Site As String) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iGetDocCfgParmsExt As IGetDocCfgParms = New GetDocCfgParmsFactory().Create(Me, True)
            Dim result As (ReturnCode As Integer?, DocConfigServerId As String, DocConfigNameSpace As String, Configurator As String, ConfiguratorURL As String, MetadataInstance As String, AuthenticationKey As String) = iGetDocCfgParmsExt.GetDocCfgParmsSp(DocConfigServerId, DocConfigNameSpace, Configurator, ConfiguratorURL, MetadataInstance, AuthenticationKey, Site)
            Dim Severity As Integer = result.ReturnCode.Value
            DocConfigServerId = result.DocConfigServerId
            DocConfigNameSpace = result.DocConfigNameSpace
            Configurator = result.Configurator
            ConfiguratorURL = result.ConfiguratorURL
            MetadataInstance = result.MetadataInstance
            AuthenticationKey = result.AuthenticationKey
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function SetAvailCfgSp(ByRef AvailCfg As Integer?,
        <[Optional]> ByVal PSite As String) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim iSetAvailCfgExt As ISetAvailCfg = New SetAvailCfgFactory().Create(Me, True)
            Dim result As (ReturnCode As Integer?, AvailCfg As String) = iSetAvailCfgExt.SetAvailCfgSp(AvailCfg, PSite)
            Dim Severity As Integer = result.ReturnCode.Value
            AvailCfg = result.AvailCfg
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CfgValidateGIDSp(ByVal pNewConfigGID As String, ByRef Infobar As String) As Integer
        Dim iCfgValidateGIDExt As ICfgValidateGID = New CfgValidateGIDFactory().Create(Me, True)
        Dim result As (ReturnCode As Integer?, Infobar As String) = iCfgValidateGIDExt.CfgValidateGIDSp(pNewConfigGID, Infobar)
        Dim Severity As Integer = result.ReturnCode.Value
        Infobar = result.Infobar
        Return Severity
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CfgGetSitesSp(ByVal RefNum As String, ByRef FromSite As String, ByRef ToSite As String, ByRef Infobar As String) As Integer
        Dim iCfgGetSitesExt As ICfgGetSites = New CfgGetSitesFactory().Create(Me, True)
        Dim result As (ReturnCode As Integer?, FromSite As String, ToSite As String, Infobar As String) = iCfgGetSitesExt.CfgGetSitesSp(RefNum, FromSite, ToSite, Infobar)
        Dim Severity As Integer = result.ReturnCode.Value
        FromSite = result.FromSite
        ToSite = result.ToSite
        Infobar = result.Infobar
        Return Severity
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CfgReSetConfigIdSp(ByVal ConfigEntryPoint As String, ByVal Key1 As String, ByVal Key2 As String, ByVal Key3 As String, ByVal ConfigId As String, ByRef ConfigGid As String,
        <[Optional], DefaultParameterValue(0)> ByVal IsDocId As Integer?) As Integer
        Dim iCfgReSetConfigIdExt As ICfgReSetConfigId = New CfgReSetConfigIdFactory().Create(Me, True)
        Dim result As (ReturnCode As Integer?, ConfigGid As String) = iCfgReSetConfigIdExt.CfgReSetConfigIdSp(ConfigEntryPoint, Key1, Key2, Key3, ConfigId, ConfigGid, IsDocId)
        Dim Severity As Integer = result.ReturnCode.Value
        ConfigGid = result.ConfigGid
        Return Severity
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CfgMapConfiguration_DeleteSp(ByVal TargetConfigID As String, ByRef Infobar As String) As Integer
        Dim iCfgMapConfiguration_DeleteExt As ICfgMapConfiguration_Delete = New CfgMapConfiguration_DeleteFactory().Create(Me, True)
        Dim result As (ReturnCode As Integer?, Infobar As String) = iCfgMapConfiguration_DeleteExt.CfgMapConfiguration_DeleteSp(TargetConfigID, Infobar)
        Dim Severity As Integer = result.ReturnCode.Value
        Infobar = result.Infobar
        Return Severity
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CfgGetPricingInfoSp(ByVal pConfigId As String, ByRef pDoPricing As Integer?, ByRef pUseModelPrice As Integer?, ByRef pBasePrice As Decimal?, ByRef Infobar As String) As Integer
        Dim iCfgGetPricingInfoExt As ICfgGetPricingInfo = New CfgGetPricingInfoFactory().Create(Me, True)
        Dim result As (ReturnCode As Integer?, pDoPricing As Integer?, pUseModelPrice As Integer?, pBasePrice As Decimal?, Infobar As String) = iCfgGetPricingInfoExt.CfgGetPricingInfoSp(pConfigId, pDoPricing, pUseModelPrice, pBasePrice, Infobar)
        Dim Severity As Integer = result.ReturnCode.Value
        pDoPricing = result.pDoPricing
        pUseModelPrice = result.pUseModelPrice
        pBasePrice = result.pBasePrice
        Infobar = result.Infobar
        Return Severity
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CfgGetOrigSiteSp(ByVal CoNum As String, ByRef OrigSite As String, ByRef Infobar As String) As Integer
        Dim iCfgGetOrigSiteExt As ICfgGetOrigSite = New CfgGetOrigSiteFactory().Create(Me, True)
        Dim result As (ReturnCode As Integer?, OrigSite As String, Infobar As String) = iCfgGetOrigSiteExt.CfgGetOrigSiteSp(CoNum, OrigSite, Infobar)
        Dim Severity As Integer = result.ReturnCode.Value
        OrigSite = result.OrigSite
        Infobar = result.Infobar
        Return Severity
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CfgShipSiteInsertSp(ByVal co_num As String, ByVal co_line As String, ByVal config_type As String, ByVal site As String, ByRef Infobar As String) As Integer
        Dim iCfgShipSiteInsertExt As ICfgShipSiteInsert = New CfgShipSiteInsertFactory().Create(Me, True)
        Dim result As (ReturnCode As Integer?, Infobar As String) = iCfgShipSiteInsertExt.CfgShipSiteInsertSp(co_num, co_line, config_type, site, Infobar)
        Dim Severity As Integer = result.ReturnCode.Value
        Infobar = result.Infobar
        Return Severity
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CfgMapConfigurationDataWriteXMLSp(ByVal TableName As String, ByVal XMLString As String, ByRef Infobar As String) As Integer
        Dim iCfgMapConfigurationDataWriteXMLExt As ICfgMapConfigurationDataWriteXML = New CfgMapConfigurationDataWriteXMLFactory().Create(Me, True)
        Dim result As (ReturnCode As Integer?, Infobar As String) = iCfgMapConfigurationDataWriteXMLExt.CfgMapConfigurationDataWriteXMLSp(TableName, XMLString, Infobar)
        Dim Severity As Integer = result.ReturnCode.Value
        Infobar = result.Infobar
        Return Severity
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CfgGetStatSp(ByVal TrnNum As String, ByVal TrnLine As Integer?, ByRef ConfigStatus As String, ByRef CoNum As String, ByRef CoLine As Integer?, ByRef CoRelease As Integer?, ByRef Infobar As String) As Integer
        Dim iCfgGetStatExt As ICfgGetStat = New CfgGetStatFactory().Create(Me, True)
        Dim result As (ReturnCode As Integer?, ConfigStatus As String, CoNum As String, CoLine As Integer?, CoRelease As Integer?, Infobar As String) = iCfgGetStatExt.CfgGetStatSp(TrnNum, TrnLine, ConfigStatus, CoNum, CoLine, CoRelease, Infobar)
        Dim Severity As Integer = result.ReturnCode.Value
        ConfigStatus = result.ConfigStatus
        CoNum = result.CoNum
        CoLine = result.CoLine
        CoRelease = result.CoRelease
        Infobar = result.Infobar
        Return Severity
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CfgGetOrigSiteViaTransferSp(ByVal pCep As String, ByVal pCoNum As String, ByVal pCoLine As Integer?, ByVal pTrnNum As String, ByVal pTrnLine As Integer?, ByRef pOrigSite As String, ByRef Infobar As String) As Integer
        Dim iCfgGetOrigSiteViaTransferExt As ICfgGetOrigSiteViaTransfer = New CfgGetOrigSiteViaTransferFactory().Create(Me, True)
        Dim result As (ReturnCode As Integer?, pOrigSite As String, Infobar As String) = iCfgGetOrigSiteViaTransferExt.CfgGetOrigSiteViaTransferSp(pCep, pCoNum, pCoLine, pTrnNum, pTrnLine, pOrigSite, Infobar)
        Dim Severity As Integer = result.ReturnCode.Value
        pOrigSite = result.pOrigSite
        Infobar = result.Infobar
        Return Severity
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CfgUpdateConfigGidSp(ByVal pRecType As String, ByVal pKey1 As String, ByVal pKey2 As String, ByVal pKey3 As String, ByVal pConfigGid As String) As Integer
        Dim iCfgUpdateConfigGidExt As ICfgUpdateConfigGid = New CfgUpdateConfigGidFactory().Create(Me, True)
        Dim result As Integer? = iCfgUpdateConfigGidExt.CfgUpdateConfigGidSp(pRecType, pKey1, pKey2, pKey3, pConfigGid)
        Dim Severity As Integer = result.Value
        Return Severity
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CfgGetCoNumSp(ByVal ConfigId As String, ByRef CoNum As String, ByRef CoLine As Integer?, ByRef Infobar As String) As Integer
        Dim iCfgGetCoNumExt As ICfgGetCoNum = New CfgGetCoNumFactory().Create(Me, True)
        Dim result As (ReturnCode As Integer?, CoNum As String, CoLine As Integer?, Infobar As String) = iCfgGetCoNumExt.CfgGetCoNumSp(ConfigId, CoNum, CoLine, Infobar)
        Dim Severity As Integer = result.ReturnCode.Value
        CoNum = result.CoNum
        CoLine = result.CoLine
        Infobar = result.Infobar
        Return Severity
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CfgCheckRefsSp(ByVal PConfigId As String, ByVal PJobFlag As Integer?, ByRef PReconfigOk As Integer?, ByRef Infobar As String) As Integer
        Dim iCfgCheckRefsExt As ICfgCheckRefs = New CfgCheckRefsFactory().Create(Me, True)
        Dim result As (ReturnCode As Integer?, PReconfigOk As Integer?, Infobar As String) = iCfgCheckRefsExt.CfgCheckRefsSp(PConfigId, PJobFlag, PReconfigOk, Infobar)
        Dim Severity As Integer = result.ReturnCode.Value
        PReconfigOk = result.PReconfigOk
        Infobar = result.Infobar
        Return Severity
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CfgJobConfigSp(ByVal pCreateJob As Integer?, ByVal pFrom As String, ByVal pJobtype As String, ByVal pConfigId As String, ByVal pCfgItem As String, ByVal pCoNum As String, ByVal pCoLine As Integer?, ByVal pCoRel As Integer?, ByRef pJob As String, ByRef pSuffix As Integer?, ByRef CurWhse As String, ByRef Infobar As String,
        <[Optional], DefaultParameterValue(1)> ByVal DelJobNote As Integer?) As Integer
        Dim iCfgJobConfigExt As ICfgJobConfig = New CfgJobConfigFactory().Create(Me, True)
        Dim result As (ReturnCode As Integer?, pJob As String, pSuffix As Integer?, CurWhse As String, Infobar As String) = iCfgJobConfigExt.CfgJobConfigSp(pCreateJob, pFrom, pJobtype, pConfigId, pCfgItem, pCoNum, pCoLine, pCoRel, pJob, pSuffix, CurWhse, Infobar, DelJobNote)
        Dim Severity As Integer = result.ReturnCode.Value
        pJob = result.pJob
        pSuffix = result.pSuffix
        CurWhse = result.CurWhse
        Infobar = result.Infobar
        Return Severity
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CfgGetFieldsSp(ByVal pFile As String, ByVal pInclude As Integer?) As Integer
        Dim iCfgGetFieldsExt As ICfgGetFields = New CfgGetFieldsFactory().Create(Me, True)
        Dim result As Integer? = iCfgGetFieldsExt.CfgGetFieldsSp(pFile, pInclude)
        Dim Severity As Integer = result.Value
        Return Severity
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CfgPreConfigSp(ByVal pPermit As String, ByVal pCep As String, ByRef pItem As String, ByRef CfgModel As String, ByVal pCoNum As String, ByVal pCoLine As Integer?, ByVal pCoRelease As Integer?, ByVal pJob As String, ByVal pSuffix As Integer?, ByVal pRunFrom As String, ByVal ShipSite As String, ByRef Infobar As String) As Integer
        Dim iCfgPreConfigExt As ICfgPreConfig = New CfgPreConfigFactory().Create(Me, True)
        Dim result As (ReturnCode As Integer?, pItem As String, CfgModel As String, Infobar As String) = iCfgPreConfigExt.CfgPreConfigSp(pPermit, pCep, pItem, CfgModel, pCoNum, pCoLine, pCoRelease, pJob, pSuffix, pRunFrom, ShipSite, Infobar)
        Dim Severity As Integer = result.ReturnCode.Value
        pItem = result.pItem
        CfgModel = result.CfgModel
        Infobar = result.Infobar
        Return Severity
    End Function

End Class

