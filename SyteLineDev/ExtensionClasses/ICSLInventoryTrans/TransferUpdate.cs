using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mongoose.Core.Configuration;
using Mongoose.IDO.Protocol;
using Mongoose.IDO;
using Mongoose.Core;




namespace InforCollect.ERP.SL.ICSLInventoryTrans
{
    class TransferUpdate : InventoryUtilities
    {
        //Input Variables.
        private string qty = "";
        private string item = "";
        private string fromSite = "";
        private string fromWhse = "";
        private string fromLoc = "";
        private string fromLot = "";
        private string toWhse = "";
        private string toLoc = "";
        private string toLot = "";
        private string toSite = "";
        private string uom = "";
        private bool addItemLocRecord = true;
        private bool allowIfCycleCountExists = false;
        private bool addPermanentItemWhseLocLink = false;
        private string SerialsSessionID = "";
        private string userInitial = "";
        //format - <serials><serial>xxx</serial><serial>xxys</serial></serials>

        //Local Varialbles
        private bool itemLotTracked = false;
        private bool itemSerialTracked = false;
        private bool insertItemLocRecord = false;
        private string errorMessage = "";
        //When the standard class is used by the extension class for containerization some parameters are not set until the container record is read.  jh:2011/08/20
        private bool containerization = true;
        private List<string> SerialList = null;
        private string containerNum = "";
        private bool containerLocMismatch = false;
        private string docNum = "";
        private DateTime _siteDateTime;
        public DateTime SiteDateTime
        {
            get { return _siteDateTime; }
            set { _siteDateTime = value; }
        }
        public TransferUpdate(string qty, string item, string fromSite,
                              string fromWhse, string fromLoc, string fromLot,
                              string toWhse, string toLoc, string toLot, string toSite,
                              string uom, bool addItemLocRecord, bool allowIfCycleCountExists,
                              bool addPermanentItemWhseLocLink, string SerialsSessionID, string containerNum, string userInitial, string docNum)
        {
            initialize();
            this.qty = qty;
            this.item = item;
            this.fromSite = fromSite;
            this.fromWhse = fromWhse;
            this.fromLoc = fromLoc;
            this.fromLot = fromLot;
            this.toWhse = toWhse;
            this.toLoc = toLoc;
            this.toLot = toLot;
            this.toSite = toSite;
            this.uom = uom;
            this.addItemLocRecord = addItemLocRecord;
            this.allowIfCycleCountExists = allowIfCycleCountExists;
            this.addPermanentItemWhseLocLink = addPermanentItemWhseLocLink;
            this.SerialsSessionID = SerialsSessionID;
            this.containerNum = containerNum;
            this.userInitial = userInitial;
            this.docNum = docNum;
        }


        public void initialize()
        {
            //Input variables initialization
            qty = "";
            item = "";
            fromSite = "";
            fromWhse = "";
            fromLoc = "";
            fromLot = "";
            toWhse = "";
            toLoc = "";
            toSite = "";
            uom = "";
            addItemLocRecord = true;
            addPermanentItemWhseLocLink = false;
            allowIfCycleCountExists = false;
            this.SerialsSessionID = "";

            //Local variables initialization
            itemLotTracked = false;
            itemSerialTracked = false;
            insertItemLocRecord = false;
            containerNum = "";
            userInitial = "";
            containerLocMismatch = false;
            docNum = "";
        }

        public bool formatInputs()
        {
            if (fromSite == null || fromSite.Trim().Equals(""))
            {
                errorMessage = "from site input mandatory";
                return false;
            }

            if (fromWhse == null || fromWhse.Trim().Equals(""))
            {
                errorMessage = "from whse input mandatory";
                return false;
            }

            if (fromLoc == null || fromLoc.Trim().Equals(""))
            {
                errorMessage = "from loc input mandatory";
                return false;
            }
            if (toWhse == null || toWhse.Trim().Equals(""))
            {
                errorMessage = "to whse input mandatory";
                return false;
            }

            if (toLoc == null || toLoc.Trim().Equals(""))
            {
                errorMessage = "to loc input mandatory";
                return false;
            }

            if (toSite == null || toSite.Trim().Equals(""))
            {
                errorMessage = "to site input mandatory";
                return false;
            }


            if (containerNum == null || containerNum.Trim() == "")
            {
                fromLot = formatDataByIDOAndPropertyName("SLLotLocs", "Lot", fromLot);
                this.toLot = formatDataByIDOAndPropertyName("SLLotLocs", "Lot", toLot);

                if ((qty == null || qty.Trim().Equals("")) & (!containerization))
                {
                    errorMessage = "qty input mandatory";
                    return false;
                }

                if (item == null || item.Trim().Equals(""))
                {
                    errorMessage = "item input mandatory";
                    return false;
                }


                if (uom == null || uom.Trim().Equals(""))
                {
                    errorMessage = "uom input mandatory";
                    return false;
                }

            }
            if (!((containerNum == null) || containerNum.Trim().Equals("")))
            {
                containerNum = formatDataByIDOAndPropertyName("SLContainers", "ContainerNum", containerNum);
            }
            return true;
        }

