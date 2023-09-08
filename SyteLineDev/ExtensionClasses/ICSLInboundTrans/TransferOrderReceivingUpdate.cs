using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mongoose.Core.Configuration;
using Mongoose.IDO.Protocol;
using Mongoose.IDO;
using Mongoose.Core;
using System.Globalization;

namespace InforCollect.ERP.SL.ICSLInboundTrans
{
    class TransferOrderReceivingUpdate : ATransferOrderUtilities
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
        private string toLoc = "";
        private string toLot = "";
        private string toSite = "";
        private string uom = "";
        private string reasonCode = "";
        private string transitLocation = "";
        private bool addItemLocRecord = true;
        private bool allowIfCycleCountExists = false;
        private bool addPermanentItemWhseLocLink = false;
        private string SessionId = "";
        private string containerNum = "";
        private string importTaxId = "";
        private string allowZeroCostItem = "";
        private string docNum = "";
        private string LotMfgDate = string.Empty;
        private string LotExpDate = string.Empty;
        private string LotTrxRestrictCode = string.Empty;
        private string SerialMfgDate = string.Empty;
        private string SerialExpDate = string.Empty;
        private string SerialTrxRestrictCode = string.Empty;
        //Local Variables
        private List<string> SerialList = null;
        private bool itemLotTracked = false;
        private bool itemSerialTracked = false;
        private bool insertItemLocRecord = false;
        private string fobSite = "";
        private string transitWhse = "";
        private string transitSite = "";
        private InvokeResponseData ordLineInvokeResponseData = null;
        private string errorMessage = "";
        private bool createContainerNum = false;
        bool containerLocMismatch = false;
        private bool createNewLot = false;

        #region Properties
        /// <summary>
        /// Gets and Sets Date and Time for respective CSI Site.
        /// </summary>
        public DateTime SiteDateTime { get; set; }
        #endregion Properties

        public TransferOrderReceivingUpdate(string order, string line, string qty, string item, string fromSite,
                                            string fromWhse, string fromLoc, string fromLot, string toWhse, string toLoc,
                                            string toLot, string toSite, string uom, string reasonCode, string transitLocation,
                                            bool addItemLocRecord, bool allowIfCycleCountExists,
                                            bool addPermanentItemWhseLocLink, string SessionId, string containerNum, string importTaxId,
                                            string allowZeroCostItem, string docNum, string LotMfgDate, string LotExpDate, string LotTrxRestrictCode,
                                            string SerialMfgDate, string SerialExpDate, string SerialTrxRestrictCode)
        {
            //Input variables initialization
            initialize();

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
            this.toLoc = toLoc;
            this.toLot = toLot;
            this.uom = uom;
            this.reasonCode = reasonCode;
            this.transitLocation = transitLocation;

            this.addItemLocRecord = addItemLocRecord;
            this.allowIfCycleCountExists = allowIfCycleCountExists;
            this.addPermanentItemWhseLocLink = addPermanentItemWhseLocLink;
            this.reasonCode = reasonCode;

            //Local variables initialization
            itemLotTracked = false;
            itemSerialTracked = false;
            insertItemLocRecord = false;
            fobSite = "";
            ordLineInvokeResponseData = null;
            this.SessionId = SessionId;
            this.containerNum = containerNum;
            this.importTaxId = importTaxId;
            this.allowZeroCostItem = allowZeroCostItem;
            this.docNum = docNum;
            this.LotMfgDate = LotMfgDate;
            this.LotExpDate = LotExpDate;
            this.LotTrxRestrictCode = LotTrxRestrictCode;
            this.SerialMfgDate = SerialMfgDate;
            this.SerialExpDate = SerialExpDate;
            this.SerialTrxRestrictCode = SerialTrxRestrictCode;
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
            toLoc = "";
            toLot = "";
            uom = "";
            addItemLocRecord = true;
            allowIfCycleCountExists = false;
            addPermanentItemWhseLocLink = false;
            reasonCode = "";

            //Local variables initialization
            itemLotTracked = false;
            itemSerialTracked = false;
            insertItemLocRecord = false;
            fobSite = "";
            ordLineInvokeResponseData = null;
            errorMessage = "";
            containerNum = "";
            importTaxId = "";
            allowZeroCostItem = "";
            docNum = "";
            LotMfgDate = string.Empty;
            LotExpDate = string.Empty;
            LotTrxRestrictCode = string.Empty;
            SerialMfgDate = string.Empty;
            SerialExpDate = string.Empty;
            SerialTrxRestrictCode = string.Empty;
        }

