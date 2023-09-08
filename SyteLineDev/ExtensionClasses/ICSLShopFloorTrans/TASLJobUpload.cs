using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mongoose.Core.Configuration;
using Mongoose.IDO.Protocol;
using Mongoose.IDO;
using Mongoose.Core;
using System.Globalization;
using System.Xml;

namespace InforCollect.ERP.SL.ICSLShopFloorTrans
{
    class TASLJobUpload : ShopFloorUtilities
    {
        //Inputs
        private string inputJobXML = "";

        #region LocalVariables

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
        private string PartnerId = "";
        private string SROLine = "";
        private string WorkCode = "";
        private string BillCode = "";
        private string BillHours = "";

        public string qtyCompleted = "0";
        public string qtyScrapped = "0";
        public string qtyMoved = "0";
        public string reasonCode = "";         //This will available only if scrapped
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
        public string userInitials = "";                                                            //12-28-11  - Kiran
        public bool postOffSets = false;
        public bool IsQtyLineExists = false;
        public bool IsPostLabor = false;
        public bool StopPostJobs = false;
        public string issueToParent = "0";
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

        private struct JobInfo
        {
            public bool markedToPost;
            public string employee;
            public string transType;
            public string job;
            public string suffix;
            public string operation;
            public string task;
            public string workcenter;
            public string startTime;
            public string endTime;
            public string laborHrs;
            public string payType;
        } List<JobInfo> toPostJobList;
        #endregion


        public TASLJobUpload(string inputJobXML)
        {
            initialize();
            this.inputJobXML = inputJobXML;
            toPostJobList = new List<JobInfo>();
        }

        public void initialize()
        {
            base.Initialize();
            
            toPostJobList = new List<JobInfo>();
        }

