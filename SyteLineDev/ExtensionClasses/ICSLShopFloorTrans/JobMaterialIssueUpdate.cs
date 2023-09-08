using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data; 
using Mongoose.Core.Configuration;
using Mongoose.IDO.Protocol;
using Mongoose.IDO;
using Mongoose.Core;
using System.Globalization;

namespace InforCollect.ERP.SL.ICSLShopFloorTrans
{
    class JobMaterialIssueUpdate : ShopFloorUtilities
    {
        #region Variables
        //Input Variables.
        private string job = "";
        private string suffix = "";
        private string operation = "";
        private string sequence = "";
        private string qty = "";
        private string item = "";
        private string site = "";
        private string whse = "";
        private string loc = "";
        private string lot = "";

        private string uom = "";
        private bool addItemLocRecord = true;
        private bool allowIfCycleCountExists = false;
        private bool addPermanentItemWhseLocLink = false;
        private bool issueNewMaterial = false;
        private bool processAsByProduct = false;
        private string SessionID = "";
        //format - <serials><serial>xxx</serial><serial>xxys</serial></serials>

        private string otherAcct = "";                           // For Non invenoty item issue
        private string otherAcctUnit1 = "";
        private string otherAcctUnit2 = "";
        private string otherAcctUnit3 = "";
        private string otherAcctUnit4 = "";
        private string materialCost = "";
        private bool isNonInventoryItem = false;
        private string containerNum = "";
        private string startingSer = "";
        private string endingSer = "";
        private string docNum = "";
        private DataTable dtSerial = null;
        /******************************/

        //Local Varialbles

        private bool itemLotTracked = false;
        private bool itemSerialTracked = false;
        private bool insertItemLocRecord = false;
        private InvokeResponseData OrderInvokeResponseData = null;
        private LoadCollectionResponseData OrderCollectionResponseData = null;
        private LoadCollectionResponseData OrderOperSeqResponseData = null;
        private InvokeResponseData QtyInvokeResponseData = null;
        private string EXT_BY_SCRAP = "1";
        private string ITEM_CONV_FACTOR = "";
        private string BACK_FLUSH = "0";
        private string ItemDesc = "";

        private string jobSerial = "";  //MSF 171589 added for job serials  jh:20141220
        private string jobLot = "";  //MSF 171589 added for job Lots  jh:20141319

        private bool serialNeedToBeFormated = false;
        private List<string> SerialList = null;
        private string errorMessage = "";
        private DateTime _siteDateTime;

        private LoadCollectionResponseData _inputSerialResponseData = null;
        #endregion
        public DateTime SiteDateTime 
        {
            get { return _siteDateTime; }
            set { _siteDateTime = value; }
        }
        //constructor

        public JobMaterialIssueUpdate(string job, string suffix, string operation, string sequence, string qty,
                                      string item, string site, string whse, string loc, string lot, string uom,
                                      bool addItemLocRecord, bool allowIfCycleCountExists,
                                      bool addPermanentItemWhseLocLink, bool issueNewMaterial,
                                      bool processAsByProduct, string otherAcct,
                                      string otherAcctUnit1, string otherAcctUnit2,
                                      string otherAcctUnit3, string otherAcctUnit4,
                                      string materialCost, string SessionID, string docNum, string JobLot = "",
                                      string JobSerial = "", string containerNum = "",
                                      string startingSer = "", string endingSer = "",DataTable dtSerial=null,
                                      string serialsDataXML = "")
        {
            initialize(); //initalize the derived class
            this.job = job;
            this.suffix = suffix;
            this.operation = operation;
            this.sequence = sequence;
            this.qty = qty;
            this.item = item;
            this.site = site;
            this.whse = whse;
            this.loc = loc;
            this.lot = lot;
            this.uom = uom;
            this.addItemLocRecord = addItemLocRecord;
            this.allowIfCycleCountExists = allowIfCycleCountExists;
            this.addPermanentItemWhseLocLink = addPermanentItemWhseLocLink;
            this.issueNewMaterial = issueNewMaterial;
            this.processAsByProduct = processAsByProduct;
            this.otherAcct = otherAcct;
            this.otherAcctUnit1 = otherAcctUnit1;
            this.otherAcctUnit2 = otherAcctUnit2;
            this.otherAcctUnit3 = otherAcctUnit3;
            this.otherAcctUnit4 = otherAcctUnit4;
            this.materialCost = materialCost;

            this.SessionID = SessionID;
            this.docNum = docNum;
            this.jobSerial = JobSerial;//MSF 171589 added joblot and jobserial  jh:20141220
            this.jobLot = JobLot;//MSF 171589 added joblot and jobserial  jh:20141220
            this.containerNum = containerNum;  // Added for Container functionality
            this.startingSer = startingSer;
            this.endingSer = endingSer;
            this.dtSerial = dtSerial;

            if (string.IsNullOrEmpty(serialsDataXML) == false && serialsDataXML != "")
            {
                this._inputSerialResponseData = LoadCollectionResponseData.FromXml(serialsDataXML);
                IDORuntime.LogUserMessage("JobMaterialUpdate.JobMaterialIssueUpdate", UserDefinedMessageType.UserDefined1, "Received Serials as Input : "+ this._inputSerialResponseData.ToXml());
            }

        }

        public void initialize()
        {
            this.Initialize();//Initilize the base class.  Setup any necessary base class variables. JH:20140103
            job = "";
            suffix = "";
            operation = "";
            sequence = "";
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
            issueNewMaterial = false;
            this.processAsByProduct = false;
            this.otherAcct = "";
            this.otherAcctUnit1 = "";
            this.otherAcctUnit2 = "";
            this.otherAcctUnit3 = "";
            this.otherAcctUnit4 = "";
            this.materialCost = "";
            this.isNonInventoryItem = false;
            //Local variables initialization
            itemLotTracked = false;
            itemSerialTracked = false;
            insertItemLocRecord = false;
            OrderInvokeResponseData = null;
            OrderCollectionResponseData = null;
            OrderOperSeqResponseData = null;
            QtyInvokeResponseData = null;
            ITEM_CONV_FACTOR = "";
            ItemDesc = "";
            processAsByProduct = false; //added to allow byproducts JH:20121116
            jobSerial = "";  //MSF 171589 added for joblot and jobserial  jh:20141220
            jobLot = "";  //MSF 171589 added for joblot and jobserial  jh:20141220
            containerNum = "";
            this.docNum = "";
            this._inputSerialResponseData = null;
        }

        public bool formatInputs()
        {
            LoadCollectionResponseData responseData = null;
            if (IsStringContainsNumericValue(job))
                job = formatDataByIDOAndPropertyName("SLJobs", "Job", job);
            lot = formatDataByIDOAndPropertyName("SLLotLocs", "Lot", lot);
            if (containerNum != null && containerNum.Trim() != "")
                containerNum = formatDataByIDOAndPropertyName("SLContainers", "ContainerNum", containerNum);

            if (job == null || job.Trim().Equals(""))
            {
                errorMessage = "Job Input is mandatory";
                return false;
            }
            suffix = formatDataByIDOAndPropertyName("SLJobs", "Suffix", suffix);
            if (suffix == null || suffix.Trim().Equals(""))
            {
                errorMessage = "Suffix Input is mandatory";
                return false;
            }

            operation = formatDataByIDOAndPropertyName("SLJobTrans", "OperNum", operation);
            if (operation == null || operation.Trim().Equals(""))
            {
                errorMessage = "Operation Input is mandatory";
            }

            sequence = formatDataByIDOAndPropertyName("SLJobmatls", "Sequence", sequence);
            if (sequence == null || sequence.Trim().Equals(""))
            {
                errorMessage = "sequence Input is mandatory";
                return false;
            }

            if (qty == null || qty.Trim().Equals(""))
            {
                errorMessage = "Qty input mandatory";
                return false;
            }
            // item = formatDataByIDOAndPropertyName("SLRsvdInvs", "Item", item);
            item = formatDataByIDOAndPropertyName("SLItems", "Item", item.ToUpper());
            if (item == null || item.Trim().Equals(""))
            {
                errorMessage = "Item input mandatory";
                return false;
            }
            if (site == null || site.Trim().Equals(""))
            {
                errorMessage = "Site input mandatory";
                return false;
            }

            whse = formatDataByIDOAndPropertyName("SLRsvdInvs", "Whse", whse);
            if (whse == null || whse.Trim().Equals(""))
            {
                errorMessage = "Whse input mandatory";
                return false;
            }

            responseData = GetItemDetails(item);
            if (responseData.Items.Count > 0)
            {
                isNonInventoryItem = false;
            }
            else
            {
                isNonInventoryItem = true;
            }
            loc = formatDataByIDOAndPropertyName("SLRsvdInvs", "Loc", loc);
            if (loc == null || loc.Trim().Equals(""))
            {
                if (isNonInventoryItem == false)
                {
                    errorMessage = constructErrorMessage("Loc input mandatory", "SLAPKPR009", null);
                    return false;
                }
            }

            lot = formatDataByIDOAndPropertyName("SLLotLocs", "Lot", lot);


            if (uom == null || uom.Trim().Equals(""))
            {
                errorMessage = "Uom input mandatory";
                return false;
            }

            try
            {
                if (isNonInventoryItem)
                {

                    if (otherAcct == null || otherAcct.Trim().Equals(""))
                    {
                        errorMessage = constructErrorMessage("otherAcct input mandatory", "SLAXXXX012", null);
                        return false;
                    }

                    //Console.WriteLine("materialcost = " + this.materialCost);
                }
            }
            catch (Exception)
            {
            }

            jobSerial = formatDataByIDOAndPropertyName("SLMSSerials", "SerNum", jobSerial); //added for pre-assigned serials: job serials  jh:20121220
            return true;
        }

