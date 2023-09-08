using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mongoose.Core.Configuration;
using Mongoose.IDO.Protocol;
using Mongoose.IDO;
using Mongoose.Core;
using System.Globalization;

namespace InforCollect.ERP.SL.ICSLOutBoundTrans
{
    class TransferOrderShipUpdate : ATransferOrderUtilities
    {
         //Input Variables.
        private string order = "";
        private string line = "";
        private string qty = "";
        private string item = "";
        private string fromSite = "";
        private string fromWhse = "";
        private string fromLoc = "";
        private string fromLot = "";
        private string toWhse = "";
        
        private string toLot = "";
        private string toSite = "";
        private string uom = "";
        private string reasonCode = "";
        private string transitLocation = "";
        private bool addItemLocRecord = true;
        private bool allowIfCycleCountExists = false;
        private bool addPermanentItemWhseLocLink = false;
        private string SessionID = "";
        private string allowZeroCostItem = "1";
        private string userInitial = "";
              
        //Local Variables
        private List<string> SerialList = null;

        //Local Varialbles
        private bool itemLotTracked = false;
        private bool itemSerialTracked = false;
        private string fobSite = "";
        private string transitWhse = "";
        private string transitSite = "";
        private InvokeResponseData ordLineInvokeResponseData = null;
        private InvokeResponseData orderInvokeResponseData = null;        
        private string errorMessage = "";
        

        public TransferOrderShipUpdate(string order, string line, string qty, string item, string fromSite,
                                            string fromWhse, string fromLoc, string fromLot, string toWhse,  
                                            string toLot,string toSite,string uom, string reasonCode, string transitLocation,
                                            bool addItemLocRecord, bool allowIfCycleCountExists,
                                            bool addPermanentItemWhseLocLink, string SessionID, string allowZeroCostItem, string userInitial)
        {
           
            this.order = order;
            this.line = line;
            this.fromSite = fromSite;
            this.toSite = toSite;
            this.fromWhse = fromWhse;
            this.toWhse = toWhse;
            this.item = item;
            this.qty = qty;
            this.fromLoc = fromLoc;
            this.fromLot = fromLot;
            this.reasonCode = reasonCode;
            this.transitLocation = transitLocation;
            this.toLot = toLot;
            this.uom = uom;
            this.addItemLocRecord = addItemLocRecord;
            this.allowIfCycleCountExists = allowIfCycleCountExists;
            this.addPermanentItemWhseLocLink = addPermanentItemWhseLocLink;
            this.reasonCode = reasonCode;

            //Local variables initialization
            itemLotTracked = false;
            itemSerialTracked = false;
            fobSite = "";
            ordLineInvokeResponseData = null;
            this.SessionID = SessionID;
            this.userInitial = userInitial;
            this.allowZeroCostItem = allowZeroCostItem;
            
        }

        public void initialize()
        {
            //Input variables initialization
            order = "";
            line = "";
            fromSite = "";
            toSite = "";
            fromWhse = "";
            toWhse = "";
            item = "";
            qty = "";
            fromLoc = "";
            fromLot = "";
          
            toLot = "";
            uom = "";
            addItemLocRecord = true;
            allowIfCycleCountExists = false;
            addPermanentItemWhseLocLink = false;
            reasonCode = "";
            allowZeroCostItem = "1";

           
            //Local variables initialization
            itemLotTracked = false;
            itemSerialTracked = false;
            fobSite = "";
            ordLineInvokeResponseData = null;
            orderInvokeResponseData = null;     
            errorMessage = "";
            
        }


