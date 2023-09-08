using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using System.Globalization;

namespace InforCollect.ERP.SL.ICSLTimeAttendanceTrans
{
    class TimeAttendanceUtilities : ICSLCommonLibrary
    {
        double RegRate = 0, OtRate = 0, DbltRate = 0, MfgRegRate = 0, MfgOtRate = 0, MfgDbltRate = 0;
        private string errorMessage = "";

        public LoadCollectionResponseData GetSLEmployeeDetails(string EmpNum)
        {
            LoadCollectionRequestData LoadRequestData = new LoadCollectionRequestData();
            LoadRequestData.IDOName = "SLEmployees";
            LoadRequestData.PropertyList.SetProperties("EmpNum,Name,Lname,ADate, TermDate, Shift, LunchAuto, IndCode, RegRate, OtRate, DtRate, MfgRegRate, MfgOtRate, MfgDtRate");
            string filterString = "EmpNum = '" + EmpNum + "'";
            LoadRequestData.Filter = filterString;
            LoadRequestData.RecordCap = 1;
            LoadRequestData.OrderBy = "EmpNum";

            return ExcuteQueryRequest(LoadRequestData);

        }

        public LoadCollectionResponseData GetShiftDetails(string shift)
        {
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLShifts";
            requestData.PropertyList.SetProperties("Shift,EffDate,GrcShiftI,GrcShiftO,GrcLunchI,GrcLunchO,ShiftStart_1,ShiftStart_2,ShiftStart_3,ShiftStart_4,ShiftStart_5,ShiftStart_6,ShiftStart_7,ShiftEnd_1,ShiftEnd_2,ShiftEnd_3,ShiftEnd_4,ShiftEnd_5,ShiftEnd_6,ShiftEnd_7,LunchStart_1,LunchStart_2,LunchStart_3,LunchStart_4,LunchStart_5,LunchStart_6,LunchStart_7,LunchEnd_1,LunchEnd_2,LunchEnd_3,LunchEnd_4,LunchEnd_5,LunchEnd_6,LunchEnd_7, ShiftHrs_1, ShiftHrs_2, ShiftHrs_3, ShiftHrs_4, ShiftHrs_5, ShiftHrs_6, ShiftHrs_7, LunchHrs_1, LunchHrs_2, LunchHrs_3, LunchHrs_4, LunchHrs_5, LunchHrs_6, LunchHrs_7");
            string filterString = "Shift = '" + shift + "'";
            requestData.Filter = filterString;
            requestData.RecordCap = 1;
            requestData.OrderBy = "Shift";
            return ExcuteQueryRequest(requestData);
        }

        public LoadCollectionResponseData GetLastRecordByEmployee(string EmpNum)
        {
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLDctas";
            requestData.PropertyList.SetProperties("TransNum, EmpNum, NoteExistsFlag, PostDate, PostTime, RowPointer,Shift,Termid,InWorkflow,_ItemId,_ItemWarnings,EmpName,EmpShift,TransType,ErrorMessage,Stat,Override,derTransTimeFmt,derPostTimeFmt, TransTime, TransDate");
            string filterString = "EmpNum = '" + EmpNum + "'";
            requestData.Filter = filterString;
            requestData.OrderBy = "PostDate DESC, PostTime DESC";
            requestData.RecordCap = 1;

            return ExcuteQueryRequest(requestData);
        }
        
        public List<string> GetLastTrans(string employeeID, string transdate, string ShiftStartDate)
        {
            List<string> retval = new List<string> { };
            string lastTransType = "Labor", lastTransRecordDate = "", lastTransacDate = "", lastTransRowPointer = "", lastTransStartTime = "", lastTransEndTime = "", TransType = "", lastTransMachRowPointer = "", lastTransMachRecordDate = "";
            DateTime LaborEndTime = DateTime.MinValue, AttendanceEndTime = DateTime.MinValue;
            string strLaborEndTime = "", strAttendanceEndTime = "";

            LoadCollectionResponseData responseDataLabor, responseDataAttendance;

            responseDataLabor = GetSLJobTransbyEmployee(employeeID, transdate, ShiftStartDate); //order by date time so oldest is at the end.
            if (Convert.ToDateTime(ShiftStartDate).Date < Convert.ToDateTime(transdate).Date)
                responseDataAttendance = GetAttendanceRecordByEmployeeTransType(employeeID, "", ShiftStartDate);
            else
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
                    errorMessage = constructErrorMessage("Date Time Conversion Failed", null, null);

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
                    errorMessage = constructErrorMessage("Date Time Conversion Failed", null, null);

                }

                strAttendanceEndTime = responseDataAttendance[responseDataAttendance.Items.Count - 1, "PostTime"].Value;
                AttendanceEndTime = AttendanceEndTime.AddSeconds(Convert.ToDouble(strAttendanceEndTime, CultureInfo.InvariantCulture)); // FTDEV-9247
            }

