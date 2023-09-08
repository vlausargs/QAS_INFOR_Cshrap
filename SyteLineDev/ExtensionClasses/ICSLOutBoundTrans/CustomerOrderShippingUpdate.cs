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
    class CustomerOrderShippingUpdate : AReservationsUtilities
    {
        //Input Variables.
        private string order = "";
        private string site = "";
        private string whse = "";
        private string stageLocation = "";
        private bool allowIfCycleCountExists = false;
        private string noOfDaysToDueDate = "0";
        private bool addPermanentItemWhseLocLink = false;
        private string UbEsigEncryptedPassword = "";
        private string UbEsigReasonCode = "";
        private string UbEsigRowPointer = "";
        private string UbEsigUserName = "";
        //Local Varialbles
        private LoadCollectionResponseData orderResponseData = null;
        private string errorMessage = "";

        public CustomerOrderShippingUpdate(string order, String site,
                                            string whse, string stageLocation,
                                            bool allowIfCycleCountExists, string noOfDaysToDueDate,
                                            bool addPermanentItemWhseLocLink, string UbEsigEncryptedPassword, string UbEsigReasonCode, string UbEsigRowPointer, string UbEsigUserName)
        {

            this.order = order;
            this.site = site;
            this.whse = whse;
            this.stageLocation = stageLocation;
            this.allowIfCycleCountExists = allowIfCycleCountExists;
            this.noOfDaysToDueDate = noOfDaysToDueDate;
            this.addPermanentItemWhseLocLink = addPermanentItemWhseLocLink;
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
            site = "";
            whse = "";
            stageLocation = "";

            allowIfCycleCountExists = false;
            noOfDaysToDueDate = "";
            addPermanentItemWhseLocLink = false;
            errorMessage = "";
            ReadERPParameters();  //read the SL parameters so we can use them  
            UbEsigEncryptedPassword = "";
            UbEsigReasonCode = "";
            UbEsigRowPointer = "";
            UbEsigUserName = "";
        }

        public bool formatInputs()
        {

            if (order == null || order.Trim().Equals(""))
            { return false; }

            if (site == null || site.Trim().Equals(""))
            {
                errorMessage = constructErrorMessage("Site input mandatory", "SLACOSH002", null);
                return false;
            }

            whse = formatDataByIDOAndPropertyName("SLRsvdInvs", "Whse", whse);
            if (whse == null || whse.Trim().Equals(""))
            {
                errorMessage = constructErrorMessage("Whse input mandatory", "SLAXXXX024", null);
                return false;
            }

            stageLocation = formatDataByIDOAndPropertyName("SLRsvdInvs", "Loc", stageLocation);

            return true;
        }

        public bool validateInputs()
        {
            //Order Validation

            orderResponseData = ValidateCustomerOrder(order);
            if (orderResponseData.Items.Count == 0)
            {
                errorMessage = constructErrorMessage("Order Details Not Found", "SLAXXXX001", null);
                return false;
            }

            //Validate From Site
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

            //Check Stage Location
            responseData = GetLocationDetails(stageLocation);

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
            if (PerformStaging() == false)
            {
                return false;
            }


            return true;
        }

        private bool PerformStaging()
        {
            try
            {
                Int32 IDOMethodParamCount = 0;
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


            LoadCollectionResponseData RsvdResponseData = GetReservations(order, whse, stageLocation, noOfDaysToDueDate);
            if (RsvdResponseData.Items.Count == 0)
            {
                errorMessage = constructErrorMessage("No Open Reservations Found, Nothing to Ship", "SLACOSH008", null);
                return false;
            }

            UpdateCollectionRequestData updateRequestData = new UpdateCollectionRequestData();
            updateRequestData.IDOName = "SLCoitemShps";
            updateRequestData.RefreshAfterUpdate = true;

            IDOMethodParamCount = GetIDOMethodParameterCount("SLCoitemShps", "COShippingPopulateTmpShpSP");
            switch (IDOMethodParamCount)
            {//added for MSF159449 to handle the new parameter "RecordDate" JH:20130319
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
            for (int i = 0; i < RsvdResponseData.Items.Count; i++)
            {
                string RefLine = RsvdResponseData[i, "RefLine"].Value;
                string RefRelease = RsvdResponseData[i, "RefRelease"].Value;

                LoadCollectionResponseData OrderLineResponseData = GetCustomerOrderLines(order, RefLine, RefRelease, site, noOfDaysToDueDate, true);
                if (OrderLineResponseData.Items.Count == 0)
                {
                    errorMessage = constructErrorMessage("Customer Order/Line/Release Not Found", "SLACOSH009", null);
                    return false;
                }

                //QC Check
                /*if (PerformQCCheck(OrderLineResponseData, RsvdResponseData[i, "QtyRsvd"].Value) == false)
                {
                    return false;
                }*/

                //Cycle Count Check

                if (PerformCycleCountCheck(OrderLineResponseData[0, "Whse"].Value, OrderLineResponseData[0, "Item"].Value, allowIfCycleCountExists, out errorMessage) == false)
                {
                    return false;
                }

                IDOUpdateItem updateItem = GetUpdateItem(RsvdResponseData, i, OrderLineResponseData);
                if (errorMessage != null && !(errorMessage.Trim().Equals("")))
                {
                    return false;
                }
                updateRequestData.Items.Add(updateItem);
            }

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

            if (COShippingLoopSp("", out errorMessage) == false)
            {
                return false;
            }

            if (COShippingCleanupSp(out errorMessage) == false)
            {
                return false;
            }
            }
            catch (Exception e)
            {                
                errorMessage = constructErrorMessage(e.Message, null, null);             
                return false;
            }
            return true;
        }

        private IDOUpdateItem GetUpdateItem(LoadCollectionResponseData RsvdResponseData, int RowCount, LoadCollectionResponseData OrderLineResponseData)
        {
            LoadCollectionResponseData SLCoItemShpsResponseData = SLCoItemShps(OrderLineResponseData[0, "CoNum"].Value, OrderLineResponseData[0, "CoLine"].Value, OrderLineResponseData[0, "CoRelease"].Value, whse);
            IDOUpdateItem updateItem = new IDOUpdateItem();
            updateItem.Action = UpdateAction.Update;
            updateItem.ItemNumber = RowCount;

            updateItem.Properties.Add("ShipmentId", "", false); //added for 8.03.11 GDE  JH:20130516 
            updateItem.Properties.Add("CoRelease", OrderLineResponseData[0, "CoRelease"].Value, false);
            updateItem.Properties.Add("CoLine", OrderLineResponseData[0, "CoLine"].Value, false);
            updateItem.Properties.Add("CoNum", OrderLineResponseData[0, "CoNum"].Value, false);
            updateItem.Properties.Add("UbByCons", "", false);
            updateItem.Properties.Add("UbCrReturn", "0", false);
            updateItem.Properties.Add("UbDoLine", "", false);
            updateItem.Properties.Add("UbDoNum", "", false);
            updateItem.Properties.Add("UbExportDocId", "", false);
            updateItem.Properties.Add("UbImportDocId", "", false);
            updateItem.Properties.Add("UbLoc", RsvdResponseData[RowCount, "Loc"].Value, false);
            updateItem.Properties.Add("UbLot", RsvdResponseData[RowCount, "Lot"].Value, false);
            updateItem.Properties.Add("UbOrigInvNum", "", false);                                //This will come up for UbCrReturn. 		
            updateItem.Properties.Add("UbPackNum", "", false);
            updateItem.Properties.Add("UbQtyToShp", RsvdResponseData[RowCount, "QtyRsvd"].Value, false);
            updateItem.Properties.Add("UbQtyToShpConv", RsvdResponseData[RowCount, "QtyRsvdConv"].Value, false);
            updateItem.Properties.Add("UbReasonCode", "", false);

            updateItem.Properties.Add("UbReasonText", "", false);
            updateItem.Properties.Add("UbRtnToStk", "1", false);
            updateItem.Properties.Add("UbSequence", RowCount);
            //updateItem.Properties.Add("UbTransDate",System.DateTime.Now.ToShortDateString(), false);
            updateItem.Properties.Add("UbTransDate", System.DateTime.Now.ToString(WMShortDatePattern), false); 	//MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128
            updateItem.Properties.Add("UbWorkKey", "ship" + OrderLineResponseData[0, "RowPointer"].Value);
            updateItem.Properties.Add("RowPointer", OrderLineResponseData[0, "RowPointer"].Value, false);
            updateItem.Properties.Add("RecordDate", OrderLineResponseData[0, "RecordDate"].Value, false);

            updateItem.Properties.Add("UbContainerNum", "", false);
            updateItem.Properties.Add("UbEsigEncryptedPassword", string.IsNullOrEmpty(UbEsigEncryptedPassword) ? "" : UbEsigEncryptedPassword, true);
            updateItem.Properties.Add("UbEsigReasonCode", string.IsNullOrEmpty(UbEsigReasonCode) ? "" : UbEsigReasonCode, true);
            updateItem.Properties.Add("UbEsigRowPointer", string.IsNullOrEmpty(UbEsigRowPointer) ? "" : UbEsigRowPointer, true);
            updateItem.Properties.Add("UbEsigUserName", string.IsNullOrEmpty(UbEsigUserName) ? "" : UbEsigUserName, true);

            updateItem.Properties.Add("UM", SLCoItemShpsResponseData[0, "UM"].Value, false);
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
            updateItem.Properties.Add("UbSerNumTargetQty", RsvdResponseData[RowCount, "QtyRsvd"].Value, false);
            updateItem.Properties.Add("ItSerialTracked", SLCoItemShpsResponseData[0, "ItSerialTracked"].Value, false);
            updateItem.Properties.Add("Whse", SLCoItemShpsResponseData[0, "Whse"].Value, false);

            updateItem.Properties.Add("UbManufacturerId", "");
            updateItem.Properties.Add("UbManName", "");
            updateItem.Properties.Add("UbManufacturerItem", "");
            updateItem.Properties.Add("UbManitemDescription", "");

            if (SLCoItemShpsResponseData[0, "ItSerialTracked"].Value.Equals("1"))
            {
                updateItem.Properties.Add("UbSerNumSelected", RsvdResponseData[RowCount, "QtyRsvd"].Value, false);
            }
            else
            {
                updateItem.Properties.Add("UbSerNumSelected", "0", false);
            }

            updateItem.Properties.Add("ItLotTracked", SLCoItemShpsResponseData[0, "ItLotTracked"].Value, false);
            updateItem.Properties.Add("UbSerNumGenerateQty", "0", false);
            if (SLCoItemShpsResponseData[0, "ItSerialTracked"].Value.Equals("1"))
            {
                updateItem.Properties.Add("UbSerNumRangeQty", RsvdResponseData[RowCount, "QtyRsvd"].Value, false);
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
                LoadCollectionRequestData requestData = new LoadCollectionRequestData();
                requestData.IDOName = "SLSerials";
                requestData.PropertyList.SetProperties("SerNum, UbRefStr, UbSelect");
                requestData.RecordCap = -1;
                CustomLoadMethod LoadMethod = new CustomLoadMethod();
                Int32 IDOMethodParamCount = 0;
                IDOMethodParamCount = GetIDOMethodParameterCount("SLSerials", "COShippingSerialRefreshSp");
                LoadMethod.Name = "COShippingSerialRefreshSp";
                if (IDOMethodParamCount==22)
                {
                    LoadMethod.Parameters.Add(SLCoItemShpsResponseData[0, "Item"].Value);
                    LoadMethod.Parameters.Add(RsvdResponseData[RowCount, "QtyRsvd"].Value);
                    LoadMethod.Parameters.Add("0"); //CrReturn
                    LoadMethod.Parameters.Add(SLCoItemShpsResponseData[0, "Whse"].Value);
                    LoadMethod.Parameters.Add(RsvdResponseData[RowCount, "Loc"].Value);
                    LoadMethod.Parameters.Add(RsvdResponseData[RowCount, "Lot"].Value);
                    LoadMethod.Parameters.Add("");  //Start Ser Num
                    LoadMethod.Parameters.Add(OrderLineResponseData[0, "CoNum"].Value);
                    LoadMethod.Parameters.Add(OrderLineResponseData[0, "CoLine"].Value);
                    LoadMethod.Parameters.Add(OrderLineResponseData[0, "CoRelease"].Value);
                    LoadMethod.Parameters.Add("");
                    LoadMethod.Parameters.Add("");
                    LoadMethod.Parameters.Add("");
                    LoadMethod.Parameters.Add("");
                    LoadMethod.Parameters.Add("");
                    LoadMethod.Parameters.Add("0");
                    LoadMethod.Parameters.Add("0");
                    LoadMethod.Parameters.Add("");
                    LoadMethod.Parameters.Add("0");
                    LoadMethod.Parameters.Add("");
                    LoadMethod.Parameters.Add("");
                    LoadMethod.Parameters.Add("");
                }
               else
                {
                    LoadMethod.Parameters.Add(SLCoItemShpsResponseData[0, "Item"].Value);
                    LoadMethod.Parameters.Add(RsvdResponseData[RowCount, "QtyRsvd"].Value);
                    LoadMethod.Parameters.Add("0"); //CrReturn
                    LoadMethod.Parameters.Add(SLCoItemShpsResponseData[0, "Whse"].Value);
                    LoadMethod.Parameters.Add(RsvdResponseData[RowCount, "Loc"].Value);
                    LoadMethod.Parameters.Add(RsvdResponseData[RowCount, "Lot"].Value);
                    LoadMethod.Parameters.Add("");  //Start Ser Num
                    LoadMethod.Parameters.Add(OrderLineResponseData[0, "CoNum"].Value);
                    LoadMethod.Parameters.Add(OrderLineResponseData[0, "CoLine"].Value);
                    LoadMethod.Parameters.Add(OrderLineResponseData[0, "CoRelease"].Value);
                    LoadMethod.Parameters.Add("");
                    LoadMethod.Parameters.Add("");
                    LoadMethod.Parameters.Add("0");
                    LoadMethod.Parameters.Add("0");
                    LoadMethod.Parameters.Add("");
                    LoadMethod.Parameters.Add("0");
                    LoadMethod.Parameters.Add("");
                    LoadMethod.Parameters.Add("");
                    LoadMethod.Parameters.Add("");
                }
               

                requestData.CustomLoadMethod = LoadMethod;

                LoadCollectionResponseData ResponseData = ExcuteQueryRequest(requestData);
                if (ResponseData.Items.Count == 0)
                {

                    IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                    substitutorDictionary.Add("sub1", SLCoItemShpsResponseData[0, "Item"].Value);

                    errorMessage = constructErrorMessage("No Serials Found For Item {sub1}", "SLACOSH003", substitutorDictionary);
                    return null;
                }

                UpdateCollectionRequestData updateRequestData = new UpdateCollectionRequestData();
                updateRequestData.IDOName = "SLSerials";
                updateRequestData.RefreshAfterUpdate = true;
                updateRequestData.CustomUpdate = "SerialSaveSp(SerNum,,UbRefStr,MESSAGE,NULL,NULL,NULL)";
                updateRequestData.CustomInsert = "SerialSaveSp(SerNum,,UbRefStr,MESSAGE,NULL,NULL,NULL)";

                for (int i = 0; i < ResponseData.Items.Count; i++)
                {
                    IDOUpdateItem SerialUpdateItem = new IDOUpdateItem();
                    SerialUpdateItem.Action = UpdateAction.Update;
                    SerialUpdateItem.ItemNumber = i;

                    SerialUpdateItem.Properties.Add("SerNum", ResponseData[i, "SerNum"].Value, false);
                    SerialUpdateItem.Properties.Add("UbRefStr", "ship" + OrderLineResponseData[0, "RowPointer"].Value, false);
                    SerialUpdateItem.Properties.Add("UbSelect", "1");
                    updateRequestData.Items.Add(SerialUpdateItem);
                }

                updateItem.NestedUpdates.Add(updateRequestData);
            }

            return updateItem;
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
    }
}