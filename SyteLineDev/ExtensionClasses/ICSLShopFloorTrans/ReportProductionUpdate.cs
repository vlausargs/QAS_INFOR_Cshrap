using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mongoose.Core.Configuration;
using Mongoose.IDO.Protocol;
using Mongoose.IDO;
using Mongoose.Core;

using System.Diagnostics; //for message handling.
using System.Globalization;

namespace InforCollect.ERP.SL.ICSLShopFloorTrans
{

    class ReportProductionUpdate : ShopFloorUtilities
    {


        //Input Variables.
        public string job = "";
        public string suffix = "";
        public string qty = "";
        public string item = "";
        public string site = "";
        public string whse = "";
        public string loc = "";
        public string uom = "";
        public string lot = "";
        public bool generateSerials = false;
        public bool generateLot = false;
        public string documentNo = "";
        public bool addItemLocRecord = true;
        public bool allowIfCycleCountExists = false;
        public bool addPermanentItemWhseLocLink = false;
        public bool overRideQtyPrompt = false;
        private string containerNum = "";
        //Local Varialbles

        public bool itemLotTracked = false;
        public bool itemSerialTracked = false;
        public bool insertItemLocRecord = false;
        public InvokeResponseData operInvokeResponseData = null;
        public double qtyOnHand = 0;
        public bool createNewLot = false;
        public string operNum = "";
        public string formattedJob = "";
        private List<string> SerialList = null;
        private string errorMessage = "";
        private string SessionID = "";
        private bool createContainerNum = false;
        private bool containerLocMismatch = false;
        private string revision = "";

        public ReportProductionUpdate(string job, string suffix, string qty,
                                      string item, string site, string whse, string loc, string uom, string lot,
                                      bool generateSerials, bool generateLot, string documentNo,
                                      bool addItemLocRecord, bool allowIfCycleCountExists,
                                      bool addPermanentItemWhseLocLink, bool overRideQtyPrompt,
                                      string SessionID, string containerNum)
        {
            initialize();
            this.job = job;
            this.suffix = suffix;

            this.qty = qty;
            this.item = item;
            this.site = site;
            this.whse = whse;
            this.loc = loc;
            this.lot = lot; // formatDataByIDOAndPropertyName("SLLotLocs", "Lot", lot);
            this.uom = uom;
            this.generateSerials = generateSerials;
            this.generateLot = generateLot;
            this.documentNo = documentNo;
            this.overRideQtyPrompt = overRideQtyPrompt;
            this.addItemLocRecord = addItemLocRecord;
            this.allowIfCycleCountExists = allowIfCycleCountExists;
            this.addPermanentItemWhseLocLink = addPermanentItemWhseLocLink;
            this.SessionID = SessionID;
            this.containerNum = containerNum;

        }

        public ReportProductionUpdate()
        {//constructor.  initialize the object.
            initialize();
        }


        public void MessageTest(string msg)
        {

            MessageLogging("ReportProductionUpdate: Warning " + msg, msgLevel.l3_warning, 1200002);
        }
        public void initialize()
        {
            this.Initialize();//Initilize the base class.   
            //Input variables initialization
            job = "";
            suffix = "";
            site = "";
            whse = "";
            item = "";

            qty = "";
            loc = "";
            lot = "";
            uom = "";
            generateSerials = false;
            generateLot = false;
            documentNo = "";
            overRideQtyPrompt = false;

            addItemLocRecord = true;
            addPermanentItemWhseLocLink = false;
            allowIfCycleCountExists = false;
            containerNum = "";

            //Local variables initialization
            itemLotTracked = false;
            itemSerialTracked = false;
            insertItemLocRecord = false;
            operInvokeResponseData = null;
            qtyOnHand = 0;
            createNewLot = false;
            operNum = "";
            formattedJob = "";
            documentNo = "";
        }

