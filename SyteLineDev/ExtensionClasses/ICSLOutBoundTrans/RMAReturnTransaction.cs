using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
namespace InforCollect.ERP.SL.ICSLOutBoundTrans
{
    class RMAReturnTransaction : OutBoundUtilities
    {
        #region Variable Declarations
        private string sessionID = "";
        private string rmaLine = "";
        private string returnQty = "";
        private string rmaOrder = "";
        private string location = "";
        private string lot = "";       
        private string RtnToStk = "";
        private string reasonCode = "";
        private string workkey = "";
        private string importDocId = "";
        private string materialCost = "0";
        private string laborCost = "0";
        private string fovhdCost = "0";
        private string vovhdCost = "0";
        private string outCost = "0";
        private string returnType = string.Empty;
        private string containerNum = "";
        private string documentNum = "";
        private string whse = string.Empty;
        private string userInitials = string.Empty;
        private string item = string.Empty;
        private string site = string.Empty;
        private string uom = string.Empty;
        private bool addItemLocRecord = true;
        private bool allowIfCycleCountExists = false;
        private bool addPermanentItemWhseLocLink = false;
        private bool generateSerials = false;
        private bool generateLot = false;
        #endregion
        #region private variables
        private string errorMessage = "";
        private string convertedReturnQty = "";
        private LoadCollectionResponseData orderResponseData = null;
        private List<string> SerialList = null;
        private IMessageProvider messageProvider = null;
        private bool itemLotTracked = false;
        private bool itemSerialTracked = false;
        private bool insertItemLocRecord = false;
        private bool createNewLot = false;
        private bool createContainerNum = false;
        bool containerLocMismatch = false;
        private double qtyOnHand = 0;
        private string successFlag = "";
        #endregion
        public void SetMessageProvider(IMessageProvider messageProvider)
        {
            this.messageProvider = messageProvider;
        }
        public RMAReturnTransaction(string whse, string rmaOrder, string line, string item, string qty, string sessionID, string location, string lot, string uom,
                                    string rtnToStock, string reasonCode, string workKey, string importDocId, string matlCost, string laborCost,string fovCost, string vovCost, string outCost,
                                    string containerNum, string documentNum, string site, string userInitials, string returnType,
                                    bool generateSerials, bool generateLot, bool addItemLocRecord, bool allowIfCycleCountExists, bool addPermanentItemWhseLocLink)
        {
            initialize();
            this.rmaOrder = rmaOrder;
            this.rmaLine = line;
            this.returnQty = qty;
            this.sessionID = sessionID;
            this.location = location;
            this.item = item;
            this.lot = lot;
            this.RtnToStk = rtnToStock;
            this.reasonCode = reasonCode;
            this.importDocId = importDocId;
            this.materialCost = matlCost;
            this.laborCost = laborCost;
            this.fovhdCost = fovCost;
            this.vovhdCost = vovCost;
            this.outCost = outCost;
            this.containerNum = containerNum;
            this.documentNum = documentNum;
            this.userInitials = userInitials;
            this.site = site;
            this.whse = whse;
            this.uom = uom;
            this.returnType = returnType;
            this.workkey = workKey;
            this.addItemLocRecord = addItemLocRecord;
            this.allowIfCycleCountExists = allowIfCycleCountExists;
            this.addPermanentItemWhseLocLink = addPermanentItemWhseLocLink;
            this.generateLot = generateLot;
            this.generateSerials = generateSerials;
        }
        public void initialize()
        {
            //Input variables initialization
            rmaOrder = "";
            rmaLine = "";
            returnQty = "";
            sessionID = "";
            location = "";
            lot = "";
            RtnToStk = "";
            reasonCode = "";
            workkey = "";
            importDocId = "";
            materialCost = "0";
            laborCost = "0";
            fovhdCost = "0";
            vovhdCost = "0";
            outCost = "0";
            containerNum = "";
            documentNum = "";
            userInitials = "";
            item = "";
            site = "";
            whse = "";
            uom = "";
            returnType = "";
            addPermanentItemWhseLocLink = false;
            allowIfCycleCountExists = false;
            addItemLocRecord = false;
            generateLot = false;
            generateSerials = false;

        }
        #region Format Inputs
        public bool formatInputs()
        {
            if (whse == null || whse.Trim().Equals(""))
            {
                errorMessage = "whse input mandatory";
                return false;
            }
            if (rmaOrder == null || rmaOrder.Trim().Equals(""))
            {
                errorMessage = "RMA input mandatory";
                return false;
            }
            if (rmaLine == null || rmaLine.Trim().Equals(""))
            {
                errorMessage = "Line input mandatory";
                return false;
            }
            if (site == null || site.Trim().Equals(""))
            {
                errorMessage = "site input mandatory";
                return false;
            }
            if (item == null || item.Trim().Equals(""))
            {
                errorMessage = "item input mandatory";
                return false;
            }
            if (location == null || location.Trim().Equals(""))
            {
                errorMessage = "loc input mandatory";
                return false;
            }
            if (string.IsNullOrEmpty(returnQty))
            {
                errorMessage = "qty input mandatory";
                return false;
            }
            try
            {
                if (Convert.ToDouble(returnQty, CultureInfo.InvariantCulture) <= 0) // FTDEV-9247
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
            if (uom == null || uom.Trim().Equals(""))
            {
                errorMessage = "uom input mandatory";
                return false;
            }
            if (!string.IsNullOrEmpty(containerNum))
            {
                containerNum = formatDataByIDOAndPropertyName("SLContainers", "ContainerNum", containerNum);
            }
            if (documentNum == null)
            {
                documentNum = "";
            }
            if (importDocId == null)
            {
                importDocId = "";
            }
            return true;
        }
        public LoadCollectionResponseData ValidateRMAOrder(string rma)
        {
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLRmas";
            requestData.PropertyList.SetProperties("RmaNum");

            string filterString = "";
            filterString += "RmaNum ='" + rma + "'";
            requestData.Filter = filterString;
            requestData.RecordCap = 1;
            requestData.OrderBy = "RmaNum";
            LoadCollectionResponseData orderResponseData = ExcuteQueryRequest(requestData);
            return orderResponseData;
        }
        #endregion
        #region Validate Inputs
        public bool validateInputs()
        {
            orderResponseData = ValidateRMAOrder(rmaOrder);
            if (orderResponseData.Items.Count == 0)
            {
                errorMessage = constructErrorMessage("Order Details Not Found", "SLAXXXX001", null);
                return false;
            }
            LoadCollectionResponseData responseData = GetSiteDetails(site);
            if (responseData.PropertyList.Count == 0)
            {
                errorMessage = constructErrorMessage("Site Details Not Found", "SLAXXXX025", null);
                return false;
            }
            //Check Warehouse
            responseData = GetWhseDetailsBySite(whse, site);
            if (responseData.PropertyList.Count == 0)
            {
                errorMessage = constructErrorMessage("Whse Details Not Found", "SLAXXXX026", null);
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
                substitutorDictionary.Add("whse", whse);
                errorMessage = constructErrorMessage("Physical Inventory is active in Warehouse : {whse}, Transaction not allowed", "SLACOSH001", substitutorDictionary);
                return false;
            }
            string itemUM = string.Empty;
            responseData = GetItemDetails(formatItem(item));
            if (responseData.PropertyList.Count == 0)
            {
                errorMessage = "Item Details Not Found";
                return false;
            }
            if (responseData != null)
            {
                itemLotTracked = GetBool(responseData[0, "LotTracked"].ToString());
                itemSerialTracked = GetBool(responseData[0, "SerialTracked"].ToString());
                itemUM = responseData[0, "UM"].ToString();
                uom = itemUM;
            }
            if (validWhseItemRecordExists(whse, item, allowIfCycleCountExists, out errorMessage) == false)
            {
                return false;
            }
            //Qty Checks
            try
            {

                if (Convert.ToDouble(returnQty, CultureInfo.InvariantCulture) <= 0) // FTDEV-9247
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
           
            responseData = GetLocationDetails(location);
            string convertedQty = GetItemConvertedQtyToBaseUnit(item, returnQty, uom, "", out errorMessage);
            if (convertedQty == null)
            {
                return false;
            }
            convertedReturnQty = convertedQty;
            qtyOnHand = 0;
            GetItemLocRecord(site, whse, item, location, ref qtyOnHand);

            if (checkLocationDetails(item, whse, site, location, out errorMessage) == false)
            {
                if (addItemLocRecord == false)
                {
                    IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                    substitutorDictionary.Add("{site}", site);
                    substitutorDictionary.Add("{whse}", whse);
                    substitutorDictionary.Add("{item}", item);
                    substitutorDictionary.Add("{loc}", location);
                    errorMessage = "{site} / {whse} / {item} / {loc} combination does not exists, Return not allowed";
                    errorMessage = constructErrorMessage(errorMessage, "SLPORecXXXX02", substitutorDictionary);
                    return false;
                }
                else
                {
                    insertItemLocRecord = true;
                    errorMessage = "";
                }
            }
            //Lot Code Checks
            if (itemLotTracked == true)
            {
                if (lot == null || lot.Trim().Equals(""))
                {
                    errorMessage = "lot input mandatory";
                    return false;
                }
                lot = formatDataByIDOAndPropertyName("SLLotLocs", "Lot", lot);
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
                        errorMessage = messageProvider.GetMessage("E=OSInvalid", "Lot", lot);
                        return false;
                    }
                    else
                    {
                        createNewLot = true;
                    }
                }
            }
            if (this.itemSerialTracked == true)
            {
                if (generateSerials == true)
                {
                    errorMessage = "Serial Generation is not implemented yet.";
                    return false;
                }
                if (SerialList.Count == 0)
                {
                    errorMessage = "Item is Serial Tracked, Serial Inputs Mandatory.";
                    return false;
                }
            }
            //if (importDocId != null && !(importDocId.Trim().Equals("")))
            //{
            //    if (ValidateImportID(importDocId, out errorMessage) == false)
            //    {
            //        return false;
            //    }
            //}
            //Container Field
            if (this.containerNum != null && !(this.containerNum.Trim().Equals("")))
            {
                if (ValidateQtyForRcvIntoContainerSp() == false)
                {
                    return false;
                }
                if (ValidateContainerExist(this.containerNum, this.whse, this.location, containerLocMismatch, out errorMessage) == true)
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
        #endregion
        #region Specific Methods
        private bool CheckDate()
        {
            object[] dateCheckValues = new object[] { System.DateTime.Now, // FTDEV-9247 - Date-conversion for bounced method System.DateTime.Now.ToString(WMShortDatePattern), // FTDEV-9247 - Date-conversion for bounced method //MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128
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
            return true;
        }
        public bool ValidateQtyForRcvIntoContainerSp()
        {
            object[] inputValues = new object[]{
                                                item,
                                                whse,
                                                location,
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
        public bool ValidateImportID(string ImportID, out string ErrorMessage)
        {
            ErrorMessage = "";
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLTaxFreeImports";
            requestData.PropertyList.SetProperties("ImportDocId");
            requestData.RecordCap = 1;
            requestData.OrderBy = "ImportDocId";
            LoadCollectionResponseData responseData = ExcuteQueryRequest(requestData);

            if (responseData.Items.Count == 0)
            {
                //mIsNotAValid
                ErrorMessage = "Import ID: " + ImportID + " Is Not Valid";
                return false;
            }
            return true;
        }
        #endregion  
        private bool PerformAdjustment()
        {          
            if (createNewLot == true)
            {
                if(!performAddLot(item, lot, "0", "0", "", "1", site, out errorMessage))
                {
                    return false;
                }
            }
            if (!CheckDate())
            {
                return false;
            }
            if (this.insertItemLocRecord == true)
            {
                if (addLocItemRecord(item, whse, site, location, addPermanentItemWhseLocLink, out errorMessage) == false)
                {
                    return false;
                }
            }
            if (this.createContainerNum == true)
            {
                PerformCreateContainer(containerNum, whse, location, out errorMessage);
            }
            //Delete the current Inventory
            object[] deleteInvValues = new object[] { site,
                                                      "G",
                                                      "R",
                                                      whse,
                                                      item,
                                                      location,
                                                      lot,
                                                      returnQty,
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

            InvokeResponseData invokeResponseDataStep2 = InvokeIDO("SLItemLocs", "ItemQtyDetlSp", deleteInvValues);
            if (!(invokeResponseDataStep2.ReturnValue.Equals("0")))
            {
                errorMessage = invokeResponseDataStep2.Parameters.ElementAt(19).ToString();
                return false;
            }
            UpdateCollectionRequestData updateRequestData = new UpdateCollectionRequestData();
            updateRequestData.IDOName = "SLSerials";
            updateRequestData.RefreshAfterUpdate = true;
            updateRequestData.CustomInsert = "SerialSaveSp(SerNum,NULL,UbRefStr,MESSAGE,NULL,NULL,NULL)";
            updateRequestData.CustomUpdate = "SerialSaveSp(SerNum,NULL,UbRefStr,MESSAGE,NULL,NULL,NULL)";
            if (SerialList != null)
            {
                for (int i = 0; i < SerialList.Count; i++)
                {
                    IDOUpdateItem serialItem = new IDOUpdateItem();
                    serialItem.Action = UpdateAction.Update;
                    serialItem.ItemNumber = i;
                    serialItem.Properties.Add("SerNum", formatDataByIDOAndPropertyName("SLMSSerials", "SerNum", SerialList.ElementAt(i)), false);
                    serialItem.Properties.Add("UbRefStr", workkey, false);
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
                errorMessage = e.Message;
                return false;
            }
            if(returnType=="0")
            {
                convertedReturnQty = (Convert.ToDouble(convertedReturnQty,CultureInfo.InvariantCulture) * -1).ToString();
                returnQty = (Convert.ToDouble(returnQty, CultureInfo.InvariantCulture) * -1).ToString();
            }
            if(string.IsNullOrEmpty(materialCost))
            {
                materialCost = "0";
            }
            if (string.IsNullOrEmpty(laborCost))
            {
                laborCost = "0";
            }
            if (string.IsNullOrEmpty(fovhdCost))
            {
                fovhdCost = "0";
            }
            if (string.IsNullOrEmpty(vovhdCost))
            {
                vovhdCost = "0";
            }
            if (string.IsNullOrEmpty(outCost))
            {
                outCost = "0";
            }
            object[] inputValues = inputValues = new object[] {
                                                              "1", //posting flag
                                                              rmaOrder,
                                                              rmaLine,
                                                              convertedReturnQty,
                                                              returnQty,
                                                              location,
                                                              lot,
                                                              "1", //serialConfirmed
                                                              RtnToStk, //RtnToStk
                                                              reasonCode,
                                                              workkey,
                                                              System.DateTime.Now,
                                                              "1",
                                                              successFlag,
                                                              "",
                                                              importDocId,
                                                              Convert.ToDouble(materialCost,CultureInfo.InvariantCulture),
                                                              Convert.ToDouble(laborCost,CultureInfo.InvariantCulture),
                                                              Convert.ToDouble(fovhdCost,CultureInfo.InvariantCulture),
                                                              Convert.ToDouble(vovhdCost,CultureInfo.InvariantCulture),
                                                              Convert.ToDouble(outCost,CultureInfo.InvariantCulture),
                                                              containerNum,
                                                              "",
                                                              "",
                                                              "",
                                                              documentNum
                                                             };

            InvokeResponseData responseValues = InvokeIDO("SLRmaItems", "SSSRMXRMAReturnvSp", inputValues);
            if (!responseValues.ReturnValue.Equals(0))
            {
                errorMessage= responseValues.Parameters.ElementAt(14).ToString();
                successFlag= responseValues.Parameters.ElementAt(13).ToString();
            }
            try
            {

                ClearSerailsBySessionID(this.sessionID);
            }
            catch (Exception)
            {
            }
            if (successFlag == "0")
                return false;
            return true;
        }

        public int PerformUpdate(out string infobar)
        {
            infobar = "";
            if (UpdateUserInitial(this.userInitials, out errorMessage) == false)
            {
                infobar = errorMessage;
                return 1;
            }
            SerialList = this.GetSerialList(this.sessionID);
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
        #region Validate Item Lot
        private bool checkIfItemLotExists()
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
        #endregion

    }
}
