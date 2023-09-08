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
    class PhysicalInvTagUpdate : InventoryCountUtilities
    {
        #region Input Variables
        //Input Variables.
        private string tag = "";
        private string sheet = "";
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
        private bool isChecker = false;
        private bool addPermanentItemWhseLocLink = false;
        private bool addSerial = true;
        private bool addLot = true;
        private string SerialsSessionID = "";
        #endregion        
        #region Local Varialbles
        //Local Varialbles
        private bool itemLotTracked = false;
        private bool itemSerialTracked = false;
        private bool insertItemLocRecord = false;
        private LoadCollectionResponseData tagResponseData = null;
        private LoadCollectionResponseData sheetResponseData = null;
        private bool recordFound = false;
        private bool tagLogic = false;
        private bool performSerialCreation = false;
        private bool performLotCreation = false;
        private double countQty = 0;
        private List<string> SerialList = null;
        private string errorMessage = "";


        #endregion
        public PhysicalInvTagUpdate(string tag, string sheet, string item, string site, string whse,
                                    string loc, string lot, string uom, string qty, string user, string RowPointer,
                                     string RecordDate, string SerNum, bool addItemLocRecord, bool isChecker,
                                          bool addPermanentItemWhseLocLink, bool addSerial,
                                          bool addLot)
        {
            this.tag = tag;
            this.sheet = sheet;
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
            this.isChecker = isChecker;
            this.addPermanentItemWhseLocLink = addPermanentItemWhseLocLink;
            this.addSerial = addSerial;
            this.addLot = addLot;

        }

        public void initialize()
        {
            //Local variables initialization
            SerialList = null;
            itemLotTracked = false;
            itemSerialTracked = false;
            insertItemLocRecord = false;
            recordFound = false;
            tagLogic = false;
            sheetResponseData = null;
            tagResponseData = null;
            performSerialCreation = false;
            performLotCreation = false;
            countQty = 0;
            errorMessage = "";

        }


        public bool formatInputs()
        {
            if (sheet == null) { sheet = ""; } //Setting sheet = "" when it is blank

            if (tag == null || tag.Trim().Equals(""))
            {
                if (sheet == null || sheet.Trim().Equals(""))
                {
                    errorMessage = constructErrorMessage("Either Sheet or Tag input mandatory", "SLAPHIN010", null);
                    return false;
                }
            }


            if (qty == null || qty.Trim().Equals(""))
            {
                //errorMessage = "qty input mandatory";
                //return false;
                qty = "0";
            }
            try
            {
                if (Convert.ToDouble(qty, CultureInfo.InvariantCulture) < 0) // FTDEV-9247
                {
                    errorMessage = "Quantity should be greater than 0 or equal to 0";
                    return false;
                }
            }
            catch (InvalidCastException)
            {
                errorMessage = "Invalid Quantity Input";
                return false;
            }

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
            return true;
        }


        public bool validateInputs()
        {
            string itemUM = "";



            if (ValidateEmployee(user, out errorMessage) == false)
            {
                return false;
            }
            //Validate Tag
            if (tag != null && !(tag.Trim().Equals("")))
            {
                tagLogic = true;
                GetTagDetails();
                if (tagResponseData == null || tagResponseData.Items.Count == 0)
                {
                    if (!(RecordDate.Trim().Equals("")) || !(RowPointer.Trim().Equals("")))
                    {
                        errorMessage = constructErrorMessage("For New Tag Found, Record Data and Row Pointer should be blank", "SLAPHIN008", null);
                        return false;
                    }
                    recordFound = false;
                }
                else
                {
                    recordFound = true;
                    if (checkTagDetails(tagResponseData) == false)
                    {
                        return false;
                    }
                }
            }


            if (tagLogic == false)
            {
                //Sheet Logic
                GetSheetDetails();
                if (sheetResponseData == null || sheetResponseData.Items.Count == 0)
                {
                    if (!(RecordDate.Trim().Equals("")) || !(RowPointer.Trim().Equals("")))
                    {
                        errorMessage = constructErrorMessage("For New Sheet, Record Data and Row Pointer should be blank", "SLAPHIN009", null);
                        return false;
                    }
                    recordFound = false;
                }
                else
                {
                    recordFound = true;
                    if (checkTagDetails(sheetResponseData) == false)
                    {
                        return false;
                    }
                }

            }

            if (recordFound == false && !(sheet.Trim().Equals("")))
            {
                object[] inputs = new object[]{
                                          whse,
                                          sheet,
                                          "1",
                                          ""
                                          };
                InvokeResponseData invokeResponseData = InvokeIDO("SLPhyinvs", "ChgReplaceSheetSp", inputs);
                if (!(invokeResponseData.ReturnValue.Equals("0")))
                {
                    errorMessage = constructErrorMessage(invokeResponseData.Parameters.ElementAt(3).ToString(), "-1", null);
                    return false;
                }
            }


            //Validate Site
            LoadCollectionResponseData responseData = GetSiteDetails(site);
            if (responseData.PropertyList.Count == 0)
            {
                errorMessage = "Site Details Not Found";
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

            if (!(physicalInventoryFlag.Equals("1")))
            {
                IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                substitutorDictionary.Add("whse", whse);

                errorMessage = constructErrorMessage("Physical Inventory is not active for this Warehouse {whse}", "SLAPHIN002", substitutorDictionary);
                return false;
            }

            //Check Item Details
            responseData = GetItemDetails(formatItem(item));
            if (responseData.PropertyList.Count == 0)
            {
                errorMessage = "Item Details Not Found";
                return false;
            }
            itemLotTracked = GetBool(responseData[0, "LotTracked"].ToString());
            itemSerialTracked = GetBool(responseData[0, "SerialTracked"].ToString());
            itemUM = responseData[0, "UM"].ToString();

            //Check Item Warehouse Combination

            if (checkItemWhseCombination() == false)
            {
                return false;
            }


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
                    errorMessage = constructErrorMessage("{site} / {whse} / {item} / {loc} combination does not exists", "SLAPHIN030", substitutorDictionary);
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
                //CountQty check

                if (recordFound == true)
                {
                    if (lot.Trim().Equals(""))
                    {
                        if (countQty == 0 && Convert.ToDecimal(qty, CultureInfo.InvariantCulture) == 0) // FTDEV-9247
                        {
                        }
                        else
                        {
                            errorMessage = constructErrorMessage("Item Lot Tracked, Lot Input Mandatory", "SLAXXXX027", null);
                            return false;
                        }
                    }
                    else
                    {
                        if (performLotChecks() == false)
                        {
                            if (addLot == true)
                            {
                                errorMessage = "";
                                performLotCreation = true;
                            }
                            else
                            {
                                performLotCreation = false;
                                return false;
                            }
                        }
                    }
                }

                /*if (lot.Trim().Equals(""))
                {
                    errorMessage = constructErrorMessage("Item Lot Tracked, Lot Input Mandatory", "SLAXXXX027", null);
                    return false;
                }*/
                if (recordFound == false)
                {
                    if (lot.Trim().Equals(""))
                    {
                        errorMessage = constructErrorMessage("Item Lot Tracked, Lot Input Mandatory", "SLAXXXX027", null);
                        return false;
                    }

                    if (performLotChecks() == false)
                    {
                        if (addLot == true)
                        {
                            errorMessage = "";
                            performLotCreation = true;
                        }
                        else
                        {
                            performLotCreation = false;
                            return false;
                        }
                    }
                }
            }

            //Serial Checks
            if (itemSerialTracked == true)
            {
                if (recordFound == true)
                {
                    if (SerNum.Trim().Equals(""))
                    {
                        if (countQty == 0 && Convert.ToDecimal(qty, CultureInfo.InvariantCulture) == 0) // FTDEV-9247
                        {
                        }
                        else
                        {
                            errorMessage = constructErrorMessage("Item Lot Tracked, Lot Input Mandatory", "SLAXXXX027", null);
                            return false;
                        }
                    }
                    else
                    {
                        if (ValidateSerial() == true)
                        {
                            if (addSerial == true)
                            {
                                errorMessage = "";
                                performSerialCreation = true;
                            }
                            else
                            {
                                performSerialCreation = false;
                                return false;
                            }

                        }
                    }
                }

                if (recordFound == false)
                {
                    if (SerNum.Trim().Equals(""))
                    {
                        errorMessage = constructErrorMessage("Item Serial Tracked, Serial Input Mandatory", "SLAXXXX028", null);
                        return false;
                    }

                    if (ValidateSerial() == true)
                    {
                        if (addSerial == true)
                        {
                            errorMessage = "";
                            performSerialCreation = true;
                        }
                        else
                        {
                            performSerialCreation = false;
                            return false;
                        }

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

            if (itemSerialTracked == true)
            {
                if (localQty > 1)
                {
                    errorMessage = constructErrorMessage("Item Serial Tracked, Input Quantity cannot be greater than 0", "SLAXXXX030", null);
                    return false;
                }
            }

            return true;
        }

        public int PerformUpdate(out string infobar)
        {
            infobar = "";
            SerialList = this.GetSerialList(this.SerialsSessionID);
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

            if (performPhyInv() == false)
            {
                infobar = errorMessage;
                return 3;
            }
            return 0;
        }


        #region private methods


        private bool performPhyInv()
        {
            try
            {
                if (this.insertItemLocRecord == true)
            {
                if (addLocItemRecord(item, whse, site, loc, addPermanentItemWhseLocLink) == false)
                {
                    return false;
                }
            }

            if (performSerialCreation == true)
            {
                if (CreateSerial() == false)
                {
                    return false;
                }

            }

            if (performLotCreation == true)
            {
                if (CreateLot() == false)
                {
                    return false;
                }

                /*if (ValidateItemWhseLocLotSerial() == false)
                {
                    return this.errorMessage;
                }*/

            }

            if (recordFound == false)
            {
                if (ValidateItemWhseLocLotSerial() == false)
                {
                    return false;
                }
            }
            UpdateCollectionRequestData updateRequestData = new UpdateCollectionRequestData();
            updateRequestData.IDOName = "SLPhyinvs";
            updateRequestData.RefreshAfterUpdate = true;

            IDOUpdateItem updateItem = new IDOUpdateItem();
            if (recordFound)
            {
                updateItem.Action = UpdateAction.Update;
                updateItem.Properties.Add("RowPointer", RowPointer);
                updateItem.Properties.Add("RecordDate", RecordDate);
                updateItem.Properties.Add("CountQty", qty);
                updateItem.Properties.Add("PostStat", "U");
                updateItem.Properties.Add("CntStat", "U");
                updateItem.Properties.Add("Lot", lot);
                updateItem.Properties.Add("SerNum", SerNum);

                if (isChecker)
                {
                    updateItem.Properties.Add("EmpCheck", user);
                }
                else
                {
                    updateItem.Properties.Add("EmpCount", user);
                }
            }
            else
            {
                updateItem.Action = UpdateAction.Insert;
                updateItem.ItemID = "";
                updateItem.Properties.Add("RowPointer", "");
                updateItem.Properties.Add("TagXref", "0");
                if (tagLogic)
                {
                    updateItem.Properties.Add("TagNum", tag);
                    updateItem.Properties.Add("SheetNum", "");
                }
                else
                {
                    updateItem.Properties.Add("TagNum", "");
                    updateItem.Properties.Add("SheetNum", sheet);
                }
                updateItem.Properties.Add("Item", item);
                updateItem.Properties.Add("Loc", loc);
                updateItem.Properties.Add("CountQty", qty);
                updateItem.Properties.Add("EmpCount", user);
                updateItem.Properties.Add("EmpCheck", "");
                updateItem.Properties.Add("Lot", lot);
                updateItem.Properties.Add("ImportDocId", "");
                updateItem.Properties.Add("SerNum", SerNum);
                updateItem.Properties.Add("PostStat", "U");
                updateItem.Properties.Add("DerStatus", "");
                updateItem.Properties.Add("Approved", "0");
                updateItem.Properties.Add("CntStat", "U");
                updateItem.Properties.Add("DerTaxFreeMatl", "0");
                updateItem.Properties.Add("DerNewSheet", "");
                updateItem.Properties.Add("LotTracked", GetIDOInputBoolValue(itemLotTracked));
                updateItem.Properties.Add("SerialTracked", GetIDOInputBoolValue(itemSerialTracked));
                updateItem.Properties.Add("Whse", whse);
                updateItem.Properties.Add("DerLotEnable", "0");
                updateItem.Properties.Add("DerSerialEnable", "0");

                updateItem.Properties.Add("Type", "N");

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
                return false;
            }
            string returnString = "<Response>";
            returnString += "<output>";
            returnString += "<row>";
            returnString += "<TRANSACTION_STATUS>0</TRANSACTION_STATUS>";
            returnString += "</row>";
            returnString += "</output>";
            returnString += "</Response>";
            return true;

        }

        private bool ValidateSerial()
        {
            object[] inputValues = new object[] { whse,
                                                  item,
                                                  loc,
                                                  lot,
                                                  SerNum,
                                                  "1",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  ""
                                                  };

            InvokeResponseData responseData = InvokeIDO("SLPhyinvs", "PhyinvSerialV2Sp", inputValues);
            if (!(responseData.ReturnValue.Equals("0")))
            {
                errorMessage = constructErrorMessage(responseData.Parameters.ElementAt(6).ToString(), "-4", null);
                return false;
            }
            if (!(responseData.Parameters.ElementAt(7).ToString().Equals("")))
            {
                return false;
            }

            return true;

        }
        private bool CreateSerial()
        {
            object[] inputValues = new object[] { whse,
                                                  item,
                                                  loc,
                                                  lot,
                                                  SerNum,
                                                  "2",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  ""
                                                  };

            InvokeResponseData responseData = InvokeIDO("SLPhyinvs", "PhyinvSerialV2Sp", inputValues);
            if (!(responseData.ReturnValue.Equals("0")))
            {
                errorMessage = constructErrorMessage(responseData.Parameters.ElementAt(6).ToString(), "-5", null);
                return false;
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
                errorMessage = responseData.Parameters.ElementAt(5).ToString();
                return false;
            }

            if (!(responseData.Parameters.ElementAt(6).ToString().Equals("")))
            {
                errorMessage = responseData.Parameters.ElementAt(6).ToString();
                return false;
            }

            return true;
        }


        private void GetTagDetails()
        {
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLPhyinvs";
            requestData.PropertyList.SetProperties("Whse,Loc,Item,ItmDescription,Lot,SerNum,LotTracked, SerialTracked,Stat,Approved,TagNum, SheetNum, RowPointer, RecordDate, EmpCount, CountQty");
            string filterString = "TagNum = '" + tag + "' and Whse = '" + IDOStrFormat(whse) + "'";//MSF165152 added formating to handle special charcters JH:20130717

            requestData.Filter = filterString;
            requestData.RecordCap = 1;
            requestData.OrderBy = "TagNum";
            tagResponseData = ExcuteQueryRequest(requestData);
        }

        private void GetSheetDetails()
        {
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLPhyinvs";
            requestData.PropertyList.SetProperties("Whse,Loc,Item,ItmDescription,Lot,SerNum,LotTracked, SerialTracked,Stat,Approved,TagNum, SheetNum, RowPointer, RecordDate, EmpCount, CountQty");
            //string filterString = "SheetNum = '" + sheet + "' and Whse ='"+whse+"' and Loc='"+loc+"' and Lot = '"+lot+"' and SerNum ='"+SerNum+"'";

            string filterString = "SheetNum = '" + sheet + "' and Item = '" + IDOStrFormat(item) + "' and Whse ='" + IDOStrFormat(whse) + "' and Loc='" + IDOStrFormat(loc) + "'";//MSF165152 added formating to handle special charcters JH:20130717
            if (lot != null && !(lot.Trim().Equals("")))
            {
                filterString += " and Lot = '" + lot + "'";
            }

            if (SerNum != null && !(SerNum.Trim().Equals("")))
            {
                filterString += " and SerNum ='" + SerNum + "'";
            }

            requestData.Filter = filterString;
            requestData.RecordCap = 1;
            requestData.OrderBy = "SheetNum";

            this.sheetResponseData = this.ExcuteQueryRequest(requestData);

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
                errorMessage = constructErrorMessage(responseData.Parameters.ElementAt(4).ToString(), "-2", null);
                return false;
            }
            return true;
        }


        private bool checkTagDetails(LoadCollectionResponseData responseData)
        {
            if (!(RecordDate.Trim().Equals(GetPropertyValue(responseData, "RecordDate").Trim())))
            {
                //errorMessage = constructErrorMessage("Record Date :" + RecordDate + " Not matching with Tag :" + tag + " Record Date :" + GetPropertyValue(responseData, "RecordDate"));
                errorMessage = constructErrorMessage("Duplicate Data", "SLAXXXX031", null);
                return false;
            }

            if (!(RowPointer.Trim().Equals(GetPropertyValue(responseData, "RowPointer").Trim())))
            {
                //errorMessage = constructErrorMessage("RowPointer :" + RowPointer + " Not matching with Tag :" + tag + " RowPointer :" + GetPropertyValue(responseData, "RowPointer"));
                errorMessage = constructErrorMessage("Duplicate Data", "SLAXXXX031", null);
                return false;
            }

            if (!(item.Trim().ToUpper().Equals(GetPropertyValue(responseData, "Item").Trim().ToUpper())))
            {

                IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                substitutorDictionary.Add("item", item);
                substitutorDictionary.Add("tag", tag);
                substitutorDictionary.Add("sub1", GetPropertyValue(responseData, "Item"));
                errorMessage = constructErrorMessage("Item : {item} Not matching with Tag : {tag}  Item : {sub1}", "SLAPHIN004", substitutorDictionary);
                return false;
            }

            if (!(whse.Trim().Equals(GetPropertyValue(responseData, "Whse").Trim())))
            {
                IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                substitutorDictionary.Add("RowPointer", RowPointer);
                substitutorDictionary.Add("tag", tag);
                substitutorDictionary.Add("sub1", GetPropertyValue(responseData, "Whse"));
                errorMessage = constructErrorMessage("Whse : {RowPointer} Not matching with Tag : {tag} Whse {sub1}", "SLAPHIN005", substitutorDictionary);
                return false;
            }

            if (!(loc.Trim().Equals(GetPropertyValue(responseData, "Loc").Trim())))
            {
                IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                substitutorDictionary.Add("loc", loc);
                substitutorDictionary.Add("tag", tag);
                substitutorDictionary.Add("sub1", GetPropertyValue(responseData, "Loc"));
                errorMessage = constructErrorMessage("Loc : {loc} Not matching with Tag : {tag}  Loc : {sub1}", "SLAPHIN006", substitutorDictionary);
                return false;
            }

            /*if (!(lot.Trim().Equals(GetPropertyValue(responseData, "Lot").Trim())))
            {
                IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                substitutorDictionary.Add("lot", lot);
                substitutorDictionary.Add("tag", tag);
                substitutorDictionary.Add("sub1", GetPropertyValue(responseData, "Lot"));
                errorMessage = constructErrorMessage("Lot : {lot} Not matching with Tag : {tag} Lot : {sub1}", "SLAPHIN007", substitutorDictionary);
                return false;
            }

            if (!(SerNum.Trim().Equals(GetPropertyValue(responseData, "SerNum").Trim())))
            {
                IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                substitutorDictionary.Add("SerNum", SerNum);
                substitutorDictionary.Add("tag", tag);
                substitutorDictionary.Add("sub1", GetPropertyValue(responseData, "SerNum"));
                errorMessage = constructErrorMessage("SerNum : {SerNum} Not matching with Tag : {tag} SerNum : {sub1}", "SLAPHIN010", substitutorDictionary);
                return false;
            }*/

            if (isChecker == true)
            {
                string employeeCount = GetPropertyValue(responseData, "EmpCount");
                if (employeeCount == null || employeeCount.Trim().Equals(""))
                {
                    errorMessage = constructErrorMessage("Tag is not Employee Counted, so Checking is not allowed", "SLAXXXX032", null);
                    return false;
                }

            }

            if (GetPropertyValue(responseData, "CountQty").Trim().Equals(""))
            {
                countQty = 0;
            }
            else
            {
                countQty = Convert.ToDouble(GetPropertyValue(responseData, "CountQty"), CultureInfo.InvariantCulture); // FTDEV-9247
            }

            return true;
        }
        private bool ValidateItemWhseLocLotSerial()
        {
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
                errorMessage = constructErrorMessage(responseDataSheet.Parameters.ElementAt(10).ToString(), "-7", null);
                return false;
            }
            return true;
        }

        private bool CreateLot()
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

            InvokeResponseData responseData = InvokeIDO("SLPhyinvs", "PhyinvLotV2Sp", inputValues);
            if (!(responseData.ReturnValue.Equals("0")))
            {
                errorMessage = constructErrorMessage(responseData.Parameters.ElementAt(5).ToString(), "-6", null);
                return false;
            }

            return true;
        }


        #endregion
    }
}