        private bool checkIfItemLotExists()
        {
            object[] inputValues = new object[] { toWhse,
                                                  item,
                                                  toLoc,
                                                  toLot,
                                                  "rcv",
                                                  "0",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  ""};

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
        public bool formatInputs()
        {
            if (IsStringContainsNumericValue(order))
                order = formatDataByIDOAndPropertyName("SLSerials", "TrnNum", order);
            if (order == null || order.Trim().Equals(""))
            {
                errorMessage = constructErrorMessage("order input mandatory", "SLAXXXX003", null);
                return false;
            }

            line = formatDataByIDOAndPropertyName("SLSerials", "TrnLine", line);
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

            fromLot = formatDataByIDOAndPropertyName("SLLotLocs", "Lot", fromLot);
           
            if (toWhse == null || toWhse.Trim().Equals(""))
            {
                errorMessage = constructErrorMessage("toWhse input mandatory", "SLAXXXX010", null);
                return false;
            }

           
            if (toLoc == null || toLoc.Trim().Equals(""))
            {
                errorMessage = constructErrorMessage("toLoc input mandatory", "SLAXXXX022", null);
                return false;
            }

            toLot = formatDataByIDOAndPropertyName("SLLotLocs", "Lot", toLot);
           
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

            /*  addItemLocRecord = updateRequest.GetBoolFieldValue("addItemLocRecord");
              allowIfCycleCountExists = updateRequest.GetBoolFieldValue("allowIfCycleCountExists");
              addPermanentItemWhseLocLink = updateRequest.GetBoolFieldValue("addPermanentItemWhseLocLink");

              transitLocation = updateRequest.GetFieldValue("transitLocation");*/
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

            //Check if Transfer between From Site and To Site are allowed. for issue 207696
            /*
            if (transferBetweenSitesAllowed(fromSite, toSite, out errorMessage) == false)
            {
                return false;
            } */

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

                errorMessage = constructErrorMessage("Physical Inventory is active in Warehouse : {fromWhse} Transfer not allowed", "SLATORE001", substitutorDictionary);
                return false;
            }

            //Check To Warehouse
            responseData = GetWhseDetailsBySite(toWhse, toSite);
            if (responseData.PropertyList.Count == 0)
            {
                errorMessage = constructErrorMessage("To Whse Details Not Found", "SLAXXXX017", null);
                return false;
            }

            physicalInventoryFlag = GetPropertyValue(responseData.PropertyList, responseData.Items, "PhyInvFlg");
            if (physicalInventoryFlag == null)
            {
                errorMessage = constructErrorMessage("Error Reading WhseAll record", "SLAXXXX018", null);
                return false;
            }

            if (!(physicalInventoryFlag.Equals("0")))
            {
                IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                substitutorDictionary.Add("fromWhse", fromWhse);

                errorMessage = constructErrorMessage("Physical Inventory is active in Warehouse : {fromWhse} Transfer not allowed", "SLATORE002", substitutorDictionary);
                return false;
            }

            //Order Validation for issue : 207696
            InvokeResponseData orderInvokeResponseData = ValidateTransferReceiveOrderNo(order, true, out errorMessage);
            if (!(errorMessage.Trim().Equals("")))
            {
                return false;
            }
            else
            {
                fobSite = orderInvokeResponseData.Parameters.ElementAt(3).ToString();
            }

            if (fobSite != toSite)
            {   // Transit location /whse are property of Source site
                transitWhse = toWhse;
                transitSite = toSite;
            }
            else
            {   // Transit location /whse are property of Destination site
                transitWhse = fromWhse;
                transitSite = fromSite;
            }
            //line field exit

            ordLineInvokeResponseData = ValidateTransferReceiveOrderLine(order, line, fromSite, fromWhse, toSite, toWhse, true, out errorMessage);

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

            if (checkLocationDetails(item, transitWhse, transitSite, fromLoc, out errorMessage) == false)
            {
                IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                substitutorDictionary.Add("fromSite", fromSite);
                substitutorDictionary.Add("fromWhse", fromWhse);
                substitutorDictionary.Add("item", item);
                substitutorDictionary.Add("fromLoc", fromLoc);

                if (this.addItemLocRecord == true)
                {
                    if (addLocItemRecord(item, fromWhse, fromSite, fromLoc, addPermanentItemWhseLocLink) == false)
                    {
                        return false;
                    }
                }
                else
                {
                    errorMessage = constructErrorMessage("{fromSite} / {fromWhse} / {item} / {fromLoc} combination does not exists, Transfer not allowed", "SLATORE003", substitutorDictionary);
                    return false;
                }
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
            if (checkLot(item, fromLot, itemLotTracked, out errorMessage) == false)
            {
                return false;
            }

            if (!string.IsNullOrEmpty(toLot))
            {
                if (!(toLot.Trim().Equals(fromLot.Trim())))
                {
                    if (checkLot(item, toLot, itemLotTracked, out errorMessage) == false)
                    {
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
                if (checkIfItemLotExists() == false)
                {
                    createNewLot = true;
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
            //Transit Location Validation
            ValidateTransitLocation(transitSite, transitWhse, item, transitLocation, true, out errorMessage);

            if (!(errorMessage.Trim().Equals("")))
            {
                return false;
            }

            if (ValidateQty() == false)
            {
                return false;
            }

            InvokeResponseData ItemFlResponseData = ValidateItemFlSp(transitSite, transitWhse, item, transitLocation,
                                 order, line, toLot,
                                 ordLineInvokeResponseData.Parameters.ElementAt(16).ToString(),
                                 qty, out errorMessage);

            if (errorMessage != null && !(errorMessage.Trim().Equals("")))
            {
                return false;
            }

            //Container Functionality
            if (this.containerNum != null && !(this.containerNum.Trim().Equals("")))
            {
                if (ValidateQtyForRcvIntoContainerSp(this.item, this.toWhse, this.toLoc, this.toLot, this.toSite, out errorMessage) == false)
                {
                    return false;
                }
                if (ValidateContainerExist(this.containerNum, this.toWhse, this.toLoc, containerLocMismatch, out errorMessage) == true)
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
        public int PerformUpdate(out string infobar)
        {
            SerialList = this.GetSerialList(this.SessionId);
            // UpdateRequest updateRequest = (UpdateRequest)request;

            //1 Initialize variables
            //  initialize();
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

            //Validate Serials

            if (ValidateSerials() == false)
            {
                infobar = errorMessage;
                return 21;
            }

            //4 Perform Updates
            if (performTransferOrderReceipt() == false)
            {
                infobar = errorMessage;
                return 3;
            }
            else
            {
                infobar = errorMessage;
                infobar = formatResponse(infobar);
                return 0;
            }
        }

        private bool performTransferOrderReceipt()
        {
            try
            {
                if (this.insertItemLocRecord == true)
                {
                    if (addLocItemRecord(item, toWhse, toSite, toLoc, addPermanentItemWhseLocLink) == false)
                    {
                        return false;
                    }
                }
                if (createNewLot == true)
                {
                    try
                    {
                        //performAddLot(item, toLot, "0", "0", "", "1", toSite, out errorMessage);
                        if(!this.performAddLotwithTransRestrict())
                        {
                            return false;
                        }
                    }
                    catch (Exception)
                    {
                        IDORuntime.LogUserMessage("T.Order.performAddLot", UserDefinedMessageType.UserDefined1, "Error occured while adding lot");
                    }
                }
                if (createContainerNum == true)
                {
                    PerformCreateContainer(containerNum, toWhse, toLoc, out errorMessage);

                }

                if (SetTransferOrderParameters("S") == false)
                {
                    return false;
                }

                //SLMSSerials.SetMethodSp - To store the values
                object[] serialsMethod = new object[] { "SLTrnacts.TransferOrderReceiveSp" };

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
                if (SetTransferOrderParameters("U") == false)
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
                ClearSerailsBySessionID(this.SessionId);
            }
            return true;
        }
        public bool performAddLotwithTransRestrict()
        {
            string LotRevision = string.Empty;
            LoadCollectionResponseData itemResponseData = this.Context.Commands.LoadCollection(new LoadCollectionRequestData("SLItems", "Revision", string.Format("Item = '{0}' AND TrackEcn=1", item), null, 1));
            if (itemResponseData != null && itemResponseData.Items.Count > 0)
            {
                LotRevision = itemResponseData[0, "Revision"].GetValue(string.Empty);
            }
            int paramcount = 0;
            paramcount = GetIDOMethodParameterCount("SLLots", "LotAddSp");
            object[] inputValues;
            switch (paramcount)
            {
                case 12:
                    inputValues = new object[] { item,
                                                  toLot,
                                                  "0",
                                                  "0",
                                                  "",
                                                  "1",
                                                  LotRevision,
                                                  "",
                                                  toSite,
                                                  LotMfgDate,
                                                  LotExpDate,
                                                  LotTrxRestrictCode};
                    break;
                default:
                    inputValues = new object[] { item,
                                                  toLot,
                                                  "0",
                                                  "0",
                                                  "",
                                                  "1",
                                                  "",
                                                  toSite};
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

        private bool SetTransferOrderParameters(string type)
        {
            object[] inputValues = new object[] { type,
                                                  order,
                                                  line,
                                                  item,
                                                  fromSite,
                                                  fromWhse,
                                                  transitLocation,
                                                  fromLot,
                                                  toSite,
                                                  toWhse,
                                                  fobSite,
                                                  toLoc,
                                                  toLot,
                                                  qty,
                                                  uom,
                                                  SiteDateTime.ToString(WMLongDateTimePattern), // FTDEV-9195 - Adding Time to the date/time string passed into CSI - Untested
                                                  ordLineInvokeResponseData.Parameters.ElementAt(28).ToString(),
                                                  ordLineInvokeResponseData.Parameters.ElementAt(29).ToString(),
                                                  ordLineInvokeResponseData.Parameters.ElementAt(30).ToString(),
                                                  ordLineInvokeResponseData.Parameters.ElementAt(31).ToString(),
                                                  ordLineInvokeResponseData.Parameters.ElementAt(32).ToString(),
                                                  "Transfer Order Receive",
                                                  ordLineInvokeResponseData.Parameters.ElementAt(23).ToString(),
                                                  ordLineInvokeResponseData.Parameters.ElementAt(24).ToString(),
                                                  reasonCode,
                                                  "",
                                                  ordLineInvokeResponseData.Parameters.ElementAt(37).ToString(),
                                                  allowZeroCostItem,   //This need to be changed. - MoveZeroCostItems
                                                  "",   //Record date 
                                                  docNum
                                                  };

            InvokeResponseData responseValues = InvokeIDO("SLTrnacts", "TransferorderReceiveSetVarsSp", inputValues);
            if (!(responseValues.ReturnValue.Equals("0")))
            {
                errorMessage = constructErrorMessage(responseValues.Parameters.ElementAt(36).ToString(), "-1", null);
                return false;
            }

            return true;
        }

        private bool ValidateQty()
        {
            object[] inputValues = new object[] { order,
                                                  line,
                                                  fromSite,
                                                  toSite,
                                                  fromWhse,
                                                  toWhse,
                                                  ordLineInvokeResponseData.Parameters.ElementAt(16).ToString(),
                                                  qty,
                                                  transitLocation,
                                                  fromLot,
                                                  toLoc,
                                                  toLot,
                                                  item,
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  ordLineInvokeResponseData.Parameters.ElementAt(37).ToString(),
                                                  "",
                                                  ""
                                                  };

            InvokeResponseData responseValues = InvokeIDO("SLTrnacts", "TrrcvQtyValidSp", inputValues);
            if (!(responseValues.ReturnValue.Equals("0")))
            {
                errorMessage = constructErrorMessage(responseValues.Parameters.ElementAt(19).ToString(), "-2", null);
                return false;
            }
            return true;
        }


        public bool ValidateReasonCode()
        {
            LoadCollectionResponseData responseData = GetReasonCodeDetails(reasonCode, "TRANSFER RETURN");
            if (responseData.Items.Count == 0)
            {
                IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                substitutorDictionary.Add("reasonCode", reasonCode);

                errorMessage = constructErrorMessage("Invalid Reason Code supplied for TRANSFER RETURN type {reasonCode}", "SLATORE004", substitutorDictionary);
                return false;
            }
            return true;
        }


    }
}
