using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mongoose.Core.Configuration;
using Mongoose.IDO.Protocol;
using Mongoose.IDO;
using Mongoose.Core;
using System.Data;
using System.Globalization;

namespace InforCollect.ERP.SL.ICSLOutBoundTrans
{
    class ManageCustomerOrderReservationsUpdate : AReservationsUtilities
    {
        //Input Variables.
        public string order = "";
        public string line = "";
        public string release = "";
        public string qty = "";
        public string item = "";
        public string site = "";
        public string whse = "";
        public string loc = "";
        public string lot = "";
        public string uom = "";
        public string stageLocation = "";
        public string operationType = "";
        private bool addItemLocRecord = true;
        private bool allowIfCycleCountExists = false;
        private bool addPermanentItemWhseLocLink = false;
        private string SessionID = "";
        private string userInitial = "";
        private string docNum = "";
        //format - <serials><serial>xxx</serial><serial>xxys</serial></serials>
        //Local Variables
        private List<string> SerialList = null;

        //Local Varialbles
        private string errorMessage = "";
        public bool itemLotTracked = false;
        public bool itemSerialTracked = false;
        public bool insertItemLocRecord = false;
        public LoadCollectionResponseData ordLineResponseData = null;
        public LoadCollectionResponseData orderResponseData = null;
        public InvokeResponseData invokeOrdLineResponseData = null;
        string rsvdNum = "";
        string qtyRsvd = "0";
        LoadCollectionResponseData rsvdSerialsResponseData = null;


        public ManageCustomerOrderReservationsUpdate(String iorder, String iline, String irelease, String iqty,
                                                     String iitem, String isite, String iwhse, String iloc, String ilot,
                                                     String iuom, string istageLocation, String ioperationType,
                                            bool iaddItemLocRecord, bool iallowIfCycleCountExists,
                                            bool iaddPermanentItemWhseLocLink, string iSessionID, string docNum, string userInitial)
        {

            this.order = iorder;
            this.line = iline;
            this.release = irelease;
            this.qty = iqty;
            this.item = iitem;
            this.site = isite;
            this.whse = iwhse;
            this.loc = iloc;
            this.lot = ilot;
            this.uom = iuom;
            this.stageLocation = istageLocation;
            this.operationType = ioperationType;
            this.addItemLocRecord = iaddItemLocRecord;
            this.allowIfCycleCountExists = iallowIfCycleCountExists;
            this.addPermanentItemWhseLocLink = iaddPermanentItemWhseLocLink;
            this.SessionID = iSessionID;
            this.userInitial = userInitial;
            this.docNum = docNum;
            //Local variables initialization

        }

        public void initialize()
        {
            //Input variables initialization
            order = "";
            line = "";
            release = "";
            site = "";
            whse = "";
            item = "";

            qty = "";
            loc = "";
            lot = "";
            uom = "";
            stageLocation = "";
            operationType = "N";
            addItemLocRecord = true;
            allowIfCycleCountExists = false;
            addPermanentItemWhseLocLink = false;
            SessionID = "";
            userInitial = "";
            docNum = "";
            //Local variables initialization
            itemLotTracked = false;
            itemSerialTracked = false;
            insertItemLocRecord = false;
            ordLineResponseData = null;
            orderResponseData = null;
            rsvdSerialsResponseData = null;


        }


