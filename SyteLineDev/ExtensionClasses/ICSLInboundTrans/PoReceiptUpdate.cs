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
    class PoReceiptUpdate : InbondUtilities
    {
        #region InputVariables

        //Input Variables.
        private string order = "";
        private string line = "";
        private string release = "";
        private string qty = "";
        private string qtyReturned = "";
        private string item = "";
        private string site = "";
        private string whse = "";
        private string loc = "";
        private string uom = "";
        private string reasonCode = "";
        private string lot = "";
        private string vendorLot = "";
        private bool generateSerials = false;
        private bool generateLot = false;

        private bool addItemLocRecord = true;
        private bool allowIfCycleCountExists = false;
        private bool addPermanentItemWhseLocLink = false;
        private bool overrideQtyTolerance = false;

        private string drReturn = "";                                       //Kiran 01-03-2012.n
        private string packingSlipNumber = "";                              //Kiran 02-07-2012.n

        //8.03 additions

        //private string manufactureId = "";
        //private string manufactureItem = "";
        private string sessionID = "";
        private string containerNum = "";
        private string importTaxId = "";
        private string grnNum = "";
        private string grnLine = "";
        private string docNum = "";
        private string UbEsigEncryptedPassword = "";
        private string UbEsigReasonCode = "";
        private string UbEsigRowPointer = "";
        private string UbEsigUserName = "";
        private string LotMfgDate = "";
        private string LotExpDate = "";
        private string LotTrxRestrictCode = "";
        private string SerialMfgDate = "";
        private string SerialExpDate = "";
        private string SerialTrxRestrictCode = "";
        #endregion

        #region LocalVariables
        //Local Varialbles
        private bool itemLotTracked = false;
        private bool itemSerialTracked = false;
        private bool insertItemLocRecord = false;
        private LoadCollectionResponseData poResponseData = null;
        private LoadCollectionResponseData poLineReleaseResponseData = null;
        private double qtyOnHand = 0;
        private bool createNewLot = false;
        private string ItemBaseUOM = "";
        private InvokeResponseData manufacturerResponseDataStep = null;

        public string holdLoc = "";
        public bool qcChecked = false;
        public bool isCertified = false;
        public string receiverNo = "";
        private bool isNonStandardPart = false;                         //Kiran 01-09-2012.n
        private List<string> SerialList = null;
        private string errorMessage = "";
        private string manufactureId = "";
        private string manufactureItem = "";

        private IMessageProvider messageProvider = null;

        #endregion
        #region intermediatevariables

        private string DerBrokerageRate;
        private string DerDutyRate;
        private string DerFreightRate;
        private string DerGrnLine;
        private string DerGrnNum;
        private string DerInsuranceRate;
        private string DerItemExists;
        private string DerLocFrtRate;
        private string EcCode;
        private string Item;
        private string RowPointer;
        private string UbByCons;
        private string UbDRRt;
        private string UbGrnExists;
        private string UbImportDocId;
        private string UbLocation;
        private string UbLot;
        private string UbPackNum;
        private string UbQtyReceived;
        private string UbQtyReceivedConv;
        private string UbQtyReturned;
        private string UbQtyReturnedConv;
        private string UbReasonCode;
        private string UbSequence;
        private string UbTransDate;
        private string UbWorkKey;
        private string UM;
        private string UnitBrokerageCost;
        private string UnitBrokerageCostConv;
        private string UnitDutyCost;
        private string UnitDutyCostConv;
        private string UnitFreightCost;
        private string UnitFreightCostConv;
        private string UnitInsuranceCost;
        private string UnitInsuranceCostConv;
        private string UnitLocFrtCost;
        private string UnitLocFrtCostConv;
        private string UnitMatCost;
        private string UnitMatCostConv;
        private string Whse;
        private string PoVendNum;
        private string UbSelectedReceiving;
        private string PoBuilderPoOrigSite;
        private string PoBuilderPoNum;
        private string UbSLocation;
        private string UbSLot;
        private string ItmLotTracked;
        private string QtyOrdered;
        private string QtyReceived;
        private string ItmDescription;
        private string QtyRejected;
        private string PoOrderDate;
        private string VendItem;
        private string POIncludeTaxInCost;
        private string RcvdDate;
        private string DueDate;
        private string RefType;
        private string RefNum;
        private string RefLineSuf;
        private string RefRelease;
        private string ItemCostConv;
        private string UbSerNumSelected;
        private string UbSerNumGenerateQty;
        private string UbSerNumRangeQty;
        private string ItmSerialPrefix;
        private string DerLUnitFreightCost;
        private string DerFreightCurrCode;
        private string DerFreightCurrCodeDesc;
        private string DerLUnitDutyCost;
        private string DerDutyCurrCode;
        private string DerDutyCurrCodeDesc;
        private string DerLUnitBrokerageCost;
        private string DerBrokerageCurrCode;
        private string DerBrokerageCurrCodeDesc;
        private string DerLUnitInsuranceCost;
        private string DerInsuranceCurrCode;
        private string DerInsuranceCurrCodeDesc;
        private string DerLUnitLocFrtCost;
        private string DerLocFrtCurrCode;
        private string DerLocFrtCurrCodeDesc;
        private string DerNeedsPostReceiveWIP;
        private string Stat;
        private string UbSerNumStatLinkBy;
        private string DerRefDescription;
        private string ItmSerialTracked;
        private string DerDefaultLoc;
        private string UbUnReceiveFlag;
        private string QtyVoucher;
        private string ItemCost;
        private string ItmTaxFreeMatl;
        private string PoContainsOnlyTaxFreeMatls;
        private string UbSImportDocId;
        private string ItemPOToleranceOver;
        private string ItemPOToleranceUnder;
        private string CurrCode;
        private string IsgenerateVoucher;
        private string voucherNum;

        private bool createContainerNum = false;
        bool containerLocMismatch = false;



        #endregion

        #region Properties
        /// <summary>
        /// Gets and Sets Date and Time for respective CSI Site.
        /// </summary>
        public DateTime SiteDateTime { get; set; }
        #endregion Properties

        public void SetMessageProvider(IMessageProvider messageProvider)
        {
            this.messageProvider = messageProvider;
        }

        public PoReceiptUpdate(string order, string line, string release, string qty, string qtyReturned, string item, string site,
                               string whse, string loc, string uom, string reasonCode, string lot, string vendorLot,
                               bool generateSerials, bool generateLot, bool addItemLocRecord, bool allowIfCycleCountExists,
                               bool addPermanentItemWhseLocLink, bool overrideQtyTolerance, string drReturn, string PackingSlipNumber,
                               string sessionID, string containerNum, string importTaxId, string grnNum, string grnLine, string docNum,
                               string UbEsigEncryptedPassword, string UbEsigReasonCode, string UbEsigRowPointer, string UbEsigUserName,
                               string LotMfgDate, string LotExpDate, string LotTrxRestrictCode, string SerialMfgDate, string SerialExpDate,
                               string SerialTrxRestrictCode,string IsgenerateVoucher)

        {
            initialize();
            this.order = order;
            this.line = line;
            this.release = release;
            this.qty = qty;
            this.qtyReturned = qtyReturned;
            this.item = item;
            this.site = site;
            this.whse = whse;
            this.loc = loc;
            this.uom = uom;
            this.reasonCode = reasonCode;
            this.lot = lot;
            this.vendorLot = vendorLot;

            this.generateSerials = generateSerials;
            this.generateLot = generateLot;
            this.addItemLocRecord = addItemLocRecord;
            this.allowIfCycleCountExists = allowIfCycleCountExists;
            this.addPermanentItemWhseLocLink = addPermanentItemWhseLocLink;
            this.overrideQtyTolerance = overrideQtyTolerance;
            this.drReturn = drReturn;
            this.packingSlipNumber = PackingSlipNumber;
            this.sessionID = sessionID;
            this.containerNum = containerNum;
            this.importTaxId = importTaxId;
            this.grnNum = grnNum;
            this.grnLine = grnLine;
            this.docNum = docNum;
            this.UbEsigEncryptedPassword = UbEsigEncryptedPassword;
            this.UbEsigReasonCode = UbEsigReasonCode;
            this.UbEsigRowPointer = UbEsigRowPointer;
            this.UbEsigUserName = UbEsigUserName;
            this.LotMfgDate = LotMfgDate;
            this.LotExpDate = LotExpDate;
            this.LotTrxRestrictCode = LotTrxRestrictCode;
            this.SerialMfgDate = SerialMfgDate;
            this.SerialExpDate = SerialExpDate;
            this.SerialTrxRestrictCode = SerialTrxRestrictCode;
            this.IsgenerateVoucher = IsgenerateVoucher;
           
    }

        public void initialize()
        {

            //Input variables initialization
            order = "";
            line = "";
            release = "";

            site = "";
            whse = "";
            item = "";


            qty = "";
            loc = "";
            lot = "";
            vendorLot = "";
            uom = "";
            reasonCode = "";
            addItemLocRecord = true;
            addPermanentItemWhseLocLink = false;
            allowIfCycleCountExists = false;

            generateSerials = false;
            generateLot = false;
            overrideQtyTolerance = false;
            drReturn = "";

            manufactureId = "";
            manufactureItem = "";
            packingSlipNumber = "";
            containerNum = "";
            importTaxId = "";
            grnNum = "";
            grnLine = "";
            docNum = "";
            UbEsigEncryptedPassword = "";
            UbEsigReasonCode = "";
            UbEsigRowPointer = "";
            UbEsigUserName = "";
            //Local variables initialization
            itemLotTracked = false;
            itemSerialTracked = false;
            insertItemLocRecord = false;
            qtyOnHand = 0;
            createNewLot = false;
            poResponseData = null;
            poLineReleaseResponseData = null;
            ItemBaseUOM = "";
            manufacturerResponseDataStep = null;

            holdLoc = "";
            qcChecked = false;
            isCertified = false;
            receiverNo = "";
            drReturn = "";
            isNonStandardPart = false;

            //Intermediate variables

            DerBrokerageRate = null;
            DerDutyRate = null;
            DerFreightRate = null;
            DerGrnLine = null;
            DerGrnNum = null;
            DerInsuranceRate = null;
            DerItemExists = null;
            DerLocFrtRate = null;
            EcCode = null;
            Item = null;
            RowPointer = null;
            UbByCons = null;
            UbDRRt = null;
            UbGrnExists = null;
            UbImportDocId = null;
            UbLocation = null;
            UbLot = null;
            UbPackNum = null;
            UbQtyReceived = null;
            UbQtyReceivedConv = null;
            UbQtyReturned = null;
            UbQtyReturnedConv = null;
            UbReasonCode = null;
            UbSequence = null;
            UbTransDate = null;
            UbWorkKey = null;
            UM = null;
            UnitBrokerageCost = null;
            UnitBrokerageCostConv = null;
            UnitDutyCost = null;
            UnitDutyCostConv = null;
            UnitFreightCost = null;
            UnitFreightCostConv = null;
            UnitInsuranceCost = null;
            UnitInsuranceCostConv = null;
            UnitLocFrtCost = null;
            UnitLocFrtCostConv = null;
            UnitMatCost = null;
            UnitMatCostConv = null;
            Whse = null;
            PoVendNum = null;
            UbSelectedReceiving = null;
            PoBuilderPoOrigSite = null;
            PoBuilderPoNum = null;
            UbSLocation = null;
            UbSLot = null;
            ItmLotTracked = null;
            QtyOrdered = null;
            QtyReceived = null;
            ItmDescription = null;
            QtyRejected = null;
            PoOrderDate = null;
            VendItem = null;
            POIncludeTaxInCost = null;
            RcvdDate = null;
            DueDate = null;
            RefType = null;
            RefNum = null;
            RefLineSuf = null;
            RefRelease = null;
            ItemCostConv = null;
            UbSerNumSelected = null;
            UbSerNumGenerateQty = null;
            UbSerNumRangeQty = null;
            ItmSerialPrefix = null;
            DerLUnitFreightCost = null;
            DerFreightCurrCode = null;
            DerFreightCurrCodeDesc = null;
            DerLUnitDutyCost = null;
            DerDutyCurrCode = null;
            DerDutyCurrCodeDesc = null;
            DerLUnitBrokerageCost = null;
            DerBrokerageCurrCode = null;
            DerBrokerageCurrCodeDesc = null;
            DerLUnitInsuranceCost = null;
            DerInsuranceCurrCode = null;
            DerInsuranceCurrCodeDesc = null;
            DerLUnitLocFrtCost = null;
            DerLocFrtCurrCode = null;
            DerLocFrtCurrCodeDesc = null;
            DerNeedsPostReceiveWIP = null;
            Stat = null;
            UbSerNumStatLinkBy = null;
            DerRefDescription = null;
            ItmSerialTracked = null;
            DerDefaultLoc = null;
            UbUnReceiveFlag = null;
            QtyVoucher = null;
            ItemCost = null;
            ItmTaxFreeMatl = null;
            PoContainsOnlyTaxFreeMatls = null;
            UbSImportDocId = null;
            ItemPOToleranceOver = null;
            ItemPOToleranceUnder = null;
            CurrCode = null;

        }


        public bool formatInputs()
        {
            if (string.IsNullOrWhiteSpace(order))
            {
                errorMessage = "order input mandatory";
                return false;
            }

            line = formatDataByIDOAndPropertyName("SLPoItems", "PoLine", line);
            if (line == null || line.Trim().Equals(""))
            {
                errorMessage = "line input mandatory";
                return false;
            }

            release = formatDataByIDOAndPropertyName("SLPoItems", "PoRelease", release);

            if (release == null || release.Trim().Equals(""))
            {
                //errorMessage =  "release input mandatory";
                errorMessage = messageProvider.GetMessage("E=IsRequired", release);

                return false;
            }

            //qty = updateRequest.GetFieldValue("qty");
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

            //  qtyReturned = updateRequest.GetFieldValue("qtyReturned");
            try
            {
                if (Convert.ToDouble(qtyReturned, CultureInfo.InvariantCulture) < 0) // FTDEV-9247
                {
                    //errorMessage =  "Quantity Returned should be 0 or greater";
                    errorMessage = messageProvider.GetMessage("E=NoCompare<", qtyReturned, 0);
                    return false;
                }
            }
            catch (InvalidCastException)
            {
                //  errorMessage =  "Invalid Quantity Returned Input";
                errorMessage = messageProvider.GetMessage("E=Invalid", qtyReturned);
                return false;
            }

            //   item = updateRequest.GetFieldValue("item");
            if (item == null || item.Trim().Equals(""))
            {
                errorMessage = "item input mandatory";
                return false;
            }

            // site = updateRequest.GetFieldValue("site");
            if (site == null || site.Trim().Equals(""))
            {
                errorMessage = "site input mandatory";
                return false;
            }

            // whse = updateRequest.GetFieldValue("whse");
            if (whse == null || whse.Trim().Equals(""))
            {
                errorMessage = "whse input mandatory";
                return false;
            }

            //uom = updateRequest.GetFieldValue("uom");
            if (uom == null || uom.Trim().Equals(""))
            {
                errorMessage = "uom input mandatory";
                return false;
            }

            // reasonCode = updateRequest.GetFieldValue("reasonCode");
            if (Convert.ToDouble(qtyReturned, CultureInfo.InvariantCulture) > 0) // FTDEV-9247
            {
                if (reasonCode == null || reasonCode.Trim().Equals(""))
                {
                    errorMessage = "reasonCode input mandatory";
                    return false;
                }
            }

            lot = formatDataByIDOAndPropertyName("SLLotLocs", "Lot", lot);

            if (generateSerials == true)
            {
                errorMessage = "Serial Generation is not implemented yet.";
                return false;
            }
            if (!((containerNum == null) || containerNum.Trim().Equals("")))
            {
                containerNum = formatDataByIDOAndPropertyName("SLContainers", "ContainerNum", containerNum);

            }
            if (grnNum == null)
            {
                grnNum = "";
            }
            if (grnLine == null)
            {
                grnLine = "";
            }

            return true;
        }


        public bool validateInputs()
        {
            //Validate PO
            if (ValidatePo() == false)
            {
                errorMessage = "Order Details Not Found";
                return false;
            }

            //Validate PO/Line/Release

            if (ValidatePoLineRelease() == false)
            {
                // errorMessage =  "Order/Release/Line Details Not Found";
                errorMessage = messageProvider.GetMessage("E=NoExist3", "PO-NUM", order, "PO-LINE", line, "PO-RELEASE", release);
                return false;
            }

            if (CheckInputs() == false)
            {
                return false;
            }

            //Validate Site
            LoadCollectionResponseData responseData = GetSiteDetails(site);
            if (responseData.Items.Count == 0)
            {
                errorMessage = "Site Details Not Found";
                return false;
            }

            //Check Location
            if (!string.IsNullOrWhiteSpace(loc))
            {
                responseData = GetLocationDetails(loc);
                if (responseData == null || responseData.Items == null || responseData.Items.Count == 0)
                {
                    errorMessage = this.messageProvider.GetMessage("E=OSInvalid", "@location.loc", loc);
                    return false;
                }
            }

            //Check Warehouse
            responseData = GetWhseDetailsBySite(whse, site);
            if (responseData.Items.Count == 0)
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
                //errorMessage =  "Physical Inventory is active in Warehouse : {whse}, Adjustment not allowed";
                errorMessage = constructErrorMessage("Physical Inventory is active in Warehouse : {whse}, Adjustment not allowed", "SLPORecXXXX01", substitutorDictionary);
                return false;
            }

            if (isNonStandardPart)                                              //Kiran 01-09-2012.sn
            {
                if (PerformUOMChanges() == false)
                {
                    return false;
                }

                return true;
            }                                                                   //Kiran 01-09-2012.en            


            //Check Item Details
            responseData = GetItemDetails(formatItem(item));
            if (responseData.Items.Count == 0)
            {
                errorMessage = "Item Details Not Found";
                return false;
            }

            itemLotTracked = GetBool(GetPropertyValue(responseData.PropertyList, responseData.Items, "LotTracked"));
            itemSerialTracked = GetBool(GetPropertyValue(responseData.PropertyList, responseData.Items, "SerialTracked"));
            //ItemBaseUOM = GetPropertyValue(responseData.PropertyList, responseData.Items, "UM");                                      //Kiran 02-27-2012.o

            if (validWhseItemRecordExists(whse, item, allowIfCycleCountExists, out errorMessage) == false)
            {
                return false;
            }

            qtyOnHand = 0;
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
                    errorMessage = "{site} / {whse} / {item} / {loc} combination does not exists, Transfer not allowed";
                    errorMessage = constructErrorMessage(errorMessage, "SLPORecXXXX02", substitutorDictionary);
                    return false;
                }
                else
                {
                    insertItemLocRecord = true;
                    errorMessage = "";
                }
            }


            //Qty Checks - Tolerance Checks

            if (CheckQtyTolerance() == false)
            {
                return false;
            }

            //UOM Checks
            if (PerformUOMChanges() == false)
            {
                return false;
            }


            if (itemLotTracked)
            {
                if (lot == null || lot.Trim().Equals(""))
                {
                    // errorMessage =  "Item is lot controlled, Lot Input is Mandatory";
                    errorMessage = messageProvider.GetMessage("I=IsCompare=1", @itemLotTracked, true, "Lot");

                    return false;
                }


                if (checkIfItemLotExists() == false)
                {
                    if (errorMessage != null && errorMessage.Trim().Length > 0)
                    {
                        return false;
                    }
                    if (generateLot == false)
                    {
                        IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                        substitutorDictionary.Add("lot", lot);
                        //   errorMessage =  "Lot : {lot} doesn't exists";
                        // errorMessage = constructErrorMessage("Lot : {lot} doesn't exists", "SLPORecXXXXX02", substitutorDictionary);
                        errorMessage = messageProvider.GetMessage("E=OSInvalid", "Lot", lot);

                        return false;
                    }
                    else
                    {
                        createNewLot = true;
                    }
                }
                if (createNewLot == false)
                {
                    if (GetManufacturedDetails() == false)
                    {
                        //  errorMessage =  "Error in GetLotManufacturerSp";
                        errorMessage = messageProvider.GetMessage("E=CmdFailed", "GetLotManufacturerSp");
                        return false;
                    }
                }

                if (!string.IsNullOrWhiteSpace(LotMfgDate) && !string.IsNullOrWhiteSpace(LotExpDate) 
                    && DateTime.TryParse(LotMfgDate, out DateTime lotMfgdt) && DateTime.TryParse(LotExpDate, out DateTime lotExpdt))
                {
                    if (DateTime.Compare(lotMfgdt, lotExpdt) > 0)
                    {
                        errorMessage = "Lot Expiration date is greater than its Manufacturing date";
                        return false;
                    }
                }
            }

            if(itemSerialTracked)
            {
                if (!string.IsNullOrWhiteSpace(SerialMfgDate) && !string.IsNullOrWhiteSpace(SerialExpDate) 
                    && DateTime.TryParse(SerialMfgDate, out DateTime serMfgdt) && DateTime.TryParse(SerialExpDate, out DateTime serExpdt))
                {
                    if (DateTime.Compare(serMfgdt, serExpdt) > 0)
                    {
                        errorMessage = "Serial Expiration date is greater than its Manufacturing date";
                        return false;
                    }
                }
            }

            //Container Functionality
            if (this.containerNum != null && !(this.containerNum.Trim().Equals("")))
            {
                if (ValidateQtyForRcvIntoContainerSp(this.item, this.whse, this.loc, this.lot, this.site, out errorMessage) == false)
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

        public int PerformUpdate(out string infobar, out string receiverNum, out string qcHoldLoc,out string voucherNum)
        {
            infobar = "";
            qcHoldLoc = "";
            receiverNum = "";
            voucherNum = string.Empty;
            SerialList = this.GetSerialList(this.sessionID);

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

            if (ValidateSerials() == false)
            {
                infobar = errorMessage;
                return 21;
            }

            //4 Perform Updates
            infobar = performReceipts();
            if (!string.IsNullOrWhiteSpace(infobar))
            {
                IDORuntime.LogUserMessage("PoReceiptUpdate.PerformUpdate : ", UserDefinedMessageType.UserDefined1, infobar);
                return 16;
            }
            qcHoldLoc = holdLoc;
            receiverNum = receiverNo;
            voucherNum = this.voucherNum;
            return 0;
        }
        // #region private methods
        private string performReceipts()
        {
            try
            {
                if (createNewLot == true)
            {
                //(string item,string lot,string qty,string poNum ,string vendorLot,string nonUnique,string site,out string errormessage )
                //performAddLot(item, lot, "0", "0", vendorLot, "1", site, out errorMessage); //removed for the issue  #205142
                if(!performAddvendorLot()) // added  for the issue removed for the issue  #205142
                {
                   return errorMessage;
                }
                SetLotManufacturerSp();
            }


            if (createContainerNum == true)
            {
                PerformCreateContainer(containerNum, whse, loc, out errorMessage);

            }
            //1 Date Check
            object[] dateCheckValues = new object[] { //System.DateTime.Now.ToShortDateString(), 
                                                      SiteDateTime.ToString(WMShortDatePattern), //MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128
                                                      "Transaction Date",
                                                      "@%update",
                                                      "",
                                                      "",
                                                      "" };

            InvokeResponseData invokeResponseDataStep1 = this.Context.Commands.Invoke("SLPeriods", "DateChkSp", dateCheckValues);
            if (!(invokeResponseDataStep1.ReturnValue.Equals("0")))
            {
                errorMessage = invokeResponseDataStep1.Parameters.ElementAt(3).ToString();
                return errorMessage;
            }



            if (this.insertItemLocRecord == true)
            {
                if (addLocItemRecord(item, whse, site, loc, addPermanentItemWhseLocLink) == false)
                {
                        return "3";
                }
            }

            //Delete the current Inventory
            object[] deleteInvValues = new object[] { site,
                                                      "G",
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
                return errorMessage;
            }

            //2 Clear Variables
            if (CheckQCProcess() == false)
            {
                return errorMessage;
            }

            //3 complete receipts steps

            if (CompleteReceiptsSteps() == false)
            {
                return errorMessage;
            }
            

                ClearSerailsBySessionID(this.sessionID);
            }
            catch (Exception e)
            {
                errorMessage = e.Message; 
            }

            return errorMessage;
        }


        public bool checkIfItemLotExists()
        {
            object[] inputValues = new object[] { item,
                                                  lot,
                                                  0,
                                                  0,
                                                  0,
                                                  "",
                                                  site,
                                                  "",
                                                  "" };

            InvokeResponseData responseDataStep = this.Context.Commands.Invoke("SLLots", "RValLotSp", inputValues);

            if (!(responseDataStep.ReturnValue.Equals("0")))
            {
                if (responseDataStep.ReturnValue.Equals("16") && responseDataStep.Parameters.ElementAt(5) != null && !(responseDataStep.Parameters.ElementAt(5).ToString().Trim().Equals("")))
                {
                    errorMessage = responseDataStep.Parameters.ElementAt(5).ToString();
                }
                return false;
            }
            if (responseDataStep.Parameters.ElementAt(2).ToString().Trim().Equals("1") && !(responseDataStep.Parameters.ElementAt(3).ToString().Trim().Equals("")))
            {
                return false;
            }
            if (responseDataStep.Parameters.ElementAt(5) != null && !(responseDataStep.Parameters.ElementAt(5).ToString().Trim().Equals("")))
            {
                return false;
            }
            return true;
        }

        public bool performAddvendorLot()
        {
            string revision = GetRevision();
            object[] inputValues = new object[] { item,
                                                  lot,
                                                  0,
                                                  1,
                                                  vendorLot,
                                                  "1",
                                                  revision,
                                                  "",
                                                  site,
                                                  LotMfgDate,
                                                  LotExpDate,
                                                  LotTrxRestrictCode};
            try
            {
                InvokeResponseData responseDataStep = this.Context.Commands.Invoke("SLLots", "LotAddSp", inputValues);
                if (!(responseDataStep.ReturnValue.Equals("0")))
                {
                    errorMessage = responseDataStep.Parameters.ElementAt(7).ToString();
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    errorMessage = ex.InnerException.Message;                    
                    return false;
                }
            }           
            return true;
        }
        public string GetRevision()
        {
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLPoItems";
            requestData.PropertyList.SetProperties("Revision,PoNum,PoLine");
            requestData.Filter = " PoNum ='" + this.order + "' AND PoLine='"+ line + "'"; 
            requestData.RecordCap = 1;
            requestData.OrderBy = "PoNum";
            LoadCollectionResponseData itemResponseData = ExcuteQueryRequest(requestData);
            if (itemResponseData.Items.Count > 0)
            {
                return Convert.ToString(itemResponseData[0, "Revision"]);               
            }
            return string.Empty;        
        }
        private bool GetManufacturedDetails()
        {
            object[] inputValues = new object[] { item,
                                         lot,
                                         manufactureId,
                                         "",
                                         manufactureItem,
                                         ""};

            manufacturerResponseDataStep = this.Context.Commands.Invoke("SLLotLocs", "GetLotManufacturerSp", inputValues);
            if (!(manufacturerResponseDataStep.ReturnValue.Equals("0")))
            {
                //errorMessage =  "GetLotManufacturerSp method failed";
                errorMessage = messageProvider.GetMessage("E=CmdFailed", "GetLotManufacturerSp");

                return false;
            }

            if (manufactureId.Trim().Equals(""))
            {
                manufactureId = manufacturerResponseDataStep.Parameters.ElementAt(2).ToString();
                manufactureItem = manufacturerResponseDataStep.Parameters.ElementAt(4).ToString();
            }
            else
            {
                if (!(manufactureId.Trim().Equals(manufacturerResponseDataStep.Parameters.ElementAt(2).ToString())))
                {
                    errorMessage = "Input Manufacture Id not matching Lot Manufacture Id :" + manufacturerResponseDataStep.Parameters.ElementAt(2).ToString();
                    return false;
                }
            }

            return true;
        }

        private bool SetLotManufacturerSp()
        {
            object[] inputValues = new object[] { item,
                                         lot,
                                         manufactureId,
                                         manufactureItem,
                                         };

            InvokeResponseData responseDataStep = this.Context.Commands.Invoke("SLLotLocs", "SetLotManufacturerSp", inputValues);
            if (!(responseDataStep.ReturnValue.Equals("0")))
            {
                errorMessage = "SetLotManufacturerSp method failed";
                return false;
            }
            return true;
        }

        private bool ValidatePo()
        {
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLPos";
            requestData.PropertyList.SetProperties("PoNum, Type, Stat, VendNum");
            string filterString = "";
            filterString += " PoNum ='" + order + "'";
            filterString += " and (Stat = 'O' or Stat = 'H')";
            requestData.Filter = filterString;
            requestData.RecordCap = 1;
            requestData.OrderBy = "PoNum";
            poResponseData = ExcuteQueryRequest(requestData);
            if (poResponseData.Items.Count == 0)
            {
                return false;
            }
            return true;
        }

        private bool ValidatePoLineRelease()
        {
            int paramcount = 0;
            paramcount = GetIDOMethodParameterCount("SLPoItems", "CLM_PurchaseOrderReceiving");
            MessageLogging("POReceipt Update: SLPoItems.CLM_PurchaseOrderReceiving param count = " + paramcount, msgLevel.l1_information, 1200002);

            LoadCollectionRequestData requestDataPO = new LoadCollectionRequestData();
            requestDataPO.IDOName = "SLPoItems";
            requestDataPO.PropertyList.SetProperties("PoRelease,PoLine,PoNum,DerBrokerageRate,DerDutyRate,DerFreightRate,DerGrnLine,DerGrnNum,DerInsuranceRate,DerItemExists,DerLocFrtRate,EcCode,Item,RowPointer,UbByCons,UbDRRt,UbGrnExists,UbImportDocId,UbLocation,UbLot,UbPackNum,UbQtyReceived,UbQtyReceivedConv ,UbQtyReturned,UbQtyReturnedConv,UbReasonCode,UbSequence,UbTransDate ,UbWorkKey,UM,UnitBrokerageCost,UnitBrokerageCostConv ,UnitDutyCost,UnitDutyCostConv ,UnitFreightCost,UnitFreightCostConv ,UnitInsuranceCost ,UnitInsuranceCostConv ,UnitLocFrtCost,UnitLocFrtCostConv ,UnitMatCost,UnitMatCostConv,Whse,PoVendNum,UbSelectedReceiving,PoBuilderPoOrigSite,PoBuilderPoNum,UbSLocation,UbSLot,ItmLotTracked,QtyOrdered,QtyReceived,ItmDescription ,QtyRejected,PoOrderDate,VendItem,POIncludeTaxInCost,RcvdDate,DueDate,RefType,RefNum,RefLineSuf,RefRelease,ItemCostConv,UbSerNumSelected,UbSerNumGenerateQty,UbSerNumRangeQty,ItmSerialPrefix,DerLUnitFreightCost ,DerFreightCurrCode,DerFreightCurrCodeDesc,DerLUnitDutyCost,DerDutyCurrCode,DerDutyCurrCodeDesc,DerLUnitBrokerageCost,DerBrokerageCurrCode,DerBrokerageCurrCodeDesc,DerLUnitInsuranceCost,DerInsuranceCurrCode,DerInsuranceCurrCodeDesc,DerLUnitLocFrtCost,DerLocFrtCurrCode,DerLocFrtCurrCodeDesc,DerNeedsPostReceiveWIP,Stat,UbSerNumStatLinkBy,DerRefDescription,ItmSerialTracked,DerDefaultLoc,UbUnReceiveFlag,QtyVoucher,ItemCost,ItmTaxFreeMatl,PoContainsOnlyTaxFreeMatls,UbSImportDocId,ItemPOToleranceOver,ItemPOToleranceUnder,CurrCode,ManufacturerId,ManufacturerItem");
            requestDataPO.Filter = "(Stat = 'O' or Stat = 'H') and Whse = '" + whse + "'";
            CustomLoadMethod customLoadMethod = new CustomLoadMethod();
            customLoadMethod.Name = "CLM_PurchaseOrderReceiving";

            InvokeParameterList parameterList = new InvokeParameterList();
            parameterList.Add(whse);
            parameterList.Add(GetPropertyValue(poResponseData, "VendNum"));
            parameterList.Add("");
            parameterList.Add("");
            parameterList.Add("");
            parameterList.Add("");
            parameterList.Add("0");
            parameterList.Add(order);
            parameterList.Add(line);
            parameterList.Add(release);
            //parameterList.Add("O");

            parameterList.Add("OF");
            if (paramcount == 12)
            {
                parameterList.Add(SiteDateTime.ToString(WMShortDatePattern));   // New property added to support SL9.00
            }
            customLoadMethod.Parameters = parameterList;

            requestDataPO.CustomLoadMethod = customLoadMethod;
            requestDataPO.RecordCap = -1;
            poLineReleaseResponseData = ExcuteQueryRequest(requestDataPO);
            if (poLineReleaseResponseData.Items.Count == 0)
            {
                return false;
            }

            DerBrokerageRate = GetPropertyValue(poLineReleaseResponseData, "DerBrokerageRate");
            DerDutyRate = GetPropertyValue(poLineReleaseResponseData, "DerDutyRate");
            DerFreightRate = GetPropertyValue(poLineReleaseResponseData, "DerFreightRate");
            DerGrnLine = GetPropertyValue(poLineReleaseResponseData, "DerGrnLine");
            DerGrnNum = GetPropertyValue(poLineReleaseResponseData, "DerGrnNum");
            DerInsuranceRate = GetPropertyValue(poLineReleaseResponseData, "DerInsuranceRate");
            DerItemExists = GetPropertyValue(poLineReleaseResponseData, "DerItemExists");
            DerLocFrtRate = GetPropertyValue(poLineReleaseResponseData, "DerLocFrtRate");
            EcCode = GetPropertyValue(poLineReleaseResponseData, "EcCode");
            Item = GetPropertyValue(poLineReleaseResponseData, "Item");
            ItemBaseUOM = GetPropertyValue(poLineReleaseResponseData, "UM");                                                //Kiran 02-27-2012.n
            RowPointer = GetPropertyValue(poLineReleaseResponseData, "RowPointer");
            UbByCons = GetPropertyValue(poLineReleaseResponseData, "UbByCons");
            //UbDRRt = GetPropertyValue(poLineReleaseResponseData, "UbDRRt");

            if (drReturn != null && !(drReturn.Trim().Equals("")))
            {
                UbDRRt = drReturn;
            }
            else
            {
                UbDRRt = GetPropertyValue(poLineReleaseResponseData, "UbDRRt");
            }
            if (string.IsNullOrEmpty(UbDRRt))
                UbDRRt = "0";
            UbGrnExists = GetPropertyValue(poLineReleaseResponseData, "UbGrnExists");
            UbImportDocId = GetPropertyValue(poLineReleaseResponseData, "UbImportDocId");
            UbLocation = GetPropertyValue(poLineReleaseResponseData, "UbLocation");
            UbLot = GetPropertyValue(poLineReleaseResponseData, "UbLot");
            if (packingSlipNumber != null)
            {
                UbPackNum = packingSlipNumber;
            }
            else
            {
                UbPackNum = GetPropertyValue(poLineReleaseResponseData, "UbPackNum");
            }
            UbQtyReceived = GetPropertyValue(poLineReleaseResponseData, "UbQtyReceived");
            UbQtyReceivedConv = GetPropertyValue(poLineReleaseResponseData, "UbQtyReceivedConv");
            UbQtyReturned = GetPropertyValue(poLineReleaseResponseData, "UbQtyReturned");
            UbQtyReturnedConv = GetPropertyValue(poLineReleaseResponseData, "UbQtyReturnedConv");
            UbReasonCode = GetPropertyValue(poLineReleaseResponseData, "UbReasonCode");
            UbSequence = GetPropertyValue(poLineReleaseResponseData, "UbSequence");
            UbTransDate = GetPropertyValue(poLineReleaseResponseData, "UbTransDate");
            UbWorkKey = "RCPT" + RowPointer + "0";
            UM = GetPropertyValue(poLineReleaseResponseData, "UM");
            UnitBrokerageCost = GetPropertyValue(poLineReleaseResponseData, "UnitBrokerageCost");
            UnitBrokerageCostConv = GetPropertyValue(poLineReleaseResponseData, "UnitBrokerageCostConv");
            UnitDutyCost = GetPropertyValue(poLineReleaseResponseData, "UnitDutyCost");
            UnitDutyCostConv = GetPropertyValue(poLineReleaseResponseData, "UnitDutyCostConv");
            UnitFreightCost = GetPropertyValue(poLineReleaseResponseData, "UnitFreightCost");
            UnitFreightCostConv = GetPropertyValue(poLineReleaseResponseData, "UnitFreightCostConv");
            UnitInsuranceCost = GetPropertyValue(poLineReleaseResponseData, "UnitInsuranceCost");
            UnitInsuranceCostConv = GetPropertyValue(poLineReleaseResponseData, "UnitInsuranceCostConv");
            UnitLocFrtCost = GetPropertyValue(poLineReleaseResponseData, "UnitLocFrtCost");
            UnitLocFrtCostConv = GetPropertyValue(poLineReleaseResponseData, "UnitLocFrtCostConv");
            UnitMatCost = GetPropertyValue(poLineReleaseResponseData, "UnitMatCost");
            UnitMatCostConv = GetPropertyValue(poLineReleaseResponseData, "UnitMatCostConv");
            Whse = GetPropertyValue(poLineReleaseResponseData, "Whse");
            PoVendNum = GetPropertyValue(poLineReleaseResponseData, "PoVendNum");
            UbSelectedReceiving = GetPropertyValue(poLineReleaseResponseData, "UbSelectedReceiving");
            PoBuilderPoOrigSite = GetPropertyValue(poLineReleaseResponseData, "PoBuilderPoOrigSite");
            PoBuilderPoNum = GetPropertyValue(poLineReleaseResponseData, "PoBuilderPoNum");
            UbSLocation = GetPropertyValue(poLineReleaseResponseData, "UbSLocation");
            UbSLot = GetPropertyValue(poLineReleaseResponseData, "UbSLot");
            ItmLotTracked = GetPropertyValue(poLineReleaseResponseData, "ItmLotTracked");

            if (ItmLotTracked.ToString().Trim().Equals(""))
            {
                isNonStandardPart = true;
            }
            else
            {
                isNonStandardPart = false;
            }

            QtyOrdered = GetPropertyValue(poLineReleaseResponseData, "QtyOrdered");
            QtyReceived = GetPropertyValue(poLineReleaseResponseData, "QtyReceived");
            ItmDescription = GetPropertyValue(poLineReleaseResponseData, "ItmDescription");
            QtyRejected = GetPropertyValue(poLineReleaseResponseData, "QtyRejected");
            PoOrderDate = GetPropertyValue(poLineReleaseResponseData, "PoOrderDate");
            VendItem = GetPropertyValue(poLineReleaseResponseData, "VendItem");
            POIncludeTaxInCost = GetPropertyValue(poLineReleaseResponseData, "POIncludeTaxInCost");
            RcvdDate = GetPropertyValue(poLineReleaseResponseData, "RcvdDate");
            DueDate = GetPropertyValue(poLineReleaseResponseData, "DueDate");
            RefType = GetPropertyValue(poLineReleaseResponseData, "RefType");
            RefNum = GetPropertyValue(poLineReleaseResponseData, "RefNum");
            RefLineSuf = GetPropertyValue(poLineReleaseResponseData, "RefLineSuf");
            RefRelease = GetPropertyValue(poLineReleaseResponseData, "RefRelease");
            ItemCostConv = GetPropertyValue(poLineReleaseResponseData, "ItemCostConv");
            UbSerNumSelected = GetPropertyValue(poLineReleaseResponseData, "UbSerNumSelected");
            UbSerNumGenerateQty = GetPropertyValue(poLineReleaseResponseData, "UbSerNumGenerateQty");
            UbSerNumRangeQty = GetPropertyValue(poLineReleaseResponseData, "UbSerNumRangeQty");
            ItmSerialPrefix = GetPropertyValue(poLineReleaseResponseData, "ItmSerialPrefix");
            DerLUnitFreightCost = GetPropertyValue(poLineReleaseResponseData, "DerLUnitFreightCost");
            DerFreightCurrCode = GetPropertyValue(poLineReleaseResponseData, "DerFreightCurrCode");
            DerFreightCurrCodeDesc = GetPropertyValue(poLineReleaseResponseData, "DerFreightCurrCodeDesc");
            DerLUnitDutyCost = GetPropertyValue(poLineReleaseResponseData, "DerLUnitDutyCost");
            DerDutyCurrCode = GetPropertyValue(poLineReleaseResponseData, "DerDutyCurrCode");
            DerDutyCurrCodeDesc = GetPropertyValue(poLineReleaseResponseData, "DerDutyCurrCodeDesc");
            DerLUnitBrokerageCost = GetPropertyValue(poLineReleaseResponseData, "DerLUnitBrokerageCost");
            DerBrokerageCurrCode = GetPropertyValue(poLineReleaseResponseData, "DerBrokerageCurrCode");
            DerBrokerageCurrCodeDesc = GetPropertyValue(poLineReleaseResponseData, "DerBrokerageCurrCodeDesc");
            DerLUnitInsuranceCost = GetPropertyValue(poLineReleaseResponseData, "DerLUnitInsuranceCost");
            DerInsuranceCurrCode = GetPropertyValue(poLineReleaseResponseData, "DerInsuranceCurrCode");
            DerInsuranceCurrCodeDesc = GetPropertyValue(poLineReleaseResponseData, "DerInsuranceCurrCodeDesc");
            DerLUnitLocFrtCost = GetPropertyValue(poLineReleaseResponseData, "DerLUnitLocFrtCost");
            DerLocFrtCurrCode = GetPropertyValue(poLineReleaseResponseData, "DerLocFrtCurrCode");
            DerLocFrtCurrCodeDesc = GetPropertyValue(poLineReleaseResponseData, "DerLocFrtCurrCodeDesc");
            DerNeedsPostReceiveWIP = GetPropertyValue(poLineReleaseResponseData, "DerNeedsPostReceiveWIP");
            Stat = GetPropertyValue(poLineReleaseResponseData, "Stat");
            UbSerNumStatLinkBy = GetPropertyValue(poLineReleaseResponseData, "UbSerNumStatLinkBy");
            DerRefDescription = GetPropertyValue(poLineReleaseResponseData, "DerRefDescription");
            ItmSerialTracked = GetPropertyValue(poLineReleaseResponseData, "ItmSerialTracked");
            DerDefaultLoc = GetPropertyValue(poLineReleaseResponseData, "DerDefaultLoc");
            UbUnReceiveFlag = GetPropertyValue(poLineReleaseResponseData, "UbUnReceiveFlag");
            QtyVoucher = GetPropertyValue(poLineReleaseResponseData, "QtyVoucher");
            ItemCost = GetPropertyValue(poLineReleaseResponseData, "ItemCost");
            ItmTaxFreeMatl = GetPropertyValue(poLineReleaseResponseData, "ItmTaxFreeMatl");
            PoContainsOnlyTaxFreeMatls = GetPropertyValue(poLineReleaseResponseData, "PoContainsOnlyTaxFreeMatls");
            UbSImportDocId = GetPropertyValue(poLineReleaseResponseData, "UbSImportDocId");
            ItemPOToleranceOver = GetPropertyValue(poLineReleaseResponseData, "ItemPOToleranceOver");
            ItemPOToleranceUnder = GetPropertyValue(poLineReleaseResponseData, "ItemPOToleranceUnder");
            CurrCode = GetPropertyValue(poLineReleaseResponseData, "CurrCode");
            manufactureId = GetPropertyValue(poLineReleaseResponseData, "ManufacturerId");
            manufactureItem = GetPropertyValue(poLineReleaseResponseData, "ManufacturerItem");
            return true;
        }

        private bool CheckInputs()
        {
            if (!(item.Trim().ToUpper().Equals(GetPropertyValue(poLineReleaseResponseData, "Item").Trim().ToUpper())))
            {
                IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                substitutorDictionary.Add("{item}", item);
                substitutorDictionary.Add("{sub1}", GetPropertyValue(poLineReleaseResponseData, "Item"));
                errorMessage = "Item : {item} Not Matching PO/Release/Line Item : {sub1}";
                errorMessage = constructErrorMessage(errorMessage, "SLPORecXXXX03", substitutorDictionary);
                return false;
            }

            if (!(whse.Trim().ToUpper().Equals(GetPropertyValue(poLineReleaseResponseData, "Whse").Trim().ToUpper())))
            {
                IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                substitutorDictionary.Add("{whse}", whse);
                substitutorDictionary.Add("{sub1}", GetPropertyValue(poLineReleaseResponseData, "Whse"));
                errorMessage = "Whse : {whse} Not Matching PO/Release/Line Item :{sub1}";
                errorMessage = constructErrorMessage(errorMessage, "SLPORecXXXX04", substitutorDictionary);
                return false;
            }
            return true;
        }

        private bool CheckQtyTolerance()
        {
            decimal dOrderedQty = Convert.ToDecimal(QtyOrdered, CultureInfo.InvariantCulture); // FTDEV-9247
            decimal dTotalForLine = Convert.ToDecimal(QtyReceived, CultureInfo.InvariantCulture); // FTDEV-9247
            decimal dQtyReceivedByUser = Convert.ToDecimal(qty, CultureInfo.InvariantCulture); // FTDEV-9247
            decimal ItemPOToleranceOver = 0;
            decimal ItemPOToleranceUnder = 0;

            if (GetPropertyValue(poLineReleaseResponseData, "ItemPOToleranceOver") != null && !(GetPropertyValue(poLineReleaseResponseData, "ItemPOToleranceOver").Trim().Equals("")))
            {
                ItemPOToleranceOver = Convert.ToDecimal(GetPropertyValue(poLineReleaseResponseData, "ItemPOToleranceOver").Trim(), CultureInfo.InvariantCulture); // FTDEV-9247
            }

            if (GetPropertyValue(poLineReleaseResponseData, "ItemPOToleranceUnder") != null && !(GetPropertyValue(poLineReleaseResponseData, "ItemPOToleranceUnder").Trim().Equals("")))
            {
                ItemPOToleranceUnder = Convert.ToDecimal(GetPropertyValue(poLineReleaseResponseData, "ItemPOToleranceUnder").Trim(), CultureInfo.InvariantCulture); // FTDEV-9247
            }

            if (dTotalForLine > dOrderedQty)
            {
                if (this.overrideQtyTolerance == false)
                {
                    if (dTotalForLine > (dOrderedQty + (dOrderedQty * ItemPOToleranceOver / 100)))
                    {
                        errorMessage = "Quantity Exceeds Upper Tolerance Limit";
                        return false;
                    }
                }
            }
            else
            {
                if (this.overrideQtyTolerance == false)
                {
                    if (dTotalForLine < (dOrderedQty - (dOrderedQty * ItemPOToleranceUnder / 100)))
                    {
                        errorMessage = "Quantity below Lower Tolerance Limit";
                        return false;
                    }
                }
            }

            dTotalForLine = dTotalForLine + dQtyReceivedByUser;


            return true;
        }

        private bool PerformUOMChanges()
        {
            if (performUOMCheck1() == false)
            {
                return false;
            }

            if (performUOMCheck2() == false)
            {
                return false;
            }

            if (performUOMCheck3() == false)
            {
                return false;
            }

            if (performUOMCheck4() == false)
            {
                return false;
            }
            return true;
        }

        private bool performUOMCheck1()
        {
            object[] requestInputs = new object[]{
                                                UnitMatCostConv,
                                                UnitBrokerageCostConv,
                                                UnitDutyCostConv,
                                                UnitFreightCostConv,
                                                ItemCostConv,
                                                QtyOrdered,
                                                QtyReceived,
                                                QtyRejected,
                                                Item,
                                                ItemBaseUOM,
                                                uom,
                                                PoVendNum,
                                                ""
                                                };
            InvokeResponseData receiveUMChangedresponseData = InvokeIDO("SLPoItems", "POReceiveUMChangedSp", requestInputs);
            if (!(receiveUMChangedresponseData.ReturnValue.Equals("0")))
            {
                errorMessage = receiveUMChangedresponseData.Parameters.ElementAt(12).ToString();
                return false;
            }

            UnitMatCostConv = receiveUMChangedresponseData.Parameters.ElementAt(0).ToString();
            UnitBrokerageCostConv = receiveUMChangedresponseData.Parameters.ElementAt(1).ToString();
            UnitDutyCostConv = receiveUMChangedresponseData.Parameters.ElementAt(2).ToString();
            UnitFreightCostConv = receiveUMChangedresponseData.Parameters.ElementAt(3).ToString();
            ItemCostConv = receiveUMChangedresponseData.Parameters.ElementAt(4).ToString();
            QtyOrdered = receiveUMChangedresponseData.Parameters.ElementAt(5).ToString();
            QtyReceived = receiveUMChangedresponseData.Parameters.ElementAt(6).ToString();
            QtyRejected = receiveUMChangedresponseData.Parameters.ElementAt(7).ToString();

            return true;

        }

        private bool performUOMCheck2()
        {
            object[] requestInputs = new object[]{
                                    qty,
                                    qtyReturned,
                                    UnitMatCostConv,
                                    UnitBrokerageCostConv,
                                    UnitDutyCostConv,
                                    UnitFreightCostConv,
                                    UnitInsuranceCostConv,
                                    UnitLocFrtCostConv,
                                    ItemCostConv,
                                    Item,
                                    uom,
                                    PoVendNum,
                                    UbQtyReceived,
                                    UbQtyReturned,
                                    UnitMatCost,
                                    UnitBrokerageCost,
                                    UnitDutyCost,
                                    UnitFreightCost,
                                    UnitInsuranceCost,
                                    UnitLocFrtCost,
                                    ItemCost,
                                    ""
                                    };

            InvokeResponseData receiveUMChangedresponseData = InvokeIDO("SLPoItems", "POReceiveQtyConvWrapperSp", requestInputs);
            if (!(receiveUMChangedresponseData.ReturnValue.Equals("0")))
            {
                errorMessage = receiveUMChangedresponseData.Parameters.ElementAt(21).ToString();
                return false;
            }

            ItemCostConv = receiveUMChangedresponseData.Parameters.ElementAt(8).ToString();
            UbQtyReceived = receiveUMChangedresponseData.Parameters.ElementAt(12).ToString();
            UbQtyReturned = receiveUMChangedresponseData.Parameters.ElementAt(13).ToString();
            UnitMatCost = receiveUMChangedresponseData.Parameters.ElementAt(14).ToString();
            UnitBrokerageCost = receiveUMChangedresponseData.Parameters.ElementAt(15).ToString();
            UnitDutyCost = receiveUMChangedresponseData.Parameters.ElementAt(16).ToString();
            UnitFreightCost = receiveUMChangedresponseData.Parameters.ElementAt(17).ToString();
            UnitInsuranceCost = receiveUMChangedresponseData.Parameters.ElementAt(18).ToString();
            UnitLocFrtCost = receiveUMChangedresponseData.Parameters.ElementAt(19).ToString();
            ItemCost = receiveUMChangedresponseData.Parameters.ElementAt(20).ToString();

            return true;
        }

        private bool performUOMCheck3()
        {
            object[] requestInputs = new object[]{
                                    "DoConvert",
                                    "1",
                                    ""
                                    };

            InvokeResponseData receiveUMChangedresponseData = InvokeIDO("MGCore.DefineVariables", "DefineVariableSp", requestInputs);
            if (!(receiveUMChangedresponseData.ReturnValue.Equals("0")))
            {
                errorMessage = receiveUMChangedresponseData.Parameters.ElementAt(2).ToString();
                return false;
            }
            return true;
        }
        private bool performUOMCheck4()
        {
            object[] requestInputs = new object[]{
                                    PoVendNum,
                                    order,
                                    UnitDutyCost,
                                    UnitFreightCost,
                                    UnitBrokerageCost,
                                    UnitInsuranceCost,
                                    UnitLocFrtCost,
                                    UnitDutyCostConv,
                                    UnitFreightCostConv,
                                    UnitBrokerageCostConv,
                                    UnitInsuranceCostConv,
                                    UnitLocFrtCostConv,
                                    DerLUnitDutyCost,
                                    DerLUnitFreightCost,
                                    DerLUnitBrokerageCost,
                                    DerLUnitInsuranceCost,
                                    DerLUnitLocFrtCost,
                                    DerDutyRate,
                                    DerFreightRate,
                                    DerBrokerageRate,
                                    DerInsuranceRate,
                                    DerLocFrtRate,
                                    DerDutyCurrCode,
                                    DerFreightCurrCode,
                                    DerBrokerageCurrCode,
                                    DerInsuranceCurrCode,
                                    DerLocFrtCurrCode,
                                    ItemCost,
                                    ItemCostConv,
                                    UnitMatCost,
                                    UnitMatCostConv,
                                    "FDBIL",
                                    "C",
                                    uom,
                                    Item,
                                    "",
                                    ""
                                    };

            InvokeResponseData receiveUMChangedresponseData = InvokeIDO("SLPoItems", "POReceivingConvertCostSp", requestInputs);
            if (!(receiveUMChangedresponseData.ReturnValue.Equals("0")))
            {
                errorMessage = receiveUMChangedresponseData.Parameters.ElementAt(35).ToString();
                return false;
            }

            UnitDutyCost = receiveUMChangedresponseData.Parameters.ElementAt(2).ToString();
            UnitFreightCost = receiveUMChangedresponseData.Parameters.ElementAt(3).ToString();
            UnitBrokerageCost = receiveUMChangedresponseData.Parameters.ElementAt(4).ToString();
            UnitInsuranceCost = receiveUMChangedresponseData.Parameters.ElementAt(5).ToString();
            UnitLocFrtCost = receiveUMChangedresponseData.Parameters.ElementAt(6).ToString();
            UnitDutyCostConv = receiveUMChangedresponseData.Parameters.ElementAt(7).ToString();
            UnitFreightCostConv = receiveUMChangedresponseData.Parameters.ElementAt(8).ToString();
            UnitBrokerageCostConv = receiveUMChangedresponseData.Parameters.ElementAt(9).ToString();
            UnitInsuranceCostConv = receiveUMChangedresponseData.Parameters.ElementAt(10).ToString();
            UnitLocFrtCostConv = receiveUMChangedresponseData.Parameters.ElementAt(11).ToString();
            DerLUnitDutyCost = receiveUMChangedresponseData.Parameters.ElementAt(12).ToString();
            DerLUnitFreightCost = receiveUMChangedresponseData.Parameters.ElementAt(13).ToString();
            DerLUnitBrokerageCost = receiveUMChangedresponseData.Parameters.ElementAt(14).ToString();
            DerLUnitInsuranceCost = receiveUMChangedresponseData.Parameters.ElementAt(15).ToString();
            DerLUnitLocFrtCost = receiveUMChangedresponseData.Parameters.ElementAt(16).ToString();

            ItemCost = receiveUMChangedresponseData.Parameters.ElementAt(27).ToString();
            ItemCostConv = receiveUMChangedresponseData.Parameters.ElementAt(28).ToString();
            UnitMatCost = receiveUMChangedresponseData.Parameters.ElementAt(29).ToString();
            UnitMatCostConv = receiveUMChangedresponseData.Parameters.ElementAt(30).ToString();

            return true;
        }

        private bool CompleteReceiptsSteps()
        {
            try
            {

                int paramcount = 0;
                paramcount = GetIDOMethodParameterCount("SLPoItems", "PoReceivePopulateTtRcvSp");
                MessageLogging("PO Receipt Update: SLPoItems.PoReceivePopulateTtRcvSp param count = " + paramcount, msgLevel.l1_information, 1200002);

                IDOUpdateItem updateItem = new IDOUpdateItem();
                updateItem.Action = UpdateAction.Update;

                updateItem.Properties.Add("PoRelease", release, false);
                updateItem.Properties.Add("PoLine", line, false);
                updateItem.Properties.Add("PoNum", order, false);
                updateItem.Properties.Add("DerBrokerageRate", DerBrokerageRate, false);
                updateItem.Properties.Add("DerDutyRate", DerDutyRate, false);
                updateItem.Properties.Add("DerFreightRate", DerFreightRate, false);
                if (grnNum == "")
                {
                    updateItem.Properties.Add("DerGrnLine", DerGrnLine, false);
                    updateItem.Properties.Add("DerGrnNum", DerGrnNum, false);

                }
                else
                {
                    //updateItem.Properties.Add("DerGrnLine", DerGrnLine, false);
                    //updateItem.Properties.Add("DerGrnNum", DerGrnNum, false);
                    updateItem.Properties.Add("DerGrnLine", grnLine, false);
                    updateItem.Properties.Add("DerGrnNum", grnNum, false);
                }
                updateItem.Properties.Add("DerInsuranceRate", DerInsuranceRate, false);
                updateItem.Properties.Add("DerItemExists", DerItemExists, false);
                updateItem.Properties.Add("DerLocFrtRate", DerLocFrtRate, false);
                updateItem.Properties.Add("EcCode", EcCode, false);
                updateItem.Properties.Add("Item", Item, false);
                updateItem.Properties.Add("ManufacturerId", manufactureId, false);
                updateItem.Properties.Add("ManufacturerItem", manufactureItem, false);

                //Console.WriteLine("after 1");
                MessageLogging("PoReceiptUpdate.CompleteReceiptsSteps: after 1", msgLevel.l1_information, 1200002);

                updateItem.Properties.Add("RowPointer", RowPointer, false);
                updateItem.Properties.Add("UbByCons", UbByCons, false);             
                updateItem.Properties.Add("UbDRRt", UbDRRt, false);
                updateItem.Properties.Add("UbGrnExists", UbGrnExists, false);
                updateItem.Properties.Add("UbImportDocId", UbImportDocId, false);
                updateItem.Properties.Add("UbLocation", loc, false);
                updateItem.Properties.Add("UbLot", lot, false);
                updateItem.Properties.Add("UbPackNum", UbPackNum, false);
                updateItem.Properties.Add("UbQtyReceived", UbQtyReceived, false);
                updateItem.Properties.Add("UbQtyReceivedConv", qty, false);
                updateItem.Properties.Add("UbQtyReturned", UbQtyReturned, false);
                updateItem.Properties.Add("UbQtyReturnedConv", UbQtyReturnedConv, false);
                updateItem.Properties.Add("UbReasonCode", reasonCode, false);
                updateItem.Properties.Add("UbSequence", "0", false);
                updateItem.Properties.Add("UbTransDate", SiteDateTime, false);
                //updateItem.Properties.Add("UbTransDate", System.DateTime.Now.ToString(WMLongDateTimePattern), false); // FTDEV-9195 - Adding Time to the date/time string passed into CSI
                updateItem.Properties.Add("UbWorkKey", UbWorkKey.ToString());

                //Console.WriteLine("after 2");
                MessageLogging("PoReceiptUpdate.CompleteReceiptsSteps: after 2", msgLevel.l1_information, 1200002);
                updateItem.Properties.Add("UM", uom, false);
                updateItem.Properties.Add("UnitBrokerageCost", UnitBrokerageCost, false);
                updateItem.Properties.Add("UnitBrokerageCostConv", UnitBrokerageCostConv, false);

                updateItem.Properties.Add("UnitDutyCost", UnitDutyCost, false);
                updateItem.Properties.Add("UnitDutyCostConv", UnitDutyCostConv, false);
                updateItem.Properties.Add("UnitFreightCost", UnitFreightCost, false);
                updateItem.Properties.Add("UnitFreightCostConv", UnitFreightCostConv, false);
                updateItem.Properties.Add("UnitInsuranceCost", UnitInsuranceCost, false);
                updateItem.Properties.Add("UnitInsuranceCostConv", UnitInsuranceCostConv, false);
                updateItem.Properties.Add("UnitLocFrtCost", UnitLocFrtCost, false);
                updateItem.Properties.Add("UnitLocFrtCostConv", UnitLocFrtCostConv, false);
                updateItem.Properties.Add("UnitMatCost", UnitMatCost, false);
                updateItem.Properties.Add("UnitMatCostConv", UnitMatCostConv, false);
                updateItem.Properties.Add("Whse", Whse, false);              
                //8.03

                //Console.WriteLine("after 3");
                MessageLogging("PoReceiptUpdate.CompleteReceiptsSteps: after 3", msgLevel.l1_information, 1200002);
                updateItem.Properties.Add("UbContainerNum", string.IsNullOrEmpty(containerNum) ? "" : containerNum, false);               
                updateItem.Properties.Add("UbEsigEncryptedPassword", UbEsigEncryptedPassword, false);
                updateItem.Properties.Add("UbEsigReasonCode", UbEsigReasonCode, false);
                updateItem.Properties.Add("UbEsigRowPointer", UbEsigRowPointer, false);
                updateItem.Properties.Add("UbEsigUserName", UbEsigUserName, false);

                updateItem.Properties.Add("DerEnableContainer", "1", false);
                updateItem.Properties.Add("PreassignLots", "0", false);
                updateItem.Properties.Add("PreassignSerials", "0", false);

                if (itemLotTracked)
                {
                    //Console.WriteLine("itemLotTracked"); //related to i5702748/MSF152359
                    MessageLogging("PoReceiptUpdate.CompleteReceiptsSteps: itemLotTracked ", msgLevel.l1_information, 1200002);
                    if (manufacturerResponseDataStep != null)
                    {
                        updateItem.Properties.Add("ManufacturerItemDesc", manufacturerResponseDataStep.Parameters.ElementAt(5).ToString(), false);

                        //i5702748/MSF152359:  Can not have a property in the list more than one time.  JH:20120831                                        
                        updateItem.Properties.Add("ManufacturerName", manufacturerResponseDataStep.Parameters.ElementAt(3).ToString(), false);
                    }
                    updateItem.Properties.Add("UbManufacturerId", manufactureId);
                    if (manufacturerResponseDataStep != null)
                    {
                        updateItem.Properties.Add("UbManName", manufacturerResponseDataStep.Parameters.ElementAt(3).ToString());

                        //i5702748/MSF152359:  Can not have a property in the list more than one time.  JH:20120831
                        //updateItem.Properties.Add("ManufacturerName", this.manufactureItem);

                        updateItem.Properties.Add("UbManitemDescription", manufacturerResponseDataStep.Parameters.ElementAt(5).ToString());
                    }
                }
                else
                {
                    #region Not lot tracked
                    //Console.WriteLine("Not lot tracked"); //related to i5702748/MSF152359
                    MessageLogging("PoReceiptUpdate.CompleteReceiptsSteps: Not lot tracked", msgLevel.l1_information, 1200002);
                    updateItem.Properties.Add("ManufacturerItemDesc", "", false);
                    //i5702748/MSF152359:  Can not have a property in the list more than one time.  JH:20120831                    
                    updateItem.Properties.Add("ManufacturerName", "", false);
                    updateItem.Properties.Add("UbManufacturerId", "");

                    updateItem.Properties.Add("UbManName", "");
                    //i5702748/MSF152359:  Can not have a property in the list more than one time.  JH:20120831
                    //updateItem.Properties.Add("ManufacturerName", "");
                    updateItem.Properties.Add("UbManitemDescription", "");
                    #endregion
                }

                //Console.WriteLine("after 4");

                //end 8.03
                updateItem.Properties.Add("PoVendNum", PoVendNum, false);
                updateItem.Properties.Add("UbSelectedReceiving", UbSelectedReceiving, false);
                updateItem.Properties.Add("UbSLocation", UbSLocation, false);
                updateItem.Properties.Add("PoBuilderPoOrigSite", PoBuilderPoOrigSite, false);
                updateItem.Properties.Add("UbToContainer", "", false);
                updateItem.Properties.Add("PoBuilderPoNum", PoBuilderPoNum, false);

                updateItem.Properties.Add("UbSLot", UbSLot, false);
                updateItem.Properties.Add("UbSImportDocId", "", false);

                updateItem.Properties.Add("ItmDescription", ItmDescription, false);
                updateItem.Properties.Add("ItmLotTracked", ItmLotTracked, false);
                updateItem.Properties.Add("ItmLotPrefix", "", false);           //need to check

                updateItem.Properties.Add("VendItem", VendItem, false);
                updateItem.Properties.Add("QtyOrdered", QtyOrdered, false);
                updateItem.Properties.Add("QtyReceived", QtyReceived, false);
                updateItem.Properties.Add("QtyRejected", QtyRejected, false);

                updateItem.Properties.Add("POIncludeTaxInCost", POIncludeTaxInCost, false);
                updateItem.Properties.Add("PoOrderDate", PoOrderDate, false);
                updateItem.Properties.Add("RcvdDate", RcvdDate, false);

                updateItem.Properties.Add("DueDate", DueDate, false);
                updateItem.Properties.Add("RefType", RefType, false);
                updateItem.Properties.Add("RefNum", RefNum, false);
                updateItem.Properties.Add("RefLineSuf", RefLineSuf, false);
                updateItem.Properties.Add("RefRelease", RefRelease, false);


                updateItem.Properties.Add("ItemCostConv", ItemCostConv, false);
                updateItem.Properties.Add("UbSerNumSelected", UbSerNumSelected, false);
                updateItem.Properties.Add("UbSerNumGenerateQty", UbSerNumGenerateQty, false);
                updateItem.Properties.Add("UbSerNumRangeQty", UbSerNumRangeQty, false);
                updateItem.Properties.Add("ItmSerialPrefix", ItmSerialPrefix, false);

                updateItem.Properties.Add("DerLUnitFreightCost", DerLUnitFreightCost, false);
                updateItem.Properties.Add("DerFreightCurrCode", DerFreightCurrCode, false);
                updateItem.Properties.Add("DerFreightCurrCodeDesc", DerFreightCurrCodeDesc, false);
                updateItem.Properties.Add("DerLUnitDutyCost", DerLUnitDutyCost, false);
                updateItem.Properties.Add("DerDutyCurrCode", DerDutyCurrCode, false);

                updateItem.Properties.Add("DerDutyCurrCodeDesc", DerDutyCurrCodeDesc, false);
                updateItem.Properties.Add("DerLUnitBrokerageCost", DerLUnitBrokerageCost, false);
                updateItem.Properties.Add("DerBrokerageCurrCode", DerBrokerageCurrCode, false);
                updateItem.Properties.Add("DerBrokerageCurrCodeDesc", DerBrokerageCurrCodeDesc, false);
                updateItem.Properties.Add("DerLUnitInsuranceCost", DerLUnitInsuranceCost, false);

                updateItem.Properties.Add("DerInsuranceCurrCode", DerInsuranceCurrCode, false);
                updateItem.Properties.Add("DerInsuranceCurrCodeDesc", DerInsuranceCurrCodeDesc, false);
                updateItem.Properties.Add("DerLUnitLocFrtCost", DerLUnitLocFrtCost, false);
                updateItem.Properties.Add("DerLocFrtCurrCode", DerLocFrtCurrCode, false);
                updateItem.Properties.Add("DerLocFrtCurrCodeDesc", DerLocFrtCurrCodeDesc, false);


                updateItem.Properties.Add("DerNeedsPostReceiveWIP", DerNeedsPostReceiveWIP, false);
                updateItem.Properties.Add("UbSerNumStatLinkBy", UbSerNumStatLinkBy, false);
                updateItem.Properties.Add("Stat", Stat, false);
                updateItem.Properties.Add("DerRefDescription", DerRefDescription, false);
                updateItem.Properties.Add("ItmSerialTracked", ItmSerialTracked, false);

                updateItem.Properties.Add("DerDefaultLoc", DerDefaultLoc, false);
                updateItem.Properties.Add("UbUnReceiveFlag", UbUnReceiveFlag, false);
                updateItem.Properties.Add("QtyVoucher", QtyVoucher, false);
                updateItem.Properties.Add("ItemCost", ItemCost, false);

                updateItem.Properties.Add("DimensionGroup", "", false);
                updateItem.Properties.Add("TrackPieces", "0", false);


                updateItem.Properties.Add("ItmTaxFreeMatl", ItmTaxFreeMatl, false);
                updateItem.Properties.Add("PoContainsOnlyTaxFreeMatls", PoContainsOnlyTaxFreeMatls, false);


                //updateItem.Properties.Add("PoContainsOnlyTaxFreeMat", GetPropertyValue(loadResponseData1.PropertyList, loadResponseData1.Items, "PoContainsOnlyTaxFreeMat"),false);
                //updateItem.Properties.Add("UbSImportDocId", GetPropertyValue(loadResponseData1.PropertyList, loadResponseData1.Items, "UbSImportDocId"),false);
                //updateItem.Properties.Add("ItemPOToleranceOver", GetPropertyValue(loadResponseData1.PropertyList, loadResponseData1.Items, "ItemPOToleranceOver"),false);
                //updateItem.Properties.Add("ItemPOToleranceUnder", GetPropertyValue(loadResponseData1.PropertyList, loadResponseData1.Items, "ItemPOToleranceUnder"),false);
                updateItem.Properties.Add("CurrCode", CurrCode, false);
                if (paramcount == 51)
                {
                    updateItem.Properties.Add("DerVendInvNum", "", false);   // Property added to support SL9.00 
                }


                updateItem.ItemID = "";
                updateItem.ItemNumber = 0;
                UpdateCollectionRequestData updateRequestData = new UpdateCollectionRequestData();
                updateRequestData.IDOName = "SLPoItems";
                updateRequestData.RefreshAfterUpdate = true;

                if (paramcount == 51)
                {
                    updateRequestData.CustomUpdate = "PoReceivePopulateTtRcvSp(PoNum,PoLine,PoRelease,DerGrnNum,DerGrnLine,Whse,UbTransDate,Item,DerItemExists,UM,UbQtyReceived,UbQtyReturned,UbQtyReceivedConv,UbQtyReturnedConv,UbPackNum,UbDRRt,UbLot,UbLocation,UbReasonCode,UnitMatCost,UnitDutyCost,UnitBrokerageCost,UnitFreightCost,UnitMatCostConv,UnitDutyCostConv,UnitBrokerageCostConv,UnitFreightCostConv,UnitInsuranceCost,UnitLocFrtCost,UnitInsuranceCostConv,UnitLocFrtCostConv,DerFreightRate,DerDutyRate,DerBrokerageRate,DerInsuranceRate,DerLocFrtRate,UbByCons,UbWorkKey,UbSequence,RowPointer,UbGrnExists,UbImportDocId,EcCode,ManufacturerId,ManufacturerItem,UbContainerNum,UbEsigRowPointer,UbEsigUserName,UbEsigEncryptedPassword,UbEsigReasonCode,DerVendInvNum)";  // Property added to support SL9.00 
                }
                else
                {
                    updateRequestData.CustomUpdate = "PoReceivePopulateTtRcvSp(PoNum,PoLine,PoRelease,DerGrnNum,DerGrnLine,Whse,UbTransDate,Item,DerItemExists,UM,UbQtyReceived,UbQtyReturned,UbQtyReceivedConv,UbQtyReturnedConv,UbPackNum,UbDRRt,UbLot,UbLocation,UbReasonCode,UnitMatCost,UnitDutyCost,UnitBrokerageCost,UnitFreightCost,UnitMatCostConv,UnitDutyCostConv,UnitBrokerageCostConv,UnitFreightCostConv,UnitInsuranceCost,UnitLocFrtCost,UnitInsuranceCostConv,UnitLocFrtCostConv,DerFreightRate,DerDutyRate,DerBrokerageRate,DerInsuranceRate,DerLocFrtRate,UbByCons,UbWorkKey,UbSequence,RowPointer,UbGrnExists,UbImportDocId,EcCode,ManufacturerId,ManufacturerItem,UbContainerNum,UbEsigRowPointer,UbEsigUserName,UbEsigEncryptedPassword,UbEsigReasonCode)";
                }

                if (itemSerialTracked)
                {
                    UpdateCollectionRequestData serialRequestData = new UpdateCollectionRequestData();
                    serialRequestData.IDOName = "SLSerials";
                    serialRequestData.RefreshAfterUpdate = true;

                    PropertyPair itemPropertyPair = new PropertyPair("Item", "Item");
                    PropertyPair whsePropertyPair = new PropertyPair("Whse", "Whse");
                    PropertyPair serialPropertyPair = new PropertyPair("UbSerNumStatLinkBy", "Stat");
                    PropertyPair locPropertyPair = new PropertyPair("UbSLocation", "Loc");
                    PropertyPair lotPropertyPair = new PropertyPair("UbSLot", "Lot");

                    PropertyPair[] linkByPropertyPair = new PropertyPair[]{itemPropertyPair,
                                                                       whsePropertyPair,
                                                                       serialPropertyPair,
                                                                       locPropertyPair,
                                                                       lotPropertyPair};

                    serialRequestData.LinkBy = linkByPropertyPair;
                    serialRequestData.CollectionID = "SLSerials";
                    serialRequestData.CustomInsert = "SerialSaveSp(SerNum,NULL,UbRefStr,MESSAGE,ManufacturedDate,ExpDate,TrxRestrictCode)";
                    serialRequestData.CustomUpdate = "SerialSaveSp(SerNum,NULL,UbRefStr,MESSAGE,ManufacturedDate,ExpDate,TrxRestrictCode)";

                    if (SerialList != null)
                    {
                        for (int i = 0; i < SerialList.Count; i++)
                        {
                            IDOUpdateItem serialItem = new IDOUpdateItem();
                            serialItem.Action = UpdateAction.Update;
                            serialItem.ItemNumber = i;
                            serialItem.Properties.Add("SerNum", formatDataByIDOAndPropertyName("SLMSSerials", "SerNum", SerialList.ElementAt(i)), false);
                            serialItem.Properties.Add("UbRefStr", UbWorkKey, false);
                            serialItem.Properties.Add("InWorkflow", "", false);
                            serialItem.Properties.Add("Item", item, false);
                            serialItem.Properties.Add("Loc", loc, false);
                            serialItem.Properties.Add("Lot", lot, false);
                            serialItem.Properties.Add("NoteExistsFlag", "", false);
                            serialItem.Properties.Add("RowPointer", "", false);
                            serialItem.Properties.Add("Stat", "", false);
                            serialItem.Properties.Add("Whse", whse, false);
                            serialItem.Properties.Add("_ItemWarnings", "", false);
                            serialItem.Properties.Add("UbSelect", "1");
                            serialItem.Properties.Add("ManufacturedDate", SerialMfgDate);
                            serialItem.Properties.Add("ExpDate", SerialExpDate);
                            serialItem.Properties.Add("TrxRestrictCode", SerialTrxRestrictCode);
                            serialRequestData.Items.Add(serialItem);
                        }
                    }
                    updateItem.AddNestedUpdate(serialRequestData);
                }

                updateRequestData.Items.Add(updateItem);
                updateItem.Action = UpdateAction.Update;

                OutputUpdateRequestDataDebugInfo(updateRequestData);//debugging info for update.
                UpdateCollectionResponseData updateResponseData = this.Context.Commands.UpdateCollection(updateRequestData);
            }
            catch (Exception ee)
            {
                //Console.WriteLine("Error occured in update collection " + ee.Message);
                //Console.WriteLine(ee.StackTrace);
                MessageLogging("PoReceiptUpdate.CompleteReceiptsSteps: Error occured in update collection " + ee.Message, msgLevel.l4_error, 1200004);
                throw ee;
            }

            object[] itemwhseDetails = new object[] { "0",
                                                        "",
                                                        "",
                                                        docNum,
                                                        ""
                                                    };

            InvokeResponseData rDataReceivingLoopStep = InvokeIDO("SLPoItems", "POReceivingLoopSp", itemwhseDetails);
            if (qcChecked == true && isCertified == false)
            {
                if (holdLoc != null && holdLoc != "")
                {
                    loc = holdLoc;
                    receiverNo = GetReceiverNo();

                }
            }

            // Generate Voucher
            if (IsgenerateVoucher == "1")
            {
                string generatedVoucher = string.Empty;
                if (GenerateVoucher(ref generatedVoucher) == false)
                {
                    generatedVoucher = string.Empty;
                }
                voucherNum = generatedVoucher;
            }
            //CreatePoReceiveEsigSp
            object[] inputValues = new object[] { "" };
            InvokeResponseData rDataStep = InvokeIDO("SLPoItems", "CreatePoReceiveEsigSp", inputValues);
            if (!(rDataStep.Parameters.ElementAt(0).ToString().Equals("")))
            {
                errorMessage = rDataStep.Parameters.ElementAt(0).ToString();
                return false;
            }

            inputValues = new object[] { };
            rDataStep = InvokeIDO("SLPoItems", "POReceivingCleanupSp", inputValues);

            if (!(rDataReceivingLoopStep.Parameters.ElementAt(1).ToString().Equals("")))
            {
                errorMessage = rDataReceivingLoopStep.Parameters.ElementAt(1).ToString();
                return false;
            }
            
            return true;
        }

        private bool ValidateSerials()
        {
            if (SerialList != null)
            {
                for (int i = 0; i < SerialList.Count; i++)
                {
                    if (CheckSerial(SerialList.ElementAt(i)) == false)
                    {
                        return false;
                    }

                }
            }
            return true;
        }

        private bool CheckSerial(string serial)
        {
            object[] inputValues = new object[] { site,
                                                  serial,
                                                  item,
                                                  "1",
                                                  "",
                                                  "",
                                                  ""
                                                  };

            InvokeResponseData responseValues = InvokeIDO("SLDctrans", "ChkSnSp", inputValues);
            if (!(responseValues.ReturnValue.Equals("0")))
            {
                errorMessage = responseValues.Parameters.ElementAt(5).ToString();
                return false;
            }

            inputValues = new object[] { serial,
                                          item,
                                          "1",
                                          "",
                                          "",
                                          ""
                                          };

            responseValues = InvokeIDO("SLCoitemShps", "SerialExpiryDateSp", inputValues);
            if (!(responseValues.ReturnValue.Equals("0")))
            {
                errorMessage = responseValues.Parameters.ElementAt(5).ToString();
                return false;
            }

            return true;

        }


        #region QC Processing

        private string GetReceiverNo()
        {

            string qcReceiverNo = string.Empty;
            string qcSuccessMessage = string.Empty;
            //string sessionID = sytelineClient.SessionID;          
            string sessionID = this.sessionID;
            object[] inputValues = new object[] { "" };
            InvokeResponseData responseValues = InvokeIDO("SLParms", "GetSessionIDSp", inputValues);
            if ((responseValues.ReturnValue.Equals("0")))
            {
                sessionID = constructErrorMessage(responseValues.Parameters.ElementAt(0).ToString(), "-1", null);

            }

            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "DefineVariables";
            requestData.PropertyList.SetProperties("ConnectionID, VariableName, VariableValue");
            requestData.Filter = "ConnectionID = '" + sessionID + "'";
            requestData.Filter += " and VariableName IN ('RSQCRcvrNumStack', 'RSQCMessageStack')";

            requestData.RecordCap = -1;
            requestData.OrderBy = "VariableName";
            LoadCollectionResponseData responseData = ExcuteQueryRequest(requestData);

            if (responseData.Items.Count > 1)
            {
                qcReceiverNo = responseData[1, "VariableValue"].ToString().Replace("z", "");
                qcSuccessMessage = responseData[0, "VariableValue"].ToString().Replace("z", "");
                if (qcReceiverNo.Trim() != qcSuccessMessage.Trim())
                {
                    return $"{qcReceiverNo.Replace(",", string.Empty)}|\n\n{qcSuccessMessage}";
                }
                return qcReceiverNo;
            }
            return "";
        }

        private bool InspectItem()
        {
            LoadCollectionResponseData paramResponseData = null;
            try
            {
                paramResponseData = GetParameters("RS_QCParmsus", "AutoCreateQcreceipt");
                bool autoCreateQCReiver = GetBool(paramResponseData[0, "AutoCreateQcreceipt"].ToString());
                if (autoCreateQCReiver == false)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
                MessageLogging("PoReceiptUpdate.InspectItem: " + e.Message, msgLevel.l4_error, 1200002);
                return true;
            }

            try
            {
                paramResponseData = GetParameters("RS_QCParmsus", "AutoCreateItem");
                bool autoCreateQCItem = GetBool(paramResponseData[0, "AutoCreateItem"].ToString());
                if (autoCreateQCItem == true)
                {
                    object[] inputValues = new object[]{
                                                    order,
                                                    line,
                                                    "",
                                                    ""
                                                    };

                    InvokeResponseData autoCreateResponseData = InvokeIDO("RS_QCQuickMrrs", "RSQC_AutoCreateQCItem2Sp", inputValues);
                    if (!(autoCreateResponseData.ReturnValue.Equals("0")))
                    {
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
                MessageLogging("PoReceiptUpdate.InspectItem RS_QCParmsus: " + e.Message, msgLevel.l4_error, 1200004);
                return true;
            }

            try
            {
                //Console.WriteLine("POReceiving eight 03 update starting: QCCheck ");
                errorMessage = QCCheckforPOReceipt(order, line, release, UbQtyReceived, loc, lot, whse, out holdLoc, out qcChecked, out isCertified);

                if (errorMessage != "")
                {//the QCCheck returned a error.  QCCheck formats the error message so all we have to do is return false.
                    return false;
                }
                /*  msf153966:  QCS team changed this to be a IDO and added the check as a method.  The following was 
                 *              replaced by a common method QCCheck  JH:2013022
                object[] inputValues1 = new object[]{
                                                    order,
                                                    line,
                                                    release,
                                                    qty,
                                                    loc,
                                                    lot,
                                                    "0",
                                                    whse,
                                                    "",
                                                    "",
                                                    "",
                                                    ""                                                
                                                    };

                InvokeResponseData responseData = InvokeIDO("SP!", "RSQC_QCCheckSp", inputValues1);
                if (!(responseData.ReturnValue.Equals("0")) || responseData.Parameters.ElementAt(11).ToString() != "")
                {
                    Console.WriteLine("Response data returned from RSQC_QCCheckSp :" + responseData.ReturnValue);
                    errorMessage =  responseData.Parameters.ElementAt(11).ToString(), "-1", null);
                }

                holdLoc = responseData.Parameters.ElementAt(8).ToString();
                string qc = responseData.Parameters.ElementAt(9).ToString();

                if (Convert.ToInt32(qc, CultureInfo.InvariantCulture) > 0) // FTDEV-9247
                {
                    qcChecked = true;
                }
                else
                {
                    qcChecked = false;
                }

                string certified = responseData.Parameters.ElementAt(10).ToString();

                if (Convert.ToInt32(certified, CultureInfo.InvariantCulture) > 0) // FTDEV-9247
                {
                    isCertified = true;
                }
                else
                {
                    isCertified = false;
                }
                 */
            }
            catch (Exception e)
            {
                //Console.WriteLine("Exception returned from RSQC_QCCheckSp :" + e.Message);
                errorMessage = e.Message;
                MessageLogging("PoReceiptUpdate.InspectItem.QCCheck : " + e.Message, msgLevel.l4_error, 1200004);
                return false;
            }

            return true;
        }
        public string QCCheckforPOReceipt(string order, string line, string release, string qty, string loc, string lot, string whse, out string holdLoc, out bool qcChecked, out bool isCertified)
        {//if success returns "" .   if fails returns the error message

            InvokeResponseData responseData = null;
            object[] inputValues;
            string tmpval, message = "";
            int paramcount = -1, iqc = -1, icertified = -1, inputcount = 0;
            holdLoc = "";
            qcChecked = false;
            isCertified = false;
            string errorMessage = "";

            paramcount = GetIDOMethodParameterCount("SLPoItems", "RSQC_QCCheck2Sp");
            if (paramcount > 0)
            {//we have a ido with the method.
                #region IDO RS_QCInspSups call
                switch (paramcount)
                {
                    case 13:
                        inputValues = new object[]{//13
                                                    order,
                                                    line,
                                                    release,
                                                    qty,
                                                    loc,
                                                    lot,
                                                    "0",
                                                    whse,
                                                    SiteDateTime, // FTDEV-9247 - Date-conversion for bounced method //System.DateTime.Now.ToString(WMShortDatePattern),
                                                    "", //-3

                                                    "", //-2
                                                    "", //-1
                                                    ""
                                                    };
                        break;
                    default:
                        inputValues = new object[]{//12
                                                    order,
                                                    line,
                                                    release,
                                                    qty,
                                                    loc,
                                                    lot,
                                                    "0",  //seq
                                                    whse,
                                                    "",   //-4 =loc
                                                    "",   //-3 =isqc

                                                    "",   //-2 =cert
                                                    ""    //-1                            
                                                    };

                        break;
                }

                try
                {//ido call
                    //DebugInfoOutputArrayValue(inputValues1);  added for MSF153966  JH:20130208
                    responseData = InvokeIDO("SLPoItems", "RSQC_QCCheck2Sp", inputValues);

                    if (!(responseData.ReturnValue.Equals("0")) || responseData.Parameters.ElementAt(paramcount - 2).ToString() != "")
                    {
                        //Console.WriteLine("QCCheck: Response data returned from RSQC_QCCheckSp >>" + responseData.ReturnValue);
                        errorMessage = responseData.Parameters.ElementAt(paramcount - 2).ToString();
                    }
                    inputcount = inputValues.Length;


                    holdLoc = responseData.Parameters.ElementAt(inputcount - 4).ToString();
                    //Console.WriteLine("InspectItem Setting Hold Loc = " + holdLoc);

                    tmpval = responseData.Parameters.ElementAt(inputcount - 3).ToString();
                    if (string.IsNullOrEmpty(tmpval))
                        tmpval = "0";
                    //Console.WriteLine("InspectItem Setting QC = " + tmpval);
                    iqc = Convert.ToInt32(tmpval, CultureInfo.InvariantCulture); // FTDEV-9247

                    if (Convert.ToInt32(iqc, CultureInfo.InvariantCulture) > 0) // FTDEV-9247
                    { qcChecked = true; }
                    else
                    { qcChecked = false; }

                    tmpval = responseData.Parameters.ElementAt(inputcount - 2).ToString();
                    //Console.WriteLine("InspectItem Setting certified = " + tmpval);
                    if (string.IsNullOrEmpty(tmpval))
                        tmpval = "0";
                    icertified = Convert.ToInt32(tmpval, CultureInfo.InvariantCulture); // FTDEV-9247

                    if (Convert.ToInt32(icertified, CultureInfo.InvariantCulture) > 0) // FTDEV-9247
                    { isCertified = true; }
                    else
                    { isCertified = false; }

                }
                catch (Exception e)
                {
                    //Console.WriteLine("QCCheck: Exception returned from RSQC_QCCheckSp >>" + e.Message);
                    message = e.Message;

                }

                #endregion
            }
            else
            {//no ido present call the stored procedure.  all versions pre 8.03.00 should do this and the sp should only have 12 params. JH:20130221

                inputValues = new object[]{//12
                                                 order,
                                                    line,
                                                    release,
                                                    qty,
                                                    loc,
                                                    lot,
                                                    "0",  //seq
                                                    whse,
                                                    "",   //-4 =loc
                                                    "",   //-3 =isqc

                                                    "",   //-2 =cert
                                                    ""    //-1                                                 
                                                    };
                try
                {
                    //DebugInfoOutputArrayValue(inputValues1);  added for MSF153966  JH:20130208
                    responseData = InvokeIDO("SP!", "RSQC_QCCheck2Sp", inputValues);

                    if (!(responseData.ReturnValue.Equals("0")) || responseData.Parameters.ElementAt(11).ToString() != "")
                    {
                        //Console.WriteLine("QCCheck: Response data returned from RSQC_QCCheckSp >>" + responseData.ReturnValue);
                        message = responseData.Parameters.ElementAt(11).ToString();
                    }

                    inputcount = inputValues.Length;
                    holdLoc = responseData.Parameters.ElementAt(inputcount - 4).ToString();
                    //Console.WriteLine("InspectItem Setting Hold Loc = " + holdLoc);

                    tmpval = responseData.Parameters.ElementAt(inputcount - 3).ToString();
                    if (string.IsNullOrEmpty(tmpval))
                        tmpval = "0";
                    //Console.WriteLine("InspectItem Setting QC = " + tmpval);
                    iqc = Convert.ToInt32(tmpval, CultureInfo.InvariantCulture); // FTDEV-9247
                    if (Convert.ToInt32(iqc, CultureInfo.InvariantCulture) > 0) // FTDEV-9247
                    { qcChecked = true; }
                    else
                    { qcChecked = false; }

                    tmpval = responseData.Parameters.ElementAt(inputcount - 2).ToString();
                    if (string.IsNullOrEmpty(tmpval))
                        tmpval = "0";
                    icertified = Convert.ToInt32(tmpval, CultureInfo.InvariantCulture); // FTDEV-9247

                    if (Convert.ToInt32(icertified, CultureInfo.InvariantCulture) > 0) // FTDEV-9247
                    { isCertified = true; }
                    else
                    { isCertified = false; }
                }
                catch (Exception e)
                {
                    //Console.WriteLine("QCCheck: Exception returned from RSQC_QCCheckSp >>" + e.Message);
                    message = e.Message;

                }

            }

            return message;
        }
        private bool CheckQCProcess()
        {
            try
            {
                if (InspectItem() == false)
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        #endregion
        #region AutoVoucher
        private bool GenerateVoucher(ref string generatedvoucher)
        {
            string autoVoucherMethod = string.Empty;
            string sProcessGUID = "";
            string IsAutoVoucher = "0";
            object[] inputValues = inputValues = new object[] { "",
                                          "",
                                          "",
                                          "",
                                          "",
                                          autoVoucherMethod,
                                          IsAutoVoucher,
                                          sProcessGUID,
                                          "",
                                          "",
                                          "",
                                          SiteDateTime
                                          };

            InvokeResponseData responseValues = InvokeIDO("SLPoItems", "EvaluateAutoVoucherSp", inputValues);
            if (!(responseValues.ReturnValue.Equals("0")))
            {
                errorMessage = responseValues.Parameters.ElementAt(10).ToString();               
                return false;
            }
            if(responseValues !=null)
            {
                sProcessGUID = responseValues.Parameters.ElementAt(7).ToString();
                autoVoucherMethod = responseValues.Parameters.ElementAt(5).ToString();
                IsAutoVoucher = responseValues.Parameters.ElementAt(6).ToString();
            }
            if (IsAutoVoucher == "1")
            {
                inputValues = inputValues = new object[] {
                                         sProcessGUID,
                                         PoVendNum,
                                         IsAutoVoucher,
                                         "PurchaseOrderReceiving",
                                         generatedvoucher,
                                         "",
                                         ""
                                          };
                responseValues = InvokeIDO("SLTmpVoucherBuilders", "VoucherBuilderProcessSp", inputValues);
                if (!(responseValues.ReturnValue.Equals("0")))
                {
                    errorMessage = responseValues.Parameters.ElementAt(6).ToString();
                }
                if (responseValues.Parameters.ElementAt(4) != null)
                    generatedvoucher = responseValues.Parameters.ElementAt(4).ToString();

                inputValues = new object[] {sProcessGUID,
                                         PoVendNum };
                responseValues = InvokeIDO("SLTmpVoucherBuilders", "VoucherBuilderDeleteSp", inputValues);
                if (!(responseValues.ReturnValue.Equals("0")))
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

    }
}