        public bool formatInputs()
        {
            if (IsStringContainsNumericValue(job))
                job = formatDataByIDOAndPropertyName("SLJobs", "Job", job);
            if (!((containerNum == null) || containerNum.Trim().Equals("")))
            {
                containerNum = formatDataByIDOAndPropertyName("SLContainers", "ContainerNum", containerNum);

            }

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

            if (qty == null || qty.Trim().Equals(""))
            {
                errorMessage = "Qty input mandatory";
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

            item = formatDataByIDOAndPropertyName("SLRsvdInvs", "Item", item);
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
            loc = formatDataByIDOAndPropertyName("SLRsvdInvs", "Loc", loc);
            if (loc == null || loc.Trim().Equals(""))
            {
                errorMessage = "Loc input mandatory";
                return false;
            }

            lot = formatDataByIDOAndPropertyName("SLLotLocs", "Lot", lot);

            if (uom == null || uom.Trim().Equals(""))
            {
                errorMessage = "Uom input mandatory";
                return false;
            }

            // documentNo =  documentNo.Trim();

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

            //Validate Job/Suffix

            if (ValidateJob() == false)
            {
                errorMessage = "Job/Suffix Details Not Found";
                return false;
            }

            if (GetOperDetails() == false)
            {
                return false;
            }

            if (GetJobDetails() == false)
            {
                return false;
            }

            string itemUM = "";
            //Validate Site
            LoadCollectionResponseData responseData = GetSiteDetails(site);
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
                //errorMessage =  "Physical Inventory is active in Warehouse : {whse} , Adjustment not allowed";
                errorMessage = constructErrorMessage("Physical Inventory is active in Warehouse : {whse} , Adjustment not allowed", "SLRepProdXXXXX02", substitutorDictionary);
                return false;
            }

            //Check Item Details
            responseData = GetItemDetails(formatItem(item));
            if (responseData.PropertyList.Count == 0)
            {
                errorMessage = "Item Details Not Found";
                return false;
            }

            itemLotTracked = GetBool(GetPropertyValue(responseData.PropertyList, responseData.Items, "LotTracked"));
            itemSerialTracked = GetBool(GetPropertyValue(responseData.PropertyList, responseData.Items, "SerialTracked"));
            itemUM = GetPropertyValue(responseData.PropertyList, responseData.Items, "UM");

            if (validWhseItemRecordExists(whse, item, allowIfCycleCountExists, out errorMessage) == false)
            {
                return false;
            }


            //Need to add check for Obsolte and Slow moving items.

            //Check Location
            responseData = GetLocationDetails(loc);
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
                    //errorMessage =  "{site} / {whse} / {item} / {loc} combination does not exists, Transfer not allowed";
                    errorMessage = constructErrorMessage("{site} / {whse} / {item} / {loc} combination does not exists, Transfer not allowed", "SLRepProdXXXXX03", substitutorDictionary);
                    return false;
                }
                else
                {
                    insertItemLocRecord = true;
                }
            }


            //UOM Checks
            string convertedQty = GetItemConvertedQtyToBaseUnit(item, qty, uom, "", out errorMessage);
            if (convertedQty == null)
            {
                return false;
            }
            qty = convertedQty;
            uom = itemUM;

            //Lot Code Checks

            if (itemLotTracked == true)
            {
                if (lot == null || lot.Trim().Equals(""))
                {
                    errorMessage = "Item is lot controlled, Lot Input is Mandatory";
                    return false;
                }
            }

            //Qty Checks

