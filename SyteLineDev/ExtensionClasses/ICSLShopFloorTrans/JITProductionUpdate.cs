using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mongoose.Core.Configuration;
using Mongoose.IDO.Protocol;
using Mongoose.IDO;
using Mongoose.Core;
using System.Globalization;

namespace InforCollect.ERP.SL.ICSLShopFloorTrans
{
    class JITProductionUpdate : ShopFloorUtilities
    {
        #region InputVariables

        //Input Variables.
        private string qty = "";
        private string item = "";
        private string site = "";
        private string whse = "";
        private string loc = "";
        private string uom = "";
        private string lot = "";
        private string vendorLot = "";
        private string shift = "";
        private string employee = "";
        private bool generateSerials = false;
        private bool generateLot = false;

        private bool addItemLocRecord = true;
        private bool allowIfCycleCountExists = false;
        private bool addPermanentItemWhseLocLink = false;
        private string SessionID = "";
        private string containerNum = "";
        private string docNum = "";

        #endregion

        #region LocalVariables

        //Local Varialbles

        private bool itemLotTracked = false;
        private bool itemSerialTracked = false;
        private bool insertItemLocRecord = false;
        private double qtyOnHand = 0;
        private string GUID = "";
        private string itemSerialPrefix = "";
        private string postNegative = "";
        private List<string> SerialList = null;
        private string errorMessage = "";
        private bool createContainerNum = false;
        private bool containerLocMismatch = false;

        #endregion

        #region Flow Methods

        public JITProductionUpdate(string qty, string item, string site, string whse, string loc,
                                    string uom, string lot, string vendorLot, string shift, string employee,
                                    bool generateSerials, bool generateLot,
                                    bool addItemLocRecord, bool allowIfCycleCountExists,
                                    bool addPermanentItemWhseLocLink, string SessionID, string containerNum, string docNum)
        {
            initialize();
            this.qty = qty;
            this.item = item;
            this.site = site;
            this.whse = whse;
            this.loc = loc;
            this.uom = uom;
            this.lot = lot;
            //this.lot = formatDataByIDOAndPropertyName("SLLotLocs", "Lot", lot);
            this.vendorLot = vendorLot;
            this.shift = shift;
            this.employee = employee;
            this.generateSerials = generateSerials;
            this.generateLot = generateLot;
            this.allowIfCycleCountExists = allowIfCycleCountExists;
            this.addPermanentItemWhseLocLink = addPermanentItemWhseLocLink;
            this.SessionID = SessionID;
            this.containerNum = containerNum;
            this.docNum = docNum;
        }

        public void initialize()
        {
            //Input variables initialization
            this.qty = "";
            this.item = "";
            this.site = "";
            this.whse = "";
            this.loc = "";
            this.uom = "";
            this.lot = "";
            this.vendorLot = "";
            this.shift = "";
            this.employee = "";
            this.generateSerials = false;
            this.generateLot = false;
            this.allowIfCycleCountExists = false;
            this.addPermanentItemWhseLocLink = false;
            //this.SessionID = "";
            this.addItemLocRecord = true;
            this.addPermanentItemWhseLocLink = false;
            this.allowIfCycleCountExists = false;

            //Local variables initialization
            this.itemLotTracked = false;
            this.itemSerialTracked = false;
            this.insertItemLocRecord = false;
            this.qtyOnHand = 0;
            this.GUID = "";
            this.itemSerialPrefix = "";
            this.docNum = "";
        }

