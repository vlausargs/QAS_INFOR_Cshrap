using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mongoose.Core.Configuration;
using Mongoose.IDO.Protocol;
using Mongoose.IDO;
using Mongoose.Core;
using System.Globalization;

namespace InforCollect.ERP.SL.ICSLOutBoundTrans
{
    class PickPackShipPickListItemUpdate : OutBoundUtilities
    {
        //original picklist information to identify the record.
        string picklistID = "";
        string picklistSequence = "";
        string picklistLocation = "";
        string picklistItem = "";
        string picklistLot = "";
        // string serNum = "";
        private string SessionID = "";
        string packLoc = "";
        //updated information.
        string location = "";
        string lot = "";
        string qty = "";
        //data used to identify the record in the tmp table.
        string ProcessGUID = "", recordRowPointer = "", ProcessGUID2 = "";
        private ICSLOutBoundTrans.SLDAL.SLTmpPickListLocsDAL DAL;
        private ICSLOutBoundTrans.SLDAL.SLPickListsDAL PickListDAL;
        private List<string> SerialList = null;
        string errorMessage = "";
        string serNum = "";
        string ItemId = "";

        //public PickPackShipPickListItemUpdate(string picklistID, string picklistLocation, string picklistItem,
        //                                      string picklistLot, string serNum, string packLoc, string location,string lot,string qty)
        //Constructor.  Should only Initialize the object
        public PickPackShipPickListItemUpdate()
        {
            initialize();
            //this.picklistID = picklistID;
            //this.picklistLocation = picklistLocation;
            //this.picklistItem = picklistItem;
            //this.picklistLot = picklistLot;
            //this.serNum = serNum;
            ////internal variables.
            //this.packLoc = packLoc;
            //this.location = location;
            //this.lot = lot;
            //this.qty = qty;

        }

        public void initialize()
        {
            //Input variables initialization
            picklistID = "";
            picklistSequence = "";
            picklistLocation = "";
            picklistItem = "";
            picklistLot = "";
            SessionID = "";
            packLoc = "";
            location = "";
            lot = "";
            qty = "";
        }
        public bool setInputs(string picklistID, string picklistSequence, string picklistLocation, string picklistItem, string picklistLot, string location, string lot, string qty, string sessionID, string packLoc)
        {
            this.picklistID = picklistID;
            this.picklistSequence = picklistSequence;
            this.picklistLocation = picklistLocation;
            this.picklistItem = picklistItem;
            this.picklistLot = picklistLot;
            this.location = location;
            this.lot = lot;
            this.qty = qty;
            this.SessionID = sessionID;
            this.packLoc = packLoc;

            return true;
        }
        public bool formatInputs()
        {

            if (picklistID == "")
            {//this is required.
                errorMessage = "picklistID input mandatory";
                return false;
            }

            if (picklistLocation == "")
            {//this is required.
                errorMessage = "picklistLocation input mandatory";
                return false;
            }

            if (picklistItem == "")
            {//this is required.
                errorMessage = "picklistItem input mandatory";
                return false;
            }
            picklistLot = formatDataByIDOAndPropertyName("SLLot", "Lot", picklistLot);

            //updated information.
            lot = formatDataByIDOAndPropertyName("SLLot", "Lot", lot);

            //SerNum = queryRequest.GetFieldValue("sernum");  //unformatted value
            serNum = formatDataByIDOAndPropertyName("SLTmpPickListLocs", "SerNum", serNum);
            return true;
        }

        private bool validateInputs()
        {
            bool retVal = true;

            return retVal;
        }

        public int PerformUpdate(out string Infobar)
        {//converted processMessage to collect PerformUpdate  JH:20130816
            Infobar = "";
            if (SessionID != null && !(SessionID.Equals("")))
            {
                SerialList = this.GetSerialList(this.SessionID);
            }


            if (formatInputs() == false)
            {
                Infobar = errorMessage;
                return 1;
            }

            validateInputs();

            if (performUpdate() == false)
            {
                Infobar = errorMessage;
                return 3;
            }


            if (ProcessGUID2 != "" & ProcessGUID2 != null)
            {
                DAL.ProcessID = ProcessGUID2;
                DAL.InvokeIDOMethod_PurgeTmpPickListLocSerialSp(); //Make sure we cleanup after our self.
                ClearSerailsBySessionID(ProcessGUID2);  // Clear serials from tmp_ser table
            }
            if (ProcessGUID != "" & ProcessGUID != null)
            {
                DAL.ProcessID = ProcessGUID;
                DAL.InvokeIDOMethod_PurgeTmpPickListLocSerialSp(); //Make sure we cleanup after our self.
            }

            return 0;
        }

