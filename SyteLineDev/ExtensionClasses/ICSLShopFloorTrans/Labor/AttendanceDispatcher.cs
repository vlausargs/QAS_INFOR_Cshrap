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
    class AttendanceDispatcher : ALaborUtils,DispatcherService 
    {
         List<AtendanceInfo> inputList = null;

         public AttendanceDispatcher(IIDOExtensionClassContext context)
        {
            this.Context = context;
        }

       // #region Dispatcher Methods

        public void Init()
        {
            base.Initialize();
            toPostAttendList = new List<AtendanceInfo>();
            inputList = new List<AtendanceInfo>();
            
        }

        private struct AtendanceInfo
        {
            //Employee~TransDate~TransTime~TransType~UserId~Shift~DeviceId
            public string employee;
            public string transDate;
            public string transTime;
            public string transType;
            public string userId;
            public string shift;
            public string deviceId;
            public InputDataSet.AttendanceLine  attendLine;
        } List<AtendanceInfo> toPostAttendList;

        public bool ProcessLaborUpdate(InputDataSet.MasterLine masterData, bool postOffSets, bool StopPostJobs)
        {
            return true;
        }
        public bool ProcessQtyUpdate(InputDataSet.QtyLine qtyData)
        {
            return true;
        }

        public bool ProcessLaborAttendance(InputDataSet.MasterLine masterData,bool postOffSets)
        {
            Init();
           

            foreach (InputDataSet.AttendanceLine attendLine in masterData.AttendanceLines)
            {
                AddToPostAttendance(attendLine);
            }
           
            if (PerformMasterChecks(masterData, postOffSets))
            {
                IDORuntime.LogUserMessage("AttendanceDispatcher.ProcessLaborAttendance", UserDefinedMessageType.UserDefined1, "After master checks");
                foreach (AtendanceInfo attendInfo in toPostAttendList)
                {
                    try
                    {
                        IDORuntime.LogUserMessage("AttendanceDispatcher.ProcessLaborAttendance", UserDefinedMessageType.UserDefined1, "Before PeformLabor update");

                        PerformAttendanceUpdate(attendInfo.employee, attendInfo.transDate, attendInfo.transTime, attendInfo.transType, attendInfo.userId, attendInfo.shift, attendInfo.deviceId);
                    }
                    catch (Exception ex)
                    {
                        attendInfo.attendLine.ErrorMessage = ex.Message;
                    }
                }
            }
           
            return true;
        }

        private void  AddToPostAttendance(InputDataSet.AttendanceLine attendLine)
        {
            //Employee~TransDate~TransTime~TransType~UserId~Shift~DeviceId

            //DateTime startDateTime = DateTime.ParseExact(startDate + " " + startTime, "MMddyyyy HHmm", CultureInfo.CurrentCulture);
            //DateTime transDateTime = DateTime.ParseExact(transDate + " " + "0000", "MMddyyyy HHmm", CultureInfo.CurrentCulture);
            if (toPostAttendList == null)
            {
                toPostAttendList = new List<AtendanceInfo>();
            }
            string employee= attendLine.GetValue("Employee");
            string transDate = attendLine.GetValue("TransDate");
            string transTime = attendLine.GetValue("TransTime");
            transTime = transTime.Replace(":", "");
            DateTime transDateTime = DateTime.ParseExact(transDate + " " + transTime, "MMddyyyy HHmm", CultureInfo.CurrentCulture);
            string transType = attendLine.GetValue("TransType");
            string userId = attendLine.GetValue("UserId");
            string shift = attendLine.GetValue("Shift");
            string deviceId = attendLine.GetValue("DeviceId");
            //string transDate= transDateTime.ToString("yyyy-MM-dd");
            
            AtendanceInfo attendInfo = new AtendanceInfo();
            attendInfo.employee = attendLine.GetValue("Employee");
            attendInfo.transDate = attendLine.GetValue("TransDate");
            attendInfo.transTime = attendLine.GetValue("TransTime");
            //attendInfo.transType = attendLine.GetValue("TransType");
            attendInfo.transType = GetSLPunchType(attendLine.GetValue("TransType"));
            attendInfo.userId = attendLine.GetValue("UserId");
            attendInfo.shift = attendLine.GetValue("Shift");
            attendInfo.deviceId = attendLine.GetValue("DeviceId");

            attendInfo.attendLine = attendLine;

            /*Console.WriteLine("Adding line to list:: " + attendInfo.employee + ":" + attendInfo.transDate + ":" + attendInfo.transTime + ":" + attendInfo.transType
                            + ":" + attendInfo.userId + ":" + attendInfo.shift + ":" + attendInfo.deviceId );*/

            toPostAttendList.Add(attendInfo);
            inputList.Add(attendInfo);

        }

        private bool PerformMasterChecks(InputDataSet.MasterLine masterLine, bool postOffSets)
        {
            string employee = masterLine.GetValue("Employee");
           //masterLine.AttendanceLines

            employee = formatDataByIDOAndPropertyName("SLEmployees", "EmpNum", employee);

            deleteDataForMaster(employee, masterLine, postOffSets);
            return true;
        }
        private bool deleteDataForMaster(string employee, InputDataSet.MasterLine masterLine, bool postOffSets)
        {
            string reportDate = ""; //DateTime.ParseExact(masterLine.GetValue("ReportDate"), "MMddyyyy", CultureInfo.CurrentCulture).ToString();

            DateTime reportDateTime = DateTime.ParseExact(masterLine.GetValue("ReportDate"), "MMddyyyy", CultureInfo.CurrentCulture);
            reportDate = reportDateTime.ToString("MMddyyyy");

            string reportDateStart = masterLine.GetValue("Startdate");
            string reportDateEnd = masterLine.GetValue("EndDate");
            string reportTimeStart = masterLine.GetValue("Starttime");
            string reportTimeEnd = masterLine.GetValue("Endtime");
            string IsProcessed = masterLine.GetValue("Processed");

            if (reportDateStart.Equals(reportDateEnd) && reportTimeStart.Equals(reportTimeEnd))
                return true;

            deleteUnProcessedRecords(employee,reportDate);

            if (postOffSets)
            {
              offsetPostedRecords(employee, reportDate);
            }
            return true;
        }


        private bool offsetPostedRecords(string employee, string reportDate)
        {
            //Console.WriteLine("In offset posting");

            
            string transType = "", transDateTime = "";
          

            DateTime reportDateTime = DateTime.ParseExact(reportDate + " " + "0000", "MMddyyyy HHmm", CultureInfo.CurrentCulture);
            DateTime reportDateStartTime = DateTime.ParseExact(reportDate + " " + "0000", "MMddyyyy HHmm", CultureInfo.CurrentCulture);
            DateTime reportDateEndTime = DateTime.ParseExact(reportDate + " " + "2359", "MMddyyyy HHmm", CultureInfo.CurrentCulture);

            LoadCollectionResponseData responseData1 = null;

            LoadCollectionRequestData requestData1 = new LoadCollectionRequestData();
            requestData1.IDOName = "SL.SLTimeatts";
            requestData1.PropertyList.SetProperties("EmpNum, TransDate, TransType,TransTime,TransNum, RowPointer, RecordDate");
            string filterString = "EmpNum = '" + employee + "'";
            filterString += " and TransDate > ='" + reportDateStartTime.ToString(WMFullDateTimePattern) + "' and TransDate < = '" + reportDateEndTime.ToString(WMFullDateTimePattern) + "'";
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
                    

                    transType = responseData1[i, "TransType"].Value;
                    transDateTime = responseData1[i, "TransDate"].Value;

                    AtendanceInfo matchingAttendanceRec = new AtendanceInfo();
                    int matchingAttendanceRecIndex = -1;

                    if (CheckMatchingAttendanceRecord(transType, transDateTime,out matchingAttendanceRec, out matchingAttendanceRecIndex))
                    {
                        if (matchingAttendanceRecIndex != -1)
                        {
                            this.toPostAttendList.RemoveAt(matchingAttendanceRecIndex);
                        }
                        continue;
                    }

                    
                }
                catch (Exception)
                {
                }
            }

            return true;
        }
        private LoadCollectionResponseData RemoveDuplicates(LoadCollectionResponseData responseData)
        {
           

            string fristTransType = "";
            string firstTransDateTime = "";
            string firstRowPointer = "";

            string secondTransType = "";
            string secondTransDateTime = "";
            string secondRowPointer = "";

            List<string> duplicateList = new List<string>(1);

            for (int i = 0; i < responseData.Items.Count; i++)
            {
                if (duplicateList.IndexOf(responseData[i, "RowPointer"].Value) != -1)
                {
                    continue;
                }


                fristTransType = responseData[i, "TransType"].Value;
                firstTransDateTime = responseData[i, "TransDate"].Value;
                firstRowPointer = responseData[i, "RowPointer"].Value;

                
                for (int secondIndex = i + 1; secondIndex < responseData.Items.Count; secondIndex++)
                {
                    if (duplicateList.IndexOf(responseData[secondIndex, "RowPointer"].Value) != -1)
                    {
                        continue;
                    }

                    secondTransType = responseData[secondIndex, "TransType"].Value;
                    secondTransDateTime = responseData[secondIndex, "TransDate"].Value;
                    secondRowPointer = responseData[secondIndex, "RowPointer"].Value;

                    if (fristTransType.Equals(secondTransType) && firstTransDateTime.Equals(secondTransDateTime)
                        && firstRowPointer.Equals(secondRowPointer) )
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

        private bool CheckMatchingAttendanceRecord(string localTransType, string localTransDateTime, out AtendanceInfo matchingAttendanceRec, out int matchingAttendanceRecIndex)
        {
            matchingAttendanceRec = new AtendanceInfo();
            matchingAttendanceRecIndex = -1;


            for (int index = 0; index < this.toPostAttendList.Count; index++)
            {
                AtendanceInfo attendanceInfo = this.toPostAttendList[index];
                DateTime transDateTimeFmt = DateTime.ParseExact(attendanceInfo.transDate + " " + attendanceInfo.transTime, "MMddyyyy HHmm", CultureInfo.CurrentCulture);
                DateTime localTransDateTimeFmt = DateTime.ParseExact(localTransDateTime, "yyyyMMdd HH:mm:ss.fff", CultureInfo.CurrentCulture);

                if (attendanceInfo.transType.Equals(localTransType) && transDateTimeFmt.Equals(localTransDateTimeFmt))
                {
                     //Console.WriteLine("Found matching Job index :: " + index);
                    matchingAttendanceRec = attendanceInfo;
                    matchingAttendanceRecIndex = index;
                    return true;
                }
            }

            return false;
        }

        


        private bool deleteUnProcessedRecords(string employee, string reportDate)
        {
            LoadCollectionResponseData responseData1 = null;
            LoadCollectionRequestData requestData1 = new LoadCollectionRequestData();
          
            DateTime reportDateTime = DateTime.ParseExact(reportDate + " " + "0000", "MMddyyyy HHmm", CultureInfo.CurrentCulture);
            requestData1.IDOName = "SL.SLDctas";
            requestData1.PropertyList.SetProperties("TransNum, RowPointer, RecordDate, EmpNum, TransDate, TransType,TransTime");
            string filterString = "EmpNum = '" + employee + "'";
            filterString += " and TransDate ='" + reportDateTime.ToString(WMShortDatePattern) + "' "; //MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128
            requestData1.Filter = filterString;
            requestData1.RecordCap = -1;
            requestData1.OrderBy = "TransNum";

            responseData1 = this.Context.Commands.LoadCollection(requestData1);
            UpdateCollectionRequestData updateRequestData = new UpdateCollectionRequestData();
            if (responseData1.Items.Count > 0)
            {
                //UpdateCollectionRequestData updateRequestData = new UpdateCollectionRequestData();
                updateRequestData.IDOName = "SL.SLDctas";
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
            }
            return true;
        }

        private string GetSLPunchType(string PunchTypeString)
        {

            string slPunchTypeStr = "";
            if (PunchTypeString == "1")
            {
                slPunchTypeStr = "1";
            }
            else if (PunchTypeString == "2")
            {
                slPunchTypeStr = "2";
            }
            else if (PunchTypeString == "8")
            {
                slPunchTypeStr = "4";
            }
            else if(PunchTypeString == "9")
            {
                slPunchTypeStr = "3";
            }
           
            else if (PunchTypeString == "10")
            {
                slPunchTypeStr = "6";
            }
            else if (PunchTypeString == "11")
            {
                slPunchTypeStr = "5";
            }
            return slPunchTypeStr;
        }
    
     
        public bool PerformAttendanceUpdate(string employee, string transDate, string transTime, string transType, string userId, string shift, string deviceId)
        {
            string Infobar = "";
            employee = formatDataByIDOAndPropertyName("SLEmployees", "EmpNum", employee);
            AttendanceUpdateDaoImpl attendanceUpdate = new AttendanceUpdateDaoImpl(employee, transDate, transTime, transType, userId, shift, deviceId);
            attendanceUpdate.Initialize();
            attendanceUpdate.SetContext(this.Context);
            attendanceUpdate.PerformUpdate(out Infobar);
            return true;
        }
        
    }
}