        public bool formatInputs()
        {
            if (!((containerNum == null) || containerNum.Trim().Equals("")))
            {
                containerNum = formatDataByIDOAndPropertyName("SLContainers", "ContainerNum", containerNum);

            }
            // qty = updateRequest.GetFieldValue("qty");
            if (qty == null || qty.Trim().Equals(""))
            {
                errorMessage = "qty input mandatory";
                return false;
            }
            try
            {
                if (Convert.ToDouble(qty, CultureInfo.InvariantCulture) == 0) // FTDEV-9247
                {
                    errorMessage = "Quantity should be other than 0";
                    return false;
                }
            }
            catch (InvalidCastException)
            {
                errorMessage = "Invalid Quantity Input";
                return false;
            }

            // item = updateRequest.GetFieldValue("item");
            item = formatDataByIDOAndPropertyName("SLRsvdInvs", "Item", item);
            if (item == null || item.Trim().Equals(""))
            {
                errorMessage = "item input mandatory";
                return false;
            }

            //site = updateRequest.GetFieldValue("site");
            if (site == null || site.Trim().Equals(""))
            {
                errorMessage = "site input mandatory";
                return false;
            }

            // whse = updateRequest.GetFieldValue("whse");
            whse = formatDataByIDOAndPropertyName("SLRsvdInvs", "Whse", whse);
            if (whse == null || whse.Trim().Equals(""))
            {
                errorMessage = "whse input mandatory";
                return false;
            }

            //loc = updateRequest.GetFieldValue("loc");
            loc = formatDataByIDOAndPropertyName("SLRsvdInvs", "Loc", loc);
            if (loc == null || loc.Trim().Equals(""))
            {
                errorMessage = "loc input mandatory";
                return false;
            }

            // uom = updateRequest.GetFieldValue("uom");
            if (uom == null || uom.Trim().Equals(""))
            {
                errorMessage = "uom input mandatory";
                return false;
            }

            lot = formatDataByIDOAndPropertyName("SLLotLocs", "Lot", lot);
            vendorLot = formatDataByIDOAndPropertyName("SLLotLocs", "Lot", vendorLot);

            shift = formatDataByIDOAndPropertyName("SLShifts", "Shift", shift);


            employee = formatDataByIDOAndPropertyName("SLEmployees", "EmpNum", employee);


            if (this.itemSerialTracked == true && generateSerials == false)
            {
                if (SerialList != null)
                {
                    if (SerialList.Count == 0)
                    {
                        errorMessage = "Item is Serial Tracked, Serial Inputs Mandatory.";
                        return false;
                    }
                }
                else
                {
                    errorMessage = "Item is Serial Tracked, Serial Inputs Mandatory.";
                    return false;
                }

            }
            return true;
        }
        public bool validateInputs()
        {
            //GUID

            if (GenerateGUID(ref GUID, out errorMessage) == false)
            {
                errorMessage = "Problem generating GUID";
                return false;
            }

            string itemUM = "";
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
                errorMessage = "Whse Details Not Found";
                return false;
            }

            string physicalInventoryFlag = GetPropertyValue(responseData.PropertyList, responseData.Items, "PhyInvFlg");
            if (physicalInventoryFlag == null)
            {
                errorMessage = "Error Reading WhseAll record";
                return false;
            }

            if (!(physicalInventoryFlag.Equals("0")))
            {
                IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                substitutorDictionary.Add("{whse}", whse);
                //errorMessage = "Physical Inventory is active in Warehouse : {whse}, Adjustment not allowed";
                errorMessage = constructErrorMessage("Physical Inventory is active in Warehouse : {whse}, Adjustment not allowed", "SLJITXXXXX01", substitutorDictionary);
                return false;
            }

            //Check Item Details
            responseData = GetItemDetails(formatItem(item));
            if (responseData.PropertyList.Count == 0)
            {
                errorMessage = "Item Details Not Found";
                return false;
            }

            itemLotTracked = GetBool(GetPropertyValue(responseData.PropertyList, responseData.Items, "LotTracked"));
            itemSerialTracked = GetBool(GetPropertyValue(responseData.PropertyList, responseData.Items, "SerialTracked"));
            itemUM = GetPropertyValue(responseData.PropertyList, responseData.Items, "UM");

            if (ValidateItem() == false)
            {
                return false;
            }

            if (validWhseItemRecordExists(whse, item, allowIfCycleCountExists, out errorMessage) == false)
            {
                return false;
            }


            //Need to add check for Obsolte and Slow moving items.

            //Check Location
            responseData = GetLocationDetails(loc);
            qtyOnHand = 0;
            GetItemLocRecord(site, whse, item, loc, ref qtyOnHand);

            if (checkLocationDetails(item, whse, site, loc, out errorMessage) == false)
            {
                if (addItemLocRecord == false)
                {
                    IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                    substitutorDictionary.Add("site", site);
                    substitutorDictionary.Add("whse", whse);
                    substitutorDictionary.Add("item", item);
                    substitutorDictionary.Add("loc", loc);
                    //errorMessage = "{site} / {whse} / {item} / {loc} combination does not exists, Transfer not allowed";
                    errorMessage = constructErrorMessage("{site} / {whse} / {item} / {loc} combination does not exists, Transfer not allowed", "SLJITXXXXX02", substitutorDictionary);

                    return false;
                }
                else
                {
                    insertItemLocRecord = true;
                }
            }