        private bool formatInputs()
        {
            job = FormatJobString(job);
            suffix = formatDataByIDOAndPropertyName("SLDcsfcs", "Suffix", suffix);
            employee = formatDataByIDOAndPropertyName("SLEmployees", "EmpNum", employee);

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

            employeeResponseData = JobtranEmpValidSp(employee, payType, reportDate);
            if (errorMessage != null && !(errorMessage.Trim().Equals("")))
            {
                return false;
            }

            if (transType.Equals("22") || transType.Equals("M"))
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


        public int PerformUpdate(out string infobar)
        {
            infobar = "";
            string returnString = "";

            Request request = new RequestParser().parseRequest(inputJobXML);

            //1 initialize
            initialize();

            if (PreProcessRequest(request, out returnString))
            {
                if (this.toPostJobList != null)
                {
                    //Console.WriteLine("Hours row count:: " + this.toPostJobList.Count);
                }

                if (!processRequest(request, out infobar))
                {
                    infobar = errorInfo;
                    return 16;
                }
                if (!processQtyRequest(request, out infobar))
                {
                    infobar = errorInfo;
                    return 16;
                }
            }
            else
            {
                infobar = errorMessage;
                return 16;
            }

            return 0;
        }

        private bool processRequest(Request updateRequest, out string returnString)
        {
            bool noError = true;
            userInitials = updateRequest.GetFieldValue("userInitials");
            postOffSets = updateRequest.GetBoolFieldValue("postOffSets");
            errorInfo = "";
            returnString = "<Response><Output>";
            string errorString = "";
            bool skipHoursLine = false;
            List<Field> inputFieldsList = updateRequest.InputFieldsList;
            foreach (Field field in inputFieldsList)
            {
                errorString = "";
                returnString += "<fieldValueList><name>" + field.Name + "</name><value>" + field.Value + "</value>";
                if (field.Name.StartsWith("MASTER"))
                {
                    skipHoursLine = false;
                    userInitials = updateRequest.GetFieldValue("userInitials");
                    if (PerformMasterChecks(field.Value, out errorString) == false)
                    {
                        errorString = errorString.Replace("\n", "");
                        errorString = errorString.Replace("\r", "");
                        returnString += "<errorInfo>" + errorString + "</errorInfo>";
                        errorMessage = errorString;
                        errorInfo = errorString;
                        skipHoursLine = true;
                        noError = false;
                    }

                }
                else if (field.Name.StartsWith("Hours"))
                {
                    if (skipHoursLine == false)
                    {
                        userInitials = updateRequest.GetFieldValue("userInitials");
                        if (PerformHoursSteps(field.Value, out errorString) == false)
                        {
                            errorString = errorString.Replace("\n", "");
                            errorString = errorString.Replace("\r", "");
                            returnString += "<errorInfo>" + errorString + "</errorInfo>";
                            errorMessage = errorString;
                            errorInfo = errorString;
                            noError = false;
                        }
                    }
                }
                /*else if (field.Name.StartsWith("QTY"))
                {
                    if (PerformQtySteps(field.Value, out errorString) == false)
                    {
                        errorString = errorString.Replace("\n", "");
                        errorString = errorString.Replace("\r", "");
                        returnString += "<errorInfo>" + errorString + "</errorInfo>";
                        errorMessage = errorString;
                        errorInfo = errorString;
                        noError = false;
                    }
                }*/
                returnString += "</fieldValueList>";
            }
            returnString += "</Output></Response>";
            return noError;
        }

        private bool processQtyRequest(Request updateRequest, out string returnString)
        {
            bool noError = true;
            userInitials = updateRequest.GetFieldValue("userInitials");
            postOffSets = updateRequest.GetBoolFieldValue("postOffSets");
            errorInfo = "";
            returnString = "<Response><Output>";
            string errorString = "";
            //bool skipHoursLine = false;
            List<Field> inputFieldsList = updateRequest.InputFieldsList;
            foreach (Field field in inputFieldsList)
            {
                errorString = "";
                returnString += "<fieldValueList><name>" + field.Name + "</name><value>" + field.Value + "</value>";
                if (field.Name.StartsWith("MASTER"))
                {
                    //skipHoursLine = false;
                    userInitials = updateRequest.GetFieldValue("userInitials");
                    if (PerformMasterChecks(field.Value, out errorString) == false)
                    {
                        errorString = errorString.Replace("\n", "");
                        errorString = errorString.Replace("\r", "");
                        returnString += "<errorInfo>" + errorString + "</errorInfo>";
                        errorMessage = errorString;
                        errorInfo = errorString;
                        //skipHoursLine = true;
                        noError = false;
                    }

                }
                /*else if (field.Name.StartsWith("Hours"))
                {
                    if (skipHoursLine == false)
                    {
                        userInitials = updateRequest.GetFieldValue("userInitials");
                        if (PerformHoursSteps(field.Value, out errorString) == false)
                        {
                            errorString = errorString.Replace("\n", "");
                            errorString = errorString.Replace("\r", "");
                            returnString += "<errorInfo>" + errorString + "</errorInfo>";
                            errorMessage = errorString;
                            errorInfo = errorString;
                            noError = false;
                        }
                    }
                }*/
                else if (field.Name.StartsWith("QTY"))
                {
                    if (PerformQtySteps(field.Value, out errorString) == false)
                    {
                        errorString = errorString.Replace("\n", "");
                        errorString = errorString.Replace("\r", "");
                        returnString += "<errorInfo>" + errorString + "</errorInfo>";
                        errorMessage = errorString;
                        errorInfo = errorString;
                        noError = false;
                    }
                }
                returnString += "</fieldValueList>";
            }
            returnString += "</Output></Response>";
            return noError;
        }

        #region Master Records
        private bool PerformMasterChecks(string inputLine, out string errorString)
        {
            errorString = "";
            string[] inputLineArray = inputLine.Split(new char[] { '|' });
            string dataString = inputLineArray[1];
            string[] dataStringArray = dataString.Split(new char[] { '~' });
            string employee = dataStringArray[0];


            employee = formatDataByIDOAndPropertyName("SLEmployees", "EmpNum", employee);

            deleteDataForMaster(employee, dataStringArray, out errorString);
            return true;
        }

        private bool deleteDataForMaster(string employee, string[] dataStringArray, out string errorString)
        {
            errorString = "";
            deleteUnProcessedRecords(employee, dataStringArray[1], dataStringArray[3], dataStringArray[2], dataStringArray[4], out errorString);
            //if (postOffSets)
            //{
                offsetPostedRecords(employee, dataStringArray[1], dataStringArray[3], dataStringArray[2], dataStringArray[4], out errorString, postOffSets);
            //}
            return true;
        }

        private bool offsetPostedRecords(string employeeInput, string reportDateStart, string reportDateEnd, string startTime, string endTime, out string errorString,bool postOffSets)
        {
            //Console.WriteLine("In offset posting");
            errorString = "";

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
                requestData1.PropertyList.SetProperties("TransNum, RowPointer, RecordDate, EmpNum, TransDate, Job, Suffix, OperNum, IndCode,TransType,UserCode, Shift, Pay, PayRate,PrRate,JobRate, AHrs,StartTime, EndTime, Wc");
                string filterString = "EmpNum = '" + employeeInput + "' and Posted='1'";
                filterString += " and TransDate ='" + reportStartDateTime.ToString(WMShortDatePattern) + "' "; //MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128
                filterString += " and StartTime >= '" + stInSeconds + "' and EndTime <= '" + etInSeconds + "' ";

                requestData1.Filter = filterString;
                requestData1.RecordCap = -1;
                requestData1.OrderBy = "TransNum";

                responseData1 = ExcuteQueryRequest(requestData1);
            }
            else
            {
                //previous day
                LoadCollectionRequestData requestData1 = new LoadCollectionRequestData();
                requestData1.IDOName = "SLJobTrans";
                requestData1.PropertyList.SetProperties("TransNum, RowPointer, RecordDate, EmpNum, TransDate, Job, Suffix, OperNum, IndCode,TransType,UserCode, Shift, Pay, PayRate,PrRate,JobRate, AHrs,StartTime, EndTime, Wc");
                string filterString = "EmpNum = '" + employeeInput + "' and Posted='1'";
                filterString += " and TransDate ='" + reportStartDateTime.ToString(WMShortDatePattern) + "' "; //MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128
                filterString += " and StartTime >= '" + stInSeconds + "' and EndTime <= '86340' ";

                requestData1.Filter = filterString;
                requestData1.RecordCap = -1;
                requestData1.OrderBy = "TransNum";

                responseData1 = this.ExcuteQueryRequest(requestData1);

                //next day
                LoadCollectionRequestData requestData2 = new LoadCollectionRequestData();
                requestData2.IDOName = "SLJobTrans";
                requestData2.PropertyList.SetProperties("TransNum, RowPointer, RecordDate, EmpNum, TransDate, Job, Suffix, OperNum, IndCode,TransType,UserCode, Shift, Pay, PayRate,PrRate,JobRate, AHrs,StartTime, EndTime, Wc");
                filterString = "EmpNum = '" + employeeInput + "' and Posted='1'";
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

            if (responseData2 != null)
            {
                for (int i = 0; i < responseData2.Items.Count; i++)
                {
                    responseData1.Items.Add(responseData2.Items.ElementAt(i));
                }
            }

            responseData1 = RemoveDuplicates(responseData1);

            for (int i = 0; i < responseData1.Items.Count; i++)
            {
                initializeVariables();
                //assign values
                this.employee = responseData1[i, "EmpNum"].Value;
                this.reportDate = responseData1[i, "TransDate"].Value;

                //|Trans Type~Order~suffix~Operation~Workcenter~Machine~Task~WTT~HLT~Startdate~starttime
                //|Enddate~Endtime~Manhours~Machhours~logincode

                job = responseData1[i, "Job"].Value;
                if (job.Trim().Equals(""))
                {
                    transType = "21";
                }
                else
                {
                    transType = "22";
                }

                suffix = responseData1[i, "Suffix"].Value;
                if (suffix.Trim().Equals(""))
                {
                    suffix = "0";
                }
                oper = responseData1[i, "OperNum"].Value;
                if (oper.Trim().Equals(""))
                {
                    oper = "0";
                }

                workCenter = responseData1[i, "Wc"].Value;
                indirectCode = responseData1[i, "IndCode"].Value;
                shift = responseData1[i, "Shift"].Value;
                payType = responseData1[i, "PayRate"].Value;

                startTimeInSeconds = responseData1[i, "StartTime"].Value;
                endTimeInSeconds = responseData1[i, "EndTime"].Value;

                caltotalTimeInHours = Convert.ToDouble(responseData1[i, "AHrs"].Value, CultureInfo.InvariantCulture); // FTDEV-9247
                username = responseData1[i, "UserCode"].Value;

                JobInfo matchingJob = new JobInfo();
                int matchingJobIndex = -1;



                if (CheckMatchingJob(employee, transType, job, suffix, oper, indirectCode, workCenter, startTimeInSeconds, endTimeInSeconds,
                        caltotalTimeInHours.ToString("0.00000000"), payType, out matchingJob, out matchingJobIndex))
                {
                    matchingJob.markedToPost = false;
                    if (matchingJobIndex != -1)
                    {
                        this.toPostJobList.RemoveAt(matchingJobIndex);
                    }
                    continue;
                }
                if (postOffSets == false)
                    continue;
                caltotalTimeInHours = -1 * caltotalTimeInHours;

                AddLaborHours(out errorString);
            }

            //Console.WriteLine("After offset. Hours count:: " + toPostJobList.Count);

            foreach (JobInfo jobInfo in toPostJobList)
            {
                /*Console.WriteLine("To Post List:: " + jobInfo.employee + ":" + jobInfo.transType + ":" + jobInfo.job + ":" + jobInfo.suffix
                            + ":" + jobInfo.operation + ":" + jobInfo.task
                             + ":" + jobInfo.workcenter + ":" + jobInfo.startTime
                             + ":" + jobInfo.endTime + ":" + jobInfo.laborHrs + ":" + jobInfo.payType);*/
            }

            return true;
        }

        private LoadCollectionResponseData RemoveDuplicates(LoadCollectionResponseData responseData)
        {
            string firstEmployee = "";
            string firstReportDate = "";
            string firstJob = "";
            string firstTransType = "";
            string firstSuffix = "";
            string firstOper = "";
            string firstWorkCenter = "";
            string firstIndirectCode = "";
            string firstShift = "";
            string firstPayType = "";
            string firstStartTimeInSeconds = "";
            string firstEndTimeInSeconds = "";
            double firstCaltotalTimeInHours = 0;
            string firstRowPointer = "";

            string secondEmployee = "";
            string secondReportDate = "";
            string secondJob = "";
            string secondTransType = "";
            string secondSuffix = "";
            string secondOper = "";
            string secondWorkCenter = "";
            string secondIndirectCode = "";
            string secondShift = "";
            string secondPayType = "";
            string secondStartTimeInSeconds = "";
            string secondEndTimeInSeconds = "";
            double secondCaltotalTimeInHours = 0;
            string secondRowPointer = "";

            List<string> duplicateList = new List<string>(1);

            for (int i = 0; i < responseData.Items.Count; i++)
            {
                if (duplicateList.IndexOf(responseData[i, "RowPointer"].Value) != -1)
                {
                    continue;
                }

                //assign values
                firstEmployee = responseData[i, "EmpNum"].Value;
                firstReportDate = responseData[i, "TransDate"].Value;

                firstJob = responseData[i, "Job"].Value;
                if (firstJob.Trim().Equals(""))
                {
                    firstTransType = "21";
                }
                else
                {
                    firstTransType = "22";
                }

                firstSuffix = responseData[i, "Suffix"].Value;
                if (firstSuffix.Trim().Equals(""))
                {
                    firstSuffix = "0";
                }
                firstOper = responseData[i, "OperNum"].Value;
                if (firstOper.Trim().Equals(""))
                {
                    firstOper = "0";
                }

                firstWorkCenter = responseData[i, "Wc"].Value;
                firstIndirectCode = responseData[i, "IndCode"].Value;
                firstShift = responseData[i, "Shift"].Value;
                firstPayType = responseData[i, "PayRate"].Value;

                firstStartTimeInSeconds = responseData[i, "StartTime"].Value;
                firstEndTimeInSeconds = responseData[i, "EndTime"].Value;
                firstRowPointer = responseData[i, "RowPointer"].Value;

                firstCaltotalTimeInHours = Convert.ToDouble(responseData[i, "AHrs"].Value, CultureInfo.InvariantCulture); // FTDEV-9247

                for (int secondIndex = i + 1; secondIndex < responseData.Items.Count; secondIndex++)
                {
                    if (duplicateList.IndexOf(responseData[secondIndex, "RowPointer"].Value) != -1)
                    {
                        continue;
                    }

                    secondEmployee = responseData[secondIndex, "EmpNum"].Value;
                    secondReportDate = responseData[secondIndex, "TransDate"].Value;

                    secondJob = responseData[secondIndex, "Job"].Value;
                    if (secondJob.Trim().Equals(""))
                    {
                        secondTransType = "21";
                    }
                    else
                    {
                        secondTransType = "22";
                    }

                    secondSuffix = responseData[secondIndex, "Suffix"].Value;
                    if (secondSuffix.Trim().Equals(""))
                    {
                        secondSuffix = "0";
                    }
                    secondOper = responseData[secondIndex, "OperNum"].Value;
                    if (secondOper.Trim().Equals(""))
                    {
                        secondOper = "0";
                    }

                    secondWorkCenter = responseData[secondIndex, "Wc"].Value;
                    secondIndirectCode = responseData[secondIndex, "IndCode"].Value;
                    secondShift = responseData[secondIndex, "Shift"].Value;
                    secondPayType = responseData[secondIndex, "PayRate"].Value;

                    secondStartTimeInSeconds = responseData[secondIndex, "StartTime"].Value;
                    secondEndTimeInSeconds = responseData[secondIndex, "EndTime"].Value;

                    secondRowPointer = responseData[secondIndex, "RowPointer"].Value;

                    secondCaltotalTimeInHours = Convert.ToDouble(responseData[secondIndex, "AHrs"].Value, CultureInfo.InvariantCulture); // FTDEV-9247

                    if (firstEmployee.Equals(secondEmployee) && firstReportDate.Equals(secondReportDate)
                        && firstJob.Equals(secondJob) && firstTransType.Equals(secondTransType)
                        && firstSuffix.Equals(secondSuffix) && firstOper.Equals(secondOper)
                        && firstWorkCenter.Equals(secondWorkCenter) && firstIndirectCode.Equals(secondIndirectCode)
                        && firstShift.Equals(secondShift) && firstPayType.Equals(secondPayType)
                        && firstStartTimeInSeconds.Equals(secondStartTimeInSeconds)
                        && firstEndTimeInSeconds.Equals(secondEndTimeInSeconds)
                        && (firstCaltotalTimeInHours * -1 == secondCaltotalTimeInHours))
                    {
                        duplicateList.Add(firstRowPointer);
                        duplicateList.Add(secondRowPointer);
                        break;
                    }
                }

            }

            for (int listindex = 0; listindex < duplicateList.Count; listindex++)
            {
                //Console.WriteLine(" Row Pointer to delete:: " + duplicateList[listindex]);
            }

            for (int listindex = 0; listindex < duplicateList.Count; listindex++)
            {
                int indexToRemove = -1;
                for (int rdindex = 0; rdindex < responseData.Items.Count; rdindex++)
                {
                    indexToRemove = -1;
                    if (responseData[rdindex, "RowPointer"].Value.Equals(duplicateList[listindex]))
                    {
                        indexToRemove = rdindex;
                        break;
                    }
                }
                if (indexToRemove != -1)
                {
                    responseData.Items.RemoveAt(indexToRemove);
                }
            }

            for (int rdindex = 0; rdindex < responseData.Items.Count; rdindex++)
            {
                //Console.WriteLine("Remaining row pointers :: " + responseData[rdindex, "RowPointer"].Value);
            }

            return responseData;
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

        //|Input File layout            - SyteLine
        //| Hours~1005~20120920~2|
        //|Trans Type~Order~suffix~Operation~Workcenter~Machine~Task~WTT~HLT~Startdate~starttime
        //|Enddate~Endtime~Manhours~Machhours~logincode

        private bool PerformHoursSteps(string inputLine, out string errorString)
        {
            errorString = "";
            initializeVariables();
            string[] inputLineArray = inputLine.Split(new char[] { '|' });
            string identifierString = inputLineArray[0];
            string dataString = inputLineArray[1];
            string[] dataStringArray = dataString.Split(new char[] { '~' });
            string[] identifierStringArray = identifierString.Split(new char[] { '~' });
            LoadCollectionResponseData serialResponseData = new LoadCollectionResponseData();
            LoadCollectionResponseData backflushLotsResponseData = new LoadCollectionResponseData();
            LoadCollectionResponseData backflushSerialsResponseData = new LoadCollectionResponseData();

            List<string> SerList = null;
            
            if(inputLineArray.Length > 2 && !string.IsNullOrEmpty(inputLineArray[2]))
            {
                serialResponseData = ConvertXMLtoIDO(inputLineArray[2]);
                if (serialResponseData.Items.Count > 0)
                {
                    SerList = new  List<string>();
                    for (int i = 0; i < serialResponseData.Items.Count; i++)
                    {
                        SerList.Add(serialResponseData[i, "SerNum"].Value.ToString());
                    }
                 }
            }

            if (inputLineArray.Length > 3 && !string.IsNullOrEmpty(inputLineArray[3]))
            {
                backflushLotsResponseData = ConvertXMLtoIDO(inputLineArray[3]);
            }

            if (inputLineArray.Length > 4 && !string.IsNullOrEmpty(inputLineArray[4]))
            {
                backflushSerialsResponseData = ConvertXMLtoIDO(inputLineArray[4]);
            }

            bool postjob = IsPostLabor;

            if (StopPostJobs == true)
                postjob = false;


            //assign values
            employee = identifierStringArray[1];
            if (string.IsNullOrWhiteSpace(employee) == false)
            {
                employee = GetExpandedString(employee, "EmpNumType", "");
            }


            //|Trans Type~Order~suffix~Operation~Workcenter~Machine~Task~WTT~HLT~Startdate~starttime
            //|Enddate~Endtime~Manhours~Machhours~logincode

            //<EmpNum>~<ReportDate>~<SequenceNum>|
            //<OrderType>~<OrderNumber or Production Schedule> ~ <Suffix> ~ <Operation>~<WorkCenter>~
            //<Empty>~<TaskCode>~<Shift>~ <R>~<ActualStartDate>~<ActualStartTime>~<ActualStopDate>~<ActualStopTime>~
            //<Machine Elapsed Time or Man Elapsed Time Based on OrderType>~<Empty>~<UserName>~
            //<PartnerId>~<SROLine>~<WorkCode>~<BillCode>~<BillHours>


            transType = dataStringArray[0];
            job = dataStringArray[1];                   //or production schedule
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
            
            if (string.IsNullOrWhiteSpace(shift))
            {

                LoadCollectionResponseData Employeedata = GetEmployeeDetails(employee);
                try
                {
                    shift = Employeedata[0, "Shift"].Value.ToString();
                }
                catch
                { shift = ""; }
            }

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

            if (dataStringArray.Length > 16)
            {
                try
                {
                    PartnerId = dataStringArray[16];
                    SROLine = dataStringArray[17];
                    WorkCode = dataStringArray[18];
                    BillCode = dataStringArray[19];
                    if (string.IsNullOrEmpty(dataStringArray[20]) || dataStringArray[20] == "0")
                    {
                        BillHours = caltotalTimeInHours.ToString("0.00000000");
                    }
                    else
                    {
                        BillHours = dataStringArray[20];
                    }
                }
                catch (Exception)
                {
                }
            }

            DateTime startDateTime = DateTime.ParseExact(this.startDate + " " + this.startTime, "MMddyyyy HHmm", CultureInfo.CurrentCulture);
            DateTime endDateTime = DateTime.ParseExact(this.endDate + " " + this.endTime, "MMddyyyy HHmm", CultureInfo.CurrentCulture);
            startTimeInSeconds = startDateTime.TimeOfDay.TotalSeconds.ToString();
            endTimeInSeconds = endDateTime.TimeOfDay.TotalSeconds.ToString();

            //~1~1~0~~0~0~MAIN~AL-10000~EA~STOCK~270220140000011~~SL_FT_ODP~      
            if (dataStringArray.Length > 21)
            {
                try
                {
                    qtyCompleted = string.IsNullOrEmpty(dataStringArray[21])?"0": dataStringArray[21];
                    qtyMoved = string.IsNullOrEmpty(dataStringArray[22]) ? "0" : dataStringArray[22]; 
                    qtyScrapped = string.IsNullOrEmpty(dataStringArray[23]) ? "0" : dataStringArray[23]; 
                    reasonCode = dataStringArray[24];


                    //variables specific for qty posting
                    deviceId = userInitials;//GetDataFromArray(dataStringArray, 8);

                    operComplete = string.IsNullOrEmpty(dataStringArray[25]) ? "0" : dataStringArray[25];
                    closeJob = string.IsNullOrEmpty(dataStringArray[26]) ? "0" : dataStringArray[26];
                    whse = GetDataFromArray(dataStringArray, 27);
                    item = GetDataFromArray(dataStringArray, 28);
                    uom = GetDataFromArray(dataStringArray, 29);
                    loc = GetDataFromArray(dataStringArray, 30);
                    lot = GetDataFromArray(dataStringArray, 31);
                    containerNum = GetDataFromArray(dataStringArray, 32);
                    site = GetDataFromArray(dataStringArray, 33);
                    SessionID = GetDataFromArray(dataStringArray, 34);
                    userInitials = GetDataFromArray(dataStringArray, 35);
                    NextOper = GetDataFromArray(dataStringArray, 36);
                    if (transType == "24")
                        RESID = GetDataFromArray(dataStringArray, 5);
                    else
                        RESID = GetDataFromArray(dataStringArray, 37);
                    if (dataStringArray.Length > 38)
                        issueToParent = GetDataFromArray(dataStringArray, 38);
                    else if (dataStringArray.Length > 37)
                        issueToParent = GetDataFromArray(dataStringArray, 38);
                    if (issueToParent == "")
                        issueToParent = "0";
                    /*if (operComplete == "1" || closeJob == "1")
                    {
                        IsPostLabor = true;
                    
                    }*/
                   
                   
                }
                catch (Exception)
                {
                }
                if (transType.Equals("22") || transType.Equals("23") || transType.Equals("24"))
                { 
                    CombineLaborAndQty combineLaborAndQty = new CombineLaborAndQty(transType, employee, reportDate, job, suffix,
                                   oper, indirectCode, workCenter, shift, startDate,
                                   startTime, endDate, endTime, totalTimeInMints, caltotalTimeInHours,
                                   payType, username, qtyCompleted, qtyMoved, qtyScrapped,
                                   reasonCode, operComplete, closeJob, startTimeInSeconds, endTimeInSeconds, deviceId,
                                   whse, item, uom, loc, lot, site, containerNum, SessionID, userInitials, postjob, NextOper, RESID, issueToParent, SerList, backflushLotsResponseData, backflushSerialsResponseData);
                combineLaborAndQty.SetContext(this.Context);
                combineLaborAndQty.Initialize();
                combineLaborAndQty.PerformUpdate(out errorString);
                if (errorString != null && errorString != "")
                {
                    return false;
                }            
                return true;
               }
            }

            if (transType.Equals("25") || transType.Equals("27") || transType.Equals("29"))
            {
                WorkCenterLaborUpdate workcenterLaborUpdate = new WorkCenterLaborUpdate(employee, workCenter, shift,
                                                                                        startDate, startTime, endTime,
                                                                                        caltotalTimeInHours, false);
                workcenterLaborUpdate.SetContext(this.Context);
                workcenterLaborUpdate.Initialize();
                workcenterLaborUpdate.PerformUpdate(out errorString);
                if (errorString != null && errorString != "")
                {
                    return false;
                }
                return true;
            }
            else if (transType.Equals("26") || transType.Equals("28") || transType.Equals("30"))
            {

                WorkCenterMachineUpdate workcenterMachineUpdate = new WorkCenterMachineUpdate(employee,workCenter,shift,
                                                                                              startDate,startTime,endTime,
                                                                                              caltotalTimeInHours);
                workcenterMachineUpdate.SetContext(this.Context);
                workcenterMachineUpdate.Initialize();
                workcenterMachineUpdate.PerformUpdate(out errorString);
                if (errorString != null && errorString != "")
                {
                    return false;
                }

                return true;
            }
            else if (transType.Equals("31"))
            {
                ProjectLaborUpdate projectLaborUpdate = new ProjectLaborUpdate(employee, shift, payType, job, indirectCode,
                                                                                              workCenter, reportDate, "" + caltotalTimeInHours, postjob);
                projectLaborUpdate.SetContext(this.Context);
                projectLaborUpdate.Initialize();
                projectLaborUpdate.PerformUpdate(out errorString);

                if (errorString != null && errorString != "")
                {
                    return false;
                }

                return true;
            }
            else if (transType.Equals("34"))
            {
                if (string.IsNullOrEmpty(WorkCode))
                {
                    LoadCollectionResponseData workcodes = GetWorkCodeDetails();
                    if (workcodes.Items.Count > 0)
                    {
                        // To avoid emplty or null values assigning default code because it gives an error at syteline side.
                        WorkCode = workcodes.Items.FirstOrDefault().PropertyValues[0].Value;
                    }
                }
                SROLaborUpdate sroLaborUpdate = new SROLaborUpdate(PartnerId, job, SROLine, oper,
                    startDateTime.ToString(WMFullDateTimePattern), endDateTime.ToString(WMFullDateTimePattern),
                    "" + caltotalTimeInHours, BillHours, WorkCode, BillCode);
                sroLaborUpdate.SetContext(this.Context);
                sroLaborUpdate.Initialize();
                sroLaborUpdate.PerformUpdate(out errorString);

                if (errorString != null && errorString != "")
                {
                    return false;
                }

                return true;
            }

            JobInfo matchingJob = new JobInfo();
            int matchingJobIndex = -1;

            if (CheckMatchingJob(employee, transType, job, suffix, oper, indirectCode, workCenter, startTimeInSeconds, endTimeInSeconds, caltotalTimeInHours.ToString("0.00000000"), payType, out matchingJob, out matchingJobIndex))
            {
                return AddLaborHours(out errorString);
            }

            return true;
        }
        public LoadCollectionResponseData ConvertXMLtoIDO(string xml) 
        {
            LoadCollectionResponseData returnResponse = new LoadCollectionResponseData();
            XmlDocument rootDoc = new XmlDocument();
            rootDoc.LoadXml(xml);

            XmlNodeList fieldNodeList = rootDoc.ChildNodes[0].ChildNodes;

            foreach (XmlNode fieldListNode in fieldNodeList[0].ChildNodes)
            {
                returnResponse.PropertyList.Add(fieldListNode.Name);
            }

            foreach (XmlNode fieldListNode in fieldNodeList)
            {
                IIDOItem idoItem = returnResponse.AddNewItem();

                foreach (XmlNode fieldvaluesNode in fieldListNode.ChildNodes)
                {
                    idoItem.SetValue(fieldvaluesNode.Name, fieldvaluesNode.InnerText);
                }
            }
            return returnResponse;
        }

        public LoadCollectionResponseData GetWorkCodeDetails(string WorkCode = "")
        {
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "FSWorkCodes";
            requestData.PropertyList.SetProperties("WorkCode,Description");

            if (WorkCode != null && !(WorkCode.Trim().Equals("")))
            {
                requestData.Filter = "WorkCode = '" + WorkCode + "'";
            }

            requestData.RecordCap = 50000;
            requestData.OrderBy = "WorkCode";
            return this.Context.Commands.LoadCollection(requestData);
        }

        private bool PerformQtySteps(string inputLine, out string errorString)
        {
            string orderType = "";
            errorString = "";
            initializeVariables();
            string[] inputLineArray = inputLine.Split(new char[] { '|' });
            string identifierString = inputLineArray[0];
            string dataString = inputLineArray[1];
            string[] dataStringArray = dataString.Split(new char[] { '~' });
            string[] identifierStringArray = identifierString.Split(new char[] { '~' });

            //assign values
            employee = identifierStringArray[1];
            if (string.IsNullOrWhiteSpace(employee) == false)
            {
                employee = GetExpandedString(employee, "EmpNumType", "");
            }

            reportDate = identifierStringArray[2];

            DateTime reportDateTime = DateTime.ParseExact(reportDate + " " + "0000", "MMddyyyy HHmm", CultureInfo.CurrentCulture);
            reportDate = reportDateTime.ToString("yyyy/MM/dd");

            //|Trans Type~Order~suffix~Operation~Workcenter~Machine~Task~WTT~HLT~Startdate~starttime
            //|Enddate~Endtime~Manhours~Machhours~logincode

//<EmpNum>~<ReportDate>~<SequenceNum>|
//<orderType>~<ProdSchedule>~<suffix>~<Operation>~<QtyReported>~<QtyMoved>~<QtyRejected>~<reasoncode>~<DeviseId>~<UM>~
//<CompleteOperation>~<CloseJob>~<Lot>~<Loc>~<Whse>~<Item>~<WorkCenter>~<Demo>~
//<addItemLocRecord>~<allowIfCycleCountExists>~<addPermanentItemWhseLocLink>~<generateSerials>~<SessionID>


            transType = "M";
            orderType = dataStringArray[0];
            job = dataStringArray[1];
            suffix = dataStringArray[2];
            oper = dataStringArray[3];
            qtyCompleted = dataStringArray[4];
            qtyMoved = dataStringArray[5];
            qtyScrapped = dataStringArray[6];
            reasonCode = dataStringArray[7];
            //userInitials = "QMI";

            //variables specific for qty posting
            userInitials = GetDataFromArray(dataStringArray, 8);
            string deviceId = GetDataFromArray(dataStringArray, 8);
            string uom = GetDataFromArray(dataStringArray, 9);
            bool operComplete = GetBoolValue(GetDataFromArray(dataStringArray, 10));
            bool closeJob = GetBoolValue(GetDataFromArray(dataStringArray, 11));
            string lot = GetDataFromArray(dataStringArray, 12);
            string loc = GetDataFromArray(dataStringArray, 13);
            string whse = GetDataFromArray(dataStringArray, 14);
            string item = GetDataFromArray(dataStringArray, 15);
            string workCenter = GetDataFromArray(dataStringArray, 16);
            string site = GetDataFromArray(dataStringArray, 17);
            bool addItemLocRecord = GetBoolValue(GetDataFromArray(dataStringArray, 18));
            bool allowIfCycleCountExists = GetBoolValue(GetDataFromArray(dataStringArray, 19));
            bool addPermanentItemWhseLocLink = GetBoolValue(GetDataFromArray(dataStringArray, 20));
            bool generateSerials = GetBoolValue(GetDataFromArray(dataStringArray, 21));
            string SessionID = GetDataFromArray(dataStringArray, 22);
            string shift = GetDataFromArray(dataStringArray, 23);

            if (string.IsNullOrWhiteSpace(shift))
            {

                LoadCollectionResponseData Employeedata = GetEmployeeDetails(employee);
                try
                {
                    shift = Employeedata[0, "Shift"].Value.ToString();
                }
                catch
                { shift = ""; }
            }

            string containerNum = GetDataFromArray(dataStringArray, 24);
            bool issueToParent = false;
            if (dataStringArray.Length > 24)
                issueToParent = GetBoolValue(GetDataFromArray(dataStringArray, 25));
            if (operComplete == true || closeJob == true)
            {
                IsPostLabor = true;

            }

            // Call standard Move for quantity posting
            if (orderType.Equals("22") || orderType.Equals("23") || orderType.Equals("24"))
            {
               string  employeeUpdate = formatDataByIDOAndPropertyName("SLEmployees", "EmpNum", employee);
                MoveUpdate moveUpdate = new MoveUpdate(job, suffix, oper, deviceId, reportDate, qtyCompleted,
                                  qtyScrapped, qtyMoved, uom, reasonCode, operComplete, closeJob, lot,
                                 loc, whse, site, userInitials,
                                addItemLocRecord, allowIfCycleCountExists,
                                addPermanentItemWhseLocLink, generateSerials, SessionID, containerNum, issueToParent, "", employeeUpdate, StopPostJobs?"1":"0");    // Issue to parent parameter the last one should be sent from front end 

                moveUpdate.SetContext(this.Context);
                moveUpdate.Initialize();
                moveUpdate.PerformUpdate(out errorString);
            }
            else if (orderType.Equals("27"))
            {
                //JIT
                JITProductionUpdate jitUpdate = new JITProductionUpdate(qtyCompleted, item, site, whse, loc,
                                                                        uom, lot, "", shift,
                                                                        employee, generateSerials, true,
                                                                        addItemLocRecord,allowIfCycleCountExists,
                                                                        addPermanentItemWhseLocLink,
                                                                        SessionID, containerNum,"");
                jitUpdate.SetContext(this.Context);
                jitUpdate.Initialize();
                jitUpdate.PerformUpdate(out errorString);
            }
            else if (orderType.Equals("29"))
            {

                //Production Schedule
                PSUpdate psUpdate = new PSUpdate(item, job, workCenter, oper, site, whse, qtyCompleted, uom, loc, lot, employee,
                                                 shift,"",generateSerials,true,
                                                                        addItemLocRecord, allowIfCycleCountExists,
                                                                        addPermanentItemWhseLocLink, qtyScrapped,reasonCode,
                                                                        SessionID, containerNum,"", string.Empty, string.Empty,
                                                                        string.Empty, string.Empty, string.Empty, string.Empty);
                psUpdate.SetContext(this.Context);
                psUpdate.Initialize();
                psUpdate.PerformUpdate(out errorString);
            }

            if (errorString != null && !errorString.Trim().Equals(""))
            {
                return false;
            }

            return true;
        }

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

        }

        private bool AddLaborHours(out string errorString)
        {
            errorString = "";
            if (formatInputs() == false)
            {
                return false;
            }
            //3 validate Inputs
            if (validateInputs() == false)
            {
                return false;
            }
            return performJobPosting(out errorString);

        }

        private bool performJobPosting(out string errorString)
        {
            string errorDeleteString = "";
            //return insertIntoMainTable(out errorString);
            if (insertIntoMainTable(out errorString) == false)
            {
                return false;
            }
            if ((IsQtyLineExists || IsPostLabor) && StopPostJobs == false)
            //if (IsPostLabor)
            {
                if (performPosting(out errorString) == false)
                {
                    deleteFromMainTable(out errorDeleteString);
                    if (!string.IsNullOrEmpty(errorDeleteString))
                        errorString = errorDeleteString;
                    return false;
                }
            }
            return true;
        }

        private bool insertIntoMainTable(out string errorString)
        {
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
            if (transType.Equals("21"))
            {
                updateItem.Properties.Add("TransType", "I");
            }
            else if (transType.Equals("22"))
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

            //updateItem.Properties.Add("TransDate", reportDate);
            //updateItem.Properties.Add("TransDate", System.DateTime.Now.ToString(WMLongDateTimePattern)); // FTDEV-9195 - Adding Time to the date/time string passed into CSI
            //updateItem.Properties.Add("TransDate", System.DateTime.Now); // FTDEV-9247 - Date-conversion for bounced method
            updateItem.Properties.Add("TransDate", DateTime.ParseExact(this.endDate + " " + this.endTime, "MMddyyyy HHmm", CultureInfo.CurrentCulture));
            if (userInitials != null && !(userInitials.Trim().Equals("")))                       
            {
                updateItem.Properties.Add("UserCode", userInitials);
            }
            else
            {
                updateItem.Properties.Add("UserCode", "SA");                             
            }

            updateItem.Properties.Add("JobItem", "");
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
                updateItem.Properties.Add("PrRate", payTypeResponseData.Parameters.ElementAt(4).ToString());
                updateItem.Properties.Add("JobRate", payTypeResponseData.Parameters.ElementAt(5).ToString());
                updateItem.Properties.Add("IndCode", this.indirectCode);
                updateItem.Properties.Add("IndcodeDescription", "");
            }

            updateItem.Properties.Add("QtyComplete", qtyCompleted);
            updateItem.Properties.Add("QtyScrapped", qtyScrapped);
            updateItem.Properties.Add("QtyMoved", qtyMoved);
            updateItem.Properties.Add("ReasonCode", reasonCode);
            updateItem.Properties.Add("Loc", "");
            updateItem.Properties.Add("LocDescription", "");
            updateItem.Properties.Add("Lot", "");

            updateItem.Properties.Add("ItemUM", "");
            if (transType.Equals("M"))
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
                updateItem.Properties.Add("NextOper", "");
            }
            updateItem.Properties.Add("XjobrWc", "");
            updateItem.Properties.Add("XwcDescription", "");
            updateItem.Properties.Add("ReasonDescription", "");

