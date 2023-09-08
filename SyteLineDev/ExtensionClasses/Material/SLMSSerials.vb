Option Explicit On
Option Strict On

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common
Imports CSI.MG
Imports CSI.Material
Imports System.Runtime.InteropServices
Imports CSI.Logistics.FieldService.Requests
Imports CSI.BusInterface
Imports CSI.Production
Imports CSI.Data.RecordSets
Imports CSI.ExternalContracts.FactoryTrack

<IDOExtensionClass("SLMSSerials")> _
Public Class SLMSSerials
    Inherits CSIExtensionClassBase
    Implements IExtFTSLMSSerials

    Private Sub PostUpdateCollection(ByVal sender As Object, ByVal args As IDOEventArgs)

        Dim updateArgs As IDOUpdateEventArgs

        ' cast the args parameter as an IDOUpdateEventArgs
        updateArgs = CType(args, IDOUpdateEventArgs)

        ' NOTE:  IDOUpdateEventArgs has an additional property named 
        ' ActionMask.  This property will be set with one or more 
        ' of the following bit flags:
        '
        '   UpdateAction.Delete
        '   UpdateAction.Insert
        '   UpdateAction.Update
        '
        ' These flags indicate which items in the update request the framework 
        ' is processing on this call.  Typically, all the flags will be set 
        ' (UpdateAction.All), however, there are times when the framework will 
        ' do deletes, inserts and updates in separate calls 
        ' (for example, when processing nested updates). create a new 
        ' instance of the AppDB class for accessing the application database
        ' Create an array containing procedures to be called.

        Using appDB As ApplicationDB = IDORuntime.Context.CreateApplicationDB()
            Dim sMethodArray As Array
            Dim sMethodName As String
            Dim sStat As Integer

            sMethodArray = Split(appDB.GetSessionVariable("PostHandlerMethodVar"), "|")

            ' Cycle through that array calling each procedure.
            For Each sMethodName In sMethodArray
                sStat = DoProcessMethod(sMethodName)
                If sStat <> 0 Then
                    Exit Sub
                End If
                'Retreieve session variables used to call the procedure
            Next

            'Finally unset the PostHandlerMethodVar variable
            appDB.DeleteSessionVariable("PostHandlerMethodVar")
        End Using
    End Sub
    Private Function DoProcessMethod(ByVal sMethodName As String) As Integer
        Dim oResponse As InvokeResponseData
        DoProcessMethod = 0
        Try
            Using appDB As ApplicationDB = IDORuntime.Context.CreateApplicationDB()
                Select Case sMethodName.Trim
                    Case "SLMSMoves.MsmpSp"
                        Dim sPType As String
                        Dim sPDate As String
                        Dim sPQty As String
                        Dim sPItem As String
                        Dim sPFromSite As String
                        Dim sPFromWhse As String
                        Dim sPFromLoc As String
                        Dim sPFromLot As String
                        Dim sPToSite As String
                        Dim sPToWhse As String
                        Dim sPToLoc As String
                        Dim sPToLot As String
                        Dim sPZeroCost As String
                        Dim sPTrnNum As String
                        Dim sPTrnLine As String
                        Dim sPTransNum As String
                        Dim sPRsvdNum As String
                        Dim sPStat As String
                        Dim sPRefNum As String
                        Dim sPRefLineSuf As String
                        Dim sPRefRelease As String
                        Dim sRemoteSiteLot As String
                        Dim sPReasonCode As String
                        Dim sPUnitCost As String
                        Dim sPMatlCost As String
                        Dim sPLbrCost As String
                        Dim sPFovhdCost As String
                        Dim sPVovhdCost As String
                        Dim sPOutCost As String
                        Dim sPTotCost As String
                        Dim sInfobar As String
                        Dim sPImportDocId As String
                        Dim sMoveZeroCostItem As String
                        Dim sEmpNum As String
                        Dim sCheckExternalWhseFlag As String
                        Dim sDocumentNum As String

                        sPType = appDB.GetSessionVariable("MsmpSp.PType")
                        sPDate = appDB.GetSessionVariable("MsmpSp.PDate")
                        sPQty = appDB.GetSessionVariable("MsmpSp.PQty")
                        sPItem = appDB.GetSessionVariable("MsmpSp.PItem")
                        sPFromSite = appDB.GetSessionVariable("MsmpSp.PFromSite")
                        sPFromWhse = appDB.GetSessionVariable("MsmpSp.PFromWhse")
                        sPFromLoc = appDB.GetSessionVariable("MsmpSp.PFromLoc")
                        sPFromLot = appDB.GetSessionVariable("MsmpSp.PFromLot")
                        sPToSite = appDB.GetSessionVariable("MsmpSp.PToSite")
                        sPToWhse = appDB.GetSessionVariable("MsmpSp.PToWhse")
                        sPToLoc = appDB.GetSessionVariable("MsmpSp.PToLoc")
                        sPToLot = appDB.GetSessionVariable("MsmpSp.PToLot")
                        sPZeroCost = appDB.GetSessionVariable("MsmpSp.PZeroCost")
                        sPTrnNum = appDB.GetSessionVariable("MsmpSp.PTrnNum")
                        sPTrnLine = appDB.GetSessionVariable("MsmpSp.PTrnLine")
                        sPTransNum = appDB.GetSessionVariable("MsmpSp.PTransNum")
                        sPRsvdNum = appDB.GetSessionVariable("MsmpSp.PRsvdNum")
                        sPStat = appDB.GetSessionVariable("MsmpSp.PStat")
                        sPRefNum = appDB.GetSessionVariable("MsmpSp.PRefNum")
                        sPRefLineSuf = appDB.GetSessionVariable("MsmpSp.PRefLineSuf")
                        sPRefRelease = appDB.GetSessionVariable("MsmpSp.PRefRelease")
                        sRemoteSiteLot = appDB.GetSessionVariable("MsmpSp.RemoteSiteLot")
                        sPReasonCode = appDB.GetSessionVariable("MsmpSp.PReasonCode")
                        sPUnitCost = appDB.GetSessionVariable("MsmpSp.PUnitCost")
                        sPMatlCost = appDB.GetSessionVariable("MsmpSp.PMatlCost")
                        sPLbrCost = appDB.GetSessionVariable("MsmpSp.PLbrCost")
                        sPFovhdCost = appDB.GetSessionVariable("MsmpSp.PFovhdCost")
                        sPVovhdCost = appDB.GetSessionVariable("MsmpSp.PVovhdCost")
                        sPOutCost = appDB.GetSessionVariable("MsmpSp.POutCost")
                        sPTotCost = appDB.GetSessionVariable("MsmpSp.PTotCost")
                        sInfobar = appDB.GetSessionVariable("MsmpSp.Infobar")
                        sPImportDocId = appDB.GetSessionVariable("MsmpSp.PImportDocId")
                        sMoveZeroCostItem = appDB.GetSessionVariable("MsmpSp.MoveZeroCostItem")
                        sEmpNum = appDB.GetSessionVariable("MsmpSp.EmpNum")
                        sCheckExternalWhseFlag = appDB.GetSessionVariable("MsmpSp.CheckExternalWhseFlag")
                        sDocumentNum = appDB.GetSessionVariable("MsmpSp.DocumentNum")

                        oResponse = Me.Context.Commands.Invoke("SLMSMoves", "MsmpSp", sPType, sPDate, sPQty, sPItem, _
                                    sPFromSite, sPFromWhse, sPFromLoc, sPFromLot, sPToSite, sPToWhse, sPToLoc, sPToLot, _
                                    sPZeroCost, sPTrnNum, sPTrnLine, sPTransNum, sPRsvdNum, sPStat, sPRefNum, sPRefLineSuf, _
                                    sPRefRelease, sRemoteSiteLot, sPReasonCode, sPUnitCost, sPMatlCost, sPLbrCost, sPFovhdCost, _
                                    sPVovhdCost, sPOutCost, sPTotCost, sInfobar, sPImportDocId, sMoveZeroCostItem, sEmpNum, sCheckExternalWhseFlag, sDocumentNum)

                        If Not oResponse.IsReturnValueStdError Then
                            appDB.SetSessionVariable("MsmpSp.PUnitCost", oResponse.Parameters(23).Value)
                            appDB.SetSessionVariable("MsmpSp.PMatlCost", oResponse.Parameters(24).Value)
                            appDB.SetSessionVariable("MsmpSp.PLbrCost", oResponse.Parameters(25).Value)
                            appDB.SetSessionVariable("MsmpSp.PFovhdCost", oResponse.Parameters(26).Value)
                            appDB.SetSessionVariable("MsmpSp.PVovhdCost", oResponse.Parameters(27).Value)
                            appDB.SetSessionVariable("MsmpSp.POutCost", oResponse.Parameters(28).Value)
                            appDB.SetSessionVariable("MsmpSp.PTotCost", oResponse.Parameters(29).Value)
                            appDB.SetSessionVariable("MsmpSp.Infobar", oResponse.Parameters(30).Value)

                        Else
                            DoProcessMethod = 16 'error
                            MGException.Throw(oResponse.Parameters(30).ToString)
                        End If
                End Select
            End Using
            DoProcessMethod = 0
        Catch ex As Exception
            MGException.Throw(MGException.ExtractMessages(ex))
            DoProcessMethod = 16
        End Try
    End Function
    Public Overrides Sub SetContext(ByVal context As _
    Mongoose.IDO.IIDOExtensionClassContext)

        MyBase.SetContext(context)
        ' Add event handlers
        AddHandler Me.Context.IDO.PostUpdateCollection, AddressOf _
        Me.PostUpdateCollection

    End Sub

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function SetMethodSP(ByVal MethodValInput As String) As Integer Implements IExtFTSLMSSerials.SetMethodSP
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iSetMethodExt As ISetMethod = New SetMethodFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iSetMethodExt.SetMethodSp(MethodValInput)
            Return result.Value
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function SerialSaveSp(ByVal SerNum As String,
<[Optional]> ByVal TmpSerId As Guid?,
<[Optional]> ByVal RefStr As String, ByRef Infobar As String,
<[Optional]> ByVal ManufacturedDate As DateTime?,
<[Optional]> ByVal ExpirationDate As DateTime?,
<[Optional], DefaultParameterValue(Nothing)> ByVal TrxRestrictCode As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iSerialSaveExt As ISerialSave = New SerialSaveFactory().Create(appDb, MGInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iSerialSaveExt.SerialSaveSp(SerNum, TmpSerId, RefStr, Infobar, ManufacturedDate, ExpirationDate, TrxRestrictCode)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function SerialLoadSp(ByVal SerialLike As String, ByVal TransType As String, ByVal WhseType As String, ByVal Stat As String,
        <[Optional], DefaultParameterValue(0)> ByVal RestoreLoss As Integer?,
        <[Optional], DefaultParameterValue(0)> ByVal JmtRETURN As Integer?,
        <[Optional]> ByVal Item As String,
        <[Optional]> ByVal Whse As String,
        <[Optional]> ByVal Loc As String,
        <[Optional]> ByVal Lot As String,
        <[Optional]> ByVal DoNum As String,
        <[Optional], DefaultParameterValue(0)> ByVal DoLine As Integer?,
        <[Optional]> ByVal TrnNum As String,
        <[Optional], DefaultParameterValue(0)> ByVal TrnLine As Integer?,
        <[Optional], DefaultParameterValue(0)> ByVal RsvdNum As Decimal?,
        <[Optional]> ByVal RefNum As String,
        <[Optional], DefaultParameterValue(0)> ByVal RefLine As Integer?,
        <[Optional], DefaultParameterValue(0)> ByVal RefRelease As Integer?,
        <[Optional]> ByVal Site As String,
        <[Optional]> ByVal ImportDocId As String,
        <[Optional]> ByVal PreassignSerials As Integer?,
        <[Optional]> ByVal ContainerNum As String,
        <[Optional]> ByVal StartingSerial As String,
        <[Optional]> ByVal EndingSerial As String,
        <[Optional]> ByVal TrcTrans As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iSerialLoadExt As ISerialLoad = New SerialLoadFactory().Create(Me, True)

            Dim result As (Data As CSI.Data.CRUD.ICollectionLoadResponse, ReturnCode As Integer?) = iSerialLoadExt.SerialLoadSp(SerialLike, TransType, WhseType, Stat, RestoreLoss, JmtRETURN, Item, Whse, Loc, Lot, DoNum, DoLine, TrnNum, TrnLine, RsvdNum, RefNum, RefLine, RefRelease, Site, ImportDocId, PreassignSerials, ContainerNum, StartingSerial, EndingSerial, TrcTrans)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function
End Class