            if (ValidateQty() == false)
            {
                return false;
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

        public int PerformUpdate(out string infobar)
        {
            infobar = "";


            if (SessionID != null && !(SessionID.Equals("")))
            {
                SerialList = this.GetSerialList(this.SessionID);
            }

            //2 Format Inputs
            if (formatInputs() == false)
            {
                infobar = errorMessage;
                infobar = formatResponse(infobar);
                return 1;
            }
            //3 validate Inputs
            if (validateInputs() == false)
            {
                infobar = errorMessage;
                infobar = formatResponse(infobar);
                return 2;
            }

            //4 Perform Updates
            if (performJobReceipt(out infobar) == false)
            {
                infobar = errorMessage;
                infobar = formatResponse(infobar);
                return 3;
            }

            infobar = formatResponse(infobar);
            return 0;
        }

        private Boolean performJobReceipt(out string infobar)
        {
            try
            {
                string message = "";
                string canOverride = "";
                infobar = "";
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
                    errorMessage = invokeResponseDataStep1.Parameters.ElementAt(3).ToString();
                    infobar = errorMessage;
                    return false;
                }

                //2 Location Check
                if (this.insertItemLocRecord == true)
                {
                    if (addLocItemRecord(item, whse, site, loc, addPermanentItemWhseLocLink) == false)
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
                // Container functionality
                if (this.createContainerNum == true)      // Create Container if it does not exist
                {

                    PerformCreateContainer(containerNum, whse, loc, out errorMessage);
                }

                //4 Set Vars

                if (JobReceiptPostSetVarsSp("S", "") == false)
                {
                    infobar = errorMessage;
                    return false;
                }

                //SLMSSerials.SetMethodSp - To store the values
                object[] serialsMethod = new object[] { "SLJobs.JobReceiptPostSp" };

                InvokeResponseData invokeResponseDataStep2 = this.Context.Commands.Invoke("SLSerials", "SetMethodSP", serialsMethod);
                if (!(invokeResponseDataStep2.ReturnValue.Equals("0")))
                {
                    errorMessage = "Transaction process failed";
                    infobar = errorMessage;
                    return false;
                }

                //Serials

                UpdateCollectionRequestData updateRequestData = new UpdateCollectionRequestData();
                updateRequestData.IDOName = "SLSerials";
                updateRequestData.RefreshAfterUpdate = true;
                updateRequestData.CustomInsert = "SerialSaveSp(SerNum,,,MESSAGE,NULL,NULL,NULL)";
                updateRequestData.CustomUpdate = "SerialSaveSp(SerNum,,,MESSAGE,NULL,NULL,NULL)";

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

                UpdateCollectionResponseData updateResponseData = this.Context.Commands.UpdateCollection(updateRequestData);
                MessageLogging("ReportProductionUpdate: Update Collection Response Data : " + updateResponseData.ToXml(), msgLevel.l1_information, 1200002);
                //Console.WriteLine("Update Collection Response Data : " + updateResponseData.ToXml());

                //Get Parameters
                message = GetParameter("JobReceiptPostSp.Inforbar");
                if (message == null)
                {//check to see what is returned from the method. JH:20140102
                    if (errorMessage != "")
                    {
                        infobar = errorMessage; //If no message was returned from the method/Syteline then return the error message
                    }
                    else
                    {//the error message was not set by the method so set infobar to the message returned by Syteline  JH:20140102
                        infobar = message;
                    }
                    return false;

                }
                canOverride = GetParameter("JobReceiptPostSp.CanOverride");
                if (canOverride == null)
                {
                    if (errorMessage != "")
                    {
                        infobar = errorMessage; //If no message was returned from the method/Syteline then return the error message
                    }
                    else
                    {//the error message was not set by the method so set infobar to the message returned by Syteline  JH:20140102
                        infobar = canOverride;
                    }
                    return false;
                }

                if (JobReceiptPostSetVarsSp("U", canOverride) == false)
                {
                    infobar = errorMessage;
                    return false;
                }

                MessageLogging("ReportProductionUpdate: JobReceiptPostSetVarsSp for update completed", msgLevel.l1_information, 1200002);
                //Console.WriteLine("JobReceiptPostSetVarsSp for update completed ");
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                infobar = errorMessage;
                return false;
            }
        }



        private bool ValidateJob()
        {
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLJobs";
            requestData.PropertyList.SetProperties("Job, Suffix, Item,ItemDescription,ItemLotTracked,ItemSerialTracked,Whse,QtyComplete,QtyReleased,QtyScrapped,DerNewStatus,Stat,Revision");
            string filterString = "Job = '" + job + "' and Suffix ='" + suffix + "'";

            requestData.Filter = filterString;
            requestData.RecordCap = 1;
            requestData.OrderBy = "Job";
            LoadCollectionResponseData responseData = ExcuteQueryRequest(requestData);
            if (responseData == null || responseData.Items.Count == 0)
            {
                return false;
            }
            if (responseData.Items.Count >0)
            {
                revision = responseData[0, "Revision"].ToString();
            }
            return true;
        }

        private bool GetOperDetails()
        {
            object[] inputValues = new object[]{
                                                job,
                                                suffix,
                                                "0",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                ""};

            operInvokeResponseData = InvokeIDO("SLJobs", "JobReceiptValidateJobSp", inputValues);
            if (!operInvokeResponseData.ReturnValue.Equals("0"))
            {
                errorMessage = operInvokeResponseData.Parameters.ElementAt(7).ToString();
                return false;
            }
            this.operNum = operInvokeResponseData.Parameters.ElementAt(2).ToString();
            return true;
        }

        private bool GetJobDetails()
        {
            object[] inputValues = new object[]{
                                                job,
                                                suffix,
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                ""};

            InvokeResponseData invokeResponseData = InvokeIDO("SLJobitems", "GetJobDetailSp", inputValues);
            if (!invokeResponseData.ReturnValue.Equals("0"))
            {
                errorMessage = invokeResponseData.Parameters.ElementAt(7).ToString();
                return false;
            }

            if (!(item.Trim().Equals(invokeResponseData.Parameters.ElementAt(4).ToString())))
            {
                IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                substitutorDictionary.Add("{item}", item);
                substitutorDictionary.Add("{sub1}", invokeResponseData.Parameters.ElementAt(4).ToString());
                //errorMessage =  "Input Item  {item} Not Matching Job Item {sub1} " ;
                errorMessage = constructErrorMessage("Input Item  {item} Not Matching Job Item {sub1} ", "SLRepProdXXXXX04", substitutorDictionary);
                return false;
            }

            if (!(whse.Trim().Equals(invokeResponseData.Parameters.ElementAt(6).ToString())))
            {
                IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                substitutorDictionary.Add("{whse}", whse);
                substitutorDictionary.Add("{sub1}", invokeResponseData.Parameters.ElementAt(6).ToString());
                //errorMessage =  "Input Whse {whse} Not Matching Job Item {sub1}" ;
                errorMessage = constructErrorMessage("Input Whse {whse} Not Matching Job Item {sub1}", "SLRepProdXXXXX04", substitutorDictionary);
                return false;
            }

            formattedJob = invokeResponseData.Parameters.ElementAt(3).ToString();
            return true;
        }

        private bool ValidateQty()
        {
            object[] inputValues = new object[]{
                                                job,
                                                suffix,
                                                item,
                                                operNum,
                                                operInvokeResponseData.Parameters.ElementAt(3).ToString(),
                                                operInvokeResponseData.Parameters.ElementAt(4).ToString(),
                                                "",
                                                ""};

            InvokeResponseData invokeResponseData = InvokeIDO("SLJobs", "JobReceiptGetQtySp", inputValues);
            if (!invokeResponseData.ReturnValue.Equals("0"))
            {
                errorMessage = invokeResponseData.Parameters.ElementAt(7).ToString();
                return false;
            }



            inputValues = new object[]{
                                            job,
                                            suffix,
                                            "",
                                            "",
                                            "",
                                            "",
                                            ""};

            InvokeResponseData invokeResponseData1 = InvokeIDO("SLJobTrans", "SetIssueParentSp", inputValues);
            if (!invokeResponseData1.ReturnValue.Equals("0"))
            {
                errorMessage = invokeResponseData1.Parameters.ElementAt(6).ToString();
                return false;
            }


            decimal dQtyMoved = Convert.ToDecimal(invokeResponseData.Parameters.ElementAt(4).ToString(), CultureInfo.InvariantCulture); // FTDEV-9247
            decimal dQtyCompleted = Convert.ToDecimal(invokeResponseData.Parameters.ElementAt(5).ToString(), CultureInfo.InvariantCulture); // FTDEV-9247
            decimal dNewQty = Convert.ToDecimal(qty, CultureInfo.InvariantCulture); // FTDEV-9247
            decimal dNet = dQtyCompleted - dQtyMoved;

            if (dNet < 0)
            {
                dNet = 0;
            }

            if (dQtyMoved + dNewQty < 0)
            {
                errorMessage = "Qty cannot be less than " + dQtyMoved;
                return false;
            }


            if (dNewQty > dNet)
            {
                if (overRideQtyPrompt == false)
                {
                    errorMessage = "Received will be greater than Available for Job operation";
                    return false;
                }
            }
            return true;
        }

        private bool PerformLotSteps()
        {
            if (this.itemLotTracked)
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
                    object[] inputLotValues = new object[] { item,
                                                  lot,
                                                  "0",
                                                  "0",
                                                  "",
                                                  "1",
                                                  revision,
                                                  "",
                                                  site,
                                                  "",
                                                  "",
                                                  ""};

                    InvokeResponseData responseDataStep = this.Context.Commands.Invoke("SLLots", "LotAddSp", inputLotValues);
                    if (!(responseDataStep.ReturnValue.Equals("0")))
                    {
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

        private bool JobReceiptPostSetVarsSp(string type, string canOverRide)
        {
            object[] inputParams = new object[]{
                                               type,
                                               job,
                                               suffix,
                                               item,
                                               operNum,
                                               qty,
                                               loc,
                                               lot,
                                               System.DateTime.Now, // FTDEV-9247 - Date-conversion for bounced method // System.DateTime.Now.ToString(WMLongDateTimePattern), // FTDEV-9195 - Adding Time to the date/time string passed into CSI
                                               (this.overRideQtyPrompt?"1":""), //1 = ignore
                                               canOverRide,
                                               "",
                                               documentNo,
                                               "",
                                               "",    // Should be updated with Employee Number after adding a new input parameter
                                               containerNum
                                               };

            InvokeResponseData responseData = InvokeIDO("SLJobs", "JobReceiptPostSetVarsSp", inputParams);
            if (!(responseData.ReturnValue.Equals("0")))
            {
                errorMessage = responseData.Parameters.ElementAt(11).ToString();
                return false;
            }
            errorMessage = responseData.Parameters.ElementAt(11).ToString();
            return true;
        }

        private string GetParameter(string parameter)
        {
            object[] inputValues = new object[]{
                                                parameter,
                                                "0",
                                                "0",
                                                "",
                                                ""
                                                };
            InvokeResponseData responseData = InvokeIDO("DefineVariables", "GetVariableSp", inputValues);
            if (responseData.ReturnValue.Equals("0"))
            {
                return responseData.Parameters.ElementAt(3).ToString();
            }
            else
            {
                errorMessage = responseData.Parameters.ElementAt(4).ToString();
                return null;
            }
        }
    }
}