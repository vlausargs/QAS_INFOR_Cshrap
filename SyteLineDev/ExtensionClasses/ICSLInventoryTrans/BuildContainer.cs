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
    class BuildContainer : InventoryUtilities
    {
        //Input Variables.
        private string qty = "";
        private string item = "";
        private string site = "";
        private string whse = "";
        private string loc = "";
        private string uom = "";
        private string lot = "";
        private bool addItemLocRecord = true;
        private bool allowIfCycleCountExists = false;
        private bool addPermanentItemWhseLocLink = false;
        private bool allowIfSlowMoving = true;

        private string SerialsSessionID = "";
        private string containerNum = "";
        private string userInitial = "";

        //Local Variables

        private List<string> SerialList = null;
        private bool itemLotTracked = false;
        private bool itemSerialTracked = false;
        private bool insertItemLocRecord = false;
        private double qtyOnHand = 0;
        private bool createContainerNum = false;
        bool containerLocMismatch = false;

        private string errorMessage = "";
        private string RowPointer = "";
        private string RecordDate = "";
        private double containerItemQty = 0.0;
        private LoadCollectionResponseData ContainerItemsResponseData = null;

        public BuildContainer(string qty, string item, string site, string whse, string loc,
                                          string uom, string lot,
                                          bool addItemLocRecord, bool allowIfCycleCountExists,
                                          bool addPermanentItemWhseLocLink, bool allowIfSlowMoving,
                                          string SerialsSessionID, string containerNum, string userInitial)
        {
            this.qty = qty;
            this.item = item;
            this.site = site;
            this.whse = whse;
            this.loc = loc;
            this.uom = uom;
            this.lot = lot;
            this.addItemLocRecord = addItemLocRecord;
            this.allowIfCycleCountExists = allowIfCycleCountExists;
            this.addPermanentItemWhseLocLink = addPermanentItemWhseLocLink;
            this.allowIfSlowMoving = allowIfSlowMoving;
            this.SerialsSessionID = SerialsSessionID;
            this.containerNum = containerNum;
            this.userInitial = userInitial;


        }

        public void initialize()
        {
            //Local variables initialization
            SerialList = null;
            itemLotTracked = false;
            itemSerialTracked = false;
            insertItemLocRecord = false;

            qtyOnHand = 0;
            userInitial = "";
            createContainerNum = false;

            errorMessage = "";
            RowPointer = "";
            RecordDate = "";

        }


        public bool formatInputs()
        {
            if (!((containerNum == null) || containerNum.Trim().Equals("")))
            {
                containerNum = formatDataByIDOAndPropertyName("SLContainers", "ContainerNum", containerNum);

            }
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

            if (containerNum == null || containerNum.Trim().Equals(""))
            {
                errorMessage = "container input mandatory";
                return false;
            }

            lot = formatDataByIDOAndPropertyName("SLLotLocs", "Lot", lot);



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
            /*if (GetWhseDetailsBySite(whse, site, out responseData, out errorMessage) == false)
            {
               return false;
            }
            */
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

            /*if (validWhseItemRecordExists(whse, item, allowIfCycleCountExists, out errorMessage) == false)
            {
                return false;
            }

            if (getWhseItemCosts() == false)
            {
                return false;
            }*/



            //Check for Obsolte and Slow moving items.

            if (ObsSlowSp(item, this.allowIfSlowMoving, out errorMessage) == false)
            {
                return false;
            }

            //Qty Checks
            try
            {

                if (Convert.ToDecimal(qty, CultureInfo.InvariantCulture) <= 0) // FTDEV-9247
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

                errorMessage = site + " / " + whse + " / " + item + " / " + loc + " combination does not exists, Transfer not allowed";
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

            if (checkIfItemLotExists() == false)
            {
                errorMessage = "Item Lot Does not exists";
                return false;
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
                                                  "Build Container",
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

            if (PerformBuildContainer() == false)
            {
                infobar = errorMessage;
                return 3;
            }
            return 0;
        }


        #region private methods


        private bool PerformBuildContainer()
        {
            try
            {
                //1 Date Check

                object[] dateCheckValues = new object[] { System.DateTime.Now.ToString(WMShortDatePattern), //MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128
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




            if (GetContainerItemDetails() == false)
            {// Container Not found

                UpdateCollectionRequestData updateContRequestData = new UpdateCollectionRequestData();
                updateContRequestData.IDOName = "SLContainerItems";
                updateContRequestData.RefreshAfterUpdate = true;
                IDOUpdateItem SlContItem = new IDOUpdateItem();
                SlContItem.Action = UpdateAction.Insert;


                SlContItem.Properties.Add("RowPointer", "", false);
                SlContItem.Properties.Add("RecordDate", "", false);
                SlContItem.Properties.Add("InWorkflow", "", false);
                SlContItem.Properties.Add("NoteExistsFlag", "", false);
                SlContItem.Properties.Add("_ItemWarnings", "", false);
                SlContItem.Properties.Add("ItemLotTracked", GetIDOInputBoolValue(itemLotTracked), true);
                SlContItem.Properties.Add("ContainerNum", containerNum, true);
                SlContItem.Properties.Add("Item", item, true);
                SlContItem.Properties.Add("Lot", lot, true);
                SlContItem.Properties.Add("QtyContained", qty, true);

                SlContItem.Properties.Add("DerTotalContainedQuantity", "", false);
                SlContItem.Properties.Add("DerQtyOnHand", "", false);
                SlContItem.Properties.Add("ItemUM", uom, true);

                SlContItem.Properties.Add("ItemDescription", "", false);
                SlContItem.Properties.Add("ItemSerialTracked", GetIDOInputBoolValue(itemSerialTracked), true);

                SlContItem.Properties.Add("DerQtyRvsd", "", false);
                SlContItem.Properties.Add("DerOtherQtyContained", "", false);
                SlContItem.Properties.Add("DerQtyContainedForUse", "", false);

                if (this.itemSerialTracked == true)
                {

                    UpdateCollectionRequestData serialUpdateRequestData = new UpdateCollectionRequestData();
                    serialUpdateRequestData.IDOName = "SLSerials";
                    serialUpdateRequestData.RefreshAfterUpdate = true;

                    PropertyPair[] propertyPair = new PropertyPair[] { new PropertyPair("Item", "Item") };
                    serialUpdateRequestData.LinkBy = propertyPair;

                    if (SerialsSessionID != null)
                    {
                        for (int i = 0; i < this.SerialList.Count(); i++)
                        {
                            IDOUpdateItem serialItem = new IDOUpdateItem();
                            serialItem.Action = UpdateAction.Update;
                            LoadCollectionResponseData responseData = GetSerialInfo(whse, item, loc, formatDataByIDOAndPropertyName("SLMSSerials", "SerNum", SerialList.ElementAt(i).ToString()), lot, false);
                            serialItem.ItemNumber = i;
                            serialItem.Properties.Add("SerNum", formatDataByIDOAndPropertyName("SLMSSerials", "SerNum", SerialList.ElementAt(i).ToString()), false);
                            serialItem.Properties.Add("InWorkflow", "", false);
                            serialItem.Properties.Add("Item", item, false);
                            serialItem.Properties.Add("Lot", lot, true);
                            serialItem.Properties.Add("NoteExistsFlag", "", false);
                            serialItem.Properties.Add("RowPointer", responseData[0, "RowPointer"].ToString().ToUpper(), false);
                            serialItem.Properties.Add("RecordDate", responseData[0, "RecordDate"].ToString().ToUpper(), false);
                            serialItem.Properties.Add("_ItemWarnings", "", false);
                            serialItem.Properties.Add("UbSelect", "1");
                            serialItem.Properties.Add("ContainerNum", containerNum, true);
                            serialItem.Properties.Add("RefRelease", "", false);
                            serialItem.Properties.Add("RefNum", "", false);
                            serialItem.Properties.Add("RefLine", "", false);
                            serialItem.Properties.Add("RsvdNum", "", false);

                            serialUpdateRequestData.Items.Add(serialItem);

                        }
                    }

                    SlContItem.NestedUpdates.Add(serialUpdateRequestData);
                }
                UpdateCollectionResponseData updateResponseData = null;
                try
                {


                    updateContRequestData.Items.Add(SlContItem);
                    String test = updateContRequestData.ToFormattedXml();
                    updateResponseData = this.Context.Commands.UpdateCollection(updateContRequestData);
                    //Console.WriteLine(updateResponseData.ToXml());
                }
                catch (Exception)
                {
                    //Console.WriteLine("Exception " + e.Message);
                }

            }
            else
            {   // Container Found in the system
                containerItemQty = containerItemQty + Convert.ToDouble(qty, CultureInfo.InvariantCulture); // FTDEV-9247
                UpdateCollectionRequestData updateContRequestData = new UpdateCollectionRequestData();
                updateContRequestData.IDOName = "SLContainerItems";
                updateContRequestData.RefreshAfterUpdate = true;

                IDOUpdateItem SlContItem = new IDOUpdateItem();
                SlContItem.Action = UpdateAction.Update;
                SlContItem.ItemNumber = 1;
                SlContItem.Properties.Add("ContainerNum", containerNum, false);
                SlContItem.Properties.Add("Item", item, false);
                SlContItem.Properties.Add("Lot", lot, true);
                SlContItem.Properties.Add("QtyContained", "" + containerItemQty, true);
                SlContItem.Properties.Add("RowPointer", RowPointer, false);
                SlContItem.Properties.Add("RecordDate", RecordDate, false);
                if (this.itemSerialTracked == true)
                {

                    UpdateCollectionRequestData serialUpdateRequestData = new UpdateCollectionRequestData();
                    serialUpdateRequestData.IDOName = "SLSerials";
                    serialUpdateRequestData.RefreshAfterUpdate = true;

                    PropertyPair[] propertyPair = new PropertyPair[] { new PropertyPair("Item", "Item") };
                    serialUpdateRequestData.LinkBy = propertyPair;

                    if (SerialsSessionID != null)
                    {
                        for (int i = 0; i < this.SerialList.Count(); i++)
                        {
                            IDOUpdateItem serialItem = new IDOUpdateItem();
                            serialItem.Action = UpdateAction.Update;
                            LoadCollectionResponseData responseData = GetSerialInfo(whse, item, loc, formatDataByIDOAndPropertyName("SLMSSerials", "SerNum", SerialList.ElementAt(i).ToString()), lot, false);
                            serialItem.ItemNumber = i;
                            serialItem.Properties.Add("SerNum", formatDataByIDOAndPropertyName("SLMSSerials", "SerNum", SerialList.ElementAt(i).ToString()), false);
                            serialItem.Properties.Add("InWorkflow", "", false);
                            serialItem.Properties.Add("Item", item, false);
                            serialItem.Properties.Add("Lot", lot, true);
                            serialItem.Properties.Add("NoteExistsFlag", "", false);
                            serialItem.Properties.Add("RowPointer", responseData[0, "RowPointer"].ToString().ToUpper(), false);
                            serialItem.Properties.Add("RecordDate", responseData[0, "RecordDate"].ToString().ToUpper(), false);
                            serialItem.Properties.Add("_ItemWarnings", "", false);
                            serialItem.Properties.Add("UbSelect", "1");
                            serialItem.Properties.Add("ContainerNum", containerNum, true);
                            serialItem.Properties.Add("RefRelease", "", false);
                            serialItem.Properties.Add("RefNum", "", false);
                            serialItem.Properties.Add("RefLine", "", false);
                            serialItem.Properties.Add("RsvdNum", "", false);

                            serialUpdateRequestData.Items.Add(serialItem);

                        }
                    }

                    SlContItem.NestedUpdates.Add(serialUpdateRequestData);
                }
                UpdateCollectionResponseData updateResponseData = null;
                try
                {


                    updateContRequestData.Items.Add(SlContItem);
                    // String test = updateContRequestData.ToFormattedXml();
                    updateResponseData = this.Context.Commands.UpdateCollection(updateContRequestData);
                    //Console.WriteLine(updateResponseData.ToXml());
                }
                catch (Exception)
                {
                    //Console.WriteLine("Exception " + e.Message);

                }

            }
           
                ClearSerailsBySessionID(this.SerialsSessionID);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }
            return true;
        }

        private bool GetContainerItemDetails()
        {
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLContainerItems";
            requestData.PropertyList.SetProperties("RowPointer, RecordDate, ItemLotTracked,ContainerNum,Item,Lot,QtyContained,DerTotalContainedQuantity,DerQtyOnHand,ItemUM,ItemDescription,ItemSerialTracked,DerQtyRvsd,DerOtherQtyContained,DerQtyContainedForUse");
            string filterString = "ContainerNum = '" + containerNum + "'   and Item ='" + item + "'";
            if (lot != null && lot.Trim().Length > 0)
            {
                filterString = filterString + " and Lot='" + lot + "'";
            }
            requestData.Filter = filterString;
            requestData.RecordCap = 0;
            requestData.OrderBy = "Item";

            ContainerItemsResponseData = ExcuteQueryRequest(requestData);
            if (ContainerItemsResponseData != null && ContainerItemsResponseData.Items.Count > 0)
            {
                this.RowPointer = ContainerItemsResponseData[0, "RowPointer"].Value;
                this.RecordDate = ContainerItemsResponseData[0, "RecordDate"].Value;
                containerItemQty = Convert.ToDouble(ContainerItemsResponseData[0, "QtyContained"].Value, CultureInfo.InvariantCulture); // FTDEV-9247
                return true;
            }

            return false;

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