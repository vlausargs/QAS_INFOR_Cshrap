using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mongoose.Core.Configuration;
using Mongoose.IDO.Protocol;
using Mongoose.IDO;
using Mongoose.Core;
using System.Globalization;

namespace InforCollect.ERP.SL.ICSLInventoryTrans
{
    class MiscellaneousReceiptUpdate : InventoryUtilities
    {
        //Input Variables.
        private string qty = "";
        private string item = "";
        private string site = "";
        private string whse = "";
        private string loc = "";
        private string uom = "";
        private string reasonCode = "";
        private string lot = "";

        private bool addItemLocRecord = true;
        private bool allowIfCycleCountExists = false;
        private bool addPermanentItemWhseLocLink = false;
        private bool allowIfSlowMoving = true;
        private string documentNumber = "";
        private string SerialsSessionID = "";
        private string ImportDocID = "";
        private string containerNum = "";
        private string userInitial = "";
        private string LotMfgDate = "";
        private string LotExpDate = "";
        private string LotTrxRestrictCode = "";
        private string SerialMfgDate = "";
        private string SerialExpDate = "";
        private string SerialTrxRestrictCode = "";


        //Local Variables

        private List<string> SerialList = null;
        private bool itemLotTracked = false;
        private bool itemSerialTracked = false;
        private bool insertItemLocRecord = false;
        private InvokeResponseData reasonCodeResData = null;
        private InvokeResponseData whseItemCostResData = null;
        private double qtyOnHand = 0;
        private bool createNewLot = false;
        private bool createContainerNum = false;
        bool containerLocMismatch = false;

        private decimal materialCost = 0;
        private decimal laborCost = 0;
        private decimal fovhdCost = 0;
        private decimal vovhdCost = 0;
        private decimal outCost = 0;
        private decimal unitCost = 0;
        private string errorMessage = "";

        public MiscellaneousReceiptUpdate(string qty, string item, string site, string whse, string loc,
                                          string uom, string reasonCode, string lot,
                                          bool addItemLocRecord, bool allowIfCycleCountExists,
                                          bool addPermanentItemWhseLocLink, bool allowIfSlowMoving,
                                          string documentNumber,
                                          string SerialsSessionID, string ImportDocID,
                                          string containerNum, string userInitial, string LotMfgDate, string LotExpDate, string LotTrxRestrictCode,
                                          string SerialMfgDate, string SerialExpDate, string SerialTrxRestrictCode)
        {
            this.qty = qty;
            this.item = item;
            this.site = site;
            this.whse = whse;
            this.loc = loc;
            this.uom = uom;
            this.reasonCode = reasonCode;
            this.lot = lot;
            this.addItemLocRecord = addItemLocRecord;
            this.allowIfCycleCountExists = allowIfCycleCountExists;
            this.addPermanentItemWhseLocLink = addPermanentItemWhseLocLink;
            this.allowIfSlowMoving = allowIfSlowMoving;
            this.documentNumber = documentNumber;
            this.SerialsSessionID = SerialsSessionID;
            this.ImportDocID = ImportDocID;
            this.containerNum = containerNum;
            this.userInitial = userInitial;
            this.LotMfgDate = LotMfgDate;
            this.LotExpDate = LotExpDate;
            this.LotTrxRestrictCode = LotTrxRestrictCode;
            this.SerialMfgDate = SerialMfgDate;
            this.SerialExpDate = SerialExpDate;
            this.SerialTrxRestrictCode = SerialTrxRestrictCode;

        }

        public void initialize()
        {
            //Local variables initialization
            SerialList = null;
            itemLotTracked = false;
            itemSerialTracked = false;
            insertItemLocRecord = false;
            whseItemCostResData = null;
            reasonCodeResData = null;
            qtyOnHand = 0;
            createNewLot = false;
            createContainerNum = false;
            userInitial = "";
            LotMfgDate = "";
            LotExpDate = "";
            LotTrxRestrictCode = "";
            SerialMfgDate = "";
            SerialExpDate = "";
            SerialTrxRestrictCode = "";


            materialCost = 0;
            laborCost = 0;
            fovhdCost = 0;
            vovhdCost = 0;
            outCost = 0;
            unitCost = 0;
            errorMessage = "";

        }