            updateItem.Properties.Add("DerStartTimeHrs", "", false);
            // updateItem.Properties.Add("DerStartTimeMin", "");            
            updateItem.Properties.Add("DerStartTimeMin", startTime);
            //updateItem.Properties.Add("DerEndTimeMin", "");                
            updateItem.Properties.Add("DerEndTimeMin", endTime);
            updateItem.Properties.Add("AHrs", this.caltotalTimeInHours);
            updateItem.Properties.Add("DerEndTimeHrs", "", false);
            updateItem.Properties.Add("Whse", JobWhse);
            updateItem.Properties.Add("CostCode", ((invokeOrderOperResponseData == null) ? "" : invokeOrderOperResponseData.Parameters.ElementAt(8).ToString()));
            updateItem.Properties.Add("JobrCntrlPoint", "");
            updateItem.Properties.Add("CompleteOp", "0");
            updateItem.Properties.Add("CloseJob", "0");
            updateItem.Properties.Add("IssueParent", "0");
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
            // Added Properties
            updateItem.Properties.Add("IsJobXrefdToProject", "0");
            updateItem.Properties.Add("IsSubJobTiedToProject", "0");
            updateItem.Properties.Add("JobtranitemQtyComplete", "");
            updateItem.Properties.Add("JobtranitemQtyScrapped", "");
            updateItem.Properties.Add("JobtranitemQtyMoved", "");
            // Ended 
            updateItem.ItemID = "";
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
            //updateItem.Properties.Add("TransDate", reportDate);
            //updateItem.Properties.Add("TransDate", System.DateTime.Now.ToString(WMLongDateTimePattern));// FTDEV-9195 - Adding Time to the date/time string passed into CSI
            updateItem.Properties.Add("TransDate", System.DateTime.Now); // FTDEV-9247 - Date-conversion for bounced method

