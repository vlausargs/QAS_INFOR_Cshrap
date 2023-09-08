using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mongoose.Core.Configuration;
using Mongoose.IDO.Protocol;
using Mongoose.IDO;
using Mongoose.Core;
using System.Globalization;

namespace InforCollect.ERP.SL.ICSLShopFloorTrans.Labor
{
    public class JobDispatcher : ALaborUtils, DispatcherService
    {
        List<JobInfo> inputList = null;
        string sRevertCompleteOperation = "";

        public JobDispatcher(IIDOExtensionClassContext context)
        {
            this.Context = context;
        }

        #region Dispatcher Methods

        public void Init()
        {
            base.Initialize();
            toPostJobList = new List<JobInfo>();
            inputList = new List<JobInfo>();
        }

        public bool ProcessLaborUpdate(InputDataSet.MasterLine masterData, bool postOffSets, bool StopPostJobs)
        {
            IDORuntime.LogUserMessage("JobDispatcher.ProcessLaborUpdate", UserDefinedMessageType.UserDefined1, "Before Init");
            Init();
            IDORuntime.LogUserMessage("JobDispatcher.ProcessLaborUpdate", UserDefinedMessageType.UserDefined1, "Before AddToPostJob {0}", masterData.JobHrsLines.Count);

            foreach (InputDataSet.HoursLine hrsLine in masterData.JobHrsLines)
            {
                AddToPostJob(hrsLine);
            }
            IDORuntime.LogUserMessage("JobDispatcher.ProcessLaborUpdate", UserDefinedMessageType.UserDefined1, "After AddToPostJob {0}", masterData.JobHrsLines.Count);
           
            sRevertCompleteOperation = fetchRevertCompleteOperation();
            
             if (PerformMasterChecks(masterData, postOffSets, StopPostJobs))
            {
                IDORuntime.LogUserMessage("JobDispatcher.ProcessLaborUpdate", UserDefinedMessageType.UserDefined1, "After master checks");
                
                if (sRevertCompleteOperation.Equals("1"))
                {
                    for (int i = 0; i < this.toPostJobList.Count; i++)
                    {
                        JobInfo jobInfo = this.toPostJobList[i];
                        if(jobInfo.transType == "22")
                        {
                            //Check operation is complete
                            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
                            requestData.IDOName = "SLJobRoutes";
                            requestData.PropertyList.SetProperties("RowPointer, RecordDate, Job,JobSuffix,OperNum,Complete");
                            string filterString = "Job = '" + jobInfo.job + "'   and JobSuffix ='" + jobInfo.suffix + "'  and OperNum ='" + jobInfo.operation + "' and Complete = 1 and JobStat = 'R'";


                            requestData.Filter = filterString;
                            requestData.RecordCap = 0;
                            requestData.OrderBy = "Job";
                            LoadCollectionResponseData JobResponseData;
                            JobResponseData = Context.Commands.LoadCollection(requestData);
                            if (JobResponseData != null && JobResponseData.Items.Count > 0)
                            {
                                UpdateCollectionRequestData updateContRequestData = new UpdateCollectionRequestData();
                                updateContRequestData.IDOName = "SLJobRoutes";
                                updateContRequestData.RefreshAfterUpdate = true;
                                IDOUpdateItem SlJobItem = new IDOUpdateItem();
                                SlJobItem.Action = UpdateAction.Update;
                                SlJobItem.ItemID = JobResponseData.Items[0].ItemID;
                                SlJobItem.ItemNumber = 0;
                                SlJobItem.Properties.Add("RowPointer", JobResponseData[0, "RowPointer"].Value, false);
                                SlJobItem.Properties.Add("RecordDate", JobResponseData[0, "RecordDate"].Value, false);

                                SlJobItem.Properties.Add("Complete", "0", true);
                                updateContRequestData.Items.Add(SlJobItem);
                                UpdateCollectionResponseData updateResponseData = null;
                                try
                                {
                                    updateResponseData = Context.Commands.UpdateCollection(updateContRequestData);
                                    this.toPostJobList[i].completeOper.Replace("0", "1");
                                }
                                catch (Exception ex)
                                {
                                    this.toPostJobList[i].hrsLine.ErrorMessage = ex.Message;
                                }

                            }
                        }
                        try
                        {
                            
                            IDORuntime.LogUserMessage("JobDispatcher.ProcessLaborUpdate", UserDefinedMessageType.UserDefined1, "Before PeformLabor update");
                            if (jobInfo.donotpostHrs != null && jobInfo.donotpostHrs.Equals("1"))
                            {
                                continue;
                            }

                            PerformLaborUpdate(jobInfo.reportDate, jobInfo.transType, jobInfo.employee, jobInfo.job, jobInfo.suffix, jobInfo.operation, jobInfo.task,
                                                        jobInfo.workcenter, jobInfo.shift, jobInfo.laborHrs, jobInfo.payType, jobInfo.startTime, jobInfo.endTime,
                                                        jobInfo.qtyCompleted, jobInfo.qtyMoved, jobInfo.qtyRejected, jobInfo.reasonCode, "0", jobInfo.nextOper, jobInfo.RESID, StopPostJobs);
                        }
                        catch (Exception ex)
                        {
                            jobInfo.hrsLine.ErrorMessage = ex.Message;
                        }
                    }
                }
                else {
                    foreach (JobInfo jobInfo in toPostJobList)
                    {
                        IDORuntime.LogUserMessage("JobDispatcher.ProcessLaborUpdate", UserDefinedMessageType.UserDefined1, "Before PeformLabor update");

                        PerformLaborUpdate(jobInfo.reportDate, jobInfo.transType, jobInfo.employee, jobInfo.job, jobInfo.suffix, jobInfo.operation, jobInfo.task,
                                                    jobInfo.workcenter, jobInfo.shift, jobInfo.laborHrs, jobInfo.payType, jobInfo.startTime, jobInfo.endTime,
                                                    jobInfo.qtyCompleted, jobInfo.qtyMoved, jobInfo.qtyRejected, jobInfo.reasonCode, "0", jobInfo.nextOper, jobInfo.RESID, StopPostJobs);
                    }
                }                

                List<JobInfo> toCompleteOperJobList = new List<JobInfo>();


                for (int index = 0; index < this.inputList.Count; index++)
                {
                    JobInfo localjobInfo = this.inputList[index];
                    if (localjobInfo.completeOper == "1" && !toCompleteOperJobList.Contains(localjobInfo))
                    {
                        toCompleteOperJobList.Add(localjobInfo);
                    }
                }



                if (toCompleteOperJobList != null && toCompleteOperJobList.Count > 0)
                {
                    for (int index = 0; index < toCompleteOperJobList.Count; index++)
                    {
                        JobInfo CompletejobInfo = toCompleteOperJobList[index];

                        LoadCollectionResponseData responseJobData = null;
                        LoadCollectionRequestData requestJobData = new LoadCollectionRequestData();
                        requestJobData.IDOName = "SL.SLJobRoutes";
                        requestJobData.PropertyList.SetProperties("Complete, Job, JobSuffix, OperNum");
                        string filterString = "Job = '" + CompletejobInfo.job + "' ";
                        filterString += " and JobSuffix = '" + CompletejobInfo.suffix + "' and OperNum = '" + CompletejobInfo.operation + "' and Complete = 1 ";
                        requestJobData.Filter = filterString;
                        requestJobData.RecordCap = -1;
                        requestJobData.OrderBy = "Job";
                        responseJobData = this.Context.Commands.LoadCollection(requestJobData);
                        if (responseJobData.Items.Count > 0)
                        {
                            continue;
                        }

                        IDORuntime.LogUserMessage("JobDispatcher.ProcessLaborUpdate", UserDefinedMessageType.UserDefined1, "Operations to be completed");
                        PerformLaborUpdate(CompletejobInfo.reportDate, CompletejobInfo.transType, CompletejobInfo.employee, CompletejobInfo.job, CompletejobInfo.suffix, CompletejobInfo.operation, "",
                                                                        CompletejobInfo.workcenter, CompletejobInfo.shift, "0.00000000", CompletejobInfo.payType, "0000", "0000", "0.00000000", "0.00000000", "0.00000000", "", "1", CompletejobInfo.nextOper, CompletejobInfo.RESID, StopPostJobs);
                    }

                }
            }


            return true;
        }