            if (LaborEndTime.CompareTo(AttendanceEndTime) == 1)
            {//labor is the biggest record
                lastTransType = "labor";
                lastTransEndTime = LaborEndTime.TimeOfDay.TotalSeconds.ToString();
                if (responseDataLabor.Items.Count > 0)
                {
                    lastTransEndTime = strLaborEndTime; // responseDataAttendance[responseDataAttendance.Items.Count - 1, "PostTime"].Value;
                    lastTransStartTime = responseDataLabor[responseDataLabor.Items.Count - 1, "StartTime"].Value;
                    lastTransRecordDate = responseDataLabor[responseDataLabor.Items.Count - 1, "RecordDate"].Value;
                    lastTransacDate = responseDataLabor[responseDataLabor.Items.Count - 1, "TransDate"].Value;
                    lastTransRowPointer = responseDataLabor[responseDataLabor.Items.Count - 1, "RowPointer"].Value;

                    if ((responseDataLabor.Items.Count - 2) >= 0)
                    {
                        if (responseDataLabor[responseDataLabor.Items.Count - 2, "TransType"].Value == "C")
                        {
                            ///we need the machine and the run records.
                            lastTransMachRecordDate = responseDataLabor[responseDataLabor.Items.Count - 2, "RecordDate"].Value;
                            lastTransacDate = responseDataLabor[responseDataLabor.Items.Count - 2, "TransDate"].Value;
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
                    lastTransacDate = null;
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
                    lastTransacDate = responseDataAttendance[responseDataAttendance.Items.Count - 1, "PostDate"].Value;
                    lastTransRowPointer = responseDataAttendance[responseDataAttendance.Items.Count - 1, "RowPointer"].Value;
                    TransType = responseDataAttendance[responseDataAttendance.Items.Count - 1, "TransType"].Value;
                }
                else
                {//no records found so set the values so we can tell.
                    lastTransEndTime = strAttendanceEndTime; // responseDataLabor[responseDataLabor.Items.Count - 1, "EndTime"].Value;
                    lastTransRecordDate = null;
                    lastTransRowPointer = null;
                    lastTransacDate = null;
                    TransType = "";
                }
            }

            if (!string.IsNullOrWhiteSpace(lastTransacDate))
            {
                int index = lastTransacDate.IndexOf(' ');
                if (index > 0)
                {
                    lastTransacDate = string.Format("{0} 00:00:00.000", lastTransacDate.Substring(0, index));
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
            retval.Add(lastTransacDate); //8  transaction date
            return retval;
        }

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

            return ExcuteQueryRequest(requestData);
        }
        public string CreateIndirect(string employee, string shift, string deviceId, DateTime dtStart, DateTime dtEnd, string userInitials = "SA", string whse = "", string postRealtime = "0")
        {
            string totalTimeInHours = null;
            string retval = "";
            string indirectcode = "";

            string limitDW = ""; //added for pay basis 2012/05/13: JH
            LoadCollectionResponseData dcparamData = null, hrdata = null;  //added for pay basis 2012/05/13: JH
            double limitOverTime = 0, limitDoubleTime = 0, totalHrs = 0, limitMinOver = 0; //added for pay basis 2012/05/13: JH
            DateTime dtTmp, dtTmp2;


            double RegRate = 0, OtRate = 0, DbltRate = 0, MfgRegRate = 0, MfgOtRate = 0, MfgDbltRate = 0;
            LoadCollectionResponseData Employeedata = null;
            IDOUpdateItem updateItemPayBasis = new IDOUpdateItem();

            try
            {//Autolunch, Jobgrace, paybasis need employee data.  20120514: JH

                indirectcode = GetEmployeeIndirectCode(employee);
                if (indirectcode == "") { return ""; } //syteline data collection tools does not create indirect labor when this is not set. JH:20012/06/26
                Employeedata = GetEmployeeDetails(employee);
                if (Employeedata.Items.Count > 0)
                {//set employe pay rates.
                    try
                    {
                        RegRate = Convert.ToDouble(Employeedata[0, "RegRate"].Value, CultureInfo.InvariantCulture); // FTDEV-9247
                        OtRate = Convert.ToDouble(Employeedata[0, "OtRate"].Value, CultureInfo.InvariantCulture); // FTDEV-9247
                        DbltRate = Convert.ToDouble(Employeedata[0, "DtRate"].Value, CultureInfo.InvariantCulture); // FTDEV-9247
                        MfgRegRate = Convert.ToDouble(Employeedata[0, "MfgRegRate"].Value, CultureInfo.InvariantCulture); // FTDEV-9247
                        MfgOtRate = Convert.ToDouble(Employeedata[0, "MfgOtRate"].Value, CultureInfo.InvariantCulture); // FTDEV-9247
                        MfgDbltRate = Convert.ToDouble(Employeedata[0, "MfgDtRate"].Value, CultureInfo.InvariantCulture); // FTDEV-9247

                    }
                    catch (Exception)
                    {
                    }
                }
            }
            catch
            {
            }



            DateTime startDateTime = dtStart;
            DateTime endDateTime = dtEnd;

            if (DateTime.Compare(startDateTime, endDateTime) > 0)
            {
                endDateTime = endDateTime.AddDays(1);
            }

            TimeSpan span = endDateTime.Subtract(startDateTime);
            string diff = (span.TotalMinutes / 60).ToString("0.###");
            //if ((span.TotalMinutes / 60) < 1)
            //    return retval;   
            if (totalTimeInHours != null)
            {
                if (!totalTimeInHours.Trim().Equals(""))
                {
                    diff = totalTimeInHours;
                }
            }

            #region UpdateRequest
            UpdateCollectionRequestData updateRequestData = new UpdateCollectionRequestData();
            updateRequestData.IDOName = "SL.SLJobTrans";
            updateRequestData.RefreshAfterUpdate = true;
            updateRequestData.CustomUpdate = "STD,JobtranPostSaveSp(Job,Suffix,OperNum,JobrWc),REF";
            updateRequestData.CustomInsert = "STD,JobtranPostSaveSp(Job,Suffix,OperNum,JobrWc),REF";
            updateRequestData.CustomDelete = "DeleteJobtranitemSp(TransNum),STD";

            IDOUpdateItem updateItem = new IDOUpdateItem();
            updateItem.Action = UpdateAction.Insert;
            updateItem.Properties.Add("TransNum", "");
            updateItem.Properties.Add("Posted", postRealtime);
            updateItem.Properties.Add("Job", "");
            updateItem.Properties.Add("JobrWc", "");
            updateItem.Properties.Add("NoteExistsFlag", "0");
            updateItem.Properties.Add("OperNum", "0");
            updateItem.Properties.Add("Suffix", ""); //suffix);


            updateItem.Properties.Add("TransType", "I");


            //updateItem.Properties.Add("TransDate", dtStart.ToString("yyyyMMdd")); //transDate);
            updateItem.Properties.Add("TransDate", dtStart.ToString(WMShortDatePattern)); //MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128

            if (userInitials != null && !(userInitials.Trim().Equals("")))                      //12-28-11.sn       - Kiran
            {
                updateItem.Properties.Add("UserCode", userInitials);
            }
            else
            {
                updateItem.Properties.Add("UserCode", "SA");                            // Need to Fix      //12-28-11.en       - Kiran
            }


            updateItem.Properties.Add("EmpNum", employee);
            updateItem.Properties.Add("Shift", shift);// GetPropertyValue(startResponseData, "Shift"));
            updateItem.Properties.Add("PayRate", ""); //payType);
            updateItem.Properties.Add("PrRate", ""); //payTypeResponseData.Parameters.ElementAt(4).ToString());
            updateItem.Properties.Add("JobRate", ""); //payTypeResponseData.Parameters.ElementAt(5).ToString());
            updateItem.Properties.Add("IndCode", indirectcode); // GetPropertyValue(startResponseData, "IndCode"));

            updateItem.Properties.Add("JobOrdType", "I");

            updateItem.Properties.Add("Whse", whse);
            updateItem.Properties.Add("TransClass", "J");
            updateItem.Properties.Add("UbNewOper", "0");
            updateItem.Properties.Add("JobStat", "R");
            updateItem.Properties.Add("JobType", "J");
            updateItem.Properties.Add("StartTime", string.IsNullOrEmpty(startDateTime.TimeOfDay.TotalSeconds.ToString("#"))?"0": startDateTime.TimeOfDay.TotalSeconds.ToString("#"));
            updateItem.Properties.Add("EndTime", endDateTime.TimeOfDay.TotalSeconds.ToString("#"));

            updateItem.Properties.Add("AHrs", HrNullCheck(diff)); //added calculated time  //MSF162514: total hours can not be null or "".  JH:20130528


            updateItem.ItemID = "";
            updateItem.ItemNumber = 1;
            //updateRequestData.Items.Add(updateItem);
            //do overtime/double time check and updates.
            //check for paybasis
            dcparamData = GetDCParams();
            if (dcparamData.Items.Count > 0)
            {
                try
                {
                    limitOverTime = Convert.ToDouble(dcparamData[0, "LimitOt"].Value, CultureInfo.InvariantCulture); // FTDEV-9247
                    limitDoubleTime = Convert.ToDouble(dcparamData[0, "LimitDt"].Value, CultureInfo.InvariantCulture); // FTDEV-9247
                    limitDW = dcparamData[0, "DayWeek"].Value;
                }
                catch (FormatException)
                {//error converting the dc values use the default.  So we skip the paybasis.
                 //Console.WriteLine("LaborStop error converting dcparam: " + fex.Message);
                }
            }

            #endregion
            //do not do the overtime/double time calculations if the overtime or double time limits are not set.
            //do not do the calculations if this is a machine transaction.
            if ((limitOverTime > 0) || (limitDoubleTime > 0))
            {//we need to do the pay basis changes
                if (limitDW.ToUpper() == "D")
                {
                    //hrdata = GetSLJobTranshoursBydate(endDateTime.Date.ToString(), employee);
                    hrdata = GetSLJobTranshoursBydate(endDateTime.Date.ToString(WMFullDateTimePattern), employee); //MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128
                }
                else
                { //the limit is by the week so get the total for the week (Sunday-Sat).
                    dtTmp = Get1stDayofWeek(endDateTime);
                    dtTmp2 = dtTmp.Date.AddDays(6);
                    //hrdata = GetSLJobTranshoursBydate(dtTmp.Date.ToString(), employee, dtTmp2.Date.ToString());
                    hrdata = GetSLJobTranshoursBydate(dtTmp.Date.ToString(WMFullDateTimePattern), employee, dtTmp2.Date.ToString(WMFullDateTimePattern)); //MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128
                }
                totalHrs = totalJobTranshrs(hrdata);
                updateItemPayBasis = copyUpdateItem(updateItem);

                if ((totalHrs < limitOverTime))
                {//less than the overtime limit.  see if the current trans passes the over time.
                    //calculate if we need to split the time.
                    #region Overtime only
                    if (((totalHrs * 60) + span.TotalMinutes) >= (limitOverTime * 60))
                    {//we crossed the over time limit.
                        limitMinOver = (limitOverTime * 60) - (totalHrs * 60); //regular time remaining
                        dtTmp = startDateTime;
                        dtTmp = dtTmp.AddMinutes(limitMinOver); //end time
                        if (limitMinOver > 0)
                        {
                            //over time part
                            updateItem.Properties["PayRate"].Value = "R";
                        updateItem.Properties["PrRate"].Value = RegRate.ToString();
                        //updateItem.Properties["JobCostRate"].Value = MfgRegRate.ToString();
                        updateItem.Properties["JobRate"].Value = MfgRegRate.ToString();
                        //updateItem.Properties["StartTime"].Value = "O"; //no change
                        updateItem.Properties["EndTime"].Value = dtTmp.TimeOfDay.TotalSeconds.ToString("#");
                        updateItem.Properties["AHrs"].Value = HrNullCheck((limitMinOver / 60).ToString()); //MSF162514: total hours can not be null or "".  JH:20130528
                        updateRequestData.Items.Add(updateItem);
                        }
                        limitMinOver = span.TotalMinutes - limitMinOver;  //min over the over time limit.
                        if (limitMinOver > 0)
                        {
                            //double time.
                            updateItemPayBasis.Properties["PayRate"].Value = "O";
                            updateItemPayBasis.Properties["PrRate"].Value = OtRate.ToString();
                            //updateItemPayBasis.Properties["JobCostRate"].Value = MfgOtRate.ToString();
                            updateItemPayBasis.Properties["JobRate"].Value = MfgOtRate.ToString();
                            updateItemPayBasis.Properties["StartTime"].Value = dtTmp.TimeOfDay.TotalSeconds.ToString("#");
                            updateItemPayBasis.Properties["EndTime"].Value = endDateTime.TimeOfDay.TotalSeconds.ToString("#");
                            updateItemPayBasis.Properties["AHrs"].Value = HrNullCheck((limitMinOver / 60).ToString()); //MSF162514: total hours can not be null or "".  JH:20130528
                            updateRequestData.Items.Add(updateItemPayBasis);
                        }                        
                    }
                    else
                    {//did not cross the over time limit so record is all regular time.
                        updateItem.Properties["PayRate"].Value = "R";
                        updateItem.Properties["PrRate"].Value = RegRate.ToString();
                        updateItem.Properties["JobRate"].Value = MfgRegRate.ToString();
                        updateRequestData.Items.Add(updateItem);
                    }
                    #endregion
                }

                if ((totalHrs >= limitOverTime) & (totalHrs < limitDoubleTime))
                {//more than the overtime limit but less than the double time limit                    
                    //calculate if we need to split the time.
                    #region more than Overtime less than double time
                    if (((totalHrs * 60) + span.TotalMinutes) >= (limitDoubleTime * 60))
                    {//we crossed the double time limit.
                        limitMinOver = (limitDoubleTime * 60) - (totalHrs * 60); //overtime remaining
                        dtTmp = startDateTime;
                        //dtTmp = dtTmp.AddMinutes(span.TotalMinutes - limitMinOver);//end time
                        dtTmp = dtTmp.AddMinutes(limitMinOver);//end time
                        if (limitMinOver > 0)
                        {
                            //over time part
                            updateItem.Properties["PayRate"].Value = "O";
                            updateItem.Properties["PrRate"].Value = OtRate.ToString();
                            updateItem.Properties["JobRate"].Value = MfgOtRate.ToString();
                            //updateItem.Properties["StartTime"].Value = "O";
                            updateItem.Properties["EndTime"].Value = dtTmp.TimeOfDay.TotalSeconds.ToString("#");
                            updateItem.Properties["AHrs"].Value = HrNullCheck((limitMinOver / 60).ToString()); // MSF162514: total hours can not be null or "".  JH:20130528
                            updateRequestData.Items.Add(updateItem);
                        }
                            limitMinOver = span.TotalMinutes - limitMinOver;  //min over the double time limit.
                        if (limitMinOver > 0)
                        {
                            //double time.
                            updateItemPayBasis.Properties["PayRate"].Value = "D";
                            updateItemPayBasis.Properties["PrRate"].Value = DbltRate.ToString();
                            updateItemPayBasis.Properties["JobRate"].Value = MfgDbltRate.ToString();
                            updateItemPayBasis.Properties["StartTime"].Value = dtTmp.TimeOfDay.TotalSeconds.ToString("#");
                            updateItemPayBasis.Properties["EndTime"].Value = endDateTime.TimeOfDay.TotalSeconds.ToString("#");
                            updateItemPayBasis.Properties["AHrs"].Value = HrNullCheck((limitMinOver / 60).ToString()); //MSF162514: total hours can not be null or "".  JH:20130528
                            updateRequestData.Items.Add(updateItemPayBasis);
                        }
                            //add both updateItem object in the correct order.
                          
                        

                    }
                    else
                    {//did not cross the double time limit so record is all over time.
                        updateItem.Properties["PayRate"].Value = "O";
                        updateItem.Properties["PrRate"].Value = OtRate.ToString();
                        updateItem.Properties["JobRate"].Value = MfgOtRate.ToString();
                        updateRequestData.Items.Add(updateItem);
                    }
                    #endregion
                }

                if ((totalHrs >= limitDoubleTime))
                {//more than the double time limit 
                    updateItem.Properties["PayRate"].Value = "D";
                    updateItem.Properties["PrRate"].Value = DbltRate.ToString();
                    updateItem.Properties["JobRate"].Value = MfgDbltRate.ToString();
                    updateRequestData.Items.Add(updateItem);
                }



            }
            else
            {
                updateRequestData.Items.Add(updateItem);
            }
            UpdateCollectionResponseData updateResponseData = null;
            try
            {
                updateResponseData = this.Context.Commands.UpdateCollection(updateRequestData);
                //Console.WriteLine(updateResponseData.ToXml());
            }
            catch (Exception ee)
            {
                //Console.WriteLine(ee.Message);
                errorMessage = constructErrorMessage(ee.Message, null, null);
                return "";
            }
            //return true;
            //SplitLastTransRTOTDT(dtStart, employee, startDateTime, endDateTime); //make sure that the last record's OT was set correctly.
            SplitLastTransRTOTDT(dtStart, employee);
            return retval;
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
                errorMessage = constructErrorMessage("Update Failed " + ee.Message, "", null);
                //Console.WriteLine(ee.Message);
                return errorMessage;
            }
            return "";
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
                errorMessage = constructErrorMessage("Update Failed " + ee.Message, "", null);
                //Console.WriteLine(ee.Message);
                return errorMessage;
            }
            return "";
        }


