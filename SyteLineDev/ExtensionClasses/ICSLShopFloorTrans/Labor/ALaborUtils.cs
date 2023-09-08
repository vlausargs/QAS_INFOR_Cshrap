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
    public abstract class ALaborUtils : ShopFloorUtilities
    {
        public new LoadCollectionResponseData employeeResponseData = null;
        public new LoadCollectionResponseData workcenterResponseData = null;
        public string errorMessage = "";
        public new LoadCollectionResponseData ValidateJob(string job, string suffix)
        {
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLJobs";

            requestData.PropertyList.SetProperties("Job, Suffix, Item,ItemDescription,ItemLotTracked,ItemSerialTracked,Whse,QtyComplete,QtyReleased,QtyScrapped,DerNewStatus,Stat");

            string filterString = "Job = '" + IDOStrFormat(job) + "' and Suffix ='" + suffix + "'";//MSF165152 added formating to handle special charcters JH:20130717

            requestData.Filter = filterString;
            requestData.RecordCap = 1;
            requestData.OrderBy = "Job";
            LoadCollectionResponseData responseData = this.Context.Commands.LoadCollection(requestData);
            return responseData;
        }

        public InvokeResponseData JobtranJobValidSp(string Type, string Job, string Suffix, string OperNum)
        {

            object[] inputValues; //added for SL9 Qualification.  JH:20130809
            //int paramcount = 0; //added for SL9 Qualification.  JH:20130809
           // paramcount = GetIDOMethodParameterCount("SLJobTrans", "JobtranJobValidSp");
            //Console.WriteLine("ALaborUtils: JobtranJobValidSp paramcount = " + paramcount);
            //switch (paramcount)
            //{
            //    case 48:
            //        #region 48 values
                    inputValues = new object[]{
                                                Type,
                                                Job,
                                                Job,
                                                Suffix,
                                                Suffix,
                                                OperNum,
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
                                                "",
                                                "",
                                                "", // new field for 8.03.10
                                                "", // new input for 9.00.00 JH:20130809
                                                "", // new input for 9.00.00 JH:20130809
                                                "", // new input for 9.00.00 JH:20130809
                                                "",  // new input for 9.00.00 JH:20130809
                                                "",
                                                ""  // for new input NewOldJob
                                                };
                //    break;
                //#endregion
                //case 47:
                //    #region 47 values
                //    inputValues = new object[]{
                //                                Type,
                //                                Job,
                //                                Job,
                //                                Suffix,
                //                                Suffix,
                //                                OperNum,
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "", // new field for 8.03.10
                //                                "", // new input for 9.00.00 JH:20130809
                //                                "", // new input for 9.00.00 JH:20130809
                //                                "", // new input for 9.00.00 JH:20130809
                //                                "",  // new input for 9.00.00 JH:20130809
                //                                ""
                //                                };
                //    break;
                //#endregion
                //case 46:  //added for SL9 Qualification JH:20130809
                //    #region 46 values
                //    inputValues = new object[]{//46
                //                                Type,
                //                                Job,
                //                                Job,
                //                                Suffix,
                //                                Suffix,
                //                                OperNum,
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                //1
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                //2
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                //3
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                //4
                //                                "",
                //                                "", // new input for 8.03.10 
                //                                "", // new input for 9.00.00 JH:20130809
                //                                "", // new input for 9.00.00 JH:20130809
                //                                "", // new input for 9.00.00 JH:20130809
                //                                ""  // new input for 9.00.00 JH:20130809
                //                                };
                //    #endregion
                //    break;
                //case 42:  //added for SL9 Qualification JH:20130809
                //    #region 42 values
                //    inputValues = new object[]{//42
                //                                Type,
                //                                Job,
                //                                Job,
                //                                Suffix,
                //                                Suffix,
                //                                OperNum,
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                //1
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                //2
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                //3
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                //4
                //                                "",
                //                                "" // new input for 8.03.10 
                //                                };
                //    #endregion
                //    break;
                //case 43:
                //    #region 43 values
                //    inputValues = new object[]{
                //                                Type,
                //                                Job,
                //                                Job,
                //                                Suffix,
                //                                Suffix,
                //                                OperNum,
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                //1
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                //2
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                //3
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                //4
                //                                "",
                //                                "", // new field for 8.03.10
                //                                ""
                //                                };
                //    #endregion
                //    break;
                //case 41:
                //default: //as orignially released.
                //    #region 41 values
                //    inputValues = new object[]{//41
                //                                Type,
                //                                Job,
                //                                Job,
                //                                Suffix,
                //                                Suffix,
                //                                OperNum,
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                //1
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                //2
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                //3
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                "",
                //                                //4
                //                                ""

                //                                };
                //    #endregion
                //    break;
            //}

            InvokeResponseData responseData = InvokeIDO("SLJobTrans", "JobtranJobValidSp", inputValues);
            if (!responseData.ReturnValue.Equals("0"))
            {
                errorMessage = responseData.Parameters.ElementAt(32).ToString();
            }
            return responseData;
        }

        public new bool ValidateJobOper(string job, string suffix, string oper)
        {
            string PropertiesList = "";
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLJobRoutes";
            PropertiesList = PropertiesList + "Job,Suffix,ItmItem,ItmDescription,QtyComplete,QtyMoved,QtyScrapped,QtyReceived, ";
            PropertiesList = PropertiesList + "PsStat,Type,Wc,WcDescription,Complete";
            requestData.PropertyList.SetProperties(PropertiesList);

            string filterString = "Job = '" + IDOStrFormat(job) + "' and Suffix = '" + suffix + "'";//MSF165152 added formating to handle special charcters JH:20130717
            filterString += " and OperNum ='" + oper + "' ";

            requestData.Filter = filterString;
            requestData.RecordCap = 0;
            requestData.OrderBy = "Job,Suffix,OperNum";

            LoadCollectionResponseData responseData = this.Context.Commands.LoadCollection(requestData);

            if (responseData == null || responseData.Items.Count == 0)
            {
                return false;
            }
            return true;
        }

        public InvokeResponseData JobtranOperNumValidSp(string Type, string Job, string Suffix, string OperNum, string workcenter)
        {
            object[] inputValues = null;
            //int paramcount = 0;
            //paramcount = GetIDOMethodParameterCount("SLJobTrans", "JobtranOperNumValidSp");
            //switch (paramcount)
            //{
            //    case 19:
                    inputValues = new object[]{//19
                                                Type,
                                                Job,
                                                Suffix,
                                                OperNum,
                                                "0",
                                                "",
                                                workcenter,
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
                                                "0"
                                                };
            //        break;
            //    default:
            //        inputValues = new object[]{//18
            //                                    Type,
            //                                    Job,
            //                                    Suffix,
            //                                    OperNum,
            //                                    "0",
            //                                    "",
            //                                    workcenter,
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
            //        break;
            //}

            InvokeResponseData responseData = InvokeIDO("SLJobTrans", "JobtranOperNumValidSp", inputValues);
            if (!responseData.ReturnValue.Equals("0"))
            {
                errorMessage = responseData.Parameters.ElementAt(17).ToString();
            }
            return responseData;
        }

        public new bool ValidateWorkCenter(string workCenter)
        {
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLWcs";
            requestData.PropertyList.SetProperties("Wc, Description");
            string filterString = "Wc = '" + IDOStrFormat(workCenter) + "'";//MSF165152 added formating to handle special charcters JH:20130717

            requestData.Filter = filterString;
            requestData.RecordCap = 1;
            requestData.OrderBy = "Wc";

            workcenterResponseData = this.Context.Commands.LoadCollection(requestData);

            if (workcenterResponseData == null || workcenterResponseData.Items.Count == 0)
            {
                errorMessage = "Workcenter details Not Found";
                return false;
            }
            return true;
        }

        public InvokeResponseData GetItemByJobSp(string Job, string Suffix)
        {
            //int paramcount = 0;
            object[] inputValues = null;
            //paramcount = GetIDOMethodParameterCount("SLJobTrans", "GetItemByJobSp");
            ////Console.WriteLine("SLJobTrans, GetItemByJobSp paramcount = " + paramcount);
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
            //    case 14:                            //MSF189598  Code update to handle extra parameters being added for SL9.00.20  
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

        public InvokeResponseData JobtranCalcRateSp(string payRate, string employee, string shift, string transDate)
        {
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

        public bool ValidateEmployee(string employee)
        {
            employeeResponseData = GetEmployeeDetails(employee);
            if (employeeResponseData.Items.Count == 0)
            {
                errorMessage = "Employee Details Not Found";
                return false;
            }
            return true;
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
                                                 "",
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

            return responseData;
        }

        #region DataCollection Job Grace methods



        /// <summary>
        /// Low level function to update a existing transaction end time
        /// </summary>
        /// <param name="transType">Labor  or Attend</param>        
        /// <param name="dtEnd">We only adjust the end time of existing records</param>
        /// <param name="RecordDate">Record Identifier</param>
        /// <param name="RowPointer">Record Identifier</param>
        /// <returns></returns>
        /// <remarks>
        ///     Labor transactions: we will allways be adjusting the records in the Unposted Job Transactions form/table
        /// </remarks>
        public bool UpdateTrans(string transType, DateTime dtEnd, string RecordDate, string RowPointer, string StartTimeSec = "")
        {
            bool retval = true;
            switch (transType.ToLower())
            {
                case "labor":
                    UpdateSLJobTransEndTime(dtEnd, RecordDate, RowPointer, StartTimeSec);
                    break;
                case "attend":
                    UpdateSLDctasTime(dtEnd, RecordDate, RowPointer);
                    break;
            }

            return retval;
        }

        public List<string> GetLastTrans(string employeeID, string transdate)
        {
            List<string> retval = new List<string> { };
            string lastTransType = "Labor", lastTransRecordDate = "", lastTransRowPointer = "", lastTransStartTime = "", lastTransEndTime = "", TransType = "", lastTransMachRowPointer = "", lastTransMachRecordDate = "";
            DateTime LaborEndTime = DateTime.MinValue, AttendanceEndTime = DateTime.MinValue;
            string strLaborEndTime = "", strAttendanceEndTime = "";

            LoadCollectionResponseData responseDataLabor, responseDataAttendance;

            responseDataLabor = GetSLJobTransbyEmployee(employeeID, transdate); //order by date time so oldest is at the end.
            responseDataAttendance = GetAttendanceRecordByEmployeeTransType(employeeID, "", transdate);

            if (responseDataLabor.Items.Count > 0)
            {

                //strLaborEndTime = responseDataLabor[responseDataLabor.Items.Count - 1, "TransDate"].Value;  //reuse laborendtime to create valid date string
                //strLaborEndTime = strLaborEndTime.Insert(4, "/");
                //strLaborEndTime = strLaborEndTime.Insert(7, "/");
                strLaborEndTime = transdate;
                try
                {//MSF157397: as a result of this issue we are adding a try catch and debug statement around date time conversions.  JH:20130128                       
                    LaborEndTime = Convert.ToDateTime(strLaborEndTime);
                }
                catch (Exception)
                {
                    //Console.WriteLine("ALaborUtils GetLastTrans date conversion exception: strLaborEndTime date converstion failed. strLaborEndTime: " + strLaborEndTime);
                    errorMessage = "Date Time Conversion Failed";

                }
                strLaborEndTime = responseDataLabor[responseDataLabor.Items.Count - 1, "EndTime"].Value;
                LaborEndTime = LaborEndTime.AddSeconds(Convert.ToDouble(strLaborEndTime, CultureInfo.InvariantCulture)); // FTDEV-9247
            }
            if (responseDataAttendance.Items.Count > 0)
            {
                strAttendanceEndTime = responseDataAttendance[responseDataAttendance.Items.Count - 1, "PostDate"].Value;  //reuse laborendtime to create valid date string
                strAttendanceEndTime = strAttendanceEndTime.Insert(4, "/");
                strAttendanceEndTime = strAttendanceEndTime.Insert(7, "/");
                try
                {//MSF157397: as a result of this issue we are adding a try catch and debug statement around date time conversions.  JH:20130212                       
                    AttendanceEndTime = Convert.ToDateTime(strAttendanceEndTime);
                }
                catch (Exception)
                {
                    //Console.WriteLine("ALaborUtils GetLastTrans date conversion exception: strAttendanceEndTime date converstion failed. strAttendanceEndTime: " + strAttendanceEndTime);
                    errorMessage = "Date Time Conversion Failed";

                }

                strAttendanceEndTime = responseDataAttendance[responseDataAttendance.Items.Count - 1, "PostTime"].Value;
                AttendanceEndTime = AttendanceEndTime.AddSeconds(Convert.ToDouble(strAttendanceEndTime, CultureInfo.InvariantCulture)); // FTDEV-9247
            }

            if (LaborEndTime.CompareTo(AttendanceEndTime) == 1)
            {//labor is the biggest record
                lastTransType = "labor";
                //lastTransEndTime = LaborEndTime.TimeOfDay.TotalSeconds.ToString();
                if (responseDataLabor.Items.Count > 0)
                {
                    lastTransEndTime = strLaborEndTime; // responseDataAttendance[responseDataAttendance.Items.Count - 1, "PostTime"].Value;
                    lastTransStartTime = responseDataLabor[responseDataLabor.Items.Count - 1, "StartTime"].Value;
                    lastTransRecordDate = responseDataLabor[responseDataLabor.Items.Count - 1, "RecordDate"].Value;
                    lastTransRowPointer = responseDataLabor[responseDataLabor.Items.Count - 1, "RowPointer"].Value;

                    if ((responseDataLabor.Items.Count - 2) >= 0)
                    {
                        if (responseDataLabor[responseDataLabor.Items.Count - 2, "TransType"].Value == "C")
                        {
                            ///we need the machine and the run records.
                            lastTransMachRecordDate = responseDataLabor[responseDataLabor.Items.Count - 2, "RecordDate"].Value;
                            lastTransMachRowPointer = responseDataLabor[responseDataLabor.Items.Count - 2, "RowPointer"].Value;
                        }
                    }

                    TransType = responseDataLabor[responseDataLabor.Items.Count - 1, "TransType"].Value;
                }
                else
                {//no records found so set the values so we can tell.
                    lastTransEndTime = strAttendanceEndTime; // responseDataLabor[responseDataLabor.Items.Count - 1, "EndTime"].Value;
                    lastTransRecordDate = null;
                    lastTransRowPointer = null;
                    TransType = "";
                }
            }
            else
            {//the attandance is the biggest record
                lastTransType = "attend";
                //lastTransEndTime = LaborEndTime.TimeOfDay.TotalSeconds.ToString();
                if (responseDataAttendance.Items.Count > 0)
                {
                    lastTransEndTime = strAttendanceEndTime; // responseDataLabor[responseDataLabor.Items.Count - 1, "EndTime"].Value;
                    lastTransRecordDate = responseDataAttendance[responseDataAttendance.Items.Count - 1, "RecordDate"].Value;
                    lastTransRowPointer = responseDataAttendance[responseDataAttendance.Items.Count - 1, "RowPointer"].Value;
                    TransType = responseDataAttendance[responseDataAttendance.Items.Count - 1, "TransType"].Value;
                }
                else
                {//no records found so set the values so we can tell.
                    lastTransEndTime = strAttendanceEndTime; // responseDataLabor[responseDataLabor.Items.Count - 1, "EndTime"].Value;
                    lastTransRecordDate = null;
                    lastTransRowPointer = null;
                    TransType = "";
                }
            }

            //DO NOT change the order of the values.  Calling methods expect the data in this order!
            retval.Add(lastTransType);      //0
            retval.Add(lastTransEndTime);   //1 string that represents the end time part of the date in seconds
            retval.Add(lastTransRecordDate);//2
            retval.Add(lastTransRowPointer);//3 
            retval.Add(TransType);          //4 the value for the TransType field stored in syteline
            retval.Add(lastTransMachRecordDate);//5
            retval.Add(lastTransMachRowPointer);//6 
            retval.Add(lastTransStartTime);//7  string that represents the start time part of the date in seconds.  For labor record only.

            return retval;
        }


        /// <summary>
        /// Method to calculate the total hours for the job transaction records pass in.
        /// </summary>
        /// <param name="data">SLJobTrans records used to calculate the total hours</param>
        /// <returns></returns>
        public double totalJobTranshrs(LoadCollectionResponseData data)
        {
            double retval = 0;
            string msg = "";
            for (int i = 0; data.Items.Count - 1 >= i; i++)
            {
                try
                {
                    if (data[i, "AHrs"].Value != "")
                    {
                        retval += Convert.ToDouble(data[i, "AHrs"].Value, CultureInfo.InvariantCulture); // FTDEV-9247
                    }
                }
                catch
                {
                    msg = data[i, "AHrs"].Value;
                }
            }
            return retval;
        }
        /// <summary>
        /// Get a list of job labor transaction for a employee on a given date
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="transDate">must be in the format yyyymmdd no '/'</param>
        /// <returns></returns>
        /// <remarks>
        ///   Made a few minor changes to allow this to replace GetJobTransByEmployeeJob method used in laborstart and laborstop
        ///   added RecordDate and RowPointer parameters to allow us to get a specific labor transaction.  2012/06/05: JH
        /// </remarks>
        public LoadCollectionResponseData GetSLJobTransbyEmployee(string employee, string transDate = "", string job = "", string posted = "0", string RecordDate = "", string RowPointer = "")
        {
            string filterString;
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            //string PostDate = DateTime.Now.Date.ToShortDateString();
            string PostDate = DateTime.Now.Date.ToString(WMShortDatePattern); //MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128         
            requestData.IDOName = "SLJobTrans";
            requestData.PropertyList.SetProperties("Job, TransNum, EmpNum, StartTime, EndTime, TransClass, TransDate, TransNum,TransType, DerEndJob, CompleteOp, Posted, RecordDate, RowPointer, EmpShift, Suffix, OperNum, Wc, QtyComplete, QtyMoved, QtyScrapped, ItemUM, ReasonCode, CompleteOp, Lot, Loc, Whse, IndCode, UserCode, PayRate ");
            filterString = "EmpNum = '" + employee + "'";   //filterString = "EmpNum = '" + employee + "' and Posted = '0' and TransDate = '" + transDate + "' ";
            //if(employee != "") {filterString = "EmpNum = '" + employee + "'";
            if (transDate != "") { filterString = filterString + " and TransDate = '" + transDate + "' "; }

            if (job != "") { filterString = filterString + " and Job = '" + IDOStrFormat(job) + "'"; }//MSF165152 added formating to handle special charcters JH:20130717
            if (posted != "") { filterString = filterString + " and Posted = '" + posted + "'"; }
            if (RecordDate != "") { filterString = filterString + " and RecordDate = '" + RecordDate + "'"; }
            if (RowPointer != "") { filterString = filterString + " and RowPointer = '" + RowPointer + "'"; }


            requestData.Filter = filterString;
            requestData.OrderBy = "EmpNum, TransDate, StartTime, EndTime, TransType";
            requestData.RecordCap = -1;

            return this.Context.Commands.LoadCollection(requestData);
        }
        public LoadCollectionResponseData GetSLJobTranshoursBydate(string date, string employee, string dateEnd = "")
        {
            string filterstring;
            LoadCollectionResponseData data;
            if (dateEnd != "")
            {
                filterstring = "EmpNum = '" + employee + "' and TransDate >= '" + date + "' and TransDate <= '" + dateEnd + "' and (TransType='R' or TransType='I' or TransType='S')";
            }
            else
            {
                filterstring = "EmpNum = '" + employee + "' and TransDate >= '" + date + "' and TransDate <= '" + date + "' and (TransType='R' or TransType='I' or TransType='S')";
            }



            data = GetSLJobTransbyfilter(filterstring);
            return data;
        }

        /// <summary>
        /// Given a date return the first day of the week(Sun-Sat).
        /// </summary>
        /// <param name="dtcurrent">A given day of the week</param>
        /// <returns>Datetime of the first day of the week.</returns>
        /// <remarks>
        /// Created: 2012/05/15     By: Jason Hammock
        /// This was created to be used in the pay basis calculations.
        /// </remarks>
        public DateTime Get1stDayofWeek(DateTime dtcurrent)
        {
            DateTime firstDayOfWeek = DateTime.MinValue;

            switch (dtcurrent.DayOfWeek)
            {
                #region day of week check
                case DayOfWeek.Sunday:
                    firstDayOfWeek = dtcurrent.AddDays(0);
                    break;
                case DayOfWeek.Monday:
                    firstDayOfWeek = dtcurrent.AddDays(-1);
                    break;
                case DayOfWeek.Tuesday:
                    firstDayOfWeek = dtcurrent.AddDays(-2);
                    break;
                case DayOfWeek.Wednesday:
                    firstDayOfWeek = dtcurrent.AddDays(-3);
                    break;
                case DayOfWeek.Thursday:
                    firstDayOfWeek = dtcurrent.AddDays(-4);
                    break;
                case DayOfWeek.Friday:
                    firstDayOfWeek = dtcurrent.AddDays(-5);
                    break;
                case DayOfWeek.Saturday:
                    firstDayOfWeek = dtcurrent.AddDays(-6);
                    break;
                default:
                    break;
                    #endregion
            }

            return firstDayOfWeek;
        }
        /// <summary>
        /// Get Job transaction records.  Using the filter provided and Order the records by OrderBy
        /// </summary>
        /// <param name="filterString"></param>
        /// <param name="OrderBy"></param>
        /// <returns></returns>
        /// <remarks>
        /// Created: 2012/05/11     By: Jason hammock
        /// This method can/should be a low level method that can be over loaded.
        /// </remarks>
        public LoadCollectionResponseData GetSLJobTransbyfilter(string filterString, string OrderBy = "")
        {
            //string filterString;
            string PropertiesList = "";
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            //string PostDate = DateTime.Now.Date.ToShortDateString();
            string PostDate = DateTime.Now.Date.ToString(WMShortDatePattern); //MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128
            requestData.IDOName = "SLJobTrans";
            PropertiesList = PropertiesList + "Job, TransNum, EmpNum, StartTime, EndTime, TransClass, TransDate, TransNum, ";
            PropertiesList = PropertiesList + "TransType, DerEndJob, CompleteOp, Posted, RecordDate, RowPointer, AHrs";

            requestData.PropertyList.SetProperties(PropertiesList);

            requestData.Filter = filterString;
            if (OrderBy == "")
            {
                requestData.OrderBy = "EmpNum, TransDate, StartTime, EndTime";
            }
            else
            {
                requestData.OrderBy = OrderBy;
            }
            requestData.RecordCap = -1;

            return this.Context.Commands.LoadCollection(requestData);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="transtype"></param>
        /// <param name="postdate"></param>
        /// <returns></returns>
        /// <remarks>
        ///   Replaces GetAttendanceRecordByEmployeeTransType method used in laborstart and laborstop
        /// </remarks>
        public LoadCollectionResponseData GetAttendanceRecordByEmployeeTransType(string employee, string transtype, string postdate)
        {
            string PropertiesList = "";
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLDctas";
            PropertiesList = PropertiesList + "TransNum, EmpNum, NoteExistsFlag, PostDate, PostTime, RowPointer,Shift, ";
            PropertiesList = PropertiesList + "Termid,InWorkflow,_ItemId,_ItemWarnings,EmpName,EmpShift,TransType,ErrorMessage, ";
            PropertiesList = PropertiesList + "Stat,Override,derTransTimeFmt,derPostTimeFmt, TransTime, TransDate, RecordDate, RowPointer";

            requestData.PropertyList.SetProperties(PropertiesList);
            string filterString = "EmpNum = '" + employee + "' ";
            if (transtype != "") { filterString = filterString + " and TransType= " + transtype; }
            if (postdate != "") { filterString = filterString + " and PostDate = '" + postdate + "'"; }

            requestData.Filter = filterString;
            requestData.OrderBy = "EmpNum, PostDate, PostTime";
            requestData.RecordCap = -1;

            return this.Context.Commands.LoadCollection(requestData);
        }

        public string UpdateSLDctasTime(DateTime dtEnd, string RecordDate, string RowPointer)
        {
            //string PostDate = DateTime.Now.Date.ToShortDateString();
            string PostDate = DateTime.Now.Date.ToString(WMShortDatePattern); //MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128

            UpdateCollectionRequestData updateRequestData = new UpdateCollectionRequestData();
            updateRequestData.IDOName = "SLDctas";
            updateRequestData.RefreshAfterUpdate = true;

            IDOUpdateItem updateItem = new IDOUpdateItem();
            updateItem.Action = UpdateAction.Update;
            updateItem.Properties.Add("EmpNum", "", false);
            updateItem.Properties.Add("PostDate", "", false);
            updateItem.Properties.Add("PostTime", dtEnd.TimeOfDay.TotalSeconds, true);


            updateItem.Properties.Add("RowPointer", RowPointer);
            updateItem.Properties.Add("RecordDate", RecordDate);


            updateRequestData.Items.Add(updateItem);

            try
            {
                UpdateCollectionResponseData updateResponseData = this.Context.Commands.UpdateCollection(updateRequestData);
                //Console.WriteLine(updateResponseData.ToXml());
            }
            catch (Exception ee)
            {
                errorMessage = "Update Failed " + ee.Message;
                //Console.WriteLine(ee.Message);
                return errorMessage;
            }
            return "";
        }

        public string UpdateSLJobTransEndTime(DateTime dtEnd, string RecordDate, string RowPointer, string StartTimeSec = "")
        {
            //string PostDate = DateTime.Now.Date.ToShortDateString();
            string PostDate = DateTime.Now.Date.ToString(WMShortDatePattern); //MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128
            double dblStartSec = 0, dblEndSec = 0, dblSec = 0;
            string strSec = "";

            UpdateCollectionRequestData updateRequestData = new UpdateCollectionRequestData();
            updateRequestData.IDOName = "SLJobTrans";
            updateRequestData.RefreshAfterUpdate = true;

            IDOUpdateItem updateItem = new IDOUpdateItem();
            updateItem.Action = UpdateAction.Update;
            updateItem.Properties.Add("Job", "", false);
            updateItem.Properties.Add("EmpNum", "", false);
            if (StartTimeSec != "")
            {//calculate the hours
                dblStartSec = Convert.ToDouble(StartTimeSec, CultureInfo.InvariantCulture); // FTDEV-9247
                dblEndSec = dtEnd.TimeOfDay.TotalSeconds;
                dblSec = dblEndSec - dblStartSec;
                strSec = (dblSec / 3600).ToString("#.###"); //convert sec to hours
                updateItem.Properties.Add("AHrs", HrNullCheck(strSec)); //MSF162514: total hours can not be null or "".  JH:20130528
            }
            updateItem.Properties.Add("EndTime", dtEnd.TimeOfDay.TotalSeconds, true);
            //updateItem.Properties.Add("TransClass", "");
            updateItem.Properties.Add("TransClass", "J"); //MSF161664 the transclass field was not being populated some of the time JH:20130506
            updateItem.Properties.Add("TransDate", "", false);
            updateItem.Properties.Add("TransNum", "", false);

            updateItem.Properties.Add("RowPointer", RowPointer);
            updateItem.Properties.Add("RecordDate", RecordDate);


            updateRequestData.Items.Add(updateItem);

            try
            {
                UpdateCollectionResponseData updateResponseData = this.Context.Commands.UpdateCollection(updateRequestData);
                //Console.WriteLine(updateResponseData.ToXml());
            }
            catch (Exception ee)
            {
                errorMessage = "Update Failed " + ee.Message;
                //Console.WriteLine(ee.Message);
                return errorMessage;
            }
            return "";
        }

        //get dc params: SLDcparms.GrcJob
        public LoadCollectionResponseData GetDCParams()
        {
            Initialize();

            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLDcparms";
            //job labor grace time. GrcMinJb
            //added fields: DayWeek, LimitOt, LimitDt for over time calculations 2012/05/11 JH
            requestData.PropertyList.SetProperties("GrcJob, GrcMinI,GrcMinO, GrcMinJb, DayWeek, LimitOt, LimitDt ");

            requestData.RecordCap = 0;
            return this.Context.Commands.LoadCollection(requestData);
        }

        public string GetDCJobGraceTime()
        {
            string retval = "";
            LoadCollectionResponseData dataDC;

            dataDC = GetDCParams();
            if (dataDC.Items.Count > 0)
            {//should allways have one record.
                retval = dataDC[0, "GrcMinJb"].Value;
            }

            return retval;

        }

        public new string GetEmployeeIndirectCode(String employee)
        {
            LoadCollectionResponseData Employeedata = null;
            string IndCode = "";
            Employeedata = GetEmployeeDetails(employee);
            try
            {
                IndCode = Employeedata[0, "IndCode"].Value; //1 = enabled
            }
            catch
            { IndCode = ""; }

            return IndCode;
        }

        public IDOUpdateItem copyUpdateItem(IDOUpdateItem orgUpdateItem)
        {
            IDOUpdateItem copy = new IDOUpdateItem();

            copy.Action = orgUpdateItem.Action;
            copy.ItemID = orgUpdateItem.ItemID;
            copy.ItemNumber = orgUpdateItem.ItemNumber;

            foreach (IDOUpdateProperty prop in orgUpdateItem.Properties)
            {
                IDOUpdateProperty copyprop;
                copyprop = new IDOUpdateProperty(prop.Name, prop.Value, prop.Modified);
                copy.Properties.Add(copyprop);
            }

            //copy.NestedUpdates.Add(orgUpdateItem.NestedUpdates.
            return copy;

        }
        #endregion

        /// <summary>
        /// Check to see if the hours is null or "" when this is true this method returns 0
        /// </summary>
        /// <param name="HoursIn"></param>
        /// <returns></returns>
        /// <remarks>
        /// Created: 05/28/2013     By: Jason Hammock
        /// MSF162514: In uposted Job transaction when the total hours is null and the record is posted Syteline zeroing out the 
        ///   Setup hours, run hours, and costing accumulative values for the operation.
        ///   All of the labor stop transactions the total hours should be zero or greater.  So when passing the total hours this 
        ///   method should be used.
        ///   Since labor start inserts records into the error table this check is only needed on the stop.
        /// </remarks>
        public string HrNullCheck(string HoursIn)
        {
            //Console.WriteLine("ALaborUtil.HrNullCheck Checking Hours for Null.");
            string retval = "0";
            if ((HoursIn != null) & (HoursIn != ""))
            {
                //Console.WriteLine("ALaborUtil.HrNullCheck Not Null.");
                retval = HoursIn;
            }
            return retval;
        }
    }
}