        private string fetchRevertCompleteOperation()
        {
            string sPDRevertCompleteOperation = "0";
            LoadCollectionRequestData ProcessDefaultsrequestData = new LoadCollectionRequestData();
            LoadCollectionResponseData ProcessDefaultsresponseData = new LoadCollectionResponseData();
            ProcessDefaultsrequestData.IDOName = "MGCore.SystemProcessDefaults";
            ProcessDefaultsrequestData.PropertyList.SetProperties("DefaultTypeDesc,DefaultValue");
            string filterString = "DefaultTypeDesc = '" + "RevertCompleteOperation" + "'";
            ProcessDefaultsrequestData.Filter = filterString;
            ProcessDefaultsrequestData.RecordCap = 1;
            ProcessDefaultsresponseData = this.Context.Commands.LoadCollection(ProcessDefaultsrequestData);
            if (ProcessDefaultsresponseData.Items.Count > 0 && ProcessDefaultsresponseData[0, "DefaultValue"].Value.Trim() != "")
            {
                sPDRevertCompleteOperation = ProcessDefaultsresponseData[0, "DefaultValue"].Value;
            }
            return sPDRevertCompleteOperation;
        }

        public bool ProcessQtyUpdate(InputDataSet.QtyLine qtyData)
        {
            Init();

            try
            {
                PerformQtySteps(qtyData);
            }
            catch (Exception ex)
            {
                qtyData.ErrorMessage = ex.Message;
            }
            return true;
        }
        #endregion

        #region Private methods

        private struct JobInfo
        {
            public string reportDate;
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
            public string shift;
            public string qtyCompleted;
            public string qtyMoved;
            public string qtyRejected;
            public string reasonCode;
            public string completeOper;
            public string nextOper;
            public string RESID;
            public string donotpostHrs;


            public InputDataSet.HoursLine hrsLine;
        }
        List<JobInfo> toPostJobList;

        private bool PerformQtySteps(InputDataSet.QtyLine qtyLine)
        {
            string reportDate = qtyLine.GetValue("ReportDate");
            string userInitials = "QMI";
            string infobar;
            bool operComplete = false;

            DateTime reportDateTime = DateTime.ParseExact(reportDate + " " + "0000", "MMddyyyy HHmm", CultureInfo.CurrentCulture);
            reportDate = reportDateTime.ToString("yyyy/MM/dd");



            if (qtyLine.GetValue("TransType").Equals("22") || qtyLine.GetValue("TransType").Equals("23") || qtyLine.GetValue("TransType").Equals("24"))
            {
                if (qtyLine.GetValue("OperationComplete") != null)
                {
                    operComplete = (qtyLine.GetValue("OperationComplete").Equals("1") ? true : false);
                }


                MoveUpdate moveUpdate = new MoveUpdate(
                    qtyLine.GetValue("Job"),
                    qtyLine.GetValue("Suffix"),
                    qtyLine.GetValue("Oper"),
                    userInitials, //Device ID
                    reportDate,
                    qtyLine.GetValue("QtyCompleted"),
                    qtyLine.GetValue("QtyScrapped"),
                    qtyLine.GetValue("QtyMoved"),
                    "",
                    qtyLine.GetValue("ReasonCode"),
                    operComplete,
                    false,
                    "", //Lot
                    "", //Loc
                    "", //whse 
                    "", //site 
                    userInitials,
                    true,
                    true,
                    true,
                    false,
                    "",
                    "",
                    false, ""); //the constructor handles initializing the derived class.

                moveUpdate.Initialize(); //Initilize the base class.  Setup any necessary base class variables. JH:20140103
                moveUpdate.SetContext(this.Context); //set the context- This method is in the base class. JH:20140103

                if (moveUpdate.PerformUpdate(out infobar) > 0)
                {
                    throw new Exception(infobar);
                }
            }
            return true;
        }


        private bool PerformLaborUpdate(string reportDate, string transType, string employee, string job, string suffix, string oper, string taskCode,
                                    string workcenter, string shift, string laborHrs, string payType, string startTime, string endTime,
                                    string qtyCompleted, string qtyMoved, string qtyRejected, string reasonCode, string completeOper, string nextOper, string RESID, bool StopPostJobs)
        {
            string userInitials = "LMI";
            string infobar = "";

            DateTime reportDateTime = DateTime.MinValue;
            try
            {
                reportDateTime = DateTime.ParseExact(reportDate + " " + "0000", "MMddyyyy HHmm", CultureInfo.CurrentCulture);
                reportDate = reportDateTime.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture);

            }
            catch (Exception)
            {
                reportDateTime = DateTime.ParseExact(reportDate, "yyyyMMdd HH:mm:ss.fff", CultureInfo.CurrentCulture);
                reportDate = reportDateTime.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture);
            }


            JobLaborDaoImpl laborUpdate = new JobLaborDaoImpl(this.Context);
            Request laborUpdateRequest = new Request();

            laborUpdateRequest.SetFieldValue("transType", transType);
            laborUpdateRequest.SetFieldValue("employee", employee);
            laborUpdateRequest.SetFieldValue("job", job);
            laborUpdateRequest.SetFieldValue("suffix", suffix);
            laborUpdateRequest.SetFieldValue("oper", oper);
            laborUpdateRequest.SetFieldValue("reportDate", reportDate);
            laborUpdateRequest.SetFieldValue("indirectCode", taskCode);