        public LoadCollectionResponseData GetSLJobTransbyEmployee(string employee, string transDate = "", string shiftStartDate = "", string job = "", string posted = "0", string RecordDate = "", string RowPointer = "")
        {
            string filterString;
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            //string PostDate = DateTime.Now.Date.ToShortDateString();
            string PostDate = DateTime.Now.Date.ToString(WMShortDatePattern); //MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128         
            requestData.IDOName = "SLJobTrans";
            requestData.PropertyList.SetProperties("Job, TransNum, EmpNum, StartTime, EndTime, TransClass, TransDate, TransNum,TransType, DerEndJob, CompleteOp, Posted, RecordDate, RowPointer, EmpShift, Suffix, OperNum, Wc, QtyComplete, QtyMoved, QtyScrapped, ItemUM, ReasonCode, CompleteOp, Lot, Loc, Whse, IndCode, UserCode, PayRate ");
            filterString = "EmpNum = '" + employee + "' and TransType IN ('R', 'S', 'I')";
            //if(employee != "") {filterString = "EmpNum = '" + employee + "'";
            //if (transDate != "" && shiftStartDate!="") { filterString = filterString + " and ( TransDate Between '" + shiftStartDate + "' AND '" + transDate + "')"; }
            if (!string.IsNullOrWhiteSpace(transDate) && !string.IsNullOrWhiteSpace(shiftStartDate)) { filterString = string.Format("{0} and ( TransDate Between '{1} 00:00:00.000' AND '{2} 23:59:59.000')", filterString, shiftStartDate, transDate); }

            if (job != "") { filterString = filterString + " and Job = '" + IDOStrFormat(job) + "'"; }//MSF165152 added formating to handle special charcters JH:20130717
            //if (posted != "") { filterString = filterString + " and Posted = '" + posted + "'"; }
            if (RecordDate != "") { filterString = filterString + " and RecordDate = '" + RecordDate + "'"; }
            if (RowPointer != "") { filterString = filterString + " and RowPointer = '" + RowPointer + "'"; }


            requestData.Filter = filterString;
            requestData.OrderBy = "EmpNum, TransDate, StartTime, EndTime, TransType";
            requestData.RecordCap = -1;

            return ExcuteQueryRequest(requestData);
        }

