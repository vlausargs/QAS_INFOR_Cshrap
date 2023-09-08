using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using Mongoose.Core.Configuration;
using Mongoose.IDO.Protocol;
using Mongoose.IDO;
using Mongoose.Core;


namespace InforCollect.ERP.SL.ICSLShopFloorTrans
{

    class CombineLaborAndQty : ShopFloorUtilities
    {
        #region LocalVariables
        public bool lastOperation = false;
        private string transType = "";
        private string employee = "";
        private string reportDate = "";
        private string job = "";
        private string suffix = "0";
        private string oper = "0";
        private string JobWhse = "";
        private string indirectCode = "";
        private string workCenter = "";
        private string shift = "";
        private string startDate = "";  //yyyymmdd      - 20120920
        private string startTime = "";  //HH:MM:SS.mmm  - 10:00:00.000
        private string endDate = "";    //yyyymmdd      - 20120920
        private string endTime = "";    //HH:MM:SS.mmm  - 12:00:00.000
        private string totalTimeInMints = "";                       //this is input
        private double caltotalTimeInHours = 0;
        private string payType = "";    //R - Regular O - Over Time and D - Double Time
        private string username = "";

        public string qtyCompleted = "0";
        public string qtyScrapped = "0";
        public string qtyMoved = "0";
        public string reasonCode = "";         //This will available only if scrapped


        public string userInitials = "";                                                            //12-28-11  - Kiran
        public bool postOffSets = false;
        public bool IsQtyLineExists = false;
        public bool IsPostLabor = false;
        public string deviceId = "";
        public string uom = "";
        public string operComplete = "0";
        public string closeJob = "";
        public string lot = "";
        public string loc = "";
        public string whse = "";
        public string item = "";
        public string site = "";
        public string SessionID = "";
        public string containerNum = "";
        public string NextOper = "";
        public string RESID = "";
        public string issueToParent = "0";
        LoadCollectionResponseData backflushLotsResponseData = new LoadCollectionResponseData();
        LoadCollectionResponseData backflushSerialsResponseData = new LoadCollectionResponseData();

        private List<string> SerialList = null;
        public new InvokeResponseData employeeResponseData = null;
        private LoadCollectionResponseData orderResponseData = null;
        private InvokeResponseData invokeOrderResponseData = null;
        private InvokeResponseData invokeOrderOperResponseData = null;
        private InvokeResponseData payTypeResponseData = null;
        private IDOUpdateItem returnUpdateItem = null;
        private string startTimeInSeconds = "0";
        private string endTimeInSeconds = "0";
        private string errorMessage = "";
        private string errorInfo = "";
        private bool createContainerNum = false;
        private bool containerLocMismatch = false;
        private string jobRevisionNumber = string.Empty;
        #endregion


        public CombineLaborAndQty(string transType, string employee, string reportDate, string job, string suffix,
                                  string oper, string indirectCode, string workCenter, string shift, string startDate,
                                  string startTime, string endDate, string endTime, string totalTimeInMints, double caltotalTimeInHours,
                                  string payType, string username, string qtyCompleted, string qtyMoved, string qtyScrapped,
                                  string reasonCode, string operComplete, string closeJob, string startTimeInSeconds, string endTimeInSeconds, string deviceId,
                                  string whse, string item, string uom, string loc, string lot, string site, string containerNum, string SessionID, string userInitials, bool IsPostLabor, string NextOper,string RESID, string issueToParent, List<string> SerialList, LoadCollectionResponseData backflushLotsResponseData, LoadCollectionResponseData backflushSerialsResponseData)
        {
            Initialize();

            this.transType = transType;
            this.employee = employee;
            this.reportDate = reportDate;
            this.job = job;
            this.suffix = suffix;
            this.oper = oper;
            this.indirectCode = indirectCode;
            this.workCenter = workCenter;
            this.shift = shift;
            this.startDate = startDate;

            this.startTime = startTime;
            this.endDate = endDate;
            this.endTime = endTime;
            this.totalTimeInMints = totalTimeInMints;
            this.caltotalTimeInHours = caltotalTimeInHours;
            this.payType = payType;
            this.username = username;
            this.qtyCompleted = qtyCompleted;
            this.qtyMoved = qtyMoved;
            this.qtyScrapped = qtyScrapped;

            this.reasonCode = reasonCode;
            this.operComplete = operComplete;
            this.closeJob = closeJob;
            this.startTimeInSeconds = startTimeInSeconds;
            this.endTimeInSeconds = endTimeInSeconds;
            this.deviceId = deviceId;
            this.whse = whse;
            this.item = item;
            this.uom = uom;
            this.loc = loc;
            this.lot = lot;
            this.site = site;
            this.containerNum = containerNum;
            this.SessionID = SessionID;
            this.userInitials = userInitials;
            this.IsPostLabor = IsPostLabor;
            this.NextOper = NextOper;
            this.RESID = RESID;
            this.issueToParent = issueToParent;

            this.SerialList = SerialList;
            this.backflushLotsResponseData = backflushLotsResponseData;
            this.backflushSerialsResponseData = backflushSerialsResponseData;
        }

        private void initializeVariables()
        {
            transType = "";
            employee = "";
            reportDate = "";
            job = "";
            suffix = "0";
            oper = "0";
            indirectCode = "";
            workCenter = "";
            shift = "";
            startDate = "";  //yyyymmdd      - 20120920
            startTime = "";  //HH:MM:SS.mmm  - 10:00:00.000
            endDate = "";    //yyyymmdd      - 20120920
            endTime = "";    //HH:MM:SS.mmm  - 12:00:00.000
            totalTimeInMints = "";                       //this is input
            caltotalTimeInHours = 0;
            payType = "";    //R - Regular O - Over Time and D - Double Time
            username = "";

            qtyCompleted = "0";
            qtyScrapped = "0";
            qtyMoved = "0";
            reasonCode = "";         //This will available only if scrapped

            employeeResponseData = null;
            orderResponseData = null;
            invokeOrderOperResponseData = null;
            payTypeResponseData = null;
            returnUpdateItem = null;
            startTimeInSeconds = "0";
            endTimeInSeconds = "0";

            deviceId = "";

            operComplete = "0";
            closeJob = "";
            lot = "";
            loc = "";
            whse = "";
            item = "";
            uom = "";

            site = "";

            SessionID = "";

            containerNum = "";
            userInitials = "";
            NextOper = "";
            RESID = "";
            issueToParent = "0";

            jobRevisionNumber = string.Empty;
        }