        public bool formatInputs()
        {
            if (qty == null || qty.Trim().Equals(""))
            {
                errorMessage = "qty input mandatory";
                return false;
            }
            try
            {
                if (Convert.ToDouble(qty, CultureInfo.InvariantCulture) <= 0) // FTDEV-9247
                {
                    errorMessage = "Quantity should be greater than 0";
                    return false;
                }
            }
            catch (InvalidCastException)
            {
                errorMessage = "Invalid Quantity Input";
                return false;
            }

            if (item == null || item.Trim().Equals(""))
            {
                errorMessage = "item input mandatory";
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

            if (reasonCode == null || reasonCode.Trim().Equals(""))
            {
                errorMessage = "reasonCode input mandatory";
                return false;
            }

            lot = formatDataByIDOAndPropertyName("SLLotLocs", "Lot", lot);
            if (!((containerNum == null) || containerNum.Trim().Equals("")))
            {
                containerNum = formatDataByIDOAndPropertyName("SLContainers", "ContainerNum", containerNum);

            }
            if (documentNumber == null)
            {
                documentNumber = "";
            }

            if (ImportDocID == null)
            {
                ImportDocID = "";
            }

            /* if (ParamTrack_tax_free_imports == false && !(ImportDocID.Trim().Equals("")))
             {
                 errorMessage = "ImportDocID input not allowed as Inventory Parameter track_tax_free_imports is not turned on";
                 return false;
             }

             if (ParamTrack_tax_free_imports == true && ContainerNum != null && !(ContainerNum.Equals("")))
             {
                 errorMessage = "Container Number Input is not allowed if Track Tax Free Import is true";
                 return false;
             } */
            return true;
        }


        public bool validateInputs()
        {
            string itemUM = "";


            //Validate Site
            LoadCollectionResponseData responseData = GetSiteDetails(site);
            if (responseData.PropertyList.Count == 0)
            {
                errorMessage = "Site Details Not Found";
                return false;
            }

            //Check Warehouse
            if (GetWhseDetailsBySite(whse, site, out responseData, out errorMessage) == false)
            {
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
            // TrackPieces = GetBool(responseData[0, "TrackPieces"].ToString());
            itemUM = responseData[0, "UM"].ToString();

            if (validWhseItemRecordExists(whse, item, allowIfCycleCountExists, out errorMessage) == false)
            {
                return false;
            }

            if (getWhseItemCosts() == false)
            {
                return false;
            }

            materialCost = GetDecimalValue((whseItemCostResData.Parameters.ElementAt(2).ToString() == "") ? "0" : whseItemCostResData.Parameters.ElementAt(2).ToString());
            laborCost = GetDecimalValue((whseItemCostResData.Parameters.ElementAt(3).ToString() == "") ? "0" : whseItemCostResData.Parameters.ElementAt(3).ToString());
            fovhdCost = GetDecimalValue((whseItemCostResData.Parameters.ElementAt(4).ToString() == "") ? "0" : whseItemCostResData.Parameters.ElementAt(4).ToString());
            vovhdCost = GetDecimalValue((whseItemCostResData.Parameters.ElementAt(5).ToString() == "") ? "0" : whseItemCostResData.Parameters.ElementAt(5).ToString());
            outCost = GetDecimalValue((whseItemCostResData.Parameters.ElementAt(6).ToString() == "") ? "0" : whseItemCostResData.Parameters.ElementAt(6).ToString());
            unitCost = GetDecimalValue((whseItemCostResData.Parameters.ElementAt(7).ToString() == "") ? "0" : whseItemCostResData.Parameters.ElementAt(7).ToString());

            //Check for Obsolte and Slow moving items.

            if (ObsSlowSp(item, this.allowIfSlowMoving, out errorMessage) == false)
            {
                return false;
            }

            //Qty Checks
            try
            {

                if (Convert.ToDouble(qty, CultureInfo.InvariantCulture) <= 0) // FTDEV-9247
                {
                    errorMessage = "Qty should be greater than 0";
                    return false;
                }
            }
            catch (Exception)
            {
                errorMessage = "Qty should be a Whole Number";
                return false;
            }


            //Check Location
            responseData = GetLocationDetails(loc);
            qtyOnHand = 0;
            GetItemLocRecord(site, whse, item, loc, ref qtyOnHand);

            if (checkLocationDetails(item, whse, site, loc, out errorMessage) == false)
            {
                if (addItemLocRecord == false)
                {
                    errorMessage = site + " / " + whse + " / " + item + " / " + loc + " combination does not exists, Transfer not allowed";
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
            uom = itemUM;

            //Reason Code Checks

            if (checkAdjReasonCodes() == false)
            {
                return false;
            }

            //Lot Code Checks

            if (itemLotTracked)
            {
                if (string.IsNullOrEmpty(lot))
                {
                    errorMessage = "Item is lot controlled, Lot Input is Mandatory";
                    return false;
                }
                if (!(string.IsNullOrEmpty(LotMfgDate)) && !(string.IsNullOrEmpty(LotExpDate)))
                {
                    if (DateTime.TryParse(LotMfgDate, out DateTime lotMfgdt) && DateTime.TryParse(LotExpDate, out DateTime lotExpdt))
                    {
                        if (DateTime.Compare(lotMfgdt, lotExpdt) > 0)
                        {
                            errorMessage = "Lot Expiration date Must be greater than its Manufacturing date";
                            return false;
                        }
                    }
                }
            }
            if (itemSerialTracked && !(string.IsNullOrEmpty(LotMfgDate)) && !(string.IsNullOrEmpty(LotExpDate)))
            {
                if (DateTime.TryParse(SerialMfgDate, out DateTime serMfgdt) && DateTime.TryParse(SerialExpDate, out DateTime serExpdt))
                {
                    if (DateTime.Compare(serMfgdt, serExpdt) > 0)
                    {
                        errorMessage = "Serial Expiration date Must be greater than its Manufacturing date";
                        return false;
                    }
                }
            }

            if (checkIfItemLotExists() == false)
            {
                createNewLot = true;
            }

            if (ImportDocID != null && !(ImportDocID.Trim().Equals("")))
            {
                if (ValidateImportID(ImportDocID, out errorMessage) == false)
                {
                    return false;
                }
            }

            //Container Field
            if (this.containerNum != null && !(this.containerNum.Trim().Equals("")))
            {
                if (ValidateQtyForRcvIntoContainerSp() == false)
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
                /*
                if (RValContainerSp() == false)
                {
                    return false;
                }
                else
                {
                    if (this.createContainerNum == false)
                    {
                        if (ValidateContainer(this.ContainerNum, this.whse, this.loc, out errorMessage) == false)
                        {
                            return false;
                        }
                    }
                }*/
            }

            return true;
        }

        public int PerformUpdate(out string infobar)
        {
            infobar = "";
            if (UpdateUserInitial(this.userInitial, out errorMessage) == false)
            {
                infobar = errorMessage;
                return 1;
            }
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

            if (PerformAdjustment() == false)
            {
                infobar = errorMessage;
                return 3;
            }
            return 0;
        }


        #region private methods


        private bool PerformAdjustment()
        {
            try
            {
                //1 Date Check
                if (createNewLot == true)
                {
                    //(string item,string lot,string qty,string poNum ,string vendorLot,string nonUnique,string site,out string errormessage )
                    //performAddLot(item, lot, "0", "0", "", "1", site, out errorMessage);
                    performAddLotwithTransRestrict();
                }
                object[] dateCheckValues = new object[] { System.DateTime.Now, // FTDEV-9247 - Date-conversion for bounced method System.DateTime.Now.ToString(WMShortDatePattern), // FTDEV-9247 - Date-conversion for bounced method //MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128
                                                      "Transaction Date",
                                                      "@%update",
                                                      "",
                                                      "",
                                                      "" };

                InvokeResponseData invokeResponseDataStep1 = this.InvokeIDO("SLPeriods", "DateChkSp", dateCheckValues);
                if (!(invokeResponseDataStep1.ReturnValue.Equals("0")))
                {
                    errorMessage = invokeResponseDataStep1.Parameters.ElementAt(3).ToString();
                    return false;
                }

                if (this.insertItemLocRecord == true)
                {
                    if (addLocItemRecord(item, whse, site, loc, addPermanentItemWhseLocLink, out errorMessage) == false)
                    {
                        return false;
                    }
                }

                if (this.createContainerNum == true)
                {

                    PerformCreateContainer(containerNum, whse, loc, out errorMessage);
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

                InvokeResponseData invokeResponseDataStep2 = InvokeIDO("SLItemLocs", "ItemQtyDetlSp", deleteInvValues);
                if (!(invokeResponseDataStep2.ReturnValue.Equals("0")))
                {
                    errorMessage = invokeResponseDataStep2.Parameters.ElementAt(19).ToString();
                    return false;
                }

                //Save Field values
                if (storeUpdateValues("S") == false)
                {
                    return false;
                }

                //Serials Process

                //SLMSSerials.SetMethodSp - To store the values
                object[] serialsSetMethodInputs = new object[] { "SLStockActItems.ItemMiscReceiptSp" };

                InvokeResponseData serialsSetMethodResponseData = this.InvokeIDO("SLSerials", "SetMethodSP", serialsSetMethodInputs);
                if (!(serialsSetMethodResponseData.ReturnValue.Equals("0")))
                {
                    errorMessage = "Process Failed";
                    return false;
                }

                //Serials

                UpdateCollectionRequestData updateRequestData = new UpdateCollectionRequestData();
                updateRequestData.IDOName = "SLSerials";
                updateRequestData.RefreshAfterUpdate = true;
                updateRequestData.CustomInsert = "SerialSaveSp(SerNum,NULL,NULL,MESSAGE,ManufacturedDate,ExpDate,TrxRestrictCode)";
                updateRequestData.CustomUpdate = "SerialSaveSp(SerNum,NULL,NULL,MESSAGE,ManufacturedDate,ExpDate,TrxRestrictCode)";

                if (SerialList != null && SerialList.Count != 0)
                {
                    for (int i = 0; i < SerialList.Count; i++)
                    {
                        IDOUpdateItem serialItem = new IDOUpdateItem();
                        serialItem.Action = UpdateAction.Update;
                        serialItem.ItemNumber = i;
                        serialItem.Properties.Add("SerNum", formatDataByIDOAndPropertyName("SLMSSerials", "SerNum", SerialList.ElementAt(i)), false);
                        serialItem.Properties.Add("UbSelect", "1");
                        serialItem.Properties.Add("ManufacturedDate", SerialMfgDate);
                        serialItem.Properties.Add("ExpDate", SerialExpDate);
                        serialItem.Properties.Add("TrxRestrictCode", SerialTrxRestrictCode);
                        updateRequestData.Items.Add(serialItem);
                    }
                }

                UpdateCollectionResponseData updateResponseData = this.Context.Commands.UpdateCollection(updateRequestData);
                //Console.WriteLine(updateResponseData.ToXml());

                //Update Field values
                if (storeUpdateValues("U") == false)
                {
                    return false;
                }

            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return false;
            }
            finally
            {
                // Clear Serials 
                ClearSerailsBySessionID(this.SerialsSessionID);
            }
            return true;
        }

        public bool performAddLotwithTransRestrict()
        {
            string LotRevision = "";
            LoadCollectionResponseData itemResponseData = this.Context.Commands.LoadCollection(new LoadCollectionRequestData("SLItems", "Revision", string.Format("Item = '{0}'", item), null, 1));
            if (itemResponseData != null && itemResponseData.Items != null && itemResponseData.Items.Count > 0)
            {
                LotRevision = itemResponseData[0, "Revision"].GetValue(string.Empty);                
            }
            string errormessage = "";
            object[] inputValues;
            inputValues = new object[] { item,
                                                  lot,
                                                  "0",
                                                  "0",
                                                  "",
                                                  "1",
                                                  LotRevision,
                                                  "",
                                                  site,
                                                  LotMfgDate,
                                                  LotExpDate,
                                                  LotTrxRestrictCode};

            InvokeResponseData responseDataStep = this.InvokeIDO("SLLots", "LotAddSp", inputValues);
            if (!(responseDataStep.ReturnValue.Equals("0")))
            {
                errormessage = responseDataStep.Parameters.ElementAt(6).ToString();
                return false;
            }
            return true;
        }

        private bool checkAdjReasonCodes()
        {
            LoadCollectionResponseData reasonValidateResponseData = GetReasonCodeDetails(reasonCode, "MISC RCPT");
            if (reasonValidateResponseData.Items.Count == 0)
            {
                errorMessage = "Reason Code : " + reasonCode + " Not Found";
                return false;
            }
            object[] reasonCodeValues; //added for SL9 Qualification.  JH:20130708
            int paramcount = 0; //added for SL9 Qualification.  JH:20130708
            paramcount = GetIDOMethodParameterCount("SLReasons", "ReasonGetInvAdjAcctSp");
            switch (paramcount)
            {
                case 16: //added for SL9 Qualification.  JH:20130708
                    reasonCodeValues = new object[] { reasonCode,
                                                      "MISC RCPT",
                                                      item,
                                                      "",
                                                      "",
                                                      "",
                                                      "",
                                                      "",
                                                      "",
                                                      "", //10

                                                      "",
                                                      "",
                                                      "",
                                                      "",
                                                      "",
                                                      ""
                                                        };
                    break;
                case 14:
                default: //the default case is 14 
                    reasonCodeValues = new object[] { reasonCode,
                                                      "MISC RCPT",
                                                      item,
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
                    break;
            }

            reasonCodeResData = this.InvokeIDO("SLReasons", "ReasonGetInvAdjAcctSp", reasonCodeValues);
            if (!(reasonCodeResData.ReturnValue.Equals("0")))
            {
                errorMessage = reasonCodeResData.Parameters.ElementAt(13).ToString();
                return false;
            }
            return true;
        }

        private bool checkIfItemLotExists()
        {
            object[] inputValues = new object[] { whse,
                                                  item,
                                                  loc,
                                                  lot,
                                                  "rcv",
                                                  "0",
                                                  "Miscellaneous Receipt",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "" };

            InvokeResponseData responseDataStep = this.InvokeIDO("SLTrnacts", "SvallotSp", inputValues);
            if (!(responseDataStep.ReturnValue.Equals("0")))
            {
                return false;
            }

            if (responseDataStep.Parameters.ElementAt(7) != null && !(responseDataStep.Parameters.ElementAt(7).ToString().Trim().Equals("")))
            {
                return false;
            }
            return true;
        }

        /* public bool performAddLot()
         {
             object[] inputValues = new object[] { item, 
                                                   lot, 
                                                   0, 
                                                   0, 
                                                   "",
                                                   "1",
                                                   "",
                                                   site};

             InvokeResponseData responseDataStep = this.InvokeIDO("SLLots", "LotAddSp", inputValues);
             if (!(responseDataStep.ReturnValue.Equals("0")))
             {
                 return false;
             }
             return true;
         } */

        private bool storeUpdateValues(string type)
        {
            //IaPostSetVarsSp - S(Save) process / U(Update) - setting the account details
            object[] inputValues = new object[] {   type,
                                                    item,
                                                    whse,
                                                    qty,
                                                    uom,
                                                    materialCost,
                                                    laborCost,
                                                    fovhdCost,
                                                    vovhdCost,
                                                    outCost,
                                                    unitCost,
                                                    loc,
                                                    lot,
                                                    reasonCode,
                                                    reasonCodeResData.Parameters.ElementAt(3).ToString(),
                                                    reasonCodeResData.Parameters.ElementAt(4).ToString(),
                                                    reasonCodeResData.Parameters.ElementAt(5).ToString(),
                                                    reasonCodeResData.Parameters.ElementAt(6).ToString(),
                                                    reasonCodeResData.Parameters.ElementAt(7).ToString(),
                                                    System.DateTime.Now, // FTDEV-9247 - Date-conversion for bounced method // System.DateTime.Now.ToString(WMShortDatePattern),
                                                    "",
                                                    documentNumber,
                                                    this.ImportDocID,
                                                    this.containerNum,
                                                    "",
                                                    ""
                                                    };

            InvokeResponseData responseDataStep = this.InvokeIDO("SLStockActItems", "ItemMiscReceiptSetVarsSp", inputValues);
            if (!(responseDataStep.ReturnValue.Equals("0")))
            {
                errorMessage = responseDataStep.Parameters.ElementAt(20).ToString();
                return false;
            }

            return true;
        }

        public bool getWhseItemCosts()
        {
            object[] inputValues = new object[] { whse,
                                                  item,
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
                                                  "",
                                                  "",
                                                  "",
                                                  ""};

            whseItemCostResData = this.InvokeIDO("SLItems", "MisReceiptItemWhseGetCostValuesSp", inputValues);
            if (!(whseItemCostResData.ReturnValue.Equals("0")))
            {
                errorMessage = whseItemCostResData.Parameters.ElementAt(8).ToString();
                return false;
            }
            return true;
        }

        public bool ValidateQtyForRcvIntoContainerSp()
        {
            object[] inputValues = new object[]{
                                                item,
                                                whse,
                                                loc,
                                                lot,
                                                site,
                                                ""
                                                };

            InvokeResponseData invokeResponseData = this.InvokeIDO("SLContainers", "ValidateQtyForRcvIntoContainerSp", inputValues);
            if (!(invokeResponseData.ReturnValue.Equals("0")))
            {
                errorMessage = invokeResponseData.Parameters.ElementAt(5).ToString();
                return false;
            }
            return true;
        }

        public bool RValContainerSp()
        {
            object[] inputValues = new object[]{
                                                this.containerNum,
                                                whse,
                                                loc,
                                                lot,
                                                "",
                                                ""
                                                };

            InvokeResponseData invokeResponseData = this.InvokeIDO("SLContainers", "ValidateQtyForRcvIntoContainerSp", inputValues);
            if (!(invokeResponseData.ReturnValue.Equals("0")))
            {
                errorMessage = invokeResponseData.Parameters.ElementAt(5).ToString();
                return false;
            }

            if (!(invokeResponseData.Parameters.ElementAt(5).ToString().Trim().Equals("")))
            {
                this.createContainerNum = true;
            }
            else
            {
                this.createContainerNum = false;
            }
            return true;
        }




        #endregion
    }
}