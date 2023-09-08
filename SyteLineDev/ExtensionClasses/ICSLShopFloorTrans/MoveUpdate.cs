using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mongoose.Core.Configuration;
using Mongoose.IDO.Protocol;
using Mongoose.IDO;
using Mongoose.Core;
using System.Globalization;
using CSI.Logistics.Vendor;

namespace InforCollect.ERP.SL.ICSLShopFloorTrans
{
    class MoveUpdate : ShopFloorUtilities
    {
        #region InputVariables

        //Input Variables.

        public string job = "";
        public string suffix = "";
        public string oper = "";
        public string deviceId = "";
        public string transDate = "";  //yyyy/mm/dd
        public double qtyCompleted = 0;
        public double qtyScrapped = 0;
        public double qtyMoved = 0;
        public string uom = "";
        public string reasonCode = "";         //This will available only if scrapped
        public bool operComplete = false;
        public bool closeJob = false;          //This will available only if it is last operation
        public string lot = "";                //This will available only if it is last operation and qty moved > 1
        public string loc = "";
        public string whse = "";
        public string site = "";
        public string userInitials = "";
        public bool addItemLocRecord = true;
        public bool allowIfCycleCountExists = false;
        public bool addPermanentItemWhseLocLink = false;
        public bool generateSerials = false;
        public string PostingFlag = "0";          
        private string SessionID = "";
        private string containerNum = "";
        private bool issueToParentInput = false;     
        public string nextOper = "";
        public string TransNum = "";                

        //If Item is serial controlled then serial input is needed.
        #endregion

        #region LocalVariables
        //Local Varialbles
        public LoadCollectionResponseData orderResponseData = null;
        public bool lastOperation = false;
        public string employee = "";
        public string jobItem = "";
        public bool itemLotTracked = false;
        public bool itemSerialTracked = false;
        public bool insertItemLocRecord = false;
        public InvokeResponseData invokeOrderOperResponseData = null;
        public InvokeResponseData payTypeResponseData = null;
        public LoadCollectionResponseData startResponseData = null;
        public LoadCollectionResponseData indirectResponseData = null;
        public LoadCollectionResponseData reasonValidateResponseData = null;
        public InvokeResponseData invokeOrderResponseData = null;
        public InvokeResponseData ItemResponseData = null;
        public IDOUpdateItem returnUpdateItem = null;
        private string errorMessage = "";
        private List<string> SerialList = null;
        private List<string> BackFlushLotList = null;
        private bool createContainerNum = false;
        private bool containerLocMismatch = false;
        private string containerInUse = "0";
        private string issueToParentFlag = "0";
        private string jobRevisionNumber = string.Empty;

        #endregion

        #region Flow Methods

        public MoveUpdate(string job, string suffix, string oper, string deviceId, string transDate, string qtyCompleted,
                          string qtyScrapped, string qtyMoved, string uom, string reasonCode, bool operComplete, bool closeJob, string lot,
                          string loc, string whse, string site, string userInitials,
                          bool addItemLocRecord, bool allowIfCycleCountExists,
                          bool addPermanentItemWhseLocLink, bool generateSerials, string SessionID, string containerNum, bool issueToParentInput, string nextOper, string employee = "", string postingFlag = "0")
        {
            this.job = job;
            this.suffix = suffix;
            this.oper = oper;
            this.deviceId = deviceId;
            this.transDate = transDate;
            if (qtyCompleted == null)
            {
                this.qtyCompleted = 0;
                qtyCompleted = "0";
            }
            if (qtyScrapped == null)
            {
                this.qtyScrapped = 0;
                qtyScrapped = "0";
            }

            if (qtyMoved == null)
            {
                this.qtyMoved = 0;
                qtyMoved = "0";
            }
            if (qtyCompleted.Trim().Equals(""))
            {
                this.qtyCompleted = 0;
            }
            else
            {
                this.qtyCompleted = Convert.ToDouble(qtyCompleted, CultureInfo.InvariantCulture); // FTDEV-9247
            }

            if (qtyScrapped.Trim().Equals(""))
            {
                this.qtyScrapped = 0;
            }
            else
            {
                this.qtyScrapped = Convert.ToDouble(qtyScrapped, CultureInfo.InvariantCulture); // FTDEV-9247
            }

            if (qtyMoved.Trim().Equals(""))
            {
                this.qtyMoved = 0;
            }
            else
            {
                this.qtyMoved = Convert.ToDouble(qtyMoved, CultureInfo.InvariantCulture); // FTDEV-9247
            }

            this.uom = uom;
            this.reasonCode = reasonCode;
            this.operComplete = operComplete;
            this.closeJob = closeJob;
            this.lot = lot;
            this.loc = loc;
            this.whse = whse;
            this.site = site;
            this.userInitials = userInitials;
            this.addItemLocRecord = addItemLocRecord;
            this.allowIfCycleCountExists = allowIfCycleCountExists;
            this.addPermanentItemWhseLocLink = addPermanentItemWhseLocLink;
            this.generateSerials = generateSerials;
            this.SessionID = SessionID;
            this.containerNum = containerNum;
            this.issueToParentInput = issueToParentInput;
            this.employee = employee;
            this.nextOper = nextOper;

            this.PostingFlag = postingFlag;
        }


        public void initialize()
        {
            this.Initialize();
            //Input variables initialization
            job = "";
            suffix = "";
            oper = "";
            deviceId = "";
            transDate = "";
            qtyCompleted = 0;
            qtyScrapped = 0;
            qtyMoved = 0;
            uom = "";
            reasonCode = "";
            operComplete = false;
            closeJob = false;
            lot = "";
            loc = "";
            whse = "";
            site = "";
            userInitials = "";
            addItemLocRecord = true;
            allowIfCycleCountExists = false;
            addPermanentItemWhseLocLink = false;
            containerNum = "";
            issueToParentInput = false;
            //Local variables initialization
            lastOperation = false;
            orderResponseData = null;
            jobItem = "";
            itemLotTracked = false;
            itemSerialTracked = false;
            insertItemLocRecord = false;
            invokeOrderOperResponseData = null;
            employeeResponseData = null;
            payTypeResponseData = null;
            startResponseData = null;
            indirectResponseData = null;
            invokeOrderResponseData = null;
            ItemResponseData = null;
            returnUpdateItem = null;
            nextOper = "";
            //Local variables initialization
            this.lastOperation = false;
            this.jobItem = "";
            this.itemLotTracked = false;
            this.itemSerialTracked = false;
            this.insertItemLocRecord = false;
            this.invokeOrderOperResponseData = null;
            this.payTypeResponseData = null;
            this.startResponseData = null;
            this.indirectResponseData = null;
            this.reasonValidateResponseData = null;
            this.invokeOrderResponseData = null;
            this.ItemResponseData = null;
            this.returnUpdateItem = null;
            this.containerInUse = "0";
            this.jobRevisionNumber = string.Empty;
        }

        public bool formatInputs()
        {
            if (!((containerNum == null) || containerNum.Trim().Equals("")))
            {
                containerNum = formatDataByIDOAndPropertyName("SLContainers", "ContainerNum", containerNum);

            }
            job = GetExpandedString(job, "JobType", site);
            suffix = formatDataByIDOAndPropertyName("SLDcsfcs", "Suffix", suffix);


            if (job == null || job.Trim().Equals(""))
            {
                errorMessage = "job input mandatory";
                return false;
            }
            if (suffix == null || suffix.Trim().Equals(""))
            {
                errorMessage = "suffix input mandatory";
                return false;
            }
            if (oper == null || oper.Trim().Equals(""))
            {
                errorMessage = "open input mandatory";
                return false;
            }

            if (deviceId == null || deviceId.Trim().Equals(""))
            {
                errorMessage = "deviceId input mandatory";
                return false;
            }

            if (transDate == null || transDate.Trim().Equals(""))
            {
                errorMessage = "transDate input mandatory";
                return false;
            }


            if (qtyScrapped > 0)
            {
                if (reasonCode == null || reasonCode.Trim().Equals(""))
                {
                    errorMessage = "Reason Code Input Mandatory";
                    return false;
                }
            }


            if (qtyMoved <= 0)
            {
                if (closeJob == true)
                {
                    errorMessage = "Close Job is only possible when Qty Moved is greater than 0";
                    return false;
                }
            }
            lot = formatDataByIDOAndPropertyName("SLLotLocs", "Lot", lot);
            if (generateSerials == true)
            {
                errorMessage = "Serial Generation is not implemented yet.";
                return false;
            }
            return true;
        }