            if (ValidateLoc() == false)
            {
                return false;
            }

            //UOM Checks
            string convertedQty = GetItemConvertedQtyToBaseUnit(item, qty, uom, "", out errorMessage);
            if (convertedQty == null)
            {
                return false;
            }
            qty = convertedQty;
            uom = itemUM;

            //Lot Code Checks

            if (itemLotTracked == true)
            {
                if (lot == null || lot.Trim().Equals(""))
                {
                    errorMessage = "Item is lot controlled, Lot Input is Mandatory";
                    return false;
                }
            }

            //Qty Checks

            if (ValidateQty() == false)
            {
                return false;
            }

            //Validate Shift
            if (this.shift != null && !(this.shift.Trim().Equals("")))    //  Shift is not a madatory.
            {
                LoadCollectionResponseData shiftResponseData = GetShiftDetails(shift);
                if (shiftResponseData.Items.Count == 0)
                {
                    errorMessage = "Shift Details Not Found";
                    return false;
                }
            }


            //Validate Employee
            if (this.employee != null && !(this.employee.Trim().Equals("")))
            {
                LoadCollectionResponseData employeeResponseData = GetEmployeeDetails(employee);
                if (employeeResponseData.Items.Count == 0)
                {
                    errorMessage = "Employee Details Not Found";
                    return false;
                }
            }


            //Container Field
            if (this.containerNum != null && !(this.containerNum.Trim().Equals("")))
            {


                if (ValidateQtyForRcvIntoContainerSp(this.item, this.whse, this.loc, this.lot, this.site, out errorMessage) == false)
                {
                    return false;
                }


                if (ValidateContainerExist(this.containerNum, this.whse, this.loc, containerLocMismatch, out errorMessage) == true)
                {
                    createContainerNum = false;
                    if (containerLocMismatch)
                    {
                        errorMessage = " Container Location missmatch ";
                        return false;
                    }
                }
                else
                {
                    createContainerNum = true;
                }

            }
            return true;
        }

        public int PerformUpdate(out string InfoBar)
        {
            InfoBar = "";

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
            //4 Perform Updates

            if (performJIT() == false)
            {
                InfoBar = errorMessage;
                return 3;

            }
            return 0;

        }