        //public bool SplitLastTransRTOTDT(DateTime dtTranstime, string employee, DateTime startDateTime, DateTime endDateTime)
        public bool SplitLastTransRTOTDT(DateTime dtTranstime, string employee)
        {
            bool retVal = true;


            string limitDW = ""; //added for pay basis 2012/05/13: JH
            LoadCollectionResponseData dcparamData = null, hrdata = null;  //added for pay basis 2012/05/13: JH
            //keep all time in Min to reduce the number of times we have to convert from hr to min.
            double limitOverTimeMin = 0, limitDoubleTimeMin = 0, totalMin = 0; //added for pay basis 2012/05/13: JH
            double lastTransMin = 0, lastTransStart = 0, lastTransEnd = 0;

            double nextTransMin = 0, TmpCalc = 0;
            DateTime tmpDateEnd, dtTmp, dtTmp2, JobEndDate;
            string timecalc, datecalc;
            List<string> lastTrans = new List<string> { };
            //update.LaborStartDaoImpl LaborStartDao = new update.LaborStartDaoImpl();
            //update.LaborStopDaoImpl LaborStopDao = new update.LaborStopDaoImpl();

            //UpdateRequest LaborStartRequest = new UpdateRequest();
            //UpdateRequest LaborStopRequest = new UpdateRequest();

            LoadCollectionResponseData LaborData = null;


            //lastTrans = GetLastTrans(employee, dtTranstime.ToString("yyyy/MM/dd"));
            lastTrans = GetLastTrans(employee, dtTranstime.ToString(WMShortDatePattern), dtTranstime.ToString(WMShortDatePattern)); //MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128

            //is limitOverTime or limitDoubleTime > 0

            #region limits and Params
            dcparamData = GetDCParams();
            if (dcparamData.Items.Count > 0)
            {
                try
                {
                    limitOverTimeMin = Convert.ToDouble(dcparamData[0, "LimitOt"].Value, CultureInfo.InvariantCulture); // FTDEV-9247
                    limitOverTimeMin = limitOverTimeMin * 60; //convert hours to min
                    limitDoubleTimeMin = Convert.ToDouble(dcparamData[0, "LimitDt"].Value, CultureInfo.InvariantCulture); // FTDEV-9247
                    limitDoubleTimeMin = limitDoubleTimeMin * 60; //convert hours to min
                    limitDW = dcparamData[0, "DayWeek"].Value;
                }
                catch (FormatException fex)
                {//error converting the dc values use the default.  
                 //Console.WriteLine("Labor Utils SplitLastTransRTOTDT error converting dcparam: " + fex.Message);
                    errorMessage = constructErrorMessage("Error converting dcparam: " + fex.Message, null, null);
                    return false;
                }

            }
            #endregion


            if (((limitOverTimeMin > 0) || (limitDoubleTimeMin > 0)))
            {//we need to do the pay basis changes
                #region Calculate the hours for the period
                if (limitDW.ToUpper() == "D")
                {
                    //hrdata = GetSLJobTranshoursBydate(dtTranstime.Date.ToString(), employee);
                    hrdata = GetSLJobTranshoursBydate(dtTranstime.Date.ToString(WMFullDateTimePattern), employee);//MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128
                }
                else
                { //the limit is by the week so get the total for the week (Sunday-Sat).
                    dtTmp = Get1stDayofWeek(dtTranstime);
                    dtTmp2 = dtTmp.Date.AddDays(6);
                    //hrdata = GetSLJobTranshoursBydate(dtTmp.Date.ToString(), employee, dtTmp2.Date.ToString());
                    hrdata = GetSLJobTranshoursBydate(dtTmp.Date.ToString(WMFullDateTimePattern), employee, dtTmp2.Date.ToString(WMFullDateTimePattern));//MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128
                }

                totalMin = totalJobTranshrs(hrdata); //the transactions express time in hours.
                totalMin = totalMin * 60; //convert hours to min
                totalMin = Math.Round(totalMin, 4); //if this is a very small number it causes issues with the calculations below.

                #endregion

                #region last trans times
                //we might need to format the date string?
                //lastTrans = GetLastTrans(employee, dtTranstime.ToShortDateString());
                lastTrans = GetLastTrans(employee, dtTranstime.ToString(WMShortDatePattern), dtTranstime.ToString(WMShortDatePattern)); //MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128

                try
                {
                    lastTransStart = Convert.ToDouble(lastTrans[7], CultureInfo.InvariantCulture); // FTDEV-9247
                    lastTransEnd = Convert.ToDouble(lastTrans[1], CultureInfo.InvariantCulture); // FTDEV-9247
                    lastTransMin = lastTransEnd - lastTransStart;
                    lastTransMin = lastTransMin / 60;  //last transaction times are in seconds convert to min.

                }
                catch (FormatException fex)
                {//error converting the dc values use the default.  So we skip the paybasis.
                 //Console.WriteLine("Labor Util SplitLastTransRTOTDT error converting Last trans minuets: " + fex.Message);
                    errorMessage = constructErrorMessage("Error converting Last trans minuets: " + fex.Message, null, null);
                    return false;
                }

                //totalMin = totalMin - lastTransMin; //take the last transaction's time out of the total.

                #endregion

                LaborData = GetSLJobTransbyEmployee(employee, RecordDate: lastTrans[2], RowPointer: lastTrans[3]); //order by date time so oldest is at the end.
                if (LaborData.Items.Count <= 0)
                {//this is a error. we should have found the last labor record.

                    //Console.WriteLine("error getting labor data: ");
                    errorMessage = constructErrorMessage("Error getting last labor transaction: Record not found", null, null);
                    return false;
                }

                switch (LaborData[0, "PayRate"].Value.ToUpper())
                {
                    case "R":
                        if (totalMin > limitOverTimeMin)
                        {//the total hrs crossed over time limit, but the last trans was regular time.  So we need to split the transaction
                            nextTransMin = totalMin - limitOverTimeMin;  //the time that is passed the overtime limit.
                            nextTransMin = Math.Round(nextTransMin, 0);
                        }
                        break;
                    case "O":
                        if (totalMin > limitDoubleTimeMin)
                        {//the total hrs crossed double time limit, but the last trans was overtime.  So we need to split the transaction
                            nextTransMin = totalMin - limitDoubleTimeMin;  //the time that is passed the overtime limit.
                            nextTransMin = Math.Round(nextTransMin, 0);
                        }
                        break;
                    case "D":
                        //we have allready crossed all of the limit so do not split.
                        break;

                }

                if (nextTransMin > 0)
                {
                    TmpCalc = lastTransEnd - (nextTransMin * 60);
                    TmpCalc = Math.Round(TmpCalc, 0);
                    tmpDateEnd = dtTranstime.Date.AddSeconds(TmpCalc);
                    datecalc = LaborData[0, "TransDate"].Value.Substring(0, 8); //the request object does not like the string returned from syteline.  so format it.
                    datecalc = datecalc.Substring(0, 4) + "/" + datecalc.Substring(4, 2) + "/" + datecalc.Substring(6, 2);
                    UpdateTrans(lastTrans[0], tmpDateEnd, lastTrans[2], lastTrans[3], lastTrans[7]); //set the current transaction's end time.
                    timecalc = tmpDateEnd.TimeOfDay.ToString();
                    JobEndDate = tmpDateEnd.AddMinutes(nextTransMin);
                    retVal = PerformLaborPosting(tmpDateEnd, JobEndDate, employee, LaborData);
                }
            }

            return true;
        }