        private bool performUpdate()
        {
            bool retVal = true;
            string msg = "";
            string sPickListRefNum = "";
            string sPickListRefLineSuf = "";
            bool bAltLocLotBelongsToPickList = false;
            DAL = new ICSLOutBoundTrans.SLDAL.SLTmpPickListLocsDAL(this.Context);
            PickListDAL = new ICSLOutBoundTrans.SLDAL.SLPickListsDAL(this.Context);

            LoadCollectionResponseData DALResponseData = null;
            LoadCollectionRequestData DALRequestData = null;

            PickListDAL.PickListId = picklistID;

            DALRequestData = PickListDAL.GetQueryRquest();

            DALRequestData.PropertyList.SetProperties("PackLoc,RowPointer,RecordDate");

            DALResponseData = ExcuteQueryRequest(DALRequestData);         // Read Pick List header

            if (DALResponseData.Items.Count > 0)
            {
                if (DALResponseData[0, "PackLoc"].Value == null || DALResponseData[0, "PackLoc"].Value == "" || DALResponseData[0, "PackLoc"].Value != packLoc)
                {
                    PickListDAL.RowPointer = DALResponseData[0, "RowPointer"].Value;
                    PickListDAL.RecordDate = DALResponseData[0, "RecordDate"].Value;
                    PickListDAL.PackLoc = packLoc;

                    msg = PickListDAL.Update();
                    if (msg != "")
                    {
                        return false;
                    }
                }
            }

            GenerateGUID(ref ProcessGUID, out errorMessage);
            if (errorMessage != "")
            {
                return false;
            }
            //GenerateGUID(ref ProcessGUID2, out errorMessage);
            if (SessionID == null || SessionID.Trim() == "")
            {
                GenerateGUID(ref ProcessGUID2, out errorMessage);
                DAL.ProcessID = ProcessGUID;
            }
            else
            {
                ProcessGUID2 = SessionID;
                DAL.ProcessID = ProcessGUID2;
            }
            DAL.PickListId = picklistID;
            // msg = DAL.InvokeIDOMethod_PickConfirmationSp();  //Copy all of the records over to the tmp_pick_list_loc table.
            msg = DAL.InvokeIDOMethod_RecordDifference_PickConfirmationSp();
            if (msg != "")
            {
                errorMessage = constructErrorMessage(msg, "PPSU0004", null);
                return false;
            }
            string pickLocFilter;
            if (picklistLot == "" || picklistLot == null)
            {
                pickLocFilter = "PickListId= " + picklistID + " AND CoiItem='" + picklistItem + "'" + " AND Loc='" + picklistLocation + "' AND Sequence=" + picklistSequence + "";// AND ((QtyToPick - QtyPicked )> 0) "; -- Illegal Content issue
            }
            else
            {
                pickLocFilter = "PickListId= " + picklistID + " AND CoiItem='" + picklistItem + "'" + " AND Loc='" + picklistLocation + "'" + " AND Lot='" + picklistLot + "' AND Sequence=" + picklistSequence + "";// AND ((QtyToPick - QtyPicked )> 0) "; -- Illegal Content issue
            }

            LoadCollectionResponseData pickLocIDOResponseData;

            LoadCollectionRequestData picklocIDORequestData = new LoadCollectionRequestData("SLPickListLocs", "PickListId,CoiItem,Loc,Lot,QtyToPick,QtyPicked,RowPointer", pickLocFilter, "", -1);

            pickLocIDOResponseData = this.ExcuteQueryRequest(picklocIDORequestData);
            if (pickLocIDOResponseData.Items.Count > 0)
            {
                DAL.Loc = picklistLocation;
                DAL.Lot = picklistLot;
            }
            LoadCollectionResponseData pickListRefIDOResponseData;

            LoadCollectionRequestData picklistRefIDORequestData = new LoadCollectionRequestData("SLPickListRefs", "PickListId,RefNum,RefLineSuf", "PickListId= " + picklistID + " AND Sequence = '" + picklistSequence + "'", "", -1);

            pickListRefIDOResponseData = this.ExcuteQueryRequest(picklistRefIDORequestData);
            if (pickListRefIDOResponseData.Items.Count > 0)
            {
                sPickListRefNum = pickListRefIDOResponseData[0, "RefNum"].Value;
                sPickListRefLineSuf = pickListRefIDOResponseData[0, "RefLineSuf"].Value;
                DAL.RefNum = sPickListRefNum;
                DAL.RefLineSuf = sPickListRefLineSuf;
            }
            //find the specific record we are working on.
            DAL.ProcessID = ProcessGUID;
            DAL.PickListId = picklistID;
            DAL.Item = picklistItem;
            //DAL.InvokeIDOMethod_RecordDifference_PickConfirmationSp();
            if (SerialList != null)
            {
                DAL.ProcessID = ProcessGUID2;
                // serial controlled item               
                for (int i = 0; i < SerialList.Count; i++)
                {
                    serNum = SerialList.ElementAt(i).ToString();
                    if ((serNum != "") & (serNum != null))
                    {
                        DAL.SerNum = serNum;

                    }
                    msg = DAL.QueryRecords(recordCap: -1, returnProperties: "_ItemId, RowPointer");
                    if (msg != "")
                    {//we had a error.
                        errorMessage = constructErrorMessage(msg, "PPSU0005", null);
                        return false;
                    }

                    if ((DAL.LoadCollectionResponse != null) & (DAL.LoadCollectionResponse.Items.Count > 0))
                    {
                        recordRowPointer = DAL.LoadCollectionResponse[0, "RowPointer"].Value;
                        ItemId = DAL.LoadCollectionResponse[0, "_ItemId"].Value;

                    }
                    else
                    {  // Record not found and create new record
                        ItemId = null;
                        recordRowPointer = null;

                    }

                    if ((recordRowPointer != "") & (recordRowPointer != null))
                    {
                        DAL.ProcessID = ProcessGUID2;
                        DAL.RowPointer = recordRowPointer;
                        DAL.ItemId = ItemId;
                        DAL.SerTracked = "1";
                        DAL.QtyPick = "1";
                        DAL.SerNum = serNum;
                        DAL.Update();  //change the GUID for the record we are working on.

                    }

                    else if (DAL.Loc == "" || DAL.Loc == null)
                    {


                        LoadCollectionResponseData IDOResponseData;
                        string sQtyToPick = "0";
                        string sItmUm = "EA";
                        string filterPickLoc = "";
                        LoadCollectionRequestData IDORequestData = new LoadCollectionRequestData("SLPickListRefs", "PickListId,CoiItem,ItmUM,QtyToPick", "PickListId= " + picklistID + " AND CoiItem='" + picklistItem + "' AND Sequence=" + picklistSequence + "", "", -1);

                        IDOResponseData = this.ExcuteQueryRequest(IDORequestData);
                        if (lot == "" || lot == null)
                        {
                            filterPickLoc = "PickListId= " + picklistID + " AND CoiItem='" + picklistItem + "'" + " AND Loc='" + location + "' AND Sequence=" + picklistSequence + "";
                        }
                        else
                        {
                            filterPickLoc = "PickListId= " + picklistID + " AND CoiItem='" + picklistItem + "'" + " AND Loc='" + location + "'" + " AND Lot='" + lot + "' AND Sequence=" + picklistSequence + "";
                        }
                        LoadCollectionResponseData pickListLocsIDOResponseData;
                        LoadCollectionRequestData pickListLocsIDORequestData = new LoadCollectionRequestData("SLPickListLocs", "PickListId,CoiItem,Loc,Lot,QtyToPick, RowPointer", filterPickLoc, "", -1);
                        pickListLocsIDOResponseData = this.ExcuteQueryRequest(pickListLocsIDORequestData);

                        LoadCollectionResponseData pickListLocsIDOResponseDataByItem;
                        LoadCollectionRequestData pickListLocsIDORequestDataByItem = new LoadCollectionRequestData("SLPickListLocs", "PickListId,CoiItem,Loc,Lot,QtyToPick", "PickListId= " + picklistID + " AND CoiItem='" + picklistItem + "' AND Sequence=" + picklistSequence + "", "", -1);
                        pickListLocsIDOResponseDataByItem = this.ExcuteQueryRequest(pickListLocsIDORequestDataByItem);

                        if (IDOResponseData.Items.Count > 0)
                        {
                            if (pickListLocsIDOResponseDataByItem.Items.Count > 0 && pickListLocsIDOResponseData.Items.Count == 0)
                            {
                                sQtyToPick = qty;
                            }
                            else if (picklistLocation == null || picklistLocation == "")
                            {
                                sQtyToPick = IDOResponseData[0, "QtyToPick"].Value;
                            }
                            sItmUm = IDOResponseData[0, "ItmUM"].Value;
                        }
                        UpdateCollectionRequestData updateRequestData = new UpdateCollectionRequestData();
                        UpdateCollectionResponseData UpdateResponse;
                        IDOUpdateItem _updateItem = new IDOUpdateItem();
                        updateRequestData.IDOName = "SLTmpPickListLocs";
                        updateRequestData.RefreshAfterUpdate = false;
                        if (_updateItem == null)
                        { _updateItem = new IDOUpdateItem(); } //for some reason this is new so create a new one.
                        _updateItem.ItemID = ItemId;
                        _updateItem.Action = UpdateAction.Insert;
                        // _updateItem.Properties.Add("Selected", "1", true);
                        _updateItem.Properties.Add("Loc", location, true);
                        _updateItem.Properties.Add("ProcessID", ProcessGUID2, true);
                        _updateItem.Properties.Add("Item", picklistItem, true);
                        _updateItem.Properties.Add("Lot", lot, true);
                        _updateItem.Properties.Add("LotTracked",string.IsNullOrEmpty(lot) ? "0" :  "1", true); 
                        if (picklistID != null) { _updateItem.Properties.Add("PickListId", picklistID, true); }
                        _updateItem.Properties.Add("PickListSeq", picklistSequence, true);
                        _updateItem.Properties.Add("RefNum", sPickListRefNum, true);
                        _updateItem.Properties.Add("RefLineSuf", sPickListRefLineSuf, true);
                        _updateItem.Properties.Add("QtyPick", "1", true);
                        if (!(string.IsNullOrEmpty(picklistLocation)))
                        {
                            _updateItem.Properties.Add("QtyToPick", "1", true);
                        }
                        else
                        {
                            _updateItem.Properties.Add("QtyToPick", sQtyToPick, true);
                        }
                        //_updateItem.Properties.Add("QtyToPick", sQtyToPick, true);
                        _updateItem.Properties.Add("Reserved", "0", true);
                        _updateItem.Properties.Add("SerNum", serNum, true);
                        _updateItem.Properties.Add("SerTracked", string.IsNullOrEmpty(serNum) ? "0" : "1", true);                        
                        _updateItem.Properties.Add("UM", sItmUm, true);
                        updateRequestData.Items.Add(_updateItem);
                        UpdateResponse = ExecuteUpdateCollection(updateRequestData);

                    }
                    else
                    {
                        retVal = false;
                        errorMessage = constructErrorMessage("no record found", "PPSU001", null);
                        return retVal;
                    }

                }
                if ((picklistLocation != null && location != null && !(picklistLocation.ToUpper().Equals(location.ToUpper()))) ||
                        (picklistLot != null && lot != null && !(picklistLot.ToUpper().Equals(lot.ToUpper()))))
                {
                    bAltLocLotBelongsToPickList = IsAlternateLocLotBelongsToPicklist();
                }
                DAL.ProcessID = ProcessGUID2;
                DAL.PickListId = picklistID;
                msg = DAL.InvokeIDOMethod_PickConfirmationCompleteSp();
                if (msg != "")
                {
                    errorMessage = msg;
                    DAL.InvokeIDOMethod_PurgeTmpPickListLocSerialSp();
                    return false;
                }
                DAL.ProcessID = ProcessGUID2;
                DAL.InvokeIDOMethod_PurgeTmpPickListLocSerialSp(); //remove all of the other records that we are not using.
                if (pickLocIDOResponseData.Items.Count > 0)
                {
                    if ((picklistLocation != null && location != null && !(picklistLocation.ToUpper().Equals(location.ToUpper()))) ||
                        (picklistLot != null && lot != null && !(picklistLot.ToUpper().Equals(lot.ToUpper()))))
                    {
                        if (!bAltLocLotBelongsToPickList)
                        {
                            UpdatePickLocQtyToPickForAlternateLocAndLot(pickLocIDOResponseData[0, "RowPointer"].Value);
                        }
                    }
                }
                return retVal;
            }
            // Non Serial item pick
            else
            {

                msg = DAL.QueryRecords(recordCap: -1, returnProperties: "_ItemId, RowPointer");
                if (msg != "")
                {//we had a error.
                    errorMessage = constructErrorMessage(msg, "PPSU0005", null);
                    return false;
                }

                if ((DAL.LoadCollectionResponse != null) & (DAL.LoadCollectionResponse.Items.Count > 0))
                {
                    recordRowPointer = DAL.LoadCollectionResponse[0, "RowPointer"].Value;
                    ItemId = DAL.LoadCollectionResponse[0, "_ItemId"].Value;

                }
                else
                {  // Record not found and create new record
                    ItemId = null;
                    recordRowPointer = null;

                }


                if ((recordRowPointer != "") & (recordRowPointer != null) & (DAL.Loc != null))
                {
                    DAL.ProcessID = ProcessGUID;
                    DAL.RowPointer = recordRowPointer;
                    DAL.ItemId = ItemId;
                    DAL.QtyPick = qty;
                    if ((picklistLocation != null && location != null && !(picklistLocation.ToUpper().Equals(location.ToUpper()))) ||
                            (picklistLot != null && lot != null && !(picklistLot.ToUpper().Equals(lot.ToUpper()))))
                    {
                        DAL.QtyToPick = qty;
                    }
                    DAL.Update();  //change the GUID for the record we are working on.

                    DAL.ProcessID = ProcessGUID;
                    DAL.PickListId = picklistID;
                    msg = DAL.InvokeIDOMethod_PickConfirmationCompleteSp();
                    DAL.InvokeIDOMethod_PurgeTmpPickListLocSerialSp(); //Make sure we cleanup after our self.
                    DAL.PickListId = "";
                    DAL.InvokeIDOMethod_PickConfirmationSp();

                }
                else if ((DAL.Loc == "") || (DAL.Loc == null))
                {
                    DAL.ProcessID = ProcessGUID;
                    DAL.RowPointer = recordRowPointer;
                    DAL.ItemId = ItemId;
                    DAL.QtyPick = qty;
                    if ((picklistLocation != null && location != null && !(picklistLocation.ToUpper().Equals(location.ToUpper()))) ||
                            (picklistLot != null && lot != null && !(picklistLot.ToUpper().Equals(lot.ToUpper()))))
                    {
                        DAL.QtyToPick = qty;
                        bAltLocLotBelongsToPickList = IsAlternateLocLotBelongsToPicklist();
                    }
                    DAL.Loc = location;
                    DAL.Lot = lot;
                    DAL.Update();  //change the GUID for the record we are working on.

                    DAL.ProcessID = ProcessGUID;
                    DAL.PickListId = picklistID;
                    msg = DAL.InvokeIDOMethod_PickConfirmationCompleteSp();
                    DAL.InvokeIDOMethod_PurgeTmpPickListLocSerialSp(); //Make sure we cleanup after our self.
                    if (msg != "")
                    {//we had a error.
                        errorMessage = constructErrorMessage(msg, "PPSU0005", null);
                        return false;
                    }
                    DAL.PickListId = "";
                    DAL.InvokeIDOMethod_PickConfirmationSp();
                    if (pickLocIDOResponseData.Items.Count > 0)
                    {
                        if ((picklistLocation != null && location != null && !(picklistLocation.ToUpper().Equals(location.ToUpper()))) ||
                            (picklistLot != null && lot != null && !(picklistLot.ToUpper().Equals(lot.ToUpper()))))
                        {
                            if (!bAltLocLotBelongsToPickList)
                            {
                                UpdatePickLocQtyToPickForAlternateLocAndLot(pickLocIDOResponseData[0, "RowPointer"].Value);
                            }
                        }
                    }
                }
                else
                {
                    retVal = false;
                    errorMessage = constructErrorMessage("no record found", "PPSU001", null);
                }
                return retVal;

            }
        }
        private bool IsAlternateLocLotBelongsToPicklist()
        {
            string filterPickLoc = "";
            LoadCollectionResponseData pickListLocsIDOResponseData;
            if (lot == "" || lot == null)
            {
                filterPickLoc = "PickListId= " + picklistID + " AND CoiItem='" + picklistItem + "'" + " AND Loc='" + location + "' AND Sequence=" + picklistSequence;
            }
            else
            {
                filterPickLoc = "PickListId= " + picklistID + " AND CoiItem='" + picklistItem + "'" + " AND Loc='" + location + "'" + " AND Lot='" + lot + "' AND Sequence=" + picklistSequence;
            }

            LoadCollectionRequestData pickListLocsIDORequestData = new LoadCollectionRequestData("SLPickListLocs", "PickListId,CoiItem,Loc,Lot,QtyToPick,QtyPicked,RowPointer", filterPickLoc, "", -1);
            pickListLocsIDOResponseData = this.ExcuteQueryRequest(pickListLocsIDORequestData);
            if (pickListLocsIDOResponseData.Items.Count > 0 &&
                    (Convert.ToDecimal(pickListLocsIDOResponseData[0, "QtyToPick"].Value, CultureInfo.InvariantCulture) - Convert.ToDecimal(pickListLocsIDOResponseData[0, "QtyPicked"].Value, CultureInfo.InvariantCulture) > 0)) // FTDEV-9247
            {
                return true;
            }
            return false;
        }
        private void UpdatePickLocQtyToPickForAlternateLocAndLot(string rowpointer)
        {
            LoadCollectionResponseData pickListLocsResponseData;
            UpdateCollectionRequestData updateRequestData;
            UpdateCollectionResponseData updateResponse;
            Decimal dQtyToPick = 0;
            LoadCollectionRequestData PickListLocsRequestData = new LoadCollectionRequestData("SLPickListLocs", "_ItemId, PickListId,CoiItem,Loc,Lot,QtyToPick",
                "PickListId= " + picklistID + " AND CoiItem='" + picklistItem + "' AND RowPointer='" + rowpointer + "' ", "", -1);
            try
            {
                pickListLocsResponseData = this.ExcuteQueryRequest(PickListLocsRequestData);
                if (pickListLocsResponseData.Items.Count > 0)
                {
                    dQtyToPick = Convert.ToDecimal(pickListLocsResponseData[0, "QtyToPick"].Value, CultureInfo.InvariantCulture) - Convert.ToDecimal(qty, CultureInfo.InvariantCulture); // FTDEV-9247
                    updateRequestData = new UpdateCollectionRequestData();
                    updateResponse = new UpdateCollectionResponseData();
                    IDOUpdateItem _updateItem = new IDOUpdateItem();
                    updateRequestData.IDOName = "SLPickListLocs";
                    updateRequestData.RefreshAfterUpdate = true;
                    _updateItem.Action = UpdateAction.Update;
                    _updateItem.ItemID = pickListLocsResponseData[0, "_ItemId"].Value;
                    _updateItem.Properties.Add("RowPointer", rowpointer, false);
                    if (dQtyToPick >= 0)
                    {
                        _updateItem.Properties.Add("QtyToPick", dQtyToPick, true);
                    }
                    else
                    {
                        _updateItem.Properties.Add("QtyToPick", 0, true);
                    }
                    updateRequestData.Items.Add(_updateItem);

                    //updateResponse = ExecuteUpdateCollection(updateRequestData);
                    updateResponse = this.Context.Commands.UpdateCollection(updateRequestData);

                }
            }
            catch (Exception)
            {
            }
        }

    }
}