        private bool performJIT()
        {
            try {
                if (GetItemSerialPrefixSp() == false)
                {
                    errorMessage = "Error in SerialPrefix";
                    return false;
                }

                //1 Date Check
                object[] dateCheckValues = new object[] { //System.DateTime.Now.ToShortDateString(), 
                                                      System.DateTime.Now.ToString(WMShortDatePattern), //MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128
                                                      "Transaction Date",
                                                      "@%update",
                                                      "",
                                                      "",
                                                      "" };

                InvokeResponseData invokeResponseDataStep1 = this.Context.Commands.Invoke("SLPeriods", "DateChkSp", dateCheckValues);
                if (!(invokeResponseDataStep1.ReturnValue.Equals("0")))
                {
                    errorMessage = invokeResponseDataStep1.Parameters.ElementAt(3).ToString();
                    return false;
                }

                //2 Location Check
                if (this.insertItemLocRecord == true)
                {
                    if (addLocItemRecord(item, whse, site, loc, addPermanentItemWhseLocLink, out errorMessage) == false)
                    {
                        return false;
                    }
                }

                //3 Lot Check
                if (PerformLotSteps() == false)
                {
                    return false;
                }
                //3.1 Perfrom container creation
                if (this.createContainerNum == true)
                {
                    PerformCreateContainer(containerNum, whse, loc, out errorMessage);
                }
                //4 Delete Temporary Serials

                if (DeleteTmpSerSp() == false)
                {
                    return false;
                }

                //5 Save Serials

                if (SaveSerials() == false)
                {
                    return false;
                }

                if (DeleteTmpSerSp() == false)
                {
                    return false;
                }

                //6 Perform JIT

                if (JustInTimeTransactionSp() == false)
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
            return true;
        }

        #endregion

        #region private methods



        private bool ValidateQty()
        {
            object[] inputValues = new object[]{
                                                qty,
                                                item,
                                                "1",
                                                "0",
                                                ""};

            InvokeResponseData invokeResponseData = InvokeIDO("SLPs", "PsQtyValidSp", inputValues);
            if (!invokeResponseData.ReturnValue.Equals("0"))
            {
                errorMessage = invokeResponseData.Parameters.ElementAt(4).ToString();
                return false;
            }

            //Delete the current Inventory
            object[] deleteInvValues = new object[] { site,
                                                      "G",
                                                      "R",
                                                      whse,
                                                      item,
                                                      loc,
                                                      lot,
                                                      qty,
                                                      0,
                                                      "rcv",
                                                      "",
                                                      0,
                                                      0,
                                                      0,
                                                      "",
                                                      0,
                                                      "",
                                                      "",
                                                      "",
                                                      "",
                                                      "",
                                                      ""};

            InvokeResponseData invokeResponseDataStep2 = this.Context.Commands.Invoke("SLItemLocs", "ItemQtyDetlSp", deleteInvValues);
            if (!(invokeResponseDataStep2.ReturnValue.Equals("0")))
            {
                errorMessage = invokeResponseDataStep2.Parameters.ElementAt(19).ToString();
                return false;
            }

            return true;
        }

        private bool PerformLotSteps()
        {
            if (this.itemLotTracked)
            {
                object[] inputValues = new object[] { item,
                                                      lot,
                                                      "",
                                                      "",
                                                      "",
                                                      "",
                                                      "",
                                                      "",
                                                      ""
                                                      };

                InvokeResponseData responseData = InvokeIDO("SLLots", "RvallotSp", inputValues);
                if (!(responseData.ReturnValue.Equals("0")))
                {
                    errorMessage = responseData.Parameters.ElementAt(5).ToString();
                    return false;
                }


                if (responseData.Parameters.ElementAt(2).ToString().Equals("1"))
                {
                    if (generateLot == false)
                    {
                        errorMessage = responseData.Parameters.ElementAt(3).ToString();
                        return false;
                    }

                    inputValues = new object[] { item,
                                                 lot,
                                                 qty,
                                                 "0",
                                                 vendorLot,
                                                 "0",
                                                 "",
                                                 "",
                                                 site,
                                                 "",
                                                 "",
                                                 ""
                                                 };

                    responseData = InvokeIDO("SLLots", "LotAddSp", inputValues);
                    if (!(responseData.ReturnValue.Equals("0")))
                    {
                        errorMessage = responseData.Parameters.ElementAt(6).ToString();
                        return false;
                    }
                }

                inputValues = new object[] { whse,
                                             item,
                                             lot,
                                             ""
                                            };

                responseData = InvokeIDO("SLLots", "LotValidSp", inputValues);
                if (!(responseData.ReturnValue.Equals("0")))
                {
                    errorMessage = responseData.Parameters.ElementAt(3).ToString();
                    return false;
                }
            }
            return true;
        }

        private bool ValidateItem()
        {
            object[] inputParams = new object[]{
                                                item,
                                                whse,
                                                "",
                                                GetIDOInputBoolValue(itemSerialTracked),
                                                GetIDOInputBoolValue(itemLotTracked),
                                                loc,
                                                lot,
                                                uom,
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                ""
                                               };
            InvokeResponseData responseData = InvokeIDO("SLPs", "PsItemValidSp", inputParams);
            if (!responseData.ReturnValue.Equals("0"))
            {
                errorMessage = responseData.Parameters.ElementAt(12).ToString();
                return false;
            }
            return true;
        }

        private bool ValidateLoc()
        {
            object[] inputParams = new object[]{
                                                site,
                                                whse,
                                                item,
                                                loc,
                                                "",
                                                "",
                                                ""
                                               };
            InvokeResponseData responseData = InvokeIDO("SLTrnacts", "RvallocSp", inputParams);
            if (!responseData.ReturnValue.Equals("0"))
            {
                errorMessage = responseData.Parameters.ElementAt(6).ToString();
                return false;
            }
            return true;
        }

        private bool DeleteTmpSerSp()
        {
            object[] inputParams = new object[]{
                                                GUID
                                               };
            InvokeResponseData responseData = InvokeIDO("SLSerials", "DeleteTmpSerSp", inputParams);
            if (!responseData.ReturnValue.Equals("0"))
            {
                IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                substitutorDictionary.Add("{GUID}", GUID);
                //errorMessage = "Failed to Delete Temporary Serials for GUID : {GUID}";
                errorMessage = constructErrorMessage("Failed to Delete Temporary Serials for GUID : {GUID}", "SLJITXXXXX03", substitutorDictionary);
                return false;
            }
            return true;
        }

        private bool SaveSerials()
        {
            //Serials

            UpdateCollectionRequestData updateRequestData = new UpdateCollectionRequestData();
            updateRequestData.IDOName = "SLSerials";
            updateRequestData.RefreshAfterUpdate = true;
            updateRequestData.CustomInsert = "SerialSaveSp(SerNum,'" + GUID + "',,MESSAGE,NULL,NULL,NULL)";
            updateRequestData.CustomUpdate = "SerialSaveSp(SerNum,'" + GUID + "',,MESSAGE,NULL,NULL,NULL)";


            if (SerialList != null)
            {
                for (int i = 0; i < SerialList.Count(); i++)
                {
                    IDOUpdateItem serialItem = new IDOUpdateItem();
                    serialItem.Action = UpdateAction.Update;
                    serialItem.ItemNumber = i;
                    serialItem.Properties.Add("SerNum", formatDataByIDOAndPropertyName("SLMSSerials", "SerNum", SerialList.ElementAt(i).ToString()));
                    serialItem.Properties.Add("UbSelect", "1");
                    updateRequestData.Items.Add(serialItem);

                }
            }


            try
            {
                UpdateCollectionResponseData updateResponseData = this.Context.Commands.UpdateCollection(updateRequestData);
                MessageLogging("JITProductionUpdate: " + updateResponseData.ToXml(), msgLevel.l1_information, 1200002);
                //Console.WriteLine(updateResponseData.ToXml());
            }
            catch (Exception e)
            {
                MessageLogging("JITProductionUpdate: " + e.Message, msgLevel.l4_error, 1200004);
                errorMessage = e.Message;
                return false;
            }
            return true;
        }

        private bool JustInTimeTransactionSp()
        {
            object[] inputParams = new object[]{
                                                item,
                                                qty,
                                                whse,
                                                loc,
                                                lot,
                                                System.DateTime.Now.ToString(WMShortDatePattern ), //MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128
                                                shift,
                                                employee,
                                                postNegative,
                                                itemSerialPrefix,
                                                this.SessionID,
                                                "",
                                                containerNum,
                                                docNum
                                               };
            InvokeResponseData responseData = InvokeIDO("SLJobTrans", "JustInTimeTransactionSp", inputParams);
            if (!responseData.ReturnValue.Equals("0"))
            {
                errorMessage = responseData.Parameters.ElementAt(11).ToString();
                return false;
            }
            errorMessage = responseData.Parameters.ElementAt(11).ToString();

            // Post pending trans for issue# 206933
            object[] inputParamsPendingTrans = new object[]{
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                System.DateTime.Now.ToString(WMShortDatePattern ),
                                                System.DateTime.Now.ToString(WMShortDatePattern ),
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "K",
                                                this.SessionID,
                                                ""
                                               };
            InvokeResponseData responseDataPendingTrans = InvokeIDO("SLJobtMats", "PostAllJobtMatVB", inputParamsPendingTrans);
            errorMessage = errorMessage + responseDataPendingTrans.Parameters.ElementAt(16).ToString();
            return true;
        }

        private bool GetItemSerialPrefixSp()
        {
            object[] inputParams = new object[]{
                                                item,
                                                site,
                                                "",
                                                ""
                                                };
            InvokeResponseData responseData = InvokeIDO("SLTrnActs", "GetItemSerialPrefixSp", inputParams);

            if (!responseData.ReturnValue.Equals("0"))
            {
                errorMessage = responseData.Parameters.ElementAt(3).ToString();
                return false;
            }
            itemSerialPrefix = responseData.Parameters.ElementAt(2).ToString();
            return true;
        }

        #endregion


    }
}