        public bool PerformLaborPosting(DateTime StartDateTime, DateTime EndDateTime, string employee, LoadCollectionResponseData LaborData)
        {
            bool retVal = true;
            LoadCollectionResponseData Employeedata;
            string Operation = "";
            string IsPost = "";
            string UserInitials = "";

            Employeedata = GetEmployeeDetails(employee);
            if (Employeedata.Items.Count > 0)
            {//set employe pay rates.

                RegRate = Convert.ToDouble(Employeedata[0, "RegRate"].Value, CultureInfo.InvariantCulture); // FTDEV-9247
                OtRate = Convert.ToDouble(Employeedata[0, "OtRate"].Value, CultureInfo.InvariantCulture); // FTDEV-9247
                DbltRate = Convert.ToDouble(Employeedata[0, "DtRate"].Value, CultureInfo.InvariantCulture); // FTDEV-9247
                MfgRegRate = Convert.ToDouble(Employeedata[0, "MfgRegRate"].Value, CultureInfo.InvariantCulture); // FTDEV-9247
                MfgOtRate = Convert.ToDouble(Employeedata[0, "MfgOtRate"].Value, CultureInfo.InvariantCulture); // FTDEV-9247
                MfgDbltRate = Convert.ToDouble(Employeedata[0, "MfgDtRate"].Value, CultureInfo.InvariantCulture); // FTDEV-9247


            }

            if (LaborData[0, "OperNum"].Value.ToString() == "0")
            {
                Operation = "";

            }
            else
            {
                Operation = LaborData[0, "OperNum"].Value;
            }

            if (LaborData[0, "Posted"].Value.ToString() == "1")
            {
                IsPost = "1";
            }
            else
            {
                IsPost = "0";
            }
            UserInitials = LaborData[0, "UserCode"].Value.ToString();


            //Needs do uncomment later
            //if ((taImplemented == true) & (processRealTime == false))
            //{//only do auto lunch if taimplemented is true and process real time is false.
            //    //3b Preform auto lunch
            //    returnString = performAutoLunch(updateRequest); //preform auto lunch calculations and add records if needed.  jh:2012/04/23
            //}



            //Calcluating Regualr,OverTime,DoubleTime
            string RegOtDtFieldSetXmlstring = "";

            string orderType;// For Machine
            int recnt = 0;
            string ReportDate, OrderNumber, Suffix, WorkCenter, TaskCode, shift, Sequence = "";
            double limitOverTime = 0, limitDoubleTime = 0, totalHrs = 0;
            double otelapsedTime, regelapsedTime, dtelapsedTime;


            DateTime jobStartDateTime, jobEndDateTime, regStartDateTime, regEndDateTime, otStartDateTime, otEndDateTime, dtStartDateTime, dtEndDateTime;

            string inputsXMLString = "<inputs>";
            inputsXMLString += "<fieldValueList><name>postOffSets</name><value>yes</value></fieldValueList>";
            inputsXMLString += "<fieldValueList><name>userInitials</name><value>" + UserInitials + "</value></fieldValueList>";
            if (IsPost == "1")
            {
                inputsXMLString += "<fieldValueList><name>isPostLabor</name><value>yes</value></fieldValueList>";
            }
            else
            {
                inputsXMLString += "<fieldValueList><name>isPostLabor</name><value>no</value></fieldValueList>";
            }
            inputsXMLString += "<fieldValueList><name>MASTER0</name>";
            inputsXMLString += "<value>MASTER~|" + employee + "~" + StartDateTime.ToString("MMddyyyy") + "~0000~" + StartDateTime.ToString("MMddyyyy") + "~0000~" + StartDateTime.ToString("MMddyyyy") + "</value></fieldValueList>";
            orderType = GetOrderType(LaborData[0, "TransType"].Value);
            jobStartDateTime = StartDateTime;
            jobEndDateTime = EndDateTime;
            ReportDate = StartDateTime.ToString("MMddyyyy");
            OrderNumber = LaborData[0, "Job"].Value;
            WorkCenter = LaborData[0, "Wc"].Value;
            TaskCode = LaborData[0, "IndCode"].Value;
            shift = LaborData[0, "EmpShift"].Value;
            Suffix = LaborData[0, "Suffix"].Value;


            CalculateHours(jobStartDateTime, jobEndDateTime, employee, recnt, ReportDate, Sequence, orderType, OrderNumber, Suffix, Operation, WorkCenter,
              TaskCode, shift, out regStartDateTime, out regEndDateTime, out regelapsedTime,
             out otStartDateTime, out otEndDateTime, out otelapsedTime, out dtStartDateTime, out dtEndDateTime, out dtelapsedTime,
             out totalHrs, out limitOverTime, out limitDoubleTime, out RegOtDtFieldSetXmlstring);

            inputsXMLString += RegOtDtFieldSetXmlstring;
            
            inputsXMLString += "</inputs>";



            //string error = "";
            string Infobar = "";
            object[] inputValues;
            inputValues = new object[]{
                                                inputsXMLString,
                                                Infobar
                                                };
            //table = this.ExecuteERPUpdateRequest("ICSLShopFloorTrans", "TASLJobUpload", out error, inputsXMLString, Infobar);
            //this.Context.Commands.Invoke("ICSLShopFloorTrans", "TASLJobUpload", inputValues);
            InvokeResponseData responseData = InvokeIDO("ICSLShopFloorTrans", "TASLJobUpload", inputValues);


            return retVal;
        }

        public string GetOrderType(string orderTypStr)
        {
            string OrderType = "";

            if (orderTypStr.Equals("I"))
            {
                OrderType = "21";
            }
            else if (orderTypStr.Equals("R"))
            {
                OrderType = "22";
            }
            else if (orderTypStr.Equals("S"))
            {

                OrderType = "23";
            }
            else if (orderTypStr.Equals("M"))
            {

                OrderType = "24";
            }

            return OrderType;
        }





