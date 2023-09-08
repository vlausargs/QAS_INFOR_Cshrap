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
    class WorkCenterMaterialIssueUpdate : ShopFloorUtilities 
    {
        //Input Variables.
        private string workcenter = "";
        private string employee = "";
        private string qty = "";
        private string item = "";
        private string site = "";
        private string whse = "";
        private string loc = "";
        private string uom = "";
        private string lot = "";
        private bool allowNegInventory = false;

        private bool allowIfCycleCountExists = false;
        private bool addPermanentItemWhseLocLink = false;
        private string containerNum = "";
        private string docNum = "";
        //Local Varialbles

        private bool itemLotTracked = false;
        private bool itemSerialTracked = false;
        private bool insertItemLocRecord = false;
        private double qtyOnHand = 0;
        private InvokeResponseData ItemCostResponseData = null;
        private InvokeResponseData SerialPrefixResponseData = null;
       // private bool serialNeedToBeFormated = false;
        private List<string> SerialList = null;
        private string errorMessage = "";
        private string SerialsAsXML = "";
        private string conversionFactor = "1.0";

        public WorkCenterMaterialIssueUpdate(string workcenter, string employee, string qty, string item, string site,
                                     string whse, string loc, string lot, string uom,
                                     bool allowNegInventory, bool allowIfCycleCountExists,
                                     bool addPermanentItemWhseLocLink,string SerialsAsXML,string containerNum,string docNum)
        {
            initialize();
            this.workcenter = workcenter;
            this.employee = employee;
            this.qty = qty;
            this.item   = item;
            this.qty = qty;
            this.site = site;
            
            this.whse = whse;
            this.loc = loc;
            this.lot = lot;
            this.uom = uom;
            this.allowNegInventory = allowNegInventory;
            this.allowIfCycleCountExists = allowIfCycleCountExists;
            this.addPermanentItemWhseLocLink = addPermanentItemWhseLocLink;
            this.SerialsAsXML = SerialsAsXML;
            this.containerNum = containerNum;
            this.docNum = docNum;
        }
        
        public void initialize()
        {            
            //Input variables initialization
            workcenter = "";
            employee = "";
            site = "";
            whse = "";
            item = "";

            qty = "";
            loc = "";
            lot = "";
            uom = "";
            allowNegInventory = false;

            addPermanentItemWhseLocLink = false;
            allowIfCycleCountExists = false;
            containerNum = "";
            docNum = "";
            //Local variables initialization
            itemLotTracked = false;
            itemSerialTracked = false;
            insertItemLocRecord = false;
            qtyOnHand = 0;
            ItemCostResponseData = null;
            SerialPrefixResponseData = null;
            errorMessage = "";

        }

        public bool formatInputs()
        {
            

            if (workcenter == null || workcenter.Trim().Equals(""))
            {
                errorMessage =  "workcenter input mandatory";
                return false;
            }

            employee = formatDataByIDOAndPropertyName("SLEmployees", "EmpNum",employee);
            //if (employee == null || employee.Trim().Equals(""))
            //{
            //    errorMessage ="employee input mandatory" ;
            //    return false;
            //}

            if (qty == null || qty.Trim().Equals(""))
            {
                errorMessage =  "qty input mandatory";
                return false;
            }
            try
            {
                //if (Convert.ToDouble(qty, CultureInfo.InvariantCulture) <= 0) // FTDEV-9247
                //{
                //    errorMessage =  "Quantity should be greater than 0";
                //    return false;
                //}
            }
            catch (InvalidCastException)
            {
                errorMessage =  "Invalid Quantity Input";
                return false;
            }
    
             item = formatDataByIDOAndPropertyName("SLRsvdInvs", "Item", item);
            if (item == null || item.Trim().Equals(""))
            {
                errorMessage =  "item input mandatory";
                return false;
            }

             
            if (site == null || site.Trim().Equals(""))
            {
                errorMessage =  "site input mandatory";
                return false;
            }

            whse = formatDataByIDOAndPropertyName("SLRsvdInvs", "Whse", whse);
            if (whse == null || whse.Trim().Equals(""))
            {
                errorMessage =  "whse input mandatory";
                return false;
            }

            loc = formatDataByIDOAndPropertyName("SLRsvdInvs", "Loc", loc);
            if (loc == null || loc.Trim().Equals(""))
            {
                errorMessage =  "loc input mandatory";
                return false;
            }

             
            if (uom == null || uom.Trim().Equals(""))
            {
                errorMessage =  "uom input mandatory";
                return false;
            }

            lot = formatDataByIDOAndPropertyName("SLLotLocs", "Lot", lot);


      /*     
          

            if (allowNegInventory.Trim().Equals("yes"))
            {
                allowNegInventory = true;
            }
            else
            {
                allowNegInventory = false;
            }
            */
        /*    if (this.itemSerialTracked == true)
            {
                if (updateRequest.GetNestedField() != null)
                {
                    List<Field> serialFieldsList = updateRequest.GetNestedField().FieldList;

                    if (serialFieldsList != null)
                    {
                        if (serialFieldsList.Count == 0)
                        {
                            errorMessage =  "Item is Serial Tracked, Serial Inputs Mandatory.";
                            return false;
                        }
                    }
                    else
                    {
                        errorMessage =  "Item is Serial Tracked, Serial Inputs Mandatory.";
                        return false;
                    }
                }
                else
                {
                    errorMessage =  "Item is Serial Tracked, Serial Inputs Mandatory.";
                    return false;
                }
            } */

            return true;
        }
        public bool validateInputs()
        {
            //Employee Validation
            if (this.employee != null && !(this.employee.Trim().Equals("")))
            {
                if (ValidateEmployee(employee, out errorMessage) == false)
                {
                    return false;
                }
            }
            if (ValidateWorkCenter(workcenter,out errorMessage) == false)
            {
                return false;
            }

            //Validate Site
            LoadCollectionResponseData responseData = GetSiteDetails(site);
            if (responseData.PropertyList.Count == 0)
            {
                errorMessage =  "Site Details Not Found";
                return false;
            }

            //Check Warehouse
            responseData = GetWhseDetailsBySite(whse, site);
            if (responseData.PropertyList.Count == 0)
            {
                errorMessage =  "Whse Details Not Found";
                return false;
            }

            string physicalInventoryFlag = GetPropertyValue(responseData.PropertyList, responseData.Items, "PhyInvFlg");
            if (physicalInventoryFlag == null)
            {
                errorMessage =  "Error Reading WhseAll record";
                return false;
            }

            if (!(physicalInventoryFlag.Equals("0")))
            {
                IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                substitutorDictionary.Add("whse", whse);
                errorMessage =  "Physical Inventory is active in Warehouse : {whse}, Adjustment not allowed";
                return false;
            }

            //Check Item Details
            responseData = GetItemDetails(formatItem(item));
            if (responseData.PropertyList.Count == 0)
            {
                errorMessage =  "Item Details Not Found";
                return false;
            }

            itemLotTracked = GetBool(GetPropertyValue(responseData.PropertyList, responseData.Items, "LotTracked"));
            itemSerialTracked = GetBool(GetPropertyValue(responseData.PropertyList, responseData.Items, "SerialTracked"));

            if (validWhseItemRecordExists(whse, item, allowIfCycleCountExists, out errorMessage) == false)
            {
                return false;
            }

            if (GetItemCosts() == false)
            {
                return false;
            }

            if (WcmatlQtyValidSp() == false)
            {
                return false;
            }

            //Check Location
            responseData = GetLocationDetails(loc);
            qtyOnHand = 0;
          
                GetItemLocRecord(site, whse, item, loc, ref qtyOnHand);

                if (checkLocationDetails(item, whse, site, loc, out errorMessage) == false)
                {
                if (allowNegInventory == false)
                {
                    IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                    substitutorDictionary.Add("site", site);
                    substitutorDictionary.Add("whse", whse);
                    substitutorDictionary.Add("item", item);
                    substitutorDictionary.Add("loc", loc);
                    errorMessage = "{site} / {whse} / {item} / {loc} combination does not exists, Transaction not allowed";
                    return false;
                }
                else
                {
                    insertItemLocRecord = true;
                }
            }
              
            if (allowNegInventory == false)
            {
                if (SlocValidSp() == false)
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

                //  Check seril count match with transaction qty

                if (itemSerialTracked == true)
                {
                    int transQty = 0;
                    try
                    {
                        transQty = Math.Abs(Convert.ToInt32(Double.Parse(qty, CultureInfo.InvariantCulture), CultureInfo.InvariantCulture)); // FTDEV-9247
                    }
                    catch
                    {

                    }
                    if (transQty != SerialList.Count)
                    {
                        errorMessage = "Serials count does not match with transaction qty";
                        return false;
                    }
                }
            }

            return true;
        }

        public int PerformUpdate(out string infobar)
        {
           // string returnString = "";
            infobar = "";
            if (SerialsAsXML != null && !(SerialsAsXML.Equals("")))
            {
                SerialList = this.GetSerialList(this.SerialsAsXML);
            }
            
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
            {//perfomAdjustment has access to the out message
                infobar = errorMessage;
                infobar = formatResponse(infobar);
                return 3;

            }
            
            return 0;
        }

        private Boolean performAdjustment()
        {
         
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
                errorMessage =  invokeResponseDataStep1.Parameters.ElementAt(3).ToString();
                return false;
            }



            if (this.insertItemLocRecord == true)
            {
                if (addLocItemRecord(item, whse, site, loc, addPermanentItemWhseLocLink, out errorMessage) == false)
                {
                    return false;
                }
            }

            if (GetItemSerialPrefixSp() == false)
            {
                return false;
            }
            // Get Converted Quantity for Inventory reduction
            string convertedQty = qty;
            object[] uomConversionValues = new object[] { item,
                                                      qty, 
                                                      uom, 
                                                      1, 
                                                      qty, 
                                                      errorMessage};

            InvokeResponseData invokeUomResponseDataStep = this.Context.Commands.Invoke("SLWcs", "WcUMValidSp", uomConversionValues);
            if (!(invokeUomResponseDataStep.ReturnValue.Equals("0")))
            {
                errorMessage = invokeUomResponseDataStep.Parameters.ElementAt(5).ToString();
                return false;
            }
            else
            {
                convertedQty = invokeUomResponseDataStep.Parameters.ElementAt(4).ToString();
                conversionFactor = invokeUomResponseDataStep.Parameters.ElementAt(3).ToString(); 
            }

            // Get Converted Quantity for Inventory reduction
             
            object[] quantityConversionValues = new object[] { 
                                                      qty,
                                                      item,
                                                      uom, 
                                                      "", 
                                                      "", 
                                                      errorMessage};

            InvokeResponseData invokeQtyConvResponseDataStep = this.Context.Commands.Invoke("SLWcs", "WcmatlQtyValidSp", quantityConversionValues);
            if (!(invokeQtyConvResponseDataStep.ReturnValue.Equals("0")))
            {
                errorMessage = invokeQtyConvResponseDataStep.Parameters.ElementAt(5).ToString();
                return false;
            }
            

            //Delete the current Inventory
            object[] deleteInvValues = new object[] { site,
                                                      "A",
                                                      "S", 
                                                      whse, 
                                                      item, 
                                                      loc, 
                                                      lot, 
                                                     // qty, 
                                                     convertedQty,
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
                errorMessage =  invokeResponseDataStep2.Parameters.ElementAt(19).ToString();
                return false;
            }

            if (allowNegInventory == false)
            {
                if (!(invokeResponseDataStep2.Parameters.ElementAt(17).ToString().Equals("")))
                {
                    errorMessage =  invokeResponseDataStep2.Parameters.ElementAt(17).ToString();
                    return false;
                }
            }

            //Save Field values
            if (storeUpdateValues("S") == false)
            {
                return false;
            }

            //Serials Process

            //SLMSSerials.SetMethodSp - To store the values
            object[] serialsSetMethodInputs = new object[] { "SLWcs.WcmatlSp" };

            InvokeResponseData serialsSetMethodResponseData = this.Context.Commands.Invoke("SLMSSerials", "SetMethodSP", serialsSetMethodInputs);
            if (!(serialsSetMethodResponseData.ReturnValue.Equals("0")))
            {
               errorMessage=  "Transfer process failed" ;
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
                for (int i = 0; i < SerialList.Count(); i++)
                {
                    IDOUpdateItem serialItem = new IDOUpdateItem();
                    serialItem.Action = UpdateAction.Update;
                    serialItem.ItemNumber = i;
                    serialItem.Properties.Add("SerNum", formatDataByIDOAndPropertyName("SLMSSerials", "SerNum", SerialList.ElementAt(i).ToString()), false);
                    serialItem.Properties.Add("UbSelect", "1");
                    updateRequestData.Items.Add(serialItem);
                }
            }
            try
            {
                UpdateCollectionResponseData updateResponseData = this.Context.Commands.UpdateCollection(updateRequestData);
               // MessageLogging("WorkCenterMaterialIssueUpdate: " + updateResponseData.ToXml(), msgLevel.l1_information, 1200002);
            }
            catch (InvalidCastException ice) 
            {
                errorMessage = ice.Message;
                MessageLogging("WorkCenterMaterialIssueUpdate: " + errorMessage, msgLevel.l1_information, 1200002);
            
            }
            catch(Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
            //Console.WriteLine(updateResponseData.ToXml());

            //Update Field values
            if (storeUpdateValues("U") == false)
            {
                return false;
            }
            if (itemSerialTracked == true)
            {
                ClearSerailsBySessionID(SerialsAsXML);
            }
            return true;
        }


        private bool storeUpdateValues(string type)
        {
            //IaPostSetVarsSp - S(Save) process / U(Update) - setting the account details
            object[] IapostValues = new object[] { type, 
                                                   workcenter,
                                                   item,
                                                   whse,
                                                   loc,
                                                   lot,
                                                   qty,
                                                   System.DateTime.Now, // FTDEV-9247 - Date-conversion for bounced method // System.DateTime.Now.ToString(WMLongDateTimePattern),  // FTDEV-9195 - Adding Time to the date/time string passed into CSI - Untested, 
                                                   employee,
                                                   "",              //Account
                                                   "",              //Acct Unit1
                                                   "",              //Acc Unit2
                                                   "",              //Acct Unit3
                                                   "",              //Acct Unit4
                                                   ItemCostResponseData.Parameters.ElementAt(13).ToString(),
                                                   ItemCostResponseData.Parameters.ElementAt(14).ToString(),
                                                   ItemCostResponseData.Parameters.ElementAt(15).ToString(),
                                                   ItemCostResponseData.Parameters.ElementAt(16).ToString(),
                                                   ItemCostResponseData.Parameters.ElementAt(17).ToString(),
                                                   conversionFactor,
                                                   SerialPrefixResponseData.Parameters.ElementAt(2).ToString(),
                                                   "",
                                                   docNum 
                                                    };

            InvokeResponseData IaPostResponseDataStep = this.Context.Commands.Invoke("SLWcs", "WcmatlSetVarsSp", IapostValues);
            if (!(IaPostResponseDataStep.ReturnValue.Equals("0")))
            {
                errorMessage =  IaPostResponseDataStep.Parameters.ElementAt(21).ToString();
                return false;
            }

            return true;
        }

        private bool GetItemCosts()
        {
            int paramcount = 0;
            paramcount = GetIDOMethodParameterCount("SLWcs", "WcItemValidSp");
            MessageLogging("JobMaterialIssueUpdate: SLWcs.WcItemValidSp param count = " + paramcount, msgLevel.l1_information, 1200002);
            object[] inputValues = null;
            //switch (paramcount)
            //{
            //    case 18:
            //        inputValues = new object[]{
            //                                    item,
            //                                    whse,
            //                                    "",
            //                                    GetIDOInputBoolValue(itemSerialTracked),
            //                                    GetIDOInputBoolValue(itemLotTracked),
            //                                    loc,
            //                                    lot,
            //                                    uom,
            //                                    "",         //UOMConvFactor    
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",         //Matl Cost
            //                                    "",         //Labor Cost
            //                                    "",         //Fovhd Cost
            //                                    "",         //VovhdCost
            //                                    ""          //OutCost
                                                 
            //                                    };
            //        break;
            //    case 21:               
                    inputValues = new object[]{
                                                item,
                                                whse,
                                                "",
                                                GetIDOInputBoolValue(itemSerialTracked),
                                                GetIDOInputBoolValue(itemLotTracked),
                                                loc,
                                                lot,
                                                uom,
                                                "",         //UOMConvFactor    
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",         //Matl Cost
                                                "",         //Labor Cost
                                                "",         //Fovhd Cost
                                                "",         //VovhdCost
                                                "",          //OutCost
                                                "",         // TrackPeices
                                                "",         // Dimension Group
                                                ""
                                                };
                //    break;
                //case 20:
                //default:
                //    inputValues = new object[]{
                //                                item,
                //                                whse,
                //                                "",
                //                                GetIDOInputBoolValue(itemSerialTracked),
                //                                GetIDOInputBoolValue(itemLotTracked),
                //                                loc,
                //                                lot,
                //                                uom,
                //                                "",         //UOMConvFactor    
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",         //Matl Cost
                //                                "",         //Labor Cost
                //                                "",         //Fovhd Cost
                //                                "",         //VovhdCost
                //                                "",          //OutCost
                //                                "",         // TrackPeices
                //                                ""          // Dimension Group
                //                                };
                //    break;


           // }


            ItemCostResponseData = InvokeIDO("SLWcs", "WcItemValidSp", inputValues);
            if (!(ItemCostResponseData.ReturnValue.Equals("0")))
            {
                errorMessage = ItemCostResponseData.Parameters.ElementAt(12).ToString();
                return false;
            }
            return true;
        }

        private bool WcmatlQtyValidSp()
        {
            object[] inputValues = new object[]{
                                                qty,
                                                item,
                                                uom,
                                                ItemCostResponseData.Parameters.ElementAt(8).ToString(),
                                                "",     //Resultant quantity
                                                ""      //Infor Bar
                                                };
            InvokeResponseData responseData = InvokeIDO("SLWcs", "WcmatlQtyValidSp", inputValues);
            if (!(responseData.ReturnValue.Equals("0")))
            {
                errorMessage =  responseData.Parameters.ElementAt(5).ToString() ;
                return false;
            }
            qty = responseData.Parameters.ElementAt(4).ToString();
            return true;
        }

        private bool SlocValidSp()
        {
            object[] inputValues = new object[]{
                                                item,
                                                whse,
                                                loc,
                                                lot,
                                                "",
                                                "P(UbImportDocId)"
                                                };

            InvokeResponseData responseData = InvokeIDO("SLItemLocs", "SlocValidSp", inputValues);
            if (!(responseData.ReturnValue.Equals("0")))
            {
                errorMessage =  responseData.Parameters.ElementAt(4).ToString() ;
                return false;
            }
            return true;

        }

        private bool GetItemSerialPrefixSp()
        {
            object[] inputValues = new object[]{
                                                item,
                                                site,
                                                "",
                                                ""
                                                };
            SerialPrefixResponseData = InvokeIDO("SLTrnacts", "GetItemSerialPrefixSp", inputValues);
            if (!(SerialPrefixResponseData.ReturnValue.Equals("0")))
            {
                errorMessage =  SerialPrefixResponseData.Parameters.ElementAt(3).ToString() ;
                return false;
            }
            return true;

        }

    }
}