        private bool formatInputs()
        {
            job = FormatJobString(job);
            suffix = formatDataByIDOAndPropertyName("SLDcsfcs", "Suffix", suffix);
            employee = formatDataByIDOAndPropertyName("SLEmployees", "EmpNum", employee);
            if (!string.IsNullOrEmpty(containerNum))
             {
                    containerNum = formatDataByIDOAndPropertyName("SLContainers", "ContainerNum", containerNum);
             }
            if (this.transType.Equals("22") || this.transType.Equals("M"))
            {
                if (job == null || job.Trim().Equals(""))
                {
                    errorMessage = "job input mandatory for Transaction Type " + "R";
                    return false;
                }
                if (suffix == null || suffix.Trim().Equals(""))
                {
                    errorMessage = "suffix input mandatory for Transaction Type " + "R";
                    return false;
                }
                if (oper == null || oper.Trim().Equals(""))
                {
                    errorMessage = "operation input mandatory for Transaction Type " + "R";
                    return false;
                }
            }

            if (indirectCode == null || indirectCode.Trim().Equals(""))
            {
                if (this.transType.Equals("21"))
                {
                    errorMessage = "Indirect Code is mandatory for Indirect Transaction Type";
                    return false;
                }
            }

            if (operComplete == null || operComplete.Trim().Equals(""))
            {
                operComplete = "0";
            }

            if (!this.transType.Equals("M"))
            {
                if (shift == null || shift.Trim().Equals(""))
                {
                    errorMessage = "shift input mandatory";
                    return false;
                }

                if (payType == null || payType.Trim().Equals(""))
                {
                    errorMessage = "payType input mandatory";
                    return false;
                }

                if (!(payType.Equals("R") || payType.Equals("O") || payType.Equals("D")))
                {
                    errorMessage = "payType Should be one of R/O/D";
                    return false;
                }
            }
            return true;
        }
        private bool validateInputs()
        {
            if (ValidateEmployee(employee, out errorMessage) == false)
            {
                errorMessage = "Employee Details Not Found";
                return false;
            }


            if (errorMessage != null && !(errorMessage.Trim().Equals("")))
            {
                return false;
            }
            employeeResponseData = JobtranEmpValidSp(employee, payType, reportDate);
            if (errorMessage != null && !(errorMessage.Trim().Equals("")))
            {
                return false;
            }
            if (transType.Equals("22") || transType.Equals("23") || transType.Equals("24"))
            {
                orderResponseData = ValidateJob(job, suffix);
                if (orderResponseData.Items.Count == 0)
                {
                    errorMessage = "Job Details Not Found";
                    return false;
                }
                else
                {
                    JobWhse = orderResponseData[0, "Whse"].ToString();
                    
                }

                jobRevisionNumber = orderResponseData[0, "Revision"].ToString();

                if (orderResponseData[0, "Stat"].ToString().ToUpper() == "F")
                {
                    errorMessage = "Job status is [Firm] Cannot proceed.";
                    return false;
                }
                else if (orderResponseData[0, "Stat"].ToString().ToUpper() == "S")
                {
                    errorMessage = "Job status is [Stopped] Cannot proceed.";
                    return false;
                }
                else if (orderResponseData[0, "Stat"].ToString().ToUpper() == "C")
                {
                    errorMessage = "Job status is [Complete] Cannot proceed.";
                    return false;
                }

                if (ValidateJobOper(job, suffix, oper) == false)
                {
                    return false;
                }

                if (workCenter != null && !(workCenter.Trim().Equals("")))
                {
                    if (ValidateWorkCenter(workCenter) == false)
                    {
                        return false;
                    }
                }

                if (transType.Equals("M"))
                {
                    invokeOrderResponseData = JobtranJobValidSp("M", job, suffix, oper, out errorMessage);
                }
                else
                {
                    invokeOrderResponseData = JobtranJobValidSp("R", job, suffix, oper, out errorMessage);
                }

                if (errorMessage != null && !(errorMessage.Trim().Equals("")))
                {
                    return false;
                }

                if (transType.Equals("M"))
                {
                    invokeOrderOperResponseData = JobtranOperNumValidSp("M", job, suffix, oper, workCenter, out errorMessage);
                }
                else
                {
                    invokeOrderOperResponseData = JobtranOperNumValidSp("R", job, suffix, oper, workCenter, out errorMessage);
                }

                if (errorMessage != null && !(errorMessage.Trim().Equals("")))
                {
                    return false;

                }
                //Container Functionality
                if (this.containerNum != null && !(this.containerNum.Trim().Equals("")))
                {
                    //if (ValidateQtyForRcvIntoContainerSp(this.jobItem, this.whse, this.loc, this.lot, this.site, out errorMessage) == false)
                    //{
                    //    return false;
                    //}
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
                //  Check and create container if it does not exist 
                if (this.createContainerNum == true)
                {
                    PerformCreateContainer(containerNum, whse, loc, out errorMessage);
                }

                if (!transType.Equals("M"))
                {
                    //Shift Field Checks
                    LoadCollectionResponseData responseData = GetShiftDetails(shift);
                    if (responseData.Items.Count == 0)
                    {
                        errorMessage = "Shift Details Not Found";
                        return false;
                    }

                    //Pay Type Field Checks

                    payTypeResponseData = JobtranCalcRateSp(payType, employee, shift, reportDate);
                    if (errorMessage != null && !(errorMessage.Trim().Equals("")))
                    {
                        return false;
                    }

                    //Validate Work Center
                    if (workCenter != null && !(workCenter.Trim().Equals("")))
                    {
                        if (ValidateWorkCenter(workCenter) == false)
                        {
                            errorMessage = "Work Center Details Not Found";
                            return false;
                        }
                    }
                }
               

                //Indirect Task Code Validation
                if (this.transType.Equals("21"))
                {
                    LoadCollectionResponseData indirectResponseData = ValidateIndirectCode(this.indirectCode);
                    if (indirectResponseData.Items.Count == 0)
                    {
                        errorMessage = "Indirect code details not found";
                        return false;
                    }
                }

            }
            // moving the following two calls out of the try/catch so that any errors are not hidden.
            if (PopulateBackflushLotUM() == false)
            {
                return false;
            }
            if (PopulateBackflushSerialLotLoc() == false)
            {
                return false;
            }

            return true;

        }




        public InvokeResponseData JobtranCalcRateSp(string payRate, string employee, string shift, string transDate)
        {
            errorMessage = "";
            object[] inputValues = new object[]{//6+
                                                payRate,
                                                employee,
                                                shift,
                                                transDate,
                                                "",
                                                ""
                                                };
            InvokeResponseData responseData = InvokeIDO("SLJobTrans", "JobtranCalcRateSp", inputValues);
            if (!responseData.ReturnValue.Equals("0"))
            {
                errorMessage = "Failed during execution of JobtranCalcRateSp";
            }
            return responseData;
        }
        public InvokeResponseData JobtranEmpValidSp(string employee, string payType, string transDate)
        {
            object[] inputValues = new object[]{employee,
                                                payType,
                                                transDate,
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                ""};

            InvokeResponseData responseData = InvokeIDO("SLJobTrans", "JobtranEmpValidSp", inputValues);
            if (!responseData.ReturnValue.Equals("0"))
            {
                errorMessage = responseData.Parameters.ElementAt(7).ToString();
            }
            return responseData;
        }
        private bool PerformSerialChecks(string serial)
        {
            object[] inputValues = new object[]{
                                                serial,
                                                item,
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
                                       item,
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


        public int PerformUpdate(out string infobar)
        {
            infobar = "";
            string returnString = "";
             
            // Request request = new RequestParser().parseRequest(inputJobXML);

            //1 initialize
            Initialize();



            if (SessionID != null && !(SessionID.Equals("")) && SerialList == null)
            {
                SerialList = this.GetSerialList(this.SessionID);

            }
            
            if (!performUnpostedJobPosting(out errorInfo))
            {
                infobar = errorInfo;
                return 16;
            }
            if (IsPostLabor)
            {

                if (!performPosting(out errorInfo))
                {
                    string tempErrorMessage = errorInfo;
                    deleteFromMainTable(out returnString);
                    infobar = tempErrorMessage + errorInfo;
                    if (string.IsNullOrEmpty(returnString))
                        infobar = errorInfo;
                    else
                        infobar = returnString;
                    return 16;
                }
            }



            return 0;
        }




        #region Master Records


        private bool deleteDataForMaster(string employee, string[] dataStringArray, out string errorString)
        {
            errorString = "";
            deleteUnProcessedRecords(employee, dataStringArray[1], dataStringArray[3], dataStringArray[2], dataStringArray[4], out errorString);

            return true;
        }

        private bool deleteUnProcessedRecords(string employee, string reportDateStart, string reportDateEnd, string startTime, string endTime, out string errorString)
        {
            errorString = "";

            /*DateTime reportStartDateTime = DateTime.ParseExact(reportDateStart + " " + "0000", "MMddyyyy HHmm", CultureInfo.CurrentCulture);
            DateTime reportEndDateTime = DateTime.ParseExact(reportDateEnd + " " + "0000", "MMddyyyy HHmm", CultureInfo.CurrentCulture);*/

            DateTime reportStartDateTime = DateTime.ParseExact(reportDateStart + " " + startTime, "MMddyyyy HHmm", CultureInfo.CurrentCulture);
            DateTime reportEndDateTime = DateTime.ParseExact(reportDateEnd + " " + endTime, "MMddyyyy HHmm", CultureInfo.CurrentCulture);

            string stInSeconds = reportStartDateTime.TimeOfDay.TotalSeconds.ToString();
            string etInSeconds = reportEndDateTime.TimeOfDay.TotalSeconds.ToString();

            LoadCollectionResponseData responseData1 = null;
            LoadCollectionResponseData responseData2 = null;

            if (reportDateStart.Equals(reportDateEnd))
            {
                LoadCollectionRequestData requestData1 = new LoadCollectionRequestData();
                requestData1.IDOName = "SLJobTrans";
                requestData1.PropertyList.SetProperties("TransNum, RowPointer, RecordDate, EmpNum, TransDate,StartTime, EndTime");
                string filterString = "EmpNum = '" + employee + "' and Posted='0'";
                //filterString += " and TransDate ='" + reportStartDateTime.ToShortDateString() + "' ";
                filterString += " and TransDate ='" + reportStartDateTime.ToString(WMShortDatePattern) + "' "; //MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128
                filterString += " and StartTime >= '" + stInSeconds + "' and EndTime <= '" + etInSeconds + "' ";

                requestData1.Filter = filterString;
                requestData1.RecordCap = -1;
                requestData1.OrderBy = "TransNum";

                responseData1 = this.ExcuteQueryRequest(requestData1);
            }
            else
            {
                //previous day
                LoadCollectionRequestData requestData1 = new LoadCollectionRequestData();
                requestData1.IDOName = "SLJobTrans";
                requestData1.PropertyList.SetProperties("TransNum, RowPointer, RecordDate, EmpNum, TransDate,StartTime, EndTime");
                string filterString = "EmpNum = '" + employee + "' and Posted='0'";
                //filterString += " and TransDate ='" + reportStartDateTime.ToShortDateString() + "' ";
                filterString += " and TransDate ='" + reportStartDateTime.ToString(WMShortDatePattern) + "' "; //MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128
                filterString += " and StartTime >= '" + stInSeconds + "' and EndTime <= '86340' ";

                requestData1.Filter = filterString;
                requestData1.RecordCap = -1;
                requestData1.OrderBy = "TransNum";

                responseData1 = this.ExcuteQueryRequest(requestData1);

                //next day
                LoadCollectionRequestData requestData2 = new LoadCollectionRequestData();
                requestData2.IDOName = "SLJobTrans";
                requestData2.PropertyList.SetProperties("TransNum, RowPointer, RecordDate, EmpNum, TransDate,StartTime, EndTime");
                filterString = "EmpNum = '" + employee + "' and Posted='0'";
                //filterString += " and TransDate ='" + reportEndDateTime.ToShortDateString() + "' ";
                filterString += " and TransDate ='" + reportEndDateTime.ToString(WMShortDatePattern) + "' "; //MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128
                filterString += " and StartTime >= '0' and EndTime <= '" + etInSeconds + "' ";

                requestData2.Filter = filterString;
                requestData2.RecordCap = -1;
                requestData2.OrderBy = "TransNum";

                responseData2 = this.ExcuteQueryRequest(requestData2);
            }


            if (responseData1 == null && responseData2 == null)
            {
                return true;
            }

            UpdateCollectionRequestData updateRequestData = new UpdateCollectionRequestData();
            updateRequestData.IDOName = "SLJobTrans";
            IDOUpdateItem updateItem = null;

            for (int i = 0; i < responseData1.Items.Count; i++)
            {
                updateItem = new IDOUpdateItem();
                updateItem.Action = UpdateAction.Delete;
                updateItem.Properties.Add("RecordDate", responseData1[i, "RecordDate"].ToString());
                updateItem.Properties.Add("RowPointer", responseData1[i, "RowPointer"].ToString());
                updateRequestData.Items.Add(updateItem);
            }

            if (responseData2 != null)
            {
                for (int i = 0; i < responseData2.Items.Count; i++)
                {
                    updateItem = new IDOUpdateItem();
                    updateItem.Action = UpdateAction.Delete;
                    updateItem.Properties.Add("RecordDate", responseData2[i, "RecordDate"].ToString());
                    updateItem.Properties.Add("RowPointer", responseData2[i, "RowPointer"].ToString());
                    updateRequestData.Items.Add(updateItem);
                }
            }

            try
            {
                UpdateCollectionResponseData updateResponeData = this.Context.Commands.UpdateCollection(updateRequestData);
                //Console.WriteLine("delete successful");
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
                errorString = e.Message;
                return false;
            }
            return true;
        }

        #endregion

        #region common private methods

        private string GetDataFromArray(string[] dataArray, int index)
        {
            if (dataArray != null && dataArray.Length > index)
            {
                return dataArray[index];
            }
            return "";
        }

        private bool GetBoolValue(string data)
        {
            if (data != null && data.Trim() != ""
                && (data.ToLower() == "yes" || data == "1" || data.ToLower() == "true"))
            {
                return true;
            }
            return false;
        }




        private bool performUnpostedJobPosting(out string errorString)
        {

            errorString = "";
            if (formatInputs() == false)
            {
                errorString = errorMessage;
                return false;
            }
            //3 validate Inputs
            if (validateInputs() == false)
            {
                errorString = errorMessage;
                return false;
            }
			if (invokeOrderOperResponseData.Parameters.ElementAt(9).ToString().Equals("") || invokeOrderOperResponseData.Parameters.ElementAt(9).ToString().Equals("N/A"))
			{
				lastOperation = true;
			}
			else
			{
				lastOperation = false;
			}
			if (string.IsNullOrEmpty(qtyMoved)) { qtyMoved = "0"; }

            if (lastOperation && Convert.ToDouble(qtyMoved, CultureInfo.InvariantCulture) > 0) // FTDEV-9247
            {
                // Update lot Revision 
                if (!string.IsNullOrEmpty(lot) && !string.IsNullOrWhiteSpace(lot))
                {
                    PerformLotChecks(item, lot, true, qtyMoved, site, "0");

                    if (errorMessage != null && !(errorMessage.Trim().Equals("")))
                    {
                        errorString = errorMessage;
                        return false;
                    }
                }

				if (SerialList != null)
				{
					for (int i = 0; i < SerialList.Count(); i++)
					{

						if (PerformSerialChecks(formatDataByIDOAndPropertyName("SLMSSerials", "SerNum", SerialList.ElementAt(i).ToString())) == false)
						{
							errorString = errorMessage;							
							return false;
						}

					}
				}

			}           
            if (insertIntoMainTableforPostingQtyHours(out errorString) == false)
            {
                errorString = errorMessage;
                return false;

            }




            return true;
        }

        public bool performPosting(out string errorString)
        {
            errorString = "";
            if (JobWhse == "")
            { JobWhse = this.whse; }

            object[] inputValues = new object[]{
                                                "1",
                                                "0",
                                                job,
                                                job,
                                                suffix,
                                                suffix,
                                                reportDate,
                                                reportDate,
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                userInitials,
                                                userInitials,
                                                "H S N",
                                                JobWhse,
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                ""      //new
                                                };
            try
            {
                InvokeResponseData responseData = InvokeIDO("SLJobTrans", "JobJobP", inputValues);
                if (!responseData.ReturnValue.Equals("0"))
                {
                    errorMessage = responseData.Parameters.ElementAt(20).ToString();
                    errorString = errorMessage;
                    IDORuntime.LogUserMessage("CombineLaborAndQty.performPosting", UserDefinedMessageType.UserDefined1, "errorMessage : {0}", errorMessage);
                    return false;
                }
            }
            catch (Exception e)
            {
                IDORuntime.LogUserMessage("CombineLaborAndQty.performPosting", UserDefinedMessageType.UserDefined1, "Exception : {0}", e.Message);
                errorMessage = e.Message.ToString();
                errorString = errorMessage;
                return false;
            }
            return true;

        }

        private bool insertIntoMainTableforPostingQtyHours(out string errorString)
        {
            if (JobWhse == "")
            { JobWhse = this.whse; }
            double sCount = 0;
            double dQtyMoved = 0;
            errorString = "";
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
            updateItem.Properties.Add("JobrWc", workCenter);
            updateItem.Properties.Add("NoteExistsFlag", "", false);
            updateItem.Properties.Add("OperNum", oper);
            updateItem.Properties.Add("RowPointer", "", false);
            updateItem.Properties.Add("Suffix", suffix);
            updateItem.Properties.Add("InWorkflow", "", false);
            updateItem.Properties.Add("_ItemWarnings", "", false);
            updateItem.Properties.Add("DerOrdNum", "");
            updateItem.Properties.Add("DerOrdLine", "0");
            updateItem.Properties.Add("DerOrdRelease", "0");

            //updateItem.Properties.Add("TransType", transactionType);
            if (transType.Equals("22"))
            {
                updateItem.Properties.Add("TransType", "R");
            }
            else if (transType.Equals("23"))
            {
                updateItem.Properties.Add("TransType", "S");
            }
            else if (transType.Equals("24"))
            {
                updateItem.Properties.Add("TransType", "C");
            }
            else
            {
                updateItem.Properties.Add("TransType", "M");
            }

            updateItem.Properties.Add("TransDate", DateTime.ParseExact(this.endDate + " " + this.endTime, "MMddyyyy HHmm", CultureInfo.CurrentCulture) ); // FTDEV-9437 (CSIB-27034) on top of ...FTDEV-9247, FTDEV-9195
            if (userInitials != null && !(userInitials.Trim().Equals("")))                      
            {
                updateItem.Properties.Add("UserCode", userInitials);
            }
            else
            {
                updateItem.Properties.Add("UserCode", "SA");                            // Need to Fix      //12-28-11.en       - Kiran
            }

            updateItem.Properties.Add("JobItem", item);
            updateItem.Properties.Add("ItemDescription", "");
            updateItem.Properties.Add("WcDescription", "");
            if (transType.Equals("M") || transType.Equals("24"))
            {
                updateItem.Properties.Add("EmpNum", "");
                updateItem.Properties.Add("EmpName", "");
                updateItem.Properties.Add("Shift", "");
                updateItem.Properties.Add("PayRate", "");
                updateItem.Properties.Add("PrRate", "");
                updateItem.Properties.Add("JobRate", "");
                updateItem.Properties.Add("IndCode", "");
                updateItem.Properties.Add("IndcodeDescription", "");
            }
            else
            {
                updateItem.Properties.Add("EmpNum", employee);
                updateItem.Properties.Add("EmpName", "");
                updateItem.Properties.Add("Shift", shift);
                updateItem.Properties.Add("PayRate", payType);
                if (payTypeResponseData!=null)
                {
                    updateItem.Properties.Add("PrRate", payTypeResponseData.Parameters.ElementAt(4).ToString());
                    updateItem.Properties.Add("JobRate", payTypeResponseData.Parameters.ElementAt(5).ToString());                    
                }
                else
                {
                    updateItem.Properties.Add("PrRate", "0");
                    updateItem.Properties.Add("JobRate", "0");
                }                
                updateItem.Properties.Add("IndCode", this.indirectCode);
                updateItem.Properties.Add("IndcodeDescription", "");
            }

            updateItem.Properties.Add("QtyComplete", qtyCompleted);
            updateItem.Properties.Add("QtyScrapped", qtyScrapped);
            updateItem.Properties.Add("QtyMoved", qtyMoved);
            updateItem.Properties.Add("ReasonCode", reasonCode);
            updateItem.Properties.Add("Loc", loc);
            updateItem.Properties.Add("LocDescription", "");
            updateItem.Properties.Add("Lot", lot);

            updateItem.Properties.Add("ItemUM", uom);
            if (this.NextOper == "")
            {

                if (invokeOrderOperResponseData == null || (invokeOrderOperResponseData.Parameters.ElementAt(9).ToString().Equals("")))
                {
                    updateItem.Properties.Add("NextOper", "");
                }
                else
                {
                    updateItem.Properties.Add("NextOper", invokeOrderOperResponseData.Parameters.ElementAt(9).ToString());
                }

            }
            else
            {

                updateItem.Properties.Add("NextOper", NextOper);
            }
            updateItem.Properties.Add("RESID", RESID);            
            updateItem.Properties.Add("XjobrWc", "");
            updateItem.Properties.Add("XwcDescription", "");
            updateItem.Properties.Add("ReasonDescription", "");
            updateItem.Properties.Add("ContainerNum", this.containerNum);
            updateItem.Properties.Add("DerStartTimeHrs", "", false);
            // updateItem.Properties.Add("DerStartTimeMin", "");           // MSF 187207  
            updateItem.Properties.Add("DerStartTimeMin", startTime);
            //updateItem.Properties.Add("DerEndTimeMin", "");               // MSF 187207  
            updateItem.Properties.Add("DerEndTimeMin", endTime);
            updateItem.Properties.Add("AHrs", this.caltotalTimeInHours);
            updateItem.Properties.Add("DerEndTimeHrs", "", false);
            updateItem.Properties.Add("Whse", JobWhse);
            updateItem.Properties.Add("CostCode", ((invokeOrderOperResponseData == null) ? "" : invokeOrderOperResponseData.Parameters.ElementAt(8).ToString()));
            updateItem.Properties.Add("JobrCntrlPoint", "");
            updateItem.Properties.Add("CompleteOp", operComplete);
            updateItem.Properties.Add("CloseJob", closeJob);
            updateItem.Properties.Add("IssueParent", issueToParent);
            updateItem.Properties.Add("UbTargetQty", "0");
            updateItem.Properties.Add("UbSelectedQty", "0");

            updateItem.Properties.Add("UbGenerateQty", "0");
            updateItem.Properties.Add("UbRangeQty", "0");
            updateItem.Properties.Add("UbSerialPrefix", "", false);
            updateItem.Properties.Add("JobCoProductMix", "");
            updateItem.Properties.Add("JobOrdType", "I");

            updateItem.Properties.Add("JobJob", "", false);
            updateItem.Properties.Add("JobRefJob", "");
            updateItem.Properties.Add("JobRootJob", job);
            updateItem.Properties.Add("JobRootSuf", suffix);
            updateItem.Properties.Add("ItemSerialTracked", "0");
            updateItem.Properties.Add("TransClass", "J");
            updateItem.Properties.Add("UbNewOper", "0");
            updateItem.Properties.Add("ItemLotTracked", "0");
            updateItem.Properties.Add("JobStat", "F");
            updateItem.Properties.Add("JobType", "E");
            updateItem.Properties.Add("UbOldEmp", "");
            updateItem.Properties.Add("DerQtyComplete", "0");
            updateItem.Properties.Add("DerQtyScrapped", "0");
            updateItem.Properties.Add("DerQtyMoved", "0");

            updateItem.Properties.Add("StartTime", this.startTimeInSeconds);

            updateItem.Properties.Add("EndTime", endTimeInSeconds);
            updateItem.Properties.Add("Wc", workCenter);
            updateItem.Properties.Add("CoProductMix", "");
            updateItem.Properties.Add("UbContainerNum", this.containerNum);
            // Added Properties
            updateItem.Properties.Add("IsJobXrefdToProject", "0");
            updateItem.Properties.Add("IsSubJobTiedToProject", "0");
            updateItem.Properties.Add("JobtranitemQtyComplete", "");
            updateItem.Properties.Add("JobtranitemQtyScrapped", "");
            updateItem.Properties.Add("JobtranitemQtyMoved", "");
            // Ended 
            try
            {
                dQtyMoved = Convert.ToDouble(qtyMoved, CultureInfo.InvariantCulture); // FTDEV-9247
            }
            catch
            {
                dQtyMoved = 0;

            }

            //Serials are added to this updateItem  - nested update
            if (this.SessionID != "" && SerialList.Count > 0 && dQtyMoved > 0)
            {
                UpdateCollectionRequestData serialUpdateRequestData = new UpdateCollectionRequestData();
                serialUpdateRequestData.IDOName = "SLSerials";
                serialUpdateRequestData.RefreshAfterUpdate = true;
                serialUpdateRequestData.CollectionID = "SLSerials";
                //serialUpdateRequestData.CustomUpdate = "JobtranSerialSaveSp(SerNum,UbSelect,,Item,,),BuildSerialSp(TransNum,BYREF MESSAGE)";
                //serialUpdateRequestData.CustomInsert = "JobtranSerialSaveSp(SerNum,UbSelect,,Item,,),BuildSerialSp(TransNum,BYREF MESSAGE,ContainerNum)";
                serialUpdateRequestData.CustomInsert = "JobtranSerialSaveSp(SerNum,UbSelect,,Item,UbRefPreassignSerials,TrxRestrictCode),BuildSerialSp(TransNum,BYREF MESSAGE,ContainerNum,ManufacturedDate)";
                serialUpdateRequestData.CustomUpdate = "JobtranSerialSaveSp(SerNum,UbSelect,,Item,UbRefPreassignSerials,TrxRestrictCode),BuildSerialSp(TransNum,BYREF MESSAGE,,ManufacturedDate)";

                PropertyPair[] propertyPair = new PropertyPair[] { new PropertyPair("TransNum", "TransNum") };
                serialUpdateRequestData.LinkBy = propertyPair;

                if (SessionID != null && SessionID != "")
                {
                    if (this.SerialList != null && this.SerialList.Count > 0)
                    {
                        sCount = dQtyMoved;
                    }
                    else
                    {
                        sCount = this.SerialList.Count;
                    }

                    for (int i = 0; i < sCount; i++)
                    {
                        IDOUpdateItem serialItem = new IDOUpdateItem();
                        serialItem.Action = UpdateAction.Update;
                        serialItem.ItemNumber = i;
                        serialItem.Properties.Add("TransNum", "",false);
                        serialItem.Properties.Add("UbRefPreassignSerials", "1", false);
                        serialItem.Properties.Add("ContainerNum", containerNum, false);
                        serialItem.Properties.Add("ManufacturedDate", "", false);
                        serialItem.Properties.Add("TrxRestrictCode", "", false);
                        serialItem.Properties.Add("SerNum", formatDataByIDOAndPropertyName("SLMSSerials", "SerNum", SerialList.ElementAt(i).ToString()), false);
                        serialItem.Properties.Add("UbSelect", "1", false);
                        //serialItem.Properties.Add("ContainerNum", "", false);
                        serialItem.Properties.Add("Item", item, false);
                        //serialItem.Properties.Add("PreassignSerials", "0");
                        
                        serialUpdateRequestData.Items.Add(serialItem);

                    }
                    updateItem.NestedUpdates.Add(serialUpdateRequestData);

                   
                }
            }
            if (backflushLotsResponseData.Items.Count > 0)
            {
                updateItem.NestedUpdates.Add(NewPostingUpdate_BackflushLots());
                updateItem.NestedUpdates.Add(NewPostingUpdate_BackflushLotsSum());
            }

            if (backflushSerialsResponseData.Items.Count > 0)
            {
                updateItem.NestedUpdates.Add(NewPostingUpdate_BackflushSerials());
                updateItem.NestedUpdates.Add(NewPostingUpdate_BackflushSerialsSum());
            }

            IDORuntime.LogUserMessage("MoveUpdate.insertIntoMainTable", UserDefinedMessageType.UserDefined1, "completed backflush inventory check, container Number {0}", this.containerNum);

            //serials items added


            updateItem.ItemID = "";
            updateItem.ItemNumber = 1;
            updateRequestData.Items.Add(updateItem);
            UpdateCollectionResponseData updateResponseData = null;
            try
            {
                IDORuntime.LogUserMessage("CombineLaborAndQty.insertIntoMainTable", UserDefinedMessageType.UserDefined1, "Request : {0}", updateRequestData.ToXml());
                updateResponseData = this.Context.Commands.UpdateCollection(updateRequestData);               
                MessageLogging("MoveUpdate: " + updateResponseData.ToXml(), msgLevel.l1_information, 1200002);

            }
            catch (Exception ee)
            {
                IDORuntime.LogUserMessage("CombineLaborAndQty.insertIntoMainTable", UserDefinedMessageType.UserDefined1, "Error : {0}", ee.Message);
                MessageLogging("MoveUpdate: " + ee.Message, msgLevel.l4_error, 1200004);
                //Console.WriteLine(ee.Message);
                errorMessage = ee.Message;
                errorString = ee.Message;
                return false;
            }



            //second update
            #region second update

            returnUpdateItem = updateResponseData.Items.ElementAt(0);


            UpdateCollectionRequestData updateRequestDatasecond = new UpdateCollectionRequestData();
            updateRequestDatasecond.IDOName = "SLJobTrans";
            updateRequestDatasecond.RefreshAfterUpdate = true;
            updateRequestDatasecond.CustomUpdate = "Null(),REF";
            updateRequestDatasecond.CustomInsert = "Null(),REF";
            updateRequestDatasecond.CustomDelete = "Null()";

            updateItem = new IDOUpdateItem();
            updateItem.Action = UpdateAction.Insert;


            updateItem.Properties.Add("TransNum", returnUpdateItem.Properties.ElementAt(0).Value);
            updateItem.Properties.Add("Posted", "0");
            updateItem.Properties.Add("Job", job);
            updateItem.Properties.Add("JobrWc", workCenter);
            updateItem.Properties.Add("NoteExistsFlag", "", false);
            updateItem.Properties.Add("OperNum", oper);
            updateItem.Properties.Add("RowPointer", returnUpdateItem.Properties.ElementAt(returnUpdateItem.Properties.IndexOf("RowPointer")).Value);
            updateItem.Properties.Add("Suffix", suffix);
            updateItem.Properties.Add("InWorkflow", "", false);
            updateItem.Properties.Add("_ItemWarnings", "", false);
            updateItem.Properties.Add("DerOrdNum", "");
            updateItem.Properties.Add("DerOrdLine", "0");
            updateItem.Properties.Add("DerOrdRelease", "0");

            if (transType.Equals("21"))
            {
                updateItem.Properties.Add("TransType", "I");
            }
            else if (transType.Equals("22"))
            {
                updateItem.Properties.Add("TransType", "R");
            }
            else
            {
                updateItem.Properties.Add("TransType", "M");
            }

            updateItem.Properties.Add("TransDate", reportDate);
            //updateItem.Properties.Add("UserCode", "SA");
            if (userInitials != null && !(userInitials.Trim().Equals("")))                      //12-28-11.sn       - Kiran
            {
                updateItem.Properties.Add("UserCode", userInitials);
            }
            else
            {
                updateItem.Properties.Add("UserCode", "SA");                            // Need to Fix      //12-28-11.en       - Kiran
            }
            updateItem.Properties.Add("JobItem", item);
            updateItem.Properties.Add("ItemDescription", "");
            updateItem.Properties.Add("WcDescription", "");

            if (transType.Equals("M") || transType.Equals("24"))
            {
                updateItem.Properties.Add("EmpNum", "");
                updateItem.Properties.Add("EmpName", "");
                updateItem.Properties.Add("Shift", "");
                updateItem.Properties.Add("PayRate", "");
                updateItem.Properties.Add("PrRate", "");
                updateItem.Properties.Add("JobRate", "");
                updateItem.Properties.Add("IndCode", "");
                updateItem.Properties.Add("IndcodeDescription", "");
            }
            else
            {
                updateItem.Properties.Add("EmpNum", employee);
                updateItem.Properties.Add("EmpName", "");
                updateItem.Properties.Add("Shift", shift);
                updateItem.Properties.Add("PayRate", payType);
                if (payTypeResponseData != null)
                {
                    updateItem.Properties.Add("PrRate", payTypeResponseData.Parameters.ElementAt(4).ToString());
                    updateItem.Properties.Add("JobRate", payTypeResponseData.Parameters.ElementAt(5).ToString());                    
                }
                else
                {
                    updateItem.Properties.Add("PrRate", "0");
                    updateItem.Properties.Add("JobRate", "0");
                }
                updateItem.Properties.Add("IndCode", this.indirectCode);
                updateItem.Properties.Add("IndcodeDescription", "");
            }


            updateItem.Properties.Add("QtyComplete", qtyCompleted);
            updateItem.Properties.Add("ItemUM", "");
            updateItem.Properties.Add("QtyScrapped", qtyScrapped);
            updateItem.Properties.Add("QtyMoved", qtyMoved);
            //updateItem.Properties.Add("NextOper", "");
            if (this.NextOper == "")
            {

                if (invokeOrderOperResponseData == null || (invokeOrderOperResponseData.Parameters.ElementAt(9).ToString().Equals("")))
                {
                    updateItem.Properties.Add("NextOper", "");
                }
                else
                {
                    updateItem.Properties.Add("NextOper", invokeOrderOperResponseData.Parameters.ElementAt(9).ToString());
                }


            }
            else
            {
                updateItem.Properties.Add("NextOper", NextOper);

            }

            updateItem.Properties.Add("RESID", RESID);
            updateItem.Properties.Add("XjobrWc", "");
            updateItem.Properties.Add("XwcDescription", "");
            updateItem.Properties.Add("ReasonCode", reasonCode);
            updateItem.Properties.Add("ReasonDescription", "");
            updateItem.Properties.Add("Loc", loc);
            updateItem.Properties.Add("LocDescription", "");
            updateItem.Properties.Add("Lot", lot);

            updateItem.Properties.Add("DerStartTimeHrs", "", false);
            // updateItem.Properties.Add("DerStartTimeMin", "");           // MSF 187207  sdommata 11/06/2014
            updateItem.Properties.Add("DerStartTimeMin", startTime);
            updateItem.Properties.Add("DerEndTimeMin", endTime);
            updateItem.Properties.Add("AHrs", caltotalTimeInHours);
            updateItem.Properties.Add("DerEndTimeHrs", "", false);
            updateItem.Properties.Add("Whse", JobWhse);
            updateItem.Properties.Add("CostCode", ((invokeOrderOperResponseData == null) ? "" : invokeOrderOperResponseData.Parameters.ElementAt(8).ToString()));
            updateItem.Properties.Add("JobrCntrlPoint", "0");
            updateItem.Properties.Add("CompleteOp", operComplete);
            updateItem.Properties.Add("CloseJob", closeJob);
            updateItem.Properties.Add("IssueParent", issueToParent);
            updateItem.Properties.Add("UbTargetQty", "0");
            updateItem.Properties.Add("UbSelectedQty", "0");
            updateItem.Properties.Add("UbGenerateQty", "0");
            updateItem.Properties.Add("UbRangeQty", "0");
            updateItem.Properties.Add("UbSerialPrefix", "", false);
            updateItem.Properties.Add("JobCoProductMix", "");
            updateItem.Properties.Add("JobOrdType", "I");

            updateItem.Properties.Add("JobJob", "", false);
            updateItem.Properties.Add("JobRefJob", "");
            updateItem.Properties.Add("JobRootJob", job);
            updateItem.Properties.Add("JobRootSuf", suffix);
            updateItem.Properties.Add("ItemSerialTracked", "0");
            updateItem.Properties.Add("TransClass", "J");
            updateItem.Properties.Add("UbNewOper", "0");
            updateItem.Properties.Add("ItemLotTracked", "0");
            updateItem.Properties.Add("JobStat", "F");
            updateItem.Properties.Add("JobType", "E");
            updateItem.Properties.Add("UbOldEmp", "");
            updateItem.Properties.Add("DerQtyComplete", "0");
            updateItem.Properties.Add("DerQtyScrapped", "0");
            updateItem.Properties.Add("DerQtyMoved", "0");

            updateItem.Properties.Add("StartTime", startTimeInSeconds);

            updateItem.Properties.Add("EndTime", endTimeInSeconds);
            updateItem.Properties.Add("Wc", workCenter);
            updateItem.Properties.Add("CoProductMix", "");
            // Added Properties
            updateItem.Properties.Add("IsJobXrefdToProject", "0");
            updateItem.Properties.Add("IsSubJobTiedToProject", "0");
            updateItem.Properties.Add("JobtranitemQtyComplete", "");
            updateItem.Properties.Add("JobtranitemQtyScrapped", "");
            updateItem.Properties.Add("JobtranitemQtyMoved", "");
            // Ended 

            updateItem.ItemID = returnUpdateItem.ItemID;
            updateItem.ItemNumber = 1;
            updateRequestDatasecond.Items.Add(updateItem);
            updateResponseData = null;
            try
            {
                updateResponseData = this.Context.Commands.UpdateCollection(updateRequestDatasecond);
                //Console.WriteLine(updateResponseData.ToXml());
            }
            catch (Exception ee)
            {
               //Console.WriteLine(ee.Message);
                errorString = ee.Message;
                return false;
            }

            try
            {

                ClearSerailsBySessionID(this.SessionID);
            }
            catch (Exception)
            {
            }

            #endregion

            return true;

        }

        public bool deleteFromMainTable(out string errorString)
        {
            errorString = "";

            UpdateCollectionRequestData updateRequestData = new UpdateCollectionRequestData();
            updateRequestData.IDOName = "SLJobTrans";
            updateRequestData.RefreshAfterUpdate = true;
            updateRequestData.CustomUpdate = "STD,JobtranPostSaveSp(Job,Suffix,OperNum,JobrWc),REF";
            updateRequestData.CustomInsert = "STD,JobtranPostSaveSp(Job,Suffix,OperNum,JobrWc),REF";
            updateRequestData.CustomDelete = "DeleteJobtranitemSp(TransNum),STD";

            IDOUpdateItem updateItem = new IDOUpdateItem();
            updateItem.Action = UpdateAction.Delete;

            updateItem.Properties.Add("TransNum", returnUpdateItem.Properties.ElementAt(0).Value);
            updateItem.Properties.Add("Posted", "0");
            updateItem.Properties.Add("Job", job);
            updateItem.Properties.Add("JobrWc", workCenter);
            updateItem.Properties.Add("NoteExistsFlag", "0", false);
            updateItem.Properties.Add("OperNum", oper);
            updateItem.Properties.Add("RowPointer", returnUpdateItem.Properties.ElementAt(7).Value);
            updateItem.Properties.Add("Suffix", suffix);
            updateItem.Properties.Add("InWorkflow", "", false);
            updateItem.Properties.Add("_ItemWarnings", "", false);
            updateItem.Properties.Add("DerOrdNum", "");
            updateItem.Properties.Add("DerOrdLine", "0");
            updateItem.Properties.Add("DerOrdRelease", "0");

            updateItem.Properties.Add("TransType", "M");
            updateItem.Properties.Add("TransDate", reportDate);
            if (userInitials != null && !(userInitials.Trim().Equals("")))                      //12-28-11.sn       - Kiran
            {
                updateItem.Properties.Add("UserCode", userInitials);
            }
            else
            {
                updateItem.Properties.Add("UserCode", "SA");                            // Need to Fix      //12-28-11.en       - Kiran
            }
            updateItem.Properties.Add("JobItem", "");
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
            updateItem.Properties.Add("ItemUM", "");
            updateItem.Properties.Add("QtyScrapped", qtyScrapped);
            updateItem.Properties.Add("QtyMoved", qtyMoved);
            updateItem.Properties.Add("NextOper", ((invokeOrderOperResponseData == null) ? "" : invokeOrderOperResponseData.Parameters.ElementAt(8).ToString()));
            updateItem.Properties.Add("RESID", RESID);               //can be filled             
            updateItem.Properties.Add("XjobrWc", "");               //can be filled 
            updateItem.Properties.Add("XwcDescription", "");    //can be filled
            updateItem.Properties.Add("ReasonCode", reasonCode);
            updateItem.Properties.Add("ReasonDescription", "");
            updateItem.Properties.Add("ContainerNum", this.containerNum);
            updateItem.Properties.Add("Loc", "");
            updateItem.Properties.Add("LocDescription", "");
            updateItem.Properties.Add("Lot", "");

            updateItem.Properties.Add("DerStartTimeHrs", "", false);
            updateItem.Properties.Add("DerStartTimeMin", "", false);
            updateItem.Properties.Add("DerEndTimeMin", "", false);
            updateItem.Properties.Add("AHrs", "");
            updateItem.Properties.Add("DerEndTimeHrs", "", false);
            updateItem.Properties.Add("Whse", JobWhse);
            updateItem.Properties.Add("CostCode", ((invokeOrderOperResponseData == null) ? "" : invokeOrderOperResponseData.Parameters.ElementAt(8).ToString()));
            updateItem.Properties.Add("JobrCntrlPoint", "need to be filled");
            updateItem.Properties.Add("CompleteOp", "0");
            updateItem.Properties.Add("CloseJob", "0");
            updateItem.Properties.Add("IssueParent", "0");
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
            updateItem.Properties.Add("ItemSerialTracked", "0");
            updateItem.Properties.Add("TransClass", "J");
            updateItem.Properties.Add("UbNewOper", "0");
            updateItem.Properties.Add("ItemLotTracked", 0);
            updateItem.Properties.Add("JobStat", "F");      //not sure
            updateItem.Properties.Add("JobType", "E");      //not sure
            updateItem.Properties.Add("UbOldEmp", "");
            updateItem.Properties.Add("DerQtyComplete", "0");
            updateItem.Properties.Add("DerQtyScrapped", "0");
            updateItem.Properties.Add("DerQtyMoved", "0");

            updateItem.Properties.Add("StartTime", "", false);

            updateItem.Properties.Add("EndTime", "", false);
            updateItem.Properties.Add("Wc", invokeOrderResponseData.Parameters.ElementAt(21).ToString());
            updateItem.Properties.Add("CoProductMix", "0");
            // Added Properties
            updateItem.Properties.Add("IsJobXrefdToProject", "0");
            updateItem.Properties.Add("IsSubJobTiedToProject", "0");
            updateItem.Properties.Add("JobtranitemQtyComplete", "");
            updateItem.Properties.Add("JobtranitemQtyScrapped", "");
            updateItem.Properties.Add("JobtranitemQtyMoved", "");
            // Ended 

            updateItem.ItemID = returnUpdateItem.ItemID;
            updateItem.ItemNumber = 1;
            updateRequestData.Items.Add(updateItem);
            UpdateCollectionResponseData updateResponseData = null;
            try
            {
                updateResponseData = this.Context.Commands.UpdateCollection(updateRequestData);
                //Console.WriteLine(updateResponseData.ToXml());
            }
            catch (Exception ee)
            {
                //Console.WriteLine(ee.Message);
                errorMessage = ee.Message;
                errorString = ee.Message;
                return false;
            }
            return true;

        }

        #endregion

        #region New Code for Hours line




        private bool ParseAndValidateHoursLine(string inputLine, out string errorString)
        {
            errorString = "";
            initializeVariables();
            string[] inputLineArray = inputLine.Split(new char[] { '|' });
            string identifierString = inputLineArray[0];
            string dataString = inputLineArray[1];
            string[] dataStringArray = dataString.Split(new char[] { '~' });
            string[] identifierStringArray = identifierString.Split(new char[] { '~' });

            //assign values
            employee = identifierStringArray[1];

            transType = dataStringArray[0];
            job = dataStringArray[1];
            suffix = dataStringArray[2];
            if (suffix.Trim().Equals(""))
            {
                suffix = "0";
            }
            oper = dataStringArray[3];
            if (oper.Trim().Equals(""))
            {
                oper = "0";
            }
            workCenter = dataStringArray[4];
            indirectCode = dataStringArray[6];
            shift = dataStringArray[7];
            payType = dataStringArray[8];
            startDate = dataStringArray[9];
            reportDate = startDate;
            DateTime reportDateTime = DateTime.ParseExact(reportDate + " " + "0000", "MMddyyyy HHmm", CultureInfo.CurrentCulture);
            reportDate = reportDateTime.ToString("yyyy/MM/dd");

            startTime = dataStringArray[10];
            endDate = dataStringArray[11];
            endTime = dataStringArray[12];
            totalTimeInMints = dataStringArray[13];
            caltotalTimeInHours = Convert.ToDouble(totalTimeInMints, CultureInfo.InvariantCulture) / 60; // FTDEV-9247
            username = dataStringArray[15];

            DateTime startDateTime = DateTime.ParseExact(this.startDate + " " + this.startTime, "MMddyyyy HHmm", CultureInfo.CurrentCulture);
            DateTime endDateTime = DateTime.ParseExact(this.endDate + " " + this.endTime, "MMddyyyy HHmm", CultureInfo.CurrentCulture);
            startTimeInSeconds = startDateTime.TimeOfDay.TotalSeconds.ToString();
            endTimeInSeconds = endDateTime.TimeOfDay.TotalSeconds.ToString();

            if (formatInputs() == false)
            {
                errorString = errorMessage;
                return false;
            }

            //AddToPostJob(employee, transType, job, suffix, oper, indirectCode, workCenter, startTimeInSeconds, endTimeInSeconds, caltotalTimeInHours.ToString("0.00000000"), payType);

            return true;
        }

        private bool ParseAndValidateMasterLine(string inputLine, out string errorString)
        {
            errorString = "";
            string[] inputLineArray = inputLine.Split(new char[] { '|' });
            string dataString = inputLineArray[1];
            string[] dataStringArray = dataString.Split(new char[] { '~' });
            string employee = dataStringArray[0];


            employee = formatDataByIDOAndPropertyName("SLEmployees", "EmpNum", employee);

            if (ValidateEmployee(employee, out errorMessage) == false)
            {
                errorString = "Employee Details Not Found";
                return false;
            }

            return true;
        }

        /*
         * Validates the Master and Hours line. Additonally converts the Hours lines to JobInfo(struct) objects and adds to a list
         */

        private string GetErrorStringFromErrorMessage(string errorMessage)
        {
            if (errorMessage.IndexOf("<error>") != -1)
            {
                return errorMessage.Substring(errorMessage.IndexOf("<error>") + 7, (errorMessage.IndexOf("</error>") - (errorMessage.IndexOf("<error>") + 7)));
            }
            else
            {
                return errorMessage;
            }

        }

        #endregion

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

            for (int i = 0; i < SerialList.Count; i++)
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
                updateItem.Properties.Add("SerNum", SerialList[i], false);
                updateItem.Properties.Add("Item", item, false);

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
                updateItem.Properties.Add("UbTransClass", "J", false);
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
    }
}
