Option Explicit On
Option Strict On

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common

Imports CSI.Data.SQL.UDDT
Imports CSI.Material
Imports CSI.MG
Imports System.Runtime.InteropServices
Imports CSI.Logistics.FieldService.Requests
Imports CSI.Production
Imports CSI.BusInterface
Imports CSI.Data.RecordSets
Imports CSI.Data.CRUD
Imports CSI.ExternalContracts.FactoryTrack

<IDOExtensionClass("SLSerials")>
Public Class SLSerials
    Inherits CSIExtensionClassBase
    Implements IExtFTSLSerials

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
        Dim sMethodArray As Array
        Dim sMethodName As String
        Using appDB As ApplicationDB = IDORuntime.Context.CreateApplicationDB()
            sMethodArray = Split(appDB.GetSessionVariable("PostHandlerMethodVar"), "|")
        End Using
        ' Cycle through that array calling each procedure.
        For Each sMethodName In sMethodArray
            Call DoProcessMethod(sMethodName)
            'Retreieve session variables used to call the procedure
        Next

        Using appDB As ApplicationDB = IDORuntime.Context.CreateApplicationDB()
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
                    Case "SLTrnacts.CombineXferShipReceiveSp"
                        Dim sTrnNum As String
                        Dim sTrnLine As String
                        Dim sItem As String
                        Dim sFromSite As String
                        Dim sFromWhse As String
                        Dim sFromLoc As String
                        Dim sFromLot As String
                        Dim sToSite As String
                        Dim sToWhse As String
                        Dim sToLoc As String
                        Dim sToLot As String

                        Dim sTQtyShipped As String
                        Dim sTUM As String
                        Dim sTShipDate As String
                        Dim sTitle As String
                        Dim sRemoteSiteLotProcess As String
                        Dim sUseExistingSerials As String
                        Dim sSerialPrefix As String
                        Dim sInfobar As String
                        Dim sImportDocId As String
                        Dim sExportDocId As String
                        Dim sReasonCode As String
                        Dim sMoveZeroCostItem As String
                        Dim sRecordDate As String
                        Dim sDocumentNum As String

                        sTrnNum = appDB.GetSessionVariable("CombineXferShipReceiveSp.TrnNum")
                        sTrnLine = appDB.GetSessionVariable("CombineXferShipReceiveSp.TrnLine")
                        sItem = appDB.GetSessionVariable("CombineXferShipReceiveSp.Item")
                        sFromSite = appDB.GetSessionVariable("CombineXferShipReceiveSp.FromSite")
                        sFromWhse = appDB.GetSessionVariable("CombineXferShipReceiveSp.FromWhse")
                        sFromLoc = appDB.GetSessionVariable("CombineXferShipReceiveSp.FromLoc")
                        sFromLot = appDB.GetSessionVariable("CombineXferShipReceiveSp.FromLot")
                        sToSite = appDB.GetSessionVariable("CombineXferShipReceiveSp.ToSite")
                        sToWhse = appDB.GetSessionVariable("CombineXferShipReceiveSp.ToWhse")
                        sToLoc = appDB.GetSessionVariable("CombineXferShipReceiveSp.ToLoc")
                        sToLot = appDB.GetSessionVariable("CombineXferShipReceiveSp.ToLot")
                        sTQtyShipped = appDB.GetSessionVariable("CombineXferShipReceiveSp.TQtyShipped")
                        sTUM = appDB.GetSessionVariable("CombineXferShipReceiveSp.TUM")
                        sTShipDate = appDB.GetSessionVariable("CombineXferShipReceiveSp.TShipDate")
                        sTitle = appDB.GetSessionVariable("CombineXferShipReceiveSp.Title")
                        sRemoteSiteLotProcess = appDB.GetSessionVariable("CombineXferShipReceiveSp.RemoteSiteLotProcess")
                        sUseExistingSerials = appDB.GetSessionVariable("CombineXferShipReceiveSp.UseExistingSerials")
                        sSerialPrefix = appDB.GetSessionVariable("CombineXferShipReceiveSp.SerialPrefix")
                        sInfobar = appDB.GetSessionVariable("CombineXferShipReceiveSp.Infobar")
                        sImportDocId = appDB.GetSessionVariable("CombineXferShipReceiveSp.ImportDocId")
                        sExportDocId = appDB.GetSessionVariable("CombineXferShipReceiveSp.ExportDocId")
                        sReasonCode = appDB.GetSessionVariable("CombineXferShipReceiveSp.ReasonCode")
                        sMoveZeroCostItem = appDB.GetSessionVariable("CombineXferShipReceiveSp.MoveZeroCostItem")
                        sRecordDate = appDB.GetSessionVariable("CombineXferShipReceiveSp.RecordDate")
                        sDocumentNum = appDB.GetSessionVariable("CombineXferShipReceiveSp.DocumentNum")

                        oResponse = Me.Context.Commands.Invoke("SLTrnacts", "CombineXferShipReceiveSp", sTrnNum, sTrnLine, sItem, sFromSite, sFromWhse, sFromLoc _
                        , sFromLot, sToSite, sToWhse, sToLoc, sToLot, sTQtyShipped, sTUM, sTShipDate, sTitle, sRemoteSiteLotProcess, sUseExistingSerials _
                        , sSerialPrefix, sInfobar, sImportDocId, sExportDocId, sReasonCode, sMoveZeroCostItem, sRecordDate, sDocumentNum)

                        If oResponse.IsReturnValueStdError Then
                            MGException.Throw(oResponse.Parameters(18).Value)
                        Else
                            appDB.SetSessionVariable("CombineXferShipReceiveSp.Infobar", oResponse.Parameters(18).Value)
                        End If

                    Case "SLJobTrans.JustInTimeTransactionSp"
                        Dim sTItem As String
                        Dim sTcQtuQty As String
                        Dim sTWhse As String
                        Dim sTLoc As String
                        Dim sTLot As String
                        Dim sTTransDate As String
                        Dim sTShift As String
                        Dim sTEmpNum As String
                        Dim sPPostNeg As String
                        Dim sSerialPrefix As String
                        Dim sSessionID As String
                        Dim sInfobar As String
                        Dim sDocumentNum As String

                        sTItem = appDB.GetSessionVariable("JustInTimeTransactionSp.TItem")
                        sTcQtuQty = appDB.GetSessionVariable("JustInTimeTransactionSp.TcQtuQty")
                        sTWhse = appDB.GetSessionVariable("JustInTimeTransactionSp.TWhse")
                        sTLoc = appDB.GetSessionVariable("JustInTimeTransactionSp.TLoc")
                        sTLot = appDB.GetSessionVariable("JustInTimeTransactionSp.TLot")
                        sTTransDate = appDB.GetSessionVariable("JustInTimeTransactionSp.TTransDate")
                        sTShift = appDB.GetSessionVariable("JustInTimeTransactionSp.TShift")
                        sTEmpNum = appDB.GetSessionVariable("JustInTimeTransactionSp.TEmpNum")
                        sPPostNeg = appDB.GetSessionVariable("JustInTimeTransactionSp.PPostNeg")
                        sSerialPrefix = appDB.GetSessionVariable("JustInTimeTransactionSp.SerialPrefix")
                        sSessionID = appDB.GetSessionVariable("JustInTimeTransactionSp.SessionID")
                        sInfobar = appDB.GetSessionVariable("JustInTimeTransactionSp.Infobar")
                        sDocumentNum = appDB.GetSessionVariable("JustInTimeTransactionSp.DocumentNum")

                        oResponse = Me.Context.Commands.Invoke("SLJobTrans", "JustInTimeTransactionSp", sTItem, sTcQtuQty, sTWhse,
                                    sTLoc, sTLot, sTTransDate, sTShift, sTEmpNum, sPPostNeg, sSerialPrefix, sSessionID, sInfobar, IDONull.Value, sDocumentNum)

                        If oResponse.IsReturnValueStdError Then
                            MGException.Throw(oResponse.Parameters(11).GetValue(Of String)())
                        Else
                            appDB.SetSessionVariable("JustInTimeTransactionSp.Infobar", oResponse.Parameters(11).GetValue(Of String))
                        End If

                    Case "SLJobTrans.ProcessJobMatlTransSp"
                        Dim sJob As String
                        Dim sSuffix As String
                        Dim sOperNum As String
                        Dim sSequence As String
                        Dim sDeleteTmpSer As String
                        Dim sBackflush As String
                        Dim sByProduct As String
                        Dim sUM As String
                        Dim sItem As String
                        Dim sDescription As String
                        Dim sWc As String
                        Dim sWhse As String
                        Dim sLoc As String
                        Dim sLot As String
                        Dim sTransDate As String
                        Dim sMatlCost As String
                        Dim sLbrCost As String
                        Dim sFovhdCost As String
                        Dim sVovhdCost As String
                        Dim sOutCost As String
                        Dim sCost As String
                        Dim sPlanCost As String
                        Dim sQty As String
                        Dim sAcct As String
                        Dim sAcctUnit1 As String
                        Dim sAcctUnit2 As String
                        Dim sAcctUnit3 As String
                        Dim sAcctUnit4 As String
                        Dim sRowPointer As String
                        Dim sJobmatlRefType As String
                        Dim sJobmatlRefNum As String
                        Dim sJobmatlRefLineSuf As String
                        Dim sJobmatlRefRelease As String
                        Dim sInfobar As String
                        Dim sImportDocId As String
                        Dim sJobLot As String
                        Dim sJobSerial As String
                        Dim sContainerNum As String
                        Dim sDocumentNum As String

                        sJob = appDB.GetSessionVariable("ProcessJobMatlTransSp.Job")
                        sSuffix = appDB.GetSessionVariable("ProcessJobMatlTransSp.Suffix")
                        sOperNum = appDB.GetSessionVariable("ProcessJobMatlTransSp.OperNum")
                        sSequence = appDB.GetSessionVariable("ProcessJobMatlTransSp.Sequence")
                        sDeleteTmpSer = appDB.GetSessionVariable("ProcessJobMatlTransSp.DeleteTmpSer")
                        sBackflush = appDB.GetSessionVariable("ProcessJobMatlTransSp.Backflush")
                        sByProduct = appDB.GetSessionVariable("ProcessJobMatlTransSp.ByProduct")
                        sUM = appDB.GetSessionVariable("ProcessJobMatlTransSp.UM")
                        sItem = appDB.GetSessionVariable("ProcessJobMatlTransSp.Item")
                        sDescription = appDB.GetSessionVariable("ProcessJobMatlTransSp.Description")
                        sWc = appDB.GetSessionVariable("ProcessJobMatlTransSp.Wc")
                        sWhse = appDB.GetSessionVariable("ProcessJobMatlTransSp.Whse")
                        sLoc = appDB.GetSessionVariable("ProcessJobMatlTransSp.Loc")
                        sLot = appDB.GetSessionVariable("ProcessJobMatlTransSp.Lot")
                        sTransDate = appDB.GetSessionVariable("ProcessJobMatlTransSp.TransDate")
                        sMatlCost = appDB.GetSessionVariable("ProcessJobMatlTransSp.MatlCost")
                        sLbrCost = appDB.GetSessionVariable("ProcessJobMatlTransSp.LbrCost")
                        sFovhdCost = appDB.GetSessionVariable("ProcessJobMatlTransSp.FovhdCost")
                        sVovhdCost = appDB.GetSessionVariable("ProcessJobMatlTransSp.VovhdCost")
                        sOutCost = appDB.GetSessionVariable("ProcessJobMatlTransSp.OutCost")
                        sCost = appDB.GetSessionVariable("ProcessJobMatlTransSp.Cost")
                        sPlanCost = appDB.GetSessionVariable("ProcessJobMatlTransSp.PlanCost")
                        sQty = appDB.GetSessionVariable("ProcessJobMatlTransSp.Qty")
                        sAcct = appDB.GetSessionVariable("ProcessJobMatlTransSp.Acct")
                        sAcctUnit1 = appDB.GetSessionVariable("ProcessJobMatlTransSp.AcctUnit1")
                        sAcctUnit2 = appDB.GetSessionVariable("ProcessJobMatlTransSp.AcctUnit2")
                        sAcctUnit3 = appDB.GetSessionVariable("ProcessJobMatlTransSp.AcctUnit3")
                        sAcctUnit4 = appDB.GetSessionVariable("ProcessJobMatlTransSp.AcctUnit4")
                        sRowPointer = appDB.GetSessionVariable("ProcessJobMatlTransSp.RowPointer")
                        sJobmatlRefType = appDB.GetSessionVariable("ProcessJobMatlTransSp.JobmatlRefType")
                        sJobmatlRefNum = appDB.GetSessionVariable("ProcessJobMatlTransSp.JobmatlRefNum")
                        sJobmatlRefLineSuf = appDB.GetSessionVariable("ProcessJobMatlTransSp.JobmatlRefLineSuf")
                        sJobmatlRefRelease = appDB.GetSessionVariable("ProcessJobMatlTransSp.JobmatlRefRelease")
                        sInfobar = appDB.GetSessionVariable("ProcessJobMatlTransSp.Infobar")
                        sImportDocId = appDB.GetSessionVariable("ProcessJobMatlTransSp.ImportDocId")
                        sJobLot = appDB.GetSessionVariable("ProcessJobMatlTransSp.JobLot")
                        sJobSerial = appDB.GetSessionVariable("ProcessJobMatlTransSp.JobSerial")
                        sContainerNum = appDB.GetSessionVariable("ProcessJobMatlTransSp.ContainerNum")
                        sDocumentNum = appDB.GetSessionVariable("ProcessJobMatlTransSp.DocumentNum")

                        sInfobar = appDB.GetSessionVariable("ProcessJobMatlTransSp.Infobar")

                        oResponse = Me.Context.Commands.Invoke("SLJobTrans", "ProcessJobMatlTransSp", sJob, sSuffix, sOperNum, sSequence,
                                    sDeleteTmpSer, sBackflush, sByProduct, sUM, sItem, sDescription, sWc, sWhse, sLoc, sLot, sTransDate,
                                    sMatlCost, sLbrCost, sFovhdCost, sVovhdCost, sOutCost, sCost, sPlanCost, sQty,
                                    sAcct, sAcctUnit1, sAcctUnit2, sAcctUnit3, sAcctUnit4, sRowPointer,
                                    sJobmatlRefType, sJobmatlRefNum, sJobmatlRefLineSuf, sJobmatlRefRelease, sInfobar, sImportDocId,
                                    sJobLot, sJobSerial, sContainerNum, IDONull.Value, IDONull.Value, sDocumentNum)

                        If oResponse.IsReturnValueStdError Then
                            MGException.Throw(oResponse.Parameters(33).Value)
                        End If

                    Case "SLItemLocs.PostSave"
                        Dim sPWhseList As String
                        Dim sPItemList As String
                        Dim sInfobar As String

                        sPWhseList = appDB.GetSessionVariable("istkrPostSaveSp.PWhseList")
                        sPItemList = appDB.GetSessionVariable("istkrPostSaveSp.PItemList")
                        sInfobar = appDB.GetSessionVariable("istkrPostSaveSp.Infobar")

                        oResponse = Me.Context.Commands.Invoke("SLItemLocs", "istkrPostSaveSp", sPWhseList, sPItemList, sInfobar)
                        If Not oResponse.IsReturnValueStdError Then
                            'Trow()
                        Else
                            appDB.SetSessionVariable("istkrPostSaveSp.Infobar", oResponse.Parameters(2).GetValue(Of String))
                        End If

                    Case "SLJobs.JobReceiptPostSp"
                        Dim sJob As String
                        Dim sSuffix As String
                        Dim sItem As String
                        Dim sOperNum As String
                        Dim sQty As String
                        Dim sLoc As String
                        Dim sLot As String
                        Dim sTransDate As String
                        Dim sOverride As String
                        Dim sCanOverride As String
                        Dim sInfobar As String
                        Dim sDocumentNum As String
                        Dim sImportDocId As String
                        Dim sEmpNum As String
                        Dim sContainerNum As String

                        sJob = appDB.GetSessionVariable("JobReceiptPostSp.Job")
                        sSuffix = appDB.GetSessionVariable("JobReceiptPostSp.Suffix")
                        sItem = appDB.GetSessionVariable("JobReceiptPostSp.Item")
                        sOperNum = appDB.GetSessionVariable("JobReceiptPostSp.OperNum")
                        sQty = appDB.GetSessionVariable("JobReceiptPostSp.Qty")
                        sLoc = appDB.GetSessionVariable("JobReceiptPostSp.Loc")
                        sLot = appDB.GetSessionVariable("JobReceiptPostSp.Lot")
                        sTransDate = appDB.GetSessionVariable("JobReceiptPostSp.TransDate")
                        sOverride = appDB.GetSessionVariable("JobReceiptPostSp.Override")
                        sCanOverride = appDB.GetSessionVariable("JobReceiptPostSp.CanOverride")
                        sInfobar = appDB.GetSessionVariable("JobReceiptPostSp.Infobar")
                        sDocumentNum = appDB.GetSessionVariable("JobReceiptPostSp.DocumentNum")
                        sImportDocId = appDB.GetSessionVariable("JobReceiptPostSp.ImportDocId")
                        sEmpNum = appDB.GetSessionVariable("JobReceiptPostSp.EmpNum")
                        sContainerNum = appDB.GetSessionVariable("JobReceiptPostSp.ContainerNum")

                        oResponse = Me.Context.Commands.Invoke("SLJobs", "JobReceiptPostSp", sJob, sSuffix, sItem,
                                    sOperNum, sQty, sLoc, sLot, sTransDate, sOverride, sCanOverride, sInfobar,
                                    sDocumentNum, sImportDocId, sEmpNum, sContainerNum)

                        If oResponse.IsReturnValueStdError Then
                            MGException.Throw(oResponse.Parameters(10).Value)
                        Else
                            appDB.SetSessionVariable("JobReceiptPostSp.CanOverride", oResponse.Parameters(9).Value)
                            appDB.SetSessionVariable("JobReceiptPostSp.Infobar", oResponse.Parameters(10).Value)
                        End If


                    Case "SLJobTrans.ApsSyncDeferSp"
                        Dim sInfobar As String

                        sInfobar = appDB.GetSessionVariable("ApsSyncDeferSp.Infobar")
                        oResponse = Me.Context.Commands.Invoke("SLJobTrans", "ApsSyncDeferSp", sInfobar, "SLSerials.DoProcessMethod()")

                        If oResponse.IsReturnValueStdError Then
                            MGException.Throw(oResponse.Parameters(0).Value)
                        End If

                    Case "SLJobTrans.ApsSyncImmediateSp"
                        Dim sInfobar As String

                        sInfobar = appDB.GetSessionVariable("ApsSyncImmediateSp.Infobar")
                        oResponse = Me.Context.Commands.Invoke("SLJobTrans", "ApsSyncImmediateSp", sInfobar, 0, "SLSerials.DoProcessMethod()")

                        If oResponse.IsReturnValueStdError Then
                            MGException.Throw(oResponse.Parameters(0).Value)
                        End If

                    Case "SLItemLocs.IaPostSp"
                        Dim sTrxType As String
                        Dim sTransDate As String
                        Dim sAcct As String
                        Dim sAcctUnit1 As String
                        Dim sAcctUnit2 As String
                        Dim sAcctUnit3 As String
                        Dim sAcctUnit4 As String
                        Dim sTransQty As String
                        Dim sWhse As String
                        Dim sItem As String
                        Dim sLoc As String
                        Dim sLot As String
                        Dim sFromSite As String
                        Dim sToSite As String
                        Dim sReasonCode As String
                        Dim sTrnNum As String
                        Dim sTrnLine As String
                        Dim sTransNum As String
                        Dim sRsvdNum As String
                        Dim sSerialStat As String
                        Dim sWorkkey As String
                        Dim sOverride As String
                        Dim sMatlCost As String
                        Dim sLbrCost As String
                        Dim sFovhdCost As String
                        Dim sVovhdCost As String
                        Dim sOutCost As String
                        Dim sTotalCost As String
                        Dim sProfitMarkup As String
                        Dim sInfobar As String
                        Dim sToWhse As String
                        Dim sToLoc As String
                        Dim sToLot As String
                        Dim sTransferTrxType As String
                        Dim sTmpSerId As String
                        Dim sUseExistingSerials As String
                        Dim sSerialPrefix As String
                        Dim sRemoteSiteLot As String
                        Dim sDocumentNum As String
                        Dim sImportDocId As String
                        Dim sMoveZeroCostItem As String
                        Dim sEmpNum As String
                        Dim sSkipItemlocDelete As String

                        sTrxType = appDB.GetSessionVariable("IaPostSp.TrxType")
                        sTransDate = appDB.GetSessionVariable("IaPostSp.TransDate")
                        sAcct = appDB.GetSessionVariable("IaPostSp.Acct")
                        sAcctUnit1 = appDB.GetSessionVariable("IaPostSp.AcctUnit1")
                        sAcctUnit2 = appDB.GetSessionVariable("IaPostSp.AcctUnit2")
                        sAcctUnit3 = appDB.GetSessionVariable("IaPostSp.AcctUnit3")
                        sAcctUnit4 = appDB.GetSessionVariable("IaPostSp.AcctUnit4")
                        sTransQty = appDB.GetSessionVariable("IaPostSp.TransQty")
                        sWhse = appDB.GetSessionVariable("IaPostSp.Whse")
                        sItem = appDB.GetSessionVariable("IaPostSp.Item")
                        sLoc = appDB.GetSessionVariable("IaPostSp.Loc")
                        sLot = appDB.GetSessionVariable("IaPostSp.Lot")
                        sFromSite = appDB.GetSessionVariable("IaPostSp.FromSite")
                        sToSite = appDB.GetSessionVariable("IaPostSp.ToSite")
                        sReasonCode = appDB.GetSessionVariable("IaPostSp.ReasonCode")
                        sTrnNum = appDB.GetSessionVariable("IaPostSp.TrnNum")
                        sTrnLine = appDB.GetSessionVariable("IaPostSp.TrnLine")
                        sTransNum = appDB.GetSessionVariable("IaPostSp.TransNum")
                        sRsvdNum = appDB.GetSessionVariable("IaPostSp.RsvdNum")
                        sSerialStat = appDB.GetSessionVariable("IaPostSp.SerialStat")
                        sWorkkey = appDB.GetSessionVariable("IaPostSp.Workkey")
                        sOverride = appDB.GetSessionVariable("IaPostSp.Override")
                        sMatlCost = appDB.GetSessionVariable("IaPostSp.MatlCost")
                        sLbrCost = appDB.GetSessionVariable("IaPostSp.LbrCost")
                        sFovhdCost = appDB.GetSessionVariable("IaPostSp.FovhdCost")
                        sVovhdCost = appDB.GetSessionVariable("IaPostSp.VovhdCost")
                        sOutCost = appDB.GetSessionVariable("IaPostSp.OutCost")
                        sTotalCost = appDB.GetSessionVariable("IaPostSp.TotalCost")
                        sProfitMarkup = appDB.GetSessionVariable("IaPostSp.ProfitMarkup")
                        sInfobar = appDB.GetSessionVariable("IaPostSp.Infobar")

                        sToWhse = appDB.GetSessionVariable("IaPostSp.ToWhse")
                        sToLoc = appDB.GetSessionVariable("IaPostSp.ToLoc")
                        sToLot = appDB.GetSessionVariable("IaPostSp.ToLot")
                        sTransferTrxType = appDB.GetSessionVariable("IaPostSp.TransferTrxType")
                        sTmpSerId = appDB.GetSessionVariable("IaPostSp.TmpSerId")
                        sUseExistingSerials = appDB.GetSessionVariable("IaPostSp.UseExistingSerials")
                        sSerialPrefix = appDB.GetSessionVariable("IaPostSp.SerialPrefix")
                        sRemoteSiteLot = appDB.GetSessionVariable("IaPostSp.RemoteSiteLot")
                        sDocumentNum = appDB.GetSessionVariable("IaPostSp.DocumentNum")
                        sImportDocId = appDB.GetSessionVariable("IaPostSp.ImportDocId")
                        sMoveZeroCostItem = appDB.GetSessionVariable("IaPostSp.MoveZeroCostItem")
                        sEmpNum = appDB.GetSessionVariable("IaPostSp.EmpNum")
                        sSkipItemlocDelete = appDB.GetSessionVariable("IaPostSp.SkipItemlocDelete")

                        sInfobar = appDB.GetSessionVariable("IaPostSp.Infobar")

                        oResponse = Me.Context.Commands.Invoke("SLItemLocs", "IaPostSp", sTrxType, sTransDate, sAcct, sAcctUnit1,
                                    sAcctUnit2, sAcctUnit3, sAcctUnit4, sTransQty, sWhse, sItem, sLoc, sLot, sFromSite, sToSite,
                                    sReasonCode, sTrnNum, sTrnLine, sTransNum, sRsvdNum, sSerialStat, sWorkkey, sOverride, sMatlCost,
                                    sLbrCost, sFovhdCost, sVovhdCost, sOutCost, sTotalCost, sProfitMarkup, sInfobar, sToWhse, sToLoc,
                                    sToLot, sTransferTrxType, sTmpSerId, sUseExistingSerials, sSerialPrefix, sRemoteSiteLot, sDocumentNum,
                                    sImportDocId, sMoveZeroCostItem, sEmpNum, sSkipItemlocDelete)

                        If oResponse.IsReturnValueStdError Then
                            MGException.Throw(oResponse.Parameters(29).Value)
                        End If

                    Case "SLStockActItems.ItemMiscReceiptSp"
                        Dim sP_Item As String
                        Dim sP_Whse As String
                        Dim sP_Qty As String
                        Dim sP_UM As String
                        Dim sP_MatlCost As String
                        Dim sP_LbrCost As String
                        Dim sP_FovhdCost As String
                        Dim sP_VovhdCost As String
                        Dim sP_OutCost As String
                        Dim sP_UnitCost As String
                        Dim sP_Loc As String
                        Dim sP_Lot As String
                        Dim sP_Reason As String
                        Dim sP_Acct As String
                        Dim sP_AcctUnit1 As String
                        Dim sP_AcctUnit2 As String
                        Dim sP_AcctUnit3 As String
                        Dim sP_AcctUnit4 As String
                        Dim sP_TransDate As String
                        Dim sInfobar As String
                        Dim sDocumentNum As String
                        Dim sP_ImportDocId As String
                        Dim sContainerNum As String
                        Dim sUMVendNum As String
                        Dim sUMArea As String

                        sP_Item = appDB.GetSessionVariable("ItemMiscReceiptSp.P_Item")
                        sP_Whse = appDB.GetSessionVariable("ItemMiscReceiptSp.P_Whse")
                        sP_Qty = appDB.GetSessionVariable("ItemMiscReceiptSp.P_Qty")
                        sP_UM = appDB.GetSessionVariable("ItemMiscReceiptSp.P_UM")
                        sP_MatlCost = appDB.GetSessionVariable("ItemMiscReceiptSp.P_MatlCost")
                        sP_LbrCost = appDB.GetSessionVariable("ItemMiscReceiptSp.P_LbrCost")
                        sP_FovhdCost = appDB.GetSessionVariable("ItemMiscReceiptSp.P_FovhdCost")
                        sP_VovhdCost = appDB.GetSessionVariable("ItemMiscReceiptSp.P_VovhdCost")
                        sP_OutCost = appDB.GetSessionVariable("ItemMiscReceiptSp.P_OutCost")
                        sP_UnitCost = appDB.GetSessionVariable("ItemMiscReceiptSp.P_UnitCost")
                        sP_Loc = appDB.GetSessionVariable("ItemMiscReceiptSp.P_Loc")
                        sP_Lot = appDB.GetSessionVariable("ItemMiscReceiptSp.P_Lot")
                        sP_Reason = appDB.GetSessionVariable("ItemMiscReceiptSp.P_Reason")
                        sP_Acct = appDB.GetSessionVariable("ItemMiscReceiptSp.P_Acct")
                        sP_AcctUnit1 = appDB.GetSessionVariable("ItemMiscReceiptSp.P_AcctUnit1")
                        sP_AcctUnit2 = appDB.GetSessionVariable("ItemMiscReceiptSp.P_AcctUnit2")
                        sP_AcctUnit3 = appDB.GetSessionVariable("ItemMiscReceiptSp.P_AcctUnit3")
                        sP_AcctUnit4 = appDB.GetSessionVariable("ItemMiscReceiptSp.P_AcctUnit4")
                        sP_TransDate = appDB.GetSessionVariable("ItemMiscReceiptSp.P_TransDate")
                        sInfobar = appDB.GetSessionVariable("ItemMiscReceiptSp.Infobar")
                        sDocumentNum = appDB.GetSessionVariable("ItemMiscReceiptSp.DocumentNum")
                        sP_ImportDocId = appDB.GetSessionVariable("ItemMiscReceiptSp.P_ImportDocId")
                        sContainerNum = appDB.GetSessionVariable("ItemMiscReceiptSp.ContainerNum")
                        sUMVendNum = appDB.GetSessionVariable("ItemMiscReceiptSp.UMVendNum")
                        sUMArea = appDB.GetSessionVariable("ItemMiscReceiptSp.UMArea")

                        oResponse = Me.Context.Commands.Invoke("SLStockActItems", "ItemMiscReceiptSp", sP_Item, sP_Whse, sP_Qty, sP_UM, sP_MatlCost _
                                    , sP_LbrCost, sP_FovhdCost, sP_VovhdCost, sP_OutCost, sP_UnitCost, sP_Loc, sP_Lot, sP_Reason, sP_Acct,
                                    sP_AcctUnit1, sP_AcctUnit2, sP_AcctUnit3, sP_AcctUnit4, sP_TransDate, sInfobar, sDocumentNum, sP_ImportDocId,
                                    sContainerNum, sUMVendNum, sUMArea)

                        If oResponse.IsReturnValueStdError Then
                            MGException.Throw(oResponse.Parameters(19).Value)
                        End If

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

                        oResponse = Me.Context.Commands.Invoke("SLMSMoves", "MsmpSp", sPType, sPDate, sPQty, sPItem,
                                    sPFromSite, sPFromWhse, sPFromLoc, sPFromLot, sPToSite, sPToWhse, sPToLoc, sPToLot,
                                    sPZeroCost, sPTrnNum, sPTrnLine, sPTransNum, sPRsvdNum, sPStat, sPRefNum, sPRefLineSuf,
                                    sPRefRelease, sRemoteSiteLot, sPReasonCode, sPUnitCost, sPMatlCost, sPLbrCost, sPFovhdCost,
                                    sPVovhdCost, sPOutCost, sPTotCost, sInfobar, sPImportDocId, sMoveZeroCostItem)

                        If Not oResponse.IsReturnValueStdError Then
                            appDB.SetSessionVariable("MsmpSp.PUnitCost", oResponse.Parameters(23).GetValue(Of String))
                            appDB.SetSessionVariable("MsmpSp.PMatlCost", oResponse.Parameters(24).GetValue(Of String))
                            appDB.SetSessionVariable("MsmpSp.PLbrCost", oResponse.Parameters(25).GetValue(Of String))
                            appDB.SetSessionVariable("MsmpSp.PFovhdCost", oResponse.Parameters(26).GetValue(Of String))
                            appDB.SetSessionVariable("MsmpSp.PVovhdCost", oResponse.Parameters(27).GetValue(Of String))
                            appDB.SetSessionVariable("MsmpSp.POutCost", oResponse.Parameters(28).GetValue(Of String))
                            appDB.SetSessionVariable("MsmpSp.PTotCost", oResponse.Parameters(29).GetValue(Of String))
                            appDB.SetSessionVariable("MsmpSp.Infobar", oResponse.Parameters(30).GetValue(Of String))
                        End If

                    Case "SLPsitems.PSCmplTransSp"
                        Dim sItem As String
                        Dim sQty As String
                        Dim sTransDate As String
                        Dim sPsNum As String
                        Dim sEmployee As String
                        Dim sOperNum As String
                        Dim sWc As String
                        Dim sShift As String
                        Dim sLoc As String
                        Dim sLot As String
                        Dim sSerialPrefix As String
                        Dim sSessionID As String
                        Dim sJobtranTransNum As String
                        Dim sTCoby As String
                        Dim sInfobar As String
                        Dim sPromptMsg As String
                        Dim sPromptButtons As String
                        Dim sCreateMatPostRecord As String
                        Dim sContainerNum As String
                        Dim sDocumentNum As String

                        sItem = appDB.GetSessionVariable("PSCmplTransSp.Item")
                        sQty = appDB.GetSessionVariable("PSCmplTransSp.Qty")
                        sTransDate = appDB.GetSessionVariable("PSCmplTransSp.TransDate")
                        sPsNum = appDB.GetSessionVariable("PSCmplTransSp.PsNum")
                        sEmployee = appDB.GetSessionVariable("PSCmplTransSp.Employee")
                        sOperNum = appDB.GetSessionVariable("PSCmplTransSp.OperNum")
                        sWc = appDB.GetSessionVariable("PSCmplTransSp.Wc")
                        sShift = appDB.GetSessionVariable("PSCmplTransSp.Shift")
                        sLoc = appDB.GetSessionVariable("PSCmplTransSp.Loc")
                        sLot = appDB.GetSessionVariable("PSCmplTransSp.Lot")
                        sSerialPrefix = appDB.GetSessionVariable("PSCmplTransSp.SerialPrefix")
                        sSessionID = appDB.GetSessionVariable("PSCmplTransSp.SessionID")
                        sJobtranTransNum = appDB.GetSessionVariable("PSCmplTransSp.JobtranTransNum")
                        sTCoby = appDB.GetSessionVariable("PSCmplTransSp.TCoby")
                        sInfobar = appDB.GetSessionVariable("PSCmplTransSp.Infobar")
                        sPromptMsg = appDB.GetSessionVariable("PSCmplTransSp.PromptMsg")
                        sPromptButtons = appDB.GetSessionVariable("PSCmplTransSp.PromptButtons")
                        sCreateMatPostRecord = appDB.GetSessionVariable("PSCmplTransSp.CreateMatPostRecord")
                        sContainerNum = appDB.GetSessionVariable("PSCmplTransSp.ContainerNum")
                        sDocumentNum = appDB.GetSessionVariable("PSCmplTransSp.DocumentNum")

                        oResponse = Me.Context.Commands.Invoke("SLPsitems", "PSCmplTransSp", sItem, sQty, sTransDate, sPsNum, sEmployee,
                                    sOperNum, sWc, sShift, sLoc, sLot, sSerialPrefix, sSessionID, sJobtranTransNum, sTCoby, sInfobar,
                                    sPromptMsg, sPromptButtons, sCreateMatPostRecord, sContainerNum, sDocumentNum)

                        If oResponse.IsReturnValueStdError Then
                            MGException.Throw(oResponse.Parameters(14).Value)
                        Else
                            appDB.SetSessionVariable("PSCmplTransSp.JobtranTransNum", oResponse.Parameters(12).Value())
                            appDB.SetSessionVariable("PSCmplTransSp.TCoby", oResponse.Parameters(13).Value())
                            appDB.SetSessionVariable("PSCmplTransSp.Infobar", oResponse.Parameters(14).Value())
                            appDB.SetSessionVariable("PSCmplTransSp.PromptMsg", oResponse.Parameters(15).Value())
                            appDB.SetSessionVariable("PSCmplTransSp.PromptButtons", oResponse.Parameters(16).Value())
                        End If
                    Case "SLProjMatls.ProjmatlTransactionSp"
                        Dim sPProjNum As String
                        Dim sPTaskNum As String
                        Dim sPSeqNum As String
                        Dim sPItem As String
                        Dim sPItemDesc As String
                        Dim sPQty As String
                        Dim sPQtyConv As String
                        Dim sPUM As String
                        Dim sCurWhse As String
                        Dim sPCostCode As String
                        Dim sPLoc1 As String
                        Dim sPLot1 As String
                        Dim sPTransDate As String
                        Dim sPTranType As String
                        Dim sPNonInvAcct As String
                        Dim sPNonInvAcctUnit1 As String
                        Dim sPNonInvAcctUnit2 As String
                        Dim sPNonInvAcctUnit3 As String
                        Dim sPNonInvAcctUnit4 As String
                        Dim sPNonInvCost As String
                        Dim sCreateMatl As String
                        Dim sTSeqNum As String
                        Dim sInfobar As String
                        Dim sPImportDocId1 As String
                        Dim sDocumentNum As String

                        sPProjNum = appDB.GetSessionVariable("ProjmatlTransactionSp.PProjNum")
                        sPTaskNum = appDB.GetSessionVariable("ProjmatlTransactionSp.PTaskNum")
                        sPSeqNum = appDB.GetSessionVariable("ProjmatlTransactionSp.PSeqNum")
                        sPItem = appDB.GetSessionVariable("ProjmatlTransactionSp.PItem")
                        sPItemDesc = appDB.GetSessionVariable("ProjmatlTransactionSp.PItemDesc")
                        sPQty = appDB.GetSessionVariable("ProjmatlTransactionSp.PQty")
                        sPQtyConv = appDB.GetSessionVariable("ProjmatlTransactionSp.PQtyConv")
                        sPUM = appDB.GetSessionVariable("ProjmatlTransactionSp.PUM")
                        sCurWhse = appDB.GetSessionVariable("ProjmatlTransactionSp.CurWhse")
                        sPCostCode = appDB.GetSessionVariable("ProjmatlTransactionSp.PCostCode")
                        sPLoc1 = appDB.GetSessionVariable("ProjmatlTransactionSp.PLoc1")
                        sPLot1 = appDB.GetSessionVariable("ProjmatlTransactionSp.PLot1")
                        sPTransDate = appDB.GetSessionVariable("ProjmatlTransactionSp.PTransDate")
                        sPTranType = appDB.GetSessionVariable("ProjmatlTransactionSp.PTranType")
                        sPNonInvAcct = appDB.GetSessionVariable("ProjmatlTransactionSp.PNonInvAcct")
                        sPNonInvAcctUnit1 = appDB.GetSessionVariable("ProjmatlTransactionSp.PNonInvAcctUnit1")
                        sPNonInvAcctUnit2 = appDB.GetSessionVariable("ProjmatlTransactionSp.PNonInvAcctUnit2")
                        sPNonInvAcctUnit3 = appDB.GetSessionVariable("ProjmatlTransactionSp.PNonInvAcctUnit3")
                        sPNonInvAcctUnit4 = appDB.GetSessionVariable("ProjmatlTransactionSp.PNonInvAcctUnit4")
                        sPNonInvCost = appDB.GetSessionVariable("ProjmatlTransactionSp.PNonInvCost")
                        sCreateMatl = appDB.GetSessionVariable("ProjmatlTransactionSp.CreateMatl")
                        sTSeqNum = appDB.GetSessionVariable("ProjmatlTransactionSp.TSeqNum")
                        sInfobar = appDB.GetSessionVariable("ProjmatlTransactionSp.Infobar")
                        sPImportDocId1 = appDB.GetSessionVariable("ProjmatlTransactionSp.PImportDocId1")
                        sDocumentNum = appDB.GetSessionVariable("ProjmatlTransactionSp.DocumentNum")

                        oResponse = Me.Context.Commands.Invoke("SLProjMatls", "ProjmatlTransactionSp", sPProjNum, sPTaskNum, sPSeqNum, sPItem, sPItemDesc,
                                    sPQty, sPQtyConv, sPUM, sCurWhse, sPCostCode, sPLoc1, sPLot1, sPTransDate, sPTranType, sPNonInvAcct,
                                    sPNonInvAcctUnit1, sPNonInvAcctUnit2, sPNonInvAcctUnit3, sPNonInvAcctUnit4, sPNonInvCost, sCreateMatl,
                                    sTSeqNum, sInfobar, sPImportDocId1, sDocumentNum)
                        If oResponse.IsReturnValueStdError Then
                            MGException.Throw(oResponse.Parameters(22).Value)
                        Else
                            appDB.SetSessionVariable("ProjmatlTransactionSp.TSeqNum", oResponse.Parameters(21).Value)
                            appDB.SetSessionVariable("ProjmatlTransactionSp.Infobar", oResponse.Parameters(22).Value)
                        End If
                    Case "SLItemLocs.MvPostSp"
                        Dim sPType As String
                        Dim sPDate As String
                        Dim sPQty As String
                        Dim sPItem As String
                        Dim sFromWhse As String
                        Dim sFromLoc As String
                        Dim sFromLot As String
                        Dim sToWhse As String
                        Dim sToLoc As String
                        Dim sToLot As String
                        Dim sPZeroCost As String
                        Dim sPTrnNum As String
                        Dim sPTrnLine As String
                        Dim sPTransNum As String
                        Dim sPRsvdNum As String
                        Dim sPStat As String
                        Dim sPRefNum As String
                        Dim sPRefLineSuf As String
                        Dim sPRefRelease As String
                        Dim sRefStr As String
                        Dim sPUnitCost As String
                        Dim sPMatlCost As String
                        Dim sPLbrCost As String
                        Dim sPFovhdCost As String
                        Dim sPVovhdCost As String
                        Dim sPOutCost As String
                        Dim sPTotCost As String
                        Dim sInfobar As String
                        Dim sDocumentNum As String
                        Dim sFromImportDocId As String
                        Dim sToImportDocId As String
                        Dim sReasonCode As String

                        sPType = appDB.GetSessionVariable("MvPostSp.PType")
                        sPDate = appDB.GetSessionVariable("MvPostSp.PDate")
                        sPQty = appDB.GetSessionVariable("MvPostSp.PQty ")
                        sPItem = appDB.GetSessionVariable("MvPostSp.PItem")
                        sFromWhse = appDB.GetSessionVariable("MvPostSp.FromWhse")
                        sFromLoc = appDB.GetSessionVariable("MvPostSp.FromLoc")
                        sFromLot = appDB.GetSessionVariable("MvPostSp.FromLot")
                        sToWhse = appDB.GetSessionVariable("MvPostSp.ToWhse")
                        sToLoc = appDB.GetSessionVariable("MvPostSp.ToLoc")
                        sToLot = appDB.GetSessionVariable("MvPostSp.ToLot")
                        sPZeroCost = appDB.GetSessionVariable("MvPostSp.PZeroCost")
                        sPTrnNum = appDB.GetSessionVariable("MvPostSp.PTrnNum")
                        sPTrnLine = appDB.GetSessionVariable("MvPostSp.PTrnLine")
                        sPTransNum = appDB.GetSessionVariable("MvPostSp.PTransNum")
                        sPRsvdNum = appDB.GetSessionVariable("MvPostSp.PRsvdNum")
                        sPStat = appDB.GetSessionVariable("MvPostSp.PStat")
                        sPRefNum = appDB.GetSessionVariable("MvPostSp.PRefNum")
                        sPRefLineSuf = appDB.GetSessionVariable("MvPostSp.PRefLineSuf")
                        sPRefRelease = appDB.GetSessionVariable("MvPostSp.PRefRelease")
                        sRefStr = appDB.GetSessionVariable("MvPostSp.RefStr")
                        sPUnitCost = appDB.GetSessionVariable("MvPostSp.PUnitCost")
                        sPMatlCost = appDB.GetSessionVariable("MvPostSp.PMatlCost")
                        sPLbrCost = appDB.GetSessionVariable("MvPostSp.PLbrCost")
                        sPFovhdCost = appDB.GetSessionVariable("MvPostSp.PFovhdCost")
                        sPVovhdCost = appDB.GetSessionVariable("MvPostSp.PVovhdCost")
                        sPOutCost = appDB.GetSessionVariable("MvPostSp.POutCost")
                        sPTotCost = appDB.GetSessionVariable("MvPostSp.PTotCost")
                        sInfobar = appDB.GetSessionVariable("MvPostSp.Infobar")
                        sDocumentNum = appDB.GetSessionVariable("MvPostSp.DocumentNum")
                        sFromImportDocId = appDB.GetSessionVariable("MvPostSp.FromImportDocId")
                        sToImportDocId = appDB.GetSessionVariable("MvPostSp.ToImportDocId")
                        sReasonCode = appDB.GetSessionVariable("MvPostSp.ReasonCode")


                        oResponse = Me.Context.Commands.Invoke("SLItemLocs", "MvPostSp", sPType, sPDate, sPQty, sPItem, sFromWhse,
                                    sFromLoc, sFromLot, sToWhse, sToLoc, sToLot, sPZeroCost, sPTrnNum, sPTrnLine, sPTransNum, sPRsvdNum,
                                    sPStat, sPRefNum, sPRefLineSuf, sPRefRelease, sRefStr, sPUnitCost, sPMatlCost, sPLbrCost, sPFovhdCost,
                                    sPVovhdCost, sPOutCost, sPTotCost, sInfobar, sDocumentNum, sFromImportDocId, sToImportDocId, sReasonCode)

                        If oResponse.IsReturnValueStdError Then
                            MGException.Throw(oResponse.Parameters(27).Value)
                        End If

                        appDB.SetSessionVariable("MvPostSp.PUnitCost", oResponse.Parameters(20).Value)
                        appDB.SetSessionVariable("MvPostSp.PMatlCost", oResponse.Parameters(21).Value)
                        appDB.SetSessionVariable("MvPostSp.PLbrCost", oResponse.Parameters(22).Value)
                        appDB.SetSessionVariable("MvPostSp.PFovhdCost", oResponse.Parameters(23).Value)
                        appDB.SetSessionVariable("MvPostSp.PVovhdCost", oResponse.Parameters(24).Value)
                        appDB.SetSessionVariable("MvPostSp.POutCost", oResponse.Parameters(25).Value)
                        appDB.SetSessionVariable("MvPostSp.PTotCost", oResponse.Parameters(26).Value)
                        appDB.SetSessionVariable("MvPostSp.Infobar", oResponse.Parameters(27).Value)

                    Case "SLTrnitems.TransferLossIaPostSp"
                        Dim sTrxType As String
                        Dim sTransDate As String
                        Dim sAcct As String
                        Dim sAcctUnit1 As String
                        Dim sAcctUnit2 As String
                        Dim sAcctUnit3 As String
                        Dim sAcctUnit4 As String
                        Dim sTransQty As String
                        Dim sWhse As String
                        Dim sItem As String
                        Dim sLoc As String
                        Dim sLot As String
                        Dim sFROMSite As String
                        Dim sToSite As String
                        Dim sRemoteSite As String
                        Dim sReasonCode As String
                        Dim sTrnNum As String
                        Dim sTrnLine As String
                        Dim sInfobar As String
                        Dim sImportDocId As String
                        Dim sMoveZeroCostItem As String
                        Dim sRecordDate As String
                        Dim sDocumentNum As String

                        sTrxType = appDB.GetSessionVariable("TransferLossIaPostSp.TrxType")
                        sTransDate = appDB.GetSessionVariable("TransferLossIaPostSp.TransDate")
                        sAcct = appDB.GetSessionVariable("TransferLossIaPostSp.Acct")
                        sAcctUnit1 = appDB.GetSessionVariable("TransferLossIaPostSp.AcctUnit1")
                        sAcctUnit2 = appDB.GetSessionVariable("TransferLossIaPostSp.AcctUnit2")
                        sAcctUnit3 = appDB.GetSessionVariable("TransferLossIaPostSp.AcctUnit3")
                        sAcctUnit4 = appDB.GetSessionVariable("TransferLossIaPostSp.AcctUnit4")
                        sTransQty = appDB.GetSessionVariable("TransferLossIaPostSp.TransQty")
                        sWhse = appDB.GetSessionVariable("TransferLossIaPostSp.Whse")
                        sItem = appDB.GetSessionVariable("TransferLossIaPostSp.Item")
                        sLoc = appDB.GetSessionVariable("TransferLossIaPostSp.Loc")
                        sLot = appDB.GetSessionVariable("TransferLossIaPostSp.Lot")
                        sFROMSite = appDB.GetSessionVariable("TransferLossIaPostSp.FROMSite")
                        sToSite = appDB.GetSessionVariable("TransferLossIaPostSp.ToSite")
                        sRemoteSite = appDB.GetSessionVariable("TransferLossIaPostSp.RemoteSite")
                        sReasonCode = appDB.GetSessionVariable("TransferLossIaPostSp.ReasonCode")
                        sTrnNum = appDB.GetSessionVariable("TransferLossIaPostSp.TrnNum")
                        sTrnLine = appDB.GetSessionVariable("TransferLossIaPostSp.TrnLine")
                        sInfobar = appDB.GetSessionVariable("TransferLossIaPostSp.Infobar")
                        sImportDocId = appDB.GetSessionVariable("TransferLossIaPostSp.ImportDocId")
                        sMoveZeroCostItem = appDB.GetSessionVariable("TransferLossIaPostSp.MoveZeroCostItem")
                        sRecordDate = appDB.GetSessionVariable("TransferLossIaPostSp.RecordDate")
                        sDocumentNum = appDB.GetSessionVariable("TransferLossIaPostSp.DocumentNum")

                        oResponse = Me.Context.Commands.Invoke("SLTrnitems", "TransferLossIaPostSp", sTrxType, sTransDate, sAcct, sAcctUnit1, sAcctUnit2, sAcctUnit3,
                                    sAcctUnit4, sTransQty, sWhse, sItem, sLoc, sLot, sFROMSite, sToSite, sRemoteSite, sReasonCode, sTrnNum, sTrnLine, sInfobar,
                                    sImportDocId, sMoveZeroCostItem, sRecordDate, sDocumentNum)
                        If oResponse.IsReturnValueStdError Then
                            MGException.Throw(oResponse.Parameters(18).Value)
                        Else
                            appDB.SetSessionVariable("TransferLossIaPostSp.Infobar", oResponse.Parameters(18).Value())
                        End If
                    Case "SLTrnacts.TransferOrderReceiveSp"
                        Dim sTrnNum As String
                        Dim sTrnLine As String
                        Dim sItem As String
                        Dim sFromSite As String
                        Dim sFromWhse As String
                        Dim sTrnLoc As String
                        Dim sFromLot As String
                        Dim sToSite As String
                        Dim sToWhse As String
                        Dim sFobSite As String
                        Dim sToLoc As String
                        Dim sToLot As String
                        Dim sTQtyReceived As String
                        Dim sTUM As String
                        Dim sTTransDate As String
                        Dim sUnitFreightCostConv As String
                        Dim sUnitDutyCostConv As String
                        Dim sUnitBrokerageCostConv As String
                        Dim sUnitInsuranceCostConv As String
                        Dim sUnitLocFrtCostConv As String
                        Dim sTitle As String
                        Dim sUseExistingSerials As String
                        Dim sSerialPrefix As String
                        Dim sPReasonCode As String
                        Dim sInfobar As String
                        Dim sImportDocId As String
                        Dim sMoveZeroCostItem As String
                        Dim sRecordDate As String
                        Dim sDocumentNum As String

                        sTrnNum = appDB.GetSessionVariable("TransferOrderReceiveSp.TrnNum")
                        sTrnLine = appDB.GetSessionVariable("TransferOrderReceiveSp.TrnLine")
                        sItem = appDB.GetSessionVariable("TransferOrderReceiveSp.Item")
                        sFromSite = appDB.GetSessionVariable("TransferOrderReceiveSp.FromSite")
                        sFromWhse = appDB.GetSessionVariable("TransferOrderReceiveSp.FromWhse")
                        sTrnLoc = appDB.GetSessionVariable("TransferOrderReceiveSp.TrnLoc")
                        sFromLot = appDB.GetSessionVariable("TransferOrderReceiveSp.FromLot")
                        sToSite = appDB.GetSessionVariable("TransferOrderReceiveSp.ToSite")
                        sToWhse = appDB.GetSessionVariable("TransferOrderReceiveSp.ToWhse")
                        sFobSite = appDB.GetSessionVariable("TransferOrderReceiveSp.FobSite")
                        sToLoc = appDB.GetSessionVariable("TransferOrderReceiveSp.ToLoc")
                        sToLot = appDB.GetSessionVariable("TransferOrderReceiveSp.ToLot")
                        sTQtyReceived = appDB.GetSessionVariable("TransferOrderReceiveSp.TQtyReceived")
                        sTUM = appDB.GetSessionVariable("TransferOrderReceiveSp.TUM")
                        sTTransDate = appDB.GetSessionVariable("TransferOrderReceiveSp.TTransDate")
                        sUnitFreightCostConv = appDB.GetSessionVariable("TransferOrderReceiveSp.UnitFreightCostConv")
                        sUnitDutyCostConv = appDB.GetSessionVariable("TransferOrderReceiveSp.UnitDutyCostConv")
                        sUnitBrokerageCostConv = appDB.GetSessionVariable("TransferOrderReceiveSp.UnitBrokerageCostConv")
                        sUnitInsuranceCostConv = appDB.GetSessionVariable("TransferOrderReceiveSp.UnitInsuranceCostConv")
                        sUnitLocFrtCostConv = appDB.GetSessionVariable("TransferOrderReceiveSp.UnitLocFrtCostConv")
                        sTitle = appDB.GetSessionVariable("TransferOrderReceiveSp.Title")
                        sUseExistingSerials = appDB.GetSessionVariable("TransferOrderReceiveSp.UseExistingSerials")
                        sSerialPrefix = appDB.GetSessionVariable("TransferOrderReceiveSp.SerialPrefix")
                        sPReasonCode = appDB.GetSessionVariable("TransferOrderReceiveSp.PReasonCode")
                        sInfobar = appDB.GetSessionVariable("TransferOrderReceiveSp.Infobar")
                        sImportDocId = appDB.GetSessionVariable("TransferOrderReceiveSp.ImportDocId")
                        sMoveZeroCostItem = appDB.GetSessionVariable("TransferOrderReceiveSp.MoveZeroCostItem")
                        sRecordDate = appDB.GetSessionVariable("TransferOrderReceiveSp.RecordDate")
                        sDocumentNum = appDB.GetSessionVariable("TransferOrderReceiveSp.DocumentNum")

                        oResponse = Me.Context.Commands.Invoke("SLTrnacts", "TransferOrderReceiveSp", sTrnNum, sTrnLine, sItem, sFromSite, sFromWhse,
                                    sTrnLoc, sFromLot, sToSite, sToWhse, sFobSite, sToLoc, sToLot, sTQtyReceived, sTUM, sTTransDate, sUnitFreightCostConv,
                                    sUnitDutyCostConv, sUnitBrokerageCostConv, sUnitInsuranceCostConv, sUnitLocFrtCostConv, sTitle, sUseExistingSerials,
                                    sSerialPrefix, sPReasonCode, sInfobar, sImportDocId, sMoveZeroCostItem, IDONull.Value, sRecordDate, sDocumentNum)

                        If Not oResponse.IsReturnValueStdError Then
                            appDB.SetSessionVariable("TransferOrderReceiveSp.Infobar", oResponse.Parameters(24).Value)
                        Else
                            MGException.Throw(oResponse.Parameters(24).Value)
                        End If

                    Case "SLTrnacts.TransferOrderShipSp"
                        Dim sTrnNum As String
                        Dim sTransferFromSite As String
                        Dim sTransferToSite As String
                        Dim sTransferFobSite As String
                        Dim sTransferFromWhse As String
                        Dim sTransferToWhse As String
                        Dim sTrnLine As String
                        Dim sTQtyShipped As String
                        Dim sTUM As String
                        Dim sTShipDate As String
                        Dim sTFromLoc As String
                        Dim sTFromLot As String
                        Dim sTToLot As String
                        Dim sTitle As String
                        Dim sRemoteSiteLotProcess As String
                        Dim sUseExistingSerials As String
                        Dim sSerialPrefix As String
                        Dim sPReasonCode As String
                        Dim sInfobar As String
                        Dim sTImportDocId As String
                        Dim sExportDocId As String
                        Dim sMoveZeroCostItem As String
                        Dim sRecordDate As String
                        Dim sDocumentNum As String

                        sTrnNum = appDB.GetSessionVariable("TransferOrderShipSp.TrnNum")
                        sTransferFromSite = appDB.GetSessionVariable("TransferOrderShipSp.TransferFromSite")
                        sTransferToSite = appDB.GetSessionVariable("TransferOrderShipSp.TransferToSite")
                        sTransferFobSite = appDB.GetSessionVariable("TransferOrderShipSp.TransferFobSite")
                        sTransferFromWhse = appDB.GetSessionVariable("TransferOrderShipSp.TransferFromWhse")
                        sTransferToWhse = appDB.GetSessionVariable("TransferOrderShipSp.TransferToWhse")
                        sTrnLine = appDB.GetSessionVariable("TransferOrderShipSp.TrnLine")
                        sTQtyShipped = appDB.GetSessionVariable("TransferOrderShipSp.TQtyShipped")
                        sTUM = appDB.GetSessionVariable("TransferOrderShipSp.TUM")
                        sTShipDate = appDB.GetSessionVariable("TransferOrderShipSp.TShipDate")
                        sTFromLoc = appDB.GetSessionVariable("TransferOrderShipSp.TFromLoc")
                        sTFromLot = appDB.GetSessionVariable("TransferOrderShipSp.TFromLot")
                        sTToLot = appDB.GetSessionVariable("TransferOrderShipSp.TToLot")
                        sTitle = appDB.GetSessionVariable("TransferOrderShipSp.Title")
                        sRemoteSiteLotProcess = appDB.GetSessionVariable("TransferOrderShipSp.RemoteSiteLotProcess")
                        sUseExistingSerials = appDB.GetSessionVariable("TransferOrderShipSp.UseExistingSerials")
                        sSerialPrefix = appDB.GetSessionVariable("TransferOrderShipSp.SerialPrefix")
                        sPReasonCode = appDB.GetSessionVariable("TransferOrderShipSp.PReasonCode")
                        sInfobar = appDB.GetSessionVariable("TransferOrderShipSp.Infobar")
                        sTImportDocId = appDB.GetSessionVariable("TransferOrderShipSp.TImportDocId")
                        sExportDocId = appDB.GetSessionVariable("TransferOrderShipSp.ExportDocId")
                        sMoveZeroCostItem = appDB.GetSessionVariable("TransferOrderShipSp.MoveZeroCostItem")
                        sRecordDate = appDB.GetSessionVariable("TransferOrderShipSp.RecordDate")
                        sDocumentNum = appDB.GetSessionVariable("TransferOrderShipSp.DocumentNum")

                        oResponse = Me.Context.Commands.Invoke("SLTrnacts", "TransferOrderShipSp", sTrnNum, sTransferFromSite, sTransferToSite, sTransferFobSite _
                                    , sTransferFromWhse, sTransferToWhse, sTrnLine, sTQtyShipped, sTUM, sTShipDate, sTFromLoc, sTFromLot, sTToLot, sTitle _
                                    , sRemoteSiteLotProcess, sUseExistingSerials, sSerialPrefix, sPReasonCode, sInfobar, sTImportDocId, sExportDocId, sMoveZeroCostItem _
                                    , IDONull.Value, sRecordDate, sDocumentNum)

                        If oResponse.IsReturnValueStdError Then
                            MGException.Throw(oResponse.Parameters(18).Value)
                        Else
                            appDB.SetSessionVariable("TransferOrderShipSp.Infobar", oResponse.Parameters(18).Value)
                        End If

                    Case "SLWcs.WcmatlSp"
                        Dim sTWc As String
                        Dim sTItem As String
                        Dim sTWhse As String
                        Dim sTLoc As String
                        Dim sTLot As String
                        Dim sTQty As String
                        Dim sTTransDate As String
                        Dim sTEmpNum As String
                        Dim sTAcct As String
                        Dim sTAcctUnit1 As String
                        Dim sTAcctUnit2 As String
                        Dim sTAcctUnit3 As String
                        Dim sTAcctUnit4 As String
                        Dim sTMatlCost As String
                        Dim sTLbrCost As String
                        Dim sTFovhdCost As String
                        Dim sTVovhdCost As String
                        Dim sTOutCost As String
                        Dim sUmConvFactor As String
                        Dim sSerialPrefix As String
                        Dim sInfobar As String
                        Dim sDocumentNum As String

                        sTWc = appDB.GetSessionVariable("WcmatlSp.TWc")
                        sTItem = appDB.GetSessionVariable("WcmatlSp.TItem")
                        sTWhse = appDB.GetSessionVariable("WcmatlSp.TWhse")
                        sTLoc = appDB.GetSessionVariable("WcmatlSp.TLoc")
                        sTLot = appDB.GetSessionVariable("WcmatlSp.TLot")
                        sTQty = appDB.GetSessionVariable("WcmatlSp.TQty")
                        sTTransDate = appDB.GetSessionVariable("WcmatlSp.TTransDate")
                        sTEmpNum = appDB.GetSessionVariable("WcmatlSp.TEmpNum")
                        sTAcct = appDB.GetSessionVariable("WcmatlSp.TAcct")
                        sTAcctUnit1 = appDB.GetSessionVariable("WcmatlSp.TAcctUnit1")
                        sTAcctUnit2 = appDB.GetSessionVariable("WcmatlSp.TAcctUnit2")
                        sTAcctUnit3 = appDB.GetSessionVariable("WcmatlSp.TAcctUnit3")
                        sTAcctUnit4 = appDB.GetSessionVariable("WcmatlSp.TAcctUnit4")
                        sTMatlCost = appDB.GetSessionVariable("WcmatlSp.TMatlCost")
                        sTLbrCost = appDB.GetSessionVariable("WcmatlSp.TLbrCost")
                        sTFovhdCost = appDB.GetSessionVariable("WcmatlSp.TFovhdCost")
                        sTVovhdCost = appDB.GetSessionVariable("WcmatlSp.TVovhdCost")
                        sTOutCost = appDB.GetSessionVariable("WcmatlSp.TOutCost")
                        sUmConvFactor = appDB.GetSessionVariable("WcmatlSp.UmConvFactor")
                        sSerialPrefix = appDB.GetSessionVariable("WcmatlSp.SerialPrefix")
                        sInfobar = appDB.GetSessionVariable("WcmatlSp.Infobar")
                        sDocumentNum = appDB.GetSessionVariable("WcmatlSp.DocumentNum")

                        oResponse = Me.Context.Commands.Invoke("SLWcs", "WcmatlSp", sTWc, sTItem, sTWhse, sTLoc, sTLot, sTQty,
                                    sTTransDate, sTEmpNum, sTAcct, sTAcctUnit1, sTAcctUnit2, sTAcctUnit3, sTAcctUnit4, sTMatlCost,
                                    sTLbrCost, sTFovhdCost, sTVovhdCost, sTOutCost, sUmConvFactor, sSerialPrefix, sInfobar, sDocumentNum)
                        If oResponse.IsReturnValueStdError Then
                            MGException.Throw(oResponse.Parameters(20).GetValue(Of String)())
                        Else
                            appDB.SetSessionVariable("WcmatlSp.Infobar", oResponse.Parameters(20).GetValue(Of String))
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


    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_SerialsForTransactionsSp(ByVal RefType As String, ByVal RefNum As String, ByVal RefLineSuf As Short?, ByVal RefRelease As Short?, ByVal Count As Decimal?,
<[Optional], DefaultParameterValue(CByte(0))> ByVal IsReturn As Byte?,
<[Optional]> ByVal Location As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim iCLM_SerialsForTransactionsExt As ICLM_SerialsForTransactions = New CLM_SerialsForTransactionsFactory().Create(appDb, bunchedLoadCollection)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iCLM_SerialsForTransactionsExt.CLM_SerialsForTransactionsSp(RefType, RefNum, RefLineSuf, RefRelease, Count, IsReturn, Location)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function LoadLotSerialExpDateSp(ByVal Item As String,
        <[Optional]> ByVal ManufacturedDate As DateTime?, ByRef ExpirationDate As DateTime?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iLoadLotSerialExpDateExt As ILoadLotSerialExpDate = New LoadLotSerialExpDateFactory().Create(Me, True)
            Dim result As (ReturnCode As Integer?, ExpirationDate As DateTime?) = iLoadLotSerialExpDateExt.LoadLotSerialExpDateSp(Item, ManufacturedDate, ExpirationDate)
            Dim Severity As Integer = result.ReturnCode.Value
            ExpirationDate = result.ExpirationDate
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function SerialClearSp(
<[Optional]> ByVal RefStr As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iSerialClearExt As CSI.BusInterface.ISerialClear = New CSI.BusInterface.SerialClearFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iSerialClearExt.SerialClearSp(RefStr, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function BflushSerialSaveSp(ByVal TransNum As Decimal?, ByVal Whse As String, ByVal Lot As String, ByVal Selected As Byte?, ByVal Job As String, ByVal Suffix As Short?, ByVal OperNum As Integer?, ByVal Sequence As Short?, ByVal EmpNum As String, ByVal JobMatlItem As String, ByVal Loc As String, ByVal QtyNeeded As Decimal?, ByVal QtyRequired As Decimal?, ByVal JobRouteWc As String, ByVal TransClass As String,
<[Optional]> ByVal TransSeq As Integer?, ByVal SerNum As String, ByRef Infobar As String) As Integer Implements IExtFTSLSerials.BflushSerialSaveSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iBflushSerialSaveExt As IBflushSerialSave = New BflushSerialSaveFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iBflushSerialSaveExt.BflushSerialSaveSp(TransNum, Whse, Lot, Selected, Job, Suffix, OperNum, Sequence, EmpNum, JobMatlItem, Loc, QtyNeeded, QtyRequired, JobRouteWc, TransClass, TransSeq, SerNum, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DeleteTmpSerSp(ByVal TmpSerId As Guid?) As Integer Implements IExtFTSLSerials.DeleteTmpSerSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iDeleteTmpSerExt As IDeleteTmpSer = New DeleteTmpSerFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iDeleteTmpSerExt.DeleteTmpSerSp(TmpSerId)
            Dim Severity As Integer = result.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function SerialDeleteSp(ByVal FROMWhse As String, ByVal ToWhse As String, ByVal FROMSerNum As String, ByVal ToSerNum As String, ByVal FROMItem As String, ByVal ToItem As String, ByVal FROMLot As String, ByVal ToLot As String, ByVal SerialStat As String, ByRef Infobar As String, ByVal ImportDocId As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iSerialDeleteExt As ISerialDelete = New SerialDeleteFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iSerialDeleteExt.SerialDeleteSp(FROMWhse, ToWhse, FROMSerNum, ToSerNum, FROMItem, ToItem, FROMLot, ToLot, SerialStat, Infobar, ImportDocId)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function SerialNumUsedSp(ByVal SerNum As String,
<[Optional], DefaultParameterValue(1)> ByVal Mode As Integer?, ByRef PromptMsg As String, ByRef PromptButtons As String, ByRef Infobar As String, ByVal Quantity As Decimal?, ByVal Item As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iSerialNumUsedExt As ISerialNumUsed = New SerialNumUsedFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PromptMsg As String, PromptButtons As String, Infobar As String) = iSerialNumUsedExt.SerialNumUsedSp(SerNum, Mode, PromptMsg, PromptButtons, Infobar, Quantity, Item)
            Dim Severity As Integer = result.ReturnCode.Value
            PromptMsg = result.PromptMsg
            PromptButtons = result.PromptButtons
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function SerialNumValidationSp(ByVal SerNum As String, ByVal Item As String, ByRef PromptMsg As String, ByRef PromptButtons As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iSerialNumValidationExt As ISerialNumValidation = New SerialNumValidationFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PromptMsg As String, PromptButtons As String, Infobar As String) = iSerialNumValidationExt.SerialNumValidationSp(SerNum, Item, PromptMsg, PromptButtons, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            PromptMsg = result.PromptMsg
            PromptButtons = result.PromptButtons
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function SetMethodSp(ByVal MethodValInput As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iSetMethodExt As ISetMethod = New SetMethodFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iSetMethodExt.SetMethodSp(MethodValInput)
            Return result.Value
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function UpdateContainerItemSerialSp(ByVal PItem As String, ByVal PLot As String, ByVal PContainerNum As String, ByVal PSessionId As Guid?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iUpdateContainerItemSerialExt As IUpdateContainerItemSerial = New UpdateContainerItemSerialFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iUpdateContainerItemSerialExt.UpdateContainerItemSerialSp(PItem, PLot, PContainerNum, PSessionId, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function SerialSaveSp(ByVal SerNum As String,
<[Optional]> ByVal TmpSerId As Guid?,
<[Optional]> ByVal RefStr As String, ByRef Infobar As String,
<[Optional]> ByVal ManufacturedDate As DateTime?,
<[Optional]> ByVal ExpirationDate As DateTime?,
<[Optional], DefaultParameterValue(Nothing)> ByVal TrxRestrictCode As String) As Integer Implements IExtFTSLSerials.SerialSaveSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iSerialSaveExt As ISerialSave = New SerialSaveFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iSerialSaveExt.SerialSaveSp(SerNum, TmpSerId, RefStr, Infobar, ManufacturedDate, ExpirationDate, TrxRestrictCode)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetCurDate(ByRef CurrentDate As DateTime?) As Integer Implements IExtFTSLSerials.GetCurDate
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iGetCurrentDateExt As IGetCurrentDate = New GetCurrentDateFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, CurrentDate As DateTime?) = iGetCurrentDateExt.GetCurrentDateSp(CurrentDate)
            Dim Severity As Integer = result.ReturnCode.Value
            CurrentDate = result.CurrentDate
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ValidateContainerItemsSp(ByVal ContainerNum As String, ByVal CurWhse As String, ByVal RefType As String,
<[Optional]> ByVal RefNum As String,
<[Optional]> ByVal RefLineSuf As Short?,
<[Optional]> ByVal RefRelease As Short?,
<[Optional], DefaultParameterValue(CByte(0))> ByVal MessageContentFlg As Byte?, ByRef PromptMsg As String, ByRef PromptButtons As String, ByRef Infobar As String,
<[Optional], DefaultParameterValue(CByte(0))> ByVal VerifyQtyFlag As Byte?,
<[Optional], DefaultParameterValue(CByte(0))> ByVal ExtScrap As Byte?,
<[Optional]> ByVal TransType As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iValidateContainerItemsExt As IValidateContainerItems = New ValidateContainerItemsFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, PromptMsg As String, PromptButtons As String, Infobar As String) = iValidateContainerItemsExt.ValidateContainerItemsSp(ContainerNum, CurWhse, RefType, RefNum, RefLineSuf, RefRelease, MessageContentFlg, PromptMsg, PromptButtons, Infobar, VerifyQtyFlag, ExtScrap, TransType)
            Dim Severity As Integer = result.ReturnCode.Value
            PromptMsg = result.PromptMsg
            PromptButtons = result.PromptButtons
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function BuildSerialSp(ByVal TransNum As Decimal?, ByRef Infobar As String,
<[Optional]> ByVal ContainerNum As String,
<[Optional]> ByVal ManufacturedDate As DateTime?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iBuildSerialExt As IBuildSerial = New BuildSerialFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iBuildSerialExt.BuildSerialSp(TransNum, Infobar, ContainerNum, ManufacturedDate)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_ExpiringLotsSerialsSp(ByVal CutoffDate As DateTime?, ByVal PMTCodes As String,
        <[Optional]> ByVal FilterString As String,
        <[Optional]> ByVal PSiteGroup As String) As DataTable
        Dim iCLM_ExpiringLotsSerialsExt As ICLM_ExpiringLotsSerials = New CLM_ExpiringLotsSerialsFactory().Create(Me, True)
        Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iCLM_ExpiringLotsSerialsExt.CLM_ExpiringLotsSerialsSp(CutoffDate, PMTCodes, FilterString, PSiteGroup)
        Dim RecordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
        Dim dt As DataTable = RecordCollectionToDataTable.ToDataTable(result.Data.Items)
        Return dt
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_LoadBackflushSp(ByVal BackflushByLot As Integer?, ByVal TransClass As String, ByVal TransNum As Decimal?, ByVal Job As String, ByVal Suffix As Integer?, ByVal OperNum As Integer?, ByVal JobItem As String, ByVal PhantomMulti As Decimal?, ByVal PhantomUnits As String, ByVal PhantomScrap As Decimal?, ByVal TransDate As DateTime?, ByVal Whse As String, ByVal Lot As String, ByVal RouteQtyComplete As Decimal?, ByVal RouteQtyScrapped As Decimal?, ByVal EmpNum As String, ByRef Infobar As String,
<[Optional], DefaultParameterValue(0)> ByVal NESTLEVEL As Integer?) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iCLM_LoadBackflushExt As ICLM_LoadBackflush = New CLM_LoadBackflushFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?, Infobar As String) = iCLM_LoadBackflushExt.CLM_LoadBackflushSp(BackflushByLot, TransClass, TransNum, Job, Suffix, OperNum, JobItem, PhantomMulti, PhantomUnits, PhantomScrap, TransDate, Whse, Lot, RouteQtyComplete, RouteQtyScrapped, EmpNum, Infobar)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Infobar = result.Infobar
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_RMAReturnSerialLoad(ByVal RMANum As String, ByVal RMALIne As Short?, ByVal SerialPrefix As String, ByVal RMAReturnQty As Decimal?, ByVal SerialGenQty As Decimal?, ByVal Whse As String, ByVal Loc As String, ByVal Lot As String, ByVal UnRecvLoc As String, ByVal UnRecvLot As String, ByVal StartSerNum As String, ByVal GenerateFlag As Byte?) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim iCLM_RMAReturnSerialLoadExt As ICLM_RMAReturnSerialLoad = New CLM_RMAReturnSerialLoadFactory().Create(appDb, bunchedLoadCollection)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iCLM_RMAReturnSerialLoadExt.CLM_RMAReturnSerialLoadSp(RMANum, RMALIne, SerialPrefix, RMAReturnQty, SerialGenQty, Whse, Loc, Lot, UnRecvLoc, UnRecvLot, StartSerNum, GenerateFlag)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CombineXferSerialRefreshSp(ByVal Item As String, ByVal QtyShipped As Decimal?, ByVal FromSite As String, ByVal FromWhse As String, ByVal FromLoc As String, ByVal FromLot As String, ByVal ToSite As String, ByVal ToWhse As String, ByVal ToLoc As String, ByVal ToLot As String, ByVal StartSerNum As String, ByVal ImportDocId As String, ByVal TrnNum As String, ByVal TrnLine As Short?, ByVal PreassignSerials As Byte?) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCombineXferSerialRefreshExt As ICombineXferSerialRefresh = New CombineXferSerialRefreshFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (Data As CSI.Data.CRUD.ICollectionLoadResponse, ReturnCode As Integer?) = iCombineXferSerialRefreshExt.CombineXferSerialRefreshSp(Item, QtyShipped, FromSite, FromWhse, FromLoc, FromLot, ToSite, ToWhse, ToLoc, ToLot, StartSerNum, ImportDocId, TrnNum, TrnLine, PreassignSerials)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function COShippingSerialRefreshSp(ByVal Item As String, ByVal QtyShipped As Decimal?, ByVal UbCRRt As Integer?, ByVal Whse As String, ByVal Loc As String, ByVal Lot As String, ByVal StartSerNum As String, ByVal CoNum As String, ByVal CoLine As Integer?, ByVal CoRelease As Integer?, ByVal DoNum As String, ByVal DoLine As Integer?, ByVal ShipmentID As Decimal?, ByVal ShipmentLine As Integer?, ByVal ShipmentSeq As Integer?, ByVal Gen As Integer?, ByVal GenQty As Decimal?, ByVal ImportDocId As String, ByVal TransType As Integer?, ByVal StartingSerial As String, ByVal EndingSerial As String, ByVal ContainerNum As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCOShippingSerialRefreshExt As ICOShippingSerialRefresh = New COShippingSerialRefreshFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (Data As CSI.Data.CRUD.ICollectionLoadResponse, ReturnCode As Integer?) = iCOShippingSerialRefreshExt.COShippingSerialRefreshSp(Item, QtyShipped, UbCRRt, Whse, Loc, Lot, StartSerNum, CoNum, CoLine, CoRelease, DoNum, DoLine, ShipmentID, ShipmentLine, ShipmentSeq, Gen, GenQty, ImportDocId, TransType, StartingSerial, EndingSerial, ContainerNum)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function JobTranLoadSerialSp(ByVal TransNum As Decimal?, ByVal Job As String, ByVal Suffix As Integer?, ByVal QtyMoved As Decimal?, ByVal MoveToLocation As String,
        <[Optional]> ByVal FilterString As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iJobTranLoadSerialExt As IJobTranLoadSerial = New JobTranLoadSerialFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (Data As CSI.Data.CRUD.ICollectionLoadResponse, ReturnCode As Integer?) = iJobTranLoadSerialExt.JobTranLoadSerialSp(TransNum, Job, Suffix, QtyMoved, MoveToLocation, FilterString)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function JobtranSerialSaveSp(ByVal SerNum As String, ByVal Selected As Integer?,
        <[Optional]> ByVal TmpSerId As Guid?, ByVal Item As String,
        <[Optional]> ByVal PreassignSerials As Integer?,
        <[Optional]> ByVal TrxRestrictCode As String) As Integer 
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iJobtranSerialSaveExt As IJobtranSerialSave = New JobtranSerialSaveFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iJobtranSerialSaveExt.JobtranSerialSaveSp(SerNum, Selected, TmpSerId, Item, PreassignSerials, TrxRestrictCode)
            Dim Severity As Integer = result.Value
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

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function TransferLossSerialRefreshSp(ByVal PTrnNum As String, ByVal PTrnLine As Short?, ByVal FROMSite As String, ByVal ToSite As String, ByVal Lot As String, ByVal TriQtyLoss As Decimal?, ByVal ItLotTracked As Byte?, ByVal Stat As String, ByVal ImportDocId As String, ByVal ItTaxFreeMatl As Byte?) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iTransferLossSerialRefreshExt As ITransferLossSerialRefresh = New TransferLossSerialRefreshFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (Data As CSI.Data.CRUD.ICollectionLoadResponse, ReturnCode As Integer?) = iTransferLossSerialRefreshExt.TransferLossSerialRefreshSp(PTrnNum, PTrnLine, FROMSite, ToSite, Lot, TriQtyLoss, ItLotTracked, Stat, ImportDocId, ItTaxFreeMatl)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function TrnShipSerialRefreshSp(ByVal Item As String, ByVal QtyShipped As Decimal?, ByVal FromSite As String, ByVal FromWhse As String, ByVal FromLoc As String, ByVal FromLot As String, ByVal ToSite As String, ByVal ToWhse As String, ByVal ToLoc As String, ByVal ToLot As String, ByVal FobSite As String, ByVal TrnNum As String, ByVal TrnLine As Short?, ByVal StartSerNum As String, ByVal ImportDocId As String, ByVal PreassignSerials As Byte?) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iTrnShipSerialRefreshExt As ITrnShipSerialRefresh = New TrnShipSerialRefreshFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (Data As CSI.Data.CRUD.ICollectionLoadResponse, ReturnCode As Integer?) = iTrnShipSerialRefreshExt.TrnShipSerialRefreshSp(Item, QtyShipped, FromSite, FromWhse, FromLoc, FromLot, ToSite, ToWhse, ToLoc, ToLot, FobSite, TrnNum, TrnLine, StartSerNum, ImportDocId, PreassignSerials)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function TrrcvSerialRefreshSp(ByVal Item As String, ByVal QtyReceived As Decimal?, ByVal FromSite As String, ByVal FromWhse As String, ByVal TrnLoc As String, ByVal FromLot As String, ByVal ToSite As String, ByVal ToWhse As String, ByVal ToLoc As String, ByVal ToLot As String, ByVal FobSite As String, ByVal TrnNum As String, ByVal TrnLine As Short?, ByVal StartSerNum As String, ByVal ImportDocId As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iTrrcvSerialRefreshExt As ITrrcvSerialRefresh = New TrrcvSerialRefreshFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (Data As CSI.Data.CRUD.ICollectionLoadResponse, ReturnCode As Integer?) = iTrrcvSerialRefreshExt.TrrcvSerialRefreshSp(Item, QtyReceived, FromSite, FromWhse, TrnLoc, FromLot, ToSite, ToWhse, ToLoc, ToLot, FobSite, TrnNum, TrnLine, StartSerNum, ImportDocId)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function UpdatePreassignedSerialSp(ByVal [Select] As Byte?, ByVal SerNum As String, ByVal RefType As String, ByVal RefNum As String, ByVal RefLineSuf As Short?, ByVal RefRelease As Short?, ByVal Item As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iUpdatePreassignedSerialExt As IUpdatePreassignedSerial = New UpdatePreassignedSerialFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iUpdatePreassignedSerialExt.UpdatePreassignedSerialSp([Select], SerNum, RefType, RefNum, RefLineSuf, RefRelease, Item, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ValidateRestrictedTransSp(
    <[Optional]> ByVal Item As String,
    <[Optional]> ByVal Lot As String,
    <[Optional]> ByVal SerialNums As String, ByVal MatlTransType As String, ByRef Infobar As String,
    <[Optional], DefaultParameterValue(0)> ByVal RefId As Decimal?,
    <[Optional]> ByVal RefType As String,
    <[Optional]> ByVal ProcessId As Guid?,
    <[Optional]> ByVal Site As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)

            Dim iValidateRestrictedTransExt As IValidateRestrictedTrans = New ValidateRestrictedTransFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)

            Dim result As (ReturnCode As Integer?, Infobar As String) = iValidateRestrictedTransExt.ValidateRestrictedTransSp(Item, Lot, SerialNums, MatlTransType, Infobar, RefId, RefType, ProcessId, Site)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

End Class