        public bool formatInputs()
        {
            if (IsStringContainsNumericValue(order))
                order = formatDataByIDOAndPropertyName("SLTrnacts", "TrnNum",  order );
            if (order == null || order.Trim().Equals(""))
            {
                errorMessage = constructErrorMessage("order input mandatory", "SLAXXXX003", null);
                return false;
            }

            line = formatDataByIDOAndPropertyName("SLTrnacts", "TrnLine",  line);
            if (line == null || line.Trim().Equals(""))
            {
                errorMessage = constructErrorMessage("line input mandatory", "SLAXXXX004", null);
                return false;
            }

           
            if (qty == null || qty.Trim().Equals(""))
            {
                errorMessage = constructErrorMessage("qty input mandatory", "SLAXXXX005", null);
                return false;
            }

           
            if (item == null || item.Trim().Equals(""))
            {
                errorMessage = constructErrorMessage("item input mandatory", "SLAXXXX006", null);
                return false;
            }

           

            if (fromSite == null || fromSite.Trim().Equals(""))
            {
                errorMessage = constructErrorMessage("fromSite input mandatory", "SLAXXXX007", null);
                return false;
            }

            
            if (fromWhse == null || fromWhse.Trim().Equals(""))
            {
                errorMessage = constructErrorMessage("fromWhse input mandatory", "SLAXXXX008", null);
                return false;
            }

            
            if (fromLoc == null || fromLoc.Trim().Equals(""))
            {
                errorMessage = constructErrorMessage("fromLoc input mandatory", "SLAXXXX009", null);
                return false;
            }

            fromLot = formatDataByIDOAndPropertyName("SLLotLocs", "Lot",  fromLot);
           
            if (toWhse == null || toWhse.Trim().Equals(""))
            {
                errorMessage = constructErrorMessage("toWhse input mandatory", "SLAXXXX010", null);
                return false;
            }

             

          /*  toLot = formatDataByIDOAndPropertyName("SLLotLocs", "Lot",toLot);
            toSite = updateRequest.GetFieldValue("toSite"); */
            if (toSite == null || toSite.Trim().Equals(""))
            {
                errorMessage = constructErrorMessage("toSite input mandatory", "SLAXXXX011", null);
                return false;
            }

            if (uom == null || uom.Trim().Equals(""))
            {
                errorMessage = constructErrorMessage("uom input mandatory", "SLAXXXX012", null);
                return false;
            }
            if (transitLocation == null || transitLocation.Trim().Equals(""))
            {
                errorMessage = constructErrorMessage("transitLocation input mandatory", "SLAXXXX013", null);
                return false;
            }
            if (Convert.ToDouble(qty, CultureInfo.InvariantCulture) < 0) // FTDEV-9247
            {
                if (reasonCode.Trim().Equals(""))
                {
                    errorMessage = constructErrorMessage("Reason Code Input Mandatory if quantity less than 0", "SLAXXXX014", null);
                    return false;
                }
            }
/*
            addItemLocRecord = updateRequest.GetBoolFieldValue("addItemLocRecord");
            allowIfCycleCountExists = updateRequest.GetBoolFieldValue("allowIfCycleCountExists");
            addPermanentItemWhseLocLink = updateRequest.GetBoolFieldValue("addPermanentItemWhseLocLink");

            */
            return true;
        }