        private bool validateInputs()
        {

            if (loc != null && !(loc.Trim().Equals("")))
            {
                orderResponseData = GetLocationDetails(loc);
                if (orderResponseData.Items.Count == 0)
                {
                    errorMessage = "Default Location Details Not Found";
                    return false;
                }
            }

            // Checks for S and R

            orderResponseData = ValidateJob(job, suffix);
            if (orderResponseData.Items.Count == 0)
            {
                errorMessage = "Job Details Not Found";
                return false;
            }
            else                                          // Logic added for Issue to parent functionality to check if parent job exists
            {
                if ((orderResponseData[0, "RefJob"].Value == null) || (orderResponseData[0, "RefJob"].Value.Trim() == ""))
                {
                    issueToParentInput = false;
                }

            }
            if (ValidateJobOper(job, suffix, oper) == false)
            {
                errorMessage = "Job Operation Validation failed";
                return false;
            }

            //Stored Procedure Checks

            invokeOrderResponseData = JobtranJobValidSp("M", job, suffix, oper, out errorMessage);
            if (errorMessage != null && !(errorMessage.Trim().Equals("")))
            {
                return false;
            }

            invokeOrderOperResponseData = JobtranOperNumValidSp("M", job, suffix, oper, invokeOrderResponseData.Parameters.ElementAt(21).ToString(), out errorMessage);

            if (errorMessage != null && !(errorMessage.Trim().Equals("")))
            {
                return false;
            }

            ItemResponseData = GetItemByJobSp(job, suffix);
            if (errorMessage != null && !(errorMessage.Trim().Equals("")))
            {
                return false;
            }

            jobItem = ItemResponseData.Parameters.ElementAt(2).ToString();

            if (ItemResponseData.Parameters.ElementAt(4).ToString().Equals("1"))
            {
                itemSerialTracked = true;
            }

            if (ItemResponseData.Parameters.ElementAt(5).ToString().Equals("1"))
            {
                itemLotTracked = true;
            }


            if (PerformLastOperationChecks() == false)
            {
                return false;
            }

            if (qtyScrapped > 0)
            {
                if (ValidateReasonCode() == false)
                {
                    return false;
                }
            }

            //Container Functionality
            containerInUse = "0";
            if (this.containerNum != null && !(this.containerNum.Trim().Equals("")))
            {
                containerInUse = "1";
                if (ValidateQtyForRcvIntoContainerSp(this.jobItem, this.whse, this.loc, this.lot, this.site, out errorMessage) == false)
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
            try { 
                infobar = "";
                if (SessionID != null && !(SessionID.Equals("")))
                {
                    SerialList = this.GetSerialList(this.SessionID);
                    try
                    {
                        BackFlushLotList = this.GetBackFlushLotList(this.SessionID);
                    }
                    catch (Exception)
                    {

                    }
                }

                IDORuntime.LogUserMessage("MoveUpdate.PerformUpdate", UserDefinedMessageType.UserDefined1, "Before format inputs");
                //2 Format Inputs
                if (formatInputs() == false)
                {
                    infobar = errorMessage;
                    return 1;
                }
                IDORuntime.LogUserMessage("MoveUpdate.PerformUpdate", UserDefinedMessageType.UserDefined1, "Before Validate format inputs");
                //3 validate Inputs
                if (validateInputs() == false)
                {
                    infobar = errorMessage;
                    return 2;
                }
                IDORuntime.LogUserMessage("MoveUpdate.PerformUpdate", UserDefinedMessageType.UserDefined1, "Before Job posting");
                //4 Perform Updates
                if (performJobPosting() == false)
                {
                    infobar = errorMessage;
                    return 3;
                }
                IDORuntime.LogUserMessage("MoveUpdate.PerformUpdate", UserDefinedMessageType.UserDefined1, "After Job Posting");
                // Dont set the error message if return value is 0
                // -- infobar = errorMessage;
                return 0;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                infobar = errorMessage;
                return 4;
            }
        }
        #endregion

        #region private methods

        private bool performJobPosting()
        {
            try {
                //added to handle when the item location record needs to be added  JH:20121121  
                if (this.insertItemLocRecord == true)
                {
                    if (addLocItemRecord(jobItem, whse, site, loc, addPermanentItemWhseLocLink, out errorMessage) == false)
                    {
                        return false;
                    }
                }
                if (createContainerNum == true && this.containerNum != null && !(this.containerNum.Trim().Equals("")))      // Create Container if it does not exist
                {
                    IDORuntime.LogUserMessage("MoveUpdate.performJobPosting", UserDefinedMessageType.UserDefined1, "Created cont num is true, before creation");
                    PerformCreateContainer(containerNum, whse, loc, out errorMessage);
                }

                if (this.PostingFlag == "0" || this.PostingFlag == "1")
                {
                    if (insertIntoMainTable() == false)
                    {
                        return false;
                    }
                }

                if (this.PostingFlag == "0" || this.PostingFlag == "2")
                {
                    IDORuntime.LogUserMessage("MoveUpdate.performJobPosting", UserDefinedMessageType.UserDefined1, "Before perform posting");
                    if (performPosting() == false)
                    {
                        if (TransNum == null) { TransNum = ""; }
                        IDORuntime.LogUserMessage("MoveUpdate.performJobPosting", UserDefinedMessageType.UserDefined1, "Peform Posting completed and result=false, TransNum = " + TransNum);

                        //if (TransNum != null && !(TransNum.Trim().Equals("")))
                        //{
                        //    deleteFromMainTable();
                        //}

                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
            return true;
        }

        private bool PerformLastOperationChecks()
        {
            //if (invokeOrderOperResponseData.Parameters.ElementAt(9).ToString().Equals(""))
            if (invokeOrderOperResponseData.Parameters.ElementAt(9).ToString().Equals("") || invokeOrderOperResponseData.Parameters.ElementAt(9).ToString().Equals("N/A"))
            {
                lastOperation = true;
            }
            else
            {
                lastOperation = false;
            }

            if (lastOperation && qtyMoved > 0)
            {
                //Item Field Validation

                if (validWhseItemRecordExists(whse, jobItem, allowIfCycleCountExists, out errorMessage) == false)
                {
                    return false;
                }

                //Check Warehouse
                LoadCollectionResponseData responseData = GetWhseDetailsBySite(whse, site);
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
                    //errorMessage =  "Physical Inventory is active in Warehouse : {whse}, Transfer not allowed";
                    errorMessage = constructErrorMessage("Physical Inventory is active in Warehouse : {whse}, Transfer not allowed", "SLMOVXXXXX01", substitutorDictionary);
                    return false;
                }


                //Check From Location
                responseData = GetLocationDetails(loc);


                if (checkLocationDetails(jobItem, whse, site, loc, out errorMessage) == false)
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
                LoadCollectionRequestData requestCoproductData = new LoadCollectionRequestData();
                requestCoproductData.IDOName = "SLJobs";
                requestCoproductData.PropertyList.SetProperties("CoProductMix,Revision");
                requestCoproductData.Filter = !string.IsNullOrWhiteSpace(suffix) ? $"Job = '{job}' and Suffix = '{suffix}'" : $"Job = '{job}'";
                requestCoproductData.RecordCap = 0;
                requestCoproductData.OrderBy = "Job";
                string coProduct = "";
                LoadCollectionResponseData responseCoProductData = ExcuteQueryRequest(requestCoproductData);
                if (responseCoProductData != null || responseCoProductData.Items.Count > 0)
                {
                    coProduct = responseCoProductData[0, "CoProductMix"].ToString();
                    jobRevisionNumber = responseCoProductData[0, "Revision"].GetValue(string.Empty);
                }
                //Check From Lot
                if (itemLotTracked && coProduct != "1")
                {
                    if (lot == null || lot.Trim().Equals(""))
                    {
                        errorMessage = "Lot Input Mandatory";
                        return false;
                    }
                    PerformLotChecks(jobItem, lot, true, "0", site, "1");
                    if (!(errorMessage.Trim().Equals("")))
                    {
                        return false;
                    }
                }
                //  Check and create container if it does not exist 
                if (this.createContainerNum == true)
                {
                    PerformCreateContainer(containerNum, whse, loc, out errorMessage);
                }

                if (SessionID != null && !(SessionID.Equals("")))
                {
                    SerialList = this.GetSerialList(this.SessionID);
                }

                if (SerialList != null)
                {
                    for (int i = 0; i < SerialList.Count(); i++)
                    {

                        if (PerformSerialChecks(formatDataByIDOAndPropertyName("SLMSSerials", "SerNum", SerialList.ElementAt(i).ToString())) == false)
                        {
                            return false;
                        }

                    }
                }
                // Issue to Parent functionality added sdommata 10/23/2014
                if (issueToParentInput == true)
                {
                    issueToParentFlag = "1";

                }
                else
                {
                    issueToParentFlag = "0";
                }

            }
            return true;
        }

        public bool insertIntoMainTable()
        {
            double sCount = 0;
            UpdateCollectionRequestData updateRequestData = new UpdateCollectionRequestData();
            updateRequestData.IDOName = "SLJobTrans";
            updateRequestData.RefreshAfterUpdate = true;
            updateRequestData.CustomUpdate = "STD,JobtranPostSaveSp(Job,Suffix,OperNum,JobrWc),REF";
            updateRequestData.CustomInsert = "STD,JobtranPostSaveSp(Job,Suffix,OperNum,JobrWc),REF";
            updateRequestData.CustomDelete = "DeleteJobtranitemSp(TransNum),STD";

            IDOUpdateItem updateItem = new IDOUpdateItem();
            updateItem.Action = UpdateAction.Insert;
            updateItem.Properties.Add("TransNum", "");
            updateItem.Properties.Add("Posted", "0");
            updateItem.Properties.Add("Job", job);
            IDORuntime.LogUserMessage("MoveUpdate.insertIntoMainTable", UserDefinedMessageType.UserDefined1, "Element at 21 {0}", ((invokeOrderResponseData == null) ? "" : invokeOrderResponseData.Parameters.ElementAt(21).ToString()));
            updateItem.Properties.Add("JobrWc", ((invokeOrderResponseData == null) ? "" : invokeOrderResponseData.Parameters.ElementAt(21).ToString()));
            updateItem.Properties.Add("NoteExistsFlag", "", false);
            updateItem.Properties.Add("OperNum", oper);
            updateItem.Properties.Add("RowPointer", "", false);
            updateItem.Properties.Add("Suffix", suffix);
            updateItem.Properties.Add("InWorkflow", "", false);
            updateItem.Properties.Add("_ItemWarnings", "", false);

            updateItem.Properties.Add("DerOrdNum", "");

            updateItem.Properties.Add("DerOrdLine", "0");
            updateItem.Properties.Add("DerOrdRelease", "0");

            updateItem.Properties.Add("TransType", "M");
            IDORuntime.LogUserMessage("MoveUpdate.insertIntoMainTable", UserDefinedMessageType.UserDefined1, "Trans date {0}", transDate);
            updateItem.Properties.Add("TransDate", transDate);
            IDORuntime.LogUserMessage("MoveUpdate.insertIntoMainTable", UserDefinedMessageType.UserDefined1, "user initials {0}", userInitials);
            updateItem.Properties.Add("UserCode", userInitials);
            IDORuntime.LogUserMessage("MoveUpdate.insertIntoMainTable", UserDefinedMessageType.UserDefined1, "job item {0}", jobItem);
            updateItem.Properties.Add("JobItem", jobItem);
            updateItem.Properties.Add("ItemDescription", "");
            updateItem.Properties.Add("WcDescription", "");
            updateItem.Properties.Add("EmpNum", employee);
            updateItem.Properties.Add("EmpName", "", false);
            updateItem.Properties.Add("Shift", "");
            updateItem.Properties.Add("PayRate", "");
            updateItem.Properties.Add("PrRate", "");
            updateItem.Properties.Add("JobRate", "");
            updateItem.Properties.Add("IndCode", "");
            updateItem.Properties.Add("IndcodeDescription", "");
            IDORuntime.LogUserMessage("MoveUpdate.insertIntoMainTable", UserDefinedMessageType.UserDefined1, "Qty comp {0}", qtyCompleted);
            updateItem.Properties.Add("QtyComplete", qtyCompleted);
            IDORuntime.LogUserMessage("MoveUpdate.insertIntoMainTable", UserDefinedMessageType.UserDefined1, "UOM {0}", uom);
            updateItem.Properties.Add("ItemUM", uom);
            IDORuntime.LogUserMessage("MoveUpdate.insertIntoMainTable", UserDefinedMessageType.UserDefined1, "Scrap {0}", qtyScrapped);
            updateItem.Properties.Add("QtyScrapped", qtyScrapped);
            IDORuntime.LogUserMessage("MoveUpdate.insertIntoMainTable", UserDefinedMessageType.UserDefined1, "moved {0}", qtyMoved);
            updateItem.Properties.Add("QtyMoved", qtyMoved);
            IDORuntime.LogUserMessage("MoveUpdate.insertIntoMainTable", UserDefinedMessageType.UserDefined1, "nexet op {0}", invokeOrderOperResponseData.Parameters.ElementAt(9));
            if(string.IsNullOrEmpty(nextOper))
                updateItem.Properties.Add("NextOper", ((invokeOrderOperResponseData == null) ? "" : invokeOrderOperResponseData.Parameters.ElementAt(9).ToString()));
            else
                updateItem.Properties.Add("NextOper", nextOper);
            updateItem.Properties.Add("XjobrWc", "");               //can be filled 
            updateItem.Properties.Add("XwcDescription", "");    //can be filled
            updateItem.Properties.Add("ReasonCode", reasonCode);
            updateItem.Properties.Add("ReasonDescription", GetReasonCodeDesc());
            updateItem.Properties.Add("Loc", loc);
            updateItem.Properties.Add("LocDescription", "");
            updateItem.Properties.Add("DerToContainer", containerInUse);
            updateItem.Properties.Add("ContainerNum", this.containerNum);
            updateItem.Properties.Add("Lot", lot);
            updateItem.Properties.Add("DerStartTimeHrs", "", false);
            updateItem.Properties.Add("DerStartTimeMin", "", false);
            updateItem.Properties.Add("DerEndTimeMin", "", false);
            updateItem.Properties.Add("AHrs", "0");
            updateItem.Properties.Add("DerEndTimeHrs", "", false);
            updateItem.Properties.Add("Whse", whse);
            updateItem.Properties.Add("CostCode", ((invokeOrderOperResponseData == null) ? "" : invokeOrderOperResponseData.Parameters.ElementAt(8).ToString()));
            updateItem.Properties.Add("JobrCntrlPoint", "");
            updateItem.Properties.Add("CompleteOp", GetIDOInputBoolValue(operComplete));
            updateItem.Properties.Add("CloseJob", GetIDOInputBoolValue(closeJob));
            // updateItem.Properties.Add("IssueParent", "0");                   // Issue to parent logic added
            updateItem.Properties.Add("IssueParent", issueToParentFlag);
            updateItem.Properties.Add("UbTargetQty", "0");
            updateItem.Properties.Add("UbSelectedQty", "0");
            updateItem.Properties.Add("UbGenerateQty", "0");
            updateItem.Properties.Add("UbRangeQty", "0");
            updateItem.Properties.Add("UbSerialPrefix", "", false);
            updateItem.Properties.Add("JobCoProductMix", "0");
            updateItem.Properties.Add("JobOrdType", "I");
            updateItem.Properties.Add("JobJob", "", false);
            updateItem.Properties.Add("JobRefJob", "");
            updateItem.Properties.Add("JobRootJob", job);
            updateItem.Properties.Add("JobRootSuf", suffix);
            updateItem.Properties.Add("ItemSerialTracked", GetIDOInputBoolValue(itemSerialTracked));
            updateItem.Properties.Add("TransClass", "J");
            updateItem.Properties.Add("UbNewOper", "0");
            updateItem.Properties.Add("ItemLotTracked", GetIDOInputBoolValue(itemLotTracked));
            updateItem.Properties.Add("JobStat", "F");      //not sure
            updateItem.Properties.Add("JobType", "E");      //not sure
            updateItem.Properties.Add("UbOldEmp", "");
            updateItem.Properties.Add("DerQtyComplete", "0");
            updateItem.Properties.Add("DerQtyScrapped", "0");
            updateItem.Properties.Add("DerQtyMoved", "0");
            updateItem.Properties.Add("StartTime", "", false);
            updateItem.Properties.Add("EndTime", "", false);
            //updateItem.Properties.Add("Wc", invokeOrderResponseData.Parameters.ElementAt(21).ToString());
            updateItem.Properties.Add("Wc", ((invokeOrderOperResponseData == null) ? "" : invokeOrderOperResponseData.Parameters.ElementAt(6).ToString())); //should be the wc on the operation not the job.  JH:20130228 MSF157944
            updateItem.Properties.Add("CoProductMix", "0");
            updateItem.Properties.Add("UbContainerNum", this.containerNum);
            // Added Properties
            updateItem.Properties.Add("IsJobXrefdToProject", "0");
            updateItem.Properties.Add("IsSubJobTiedToProject", "0");
            updateItem.Properties.Add("JobtranitemQtyComplete", "");
            updateItem.Properties.Add("JobtranitemQtyScrapped", "");
            updateItem.Properties.Add("JobtranitemQtyMoved", "");
            // Ended 
            IDORuntime.LogUserMessage("MoveUpdate.insertIntoMainTable", UserDefinedMessageType.UserDefined1, "after adding all properties, container Number {0}", this.containerNum);

            //Add inventory records for back flush lot controlled items
            //MF07032019: removed unreachable code
            /*if (1 == 0)
            if (this.itemSerialTracked && (qtyMoved > 0) && this.lastOperation)

            {
                UpdateCollectionRequestData BuckFlushLotsData = new UpdateCollectionRequestData();
                BuckFlushLotsData.IDOName = "SLLots";
                BuckFlushLotsData.RefreshAfterUpdate = true;
                BuckFlushLotsData.CollectionID = "SLBflushLots";
                BuckFlushLotsData.CustomUpdate = "BflushLotSaveSp(UbTransNum,UbWhse,UbLot,UbSelect,UbJob,UbJobSuffix,UbJobOperNum,UbJobMatlSeq,UbEmpNum,UbItem,UbLoc,UbQtyNeeded,UbQuantity,UbWc,UbTransClass,UbTransSeq,BYREF _ItemWarnings,)";
                BuckFlushLotsData.CustomInsert = "BflushLotSaveSp(UbTransNum,UbWhse,UbLot,UbSelect,UbJob,UbJobSuffix,UbJobOperNum,UbJobMatlSeq,UbEmpNum,UbItem,UbLoc,UbQtyNeeded,UbQuantity,UbWc,UbTransClass,UbTransSeq,BYREF _ItemWarnings,)";

                PropertyPair[] propertyPair = new PropertyPair[] { new PropertyPair("TransNum", "UbTransNum") };
                BuckFlushLotsData.LinkBy = propertyPair;

                if (SessionID != null && SessionID != "")
                {
                    for (int i = 0; i < this.SerialList.Count(); i++)
                    {
                        IDOUpdateItem serialItem = new IDOUpdateItem();
                        serialItem.Action = UpdateAction.Update;
                        serialItem.ItemNumber = i;
                        serialItem.Properties.Add("SerNum", formatDataByIDOAndPropertyName("SLMSSerials", "SerNum", SerialList.ElementAt(i).ToString()));
                        serialItem.Properties.Add("UbSelect", "1");
                        serialItem.Properties.Add("ContainerNum", "", false);
                        serialItem.Properties.Add("Item", jobItem);
                        serialItem.Properties.Add("PreassignSerials", "0");
                        serialItem.Properties.Add("TransNum", "");
                        serialItem.Properties.Add("ContainerNum", containerNum);
                        BuckFlushLotsData.Items.Add(serialItem);
                    }
                    updateItem.NestedUpdates.Add(BuckFlushLotsData);
                }
            }*/


            IDORuntime.LogUserMessage("MoveUpdate.insertIntoMainTable", UserDefinedMessageType.UserDefined1, "completed backflush inventory check, container Number {0}", this.containerNum);

            //Serials are added to this updateItem  - nested update
            if (this.itemSerialTracked && (qtyMoved != 0))
            //if (this.itemSerialTracked && (qtyMoved > 0) && this.lastOperation)     
            {
                UpdateCollectionRequestData serialUpdateRequestData = new UpdateCollectionRequestData();
                serialUpdateRequestData.IDOName = "SLSerials";
                serialUpdateRequestData.RefreshAfterUpdate = true;
                serialUpdateRequestData.CollectionID = "SLSerials";
                serialUpdateRequestData.CustomUpdate = "JobtranSerialSaveSp(SerNum,UbSelect,,Item,,),BuildSerialSp(TransNum,BYREF MESSAGE)";
                serialUpdateRequestData.CustomInsert = "JobtranSerialSaveSp(SerNum,UbSelect,,Item,,),BuildSerialSp(TransNum,BYREF MESSAGE,ContainerNum)";

                PropertyPair[] propertyPair = new PropertyPair[] { new PropertyPair("TransNum", "TransNum") };
                serialUpdateRequestData.LinkBy = propertyPair;

                if (SessionID != null && SessionID != "")
                {
                    if (this.SerialList != null && this.SerialList.Count > 0 && this.SerialList.Count > qtyMoved)
                    {
                        sCount = qtyMoved;
                    }
                    else
                    {
                        sCount = this.SerialList.Count;
                    }
                    if (sCount < 0) { sCount = sCount * -1; }
                    for (int i = 0; i < sCount; i++)
                    {
                        IDOUpdateItem serialItem = new IDOUpdateItem();
                        if (qtyMoved > 0)
                            serialItem.Action = UpdateAction.Insert;
                        else
                            serialItem.Action = UpdateAction.Update;                       
                        serialItem.ItemNumber = i;
                        serialItem.Properties.Add("SerNum", formatDataByIDOAndPropertyName("SLMSSerials", "SerNum", SerialList.ElementAt(i).ToString()));
                        serialItem.Properties.Add("UbSelect", "1");
                        serialItem.Properties.Add("ContainerNum", "", false);
                        serialItem.Properties.Add("Item", jobItem);
                        serialItem.Properties.Add("PreassignSerials", "0");
                        serialItem.Properties.Add("TransNum", "");
                        serialItem.Properties.Add("ContainerNum", containerNum);

                        serialUpdateRequestData.Items.Add(serialItem);

                    }
                    updateItem.NestedUpdates.Add(serialUpdateRequestData);
                }
            }

            IDORuntime.LogUserMessage("MoveUpdate.insertIntoMainTable", UserDefinedMessageType.UserDefined1, "completed backflush inventory check, container Number {0}", this.containerNum);

            //serials items added


            updateItem.ItemID = "";
            updateItem.ItemNumber = 1;
            updateRequestData.Items.Add(updateItem);
            UpdateCollectionResponseData updateResponseData = null;
            try
            {
                updateResponseData = this.Context.Commands.UpdateCollection(updateRequestData);
                //IDORuntime.LogUserMessage("MoveUpdate.insertIntoMainTable", UserDefinedMessageType.UserDefined1, "First update return xml {0}", updateRequestData.ToXml());
                MessageLogging("MoveUpdate: " + updateResponseData.ToXml(), msgLevel.l1_information, 1200002);
                //Console.WriteLine(updateResponseData.ToXml());
            }
            catch (Exception ee)
            {
                MessageLogging("MoveUpdate: " + ee.Message, msgLevel.l4_error, 1200004);
                //Console.WriteLine(ee.Message);
                errorMessage = ee.Message;
                return false;
            }

            //second update
            IDORuntime.LogUserMessage("MoveUpdate.insertIntoMainTable", UserDefinedMessageType.UserDefined1, "Before second update");
            UpdateCollectionRequestData updateRequestDatasecond = new UpdateCollectionRequestData();
            updateRequestDatasecond.IDOName = "SLJobTrans";
            updateRequestDatasecond.RefreshAfterUpdate = true;
            updateRequestDatasecond.CustomUpdate = "Null(),REF";
            updateRequestDatasecond.CustomInsert = "Null(),REF";
            updateRequestDatasecond.CustomDelete = "Null()";

            updateItem = new IDOUpdateItem();
            updateItem.Action = UpdateAction.Insert;

            returnUpdateItem = updateResponseData.Items.ElementAt(0);
            IDORuntime.LogUserMessage("MoveUpdate.insertIntoMainTable", UserDefinedMessageType.UserDefined1, "trans num {0}", returnUpdateItem.Properties.ElementAt(0));
            updateItem.Properties.Add("TransNum", returnUpdateItem.Properties.ElementAt(0).Value);
            updateItem.Properties.Add("Posted", "0");
            updateItem.Properties.Add("Job", job);
            IDORuntime.LogUserMessage("MoveUpdate.insertIntoMainTable", UserDefinedMessageType.UserDefined1, "wc {0}", returnUpdateItem.Properties.ElementAt(21));
            updateItem.Properties.Add("JobrWc",  invokeOrderResponseData.Parameters.ElementAt(21).ToString());
            updateItem.Properties.Add("NoteExistsFlag", "0", false);
            updateItem.Properties.Add("OperNum", oper);
            IDORuntime.LogUserMessage("MoveUpdate.insertIntoMainTable", UserDefinedMessageType.UserDefined1, "row pointer {0}", returnUpdateItem.Properties.ElementAt(6));
            updateItem.Properties.Add("RowPointer", returnUpdateItem.Properties.ElementAt(returnUpdateItem.Properties.IndexOf("RowPointer")).Value, false);
            updateItem.Properties.Add("Suffix", suffix);
            updateItem.Properties.Add("InWorkflow", "", false);
            updateItem.Properties.Add("_ItemWarnings", "", false);
            updateItem.Properties.Add("DerOrdNum", "");
            updateItem.Properties.Add("DerOrdLine", "0");
            updateItem.Properties.Add("DerOrdRelease", "0");
            updateItem.Properties.Add("TransType", "M");
            updateItem.Properties.Add("TransDate", transDate);
            updateItem.Properties.Add("UserCode", userInitials);
            updateItem.Properties.Add("JobItem", jobItem);
            updateItem.Properties.Add("ItemDescription", "");
            updateItem.Properties.Add("WcDescription", "");
            updateItem.Properties.Add("EmpNum", "");
            updateItem.Properties.Add("EmpName", "", false);
            updateItem.Properties.Add("Shift", "");
            updateItem.Properties.Add("PayRate", "");
            updateItem.Properties.Add("PrRate", "");
            updateItem.Properties.Add("JobRate", "");
            updateItem.Properties.Add("IndCode", "");
            updateItem.Properties.Add("IndcodeDescription", "");
            updateItem.Properties.Add("QtyComplete", qtyCompleted);
            updateItem.Properties.Add("ItemUM", uom);
            updateItem.Properties.Add("QtyScrapped", qtyScrapped);
            updateItem.Properties.Add("QtyMoved", qtyMoved);
            if(string.IsNullOrEmpty(nextOper))
                updateItem.Properties.Add("NextOper", ((invokeOrderOperResponseData == null) ? "" : invokeOrderOperResponseData.Parameters.ElementAt(9).ToString()));
            else
                updateItem.Properties.Add("NextOper", nextOper);
            updateItem.Properties.Add("XjobrWc", "");               //can be filled 
            updateItem.Properties.Add("XwcDescription", "");    //can be filled
            updateItem.Properties.Add("ReasonCode", reasonCode);
            updateItem.Properties.Add("ReasonDescription", GetReasonCodeDesc());
            updateItem.Properties.Add("Loc", loc);
            updateItem.Properties.Add("LocDescription", "");
            IDORuntime.LogUserMessage("MoveUpdate.insertIntoMainTable", UserDefinedMessageType.UserDefined1, "container in use {0}", containerInUse);
            updateItem.Properties.Add("DerToContainer", containerInUse);
            IDORuntime.LogUserMessage("MoveUpdate.insertIntoMainTable", UserDefinedMessageType.UserDefined1, "container num {0}", containerNum);
            updateItem.Properties.Add("ContainerNum", this.containerNum);
            IDORuntime.LogUserMessage("MoveUpdate.insertIntoMainTable", UserDefinedMessageType.UserDefined1, "lot {0}", lot);
            updateItem.Properties.Add("Lot", lot);
            updateItem.Properties.Add("DerStartTimeHrs", "", false);
            updateItem.Properties.Add("DerStartTimeMin", "", false);
            updateItem.Properties.Add("DerEndTimeMin", "", false);
            updateItem.Properties.Add("AHrs", "");
            updateItem.Properties.Add("DerEndTimeHrs", "", false);
            updateItem.Properties.Add("Whse", whse);
            updateItem.Properties.Add("CostCode", ((invokeOrderOperResponseData == null) ? "" : invokeOrderOperResponseData.Parameters.ElementAt(8).ToString()));
            updateItem.Properties.Add("JobrCntrlPoint", "");
            IDORuntime.LogUserMessage("MoveUpdate.insertIntoMainTable", UserDefinedMessageType.UserDefined1, "complete op {0}", GetIDOInputBoolValue(operComplete));
            updateItem.Properties.Add("CompleteOp", GetIDOInputBoolValue(operComplete));
            IDORuntime.LogUserMessage("MoveUpdate.insertIntoMainTable", UserDefinedMessageType.UserDefined1, "close job {0}", GetIDOInputBoolValue(closeJob));
            updateItem.Properties.Add("CloseJob", GetIDOInputBoolValue(closeJob));
            // updateItem.Properties.Add("IssueParent", "0");                   // Issue to parent logic added
            IDORuntime.LogUserMessage("MoveUpdate.insertIntoMainTable", UserDefinedMessageType.UserDefined1, "issue to parent {0}", issueToParentFlag);
            updateItem.Properties.Add("IssueParent", issueToParentFlag);
            updateItem.Properties.Add("UbTargetQty", "0");
            updateItem.Properties.Add("UbSelectedQty", "0");
            updateItem.Properties.Add("UbGenerateQty", "0");
            updateItem.Properties.Add("UbRangeQty", "0");
            updateItem.Properties.Add("UbSerialPrefix", "", false);
            updateItem.Properties.Add("JobCoProductMix", "0");
            updateItem.Properties.Add("JobOrdType", "I");
            updateItem.Properties.Add("JobJob", "", false);
            updateItem.Properties.Add("JobRefJob", "");
            updateItem.Properties.Add("JobRootJob", job);
            updateItem.Properties.Add("JobRootSuf", suffix);
            updateItem.Properties.Add("ItemSerialTracked", GetIDOInputBoolValue(itemSerialTracked));
            updateItem.Properties.Add("TransClass", "J");
            updateItem.Properties.Add("UbNewOper", "0");
            updateItem.Properties.Add("ItemLotTracked", GetIDOInputBoolValue(itemLotTracked));
            updateItem.Properties.Add("JobStat", "F");      //not sure
            updateItem.Properties.Add("JobType", "E");      //not sure
            updateItem.Properties.Add("UbOldEmp", "");
            updateItem.Properties.Add("DerQtyComplete", "0");
            updateItem.Properties.Add("DerQtyScrapped", "0");
            updateItem.Properties.Add("DerQtyMoved", "0");
            updateItem.Properties.Add("StartTime", "", false);
            updateItem.Properties.Add("EndTime", "", false);
            //updateItem.Properties.Add("Wc", invokeOrderResponseData.Parameters.ElementAt(21).ToString());
            updateItem.Properties.Add("Wc", ((invokeOrderOperResponseData == null) ? "" : invokeOrderOperResponseData.Parameters.ElementAt(6).ToString())); //should be the wc on the operation not the job.  JH:20130228 MSF157944
            updateItem.Properties.Add("CoProductMix", "0");
            updateItem.Properties.Add("UbContainerNum", this.containerNum);
            // Added Properties
            updateItem.Properties.Add("IsJobXrefdToProject", "0");
            updateItem.Properties.Add("IsSubJobTiedToProject", "0");
            updateItem.Properties.Add("JobtranitemQtyComplete", "");
            updateItem.Properties.Add("JobtranitemQtyScrapped", "");
            updateItem.Properties.Add("JobtranitemQtyMoved", "");
            // Ended 
            updateItem.ItemID = returnUpdateItem.ItemID;
            updateItem.ItemNumber = 2;
            updateRequestDatasecond.Items.Add(updateItem);
            try
            {
                updateResponseData = this.Context.Commands.UpdateCollection(updateRequestDatasecond);
                MessageLogging("MoveUpdate: " + updateResponseData.ToXml(), msgLevel.l1_information, 1200002);
                //Console.WriteLine(updateResponseData.ToXml());
            }
            catch (Exception ee)
            {
                IDORuntime.LogUserMessage("MoveUpdate.insertIntoMainTable", UserDefinedMessageType.UserDefined1, "error {0}", ee.Message);
                MessageLogging("MoveUpdate: " + ee.Message, msgLevel.l4_error, 1200002);
                //Console.WriteLine(ee.Message);
                errorMessage = ee.Message + " " + returnUpdateItem.Properties.ElementAt(returnUpdateItem.Properties.IndexOf("RowPointer")).Value;
                return false;
            }

            performSetIssueParentSp();

            try
            {

                ClearSerailsBySessionID(this.SessionID);
            }
            catch (Exception)
            {
            }


            return true;

        }

        private bool performSetIssueParentSp()
        {
            object[] inputValues = new object[]{
                                                job,
                                                suffix,
                                                "0",
                                                "",
                                                "",
                                                "",
                                                ""
                                                };
            InvokeResponseData responseData = InvokeIDO("SLJobTrans", "SetIssueParentSp", inputValues);
            if (!responseData.ReturnValue.Equals("0"))
            {
                errorMessage = responseData.Parameters.ElementAt(6).ToString();
                return false;
            }

            return true;
        }

        public bool deleteFromMainTable()
        {
            UpdateCollectionRequestData updateRequestData = new UpdateCollectionRequestData();
            updateRequestData.IDOName = "SLJobTrans";
            updateRequestData.RefreshAfterUpdate = true;
            updateRequestData.CustomUpdate = "STD,JobtranPostSaveSp(Job,Suffix,OperNum,JobrWc),REF";
            updateRequestData.CustomInsert = "STD,JobtranPostSaveSp(Job,Suffix,OperNum,JobrWc),REF";
            updateRequestData.CustomDelete = "DeleteJobtranitemSp(TransNum),STD";

            IDOUpdateItem updateItem = new IDOUpdateItem();
            updateItem.Action = UpdateAction.Delete;

            IDORuntime.LogUserMessage("MoveUpdate.performJobPosting", UserDefinedMessageType.UserDefined1, "Before LoadCollectionRequest TransNum = " + TransNum);

            LoadCollectionRequestData loadRequestData = new LoadCollectionRequestData();
            loadRequestData.IDOName = "SLJobTrans";
            loadRequestData.PropertyList.SetProperties("RowPointer,RecordDate, TransNum");
            loadRequestData.Filter = "TransNum='" + TransNum + "'";
            loadRequestData.RecordCap = 1;
            LoadCollectionResponseData loadResponseData = this.Context.Commands.LoadCollection(loadRequestData);
            IDORuntime.LogUserMessage("MoveUpdate.performJobPosting", UserDefinedMessageType.UserDefined1, "Before LoadCollectionRequest row pointer= " + loadResponseData[0, "RowPointer"].Value);

            updateItem.Properties.Add("RowPointer", loadResponseData[0, "RowPointer"].Value);
            updateItem.Properties.Add("RecordDate", loadResponseData[0, "RecordDate"].Value);
            updateItem.Properties.Add("TransNum", TransNum);

            //updateItem.Properties.Add("TransNum", returnUpdateItem.Properties.ElementAt(0).Value);
            updateItem.Properties.Add("Posted", "0");
            updateItem.Properties.Add("Job", job);
            //updateItem.Properties.Add("JobrWc", invokeOrderResponseData.Parameters.ElementAt(21).ToString()); - I don't think it is needed.
            updateItem.Properties.Add("NoteExistsFlag", "0", false);
            updateItem.Properties.Add("OperNum", oper);
            //updateItem.Properties.Add("RowPointer", returnUpdateItem.Properties.ElementAt(7).Value);
            updateItem.Properties.Add("Suffix", suffix);
            updateItem.Properties.Add("InWorkflow", "", false);
            updateItem.Properties.Add("_ItemWarnings", "", false);

            updateItem.Properties.Add("DerOrdNum", "");
            updateItem.Properties.Add("DerOrdLine", "0");
            updateItem.Properties.Add("DerOrdRelease", "0");
            updateItem.Properties.Add("TransType", "M");
            updateItem.Properties.Add("TransDate", transDate);
            updateItem.Properties.Add("UserCode", userInitials);
            updateItem.Properties.Add("JobItem", jobItem);
            updateItem.Properties.Add("ItemDescription", "");
            updateItem.Properties.Add("WcDescription", "");
            updateItem.Properties.Add("EmpNum", "");
            updateItem.Properties.Add("EmpName", "", false);
            updateItem.Properties.Add("Shift", "");
            updateItem.Properties.Add("PayRate", "");
            updateItem.Properties.Add("PrRate", "");
            updateItem.Properties.Add("JobRate", "");
            updateItem.Properties.Add("IndCode", "");
            updateItem.Properties.Add("IndcodeDescription", "");
            updateItem.Properties.Add("QtyComplete", qtyCompleted);
            updateItem.Properties.Add("ItemUM", uom);
            updateItem.Properties.Add("QtyScrapped", qtyScrapped);
            updateItem.Properties.Add("QtyMoved", qtyMoved);
            //updateItem.Properties.Add("NextOper", ((invokeOrderOperResponseData == null) ? "" : invokeOrderOperResponseData.Parameters.ElementAt(9).ToString())); -- I don't think needed
            updateItem.Properties.Add("XjobrWc", "");               //can be filled 
            updateItem.Properties.Add("XwcDescription", "");    //can be filled
            updateItem.Properties.Add("ReasonCode", reasonCode);
            updateItem.Properties.Add("ReasonDescription", GetReasonCodeDesc());
            updateItem.Properties.Add("Loc", loc);
            updateItem.Properties.Add("LocDescription", "");
            updateItem.Properties.Add("DerToContainer", containerInUse);
            updateItem.Properties.Add("ContainerNum", this.containerNum);
            updateItem.Properties.Add("Lot", lot);
            updateItem.Properties.Add("DerStartTimeHrs", "", false);
            updateItem.Properties.Add("DerStartTimeMin", "", false);
            updateItem.Properties.Add("DerEndTimeMin", "", false);
            updateItem.Properties.Add("AHrs", "");
            updateItem.Properties.Add("DerEndTimeHrs", "", false);
            updateItem.Properties.Add("Whse", whse);
            updateItem.Properties.Add("CostCode", ((invokeOrderOperResponseData == null) ? "" : invokeOrderOperResponseData.Parameters.ElementAt(8).ToString()));
            updateItem.Properties.Add("JobrCntrlPoint", "need to be filled");
            updateItem.Properties.Add("CompleteOp", GetIDOInputBoolValue(operComplete));
            updateItem.Properties.Add("CloseJob", GetIDOInputBoolValue(closeJob));
            // updateItem.Properties.Add("IssueParent", "0");                   // Issue to parent logic added
            updateItem.Properties.Add("IssueParent", issueToParentFlag);
            updateItem.Properties.Add("UbTargetQty", "0");
            updateItem.Properties.Add("UbSelectedQty", "0");
            updateItem.Properties.Add("UbGenerateQty", "0");
            updateItem.Properties.Add("UbRangeQty", "0");
            updateItem.Properties.Add("UbSerialPrefix", "", false);
            updateItem.Properties.Add("JobCoProductMix", "0");
            updateItem.Properties.Add("JobOrdType", "I");
            updateItem.Properties.Add("JobJob", "", false);
            updateItem.Properties.Add("JobRefJob", "");
            updateItem.Properties.Add("JobRootJob", job);
            updateItem.Properties.Add("JobRootSuf", suffix);
            updateItem.Properties.Add("ItemSerialTracked", GetIDOInputBoolValue(itemSerialTracked));
            updateItem.Properties.Add("TransClass", "J");
            updateItem.Properties.Add("UbNewOper", "0");
            updateItem.Properties.Add("ItemLotTracked", GetIDOInputBoolValue(itemLotTracked));
            updateItem.Properties.Add("JobStat", "F");      //not sure
            updateItem.Properties.Add("JobType", "E");      //not sure
            updateItem.Properties.Add("UbOldEmp", "");
            updateItem.Properties.Add("DerQtyComplete", "0");
            updateItem.Properties.Add("DerQtyScrapped", "0");
            updateItem.Properties.Add("DerQtyMoved", "0");
            updateItem.Properties.Add("StartTime", "", false);
            updateItem.Properties.Add("EndTime", "", false);
            //updateItem.Properties.Add("Wc", invokeOrderResponseData.Parameters.ElementAt(21).ToString());
            //updateItem.Properties.Add("Wc", invokeOrderOperResponseData.Parameters.ElementAt(6).ToString()); //should be the wc on the operation not the job.  JH:20130228 MSF157944 -- i don't think it is needed
            updateItem.Properties.Add("CoProductMix", "0");
            // Added Properties
            updateItem.Properties.Add("IsJobXrefdToProject", "0");
            updateItem.Properties.Add("IsSubJobTiedToProject", "0");
            updateItem.Properties.Add("JobtranitemQtyComplete", "");
            updateItem.Properties.Add("JobtranitemQtyScrapped", "");
            updateItem.Properties.Add("JobtranitemQtyMoved", "");
            // Ended 
            //updateItem.ItemID = returnUpdateItem.ItemID;
            updateItem.ItemNumber = 1;
            updateRequestData.Items.Add(updateItem);
            UpdateCollectionResponseData updateResponseData = null;
            try
            {
                updateResponseData = this.Context.Commands.UpdateCollection(updateRequestData);
                MessageLogging("MoveUpdate: " + updateResponseData.ToXml(), msgLevel.l1_information, 1200002);
                //Console.WriteLine(updateResponseData.ToXml());
            }
            catch (Exception ee)
            {
                MessageLogging("MoveUpdate: " + ee.Message, msgLevel.l4_error, 1200002);
                //Console.WriteLine(ee.Message);
                errorMessage = ee.Message;
                return false;
            }
            return true;

        }

        private bool performPosting()
        {
            //if a customer reports a error with the number of params for JobJobP see LaborStopDaoImpl.performPosting() JH:20130215
            //  no error has been reported in this class or for previous version of this class and it appears to work.  So no changes were made at this time 
            //  but this has been a significant issue in the past for labor stop.
            int paramcount = 0;
            paramcount = GetIDOMethodParameterCount("SLJobTrans", "JobJobP");
            string transStartDate = transDate;
            DateTime startDate;
            try
            {
                int index = transDate.IndexOf(' ');
                if (index > 0)
                {
                    startDate = DateTime.ParseExact(transDate.Substring(0, transDate.LastIndexOf(".")), "yyyy/MM/dd HH:mm:ss", CultureInfo.CurrentCulture);
                }
                else
                {
                    startDate = DateTime.ParseExact(transDate, "yyyy/MM/dd", CultureInfo.CurrentCulture);
                }
                transStartDate = startDate.AddDays(-1).ToString("yyyy/MM/dd");
            }
            catch (Exception)
            {
                transStartDate = transDate;
            }

            //MessageLogging("MoveUpdate: SLJobmatls.GetJobmatlItemSp param count = " + paramcount, msgLevel.l1_information, 1200002);
            IDORuntime.LogUserMessage("MoveUpdate.performJobPosting", UserDefinedMessageType.UserDefined1, "SLJobTrans.JobJobP param count = " + paramcount);
            IDORuntime.LogUserMessage("MoveUpdate.performJobPosting", UserDefinedMessageType.UserDefined1, "transDate = " + transDate);
            IDORuntime.LogUserMessage("MoveUpdate.performJobPosting", UserDefinedMessageType.UserDefined1, "job = " + job + " Suffix = " + suffix);
            //Console.WriteLine(" PickforProduction sl8.03.10: SLJobmatls.GetJobmatlItemSp param count = " + paramcount);
            object[] inputValues = new object[]{
                                                "1",
                                                "0",
                                                job,
                                                job,
                                                suffix,   //5
                                                suffix,
                                                transStartDate,
                                                transDate,
                                                "",
                                                "",      //10 
                                                "",
                                                "",
                                                "",
                                                "",
                                                userInitials,   //15
                                                userInitials,
                                                "H S N",
                                                whse,
                                                "",
                                                "",       //20
                                                "",
                                                "",
                                                "",
                                                ""          //new
                                                };
            try
            {
                InvokeResponseData responseData = InvokeIDO("SLJobTrans", "JobJobP", inputValues);
                //errorMessage = responseData.Parameters.ElementAt(20).ToString();
                if (!responseData.ReturnValue.Equals("0"))
                {
                    IDORuntime.LogUserMessage("MoveUpdate.performJobPosting", UserDefinedMessageType.UserDefined1, "in error condition " + responseData.Parameters.ElementAt(20).ToString());
                    // errorMessage field should be assigned only if return value is not zero, if not it should be empty *** 5/30 dpaul
                    errorMessage = responseData.Parameters.ElementAt(20).ToString();
                    return false;
                }
            }
            catch (Exception e)
            {
                IDORuntime.LogUserMessage("MoveUpdate.performJobPosting", UserDefinedMessageType.UserDefined1, "in Exception block " + e.Message.ToString());
                errorMessage = e.Message.ToString();
                return false;
            }

            return true;

        }

        private bool ValidateReasonCode()
        {
            reasonValidateResponseData = GetReasonCodeDetails(reasonCode, "MFG SCRAP");
            if (reasonValidateResponseData.Items.Count == 0)
            {
                errorMessage = "Reason Code Details Not Found";
                return false;
            }
            return true;
        }

        private string GetReasonCodeDesc()
        {
            if (this.reasonValidateResponseData == null)
            {
                return "";
            }
            string desc = GetPropertyValue(reasonValidateResponseData, "Description");
            if (desc == null)
            {
                return "";
            }
            return desc;

        }
        public InvokeResponseData GetItemByJobSp(string Job, string Suffix)
        {
           // int paramcount = 0;
            object[] inputValues = null;
            //paramcount = GetIDOMethodParameterCount("SLJobTrans", "GetItemByJobSp");
            //Console.WriteLine("SLJobTrans, GetItemByJobSp paramcount = " + paramcount);
            //switch (paramcount)
            //{
            //    case 10:

            //        inputValues = new object[]{//10
            //                                    Job,
            //                                    Suffix,
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    ""
            //                                    };
            //        break;
            //    case 12:                            //MSF189598  Code update to handle extra parameters being added for SL9.00.20  
            //        inputValues = new object[]{//12
            //                                    Job,
            //                                    Suffix,
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",   //10
            //                                    "",
            //                                    ""
            //                                    };
            //        break;
            //    case 14:                            //SL 9.01 related changes Kiran 04-06-2016.n 
                    inputValues = new object[]{//12
                                                Job,
                                                Suffix,
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",   //10
                                                "",
                                                "",
                                                "",
                                                ""
                                                };
            //        break;
            //}
            InvokeResponseData responseData = InvokeIDO("SLJobTrans", "GetItemByJobSp", inputValues);
            if (!responseData.ReturnValue.Equals("0"))
            {
                errorMessage = responseData.Parameters.ElementAt(6).ToString();
            }
            return responseData;
        }

        private bool PerformSerialChecks(string serial)
        {
            object[] inputValues = new object[]{
                                                serial,
                                                jobItem,
                                                ""
                                                };
            InvokeResponseData responseData = InvokeIDO("SLJobTrans", "CheckSerialSp", inputValues);

            if (responseData.ReturnValue.Equals("16"))
            {
                errorMessage = responseData.Parameters.ElementAt(2).ToString();
                return false;
            }

            inputValues = new object[]{
                                       site,
                                       serial,
                                       jobItem,
                                       "1",
                                       "",
                                       "",
                                       ""
                                       };

            responseData = InvokeIDO("SLDctrans", "ChkSnSp", inputValues);

            if (responseData.ReturnValue.Equals("16"))
            {
                errorMessage = responseData.Parameters.ElementAt(5).ToString();
                return false;
            }
            return true;
        }

        public InvokeResponseData PerformLotChecks(string item, string lot, bool addLot, string qty, string site)
        {
            return PerformLotChecks(item, lot, addLot, qty, site, "0");
        }

        public InvokeResponseData PerformLotChecks(string item, string lot, bool addLot, string qty, string site, string createNonUnique)
        {
            object[] inputValues = new object[]{//13+
                                                lot,
                                                item,
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
                                                "",
                                                ""};

            InvokeResponseData responseData = InvokeIDO("SLJobTrans", "JobtranLotValidSp", inputValues);
            if (!string.IsNullOrEmpty(responseData.Parameters.ElementAt(10).ToString()))
            {
                errorMessage = responseData.Parameters.ElementAt(10).ToString();
                return responseData;
            }

            string itemRevisionTracked = string.Empty;
            LoadCollectionResponseData itemResponseData = this.Context.Commands.LoadCollection(new LoadCollectionRequestData("SLItems", "TrackEcn", string.Format("Item = '{0}'", item), null, 1));
            if (itemResponseData != null && itemResponseData.Items != null && itemResponseData.Items.Count > 0)
            {
                itemRevisionTracked = itemResponseData[0, "TrackEcn"].GetValue(string.Empty);
                jobRevisionNumber = (itemRevisionTracked == "1") ? jobRevisionNumber : string.Empty;
            }
            else
            {
                jobRevisionNumber = string.Empty;
            }

            if (responseData.Parameters.ElementAt(6).ToString().Equals("1"))
            {
                if (addLot)
                {
                    inputValues = new object[] {
                                                item,
                                                 lot,
                                                 qty,
                                                 "0",
                                                 "",
                                                 createNonUnique,
                                                 jobRevisionNumber,
                                                 "",
                                                 site,
                                                 "",
                                                 "",
                                                 ""
                                                 };

                    responseData = InvokeIDO("SLLots", "LotAddSp", inputValues);
                    if (!(responseData.ReturnValue.Equals("0")))
                    {
                        errorMessage = responseData.Parameters.ElementAt(6).ToString();
                    }
                }
                else
                {
                    errorMessage = responseData.Parameters.ElementAt(8).ToString();
                }
            }
            else if (itemRevisionTracked == "1")
            {
                LoadCollectionResponseData lotResponseData = this.Context.Commands.LoadCollection(new LoadCollectionRequestData("SLLots", "Revision, RecordDate, RowPointer", $"Item = '{item}' and Lot = '{lot}'", null, 1));
                if (lotResponseData != null && lotResponseData.Items != null && lotResponseData.Items.Count > 0)
                {
                    string lotRevisionNumber = lotResponseData[0, "Revision"].GetValue(string.Empty);
                    string blankString = "(Blank)";
                    if (string.IsNullOrWhiteSpace(lotRevisionNumber))
                    {
                        UpdateCollectionRequestData updateLotRequestData = new UpdateCollectionRequestData{IDOName = "SLLots", RefreshAfterUpdate = true};
                        IDOUpdateItem updateItem = new IDOUpdateItem{Action = UpdateAction.Update};
                        updateItem.Properties.Add("Item", item, false);
                        updateItem.Properties.Add("Lot", lot, false);
                        updateItem.Properties.Add("Revision", jobRevisionNumber, true);
                        updateItem.Properties.Add("RecordDate", lotResponseData[0, "RecordDate"].GetValue(string.Empty), false);
                        updateItem.Properties.Add("RowPointer", lotResponseData[0, "RowPointer"].GetValue(string.Empty), false);
                        updateItem.ItemID = string.Empty;
                        updateItem.ItemNumber = 1;
                        updateLotRequestData.Items.Add(updateItem);
                        IDORuntime.LogUserMessage("MoveUpdate.PerformLotChecks", UserDefinedMessageType.UserDefined1, $"item: '{item}', lot: '{lot}', jobRevisionNumber: '{jobRevisionNumber}'");
                        UpdateCollectionResponseData updateLotResponseData = null;
                        try
                        {
                            updateLotResponseData = this.Context.Commands.UpdateCollection(updateLotRequestData);
                        }
                        catch(Exception)
                        {
                            errorMessage = $"Unable to update Lot Revision number with Job Revision number: [{(string.IsNullOrWhiteSpace(jobRevisionNumber) ? blankString : jobRevisionNumber)}]";
                        }
                        if (updateLotResponseData == null || updateLotResponseData.Items == null || updateLotResponseData.Items.Count <= 0)
                        {
                            errorMessage = $"Unable to update Lot Revision number with Job Revision number: [{(string.IsNullOrWhiteSpace(jobRevisionNumber) ? blankString : jobRevisionNumber)}]";
                        }
                    }
                    else if (!lotRevisionNumber.Equals(jobRevisionNumber))
                    {
                        errorMessage = $"Lot Revision number: [{lotRevisionNumber}] is not matching with Job Revision number: [{(string.IsNullOrWhiteSpace(jobRevisionNumber) ? blankString : jobRevisionNumber)}]";
                    }
                }
            }

            return responseData;
        }

        #endregion


    }
}