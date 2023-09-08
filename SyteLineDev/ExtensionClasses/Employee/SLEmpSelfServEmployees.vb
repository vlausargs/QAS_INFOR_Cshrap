Imports Mongoose.IDO
Imports System.Runtime.Serialization
Imports Mongoose.IDO.Protocol
Imports System.Runtime.Serialization.Json
Imports System.IO
Imports CSI.MG
Imports Mongoose.IDO.DataAccess
Imports CSI.Employee
Imports System.Runtime.InteropServices
Imports CSI.Data.RecordSets
Imports Microsoft.Extensions.DependencyInjection


''' <summary>
''' OrgChartLegendEntry: data structure for chart legend
''' </summary>
<DataContract()>
Public Class OrgChartLegendEntry
    <DataMember()>
    Public Property value As String
    <DataMember()>
    Public Property label As String
End Class

''' <summary>
''' OrgChartEntry: data structure for individuals in the org chart
''' </summary>
<DataContract()>
Public Class OrgChartEntry
    <DataMember()>
    Public Property id As String
    <DataMember()>
    Public Property Name As String
    <DataMember()>
    Public Property Position As String
    <DataMember()>
    Public Property Picture As String
    <DataMember()>
    Public Property Phone As String
    <DataMember()>
    Public Property BusinessPhone As String
    <DataMember()>
    Public Property EmailAddr As String
    <DataMember()>
    Public Property Status As String

    <DataMember()>
    Public Property children As OrgChartEntry()

    ' this field is required by chart control
    <DataMember()>
    Public Property isLeaf As Boolean

    ' non-serialized member used when building hierarchy
    <IgnoreDataMember()>
    Public Property IsSelf As Boolean = False
End Class

