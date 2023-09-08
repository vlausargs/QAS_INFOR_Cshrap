Imports Infor.DocumentManagement.ICP
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO
Imports Mongoose.Core.Common
Imports System.IO
Imports Newtonsoft.Json
Imports System.Text
Imports CSI.MG
Imports Mongoose.IDO.DataAccess
Imports CSI.Admin
Imports CSI.Data.RecordSets
Imports System.Runtime.InteropServices

<IDOExtensionClass("LoadJSONVar")>
Public Class SLFormExtMsgEntities
    Inherits ExtensionClassBase
    <IDOMethod(MethodFlags.None)>
    Public Function LoadJSONVar(ByVal FormnameAndDrillbackFormname As String, ByRef jSONVarUnFormated As String) As Integer
        Dim formName As String = ""
        Dim drillbackFormname As String = ""
        Dim filter As String
        Dim formExtMsgResponse As LoadCollectionResponseData
        Dim formExtMsgAttrResponse As LoadCollectionResponseData
        Dim formPrefixResponse As LoadCollectionResponseData
        Dim formPrefix As String
        Dim entrysb As StringBuilder = New StringBuilder()
        Dim bodsb As StringBuilder = New StringBuilder()
        Dim datasb As StringBuilder = New StringBuilder()
        Dim datasw As StringWriter = New StringWriter(datasb)
        Dim formExtMsgList As List(Of FormExtMsgEntity) = New List(Of FormExtMsgEntity)()
        Dim formExtMsgAttrList As List(Of FormExtMsgEntityAttribute) = New List(Of FormExtMsgEntityAttribute)()
        Dim formLambda As String
        Dim vLogicalID As String
        Dim splitIndex As Integer = FormnameAndDrillbackFormname.IndexOf(",")

        If splitIndex = -1 Then
            formName = FormnameAndDrillbackFormname
            drillbackFormname = FormnameAndDrillbackFormname
        Else
            formName = Left(FormnameAndDrillbackFormname, splitIndex)
            drillbackFormname = Right(FormnameAndDrillbackFormname, Len(FormnameAndDrillbackFormname) - splitIndex - 1)
        End If
        formLambda = formName

        vLogicalID = "V(Parm_MsgBusLogicalId)"
        filter = "FormName = '" + formName + "'"
        formPrefix = String.Empty

        formExtMsgResponse = LoadIDO(filter, "SLFormExtMsgEntities", "ExtMsgEntity", "ExtMsgEntity")
        formExtMsgAttrResponse = LoadIDO(filter, "SLFormExtMsgEntityAttrs", "ExtMsgEntity,Type,Attribute,Value", "ExtMsgEntity,Type")
        formPrefixResponse = LoadIDO("DefaultType = 55", "SystemProcessDefaults", "DefaultValue", "")

        If formPrefixResponse.Items.Count > 0 Then
            formPrefix = formPrefixResponse(0, "DefaultValue").Value
        End If

        ReadCollectionToEntity(formExtMsgResponse, formExtMsgList, formName)
        ReadCollectionToEntity(formExtMsgAttrResponse, formExtMsgAttrList, formName)

        'Build data area
        Using dataWriter As JsonWriter = New JsonTextWriter(datasw)
            dataWriter.WriteStartObject()
            dataWriter.WritePropertyName("screenId")
            dataWriter.WriteValue(formPrefix + drillbackFormname)
            dataWriter.WritePropertyName("logicalId")
            dataWriter.WriteValue(vLogicalID)
            dataWriter.WritePropertyName("entities")
            dataWriter.WriteStartArray()
            'Build eath entiry
            For Each h As FormExtMsgEntity In formExtMsgList
                entrysb.Clear()
                Dim entrysw As StringWriter = New StringWriter(entrysb)
                Using entryriter As JsonWriter = New JsonTextWriter(entrysw)
                    entryriter.WriteStartObject()
                    entryriter.WritePropertyName("entityType")
                    entryriter.WriteValue(h.ExtMsgEntity)

                    'Build entity type Json
                    For Each typeE As FormExtMsgEntityAttribute In formExtMsgAttrList.FindAll(Function(ByVal attr As FormExtMsgEntityAttribute) attr.FormName = formLambda _
                                                                                                            AndAlso attr.ExtMsgEntity = h.ExtMsgEntity AndAlso attr.Type = "E")
                        entryriter.WritePropertyName(typeE.Attribute)
                        If ((typeE.Attribute.ToLower() = "drillbackurl")) Then
                            Dim drilbackURL As StringBuilder = New StringBuilder()
                            drilbackURL.Append("?LogicalId=")
                            drilbackURL.Append(vLogicalID)
                            drilbackURL.Append("&page=formonly&form=")
                            drilbackURL.Append(drillbackFormname)
                            drilbackURL.Append("(FILTER(")
                            drilbackURL.Append(typeE.Value)
                            drilbackURL.Append(")SETVARVALUES(InitialCommand%3DRefresh))")
                            entryriter.WriteValue(drilbackURL.ToString())
                        Else
                            entryriter.WriteValue(typeE.Value)
                        End If
                    Next

                    'Build BOD type Json
                    If (formExtMsgAttrList.Exists(Function(ByVal attr As FormExtMsgEntityAttribute) attr.FormName = formLambda _
                                                               AndAlso attr.ExtMsgEntity = h.ExtMsgEntity AndAlso attr.Type = "B")) Then
                        entryriter.WritePropertyName("bodReference")
                        Dim bodsw As StringWriter = New StringWriter(bodsb)
                        Using bodwriter As JsonWriter = New JsonTextWriter(bodsw)
                            bodsb.Clear()
                            bodwriter.WriteStartObject()
                            For Each typeB As FormExtMsgEntityAttribute In formExtMsgAttrList.FindAll(Function(ByVal attr As FormExtMsgEntityAttribute) attr.FormName = formLambda _
                                                                                                              AndAlso attr.ExtMsgEntity = h.ExtMsgEntity AndAlso attr.Type = "B")

                                bodwriter.WritePropertyName(typeB.Attribute)
                                bodwriter.WriteValue(typeB.Value)
                            Next
                            bodwriter.WriteEndObject()
                            entryriter.WriteRawValue(bodsb.ToString())
                        End Using
                    End If
                    entryriter.WriteEndObject()
                    dataWriter.WriteRawValue(entrysb.ToString())
                End Using
            Next
            dataWriter.WriteEndObject()
        End Using
        jSONVarUnFormated = datasb.ToString()
        jSONVarUnFormated = jSONVarUnFormated.Replace("""", ChrW(10))
        IDORuntime.LogUserMessage("SLFormExtMsgEntities.LoadJSONVar", UserDefinedMessageType.UserDefined1, jSONVarUnFormated)
    End Function

    <IDOMethod(MethodFlags.None)>
    Public Function FormatJSONVar(ByVal formName As String,
                                  ByVal jSONVarUnFormated As String,
                                  ByRef jSONVar As String) As Integer
        Dim startString As String = formName + "(FILTER("
        Dim endstring As String = ")SETVARVALUES("
        Dim replaceString As String = String.Empty
        Dim filterString As String = String.Empty
        Dim hasStartEndString As Boolean = False

        Try
            If (jSONVarUnFormated.Contains(startString) And jSONVarUnFormated.Contains(endstring)) Then
                replaceString = jSONVarUnFormated.Substring(jSONVarUnFormated.IndexOf(startString), jSONVarUnFormated.IndexOf(endstring) - jSONVarUnFormated.IndexOf(startString) + endstring.Length)
                filterString = replaceString.Replace("'", "%27").
                                 Replace(" ", "%20").
                                 Replace("&", "%26").
                                 Replace("=", "%3D")
                hasStartEndString = True
            End If

            jSONVar = jSONVarUnFormated.Replace("\", "\\") _
                               .Replace("""", "\""") _
                               .Replace(ChrW(10), """")

            If hasStartEndString Then
                jSONVar = jSONVar.Replace(replaceString, filterString)
            End If
        Catch ex As Exception
            IDORuntime.LogUserMessage("SLFormExtMsgEntities.FormatJSONVar", UserDefinedMessageType.UserDefined1, jSONVarUnFormated)
            jSONVar = jSONVarUnFormated
        End Try

    End Function

    Private Function LoadIDO(ByRef Filter As String, ByRef IDOName As String, ByRef PropertyList As String, ByRef OrderBy As String) As LoadCollectionResponseData
        LoadIDO = Me.Context.Commands.LoadCollection(IDOName, PropertyList, Filter, OrderBy, 0)
    End Function

    Private Sub ReadCollectionToEntity(ByRef response As LoadCollectionResponseData, ByRef entityList As List(Of FormExtMsgEntity), ByRef formName As String)
        For i = 0 To response.Items.Count - 1
            Dim entity As FormExtMsgEntity = New FormExtMsgEntity With {
                .ExtMsgEntity = response(i, "ExtMsgEntity").Value,
                .FormName = formName
            }
            entityList.Add(entity)
        Next
    End Sub

    Private Sub ReadCollectionToEntity(ByRef response As LoadCollectionResponseData, ByRef entityList As List(Of FormExtMsgEntityAttribute), ByRef formName As String)
        For i = 0 To response.Items.Count - 1
            Dim entity As FormExtMsgEntityAttribute = New FormExtMsgEntityAttribute With {
                .ExtMsgEntity = response(i, "ExtMsgEntity").Value,
                .FormName = formName,
                .Type = response(i, "Type").Value,
                .Attribute = response(i, "Attribute").Value,
                .Value = response(i, "Value").Value
            }
            entityList.Add(entity)
        Next
    End Sub

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_ExtMsgEntitiesWbkpiEffectiveFormsSp(
        <[Optional]> ByVal ExtMsgEntity As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker = New MGInvoker(Me.Context)
            Dim iCLM_ExtMsgEntitiesWbkpiEffectiveFormsExt = New CLM_ExtMsgEntitiesWbkpiEffectiveFormsFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result = iCLM_ExtMsgEntitiesWbkpiEffectiveFormsExt.CLM_ExtMsgEntitiesWbkpiEffectiveFormsSp(ExtMsgEntity)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function
End Class


Public Class FormExtMsgEntity
    Public Property FormName As String
    Public Property ExtMsgEntity As String
End Class

Public Class FormExtMsgEntityAttribute
    Public Property FormName As String
    Public Property ExtMsgEntity As String
    Public Property Type As String
    Public Property Attribute As String
    Public Property Value As String
End Class