            laborUpdateRequest.SetFieldValue("workCenter", workcenter);
            laborUpdateRequest.SetFieldValue("shift", shift);
            laborUpdateRequest.SetFieldValue("caltotalTimeInHours", laborHrs);
            laborUpdateRequest.SetFieldValue("payType", payType);
            laborUpdateRequest.SetFieldValue("startTimeInSeconds", startTime);
            laborUpdateRequest.SetFieldValue("endTimeInSeconds", endTime);

            laborUpdateRequest.SetFieldValue("userInitials", userInitials);

            laborUpdateRequest.SetFieldValue("qtyCompleted", qtyCompleted);
            laborUpdateRequest.SetFieldValue("qtyMoved", qtyMoved);
            laborUpdateRequest.SetFieldValue("qtyRejected", qtyRejected);
            laborUpdateRequest.SetFieldValue("reasonCode", reasonCode);
            laborUpdateRequest.SetFieldValue("completeOper", completeOper);
            laborUpdateRequest.SetFieldValue("nextOper", nextOper);
            laborUpdateRequest.SetFieldValue("RESID", RESID);
            laborUpdateRequest.SetFieldValue("StopPostJobs", StopPostJobs?"yes":"no");
            
            if (laborUpdate.PerformUpdate(laborUpdateRequest, out infobar) > 0)
            {
                throw new Exception(infobar);
            }