        public bool formatInputs()
        {
            if (IsStringContainsNumericValue(order))
                order = formatDataByIDOAndPropertyName("SLCoitems", "CoNum", order);
            if (order == null || order.Trim().Equals(""))
            {
                errorMessage = constructErrorMessage("order input mandatory", "SLAXXXX003", null);
                return false;
            }

            line = formatDataByIDOAndPropertyName("SLCoitems", "CoLine", line);
            if (line == null || line.Trim().Equals(""))
            {
                errorMessage = constructErrorMessage("line input mandatory", "SLAXXXX004", null);
                return false;
            }

            release = formatDataByIDOAndPropertyName("SLCoitems", "CoRelease", release);


            if (qty == null || qty.Trim().Equals(""))
            {
                errorMessage = constructErrorMessage("qty input mandatory", "SLAXXXX005", null);
                return false;
            }

            item = formatDataByIDOAndPropertyName("SLRsvdInvs", "Item", item);
            if (item == null || item.Trim().Equals(""))
            {
                errorMessage = constructErrorMessage("item input mandatory", "SLAXXXX006", null);
                return false;
            }



            if (site == null || site.Trim().Equals(""))
            {
                errorMessage = constructErrorMessage("Site input mandatory", "SLAMNCO005", null);
                return false;
            }

            whse = formatDataByIDOAndPropertyName("SLRsvdInvs", "Whse", whse);
            if (whse == null || whse.Trim().Equals(""))
            {
                errorMessage = constructErrorMessage("Whse input mandatory", "SLAXXXX024", null);
                return false;
            }

            loc = formatDataByIDOAndPropertyName("SLRsvdInvs", "Loc", loc);
            if (loc == null || loc.Trim().Equals(""))
            {
                errorMessage = constructErrorMessage("Loc input mandatory", "SLAMNCO007", null);
                return false;
            }

            lot = formatDataByIDOAndPropertyName("SLLotLocs", "Lot", lot);


            if (uom == null || uom.Trim().Equals(""))
            {
                errorMessage = constructErrorMessage("uom input mandatory", "SLAXXXX012", null);
                return false;
            }

            stageLocation = formatDataByIDOAndPropertyName("SLRsvdInvs", "Loc", stageLocation);
            // operationType = updateRequest.GetFieldValue("operationType");

            if (!(operationType.Equals("N") || operationType.Equals("U") || operationType.Equals("D")))
            {
                errorMessage = constructErrorMessage("Invalid Operation Type, Operation Type should be one of N - NEW /U - Update/D - Delete", "SLAMNCO009", null);
                return false;
            }

            return true;
        }

        public bool validateInputs()
        {
            //Order Validation

            orderResponseData = ValidateCustomerOrder(order);
            if (orderResponseData.Items.Count == 0)
            {
                errorMessage = constructErrorMessage("Order Details Not Found", "SLAXXXX001", null);
                return false;
            }

            //line field exit

            ordLineResponseData = GetCustomerOrderLines(order, line, release, site, null, true);
            if (ordLineResponseData.Items.Count == 0)
            {
                errorMessage = constructErrorMessage("Order/Line Details Not Found", "SLAMNCO011", null);
                return false;
            }

            if (GetPropertyValue(ordLineResponseData, "ItReservable").Equals("0"))
            {
                IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                substitutorDictionary.Add("item", item);
                errorMessage = constructErrorMessage("Item : {item} is not Reservable, Transaction Not Allowed", "SLAMNCO001", substitutorDictionary);
                return false;
            }


            if (ValidateOrderLine() == false)
            {
                return false;
            }

            //Validate Inputs

            if (VerifyInputs() == false)
            {
                return false;
            }

            //Validate From Site
            LoadCollectionResponseData responseData = GetSiteDetails(site);
            if (responseData.PropertyList.Count == 0)
            {
                errorMessage = constructErrorMessage("Site Details Not Found", "SLAXXXX025", null);
                return false;
            }

            //Check From Warehouse
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
                errorMessage = constructErrorMessage("Physical Inventory is active in Warehouse : {whse} , Transaction not allowed", "SLAMNCO002", substitutorDictionary);
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

            if (validWhseItemRecordExists(whse, item, allowIfCycleCountExists, out errorMessage) == false)
            {
                return false;
            }

            //Check Location
            responseData = GetLocationDetails(loc);
            if (checkLocationDetails(item, whse, site, loc, out errorMessage) == false)
            {
                IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                substitutorDictionary.Add("site", site);
                substitutorDictionary.Add("whse", whse);
                substitutorDictionary.Add("item", item);
                substitutorDictionary.Add("loc", loc);
                errorMessage = constructErrorMessage("{site} / {whse} / {item} / {loc} combination does not exists, Reservations not allowed", "SLAMNCO003", substitutorDictionary);
                return false;
            }

            //Check Stage Location
            responseData = GetLocationDetails(stageLocation);

            if (checkLocationDetails(item, whse, site, loc, out errorMessage) == false)
            {
                if (addItemLocRecord)
                {
                    insertItemLocRecord = true;
                    errorMessage = "";
                }
                else
                {
                    return false;
                }
            }

            //Check Lot
            if (checkLot(item, lot, itemLotTracked, out errorMessage) == false)
            {
                return false;
            }


            return true;
        }
        public int PerformUpdate(out string InfoBar)
        {
            InfoBar = "";
            if (UpdateUserInitial(this.userInitial, out errorMessage) == false)
            {
                InfoBar = errorMessage;
                return 1;
            }
            if (SessionID != null && !(SessionID.Equals("")))
            {
                SerialList = this.GetSerialList(this.SessionID);
            }



            //2 Format Inputs
            if (formatInputs() == false)
            {
                InfoBar = errorMessage;
                return 1;
            }
            //3 validate Inputs
            if (validateInputs() == false)
            {
                InfoBar = errorMessage;
                return 2;
            }
            //Validate Serials

            if (ValidateSerials() == false)
            {
                InfoBar = errorMessage;
                return 21;
            }


            //4 Perform Updates
            if (PerformReservations() == false)
            {
                InfoBar = errorMessage;
                return 3;
            }

            InfoBar = formatResponse(errorMessage);
            return 0;

        }