        public bool validateInputs()
        {
            //Order Validation

            orderInvokeResponseData = ValidateTransferShipOrderNo(order, true, out errorMessage);
            if (!(errorMessage.Trim().Equals("")))
            {
                return false;
            }
            fobSite = orderInvokeResponseData.Parameters.ElementAt(5).ToString();

            if (fobSite != toSite)
            {   // Transit location /whse are property of Source site
                transitWhse = toWhse;
                transitSite = toSite;
            }
            else
            {   // Transit location /whse are property of Destination site
                transitSite = fromSite;
                transitWhse = (fromSite != toSite) ? fromWhse : toWhse;
            }


            //line field exit


            if (ValidateOrderLine() == false)
            {
                return false;
            }

            //Validate Inputs

            if (VerifyInputs() == false)
            {
                return false;
            }

            //Validate From Site
            LoadCollectionResponseData responseData = GetSiteDetails(fromSite);
            if (responseData.PropertyList.Count == 0)
            {
                errorMessage = constructErrorMessage("From Site Details Not Found", "SLAXXXX015", null);
                return false;
            }

            //Validate To Site
            responseData = GetSiteDetails(toSite);
            if (responseData.PropertyList.Count == 0)
            {
                errorMessage = constructErrorMessage("To Site Details Not Found", "SLAXXXX016", null);
                return false;
            }

            //Check if Transfer between From Site and To Site are allowed.

            //if (transferBetweenSitesAllowed(fromSite, toSite, out errorMessage) == false)
            //{
            //    return false;
            //}

            //Check From Warehouse
            responseData = GetWhseDetailsBySite(fromWhse, fromSite);
            if (responseData.PropertyList.Count == 0)
            {
                errorMessage = constructErrorMessage("From Whse Details Not Found", "SLAXXXX017", null);
                return false;
            }

            string physicalInventoryFlag = GetPropertyValue(responseData.PropertyList, responseData.Items, "PhyInvFlg");
            if (physicalInventoryFlag == null)
            {
                errorMessage = constructErrorMessage("Error Reading WhseAll record", "SLAXXXX018", null);
                return false;
            }

            if (!(physicalInventoryFlag.Equals("0")))
            {
                IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                substitutorDictionary.Add("fromWhse", fromWhse);

                errorMessage = constructErrorMessage("Physical Inventory is active in Warehouse : {fromWhse} Transfer not allowed", "SLACORD002", substitutorDictionary);
                return false;
            }

            //Check To Warehouse
            responseData = GetWhseDetailsBySite(toWhse, toSite);
            if (responseData.PropertyList.Count == 0)
            {
                errorMessage = constructErrorMessage("To Whse Details Not Found", "SLAXXXX019", null);
                return false;
            }

            physicalInventoryFlag = GetPropertyValue(responseData.PropertyList, responseData.Items, "PhyInvFlg");
            if (physicalInventoryFlag == null)
            {
                errorMessage = constructErrorMessage("Error Reading WhseAll record", "SLATORD018", null);
                return false;
            }

            if (!(physicalInventoryFlag.Equals("0")))
            {
                IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                substitutorDictionary.Add("toWhse", toWhse);

                errorMessage = constructErrorMessage("Physical Inventory is active in Warehouse :{toWhse}, Transfer not allowed", "SLACORD003", substitutorDictionary);
                return false;
            }

            //Check Item Details
            responseData = GetItemDetails(formatItem(item));
            if (responseData.PropertyList.Count == 0)
            {
                errorMessage = constructErrorMessage("Item Details Not Found", "SLAXXXX020", null);
                return false;
            }

            itemLotTracked = GetBool(GetPropertyValue(responseData.PropertyList, responseData.Items, "LotTracked"));
            itemSerialTracked = GetBool(GetPropertyValue(responseData.PropertyList, responseData.Items, "SerialTracked"));

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
                IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                substitutorDictionary.Add("fromSite", fromSite);
                substitutorDictionary.Add("fromWhse", fromWhse);
                substitutorDictionary.Add("item", item);
                substitutorDictionary.Add("fromLoc", fromLoc);

                errorMessage = constructErrorMessage("{fromSite}/{fromWhse}/{item}/{fromLoc}combination does not exists, Transfer not allowed", "SLACORD004", substitutorDictionary);
                return false;
            }

            if (ValidateLocation() == false)
            {
                return false;
            }

            //Check From Lot
            if (checkLot(item, fromLot, itemLotTracked,out errorMessage) == false)
            {
                return false;
            }

            if (toLot != null)
            {
                if (!(toLot.Trim().Equals(fromLot)))
                {
                    if (checkLot(item, toLot, itemLotTracked,out errorMessage) == false)
                    {
                        return false;
                    }
                }
            }

            //Validate Qty

            if (ValidateQty() == false)
            {
                return false;
            }

            //Validate UOM
            //UOM validate and Qty conversion happened in the TransferOrderShipSp, commented the code
            //if (ValidateUOM() == false)
            //{
            //    return false;
            //}

            //Validate Reason Code
/*
            if (!(reasonCode.Trim().Equals("")))
            {
                if (ValidateReasonCode() == false)
                {
                    return false;
                }
            }
             */


            return true;
        }
        public int PerformUpdate(out string InfoBar)
        {
              InfoBar = "";
              if (UpdateUserInitial(this.userInitial, out errorMessage) == false)
              {
                  InfoBar = errorMessage;
                  return 1;
              }
            if (SessionID != null && !(SessionID.Equals("")))
            {
                SerialList = this.GetSerialList(this.SessionID);
            }
            
            //2 Format Inputs
            if (formatInputs( ) == false)
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

            //Validate Serials

            if (ValidateSerials( ) == false)
            {
                InfoBar = errorMessage;
                return 21;
            }

           
            //4 Perform Updates
            if (performTransferOrderShip() == false)
            {
                InfoBar = errorMessage;
                return 3;
            }

            
            InfoBar = formatResponse(errorMessage);
            return 0;

        }

