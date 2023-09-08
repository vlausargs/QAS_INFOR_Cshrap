using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mongoose.Core.Configuration;
using Mongoose.IDO.Protocol;
using Mongoose.IDO;
using Mongoose.Core;


namespace InforCollect.ERP.SL.ICSLShopFloorTrans
{
    class JobMoveUpdate : ShopFloorUtilities
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
        public string PostingFlag = "0";          // 0: Insert and Post, 1: Insert only, 2: Post only
        private readonly string SessionID = "";
        private string containerNum = "";
        private bool issueToParentInput = false;     // New Parameter being added to support Issue to Parent job  from Sub assembley job

        public string TransNum = "";                //Kiran 11-4-2015 - Added to support deletion of jobtrans records in Posting fails.
        private LoadCollectionResponseData backflushLotsResponseData;
        private LoadCollectionResponseData backflushSerialsResponseData;
        private LoadCollectionResponseData scrapResponseData;
        private LoadCollectionResponseData endItemSerialsResponseData;
        private LoadCollectionResponseData coproductResponseData;
        private bool reverserQty;

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
        private bool createContainerNum = false;
        private readonly bool containerLocMismatch = false;
        private string containerInUse = "0";
        private string issueToParentFlag = "0";
        private string jobRevisionNumber = string.Empty;

        #endregion

        #region Flow Methods
        public JobMoveUpdate(string job, string suffix, string oper, string deviceId, string transDate,
                             string qtyCompleted, string qtyScrapped, string qtyMoved, string uom, string reasonCode,
                             bool operComplete, bool closeJob, string lot, string loc, string whse, string site,
                             string userInitials, bool addItemLocRecord, bool allowIfCycleCountExists,
                             bool addPermanentItemWhseLocLink, bool generateSerials, string SessionID,
                             string containerNum, bool issueToParentInput, string employee = "", bool reverserQty = false,
                             string scrapDataXML = "", string backflushLotsDataXML = "",
                             string backflushSerialsDataXML = "", string endItemSerialsDataXML = "", string coproductDataXML = "")
        {
            this.InitializeClass();
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
            if(qtyCompleted.Trim().Equals(""))
            {
                this.qtyCompleted = 0;
            }
            else
            {
                this.qtyCompleted = Convert.ToDouble( qtyCompleted);
            }

            if(qtyScrapped.Trim().Equals(""))
            {
                this.qtyScrapped = 0;
            }
            else
            {
                this.qtyScrapped = Convert.ToDouble( qtyScrapped);
            }

            if(qtyMoved.Trim().Equals(""))
            {
                this.qtyMoved = 0;
            }
            else
            {
                this.qtyMoved = Convert.ToDouble( qtyMoved);
            }

            this.uom = uom;
            this.reasonCode = reasonCode ;
            this.operComplete = operComplete ;
            this.closeJob = closeJob ;
            this.lot = lot;
            this.loc = loc ;
            this.whse = whse;
            this.site = site;
            this.userInitials = userInitials ;
            this.addItemLocRecord = addItemLocRecord;
            this.allowIfCycleCountExists = allowIfCycleCountExists;
            this.addPermanentItemWhseLocLink = addPermanentItemWhseLocLink;
            this.generateSerials = generateSerials ;            
            this.SessionID = SessionID;
            this.containerNum = containerNum;
            this.issueToParentInput = issueToParentInput;
            this.employee = employee;

            this.reverserQty = reverserQty;
            if (string.IsNullOrEmpty(scrapDataXML) == false && scrapDataXML != "")
            {
                this.scrapResponseData = LoadCollectionResponseData.FromXml(scrapDataXML);
            }
            if (string.IsNullOrEmpty(backflushLotsDataXML) == false && backflushLotsDataXML != "")
            {
                this.backflushLotsResponseData = LoadCollectionResponseData.FromXml(backflushLotsDataXML);
            }
            if (string.IsNullOrEmpty(backflushSerialsDataXML) == false && backflushSerialsDataXML != "")
            {
                this.backflushSerialsResponseData = LoadCollectionResponseData.FromXml(backflushSerialsDataXML);
            }
            if (string.IsNullOrEmpty(endItemSerialsDataXML) == false && endItemSerialsDataXML != "")
            {
                this.endItemSerialsResponseData = LoadCollectionResponseData.FromXml(endItemSerialsDataXML);
            }
            if (string.IsNullOrEmpty(coproductDataXML) == false && coproductDataXML != "")
            {
                this.coproductResponseData = LoadCollectionResponseData.FromXml(coproductDataXML);
            }
        }