        public void CalculateHours(DateTime jobstartDateTime, DateTime jobendDateTime, string EmployeeNumber, int recnt, string ReportDate, string Sequence, string OrderType, string OrderNumber, string Suffix, string Operation, string WorkCenter,
            string TaskCode, string shift, out DateTime regStartDateTime, out DateTime regEndDateTime, out double regelapsedTime,
            out DateTime otStartDateTime, out DateTime otEndDateTime, out double otelapsedTime, out DateTime dtStartDateTime, out DateTime dtEndDateTime, out double dtelapsedTime,
            out double totalHrs, out double limitOverTime, out double limitDoubleTime, out string RegOtDtFieldSetXmlstring)
        {
            bool processRealTime = false;
            RegOtDtFieldSetXmlstring = "";
            string limitDW = ""; //added for pay basis 2012/05/13: JH
            LoadCollectionResponseData dcparamData = null, hrdata = null;  //added for pay basis 2012/05/13: JH
                                                                           //double limitOverTime = 0, limitDoubleTime = 0, totalHrs = 0, limitMinOver = 0; //added for pay basis 2012/05/13: JH
            limitOverTime = 0;
            limitDoubleTime = 0;
            totalHrs = 0;
            double limitMinOver = 0;

            DateTime dtTmp, dtTmp2; //paybasis changes 2012/05/13: JH
            regStartDateTime = jobstartDateTime;
            regEndDateTime = jobstartDateTime;
            otStartDateTime = jobstartDateTime;
            otEndDateTime = jobstartDateTime;
            dtStartDateTime = jobstartDateTime;
            dtEndDateTime = jobstartDateTime;
            otelapsedTime = 0;
            regelapsedTime = 0;
            dtelapsedTime = 0;

            string wmFullDateTimePattern = "yyyy/MM/dd H:mm:ss";

            if (DateTime.Compare(jobstartDateTime, jobendDateTime) > 0)
            {
                jobendDateTime = jobendDateTime.AddDays(1);
            }
            TimeSpan span = jobendDateTime.Subtract(jobstartDateTime);
            string diff = (span.TotalMinutes / 60).ToString("0.###");
            //Machine Type order will be in Regular hours
            if (OrderType == "24" || OrderType == "26" || OrderType == "28" || OrderType == "30")
            {
                regStartDateTime = jobstartDateTime;
                regEndDateTime = jobendDateTime;
                regelapsedTime = span.TotalMinutes;
                otelapsedTime = 0;
                dtelapsedTime = 0;
                limitOverTime = 1;

                RegOtDtFieldSetXmlstring = BuildFieldSet(recnt, EmployeeNumber, ReportDate, Sequence, OrderType, OrderNumber, Suffix, Operation, WorkCenter,
                                                       TaskCode, shift, "R", regStartDateTime, regEndDateTime, regelapsedTime);
                return;
            }

            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLDcparms";
            //job labor grace time. GrcMinJb
            //added fields: DayWeek, LimitOt, LimitDt for over time calculations 2012/05/11 JH
            requestData.PropertyList.SetProperties("GrcJob, GrcMinI,GrcMinO, GrcMinJb, DayWeek, LimitOt, LimitDt ");
            requestData.RecordCap = 0;
            dcparamData = this.Context.Commands.LoadCollection(requestData);

            if (dcparamData.Items.Count > 0)
            {
                try
                {
                    limitOverTime = Convert.ToDouble(dcparamData[0, "LimitOt"].Value, CultureInfo.InvariantCulture); // FTDEV-9247
                    limitDoubleTime = Convert.ToDouble(dcparamData[0, "LimitDt"].Value, CultureInfo.InvariantCulture); // FTDEV-9247
                    limitDW = dcparamData[0, "DayWeek"].Value;
                }
                catch (FormatException)
                {//error converting the dc values use the default.  So we skip the paybasis.
                 //Console.WriteLine("LaborStop error converting dcparam: " + fex.Message);

                }
            }


            //do not do the overtime/double time calculations if the overtime or double time limits are not set.
            //do not do the calculations if this is a machine transaction.
            // if (((limitOverTime > 0) || (limitDoubleTime > 0)) & (!in_transactionType.Equals("M")) & (processRealTime == false))
            if (((limitOverTime > 0) || (limitDoubleTime > 0)) & (processRealTime == false))
            {//we need to do the pay basis changes
                if (limitDW.ToUpper() == "D")
                {
                    //hrdata = GetSLJobTranshoursBydate(endDateTime.Date.ToString(), employee);
                    hrdata = GetSLJobTranshoursBydate(jobendDateTime.Date.ToString(wmFullDateTimePattern), EmployeeNumber);//MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128
                }
                else
                { //the limit is by the week so get the total for the week (Sunday-Sat).
                    dtTmp = Get1stDayofWeek(jobendDateTime);
                    dtTmp2 = dtTmp.Date.AddDays(6);
                    //hrdata = GetSLJobTranshoursBydate(dtTmp.Date.ToString(), employee, dtTmp2.Date.ToString());
                    hrdata = GetSLJobTranshoursBydate(dtTmp.Date.ToString(wmFullDateTimePattern), EmployeeNumber, dtTmp2.Date.ToString(wmFullDateTimePattern)); //MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128
                }
                totalHrs = totalHrs + totalJobTranshrs(hrdata);
                totalHrs = Math.Round(totalHrs, 4); //if this is a very small number it causes issues with the calculations below.
                if ((totalHrs < limitOverTime))
                {//less than the overtime limit.  see if the current trans passes the over time.
                 //calculate if we need to split the time.

                    //if (((totalHrs * 60) + span.TotalMinutes) >= (limitDoubleTime * 60))
                    if (((Math.Round((totalHrs * 60), 0)) + span.TotalMinutes) > (limitDoubleTime * 60))
                    {//we crossed the double time limit as well.                        
                        limitMinOver = ((Math.Round((totalHrs * 60), 0)) + span.TotalMinutes) - (limitDoubleTime * 60); //regular time remaining
                        dtTmp2 = jobendDateTime;//startDateTime;
                                                //dtTmp2 = dtTmp2.AddMinutes(((totalHrs * 60) + span.TotalMinutes)); //start time  = over time end
                        dtTmp2 = dtTmp2.AddMinutes((-1 * limitMinOver)); //move
                        if (limitMinOver > 0)
                        {
                            dtStartDateTime = dtTmp2;
                            dtEndDateTime = jobendDateTime;
                        }
                        TimeSpan ts = new TimeSpan(0, Convert.ToInt32(limitMinOver, CultureInfo.InvariantCulture), 0); // FTDEV-9247
                        span = span.Subtract(ts);
                        //totalHrs = totalHrs - (limitMinOver / 60);  //do not reduce the total number of hours that are in the system. 20120523: JH

                        //set end time to dbl time start
                        jobendDateTime = dtTmp2;
                    }
                    if (((Math.Round((totalHrs * 60), 0)) + span.TotalMinutes) > (limitOverTime * 60))
                    {//we crossed the over time limit.
                        limitMinOver = (limitOverTime * 60) - (Math.Round((totalHrs * 60), 0)); //regular time remaining
                        dtTmp = jobstartDateTime;
                        dtTmp = dtTmp.AddMinutes(limitMinOver); //end time
                        regStartDateTime = jobstartDateTime;
                        regEndDateTime = dtTmp;
                        limitMinOver = span.TotalMinutes - limitMinOver;  //min over the over time limit.
                        limitMinOver = Math.Round(limitMinOver, 0); //round min to the whole number to avoid rounding errors. 20120530: JH
                        if (limitMinOver > 0)
                        {
                            //overtime part.
                            otStartDateTime = dtTmp;
                            otEndDateTime = jobendDateTime;
                        }
                    }
                    //Added Extra condition for Rg hrs calculation
                    if (((Math.Round((totalHrs * 60), 0)) + span.TotalMinutes) <= (limitOverTime * 60))
                    {
                        regStartDateTime = jobstartDateTime;
                        regEndDateTime = jobendDateTime;
                    }
                }

                if ((totalHrs >= limitOverTime) & (totalHrs < limitDoubleTime))
                {
                    //more than the overtime limit but less than the double time limit                    
                    //calculate if we need to split the time.
                    if (((Math.Round((totalHrs * 60), 0)) + span.TotalMinutes) >= (limitDoubleTime * 60))
                    {//we crossed the double time limit.
                     //round minuets to the whole minuet. 20120530: JH
                        limitMinOver = (limitDoubleTime * 60) - (Math.Round((totalHrs * 60), 0)); //overtime remaining
                        dtTmp = jobstartDateTime;
                        //dtTmp = dtTmp.AddMinutes(span.TotalMinutes - limitMinOver);//end time
                        dtTmp = dtTmp.AddMinutes(limitMinOver);//end time
                        otEndDateTime = dtTmp;
                        limitMinOver = span.TotalMinutes - limitMinOver;  //min over the over time limit.
                        limitMinOver = Math.Round(limitMinOver, 0); //round min to the whole number to avoid rounding errors. 20120530: JH
                        if (limitMinOver > 0)
                        {
                            //double time.
                            dtStartDateTime = dtTmp;
                            dtEndDateTime = jobendDateTime;
                        }
                    }
                    else
                    //did not cross the double time limit so record is all over time.
                    {
                        otStartDateTime = jobstartDateTime;
                        otEndDateTime = jobendDateTime;
                    }
                }

                if ((totalHrs >= limitDoubleTime))
                {
                    dtStartDateTime = jobstartDateTime;
                    dtEndDateTime = jobendDateTime;
                }
            }

            TimeSpan regSpan = regEndDateTime.Subtract(regStartDateTime);
            regelapsedTime = regSpan.TotalMinutes;

            TimeSpan otSpan = otEndDateTime.Subtract(otStartDateTime);
            otelapsedTime = otSpan.TotalMinutes;

            TimeSpan dtSpan = dtEndDateTime.Subtract(dtStartDateTime);
            dtelapsedTime = dtSpan.TotalMinutes;

            //BuildFIledset(XmlReadMode File)
            for (int i = 1; i <= 3; i++)
            {
                //Regular Hours
                if (i == 1)
                {
                    if (totalHrs < limitOverTime)
                    {
                        RegOtDtFieldSetXmlstring = BuildFieldSet(recnt, EmployeeNumber, ReportDate, Sequence, OrderType, OrderNumber, Suffix, Operation, WorkCenter,
                                                        TaskCode, shift, "R", regStartDateTime, regEndDateTime, regelapsedTime);
                    }
                }
                //overTime
                if (i == 2)
                {
                    //overTime
                    if (otelapsedTime > 0)
                    {
                        RegOtDtFieldSetXmlstring += BuildFieldSet(recnt, EmployeeNumber, ReportDate, Sequence, OrderType, OrderNumber, Suffix, Operation, WorkCenter,
                                                                                TaskCode, shift, "O", otStartDateTime, otEndDateTime, otelapsedTime);
                    }
                }
                //DoubleTime
                if (i == 3)
                {
                    if (dtelapsedTime > 0)
                    {
                        RegOtDtFieldSetXmlstring += BuildFieldSet(recnt, EmployeeNumber, ReportDate, Sequence, OrderType, OrderNumber, Suffix, Operation, WorkCenter,
                                                        TaskCode, shift, "D", dtStartDateTime, dtEndDateTime, dtelapsedTime);
                    }
                }
            }


        }