        private bool performTransferOrderShip( )
        {
            // 1 Transit Location Validation

            // ValidateTransitLocation(toSite, toWhse, item, transitLocation, true, out errorMessage);     -- sdommata 10/08/2014  updated transitSite to consider for transit location check       

            ValidateTransitLocation(transitSite, transitWhse, item, transitLocation, true, out errorMessage);


            if (!(errorMessage.Trim().Equals("")))
            {
                return false;
            }

            //2 Add Item/Location record   -- sdommata 10/08/2014  updated transitSite to consider for transit location check  

            /*   if (addLocItemRecord(item, toWhse, toSite, transitLocation, addPermanentItemWhseLocLink) == false)
               {
                   return this.errorMessage;
               }
                */

            if (addLocItemRecord(item, transitWhse, transitSite, transitLocation, addPermanentItemWhseLocLink, out errorMessage) == false)
            {               
                return false;
            }



            //3 Transit Location Post Validation

            // ValidatePostTransitLocation(toSite, toWhse, item, transitLocation, true, out errorMessage);          -- sdommata 10/08/2014  updated transitSite to consider for transit location check 
            ValidatePostTransitLocation(transitSite, transitWhse, item, transitLocation, true, out errorMessage);



            if (!(errorMessage.Trim().Equals("")))
            {
                return false;
            }

            if (SetTransferOrderParameters("S") == false)
            {
                return false;
            }

            //SLMSSerials.SetMethodSp - To store the values
            object[] serialsMethod = new object[] { "SLTrnacts.TransferOrderShipSp" };
           
            InvokeResponseData invokeResponseDataStep2 = this.Context.Commands.Invoke("SLMSSerials", "SetMethodSP", serialsMethod);
            if (!(invokeResponseDataStep2.ReturnValue.Equals("0")))
            {
               errorMessage = constructErrorMessage("Transfer Order Receipt process failed", "SLAXXXX021", null);
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
            try{
                 
                UpdateCollectionResponseData updateResponseData = this.Context.Commands.UpdateCollection(updateRequestData);
                 //Console.WriteLine(updateResponseData.ToXml());
            }  catch (Exception e )
            {
                errorMessage = e.Message;
                return false;
            }
            
            if (SetTransferOrderParameters("U") == false)
            {
                return false;
            }
            try
            {

                ClearSerailsBySessionID(this.SessionID);
            }
            catch (Exception)
            {
            }
            return true;
        }

        private bool ValidateSerials()
        {
            if (SerialList != null)
            {
                for (int i = 0; i < SerialList.Count; i++)
                {
                    IDOUpdateItem serialItem = new IDOUpdateItem();
                    serialItem.Action = UpdateAction.Update;
                    serialItem.ItemNumber = i;
                    ValidateTransferReceiveSerial(fobSite,
                                                     item,
                                                     SerialList.ElementAt(i),
                                                     "0",
                                                     "1",
                                                     fromSite,
                                                     toSite,
                                                     fobSite,
                                                     true,
                                                     out errorMessage
                                                     );

                    if (!(errorMessage.Trim().Equals("")))
                    {
                        return false;
                    }

                }
            }
            return true;
        }

        private bool ValidateOrderLine()
        {
            object[] inputValues = null;
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
                errorMessage = constructErrorMessage(invokeResponseDataStep1.Parameters.ElementAt(3).ToString(), "-1", null);
                return false;
            }

            int paramcount = 0;
            paramcount = GetIDOMethodParameterCount("SLTrnacts", "GetItemTransitInfoSp");

            switch (paramcount)
            {
                case 32:
                    inputValues = new object[] { order,
                                                  line,
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",  //1
                                                  
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",//2
                                                  
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",//3

                                                  "",
                                                  "0"                      //Tax Free Material - To DO                                                  
                                                  };
                    break;

                case 33:
                    inputValues = new object[] { order,
                                                  line,
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",  //1
                                                  
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",//2
                                                  
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",//3

                                                  "",
                                                  "0",                      //Tax Free Material - To DO  
                                                  "0"
                                                  };
                    break;


                default:    //default is 8.03.10 inital release when this adapter was created.        
                    inputValues = new object[] { //33 parameters
                                                  order,
                                                  line,
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",  //1
                                                  
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",//2
                                                  
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",//3

                                                  "",
                                                  "0",                      //Tax Free Material - To DO
                                                 
                                                 System.DateTime.Now.ToString(WMShortDatePattern),  // Record date 
                                                  ""
                                                  };
                    break;
            }

            ordLineInvokeResponseData = InvokeIDO("SLTrnacts", "GetItemTransitInfoSp", inputValues);
            if (!(ordLineInvokeResponseData.ReturnValue.Equals("0")))
            {
                errorMessage = constructErrorMessage(ordLineInvokeResponseData.Parameters.ElementAt(29).ToString(), "-1", null);
                return false;
            }
            transitLocation = ordLineInvokeResponseData.Parameters.ElementAt(10).ToString();
            return true;
        }

