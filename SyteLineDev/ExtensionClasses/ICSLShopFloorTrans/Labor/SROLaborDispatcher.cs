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
    public class SROLaborDispatcher : ALaborUtils, DispatcherService
    {
        private List<string> partnerIDs = null;

        #region Dispatcher Methods
        public SROLaborDispatcher(IIDOExtensionClassContext context)
        {
            this.Context = context;
            this.partnerIDs = new List<string>();
        }

        public bool ProcessLaborUpdate(InputDataSet.MasterLine masterData, bool postOffSets, bool StopPostJobs)
        {
            Initialize();
            toPostJobList = new List<JobInfo>();
            this.partnerIDs = new List<string>();

            foreach (InputDataSet.HoursLine hrsLine in masterData.SROHrsLines)
            {
                AddToPostJob(hrsLine);
                //string partnerID = hrsLine.GetValue("PartnerId");

                //if (!partnerIDs.Exists(id => id.Equals(partnerID)))
                //{
                //    partnerIDs.Add(partnerID);
                //}
            }

            LoadPartnerIdsByEmployee(masterData.GetValue("Employee"));

            foreach (string partnerID in partnerIDs)
            {
                if (PerformMasterChecks(partnerID, masterData, postOffSets))
                {
                    foreach (JobInfo jobInfo in toPostJobList)
                    {
                        if (jobInfo.partnerId != partnerID)
                        {
                            continue;
                        }

                        try
                        {

                            PerformLaborUpdate(jobInfo.partnerId, jobInfo.sroNum, jobInfo.sroLine, jobInfo.sroOper,
                                            jobInfo.startDateTime, jobInfo.endDateTime, jobInfo.hoursWorked, jobInfo.billHours,
                                            jobInfo.workCode, jobInfo.billCode);
                        }
                        catch (Exception ex)
                        {
                            jobInfo.hrsLine.ErrorMessage = ex.Message;
                        }
                    }
                }
            }
            return true;
        }

        private void LoadPartnerIdsByEmployee(string empNum)
        {
            empNum = formatDataByIDOAndPropertyName("SLEmployees", "EmpNum", empNum);

            if (partnerIDs == null)
            {
                partnerIDs = new List<string>();
            }
         LoadCollectionResponseData partnerResponseData = null;      
         LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "FTSLQueries";
            requestData.PropertyList.SetProperties("PartnerId,Name");           
            CustomLoadMethod customLoadMethod = new CustomLoadMethod();
            customLoadMethod.Name = "CLM_FTSLGetPartnerIdSp";
            InvokeParameterList parameterList = new InvokeParameterList();
            parameterList.Add(empNum);
            parameterList.Add("");
            customLoadMethod.Parameters = parameterList;
            requestData.CustomLoadMethod = customLoadMethod;
            requestData.RecordCap = -1;
            partnerResponseData = ExcuteQueryRequest(requestData);          
            for (int i = 0; i < partnerResponseData.Items.Count; i++)
            {
                partnerIDs.Add(partnerResponseData[i, "PartnerId"].Value);
            }
        }

        public bool ProcessQtyUpdate(InputDataSet.QtyLine qtyData)
        {
            return true;
        }
        #endregion

        #region Private methods

        private struct JobInfo
        {
            public string partnerId;
            public string sroNum;
            public string sroLine;
            public string sroOper;
            public string startDateTime;
            public string endDateTime;
            public string hoursWorked;
            public string billHours;
            public string workCode;
            public string billCode;

            public InputDataSet.HoursLine hrsLine;
        } List<JobInfo> toPostJobList;

        private bool PerformMasterChecks(string partnerID, InputDataSet.MasterLine masterLine, bool postOffSets)
        {
            deleteDataForMaster(partnerID, masterLine, postOffSets);
            return true;
        }

        private bool deleteDataForMaster(string partnerID, InputDataSet.MasterLine masterLine, bool postOffSets)
        {
            string reportDate = ""; //DateTime.ParseExact(masterLine.GetValue("ReportDate"), "MMddyyyy", CultureInfo.CurrentCulture).ToString();
            string[] rptDate = masterLine.GetValue("ReportDate").Split(' ');
            DateTime reportDateTime = DateTime.ParseExact(rptDate[0], "MMddyyyy", CultureInfo.CurrentCulture);
            reportDate = reportDateTime.ToString("MMddyyyy");

            string reportDateStart = masterLine.GetValue("Startdate");
            string reportDateEnd = masterLine.GetValue("EndDate");
            string reportTimeStart = masterLine.GetValue("Starttime");
            string reportTimeEnd = masterLine.GetValue("Endtime");

            if (reportDateStart.Equals(reportDateEnd) && reportTimeStart.Equals(reportTimeEnd))
                return true;

            deleteUnProcessedRecords(partnerID, reportDate);

            //if (postOffSets)//Msf Issue 217615
            //{
            //offsetPostedRecords(partnerID, reportDate, postOffSets);
            offsetPostedRecords(partnerID, reportDateStart, reportDateEnd, reportTimeStart, reportTimeEnd, postOffSets);
            //}
            return true;
        }

        private bool deleteUnProcessedRecords(string partnerID, string reportDate)
        {
            DateTime reportDateTime = DateTime.ParseExact(reportDate + " " + "0000", "MMddyyyy HHmm", CultureInfo.CurrentCulture);
            reportDate = reportDateTime.ToString("yyyy/MM/dd");

            LoadCollectionResponseData responseData1 = null;

            LoadCollectionRequestData requestData1 = new LoadCollectionRequestData();
            requestData1.IDOName = "FSSROLabors";
            requestData1.PropertyList.SetProperties("TransNum, RowPointer, RecordDate");
            string filterString = "PartnerId = '" + partnerID + "' and TransDate='" + reportDate + "' and Posted=0 and Type <> 'P'";

            requestData1.Filter = filterString;
            //requestData1.RecordCap = -1;
            requestData1.RecordCap = 20000;
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
            updateRequestData.IDOName = "FSSROLabors";
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
                //Console.WriteLine(e.Message);
                throw new Exception(e.Message);
            }
            return true;
        }

        private bool offsetPostedRecords(string partnerID, string reportDateStart, string reportDateEnd, string startTime, string endTime,  bool postOffSets)
        {
            //Console.WriteLine("In offset posting");

            string sroNum = "", sroLine = "", sroOper = "", startDate = "", endDate = "",  
                    hoursWorked = "", billedHours = "", workCode = "", billCode = "";

            //DateTime reportDateTime = DateTime.ParseExact(reportDate + " " + "0000", "MMddyyyy HHmm", CultureInfo.CurrentCulture);
            DateTime reportStartDateTime = DateTime.ParseExact(reportDateStart + " " + startTime, "MMddyyyy HHmm", CultureInfo.CurrentCulture);
            DateTime reportEndDateTime = DateTime.ParseExact(reportDateEnd + " " + endTime, "MMddyyyy HHmm", CultureInfo.CurrentCulture);
            
            DateTime stInSeconds = DateTime.ParseExact(reportDateEnd + " " + "0000", "MMddyyyy HHmm", CultureInfo.CurrentCulture);
            DateTime etInSeconds = DateTime.ParseExact(reportDateStart + " " + "2359", "MMddyyyy HHmm", CultureInfo.CurrentCulture);
            
            LoadCollectionResponseData responseData1 = null;
            LoadCollectionResponseData responseData2 = null;
            if (reportDateStart.Equals(reportDateEnd))
            {
                LoadCollectionRequestData requestData1 = new LoadCollectionRequestData();
                requestData1.IDOName = "FSSROLabors";
                requestData1.PropertyList.SetProperties(
                "SroNum, SroLine, SroOper, StartDate, StartTime, EndDate, EndTime, HrsWorked," +
                "HrsToBill, WorkCode, BillCode, TransNum, RowPointer, RecordDate");
                string filterString = "PartnerId = '" + partnerID + "' and TransDate='" + reportStartDateTime.ToString("yyyy/MM/dd") + "'";
                filterString += " and StartDate >= '" + reportStartDateTime.ToString("yyyy/MM/dd HH:mm", CultureInfo.InvariantCulture) + "' and EndDate <= '" + reportEndDateTime.ToString("yyyy/MM/dd HH:mm", CultureInfo.InvariantCulture) + "'";
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
                requestData1.IDOName = "FSSROLabors";
                requestData1.PropertyList.SetProperties(
                  "SroNum, SroLine, SroOper, StartDate, StartTime, EndDate, EndTime, HrsWorked," +
                  "HrsToBill, WorkCode, BillCode, TransNum, RowPointer, RecordDate");
                string filterString = "PartnerId = '" + partnerID + "'";
                filterString += " and TransDate ='" + reportStartDateTime.ToString("yyyy/MM/dd") + "' "; //MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128
                filterString += " and StartDate >= '" + reportStartDateTime.ToString("yyyy/MM/dd HH:mm", CultureInfo.InvariantCulture) + "' and EndDate <= '"+ etInSeconds.ToString("yyyy/MM/dd HH:mm", CultureInfo.InvariantCulture) + "' ";

                requestData1.Filter = filterString;
                requestData1.RecordCap = -1;
                requestData1.OrderBy = "TransNum";

                responseData1 = this.Context.Commands.LoadCollection(requestData1);

                //next day
                LoadCollectionRequestData requestData2 = new LoadCollectionRequestData();
                requestData2.IDOName = "FSSROLabors";
                requestData2.PropertyList.SetProperties(
                  "SroNum, SroLine, SroOper, StartDate, StartTime, EndDate, EndTime, HrsWorked," +
                  "HrsToBill, WorkCode, BillCode, TransNum, RowPointer, RecordDate");            
                string filterString1 = "PartnerId = '" + partnerID + "'";
                filterString1 += " and TransDate ='" + reportEndDateTime.ToString("yyyy/MM/dd") + "' "; //MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128
                filterString1 += " and StartDate >= '"+stInSeconds.ToString("yyyy/MM/dd HH:mm", CultureInfo.InvariantCulture) + "' and EndDate <= '" + reportEndDateTime.ToString("yyyy/MM/dd HH:mm", CultureInfo.InvariantCulture) + "'";

                requestData2.Filter = filterString1;
                requestData2.RecordCap = -1;
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


            responseData1 = RemoveDuplicates(responseData1);

            for (int i = 0; i < responseData1.Items.Count; i++)
            {
                /*
                  "SroNum, SroLine, SroOper, StartDate, StartTime, EndDate, EndTime, HrsWorked," +
                "HrsToBill, WorkCode, BillCode, TransNum, RowPointer, RecordDate")
                 */
                try
                {
                    sroNum = responseData1[i, "SroNum"].Value;
                    sroLine = responseData1[i, "SroLine"].Value;
                    sroOper = responseData1[i, "SroOper"].Value;
                    startDate = responseData1[i, "StartDate"].Value;
                    endDate = responseData1[i, "EndDate"].Value;
                    hoursWorked = responseData1[i, "HrsWorked"].Value;
                    billedHours = responseData1[i, "HrsToBill"].Value;
                    workCode = responseData1[i, "WorkCode"].Value;
                    billCode = responseData1[i, "BillCode"].Value;

                    JobInfo matchingJob = new JobInfo();
                    int matchingJobIndex = -1;

                    if (CheckMatchingJob(sroNum, sroLine, sroOper, startDate, endDate, hoursWorked, billedHours, 
                        workCode, billCode, out matchingJob, out matchingJobIndex))
                    {
                        if (matchingJobIndex != -1)
                        {
                            this.toPostJobList.RemoveAt(matchingJobIndex);
                        }
                        continue;
                    }
                    if (postOffSets == false)
                        continue;

                    decimal hrsWorked = Convert.ToDecimal(hoursWorked, CultureInfo.InvariantCulture); // FTDEV-9247
                    decimal hrsBilled = Convert.ToDecimal(billedHours, CultureInfo.InvariantCulture); // FTDEV-9247
                    hrsWorked = -1 * hrsWorked;
                    hrsBilled = -1 * hrsBilled;

                    /*
                     string partnerId, string sroNum, string sroLine, string sroOper,
                                        string startDateTime, string endDateTime, string hoursWorked, string billHours, 
                                        string workCode, string billCode
                     */

                    PerformLaborUpdate(partnerID, sroNum, sroLine, sroOper, startDate, endDate, hrsWorked.ToString(), hrsBilled.ToString(), workCode, billCode);
                }
                catch (Exception)
                {
                }
            }

            return true;
        }

        private LoadCollectionResponseData RemoveDuplicates(LoadCollectionResponseData responseData)
        {
            /*
                     string partnerId, string sroNum, string sroLine, string sroOper,
                                        string startDateTime, string endDateTime, string hoursWorked, string billHours, 
                                        string workCode, string billCode
             
                     */

            string firstSroNum = "";
            string firstSroLine = "";
            string firstSroOper = "";
            string firstStartDateTime = "";
            string firstEndDateTime = "";
            double firstHrsWorked = 0;
            double firstBillHrs = 0;
            string firstWorkCode = "";
            string firstBillCode = "";
            string firstRowPointer = "";

            string secondSroNum = "";
            string secondSroLine = "";
            string secondSroOper = "";
            string secondStartDateTime = "";
            string secondEndDateTime = "";
            double secondHrsWorked = 0;
            double secondBillHrs = 0;
            string secondWorkCode = "";
            string secondBillCode = "";
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
                firstSroNum = responseData[i, "SroNum"].Value;
                firstSroLine = responseData[i, "SroLine"].Value;
                firstSroOper = responseData[i, "SroOper"].Value;
                firstStartDateTime = responseData[i, "StartDate"].Value;
                firstEndDateTime = responseData[i, "EndDate"].Value;
                
                firstBillCode = responseData[i, "BillCode"].Value;
                firstWorkCode = responseData[i, "WorkCode"].Value;
                firstRowPointer = responseData[i, "RowPointer"].Value;

                firstHrsWorked = Convert.ToDouble(responseData[i, "HrsWorked"].Value, CultureInfo.InvariantCulture); // FTDEV-9247
                firstBillHrs = Convert.ToDouble(responseData[i, "HrsToBill"].Value, CultureInfo.InvariantCulture); // FTDEV-9247

                for (int secondIndex = i + 1; secondIndex < responseData.Items.Count; secondIndex++)
                {
                    if (duplicateList.IndexOf(responseData[secondIndex, "RowPointer"].Value) != -1)
                    {
                        continue;
                    }

                    secondSroNum = responseData[secondIndex, "SroNum"].Value;
                    secondSroLine = responseData[secondIndex, "SroLine"].Value;
                    secondSroOper = responseData[secondIndex, "SroOper"].Value;
                    secondStartDateTime = responseData[secondIndex, "StartDate"].Value;
                    secondEndDateTime = responseData[secondIndex, "EndDate"].Value;
                    secondBillCode = responseData[secondIndex, "BillCode"].Value;
                    secondWorkCode = responseData[secondIndex, "WorkCode"].Value;
                    secondRowPointer = responseData[secondIndex, "RowPointer"].Value;

                    secondHrsWorked = Convert.ToDouble(responseData[secondIndex, "HrsWorked"].Value, CultureInfo.InvariantCulture); // FTDEV-9247
                    secondBillHrs = Convert.ToDouble(responseData[secondIndex, "HrsToBill"].Value, CultureInfo.InvariantCulture); // FTDEV-9247

                    if (firstSroNum.Equals(secondSroNum) && firstSroLine.Equals(secondSroLine) 
                        && firstSroOper.Equals(secondSroOper) && firstStartDateTime.Equals(secondStartDateTime)
                        && firstEndDateTime.Equals(secondEndDateTime) 
                        && firstBillCode.Equals(secondBillCode) && firstWorkCode.Equals(secondWorkCode)
                        && (firstHrsWorked * -1 == secondHrsWorked) && firstBillHrs * -1 == secondBillHrs)
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

        private bool CheckMatchingJob(string localSroNum, string localSroLine, string localSroOper,
                                string localStartDateTime, string localEndDateTime, string localHoursWorked, 
                                string localBilledHours, string localWorkCode, string localBillCode, 
                                out JobInfo matchingJob, out int matchingJobIndex)
        {
            matchingJob = new JobInfo();
            matchingJobIndex = -1;

            
            for (int index = 0; index < this.toPostJobList.Count; index++)
            {
                JobInfo jobInfo = this.toPostJobList[index];
                if (jobInfo.billCode == "" && localBillCode != "")
                {
                    jobInfo.billCode = localBillCode;
                }

                if (jobInfo.sroNum.Equals(localSroNum) && jobInfo.sroLine.Equals(localSroLine) && jobInfo.sroOper.Equals(localSroOper)
                    && jobInfo.startDateTime.Equals(localStartDateTime) && jobInfo.endDateTime.Equals(localEndDateTime) 
                    && jobInfo.hoursWorked.Equals(localHoursWorked) && jobInfo.billHours.Equals(localBilledHours)
                    && jobInfo.workCode.Equals(localWorkCode) && jobInfo.billCode.Equals(localBillCode))
                {
                    //Console.WriteLine("Found matching Job index :: " + index);
                    matchingJob = jobInfo;
                    matchingJobIndex = index;
                    return true;
                }
            }

            return false;
        }

        private  LoadCollectionResponseData GetWorkCodeDetails(string WorkCode = "")
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
            
            jobInfo.partnerId = hrsLine.GetValue("PartnerId");
            jobInfo.sroNum = hrsLine.GetValue("Job");
            jobInfo.sroOper = hrsLine.GetValue("Oper");
            jobInfo.startDateTime = startDateTime.ToString("yyyyMMdd HH:mm:ss.000");
            jobInfo.endDateTime = endDateTime.ToString("yyyyMMdd HH:mm:ss.000");
            jobInfo.hoursWorked = caltotalTimeInHours.ToString("0.00000000",CultureInfo.InvariantCulture);
            jobInfo.billHours = caltotalTimeInHours.ToString("0.00000000",CultureInfo.InvariantCulture);
            if (string.IsNullOrEmpty(hrsLine.GetValue("WorkCode")))
            {
                LoadCollectionResponseData workcodes = GetWorkCodeDetails();
                if (workcodes.Items.Count > 0)
                {
                    // To avoid emplty or null values assigning default code because it gives an error at syteline side.
                    jobInfo.workCode = workcodes.Items.FirstOrDefault().PropertyValues[0].Value;
                }
            }
            else
            { jobInfo.workCode = hrsLine.GetValue("WorkCode"); }         
            jobInfo.billCode = hrsLine.GetValue("BillCode");
            jobInfo.sroLine = hrsLine.GetValue("SROLine");

            jobInfo.hrsLine = hrsLine;

            /*Console.WriteLine("Adding line to list:: " + jobInfo.partnerId + ":" + jobInfo.sroNum + ":" + jobInfo.sroOper + ":" + jobInfo.startDateTime
                            + ":" + jobInfo.endDateTime + ":" + jobInfo.hoursWorked
                             + ":" + jobInfo.billHours + ":" + jobInfo.workCode
                             + ":" + jobInfo.billCode);*/

            toPostJobList.Add(jobInfo);
        }


        private bool PerformLaborUpdate(string partnerId, string sroNum, string sroLine, string sroOper,
                                        string startDateTime, string endDateTime, string hoursWorked, string billHours, 
                                        string workCode, string billCode)
        {
            int retVal = 0;
            errorMessage  = "";
            
            SROLaborUpdate SroLaborUpdate = new SROLaborUpdate(partnerId, sroNum, sroLine, sroOper, startDateTime, endDateTime, hoursWorked, billHours, workCode, billCode);
            //The base class is initalized here rather than the derived class to avoid unintentionally clearing the context.
            SroLaborUpdate.Initialize();//Initilize the base class.
            SroLaborUpdate.SetContext(this.Context);
            retVal = SroLaborUpdate.PerformUpdate(out errorMessage);

            if (errorMessage != null && !(errorMessage.Trim().Equals("")))
            {
                throw new Exception(errorMessage);
            }

            return true;
        }

         
        #endregion
    }
}