            if (userInitials != null && !(userInitials.Trim().Equals("")))                       
            {
                updateItem.Properties.Add("UserCode", userInitials);
            }
            else
            {
                updateItem.Properties.Add("UserCode", "SA");                            
            }
            updateItem.Properties.Add("JobItem", "");
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
                updateItem.Properties.Add("PrRate", payTypeResponseData.Parameters.ElementAt(4).ToString());
                updateItem.Properties.Add("JobRate", payTypeResponseData.Parameters.ElementAt(5).ToString());
                updateItem.Properties.Add("IndCode", this.indirectCode);
                updateItem.Properties.Add("IndcodeDescription", "");
            }


            updateItem.Properties.Add("QtyComplete", "0");
            updateItem.Properties.Add("ItemUM", "");
            updateItem.Properties.Add("QtyScrapped", "0");
            updateItem.Properties.Add("QtyMoved", "0");
            //updateItem.Properties.Add("NextOper", "");
            if (transType.Equals("M"))
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
                updateItem.Properties.Add("NextOper", "");
            }


            updateItem.Properties.Add("XjobrWc", "");
            updateItem.Properties.Add("XwcDescription", "");
            updateItem.Properties.Add("ReasonCode", "");
            updateItem.Properties.Add("ReasonDescription", "");
            updateItem.Properties.Add("Loc", "");
            updateItem.Properties.Add("LocDescription", "");
            updateItem.Properties.Add("Lot", "");

            updateItem.Properties.Add("DerStartTimeHrs", "", false);
            // updateItem.Properties.Add("DerStartTimeMin", "");            
            updateItem.Properties.Add("DerStartTimeMin", startTime);
            updateItem.Properties.Add("DerEndTimeMin", endTime);
            updateItem.Properties.Add("AHrs", caltotalTimeInHours);
            updateItem.Properties.Add("DerEndTimeHrs", "", false);
            updateItem.Properties.Add("Whse", JobWhse);
            updateItem.Properties.Add("CostCode", (invokeOrderOperResponseData == null) ? "" : invokeOrderOperResponseData.Parameters.ElementAt(8).ToString());
            updateItem.Properties.Add("JobrCntrlPoint", "0");
            updateItem.Properties.Add("CompleteOp", "0");
            updateItem.Properties.Add("CloseJob", "0");
            updateItem.Properties.Add("IssueParent", "0");
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

            #endregion

            return true;

        }

       

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

        private bool performPosting(out string errorString)
        {
            errorString = "";
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
                                                ""          //new
                                                };
            try
            {
                InvokeResponseData responseData = InvokeIDO("SLJobTrans", "JobJobP", inputValues);
                if (!responseData.ReturnValue.Equals("0"))
                {
                    errorMessage = responseData.Parameters.ElementAt(20).ToString();
                    errorString= responseData.Parameters.ElementAt(20).ToString();
                    return false;
                }
            }
            catch (Exception e)
            {
                errorMessage =  e.Message.ToString() ;
                errorString = e.Message.ToString();
                return false;
            }
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
            updateItem.Properties.Add("NextOper", ((invokeOrderOperResponseData == null) ? "" : invokeOrderOperResponseData.Parameters.ElementAt(9).ToString()));

            updateItem.Properties.Add("XjobrWc", "");               //can be filled 
            updateItem.Properties.Add("XwcDescription", "");    //can be filled
            updateItem.Properties.Add("ReasonCode", reasonCode);
            updateItem.Properties.Add("ReasonDescription", "");
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
            updateItem.Properties.Add("Wc", workCenter);
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
        private void AddToPostJob(string localEmployee, string localTransType, string localJob, string localSuffix, string localOper, string localTask, string localWorkcenter,
                                string localStartTime, string localEndTime, string localLaborHours, string localPayType)
        {
            if (toPostJobList == null)
            {
                toPostJobList = new List<JobInfo>();
            }

            JobInfo jobInfo = new JobInfo();

            jobInfo.markedToPost = true;
            jobInfo.employee = localEmployee;
            jobInfo.transType = localTransType;
            jobInfo.job = localJob;
            jobInfo.suffix = localSuffix;
            jobInfo.operation = localOper;
            jobInfo.task = localTask;
            jobInfo.workcenter = localWorkcenter;
            jobInfo.startTime = localStartTime;
            jobInfo.endTime = localEndTime;
            jobInfo.laborHrs = localLaborHours;
            jobInfo.payType = localPayType;

           /* Console.WriteLine("Adding line to list:: " + jobInfo.employee + ":" + jobInfo.transType + ":" + jobInfo.job + ":" + jobInfo.suffix
                            + ":" + jobInfo.operation + ":" + jobInfo.task
                             + ":" + jobInfo.workcenter + ":" + jobInfo.startTime
                             + ":" + jobInfo.endTime + ":" + jobInfo.laborHrs + ":" + jobInfo.payType);*/

            toPostJobList.Add(jobInfo);
        }

        private bool CheckMatchingJob(string localEmployee, string localTransType, string localJob, string localSuffix, string localOper, string localTask, string localWorkcenter,
                                string localStartTime, string localEndTime, string localLaborHours, string localPayType, out JobInfo matchingJob, out int matchingJobIndex)
        {
            matchingJob = new JobInfo();
            matchingJobIndex = -1;
           /* Console.WriteLine("Trying to match::" + localEmployee + ":" + localTransType + ":" + localJob + ":" + localSuffix + ":" + localOper + ":" + localTask
                             + ":" + localWorkcenter + ":" + localStartTime
                             + ":" + localEndTime + ":" + localLaborHours + ":" + localPayType);*/


            for (int index = 0; index < this.toPostJobList.Count; index++)
            {
                JobInfo jobInfo = this.toPostJobList[index];

                /*Console.WriteLine("Hours Line::" + jobInfo.employee + ":" + jobInfo.transType + ":" + jobInfo.job + ":" + jobInfo.suffix
                            + ":" + jobInfo.operation + ":" + jobInfo.task
                             + ":" + jobInfo.workcenter + ":" + jobInfo.startTime
                             + ":" + jobInfo.endTime + ":" + jobInfo.laborHrs + ":" + jobInfo.payType);*/



                localEmployee = localEmployee.Trim();

                if (jobInfo.employee.Trim().Equals(localEmployee.Trim()) && jobInfo.transType.Trim().Equals(localTransType.Trim()) && jobInfo.job.Trim().Equals(localJob.Trim()) && jobInfo.suffix.Trim().Equals(localSuffix.Trim())
                    && jobInfo.operation.Trim().Equals(localOper.Trim()) && jobInfo.task.Trim().Equals(localTask.Trim()) && jobInfo.workcenter.Trim().Equals(localWorkcenter.Trim())
                    && jobInfo.startTime.Trim().Equals(localStartTime.Trim()) && jobInfo.endTime.Trim().Equals(localEndTime.Trim()) && jobInfo.laborHrs.Trim().Equals(localLaborHours.Trim())
                    && jobInfo.payType.Trim().Equals(localPayType.Trim()))
                {
                    //Console.WriteLine("Found matching Job index :: " + index);
                    matchingJob = jobInfo;
                    matchingJobIndex = index;
                    return true;
                }
            }

            return false;
        }

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
            if (string.IsNullOrWhiteSpace(employee) == false)
            {
                employee = GetExpandedString(employee, "EmpNumType", "");
            }

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

            if (string.IsNullOrWhiteSpace(shift))
            {

                LoadCollectionResponseData Employeedata = GetEmployeeDetails(employee);
                try
                {
                    shift = Employeedata[0, "Shift"].Value.ToString();
                }
                catch
                { shift = ""; }
            }

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

            AddToPostJob(employee, transType, job, suffix, oper, indirectCode, workCenter, startTimeInSeconds, endTimeInSeconds, caltotalTimeInHours.ToString("0.00000000"), payType);

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
        private bool PreProcessRequest(Request updateRequest, out string returnString)
        {
            userInitials = updateRequest.GetFieldValue("userInitials");
            if (!string.IsNullOrWhiteSpace(userInitials))
            {
                UpdateUserInitial(userInitials, out _);
            }
            postOffSets = updateRequest.GetBoolFieldValue("postOffSets");
            IsPostLabor = updateRequest.GetBoolFieldValue("isPostLabor");
            
            try
            {
                StopPostJobs = updateRequest.GetBoolFieldValue("StopPostJobs");
            }
            catch (Exception) {
                StopPostJobs = false;
            }

            returnString = "<Response><Output>";
            string errorString = "";
            bool skipHoursLine = false;
            bool isError = false;
            IsQtyLineExists = false;
            List<Field> inputFieldsList = updateRequest.InputFieldsList;
            foreach (Field field in inputFieldsList)
            {
                field.Name = field.Name.Replace("\n", "");
                field.Name = field.Name.Replace("\r", "");
                field.Value = field.Value.Replace("\n", "");
                field.Value = field.Value.Replace("\r", "");
                errorString = "";
                returnString += "<fieldValueList><name>" + field.Name + "</name><value>" + field.Value + "</value>";
                if (field.Name.StartsWith("QTY"))
                {
                    IsQtyLineExists = true;
                }
                else if (field.Name.StartsWith("MASTER"))
                {
                    skipHoursLine = false;
                    userInitials = updateRequest.GetFieldValue("userInitials");
                    if (ParseAndValidateMasterLine(field.Value, out errorString) == false)
                    {
                        errorString = errorString.Replace("\n", "");
                        errorString = errorString.Replace("\r", "");
                        returnString += "<errorInfo>" + errorString + "</errorInfo>";
                        skipHoursLine = true;
                        isError = true;
                    }

                }
                else if (field.Name.StartsWith("Hours"))
                {
                    if (skipHoursLine == false)
                    {
                        userInitials = updateRequest.GetFieldValue("userInitials");
                        if (ParseAndValidateHoursLine(field.Value, out errorString) == false)
                        {
                            errorString = errorString.Replace("\n", "");
                            errorString = errorString.Replace("\r", "");
                            returnString += "<errorInfo>" + errorString + "</errorInfo>";
                            isError = true;
                        }
                    }
                }

                returnString += "</fieldValueList>";
            }
            returnString += "</Output></Response>";

            if (isError)
            {
                return false;
            }

            return true;
        }
        #endregion


    }
}