        private bool ValidateQty()
        {
            object[] inputValues = new object[] { order,
                                                  line,
                                                  ordLineInvokeResponseData.Parameters.ElementAt(16).ToString(),
                                                  qty,
                                                  fromLoc,
                                                  fromLot,
                                                  toLot,
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  ""
                                                  };

            InvokeResponseData responseValues = InvokeIDO("SLTrnacts", "TrnShipQtyValidSp", inputValues);
            if (!(responseValues.ReturnValue.Equals("0")))
            {
                errorMessage = constructErrorMessage(responseValues.Parameters.ElementAt(13).ToString(), "-2", null);
                return false;
            }
            return true;
        }

        private bool ValidateReasonCode()
        {
            LoadCollectionResponseData responseData = GetReasonCodeDetails(reasonCode, "TRANSFER RETURN");
            if (responseData.Items.Count == 0)
            {
                IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                substitutorDictionary.Add("reasonCode", reasonCode);

                errorMessage = constructErrorMessage("Invalid Reason Code supplied for TRANSFER RETURN type {reasonCode}", "SLACORD005", substitutorDictionary);
                
                return false;
            }
            return true;
        }

        private bool VerifyInputs()
        {
            if (!(this.orderInvokeResponseData.Parameters.ElementAt(1).ToString().Equals(fromSite)))
            {
                IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                substitutorDictionary.Add("sub1", this.orderInvokeResponseData.Parameters.ElementAt(1).ToString());

                errorMessage = constructErrorMessage("From Site not matching Order/Line {sub1}", "SLACORD006", substitutorDictionary);
                return false;
            }
            if (!(this.orderInvokeResponseData.Parameters.ElementAt(2).ToString().Equals(toSite)))
            {

                IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                substitutorDictionary.Add("sub1", this.orderInvokeResponseData.Parameters.ElementAt(2).ToString());

                errorMessage = constructErrorMessage("To Site not matching Order/Line {sub1} ", "SLACORD007", substitutorDictionary);
                return false;
            }
            if (!(this.orderInvokeResponseData.Parameters.ElementAt(3).ToString().Equals(fromWhse)))
            {
                IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                substitutorDictionary.Add("sub1", this.orderInvokeResponseData.Parameters.ElementAt(3).ToString());

                errorMessage = constructErrorMessage("From Whse not matching Order/Line {sub1} ", "SLACORD008", substitutorDictionary);
                return false;
            }
            if (!(this.orderInvokeResponseData.Parameters.ElementAt(4).ToString().Equals(toWhse)))
            {
                IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                substitutorDictionary.Add("sub1", this.orderInvokeResponseData.Parameters.ElementAt(4).ToString());

                errorMessage = constructErrorMessage("To Whse not matching Order/Line {sub1} ", "SLACORD009", substitutorDictionary);
                return false;
            }
            return true;
        }

        private bool ValidateLocation()
        {
            object[] inputValues = new object[] { item,
                                                  fromWhse,
                                                  fromSite,
                                                  fromLoc,
                                                  "",
                                                  "",
                                                  "",
                                                  ""
                                                  };

            InvokeResponseData responseValues = InvokeIDO("SLTrnacts", "TrnShipLocValidSp", inputValues);
            if (!(responseValues.ReturnValue.Equals("0")))
            {
                errorMessage = constructErrorMessage(responseValues.Parameters.ElementAt(7).ToString(), "-3", null);
                return false;
            }

            inputValues = new object[] { order,
                                         line,
                                         item,
                                         fromWhse,
                                         fromLoc,
                                         ordLineInvokeResponseData.Parameters.ElementAt(16).ToString(), //Conversion Factor
                                         fromLot,
                                         qty,
                                         "",
                                         "",
                                         "",
                                         ""};

            responseValues = InvokeIDO("SLTrnacts", "TrnShipLocChangeSp", inputValues);
            if (!(responseValues.ReturnValue.Equals("0")))
            {
                errorMessage = constructErrorMessage(responseValues.Parameters.ElementAt(10).ToString(), "-4", null);
                return false;
            }
            return true;

        }

