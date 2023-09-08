using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mongoose.Core.Configuration;
using Mongoose.IDO.Protocol;
using Mongoose.IDO;
using Mongoose.Core;
using System.Globalization;

namespace InforCollect.ERP.SL.ICSLInventoryCountTrans
{
    class CycleCountUpdate : InventoryCountUtilities
    {
        #region Input Variables
        //Input Variables.
        private string item = "";
        private string site = "";
        private string whse = "";
        private string loc = "";
        private string lot = "";
        private string uom = "";
        private string qty = "";
        private string user = "";
        private string RowPointer = "";
        private string RecordDate = "";
        private string SerNum = "";
        private bool addItemLocRecord = true;
        private bool addCycleCountRecord = false;
        private bool addPermanentItemWhseLocLink = false;
        #endregion
        #region Local Varialbles
        //Local Varialbles
        private bool itemLotTracked = false;
        private bool itemSerialTracked = false;
        private bool insertItemLocRecord = false;
        private bool cycleCountRecordFound = false;
        private LoadCollectionResponseData cycleResponseData = null;
        //private List<string> SerialList = null;
        private string errorMessage = "";

        #endregion


        public CycleCountUpdate(string item, string site, string whse,
                                    string loc, string lot, string uom, string qty, string user, string RowPointer,
                                    string RecordDate, string SerNum, bool addItemLocRecord, bool addCycleCountRecord,
                                    bool addPermanentItemWhseLocLink)
        {

            this.item = item;
            this.site = site;
            this.whse = whse;
            this.loc = loc;
            this.lot = lot;
            this.uom = uom;
            this.qty = qty;
            this.user = user;
            this.RowPointer = RowPointer;
            this.RecordDate = RecordDate;
            this.SerNum = SerNum;
            this.addItemLocRecord = addItemLocRecord;
            this.addCycleCountRecord = addCycleCountRecord;
            this.addPermanentItemWhseLocLink = addPermanentItemWhseLocLink;

        }

        public void initialize()
        {
            //Input variables initialization
            site = "";
            whse = "";
            item = "";
            RowPointer = "";
            RecordDate = "";
            lot = "";
            qty = "";
            loc = "";
            uom = "";
            addItemLocRecord = true;
            SerNum = "";
            addPermanentItemWhseLocLink = false;
            addCycleCountRecord = false;

            //Local variables initialization
            itemLotTracked = false;
            itemSerialTracked = false;
            insertItemLocRecord = false;
            cycleCountRecordFound = false;
            cycleResponseData = null;

        }



        public bool formatInputs()
        {

            if (qty == null || qty.Trim().Equals(""))
            {
                //errorMessage = "qty input mandatory";
                //return false;
                qty = "0";
            }
            //try
            //{
            //    if (Convert.ToDouble(qty) <= 0)
            //    {
            //        errorMessage = "Quantity should be greater than 0";
            //        return false;
            //    }
            //}
            //catch (InvalidCastException ice)
            //{
            //    errorMessage = "Invalid Quantity Input";
            //    return false;
            //}


            item = formatDataByIDOAndPropertyName("SLLotLocs", "Item", item);
            if (item == null || item.Trim().Equals(""))
            {
                errorMessage = constructErrorMessage("item input mandatory", "SLAXXXX006", null);
                return false;
            }



            if (site == null || site.Trim().Equals(""))
            {
                errorMessage = "site input mandatory";
                return false;
            }

            if (whse == null || whse.Trim().Equals(""))
            {
                errorMessage = "whse input mandatory";
                return false;
            }
            if (loc == null || loc.Trim().Equals(""))
            {
                errorMessage = "loc input mandatory";
                return false;
            }

            if (uom == null || uom.Trim().Equals(""))
            {
                errorMessage = "uom input mandatory";
                return false;
            }
            lot = formatDataByIDOAndPropertyName("SLLotLocs", "Lot", lot);
            if (lot == null)
                lot = "";
            SerNum = formatDataByIDOAndPropertyName("SLMSSerials", "SerNum", SerNum);
            if (SerNum == null)
                SerNum = "";

            return true;
        }


        private string ExpandKey(string key, int length)
        {
            string retVal = "";

            if (key == null)
            {
                return retVal;
            }

            key = key.Trim();

            if (key.Length == length)
            {
                retVal = key;
            }

            if (key.Length < length)
            {
                retVal = key.PadLeft(length, ' ');
            }

            if (key.Length > length)
            {
                while (key.Length > length && key.Contains("0"))
                {
                    key = key.Remove(key.IndexOf("0"), 1);
                }
                retVal = key;
            }

            return retVal;
        }

