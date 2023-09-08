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
    class AdjustmentUpdate : InventoryUtilities
    {
        private string qty = "";
        private string item = "";
        private string site = "";
        private string whse = "";
        private string loc = "";
        private string uom = "";
        private string reasonCode = "";

        private bool addItemLocRecord = true;
        private bool allowIfCycleCountExists = false;
        private bool addPermanentItemWhseLocLink = false;
        private string documentNumber = "";
        private string userInitial = "";

        //Local Varialbles

        private bool itemLotTracked = false;
        private bool itemSerialTracked = false;
        private bool insertItemLocRecord = false;
        private InvokeResponseData reasonCodeResData = null;
        private double qtyOnHand = 0;
        private string errorMessage = "";


        public AdjustmentUpdate(string qty, string item, string site, string whse,
                                     string loc, string uom, string reasonCode, bool addItemLocRecord,
                                     bool allowIfCycleCountExists, bool addPermanentItemWhseLocLink, string documentNumber, string userInitial)
        {
            initialize();
            this.qty = qty;
            this.item = item;
            this.site = site;
            this.whse = whse;
            this.loc = loc;
            this.uom = uom;
            this.reasonCode = reasonCode;
            this.addItemLocRecord = addItemLocRecord;
            this.allowIfCycleCountExists = allowIfCycleCountExists;
            this.addPermanentItemWhseLocLink = addPermanentItemWhseLocLink;
            this.documentNumber = documentNumber;
            this.userInitial = userInitial;
        }


        public void initialize()
        {
            //Input variables initialization
            site = "";
            whse = "";
            item = "";

            qty = "";
            loc = "";
            uom = "";
            reasonCode = "";
            addItemLocRecord = true;
            addPermanentItemWhseLocLink = false;
            allowIfCycleCountExists = false;
            documentNumber = "";

            //Local variables initialization
            itemLotTracked = false;
            itemSerialTracked = false;
            insertItemLocRecord = false;
            qtyOnHand = 0;
            errorMessage = "";
            //set taxfreeimports- any module that uses tax free should set it on the initilize -read from the ERP

            //ReadERPParameters(); //load the ERP parameters.  So we can use the taxfree parameter

        }

        public bool formatInputs()
        {
            if (qty == null || qty.Trim().Equals(""))
            {
                errorMessage = "qty input mandatory";
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

            itemLotTracked = GetBool(responseData[0, "LotTracked"].Value);
            itemSerialTracked = GetBool(responseData[0, "SerialTracked"].Value);

            if (itemLotTracked == true)
            {
                errorMessage = "Item : " + item + " is Lot Tracked, Adjusment not allowed";
                return false;
            }

            if (itemSerialTracked == true)
            {
                errorMessage = "Item : " + item + " is Serial Tracked, Adjusment not allowed";
                return false;
            }

            if (validWhseItemRecordExists(whse, item, allowIfCycleCountExists, out errorMessage) == false)
            {
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
                    errorMessage = site + " / " + whse + " / " + item + " / " + loc + " combination does not exists, Adjustment not allowed";
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

            //Reason Code Checks

            if (checkAdjReasonCodes() == false)
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

        private bool PerformAdjustment()
        {
            try { 
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



            if (this.insertItemLocRecord == true)
            {
                if (addLocItemRecord(item, whse, site, loc, addPermanentItemWhseLocLink, out errorMessage) == false)
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
                                                      "",
                                                      qty,
                                                      0,
                                                      "adj",
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

            //Actual Adjustment.
            object[] adjustmentInputs = new object[] { "A",
                                                        //System.DateTime.Now, 
                                                        System.DateTime.Now.ToString(WMShortDatePattern), //MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128
                                                        reasonCodeResData.Parameters.ElementAt(3).ToString(),
                                                        reasonCodeResData.Parameters.ElementAt(4).ToString(),
                                                        reasonCodeResData.Parameters.ElementAt(5).ToString(),
                                                        reasonCodeResData.Parameters.ElementAt(6).ToString(),
                                                        reasonCodeResData.Parameters.ElementAt(7).ToString(),
                                                        qty,
                                                        whse,
                                                        item,
                                                        loc,
                                                        "",
                                                        site,
                                                        site,
                                                        reasonCode,
                                                        "",
                                                        0,
                                                        0,
                                                        0,
                                                        "I",
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
                                                        this.documentNumber,
                                                        "",
                                                        0,
                                                        0,
                                                        "",
                                                        ""
                                                        };

            InvokeResponseData invokeResponseDataStep3 = this.Context.Commands.Invoke("SLItemLocs", "PostAdjTransWrapperSp", adjustmentInputs);
            if (!(invokeResponseDataStep3.ReturnValue.Equals("0")))
            {
                errorMessage = "Adjustment process failed";
                return false;
            }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
            return true;
        }
        
        public bool checkAdjReasonCodes()
        {
            LoadCollectionResponseData reasonValidateResponseData = GetReasonCodeDetails(reasonCode, "INV ADJUST");
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
                                                      "INV ADJUST",
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
                                                      "INV ADJUST",
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

    }
}