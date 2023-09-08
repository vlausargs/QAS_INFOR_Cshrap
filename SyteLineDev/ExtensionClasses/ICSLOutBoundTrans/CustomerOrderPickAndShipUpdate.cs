using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mongoose.Core.Configuration;
using Mongoose.IDO.Protocol;
using Mongoose.IDO;
using Mongoose.Core;

namespace InforCollect.ERP.SL.ICSLOutBoundTrans
{
    class CustomerOrderPickAndShipUpdate : AReservationsUtilities
    {
        //Input Variables.
        public string order = "";
        public string line = "";
        public string release = "";
        public string qty = "";
        public string item = "";
        public string site = "";
        public string whse = "";
        public string loc = "";
        public string lot = "";
        public string uom = "";
        public string containerNum = "";
        private bool addItemLocRecord = true;
        private bool allowIfCycleCountExists = false;
        private bool addPermanentItemWhseLocLink = false;
        private string SessionID = "";
        private string userInitial = "";
        private bool allowNegInventory = false;
        private bool createNewLot = false;
        private string docNum = "";
        private string UbEsigEncryptedPassword = "";
        private string UbEsigReasonCode = "";
        private string UbEsigRowPointer = "";
        private string UbEsigUserName = "";
        //format - <serials><serial>xxx</serial><serial>xxys</serial></serials>

        //Local Variables
        private string errorMessage = "";
        private List<string> SerialList = null;
        public bool itemLotTracked = false;
        public bool itemSerialTracked = false;
        public bool insertItemLocRecord = false;
        public LoadCollectionResponseData ordLineResponseData = null;
        public LoadCollectionResponseData orderResponseData = null;
        public InvokeResponseData invokeOrdLineResponseData = null;


        public CustomerOrderPickAndShipUpdate(String iorder, String iline, String irelease, String iqty,
                                              String iitem, String isite, String iwhse, String iloc, String ilot,
                                              String iuom,
                                              bool iaddItemLocRecord, bool iallowIfCycleCountExists,
                                              bool iaddPermanentItemWhseLocLink, string iSessionID, string userInitial, bool allowNegInventory, string docNum, string UbEsigEncryptedPassword, string UbEsigReasonCode, string UbEsigRowPointer, string UbEsigUserName, string containerNum)
        {

            this.order = iorder;
            this.line = iline;
            this.release = irelease;
            this.qty = iqty;
            this.item = iitem;
            this.site = isite;
            this.whse = iwhse;
            this.loc = iloc;
            this.lot = ilot;
            this.uom = iuom;
            this.addItemLocRecord = iaddItemLocRecord;
            this.allowIfCycleCountExists = iallowIfCycleCountExists;
            this.addPermanentItemWhseLocLink = iaddPermanentItemWhseLocLink;
            this.SessionID = iSessionID;
            this.userInitial = userInitial;
            this.allowNegInventory = allowNegInventory;
            this.containerNum = containerNum;
            this.docNum = docNum;
            this.UbEsigEncryptedPassword = UbEsigEncryptedPassword;
            this.UbEsigReasonCode = UbEsigReasonCode;
            this.UbEsigRowPointer = UbEsigRowPointer;
            this.UbEsigUserName = UbEsigUserName;
            //Local variables initialization

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
            uom = "";
            addItemLocRecord = true;
            allowIfCycleCountExists = false;
            addPermanentItemWhseLocLink = false;
            SessionID = "";
            userInitial = "";
            allowNegInventory = false;
            //Local variables initialization
            itemLotTracked = false;
            itemSerialTracked = false;
            insertItemLocRecord = false;
            ordLineResponseData = null;
            orderResponseData = null;
            createNewLot = false;
            containerNum = "";
            docNum = "";
            UbEsigEncryptedPassword = "";
            UbEsigReasonCode = "";
            UbEsigRowPointer = "";
            UbEsigUserName = "";
        }