        public bool validateInputs()
        {

            GetCycleCountDetails();
            if (cycleResponseData == null || cycleResponseData.Items.Count == 0)
            {
                if (!(RecordDate.Trim().Equals("")) || !(RowPointer.Trim().Equals("")))
                {
                    errorMessage = constructErrorMessage("Cycle Count Record Not Found, Record Data and Row Pointer should be blank", "SLACYUP007", null);
                    return false;
                }
                cycleCountRecordFound = false;
                if (addCycleCountRecord == false)
                {
                    errorMessage = constructErrorMessage("Cycle Count Record Not Found", "SLACYUP008", null);
                    return false;
                }
            }
            else
            {
                cycleCountRecordFound = true;
                if (checkCycleCountRecordDetails() == false)
                {
                    return false;
                }
            }

            //Validate Site
            LoadCollectionResponseData responseData = GetSiteDetails(site);
            if (responseData.PropertyList.Count == 0)
            {
                errorMessage = constructErrorMessage("Site Details Not Found", "SLAXXXX025", null);
                return false;
            }

            //Check Warehouse
            responseData = GetWhseDetailsBySite(whse, site);
            if (responseData.PropertyList.Count == 0)
            {
                errorMessage = constructErrorMessage("Whse Details Not Found", "SLAXXXX026", null);
                return false;
            }

            string physicalInventoryFlag = GetPropertyValue(responseData.PropertyList, responseData.Items, "PhyInvFlg");
            if (physicalInventoryFlag == null)
            {
                errorMessage = constructErrorMessage("Error Reading WhseAll record", "SLAXXXX018", null);
                return false;
            }

            if (!(physicalInventoryFlag.Equals("0")))
            {
                IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                substitutorDictionary.Add("whse", whse);
                errorMessage = constructErrorMessage("Physical Inventory is active for this Warehouse : {whse}", "SLACYUP001", substitutorDictionary);
                return false;
            }

            //Check Item Details
            responseData = GetItemDetails(formatItem(item));
            if (responseData.PropertyList.Count == 0)
            {
                errorMessage = constructErrorMessage("Item Details Not Found", "SLAXXXX020", null);
                return false;
            }

            itemLotTracked = GetBool(GetPropertyValue(responseData.PropertyList, responseData.Items, "LotTracked"));
            itemSerialTracked = GetBool(GetPropertyValue(responseData.PropertyList, responseData.Items, "SerialTracked"));

            //Check Item Warehouse Combination

            /*if (checkItemWhseCombination() == false)
            {
                return false;
            }*/

            //Check Location
            responseData = GetLocationDetails(loc);
            if (checkLocationDetails(item, whse, site, loc, out errorMessage) == false)
            {
                if (addItemLocRecord == false)
                {
                    IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                    substitutorDictionary.Add("site", site);
                    substitutorDictionary.Add("whse", whse);
                    substitutorDictionary.Add("item", item);
                    substitutorDictionary.Add("loc", loc);
                    errorMessage = constructErrorMessage("{site} / {whse} / {item} / {loc} combination does not exists", "SLACYUP002", substitutorDictionary);
                    return false;
                }
                else
                {
                    insertItemLocRecord = true;
                }
            }

            //UOM Checks
            string convertedQty = GetItemConvertedQtyToBaseUnit(item, qty, uom, "", out errorMessage);
            if (convertedQty == null)
            {
                return false;
            }
            qty = convertedQty;

            //Lot Checks
            if (itemLotTracked == true)
            {
                //CutOffQty

                if (lot.Trim().Equals(""))
                {
                    if (Convert.ToDecimal(GetPropertyValue(cycleResponseData, "CutOffQty"), CultureInfo.InvariantCulture) == 0 && Convert.ToDecimal(qty, CultureInfo.InvariantCulture) == 0) // FTDEV-9247
                    {
                    }
                    else
                    {
                        errorMessage = constructErrorMessage("Item Lot Tracked, Lot Input Mandatory", "SLAXXXX027", null);
                        return false;
                    }
                }


                if (!(lot.Trim().Equals("")))
                {
                    if (performLotChecks() == false)
                    {
                        return false;
                    }
                }
            }

            //Serial Checks
            if (itemSerialTracked == true)
            {
                if (SerNum.Trim().Equals(""))
                {
                    if (Convert.ToDecimal(GetPropertyValue(cycleResponseData, "CutOffQty"), CultureInfo.InvariantCulture) == 0 && Convert.ToDecimal(qty, CultureInfo.InvariantCulture) == 0) // FTDEV-9247
                    {
                    }
                    else
                    {
                        errorMessage = constructErrorMessage("Item Serial Tracked, Serial Input Mandatory", "SLAXXXX028", null);
                        return false;
                    }
                }
            }

            //Qty Checks

            double localQty = Convert.ToDouble(this.qty, CultureInfo.InvariantCulture); // FTDEV-9247

            if (localQty < 0)
            {
                errorMessage = constructErrorMessage("Quantity Input should be greater than 0", "SLAXXXX029", null);
                return false;
            }

            if (performQtyFieldChecks() == false)
            {
                return false;
            }

            if (itemSerialTracked == true)
            {
                if (localQty > 1)
                {
                    errorMessage = constructErrorMessage("Item Serial Tracked, Input Quantity cannot be greater than 0", "SLACYUP016", null);
                    return false;
                }
            }



            return true;
        }