        private string BuildFieldSet(int recnt, string EmployeeNumber, string ReportDate, string Sequence, string OrderType, string OrderNumber, string Suffix, string Operation, string WorkCenter,
                                      string TaskCode, string shift, string LaborType, DateTime StartDateTime, DateTime EndDateTime, double ElapsedTime)
        {
            string FieldSetXmlstring = "";



            FieldSetXmlstring += "<fieldValueList><name>Hours" + 1 + "</name>";
            FieldSetXmlstring += "<value>Hours~" + EmployeeNumber + "~" + StartDateTime.ToString("MMddyyyy") + "~" + "1" + "|";
            FieldSetXmlstring += OrderType;
            FieldSetXmlstring += "~" + OrderNumber;
            FieldSetXmlstring += "~" + Suffix;
            FieldSetXmlstring += "~" + Operation;
            FieldSetXmlstring += "~" + WorkCenter;
            FieldSetXmlstring += "~";
            FieldSetXmlstring += "~" + TaskCode;
            FieldSetXmlstring += "~" + shift;
            FieldSetXmlstring += "~" + LaborType;// punchResponseData[i, "ErpLaborType"].Value;
            FieldSetXmlstring += "~" + StartDateTime.ToString("MMddyyyy");
            FieldSetXmlstring += "~" + StartDateTime.ToString("HHmm");
            FieldSetXmlstring += "~" + EndDateTime.ToString("MMddyyyy");
            FieldSetXmlstring += "~" + EndDateTime.ToString("HHmm");
            FieldSetXmlstring += "~" + ElapsedTime.ToString(); ;

            FieldSetXmlstring += "~";//+ punchResponseData[i, "MachineTime"].Value;
            FieldSetXmlstring += "~" + "collectUser";//UserName;
            FieldSetXmlstring += "~" + "";
            FieldSetXmlstring += "~" + "";
            FieldSetXmlstring += "~" + "";
            FieldSetXmlstring += "~" + "";
            FieldSetXmlstring += "~" + "";

            FieldSetXmlstring += "</value>";
            FieldSetXmlstring += "</fieldValueList>";

            return FieldSetXmlstring;

        }




        public string GetEmployeeIndirectCode(String employee)
        {
            LoadCollectionResponseData Employeedata = null;
            string IndCode = "";
            Employeedata = GetSLEmployeeDetails(employee);
            try
            {
                IndCode = Employeedata[0, "IndCode"].Value; //1 = enabled
            }
            catch
            { IndCode = ""; }

            return IndCode;
        }


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