        public bool formatInputs()
        {
            if (IsStringContainsNumericValue(order))
                order = formatDataByIDOAndPropertyName("SLCoitems", "CoNum", order);
            if (order == null || order.Trim().Equals(""))
            {
                errorMessage = constructErrorMessage("order input mandatory", "SLAXXXX003", null);
                return false;
            }

            line = formatDataByIDOAndPropertyName("SLCoitems", "CoLine", line);
            if (line == null || line.Trim().Equals(""))
            {
                errorMessage = constructErrorMessage("line input mandatory", "SLAXXXX004", null);
                return false;
            }

            release = formatDataByIDOAndPropertyName("SLCoitems", "CoRelease", release);


            if (qty == null || qty.Trim().Equals(""))
            {
                errorMessage = constructErrorMessage("qty input mandatory", "SLAXXXX005", null);
                return false;
            }
            item = formatDataByIDOAndPropertyName("SLRsvdInvs", "Item", item);
            if (item == null || item.Trim().Equals(""))
            {
                errorMessage = constructErrorMessage("item input mandatory", "SLAXXXX006", null);
                return false;
            }
            if (site == null || site.Trim().Equals(""))
            {
                errorMessage = constructErrorMessage("Site input mandatory", "SLAMNCO005", null);
                return false;
            }
            whse = formatDataByIDOAndPropertyName("SLRsvdInvs", "Whse", whse);
            if (whse == null || whse.Trim().Equals(""))
            {
                errorMessage = constructErrorMessage("Whse input mandatory", "SLAXXXX024", null);
                return false;
            }
            loc = formatDataByIDOAndPropertyName("SLRsvdInvs", "Loc", loc);
            if (loc == null || loc.Trim().Equals(""))
            {
                errorMessage = constructErrorMessage("Loc input mandatory", "SLAMNCO007", null);
                return false;
            }
            lot = formatDataByIDOAndPropertyName("SLLotLocs", "Lot", lot);
            
            if (uom == null || uom.Trim().Equals(""))
            {
                errorMessage = constructErrorMessage("uom input mandatory", "SLAXXXX012", null);
                return false;
            }
            if (containerNum != null && !(containerNum.Trim().Equals("")))
            {
                containerNum = formatDataByIDOAndPropertyName("SLContainers", "ContainerNum", containerNum);
            }
            return true;
        }

