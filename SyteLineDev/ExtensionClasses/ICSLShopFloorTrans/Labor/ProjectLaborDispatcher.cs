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
    public class ProjectLaborDispatcher : ALaborUtils, DispatcherService
    {

        public ProjectLaborDispatcher(IIDOExtensionClassContext context)
        {
            this.Context = context;
        }

        #region Dispatcher Methods
        public bool ProcessLaborUpdate(InputDataSet.MasterLine masterData, bool postOffSets, bool StopPostJobs)
        {
            Initialize();
            toPostJobList = new List<JobInfo>(); ;

            foreach (InputDataSet.HoursLine hrsLine in masterData.ProjectHrsLines)
            {
                AddToPostJob(hrsLine);
            }

            if (PerformMasterChecks(masterData, postOffSets))
            {
                foreach (JobInfo jobInfo in toPostJobList)
                {
                    try
                    {

                        PerformLaborUpdate(jobInfo.reportDate, jobInfo.employee, jobInfo.job, jobInfo.task,
                                                    jobInfo.shift, jobInfo.laborHrs, jobInfo.payType, jobInfo.costCode);
                    }
                    catch (Exception ex)
                    {
                        jobInfo.hrsLine.ErrorMessage = ex.Message;
                    }
                }
            }
            return true;
        }

        public bool ProcessQtyUpdate(InputDataSet.QtyLine qtyData)
        {
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
            public string costCode;

            public InputDataSet.HoursLine hrsLine;
        } List<JobInfo> toPostJobList;

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

            jobInfo.reportDate = hrsLine.GetValue("ReportDate");
            jobInfo.employee = formatDataByIDOAndPropertyName("SLEmployees", "EmpNum", hrsLine.GetValue("Employee"));
            jobInfo.transType = hrsLine.GetValue("TransType");
            jobInfo.job = hrsLine.GetValue("Job");
            jobInfo.suffix = hrsLine.GetValue("Suffix");
            jobInfo.operation = hrsLine.GetValue("Oper");
            jobInfo.task = hrsLine.GetValue("Task");
            jobInfo.workcenter = hrsLine.GetValue("Workcenter");
            jobInfo.startTime = startTimeInSeconds;
            jobInfo.endTime = endTimeInSeconds;
            jobInfo.laborHrs = caltotalTimeInHours.ToString("0.00000000",CultureInfo.InvariantCulture);
            jobInfo.payType = hrsLine.GetValue("PayType");
            jobInfo.shift = hrsLine.GetValue("Shift");
            jobInfo.costCode = hrsLine.GetValue("CostCode");

            jobInfo.hrsLine = hrsLine;

            /*Console.WriteLine("Adding line to list:: " + jobInfo.employee + ":" + jobInfo.transType + ":" + jobInfo.job + ":" + jobInfo.suffix
                            + ":" + jobInfo.operation + ":" + jobInfo.task
                             + ":" + jobInfo.workcenter + ":" + jobInfo.startTime
                             + ":" + jobInfo.endTime + ":" + jobInfo.laborHrs + ":" + jobInfo.payType);*/

            toPostJobList.Add(jobInfo);
        }


        private bool PerformLaborUpdate(string reportDate, string employee, string job, string taskCode,
                                        string shift, string laborHrs, string payType, string costCode)
        {
            DateTime reportDateTime = DateTime.ParseExact(reportDate + " " + "0000", "MMddyyyy HHmm", CultureInfo.CurrentCulture);
            reportDate = reportDateTime.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture);
            string inforbar = "";

            ProjectLaborUpdateDaoImpl laborUpdate = new ProjectLaborUpdateDaoImpl(this.Context);
            Request laborUpdateRequest = new Request();

            laborUpdateRequest.SetFieldValue("employee", employee);
            laborUpdateRequest.SetFieldValue("shift", shift);
            laborUpdateRequest.SetFieldValue("payType", payType);
            laborUpdateRequest.SetFieldValue("project", job);
            laborUpdateRequest.SetFieldValue("task", taskCode);
            laborUpdateRequest.SetFieldValue("costCode", costCode);
            laborUpdateRequest.SetFieldValue("transDate", reportDate);
            laborUpdateRequest.SetFieldValue("totalHours", laborHrs);

            laborUpdateRequest.SetFieldValue("autoProcessHours", "false");

            if (laborUpdate.PerformUpdate(laborUpdateRequest, out inforbar) > 0)
            {
                throw new Exception(inforbar);
            }

            return true;
        }

        private bool PerformMasterChecks(InputDataSet.MasterLine masterLine, bool postOffSets)
        {
            string employee = masterLine.GetValue("Employee");

            employee = formatDataByIDOAndPropertyName("SLEmployees", "EmpNum", employee);

            deleteDataForMaster(employee, masterLine, postOffSets);
            return true;
        }

        private bool deleteDataForMaster(string employee, InputDataSet.MasterLine masterLine, bool postOffSets)
        {
            string reportDate = ""; //DateTime.ParseExact(masterLine.GetValue("ReportDate"), "MMddyyyy", CultureInfo.CurrentCulture).ToString();

            DateTime reportDateTime = DateTime.ParseExact(masterLine.GetValue("ReportDate"), "MMddyyyy", CultureInfo.CurrentCulture);
            reportDate = reportDateTime.ToString("MMddyyyy",CultureInfo.InvariantCulture);

            string reportDateStart = masterLine.GetValue("Startdate");
            string reportDateEnd = masterLine.GetValue("EndDate");
            string reportTimeStart = masterLine.GetValue("Starttime");
            string reportTimeEnd = masterLine.GetValue("Endtime");

            if (reportDateStart.Equals(reportDateEnd) && reportTimeStart.Equals(reportTimeEnd))
                return true;

            deleteUnProcessedRecords(employee, reportDate);

            //if (postOffSets)//Msf Issue 217615
            ///{
            offsetPostedRecords(employee, reportDate, postOffSets);
            //}
            return true;
        }

        private bool deleteUnProcessedRecords(string employee, string reportDate)
        {
            DateTime reportDateTime = DateTime.ParseExact(reportDate + " " + "0000", "MMddyyyy HHmm", CultureInfo.CurrentCulture);
            reportDate = reportDateTime.ToString("yyyy/MM/dd",CultureInfo.InvariantCulture);

            LoadCollectionResponseData responseData1 = null;

            LoadCollectionRequestData requestData1 = new LoadCollectionRequestData();
            requestData1.IDOName = "SLProjLabrs";
            requestData1.PropertyList.SetProperties("TransNum, RowPointer, RecordDate, EmpNum, TransDate");
            string filterString = "EmpNum = '" + employee + "' and TransDate='" + reportDate + "'";

            requestData1.Filter = filterString;
            requestData1.RecordCap = -1;
            requestData1.OrderBy = "TransNum";

            responseData1 = this.Context.Commands.LoadCollection(requestData1);


            if (responseData1 == null)
            {
                return true;
            }

            if (responseData1 != null && responseData1.Items.Count == 0)
            {
                return true;
            }


            UpdateCollectionRequestData updateRequestData = new UpdateCollectionRequestData();
            updateRequestData.IDOName = "SLProjLabrs";
            IDOUpdateItem updateItem = null;

            for (int i = 0; i < responseData1.Items.Count; i++)
            {
                updateItem = new IDOUpdateItem();
                updateItem.Action = UpdateAction.Delete;
                updateItem.Properties.Add("RecordDate", responseData1[i, "RecordDate"].ToString());
                updateItem.Properties.Add("RowPointer", responseData1[i, "RowPointer"].ToString());
                updateRequestData.Items.Add(updateItem);
            }

            try
            {
                UpdateCollectionResponseData updateResponeData = this.Context.Commands.UpdateCollection(updateRequestData);
                //Console.WriteLine("delete successful");
            }
            catch (Exception e)
            {
               // Console.WriteLine(e.Message);
                throw new Exception(e.Message);
            }
            return true;
        }

        private bool offsetPostedRecords(string employee, string reportDate,bool postOffSets)
        {
            //Console.WriteLine("In offset posting");

            string projNum = "", taskNum = "", costCode = "", shift = "";
            decimal hours = 0;

            DateTime reportDateTime = DateTime.ParseExact(reportDate + " " + "0000", "MMddyyyy HHmm", CultureInfo.CurrentCulture);

            LoadCollectionResponseData responseData1 = null;

            LoadCollectionRequestData requestData1 = new LoadCollectionRequestData();
            requestData1.IDOName = "SLProjTrans";
            requestData1.PropertyList.SetProperties("TransNum, RowPointer, RecordDate, TranDate, EmpNum, TranType, ProjNum, Shift, TaskNum, CostCode, Hours, ProjRate");
            string filterString = $"EmpNum = '{employee}' and TranDate='{reportDateTime:yyyy/MM/dd}' and TranType='L' and RefType='I'";

            requestData1.Filter = filterString;
            requestData1.RecordCap = -1;
            requestData1.OrderBy = "TransNum";

            responseData1 = this.Context.Commands.LoadCollection(requestData1);

            if (responseData1 == null)
            {
                return true;
            }
            else
            {
                if (responseData1.Items.Count == 0)
                {
                    return true;
                }
            }


            responseData1 = RemoveDuplicates(responseData1);

            for (int i = 0; i < responseData1.Items.Count; i++)
            {

                try
                {
                    projNum = responseData1[i, "ProjNum"].Value;
                    taskNum = responseData1[i, "TaskNum"].Value;
                    costCode = responseData1[i, "CostCode"].Value;
                    shift = responseData1[i, "Shift"].Value;
                    hours = Convert.ToDecimal(responseData1[i, "Hours"].Value, CultureInfo.InvariantCulture); // FTDEV-9247

                    JobInfo matchingJob = new JobInfo();
                    int matchingJobIndex = -1;

                    if (CheckMatchingJob(employee, reportDate, projNum, taskNum, costCode, shift, hours.ToString("0.00000000"), out matchingJob, out matchingJobIndex))
                    {
                        if (matchingJobIndex != -1)
                        {
                            this.toPostJobList.RemoveAt(matchingJobIndex);
                        }
                        continue;
                    }
                    if (postOffSets == false)
                        continue;

                    decimal projectHours = Convert.ToDecimal(responseData1[i, "Hours"].Value, CultureInfo.InvariantCulture); // FTDEV-9247
                    projectHours = -1 * projectHours;
                    PerformLaborUpdate(reportDate, employee, responseData1[i, "ProjNum"].Value, responseData1[i, "TaskNum"].Value,
                                        responseData1[i, "Shift"].Value, projectHours.ToString(), "R", responseData1[i, "CostCode"].Value);
                }
                catch (Exception)
                {
                    //Console.WriteLine(reportDate + ":" + employee + ex.Message);
                }
            }

           // Console.WriteLine("After offset. Hours count:: " + toPostJobList.Count);

            //foreach (JobInfo jobInfo in toPostJobList)
            //{
            //    Console.WriteLine("To Post List:: " + jobInfo.employee + ":" + jobInfo.transType + ":" + jobInfo.job + ":" + jobInfo.suffix
            //                + ":" + jobInfo.operation + ":" + jobInfo.task
            //                 + ":" + jobInfo.workcenter + ":" + jobInfo.startTime
            //                 + ":" + jobInfo.endTime + ":" + jobInfo.laborHrs + ":" + jobInfo.payType);
            //}

            return true;
        }

        private LoadCollectionResponseData RemoveDuplicates(LoadCollectionResponseData responseData)
        {
            /*
                     string partnerId, string sroNum, string sroLine, string sroOper,
                                        string startDateTime, string endDateTime, string hoursWorked, string billHours, 
                                        string workCode, string billCode
             * 
             * 
             * ProjNum, Shift, TaskNum, CostCode, Hours, ProjRate
             
                     */

            string firstProjNum = "";
            string firstShift = "";
            string firstTaskNum = "";
            string firstCostCode = "";
            double firstHours = 0;
            String firstProjRate = "";
            string firstRowPointer = "";

            string secondProjNum = "";
            string secondShift = "";
            string secondTaskNum = "";
            string secondCostCode = "";
            double secondHours = 0;
            String secondProjRate = "";
            string secondRowPointer = "";

            List<string> duplicateList = new List<string>(1);

            for (int i = 0; i < responseData.Items.Count; i++)
            {
                if (duplicateList.IndexOf(responseData[i, "RowPointer"].Value) != -1)
                {
                    continue;
                }

                /*
                  
                 * 
             * 
             * SroNum, SroLine, SroOper, StartDate, StartTime, EndDate, EndTime, HrsWorked," +
                "HrsToBill, WorkCode, BillCode, TransNum, RowPointer, RecordDate
                 * */
                //assign values
                firstProjNum = responseData[i, "ProjNum"].Value;
                firstShift = responseData[i, "Shift"].Value;
                firstTaskNum = responseData[i, "TaskNum"].Value;
                firstCostCode = responseData[i, "CostCode"].Value;
                firstProjRate = responseData[i, "ProjRate"].Value;
                firstRowPointer = responseData[i, "RowPointer"].Value;

                firstHours = Convert.ToDouble(responseData[i, "Hours"].Value, CultureInfo.InvariantCulture); // FTDEV-9247

                for (int secondIndex = i + 1; secondIndex < responseData.Items.Count; secondIndex++)
                {
                    if (duplicateList.IndexOf(responseData[secondIndex, "RowPointer"].Value) != -1)
                    {
                        continue;
                    }

                    secondProjNum = responseData[secondIndex, "ProjNum"].Value;
                    secondShift = responseData[secondIndex, "Shift"].Value;
                    secondTaskNum = responseData[secondIndex, "TaskNum"].Value;
                    secondCostCode = responseData[secondIndex, "CostCode"].Value;
                    secondProjRate = responseData[secondIndex, "ProjRate"].Value;
                    secondRowPointer = responseData[secondIndex, "RowPointer"].Value;

                    secondHours = Convert.ToDouble(responseData[secondIndex, "Hours"].Value, CultureInfo.InvariantCulture); // FTDEV-9247


                    if (firstProjNum.Equals(secondProjNum) && firstShift.Equals(secondShift)
                        && firstTaskNum.Equals(secondTaskNum) && firstCostCode.Equals(secondCostCode)
                           && firstProjRate.Equals(secondProjRate) 
                        && (firstHours * -1 == secondHours) )
                    {
                        duplicateList.Add(firstRowPointer);
                        duplicateList.Add(secondRowPointer);
                        break;
                    }
                }

            }

            //for (int listindex = 0; listindex < duplicateList.Count; listindex++)
            //{
            //    Console.WriteLine(" Row Pointer to delete:: " + duplicateList[listindex]);
            //}

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

            //for (int rdindex = 0; rdindex < responseData.Items.Count; rdindex++)
            //{
            //    Console.WriteLine("Remaining row pointers :: " + responseData[rdindex, "RowPointer"].Value);
            //}

            return responseData;
        }

        private bool CheckMatchingJob(string localEmployee, string localTranDate, string localProjNum, string localTaskNum, string localCostCode,
                                string localShift, string localLaborHours, out JobInfo matchingJob, out int matchingJobIndex)
        {
            matchingJob = new JobInfo();
            matchingJobIndex = -1;

            /*Console.WriteLine("Trying to match::" + localEmployee + ":" + localTranDate + ":" + localProjNum + ":" + localTaskNum + ":" + localCostCode + ":" + localShift
                             + ":" + localLaborHours);*/


            for (int index = 0; index < this.toPostJobList.Count; index++)
            {
                JobInfo jobInfo = this.toPostJobList[index];

                /*Console.WriteLine("Hours Line::" + jobInfo.employee + ":" + jobInfo.reportDate + ":" + jobInfo.job + ":" + jobInfo.task
                                    + jobInfo.laborHrs + ":" + jobInfo.shift + ":" + jobInfo.costCode);*/




                if (jobInfo.employee.Equals(localEmployee) && jobInfo.reportDate.Equals(localTranDate) && jobInfo.job.Equals(localProjNum)
                    && jobInfo.task.Equals(localTaskNum) && jobInfo.shift.Equals(localShift) && jobInfo.laborHrs.Equals(localLaborHours))
                {
                   // Console.WriteLine("Found matching Job index :: " + index);
                    matchingJob = jobInfo;
                    matchingJobIndex = index;
                    return true;
                }
            }

            return false;
        }

        #endregion
    }
}