        public int PerformUpdate(out string infobar)
        {
            infobar = "";
            // SerialList = this.GetSerialList(this.SerialsSessionID);
            if (formatInputs() == false)
            {
                infobar = errorMessage;
                return 1;
            }

            if (validateInputs() == false)
            {
                infobar = errorMessage;
                return 2;
            }

            if (performCycleCount() == false)
            {
                infobar = errorMessage;
                return 3;
            }
            return 0;
        }


        #region private methods


        private bool performCycleCount()
        {
            try
            {
                if (this.insertItemLocRecord == true)
            {
                if (addLocItemRecord(item, whse, site, loc, addPermanentItemWhseLocLink) == false)
                {
                    //return this.errorMessage;
                    return false;
                }
            }

            UpdateCollectionRequestData updateRequestData = new UpdateCollectionRequestData();
            updateRequestData.IDOName = "SLCycles";
            updateRequestData.RefreshAfterUpdate = true;

            IDOUpdateItem updateItem = new IDOUpdateItem();
            if (cycleCountRecordFound)
            {
                updateItem.Action = UpdateAction.Update;
                updateItem.Properties.Add("RowPointer", RowPointer);
                updateItem.Properties.Add("RecordDate", RecordDate);
                updateItem.Properties.Add("CountQty", qty);
                updateItem.Properties.Add("Stat", "C");
            }
            else
            {
                updateItem.Action = UpdateAction.Insert;
                updateItem.ItemID = "";
                updateItem.Properties.Add("RowPointer", "");
                updateItem.Properties.Add("Item", item);
                updateItem.Properties.Add("Loc", loc);
                updateItem.Properties.Add("Stat", "C");
                updateItem.Properties.Add("CutOffQty", qty);
                updateItem.Properties.Add("CountQty", qty);
                updateItem.Properties.Add("Lot", lot);
                updateItem.Properties.Add("ImportDocId", "");
                updateItem.Properties.Add("SerNum", SerNum);
                updateItem.Properties.Add("ItemLotTracked", GetIDOInputBoolValue(itemLotTracked));
                updateItem.Properties.Add("ItemSerialTracked", GetIDOInputBoolValue(itemSerialTracked));
            }
            updateRequestData.Items.Add(updateItem);

          
                UpdateCollectionResponseData updateResponseData = this.Context.Commands.UpdateCollection(updateRequestData);
                //Console.WriteLine(updateResponseData.ToXml());
                //Console.WriteLine(updateResponseData.ToString());
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
                errorMessage = constructErrorMessage(e.Message, null, null);
                // return errorMessage;
                return false;
            }


            string returnString = "<Response>";
            returnString += "<output>";
            returnString += "<row>";
            returnString += "<TRANSACTION_STATUS>0</TRANSACTION_STATUS>";
            returnString += "</row>";
            returnString += "</output>";
            returnString += "</Response>";
            //return returnString;
            return true;
        }


