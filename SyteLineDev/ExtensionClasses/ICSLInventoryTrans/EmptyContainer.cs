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
    class EmptyContainer : InventoryUtilities
    {
        //Input Variables.
        private string qty = "";
        private string item = "";
        private string site = "";
        private string whse = "";
        private string loc = "";
        private string emptyall = "";
        private string lot = "";
        private bool addItemLocRecord = true;
        private bool allowIfCycleCountExists = false;
        private bool addPermanentItemWhseLocLink = false;
        private string SerialsSessionID = "";
        private string containerNum = "";
        private string userInitial = "";

        //Local Variables

        private List<string> SerialList = null;
        private bool itemLotTracked = false;
        private bool itemSerialTracked = false;
        bool containerLocMismatch = false;
        private double containerItemQty = 0.0;

        private string errorMessage = "";
        private string RowPointer = "";
        private string RecordDate = "";
        private string _itemId = "";
        private LoadCollectionResponseData ContainerItemsResponseData = null;

        public EmptyContainer(string qty, string containerNum, string emptyall, string item, string site, string lot,
                                          string whse, string loc, bool addItemLocRecord, bool allowIfCycleCountExists,
                                          bool addPermanentItemWhseLocLink, string SerialsSessionID, string userInitial)
        {
            this.qty = qty;
            this.containerNum = containerNum;
            this.emptyall = emptyall;
            this.item = item;
            this.site = site;
            this.lot = lot;
            this.whse = whse;
            this.loc = loc;
            this.addItemLocRecord = addItemLocRecord;
            this.allowIfCycleCountExists = allowIfCycleCountExists;
            this.addPermanentItemWhseLocLink = addPermanentItemWhseLocLink;
            this.SerialsSessionID = SerialsSessionID;
            this.userInitial = userInitial;

        }
        public void initialize()
        {
            //Local variables initialization
            SerialList = null;
            itemLotTracked = false;
            itemSerialTracked = false;
            errorMessage = "";
            RowPointer = "";
            RecordDate = "";
            userInitial = "";
        }

        public bool formatInputs()
        {
            if (!((containerNum == null) || containerNum.Trim().Equals("")))
            {
                containerNum = formatDataByIDOAndPropertyName("SLContainers", "ContainerNum", containerNum);

            }
            if (containerNum == null || containerNum.Trim().Equals(""))
            {
                errorMessage = "container input mandatory";
                return false;
            }

            if (emptyall.ToUpper() != "Y")
            {

                if (qty == null || qty.Trim().Equals(""))
                {
                    errorMessage = "qty input mandatory";
                    return false;
                }
                try
                {
                    if (Convert.ToDouble(qty, CultureInfo.InvariantCulture) < 0) // FTDEV-9247
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
                lot = formatDataByIDOAndPropertyName("SLLotLocs", "Lot", lot);

            }


            return true;
        }


        public bool validateInputs()
        {
            //Validate Site
            LoadCollectionResponseData responseData = GetSiteDetails(site);
            if (responseData.PropertyList.Count == 0)
            {
                errorMessage = "Site Details Not Found";
                return false;
            }



            //Container Field
            if (this.containerNum != null && !(this.containerNum.Trim().Equals("")))
            {
                if (ValidateQtyForRcvIntoContainerSp() == false)
                {
                    return false;
                }

            }
            if (emptyall.ToUpper() != "Y")
            {

                if (ValidateContainerExist(this.containerNum, this.whse, this.loc, containerLocMismatch, out errorMessage) == true)
                {
                    if (containerLocMismatch)
                    {
                        errorMessage = " Container Location missmatch ";
                        return false;
                    }
                }

                //Qty Checks
                try
                {

                    if (Convert.ToDecimal(qty, CultureInfo.InvariantCulture) < 0) // FTDEV-9247
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


                //Check Item Details
                responseData = GetItemDetails(formatItem(item));
                if (responseData.PropertyList.Count == 0)
                {
                    errorMessage = "Item Details Not Found";
                    return false;
                }

                itemLotTracked = GetBool(responseData[0, "LotTracked"].ToString());
                itemSerialTracked = GetBool(responseData[0, "SerialTracked"].ToString());

                //Lot Code Checks

                if (itemLotTracked == true)
                {
                    if (lot == null || lot.Trim().Equals(""))
                    {
                        errorMessage = "Item is lot controlled, Lot Input is Mandatory";
                        return false;
                    }
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

            if (PerformEmptyContainer() == false)
            {
                infobar = errorMessage;
                return 3;
            }
            return 0;
        }


        private bool PerformEmptyContainer()
        {
            try
            {
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


            if (emptyall.ToUpper() == "Y")
            {
                // Empty complete Container
                object[] deleteContainerInput = new object[] { containerNum, 
                                                       
                                                      "" };

                InvokeResponseData deleteResponseDataStep = this.InvokeIDO("SLContainers", "ContainerDeleteSp", deleteContainerInput);
                if (!(invokeResponseDataStep1.ReturnValue.Equals("0")))
                {
                    errorMessage = deleteResponseDataStep.Parameters.ElementAt(1).ToString();
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                if (GetContainerItemDetails() == true)
                {

                    containerItemQty = containerItemQty - Convert.ToDouble(qty, CultureInfo.InvariantCulture); // FTDEV-9247
                    UpdateCollectionRequestData updateContRequestData = new UpdateCollectionRequestData();
                    updateContRequestData.IDOName = "SLContainerItems";
                    updateContRequestData.RefreshAfterUpdate = true;
                    IDOUpdateItem SlContItem = new IDOUpdateItem();
                    if (containerItemQty==0)                   
                        SlContItem.Action = UpdateAction.Delete;
                      else
                        SlContItem.Action = UpdateAction.Update;                    
                    SlContItem.ItemID = this._itemId;
                    SlContItem.ItemNumber = 0;
                    SlContItem.Properties.Add("RowPointer", RowPointer, false);
                    SlContItem.Properties.Add("RecordDate", RecordDate, false);
                    SlContItem.Properties.Add("InWorkflow", "", false);
                    SlContItem.Properties.Add("NoteExistsFlag", "", false);
                    SlContItem.Properties.Add("_ItemWarnings", "", false);
                    SlContItem.Properties.Add("ItemLotTracked", GetIDOInputBoolValue(itemLotTracked), true);
                    SlContItem.Properties.Add("ContainerNum", containerNum, false);
                    SlContItem.Properties.Add("Item", item, true);
                    SlContItem.Properties.Add("Lot", lot, true);
                    SlContItem.Properties.Add("QtyContained", "" + containerItemQty, true);
                    SlContItem.Properties.Add("DerTotalContainedQuantity", "", false);
                    SlContItem.Properties.Add("DerQtyOnHand", "", false);
                    //SlContItem.Properties.Add("ItemUM", um, false);
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
                                LoadCollectionResponseData responseData = GetSerialInfobyFilter(whse, item, loc, formatDataByIDOAndPropertyName("SLSerials", "SerNum", SerialList.ElementAt(i).ToString()), lot, false);
                                serialItem.ItemNumber = i;                              
                                serialItem.Properties.Add("SerNum", formatDataByIDOAndPropertyName("SLSerials", "SerNum", SerialList.ElementAt(i).ToString()), false);
                                serialItem.Properties.Add("InWorkflow", "", false);
                               serialItem.Properties.Add("Item", item, false);
                                serialItem.Properties.Add("Lot", lot, false);
                                serialItem.Properties.Add("NoteExistsFlag", "", false);
                                serialItem.Properties.Add("RowPointer", responseData[0, "RowPointer"].ToString().ToUpper(), false);
                                serialItem.Properties.Add("RecordDate", responseData[0, "RecordDate"].ToString().ToUpper(), false);
                                serialItem.Properties.Add("_ItemWarnings", "", false);
                                serialItem.Properties.Add("UbSelect", "0", true);
                                serialItem.Properties.Add("ContainerNum", "", true);
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
                    catch (Exception e)
                    {
                         //Console.WriteLine("Exception " + e.Message);
                        errorMessage = e.Message;
                        return false;
                    }
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
            if (this.lot != null && !(this.lot.Trim().Equals("")))
            {
                filterString = filterString + " AND Lot = '" + lot + "'";
            }

            requestData.Filter = filterString;
            requestData.RecordCap = 0;
            requestData.OrderBy = "Item";

            ContainerItemsResponseData = ExcuteQueryRequest(requestData);
            if (ContainerItemsResponseData != null && ContainerItemsResponseData.Items.Count > 0)
            {
                this.RowPointer = ContainerItemsResponseData[0, "RowPointer"].Value;
                this.RecordDate = ContainerItemsResponseData[0, "RecordDate"].Value;
                this._itemId = ContainerItemsResponseData.Items[0].ItemID;

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


        public LoadCollectionResponseData GetSerialInfobyFilter(string whse, string item, string loc, string serial, string lot, bool excludePreassignedSN = false)  //added optional parameter excludePreassignedSN to allow us to implement preassigned serial numbers.  jh:20121220
        {
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLSerials";
            requestData.PropertyList.SetProperties("SerNum, Stat,RowPointer,RecordDate");
            //string filterString = "SerNum = '" + serial + "' and Item ='" + item + "' and whse ='" + whse + "' and Loc ='" + loc + "'";            
            string filterString = "SerNum = '" + IDOStrFormat(serial) + "' "; //MSF165152 added formating to handle special charcters JH:20130717

            if (item != null && !(item.Trim().Equals("")))
            {
                filterString += "  and Item ='" + IDOStrFormat(item) + "' "; //MSF165152 added formating to handle special charcters JH:20130717
            }

            if (whse != null && !(whse.Trim().Equals("")))
            {
                filterString += "  and Whse ='" + IDOStrFormat(whse) + "'";//MSF165152 added formating to handle special charcters JH:20130717
            }

            if (loc != null && !(loc.Trim().Equals("")))
            {
                filterString += " and Loc ='" + IDOStrFormat(loc) + "'";//MSF165152 added formating to handle special charcters JH:20130717
            }
            if (lot != null && !(lot.Trim().Equals("")))
            {
                filterString += " and Lot ='" + IDOStrFormat(lot) + "'";//MSF165152 added formating to handle special charcters JH:20130717
            }
            if (excludePreassignedSN) //filter for preassigned serials JH:20121226
            {
                filterString += " and Stat != 'P' ";
            }
            requestData.Filter = filterString;
            requestData.RecordCap = 0;
            requestData.OrderBy = "SerNum";
             //Console.WriteLine("In GetSerialInfo method, " + filterString);

            LoadCollectionResponseData responseData = ExcuteQueryRequest(requestData);
            if (responseData != null)
            {
                 //Console.WriteLine("Response Data Item Count =, " + responseData.Items.Count);
            }
            if (responseData != null && responseData.Items.Count == 0)
            {
                //filterString = "SerNum = '" + serial.Trim() + "' and Item ='" + item + "' and whse ='" + whse + "' and Loc ='" + loc + "'";

                filterString = "SerNum = '" + serial.Trim() + "' and Item ='" + IDOStrFormat(item) + "'";//MSF165152 added formating to handle special charcters JH:20130717

                if (whse != null && !(whse.Trim().Equals("")))
                {
                    filterString += "  and Whse ='" + IDOStrFormat(whse) + "'"; //MSF165152 added formating to handle special charcters JH:20130717
                }

                if (loc != null && !(loc.Trim().Equals("")))
                {
                    filterString += " and Loc ='" + IDOStrFormat(loc) + "'";//MSF165152 added formating to handle special charcters JH:20130717
                }

                if (lot != null && !(lot.Trim().Equals("")))
                {
                    filterString += " and Lot ='" + IDOStrFormat(lot) + "'";//MSF165152 added formating to handle special charcters JH:20130717
                }
                if (excludePreassignedSN)  //filter for preassigned serials JH:20121226
                {
                    filterString += " and Stat != 'P' ";
                }
                requestData.Filter = filterString;
                requestData.RecordCap = 0;
                requestData.OrderBy = "SerNum";
                 //Console.WriteLine("In GetSerialInfo method, " + filterString);

                responseData = ExcuteQueryRequest(requestData);
            }
            return responseData;

        }


    }



}