        public bool validateInputs()
        {

            //Order Validation

            if (ValidateJob() == false)
            {
                return false;
            }

            //Validate Job/Suffix/Operation/Sequence

            if (ValidateJobKeyInputs() == false)
            {
                return false;
            }

            //Validate Inputs

            if (issueNewMaterial == false)
            {
                if (VerifyInputs() == false)
                {
                    return false;
                }
            }

            MessageLogging("JobMaterialIssueUpdate: in ValidateInputs Method, after issueMaterial = false check", msgLevel.l1_information, 1200002);
            //Console.WriteLine("In PickForProductionUpdateDaoImpl.cs, in ValidateInputs Method, after issueMaterial = false check");

            //Validate From Site
            LoadCollectionResponseData responseData = GetSiteDetails(site);
            if (responseData.PropertyList.Count == 0)
            {
                //changed to use the constructErrorMessage.  constructErrorMessage substitutes tag with actual data.  JH:20140108
                //   example tag {reasonCode} can be substituted with the actual value "MMR"
                //   example tag {whse} can be substitued with the actual value "MAIN"
                errorMessage = constructErrorMessage("Site Details Not Found", "SLAXXXX025", null);
                //errorMessage = "Site Details Not Found";
                return false;
            }

            //Check From Warehouse
            responseData = GetWhseDetailsBySite(whse, site);
            if (responseData.PropertyList.Count == 0)
            {
                errorMessage = "Whse Details Not Found";
                return false;
            }

            string physicalInventoryFlag = GetPropertyValue(responseData.PropertyList, responseData.Items, "PhyInvFlg");
            if (physicalInventoryFlag == null)
            {
                //errorMessage = constructErrorMessage("Error Reading WhseAll record", "SLAXXXX018", null);
                errorMessage = "Error Reading WhseAll record";
                return false;
            }

            if (!(physicalInventoryFlag.Equals("0")))
            {
                IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                substitutorDictionary.Add("whse", whse);
                //errorMessage = "Physical Inventory is active in Warehouse : {whse}, Transaction not allowed";

                //changed to use the constructErrorMessage method.  constructErrorMessage substitutes a tag with the actual data.  JH:20140108
                errorMessage = constructErrorMessage("Physical Inventory is active in Warehouse : {whse}, Transaction not allowed", "SLMIxxxx001", substitutorDictionary);

                return false;
            }

            MessageLogging("JobMaterialIssueUpdate: in ValidateInputs Method, after whse validation", msgLevel.l1_information, 1200002);
            //Console.WriteLine("In PickForProductionUpdateDaoImpl.cs, in ValidateInputs Method, after whse validation");

            //Check Item Details
            if (isNonInventoryItem == false)
            {
                //Check Item Details  -- only do this if it is an Inventory item
                responseData = GetItemDetails(formatItem(item));
                if (responseData.Items.Count == 0)
                {
                    errorMessage = "Item Details Not Found";
                    return false;
                }

                itemLotTracked = GetBool(GetPropertyValue(responseData.PropertyList, responseData.Items, "LotTracked"));
                itemSerialTracked = GetBool(GetPropertyValue(responseData.PropertyList, responseData.Items, "SerialTracked"));
                ItemDesc = GetPropertyValue(responseData, "Description");
                MessageLogging("JobMaterialIssueUpdate: in ValidateInputs Method, after item validation", msgLevel.l1_information, 1200002);
                //Console.WriteLine("In PickForProductionUpdateDaoImpl.cs, in ValidateInputs Method, after item validation");
                if (validWhseItemRecordExists(whse, item, allowIfCycleCountExists, out errorMessage) == false)
                {
                    return false;
                }
                responseData = GetLocationDetails(loc);
                if (checkLocationDetails(item, whse, site, loc, out errorMessage) == false)
                {
                    if (addItemLocRecord == false)//added to handle when the item location record needs to be added  JH:20121121
                    {
                        IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                        substitutorDictionary.Add("site", site);
                        substitutorDictionary.Add("whse", whse);
                        substitutorDictionary.Add("item", item);
                        substitutorDictionary.Add("loc", loc);
                        //errorMessage = "{site} / {whse} / {item} / {loc} combination does not exists, Transfer not allowed";

                        //changed to use the constructErrorMessage method.  constructErrorMessage substitutes a tag with the actual data.  JH:20140108
                        errorMessage = constructErrorMessage("{site} / {whse} / {item} / {loc} combination does not exists, Transfer not allowed", "SLMIxxxx002", substitutorDictionary);
                        return false;
                    }
                    else
                    {
                        insertItemLocRecord = true;
                    }
                }

                if (ValidateLocation() == false)
                {
                    return false;
                }

                //Check Lot
                if (checkLot(item, lot, itemLotTracked, out errorMessage) == false)
                {
                    return false;
                }
            }


            //Validate Qty

            if (ValidateQty() == false)
            {
                return false;
            }

            return true;

        }


        public int PerformUpdate(out string infobar)
        {
            infobar = "";
            if (SessionID != null && !(SessionID.Equals("")))
            {
                if(this._inputSerialResponseData != null)
                {
                    SerialList = this.GetSerialListFormInputParameter();
                    IDORuntime.LogUserMessage("JobMaterialUpdate.PerformUpdate", UserDefinedMessageType.UserDefined1, "Received Serials as Input : " + SerialList.Count);

                }
                else
                {
                    SerialList = this.GetSerialList(this.SessionID);
                }
                
            }

            //2 Format Inputs
            if (formatInputs() == false)
            {
                infobar = errorMessage;
                return 1;
            }

            MessageLogging("JobMaterialIssueUpdate: in ValidateInputs Method, after Format Inputs", msgLevel.l1_information, 1200002);

            //3 validate Inputs
            if (validateInputs() == false)
            {
                infobar = errorMessage;
                return 2;
            }
            MessageLogging("JobMaterialIssueUpdate: in ValidateInputs Method, after validate Inputs", msgLevel.l1_information, 1200002);
            //Console.WriteLine("in Pick For Production UpdateDaoImpl, after validate Inputs");
            //Validate Serials

            if (ValidateSerials(SerialList) == false && itemSerialTracked && (containerNum == null || containerNum.Trim() == "") && issueNewMaterial == false)
            {
                infobar = errorMessage;
                return 2;
            }

            //4 Perform Updates

            if (PerformIssue() == false)
            {
                infobar = errorMessage;
                return 3;

            }

            infobar = errorMessage;
            return 0;

        }