        public bool validateInputs()
        {
            string itemUM = "";
            //Order Validation

            orderResponseData = ValidateCustomerOrder(order);
            if (orderResponseData.Items.Count == 0)
            {
                errorMessage = constructErrorMessage("Order Details Not Found", "SLAXXXX001", null);
                return false;
            }

            //line field exit

            ordLineResponseData = GetCustomerOrderLines(order, line, release, site, null, true);
            if (ordLineResponseData.Items.Count == 0)
            {
                errorMessage = constructErrorMessage("Order/Line Details Not Found", "SLAMNCO011", null);
                return false;
            }


            /*if (ValidateOrderLine() == false)
            {
                return false;
            }*/

            //Validate Inputs

            if (VerifyInputs() == false)
            {
                return false;
            }

            if (checkIfItemLotExists() == false)
            {
                createNewLot = true;
            }
            //Validate From Site
            LoadCollectionResponseData responseData = GetSiteDetails(site);
            if (responseData.PropertyList.Count == 0)
            {
                errorMessage = constructErrorMessage("Site Details Not Found", "SLAXXXX025", null);
                return false;
            }

            //Check From Warehouse
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
                errorMessage = constructErrorMessage("Physical Inventory is active in Warehouse : {whse} , Transaction not allowed", "SLAMNCO002", substitutorDictionary);
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
            itemUM = GetPropertyValue(responseData.PropertyList, responseData.Items, "UM");
            if (PerformCycleCountCheck(whse, item, allowIfCycleCountExists, out errorMessage) == false)
            {
                return false;
            }


            if (validWhseItemRecordExists(whse, item, allowIfCycleCountExists, out errorMessage) == false)
            {
                return false;
            }

            //Check Location
            responseData = GetLocationDetails(loc);

            if (checkLocationDetails(item, whse, site, loc, out errorMessage) == false)
            {
                if (allowNegInventory == false)
                {
                    IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                    substitutorDictionary.Add("site", site);
                    substitutorDictionary.Add("whse", whse);
                    substitutorDictionary.Add("item", item);
                    substitutorDictionary.Add("loc", loc);
                    errorMessage = constructErrorMessage("{site} / {whse} / {item} / {loc} combination does not exists, Reservations not allowed", "SLAMNCO003", substitutorDictionary);
                    return false;
                }
                else
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
            }

            //Check Lot
            if (checkLot(item, lot, itemLotTracked, out errorMessage) == false)
            {
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
                                                  "Pick N Ship",
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
        public int PerformUpdate(out string InfoBar)
        {
            //1 Initialize variables          
            //2 Format Inputs
            if (formatInputs() == false)
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

            //4 Perform Updates
            if (PerformTransaction() == false)
            {
                InfoBar = errorMessage;
                return 3;
            }

            InfoBar = formatResponse(errorMessage);
            return 0;

        }

        private bool PerformTransaction()
        {
            if (createNewLot == true)
            {
                performAddLot(item, lot, "0", "0", "", "1", site, out errorMessage);
            }
            if (this.insertItemLocRecord == true)
            {
                //if (addLocItemRecord(item, whse, site, loc, addPermanentItemWhseLocLink, out errorMessage) == false)
                //{
                //    return false;
                //}
            }

            if (PerformPickAndShip() == false)
            {
                return false;
            }
            return true;
        }

        private bool PerformPickAndShip()
        {
            try
            {
                Int32 IDOMethodParamCount = 0;
            LoadCollectionRequestData requestContainerData = null;
            if (SessionID != null && !(SessionID.Equals("")))
            {
                SerialList = this.GetSerialList(this.SessionID);
            }
            else if (containerNum != null && containerNum != "")
            {
                requestContainerData = new LoadCollectionRequestData();
                requestContainerData.IDOName = "SLSerials";
                requestContainerData.PropertyList.SetProperties("SerNum, ContainerNum, Loc, Item, Lot,Whse");
                string filterString = "ContainerNum = '" + containerNum + "' and Item ='" + IDOStrFormat(item) + "' and Whse ='" + IDOStrFormat(whse) + "' and Loc ='" + IDOStrFormat(loc) + "'";
                if (lot != null && !(lot.Trim().Equals("")))
                {
                    filterString += " and Lot ='" + IDOStrFormat(lot) + "'";
                }
                requestContainerData.Filter = filterString;
                requestContainerData.RecordCap = 0;
                requestContainerData.OrderBy = "SerNum";
                LoadCollectionResponseData responseContainerData = ExcuteQueryRequest(requestContainerData);
                if (responseContainerData.Items.Count > 0)
                {
                    SerialList = new List<string>(1);
                    for (int i = 0; i < responseContainerData.Items.Count; i++)
                    {
                        SerialList.Add(responseContainerData[i, "SerNum"].ToString());
                    }
                }
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
                errorMessage = constructErrorMessage(invokeResponseDataStep1.Parameters.ElementAt(3).ToString(), "-1", null);
                return false;
            }

            //2 SLCoitemShps - ShipLcrSp

            if (ShipLcrSp(order, out errorMessage) == false)
            {
                return false;
            }


            UpdateCollectionRequestData updateRequestData = new UpdateCollectionRequestData();
            updateRequestData.IDOName = "SLCoitemShps";
            updateRequestData.RefreshAfterUpdate = true;

            IDOMethodParamCount = GetIDOMethodParameterCount("SLCoitemShps", "COShippingPopulateTmpShpSP");
            switch (IDOMethodParamCount)
            {
               case 33:
                    MessageLogging("COShippingPopulateTmpShpSP: 33", msgLevel.l1_information, 1200002);
                    updateRequestData.CustomUpdate = "COShippingPopulateTmpShpSP(CoNum,CoLine,CoRelease,UbDoNum,UbDoLine,UbQtyToShpConv,UbQtyToShp,UbLoc,UbLot,UbCrReturn,  UbRtnToStk,UbByCons,UbReasonCode,UbWorkKey,UbTransDate,RowPointer,UbSequence,UbOrigInvNum,UbReasonText,UbImportDocId,  UbExportDocId,UbPackNum,UbContainerNum,UM,UbEsigUserName,UbEsigReasonCode,UbEsigRowPointer,UbEsigEncryptedPassword,RecordDate, ShipmentId,NULL,NULL,NULL)";
                    break;
               case 32:
                    MessageLogging("COShippingPopulateTmpShpSP: 32", msgLevel.l1_information, 1200002);
                    updateRequestData.CustomUpdate = "COShippingPopulateTmpShpSP(CoNum,CoLine,CoRelease,UbDoNum,UbDoLine,UbQtyToShpConv,UbQtyToShp,UbLoc,UbLot,UbCrReturn,  UbRtnToStk,UbByCons,UbReasonCode,UbWorkKey,UbTransDate,RowPointer,UbSequence,UbOrigInvNum,UbReasonText,UbImportDocId,  UbExportDocId,UbPackNum,UbContainerNum,UM,UbEsigUserName,UbEsigReasonCode,UbEsigRowPointer,UbEsigEncryptedPassword,RecordDate, ShipmentId,NULL,NULL)";
                    break;
                case 30://added for 8.03.11 GDE  JH:20130516
                    //Console.WriteLine("COShippingPopulateTmpShpSP: 30");
                    MessageLogging("COShippingPopulateTmpShpSP: 30", msgLevel.l1_information, 1200002);
                    updateRequestData.CustomUpdate = "COShippingPopulateTmpShpSP(CoNum,CoLine,CoRelease,UbDoNum,UbDoLine,UbQtyToShpConv,UbQtyToShp,UbLoc,UbLot,UbCrReturn,  UbRtnToStk,UbByCons,UbReasonCode,UbWorkKey,UbTransDate,RowPointer,UbSequence,UbOrigInvNum,UbReasonText,UbImportDocId,  UbExportDocId,UbPackNum,UbContainerNum,UM,UbEsigUserName,UbEsigReasonCode,UbEsigRowPointer,UbEsigEncryptedPassword,RecordDate, ShipmentId)";

                    break;
                case 29:
                    //Console.WriteLine("COShippingPopulateTmpShpSP: 29");
                    MessageLogging("COShippingPopulateTmpShpSP: 29", msgLevel.l1_information, 1200002);
                    updateRequestData.CustomUpdate = "COShippingPopulateTmpShpSP(CoNum,CoLine,CoRelease,UbDoNum,UbDoLine,UbQtyToShpConv,UbQtyToShp,UbLoc,UbLot,UbCrReturn,  UbRtnToStk,UbByCons,UbReasonCode,UbWorkKey,UbTransDate,RowPointer,UbSequence,UbOrigInvNum,UbReasonText,UbImportDocId,  UbExportDocId,UbPackNum,UbContainerNum,UM,UbEsigUserName,UbEsigReasonCode,UbEsigRowPointer,UbEsigEncryptedPassword,RecordDate)";
                    break;
                case 23:
                    //Console.WriteLine("COShippingPopulateTmpShpSP: 23");
                    MessageLogging("COShippingPopulateTmpShpSP: 23", msgLevel.l1_information, 1200002);
                    updateRequestData.CustomUpdate = "COShippingPopulateTmpShpSP(CoNum,CoLine,CoRelease,UbDoNum,UbDoLine,UbQtyToShpConv,UbQtyToShp,UbLoc,UbLot,UbCrReturn,UbRtnToStk,UbByCons,UbReasonCode,UbWorkKey,UbTransDate,RowPointer,UbSequence,UbOrigInvNum,UbReasonText,UbImportDocId,UbExportDocId,UbPackNum, RecordDate)";
                    break;
                default:  //default is 22
                    //Console.WriteLine("COShippingPopulateTmpShpSP: Default 22");
                    MessageLogging("COShippingPopulateTmpShpSP: Default 22", msgLevel.l1_information, 1200002);
                    updateRequestData.CustomUpdate = "COShippingPopulateTmpShpSP(CoNum,CoLine,CoRelease,UbDoNum,UbDoLine,UbQtyToShpConv,UbQtyToShp,UbLoc,UbLot,UbCrReturn,UbRtnToStk,UbByCons,UbReasonCode,UbWorkKey,UbTransDate,RowPointer,UbSequence,UbOrigInvNum,UbReasonText,UbImportDocId,UbExportDocId,UbPackNum)";
                    break;
            }
            ordLineResponseData = GetCustomerOrderLines(order, line, release, site, null, true);
            //QC Check
            /*if (PerformQCCheck(ordLineResponseData, this.qty) == false)
            {
                return false;
            }*/

            IDOUpdateItem updateItem = GetUpdateItem(ordLineResponseData);
            if (errorMessage != null && !(errorMessage.Trim().Equals("")))
            {
                return false;
            }
            updateRequestData.Items.Add(updateItem);


            try
            {
                UpdateCollectionResponseData updateResponseData = this.Context.Commands.UpdateCollection(updateRequestData);
                //Console.WriteLine(updateResponseData.ToXml());
                //Console.WriteLine(updateResponseData.ToString());
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
                errorMessage = constructErrorMessage(e.Message, null, null);
                MessageLogging(errorMessage, msgLevel.l4_error, 1200004);
                return false;
            }

            if (COShippingLoopSp(docNum, out errorMessage,allowNegInventory) == false && this.insertItemLocRecord == false)
            {
                return false;
            }

            if (COShippingCleanupSp(out errorMessage) == false)
            {
                return false;
            }
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLCoitemShps";
            requestData.PropertyList.SetProperties("CoRelease, CoLine, CoNum, UbByCons, UbCrReturn,UbDoLine, UbDoNum, UbExportDocId,UbImportDocId, UbLoc, UbLot, UbOrigInvNum, UbPackNum,UbQtyToShp,UbQtyToShpConv,UbReasonCode,UbReasonText,UbRtnToStk,UbSequence,UbShipmentId,UbTransDate,UbWorkKey,RecordDate,RowPointer,UbContainerNum,UbEsigEncryptedPassword,UbEsigReasonCode,UbEsigRowPointer,UbEsigUserName,UM,CoCustNum,AdrName,CoStat,UbCoType,CouEcCode,CusTaxCode1Type,CusPrintPackInv,CoShipEarly,CoShipPartial,UbSelect,Stat,DerShipStat,ManufacturerId,Item,ManName,ItDescription,ManufacturerItem,DerQtyAvailableConv,ManitemDescription,DerItwhsQtyOnHandConv,ItReservable,Consignment,ConsignmentWhse,DueDate,ShipDate,DerDropShipFlag,RefType,RefNum,RefLineSuf,RefRelease,QtyOrderedConv,DerQtyReturnedConv,DerQtyShippedConv,DerQtyInvoicedConv,DerUM,UbManufacturerId,UbManName,UbManufacturerItem,UbManitemDescription,DerQtyAvailable,ItTaxFreeMatl,CoExportType,UbDispMsg,CusTaxRegNum1ExpDate,UbStartingSerial,UbEndingSerial,ItemTrackPieces,ItemDimensionGroup,ItSerialTracked,Whse,ItwhsQtyOnHand,ItLotTracked,CoFixedRate,UbSerNumTargetQty,UbSerNumSelected,UbSerNumGenerateQty,UbSerNumRangeQty,QtyOrdered,QtyReturned,QtyShipped,QtyInvoiced,DerItemExists");
            requestData.RecordCap = -1;
            CustomLoadMethod LoadMethod = new CustomLoadMethod();
            LoadMethod.Name = "CLM_OrderShippingSp";
            LoadMethod.Parameters.Add(order);
            LoadMethod.Parameters.Add("");
            LoadMethod.Parameters.Add(""); //CrReturn
            LoadMethod.Parameters.Add("O");
            LoadMethod.Parameters.Add(whse);
            LoadMethod.Parameters.Add(containerNum);
            LoadMethod.Parameters.Add("");
            LoadMethod.Parameters.Add("");
            requestData.CustomLoadMethod = LoadMethod;
            LoadCollectionResponseData ResponseData = ExcuteQueryRequest(requestData);
            return true;
            }
            catch (Exception e)
            {                
                errorMessage = constructErrorMessage(e.Message, null, null);
                return false;
            }
        }

        private bool PerformQCCheck(LoadCollectionResponseData responseData, string qty)
        {
            object[] inputValues = new object[]{
                                                responseData[0,"CoNum"].Value,
                                                responseData[0,"CoLine"].Value,
                                                responseData[0,"CoRelease"].Value,
                                                responseData[0,"Item"].Value,
                                                orderResponseData[0,"CustNum"].Value,
                                                qty,
                                                responseData[0,"ItUM"].Value,
                                                "",         //Need QC
                                                "",
                                                "",
                                                "",
                                                ""
                                                };
            InvokeResponseData InvokeResponseData = InvokeIDO("RQ.RS_QCCORcpts", "RSQC_CheckCustomerSp", inputValues);
            if (!InvokeResponseData.ReturnValue.Equals("0"))
            {
                errorMessage = constructErrorMessage(InvokeResponseData.Parameters.ElementAt(11).ToString(), "-2", null);
                return false;
            }

            if (InvokeResponseData.Parameters.ElementAt(7).ToString().Equals("1") || InvokeResponseData.Parameters.ElementAt(8).ToString().Equals("1"))
            {
                errorMessage = constructErrorMessage(InvokeResponseData.Parameters.ElementAt(9).ToString(), "-3", null);
                return false;
            }
            return true;
        }

        private bool VerifyInputs()
        {
            if (!(GetPropertyValue(ordLineResponseData, "Whse").Trim().Equals(whse.Trim())))
            {
                IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                substitutorDictionary.Add("sub1", GetPropertyValue(ordLineResponseData, "Whse"));
                substitutorDictionary.Add("whse", whse);
                errorMessage = constructErrorMessage("Whse not matching Order/Line {sub1} {whse} ", "SLAMNCO006", substitutorDictionary);
                return false;
            }

            if (!(GetPropertyValue(ordLineResponseData, "Item").Trim().Equals(item.Trim())))
            {
                IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                substitutorDictionary.Add("sub1", GetPropertyValue(ordLineResponseData, "Item"));
                errorMessage = constructErrorMessage("Item not matching Order/Line {sub1} ", "SLAMNCO008", substitutorDictionary);
                return false;
            }
            return true;
        }

        private IDOUpdateItem GetUpdateItem(LoadCollectionResponseData OrderLineResponseData)
        {
            LoadCollectionResponseData SLCoItemShpsResponseData = SLCoItemShps(OrderLineResponseData[0, "CoNum"].Value, OrderLineResponseData[0, "CoLine"].Value, OrderLineResponseData[0, "CoRelease"].Value, whse);
            IDOUpdateItem updateItem = new IDOUpdateItem();
            updateItem.Action = UpdateAction.Update;
            updateItem.ItemNumber = 0;

            updateItem.Properties.Add("ShipmentId", "", false); //added for 8.03.11 GDE  JH:20130516 
            updateItem.Properties.Add("CoRelease", OrderLineResponseData[0, "CoRelease"].Value, false);
            updateItem.Properties.Add("CoLine", OrderLineResponseData[0, "CoLine"].Value, false);
            updateItem.Properties.Add("CoNum", OrderLineResponseData[0, "CoNum"].Value, false);
            updateItem.Properties.Add("UbByCons", "", true);
            updateItem.Properties.Add("UbCrReturn", "0", true);                    //this needs to be implemented.
            updateItem.Properties.Add("UbDoLine", "", true);
            updateItem.Properties.Add("UbDoNum", "", true);
            updateItem.Properties.Add("UbExportDocId", "", true);
            updateItem.Properties.Add("UbImportDocId", "", true);
            updateItem.Properties.Add("UbLoc", this.loc, true);
            updateItem.Properties.Add("UbLot", this.lot, true);
            updateItem.Properties.Add("UbOrigInvNum", "", false);                                //This will come up for UbCrReturn. 		
            updateItem.Properties.Add("UbPackNum", "", true);
            updateItem.Properties.Add("UbQtyToShp", this.qty, true);
            updateItem.Properties.Add("UbQtyToShpConv", this.qty, true);           //need to implement
            updateItem.Properties.Add("UbReasonCode", "", true);

            updateItem.Properties.Add("UbReasonText", "", false);
            updateItem.Properties.Add("UbRtnToStk", "1", true);
            updateItem.Properties.Add("UbSequence", "1", true);
            //updateItem.Properties.Add("UbTransDate",System.DateTime.Now.ToShortDateString(), false);
            updateItem.Properties.Add("UbTransDate", System.DateTime.Now.ToString(WMShortDatePattern), false); 	//MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128
            updateItem.Properties.Add("UbWorkKey", "ship" + OrderLineResponseData[0, "RowPointer"].Value);
            updateItem.Properties.Add("RowPointer", OrderLineResponseData[0, "RowPointer"].Value, false);
            updateItem.Properties.Add("RecordDate", OrderLineResponseData[0, "RecordDate"].Value, false);

            updateItem.Properties.Add("UbContainerNum", containerNum, true);
            updateItem.Properties.Add("UbEsigEncryptedPassword", string.IsNullOrEmpty(UbEsigEncryptedPassword) ? "" : UbEsigEncryptedPassword, true);
            updateItem.Properties.Add("UbEsigReasonCode", string.IsNullOrEmpty(UbEsigReasonCode) ? "" : UbEsigReasonCode, true);
            updateItem.Properties.Add("UbEsigRowPointer", string.IsNullOrEmpty(UbEsigRowPointer) ? "" : UbEsigRowPointer, true);
            updateItem.Properties.Add("UbEsigUserName", string.IsNullOrEmpty(UbEsigUserName) ? "" : UbEsigUserName, true);

            updateItem.Properties.Add("UM", SLCoItemShpsResponseData[0, "UM"].Value, true);
            updateItem.Properties.Add("CoCustNum", OrderLineResponseData[0, "CoCustNum"].Value, false);
            updateItem.Properties.Add("AdrName", SLCoItemShpsResponseData[0, "AdrName"].Value, false);
            updateItem.Properties.Add("CoStat", OrderLineResponseData[0, "CoStat"].Value, false);
            updateItem.Properties.Add("CoShipEarly", SLCoItemShpsResponseData[0, "CoShipEarly"].Value, false);
            updateItem.Properties.Add("CoShipPartial", SLCoItemShpsResponseData[0, "CoShipPartial"].Value, false);
            updateItem.Properties.Add("UbSelect", "1");

            updateItem.Properties.Add("ItemTrackPieces", "0", false);
            updateItem.Properties.Add("ItemDimensionGroup", "", false);


            updateItem.Properties.Add("DerShipStat", SLCoItemShpsResponseData[0, "DerShipStat"].Value, false);

            updateItem.Properties.Add("ManufacturerId", "", false);
            updateItem.Properties.Add("ManName", "", false);
            updateItem.Properties.Add("ItwhsQtyOnHand", "", false);
            updateItem.Properties.Add("ManufacturerItem", "", false);
            updateItem.Properties.Add("ManitemDescription", "", false);

            updateItem.Properties.Add("ItReservable", SLCoItemShpsResponseData[0, "ItReservable"].Value, false);
            updateItem.Properties.Add("Stat", SLCoItemShpsResponseData[0, "Stat"].Value, false);

            updateItem.Properties.Add("Consignment", "", false);
            updateItem.Properties.Add("ConsignmentWhse", "", false);

            updateItem.Properties.Add("Item", SLCoItemShpsResponseData[0, "Item"].Value, false);
            updateItem.Properties.Add("CoEinvoice", SLCoItemShpsResponseData[0, "CoEinvoice"].Value, false);
            updateItem.Properties.Add("ItDescription", SLCoItemShpsResponseData[0, "ItDescription"].Value, false);
            updateItem.Properties.Add("DerQtyAvailable", SLCoItemShpsResponseData[0, "DerQtyAvailable"].Value, false);

            updateItem.Properties.Add("DerQtyAvailableConv", SLCoItemShpsResponseData[0, "ItDescription"].Value, false);
            updateItem.Properties.Add("DerItwhsQtyOnHandConv", SLCoItemShpsResponseData[0, "DerItwhsQtyOnHandConv"].Value, false);
            updateItem.Properties.Add("DueDate", SLCoItemShpsResponseData[0, "DueDate"].Value, false);
            updateItem.Properties.Add("ShipDate", SLCoItemShpsResponseData[0, "ShipDate"].Value, false);
            updateItem.Properties.Add("DerDropShipFlag", "0", false);
            updateItem.Properties.Add("RefType", SLCoItemShpsResponseData[0, "RefType"].Value, false);
            updateItem.Properties.Add("RefNum", SLCoItemShpsResponseData[0, "RefNum"].Value, false);
            updateItem.Properties.Add("RefLineSuf", SLCoItemShpsResponseData[0, "RefLineSuf"].Value, false);
            updateItem.Properties.Add("RefRelease", SLCoItemShpsResponseData[0, "RefRelease"].Value, false);


            updateItem.Properties.Add("QtyOrderedConv", SLCoItemShpsResponseData[0, "QtyOrderedConv"].Value, false);
            updateItem.Properties.Add("DerQtyReturnedConv", SLCoItemShpsResponseData[0, "DerQtyReturnedConv"].Value, false);
            updateItem.Properties.Add("DerQtyShippedConv", SLCoItemShpsResponseData[0, "DerQtyShippedConv"].Value, false);
            updateItem.Properties.Add("DerQtyInvoicedConv", SLCoItemShpsResponseData[0, "DerQtyInvoicedConv"].Value, false);

            updateItem.Properties.Add("DerUM", SLCoItemShpsResponseData[0, "UM"].Value, false);
            updateItem.Properties.Add("UbSerNumTargetQty", this.qty, false);
            updateItem.Properties.Add("ItSerialTracked", SLCoItemShpsResponseData[0, "ItSerialTracked"].Value, false);
            updateItem.Properties.Add("Whse", SLCoItemShpsResponseData[0, "Whse"].Value, false);

            updateItem.Properties.Add("UbManufacturerId", "");
            updateItem.Properties.Add("UbManName", "");
            updateItem.Properties.Add("UbManufacturerItem", "");
            updateItem.Properties.Add("UbManitemDescription", "");

            if (SLCoItemShpsResponseData[0, "ItSerialTracked"].Value.Equals("1"))
            {
                updateItem.Properties.Add("UbSerNumSelected", this.qty, false);
            }
            else
            {
                updateItem.Properties.Add("UbSerNumSelected", "0", true);
            }

            updateItem.Properties.Add("ItLotTracked", SLCoItemShpsResponseData[0, "ItLotTracked"].Value, false);
            updateItem.Properties.Add("UbSerNumGenerateQty", "0", true);
            if (SLCoItemShpsResponseData[0, "ItSerialTracked"].Value.Equals("1"))
            {
                updateItem.Properties.Add("UbSerNumRangeQty", this.qty, false);
            }
            else
            {
                updateItem.Properties.Add("UbSerNumRangeQty", "0", false);
            }
            updateItem.Properties.Add("CoFixedRate", SLCoItemShpsResponseData[0, "CoFixedRate"].Value, false);
            updateItem.Properties.Add("ItwhsQtyOnHand", SLCoItemShpsResponseData[0, "CoFixedRate"].Value, false);
            updateItem.Properties.Add("QtyOrdered", SLCoItemShpsResponseData[0, "QtyOrdered"].Value, false);
            updateItem.Properties.Add("QtyReturned", SLCoItemShpsResponseData[0, "QtyReturned"].Value, false);
            updateItem.Properties.Add("QtyShipped", SLCoItemShpsResponseData[0, "QtyShipped"].Value, false);
            updateItem.Properties.Add("QtyInvoiced", SLCoItemShpsResponseData[0, "QtyInvoiced"].Value, false);
            updateItem.Properties.Add("CusPrintPackInv", SLCoItemShpsResponseData[0, "CusPrintPackInv"].Value, false);
            updateItem.Properties.Add("ItTaxFreeMatl", SLCoItemShpsResponseData[0, "ItTaxFreeMatl"].Value, false);
            updateItem.Properties.Add("CoExportType", "N", false);
            updateItem.Properties.Add("RecordDate", SLCoItemShpsResponseData[0, "RecordDate"].Value, false); //added for MSF159449 to handle the new parameter "RecordDate" JH:20130319

            if (SLCoItemShpsResponseData[0, "ItSerialTracked"].Value.Equals("1"))
            {
                //LoadCollectionRequestData requestData = new LoadCollectionRequestData();
                //requestData.IDOName = "SLSerials";
                //requestData.PropertyList.SetProperties("SerNum, UbRefStr, UbSelect");
                //requestData.RecordCap = -1;
                //CustomLoadMethod LoadMethod = new CustomLoadMethod();
                //LoadMethod.Name = "COShippingSerialRefreshSp";
                //LoadMethod.Parameters.Add(SLCoItemShpsResponseData[0, "Item"].Value);
                //LoadMethod.Parameters.Add(this.qty);
                //LoadMethod.Parameters.Add("0"); //CrReturn
                //LoadMethod.Parameters.Add(SLCoItemShpsResponseData[0, "Whse"].Value);
                //LoadMethod.Parameters.Add(this.loc);
                //LoadMethod.Parameters.Add(this.lot);
                //LoadMethod.Parameters.Add("");  //Start Ser Num
                //LoadMethod.Parameters.Add(OrderLineResponseData[0, "CoNum"].Value);
                //LoadMethod.Parameters.Add(OrderLineResponseData[0, "CoLine"].Value);
                //LoadMethod.Parameters.Add(OrderLineResponseData[0, "CoRelease"].Value);
                //LoadMethod.Parameters.Add("");
                //LoadMethod.Parameters.Add("");
                //LoadMethod.Parameters.Add("0");
                //LoadMethod.Parameters.Add("0");
                //LoadMethod.Parameters.Add("");
                //LoadMethod.Parameters.Add("0");
                //LoadMethod.Parameters.Add("");
                //LoadMethod.Parameters.Add("");
                //LoadMethod.Parameters.Add("");

                //requestData.CustomLoadMethod = LoadMethod;

                //LoadCollectionResponseData ResponseData = ExcuteQueryRequest(requestData);
                //if (ResponseData.Items.Count == 0)
                //{

                //    IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                //    substitutorDictionary.Add("sub1", SLCoItemShpsResponseData[0, "Item"].Value);

                //    errorMessage = constructErrorMessage("No Serials Found For Item {sub1}", "SLACOSH003", substitutorDictionary);
                //    return null;
                //}

                UpdateCollectionRequestData updateRequestData = new UpdateCollectionRequestData();
                updateRequestData.IDOName = "SLSerials";
                updateRequestData.RefreshAfterUpdate = true;
                updateRequestData.CustomUpdate = "SerialSaveSp(SerNum,,UbRefStr,MESSAGE,NULL,NULL,NULL)";
                updateRequestData.CustomInsert = "SerialSaveSp(SerNum,,UbRefStr,MESSAGE,NULL,NULL,NULL)";
                if (SerialList != null)
                {
                    for (int i = 0; i < SerialList.Count; i++)
                    {
                        IDOUpdateItem SerialUpdateItem = new IDOUpdateItem();
                        SerialUpdateItem.Action = UpdateAction.Update;
                        SerialUpdateItem.ItemNumber = i;

                        SerialUpdateItem.Properties.Add("SerNum", SerialList.ElementAt(i).ToString(), false);
                        SerialUpdateItem.Properties.Add("UbRefStr", "ship" + OrderLineResponseData[0, "RowPointer"].Value, false);
                        SerialUpdateItem.Properties.Add("UbSelect", "1");
                        updateRequestData.Items.Add(SerialUpdateItem);
                    }
                    updateItem.NestedUpdates.Add(updateRequestData);
                }
            }

            return updateItem;
        }

    }
}