        private bool ValidateUOM()
        {
            object[] inputValues = new object[] { uom,
                                                  order,
                                                  line,
                                                  ordLineInvokeResponseData.Parameters.ElementAt(16).ToString(), //Conversion Factor
                                                  qty,
                                                  ""
                                                  };

            InvokeResponseData responseValues = InvokeIDO("SLTrnacts", "CombineXferUMValidSp", inputValues);
            if (!(responseValues.ReturnValue.Equals("0")))
            {
                errorMessage = constructErrorMessage(responseValues.Parameters.ElementAt(5).ToString(), "-5", null);
                return false;
            }
            qty = responseValues.Parameters.ElementAt(4).ToString();
            return true;

        }

        private bool SetTransferOrderParameters(string type)
        {
            //int paramcount = 0;
            object[] inputValues = null; ;

            //paramcount = GetIDOMethodParameterCount("SLTrnacts", "TransferorderShipSetVarsSp");

             //Console.WriteLine("GetItemTransitInfoSp Param count: " + paramcount);
            //switch (paramcount)
            //{
            //    case 23:                                  // Extra check added to support SL8.03.00   sdommata    10/06/2014
            //        inputValues = new object[] { type,
            //                                      order,
            //                                      fromSite,
            //                                      toSite,
            //                                      fobSite,
            //                                      fromWhse,
            //                                      toWhse,
            //                                      line,
            //                                      qty,
            //                                      uom,
            //                                      //System.DateTime.Now,
            //                                      System.DateTime.Now.ToString(WMFullDateTimePattern),  
            //                                      fromLoc,
            //                                      fromLot,
            //                                      toLot,
            //                                      "Transfer Order Ship",
            //                                      ordLineInvokeResponseData.Parameters.ElementAt(14).ToString(),
            //                                      ordLineInvokeResponseData.Parameters.ElementAt(17).ToString(),
            //                                      ordLineInvokeResponseData.Parameters.ElementAt(18).ToString(),
            //                                      reasonCode,
            //                                      "",
            //                                      "",         // Import Doc ID
            //                                      "",         // Export Doc ID
            //                                      allowZeroCostItem  ,         //Move zero cost items.
            //                                      };
            //        break;
            //    case 24:
            //        inputValues = new object[] { type,
            //                                      order,
            //                                      fromSite,
            //                                      toSite,
            //                                      fobSite,
            //                                      fromWhse,
            //                                      toWhse,
            //                                      line,
            //                                      qty,
            //                                      uom,
            //                                      //System.DateTime.Now,
            //                                      System.DateTime.Now.ToString(WMFullDateTimePattern), 
            //                                      fromLoc,
            //                                      fromLot,
            //                                      toLot,
            //                                      "Transfer Order Ship",
            //                                      ordLineInvokeResponseData.Parameters.ElementAt(14).ToString(),
            //                                      ordLineInvokeResponseData.Parameters.ElementAt(17).ToString(),
            //                                      ordLineInvokeResponseData.Parameters.ElementAt(18).ToString(),
            //                                      reasonCode,
            //                                      "",
            //                                      "",         // Import Doc ID
            //                                      "",         // Export Doc ID
            //                                      allowZeroCostItem  ,         //Move zero cost items.
            //                                      "" 
            //                                      };
            //        break;
            //    case 25:
                    inputValues = new object[] { type,
                                                  order,
                                                  fromSite,
                                                  toSite,
                                                  fobSite,
                                                  fromWhse,
                                                  toWhse,
                                                  line,
                                                  qty,
                                                  uom,
                                                  //System.DateTime.Now,
                                                  System.DateTime.Now.ToString(WMFullDateTimePattern),
                                                  fromLoc,
                                                  fromLot,
                                                  toLot,
                                                  "Transfer Order Ship",
                                                  ordLineInvokeResponseData.Parameters.ElementAt(14).ToString(),
                                                  ordLineInvokeResponseData.Parameters.ElementAt(17).ToString(),
                                                  ordLineInvokeResponseData.Parameters.ElementAt(18).ToString(),
                                                  reasonCode,
                                                  "",
                                                  "",         // Import Doc ID
                                                  "",         // Export Doc ID
                                                  allowZeroCostItem  ,         //Move zero cost items.
                                                  "",
                                                  ""         //DocumentNum
                                                  };
            //        break;
            //}


            InvokeResponseData responseValues = InvokeIDO("SLTrnacts", "TransferorderShipSetVarsSp", inputValues);
            if (!(responseValues.ReturnValue.Equals("0")))
            {
                errorMessage = constructErrorMessage(responseValues.Parameters.ElementAt(19).ToString(), "-6", null);
                return false;
            }
           
            return true;
        }

       
       
    }
}
