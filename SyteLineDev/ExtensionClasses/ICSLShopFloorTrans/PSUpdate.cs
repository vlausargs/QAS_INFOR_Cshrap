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

    class PSUpdate : ShopFloorUtilities
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
        private string loc = "";
        private string uom = "";
        private string lot = "";
        private string employee = "";
        private string shift = "";
        private string vendorLot = "";
        private bool generateSerials = false;
        private bool generateLot = false;
        private string LotMfgDate = string.Empty;
        private string LotExpDate = string.Empty;
        private string LotTrxRestrictCode = string.Empty;
        private string SerialMfgDate = string.Empty;
        private string SerialExpDate = string.Empty;
        private string SerialTrxRestrictCode = string.Empty;

        private bool addItemLocRecord = true;
        private bool allowIfCycleCountExists = false;
        private bool addPermanentItemWhseLocLink = false;
        private string SerialsSessionID = "";

        private string qtyRej = "0";
        private string reasonCode = "";
        private string containerNum = "";
        private string docNum = "";

        #endregion

        #region LocalVariables

        //Local Varialbles

        private bool itemLotTracked = false;
        private bool itemSerialTracked = false;
        private bool insertItemLocRecord = false;
        private InvokeResponseData ItemResponseData = null;
        private string GUID = "";
        private string serialPrefix = "";
        private string jobTransNum = "";
        private string tcoby = "0";  //this should default to zero MSF163012  JH:20130605
        private List<string> SerialList = null;
        private string errorMessage = "";
        private bool createContainerNum = false;
        private bool containerLocMismatch = false;
        private string isLastOperation = "0";   // 0 - Not last operation , 1- Last operation        
        #endregion



        public PSUpdate(string item, string prodschedule, string workcenter,
                                      string operation, string site, string whse, string qty, string uom, string loc, string lot, string employee,
                                      string shift, string vendorLot, bool generateSerials, bool generateLot, bool addItemLocRecord,
                                      bool allowIfCycleCountExists, bool addPermanentItemWhseLocLink, string qtyRej, string reasonCode, 
                                      string SerialsSessionID, string containerNum, string docNum, string LotMfgDate, string LotExpDate, 
                                      string LotTrxRestrictCode, string SerialMfgDate, string SerialExpDate, string SerialTrxRestrictCode)
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
            this.vendorLot = vendorLot;
            this.lot = lot;
            this.loc = loc;
            this.generateSerials = generateSerials;
            this.generateLot = generateLot;
            this.addItemLocRecord = addItemLocRecord;
            this.allowIfCycleCountExists = allowIfCycleCountExists;
            this.addPermanentItemWhseLocLink = addPermanentItemWhseLocLink;
            this.SerialsSessionID = SerialsSessionID;

            this.qtyRej = qtyRej;
            this.reasonCode = reasonCode;
            this.containerNum = containerNum;
            this.docNum = docNum;
            this.LotMfgDate = LotMfgDate;
            this.LotExpDate = LotExpDate;
            this.LotTrxRestrictCode = LotTrxRestrictCode;
            this.SerialMfgDate = SerialMfgDate;
            this.SerialExpDate = SerialExpDate;
            this.SerialTrxRestrictCode = SerialTrxRestrictCode;
            errorMessage = "";

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
            loc = "";
            lot = "";
            uom = "";
            employee = "";
            shift = "";
            vendorLot = "";

            addItemLocRecord = true;
            addPermanentItemWhseLocLink = false;
            allowIfCycleCountExists = false;
            qtyRej = "0";
            reasonCode = "";

            //Local variables initialization
            itemLotTracked = false;
            itemSerialTracked = false;
            insertItemLocRecord = false;
            ItemResponseData = null;
            GUID = "";
            serialPrefix = "";
            jobTransNum = "";
            tcoby = "0";  //this should be set to 0 MSF163012  JH:20130605
            docNum = "";
            LotMfgDate = string.Empty;
            LotExpDate = string.Empty;
            LotTrxRestrictCode = string.Empty;
            SerialMfgDate = string.Empty;
            SerialExpDate = string.Empty;
            SerialTrxRestrictCode = string.Empty;

        }

        public bool formatInputs()
        {
            if (!((containerNum == null) || containerNum.Trim().Equals("")))
            {
                if (IsStringContainsNumericValue(containerNum))
                    containerNum = formatDataByIDOAndPropertyName("SLContainers", "ContainerNum", containerNum);

            }

            if (item == null || item.Trim().Equals(""))
            {
                errorMessage = "Item input mandatory";
                return false;
            }

            if (prodschedule == null || prodschedule.Trim().Equals(""))
            {
                errorMessage = "Schedule input mandatory";
                return false;
            }
            
            if (workcenter == null || workcenter.Trim().Equals(""))
            {
                errorMessage = "Workcenter input mandatory";
                return false;
            }
            
            if (operation == null || operation.Trim().Equals(""))
            {
                errorMessage = "Operation input mandatory";
                return false;
            }

            InvokeResponseData invokeResponseData = PSVal5Sp(prodschedule, item, operation, "0", workcenter);
            if (!(invokeResponseData.ReturnValue.Equals("0")))
            {
                errorMessage = invokeResponseData.Parameters.ElementAt(5).ToString();
                return false;
            }
            else
            {
                isLastOperation = invokeResponseData.Parameters.ElementAt(6).ToString();
            }
            //*******// 

            if (qty == null || qty.Trim().Equals(""))
            {
                errorMessage = "Qty input mandatory";
                return false;
            }
            try
            {
                if (Convert.ToDouble(qty, CultureInfo.InvariantCulture) == 0 && Convert.ToDouble(qtyRej, CultureInfo.InvariantCulture) == 0) // FTDEV-9247
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

            if (site == null || site.Trim().Equals(""))
            {
                errorMessage = "Site input mandatory";
                return false;
            }


            if (whse == null || whse.Trim().Equals(""))
            {
                errorMessage = "Whse input mandatory";
                return false;
            }

            if (uom == null || uom.Trim().Equals(""))
            {
                errorMessage = "UOM input mandatory";
                return false;
            }

            if ((loc == null || loc.Trim().Equals("")) && isLastOperation == "1")
            {
                errorMessage = "Loc input mandatory";
                return false;
            }
            lot = formatDataByIDOAndPropertyName("SLLotLocs", "Lot", lot);
            if (!string.IsNullOrEmpty(employee))
            {
                if (IsStringContainsNumericValue(employee))
                    employee = formatDataByIDOAndPropertyName("SLEmployees", "EmpNum", employee);
            }
            shift = formatDataByIDOAndPropertyName("SLShifts", "Shift", shift);
            if (generateSerials == true)
            {
                errorMessage = "Serial Generation is not implemented yet.";
                return false;
            }
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

            ItemResponseData = PSVal10Sp(item, "1");

            if (!ItemResponseData.ReturnValue.Equals("0"))
            {
                errorMessage = ItemResponseData.Parameters.ElementAt(11).ToString();
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

            if (ValidateQty() == false)
            {
                return false;
            }

            //Schedule Checks

            InvokeResponseData invokeResponseData = PSVal3Sp(prodschedule, item, "1",
                                                             ItemResponseData.Parameters.ElementAt(6).ToString(),
                                                             ItemResponseData.Parameters.ElementAt(9).ToString(),
                                                             ItemResponseData.Parameters.ElementAt(10).ToString());

            if (!invokeResponseData.ReturnValue.Equals("0"))
            {
                errorMessage = invokeResponseData.Parameters.ElementAt(8).ToString();
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
                errorMessage = constructErrorMessage("Physical Inventory is active in Warehouse : {whse} , Adjustment not allowed", "SLPUpdateVXXXXX01", substitutorDictionary);
                return false;
            }

            if (validWhseItemRecordExists(whse, item, allowIfCycleCountExists, out errorMessage) == false)
            {
                return false;
            }


            //Need to add check for Obsolte and Slow moving items.

            if (!string.IsNullOrEmpty(containerNum) &&  !string.IsNullOrEmpty(loc))//           isLastOperation == "1")
            {
                //Check Location
                responseData = GetLocationDetails(loc);
                double qtyOnHand = 0;
                GetItemLocRecord(site, whse, item, loc, ref qtyOnHand);

                if (checkLocationDetails(item, whse, site, loc, out errorMessage) == false)
                {
                    if (addItemLocRecord == false)
                    {
                        IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                        substitutorDictionary.Add("{site}", site);
                        substitutorDictionary.Add("{whse}", whse);
                        substitutorDictionary.Add("{item}", item);
                        substitutorDictionary.Add("{loc}", loc);
                        //errorMessage = "{site} / {whse} / {item} / {loc} combination does not exists, Transfer not allowed";
                        errorMessage = constructErrorMessage("{site} / {whse} / {item} / {loc} combination does not exists, Transfer not allowed", "SLPUpdateVXXXXX02", substitutorDictionary);
                        return false;
                    }
                    else
                    {
                        insertItemLocRecord = true;
                    }
                }

                //Lot Code Checks

                if (itemLotTracked == true)
                {
                    if (string.IsNullOrEmpty(lot.Trim()))
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
                if (itemSerialTracked && !(string.IsNullOrEmpty(SerialMfgDate)) && !(string.IsNullOrEmpty(SerialExpDate)))
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
                //Container Field
               
                if (ValidateQtyForRcvIntoContainerSp(this.item, this.whse, this.loc, this.lot, this.site, out errorMessage) == false)
                        return false;

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
                //}
            }
            return true;
        }

        public int PerformUpdate(out string infobar)
        {
            infobar = "";
            if (SerialsSessionID != null && !(SerialsSessionID.Equals("")))
            {
                SerialList = this.GetSerialList(this.SerialsSessionID);
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

            if (performJobReceipt(out infobar) == false)
            {
                infobar = errorMessage;
                return 3;
            }

            try
            {
                if (qtyRej != null && !(qtyRej.Trim().Equals("")))
                {
                    if (Convert.ToDouble(qtyRej, CultureInfo.InvariantCulture) > 0) // FTDEV-9247
                    {
                        PSScrapUpdate scrapUpdate = new PSScrapUpdate(item, prodschedule, workcenter, operation,
                                                                      site, whse, qtyRej, uom, employee, shift,
                                                                      reasonCode, SerialsSessionID);
                        scrapUpdate.SetContext(this.Context);
                        string scrapUpdateInfoBar = "";
                        int scrapUpdateResponce = scrapUpdate.PerformUpdate(out scrapUpdateInfoBar);
                        if (scrapUpdateResponce > 0)
                        {
                            infobar = scrapUpdateInfoBar;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageLogging("PSUpdate: Update exception " + e.Message, msgLevel.l4_error, 1200002);
            }


            return 0;

        }
        private Boolean performJobReceipt(out string infobar)
        {
            try
            {
                infobar = "";
            //1 Generate GUID

            if (GenerateGUID(ref GUID, out errorMessage) == false)
            {
                errorMessage = "Problem generating GUID";
                return false;
            }
            //2 Get Serial Prefix
            if (GetItemSerialPrefixSp(ref serialPrefix) == false)
            {
                infobar = errorMessage;
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

            //2 Location Check
            if (this.insertItemLocRecord == true)
            {
                if (addLocItemRecord(item, whse, site, loc, addPermanentItemWhseLocLink, out errorMessage) == false)
                {
                    infobar = errorMessage;
                    return false;
                }
            }

            //3 Lot Check
            if (PerformLotSteps() == false)
            {
                infobar = errorMessage;
                return false;
            }

            //Delete InvSp
            if (ItemQtyDetlSp() == false)
            {
                infobar = errorMessage;
                return false;
            }

            // Container functionality
            if (this.createContainerNum == true)      // Create Container if it does not exist
            {

                PerformCreateContainer(containerNum, whse, loc, out errorMessage);
            }

            //4 Set Vars
            if (PSSetVarsSp("S") == false)
            {
                infobar = errorMessage;
                return false;
            }

            //SLMSSerials.SetMethodSp - To store the values
            object[] serialsMethod = new object[] { "SLPsitems.PSCmplTransSp" };

            InvokeResponseData invokeResponseDataStep2 = this.Context.Commands.Invoke("SLSerials", "SetMethodSP", serialsMethod);
            if (!(invokeResponseDataStep2.ReturnValue.Equals("0")))
            {
                infobar = "Transaction process failed";
                return false;
            }

            //Serials
            UpdateCollectionRequestData updateRequestData = new UpdateCollectionRequestData();
            updateRequestData.IDOName = "SLSerials";
            updateRequestData.RefreshAfterUpdate = true;
            updateRequestData.CustomInsert = "SerialSaveSp(SerNum,'" + GUID + "',,MESSAGE,ManufacturedDate,ExpDate,TrxRestrictCode)";
            updateRequestData.CustomUpdate = "SerialSaveSp(SerNum,'" + GUID + "',,MESSAGE,ManufacturedDate,ExpDate,TrxRestrictCode)";

            if (SerialList != null)
            {
                for (int i = 0; i < SerialList.Count(); i++)
                {
                    IDOUpdateItem serialItem = new IDOUpdateItem();
                    serialItem.Action = UpdateAction.Update;
                    serialItem.ItemNumber = i;
                    serialItem.Properties.Add("SerNum", formatDataByIDOAndPropertyName("SLMSSerials", "SerNum", SerialList.ElementAt(i).ToString()), false);
                    serialItem.Properties.Add("UbSelect", "1");
                    serialItem.Properties.Add("ManufacturedDate", SerialMfgDate);
                    serialItem.Properties.Add("ExpDate", SerialExpDate);
                    serialItem.Properties.Add("TrxRestrictCode", SerialTrxRestrictCode);
                    updateRequestData.Items.Add(serialItem);
                }
            }

          
                UpdateCollectionResponseData updateResponseData = this.Context.Commands.UpdateCollection(updateRequestData);
                MessageLogging("PSUpdateUpdate: " + updateResponseData.ToXml(), msgLevel.l1_information, 1200002);
                //Console.WriteLine(updateResponseData.ToXml());
         
            if (PSCmplTransGetVarsSp() == false)
            {
                infobar = errorMessage;
                return false;
            }

            if (PSSetVarsSp("U") == false)
            {
                infobar = errorMessage;
                return false;
            }

            //In 8.03.10 and above we need to call the post or the material and labor records get left in the pending material transactions.  MSF163012  JH:20130605
            if (PSCmplTransPost() == false)
            {
                infobar = errorMessage;
                return false;
             }
            }
            catch (Exception e)
            {
                infobar = errorMessage = e.Message;
                return false;
            }
            return true;
        }



        #region private methods

        private bool GetItemSerialPrefixSp(ref string SerialPrefix)
        {
            object[] inputValues = new object[]{
                                               item,
                                               site,
                                               "",
                                               ""
                                               };

            InvokeResponseData responseData = InvokeIDO("SLTrnacts", "GetItemSerialPrefixSp", inputValues);
            if (!responseData.ReturnValue.Equals("0"))
            {
                errorMessage = responseData.Parameters.ElementAt(3).ToString();
                return false;
            }
            SerialPrefix = responseData.Parameters.ElementAt(2).ToString();
            return true;
        }

        private bool ValidateQty()
        {
            InvokeResponseData responseData = PsQtyValidSp(qty, item, "1", "0");
            if (!responseData.ReturnValue.Equals("0"))
            {
                errorMessage = responseData.Parameters.ElementAt(4).ToString();
                return false;
            }
            return true;
        }

        private bool PerformLotSteps()
        {
            if (this.itemLotTracked && isLastOperation == "1")
            {
                object[] inputValues = new object[] { whse,
                                                      item,
                                                      loc,
                                                      lot,
                                                      "rcv",
                                                      "0",
                                                      "Job.Receipt",
                                                      "",
                                                      "",
                                                      "",
                                                      "",
                                                      "",
                                                      "",
                                                      ""
                                                      };

                InvokeResponseData responseData = InvokeIDO("SLTrnacts", "SvallotSp", inputValues);
                if (!(responseData.ReturnValue.Equals("0")))
                {
                    errorMessage = responseData.Parameters.ElementAt(11).ToString();
                    return false;
                }


                if (!(responseData.Parameters.ElementAt(7).ToString().Equals("")))
                {
                    if (generateLot == false)
                    {
                        errorMessage = responseData.Parameters.ElementAt(7).ToString();
                        return false;
                    }
                    else
                    {

                        //if (performAddLot(item, lot, "0", "0", "", "1", site, out errorMessage) == false)
                        //{
                        //    return false;
                        //}
                        if (!performAddLotwithTransRestrict())
                            return false;
                    }
                }

                if (!(responseData.Parameters.ElementAt(9).ToString().Equals("")))
                {
                    errorMessage = responseData.Parameters.ElementAt(9).ToString();
                    return false;
                }
            }
            return true;
        }

        private bool PSSetVarsSp(string type)
        {
            object[] inputParams = new object[]{
                                               type,
                                               item,
                                               qty,
                                               System.DateTime.Now.ToString(WMShortDatePattern), //MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128
                                               prodschedule,
                                               employee,
                                               operation,
                                               workcenter,
                                               shift,
                                               loc,
                                               lot,
                                               serialPrefix,
                                               GUID,
                                               jobTransNum,                              //Job Trans Number
                                               tcoby,
                                               "",
                                               "",
                                               "",
                                               ((type == "U") ? "1" : "0"),   //For update this needs to be 1.  MSF163012  JH:20130605
                                               containerNum,
                                               docNum
                                               };

            InvokeResponseData responseData = InvokeIDO("SLPsitems", "PSCmplTransSetVarsSp", inputParams);
            if (!(responseData.ReturnValue.Equals("0")))
            {
                errorMessage = responseData.Parameters.ElementAt(15).ToString();
                return false;
            }

            jobTransNum = responseData.Parameters.ElementAt(13).ToString();
            tcoby = responseData.Parameters.ElementAt(14).ToString();
            return true;
        }

        private bool PSCmplTransGetVarsSp()
        {
            object[] inputValues = new object[]{
                                                jobTransNum,
                                                tcoby,
                                                "",
                                                "",
                                                ""
                                                };
            InvokeResponseData responseData = InvokeIDO("SLPsitems", "PSCmplTransGetVarsSp", inputValues);
            if (!responseData.ReturnValue.Equals("0"))
            {
                errorMessage = responseData.Parameters.ElementAt(2).ToString();
                return false;
            }
            jobTransNum = responseData.Parameters.ElementAt(0).ToString(); //set the transnum.  MSF163012  JH:20130605
            return true;
        }

        private bool PSCmplTransPost()
        {
            object[] inputValues = new object[]{
                                                GUID,
                                                jobTransNum,
                                                tcoby,
                                                "",
                                                };
            InvokeResponseData responseData = InvokeIDO("SLJobTrans", "PSCmplTransPost", inputValues);

            if ((!responseData.ReturnValue.Equals("")) & (!responseData.ReturnValue.Equals("0")))
            {
                errorMessage = responseData.Parameters.ElementAt(3).ToString();
                if (errorMessage.Trim() == "")
                {
                    errorMessage = "PSCmplTransPost failed";
                }
                return false;
            }
            return true;
        }

        private bool ItemQtyDetlSp()
        {
            //Delete the current Inventory
            object[] deleteInvValues = new object[] { site,
                                                      "",
                                                      "R",
                                                      whse,
                                                      item,
                                                      loc,
                                                      lot,
                                                      "",
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
        private bool performAddLotwithTransRestrict()
        {
            object[] inputValues;
            string LotRevision = string.Empty;
            LoadCollectionResponseData itemResponseData = this.Context.Commands.LoadCollection(new LoadCollectionRequestData("SLItems", "Revision", string.Format("Item = '{0}' AND TrackEcn=1", item), null, 1));
            if (itemResponseData != null && itemResponseData.Items.Count > 0)
            {
                LotRevision = itemResponseData[0, "Revision"].GetValue(string.Empty);
            }
            int paramcount = 0;
            paramcount = GetIDOMethodParameterCount("SLLots", "LotAddSp");
            switch (paramcount)
            {
                case 12:
                    inputValues = new object[] {  item,
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
                    break;
                default:
                    inputValues = new object[] { item,
                                                  lot,
                                                  "0",
                                                  "0",
                                                  "",
                                                  "1",
                                                  "",
                                                  site};
                    break;
            }
            InvokeResponseData responseDataStep = this.InvokeIDO("SLLots", "LotAddSp", inputValues);
            if (responseDataStep != null && responseDataStep.ReturnValue != null)
            {
                if (!(responseDataStep.ReturnValue.Equals("0")))
                {
                    if (paramcount > 8)
                    {
                        errorMessage = responseDataStep.Parameters.ElementAt(7).ToString();
                    }
                    return false;
                }
            }
            return true;
        }
        #endregion
    }
}