        private Boolean PerformIssue()
        {
            try {
                //1 Date Check
                object[] dateCheckValues = new object[] {
                                                      _siteDateTime.ToString(WMShortDatePattern), //MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128
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

                //added to handle when the item location record needs to be added  JH:20121121  
                if (this.insertItemLocRecord == true)
                {
                    if (addLocItemRecord(item, whse, site, loc, addPermanentItemWhseLocLink, out errorMessage) == false)
                    {
                        return false;
                    }
                }

                //Process Checks
                if (ValidateJobmatlSeqSp() == false)
                {
                    return false;
                }

                //changed Console writeline to use the message logging system in the ICSlbase class.  JH:20140108
                //        Also removed unnecessary Console writeline statements
                MessageLogging("JobMaterialIssueUpdate: after ValidateJobmatlSeqSp method ", msgLevel.l1_information, 1200002);
                //Console.WriteLine("after ValidateJobmatlSeqSp method ");

                if (JobMaterialIssueValidationSp() == false)
                {
                    return false;
                }

                if (itemSerialTracked)
                {
                    return PerformSerailUpdate();
                }
                else
                {
                    return PerformNonSerailUpdate();
                }               
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        private bool PerformNonSerailUpdate()
        {

            object[] inputValues = new object[]{
                                                job,
                                                suffix,
                                                operation,
                                                sequence,
                                                (this.itemSerialTracked?"1":"0"),
                                                BACK_FLUSH,
                                                (this.processAsByProduct?"1":"0"), //added to allow the scanner to process the data as a byproduct. 0 = normal JH:20121116 
                                                  uom,
                                                item,
                                                ItemDesc,
                                                (this.issueNewMaterial?"":GetPropertyValue(OrderOperSeqResponseData,"JbrWc")),  //i5735361/MSF152580  if issueNewMaterial = yes then this is null
                                                whse,
                                                string.IsNullOrEmpty(loc)?"":loc,
                                                string.IsNullOrEmpty(lot)?"":lot,
                                                  _siteDateTime, // FTDEV-9247 - Date-conversion for bounced method // System.DateTime.Now.ToString(WMLongDateTimePattern), // FTDEV-9195 - Adding Time to the date/time string passed into CSI
                                                (this.isNonInventoryItem?this.materialCost:QtyInvokeResponseData.Parameters.ElementAt(17).ToString()),  //Material Cost 
                                                (this.isNonInventoryItem?"0":QtyInvokeResponseData.Parameters.ElementAt(19).ToString()),  //Labor Cost  
                                                (this.isNonInventoryItem?"0":QtyInvokeResponseData.Parameters.ElementAt(21).ToString()),  //Fovhd Cost  
                                                (this.isNonInventoryItem?"0":QtyInvokeResponseData.Parameters.ElementAt(23).ToString()),  //Vovhd Cost  
                                                (this.isNonInventoryItem?"0":QtyInvokeResponseData.Parameters.ElementAt(25).ToString()),  //Out Cost    
                                                 (this.isNonInventoryItem?"0":QtyInvokeResponseData.Parameters.ElementAt(17).ToString()),  //Issue of Non-Inventory Item.
                                                (this.isNonInventoryItem?"0":QtyInvokeResponseData.Parameters.ElementAt(36).ToString()),  //Plan Cost  
                                                qty, //when processing as a byproduct should be a negative qty.  because we only allow the user to enter positive values on the scanner.  
                                                (this.isNonInventoryItem?otherAcct:""),                                                   // Non-Inventory Item.
                                                (this.isNonInventoryItem?(string.IsNullOrEmpty(otherAcctUnit1)?"":otherAcctUnit1):""),                                              // Non-Inventory Item.
                                                (this.isNonInventoryItem?(string.IsNullOrEmpty(otherAcctUnit2)?"":otherAcctUnit2):""),                                              // Non-Inventory Item.
                                                (this.isNonInventoryItem? (string.IsNullOrEmpty(otherAcctUnit3) ? "" : otherAcctUnit3):""),                                              // Non-Inventory Item.
                                                (this.isNonInventoryItem? (string.IsNullOrEmpty(otherAcctUnit4) ? "" : otherAcctUnit4):""),
                                                  (this.issueNewMaterial?"":GetPropertyValue(OrderOperSeqResponseData,"RowPointer")),
                                                   (this.processAsByProduct?"P":"I"),
                                                "",
                                                "0",
                                                 "0",
                                                  "",
                                                "",
                                                string.IsNullOrEmpty(jobLot)?"":jobLot,
                                                string.IsNullOrEmpty(jobSerial)?"":jobSerial,
                                                string.IsNullOrEmpty(containerNum)?"":containerNum,
                                                (this.issueNewMaterial?"":GetPropertyValue(OrderOperSeqResponseData,"RecordDate")),
                                                "",
                                                docNum
                                               };
            InvokeResponseData responseData = InvokeIDO("SLJobTrans", "ProcessJobMatlTransSp", inputValues);
            if (!responseData.ReturnValue.Equals("0"))
            {
                errorMessage = responseData.Parameters.ElementAt(33).ToString();
                return false;
            }
            //Logic added to handle by product reporting by container
            if (processAsByProduct == true && !string.IsNullOrEmpty(containerNum))
            {
                //PerformCreateContainer(containerNum, whse, loc, out errorMessage);
                BuildContainer();
            }
            return true;

        }

        private bool PerformSerailUpdate()
        {
            //need to add ItemQtyDetlSp call

            //changed Console writeline to use the message logging system in the ICSlbase class.  JH:20140108
            //        Also removed unnecessary Console writeline statements
            MessageLogging("JobMaterialIssueUpdate: after JobMaterialIssueValidationSp method  ", msgLevel.l1_information, 1200002);
            //Console.WriteLine("after JobMaterialIssueValidationSp method ");


            /*if (ApsSyncDeferSetVarsSp("S") == false)
            {
                return false;
            }*/


            if (ProcessJobMatlTransSetVarsSp("S") == false)
            {
                return false;
            }

            /*if (ApsSyncImmediateSetVarsSp("S") == false)
            {
                return false;
            }*/


            //Console.WriteLine("after ApsSyncImmediateSetVarsSp method ");

            //SLMSSerials.SetMethodSp - To store the values
            //object[] serialsMethod = new object[] { "SLJobTrans.ApsSyncDeferSp|SLJobTrans.ProcessJobMatlTransSp|SLJobTrans.ApsSyncImmediateSp" };
            object[] serialsMethod = new object[] { "SLJobTrans.ProcessJobMatlTransSp" };


            InvokeResponseData invokeResponseDataStep2 = this.Context.Commands.Invoke("SLSerials", "SetMethodSP", serialsMethod);
            if (!(invokeResponseDataStep2.ReturnValue.Equals("0")))
            {
                errorMessage = "Transaction failed";
                return false;
            }

            //changed Console writeline to use the message logging system in the ICSlbase class.  JH:20140108            
            MessageLogging("JobMaterialIssueUpdate: after SetMethodSP method", msgLevel.l1_information, 1200002);
            //Console.WriteLine("after SetMethodSP method ");

            //Serials
            UpdateCollectionRequestData updateRequestData = new UpdateCollectionRequestData();
            updateRequestData.IDOName = "SLSerials";
            updateRequestData.RefreshAfterUpdate = true;
            updateRequestData.CustomInsert = "SerialSaveSp(SerNum,,UbRefStr,MESSAGE,NULL,NULL,NULL)";
            updateRequestData.CustomUpdate = "SerialSaveSp(SerNum,,UbRefStr,MESSAGE,NULL,NULL,NULL)";

            if (containerNum != null && containerNum.Trim() != "" && itemSerialTracked)
            {
                // Contianer Issue 
                //LoadCollectionResponseData serialLoadResponce = new LoadCollectionResponseData();
                //serialLoadResponce = SerialLoadSpByContainer("T", item, whse, loc, lot,
                //                                                   "", "", "", "", "",
                //                                                   job, "0", suffix, site, "",
                //                                                   "", containerNum, startingSer, endingSer, out errorMessage);
                //ShopFloorTransactions sftrans = new ShopFloorTransactions();
                //DataTable dtContainerSerials = sftrans.dtSerials;
                if (dtSerial != null && dtSerial.Rows.Count > 0)
                {
                    DataRow[] dtRowSerial;
                    if (string.IsNullOrEmpty(lot))
                    {
                        dtRowSerial = dtSerial.Select("Item='" + item + "' AND Loc='" + loc + "'");
                    }
                    else
                    {
                        dtRowSerial = dtSerial.Select("Item='" + item + "' AND Loc='" + loc + "' AND Lot='" + lot + "'");
                    }

                    if (dtRowSerial.Length > 0)
                    {
                        //LoadCollectionRequestData ConrequestData = new LoadCollectionRequestData();
                        //ConrequestData.IDOName = "SLContainerItems";
                        //ConrequestData.PropertyList.SetProperties("RowPointer, RecordDate, ContainerNum, Item,QtyContained");
                        //string filterString = "";
                        //if (string.IsNullOrEmpty(lot))
                        //{
                        //    filterString = "ContainerNum = '" + containerNum + "' and Item ='" + formatItem(item) + "'";
                        //}
                        //else
                        //{
                        //    filterString = "ContainerNum = '" + containerNum + "' and Item ='" + formatItem(item) + "' and Lot='" + lot + "'";
                        //}
                        //ConrequestData.Filter = filterString;
                        //ConrequestData.RecordCap = 1;
                        //ConrequestData.OrderBy = "ContainerNum";
                        //ContainerSerialResponseData = ExcuteQueryRequest(ConrequestData);
                        //int iconserial = Decimal.ToInt32(Convert.ToDecimal(ContainerSerialResponseData[0, "QtyContained"].ToString()));
                        int iconserial = Decimal.ToInt32(Convert.ToDecimal(dtRowSerial[0]["QtyContained"].ToString()));
                        for (int i = 0; i < iconserial; i++)
                        {
                            IDOUpdateItem serialItem = new IDOUpdateItem();
                            serialItem.ItemNumber = i;
                            serialItem.Action = UpdateAction.Update;
                            serialItem.Properties.Add("SerNum", dtRowSerial[i]["Serial"].ToString(), false);
                            serialItem.Properties.Add("UbRefStr", GetPropertyValue(OrderOperSeqResponseData, "RowPointer"), false);
                            serialItem.Properties.Add("UbSelect", "1");
                            updateRequestData.Items.Add(serialItem);
                        }
                    }
                }
            }

            if (SerialList != null && SerialList.Count > 0)
            {
                for (int i = 0; i < SerialList.Count(); i++)
                {
                    IDOUpdateItem serialItem = new IDOUpdateItem();
                    serialItem.Action = UpdateAction.Update;
                    serialItem.ItemNumber = i;
                    if (serialNeedToBeFormated)
                    {
                        serialItem.Properties.Add("SerNum", formatDataByIDOAndPropertyName("SLMSSerials", "SerNum", SerialList.ElementAt(i).ToString()));
                    }
                    else
                    {
                        serialItem.Properties.Add("SerNum", SerialList.ElementAt(i).ToString().Trim(), false);
                    }

                    if (issueNewMaterial)
                    {
                        serialItem.Properties.Add("UbRefStr", "", false);
                    }
                    else
                    {
                        serialItem.Properties.Add("UbRefStr", GetPropertyValue(OrderOperSeqResponseData, "RowPointer"), false);
                    }
                    serialItem.Properties.Add("UbSelect", "1");
                    updateRequestData.Items.Add(serialItem);

                }
            }

            if (updateRequestData != null && updateRequestData.Items.Count > 0)
            {
                UpdateCollectionResponseData updateResponseData = this.Context.Commands.UpdateCollection(updateRequestData);
                //changed Console writeline to use the message logging system in the ICSlbase class.  JH:20140108
                MessageLogging("JobMaterialIssueUpdate: " + updateResponseData.ToXml(), msgLevel.l1_information, 1200002);
                //Console.WriteLine(updateResponseData.ToXml());
            }
            /*if (ApsSyncDeferSetVarsSp("U") == false)
            {
                //return errorMessage;
                return false;
            }*/

            if (ProcessJobMatlTransSetVarsSp("U") == false)
            {
                //return errorMessage;
                return false;
            }

            /*if (ApsSyncImmediateSetVarsSp("U") == false)
            {
                //return errorMessage;
                return false;
            }*/
            MessageLogging("JobMaterialIssueUpdate: after updateCollectionSLJobmatls method", msgLevel.l1_information, 1200002);
            //Console.WriteLine("after updateCollectionSLJobmatls method ");
            //Logic added to handle by product reporting by container
            if (processAsByProduct == true && !string.IsNullOrEmpty(containerNum))
            {
                //PerformCreateContainer(containerNum, whse, loc, out errorMessage);
                BuildContainer();
            }
            return true;

        }

        public bool ValidateJobmatlSeqSp()
        {
            object[] inputValues = new object[]{
                                                job,
                                                suffix,
                                                operation,
                                                sequence,
                                                uom,
                                                item,
                                                ""
                                                };
            InvokeResponseData responseData = InvokeIDO("SLJobMatls", "ValidateJobmatlSeqSp", inputValues);
            if (!responseData.ReturnValue.Equals("0"))
            {
                errorMessage = responseData.Parameters.ElementAt(6).ToString();
                return false;
            }
            return true;
        }
        private bool JobMaterialIssueValidationSp()
        {
            object[] inputValues = new object[]{
                                                job,
                                                suffix,
                                                operation,
                                                sequence,
                                                item,
                                                ""
                                                };
            InvokeResponseData responseData = InvokeIDO("SLJobMatls", "JobMaterialIssueValidationSp", inputValues);
            if (!responseData.ReturnValue.Equals("0"))
            {
                errorMessage = responseData.Parameters.ElementAt(5).ToString();
                return false;
            }
            return true;
        }

        private bool ApsSyncDeferSetVarsSp(string type)
        {
            object[] inputValues = new object[]{
                                                type,
                                                ""};

            InvokeResponseData responseData = InvokeIDO("SLJobTrans", "ApsSyncDeferSetVarsSp", inputValues);
            if (!responseData.ReturnValue.Equals("0"))
            {
                errorMessage = responseData.Parameters.ElementAt(1).ToString();
                return false;
            }
            return true;
        }
        private bool ProcessJobMatlTransSetVarsSp(string type)
        {
            //changed Console writeline to use the message logging system in the ICSlbase class.  JH:20140108
            MessageLogging("JobMaterialIssueUpdate: ProcessJobMatlTransSetVarsSp", msgLevel.l1_information, 1200002);
            //Console.WriteLine("ProcessJobMatlTransSetVarsSp");

            //   If issueNewMaterial = yes then it will allways add the item to the Job's BOM as a non-required item.
            //   If the issueNewmaterial = no then the transaction will try to issue the material to the sequence that is passed in.
            object[] inputValues = new object[]{
                                                type,
                                                job,
                                                suffix,
                                                operation,
                                                sequence,
                                                (this.itemSerialTracked?"1":"0"),
                                                BACK_FLUSH,
                                                (this.processAsByProduct?"1":"0"), //added to allow the scanner to process the data as a byproduct. 0 = normal JH:20121116                                                
                                                uom,
                                                item,

                                                ItemDesc,
                                                (this.issueNewMaterial?"":GetPropertyValue(OrderOperSeqResponseData,"JbrWc")),  //i5735361/MSF152580  if issueNewMaterial = yes then this is null
                                                whse,
                                                loc,
                                                lot,                                                
                                                _siteDateTime.ToString(WMLongDateTimePattern), // FTDEV-9195 - Adding Time to the date/time string passed into CSI
                                                (this.isNonInventoryItem?this.materialCost:QtyInvokeResponseData.Parameters.ElementAt(17).ToString()),  //Material Cost 
                                                (this.isNonInventoryItem?"0":QtyInvokeResponseData.Parameters.ElementAt(19).ToString()),  //Labor Cost  
                                                (this.isNonInventoryItem?"0":QtyInvokeResponseData.Parameters.ElementAt(21).ToString()),  //Fovhd Cost  
                                                (this.isNonInventoryItem?"0":QtyInvokeResponseData.Parameters.ElementAt(23).ToString()),  //Vovhd Cost  

                                                (this.isNonInventoryItem?"0":QtyInvokeResponseData.Parameters.ElementAt(25).ToString()),  //Out Cost    
                                                (this.isNonInventoryItem?"0":QtyInvokeResponseData.Parameters.ElementAt(17).ToString()),  //Issue of Non-Inventory Item.
                                                (this.isNonInventoryItem?"0":QtyInvokeResponseData.Parameters.ElementAt(36).ToString()),  //Plan Cost  
                                                qty, //when processing as a byproduct should be a negative qty.  because we only allow the user to enter positive values on the scanner.  
                                                (this.isNonInventoryItem?otherAcct:""),                                                   // Non-Inventory Item.
                                                (this.isNonInventoryItem?otherAcctUnit1:""),                                              // Non-Inventory Item.
                                                (this.isNonInventoryItem?otherAcctUnit2:""),                                              // Non-Inventory Item.
                                                (this.isNonInventoryItem?otherAcctUnit3:""),                                              // Non-Inventory Item.
                                                (this.isNonInventoryItem?otherAcctUnit4:""),
                                                (this.issueNewMaterial?"":GetPropertyValue(OrderOperSeqResponseData,"RowPointer")),

                                                (this.processAsByProduct?"P":"I"),
                                                "",
                                                "0",
                                                "0",
                                                "",
                                                "",
                                                jobLot,
                                                jobSerial,
                                                processAsByProduct==true?"": containerNum,
                                                (this.issueNewMaterial?"":GetPropertyValue(OrderOperSeqResponseData,"RecordDate")),
                                                "",
                                                docNum
                                                };

            InvokeResponseData responseData = InvokeIDO("SLJobTrans", "ProcessJobMatlTransSetVarsSp", inputValues);
            if (!responseData.ReturnValue.Equals("0"))
            {
                errorMessage = responseData.Parameters.ElementAt(34).ToString();
                return false;
            }

            return true;
        }

        private bool ApsSyncImmediateSetVarsSp(string type)
        {
            object[] inputValues = new object[]{
                                                type,
                                                "",
                                                "0"
                                                };

            InvokeResponseData responseData = InvokeIDO("SLJobTrans", "ApsSyncImmediateSetVarsSp", inputValues);
            if (!(responseData.ReturnValue.Equals("0")))
            {
                errorMessage = responseData.Parameters.ElementAt(1).ToString();
                return false;
            }
            return true;
        }
        private bool BuildContainer()
        {
            string quantity = processAsByProduct == true ? Math.Abs(Convert.ToDecimal(qty, CultureInfo.InvariantCulture)).ToString() : qty; // FTDEV-9247
            object[] inputValues = new object[] { quantity, item, site, whse, loc, uom, lot, addItemLocRecord, allowIfCycleCountExists, addPermanentItemWhseLocLink, "1", SessionID, containerNum, "", "" };

            InvokeResponseData responseData = InvokeIDO("ICSLInventoryTrans", "BuildContainer", inputValues);
            if (!(responseData.ReturnValue.Equals("0")))
            {
                errorMessage = responseData.Parameters.ElementAt(13).ToString();
                return false;
            }
            return true;
        }

        private void updateCollectionSLJobmatls()
        {
            UpdateCollectionRequestData updateRequestData = new UpdateCollectionRequestData();
            updateRequestData.IDOName = "SLJobmatls";
            updateRequestData.RefreshAfterUpdate = false;
            updateRequestData.CustomInsert = "ProcessJobMatlTransSp(Job,Suffix,OperNum,Sequence,DerItemSerialTracked,Backflush,DerByProduct,UM,Item,Description,DerWC,UbWhse,DerLoc,DerLot,UbTransDate,MatlCostConv,LbrCostConv,FovhdCostConv,VovhdCostConv,OutCostConv,CostConv,DerPlanCost,DerQtyConv,UbAcct,UbAcctUnit1,UbAcctUnit2,UbAcctUnit3,UbAcctUnit4,RowPointer,RefType,RefNum,RefLineSuf,RefRelease,MESSAGE,UbImportDocId,JobLot,JobSerial,UbContainerNum)";
            updateRequestData.CustomUpdate = "ProcessJobMatlTransSp(Job,Suffix,OperNum,Sequence,DerItemSerialTracked,Backflush,DerByProduct,UM,Item,Description,DerWC,UbWhse,DerLoc,DerLot,UbTransDate,MatlCostConv,LbrCostConv,FovhdCostConv,VovhdCostConv,OutCostConv,CostConv,DerPlanCost,DerQtyConv,UbAcct,UbAcctUnit1,UbAcctUnit2,UbAcctUnit3,UbAcctUnit4,RowPointer,RefType,RefNum,RefLineSuf,RefRelease,MESSAGE,UbImportDocId,JobLot,JobSerial,UbContainerNum)";

            IDOUpdateItem updateItem = new IDOUpdateItem();
            updateItem.Action = UpdateAction.Update;

            updateItem.Properties.Add("Sequence", sequence, false);
            updateItem.Properties.Add("OperNum", this.operation, false);
            updateItem.Properties.Add("Suffix", this.suffix, false);
            updateItem.Properties.Add("Job", this.job, false);
            updateItem.Properties.Add("Backflush", BACK_FLUSH, false);
            updateItem.Properties.Add("CostConv", OrderOperSeqResponseData[0, "CostConv"].ToString(), false);
            updateItem.Properties.Add("DerByProduct", OrderOperSeqResponseData[0, "DerByProduct"].ToString());
            updateItem.Properties.Add("DerItemSerialTracked", OrderOperSeqResponseData[0, "DerItemSerialTracked"].ToString());
            updateItem.Properties.Add("DerLoc", this.loc);
            updateItem.Properties.Add("DerLot", this.lot);


            updateItem.Properties.Add("DerPlanCost", OrderOperSeqResponseData[0, "DerPlanCost"].ToString());
            updateItem.Properties.Add("DerQtyConv", this.qty);
            updateItem.Properties.Add("DerWC", OrderOperSeqResponseData[0, "DerWC"].ToString(), false);
            updateItem.Properties.Add("Description", OrderOperSeqResponseData[0, "ItmDescription"].ToString());
            updateItem.Properties.Add("FovhdCostConv", OrderOperSeqResponseData[0, "FovhdCostConv"].ToString());

            updateItem.Properties.Add("Item", OrderOperSeqResponseData[0, "Item"].ToString(), false);
            updateItem.Properties.Add("LbrCostConv", OrderOperSeqResponseData[0, "LbrCostConv"].ToString());
            updateItem.Properties.Add("MatlCostConv", OrderOperSeqResponseData[0, "MatlCostConv"].ToString());
            updateItem.Properties.Add("OutCostConv", OrderOperSeqResponseData[0, "OutCostConv"].ToString());

            updateItem.Properties.Add("RefLineSuf", OrderOperSeqResponseData[0, "RefLineSuf"].ToString(), false);
            updateItem.Properties.Add("RefNum", OrderOperSeqResponseData[0, "RefNum"].ToString(), false);
            updateItem.Properties.Add("RefRelease", OrderOperSeqResponseData[0, "RefRelease"].ToString(), false);
            updateItem.Properties.Add("RefType", OrderOperSeqResponseData[0, "RefType"].ToString(), false);
            updateItem.Properties.Add("RowPointer", OrderOperSeqResponseData[0, "RowPointer"].ToString(), false);


            updateItem.Properties.Add("UbAcct", OrderOperSeqResponseData[0, "UbAcct"].ToString());
            updateItem.Properties.Add("UbAcctUnit1", OrderOperSeqResponseData[0, "UbAcctUnit1"].ToString());
            updateItem.Properties.Add("UbAcctUnit2", OrderOperSeqResponseData[0, "UbAcctUnit2"].ToString());
            updateItem.Properties.Add("UbAcctUnit3", OrderOperSeqResponseData[0, "UbAcctUnit3"].ToString());
            updateItem.Properties.Add("UbAcctUnit4", OrderOperSeqResponseData[0, "UbAcctUnit4"].ToString());

            updateItem.Properties.Add("UbImportDocId", OrderOperSeqResponseData[0, "UbImportDocId"].ToString());
            updateItem.Properties.Add("UbTransDate", _siteDateTime.ToString(WMLongDateTimePattern)); // FTDEV-9195 - Adding Time to the date/time string passed into CSI - Untested
            updateItem.Properties.Add("UbWhse", this.whse, false);

            updateItem.Properties.Add("UM", OrderOperSeqResponseData[0, "UM"].ToString(), false);
            updateItem.Properties.Add("VovhdCostConv", OrderOperSeqResponseData[0, "VovhdCostConv"].ToString());
            updateItem.Properties.Add("UbSelect", OrderOperSeqResponseData[0, "UbSelect"].ToString());
            updateItem.Properties.Add("DerCostCode", OrderOperSeqResponseData[0, "DerCostCode"].ToString());
            updateItem.Properties.Add("DerQtyOnHandConv", OrderOperSeqResponseData[0, "DerQtyOnHandConv"].ToString());

            updateItem.Properties.Add("DerReqQtyConv", OrderOperSeqResponseData[0, "DerReqQtyConv"].ToString());
            updateItem.Properties.Add("DerQtyIssuedConv", OrderOperSeqResponseData[0, "DerQtyIssuedConv"].ToString());
            updateItem.Properties.Add("DerPlanCostConv", OrderOperSeqResponseData[0, "DerPlanCostConv"].ToString());
            updateItem.Properties.Add("ACost", OrderOperSeqResponseData[0, "ACost"].ToString());

            updateItem.Properties.Add("UbTargetQty", OrderOperSeqResponseData[0, "UbTargetQty"].ToString());
            updateItem.Properties.Add("UbSelectedQty", OrderOperSeqResponseData[0, "UbSelectedQty"].ToString());
            updateItem.Properties.Add("UbGenerateQty", OrderOperSeqResponseData[0, "UbGenerateQty"].ToString());
            updateItem.Properties.Add("UbRangeQty", OrderOperSeqResponseData[0, "UbRangeQty"].ToString());

            updateItem.Properties.Add("OrdType", OrderOperSeqResponseData[0, "OrdType"].ToString(), false);
            updateItem.Properties.Add("ScrapFact", OrderOperSeqResponseData[0, "ScrapFact"].ToString(), false);
            updateItem.Properties.Add("MatlQty", OrderOperSeqResponseData[0, "MatlQty"].ToString(), false);
            updateItem.Properties.Add("MatlQtyConv", OrderOperSeqResponseData[0, "MatlQtyConv"].ToString(), false);

            updateItem.Properties.Add("DerItemExist", OrderOperSeqResponseData[0, "DerItemExist"].ToString());
            updateItem.Properties.Add("DerReqQty", OrderOperSeqResponseData[0, "DerReqQty"].ToString());
            updateItem.Properties.Add("QtyIssued", OrderOperSeqResponseData[0, "QtyIssued"].ToString());
            updateItem.Properties.Add("DerQty", qty);

            updateItem.Properties.Add("DerItemUMConvFactor", OrderOperSeqResponseData[0, "DerItemUMConvFactor"].ToString());
            updateItem.Properties.Add("MatlCost", OrderOperSeqResponseData[0, "MatlCost"].ToString());

            updateItem.Properties.Add("LbrCost", OrderOperSeqResponseData[0, "LbrCost"].ToString());
            updateItem.Properties.Add("FovhdCost", OrderOperSeqResponseData[0, "FovhdCost"].ToString());
            updateItem.Properties.Add("VovhdCost", OrderOperSeqResponseData[0, "VovhdCost"].ToString());
            updateItem.Properties.Add("OutCost", OrderOperSeqResponseData[0, "OutCost"].ToString());

            updateItem.Properties.Add("DerItemUMConvFactor", OrderOperSeqResponseData[0, "DerItemLotTracked"].ToString());
            updateItem.Properties.Add("DerItemIssueBy", OrderOperSeqResponseData[0, "DerItemIssueBy"].ToString());

            updateItem.Properties.Add("UbDelTempSer", OrderOperSeqResponseData[0, "UbDelTempSer"].ToString(), false);
            updateItem.Properties.Add("DerQtyOnHand", OrderOperSeqResponseData[0, "DerQtyOnHand"].ToString());
            updateItem.Properties.Add("Units", OrderOperSeqResponseData[0, "Units"].ToString(), false);
            updateItem.Properties.Add("QtyReleased", OrderOperSeqResponseData[0, "QtyReleased"].ToString(), false);
            updateItem.Properties.Add("Cost", string.IsNullOrEmpty(OrderOperSeqResponseData[0, "Cost"].ToString())?"0": OrderOperSeqResponseData[0, "Cost"].ToString(), true);

            updateItem.Properties.Add("DerItemUM", OrderOperSeqResponseData[0, "DerItemUM"].ToString());
            updateItem.Properties.Add("AMatlCost", OrderOperSeqResponseData[0, "AMatlCost"].ToString());
            updateItem.Properties.Add("ALbrCost", OrderOperSeqResponseData[0, "ALbrCost"].ToString());
            updateItem.Properties.Add("AFovhdCost", OrderOperSeqResponseData[0, "AFovhdCost"].ToString());

            updateItem.Properties.Add("AVovhdCost", OrderOperSeqResponseData[0, "AVovhdCost"].ToString());
            updateItem.Properties.Add("AOutCost", OrderOperSeqResponseData[0, "AOutCost"].ToString());

            updateItem.Properties.Add("ItmMatlCost", OrderOperSeqResponseData[0, "ItmMatlCost"].ToString(), false);
            updateItem.Properties.Add("ItmLbrCost", OrderOperSeqResponseData[0, "ItmLbrCost"].ToString(), false);
            updateItem.Properties.Add("ItmFovhdCost", OrderOperSeqResponseData[0, "ItmFovhdCost"].ToString(), false);
            updateItem.Properties.Add("ItmVovhdCost", OrderOperSeqResponseData[0, "ItmVovhdCost"].ToString(), false);
            updateItem.Properties.Add("ItmOutCost", OrderOperSeqResponseData[0, "ItmOutCost"].ToString(), false);

            updateItem.Properties.Add("DerPoVendNum", OrderOperSeqResponseData[0, "DerPoVendNum"].ToString(), false);
            updateItem.Properties.Add("UbAcctAccessUnit1", OrderOperSeqResponseData[0, "UbAcctAccessUnit1"].ToString(), false);

            updateItem.Properties.Add("UbAcctAccessUnit2", OrderOperSeqResponseData[0, "UbAcctAccessUnit2"].ToString(), false);
            updateItem.Properties.Add("UbAcctAccessUnit3", OrderOperSeqResponseData[0, "UbAcctAccessUnit3"].ToString(), false);
            updateItem.Properties.Add("UbAcctAccessUnit4", OrderOperSeqResponseData[0, "UbAcctAccessUnit4"].ToString(), false);
            updateItem.Properties.Add("DerItemTaxFreeMatl", OrderOperSeqResponseData[0, "DerItemTaxFreeMatl"].ToString(), false);
            updateItem.Properties.Add("WcOutside", OrderOperSeqResponseData[0, "WcOutside"].ToString(), false);

            //JobLot,JobSerial
            updateItem.Properties.Add("JobLot", jobLot);  //MSF 171589 added for joblot and jobserial  jh:20141220
            updateItem.Properties.Add("JobSerial", jobSerial);  //MSF 171589 added for joblot and jobserial  jh:20141220

            updateItem.Properties.Add("UbContainerNum", this.containerNum);
            updateRequestData.Items.Add(updateItem);

            UpdateCollectionResponseData updateResponseData = this.Context.Commands.UpdateCollection(updateRequestData);
            MessageLogging("JobMaterialIssueUpdate: " + updateResponseData.ToXml(), msgLevel.l1_information, 1200002);
            //Console.WriteLine(updateResponseData.ToXml());

        }

        private bool ValidateSerials(List<string> SessionID)
        {

            if (SessionID != null && (!SessionID.Equals("")))
            {
                for (int i = 0; i < SessionID.Count(); i++)
                {

                    string serial = formatDataByIDOAndPropertyName("SLMSSerials", "SerNum", SessionID.ElementAt(i).ToString());
                    if (CheckSerialForReturn(serial) == false)
                    {
                        return false;
                    }

                }
                return true;
            }
            return false;
        }


        private bool ValidateJob()
        {
            OrderCollectionResponseData = GetJobDetails(job, suffix);
            if (OrderCollectionResponseData == null || OrderCollectionResponseData.Items.Count == 0)
            {
                errorMessage = constructErrorMessage("Job/Suffix Details Not Found", "SLAXXXX063", null);
                return false;
            }
            object[] inputValues; //added for SL9 Qualification.  JH:20130715
            //int paramcount = 0; //added for SL9 Qualification.  JH:20130715
           // paramcount = GetIDOMethodParameterCount("SLJobTrans", "JobtranJobValidSp");
            //Console.WriteLine("ValidateJob: JobtranJobValidSp paramcount = " + paramcount);
            //switch (paramcount)
            //{
            //    case 48:
                    //#region 48 values
                    inputValues = new object[]{
                                                "",
                                                job,
                                                job,
                                                suffix,
                                                suffix,
                                                operation,
                                                "",
                                                "",
                                                "",
                                                item,
                                                //1
                                                "",
                                                "",
                                                "",
                                                uom,
                                                whse,
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                //2
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
                                                //3
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
                                                //4
                                                "",
                                                "", // new field for 8.03.10
                                                "", // new input for 9.00.00 JH:20130809
                                                "", // new input for 9.00.00 JH:20130809
                                                "", // new input for 9.00.00 JH:20130809
                                                "",  // new input for 9.00.00 JH:20130809
                                                "",
                                                ""  // for new input NewOldJob
                                                };
            //        break;
            //    #endregion
            //    case 47:
            //        #region 47 values
            //        inputValues = new object[]{
            //                                    "",
            //                                    job,
            //                                    job,
            //                                    suffix,
            //                                    suffix,
            //                                    operation,
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    item,
            //                                    //1
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    uom,
            //                                    whse,
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    //2
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    //3
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    //4
            //                                    "",
            //                                    "", // new field for 8.03.10
            //                                    "", // new input for 9.00.00 JH:20130809
            //                                    "", // new input for 9.00.00 JH:20130809
            //                                    "", // new input for 9.00.00 JH:20130809
            //                                    "",  // new input for 9.00.00 JH:20130809
            //                                    ""
            //                                    };
            //        break;
            //    #endregion
            //    case 46:
            //        #region 46 values
            //        inputValues = new object[]{
            //                                    "",
            //                                    job,
            //                                    job,
            //                                    suffix,
            //                                    suffix,
            //                                    operation,
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    item,
            //                                    //1
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    uom,
            //                                    whse,
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    //2
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    //3
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    //4
            //                                    "",
            //                                    "", // new field for 8.03.10
            //                                    "", // new input for 9.00.00 JH:20130809
            //                                    "", // new input for 9.00.00 JH:20130809
            //                                    "", // new input for 9.00.00 JH:20130809
            //                                    ""  // new input for 9.00.00 JH:20130809
            //                                    };
            //        break;
            //    #endregion
            //    case 42:
            //        #region 42 values
            //        inputValues = new object[]{
            //                                    "",
            //                                    job,
            //                                    job,
            //                                    suffix,
            //                                    suffix,
            //                                    operation,
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    item,
            //                                    //1
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    uom,
            //                                    whse,
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    //2
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    //3
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    //4
            //                                    "",
            //                                    "" // new field for 8.03.10
            //                                    };
            //        #endregion
            //        break;
            //    case 43:
            //        #region 43 values
            //        inputValues = new object[]{
            //                                    "",
            //                                    job,
            //                                    job,
            //                                    suffix,
            //                                    suffix,
            //                                    operation,
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    item,
            //                                    //1
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    uom,
            //                                    whse,
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    //2
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    //3
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    //4
            //                                    "",
            //                                    "", // new field for 8.03.10
            //                                    ""  //added for MSF168270 JH:20130910
            //                                    };
            //        #endregion
            //        break;
            //    case 41:
            //    default: //as orignially released.
            //        #region 41 values
            //        inputValues = new object[]{
            //                                    "",
            //                                    job,
            //                                    job,
            //                                    suffix,
            //                                    suffix,
            //                                    operation,
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    item,
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    uom,
            //                                    whse,
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    ""
            //                                    };
            //        #endregion
            //        break;
            //}


            OrderInvokeResponseData = InvokeIDO("SLJobTrans", "JobtranJobValidSp", inputValues);

            if (!(OrderInvokeResponseData.ReturnValue.Equals("0")))
            {
                //errorMessage = constructErrorMessage(OrderInvokeResponseData.Parameters.ElementAt(32).ToString(), "-2", null);
                errorMessage = OrderInvokeResponseData.Parameters.ElementAt(32).ToString();
                return false;
            }

            return true;
        }
        private bool ValidateJobKeyInputs()
        {
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLJobmatls";
            requestData.PropertyList.SetProperties("RowPointer, RecordDate, Job, Suffix, OperNum, Sequence, Item,ItmDescription,ItmLotTracked,ItmSerialTracked,DerWhse,JbrWc,DerQty, DerReqQty, DerQtyPicked, DerQtyToPick, DerUM, CostConv, DerByProduct, DerItemSerialTracked, DerPlanCostConv, DerQtyConv, DerWC, FovhdCostConv, MatlCostConv,LbrCostConv, OutCostConv, RefLineSuf");
            //requestData.PropertyList.SetProperties("JobItem,UbSelect,OperNum,Sequence,Item,Description,DerQtyConv,UM,DerLoc,DerLot,DerCostCode,Job,Suffix,UbImportDocId,MatlCostConv,LbrCostConv,FovhdCostConv,VovhdCostConv,OutCostConv,UbAcct,DerQtyOnHandConv,DerReqQtyConv,DerQtyIssuedConv,DerPlanCostConv,ACost,UbAcctUnit1,UbAcctUnit2,UbAcctUnit3,UbAcctUnit4,UbTargetQty,UbSelectedQty,UbGenerateQty,UbRangeQty,OrdType,Backflush,DerWC,ScrapFact,MatlQty,MatlQtyConv,DerItemExist,DerReqQty,QtyIssued,DerQty,DerItemUMConvFactor,MatlCost,LbrCost,FovhdCost,VovhdCost,OutCost,DerPlanCost,DerItemLotTracked,DerItemSerialTracked,DerItemIssueBy,UbDelTempSer,UbWhse,RowPointer,DerQtyOnHand,Units,QtyReleased,Cost,CostConv,DerItemUM,AMatlCost,ALbrCost,AFovhdCost,AVovhdCost,AOutCost,ItmMatlCost,ItmLbrCost,ItmFovhdCost,ItmVovhdCost,ItmOutCost,DerPoVendNum,RefType,RefNum,UbAcctAccessUnit1,UbAcctAccessUnit2,UbAcctAccessUnit3,UbAcctAccessUnit4,UbTransDate,RefLineSuf,RefRelease,DerByProduct,DerItemTaxFreeMatl,WcOutside, ItmDescription, ItmLotTracked, ItmSerialTracked, DerWhse, JbrWc, DerQtyPicked, DerUM");

            //requestData.PropertyList.SetProperties("JobItem,UbSelect,OperNum,Sequence,Item,Description,DerQtyConv,UM,DerLoc,DerLot,DerCostCode,Job,Suffix,UbImportDocId,MatlCostConv,LbrCostConv,FovhdCostConv,VovhdCostConv,OutCostConv,UbAcct,DerQtyOnHandConv,DerReqQtyConv,DerQtyIssuedConv,DerPlanCostConv,ACost,UbAcctUnit1,UbAcctUnit2,UbAcctUnit3,UbAcctUnit4,UbTargetQty,UbSelectedQty,UbGenerateQty,UbRangeQty,OrdType,Backflush,DerWC,ScrapFact,MatlQty,MatlQtyConv,DerItemExist,DerReqQty,QtyIssued,DerQty,DerItemUMConvFactor,MatlCost,LbrCost,FovhdCost,VovhdCost,OutCost,DerPlanCost,DerItemLotTracked,DerItemSerialTracked,DerItemIssueBy,UbDelTempSer,UbWhse,RowPointer,DerQtyOnHand,Units,QtyReleased,Cost,CostConv,DerItemUM,AMatlCost,ALbrCost,AFovhdCost,AVovhdCost,AOutCost,ItmMatlCost,ItmLbrCost,ItmFovhdCost,ItmVovhdCost,ItmOutCost,DerPoVendNum,RefType,RefNum");

            string filterString = "";
            if (issueNewMaterial)
            {
                filterString = "Job = '" + job + "' and Suffix ='" + suffix + "' and OperNum ='" + operation + "' and Item ='" + formatItem(item) + "'";
            }
            else
            {
                filterString = "Job = '" + job + "' and Suffix ='" + suffix + "' and OperNum ='" + operation + "' and Sequence ='" + sequence + "'";
            }

            requestData.Filter = filterString;
            requestData.RecordCap = 1;
            requestData.OrderBy = "Job";
            OrderOperSeqResponseData = ExcuteQueryRequest(requestData);
            if (OrderOperSeqResponseData == null || OrderOperSeqResponseData.Items.Count == 0)
            {
                if (issueNewMaterial)
                {
                    sequence = "0";
                }
                else
                {
                    errorMessage = "Job/Suffix/Operation/Sequence Details Not Found";
                    return false;
                }
            }
            else
            {
                if (issueNewMaterial)
                {

                    LoadCollectionRequestData requestDataNew = new LoadCollectionRequestData();
                    requestDataNew.IDOName = "SLJobmatls";
                    requestDataNew.PropertyList.SetProperties("JobItem,UbSelect,OperNum,Sequence,Item,Description,DerQtyConv,UM,DerLoc,DerLot,DerCostCode,Job,Suffix,UbImportDocId,MatlCostConv,LbrCostConv,FovhdCostConv,VovhdCostConv,OutCostConv,UbAcct,DerQtyOnHandConv,DerReqQtyConv,DerQtyIssuedConv,DerPlanCostConv,ACost,UbAcctUnit1,UbAcctUnit2,UbAcctUnit3,UbAcctUnit4,UbTargetQty,UbSelectedQty,UbGenerateQty,UbRangeQty,OrdType,Backflush,DerWC,ScrapFact,MatlQty,MatlQtyConv,DerItemExist,DerReqQty,QtyIssued,DerQty,DerItemUMConvFactor,MatlCost,LbrCost,FovhdCost,VovhdCost,OutCost,DerPlanCost,DerItemLotTracked,DerItemSerialTracked,DerItemIssueBy,UbDelTempSer,UbWhse,RowPointer,DerQtyOnHand,Units,QtyReleased,Cost,CostConv,DerItemUM,AMatlCost,ALbrCost,AFovhdCost,AVovhdCost,AOutCost,ItmMatlCost,ItmLbrCost,ItmFovhdCost,ItmVovhdCost,ItmOutCost,DerPoVendNum,RefType,RefNum,UbAcctAccessUnit1,UbAcctAccessUnit2,UbAcctAccessUnit3,UbAcctAccessUnit4,UbTransDate,RefLineSuf,RefRelease,DerByProduct,DerItemTaxFreeMatl,WcOutside, RecordDate");
                    requestDataNew.Filter = "Job = '" + job + "' and Suffix = '" + suffix + "' and OperNum ='" + operation + "' and Item ='" + formatItem(item) + "'";
                    requestDataNew.RecordCap = -1;
                    requestDataNew.OrderBy = "Job";
                    CustomLoadMethod customLoadMethod = new CustomLoadMethod();

                    customLoadMethod.Name = "GetJobMatlsSp";
                    customLoadMethod.Parameters.Add(site);
                    customLoadMethod.Parameters.Add(job);
                    customLoadMethod.Parameters.Add(suffix);
                    customLoadMethod.Parameters.Add(operation);
                    customLoadMethod.Parameters.Add("");
                    customLoadMethod.Parameters.Add(item);
                    customLoadMethod.Parameters.Add("");
                    customLoadMethod.Parameters.Add("1");
                    customLoadMethod.Parameters.Add(whse);
                    customLoadMethod.Parameters.Add("");
                    customLoadMethod.Parameters.Add(containerNum);                //container num
                    customLoadMethod.Parameters.Add("");                //inforBar
                    requestDataNew.CustomLoadMethod = customLoadMethod;

                    LoadCollectionResponseData responseDataNew = ExcuteQueryRequest(requestDataNew);
                    if (responseDataNew == null || responseDataNew.Items.Count > 0)
                    {
                        decimal openQty = Convert.ToDecimal(responseDataNew[0, "DerQty"].ToString(), CultureInfo.InvariantCulture); // FTDEV-9247

                        MessageLogging("JobMaterialIssueUpdate: " + "Open Qty = " + openQty + "  responseDataNew[0, DerReqQty] : " + responseDataNew[0, "DerReqQty"].ToString(), msgLevel.l1_information, 1200002);
                        //Console.WriteLine("Open Qty = " + openQty + "  responseDataNew[0, DerReqQty] : " + responseDataNew[0, "DerReqQty"].ToString());


                        if (openQty > 0)
                        {
                            IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                            substitutorDictionary.Add("openQty", openQty.ToString());
                            //errorMessage = "There is already a line open for this Job/Suffix/Operation/Item with Open Qty: {openQty}";                            
                            errorMessage = constructErrorMessage("There is already a line open for this Job/Suffix/Operation/Item with Open Qty: {openQty}", "SLMIXXXXX04", substitutorDictionary);
                            return false;

                        }

                    }


                }

            }

            return true;
        }
        private bool VerifyInputs()
        {

            MessageLogging("JobMaterialIssueUpdate: in VerifyInputs Method, after Whse verification", msgLevel.l1_information, 1200002);
            //Console.WriteLine("In PickForProductionUpdateDaoImpl.cs, in VerifyInputs Method, after Whse verification");

            if (!(GetPropertyValue(OrderOperSeqResponseData, "Item").ToUpper().Trim().Equals(item.ToUpper().Trim())))
            {
                IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                substitutorDictionary.Add("{item}", item);
                substitutorDictionary.Add("{sub1}", GetPropertyValue(OrderOperSeqResponseData, "Item"));
                errorMessage = constructErrorMessage("Item not matching Order {sub1}  {item}", "SLMIXXXXX06", substitutorDictionary);
                //errorMessage = "Item not matching Order {sub1}  {item}";
                return false;
            }
            //}
            MessageLogging("JobMaterialIssueUpdate: in VerifyInputs Method, after Item verification", msgLevel.l1_information, 1200002);
            //Console.WriteLine("In PickForProductionUpdateDaoImpl.cs, in VerifyInputs Method, after Item verification");
            return true;
        }
        private bool GetumcfSp()
        {
            object[] inputParams = new object[]{
                                                uom,
                                                item,
                                                "",
                                                "",
                                                ITEM_CONV_FACTOR,
                                                "",
                                                site
                                                };
            InvokeResponseData responseData = InvokeIDO("SLUMConvs", "GetumcfSp", inputParams);

            if (!(responseData.ReturnValue.Equals("0")))
            {
                errorMessage = responseData.Parameters.ElementAt(6).ToString();
                return false;
            }
            ITEM_CONV_FACTOR = responseData.Parameters.ElementAt(4).ToString();
            return true;
        }

        private bool ItemQtyDetlSp()
        {
            string qtyConv = qty;
            if (ITEM_CONV_FACTOR != null && !(ITEM_CONV_FACTOR.Equals("")))
            {
                try
                {
                    qtyConv = Convert.ToString(Convert.ToDecimal(qty, CultureInfo.InvariantCulture) / Convert.ToDecimal(ITEM_CONV_FACTOR, CultureInfo.InvariantCulture)); // FTDEV-9247
                }
                catch (Exception)
                {
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
                                                      qtyConv,
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
                errorMessage = invokeResponseDataStep2.Parameters.ElementAt(19).ToString();
                return false;
            }
            return true;

        }

        private bool ValidateLocation()
        {

            object[] inputValues = new object[]{
                                                whse,
                                                item,
                                                loc,
                                                qty,
                                                site,
                                                "",
                                                "",
                                                "",
                                                "",
                                                0,
                                                uom
                                                };
            InvokeResponseData responseData = InvokeIDO("SYMIX.SLItemacts", "MiscIssueGetLocQtyOnHandSp", inputValues);
            if (!(responseData.ReturnValue.Equals("0")))
            {
                errorMessage = responseData.Parameters.ElementAt(8).ToString();
                return false;
            }
            return true;
        }

        public bool ValidateQty()
        {
            if (ValidateQty1() == false)
            {
                // return false;  To Avoid Warning message on adding New Item.
            }

            if (GetumcfSp() == false)
            {
                return false;
            }
            if (containerNum == null || containerNum == "")
            {
                if (ItemQtyDetlSp() == false)
                {
                    return false;
                }
            }
            return true;
        }

        public bool ValidateQty1()
        {
            MessageLogging("JobMaterialIssueUpdate: in VerifyInputs Method, in ValidateQty1 Method, start", msgLevel.l1_information, 1200002);
            //Console.WriteLine("In PickForProductionUpdateDaoImpl sl8.03.10, in ValidateQty1 Method, start");
            object[] inputParams = null;
            int paramcount = 0;
            paramcount = GetIDOMethodParameterCount("SLJobmatls", "GetJobmatlItemSp");
            MessageLogging("JobMaterialIssueUpdate: SLJobmatls.GetJobmatlItemSp param count = " + paramcount, msgLevel.l1_information, 1200002);
            //Console.WriteLine(" PickforProduction sl8.03.10: SLJobmatls.GetJobmatlItemSp param count = " + paramcount);
            //switch (paramcount)
            //{
            //    case 60:
            //        inputParams = new object[]{//60
            //                                    item,
            //                                    uom,
            //                                    job,
            //                                    suffix,
            //                                    operation,
            //                                    sequence,
            //                                    whse,
            //                                    EXT_BY_SCRAP,
            //                                    "",
            //                                    "", //1
            //                                    "",
            //                                    uom,
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",//2
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    GetIDOInputBoolValue(itemSerialTracked),
            //                                    GetIDOInputBoolValue(itemLotTracked), //3
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "", //4
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",//5
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    site,
            //                                    "",
            //                                    "0",//jmtReturn
            //                                    "",
            //                                    ""
            //                                    };

            //        break;
            //    case 67:
            //        inputParams = new object[]{//60
            //                                    item,
            //                                    uom,
            //                                    job,
            //                                    suffix,
            //                                    operation,
            //                                    sequence,
            //                                    whse,
            //                                    EXT_BY_SCRAP,
            //                                    "",
            //                                    "", //1
            //                                    "",
            //                                    uom,
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",//2
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    GetIDOInputBoolValue(itemSerialTracked),
            //                                    GetIDOInputBoolValue(itemLotTracked), //3
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "", //4
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",//5
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    site,
            //                                    "",
            //                                    "0",//jmtReturn
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    ""
            //                                    };

            //        break;
            //    case 72:
            //    case 0:
                    inputParams = new object[]{
                                                item,
                                                uom,
                                                job,
                                                suffix,
                                                operation,
                                                sequence,
                                                whse,
                                                EXT_BY_SCRAP,
                                                "",
                                                "", //1
                                                "",
                                                uom,
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
                                                GetIDOInputBoolValue(itemSerialTracked),
                                                GetIDOInputBoolValue(itemLotTracked), //3
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "", //4
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",//5
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                site,
                                                "",
                                                "0",//jmtReturn
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

            //        break;
            //    case 61:
            //    default:
            //        inputParams = new object[]{//61
            //                                    item,
            //                                    uom,
            //                                    job,
            //                                    suffix,
            //                                    operation,
            //                                    sequence,
            //                                    whse,
            //                                    EXT_BY_SCRAP,
            //                                    "",
            //                                    "", //1
            //                                    "",
            //                                    uom,
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",//2
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    GetIDOInputBoolValue(itemSerialTracked),
            //                                    GetIDOInputBoolValue(itemLotTracked), //3
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "", //4
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",//5

            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    site,
            //                                    "",
            //                                    "0",//jmtReturn
            //                                    "",
            //                                    "",
            //                                    ""
            //                                    };
            //        break;




            //}
            /* 
            inputParams = new object[]{//66
                                        item,
                                        uom,
                                        job,
                                        suffix,
                                        operation,
                                        sequence,
                                        whse,
                                        EXT_BY_SCRAP,
                                        "",
                                        "", //1

                                        "",
                                        uom,
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
                                        GetIDOInputBoolValue(itemSerialTracked),
                                        GetIDOInputBoolValue(itemLotTracked), //3

                                        "",
                                        "",
                                        "",
                                        "",
                                        "",
                                        "",
                                        "",
                                        "",
                                        "",
                                        "", //4

                                        "",
                                        "",
                                        "",
                                        "",
                                        "",
                                        "",
                                        "",
                                        "",
                                        "",
                                        "",//5

                                        "",
                                        "",
                                        "",
                                        "",
                                        "",
                                        "",
                                        "",
                                        "",
                                        "",
                                        site,//6

                                        "",
                                        "",
                                        "0", //jmtReturn
                                        "",
                                        "",
                                        "",                                                
                                        }; */



            QtyInvokeResponseData = InvokeIDO("SLJobmatls", "GetJobmatlItemSp", inputParams);

            if (!(QtyInvokeResponseData.ReturnValue.Equals("0")))
            {
                errorMessage = QtyInvokeResponseData.Parameters.ElementAt(56).ToString();
                return false;
            }
            return true;
        }
        public bool CheckSerialForReturn(string serial)
        {
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLSerials";
            requestData.PropertyList.SetProperties("SerNum, Stat");
            string filterString = "SerNum = '" + serial + "' and Item ='" + formatItem(item) + "' ";
            if (Convert.ToDouble(qty, CultureInfo.InvariantCulture) > 0) // FTDEV-9247
            {
                filterString += " and Stat = 'I' ";
            }
            else
            {
                filterString += " and Stat = 'O' ";
            }
            requestData.Filter = filterString;
            requestData.RecordCap = 0;
            requestData.OrderBy = "SerNum";
            LoadCollectionResponseData responseData = ExcuteQueryRequest(requestData);
            if (responseData.Items.Count == 0)
            {
                MessageLogging("JobMaterialIssueUpdate: reexecuting query for serial number with trimmed", msgLevel.l1_information, 1200002);
                //Console.WriteLine("reexecuting query for serial number with trimmed");

                filterString = "SerNum = '" + serial.Trim() + "' and Item ='" + formatItem(item) + "' ";

                //Todo - need to determine the correct serial status.
                /*if (Convert.ToDouble(qty, CultureInfo.InvariantCulture) > 0) // FTDEV-9247
                {
                    filterString += " and Stat = 'I' ";
                }
                else
                {
                    filterString += " and Stat = 'O' ";
                }
                 */

                requestData.Filter = filterString;
                requestData.RecordCap = 0;
                requestData.OrderBy = "SerNum";
                responseData = ExcuteQueryRequest(requestData);

                if (responseData.Items.Count == 0)
                {
                    IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                    substitutorDictionary.Add("serial", serial);
                    //errorMessage = "Serial Number : {serial} Not Found" ;
                    errorMessage = constructErrorMessage("Serial Number : {serial} Not Found", "SLMIXXXXX07", substitutorDictionary);
                    return false;
                }
                else
                {
                    serialNeedToBeFormated = false;
                }
            }
            else
            {
                serialNeedToBeFormated = true;
            }
            return true;
        }

        private List<string> GetSerialListFormInputParameter()
        {
            List<string> SerialList = new List<string>(1);

            for (int i = 0; i < this._inputSerialResponseData.Items.Count; i++)
            {
                SerialList.Add(this._inputSerialResponseData[i, "SerNum"].ToString());
            }

            return SerialList;
        }



    }
}