''' <summary>
''' OrgChartInfo: top level data structure for org chart json serialization
''' </summary>
<DataContract()>
Public Class OrgChartInfo
    <DataMember()>
    Public Property legend As OrgChartLegendEntry()

    <DataMember()>
    Public Property data As OrgChartEntry()
End Class
<IDOExtensionClass("SLEmpSelfServEmployees")> _
Public Class SLEmpSelfServEmployees
    Inherits CSIExtensionClassBase

    <IDOMethod(MethodFlags.RequiresTransaction, "Infobar")> _
    Public Function GetOrgChartData(ByVal empNum As String, ByVal username As String, ByRef orgChartJson As String, ByRef infobar As String) As Integer
        Dim orgChartInfo = New OrgChartInfo()
        Dim result = StdMethodResult.Success
        Dim nextId As Integer = 1

        orgChartJson = String.Empty
        infobar = String.Empty

        Try
            ' legend not currently used...leaving this here for possible future use
            'orgChartInfo.legend = New OrgChartLegendEntry() { _ss
            '   New OrgChartLegendEntry() With {.value = "FT", .label = "Full Time"}, _
            '   New OrgChartLegendEntry() With {.value = "PT", .label = "Part Time"}}
            orgChartInfo.legend = New OrgChartLegendEntry() {}

            ' call custom load method to get employees
            Dim propList = New PropertyList("Name, Picture, UbJobTitle, UbStatus, Phone, BusinessPhone, EmailAddr, UbSupervisor, UbTeam, UbMyTeam, UbSelf")
            Dim args = New InvokeParameterList From {
                empNum,
                username,
                IDONull.Value
            }

            'Dim orgHierarchy As LoadCollectionResponseData
            Dim orgHierarchy = Me.Context.Commands.LoadCollection( _
               New LoadCollectionRequestData() With _
               { _
                  .IDOName = "SLEmpSelfServEmployees", _
                  .PropertyList = propList, _
                  .CustomLoadMethod = New CustomLoadMethod() With {.Name = "CLM_GetOrgHierarchySp", .Parameters = args} _
               })

            Dim supervisorIx = propList.IndexOf("UbSupervisor")
            Dim supervisor = orgHierarchy.Items.FirstOrDefault(Function(it) it.PropertyValues(supervisorIx).Value = "1")

            If (Not supervisor Is Nothing) Then
                orgChartInfo.data = New OrgChartEntry() { _
                   New OrgChartEntry() With _
                      { _
                         .id = Me.MakeUniqueId(nextId), _
                         .Name = supervisor.PropertyValues(propList.IndexOf("Name")).Value, _
                         .Picture = Me.MakePicture(supervisor.PropertyValues(propList.IndexOf("Picture")).Value), _
                         .Position = supervisor.PropertyValues(propList.IndexOf("UbJobTitle")).Value, _
                         .Status = supervisor.PropertyValues(propList.IndexOf("UbStatus")).Value, _
                         .Phone = supervisor.PropertyValues(propList.IndexOf("Phone")).Value, _
                         .BusinessPhone = supervisor.PropertyValues(propList.IndexOf("BusinessPhone")).Value, _
                         .EmailAddr = supervisor.PropertyValues(propList.IndexOf("EmailAddr")).Value _
                      } _
                   }

                Dim teamIx = orgHierarchy.PropertyList.IndexOf("UbTeam")
                Dim teamMembers = orgHierarchy.Items.Where(Function(item) item.PropertyValues(teamIx).Value = "1")

                orgChartInfo.data(0).children = (From member In teamMembers _
                                                 Select New OrgChartEntry() With _
                                                 { _
                                                    .id = Me.MakeUniqueId(nextId), _
                                                    .Name = member.PropertyValues(propList.IndexOf("Name")).Value, _
                                                    .Picture = Me.MakePicture(member.PropertyValues(propList.IndexOf("Picture")).Value), _
                                                    .Position = member.PropertyValues(propList.IndexOf("UbJobTitle")).Value, _
                                                    .Status = member.PropertyValues(propList.IndexOf("UbStatus")).Value, _
                                                    .Phone = member.PropertyValues(propList.IndexOf("Phone")).Value, _
                                                    .BusinessPhone = member.PropertyValues(propList.IndexOf("BusinessPhone")).Value, _
                                                    .EmailAddr = member.PropertyValues(propList.IndexOf("EmailAddr")).Value, _
                                                    .IsSelf = member.PropertyValues(propList.IndexOf("UbSelf")).Value = "1" _
                                                 }).ToArray()

                Dim myTeamIx = orgHierarchy.PropertyList.IndexOf("UbMyTeam")
                Dim myTeamMembers = orgHierarchy.Items.Where(Function(item) item.PropertyValues(myTeamIx).Value = "1")
                Dim myOrgChartEntry = orgChartInfo.data(0).children.FirstOrDefault(Function(entry) entry.IsSelf)

                If (Not myOrgChartEntry Is Nothing) Then _
                   myOrgChartEntry.children = (From member In myTeamMembers _
                                               Select New OrgChartEntry() With _
                                               { _
                                                  .id = Me.MakeUniqueId(nextId), _
                                                  .Name = member.PropertyValues(propList.IndexOf("Name")).Value, _
                                                  .Picture = Me.MakePicture(member.PropertyValues(propList.IndexOf("Picture")).Value), _
                                                  .Position = member.PropertyValues(propList.IndexOf("UbJobTitle")).Value, _
                                                  .Status = member.PropertyValues(propList.IndexOf("UbStatus")).Value, _
                                                  .Phone = member.PropertyValues(propList.IndexOf("Phone")).Value, _
                                                  .BusinessPhone = member.PropertyValues(propList.IndexOf("BusinessPhone")).Value, _
                                                  .EmailAddr = member.PropertyValues(propList.IndexOf("EmailAddr")).Value _
                                               }).ToArray()

            End If

            Me.UpdateLeafIndicators(orgChartInfo.data)

            orgChartJson = Me.ToJson(orgChartInfo)

        Catch ex As Exception
            infobar = ex.Message
            result = StdMethodResult.MinError
        End Try

        Return CInt(result)
    End Function

    Private Sub UpdateLeafIndicators(ByVal orgChartEntries As OrgChartEntry())
        For Each entry As OrgChartEntry In orgChartEntries
            entry.isLeaf = (entry.children Is Nothing) OrElse (entry.children.Length = 0)
            If (Not entry.isLeaf) Then Me.UpdateLeafIndicators(entry.children)
        Next
    End Sub

    Private Function MakeUniqueId(ByRef nextId As Integer) As String
        Dim dt = DateTime.Now

        nextId = nextId + 1

        Return String.Format("emp{0:00}{1:00}{2:00}_{3}", dt.Hour, dt.Minute, dt.Second, nextId)
    End Function

    Private Function MakePicture(ByVal base64Data As String) As String
        Dim result = NO_IMAGE

        If (Not String.IsNullOrEmpty(base64Data)) Then _
           result = "data:image/png;base64," + base64Data

        Return result
    End Function

    Private Function ToJson(Of T)(ByVal obj As T) As String
        Dim ser = New DataContractJsonSerializer(GetType(T))
        Dim json As String

        Using ms As New MemoryStream()
            ser.WriteObject(ms, obj)
            ms.Position = 0
            Using sr = New StreamReader(ms)
                json = sr.ReadToEnd()
                sr.Close()
            End Using
            ms.Close()
        End Using

        Return json
    End Function

    Private Const NO_IMAGE As String = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mNgYAAAAAMAASsJTYQAAAAASUVORK5CYII="


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ESSHasEmployeePositionSp(
<[Optional]> ByVal EmpNum As String, ByRef HasEmployeePosition As Byte?) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iESSHasEmployeePositionSpExt As IESSHasEmployeePosition = New ESSHasEmployeePositionFactory().Create(appDb)
            Dim result = iESSHasEmployeePositionSpExt.ESSHasEmployeePositionSp(EmpNum, HasEmployeePosition)
            Dim Severity As Integer = result.ReturnCode.Value
            HasEmployeePosition = result.HasEmployeePosition
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetEmpUsernameSp(
<[Optional]> ByVal EmpNum As String, ByRef UserName As String) As Integer
        Dim iGetEmpUsernameExt = New GetEmpUsernameFactory().Create(Me, True)
        Dim result As (ReturnCode As Integer?, UserName As String) = iGetEmpUsernameExt.GetEmpUsernameSp(EmpNum, UserName)
        Dim Severity As Integer = result.ReturnCode.Value
        UserName = result.UserName
        Return Severity
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_GetEmpManagerInfoSp(
<[Optional]> ByVal EmpNum As String,
<[Optional]> ByVal UserName As String) As DataTable
        Dim iCLM_GetEmpManagerInfoExt As ICLM_GetEmpManagerInfo = Me.GetService(Of ICLM_GetEmpManagerInfo)()
        Dim result As (Data As CSI.Data.CRUD.ICollectionLoadResponse, ReturnCode As Integer?) = iCLM_GetEmpManagerInfoExt.CLM_GetEmpManagerInfoSp(EmpNum, UserName)
        If result.Data Is Nothing Then
            Return New DataTable()
        Else
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End If
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_GetOrgHierarchySp(
<[Optional]> ByVal EmpNum As String,
<[Optional]> ByVal UserName As String, ByRef Infobar As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCLM_GetOrgHierarchyExt As ICLM_GetOrgHierarchy = New CLM_GetOrgHierarchyFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result = iCLM_GetOrgHierarchyExt.CLM_GetOrgHierarchySp(EmpNum, UserName, Infobar)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Infobar = result.Infobar
            Return dt
        End Using
    End Function
End Class