        public LoadCollectionResponseData GetDCParams()
        {


            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLDcparms";
            //job labor grace time. GrcMinJb
            //added fields: DayWeek, LimitOt, LimitDt for over time calculations 2012/05/11 JH
            requestData.PropertyList.SetProperties("GrcJob, GrcMinI,GrcMinO, GrcMinJb, DayWeek, LimitOt, LimitDt ");

            requestData.RecordCap = 0;
            return ExcuteQueryRequest(requestData);
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

            return ExcuteQueryRequest(requestData);
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




        /// <summary>
        /// Low level method to create lunch records.  Used by transactions that create auto lunch.
        /// </summary>
        /// <returns>Error message</returns>
        public string CreateLunch(string EmpNum, string transDate, string transTime, string transType, string userId, string shift, string deviceId, string stopLaborRecords,
                    string recordMachineTime, string processRealTime, string taImplemented, string validatePreviousTARecord, DateTime LunchStartTime, DateTime LunchEndTime)
        {
            string retVal = "";
            int returnval = 0;

            string Infobar = "";
            transType = "4";
            transTime = LunchStartTime.ToString().Substring(LunchStartTime.ToString().IndexOf(" "));

            TimeAttendanceUpdate TaUpdateLunchOut = new TimeAttendanceUpdate(EmpNum, transDate, transTime, transType, userId, shift, deviceId, stopLaborRecords,
                     recordMachineTime, processRealTime, taImplemented, validatePreviousTARecord, "1", out Infobar);
            TaUpdateLunchOut.Initialize();//Initilize the base class.
            TaUpdateLunchOut.SetContext(this.Context);
            returnval = TaUpdateLunchOut.PerformUpdate(out Infobar);

            if (returnval == 0)
            {
                transType = "3";
                transTime = LunchEndTime.ToString().Substring(LunchEndTime.ToString().IndexOf(" "));

                TimeAttendanceUpdate TaUpdateLunchIn = new TimeAttendanceUpdate(EmpNum, transDate, transTime, transType, userId, shift, deviceId, stopLaborRecords,
                     recordMachineTime, processRealTime, taImplemented, validatePreviousTARecord, "1", out Infobar);
                TaUpdateLunchIn.Initialize();//Initilize the base class.
                TaUpdateLunchIn.SetContext(this.Context);
                returnval = TaUpdateLunchIn.PerformUpdate(out Infobar);

                return retVal;
            }


            return retVal;

        }
        public string CreateBreak(string EmpNum, string transDate, string transTime, string transType, string userId, string shift, string deviceId, string stopLaborRecords,
                    string recordMachineTime, string processRealTime, string taImplemented, string validatePreviousTARecord, DateTime BreakStartTime, DateTime BreakEndTime)
        {
            string retVal = "";
            int returnval = 0;

            string Infobar = "";
            transType = "6";
            transTime = BreakStartTime.ToString().Substring(BreakStartTime.ToString().IndexOf(" "));

            TimeAttendanceUpdate TaUpdateBreakOut = new TimeAttendanceUpdate(EmpNum, transDate, transTime, transType, userId, shift, deviceId, stopLaborRecords,
                     recordMachineTime, processRealTime, taImplemented, validatePreviousTARecord, "1", out Infobar);
            TaUpdateBreakOut.Initialize();//Initilize the base class.
            TaUpdateBreakOut.SetContext(this.Context);
            returnval = TaUpdateBreakOut.PerformUpdate(out Infobar);

            if (returnval == 0)
            {
                transType = "5";
                transTime = BreakEndTime.ToString().Substring(BreakEndTime.ToString().IndexOf(" "));

                TimeAttendanceUpdate TaUpdateBreakIn = new TimeAttendanceUpdate(EmpNum, transDate, transTime, transType, userId, shift, deviceId, stopLaborRecords,
                     recordMachineTime, processRealTime, taImplemented, validatePreviousTARecord, "1", out Infobar);
                TaUpdateBreakIn.Initialize();//Initilize the base class.
                TaUpdateBreakIn.SetContext(this.Context);
                returnval = TaUpdateBreakIn.PerformUpdate(out Infobar);

                return retVal;
            }


            return retVal;

        }
        public string JobGraceIndirectCalc(string employee, string shift, string deviceID, string transDate, DateTime transactionDate, DateTime? lunchStartTime = null, string transtype = "")
        {
            string retVal = "";
            //job grace period variables.
            List<string> lastTrans = new List<string> { };
            double transtimeChange = 0, dbltransTime = 0, dbllasttransTime = 0;
            int jobGraceMin = 0;
            DateTime currentDateTime = transactionDate;
            DateTime tmpDate = DateTime.MinValue, tmpDateStart = DateTime.MinValue, tmpDateEnd = DateTime.MinValue;

            //employee data for auto lunch check.
            LoadCollectionResponseData Employeedata = null;
            //get employee record

            #region last trans times
            lastTrans = GetLastTrans(employee, transDate, transDate);

            try
            {
                dbltransTime = Convert.ToDouble(currentDateTime.TimeOfDay.TotalSeconds, CultureInfo.InvariantCulture); // FTDEV-9247
                dbllasttransTime = Convert.ToDouble(lastTrans[1], CultureInfo.InvariantCulture); // FTDEV-9247
            }
            catch (FormatException)
            {//we had a error converting the transaction times. Keep going and use the default value of 0.
             //Console.WriteLine("ALaborUtils.LaborIndrectCalc: Error formatting transaction times.");
            }
            transtimeChange = dbltransTime - dbllasttransTime;
            try
            {
                jobGraceMin = Convert.ToInt16(GetDCJobGraceTime(), CultureInfo.InvariantCulture); // FTDEV-9247
            }
            catch (FormatException)
            {//we had a error converting the job grace time.  Keep going and use the default value of 0.
             //Console.WriteLine("ALaborUtils.LaborIndrectCalc: Error formatting job grace time.");
            }
            #endregion
            if (transtimeChange > 0) //in seconds
            {//dbltranstime is bigger.  This should allways be the case.
                if (transtimeChange > (jobGraceMin * 60) || (transtype == "4"))
                {//we are after the job grace time.  add indirect labor
                    tmpDateStart = currentDateTime.Date;//Convert.ToDateTime(transDate + " " + dbllasttransTime);
                    tmpDateStart = tmpDateStart.AddSeconds(dbllasttransTime);
                    tmpDateEnd = currentDateTime.Date;//Convert.ToDateTime(transDate + " " + dbltransTime);
                    //if (!string.IsNullOrEmpty(Convert.ToString(lunchStartTime)))
                    //    dbltransTime = lunchStartTime.Value.TimeOfDay.TotalSeconds;
                    tmpDateEnd = tmpDateEnd.AddSeconds(dbltransTime);
                    CreateIndirect(employee, shift, deviceID, tmpDateStart, tmpDateEnd);
                    SplitLastTransRTOTDT(tmpDateEnd, employee);  //In this instance sometimes CreateIndirect miscalculates the overtime/doble time.  Call SplitLastTransRTOTDT to make sure the last indirect record was calculated correctly. JH: 2012/06/25   
                }
                else
                {//we are with in the job grace time. adjust the last labor record.
                    if (lastTrans[4] == "3")
                    {//last trans was lunch in
                        Employeedata = GetEmployeeDetails(employee);

                        if (Employeedata[0, "LunchAuto"].Value == "1")
                        {//if auto lunch is true then we can not change the lunch transaction.  
                            return lastTrans[1];  //return the last transactions time
                        }
                        else
                        {
                            tmpDateEnd = currentDateTime;
                            UpdateTrans(lastTrans[0], tmpDateEnd, lastTrans[2], lastTrans[3], lastTrans[7]);
                            SplitLastTransRTOTDT(tmpDateEnd, employee); //we updated the last transaction so we have to recalculate the OT and DT limits. 2012/06/06 JH
                            if ((lastTrans[6] != "") || (lastTrans[6] != null))
                            {//adjust the machine record to match.
                                UpdateTrans(lastTrans[0], tmpDateEnd, lastTrans[5], lastTrans[6], lastTrans[7]);
                            }
                        }
                    }
                    else
                    {
                        if (lastTrans[4] == "1")
                        {//last record was a login can not adjust the log in. return the new start time
                            retVal = lastTrans[1]; //labor start needs the number of seconds.
                            //double dbltmpTime = 0;
                            //dbltmpTime = Convert.ToDouble(lastTrans[1], CultureInfo.InvariantCulture); // FTDEV-9247
                            //tmpDate = currentDateTime.Date;
                            //tmpDate = tmpDate.AddSeconds(dbltmpTime);
                            //retVal = tmpDate.TimeOfDay.ToString();
                        }
                        else
                        {
                            tmpDateEnd = currentDateTime;
                            UpdateTrans(lastTrans[0], tmpDateEnd, lastTrans[2], lastTrans[3], lastTrans[7]);
                            SplitLastTransRTOTDT(tmpDateEnd, employee); //we updated the last transaction so we have to recalculate the OT and DT limits. 2012/06/06 JH
                            if ((lastTrans[6] != "") || (lastTrans[6] != null))
                            {//adjust the machine record to match.
                                UpdateTrans(lastTrans[0], tmpDateEnd, lastTrans[5], lastTrans[6], lastTrans[7]);
                            }
                        }
                    }


                }

            }

            return retVal;
        }
        public string UpdateLaborRecords(string employee, string shift, string deviceID, string transDate, DateTime transactionDate)
        {
            string retVal = "";
            //job grace period variables.
            List<string> lastTrans = new List<string> { };
            double transtimeChange = 0, dbltransTime = 0, dbllasttransTime = 0;
            int jobGraceMin = 0;
            DateTime currentDateTime = transactionDate;
            DateTime tmpDate = DateTime.MinValue, tmpDateStart = DateTime.MinValue, tmpDateEnd = DateTime.MinValue;

            //employee data for auto lunch check.
            LoadCollectionResponseData Employeedata = null;

            #region last trans times
            lastTrans = GetLastTrans(employee, transDate, transDate);

            try
            {
                dbltransTime = Convert.ToDouble(currentDateTime.TimeOfDay.TotalSeconds, CultureInfo.InvariantCulture); // FTDEV-9247
                dbllasttransTime = Convert.ToDouble(lastTrans[1], CultureInfo.InvariantCulture); // FTDEV-9247
            }
            catch (FormatException)
            {//we had a error converting the transaction times. Keep going and use the default value of 0.
             //Console.WriteLine("ALaborUtils.LaborIndrectCalc: Error formatting transaction times.");
            }
            transtimeChange = dbltransTime - dbllasttransTime;
            try
            {
                jobGraceMin = Convert.ToInt16(GetDCJobGraceTime(), CultureInfo.InvariantCulture); // FTDEV-9247
            }
            catch (FormatException)
            {//we had a error converting the job grace time.  Keep going and use the default value of 0.
             //Console.WriteLine("ALaborUtils.LaborIndrectCalc: Error formatting job grace time.");
            }
            #endregion

            //we are with in the job grace time. adjust the last labor record.
            if (lastTrans[4] == "3")
            {//last trans was lunch in
                Employeedata = GetEmployeeDetails(employee);

                if (Employeedata[0, "LunchAuto"].Value == "1")
                {//if auto lunch is true then we can not change the lunch transaction.  
                    return lastTrans[1];  //return the last transactions time
                }
                else
                {
                    tmpDateEnd = currentDateTime;
                    UpdateTrans(lastTrans[0], tmpDateEnd, lastTrans[2], lastTrans[3], lastTrans[7]);
                    SplitLastTransRTOTDT(tmpDateEnd, employee); //we updated the last transaction so we have to recalculate the OT and DT limits. 2012/06/06 JH
                    if ((lastTrans[6] != "") || (lastTrans[6] != null))
                    {//adjust the machine record to match.
                        UpdateTrans(lastTrans[0], tmpDateEnd, lastTrans[5], lastTrans[6], lastTrans[7]);
                    }
                }
            }
            else
            {
                if (lastTrans[4] == "1")
                {//last record was a login can not adjust the log in. return the new start time
                    retVal = lastTrans[1]; //labor start needs the number of seconds.
                                           //double dbltmpTime = 0;
                                           //dbltmpTime = Convert.ToDouble(lastTrans[1], CultureInfo.InvariantCulture); // FTDEV-9247
                                           //tmpDate = currentDateTime.Date;
                                           //tmpDate = tmpDate.AddSeconds(dbltmpTime);
                                           //retVal = tmpDate.TimeOfDay.ToString();
                }
                else
                {
                    tmpDateEnd = currentDateTime;
                    UpdateTrans(lastTrans[0], tmpDateEnd, lastTrans[2], lastTrans[3], lastTrans[7]);
                    SplitLastTransRTOTDT(tmpDateEnd, employee); //we updated the last transaction so we have to recalculate the OT and DT limits. 2012/06/06 JH
                    if ((lastTrans[6] != "") || (lastTrans[6] != null))
                    {//adjust the machine record to match.
                        UpdateTrans(lastTrans[0], tmpDateEnd, lastTrans[5], lastTrans[6], lastTrans[7]);
                    }
                }
            }

            return retVal;
        }

    }
}
