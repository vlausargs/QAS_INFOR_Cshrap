Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common
Imports Mongoose.Core.Configuration
Imports System.Data.SqlClient
Imports Mongoose.Scripting
Imports CSI.Data.SQL.UDDT
Imports System
Imports System.Data
Imports CSI.Logistics.FieldService
Imports CSI.MG
Imports System.Runtime.InteropServices



Public Class SqlDbLocal
    Inherits SqlDb

    Private ReadOnly _dbName As String
    Private ReadOnly _dbServer As String

    ReadOnly Property ServerName As String
        Get
            Return _dbServer
        End Get
    End Property
    ReadOnly Property DbName As String
        Get
            Return _dbName
        End Get
    End Property

    Public Sub New(profile As ConnectionProfile)
        MyBase.New(profile)
        MyBase.GetServerAndDatabase(_dbServer, _dbName)
    End Sub
End Class

<IDOExtensionClass("FSParms")> _
Public Class FSParms
    Inherits CSIExtensionClassBase
    Implements IIDOExtensionClass


    <IDOMethod(MethodFlags.None, "sInfobar")>
    Public Function GetDBInfoFromConfigName(
                ByRef sConfigName As String,
                ByRef sServerName As String,
                ByRef sDBName As String,
                ByRef sInfobar As String) As Integer

        Dim oConfig As Configuration

        Dim oProfile As ConnectionProfile

        sConfigName = IDORuntime.ConfigurationName
        sServerName = ""
        sDBName = ""
        sInfobar = ""

        oConfig = IDORuntime.LoadConfiguration(IDORuntime.ConfigurationName)
        oProfile = oConfig.GetAppConnection(ConnectionProfileType.Runtime)
        Dim oSqlDb As New SqlDbLocal(oProfile)
        sServerName = oSqlDb.ServerName
        sDBName = oSqlDb.DbName
    End Function

    <IDOMethod(MethodFlags.None)>
    Public Function GetSystemParm(ByRef strParmValue As String _
                                , ByVal strParmName As String) As Integer

        Dim dr As IDataReader = Nothing

        GetSystemParm = 0
        Try
            Dim loadResponse As LoadCollectionResponseData
            loadResponse = Me.Context.Commands.LoadCollection("FSParms", strParmName, String.Empty, String.Empty, 0)

            strParmValue = loadResponse(0, strParmName).GetValue("0")
        Catch ex As Exception
            GetSystemParm = 16
            MGException.Throw(ex.Message)
        End Try
        Return GetSystemParm
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function SSSFSGetDefConfigRemovalReasonSp(ByRef ConfigReason As String) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iSSSFSGetDefConfigRemovalReasonExt = New SSSFSGetDefConfigRemovalReasonFactory().Create(Me, True)
            Dim result As (ReturnCode As Integer?, ConfigReason As String) = iSSSFSGetDefConfigRemovalReasonExt.SSSFSGetDefConfigRemovalReasonSp(ConfigReason)
            ConfigReason = result.ConfigReason
            Dim Severity As Integer = result.ReturnCode.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function SSSFSGetDefConfigUpdMethodSp(ByRef ConfigUpdateMethod As String) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iSSSFSGetDefConfigUpdMethodExt = New SSSFSGetDefConfigUpdMethodFactory().Create(appDb)
            Dim oConfigUpdateMethod As FSConfigUpdateMethodType = ConfigUpdateMethod
            Dim Severity As Integer = iSSSFSGetDefConfigUpdMethodExt.SSSFSGetDefConfigUpdMethodSp(oConfigUpdateMethod)
            ConfigUpdateMethod = oConfigUpdateMethod
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function SSSFSGetDefMatlTransTypeSp(ByRef MatlTransType As String) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iSSSFSGetDefMatlTransTypeExt = New SSSFSGetDefMatlTransTypeFactory().Create(Me, True)
            Dim result As (ReturnCode As Integer?, MatlTransType As String) = iSSSFSGetDefMatlTransTypeExt.SSSFSGetDefMatlTransTypeSp(MatlTransType)
            MatlTransType = result.MatlTransType
            Dim Severity As Integer = result.ReturnCode.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function SSSFSGetInitialConfigDisplaySp(ByRef InitialConfigDisplay As Integer?) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iSSSFSGetInitialConfigDisplayExt = New SSSFSGetInitialConfigDisplayFactory().Create(Me, True)
            Dim result As (ReturnCode As Integer?, InitialConfigDisplay As Integer?) = iSSSFSGetInitialConfigDisplayExt.SSSFSGetInitialConfigDisplaySp(InitialConfigDisplay)
            InitialConfigDisplay = result.InitialConfigDisplay
            Dim Severity As Integer = result.ReturnCode.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function SSSFSGetUseConsumerSp(ByRef UseCons As Integer?) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iSSSFSGetUseConsumerExt = New SSSFSGetUseConsumerFactory().Create(Me, True)
            Dim result As (ReturnCode As Integer?, UseCons As Integer?) = iSSSFSGetUseConsumerExt.SSSFSGetUseConsumerSp(UseCons)
            UseCons = result.UseCons
            Dim Severity As Integer = result.ReturnCode.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function SSSFSParmsSyncIncSroSp(ByVal iMode As String, ByVal iSyncIndex As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iSSSFSParmsSyncIncSroExt = New SSSFSParmsSyncIncSroFactory().Create(appDb)
            Dim Severity As Integer = iSSSFSParmsSyncIncSroExt.SSSFSParmsSyncIncSroSp(iMode, iSyncIndex, Infobar)
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function SSSFSGetAwaitingPartsParmsSp(ByRef PartsWaitStatCode As String, ByRef PartsWaitPriorCode As String, ByRef PartsWaitScheduleFlag As Byte?, ByRef PartsRecStatCode As String, ByRef PartsRecPriorCode As String, ByRef PartsRecScheduleFlag As Byte?, ByRef PartsRecEmailSRO As Byte?, ByRef PartsRecEmailIncident As Byte?, ByRef PartsRecEmailContent As String, ByRef PartsWaitMode As String) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iSSSFSGetAwaitingPartsParmsExt = New SSSFSGetAwaitingPartsParmsFactory().Create(appDb)
            Dim Severity As Integer = iSSSFSGetAwaitingPartsParmsExt.SSSFSGetAwaitingPartsParmsSp(PartsWaitStatCode, PartsWaitPriorCode, PartsWaitScheduleFlag, PartsRecStatCode, PartsRecPriorCode, PartsRecScheduleFlag, PartsRecEmailSRO, PartsRecEmailIncident, PartsRecEmailContent, PartsWaitMode)
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function SSSSetAvailSp(ByRef Avail_SSS_FSP As Byte?, ByRef Avail_SSS_RMX As Byte?, ByRef Avail_SSS_SHP As Byte?, ByRef Avail_SSS_RFQ As Byte?, ByRef Avail_SSS_VTX As Byte?, ByRef Avail_SSS_ROE As Byte?, ByRef Avail_SSS_POS As Byte?, ByRef Avail_SSS_CCI As Byte?, ByRef Avail_SSS_SL As Byte?) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iSSSSetAvailExt = New SSSSetAvailFactory().Create(appDb)
            Dim Severity As Integer = iSSSSetAvailExt.SSSSetAvailSp(Avail_SSS_FSP, Avail_SSS_RMX, Avail_SSS_SHP, Avail_SSS_RFQ, Avail_SSS_VTX, Avail_SSS_ROE, Avail_SSS_POS, Avail_SSS_CCI, Avail_SSS_SL)
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function FormatMultiLineAddressSp(
<[Optional]> ByVal Name As String,
<[Optional]> ByVal Addr1 As String,
<[Optional]> ByVal Addr2 As String,
<[Optional]> ByVal Addr3 As String,
<[Optional]> ByVal Addr4 As String,
<[Optional]> ByVal City As String,
<[Optional]> ByVal State As String,
<[Optional]> ByVal Zip As String,
<[Optional]> ByVal Country As String, ByRef Address As String, ByRef Infobar As String) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iFormatMultiLineAddressExt As IFormatMultiLineAddress = New FormatMultiLineAddressFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Address As String, Infobar As String) = iFormatMultiLineAddressExt.FormatMultiLineAddressSp(Name, Addr1, Addr2, Addr3, Addr4, City, State, Zip, Country, Address, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Address = result.Address
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function
End Class
