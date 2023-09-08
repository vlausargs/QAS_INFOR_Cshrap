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

    class PSScrapUpdate : ShopFloorUtilities
    {


        #region InputVariables

        //Input Variables.
        private string item = "";
        private string prodschedule = "";
        private string workcenter = "";
        private string operation = "";
        private string site = "";
        private string whse = "";
        private string qty = "";
        private string uom = "";
        private string employee = "";
        private string shift = "";
        private string reasonCode = "";

        private bool allowIfCycleCountExists = false;
        #endregion

        #region LocalVariables

        //Local Varialbles

        private bool itemLotTracked = false;
        private bool itemSerialTracked = false;
        private InvokeResponseData ItemResponseData = null;
        private string GUID = "";
        private string jobTransNum = "";
        private string tcoby = "";
        private string errorMessage = "";
        private string SessionID = "";


        #endregion



        public PSScrapUpdate(string item, string prodschedule, string workcenter,
                                      string operation, string site, string whse, string qty, string uom, string employee,
                                      string shift, string reasonCode,
                                      string SessionID)
        {
            initialize();
            this.item = item;
            this.prodschedule = prodschedule;
            this.workcenter = workcenter;
            this.operation = operation;
            this.site = site;
            this.whse = whse;
            this.qty = qty;
            this.uom = uom;
            this.employee = employee;
            this.shift = shift;
            this.reasonCode = reasonCode;
            this.SessionID = SessionID;

            this.SessionID = SessionID;

        }

        public void initialize()
        {
            //Input variables initialization
            item = "";
            prodschedule = "";
            workcenter = "";
            operation = "";
            site = "";
            whse = "";

            qty = "";
            uom = "";
            employee = "";
            shift = "";
            reasonCode = "";
            allowIfCycleCountExists = false;


            //Local variables initialization
            itemLotTracked = false;
            itemSerialTracked = false;
            ItemResponseData = null;
            GUID = "";
            jobTransNum = "";
            tcoby = "";

        }
        public bool formatInputs()
        {


            if (item == null || item.Trim().Equals(""))
            {
                errorMessage = "item input mandatory";
                return false;
            }


            if (prodschedule == null || prodschedule.Trim().Equals(""))
            {
                errorMessage = "schedule input mandatory";
                return false;
            }


            if (workcenter == null || workcenter.Trim().Equals(""))
            {
                errorMessage = "workcenter input mandatory";
                return false;
            }


            if (operation == null || operation.Trim().Equals(""))
            {
                errorMessage = "operation input mandatory";
                return false;
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


            if (uom == null || uom.Trim().Equals(""))
            {
                errorMessage = "uom input mandatory";
                return false;
            }

            employee = formatDataByIDOAndPropertyName("SLEmployees", "EmpNum", employee);
            shift = formatDataByIDOAndPropertyName("SLShifts", "Shift", shift);
            return true;

        }
        public bool validateInputs()
        {

            string itemUM = "";
            //Check Item Details
            LoadCollectionResponseData responseData = GetItemDetails(formatItem(item));

            if (responseData.PropertyList.Count == 0)
            {
                errorMessage = "Item Details Not Found";
                return false;
            }

            itemLotTracked = GetBool(GetPropertyValue(responseData.PropertyList, responseData.Items, "LotTracked"));
            itemSerialTracked = GetBool(GetPropertyValue(responseData.PropertyList, responseData.Items, "SerialTracked"));
            itemUM = GetPropertyValue(responseData.PropertyList, responseData.Items, "UM");

            ItemResponseData = PSVal10Sp(item, "0");

            if (!ItemResponseData.ReturnValue.Equals("0"))
            {
                errorMessage = ItemResponseData.Parameters.ElementAt(11).ToString();
                return false;
            }

            //Qty Field Exit

            //UOM Checks
            string convertedQty = GetItemConvertedQtyToBaseUnit(item, qty, uom, "", out errorMessage);
            if (convertedQty == null)
            {
                return false;
            }
            qty = convertedQty;
            uom = itemUM;

            if (ValidateQty() == false)
            {
                return false;
            }

            //Schedule Checks

            InvokeResponseData invokeResponseData = PSVal3Sp(prodschedule, item, "0",
                                                             ItemResponseData.Parameters.ElementAt(6).ToString(),
                                                             ItemResponseData.Parameters.ElementAt(9).ToString(),
                                                             ItemResponseData.Parameters.ElementAt(10).ToString());

            if (!invokeResponseData.ReturnValue.Equals("0"))
            {
                errorMessage = invokeResponseData.Parameters.ElementAt(8).ToString();
                return false;
            }

            //Reason Code Checks

            LoadCollectionResponseData reasonCodeResponseData = GetReasonCodeDetails(reasonCode, "MFG SCRAP");
            if (reasonCodeResponseData.Items.Count == 0)
            {
                errorMessage = "Reason Code Details Not Found";
                return false;
            }

            //Work Center Checks

            invokeResponseData = PSVal4Sp(prodschedule, item, workcenter, "0");
            if (!(invokeResponseData.ReturnValue.Equals("0")))
            {
                errorMessage = invokeResponseData.Parameters.ElementAt(5).ToString();
                return false;
            }

            //Operation Field checks

            invokeResponseData = PSVal5Sp(prodschedule, item, operation, "0", workcenter);
            if (!(invokeResponseData.ReturnValue.Equals("0")))
            {
                errorMessage = invokeResponseData.Parameters.ElementAt(5).ToString();
                return false;
            }


            //Validate Site
            responseData = GetSiteDetails(site);
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
                //errorMessage = "Physical Inventory is active in Warehouse : {whse} , Adjustment not allowed";
                errorMessage = constructErrorMessage("Physical Inventory is active in Warehouse : {whse} , Adjustment not allowed", "SLPScrapVXXXXX01", substitutorDictionary);
                return false;
            }

            if (validWhseItemRecordExists(whse, item, allowIfCycleCountExists, out errorMessage) == false)
            {
                return false;
            }


            //Need to add check for Obsolte and Slow moving items.


            //Employee Validation

            responseData = GetEmployeeDetails(employee);
            if (responseData.Items.Count == 0)
            {
                errorMessage = "Employee Details Not found";
                return false;
            }

            //Validate Shift
            if (!shift.Trim().Equals(""))     //  Shift is not a madatory.
            {
                LoadCollectionResponseData shiftResponseData = GetShiftDetails(shift);
                if (shiftResponseData.Items.Count == 0)
                {
                    errorMessage = "Shift Details Not Found";
                    return false;
                }
            }

            return true;
        }

        public int PerformUpdate(out string infobar)
        {
            infobar = "";

            //1 Initialize variables

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

            if (performJobReceipt(out infobar) == false)
            {
                return 3;
            }
            return 0;

        }
        private bool performJobReceipt(out string infobar)
        {
                infobar = "";
                //1 Generate GUID

                if (GenerateGUID(ref GUID, out infobar) == false)
                {
                    errorMessage = "Problem generating GUID";
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
                    infobar = invokeResponseDataStep1.Parameters.ElementAt(3).ToString();
                    return false;
                }

                if (PSScrapTransSp() == false)
                {
                    infobar = errorMessage;
                    return false;
                }

                if (PSScrapTransPost() == false)
                {
                    infobar = errorMessage;
                    return false;
                }              

            return true;
        }



        #region private methods

        private bool ValidateQty()
        {
            InvokeResponseData responseData = PsQtyValidSp(qty, item, "0", "1");
            if (!responseData.ReturnValue.Equals("0"))
            {
                errorMessage = responseData.Parameters.ElementAt(4).ToString();
                return false;
            }
            return true;
        }

        private bool PSScrapTransSp()
        {
            object[] inputValues = new object[]{
                                                item,
                                                qty,
                                                System.DateTime.Now.ToString(WMShortDatePattern), //MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128
                                                prodschedule,
                                                reasonCode,
                                                employee,
                                                operation,
                                                workcenter,
                                                shift,
                                                GUID,
                                                "",
                                                "",
                                                "",
                                                ""
                                                };

            InvokeResponseData responseData = InvokeIDO("SLPsitems", "PSScrapTransSp", inputValues);

            if (!responseData.ReturnValue.Equals("0"))
            {
                errorMessage = responseData.Parameters.ElementAt(12).ToString();
                return false;
            }

            jobTransNum = responseData.Parameters.ElementAt(10).ToString();
            tcoby = responseData.Parameters.ElementAt(11).ToString();
            return true;
        }

        private bool PSScrapTransPost()
        {
            object[] inputValues = new object[]{
                                                GUID,
                                                jobTransNum,
                                                tcoby,
                                                ""
                                                };

            InvokeResponseData responseData = InvokeIDO("SLJobTrans", "PSScrapTransPost", inputValues);

            if (!responseData.ReturnValue.Equals("0"))
            {
                errorMessage = responseData.Parameters.ElementAt(3).ToString();
                return false;
            }

            return true;
        }

        #endregion




    }
}