        private void GetCycleCountDetails()
        {
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLCycles";
            requestData.PropertyList.SetProperties("RowPointer, RecordDate, Whse,Loc,Item,ItemLotTracked,ItemSerialTracked,Lot,SerNum,Stat,CutOffQty,CountQty,RecordDate");
            string filterString = "Whse = '" + IDOStrFormat(whse) + "' and Item = '" + formatItem(item) + "' and Loc ='" + IDOStrFormat(loc) + "'";//MSF165152 added formating to handle special charcters JH:20130717
            if (!(lot.Trim().Equals("")))
            {
                filterString += " and Lot ='" + lot + "'";
            }

            if (!(SerNum.Trim().Equals("")))
            {
                filterString += " and SerNum ='" + SerNum + "'";
            }

            if (!(RowPointer.Trim().Equals("")) & RowPointer != null)
            {//we have the rowpointer it is more accurate for getting a record so use it rather than the other properties. MSF169356: Jh20131002
                filterString = "RowPointer = '" + RowPointer + "'";  //replace all of the other filter options with the rowpointer MSF169356: Jh20131002
                                                                     //Console.WriteLine("GetCycleCountDetails: RowPointer filter = " + filterString);
            }
            requestData.Filter = filterString;
            requestData.RecordCap = 0;
            requestData.OrderBy = "Whse,Loc,Item,Lot,SerNum";

            cycleResponseData = ExcuteQueryRequest(requestData);

            if (cycleResponseData != null && cycleResponseData.Items.Count == 0 && (!(SerNum.Trim().Equals(""))))
            {
                //Console.WriteLine("error executing the query for serial number with serial number trimmed");

                filterString = "Whse = '" + IDOStrFormat(whse) + "' and Item = '" + IDOStrFormat(item) + "' and Loc ='" + IDOStrFormat(loc) + "'";//MSF165152 added formating to handle special charcters JH:20130717
                if (!(lot.Trim().Equals("")))
                {
                    filterString += " and Lot ='" + lot + "'";
                }

                if (!(SerNum.Trim().Equals("")))
                {
                    filterString += " and SerNum ='" + SerNum.Trim() + "'";
                    SerNum = SerNum.Trim();
                }

                requestData.Filter = filterString;
                requestData.RecordCap = 0;
                requestData.OrderBy = "Whse,Loc,Item,Lot,SerNum";
                cycleResponseData = ExcuteQueryRequest(requestData);
            }

        }

        private bool checkItemWhseCombination()
        {
            object[] inputValues = new object[] { whse,
                                                  item,
                                                  GetIDOInputBoolValue(this.itemLotTracked),
                                                  GetIDOInputBoolValue(this.itemSerialTracked),
                                                   ""};

            InvokeResponseData responseData = InvokeIDO("SLPhyinvs", "PhyinvItemVSp", inputValues);
            if (!(responseData.ReturnValue.Equals("0")))
            {
                errorMessage = constructErrorMessage(responseData.Parameters.ElementAt(4).ToString(), "-1", null);
                return false;
            }

            object[] inputValuesBySheet = new object[] { whse,
                                                         item,
                                                         loc,
                                                         lot,
                                                         SerNum,
                                                         GetIDOInputBoolValue(itemLotTracked),
                                                         GetIDOInputBoolValue(itemSerialTracked),
                                                         "",
                                                         "",
                                                         "0",
                                                         "",
                                                         "",
                                                         "0"            //ToDo Tax Free Material
                                                         };

            InvokeResponseData responseDataSheet = InvokeIDO("SLPhyinvs", "PhyinvSheetVSp", inputValuesBySheet);
            if (!(responseDataSheet.ReturnValue.Equals("0")))
            {
                errorMessage = constructErrorMessage(responseDataSheet.Parameters.ElementAt(10).ToString(), "-2", null);
                return false;
            }

            return true;
        }