        private bool PerformReservations()
        {
            //1 Perform Transfer Of Material to Stage Location
            string saveLoc = loc;
            string saveStageLoc = stageLocation;
            string pickLoc = loc;
            string actualPickQty = qty;
            if (PerformTransfer(false) == false)
            {
                //infobar =  errorMessage;
                return false;
            }

            loc = stageLocation;

            if (PerformStaging() == false)
            {
                loc = saveLoc;
                string stageError = errorMessage;
                errorMessage = "";
                if (PerformTransfer(true) == false)
                {
                    //return errorMessage;
                    return false;
                }
                //return stageError;
                errorMessage = stageError;
                return false;
            }
            if (SerialList == null)
            {
                CheckForPickLocationReservations(pickLoc, actualPickQty);
            }
            return true;
        }
        private bool CheckForPickLocationReservations(string pickLoc, string actualPickQty)
        {
            string pickLocqty = "";
            string pickLocRsvdNum = "";
            string pickLocQtyRsvd = "";
            try
            {
                LoadCollectionResponseData reservationResponseData = GetReservations(order,
                                                                                     line,
                                                                                     release,
                                                                                     whse,
                                                                                     pickLoc,
                                                                                     lot);


                if (reservationResponseData.Items.Count > 0)
                {
                    pickLocRsvdNum = GetPropertyValue(reservationResponseData, "RsvdNum");
                    pickLocQtyRsvd = GetPropertyValue(reservationResponseData, "QtyRsvd");
                    pickLocqty = (Convert.ToDecimal(pickLocQtyRsvd, CultureInfo.InvariantCulture) - Convert.ToDecimal(actualPickQty, CultureInfo.InvariantCulture)).ToString(); // FTDEV-9247
                }
                else
                {
                    return false;
                }
                if (pickLocqty.Equals(""))
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

            if (!(pickLocRsvdNum.Equals("")))
            {
                operationType = "U";

                object[] inputValues = new object[] {
                                                  operationType,
                                                  pickLocRsvdNum,
                                                  item,
                                                  whse,
                                                  order,
                                                  line,
                                                  release,
                                                  GetPropertyValue(ordLineResponseData,"CustNum"),
                                                  pickLoc,
                                                  lot,
                                                  pickLocqty,
                                                  uom,
                                                  SessionID,
                                                  "",
                                                  ""};

                InvokeResponseData invokeResponseData = InvokeIDO("SLRsvdInvs", "ResforOrderUpdateSp", inputValues);
                if (!(invokeResponseData.ReturnValue.Equals("0")))
                {
                    errorMessage = constructErrorMessage(invokeResponseData.Parameters.ElementAt(13).ToString(), "-6", null);
                    return false;
                }
            }

            return true;
        }


        private bool PerformStaging()
        {
            //Validate Qty


            if (ValidateQty() == false)
            {
                return false;
            }

            //1 ValidateCoReservationsSp

            if (ValidateCoReservation(rsvdNum) == false)
            {
                return false;
            }

            //2 ValidateCoRsvdQtySp

            if (ValidateCoRsvdQty(qtyRsvd) == false)
            {
                return false;
            }

            //3 Create Session ID-- not needed in collect

            //4 SerialSaveSp

            if (PerformSaveSerials(SessionID, rsvdSerialsResponseData, rsvdNum) == false)
            {
                return false;
            }

            //5 ResforOrderUpdateSp
            if (ResforOrderUpdate(SessionID, rsvdNum) == false)
            {
                return false;
            }
            return true;

        }

        private bool ValidateSerials()
        {
            if (SerialList != null)
            {
                for (int i = 0; i < SerialList.Count; i++)
                {
                    string serial = formatDataByIDOAndPropertyName("SLMSSerials", "SerNum", SerialList.ElementAt(i));
                    LoadCollectionResponseData responseData = GetSerialInfo(whse, item, loc, serial, lot);
                    if (responseData.Items.Count == 0)
                    {
                        IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                        substitutorDictionary.Add("{serial}", SerialList.ElementAt(i));
                        errorMessage = constructErrorMessage("Serial Number : {serial} is not valid", "SLAMNCO004", substitutorDictionary);
                        return false;
                    }
                }
            }

            return true;
        }

        private bool ValidateQty()
        {

            //0 check if there are any existing Reservations
            LoadCollectionResponseData reservationResponseData = GetReservations(order,
                                                                                 line,
                                                                                 release,
                                                                                 whse,
                                                                                 stageLocation,
                                                                                 lot);


            if (reservationResponseData.Items.Count > 0)
            {
                rsvdNum = GetPropertyValue(reservationResponseData, "RsvdNum");
                qtyRsvd = GetPropertyValue(reservationResponseData, "QtyRsvd");
                rsvdSerialsResponseData = GetReservationSerials(rsvdNum);
                qty = (Convert.ToDouble(qty, CultureInfo.InvariantCulture) + Convert.ToDouble(qtyRsvd, CultureInfo.InvariantCulture)).ToString(); // FTDEV-9247
            }

            object[] inputValues = new object[] {
                                                  item,
                                                  qty,
                                                  qtyRsvd,
                                                  uom,
                                                  order,
                                                  GetIDOInputBoolValue(itemLotTracked),
                                                  whse,
                                                  lot,
                                                  loc,
                                                  "",
                                                  "",
                                                  "0"                             //ToDo - need to see what need to be done for this.
                                                  };

            invokeOrdLineResponseData = InvokeIDO("SLRsvdInvs", "CoResValidateQtySp", inputValues);


            if (!(invokeOrdLineResponseData.ReturnValue.Equals("0")))
            {
                errorMessage = constructErrorMessage(invokeOrdLineResponseData.Parameters.ElementAt(9).ToString(), "-1", null);
                return false;
            }
            return true;
        }

        private bool VerifyInputs()
        {
            if (!(GetPropertyValue(ordLineResponseData, "Whse").Trim().Equals(whse.Trim())))
            {
                IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                substitutorDictionary.Add("sub1", GetPropertyValue(ordLineResponseData, "Whse"));
                substitutorDictionary.Add("whse", whse);
                errorMessage = constructErrorMessage("Whse not matching Order/Line {sub1} {whse} ", "SLAMNCO006", substitutorDictionary);
                return false;
            }

            if (!(GetPropertyValue(ordLineResponseData, "Item").Trim().Equals(item.Trim())))
            {
                IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                substitutorDictionary.Add("sub1", GetPropertyValue(ordLineResponseData, "Item"));
                errorMessage = constructErrorMessage("Item not matching Order/Line {sub1} ", "SLAMNCO008", substitutorDictionary);
                return false;
            }
            return true;
        }

        private bool ValidateOrderLine()
        {
            object[] inputValues = new object[] { order,
                                                  line,
                                                  release,
                                                  GetPropertyValue(ordLineResponseData,"CustNum"),
                                                  "",
                                                  item,
                                                  "",
                                                  "O",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  ""};

            invokeOrdLineResponseData = InvokeIDO("SLRsvdInvs", "GetCoItemDetailSp", inputValues);


            if (!(invokeOrdLineResponseData.ReturnValue.Equals("0")))
            {
                errorMessage = constructErrorMessage(invokeOrdLineResponseData.Parameters.ElementAt(17).ToString(), "-2", null);
                return false;
            }
            return true;

        }

        private bool ValidateCoReservation(string rsvdNum)
        {
            object[] inputValues = new object[] { rsvdNum,
                                                  order,
                                                  line,
                                                  release,
                                                  item,
                                                  whse,
                                                  loc,
                                                  GetIDOInputBoolValue(itemLotTracked),
                                                  lot,
                                                  qty,
                                                  uom,
                                                  GetPropertyValue(ordLineResponseData,"CustNum"),
                                                  "",
                                                  "",
                                                  "0"};

            InvokeResponseData invokeResponseData = InvokeIDO("SLRsvdInvs", "ValidateCoReservationSp", inputValues);


            if (!(invokeResponseData.ReturnValue.Equals("0")))
            {
                errorMessage = constructErrorMessage(invokeResponseData.Parameters.ElementAt(12).ToString(), "-3", null);
                return false;
            }
            return true;
        }

        private bool ValidateCoRsvdQty(string qtyRsvd)
        {
            object[] inputValues = new object[] { order,
                                                  line,
                                                  release,
                                                  qty,
                                                  qtyRsvd,
                                                  "",
                                                  "",
                                                  ""};

            InvokeResponseData invokeResponseData = InvokeIDO("SLRsvdInvs", "ValidateCoRsvdQtySp", inputValues);


            if (!(invokeResponseData.ReturnValue.Equals("0")))
            {
                errorMessage = constructErrorMessage(invokeResponseData.Parameters.ElementAt(7).ToString(), "-4", null);
                return false;
            }
            return true;
        }



        private bool PerformSaveSerials(string SessionID, LoadCollectionResponseData SerialResponseData, string rsvdNum)
        {

            if (SerialList != null)
            {
                for (int i = 0; i < SerialList.Count; i++)
                {
                    if (rsvdNum != null && !(rsvdNum.Trim().Equals("")))
                    {
                        if (UpdateSerials((i + 1), SerialList.ElementAt(i).ToString(), rsvdNum) == false)
                        {
                            return false;
                        }
                    }

                    if (SaveSerial(SessionID, SerialList.ElementAt(i).ToString()) == false)
                    {
                        return false;
                    }
                }
            }


            if (SerialResponseData != null)
            {
                foreach (IDOItem idoItem in SerialResponseData.Items)
                {
                    IDOPropertyValueList listOfProperties = idoItem.PropertyValues;
                    if (listOfProperties.Count > 0)
                    {
                        if (SaveSerial(SessionID, listOfProperties[0].Value) == false)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        private bool SaveSerial(string SessionID, string Serial)
        {
            Serial = formatDataByIDOAndPropertyName("SLMSSerials", "SerNum", Serial);
            object[] inputValues = new object[] { Serial,
                                                  SessionID,
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  ""};

            InvokeResponseData invokeResponseData = InvokeIDO("SLSerials", "SerialSaveSp", inputValues);
            if (!(invokeResponseData.ReturnValue.Equals("0")))
            {
                errorMessage = constructErrorMessage(invokeResponseData.Parameters.ElementAt(3).ToString(), "-5", null);
                return false;
            }
            return true;
        }

        private bool ResforOrderUpdate(string SessionID, string rsvdNum)
        {
            if (!(rsvdNum.Equals("")))
            {
                operationType = "U";
            }

            object[] inputValues = new object[] {
                                                  operationType,
                                                  rsvdNum,
                                                  item,
                                                  whse,
                                                  order,
                                                  line,
                                                  release,
                                                  GetPropertyValue(ordLineResponseData,"CustNum"),
                                                  loc,
                                                  lot,
                                                  qty,
                                                  uom,
                                                  SessionID,
                                                  "",
                                                  "" };

            InvokeResponseData invokeResponseData = InvokeIDO("SLRsvdInvs", "ResforOrderUpdateSp", inputValues);
            if (!(invokeResponseData.ReturnValue.Equals("0")))
            {
                errorMessage = constructErrorMessage(invokeResponseData.Parameters.ElementAt(13).ToString(), "-6", null);
                return false;
            }
            return true;
        }

        private bool PerformTransfer(bool ReverseTransfer)
        {
            object[] inputValues = null;
            if (ReverseTransfer == true)
            {
                inputValues = new object[] {
                                                  qty,
                                                  item,
                                                  site,
                                                  whse,
                                                  stageLocation,  // Transfer back from Staging area
                                                  lot,
                                                  whse,
                                                  loc,
                                                  lot,
                                                  site,
                                                  uom,
                                                  addItemLocRecord,
                                                  allowIfCycleCountExists,
                                                  addPermanentItemWhseLocLink,
                                                  SessionID,
                                                  "" ,
                                                  ""  ,                       // Container Number
                                                  userInitial,                          // User Initial
                                                  docNum
                                                    };

            }
            else
            {
                inputValues = new object[] {
                                                  qty,
                                                  item,
                                                  site,
                                                  whse,
                                                  loc,
                                                  lot,
                                                  whse,
                                                  stageLocation,
                                                  lot,
                                                  site,
                                                  uom,
                                                  addItemLocRecord,
                                                  allowIfCycleCountExists,
                                                  addPermanentItemWhseLocLink,
                                                  SessionID,
                                                  "" ,
                                                  ""  ,                       // Container Number
                                                  userInitial,                          // User Initial
                                                  docNum
                                                    };
            }
            InvokeResponseData invokeResponseData = InvokeIDO("ICSLInventoryTrans", "TransferUpdate", inputValues);
            if (!(invokeResponseData.ReturnValue.Equals("0")))
            {
                errorMessage = constructErrorMessage(invokeResponseData.Parameters.ElementAt(15).ToString(), "-6", null);
                return false;
            }
            errorMessage = invokeResponseData.Parameters.ElementAt(15).ToString();


            return true;
        }

        private bool UpdateSerials(int ItemNo, string Serial, string rsvdNum)
        {
            Serial = formatDataByIDOAndPropertyName("SLMSSerials", "SerNum", Serial);
            LoadCollectionResponseData responseData = GetSerialInfoBySerialTable(whse, item, loc, Serial, lot);
            if (responseData.Items.Count == 0)
            {
                IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                substitutorDictionary.Add("Serial", Serial);
                errorMessage = constructErrorMessage("Serial Number :{Serial} is not valid ", "SLAMNCO010", substitutorDictionary);
                return false;
            }

            UpdateCollectionRequestData updateRequestData = new UpdateCollectionRequestData();
            updateRequestData.IDOName = "SLSerials";
            updateRequestData.RefreshAfterUpdate = true;

            IDOUpdateItem serialItem = new IDOUpdateItem();
            serialItem.Action = UpdateAction.Update;
            serialItem.ItemNumber = ItemNo;
            serialItem.ItemID = responseData.Items[0].ItemID;
            //serialItem.ItemID = "PBT=[serial] ser.ID=[" + GetPropertyValue(responseData, "RowPointer") + "] ser.DT=[" + GetPropertyValue(responseData, "RecordDate") + "]";
            serialItem.Properties.Add("SerNum", Serial, false);
            serialItem.Properties.Add("InWorkflow", GetPropertyValue(responseData, "InWorkflow"), false);
            serialItem.Properties.Add("Item", item, false);
            serialItem.Properties.Add("Loc", loc, false);
            serialItem.Properties.Add("Lot", lot, false);
            serialItem.Properties.Add("NoteExistsFlag", GetPropertyValue(responseData, "NoteExistsFlag"), false);
            serialItem.Properties.Add("RowPointer", GetPropertyValue(responseData, "RowPointer"), false);
            serialItem.Properties.Add("Whse", whse, false);
            serialItem.Properties.Add("UbSelect", "1");
            serialItem.Properties.Add("Stat", "R");
            serialItem.Properties.Add("RefRelease", GetPropertyValue(responseData, "RefRelease"), false);
            serialItem.Properties.Add("RefNum", GetPropertyValue(responseData, "RefNum"), false);
            serialItem.Properties.Add("RefLine", GetPropertyValue(responseData, "RefLine"), false);
            serialItem.Properties.Add("RsvdNum", rsvdNum);
            updateRequestData.Items.Add(serialItem);

            try
            {
                UpdateCollectionResponseData updateResponseData = this.Context.Commands.UpdateCollection(updateRequestData);
                //Console.WriteLine(updateResponseData.ToXml());
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.StackTrace);
                errorMessage = constructErrorMessage(e.Message, null, null);
                MessageLogging("ManageCustomerOrderRes.UpdateSerials: " + errorMessage, msgLevel.l4_error, 1200002);
                return false;
            }
            return true;

        }



    }
}