            return true;
        }

        private bool PerformMasterChecks(InputDataSet.MasterLine masterLine, bool postOffSets, bool StopPostJobs)
        {
            string employee = masterLine.GetValue("Employee");

            employee = formatDataByIDOAndPropertyName("SLEmployees", "EmpNum", employee);

            IDORuntime.LogUserMessage("JobDispatcher.PerformMasterChecks", UserDefinedMessageType.UserDefined1, "Employee {0}", employee);

            deleteDataForMaster(employee, masterLine, postOffSets, StopPostJobs);
            IDORuntime.LogUserMessage("JobDispatcher.PerformMasterChecks", UserDefinedMessageType.UserDefined1, "After DeleteDataForMaster {0}", employee);
            return true;
        }

        private bool deleteDataForMaster(string employee, InputDataSet.MasterLine masterLine, bool postOffSets, bool StopPostJobs)
        {
            string reportDateStart = masterLine.GetValue("Startdate");
            string reportDateEnd = masterLine.GetValue("EndDate");
            string reportTimeStart = masterLine.GetValue("Starttime");
            string reportTimeEnd = masterLine.GetValue("Endtime");
            string IsProcessed = masterLine.GetValue("Processed");

            IDORuntime.LogUserMessage("JobDispatcher.deleteDataForMaster", UserDefinedMessageType.UserDefined1, "In deleteDataForMaster {0},{1},{2},{3}", reportDateStart, reportDateEnd, reportTimeStart, reportTimeEnd);

            if (reportDateStart.Equals(reportDateEnd) && reportTimeStart.Equals(reportTimeEnd))
                return true;

            IDORuntime.LogUserMessage("JobDispatcher.deleteDataForMaster", UserDefinedMessageType.UserDefined1, "Before deleteUnProcessedRecords");

            deleteUnProcessedRecords(employee, reportDateStart, reportDateEnd, reportTimeStart, reportTimeEnd);

            IDORuntime.LogUserMessage("JobDispatcher.deleteDataForMaster", UserDefinedMessageType.UserDefined1, "After deleteUnProcessedRecords");

            //if (postOffSets) //Msf Issue 217615
            //{
            offsetPostedRecords(employee, reportDateStart, reportDateEnd, reportTimeStart, reportTimeEnd, IsProcessed, postOffSets, StopPostJobs);
            //}

            IDORuntime.LogUserMessage("JobDispatcher.deleteDataForMaster", UserDefinedMessageType.UserDefined1, "After OffsetPosting");
            return true;
        }

        private bool deleteUnProcessedRecords(string employee, string reportDateStart, string reportDateEnd, string reportTimeStart, string reportTimeEnd)
        {
            DateTime reportStartDateTime = DateTime.ParseExact(reportDateStart + " " + reportTimeStart, "MMddyyyy HHmm", CultureInfo.CurrentCulture);
            DateTime reportEndDateTime = DateTime.ParseExact(reportDateEnd + " " + reportTimeEnd, "MMddyyyy HHmm", CultureInfo.CurrentCulture);

            string stInSeconds = reportStartDateTime.TimeOfDay.TotalSeconds.ToString();
            string etInSeconds = reportEndDateTime.TimeOfDay.TotalSeconds.ToString();

            LoadCollectionResponseData responseData1 = null;
            LoadCollectionResponseData responseData2 = null;

            if (reportDateStart.Equals(reportDateEnd))
            {
                LoadCollectionRequestData requestData1 = new LoadCollectionRequestData();
                requestData1.IDOName = "SL.SLJobTrans";
                requestData1.PropertyList.SetProperties("TransNum, RowPointer, RecordDate, EmpNum, TransDate,StartTime, EndTime");
                string filterString = "EmpNum = '" + employee + "' and Posted='0'";
                filterString += " and TransDate ='" + reportStartDateTime.ToString(WMShortDatePattern) + "' "; //MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128
                filterString += " and StartTime >= '" + stInSeconds + "' and EndTime <= '" + etInSeconds + "' ";

                requestData1.Filter = filterString;
                //requestData1.RecordCap = -1;
                requestData1.RecordCap = 20000;
                requestData1.OrderBy = "TransNum";

                responseData1 = this.Context.Commands.LoadCollection(requestData1);
            }
            else
            {
                //previous day
                LoadCollectionRequestData requestData1 = new LoadCollectionRequestData();
                requestData1.IDOName = "SL.SLJobTrans";
                requestData1.PropertyList.SetProperties("TransNum, RowPointer, RecordDate, EmpNum, TransDate,StartTime, EndTime");
                string filterString = "EmpNum = '" + employee + "' and Posted='0'";
                filterString += " and TransDate ='" + reportStartDateTime.ToString(WMShortDatePattern) + "' "; //MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128
                filterString += " and StartTime >= '" + stInSeconds + "' and EndTime <= '86340' ";

                requestData1.Filter = filterString;
                //requestData1.RecordCap = -1;
                requestData1.RecordCap = 20000;
                requestData1.OrderBy = "TransNum";

                responseData1 = this.Context.Commands.LoadCollection(requestData1);

                //next day
                LoadCollectionRequestData requestData2 = new LoadCollectionRequestData();
                requestData2.IDOName = "SL.SLJobTrans";
                requestData2.PropertyList.SetProperties("TransNum, RowPointer, RecordDate, EmpNum, TransDate,StartTime, EndTime");
                filterString = "EmpNum = '" + employee + "' and Posted='0'";
                //filterString += " and TransDate ='" + reportEndDateTime.ToShortDateString() + "' ";
                filterString += " and TransDate ='" + reportEndDateTime.ToString(WMShortDatePattern) + "' "; //MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128
                filterString += " and StartTime >= '0' and EndTime <= '" + etInSeconds + "' ";

                requestData2.Filter = filterString;
                //requestData2.RecordCap = -1;
                requestData2.RecordCap = 20000;
                requestData2.OrderBy = "TransNum";

                responseData2 = this.Context.Commands.LoadCollection(requestData2);
            }


            if (responseData1 == null && responseData2 == null)
            {
                return true;
            }

            if (responseData1 != null && responseData1.Items.Count == 0)
            {
                if (responseData2 == null)
                {
                    return true;
                }

                if (responseData2 != null && responseData2.Items.Count == 0)
                {
                    return true;
                }
            }

            if (responseData1 == null && responseData2 != null && responseData2.Items.Count == 0)
            {
                return true;
            }

            UpdateCollectionRequestData updateRequestData = new UpdateCollectionRequestData();
            updateRequestData.IDOName = "SL.SLJobTrans";
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
                IDORuntime.LogUserMessage("JobDispatcher.deleteUnProcessedRecords", UserDefinedMessageType.UserDefined1, "delete successful");
            }
            catch (Exception e)
            {
                IDORuntime.LogUserMessage("JobDispatcher.deleteUnProcessedRecords", UserDefinedMessageType.UserDefined1, "in exception block {0}", e.Message);
                //Console.WriteLine(e.Message);
                throw new Exception(e.Message);
            }
            return true;
        }

        private bool offsetPostedRecords(string employeeInput, string reportDateStart, string reportDateEnd, string startTime, string endTime, string IsProcessed, bool postOffSets, bool StopPostJobs)
        {
            //Console.WriteLine("In offset posting");
            IDORuntime.LogUserMessage("JobDispatcher.offsetPostedRecords", UserDefinedMessageType.UserDefined1, "inside offset posting");

            string employee = "";
            string reportDate = "";
            string job = "", transType = "", suffix = "", oper = "", workCenter = "", indirectCode = "", shift = "", payType = "", startTimeInSeconds = "",
                endTimeInSeconds = "", username = "", nextOper = "", RESID = "";
            double caltotalTimeInHours = 0;
            double qtyCompleted = 0;
            double qtyMoved = 0;
            double qtyScraped = 0;
            string reasoncode = "";
            string CompleteOper = "";
            DateTime reportStartDateTime = DateTime.ParseExact(reportDateStart + " " + startTime, "MMddyyyy HHmm", CultureInfo.CurrentCulture);
            DateTime reportEndDateTime = DateTime.ParseExact(reportDateEnd + " " + endTime, "MMddyyyy HHmm", CultureInfo.CurrentCulture);

            string stInSeconds = reportStartDateTime.TimeOfDay.TotalSeconds.ToString();
            string etInSeconds = reportEndDateTime.TimeOfDay.TotalSeconds.ToString();

            LoadCollectionResponseData responseData1 = null;
            LoadCollectionResponseData responseData2 = null;

            IDORuntime.LogUserMessage("JobDispatcher.offsetPostedRecords", UserDefinedMessageType.UserDefined1, "inside offset posting 2");


            if (reportDateStart.Equals(reportDateEnd))
            {
                LoadCollectionRequestData requestData1 = new LoadCollectionRequestData();
                requestData1.IDOName = "SL.SLJobTrans";
                requestData1.PropertyList.SetProperties("TransNum, RowPointer, RecordDate, EmpNum, TransDate, TransType, Job, Suffix, OperNum, IndCode,TransType,UserCode, Shift, Pay, PayRate,PrRate,JobRate, AHrs,StartTime, EndTime, Wc,QtyComplete,QtyMoved,QtyScrapped,ReasonCode,CompleteOp,NextOper,RESID");
                string filterString = "EmpNum = '" + employeeInput + "' and Posted='1'";
                filterString += " and TransDate ='" + reportStartDateTime.ToString(WMShortDatePattern) + "' "; //MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128
                filterString += " and StartTime >= '" + stInSeconds + "' and EndTime <= '" + etInSeconds + "' and CompleteOp <> '1' ";

                requestData1.Filter = filterString;
                //requestData1.RecordCap = -1;
                requestData1.RecordCap = 20000;
                requestData1.OrderBy = "TransNum";

                responseData1 = this.Context.Commands.LoadCollection(requestData1);
            }
            else
            {
                //previous day
                LoadCollectionRequestData requestData1 = new LoadCollectionRequestData();
                requestData1.IDOName = "SL.SLJobTrans";
                requestData1.PropertyList.SetProperties("TransNum, RowPointer, RecordDate, EmpNum, TransDate, TransType, Job, Suffix, OperNum, IndCode,TransType,UserCode, Shift, Pay, PayRate,PrRate,JobRate, AHrs,StartTime, EndTime, Wc,QtyComplete,QtyMoved,QtyScrapped,ReasonCode,CompleteOp,NextOper,RESID");
                string filterString = "EmpNum = '" + employeeInput + "' and Posted='1'";
                filterString += " and TransDate ='" + reportStartDateTime.ToString(WMShortDatePattern) + "' "; //MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128
                filterString += " and StartTime >= '" + stInSeconds + "' and EndTime <= '86340' and CompleteOp <> '1' ";

                requestData1.Filter = filterString;
                //requestData1.RecordCap = -1;
                requestData1.RecordCap = 20000;
                requestData1.OrderBy = "TransNum";

                responseData1 = this.Context.Commands.LoadCollection(requestData1);

                //next day
                LoadCollectionRequestData requestData2 = new LoadCollectionRequestData();
                requestData2.IDOName = "SL.SLJobTrans";
                requestData2.PropertyList.SetProperties("TransNum, RowPointer, RecordDate, EmpNum, TransDate, TransType, Job, Suffix, OperNum, IndCode,TransType,UserCode, Shift, Pay, PayRate,PrRate,JobRate, AHrs,StartTime, EndTime, Wc,QtyComplete,QtyMoved,QtyScrapped,ReasonCode,CompleteOp,NextOper,RESID");
                filterString = "EmpNum = '" + employeeInput + "' and Posted='1'";
                filterString += " and TransDate ='" + reportEndDateTime.ToString(WMShortDatePattern) + "' "; //MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128
                filterString += " and StartTime >= '0' and EndTime <= '" + etInSeconds + "' and CompleteOp <> '1'";

                requestData2.Filter = filterString;
                //requestData2.RecordCap = -1;
                requestData2.RecordCap = 20000;
                requestData2.OrderBy = "TransNum";

                responseData2 = this.Context.Commands.LoadCollection(requestData2);
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

            IDORuntime.LogUserMessage("JobDispatcher.offsetPostedRecords", UserDefinedMessageType.UserDefined1, "before remove dupliates");


            responseData1 = RemoveDuplicates(responseData1);

            IDORuntime.LogUserMessage("JobDispatcher.offsetPostedRecords", UserDefinedMessageType.UserDefined1, "after removeduplicates {0}", responseData1.Items.Count);


            for (int i = 0; i < responseData1.Items.Count; i++)
            {
                //assign values

                IDORuntime.LogUserMessage("JobDispatcher.offsetPostedRecords", UserDefinedMessageType.UserDefined1, "inside for loop {0}", i);

                employee = responseData1[i, "EmpNum"].Value;
                reportDate = responseData1[i, "TransDate"].Value;

                job = responseData1[i, "Job"].Value;
                /*if (job.Trim().Equals(""))
                {
                    transType = "21";
                }
                else
                {
                    transType = "22";
                }*/

                transType = GetTransTypeNumber(responseData1[i, "TransType"].Value);


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
                nextOper = responseData1[i, "NextOper"].Value;
                if (nextOper.Trim().Equals(""))
                {
                    nextOper = "0";
                }

                if (transType == "21") // Clearing value to compare indirect order
                {
                    suffix = "";
                    oper = "";
                    nextOper = "";
                }
                RESID = responseData1[i, "RESID"].Value;
                workCenter = responseData1[i, "Wc"].Value;
                indirectCode = responseData1[i, "IndCode"].Value;
                shift = responseData1[i, "Shift"].Value;
                payType = responseData1[i, "PayRate"].Value;

                startTimeInSeconds = responseData1[i, "StartTime"].Value;
                endTimeInSeconds = responseData1[i, "EndTime"].Value;
                IDORuntime.LogUserMessage("JobDispatcher.offsetPostedRecords", UserDefinedMessageType.UserDefined1, "inside for loop 2 {0},{1},{2},{3}",
                                        responseData1[i, "AHrs"].Value, responseData1[i, "QtyComplete"].Value, responseData1[i, "QtyMoved"].Value, responseData1[i, "QtyScrapped"].Value);

                try
                {
                    caltotalTimeInHours = Convert.ToDouble(responseData1[i, "AHrs"].Value, CultureInfo.InvariantCulture); // FTDEV-9247
                }
                catch (Exception)
                {

                }

                try
                {
                    if (responseData1[i, "QtyComplete"].Value != null && !(responseData1[i, "QtyComplete"].Value.Trim().Equals("")))
                    {
                        qtyCompleted = Convert.ToDouble(responseData1[i, "QtyComplete"].Value, CultureInfo.InvariantCulture); // FTDEV-9247
                    }
                }
                catch (Exception)
                {

                }

                try
                {
                    if (responseData1[i, "QtyMoved"].Value != null && !(responseData1[i, "QtyMoved"].Value.Trim().Equals("")))
                    {
                        qtyMoved = Convert.ToDouble(responseData1[i, "QtyMoved"].Value, CultureInfo.InvariantCulture); // FTDEV-9247
                    }
                }
                catch (Exception)
                {

                }

                try
                {
                    if (responseData1[i, "QtyScrapped"].Value != null && !(responseData1[i, "QtyScrapped"].Value.Trim().Equals("")))
                    {
                        qtyScraped = Convert.ToDouble(responseData1[i, "QtyScrapped"].Value, CultureInfo.InvariantCulture); // FTDEV-9247
                    }
                }
                catch (Exception)
                {

                }

                reasoncode = responseData1[i, "ReasonCode"].Value;
                CompleteOper = responseData1[i, "CompleteOp"].Value;
                if (CompleteOper == "")
                {
                    CompleteOper = "0";
                }
                username = responseData1[i, "UserCode"].Value;
                IDORuntime.LogUserMessage("JobDispatcher.offsetPostedRecords", UserDefinedMessageType.UserDefined1, "inside for loop 3 {0}", i);


                JobInfo matchingJob = new JobInfo();
                int matchingJobIndex = -1;



                if (CheckMatchingJob(employee, transType, job, suffix, oper, indirectCode, workCenter, startTimeInSeconds, endTimeInSeconds,
                        caltotalTimeInHours.ToString("0.00000000"), payType, qtyCompleted.ToString("0.00000000"), qtyMoved.ToString("0.00000000"),
                        qtyScraped.ToString("0.00000000"), reasoncode, CompleteOper, nextOper, RESID, out matchingJob, out matchingJobIndex, IsProcessed))
                {
                    if (matchingJobIndex != -1)
                    {
                        this.toPostJobList.RemoveAt(matchingJobIndex);
                    }
                    continue;
                }
                if (postOffSets == false)
                    continue;

                if (sRevertCompleteOperation.Equals("1") && transType == "22")
                {
                    //Check operation is complete
                    LoadCollectionRequestData requestData = new LoadCollectionRequestData();
                    requestData.IDOName = "SLJobRoutes";
                    requestData.PropertyList.SetProperties("RowPointer, RecordDate, Job,JobSuffix,OperNum,Complete");
                    string filterString = "Job = '" + job + "'   and JobSuffix ='" + suffix + "'  and OperNum ='" + oper + "' and Complete = 1 and JobStat = 'R'";


                    requestData.Filter = filterString;
                    requestData.RecordCap = 0;
                    requestData.OrderBy = "Job";
                    LoadCollectionResponseData JobResponseData;
                    JobResponseData = Context.Commands.LoadCollection(requestData);
                    if (JobResponseData != null && JobResponseData.Items.Count > 0)
                    {
                        UpdateCollectionRequestData updateContRequestData = new UpdateCollectionRequestData();
                        updateContRequestData.IDOName = "SLJobRoutes";
                        updateContRequestData.RefreshAfterUpdate = true;
                        IDOUpdateItem SlJobItem = new IDOUpdateItem();
                        SlJobItem.Action = UpdateAction.Update;
                        SlJobItem.ItemID = JobResponseData.Items[0].ItemID;
                        SlJobItem.ItemNumber = 0;
                        SlJobItem.Properties.Add("RowPointer", JobResponseData[0, "RowPointer"].Value, false);
                        SlJobItem.Properties.Add("RecordDate", JobResponseData[0, "RecordDate"].Value, false);

                        SlJobItem.Properties.Add("Complete", "0", true);
                        updateContRequestData.Items.Add(SlJobItem);
                        UpdateCollectionResponseData updateResponseData = null;
                        try
                        {
                            updateResponseData = Context.Commands.UpdateCollection(updateContRequestData);
                            //CompleteOper = "1";

                            JobInfo offsetJobInfo = new JobInfo();
                            offsetJobInfo.reportDate = reportDate;
                            offsetJobInfo.employee = employee;
                            offsetJobInfo.shift = shift;
                            offsetJobInfo.transType = transType;
                            offsetJobInfo.job = job;
                            offsetJobInfo.suffix = suffix;
                            offsetJobInfo.operation = oper;
                            offsetJobInfo.nextOper = nextOper;
                            offsetJobInfo.task = indirectCode;
                            offsetJobInfo.startTime = "0";
                            offsetJobInfo.endTime = "0";
                            offsetJobInfo.laborHrs = "0.00000000";
                            offsetJobInfo.payType = payType;
                            offsetJobInfo.workcenter = workCenter;
                            try
                            {
                                offsetJobInfo.qtyCompleted = "0.00000000";
                                offsetJobInfo.qtyMoved = "0.00000000";
                                offsetJobInfo.qtyRejected = "0.00000000";
                                offsetJobInfo.reasonCode = "";
                                offsetJobInfo.completeOper = "0";

                            }
                            catch { }
                            offsetJobInfo.RESID = "";
                            offsetJobInfo.donotpostHrs = "1";
                            toPostJobList.Add(offsetJobInfo);
                        }
                        catch (Exception)
                        {
                                
                        }

                    }
                            
                }

                if (IsProcessed == "1")
                {
                    LoadCollectionResponseData responseJobData = null;
                    LoadCollectionRequestData requestJobData = new LoadCollectionRequestData();
                    requestJobData.IDOName = "SL.SLJobRoutes";
                    requestJobData.PropertyList.SetProperties("Complete, Job, JobSuffix, OperNum");
                    string filterString = "Job = '" + job + "' ";
                    filterString += " and JobSuffix = '" + suffix + "' and OperNum = '" + oper + "' and Complete = 1 ";
                    requestJobData.Filter = filterString;
                    requestJobData.RecordCap = -1;
                    requestJobData.OrderBy = "Job";
                    responseJobData = this.Context.Commands.LoadCollection(requestJobData);
                    if (responseJobData.Items.Count > 0)
                    {

                        continue;
                    }
                }
                caltotalTimeInHours = -1 * caltotalTimeInHours;
                qtyCompleted = -1 * qtyCompleted;
                qtyMoved = -1 * qtyMoved;
                qtyScraped = -1 * qtyScraped;

                if (transType == "21")
                {
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

                }

                try
                {
                    /*Console.WriteLine("Performing Insert :" + reportDate + ":" + transType + ":" + employee + ":" + job + ":" + suffix
                        + ":" + oper + ":" + indirectCode + ":" + workCenter + ":" + shift + ":" + caltotalTimeInHours.ToString("0.00000000")
                        + ":" + payType + ":" + startTimeInSeconds + ":" + endTimeInSeconds);*/
                    if (CompleteOper == "1")
                    {
                        CompleteOper = "0";

                    }
                    IDORuntime.LogUserMessage("JobDispatcher.offsetRecords", UserDefinedMessageType.UserDefined1, "Offset posted records {0}", reportDate + ":" + transType + ":" + employee + ":" + job + ":" + suffix
                        + ":" + oper + ":" + indirectCode + ":" + workCenter + ":" + shift + ":" + caltotalTimeInHours.ToString("0.00000000")
                        + ":" + payType + ":" + startTime + ":" + endTime + ":");
                    PerformLaborUpdate(reportDate, transType, employee, job, suffix, oper, indirectCode,
                                                workCenter, shift, caltotalTimeInHours.ToString("0.00000000"), payType, startTimeInSeconds, endTimeInSeconds, qtyCompleted.ToString("0.00000000"), qtyMoved.ToString("0.00000000"), qtyScraped.ToString("0.00000000"), "", CompleteOper, nextOper, RESID, StopPostJobs);
                }
                catch (Exception)
                {
                    IDORuntime.LogUserMessage("JobDispatcher.offsetRecords", UserDefinedMessageType.UserDefined1, "Offset posted records {0}", reportDate + ":" + transType + ":" + employee + ":" + job + ":" + suffix
                        + ":" + oper + ":" + indirectCode + ":" + workCenter + ":" + shift + ":" + caltotalTimeInHours.ToString("0.00000000")
                        + ":" + payType + ":" + startTime + ":" + endTime + ":");
                    /*Console.WriteLine(reportDate + ":" + transType + ":" + employee + ":" + job + ":" + suffix
                        + ":" + oper + ":" + indirectCode + ":" + workCenter + ":" + shift + ":" + caltotalTimeInHours.ToString("0.00000000")
                        + ":" + payType + ":" + startTime + ":" + endTime + ":" + ex.Message);*/
                }
            }

            //Console.WriteLine("After offset. Hours count:: " + toPostJobList.Count);

            /*foreach (JobInfo jobInfo in toPostJobList)
            {
                Console.WriteLine("To Post List:: " + jobInfo.employee + ":" + jobInfo.transType + ":" + jobInfo.job + ":" + jobInfo.suffix
                            + ":" + jobInfo.operation + ":" + jobInfo.task
                             + ":" + jobInfo.workcenter + ":" + jobInfo.startTime
                             + ":" + jobInfo.endTime + ":" + jobInfo.laborHrs + ":" + jobInfo.payType);
            }*/
            return true;
        }

        private void AddToPostJob(InputDataSet.HoursLine hrsLine)
        {
            if (toPostJobList == null)
            {
                toPostJobList = new List<JobInfo>();
            }

            string startDate = hrsLine.GetValue("Startdate");
            DateTime reportDateTime = DateTime.ParseExact(startDate + " " + "0000", "MMddyyyy HHmm", CultureInfo.CurrentCulture);
            //startDate = reportDateTime.ToString("yyyy/MM/dd");

            string startTime = hrsLine.GetValue("Starttime");
            string endDate = hrsLine.GetValue("Enddate");
            string endTime = hrsLine.GetValue("Endtime");
            string totalTimeInMints = hrsLine.GetValue("ManTimeInMins"); ;
            double caltotalTimeInHours = Convert.ToDouble(totalTimeInMints, CultureInfo.InvariantCulture) / 60; // FTDEV-9247

            DateTime startDateTime = DateTime.ParseExact(startDate + " " + startTime, "MMddyyyy HHmm", CultureInfo.CurrentCulture);
            DateTime endDateTime = DateTime.ParseExact(endDate + " " + endTime, "MMddyyyy HHmm", CultureInfo.CurrentCulture);
            string startTimeInSeconds = startDateTime.TimeOfDay.TotalSeconds.ToString();
            string endTimeInSeconds = endDateTime.TimeOfDay.TotalSeconds.ToString();

            JobInfo jobInfo = new JobInfo();

            //jobInfo.reportDate = hrsLine.GetValue("ReportDate");
            jobInfo.reportDate = hrsLine.GetValue("Startdate");
            jobInfo.employee = formatDataByIDOAndPropertyName("SLEmployees", "EmpNum", hrsLine.GetValue("Employee"));
            jobInfo.transType = hrsLine.GetValue("TransType");
            jobInfo.job = hrsLine.GetValue("Job");
            jobInfo.suffix = hrsLine.GetValue("Suffix");
            jobInfo.operation = hrsLine.GetValue("Oper");
            jobInfo.task = hrsLine.GetValue("Task");
            jobInfo.workcenter = hrsLine.GetValue("Workcenter");
            jobInfo.startTime = startTimeInSeconds;
            jobInfo.endTime = endTimeInSeconds;
            jobInfo.laborHrs = caltotalTimeInHours.ToString("0.00000000", CultureInfo.InvariantCulture);
            jobInfo.payType = hrsLine.GetValue("PayType");
            jobInfo.shift = hrsLine.GetValue("Shift");

            jobInfo.hrsLine = hrsLine;

            try
            {
                jobInfo.qtyCompleted = hrsLine.GetValue("QtyReported");
                jobInfo.qtyMoved = hrsLine.GetValue("QtyMoved");
                jobInfo.qtyRejected = hrsLine.GetValue("QtyRejected");
                jobInfo.reasonCode = hrsLine.GetValue("ReasonCode");
                jobInfo.completeOper = hrsLine.GetValue("CompleteOper");

            }
            catch { }

            jobInfo.nextOper = hrsLine.GetValue("NextOper");
            jobInfo.RESID = hrsLine.GetValue("RESID");
            /*Console.WriteLine("Adding line to list:: " + jobInfo.employee + ":" + jobInfo.transType + ":" + jobInfo.job + ":" + jobInfo.suffix
                            + ":" + jobInfo.operation + ":" + jobInfo.task
                             + ":" + jobInfo.workcenter + ":" + jobInfo.startTime
                             + ":" + jobInfo.endTime + ":" + jobInfo.laborHrs + ":" + jobInfo.payType + ":" + jobInfo.nextOper+":"+jobInfo.RESID);*/

            toPostJobList.Add(jobInfo);
            inputList.Add(jobInfo);
        }

        private bool CheckMatchingJob(string localEmployee, string localTransType, string localJob, string localSuffix, string localOper, string localTask, string localWorkcenter,
                                string localStartTime, string localEndTime, string localLaborHours, string localPayType,
                                string qtyCompleted, string qtyMoved, string qtyRejected, string reasoncode, string completeoper, string localNextOper, string localRESID, out JobInfo matchingJob, out int matchingJobIndex, string IsProcessed)
        {
            matchingJob = new JobInfo();
            matchingJobIndex = -1;
            /*Console.WriteLine("Trying to match::" + localEmployee + ":" + localTransType + ":" + localJob + ":" + localSuffix + ":" + localOper + ":" + localTask
                             + ":" + localWorkcenter + ":" + localStartTime
                             + ":" + localEndTime + ":" + localLaborHours + ":" + localPayType + ":" + qtyCompleted + ":" + qtyMoved + ":" + qtyRejected + ":" + reasoncode + ":" + completeoper + ":" + localNextOper+":"+localRESID );*/

            for (int index = 0; index < this.toPostJobList.Count; index++)
            {
                JobInfo jobInfo = this.toPostJobList[index];
                if (qtyCompleted == "0.00000000")
                {
                    qtyCompleted = "";
                }
                if (qtyMoved == "0.00000000")
                {
                    qtyMoved = "";
                }
                if (qtyRejected == "0.00000000")
                {
                    qtyRejected = "";
                }

                if (jobInfo.qtyCompleted == "0.00000000")
                {
                    jobInfo.qtyCompleted = "";
                }
                if (jobInfo.qtyMoved == "0.00000000")
                {
                    jobInfo.qtyMoved = "";
                }
                if (jobInfo.qtyRejected == "0.00000000")
                {
                    jobInfo.qtyRejected = "";
                }

                if (jobInfo.laborHrs == "" && localLaborHours == "0.00000000")
                {
                    localLaborHours = "";

                }
                if (jobInfo.laborHrs == "0.00000000" && localLaborHours == "")
                {
                    localLaborHours = "0.00000000";

                }
                if (jobInfo.completeOper == "0" && (completeoper == "0" || completeoper == ""))
                {
                    completeoper = "0";
                }
                if (jobInfo.completeOper == "" && (completeoper == "0" || completeoper == ""))
                {
                    completeoper = "";
                }
                /*Console.WriteLine("Hours Line::" + jobInfo.employee + ":" + jobInfo.transType + ":" + jobInfo.job + ":" + jobInfo.suffix
                            + ":" + jobInfo.operation + ":" + jobInfo.task
                             + ":" + jobInfo.workcenter + ":" + jobInfo.startTime
                             + ":" + jobInfo.endTime + ":" + jobInfo.laborHrs + ":" + jobInfo.payType + ":" + jobInfo.qtyCompleted + ":" + jobInfo.qtyMoved + ":" + jobInfo.qtyRejected + ":" + jobInfo.reasonCode + ":" + jobInfo.completeOper + ":" + localNextOper+":"+localRESID );*/


                if (jobInfo.employee.Equals(localEmployee) && jobInfo.transType.Equals(localTransType) && jobInfo.job.Equals(localJob) && jobInfo.suffix.Equals(localSuffix)
                    && jobInfo.operation.Equals(localOper) && jobInfo.task.Equals(localTask) && jobInfo.workcenter.Equals(localWorkcenter)
                    && jobInfo.startTime.Equals(localStartTime) && jobInfo.endTime.Equals(localEndTime) && jobInfo.laborHrs.Equals(localLaborHours)
                     && jobInfo.qtyCompleted.Equals(qtyCompleted) && jobInfo.qtyMoved.Equals(qtyMoved) && jobInfo.qtyRejected.Equals(qtyRejected)
                     && jobInfo.reasonCode.Equals(reasoncode))
                {
                    if (IsProcessed == "1" && sRevertCompleteOperation == "0")
                    {
                        LoadCollectionResponseData responseJobData = null;
                        LoadCollectionRequestData requestJobData = new LoadCollectionRequestData();
                        requestJobData.IDOName = "SL.SLJobRoutes";
                        requestJobData.PropertyList.SetProperties("Complete, Job, JobSuffix, OperNum");
                        string filterString = "Job = '" + jobInfo.job + "' ";
                        filterString += " and JobSuffix = '" + jobInfo.suffix + "' and OperNum = '" + jobInfo.operation + "' and Complete = 1 ";
                        requestJobData.Filter = filterString;
                        requestJobData.RecordCap = -1;
                        requestJobData.OrderBy = "Job";
                        responseJobData = this.Context.Commands.LoadCollection(requestJobData);
                        if (responseJobData.Items.Count > 0)
                        {
                            matchingJob = jobInfo;
                            matchingJobIndex = index;
                            this.toPostJobList.RemoveAt(matchingJobIndex);
                            continue;
                        }
                    }
                    if (!jobInfo.transType.Equals("24"))
                    {
                        if (jobInfo.payType.Equals(localPayType))
                        {
                            //Console.WriteLine("Found matching Job index :: " + index);
                            matchingJob = jobInfo;
                            matchingJobIndex = index;
                            return true;
                        }
                    }
                    else
                    {
                        //Console.WriteLine("Found matching Job index :: " + index);
                        matchingJob = jobInfo;
                        matchingJobIndex = index;
                        return true;
                    }
                }
            }

            return false;
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
            string firstNextOper = "";
            string firstRESID = "";
            double firstqtyCompleted = 0;
            double firstqtyMoved = 0;
            double firstqtyRejected = 0;

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
            string secondNextOper = "";
            string secondRESID = "";
            double secondqtyCompleted = 0;
            double secondqtyMoved = 0;
            double secondqtyRejected = 0;

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
                /*if (firstJob.Trim().Equals(""))
                {
                    firstTransType = "21";
                }
                else
                {
                    firstTransType = "22";
                }*/

                firstTransType = GetTransTypeNumber(responseData[i, "TransType"].Value);

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

                if (firstTransType != "21" && responseData[i, "NextOper"] != null)
                {
                    firstNextOper = responseData[i, "NextOper"].Value;
                }

                if (firstNextOper.Trim().Equals(""))
                {
                    firstNextOper = "0";
                }
                firstRESID = responseData[i, "RESID"].Value;
                firstWorkCenter = responseData[i, "Wc"].Value;
                firstIndirectCode = responseData[i, "IndCode"].Value;
                firstShift = responseData[i, "Shift"].Value;
                firstPayType = responseData[i, "PayRate"].Value;

                firstStartTimeInSeconds = responseData[i, "StartTime"].Value;
                firstEndTimeInSeconds = responseData[i, "EndTime"].Value;
                firstRowPointer = responseData[i, "RowPointer"].Value;

                firstCaltotalTimeInHours = Convert.ToDouble(responseData[i, "AHrs"].Value, CultureInfo.InvariantCulture); // FTDEV-9247
                if (responseData[i, "QtyComplete"].Value != null && !(responseData[i, "QtyComplete"].Value.Trim().Equals("")))
                {
                    firstqtyCompleted = Convert.ToDouble(responseData[i, "QtyComplete"].Value, CultureInfo.InvariantCulture); // FTDEV-9247
                }
                if (responseData[i, "QtyMoved"].Value != null && !(responseData[i, "QtyMoved"].Value.Trim().Equals("")))
                {
                    firstqtyMoved = Convert.ToDouble(responseData[i, "QtyMoved"].Value, CultureInfo.InvariantCulture); // FTDEV-9247
                }
                if (responseData[i, "QtyScrapped"].Value != null && !(responseData[i, "QtyScrapped"].Value.Trim().Equals("")))
                {
                    firstqtyRejected = Convert.ToDouble(responseData[i, "QtyScrapped"].Value, CultureInfo.InvariantCulture); // FTDEV-9247
                }
                for (int secondIndex = i + 1; secondIndex < responseData.Items.Count; secondIndex++)
                {
                    if (duplicateList.IndexOf(responseData[secondIndex, "RowPointer"].Value) != -1)
                    {
                        continue;
                    }

                    secondEmployee = responseData[secondIndex, "EmpNum"].Value;
                    secondReportDate = responseData[secondIndex, "TransDate"].Value;

                    secondJob = responseData[secondIndex, "Job"].Value;
                    /*if (secondJob.Trim().Equals(""))
                    {
                        secondTransType = "21";
                    }
                    else
                    {
                        secondTransType = "22";
                    }*/

                    secondTransType = GetTransTypeNumber(responseData[secondIndex, "TransType"].Value);

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

                    if (secondTransType != "21" && responseData[secondIndex, "NextOper"] != null)
                    {
                        secondNextOper = responseData[secondIndex, "NextOper"].Value;
                    }
                    if (secondNextOper.Trim().Equals(""))
                    {
                        secondNextOper = "0";
                    }
                    secondRESID = responseData[secondIndex, "RESID"].Value;
                    secondWorkCenter = responseData[secondIndex, "Wc"].Value;
                    secondIndirectCode = responseData[secondIndex, "IndCode"].Value;
                    secondShift = responseData[secondIndex, "Shift"].Value;
                    secondPayType = responseData[secondIndex, "PayRate"].Value;

                    secondStartTimeInSeconds = responseData[secondIndex, "StartTime"].Value;
                    secondEndTimeInSeconds = responseData[secondIndex, "EndTime"].Value;

                    secondRowPointer = responseData[secondIndex, "RowPointer"].Value;

                    secondCaltotalTimeInHours = Convert.ToDouble(responseData[secondIndex, "AHrs"].Value, CultureInfo.InvariantCulture); // FTDEV-9247
                    if (responseData[secondIndex, "QtyComplete"].Value != null && !(responseData[secondIndex, "QtyComplete"].Value.Trim().Equals("")))
                    {
                        secondqtyCompleted = Convert.ToDouble(responseData[secondIndex, "QtyComplete"].Value, CultureInfo.InvariantCulture); // FTDEV-9247
                    }
                    if (responseData[secondIndex, "QtyMoved"].Value != null && !(responseData[secondIndex, "QtyMoved"].Value.Trim().Equals("")))
                    {
                        secondqtyMoved = Convert.ToDouble(responseData[secondIndex, "QtyMoved"].Value, CultureInfo.InvariantCulture); // FTDEV-9247
                    }
                    if (responseData[secondIndex, "QtyScrapped"].Value != null && !(responseData[secondIndex, "QtyScrapped"].Value.Trim().Equals("")))
                    {
                        secondqtyRejected = Convert.ToDouble(responseData[secondIndex, "QtyScrapped"].Value, CultureInfo.InvariantCulture); // FTDEV-9247
                    }
                    if (firstEmployee.Equals(secondEmployee) && firstReportDate.Equals(secondReportDate)
                        && firstJob.Equals(secondJob) && firstTransType.Equals(secondTransType)
                        && firstSuffix.Equals(secondSuffix) && firstOper.Equals(secondOper) && firstNextOper.Equals(secondNextOper) && firstRESID.Equals(secondRESID)
                        && firstWorkCenter.Equals(secondWorkCenter) && firstIndirectCode.Equals(secondIndirectCode)
                        && firstShift.Equals(secondShift) && firstPayType.Equals(secondPayType)
                        && firstStartTimeInSeconds.Equals(secondStartTimeInSeconds)
                        && firstEndTimeInSeconds.Equals(secondEndTimeInSeconds)
                        && (firstCaltotalTimeInHours * -1 == secondCaltotalTimeInHours)
                        && (firstqtyCompleted * -1 == secondqtyCompleted) && (firstqtyMoved * -1 == secondqtyMoved)
                        && (firstqtyRejected * -1 == secondqtyRejected))
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

        private string GetTransTypeNumber(string TransTypeString)
        {
            if (TransTypeString.Equals("I"))
            {
                return "21";
            }
            else if (TransTypeString.Equals("R"))
            {
                return "22";
            }
            else if (TransTypeString.Equals("S"))
            {
                return "23";
            }
            else if (TransTypeString.Equals("C"))
            {
                return "24";
            }
            return "";
        }
        #endregion
    }
}