        private bool checkCycleCountRecordDetails()
        {
            if (RecordDate.Trim().Equals(GetPropertyValue(cycleResponseData, "RecordDate").Substring(0, 8)))
            {
                RecordDate = GetPropertyValue(cycleResponseData, "RecordDate");
            }

            if (!(RecordDate.Trim().Equals(GetPropertyValue(cycleResponseData, "RecordDate"))))
            {
                IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                substitutorDictionary.Add("RecordDate", RecordDate);
                substitutorDictionary.Add("sub1", GetPropertyValue(cycleResponseData, "RecordDate"));
                errorMessage = constructErrorMessage("Record Date : {RecordDate} Not matching {sub1}", "SLACYUP003", substitutorDictionary);
                return false;
            }

            if (!(RowPointer.Trim().Equals(GetPropertyValue(cycleResponseData, "RowPointer"))))
            {
                IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                substitutorDictionary.Add("RowPointer", RowPointer);
                substitutorDictionary.Add("sub1", GetPropertyValue(cycleResponseData, "RowPointer"));
                errorMessage = constructErrorMessage("RowPointer : {RowPointer} Not matching {sub1} ", "SLACYUP004", substitutorDictionary);
                return false;
            }

            if (!(item.Trim().ToUpper().Equals(GetPropertyValue(cycleResponseData, "Item").ToUpper().Trim())))
            {
                IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                substitutorDictionary.Add("item", item);
                substitutorDictionary.Add("sub1", GetPropertyValue(cycleResponseData, "Item"));
                errorMessage = constructErrorMessage("Item : {item} Not matching {sub1}", "SLACYUP005", substitutorDictionary);
                return false;
            }

            if (!(whse.Trim().ToUpper().Equals(GetPropertyValue(cycleResponseData, "Whse").ToUpper().Trim())))
            {
                IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                substitutorDictionary.Add("Whse", whse);
                substitutorDictionary.Add("sub1", GetPropertyValue(cycleResponseData, "Whse"));
                errorMessage = constructErrorMessage("Whse : {Whse} Not matching {sub1}", "SLACYUP006", substitutorDictionary);
                return false;
            }

            if (!(loc.Trim().ToUpper().Equals(GetPropertyValue(cycleResponseData, "Loc").ToUpper().Trim())))
            {
                IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                substitutorDictionary.Add("loc", loc);
                substitutorDictionary.Add("sub1", GetPropertyValue(cycleResponseData, "Loc"));
                errorMessage = constructErrorMessage("Loc :{loc} Not matching {sub1}", "SLACYUP009", substitutorDictionary);
                return false;
            }

            if (!(lot.Trim().ToUpper().Equals(GetPropertyValue(cycleResponseData, "Lot").ToUpper().Trim())))
            {
                IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                substitutorDictionary.Add("lot", lot);
                substitutorDictionary.Add("sub1", GetPropertyValue(cycleResponseData, "Lot"));
                errorMessage = constructErrorMessage("Lot : {lot} Not matching {sub1}", "SLACYUP010", substitutorDictionary);
                return false;
            }
            IDORuntime.LogUserMessage("Cycle.checkCycleCountRecordDetails-FT Sernum", UserDefinedMessageType.UserDefined1, SerNum);
            IDORuntime.LogUserMessage("Cycle.checkCycleCountRecordDetails- Syteline SerNum", UserDefinedMessageType.UserDefined1, GetPropertyValue(cycleResponseData, "SerNum"));
            if (SerNum != null && (SerNum.Trim().Length) != (GetPropertyValue(cycleResponseData, "SerNum").ToUpper().Trim().Length))
            {
                if (!(ExpandKey(SerNum.ToUpper().Trim(), GetPropertyValue(cycleResponseData, "SerNum").Trim().Length).Equals(GetPropertyValue(cycleResponseData, "SerNum").ToUpper().Trim())))
                {
                    IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                    substitutorDictionary.Add("SerNum", SerNum);
                    substitutorDictionary.Add("sub1 ", GetPropertyValue(cycleResponseData, "SerNum"));
                    errorMessage = constructErrorMessage("SerNum : {SerNum} Not matching {sub1}", "SLACYUP011", substitutorDictionary);
                    return false;
                }
                else
                    return true;
            }

            if (SerNum != null && (SerNum.Trim().Length) == (GetPropertyValue(cycleResponseData, "SerNum").ToUpper().Trim().Length))
            {
                if (!(SerNum.ToUpper().Trim().Equals(GetPropertyValue(cycleResponseData, "SerNum").ToUpper().Trim())))
                {
                    IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                    substitutorDictionary.Add("SerNum", SerNum);
                    substitutorDictionary.Add("sub1 ", GetPropertyValue(cycleResponseData, "SerNum"));
                    errorMessage = constructErrorMessage("SerNum : {SerNum} Not matching {sub1}", "SLACYUP011", substitutorDictionary);
                    return false;
                }
            }


            return true;
        }

        private bool performLotChecks()
        {
            object[] inputValues = new object[] { whse,
                                                  item,
                                                  loc,
                                                  lot,
                                                  "1",
                                                  "",
                                                  "",
                                                  "",
                                                  ""
                                                  };

            InvokeResponseData responseData = InvokeIDO("SLPhyinvs", "PhyinvLotV2Sp", inputValues);
            if (!(responseData.ReturnValue.Equals("0")))
            {
                errorMessage = constructErrorMessage(responseData.Parameters.ElementAt(5).ToString(), "-3", null);
                return false;
            }

            return true;
        }

        private bool performQtyFieldChecks()
        {
            object[] inputValues = new object[] { whse,
                                                  item,
                                                  loc,
                                                  lot,
                                                  "2",
                                                  "",
                                                  "",
                                                  "",
                                                  ""
                                                  };

            InvokeResponseData responseData = InvokeIDO("SLCycles", "PhyinvLotV2Sp", inputValues);
            if (!(responseData.ReturnValue.Equals("0")))
            {
                errorMessage = constructErrorMessage(responseData.Parameters.ElementAt(5).ToString(), "-4", null);
                return false;
            }
            return true;
        }

        #endregion
    }
}
