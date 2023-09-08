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
    class MiscellaneousIssueUpdate : InventoryUtilities
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
        private bool allowNegInventory = false;

        private bool addItemLocRecord = true;
        private bool allowIfCycleCountExists = false;
        private bool addPermanentItemWhseLocLink = false;
        private string documentNumber = "";
        private string SerialsSessionID = "";
        private string ImportDocID = "";
        private string containerNum = "";
        private string userInitial = "";

        //Local Variables

        private List<string> SerialList = null;
        private bool itemLotTracked = false;
        private bool itemSerialTracked = false;
        private bool insertItemLocRecord = false;

        private double qtyOnHand = 0;
        private string errorMessage = "";
        private string accountCode = "";
        private string accountUnit1 = "";
        private string accountUnit2 = "";
        private string accountUnit3 = "";
        private string accountUnit4 = "";
        private bool containerLocMismatch = false;






        public MiscellaneousIssueUpdate(string qty, string item, string site, string whse, string loc,
                                          string uom, string reasonCode, string lot, bool allowNegInventory, bool addItemLocRecord, bool allowIfCycleCountExists,
                                          bool addPermanentItemWhseLocLink, string documentNumber, string SerialsSessionID, string containerNum, string userInitial, string ImportDocID)
        {
            this.qty = qty;
            this.item = item;
            this.site = site;
            this.whse = whse;
            this.loc = loc;
            this.uom = uom;
            this.reasonCode = reasonCode;
            this.lot = lot;
            this.allowNegInventory = allowNegInventory;
            this.addItemLocRecord = addItemLocRecord;
            this.allowIfCycleCountExists = allowIfCycleCountExists;
            this.addPermanentItemWhseLocLink = addPermanentItemWhseLocLink;
            this.documentNumber = documentNumber;
            this.SerialsSessionID = SerialsSessionID;
            this.ImportDocID = ImportDocID;
            this.containerNum = containerNum;
            this.userInitial = userInitial;

        }

        public void initialize()
        {
            site = "";
            whse = "";
            item = "";

            qty = "";
            loc = "";
            lot = "";
            uom = "";
            reasonCode = "";
            allowNegInventory = false;

            addItemLocRecord = true;
            addPermanentItemWhseLocLink = false;
            allowIfCycleCountExists = false;
            //Local variables initialization
            SerialList = null;
            itemLotTracked = false;
            itemSerialTracked = false;
            insertItemLocRecord = false;

            qtyOnHand = 0;
            errorMessage = "";
            containerNum = "";
            containerLocMismatch = false;
            userInitial = "";

        }


        public bool formatInputs()
        {
            if (containerNum == null || containerNum == (""))
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

                if (documentNumber == null)
                {
                    documentNumber = "";
                }
                if (ImportDocID == null)
                {
                    ImportDocID = "";
                }
            }
            else
            {  // Container Issue
                if (!((containerNum == null) || containerNum.Trim().Equals("")))
                {
                    containerNum = formatDataByIDOAndPropertyName("SLContainers", "ContainerNum", containerNum);

                }
                if (reasonCode == null || reasonCode.Trim().Equals(""))
                {
                    errorMessage = "reasonCode input mandatory";
                    return false;
                }


            }
            return true;
        }


        public bool validateInputs()
        {

            if (containerNum == null || containerNum.Trim() == (""))
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
                itemUM = responseData[0, "UM"].ToString();

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
                        errorMessage = site + " / " + whse + " / " + item + " / " + loc + " combination does not exists, Transfer not allowed";
                        return false;
                    }
                    else
                    {
                        insertItemLocRecord = true;
                    }
                }

                if (checkLocOnHand() == false)
                {
                    return false;
                }


                /*  itemUM = responseData[0,"UM"].ToString();                     */



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

                if (checkAdjReasonCodes(reasonCode, "MISC ISSUE", item, "0", out accountCode, out accountUnit1, out accountUnit2, out accountUnit3, out accountUnit4, out errorMessage) == false)
                {
                    return false;
                }


                //Lot Code Checks

                if (itemLotTracked == true)
                {
                    if (lot == null || lot.Trim().Equals(""))
                    {
                        errorMessage = "Item is lot controlled, Lot Input is Mandatory";
                        return false;
                    }
                }
                if (ImportDocID != null && !(ImportDocID.Trim().Equals("")))
                {
                    if (ValidateImportID(ImportDocID, out errorMessage) == false)
                    {
                        return false;
                    }
                }
            }
            else
            {
                if (ValidateContainerExist(this.containerNum, this.whse, this.loc, containerLocMismatch, out errorMessage) == true)
                {

                    if (containerLocMismatch)
                    {
                        errorMessage = " Container Location missmatch ";
                        return false;
                    }
                }
                else
                {
                    errorMessage = " Container does not exist ";
                    return false;
                }

                //Reason Code Checks

                if (checkAdjReasonCodes(reasonCode, "MISC ISSUE", item, "1", out accountCode, out accountUnit1, out accountUnit2, out accountUnit3, out accountUnit4, out errorMessage) == false)
                {
                    return false;
                }
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

            //1 Initialize variables
            //initialize();
            //2 Format Inputs
            if (formatInputs() == false)
            {
                infobar = errorMessage;
                return 1;
            }

            //3 validate Inputs
            if (validateInputs() == false)
            {
                infobar = errorMessage;
                return 2;
            }

            //4 Perform Updates
            if (performAdjustment() == false)
            {
                infobar = errorMessage;
                return 3;
            }
            return 0;
        }


        #region private methods


        private bool performAdjustment()
        {
            try
            {
                //1 Date Check
                object[] dateCheckValues = new object[] { //System.DateTime.Now.ToShortDateString(), 
                                                      System.DateTime.Now.ToString(WMShortDatePattern), //MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128 
                                                      "Transaction Date",
                                                      "@%update",
                                                      "",
                                                      "",
                                                      "" };

            //   InvokeResponseData invokeResponseDataStep1 = this.sytelineClient.Invoke("SLPeriods", "DateChkSp", dateCheckValues);
            InvokeResponseData invokeResponseDataStep1 = this.Context.Commands.Invoke("SLPeriods", "DateChkSp", dateCheckValues);

            if (!(invokeResponseDataStep1.ReturnValue.Equals("0")))
            {
                errorMessage = invokeResponseDataStep1.Parameters.ElementAt(3).ToString();
                return false;
            }

            if ((containerNum == null) || (containerNum.Trim() == ""))
            {

                if (this.insertItemLocRecord == true)
                {
                    if (addLocItemRecord(item, whse, site, loc, addPermanentItemWhseLocLink) == false)
                    {
                        return false;
                    }
                }

                //Delete the current Inventory
                object[] deleteInvValues = new object[] { site,
                                                      "A",
                                                      "S",
                                                      whse,
                                                      item,
                                                      loc,
                                                      lot,
                                                      qty,
                                                      0,
                                                      "iss",
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

                //Save Field values
                if (storeUpdateValues("S") == false)
                {
                    return false;
                }

                //Serials Process

                //SLMSSerials.SetMethodSp - To store the values
                object[] serialsSetMethodInputs = new object[] { "SLJobTrans.ApsSyncDeferSp|SLItemLocs.IaPostSp|SLJobTrans.ApsSyncImmediateSp" };

                InvokeResponseData serialsSetMethodResponseData = this.Context.Commands.Invoke("SLMSSerials", "SetMethodSP", serialsSetMethodInputs);
                if (!(serialsSetMethodResponseData.ReturnValue.Equals("0")))
                {
                    errorMessage = "Transfer process failed";
                    return false;
                }

                //Serials

                UpdateCollectionRequestData updateRequestData = new UpdateCollectionRequestData();
                updateRequestData.IDOName = "SLSerials";
                updateRequestData.RefreshAfterUpdate = true;
                updateRequestData.CustomInsert = "SerialSaveSp(SerNum,NULL,NULL,MESSAGE,NULL,NULL,NULL)";
                updateRequestData.CustomUpdate = "SerialSaveSp(SerNum,NULL,NULL,MESSAGE,NULL,NULL,NULL)";

                if (SerialList != null)
                {
                    for (int i = 0; i < SerialList.Count; i++)
                    {
                        IDOUpdateItem serialItem = new IDOUpdateItem();
                        serialItem.Action = UpdateAction.Update;
                        serialItem.ItemNumber = i;
                        serialItem.Properties.Add("SerNum", formatDataByIDOAndPropertyName("SLMSSerials", "SerNum", SerialList.ElementAt(i)), false);
                        serialItem.Properties.Add("UbSelect", "1");
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
            else
            {
                // Container Issue

                object[] containerIssueInputs = new object[] {
                                                      containerNum,
                                                      System.DateTime.Now.ToString(WMShortDatePattern),
                                                      accountCode,
                                                      accountUnit1,
                                                      accountUnit2,
                                                      accountUnit3 ,
                                                      accountUnit4,
                                                      reasonCode,
                                                       "",
                                                       "",
                                                       ""};

                InvokeResponseData invokeResponseDataStep2 = this.Context.Commands.Invoke("SLItemacts", "ContainerIssuePostSp", containerIssueInputs);
                if (!(invokeResponseDataStep2.ReturnValue.Equals("0")))
                {
                    errorMessage = invokeResponseDataStep2.Parameters.ElementAt(8).ToString();
                    return false;
                }


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

        private bool checkLocOnHand()
        {
            object[] inputValues = new object[] { whse,
                                                  item,
                                                  loc,
                                                  qty,
                                                  site,
                                                  this.qtyOnHand,
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "" };

            InvokeResponseData responseData = this.Context.Commands.Invoke("SLItemacts", "MiscIssueGetLocQtyOnHandSp", inputValues);
            if (!(responseData.ReturnValue.Equals("0")))
            {
                errorMessage = responseData.Parameters.ElementAt(8).ToString();
                return false;
            }
            /*else
            {
                double qtyIssued = Convert.ToDouble(responseData.Parameters.ElementAt(3).ToString(), CultureInfo.InvariantCulture); // FTDEV-9247
                if (this.allowNegInventory == false)
                {
                }
            }*/
            return true;
        }

        private bool storeUpdateValues(string type)
        {
            //APSSynchDefer process
            object[] apsSyncDeferValues = new object[] {type,
                                                    ""};

            InvokeResponseData apsSynchDeferResponseDataStep = this.Context.Commands.Invoke("SLJobTrans", "ApsSyncDeferSetVarsSp", apsSyncDeferValues);
            if (!(apsSynchDeferResponseDataStep.ReturnValue.Equals("0")))
            {
                errorMessage = apsSynchDeferResponseDataStep.Parameters.ElementAt(1).ToString();
                return false;
            }


            //IaPostSetVarsSp - S(Save) process / U(Update) - setting the account details
            object[] IapostValues = new object[] { type,
                                                   "I",
                                                   System.DateTime.Now.ToString(WMShortDatePattern), //MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128
                                                    accountCode,
                                                    accountUnit1,
                                                    accountUnit2,
                                                    accountUnit3 ,
                                                    accountUnit4,
                                                    qty,
                                                    whse,
                                                    item,
                                                    loc,
                                                    lot,
                                                    site,
                                                    site,
                                                    reasonCode,
                                                    "",
                                                    0,
                                                    0,
                                                    0,
                                                    "O",
                                                    "",
                                                    "1",
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
                                                    "",
                                                    "",
                                                    "",
                                                    documentNumber,
                                                   ImportDocID,
                                                    0,
                                                    "",
                                                    "",
                                                    "",
                                                    ""
                                                    };

            InvokeResponseData IaPostResponseDataStep = this.Context.Commands.Invoke("SLItemLocs", "IaPostSetVarsSp", IapostValues);
            if (!(IaPostResponseDataStep.ReturnValue.Equals("0")))
            {
                errorMessage = IaPostResponseDataStep.Parameters.ElementAt(30).ToString();
                return false;
            }


            //APSSynchImmediate process
            object[] apsSyncImmediateValues = new object[] { type,
                                                    "",
                                                    "" };

            InvokeResponseData apsSynchImmediateResponseDataStep = this.Context.Commands.Invoke("SLJobTrans", "ApsSyncImmediateSetVarsSp", apsSyncImmediateValues);
            if (!(apsSynchImmediateResponseDataStep.ReturnValue.Equals("0")))
            {
                errorMessage = apsSynchImmediateResponseDataStep.Parameters.ElementAt(1).ToString();
                return false;
            }

            return true;
        }

        #endregion
    }
}