        public bool validateInputs()
        {

            //Validate From Site
            LoadCollectionResponseData responseData = GetSiteDetails(fromSite);
            if (responseData.PropertyList.Count == 0)
            {
                errorMessage = "From Site Details Not Found";
                return false;
            }
            //Validate To Site
            responseData = GetSiteDetails(toSite);
            if (responseData.PropertyList.Count == 0)
            {
                errorMessage = "To Site Details Not Found";
                return false;
            }
            //Check if Transfer between From Site and To Site are allowed.
            if (transferBetweenSitesAllowed(fromSite, toSite, out errorMessage) == false)
            {
                return false;
            }
            //Check From Warehouse
            if (GetWhseDetailsBySite(fromWhse, fromSite, out responseData, out errorMessage) == false)
            {
                return false;
            }
            //Check To Warehouse
            if (GetWhseDetailsBySite(toWhse, toSite, out responseData, out errorMessage) == false)
            {
                return false;
            }
            if (containerNum == null || containerNum.Trim() == "")
            {

                //Check Item Details
                responseData = GetItemDetails(formatItem(item));
                if (responseData.PropertyList.Count == 0)
                {
                    errorMessage = "Item Details Not Found";
                    return false;
                }

                itemLotTracked = GetBool(responseData[0, "LotTracked"].Value);
                itemSerialTracked = GetBool(responseData[0, "SerialTracked"].Value);

                if (validWhseItemRecordExists(fromWhse, item, allowIfCycleCountExists, out errorMessage) == false)
                {
                    return false;
                }

                if (validWhseItemRecordExists(toWhse, item, allowIfCycleCountExists, out errorMessage) == false)
                {
                    return false;
                }

                //Check From Location
                responseData = GetLocationDetails(fromLoc);

                if (checkLocationDetails(item, fromWhse, fromSite, fromLoc, out errorMessage) == false)
                {
                    errorMessage = fromSite + " / " + fromWhse + " / " + item + "/" + fromLoc + " combination does not exists, Transfer not allowed";
                    return false;
                }

                //Check To Location
                responseData = GetLocationDetails(toLoc);
                if (checkLocationDetails(item, toWhse, toSite, toLoc, out errorMessage) == false)
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

                //Check From Lot
                if (checkLot(formatItem(item), fromLot, itemLotTracked, out errorMessage) == false)
                {
                    return false;
                }

                if (toLot != null)
                {
                    if (!(toLot.Trim().Equals(fromLot)))
                    {
                        if (checkLot(item, toLot, itemLotTracked, out errorMessage) == false)
                        {
                            return false;
                        }
                    }
                }

                //UOM Checks
                string convertedQty = GetItemConvertedQtyToBaseUnit(item, qty, uom, "", out errorMessage);
                if (convertedQty == null)
                {
                    return false;
                }
                qty = convertedQty;
            }
            else
            {

                if (ValidateContainerExist(this.containerNum, this.fromWhse, this.fromLoc, containerLocMismatch, out errorMessage) == true)
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
            if (containerNum == null || containerNum.Trim() == "")
            {
                if (PerformTransfer() == false)
                {
                    infobar = errorMessage;
                    return 3;
                }
            }
            else
            {
                if (PerformContainerTransfer() == false)
                {
                    infobar = errorMessage;
                    return 3;
                }
            }
            return 0;
        }

        private bool PerformTransfer()
        {
            try
            {
                //1 Date Check
                object[] dateCheckValues = new object[] {
                                                      _siteDateTime, // FTDEV-9247 - Date-conversion for bounced method // System.DateTime.Now.ToString(WMShortDatePattern), //MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128
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

            if (this.insertItemLocRecord == true)
            {
                if (addLocItemRecord(item, toWhse, toSite, toLoc, addPermanentItemWhseLocLink, out errorMessage) == false)
                {
                    return false;
                }
            }

            //Delete the current Inventory
            object[] deletefromInvValues = new object[] { fromSite,
                                                      "M",
                                                      "R",
                                                      fromWhse,
                                                      item,
                                                      fromLoc,
                                                      fromLot,
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
                                                      "ToImportDocId",
                                                      "1"};

            InvokeResponseData invokeResponseDataStepfrom = this.Context.Commands.Invoke("SLItemLocs", "ItemQtyDetlSp", deletefromInvValues);
            if (!(invokeResponseDataStepfrom.ReturnValue.Equals("0")))
            {
                errorMessage = invokeResponseDataStepfrom.Parameters.ElementAt(19).ToString();
                return false;
            }

            //Delete the current Inventory
            object[] deleteInvValues = new object[] { toSite,
                                                      "M",
                                                      "R",
                                                      toWhse,
                                                      item,
                                                      toLoc,
                                                      toLot,
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
                                                      "ToImportDocId",
                                                      "1"};

            InvokeResponseData invokeResponseDataStepto = this.Context.Commands.Invoke("SLItemLocs", "ItemQtyDetlSp", deleteInvValues);
            if (!(invokeResponseDataStepto.ReturnValue.Equals("0")))
            {
                errorMessage = invokeResponseDataStepto.Parameters.ElementAt(19).ToString();
                return false;
            }

            //MsmpSetVarsSp - To store the values
            /******* OLD Code*/
            object[] msmpStoreValues = new object[] { "S",
                                                      "M",
                                                      _siteDateTime, // FTDEV-9247 - Date-conversion for bounced method // System.DateTime.Now.ToString(WMLongDateTimePattern), // FTDEV-9195 - Adding Time to the date/time string passed into CSI
                                                      qty,
                                                      item,
                                                      fromSite,
                                                      fromWhse,
                                                      fromLoc,
                                                      fromLot,
                                                      toSite,
                                                      toWhse,
                                                      toLoc,
                                                      toLot,
                                                      "",
                                                      "",
                                                      0,
                                                      0,
                                                      0,
                                                      'I',
                                                      "",
                                                      0,
                                                      "",
                                                      "",
                                                      "",
                                                      "0",
                                                      "0",
                                                      "0",
                                                      "0",
                                                      "0",
                                                      "",
                                                      "",
                                                      "",
                                                      "",
                                                      "",
                                                      "",
                                                      "",
                                                      docNum};

            InvokeResponseData invokeResponseDataStep2 = this.Context.Commands.Invoke("SLMSMoves", "MsmpSetVarsSp", msmpStoreValues);

            if (!(invokeResponseDataStep2.ReturnValue.Equals("0")))
            {
                errorMessage = invokeResponseDataStep2.Parameters.ElementAt(31).ToString();
                return false;
            }


            //SLMSSerials.SetMethodSp - To store the values


            object[] serialsMethod = new object[] { "SLMSMoves.MsmpSp" };

            InvokeResponseData invokeResponseDataStep3 = this.Context.Commands.Invoke("SLMSSerials", "SetMethodSP", serialsMethod);
            if (!(invokeResponseDataStep3.ReturnValue.Equals("0")))
            {
                errorMessage = "Transfer process failed";
                return false;
            }
            //Serials

            UpdateCollectionRequestData updateRequestData = new UpdateCollectionRequestData();
            updateRequestData.IDOName = "SLMSSerials";
            updateRequestData.RefreshAfterUpdate = true;
            updateRequestData.CustomInsert = "SerialSaveSp(SerNum,,,MESSAGE,NULL,NULL,NULL)";
            updateRequestData.CustomUpdate = "SerialSaveSp(SerNum,,,MESSAGE,NULL,NULL,NULL)";
            // Serial control logic


            if (SerialsSessionID != null)
            {
                for (int i = 0; i < this.SerialList.Count(); i++)
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
                Console.WriteLine(updateResponseData.ToXml());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                errorMessage = e.Message.ToString();
                return false;
            }



            //MsmpSetVarsSp - To store the values

            object[] msmpStoreValues2 = new object[] { "U",
                                                      "M",
                                                      _siteDateTime, // FTDEV-9247 - Date-conversion for bounced method // System.DateTime.Now.ToString(WMLongDateTimePattern), // FTDEV-9195 - Adding Time to the date/time string passed into CSI
                                                      "",
                                                      item,
                                                      fromSite,
                                                      fromWhse,
                                                      fromLoc,
                                                      fromLot,
                                                      toSite,
                                                      toWhse,
                                                      toLoc,
                                                      toLot,
                                                      "",
                                                      "",
                                                      0,
                                                      0,
                                                      0,
                                                      'I',
                                                      "",
                                                      0,
                                                      "",
                                                      "",
                                                      "0",
                                                      "0",
                                                      "0",
                                                      "0",
                                                      "0",
                                                      "0",
                                                      "",
                                                      "",
                                                      "",
                                                      "",
                                                      "",
                                                      "",
                                                      "",
                                                      docNum};
            InvokeResponseData invokeResponseDataStep4 = this.Context.Commands.Invoke("SLMSMoves", "MsmpSetVarsSp", msmpStoreValues2);
            if (!(invokeResponseDataStep4.ReturnValue.Equals("0")))
            {
                errorMessage = invokeResponseDataStep4.Parameters.ElementAt(31).ToString();
                return false;
            }


                /* try
                 {
                     object[] msmpStoreValuespost1 = new object[] { "S",
                                                           "M",
                                                           //System.DateTime.Now.ToShortDateString(), 
                                                           System.DateTime.Now.ToString(WMShortDatePattern), //MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128
                                                           qty, 
                                                           item, 
                                                           fromWhse, 
                                                           fromLoc, 
                                                           fromLot, 
                                                           toWhse, 
                                                           toLoc, 
                                                           toLot, 
                                                           1, 
                                                           "", 
                                                           "", 
                                                           "", 
                                                           "", 
                                                           'I', 
                                                           "", 
                                                           "", 
                                                           "", 
                                                           "", 
                                                           "0", 
                                                           "0", 
                                                           "0", 
                                                           "0", 
                                                           "0", 
                                                           "0", 
                                                           "0",
                                                           "",
                                                           docNum,
                                                           "",
                                                           "" };
                     InvokeResponseData invokeResponsepost1 = this.Context.Commands.Invoke("SLItemLocs", "MvPostSetVarsSp", msmpStoreValuespost1);
                     if (!(invokeResponsepost1.ReturnValue.Equals("0")))
                     {
                         errorMessage = invokeResponsepost1.Parameters.ElementAt(29).ToString();
                         return false;
                     }
                     //


                     object[] serialsMethod = new object[] { "SLItemLocs.MvPostSp" };

                     InvokeResponseData invokeResponseDataStepser = this.Context.Commands.Invoke("SLSerials", "SetMethodSP", serialsMethod);
                     if (!(invokeResponseDataStepser.ReturnValue.Equals("0")))
                     {
                         errorMessage = "Transfer process failed";
                         return false;
                     }
                     //Serials

                     UpdateCollectionRequestData updateRequestData = new UpdateCollectionRequestData();
                     updateRequestData.IDOName = "SLSerials";
                     updateRequestData.RefreshAfterUpdate = true;
                     updateRequestData.CustomInsert = "SerialSaveSp(SerNum,,,MESSAGE,NULL,NULL,NULL)";
                     updateRequestData.CustomUpdate = "SerialSaveSp(SerNum,,,MESSAGE,NULL,NULL,NULL)";
                     // Serial control logic


                     if (SerialsSessionID != null)
                     {
                         for (int i = 0; i < this.SerialList.Count(); i++)
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
                          //Console.WriteLine(updateResponseData.ToXml());
                     }
                     catch (Exception e)
                     {
                          //Console.WriteLine(e.Message.ToString());
                         errorMessage = e.Message.ToString();
                     }
                     //


                     object[] msmpStoreValuespost2 = new object[] { "U",
                                                           "M",
                                                           //System.DateTime.Now.ToShortDateString(), 
                                                           System.DateTime.Now.ToString(WMShortDatePattern), //MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128
                                                           qty, 
                                                           item, 
                                                           fromWhse, 
                                                           fromLoc, 
                                                           fromLot, 
                                                           toWhse, 
                                                           toLoc, 
                                                           toLot, 
                                                           1, 
                                                           "", 
                                                           "", 
                                                           "", 
                                                           "",
                                                           'I', 
                                                           "", 
                                                           "", 
                                                           "", 
                                                           "", 
                                                           "0", 
                                                           "0", 
                                                           "0", 
                                                           "0", 
                                                           "0", 
                                                           "0", 
                                                           "0",
                                                           "",
                                                           docNum,
                                                           "",
                                                           "" };
                     InvokeResponseData invokeResponsepost2 = this.Context.Commands.Invoke("SLItemLocs", "MvPostSetVarsSp", msmpStoreValuespost2);
                     if (!(invokeResponsepost2.ReturnValue.Equals("0")))
                     {
                         errorMessage = invokeResponsepost2.Parameters.ElementAt(29).ToString();
                         return false;
                     }

                 }
                 catch (Exception e)
                 {
                 }

         */


                ClearSerailsBySessionID(this.SerialsSessionID);
            }
            catch (Exception)
            {
            }

            return true;
        }

        private bool PerformContainerTransfer()
        {

            object[] containerTransferInput = new object[] {
                                                      containerNum,
                                                      "M",
                                                      _siteDateTime, // FTDEV-9247 - Date-conversion for bounced method // System.DateTime.Now.ToString(WMLongDateTimePattern), // FTDEV-9195 - Adding Time to the date/time string passed into CSI
                                                      fromWhse,
                                                      toWhse,
                                                      toLoc,
                                                      0,
                                                      "I" ,
                                                      ""
                                                        };

            InvokeResponseData invokeResponseData = this.Context.Commands.Invoke("SLItemLocs", "ContainerMvPostSp", containerTransferInput);
            errorMessage = invokeResponseData.Parameters.ElementAt(8).ToString();
            if ((invokeResponseData.ReturnValue.Equals("16")))
            {
                return false;
            }
            return true;
        }

    }
}