        public void InitializeClass()
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
            reverserQty = false;
            backflushLotsResponseData = null;
            backflushSerialsResponseData = null;
            endItemSerialsResponseData = null;
            coproductResponseData = null;
            scrapResponseData = null;
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
        }

        public bool FormatInputs( )
        {
            employee = formatDataByIDOAndPropertyName("SLEmployees", "EmpNum", employee);

            if (!((containerNum == null) || containerNum.Trim().Equals("")))
            {
                containerNum = formatDataByIDOAndPropertyName("SLContainers", "ContainerNum", containerNum);

            }
            job = GetExpandedString(job,"JobType",site);
            suffix = formatDataByIDOAndPropertyName("SLDcsfcs", "Suffix",  suffix);
           

            if (job == null || job.Trim().Equals(""))
            {
                errorMessage =  "job input mandatory";
                return false;
            }
            if (suffix == null || suffix.Trim().Equals(""))
            {
                errorMessage =  "suffix input mandatory";
                return false;
            }
            if (oper == null || oper.Trim().Equals(""))
            {
                errorMessage =  "open input mandatory";
                return false;
            }

            if (deviceId == null || deviceId.Trim().Equals(""))
            {
                errorMessage =  "deviceId input mandatory" ;
                return false;
            }

            if (transDate == null || transDate.Trim().Equals(""))
            {
                errorMessage =  "transDate input mandatory" ;
                return false;
            }

           
            if (qtyScrapped > 0)
            {
                if (reasonCode == null || reasonCode.Trim().Equals(""))
                {
                    errorMessage =  "Reason Code Input Mandatory";
                    return false;
                }
            }


            if (qtyMoved <= 0)
            {
                if (closeJob == true)
                {
                    errorMessage =  "Close Job is only possible when Qty Moved is greater than 0" ;
                    return false;
                }
            }


            lot = formatDataByIDOAndPropertyName("SLLotLocs", "Lot",  lot);
            if (generateSerials == true)
            {
                errorMessage =  "Serial Generation is not implemented yet.";
                return false;
            }

            return true;
        }

        private bool ValidateInputs()
        {
            
            if (loc != null && !(loc.Trim().Equals("")))
            {
                orderResponseData = GetLocationDetails(loc);
                if (orderResponseData.Items.Count == 0)
                {
                    errorMessage =  "Default Location Details Not Found";
                    return false;
                }
            }

            // Checks for S and R -- to be verified later .sn

            orderResponseData = ValidateJob(job, suffix);
            if (orderResponseData.Items.Count == 0)
            {
                errorMessage = "Job Details Not Found";
                return false;
            }
            else                                          // Logic added for Issue to parent functionality to check if parent job exists
            {
                if ((orderResponseData[0, "RefJob"].Value == null) ||( orderResponseData[0, "RefJob"].Value.Trim() == ""))
                {
                    issueToParentInput = false;
                }

            }

            if (ValidateJobOper(job, suffix, oper) == false)
            {
                errorMessage = "Job Operation Validation failed";
                return false;
            }
                                       // -- to be verified later .en
            //Stored Procedure Checks

            invokeOrderResponseData = JobtranJobValidSp("M", job, suffix, oper, out errorMessage);
            if (errorMessage != null && !(errorMessage.Trim().Equals("")))
            {
                return false;
            }

            invokeOrderOperResponseData = JobtranOperNumValidSp("M", job, suffix, oper, invokeOrderResponseData.Parameters.ElementAt(21).ToString(),  out errorMessage);
            
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

        private List<string> GetSerialListFromXml()
        {
            List<string> SerialList = new List<string>(1);

            for (int i = 0; i < endItemSerialsResponseData.Items.Count; i++)
            {
                SerialList.Add(endItemSerialsResponseData[i, "SerNum"].ToString());
            }

            return SerialList;
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int PerformUpdate(out string infobar)
        {
            try { 
                infobar = "";
                if (SessionID != null && !(SessionID.Equals("")))
                {
                    SerialList = this.GetSerialListFromXml();
                    // moving the following two calls out of the try/catch so that any errors are not hidden.
                    if (PopulateBackflushLotUM() == false)
                    {
                        infobar = errorMessage;
                        return 11;
                    }
                    if (PopulateBackflushSerialLotLoc() == false)
                    {
                        infobar = errorMessage;
                        return 12;
                    }
                }

                IDORuntime.LogUserMessage("MoveUpdate.PerformUpdate", UserDefinedMessageType.UserDefined1, "Before format inputs");
                //2 Format Inputs
                if (FormatInputs( ) == false)
                {
                    infobar = errorMessage;
                    return 1;
                }
                IDORuntime.LogUserMessage("MoveUpdate.PerformUpdate", UserDefinedMessageType.UserDefined1, "Before Validate format inputs");
                //3 validate Inputs
                if (ValidateInputs( ) == false)
                {
                    infobar = errorMessage;
                    return 2;
                }
                IDORuntime.LogUserMessage("MoveUpdate.PerformUpdate", UserDefinedMessageType.UserDefined1, "Before Job posting");
                //4 Perform Updates
                if (PerformJobPosting() == false)
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
        private bool PopulateBackflushLotUM()
        {
            errorMessage = string.Empty;
            if (!backflushLotsResponseData.PropertyList.List.Contains("UM"))
                backflushLotsResponseData.PropertyList.Add("UM");
            for (int i = 0; i < backflushLotsResponseData.Items.Count; i++)
            {
                string filter = String.Format(
                    "Item = '{0}' AND Job = '{1}' AND OperNum = '{2}' AND Suffix = '{3}' AND Sequence = '{4}' AND Backflush = 1",
                    backflushLotsResponseData[i, "Item"].ToString(),
                    backflushLotsResponseData[i, "Job"].ToString(), // temporary fix until we can address whats populating data into the ft tmp table ic_jobt_mat
                    backflushLotsResponseData[i, "OperNum"].ToString(),
                    backflushLotsResponseData[i, "Suffix"].ToString(),
                    backflushLotsResponseData[i, "Sequence"].ToString()
                );
                LoadCollectionRequestData requestData = new LoadCollectionRequestData
                {
                    IDOName = "SLJobmatls",
                    RecordCap = 1,
                    OrderBy = "UM",
                    Filter = filter
                };
                requestData.PropertyList.SetProperties("UM");

                LoadCollectionResponseData responseData = ExcuteQueryRequest(requestData);
                if (responseData.Items.Count == 1)
                {
                    string newUM = responseData[0, "UM"].ToString();
                    backflushLotsResponseData.Items[i].PropertyValues.Add(new IDOPropertyValue(newUM));
                }
                else
                {
                    errorMessage = String.Format("Found [{0}] UM entries for filter [{1}]", responseData.Items.Count.ToString(), filter);
                    return false;
                }
            }
            return true;
        }

        private bool PopulateBackflushSerialLotLoc()
        {
            errorMessage = string.Empty;
            if (!backflushSerialsResponseData.PropertyList.List.Contains("Loc"))
                backflushSerialsResponseData.PropertyList.Add("Loc");
            if (!backflushSerialsResponseData.PropertyList.List.Contains("Lot"))
                backflushSerialsResponseData.PropertyList.Add("Lot");

            for (int i = 0; i < backflushSerialsResponseData.Items.Count; i++)
            {
                string filter = String.Format(
                    "Item = '{0}' AND SerNum = '{1}'",
                    backflushSerialsResponseData[i, "Item"].ToString(),
                    backflushSerialsResponseData[i, "SerNum"].ToString()
                );
                LoadCollectionRequestData requestData = new LoadCollectionRequestData
                {
                    IDOName = "SLSerials",
                    Filter = filter,
                    RecordCap = 1,
                    OrderBy = "CreateDate"
                };
                requestData.PropertyList.SetProperties("Loc, Lot");

                LoadCollectionResponseData responseData = ExcuteQueryRequest(requestData);
                if (responseData.Items.Count == 1)
                {
                    string newLoc = responseData[0, "Loc"].ToString();
                    string newLot = responseData[0, "Lot"].ToString();

                    if (String.IsNullOrEmpty(newLoc))
                    {
                        filter = String.Format(
                            "Item = '{0}' AND Job = '{1}'",
                            backflushSerialsResponseData[i, "Item"].ToString(),
                            this.job
                        );
                        LoadCollectionRequestData request2Data = new LoadCollectionRequestData
                        {
                            IDOName = "SLJobmatls",
                            Filter = filter,
                            RecordCap = 1,
                            OrderBy = "CreateDate"
                        };
                        request2Data.PropertyList.SetProperties("BflushLoc");
                        LoadCollectionResponseData response2Data = ExcuteQueryRequest(request2Data);
                        if (response2Data.Items.Count > 0)
                        {
                            newLoc = response2Data[0, "BflushLoc"].ToString();
                        }
                    }

                    // the following two lines have to be in the same order as the PropertyList.Add lines at the top of this method.
                    backflushSerialsResponseData.Items[i].PropertyValues.Add(new IDOPropertyValue(newLoc));
                    backflushSerialsResponseData.Items[i].PropertyValues.Add(new IDOPropertyValue(newLot));
                }
                else
                {
                    errorMessage = String.Format("Found [{0}] Loc,Lot entries for filter [{1}]", responseData.Items.Count.ToString(), filter);
                    return false;
                }
            }
            return true;
        }

        private bool PerformJobPosting(   )
        {
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
                IDORuntime.LogUserMessage("MoveUpdate.performJobPosting", UserDefinedMessageType.UserDefined1, "Created container number is true, before creation");
                PerformCreateContainer(containerNum, whse, loc, out errorMessage);
            }

            //Add additional  Scrap 
            // Insert main record
            if (AddScrap() == false)
            {
                return false;
            }

            // Insert main record
            if (InsertIntoTable() == false)
            {
                return false;
            }

            IDORuntime.LogUserMessage("MoveUpdate.performJobPosting", UserDefinedMessageType.UserDefined1, "Before perform posting");

            ////if (PerformPosting() == false)
            ////{
            ////    if (TransNum == null) { TransNum = ""; }
            ////    IDORuntime.LogUserMessage("MoveUpdate.performJobPosting", UserDefinedMessageType.UserDefined1, "Peform Posting completed and result=false, TransNum = " + TransNum);

            ////    //if (TransNum != null && !(TransNum.Trim().Equals("")))
            ////    //{
            ////    //    deleteFromMainTable();
            ////    //}

            ////    return false;
            ////}
            if (PostingFlag == "0" || PostingFlag == "2")
            {
                if (PerformPosting() == false)
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
            /*
            if (this.PostingFlag == "2" && this.containerNum != null && !(this.containerNum.Trim().Equals("")))      // Create Container if it does not exist
            {
                BuildContainer();
            }
            */
            return true;
        }

        private bool PerformLastOperationChecks( )
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
                    errorMessage =  "Whse Details Not Found";
                    return false;
                }

                string physicalInventoryFlag = GetPropertyValue(responseData.PropertyList, responseData.Items, "PhyInvFlg");
                if (physicalInventoryFlag == null)
                {
                    errorMessage =  "Error Reading WhseAll record";
                    return false;
                }

                if (!(physicalInventoryFlag.Equals("0")))
                {
                    IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>
                    {
                        { "{whse}", whse }
                    };
                    //errorMessage =  "Physical Inventory is active in Warehouse : {whse}, Transfer not allowed";
                    errorMessage = constructErrorMessage("Physical Inventory is active in Warehouse : {whse}, Transfer not allowed", "SLMOVXXXXX01", substitutorDictionary);
                    return false;
                }


                //Check From Location
                //responseData = GetLocationDetails(loc);


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
                // CSIB-52576 - Job Revision Number - replacing this with the same one from MoveUpdate.cs, which makes sure to reference/use the specified revision for an item, if present, from the job.
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
                if (itemLotTracked && coProduct!="1")
                {
                    if (lot == null || lot.Trim().Equals(""))
                    {
                        errorMessage =  "Lot Input Mandatory";
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
                    SerialList = this.GetSerialListFromXml();
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

        public bool InsertIntoTable()
        {
            IDORuntime.LogUserMessage("JobMoveUpdate.InsertIntoTable", UserDefinedMessageType.UserDefined1, "Inserting into table...");
            UpdateCollectionRequestData updateCollectionRequest = NewPostingRequest();

            if (coproductResponseData.Items.Count > 0)
            {
                updateCollectionRequest.Items[0].NestedUpdates.Add(NewPostingUpdate_Coproducts());
            }

            if (endItemSerialsResponseData.Items.Count > 0)
            {
                updateCollectionRequest.Items[0].NestedUpdates.Add(NewPostingUpdate_EndItemSerials());
            }

            if (backflushLotsResponseData.Items.Count > 0)
            {
                updateCollectionRequest.Items[0].NestedUpdates.Add(NewPostingUpdate_BackflushLots());
                updateCollectionRequest.Items[0].NestedUpdates.Add(NewPostingUpdate_BackflushLotsSum());
            }

            if (backflushSerialsResponseData.Items.Count > 0)
            {
                updateCollectionRequest.Items[0].NestedUpdates.Add(NewPostingUpdate_BackflushSerials());
                updateCollectionRequest.Items[0].NestedUpdates.Add(NewPostingUpdate_BackflushSerialsSum());
            }

            UpdateCollectionResponseData updateCollectionResponse;
            try
            {
                updateCollectionResponse = this.Context.Commands.UpdateCollection(updateCollectionRequest);
                MessageLogging("MoveUpdate: " + updateCollectionResponse.ToXml(), msgLevel.l1_information, 1200002);
            }
            catch (Exception ee)
            {
                MessageLogging("MoveUpdate: " + ee.Message, msgLevel.l4_error, 1200004);
                errorMessage = ee.Message;
                return false;
            }

            IDORuntime.LogUserMessage("JobMoveUpdate.InsertIntoTable", UserDefinedMessageType.UserDefined1, "Inserting into table...done.");
            return true;
        }

        private UpdateCollectionRequestData NewPostingUpdate_EndItemSerials()
        {
            IDORuntime.LogUserMessage("JobMoveUpdate.NewPostingUpdate_EndItemSerials", UserDefinedMessageType.UserDefined1, "Adding end item serials to the request...");

            UpdateCollectionRequestData update = new UpdateCollectionRequestData
            {
                IDOName = "SLSerials",
                RefreshAfterUpdate = false,
                CollectionID = "SLSerials",
                CustomInsert = "JobtranSerialSaveSp(SerNum,UbSelect,,Item,UbRefPreassignSerials,TrxRestrictCode),BuildSerialSp(TransNum,BYREF MESSAGE,ContainerNum,ManufacturedDate)",
                CustomUpdate = "JobtranSerialSaveSp(SerNum,UbSelect,,Item,UbRefPreassignSerials,TrxRestrictCode),BuildSerialSp(TransNum,BYREF MESSAGE,,ManufacturedDate)",
                LinkBy = new PropertyPair[] { new PropertyPair("TransNum", "TransNum") }
            };

            for (int i = 0; i < endItemSerialsResponseData.Items.Count; i++)
            {
                IDOUpdateItem updateItem = new IDOUpdateItem
                {
                    Action = UpdateAction.Update,
                    ItemNumber = i
                };

                updateItem.Properties.Add("TransNum", "", false);
                updateItem.Properties.Add("UbRefPreassignSerials", "1", false);
                updateItem.Properties.Add("ContainerNum", containerNum, false);
                updateItem.Properties.Add("ManufacturedDate", "", false);
                updateItem.Properties.Add("TrxRestrictCode", "", false);
                updateItem.Properties.Add("UbSelect", "1", false);
                updateItem.Properties.Add("SerNum", endItemSerialsResponseData[i, "SerNum"].ToString(), false);
                updateItem.Properties.Add("Item", jobItem, false);

                update.Items.Add(updateItem);
            }

            IDORuntime.LogUserMessage("JobMoveUpdate.NewPostingUpdate_EndItemSerials", UserDefinedMessageType.UserDefined1, "Adding end item serials to the request...done.");
            return update;
        }

        private UpdateCollectionRequestData NewPostingUpdate_BackflushLots()
        {
            IDORuntime.LogUserMessage("JobMoveUpdate.NewPostingUpdate_BackflushLots", UserDefinedMessageType.UserDefined1, "Adding backflush lots to the request...");
            UpdateCollectionRequestData update = new UpdateCollectionRequestData
            {
                IDOName = "SLLots",
                RefreshAfterUpdate = false,
                CollectionID = "SLBflushLots",
                CustomUpdate = "BflushLotSaveSp(UbTransNum,UbWhse,UbLot,UbSelect,UbJob,UbJobSuffix,UbJobOperNum,UbJobMatlSeq,UbEmpNum,UbItem,UbLoc,UbQtyNeeded,UbQuantity,UbWc,UbUm,UbTransClass,UbTransSeq,BYREF _ItemWarnings,)",
                LinkBy = new PropertyPair[] { new PropertyPair("TransNum", "UbTransNum") }
            };

            for (int i = 0; i < backflushLotsResponseData.Items.Count; i++)
            {
                IDOUpdateItem updateItem = new IDOUpdateItem
                {
                    Action = UpdateAction.Update,
                    ItemNumber = i
                };

                string bfQtyNeeded = backflushLotsResponseData[i, "QtyNeeded"].Value;      // BFReverse.sn
                string bfQtyRequired = backflushLotsResponseData[i, "QtyRequired"].Value;
                
                if (string.IsNullOrEmpty(bfQtyNeeded))
                {
                    bfQtyNeeded = "0";
                }
                if (string.IsNullOrEmpty(bfQtyRequired))
                {
                    bfQtyRequired = "0";
                }

                if (reverserQty == true)
                {
                    bfQtyNeeded = (Convert.ToDecimal(bfQtyNeeded) * -1).ToString();
                    bfQtyRequired = (Convert.ToDecimal(bfQtyRequired) * -1).ToString();
                }                                                                           // BFReverse.en

                updateItem.Properties.Add("UbEmpNum", employee, false);
                updateItem.Properties.Add("UbItem", backflushLotsResponseData[i, "Item"].ToString(), false);
                updateItem.Properties.Add("UbJob", backflushLotsResponseData[i, "Job"].ToString(), false);
                updateItem.Properties.Add("UbJobMatlSeq", backflushLotsResponseData[i, "Sequence"].ToString(), false);
                updateItem.Properties.Add("UbJobOperNum", backflushLotsResponseData[i, "OperNum"].ToString(), false);
                updateItem.Properties.Add("UbJobSuffix", backflushLotsResponseData[i, "Suffix"].ToString(), false);
                updateItem.Properties.Add("UbLoc", backflushLotsResponseData[i, "Loc"].ToString(), false);
                updateItem.Properties.Add("UbLot", backflushLotsResponseData[i, "Lot"].ToString(), false);
                ////updateItem.Properties.Add("UbQtyNeeded", backflushLotsResponseData[i, "QtyNeeded"].ToString(), false); // Ramu.o
                ////updateItem.Properties.Add("UbQuantity", backflushLotsResponseData[i, "QtyRequired"].ToString()); // Ramu.o
                updateItem.Properties.Add("UbQtyNeeded", bfQtyNeeded, false);   // Ramu.n
                updateItem.Properties.Add("UbQuantity", bfQtyRequired); // Ramu.n
                updateItem.Properties.Add("UbSelect", "1");
                updateItem.Properties.Add("UbTransClass", backflushLotsResponseData[i, "TransClass"].ToString(), false);
                updateItem.Properties.Add("UbTransNum", "", false);
                updateItem.Properties.Add("UbTransSeq", "", false);
                updateItem.Properties.Add("UbUm", backflushLotsResponseData[i, "UM"].ToString(), false);
                updateItem.Properties.Add("UbWc", backflushLotsResponseData[i, "Wc"].ToString(), false);
                updateItem.Properties.Add("UbWhse", backflushLotsResponseData[i, "Whse"].ToString(), false);
                updateItem.Properties.Add("_ItemWarnings", "", false);
                //updateItem.Properties.Add("UbItemDescription", "", false); // TODO: Not sure about this one.
                //updateItem.Properties.Add("UbOnHandQty", "", false); // TODO: Not sure about this one.
                //updateItem.Properties.Add("UbLotTrxRestrictCode", "", false); // TODO: Not sure about this one.

                update.Items.Add(updateItem);
            }

            IDORuntime.LogUserMessage("JobMoveUpdate.NewPostingUpdate_BackflushLots", UserDefinedMessageType.UserDefined1, "Adding backflush lots to the request...done.");
            return update;
        }

        private UpdateCollectionRequestData NewPostingUpdate_BackflushLotsSum()
        {
            IDORuntime.LogUserMessage("JobMoveUpdate.NewPostingUpdate_BackflushLotsSum", UserDefinedMessageType.UserDefined1, "Adding backflush lots summary to the request...");

            UpdateCollectionRequestData update = new UpdateCollectionRequestData
            {
                IDOName = "SLLots",
                RefreshAfterUpdate = false,
                CollectionID = "SLBflushLotsSum",
                CustomInsert = "REF"
            };

            // loop through the lots and get a summation of the qty selected based on the
            // criteria: job, job matl seq, suffix. this would be the ubQuantity value,
            // which must sum up to match the qtyneeded value

            int itemNumber = 0;
            for (int i = 0; i < backflushLotsResponseData.Items.Count; i++)
            {
                int entryFound = -1;
                for (int j = 0; j < update.Items.Count; j++)
                {
                    // if the property is found, get its value, otherwise empty string
                    var jobValue = update.Items[j].Properties.IndexOf("UbJob") > -1 ?
                        update.Items[j].Properties[update.Items[j].Properties.IndexOf("UbJob")].Value.ToUpper() : "";
                    var operValue = update.Items[j].Properties.IndexOf("UbJobOperNum") > -1 ?
                        update.Items[j].Properties[update.Items[j].Properties.IndexOf("UbJobOperNum")].Value.ToUpper() : "";
                    var seqValue = update.Items[j].Properties.IndexOf("UbJobMatlSeq") > -1 ?
                        update.Items[j].Properties[update.Items[j].Properties.IndexOf("UbJobMatlSeq")].Value.ToUpper() : "";

                    // if the current entry from the full backflush list matches an update
                    // item, then we'll add to the update item's qty, otherwise, we'll add
                    // a new update item entry
                    if (jobValue.Equals(backflushLotsResponseData[i, "Job"].Value.ToUpper())
                        && operValue.Equals(backflushLotsResponseData[i, "OperNum"].Value.ToUpper())
                        && seqValue.Equals(backflushLotsResponseData[i, "Sequence"].Value.ToUpper()))
                    {
                        entryFound = j;
                        break;
                    }
                }

                string bfQtyNeeded = backflushLotsResponseData[i, "QtyNeeded"].Value;       // BFReverse.sn
                string bfQtyRequired = backflushLotsResponseData[i, "QtyRequired"].Value;
               
                if (string.IsNullOrEmpty(bfQtyNeeded))
                {
                    bfQtyNeeded = "0";
                }
                if (string.IsNullOrEmpty(bfQtyRequired))
                {
                    bfQtyRequired = "0";
                }

                if (reverserQty == true)
                {
                    bfQtyNeeded = (Convert.ToDecimal(bfQtyNeeded) * -1).ToString();
                    bfQtyRequired = (Convert.ToDecimal(bfQtyRequired) * -1).ToString();
                }                                                                           // BFReverse.en

                if (entryFound > -1)
                {

                    // update the existing entry
                    var qtyValue = update.Items[entryFound].Properties[update.Items[entryFound].Properties.IndexOf("UbQuantity")].Value.ToUpper();
                    ////var addValue = backflushLotsResponseData[i, "QtyRequired"].Value; // BFReverse.o
                    var addValue = bfQtyRequired; // BFReverse.n

                    if (float.TryParse(addValue, out float add) && float.TryParse(qtyValue, out float qty))
                    {
                        update.Items[entryFound].Properties[update.Items[entryFound].Properties.IndexOf("UbQuantity")].SetValue((qty + add).ToString("0.00000000"));
                    }
                    else
                    {
                        // TODO: what should we do here?
                    }
                }
                else
                {
                    IDOUpdateItem updateItem = new IDOUpdateItem
                    {
                        Action = UpdateAction.Insert,
                        ItemNumber = itemNumber
                    };

                    updateItem.Properties.Add("InWorkflow", "", false);
                    updateItem.Properties.Add("NoteExistsFlag", "", false);
                    updateItem.Properties.Add("RowPointer", "", false);

                    updateItem.Properties.Add("Item", "", false);
                    updateItem.Properties.Add("Lot", "", false);
                    updateItem.Properties.Add("_ItemWarnings", "", false);
                    updateItem.Properties.Add("UbSelect", "1");
                    updateItem.Properties.Add("UbJob", backflushLotsResponseData[i, "Job"].ToString());
                    updateItem.Properties.Add("UbJobOperNum", backflushLotsResponseData[i, "OperNum"].ToString());
                    updateItem.Properties.Add("UbJobMatlSeq", backflushLotsResponseData[i, "Sequence"].ToString());
                    //updateItem.Properties.Add("UbQtyNeeded", backflushLotsResponseData[i, "QtyNeeded"].ToString()); // BFReverse.o
                    //updateItem.Properties.Add("UbQuantity", backflushLotsResponseData[i, "QtyRequired"].ToString()); // BFReverse.o
                    updateItem.Properties.Add("UbQtyNeeded", bfQtyNeeded); // BFReverse.n
                    updateItem.Properties.Add("UbQuantity", bfQtyRequired);// BFReverse.n
                    update.Items.Add(updateItem);
                    itemNumber++;
                }
            }

            IDORuntime.LogUserMessage("JobMoveUpdate.NewPostingUpdate_BackflushLotsSum", UserDefinedMessageType.UserDefined1, "Adding backflush lots summary to the request...done.");
            return update;
        }

        private UpdateCollectionRequestData NewPostingUpdate_BackflushSerials()
        {
            IDORuntime.LogUserMessage("JobMoveUpdate.NewPostingUpdate_BackflushSerials", UserDefinedMessageType.UserDefined1, "Adding backflush serials to the request...");
            string bfwc = invokeOrderOperResponseData.Parameters.ElementAt(6).ToString();

            UpdateCollectionRequestData update = new UpdateCollectionRequestData
            {
                IDOName = "SLSerials",
                RefreshAfterUpdate = false,
                CollectionID = "SLBflushSerials",
                CustomUpdate = "BflushSerialSaveSp(UbTransNum,UbWhse,UbLot,UbSelect,UbJob,UbJobSuffix,UbJobOperNum,UbJobMatlSeq,UbEmpNum,UbItem,UbLoc,UbQtyNeeded,UbQuantity,UbWc,UbTransClass,UbTransSeq,UbSerNum,)",
                LinkBy = new PropertyPair[] { new PropertyPair("TransNum", "UbTransNum") }
            };

            List<string> materials = new List<string>();
            for (int i = 0; i < backflushSerialsResponseData.Items.Count; i++)
            {
                materials.Add(backflushSerialsResponseData[i, "Sequence"].ToString());
            }
            var materialGroups = materials.GroupBy(i => i);

            for (int i = 0; i < backflushSerialsResponseData.Items.Count; i++)
            {
                IDOUpdateItem updateItem = new IDOUpdateItem
                {
                    Action = UpdateAction.Update,
                    ItemNumber = i
                };

                // this fixed the initial issue with scraps modifying qtys posted... the above might be a better fix though.
                //var qtyToUse = qtyCompleted + qtyScrapped;
                var qtyToUse = string.Empty;
                foreach (var mtlGrp in materialGroups)
                {
                    if (mtlGrp.Key.Equals(backflushSerialsResponseData[i, "Sequence"].ToString()))
                    {
                        qtyToUse = mtlGrp.Count().ToString();
                        if (reverserQty == true)                                        // BFReverse.sn
                        {
                            qtyToUse = (Convert.ToDecimal(qtyToUse) * -1).ToString();
                        }                                                               // BFReverse.en
                        break;
                    }
                }

                updateItem.Properties.Add("UbEmpNum", employee, false);
                updateItem.Properties.Add("UbItem", backflushSerialsResponseData[i, "Item"].ToString(), false);
                updateItem.Properties.Add("UbJob", backflushSerialsResponseData[i, "Job"].ToString(), false);
                updateItem.Properties.Add("UbJobMatlSeq", backflushSerialsResponseData[i, "Sequence"].ToString(), false);
                updateItem.Properties.Add("UbJobOperNum", backflushSerialsResponseData[i, "OperNum"].ToString(), false);
                updateItem.Properties.Add("UbJobSuffix", backflushSerialsResponseData[i, "Suffix"].ToString(), false);
                updateItem.Properties.Add("UbLoc", backflushSerialsResponseData[i, "Loc"].ToString(), false);
                updateItem.Properties.Add("UbLot", backflushSerialsResponseData[i, "Lot"].ToString(), false);
                updateItem.Properties.Add("UbQtyNeeded", qtyToUse.ToString(), false); // was previously backflushSerialsResponseData[i, "QtyRequired"].ToString(), then tried using qtyMoved.ToString("0.00000000") and that didn't work. the correct formula is qtycompleted plus qtyscrapped.
                updateItem.Properties.Add("UbQuantity", qtyToUse.ToString(), false); // TODO: We might have a bug here, since we're passing QtyReq from FT as both Qty and QtyNeeded.... was previously backflushSerialsResponseData[i, "QtyRequired"].ToString()
                updateItem.Properties.Add("UbSerNum", backflushSerialsResponseData[i, "SerNum"].ToString(), false);
                updateItem.Properties.Add("UbTransClass", "J", false);
                updateItem.Properties.Add("UbTransNum", "", false);
                updateItem.Properties.Add("UbTransSeq", "", false);
                updateItem.Properties.Add("UbWhse", whse, false); // Updated to use known values.
                updateItem.Properties.Add("UbWc", bfwc, false);   // Updated to use known values.
                updateItem.Properties.Add("UbSelect", "1");
                updateItem.Properties.Add("UbItemDescription", "", false);      // Not sure about this one.
                updateItem.Properties.Add("UbOnHandQty", "", false);            // Not sure about this one.
                updateItem.Properties.Add("UbSNTrxRestrictCode", "", false);    // Not sure about this one.

                update.Items.Add(updateItem);
            }

            IDORuntime.LogUserMessage("JobMoveUpdate.NewPostingUpdate_BackflushSerials", UserDefinedMessageType.UserDefined1, "Adding backflush serials to the request...done.");
            return update;
        }

        private UpdateCollectionRequestData NewPostingUpdate_BackflushSerialsSum()
        {
            IDORuntime.LogUserMessage("JobMoveUpdate.NewPostingUpdate_BackflushSerialsSummary", UserDefinedMessageType.UserDefined1, "Adding backflush serials summary to the request...");

            UpdateCollectionRequestData update = new UpdateCollectionRequestData
            {
                IDOName = "SLSerials",
                RefreshAfterUpdate = false,
                CollectionID = "SLBflushSerialsSum",
                CustomInsert = "REF"
            };

            // loop through the serials and get a summation of the qty selected based on the
            // criteria: job, job matl seq, oper. this would be the ubQuantity value,
            // which must sum up to match the qtyneeded value

            int itemNumber = 0;
            for (int i = 0; i < backflushSerialsResponseData.Items.Count; i++)
            {
                int entryFound = -1;
                for (int j = 0; j < update.Items.Count; j++)
                {
                    // if the property is found, get its value, otherwise empty string
                    var jobValue = update.Items[j].Properties.IndexOf("UbJob") > -1 ?
                        update.Items[j].Properties[update.Items[j].Properties.IndexOf("UbJob")].Value.ToUpper() : "";
                    var operValue = update.Items[j].Properties.IndexOf("UbJobOperNum") > -1 ?
                        update.Items[j].Properties[update.Items[j].Properties.IndexOf("UbJobOperNum")].Value.ToUpper() : "";
                    var seqValue = update.Items[j].Properties.IndexOf("UbJobMatlSeq") > -1 ?
                        update.Items[j].Properties[update.Items[j].Properties.IndexOf("UbJobMatlSeq")].Value.ToUpper() : "";

                    // if the current entry from the full backflush list matches an update
                    // item, then we'll add to the update item's qty, otherwise, we'll add
                    // a new update item entry
                    if (jobValue.Equals(backflushSerialsResponseData[i, "Job"].Value.ToUpper())
                        && operValue.Equals(backflushSerialsResponseData[i, "OperNum"].Value.ToUpper())
                        && seqValue.Equals(backflushSerialsResponseData[i, "Sequence"].Value.ToUpper()))
                    {
                        entryFound = j;
                        break;
                    }
                }
                
                string bfQtyRequired = backflushSerialsResponseData[i, "QtyRequired"].Value; // BFReverse.sn
                
                if (string.IsNullOrEmpty(bfQtyRequired))
                {
                    bfQtyRequired = "0";
                }

                if (reverserQty == true)
                {
                    //bfQtyNeeded = (Convert.ToDecimal(bfQtyNeeded) * -1).ToString();
                    bfQtyRequired = (Convert.ToDecimal(bfQtyRequired) * -1).ToString();
                }                                                                           // BFReverse.en

                if (entryFound > -1)
                {
                    // update the existing entry
                    var qtyValue = update.Items[entryFound].Properties[update.Items[entryFound].Properties.IndexOf("UbQuantity")].Value.ToUpper();
                    //var addValue = backflushSerialsResponseData[i, "QtyRequired"].Value.ToUpper();// BFReverse.o
                    var addValue = bfQtyRequired; // BFReverse.n

                    if (float.TryParse(addValue, out float add) && float.TryParse(qtyValue, out float qty))
                    { // in the following two lines, the example ubQty had 8 zeros behind it, but example ubQtyNeeded did not.
                        var newQty = qty + add;
                        update.Items[entryFound].Properties[update.Items[entryFound].Properties.IndexOf("UbQuantity")].SetValue((newQty).ToString("0.00000000"));
                        update.Items[entryFound].Properties[update.Items[entryFound].Properties.IndexOf("UbQtyNeeded")].SetValue((newQty)); //  TODO: This might not be needed. I'm just thinking that they should match in the summary, since the summary is based on our selected/filtered list of provided data.
                    }
                    else
                    {
                        // TODO: what should we do here?
                    }
                }
                else
                {
                    IDOUpdateItem updateItem = new IDOUpdateItem
                    {
                        Action = UpdateAction.Insert,
                        ItemNumber = itemNumber
                    };

                    updateItem.Properties.Add("InWorkflow", "", false);
                    updateItem.Properties.Add("NoteExistsFlag", "", false);
                    updateItem.Properties.Add("RowPointer", "", false);

                    updateItem.Properties.Add("SerNum", "", false);
                    updateItem.Properties.Add("Item", "", false);
                    updateItem.Properties.Add("_ItemWarnings", "", false);
                    updateItem.Properties.Add("UbSelect", "1");
                    updateItem.Properties.Add("UbJob", backflushSerialsResponseData[i, "Job"].ToString());
                    updateItem.Properties.Add("UbJobSuffix", "", false);
                    updateItem.Properties.Add("UbJobOperNum", backflushSerialsResponseData[i, "OperNum"].ToString());
                    updateItem.Properties.Add("UbJobMatlSeq", backflushSerialsResponseData[i, "Sequence"].ToString());
                    updateItem.Properties.Add("UbLot", "");
                    ////updateItem.Properties.Add("UbQtyNeeded", backflushSerialsResponseData[i, "QtyRequired"].ToString()); // BFReverse.o // TODO: This could be an issue. Similar issue exists in NewPostingUpdate_BackflushSerials method above.
                    ////updateItem.Properties.Add("UbQuantity", backflushSerialsResponseData[i, "QtyRequired"].ToString());// BFReverse.o

                    updateItem.Properties.Add("UbQtyNeeded", bfQtyRequired); // BFReverse.n
                    updateItem.Properties.Add("UbQuantity", bfQtyRequired);// BFReverse.n
                    update.Items.Add(updateItem);
                    itemNumber++;
                }
            }

            IDORuntime.LogUserMessage("JobMoveUpdate.NewPostingUpdate_BackflushSerialsSummary", UserDefinedMessageType.UserDefined1, "Adding backflush serials summary to the request...done.");
            return update;
        }

        private UpdateCollectionRequestData NewPostingUpdate_Coproducts()
        {
            IDORuntime.LogUserMessage("JobMoveUpdate.NewPostingUpdate_Coproducts", UserDefinedMessageType.UserDefined1, "Adding coproducts to the request...");

            UpdateCollectionRequestData update = new UpdateCollectionRequestData
            {
                IDOName = "SLJobtranitems",
                RefreshAfterUpdate = false,
                CollectionID = "SLJobtranitems",
                CustomInsert = "SaveJobtranitemSp(TransNum,Item,QtyComplete,QtyMoved,QtyScrapped,ReasonCode,NextOper,Loc,Lot)",
                CustomUpdate = "SaveJobtranitemSp(TransNum,Item,QtyComplete,QtyMoved,QtyScrapped,ReasonCode,NextOper,Loc,Lot)",
                LinkBy = new PropertyPair[] { new PropertyPair("TransNum", "TransNum") }
            };

            for (int i = 0; i < coproductResponseData.Items.Count; i++)
            {
                IDOUpdateItem updateItem = new IDOUpdateItem
                {
                    Action = UpdateAction.Insert,
                    ItemNumber = i
                };

                if (string.IsNullOrEmpty(coproductResponseData[i, "loc"].ToString()))
                {
                    updateItem.Properties.Add("Loc", "", false); // add empty, unmodified record
                }
                else
                {
                    updateItem.Properties.Add("Loc", coproductResponseData[i, "loc"].ToString()); // loc is the transaction global value
                }
                updateItem.Properties.Add("Lot", coproductResponseData[i, "lot"].ToString(), false);
                updateItem.Properties.Add("NextOper", coproductResponseData[i, "NextOper"].ToString(), false);
                updateItem.Properties.Add("QtyComplete", coproductResponseData[i, "QtyComplete"].ToString());
                updateItem.Properties.Add("QtyMoved", coproductResponseData[i, "MovedQty"].ToString());
                updateItem.Properties.Add("QtyScrapped", coproductResponseData[i, "QtyScrapped"].ToString(), false);
                updateItem.Properties.Add("ReasonCode", coproductResponseData[i, "Reason"].ToString(), false);
                updateItem.Properties.Add("TransNum", "");
                updateItem.Properties.Add("Item", coproductResponseData[i, "Item"].ToString(), false);
                updateItem.Properties.Add("DerRatio1", coproductResponseData[i, "Ratio"].ToString(), false);
                updateItem.Properties.Add("LotPrefix", "", false);
                updateItem.Properties.Add("ItemUM", coproductResponseData[i, "UM"].ToString(), false);
                updateItem.Properties.Add("ReasonDescription", "", false);
                updateItem.Properties.Add("UbReceiptFlag", "", false); // TODO: try blank, then try with 1
                updateItem.Properties.Add("ItemLotTracked", coproductResponseData[i, "LotTracked"].ToString(), false);

                update.Items.Add(updateItem);
            }

            IDORuntime.LogUserMessage("JobMoveUpdate.NewPostingUpdate_Coproducts", UserDefinedMessageType.UserDefined1, "Adding coproducts to the request...done.");
            return update;
        }

        private UpdateCollectionRequestData NewPostingRequest()
        {
            var thisNextOper = (invokeOrderOperResponseData == null) ? string.Empty : invokeOrderOperResponseData.Parameters.ElementAt(9).ToString();
            // Expanding the following out to one decimal point, if they don't already have a decimal in them.
            var qtyCompletedToUse = qtyCompleted.ToString().Contains(".") ? qtyCompleted.ToString() : qtyCompleted.ToString() + ".0";
            var qtyScrappedToUse = qtyScrapped.ToString().Contains(".") ? qtyScrapped.ToString() : qtyScrapped.ToString() + ".0";
            var qtyMovedToUse = qtyMoved.ToString().Contains(".") ? qtyMoved.ToString() : qtyMoved.ToString() + ".0";

            IDORuntime.LogUserMessage("JobMoveUpdate.InsertIntoTable", UserDefinedMessageType.UserDefined1, "Creating initial posting request transdate [{0}] user initials [{1}] jobitem [{2}]...", transDate, userInitials, jobItem);
            IDORuntime.LogUserMessage("JobMoveUpdate.InsertIntoTable", UserDefinedMessageType.UserDefined1, "Posting details: qtyCompleted [{0}] qtyScrapped [{1}] qtyMoved [{2}] uom [{3}] nextOper [{4}]", qtyCompleted, qtyScrapped, qtyMoved, uom, thisNextOper);
            UpdateCollectionRequestData updateRequestData = new UpdateCollectionRequestData
            {
                IDOName = "SLJobTrans",
                RefreshAfterUpdate = false,
                CollectionID = "",
                CustomInsert = "JobtranPreSaveSp(Job,Suffix,OperNum,MESSAGE),STD,JobtranPostSaveSp(Job,Suffix,OperNum,JobrWc),REF",
                CustomUpdate = "JobtranPreSaveSp(Job,Suffix,OperNum,MESSAGE),STD,JobtranPostSaveSp(Job,Suffix,OperNum,JobrWc),REF",
                CustomDelete = "DeleteJobtranitemSp(TransNum),STD"
            };

            IDOUpdateItem updateItem = new IDOUpdateItem
            {
                Action = UpdateAction.Insert,
                ItemID = "",
                ItemNumber = 1
            };

            updateItem.Properties.Add("InWorkflow", "", false);
            updateItem.Properties.Add("Job", job);
            updateItem.Properties.Add("JobrWc", invokeOrderResponseData.Parameters.ElementAt(21).ToString());
            updateItem.Properties.Add("NoteExistsFlag", "", false);
            updateItem.Properties.Add("OperNum", oper);
            updateItem.Properties.Add("RowPointer", "", false); // TODO: this could come back to bite. we provided blank in our posting, and probably got this value for subsequent pass.
            updateItem.Properties.Add("Suffix", suffix);
            updateItem.Properties.Add("Posted", "0");
            updateItem.Properties.Add("TransNum", "");
            updateItem.Properties.Add("_ItemWarnings", "", false);
            //updateItem.Properties.Add("MOShared", "0");
            //updateItem.Properties.Add("RESID", "");
            //updateItem.Properties.Add("RESDescription", "");
            //updateItem.Properties.Add("UbSheetQtyComplete", "0");
            //updateItem.Properties.Add("UbSheetQtyScrapped", "0");
            //updateItem.Properties.Add("UbSheetQtyMoved", "0");
            //updateItem.Properties.Add("LotTrxRestrictCode", "", false);
            //updateItem.Properties.Add("ParentLot", "", false);
            //updateItem.Properties.Add("ParentSerial", "", false);
            //updateItem.Properties.Add("UbJobProductCycle", "0");
            //updateItem.Properties.Add("UbUseSheetQty", "", false);
            //updateItem.Properties.Add("MOCojob", "0");
            updateItem.Properties.Add("TransType", "M");
            updateItem.Properties.Add("JobItem", jobItem);
            updateItem.Properties.Add("ItemDescription", "");
            updateItem.Properties.Add("WcDescription", "");
            updateItem.Properties.Add("TransDate", transDate);
            updateItem.Properties.Add("UserCode", userInitials);
            //updateItem.Properties.Add("ItemTrackPieces", "0");
            //updateItem.Properties.Add("ItemDimensionGroup", "");
            //updateItem.Properties.Add("DerIsCoProdcutPieceTrackExist", "", false);
            updateItem.Properties.Add("CoProductMix", "0");
            updateItem.Properties.Add("EmpNum", "");
            updateItem.Properties.Add("EmpName", "");
            updateItem.Properties.Add("Shift", "");
            updateItem.Properties.Add("PayRate", "");
            updateItem.Properties.Add("PrRate", "");
            updateItem.Properties.Add("JobRate", "");
            updateItem.Properties.Add("IndCode", "");
            updateItem.Properties.Add("IndcodeDescription", "");
            updateItem.Properties.Add("QtyComplete", qtyCompletedToUse);
            updateItem.Properties.Add("ItemUM", uom);
            updateItem.Properties.Add("QtyScrapped", qtyScrappedToUse);
            updateItem.Properties.Add("QtyMoved", qtyMovedToUse);
            updateItem.Properties.Add("NextOper", thisNextOper);
            updateItem.Properties.Add("XjobrWc", "");
            updateItem.Properties.Add("XwcDescription", "");
            updateItem.Properties.Add("ReasonCode", reasonCode);
            updateItem.Properties.Add("ReasonDescription", GetReasonCodeDesc());
            updateItem.Properties.Add("Loc", loc);
            updateItem.Properties.Add("LocDescription", "");
            updateItem.Properties.Add("DerToContainer", containerInUse);
            //updateItem.Properties.Add("DerEnableContainer", "1");
            //updateItem.Properties.Add("ItemTaxFreeMatl", "0");
            updateItem.Properties.Add("ContainerNum", this.containerNum);
            updateItem.Properties.Add("Lot", lot);
            updateItem.Properties.Add("ItemLotPrefix", "");
            updateItem.Properties.Add("DerOrdNum", "");
            updateItem.Properties.Add("DerOrdLine", "0");
            updateItem.Properties.Add("DerOrdRelease", "0");
            updateItem.Properties.Add("CostCode", ((invokeOrderOperResponseData == null) ? "" : invokeOrderOperResponseData.Parameters.ElementAt(8).ToString()));
            updateItem.Properties.Add("DerStartTimeHrs", "", false);
            updateItem.Properties.Add("DerStartTimeMin", "", false);
            updateItem.Properties.Add("DerEndTimeHrs", "", false);
            updateItem.Properties.Add("DerEndTimeMin", "", false);
            updateItem.Properties.Add("AHrs", "0");
            updateItem.Properties.Add("Whse", whse);
            updateItem.Properties.Add("JobrCntrlPoint", "");
            updateItem.Properties.Add("CompleteOp", GetIDOInputBoolValue(operComplete));
            updateItem.Properties.Add("CloseJob", GetIDOInputBoolValue(closeJob));
            updateItem.Properties.Add("IssueParent", issueToParentFlag);
            //updateItem.Properties.Add("PpjrJobQtyPerSheet", "0.00000000");
            //updateItem.Properties.Add("DerSubJobTiedToProj", "", false);
            //updateItem.Properties.Add("DerXrefToProj", "0");
            //updateItem.Properties.Add("JobQtyPerCycle", "0.00000000");
            //updateItem.Properties.Add("JobPreassignLots", "0");
            //updateItem.Properties.Add("JobPreassignSerials", "1");
            //updateItem.Properties.Add("JobRework", "0");
            updateItem.Properties.Add("JobCoProductMix", "0");
            //updateItem.Properties.Add("UbReceiptFlag", "1", false);
            updateItem.Properties.Add("JobOrdType", "I");
            updateItem.Properties.Add("JobRefJob", "");
            updateItem.Properties.Add("JobJob", "", false);
            //updateItem.Properties.Add("JobRefSuf", "0");
            //updateItem.Properties.Add("JobppreassignLots", "0");
            updateItem.Properties.Add("JobRootJob", job);
            //updateItem.Properties.Add("JobppreassignSerials", "0");
            updateItem.Properties.Add("JobRootSuf", suffix);
            updateItem.Properties.Add("ItemSerialTracked", GetIDOInputBoolValue(itemSerialTracked));
            updateItem.Properties.Add("TransClass", "J");
            updateItem.Properties.Add("ItemLotTracked", GetIDOInputBoolValue(itemLotTracked));
            updateItem.Properties.Add("JobStat", "R");
            updateItem.Properties.Add("UbNewOper", "0");
            updateItem.Properties.Add("JobType", "J");
            updateItem.Properties.Add("UbTargetQty", qtyMovedToUse);
            updateItem.Properties.Add("UbOldEmp", "", false);
            if (itemSerialTracked)
            {
                updateItem.Properties.Add("UbSelectedQty", qtyMovedToUse);
            }
            else
            {
                updateItem.Properties.Add("UbSelectedQty", 0, false);
            }
            updateItem.Properties.Add("DerQtyComplete", "", false);
            updateItem.Properties.Add("UbGenerateQty", "0");
            updateItem.Properties.Add("DerQtyScrapped", "", false);
            updateItem.Properties.Add("DerQtyMoved", "", false);
            updateItem.Properties.Add("UbRangeQty", "0");
            updateItem.Properties.Add("StartTime", "", false);
            updateItem.Properties.Add("EndTime", "", false);
            updateItem.Properties.Add("UbSerialPrefix", "", false);
            //updateItem.Properties.Add("UbSNManufacturedDate", "2021/07/01");
            updateItem.Properties.Add("Wc", invokeOrderOperResponseData.Parameters.ElementAt(6).ToString());
            //updateItem.Properties.Add("UbSNTrxRestrictCode", "", false);
            //updateItem.Properties.Add("UbBflushLotsQtyMatched", "1");
            //updateItem.Properties.Add("UbBflushSerialsQtyMatched", "1");
            //updateItem.Properties.Add("IsJobXrefdToProject", "", false);
            //updateItem.Properties.Add("JobtranitemQtyComplete", "", false);

            updateRequestData.Items.Add(updateItem);

            // if this is a coproduct item, then make some changes to the object.
            if (coproductResponseData.Items.Count > 0)
            {
                updateRequestData.Items[0].SetOrAdd("LotTrxRestrictCode", "");
                updateRequestData.Items[0].SetOrAdd("CoProductMix", "1");
                updateRequestData.Items[0].SetOrAdd("QtyComplete", "");
                updateRequestData.Items[0].SetOrAdd("QtyScrapped", "");
                updateRequestData.Items[0].SetOrAdd("QtyMoved", "");
                updateRequestData.Items[0].SetOrAdd("XwcDescription", "");
                updateRequestData.Items[0].SetOrAdd("ReasonCode", "");
                updateRequestData.Items[0].SetOrAdd("ReasonDescription", "");
                updateRequestData.Items[0].SetOrAdd("DerEnableContainer", "1");
                updateRequestData.Items[0].SetOrAdd("JobCoProductMix", "1");
                updateRequestData.Items[0].SetOrAdd("UbSelectedQty", "", false);
                updateRequestData.Items[0].SetOrAdd("UbGenerateQty", "", false);
                updateRequestData.Items[0].SetOrAdd("Loc", "", false);
            }

            IDORuntime.LogUserMessage("JobMoveUpdate.InsertIntoTable", UserDefinedMessageType.UserDefined1, "Creating initial posting request transdate [{0}] user initials [{1}] jobitem [{2}]...done.", transDate, userInitials, jobItem);

            return updateRequestData;
        }

        public bool InsertScrapIntoMainTable(string scrapQuantity, string scrapReasonCode)
        {
            UpdateCollectionRequestData updateRequestData = new UpdateCollectionRequestData
            {
                IDOName = "SLJobTrans",
                RefreshAfterUpdate = true,
                CustomUpdate = "STD,JobtranPostSaveSp(Job,Suffix,OperNum,JobrWc),REF",
                CustomInsert = "STD,JobtranPostSaveSp(Job,Suffix,OperNum,JobrWc),REF",
                CustomDelete = "DeleteJobtranitemSp(TransNum),STD"
            };

            IDOUpdateItem updateItem = new IDOUpdateItem
            {
                Action = UpdateAction.Insert
            };
            updateItem.Properties.Add("TransNum", "");
            updateItem.Properties.Add("Posted", "0");
            updateItem.Properties.Add("Job", job);
            IDORuntime.LogUserMessage("JobMoveUpdate.InsertIntoMainTable", UserDefinedMessageType.UserDefined1, "Element at 21 {0}", invokeOrderResponseData.Parameters.ElementAt(21));
            updateItem.Properties.Add("JobrWc", invokeOrderResponseData.Parameters.ElementAt(21).ToString());
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
            IDORuntime.LogUserMessage("JobMoveUpdate.InsertIntoMainTable", UserDefinedMessageType.UserDefined1, "Trans date {0}", transDate);
            updateItem.Properties.Add("TransDate", transDate);
            IDORuntime.LogUserMessage("JobMoveUpdate.InsertIntoMainTable", UserDefinedMessageType.UserDefined1, "user initials {0}", userInitials);
            updateItem.Properties.Add("UserCode", userInitials);
            IDORuntime.LogUserMessage("JobMoveUpdate.InsertIntoMainTable", UserDefinedMessageType.UserDefined1, "job item {0}", jobItem);
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
            IDORuntime.LogUserMessage("JobMoveUpdate.InsertIntoMainTable", UserDefinedMessageType.UserDefined1, "Qty comp {0}", qtyCompleted);
            updateItem.Properties.Add("QtyComplete", "0");
            IDORuntime.LogUserMessage("JobMoveUpdate.InsertIntoMainTable", UserDefinedMessageType.UserDefined1, "UOM {0}", uom);
            updateItem.Properties.Add("ItemUM", uom);
            IDORuntime.LogUserMessage("JobMoveUpdate.InsertIntoMainTable", UserDefinedMessageType.UserDefined1, "Scrap {0}", qtyScrapped);
            updateItem.Properties.Add("QtyScrapped", scrapQuantity);
            IDORuntime.LogUserMessage("JobMoveUpdate.InsertIntoMainTable", UserDefinedMessageType.UserDefined1, "moved {0}", qtyMoved);
            updateItem.Properties.Add("QtyMoved", "0");
            IDORuntime.LogUserMessage("JobMoveUpdate.InsertIntoMainTable", UserDefinedMessageType.UserDefined1, "nexet op {0}", invokeOrderOperResponseData.Parameters.ElementAt(9));
            updateItem.Properties.Add("NextOper", ((invokeOrderOperResponseData == null) ? "" : invokeOrderOperResponseData.Parameters.ElementAt(9).ToString()));
            updateItem.Properties.Add("XjobrWc", "");               //can be filled 
            updateItem.Properties.Add("XwcDescription", "");    //can be filled
            updateItem.Properties.Add("ReasonCode", scrapReasonCode);
            updateItem.Properties.Add("ReasonDescription", GetScrapReasonCodeDesc(scrapReasonCode));
            updateItem.Properties.Add("Loc", loc);
            updateItem.Properties.Add("LocDescription", "");
            updateItem.Properties.Add("DerToContainer", containerInUse);
            updateItem.Properties.Add("ContainerNum", "");
            updateItem.Properties.Add("Lot", "");
            updateItem.Properties.Add("DerStartTimeHrs", "", false);
            updateItem.Properties.Add("DerStartTimeMin", "", false);
            updateItem.Properties.Add("DerEndTimeMin", "", false);
            updateItem.Properties.Add("AHrs", "0");
            updateItem.Properties.Add("DerEndTimeHrs", "", false);
            updateItem.Properties.Add("Whse", whse);
            updateItem.Properties.Add("CostCode", ((invokeOrderOperResponseData == null) ? "" : invokeOrderOperResponseData.Parameters.ElementAt(8).ToString()));
            updateItem.Properties.Add("JobrCntrlPoint", "");
            updateItem.Properties.Add("CompleteOp", "0");
            updateItem.Properties.Add("CloseJob", "0");
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
            updateItem.Properties.Add("Wc", invokeOrderOperResponseData.Parameters.ElementAt(6).ToString()); //should be the wc on the operation not the job.  JH:20130228 MSF157944
            updateItem.Properties.Add("CoProductMix", "0");
            updateItem.Properties.Add("UbContainerNum", "");
            IDORuntime.LogUserMessage("JobMoveUpdate.InsertIntoMainTable", UserDefinedMessageType.UserDefined1, "after adding all properties, container Number {0}", this.containerNum);

           

            IDORuntime.LogUserMessage("JobMoveUpdate.InsertIntoMainTable", UserDefinedMessageType.UserDefined1, "completed backflush inventory check, container Number {0}", this.containerNum);

          

            IDORuntime.LogUserMessage("JobMoveUpdate.InsertIntoMainTable", UserDefinedMessageType.UserDefined1, "completed backflush inventory check, container Number {0}", this.containerNum);

            //serials items added


            updateItem.ItemID = "";
            updateItem.ItemNumber = 1;
            updateRequestData.Items.Add(updateItem);
            UpdateCollectionResponseData updateResponseData;
            try
            {
                updateResponseData = this.Context.Commands.UpdateCollection(updateRequestData);
                //IDORuntime.LogUserMessage("JobMoveUpdate.InsertIntoMainTable", UserDefinedMessageType.UserDefined1, "First update return xml {0}", updateRequestData.ToXml());
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
            IDORuntime.LogUserMessage("JobMoveUpdate.InsertIntoMainTable", UserDefinedMessageType.UserDefined1, "Before second update");
            UpdateCollectionRequestData updateRequestDatasecond = new UpdateCollectionRequestData
            {
                IDOName = "SLJobTrans",
                RefreshAfterUpdate = true,
                CustomUpdate = "Null(),REF",
                CustomInsert = "Null(),REF",
                CustomDelete = "Null()"
            };

            updateItem = new IDOUpdateItem
            {
                Action = UpdateAction.Insert
            };

            returnUpdateItem = updateResponseData.Items.ElementAt(0);
            IDORuntime.LogUserMessage("JobMoveUpdate.InsertIntoMainTable", UserDefinedMessageType.UserDefined1, "trans num {0}", returnUpdateItem.Properties.ElementAt(0));
            updateItem.Properties.Add("TransNum", returnUpdateItem.Properties.ElementAt(0).Value);
            updateItem.Properties.Add("Posted", "0");
            updateItem.Properties.Add("Job", job);
            IDORuntime.LogUserMessage("JobMoveUpdate.InsertIntoMainTable", UserDefinedMessageType.UserDefined1, "wc {0}", returnUpdateItem.Properties.ElementAt(21));
            updateItem.Properties.Add("JobrWc", invokeOrderResponseData.Parameters.ElementAt(21).ToString());
            updateItem.Properties.Add("NoteExistsFlag", "0", false);
            updateItem.Properties.Add("OperNum", oper);
            IDORuntime.LogUserMessage("JobMoveUpdate.InsertIntoMainTable", UserDefinedMessageType.UserDefined1, "row pointer {0}", returnUpdateItem.Properties.ElementAt(6));
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
            updateItem.Properties.Add("QtyComplete", "0");
            updateItem.Properties.Add("ItemUM", uom);
            updateItem.Properties.Add("QtyScrapped", scrapQuantity);
            updateItem.Properties.Add("QtyMoved", "0");
            updateItem.Properties.Add("NextOper", ((invokeOrderOperResponseData == null) ? "" : invokeOrderOperResponseData.Parameters.ElementAt(9).ToString()));
            updateItem.Properties.Add("XjobrWc", "");               //can be filled 
            updateItem.Properties.Add("XwcDescription", "");    //can be filled
            updateItem.Properties.Add("ReasonCode", scrapReasonCode);
            updateItem.Properties.Add("ReasonDescription", GetScrapReasonCodeDesc(scrapReasonCode));
            updateItem.Properties.Add("Loc", loc);
            updateItem.Properties.Add("LocDescription", "");
            IDORuntime.LogUserMessage("JobMoveUpdate.InsertIntoMainTable", UserDefinedMessageType.UserDefined1, "container in use {0}", containerInUse);
            updateItem.Properties.Add("DerToContainer", containerInUse);
            IDORuntime.LogUserMessage("JobMoveUpdate.InsertIntoMainTable", UserDefinedMessageType.UserDefined1, "container num {0}", containerNum);
            updateItem.Properties.Add("ContainerNum", "");
            IDORuntime.LogUserMessage("JobMoveUpdate.InsertIntoMainTable", UserDefinedMessageType.UserDefined1, "lot {0}", lot);
            updateItem.Properties.Add("Lot", "");
            updateItem.Properties.Add("DerStartTimeHrs", "", false);
            updateItem.Properties.Add("DerStartTimeMin", "", false);
            updateItem.Properties.Add("DerEndTimeMin", "", false);
            updateItem.Properties.Add("AHrs", "");
            updateItem.Properties.Add("DerEndTimeHrs", "", false);
            updateItem.Properties.Add("Whse", whse);
            updateItem.Properties.Add("CostCode", ((invokeOrderOperResponseData == null) ? "" : invokeOrderOperResponseData.Parameters.ElementAt(8).ToString()));
            updateItem.Properties.Add("JobrCntrlPoint", "");
            IDORuntime.LogUserMessage("JobMoveUpdate.InsertIntoMainTable", UserDefinedMessageType.UserDefined1, "complete op {0}", GetIDOInputBoolValue(operComplete));
            updateItem.Properties.Add("CompleteOp", "0");
            IDORuntime.LogUserMessage("JobMoveUpdate.InsertIntoMainTable", UserDefinedMessageType.UserDefined1, "close job {0}", GetIDOInputBoolValue(closeJob));
            updateItem.Properties.Add("CloseJob", "0");
            // updateItem.Properties.Add("IssueParent", "0");                   // Issue to parent logic added
            IDORuntime.LogUserMessage("JobMoveUpdate.InsertIntoMainTable", UserDefinedMessageType.UserDefined1, "issue to parent {0}", issueToParentFlag);
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
            updateItem.Properties.Add("Wc", invokeOrderOperResponseData.Parameters.ElementAt(6).ToString()); //should be the wc on the operation not the job.  JH:20130228 MSF157944
            updateItem.Properties.Add("CoProductMix", "0");
            updateItem.Properties.Add("UbContainerNum", "");
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
                IDORuntime.LogUserMessage("JobMoveUpdate.InsertIntoMainTable", UserDefinedMessageType.UserDefined1, "error {0}", ee.Message);
                MessageLogging("MoveUpdate: " + ee.Message, msgLevel.l4_error, 1200002);
                //Console.WriteLine(ee.Message);
                errorMessage = ee.Message + " " + returnUpdateItem.Properties.ElementAt(returnUpdateItem.Properties.IndexOf("RowPointer")).Value;
                return false;
            }

            try
            {
                PerformSetIssueParentSp();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            ClearSerailsBySessionID(this.SessionID);

            return true;
        }

        private bool PerformSetIssueParentSp()
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
                errorMessage =  responseData.Parameters.ElementAt(6).ToString() ;
                return false;
            }

            return true;
        }

        public bool DeleteFromMainTable()
        {
            UpdateCollectionRequestData updateRequestData = new UpdateCollectionRequestData
            {
                IDOName = "SLJobTrans",
                RefreshAfterUpdate = true,
                CustomUpdate = "STD,JobtranPostSaveSp(Job,Suffix,OperNum,JobrWc),REF",
                CustomInsert = "STD,JobtranPostSaveSp(Job,Suffix,OperNum,JobrWc),REF",
                CustomDelete = "DeleteJobtranitemSp(TransNum),STD"
            };

            IDOUpdateItem updateItem = new IDOUpdateItem
            {
                Action = UpdateAction.Delete
            };

            IDORuntime.LogUserMessage("MoveUpdate.performJobPosting", UserDefinedMessageType.UserDefined1, "Before LoadCollectionRequest TransNum = " + TransNum);

            LoadCollectionRequestData loadRequestData = new LoadCollectionRequestData
            {
                IDOName = "SLJobTrans",
                Filter = "TransNum='" + TransNum + "'",
                RecordCap = 1
            };
            loadRequestData.PropertyList.SetProperties("RowPointer,RecordDate, TransNum");
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
            //updateItem.ItemID = returnUpdateItem.ItemID;
            updateItem.ItemNumber = 1;
            updateRequestData.Items.Add(updateItem);
            try
            {
                UpdateCollectionResponseData updateResponseData = this.Context.Commands.UpdateCollection(updateRequestData);
                MessageLogging("MoveUpdate: " + updateResponseData.ToXml(), msgLevel.l1_information, 1200002);
                //Console.WriteLine(updateResponseData.ToXml());
            }
            catch (Exception ee)
            {
                MessageLogging("MoveUpdate: " + ee.Message, msgLevel.l4_error, 1200002);
                //Console.WriteLine(ee.Message);
                errorMessage =  ee.Message;
                return false;
            }
            return true;

        }

        private bool ValidateReasonCode()
        {
            reasonValidateResponseData = GetReasonCodeDetails(reasonCode, "MFG SCRAP");
            if (reasonValidateResponseData.Items.Count == 0)
            {
                errorMessage =  "Reason Code Details Not Found";
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
        private string GetScrapReasonCodeDesc(string scrapReasonCode)
        {
            LoadCollectionResponseData  reasonValidateResponseData1 = GetReasonCodeDetails(scrapReasonCode, "MFG SCRAP");
            if (reasonValidateResponseData1.Items.Count == 0)
            {
                return "";
            }
            string desc = GetPropertyValue(reasonValidateResponseData1, "Description");
            if (desc == null)
            {
                return "";
            }
            return desc;

        }
        public InvokeResponseData GetItemByJobSp(string Job, string Suffix)
        {
            object[] inputValues = null;
            int paramcount = GetIDOMethodParameterCount("SLJobTrans", "GetItemByJobSp");
            //Console.WriteLine("SLJobTrans, GetItemByJobSp paramcount = " + paramcount);
            switch (paramcount)
            {
                case 10:

                    inputValues = new object[]{//10
                                                Job,
                                                Suffix,
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                ""
                                                };
                    break;
                case 12:                            //MSF189598  Code update to handle extra parameters being added for SL9.00.20  
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
                                                ""
                                                };
                    break;
                case 14:                            //SL 9.01 related changes Kiran 04-06-2016.n 
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
                    break;
            }
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

            if (!(responseData.ReturnValue.Equals("0")) || !(responseData.Parameters.ElementAt(2).ToString().Equals("")))
            {
                errorMessage =  responseData.Parameters.ElementAt(2).ToString();
                return false;
            }

            inputValues = new object[]{
                                       site,
                                       serial,
                                       jobItem,
                                       "1",
                                       "",
                                       ""
                                       };

            responseData = InvokeIDO("SLDctrans", "ChkSnSp", inputValues);

            if (responseData.ReturnValue.Equals("16"))
            {
                errorMessage =  responseData.Parameters.ElementAt(5).ToString();
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
            // CSIB-52576 - Job Revision Number - replacing this method with the same one from MoveUpdate.cs, which makes sure to reference/use the specified revision for an item, if present.

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
                        UpdateCollectionRequestData updateLotRequestData = new UpdateCollectionRequestData { IDOName = "SLLots", RefreshAfterUpdate = true };
                        IDOUpdateItem updateItem = new IDOUpdateItem { Action = UpdateAction.Update };
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
                        catch (Exception)
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

        private bool AddScrap()
        {
            if (scrapResponseData != null)
            {
                for (int rdindex = 0; rdindex < scrapResponseData.Items.Count; rdindex++)
                {
                    if (InsertScrapIntoMainTable(scrapResponseData[rdindex, "UbQtyScrapped"].Value, scrapResponseData[rdindex, "ReasonCode"].Value) == false)
                    {
                        return false;
                    }

                }
            }
            return true;
        }

        public bool InsertIntoMainTable()
        {
            UpdateCollectionRequestData updateRequestData = new UpdateCollectionRequestData
            {
                IDOName = "SLJobTrans",
                RefreshAfterUpdate = true,
                CustomUpdate = "STD,JobtranPostSaveSp(Job,Suffix,OperNum,JobrWc),REF",
                CustomInsert = "STD,JobtranPostSaveSp(Job,Suffix,OperNum,JobrWc),REF",
                CustomDelete = "DeleteJobtranitemSp(TransNum),STD"
            };

            IDOUpdateItem updateItem = new IDOUpdateItem
            {
                Action = UpdateAction.Insert
            };
            updateItem.Properties.Add("TransNum", "");
            updateItem.Properties.Add("Posted", "0");
            updateItem.Properties.Add("Job", job);
            IDORuntime.LogUserMessage("JobMoveUpdate.InsertIntoMainTable", UserDefinedMessageType.UserDefined1, "Element at 21 {0}", invokeOrderResponseData.Parameters.ElementAt(21));
            updateItem.Properties.Add("JobrWc", invokeOrderResponseData.Parameters.ElementAt(21).ToString());
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
            IDORuntime.LogUserMessage("JobMoveUpdate.InsertIntoMainTable", UserDefinedMessageType.UserDefined1, "Trans date {0}", transDate);
            updateItem.Properties.Add("TransDate", transDate);
            IDORuntime.LogUserMessage("JobMoveUpdate.InsertIntoMainTable", UserDefinedMessageType.UserDefined1, "user initials {0}", userInitials);
            updateItem.Properties.Add("UserCode", userInitials);
            IDORuntime.LogUserMessage("JobMoveUpdate.InsertIntoMainTable", UserDefinedMessageType.UserDefined1, "job item {0}", jobItem);
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
            IDORuntime.LogUserMessage("JobMoveUpdate.InsertIntoMainTable", UserDefinedMessageType.UserDefined1, "Qty comp {0}", qtyCompleted);
            updateItem.Properties.Add("QtyComplete", qtyCompleted);
            IDORuntime.LogUserMessage("JobMoveUpdate.InsertIntoMainTable", UserDefinedMessageType.UserDefined1, "UOM {0}", uom);
            updateItem.Properties.Add("ItemUM", uom);
            IDORuntime.LogUserMessage("JobMoveUpdate.InsertIntoMainTable", UserDefinedMessageType.UserDefined1, "Scrap {0}", qtyScrapped);
            updateItem.Properties.Add("QtyScrapped", qtyScrapped);
            IDORuntime.LogUserMessage("JobMoveUpdate.InsertIntoMainTable", UserDefinedMessageType.UserDefined1, "moved {0}", qtyMoved);
            updateItem.Properties.Add("QtyMoved", qtyMoved);
            IDORuntime.LogUserMessage("JobMoveUpdate.InsertIntoMainTable", UserDefinedMessageType.UserDefined1, "nexet op {0}", invokeOrderOperResponseData.Parameters.ElementAt(9));
            updateItem.Properties.Add("NextOper", ((invokeOrderOperResponseData == null) ? "" : invokeOrderOperResponseData.Parameters.ElementAt(9).ToString()));
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
            updateItem.Properties.Add("Wc", invokeOrderOperResponseData.Parameters.ElementAt(6).ToString()); //should be the wc on the operation not the job.  JH:20130228 MSF157944
            updateItem.Properties.Add("CoProductMix", "0");
            updateItem.Properties.Add("UbContainerNum", this.containerNum);
            IDORuntime.LogUserMessage("JobMoveUpdate.InsertIntoMainTable", UserDefinedMessageType.UserDefined1, "after adding all properties, container Number {0}", this.containerNum);

            //Add inventory records for back flush lot controlled items
            //if (1 == 0)
            ////if (this.itemSerialTracked && (qtyMoved > 0) && this.lastOperation)

            //{
            //    UpdateCollectionRequestData BuckFlushLotsData = new UpdateCollectionRequestData();
            //    BuckFlushLotsData.IDOName = "SLLots";
            //    BuckFlushLotsData.RefreshAfterUpdate = true;
            //    BuckFlushLotsData.CollectionID = "SLBflushLots";
            //    BuckFlushLotsData.CustomUpdate = "BflushLotSaveSp(UbTransNum,UbWhse,UbLot,UbSelect,UbJob,UbJobSuffix,UbJobOperNum,UbJobMatlSeq,UbEmpNum,UbItem,UbLoc,UbQtyNeeded,UbQuantity,UbWc,UbTransClass,UbTransSeq,BYREF _ItemWarnings,)";
            //    BuckFlushLotsData.CustomInsert = "BflushLotSaveSp(UbTransNum,UbWhse,UbLot,UbSelect,UbJob,UbJobSuffix,UbJobOperNum,UbJobMatlSeq,UbEmpNum,UbItem,UbLoc,UbQtyNeeded,UbQuantity,UbWc,UbTransClass,UbTransSeq,BYREF _ItemWarnings,)";

            //    PropertyPair[] propertyPair = new PropertyPair[] { new PropertyPair("TransNum", "UbTransNum") };
            //    BuckFlushLotsData.LinkBy = propertyPair;

            //    if (SessionID != null && SessionID != "")
            //    {
            //        for (int i = 0; i < this.SerialList.Count(); i++)
            //        {
            //            IDOUpdateItem serialItem = new IDOUpdateItem();
            //            serialItem.Action = UpdateAction.Update;
            //            serialItem.ItemNumber = i;
            //            serialItem.Properties.Add("SerNum", formatDataByIDOAndPropertyName("SLMSSerials", "SerNum", SerialList.ElementAt(i).ToString()));
            //            serialItem.Properties.Add("UbSelect", "1");
            //            serialItem.Properties.Add("ContainerNum", "", false);
            //            serialItem.Properties.Add("Item", jobItem);
            //            serialItem.Properties.Add("PreassignSerials", "0");
            //            serialItem.Properties.Add("TransNum", "");
            //            serialItem.Properties.Add("ContainerNum", containerNum);
            //            BuckFlushLotsData.Items.Add(serialItem);

            //        }

            //        updateItem.NestedUpdates.Add(BuckFlushLotsData);
            //    }
            //}


            IDORuntime.LogUserMessage("JobMoveUpdate.InsertIntoMainTable", UserDefinedMessageType.UserDefined1, "completed backflush inventory check, container Number {0}", this.containerNum);

            //Serials are added to this updateItem  - nested update
            if (this.itemSerialTracked && (qtyMoved != 0))
            //if (this.itemSerialTracked && (qtyMoved > 0) && this.lastOperation)     
            {
                UpdateCollectionRequestData serialUpdateRequestData = new UpdateCollectionRequestData
                {
                    IDOName = "SLSerials",
                    RefreshAfterUpdate = true,
                    CollectionID = "SLSerials",
                    CustomUpdate = "JobtranSerialSaveSp(SerNum,UbSelect,,Item,PreassignSerials),BuildSerialSp(TransNum,BYREF MESSAGE)",
                    CustomInsert = "JobtranSerialSaveSp(SerNum,UbSelect,,Item,PreassignSerials),BuildSerialSp(TransNum,BYREF MESSAGE,ContainerNum)"
                };

                PropertyPair[] propertyPair = new PropertyPair[] { new PropertyPair("TransNum", "TransNum") };
                serialUpdateRequestData.LinkBy = propertyPair;

                if (SessionID != null && SessionID != "")
                {
                    double sCount;
                    if (this.SerialList != null && this.SerialList.Count > qtyMoved && this.SerialList.Count > 0)
                    {
                        sCount = qtyMoved;
                    }
                    else
                    {
                        sCount = this.SerialList.Count;
                    }
                    if (sCount < 0) { sCount *= -1; }
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

            IDORuntime.LogUserMessage("JobMoveUpdate.InsertIntoMainTable", UserDefinedMessageType.UserDefined1, "completed backflush inventory check, container Number {0}", this.containerNum);

            //serials items added


            updateItem.ItemID = "";
            updateItem.ItemNumber = 1;
            updateRequestData.Items.Add(updateItem);
            UpdateCollectionResponseData updateResponseData;
            try
            {
                updateResponseData = this.Context.Commands.UpdateCollection(updateRequestData);
                //IDORuntime.LogUserMessage("JobMoveUpdate.InsertIntoMainTable", UserDefinedMessageType.UserDefined1, "First update return xml {0}", updateRequestData.ToXml());
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
            IDORuntime.LogUserMessage("JobMoveUpdate.InsertIntoMainTable", UserDefinedMessageType.UserDefined1, "Before second update");
            UpdateCollectionRequestData updateRequestDatasecond = new UpdateCollectionRequestData
            {
                IDOName = "SLJobTrans",
                RefreshAfterUpdate = true,
                CustomUpdate = "Null(),REF",
                CustomInsert = "Null(),REF",
                CustomDelete = "Null()"
            };

            updateItem = new IDOUpdateItem
            {
                Action = UpdateAction.Insert
            };

            returnUpdateItem = updateResponseData.Items.ElementAt(0);
            IDORuntime.LogUserMessage("JobMoveUpdate.InsertIntoMainTable", UserDefinedMessageType.UserDefined1, "trans num {0}", returnUpdateItem.Properties.ElementAt(0));
            updateItem.Properties.Add("TransNum", returnUpdateItem.Properties.ElementAt(0).Value);
            updateItem.Properties.Add("Posted", "0");
            updateItem.Properties.Add("Job", job);
            IDORuntime.LogUserMessage("JobMoveUpdate.InsertIntoMainTable", UserDefinedMessageType.UserDefined1, "wc {0}", returnUpdateItem.Properties.ElementAt(21));
            updateItem.Properties.Add("JobrWc", invokeOrderResponseData.Parameters.ElementAt(21).ToString());
            updateItem.Properties.Add("NoteExistsFlag", "0", false);
            updateItem.Properties.Add("OperNum", oper);
            IDORuntime.LogUserMessage("JobMoveUpdate.InsertIntoMainTable", UserDefinedMessageType.UserDefined1, "row pointer {0}", returnUpdateItem.Properties.ElementAt(6));
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
            updateItem.Properties.Add("NextOper", ((invokeOrderOperResponseData == null) ? "" : invokeOrderOperResponseData.Parameters.ElementAt(9).ToString()));
            updateItem.Properties.Add("XjobrWc", "");               //can be filled 
            updateItem.Properties.Add("XwcDescription", "");    //can be filled
            updateItem.Properties.Add("ReasonCode", reasonCode);
            updateItem.Properties.Add("ReasonDescription", GetReasonCodeDesc());
            updateItem.Properties.Add("Loc", loc);
            updateItem.Properties.Add("LocDescription", "");
            IDORuntime.LogUserMessage("JobMoveUpdate.InsertIntoMainTable", UserDefinedMessageType.UserDefined1, "container in use {0}", containerInUse);
            updateItem.Properties.Add("DerToContainer", containerInUse);
            IDORuntime.LogUserMessage("JobMoveUpdate.InsertIntoMainTable", UserDefinedMessageType.UserDefined1, "container num {0}", containerNum);
            updateItem.Properties.Add("ContainerNum", this.containerNum);
            IDORuntime.LogUserMessage("JobMoveUpdate.InsertIntoMainTable", UserDefinedMessageType.UserDefined1, "lot {0}", lot);
            updateItem.Properties.Add("Lot", lot);
            updateItem.Properties.Add("DerStartTimeHrs", "", false);
            updateItem.Properties.Add("DerStartTimeMin", "", false);
            updateItem.Properties.Add("DerEndTimeMin", "", false);
            updateItem.Properties.Add("AHrs", "");
            updateItem.Properties.Add("DerEndTimeHrs", "", false);
            updateItem.Properties.Add("Whse", whse);
            updateItem.Properties.Add("CostCode", ((invokeOrderOperResponseData == null) ? "" : invokeOrderOperResponseData.Parameters.ElementAt(8).ToString()));
            updateItem.Properties.Add("JobrCntrlPoint", "");
            IDORuntime.LogUserMessage("JobMoveUpdate.InsertIntoMainTable", UserDefinedMessageType.UserDefined1, "complete op {0}", GetIDOInputBoolValue(operComplete));
            updateItem.Properties.Add("CompleteOp", GetIDOInputBoolValue(operComplete));
            IDORuntime.LogUserMessage("JobMoveUpdate.InsertIntoMainTable", UserDefinedMessageType.UserDefined1, "close job {0}", GetIDOInputBoolValue(closeJob));
            updateItem.Properties.Add("CloseJob", GetIDOInputBoolValue(closeJob));
            // updateItem.Properties.Add("IssueParent", "0");                   // Issue to parent logic added
            IDORuntime.LogUserMessage("JobMoveUpdate.InsertIntoMainTable", UserDefinedMessageType.UserDefined1, "issue to parent {0}", issueToParentFlag);
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
            updateItem.Properties.Add("Wc", invokeOrderOperResponseData.Parameters.ElementAt(6).ToString()); //should be the wc on the operation not the job.  JH:20130228 MSF157944
            updateItem.Properties.Add("CoProductMix", "0");
            updateItem.Properties.Add("UbContainerNum", this.containerNum);
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
                IDORuntime.LogUserMessage("JobMoveUpdate.InsertIntoMainTable", UserDefinedMessageType.UserDefined1, "error {0}", ee.Message);
                MessageLogging("MoveUpdate: " + ee.Message, msgLevel.l4_error, 1200002);
                //Console.WriteLine(ee.Message);
                errorMessage = ee.Message + " " + returnUpdateItem.Properties.ElementAt(returnUpdateItem.Properties.IndexOf("RowPointer")).Value;
                return false;
            }

            TransNum = returnUpdateItem.Properties.ElementAt(0).Value;

            try
            {
                PerformSetIssueParentSp();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            ClearSerailsBySessionID(this.SessionID);

            return true;
        }

        private bool PerformPosting()
        {
            //if a customer reports a error with the number of params for JobJobP see LaborStopDaoImpl.performPosting() JH:20130215
            //  no error has been reported in this class or for previous version of this class and it appears to work.  So no changes were made at this time 
            //  but this has been a significant issue in the past for labor stop.
            int paramcount = GetIDOMethodParameterCount("SLJobTrans", "JobJobP");
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
                                                transDate,
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

        private bool AddBackflushLots()
        {
            for (int rdindex = 0; rdindex < backflushLotsResponseData.Items.Count; rdindex++)
            {
                string bfJob = backflushLotsResponseData[rdindex, "Job"].Value;
                string bfSuffix = backflushLotsResponseData[rdindex, "Suffix"].Value;
                string bfOperNum = backflushLotsResponseData[rdindex, "OperNum"].Value;
                string bfSeq = backflushLotsResponseData[rdindex, "Sequence"].Value;

                string bfItem = backflushLotsResponseData[rdindex, "Item"].Value;
                string bfLoc = backflushLotsResponseData[rdindex, "Loc"].Value;
                string bfLot = backflushLotsResponseData[rdindex, "Lot"].Value;

                string bfQtyNeeded = backflushLotsResponseData[rdindex, "QtyNeeded"].Value;
                string bfQtyRequired = backflushLotsResponseData[rdindex, "QtyRequired"].Value;

                if (string.IsNullOrEmpty(bfQtyNeeded))
                {
                    bfQtyNeeded = "0";
                }
                if (string.IsNullOrEmpty(bfQtyRequired))
                {
                    bfQtyRequired = "0";
                }

                if (reverserQty == true)
                {
                    bfQtyNeeded = (Convert.ToDecimal(bfQtyNeeded) * -1).ToString();
                    bfQtyRequired = (Convert.ToDecimal(bfQtyRequired) * -1).ToString();
                }

                string bfWc = backflushLotsResponseData[rdindex, "Wc"].Value;
                string bfWhse = backflushLotsResponseData[rdindex, "Whse"].Value;
                string bfTransSeq = backflushLotsResponseData[rdindex, "TransSeq"].Value;

                ////bfUM = backflushLotsResponseData[rdindex, "DerItemUM"].Value;
                string bfUM = backflushLotsResponseData[rdindex, "UM"].Value;

                if ( string.IsNullOrEmpty(bfLot.Trim())  || string.IsNullOrEmpty(bfLoc.Trim()) || string.IsNullOrEmpty(bfItem.Trim()))
                {
                    continue;
                }

                object[] inputValues = new object[]{
                                                    TransNum,
                                                    bfWhse,
                                                    bfLot,
                                                    "1",
                                                    bfJob,
                                                    bfSuffix,
                                                    bfOperNum,
                                                    bfSeq,
                                                    employee,
                                                    bfItem,
                                                    bfLoc,
                                                    bfQtyNeeded,
                                                    bfQtyRequired,
                                                    bfWc,
                                                    bfUM,
                                                    "J",
                                                    bfTransSeq,
                                                    "",
                                                    SessionID
                                                    };
                InvokeResponseData responseData = InvokeIDO("SLLots", "BflushLotSaveSp", inputValues);

                if (!(responseData.ReturnValue.Equals("0")) || !(responseData.Parameters.ElementAt(17).ToString().Equals("")))
                {
                    errorMessage = responseData.Parameters.ElementAt(17).ToString();
                    return false;
                }
            }

            return true;
        }

        private bool AddCoproduct()
        {
            for (int rdindex = 0; rdindex < coproductResponseData.Items.Count; rdindex++)
            {
                object[] inputValues = new object[]{
                    TransNum,
                    coproductResponseData[rdindex, "Item"].Value,
                    coproductResponseData[rdindex, "QtyComplete"].Value,
                    coproductResponseData[rdindex, "MovedQty"].Value,
                    coproductResponseData[rdindex, "QtyScrapped"].Value,
                    coproductResponseData[rdindex, "Reason"].Value,
                    coproductResponseData[rdindex, "NextOper"].Value,
                    coproductResponseData[rdindex, "loc"].Value,
                    coproductResponseData[rdindex, "lot"].Value,
                };
                InvokeResponseData responseData = InvokeIDO("SLJobtranitems", "SaveJobtranitemSp", inputValues);

                if (!(responseData.ReturnValue.Equals("0")))
                {
                    errorMessage = "SaveJobtranitemSp failed with return value [" + responseData.ReturnValue.ToString() + "]";
                    return false;
                }
            }
            return true;
        }

        private bool AddBackflushSerials()
        {
            string bfwc = invokeOrderOperResponseData.Parameters.ElementAt(6).ToString();
            for (int rdindex = 0; rdindex < backflushSerialsResponseData.Items.Count; rdindex++)
            {
                string bfTransSeq = backflushSerialsResponseData[rdindex, "TransSeq"].Value;
                string bfSerNum = backflushSerialsResponseData[rdindex, "SerNum"].Value;
                string bfItem = backflushSerialsResponseData[rdindex, "Item"].Value;
                //////bfLoc = backflushSerialsResponseData[rdindex, "DerLoc"].Value;
                string bfLoc = backflushSerialsResponseData[rdindex, "Loc"].Value;
                //////bfLot = backflushSerialsResponseData[rdindex, "DerLot"].Value;
                string bfLot = backflushSerialsResponseData[rdindex, "Lot"].Value;

                string bfSeq = backflushSerialsResponseData[rdindex, "Sequence"].Value;
                string bfQtyRequired = backflushSerialsResponseData[rdindex, "QtyRequired"].Value;

                if (string.IsNullOrEmpty(bfQtyRequired))
                {
                    bfQtyRequired = "0";
                }

                if (reverserQty == true)
                {
                    bfQtyRequired = (Convert.ToDecimal(bfQtyRequired) * -1).ToString();
                }

                object[] inputValues = new object[]{
                                                    TransNum,
                                                    whse,
                                                    bfLot,
                                                    "1",
                                                    job,
                                                    suffix,
                                                    oper,
                                                    bfSeq,
                                                    employee,
                                                    bfItem,
                                                    bfLoc,
                                                    bfQtyRequired,
                                                    bfQtyRequired,
                                                    bfwc,
                                                    "J",
                                                    bfTransSeq,
                                                    bfSerNum,
                                                    ""
                                                    };
                InvokeResponseData responseData = InvokeIDO("SLSerials", "BflushSerialSaveSp", inputValues);

                if (!(responseData.ReturnValue.Equals("0")) || !(responseData.Parameters.ElementAt(17).ToString().Equals("")))
                {
                    errorMessage = responseData.Parameters.ElementAt(17).ToString();
                    return false;
                }
            }
            return true;
        }
        
        #endregion


    }
}
