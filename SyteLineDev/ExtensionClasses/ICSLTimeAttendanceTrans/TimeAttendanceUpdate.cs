using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using Mongoose.Core.Configuration;
using Mongoose.IDO.Protocol;
using Mongoose.IDO;
using Mongoose.Core;

namespace InforCollect.ERP.SL.ICSLTimeAttendanceTrans
{
    class TimeAttendanceUpdate : TimeAttendanceUtilities
    {
        private string EmpNum;
        private string transDate;
        private string transTime;
        private string transType;
        private string deviceId;
        private string userId;
        private bool stopLaborRecords;
        private bool recordMachineTime;
        private bool processRealTime;
        private bool taImplemented;
        private bool validatePreviousTARecord;
        private bool skipAutoLunchcheck = false;
        private string shift;

        private string errorMessage = "";
        //public bool processRealTime = false;
        //preform autolunch check.
        #region LocalVariables

        //Local Varialbles
        private Int64 nextTransNumber = -1;
        private LoadCollectionResponseData shiftResponseData = null;
        private LoadCollectionResponseData EmpResponseData = null;
        private DateTime currentDateTime = DateTime.Now;

        private DateTime shiftStartTime = DateTime.Now;
        private DateTime shiftEndTime = DateTime.Now;
        private DateTime lunchStartTime = DateTime.Now;
        private DateTime lunchEndTime = DateTime.Now;

        private double lunchhr = 0;  //Added for MSF161931  JH:20130506
        private int GrcShiftI = 0;
        private int GrcShiftO = 0;
        private int GrcLunchI = 0;
        private int GrcLunchO = 0;

        private bool AutoLunchEnabled = false;  //added for auto lunch calculations 2012/04/26 - JH

        //private bool taImplemented = false; //Do time and attendance related code: adc admin Time and Attendance Implemented        
        private bool DCJobGraceCheck = true; //added for Data Collection Job Grace time check.  2012/04/30 - JH
        string postRealTime = "";
        #endregion
        public TimeAttendanceUpdate(string EmpNum, string transDate, string transTime, string transType, string userId, string shift, string deviceId, string stopLaborRecords,
                    string recordMachineTime, string processRealTime, string taImplemented, string validatePreviousTARecord, string skipAutoLunchcheck, out string Infobar)
        {
            //check the ProcessRealTime
            //processRealTime= false;(Get the value from front end)
            postRealTime = processRealTime;
            Infobar = "";
            this.EmpNum = EmpNum;
            this.transDate = transDate;
            this.transTime = transTime;
            this.transType = transType;
            this.deviceId = deviceId;
            this.shift = shift;
            this.userId = userId;
            this.stopLaborRecords = (stopLaborRecords == "1") ? true : false;
            this.recordMachineTime = (recordMachineTime == "1") ? true : false;
            this.processRealTime = (processRealTime == "1") ? true : false;
            //this.processRealTime = false;
            this.taImplemented = (taImplemented == "1") ? true : false;
            this.validatePreviousTARecord = (validatePreviousTARecord == "1") ? true : false;
            this.skipAutoLunchcheck = (skipAutoLunchcheck == "1") ? true : false;

            //this.transDate = DateTime.ParseExact("Trans
        }
        public TimeAttendanceUpdate(string Empnum, string transDate, string TransTime, string userId, string Shift, string deviceId, out string Infobar)
        {
            Infobar = "";
            this.EmpNum = Empnum;
            this.transDate = transDate;
            this.transTime = TransTime;
            this.deviceId = deviceId;
            this.shift = Shift;
            this.userId = userId;
            this.taImplemented = true;
            this.processRealTime = false;
            this.skipAutoLunchcheck = false;
            this.transType = "100"; //passing dummy value

        }
        public int PerformUpdate(out string infobar)
        {
            infobar = "";
            //1 format inputs
            if (formatInputs() == false)
            {
                infobar = errorMessage;
                return 1;
            }

            //2 validate Inputs
            if (validateInputs() == false)
            {
                infobar = errorMessage;
                return 2;
            }


            //4 Perform Updates
            if (performTimeAttendanceUpdate(out infobar) == false)
            {
                infobar = errorMessage;
                infobar = formatResponse(infobar);
                return 3;
            }

            //if (PerformDelete(out infobar) == false)
            //{
            //    infobar = errorMessage;
            //    return 4;
            //}


            return 0;
        }
        public int PerformAdjustLaborRecords(out string Infobar)
        {
            Infobar = "";
            if (formatInputs() == false)
            {
                Infobar = errorMessage;
                return 1;
            }
            Infobar = UpdateLaborRecords(EmpNum, shift, deviceId, transDate, currentDateTime);
            if (Infobar.Contains("Error"))
            {
                return 2;
            }
            return 0;
        }
        public int PerformSpiltRecords(out string Infobar)
        {
            Infobar = "";
            if (formatInputs() == false)
            {
                Infobar = errorMessage;
                return 1;
            }
            if (SplitLastTransRTOTDT(currentDateTime, EmpNum) == false)
            {
                return 2;
            }
            return 0;
        }
        public bool formatInputs()
        {
            if (transType == null || transType.Trim().Equals(""))
            {
                errorMessage = "TransType input mandatory";
                return false;
            }
            EmpNum = formatDataByIDOAndPropertyName("SLEmployees", "EmpNum", EmpNum);
            if (EmpNum == null || EmpNum.Trim().Equals(""))
            {
                errorMessage = "Employee Number input mandatory";
                return false;
            }
            if (transDate == null || transDate.Trim().Equals(""))
            {
                errorMessage = "TransDate input mandatory";
                return false;
            }
            if (transTime == null || transTime.Trim().Equals(""))
            {
                errorMessage = "TransTime input mandatory";
                return false;
            }
            if (deviceId == null || deviceId.Trim().Equals(""))
            {
                errorMessage = "deviceId input mandatory";
                return false;
            }
            if (shift == null || shift.Trim().Equals(""))
            {
                errorMessage = "shift input mandatory";
                return false;
            }
            //we have the transaction date and time set the currentdatetime variable.
            try
            {//MSF157397: as a result of this issue we are adding a try catch and debug statement around date time conversions.  JH:20130116
             //Console.WriteLine("transDateTime string: " + transDate + " " + transTime);
             //we have the transaction date and time set the currentdatetime variable.
                currentDateTime = Convert.ToDateTime(transDate + " " + transTime);
                //Console.WriteLine("currentDateTime: " + currentDateTime.ToString(WMFullDateTimePattern));
            }
            catch (Exception)
            {
                //Console.WriteLine("Time Attendance exception: transaction date converstion failed. Date: " + transDate + " Time: " + transTime);
                errorMessage = constructErrorMessage("Date Time Conversion Failed", null, null);
                return false;
            }

            return true;
        }
        public bool validateInputs()
        {
            /* Needst to implement */
            // LoadCollectionResponseData EmpResponseData = null;
            EmpResponseData = GetSLEmployeeDetails(EmpNum);
            if (EmpResponseData.Items.Count == 0)
            {
                errorMessage = "Employee Details Not found";
                return false;
            }
            shiftResponseData = GetShiftDetails(shift);
            if (shiftResponseData.Items.Count == 0)
            {
                errorMessage = "Shift Details Not found";
                return false;
            }
            //EmpResponseData = GetSLEmployeeDetails(EmpNum);

            try
            {
                AutoLunchEnabled = Convert.ToBoolean(Convert.ToInt16(EmpResponseData[0, "LunchAuto"].Value)); //1 = enabled
            }
            catch
            { AutoLunchEnabled = false; }

            if ((!skipAutoLunchcheck) & (transType.Equals("3") || transType.Equals("4")))
            {//check to see if auto lunch is enabled.

                //if (Employeedata[0, "LunchAuto"].Value == "1")
                //if(AutoLunchEnabled)
                if ((taImplemented == true) & (AutoLunchEnabled == true) & (processRealTime == false))
                {//the employee has autolunch enabled. so we do not allow the user to manually lunch in/out
                    errorMessage = constructErrorMessage("Auto lunch is enabled.  Manual lunch is not allowed.", null, null);
                    return false;
                }
            }
            if (Convert.ToBoolean(validatePreviousTARecord) == true)
            {
                LoadCollectionResponseData clockPreviousRecords = GetLastRecordByEmployee(EmpNum);

                if (clockPreviousRecords.Items.Count == 0)
                {
                    //return true;
                }
                else
                {
                    if (clockPreviousRecords[0, "TransType"].ToString().Equals("1") || clockPreviousRecords[0, "TransType"].ToString().Equals("3")
                        || clockPreviousRecords[0, "TransType"].ToString().Equals("5") || clockPreviousRecords[0, "TransType"].ToString().Equals("7"))
                    {
                        if (transType.Equals("2") || transType.Equals("4") || transType.Equals("6") || transType.Equals("8"))
                        {
                            //return true;
                        }
                        else
                        {
                            errorMessage = constructErrorMessage("Transaction Type Must be either Clock-Out/Lunch-Out/Break-Out/Misc-Out", "-1", null);
                            return false;
                        }
                    }
                    else if (clockPreviousRecords[0, "TransType"].ToString().Equals("2"))
                    {
                        if (transType.Equals("1"))
                        {
                            //return true;
                        }
                        else
                        {
                            errorMessage = constructErrorMessage("Transaction Type Must be Clock-In", "-1", null);
                            return false;
                        }
                    }
                    else if (clockPreviousRecords[0, "TransType"].ToString().Equals("4"))
                    {
                        if (transType.Equals("3"))
                        {
                            //return true;
                        }
                        else
                        {
                            errorMessage = constructErrorMessage("Transaction Type Must be Lunch-In", "-1", null);
                            return false;
                        }
                    }
                    else if (clockPreviousRecords[0, "TransType"].ToString().Equals("6"))
                    {
                        if (transType.Equals("5"))
                        {
                            //return true;
                        }
                        else
                        {
                            errorMessage = constructErrorMessage("Transaction Type Must be Break-In", "-1", null);
                            return false;
                        }
                    }
                    else if (clockPreviousRecords[0, "TransType"].ToString().Equals("8"))
                    {
                        if (transType.Equals("7"))
                        {
                            //return true;
                        }
                        else
                        {
                            errorMessage = constructErrorMessage("Transaction Type Must be Misc-In", "-1", null);
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private bool adjustTimeBasedOnShiftRules()
        {
            string shiftStartString = "";
            string shiftEndString = "";
            string shiftHoursString = "";
            string lunchStartString = "";
            string lunchEndString = "";
            string lunchHoursString = "";
            //shiftResponseData = GetShiftDetails(shift);
            //job grace period variables.
            List<string> lastTrans = new List<string> { };
            double transtimeChange = 0, dbltransTime = 0, dbllasttransTime = 0;
            int jobGraceMin = 0;
            DateTime MShiftDate = DateTime.Now;
            DateTime tmpDate = DateTime.MinValue, tmpDateStart = DateTime.MinValue, tmpDateEnd = DateTime.MinValue, previousDate = currentDateTime, shiftDate = currentDateTime;
            string JobGraceCalc = "";
            LoadCollectionResponseData responseDataAttendance = GetAttendanceRecordByEmployeeTransType(EmpNum, "1", currentDateTime.Date.ToString("yyyy-MM-dd"));
            if (responseDataAttendance.Items.Count == 0 && transType == "2")
                previousDate = previousDate.AddDays(-1);
            switch (previousDate.DayOfWeek)
            {
                #region day of week check
                case DayOfWeek.Sunday:
                    shiftStartString = this.shiftResponseData[0, "ShiftStart_1"].ToString();
                    shiftEndString = this.shiftResponseData[0, "ShiftEnd_1"].ToString();
                    lunchStartString = this.shiftResponseData[0, "LunchStart_1"].ToString();
                    lunchEndString = this.shiftResponseData[0, "LunchEnd_1"].ToString();
                    shiftHoursString = this.shiftResponseData[0, "ShiftHrs_1"].ToString();
                    lunchHoursString = this.shiftResponseData[0, "LunchHrs_1"].ToString();
                    break;
                case DayOfWeek.Monday:
                    shiftStartString = this.shiftResponseData[0, "ShiftStart_2"].ToString();
                    shiftEndString = this.shiftResponseData[0, "ShiftEnd_2"].ToString();
                    lunchStartString = this.shiftResponseData[0, "LunchStart_2"].ToString();
                    lunchEndString = this.shiftResponseData[0, "LunchEnd_2"].ToString();
                    shiftHoursString = this.shiftResponseData[0, "ShiftHrs_2"].ToString();
                    lunchHoursString = this.shiftResponseData[0, "LunchHrs_2"].ToString();
                    break;
                case DayOfWeek.Tuesday:
                    shiftStartString = this.shiftResponseData[0, "ShiftStart_3"].ToString();
                    shiftEndString = this.shiftResponseData[0, "ShiftEnd_3"].ToString();
                    lunchStartString = this.shiftResponseData[0, "LunchStart_3"].ToString();
                    lunchEndString = this.shiftResponseData[0, "LunchEnd_3"].ToString();
                    shiftHoursString = this.shiftResponseData[0, "ShiftHrs_3"].ToString();
                    lunchHoursString = this.shiftResponseData[0, "LunchHrs_3"].ToString();
                    break;
                case DayOfWeek.Wednesday:
                    shiftStartString = this.shiftResponseData[0, "ShiftStart_4"].ToString();
                    shiftEndString = this.shiftResponseData[0, "ShiftEnd_4"].ToString();
                    lunchStartString = this.shiftResponseData[0, "LunchStart_4"].ToString();
                    lunchEndString = this.shiftResponseData[0, "LunchEnd_4"].ToString();
                    shiftHoursString = this.shiftResponseData[0, "ShiftHrs_4"].ToString();
                    lunchHoursString = this.shiftResponseData[0, "LunchHrs_4"].ToString();
                    break;
                case DayOfWeek.Thursday:
                    shiftStartString = this.shiftResponseData[0, "ShiftStart_5"].ToString();
                    shiftEndString = this.shiftResponseData[0, "ShiftEnd_5"].ToString();
                    lunchStartString = this.shiftResponseData[0, "LunchStart_5"].ToString();
                    lunchEndString = this.shiftResponseData[0, "LunchEnd_5"].ToString();
                    shiftHoursString = this.shiftResponseData[0, "ShiftHrs_5"].ToString();
                    lunchHoursString = this.shiftResponseData[0, "LunchHrs_5"].ToString();
                    break;
                case DayOfWeek.Friday:
                    shiftStartString = this.shiftResponseData[0, "ShiftStart_6"].ToString();
                    shiftEndString = this.shiftResponseData[0, "ShiftEnd_6"].ToString();
                    lunchStartString = this.shiftResponseData[0, "LunchStart_6"].ToString();
                    lunchEndString = this.shiftResponseData[0, "LunchEnd_6"].ToString();
                    shiftHoursString = this.shiftResponseData[0, "ShiftHrs_6"].ToString();
                    lunchHoursString = this.shiftResponseData[0, "LunchHrs_6"].ToString();
                    break;
                case DayOfWeek.Saturday:
                    shiftStartString = this.shiftResponseData[0, "ShiftStart_7"].ToString();
                    shiftEndString = this.shiftResponseData[0, "ShiftEnd_7"].ToString();
                    lunchStartString = this.shiftResponseData[0, "LunchStart_7"].ToString();
                    lunchEndString = this.shiftResponseData[0, "LunchEnd_7"].ToString();
                    shiftHoursString = this.shiftResponseData[0, "ShiftHrs_7"].ToString();
                    lunchHoursString = this.shiftResponseData[0, "LunchHrs_7"].ToString();
                    break;
                default:
                    break;
                    #endregion
            }

            try
            {
                shiftDate = previousDate;
                MShiftDate = previousDate.AddMinutes(Convert.ToInt32(this.shiftResponseData[0, "GrcShiftI"].ToString(), CultureInfo.InvariantCulture)); // FTDEV-9247
                //if (MShiftDate.Date.CompareTo(previousDate.Date) > 0 && currentDateTime.Date.CompareTo(MShiftDate.Date) > 0)
                if (MShiftDate.Date.CompareTo(previousDate.Date) > 0 && (currentDateTime.Date.CompareTo(MShiftDate.Date) > 0 || currentDateTime.Date.CompareTo(previousDate.Date) == 0 ))
                {
                    transDate = MShiftDate.ToString("yyyy-MM-dd");
                    shiftDate = MShiftDate;
                    if (currentDateTime.Date.CompareTo(previousDate.Date) == 0) // special case
                    {
                        switch (shiftDate.DayOfWeek)
                        {
                            #region day of week check
                            case DayOfWeek.Sunday:
                                shiftStartString = this.shiftResponseData[0, "ShiftStart_1"].ToString();
                                shiftEndString = this.shiftResponseData[0, "ShiftEnd_1"].ToString();
                                lunchStartString = this.shiftResponseData[0, "LunchStart_1"].ToString();
                                lunchEndString = this.shiftResponseData[0, "LunchEnd_1"].ToString();
                                shiftHoursString = this.shiftResponseData[0, "ShiftHrs_1"].ToString();
                                lunchHoursString = this.shiftResponseData[0, "LunchHrs_1"].ToString();
                                break;
                            case DayOfWeek.Monday:
                                shiftStartString = this.shiftResponseData[0, "ShiftStart_2"].ToString();
                                shiftEndString = this.shiftResponseData[0, "ShiftEnd_2"].ToString();
                                lunchStartString = this.shiftResponseData[0, "LunchStart_2"].ToString();
                                lunchEndString = this.shiftResponseData[0, "LunchEnd_2"].ToString();
                                shiftHoursString = this.shiftResponseData[0, "ShiftHrs_2"].ToString();
                                lunchHoursString = this.shiftResponseData[0, "LunchHrs_2"].ToString();
                                break;
                            case DayOfWeek.Tuesday:
                                shiftStartString = this.shiftResponseData[0, "ShiftStart_3"].ToString();
                                shiftEndString = this.shiftResponseData[0, "ShiftEnd_3"].ToString();
                                lunchStartString = this.shiftResponseData[0, "LunchStart_3"].ToString();
                                lunchEndString = this.shiftResponseData[0, "LunchEnd_3"].ToString();
                                shiftHoursString = this.shiftResponseData[0, "ShiftHrs_3"].ToString();
                                lunchHoursString = this.shiftResponseData[0, "LunchHrs_3"].ToString();
                                break;
                            case DayOfWeek.Wednesday:
                                shiftStartString = this.shiftResponseData[0, "ShiftStart_4"].ToString();
                                shiftEndString = this.shiftResponseData[0, "ShiftEnd_4"].ToString();
                                lunchStartString = this.shiftResponseData[0, "LunchStart_4"].ToString();
                                lunchEndString = this.shiftResponseData[0, "LunchEnd_4"].ToString();
                                shiftHoursString = this.shiftResponseData[0, "ShiftHrs_4"].ToString();
                                lunchHoursString = this.shiftResponseData[0, "LunchHrs_4"].ToString();
                                break;
                            case DayOfWeek.Thursday:
                                shiftStartString = this.shiftResponseData[0, "ShiftStart_5"].ToString();
                                shiftEndString = this.shiftResponseData[0, "ShiftEnd_5"].ToString();
                                lunchStartString = this.shiftResponseData[0, "LunchStart_5"].ToString();
                                lunchEndString = this.shiftResponseData[0, "LunchEnd_5"].ToString();
                                shiftHoursString = this.shiftResponseData[0, "ShiftHrs_5"].ToString();
                                lunchHoursString = this.shiftResponseData[0, "LunchHrs_5"].ToString();
                                break;
                            case DayOfWeek.Friday:
                                shiftStartString = this.shiftResponseData[0, "ShiftStart_6"].ToString();
                                shiftEndString = this.shiftResponseData[0, "ShiftEnd_6"].ToString();
                                lunchStartString = this.shiftResponseData[0, "LunchStart_6"].ToString();
                                lunchEndString = this.shiftResponseData[0, "LunchEnd_6"].ToString();
                                shiftHoursString = this.shiftResponseData[0, "ShiftHrs_6"].ToString();
                                lunchHoursString = this.shiftResponseData[0, "LunchHrs_6"].ToString();
                                break;
                            case DayOfWeek.Saturday:
                                shiftStartString = this.shiftResponseData[0, "ShiftStart_7"].ToString();
                                shiftEndString = this.shiftResponseData[0, "ShiftEnd_7"].ToString();
                                lunchStartString = this.shiftResponseData[0, "LunchStart_7"].ToString();
                                lunchEndString = this.shiftResponseData[0, "LunchEnd_7"].ToString();
                                shiftHoursString = this.shiftResponseData[0, "ShiftHrs_7"].ToString();
                                lunchHoursString = this.shiftResponseData[0, "LunchHrs_7"].ToString();
                                break;
                            default:
                                break;
                                #endregion
                        }
                    }
                }
                else
                {
                    transDate = currentDateTime.ToString("yyyy-MM-dd");
                }

                lunchhr = Convert.ToDouble(lunchHoursString, CultureInfo.InvariantCulture);//MSF161931: We need to check for 0 hr lunch  JH:20130506 // FTDEV-9247
                shiftStartTime = Convert.ToDateTime(shiftDate.ToString("yyyy-MM-dd") + " " + shiftStartString.Substring(shiftStartString.IndexOf(" ") + 1));
                shiftEndTime = Convert.ToDateTime(currentDateTime.ToString("yyyy-MM-dd") + " " + shiftEndString.Substring(shiftEndString.IndexOf(" ") + 1));
                lunchStartTime = Convert.ToDateTime(shiftDate.ToString("yyyy-MM-dd") + " " + lunchStartString.Substring(lunchStartString.IndexOf(" ") + 1));
                lunchEndTime = Convert.ToDateTime(shiftDate.ToString("yyyy-MM-dd") + " " + lunchEndString.Substring(lunchEndString.IndexOf(" ") + 1));

                if (transType.Equals("2")) // special case for clock out adjustment around midnight
                {
                    MShiftDate = currentDateTime.AddMinutes(-Convert.ToInt32(this.shiftResponseData[0, "GrcShiftI"].ToString(), CultureInfo.InvariantCulture)); // FTDEV-9247
                    //if (MShiftDate.ToString("yyyy-MM-dd") != currentDateTime.Date.ToString("yyyy-MM-dd"))
                    if (MShiftDate.Date.CompareTo(currentDateTime.Date) < 0)
                    {
                        shiftEndTime = Convert.ToDateTime(MShiftDate.ToString("yyyy-MM-dd") + " " + shiftEndString.Substring(shiftEndString.IndexOf(" ") + 1));
                    }

                    transDate = MShiftDate.ToString("yyyy-MM-dd");
                }

            }
            catch
            {
                //MSF157397: as a result of this issue we are adding a try catch and debug statement around date time conversions.  JH:20130128
                //Console.WriteLine("shiftStartTime, shiftEndTime, lunchStartTime, lunchEndTime conversion error");
            }
            #region shift grace
            GrcShiftI = 0;
            GrcShiftO = 0;
            GrcLunchI = 0;
            GrcLunchO = 0;

            try
            {
                GrcShiftI = Convert.ToInt32(this.shiftResponseData[0, "GrcShiftI"].ToString(), CultureInfo.InvariantCulture); // FTDEV-9247
            }
            catch (Exception)
            {
            }

            try
            {
                GrcShiftO = Convert.ToInt32(this.shiftResponseData[0, "GrcShiftO"].ToString(), CultureInfo.InvariantCulture); // FTDEV-9247
            }
            catch (Exception)
            {
            }

            try
            {
                GrcLunchI = Convert.ToInt32(this.shiftResponseData[0, "GrcLunchI"].ToString(), CultureInfo.InvariantCulture); // FTDEV-9247
            }
            catch (Exception)
            {
            }

            try
            {
                GrcLunchO = Convert.ToInt32(this.shiftResponseData[0, "GrcLunchO"].ToString(), CultureInfo.InvariantCulture); // FTDEV-9247
            }
            catch (Exception)
            {
            }
            #endregion
            //1 - Clock In 
            //2 - Clock Out
            //3 - Lunch In 
            //4 - Lunch Out

            if (transType.Equals("1"))
            {
                #region clock in
                if (currentDateTime.CompareTo(shiftStartTime) < 0)
                {//check for early clock-in
                    if (((shiftStartTime.Subtract(currentDateTime)).Ticks) / (10000 * 1000 * 60) <= GrcShiftI)
                    {
                        currentDateTime = shiftStartTime;
                    }
                }
                else if (currentDateTime.CompareTo(shiftStartTime) > 0)
                { //check for late clock-in
                    if (((currentDateTime.Subtract(shiftStartTime)).Ticks) / (10000 * 1000 * 60) <= GrcShiftO)
                    {
                        currentDateTime = shiftStartTime;
                    }
                }
                #endregion
            }
            else if (transType.Equals("2")) //clock out
            {//currentDateTime is used as the new clock out record's time.
                #region clock out

                //if (DCJobGraceCheck & taImplemented)//flag so we can turn off job grace check. 
                if ((processRealTime == false) & (taImplemented == true))
                {
                    if (currentDateTime.CompareTo(shiftEndTime) < 0)
                    {//we are before the shift ends.
                        #region before shift
                        //check shift grace time  .TotalMinutes
                        if (((shiftEndTime.Subtract(currentDateTime)).TotalMinutes) <= GrcShiftO) //chagned from minutes (is the minutes part of the time) to total minutes (is the total minuets for the day) JH: 20120625
                                                                                                  //   (500-455) <= 10    :: 5 <= 10
                        {//before the shift end and within(less) the shift grace time.  Out endtime = shift end.
                            #region before the shift ends - less than the shift grace
                            #region last trans times
                            //if (shiftStartTime > shiftEndTime)
                            //    lastTrans = GetLastTrans(EmpNum, shiftStartTime.Date.ToString("yyyy-MM-dd"));
                            //else
                            lastTrans = GetLastTrans(EmpNum, transDate, shiftStartTime.ToString("yyyy-MM-dd"));
                            currentDateTime = shiftEndTime;
                            try
                            {
                                dbltransTime = Convert.ToDouble(shiftEndTime.TimeOfDay.TotalSeconds, CultureInfo.InvariantCulture);  //the log out time becomes the end of the shift. // FTDEV-9247
                                dbllasttransTime = Convert.ToDouble(lastTrans[1], CultureInfo.InvariantCulture); // FTDEV-9247
                            }
                            catch (FormatException)
                            {//we had a error converting the transaction times. Keep going and use the default value of 0.
                             //Console.WriteLine("TimeAttendanceDaoImpl.adjustTimeBasedOnShiftRules: Error formatting transaction times.");
                            }
                            transtimeChange = dbltransTime - dbllasttransTime;
                            try
                            {
                                jobGraceMin = Convert.ToInt16(GetDCJobGraceTime(), CultureInfo.InvariantCulture); // FTDEV-9247
                            }
                            catch (FormatException)
                            {//we had a error converting the job grace time.  Keep going and use the default value of 0.
                             //Console.WriteLine("TimeAttendanceDaoImpl.adjustTimeBasedOnShiftRules: Error formatting job grace time.");
                            }
                            #endregion
                            if (transtimeChange > 0 || (currentDateTime.Date.CompareTo(previousDate.Date) > 0)) //in seconds
                            {//dbltranstime is bigger.  This should allways be the case.
                             // if (transtimeChange > (jobGraceMin * 60))
                             // {//we are after the job grace time.  add indirect labor
                             //if (shiftStartTime > shiftEndTime)
                             //    tmpDateStart = currentDateTime.AddDays(-1).Date;//Convert.ToDateTime(transDate + " " + dbllasttransTime);
                             //else
                             //tmpDateStart = Convert.ToDateTime(transDate).Date;
                                if (!string.IsNullOrEmpty(lastTrans[8]))
                                {
                                    tmpDateStart = DateTime.ParseExact(lastTrans[8].Substring(0, lastTrans[8].IndexOf(".")), "yyyyMMdd HH:mm:ss", CultureInfo.CurrentCulture).AddSeconds(dbllasttransTime);
                                }
                                else
                                {
                                    tmpDateStart = Convert.ToDateTime(transDate).Date;
                                    tmpDateStart = tmpDateStart.AddSeconds(dbllasttransTime);
                                }

                                tmpDateEnd = currentDateTime.Date;//Convert.ToDateTime(transDate + " " + dbltransTime);
                                tmpDateEnd = tmpDateEnd.AddSeconds(dbltransTime);
                                if (tmpDateEnd.Date.CompareTo(tmpDateStart.Date) == 0 && tmpDateStart > tmpDateEnd)
                                {
                                    tmpDateEnd = tmpDateStart;
                                    currentDateTime = tmpDateEnd;
                                }
                                //->CreateIndirect(employee, shift,deviceId, tmpDateStart, tmpDateEnd, userInitials:userInitials);
                                AddIndirectWithAutoLunch(EmpNum, shift, deviceId, tmpDateStart, tmpDateEnd, userId); //added this method to add auto lunch records and split the indirect labor.  JH:2012/06/25
                                                                                                                     //}
                                                                                                                     //else
                                                                                                                     //{//we are with in the job grace time. adjust the last labor record.
                                                                                                                     //    tmpDateEnd = currentDateTime;
                                                                                                                     //    UpdateTrans(lastTrans[0], tmpDateEnd, lastTrans[2], lastTrans[3], lastTrans[7]);

                                //    if (lastTrans[5] != "")
                                //    {//we have machine and run records update both.
                                //        UpdateTrans(lastTrans[0], tmpDateEnd, lastTrans[5], lastTrans[6], lastTrans[7]);
                                //    }
                                //    SplitLastTransRTOTDT(tmpDateEnd,EmpNum); //we updated the last transaction so we have to recalculate the OT and DT limits. 2012/06/06 JH

                                //}
                                //add clock out record with the current date time.
                            }
                            #endregion
                        }
                        else
                        //   (500-445) <= 10    :: 30 <= 10
                        {//before the shift ends and outside of (more) the shift grace time.
                            #region before the shift ends - more than the shift grace
                            #region last trans times
                            //if (shiftStartTime > shiftEndTime)
                            //    lastTrans = GetLastTrans(EmpNum, shiftStartTime.Date.ToString("yyyy-MM-dd"));
                            //else
                            lastTrans = GetLastTrans(EmpNum, transDate, shiftStartTime.ToString("yyyy-MM-dd"));
                            //currentDateTime = shiftEndTime;  //do not change the transaction date time.
                            try
                            {
                                dbltransTime = currentDateTime.TimeOfDay.TotalSeconds;  //the log out time becomes the end of the shift.
                                dbllasttransTime = Convert.ToDouble(lastTrans[1], CultureInfo.InvariantCulture); // FTDEV-9247
                            }
                            catch (FormatException)
                            {//we had a error converting the transaction times. Keep going and use the default value of 0.
                             //Console.WriteLine("TimeAttendanceDaoImpl.adjustTimeBasedOnShiftRules: Error formatting transaction times.");
                            }
                            transtimeChange = dbltransTime - dbllasttransTime;
                            try
                            {
                                jobGraceMin = Convert.ToInt16(GetDCJobGraceTime(), CultureInfo.InvariantCulture); // FTDEV-9247
                            }
                            catch (FormatException)
                            {//we had a error converting the job grace time.  Keep going and use the default value of 0.
                             //Console.WriteLine("TimeAttendanceDaoImpl.adjustTimeBasedOnShiftRules: Error formatting job grace time.");
                            }
                            #endregion
                            if (transtimeChange > 0 || (currentDateTime.Date.CompareTo(previousDate.Date) > 0)) //in seconds
                            {//dbltranstime is bigger.  This should allways be the case.
                             //if (transtimeChange > (jobGraceMin * 60))
                             //{//we are after the job grace time.  add indirect labor
                             //if (shiftStartTime > shiftEndTime)
                             //    tmpDateStart = currentDateTime.AddDays(-1).Date;//Convert.ToDateTime(transDate + " " + dbllasttransTime);
                             //else
                                if (!string.IsNullOrEmpty(lastTrans[8]))
                                {
                                    tmpDateStart = DateTime.ParseExact(lastTrans[8].Substring(0, lastTrans[8].IndexOf(".")), "yyyyMMdd HH:mm:ss", CultureInfo.CurrentCulture).AddSeconds(dbllasttransTime);
                                }
                                else
                                {
                                    tmpDateStart = Convert.ToDateTime(transDate).Date;
                                    tmpDateStart = tmpDateStart.AddSeconds(dbllasttransTime);
                                }
                                tmpDateEnd = currentDateTime.Date;//Convert.ToDateTime(transDate + " " + dbltransTime);
                                tmpDateEnd = tmpDateEnd.AddSeconds(dbltransTime);
                                if (tmpDateEnd.Date.CompareTo(tmpDateStart.Date) == 0 && tmpDateStart > tmpDateEnd)
                                {
                                    tmpDateEnd = tmpDateStart;
                                    currentDateTime = tmpDateEnd;
                                }
                                //-> CreateIndirect(employee, shift, deviceId, tmpDateStart, tmpDateEnd, userInitials: userInitials);
                                AddIndirectWithAutoLunch(EmpNum, shift, deviceId, tmpDateStart, tmpDateEnd, userId); //added this method to add auto lunch records and split the indirect labor.  JH:2012/06/25
                                                                                                                     //}
                                                                                                                     //else
                                                                                                                     //{//we are with in the job grace time. adjust the last labor record.
                                                                                                                     //    tmpDateEnd = currentDateTime;
                                                                                                                     //    UpdateTrans(lastTrans[0], tmpDateEnd, lastTrans[2], lastTrans[3], lastTrans[7]);
                                                                                                                     //    if (lastTrans[5] != "")
                                                                                                                     //    {//we have machine and run records update both.
                                                                                                                     //        UpdateTrans(lastTrans[0], tmpDateEnd, lastTrans[5], lastTrans[6], lastTrans[7]);
                                                                                                                     //    }
                                                                                                                     //    SplitLastTransRTOTDT(tmpDateEnd, EmpNum); //we updated the last transaction so we have to recalculate the OT and DT limits. 2012/06/06 JH
                                                                                                                     //}
                                                                                                                     //add clock out record with the current date time.
                            }
                            #endregion
                        }
                        #endregion
                    }
                    else
                    {//we are after the shift
                        #region after shift

                        //check shift grace time
                        if (((currentDateTime.Subtract(shiftEndTime)).TotalMinutes) <= GrcShiftI)
                        //   (510-500) <= 10    :: 15 <= 10
                        {//after the shift end and within(less) the shift grace time.  Out endtime = shift end.
                            #region after the shift ends - less than the shift grace
                            #region last trans times
                            //if (shiftStartTime > shiftEndTime)
                            //    lastTrans = GetLastTrans(EmpNum, shiftStartTime.Date.ToString("yyyy-MM-dd"));
                            //else
                            lastTrans = GetLastTrans(EmpNum, transDate, shiftStartTime.ToString("yyyy-MM-dd"));
                            tmpDate = currentDateTime; //keep the actual transaction time 
                            currentDateTime = shiftEndTime;
                            try
                            {
                                dbltransTime = Convert.ToDouble(shiftEndTime.TimeOfDay.TotalSeconds, CultureInfo.InvariantCulture);  //the log out time becomes the end of the shift. // FTDEV-9247
                                dbllasttransTime = Convert.ToDouble(lastTrans[1], CultureInfo.InvariantCulture); // FTDEV-9247
                            }
                            catch (FormatException)
                            {//we had a error converting the transaction times. Keep going and use the default value of 0.
                             //Console.WriteLine("TimeAttendanceDaoImpl.adjustTimeBasedOnShiftRules: Error formatting transaction times.");
                            }
                            transtimeChange = dbltransTime - dbllasttransTime;
                            try
                            {
                                jobGraceMin = Convert.ToInt16(GetDCJobGraceTime(), CultureInfo.InvariantCulture); // FTDEV-9247
                            }
                            catch (FormatException)
                            {//we had a error converting the job grace time.  Keep going and use the default value of 0.
                             //Console.WriteLine("TimeAttendanceDaoImpl.adjustTimeBasedOnShiftRules: Error formatting job grace time.");
                            }
                            #endregion
                            if (transtimeChange > 0 || (currentDateTime.Date.CompareTo(previousDate.Date) > 0)) //in seconds
                            {//dbltranstime is bigger then the last trans.  
                             // clockout = shift end    last trans = ?? add indirect = ??
                             // if (transtimeChange > (jobGraceMin * 60))
                             // {//we are after the job grace time.  add indirect labor
                             //if (shiftStartTime > shiftEndTime)
                             //    tmpDateStart = currentDateTime.AddDays(-1).Date;//Convert.ToDateTime(transDate + " " + dbllasttransTime);
                             //else
                                if (!string.IsNullOrEmpty(lastTrans[8]))
                                {
                                    tmpDateStart = DateTime.ParseExact(lastTrans[8].Substring(0, lastTrans[8].IndexOf(".")), "yyyyMMdd HH:mm:ss", CultureInfo.CurrentCulture).AddSeconds(dbllasttransTime);
                                }
                                else
                                {
                                    tmpDateStart = Convert.ToDateTime(transDate).Date;
                                    tmpDateStart = tmpDateStart.AddSeconds(dbllasttransTime);
                                }
                                tmpDateEnd = currentDateTime.Date;//Convert.ToDateTime(transDate + " " + dbltransTime);
                                tmpDateEnd = tmpDateEnd.AddSeconds(dbltransTime);
                                //check to see if it crosses lunch.
                                //if (tmpDateStart > lunchStartTime) and (tmpDateStart < lunchEndTime)
                                //{//the start time is between the lunch time
                                //}
                                //else
                                //if (tmpDateEnd > lunchStartTime) and (tmpDateEnd < lunchEndTime)
                                //{//the end time is between the lunch time
                                //}
                                if (tmpDateEnd.Date.CompareTo(tmpDateStart.Date) == 0 && tmpDateStart > tmpDateEnd)
                                {
                                    tmpDateEnd = tmpDateStart;
                                    currentDateTime = tmpDateEnd;
                                }
                                //AddIndirectWithAutoLunch(EmpNum, shift, deviceId, tmpDateStart, tmpDateEnd, userId);
                                //->CreateIndirect(employee, shift, deviceId, tmpDateStart, tmpDateEnd, userInitials: userInitials);

                                //tmpDateStart = Convert.ToDateTime(transDate + " " + dbllasttransTime);
                                //tmpDateEnd = Convert.ToDateTime(transDate + " " + dbltransTime);
                                //CreateIndirect(tmpDateStart, tmpDateEnd);
                                //}
                                //else
                                //{//we are with in the job grace time. adjust the last labor record.
                                //    tmpDateEnd = currentDateTime;
                                //    UpdateTrans(lastTrans[0], tmpDateEnd, lastTrans[2], lastTrans[3], lastTrans[7]);
                                //    if (lastTrans[5] != "")
                                //    {//we have machine and run records update both.
                                //        UpdateTrans(lastTrans[0], tmpDateEnd, lastTrans[5], lastTrans[6], lastTrans[7]);
                                //    }
                                //    SplitLastTransRTOTDT(tmpDateEnd, EmpNum); //we updated the last transaction so we have to recalculate the OT and DT limits. 2012/06/06 JH
                                //}
                                //add clock out record with the current date time.
                            }
                            else
                            {//the last transaction is after the shift.
                             // clockout = shift end    last trans = shift end.
                             //Since we adjusted the clockout we need to adjust the job record.

                                /* Get all transactions that end after tmpDateEnd
                                 * and update them to end at tmpDateEnd, if the update would not make a negative record.
                                 * If it would make a negative record, delete it instead.
                                 */
                                tmpDateEnd = currentDateTime;

                                LoadCollectionRequestData requestData = new LoadCollectionRequestData();
                                requestData.IDOName = "SLJobTrans";
                                requestData.PropertyList.SetProperties("RecordDate, RowPointer, StartTime, TransNum");
                                requestData.Filter = "EmpNum = '" + EmpNum + "'";
                                requestData.Filter += " and TransType IN ('R', 'S', 'I')";
                                requestData.Filter += " and TransDate = '" + tmpDateEnd.ToString(WMShortDatePattern) + "'";
                                requestData.Filter += " and EndTime >= '" + Math.Round(tmpDateEnd.TimeOfDay.TotalSeconds).ToString() + "'";
                                requestData.Filter += " and Posted = 0";
                                requestData.OrderBy = "EndTime";
                                requestData.RecordCap = -1;
                                LoadCollectionResponseData responseData = ExcuteQueryRequest(requestData);

                                for (int i = 0; i < responseData.Items.Count; i++)
                                {
                                    string recordDate = responseData.Items[i].PropertyValues[0].ToString();
                                    string rowPointer = responseData.Items[i].PropertyValues[1].ToString();
                                    string startTimeSec = responseData.Items[i].PropertyValues[2].ToString();
                                    string transNum = responseData.Items[i].PropertyValues[3].ToString();

                                    double start = -999, newEnd = -999;
                                    try
                                    {
                                        start = Convert.ToDouble(startTimeSec, CultureInfo.InvariantCulture); // FTDEV-9247
                                        newEnd = Math.Round(tmpDateEnd.TimeOfDay.TotalSeconds);
                                    }
                                    catch { }
                                    if (start != -999 && newEnd != -999 && (newEnd < start))
                                    {   // If the time converted successfully and the new end time is before the start time, delete the record.
                                        performDeleteJobTran(transNum, recordDate, rowPointer);
                                    } else
                                    { // update the jobtran end time
                                        UpdateTrans(@"labor", tmpDateEnd, recordDate, rowPointer, startTimeSec);
                                    }
                                }
                                SplitLastTransRTOTDT(tmpDateEnd, EmpNum); //we updated the last transaction so we have to recalculate the OT and DT limits. 2012/06/06 JH
                            }
                            #endregion
                        }
                        else
                        //   (500-430) <= 10    :: 30 <= 10
                        {//after the shift ends and outside of (more) the shift grace time.
                            #region after the shift ends - more than the shift grace
                            #region last trans times
                            //if (shiftStartTime > shiftEndTime)
                            //    lastTrans = GetLastTrans(EmpNum, shiftStartTime.Date.ToString("yyyy-MM-dd"));
                            //else
                            lastTrans = GetLastTrans(EmpNum, transDate, shiftStartTime.ToString("yyyy-MM-dd"));
                            //currentDateTime = shiftEndTime;  //do not change the transaction date time.
                            try
                            {
                                dbltransTime = currentDateTime.TimeOfDay.TotalSeconds;  //the log out time becomes the end of the shift.
                                dbllasttransTime = Convert.ToDouble(lastTrans[1], CultureInfo.InvariantCulture); // FTDEV-9247

                            }
                            catch (FormatException)
                            {//we had a error converting the transaction times. Keep going and use the default value of 0.
                             //Console.WriteLine("TimeAttendanceDaoImpl.adjustTimeBasedOnShiftRules: Error formatting transaction times.");
                            }
                            transtimeChange = dbltransTime - dbllasttransTime;
                            try
                            {
                                jobGraceMin = Convert.ToInt16(GetDCJobGraceTime(), CultureInfo.InvariantCulture); // FTDEV-9247
                            }
                            catch (FormatException)
                            {//we had a error converting the job grace time.  Keep going and use the default value of 0.
                             //Console.WriteLine("TimeAttendanceDaoImpl.adjustTimeBasedOnShiftRules: Error formatting job grace time.");
                            }
                            #endregion
                            if (transtimeChange > 0 || (currentDateTime.Date.CompareTo(previousDate.Date) > 0)) //in seconds
                            {//dbltranstime is bigger.  This should allways be the case.
                             // if (transtimeChange > (jobGraceMin * 60))
                             // {//we are after the job grace time.  add indirect labor
                             //if (shiftStartTime > shiftEndTime)
                             //    tmpDateStart = currentDateTime.AddDays(-1).Date;//Convert.ToDateTime(transDate + " " + dbllasttransTime);
                             //else
                                if (!string.IsNullOrEmpty(lastTrans[8]))
                                {
                                    tmpDateStart = DateTime.ParseExact(lastTrans[8].Substring(0, lastTrans[8].IndexOf(".")), "yyyyMMdd HH:mm:ss", CultureInfo.CurrentCulture).AddSeconds(dbllasttransTime);
                                }
                                else
                                {
                                    tmpDateStart = Convert.ToDateTime(transDate).Date;
                                    tmpDateStart = tmpDateStart.AddSeconds(dbllasttransTime);
                                }
                                tmpDateEnd = currentDateTime.Date;//Convert.ToDateTime(transDate + " " + dbltransTime);
                                tmpDateEnd = tmpDateEnd.AddSeconds(dbltransTime);
                                if (tmpDateEnd.Date.CompareTo(tmpDateStart.Date) == 0 && tmpDateStart > tmpDateEnd)
                                {
                                    tmpDateEnd = tmpDateStart;
                                    currentDateTime = tmpDateEnd;
                                }
                                AddIndirectWithAutoLunch(EmpNum, shift, deviceId, tmpDateStart, tmpDateEnd, userId); //added this method to add auto lunch records and split the indirect labor.  JH:2012/06/25
                                                                                                                     //-> CreateIndirect(employee, shift, deviceId, tmpDateStart, tmpDateEnd);


                                //}
                                //else
                                //{//we are with in the job grace time. adjust the last labor record.
                                //    tmpDateEnd = currentDateTime;
                                //    UpdateTrans(lastTrans[0], tmpDateEnd, lastTrans[2], lastTrans[3], lastTrans[7]);
                                //    if (lastTrans[5] != "")
                                //    {//we have machine and run records update both.
                                //        UpdateTrans(lastTrans[0], tmpDateEnd, lastTrans[5], lastTrans[6], lastTrans[7]);
                                //    }
                                //    SplitLastTransRTOTDT(tmpDateEnd, EmpNum); //we updated the last transaction so we have to recalculate the OT and DT limits. 2012/06/06 JH
                                //}
                                //add clock out record with the current date time.
                            }
                            #endregion
                        }

                        #endregion

                    }

                }
                else
                {//job grace time should not be checked.
                    if (currentDateTime.CompareTo(shiftEndTime) < 0)
                    {//check for early clock-in
                        if (((shiftEndTime.Subtract(currentDateTime)).Ticks) / (10000 * 1000 * 60) <= GrcShiftO)
                        {
                            currentDateTime = shiftEndTime;
                        }
                    }
                    else if (currentDateTime.CompareTo(shiftEndTime) > 0)
                    { //check for late clock-in
                        if (((currentDateTime.Subtract(shiftEndTime)).Ticks) / (10000 * 1000 * 60) <= GrcShiftI)
                        {
                            currentDateTime = shiftEndTime;
                        }
                    }
                }
                #endregion
            }
            else if (transType.Equals("3"))
            {//lunch in
                #region lunch in
                if ((AutoLunchEnabled == true) && (skipAutoLunchcheck == true) && (processRealTime == false))
                {//the employee has auto lunch enabled but we are skipping the auto lunch check
                 //this is usually becase the labor transaction is giving the autolunch time.
                 //we want to use the transaction time.
                    currentDateTime = Convert.ToDateTime(transDate + " " + transTime);


                }
                else
                {//no auto lunch so do as normal
                    if (currentDateTime.CompareTo(lunchEndTime) < 0)
                    {//check for early clock-in
                        if (((lunchEndTime.Subtract(currentDateTime)).Ticks) / (10000 * 1000 * 60) <= GrcLunchI)
                        {
                            currentDateTime = lunchEndTime;
                        }
                    }
                    else if (currentDateTime.CompareTo(lunchEndTime) > 0)
                    { //check for late clock-in
                        if (((currentDateTime.Subtract(lunchEndTime)).Ticks) / (10000 * 1000 * 60) <= GrcLunchO)
                        {
                            currentDateTime = lunchEndTime;
                        }
                    }
                }
                #endregion
            }
            else if (transType.Equals("4"))
            {//lunch out
                #region lunch out
                if ((taImplemented == true) && (AutoLunchEnabled == true) && (skipAutoLunchcheck == true) && (processRealTime == false))
                {//the employee has auto lunch enabled but we are skipping the auto lunch check
                 //this is usually becase the labor transaction is giving the autolunch time.
                 //we want to use the transaction time.
                    try
                    {//MSF157397: as a result of this issue we are adding a try catch and debug statement around date time conversions.  JH:20130116
                        currentDateTime = Convert.ToDateTime(transDate + " " + transTime);
                    }
                    catch (Exception)
                    {
                        //Console.WriteLine("Time Attendance exception: transaction date converstion failed. Date: " + transDate + " Time: " + transTime);
                        errorMessage = constructErrorMessage("Date Time Conversion Failed", null, null);
                    }
                    if (DCJobGraceCheck)//flag so we can turn off job grace check. 
                    {
                        //JobGraceCalc = JobGraceIndirectCalc(EmpNum, shift, deviceId, transDate, currentDateTime);
                        if (JobGraceCalc != "")
                        {
                            if (!JobGraceCalc.Contains("Error"))
                            {//the method return the time that the new job should be set to.
                                tmpDateStart = currentDateTime.Date;
                                try
                                {
                                    dbllasttransTime = Convert.ToDouble(lastTrans[1], CultureInfo.InvariantCulture); // FTDEV-9247
                                }
                                catch (FormatException)
                                {//we had a error converting the transaction times. Keep going and use the default value of 0.
                                 //Console.WriteLine("TimeAttendanceDaoImpl.adjustTimeBasedOnShiftRules: Error formatting transaction times.");
                                }
                                tmpDateStart = tmpDateStart.AddSeconds(dbllasttransTime);
                                currentDateTime = tmpDateStart;

                            }
                        }
                    }
                }
                else
                {//no auto lunch so do as normal
                    if ((taImplemented == true) & (processRealTime == false) & (AutoLunchEnabled == false))
                    {//ta implemented is enabled but the employee does not have auto lunch set so we need to check the grace
                        JobGraceCalc = JobGraceIndirectCalc(EmpNum, shift, deviceId, transDate, currentDateTime, lunchStartTime, transType);
                        if (JobGraceCalc != "")
                        {
                            if (!JobGraceCalc.Contains("Error"))
                            {//the method return the time that the new job should be set to.
                                tmpDateStart = currentDateTime.Date;
                                try
                                {
                                    dbllasttransTime = Convert.ToDouble(lastTrans[1], CultureInfo.InvariantCulture); // FTDEV-9247
                                }
                                catch (FormatException)
                                {//we had a error converting the transaction times. Keep going and use the default value of 0.
                                 //Console.WriteLine("TimeAttendanceDaoImpl.adjustTimeBasedOnShiftRules: Error formatting transaction times.");
                                }
                                tmpDateStart = tmpDateStart.AddSeconds(dbllasttransTime);
                                currentDateTime = tmpDateStart;

                            }
                        }
                    }
                    if (currentDateTime.CompareTo(lunchStartTime) < 0)
                    {//check for early clock-in
                        if (((lunchStartTime.Subtract(currentDateTime)).Ticks) / (10000 * 1000 * 60) <= GrcLunchO)
                        {
                            currentDateTime = lunchStartTime;
                        }
                    }
                    else if (currentDateTime.CompareTo(lunchStartTime) > 0)
                    { //check for late clock-in
                        if (((currentDateTime.Subtract(lunchStartTime)).Ticks) / (10000 * 1000 * 60) <= GrcLunchI)
                        {
                            currentDateTime = lunchStartTime;
                        }
                    }
                }
                #endregion
            }
            else if (transType.Equals("8"))
            {//job grace adjustments


                //if (DCJobGraceCheck)//flag so we can turn off job grace check. 
                if ((processRealTime == false) & (taImplemented == true))
                {
                    JobGraceCalc = JobGraceIndirectCalc(EmpNum, shift, deviceId, transDate, currentDateTime);
                    if (JobGraceCalc != "")
                    {
                        if (!JobGraceCalc.Contains("Error"))
                        {//the method return the time that the new job should be set to.
                            tmpDateStart = currentDateTime.Date;
                            try
                            {
                                dbllasttransTime = Convert.ToDouble(lastTrans[1], CultureInfo.InvariantCulture); // FTDEV-9247
                            }
                            catch (FormatException)
                            {//we had a error converting the transaction times. Keep going and use the default value of 0.
                             //Console.WriteLine("TimeAttendanceDaoImpl.adjustTimeBasedOnShiftRules: Error formatting transaction times.");
                            }
                            tmpDateStart = tmpDateStart.AddSeconds(dbllasttransTime);
                            currentDateTime = tmpDateStart;

                        }
                    }
                }

            }


            return true;
        }
        private Boolean performTimeAttendanceUpdate(out string infobar)
        {
            infobar = "";
            adjustTimeBasedOnShiftRules();
            SxGetAutoNumberMax();
            UpdateCollectionRequestData updateRequestData = new UpdateCollectionRequestData();
            updateRequestData.IDOName = "SLDctas";
            updateRequestData.RefreshAfterUpdate = false;
            updateRequestData.CustomUpdate = "STD,AutoLunchCheckSp(EmpNum,Shift,PostDate,PostTime,,TransNum,Termid,,,0,0,,,'TAU',MESSAGE),REF";
            updateRequestData.CustomInsert = "STD,AutoLunchCheckSp(EmpNum,Shift,PostDate,PostTime,,TransNum,Termid,,,0,0,,,'TAU',MESSAGE),REF";


            IDOUpdateItem updateItem = new IDOUpdateItem();
            updateItem.Action = UpdateAction.Insert;

            updateItem.Properties.Add("TransNum", this.nextTransNumber);
            updateItem.Properties.Add("EmpNum", EmpNum);
            updateItem.Properties.Add("EmpName", GetPropertyValue(EmpResponseData, "Name"));
            updateItem.Properties.Add("NoteExistsFlag", "", false);
            //updateItem.Properties.Add("PostDate", currentDateTime.ToString("yyyy/MM/dd"));
            updateItem.Properties.Add("PostDate", currentDateTime.ToString(WMShortDatePattern));//MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128
            updateItem.Properties.Add("PostTime", Convert.ToInt64(currentDateTime.TimeOfDay.TotalSeconds, CultureInfo.InvariantCulture).ToString()); // FTDEV-9247
            updateItem.Properties.Add("RowPointer", "", false);
            updateItem.Properties.Add("Shift", shift);
            updateItem.Properties.Add("InWorkflow", "", false);
            updateItem.Properties.Add("_ItemWarnings", "", false);
            updateItem.Properties.Add("Termid", deviceId);
            updateItem.Properties.Add("EmpShift", shift);
            updateItem.Properties.Add("TransType", this.transType);
            updateItem.Properties.Add("ErrorMessage", "");
            updateItem.Properties.Add("Stat", "P");
            updateItem.Properties.Add("Override", "0");
            //updateItem.Properties.Add("derTransTimeFmt", currentDateTime.ToString("hh:mm:ss"));
            updateItem.Properties.Add("derTransTimeFmt", Convert.ToDateTime(transDate + " " + transTime).ToString(WMTimePattern)); //MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128
                                                                                                                                   //updateItem.Properties.Add("derPostTimeFmt", currentDateTime.ToString("HH:mm:ss"));
            updateItem.Properties.Add("derPostTimeFmt", currentDateTime.ToString(WMTimePattern)); //MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128
            updateItem.Properties.Add("TransTime", Convert.ToInt64(Convert.ToDateTime(transDate + " " + transTime).TimeOfDay.TotalSeconds, CultureInfo.InvariantCulture).ToString()); // FTDEV-9247
            //updateItem.Properties.Add("TransDate", currentDateTime.ToString("yyyy/MM/dd") + " " + "00:00:00");
            updateItem.Properties.Add("TransDate", currentDateTime.ToString(WMShortDatePattern) + " " + "00:00:00");//MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128


            updateItem.ItemID = "";
            updateItem.ItemNumber = 1;
            updateRequestData.Items.Add(updateItem);
            try
            {
                // UpdateCollectionResponseData updateResponseData = this.sytelineClient.UpdateCollection(updateRequestData);
                UpdateCollectionResponseData updateResponseData = this.Context.Commands.UpdateCollection(updateRequestData);
                //Console.WriteLine(updateResponseData.ToXml());
            }
            catch (Exception ee)
            {
                errorMessage = constructErrorMessage("Update Failed " + ee.Message, "", null);
                //Console.WriteLine(ee.Message);
                return false;
            }

            string returnString = "<Response>";
            returnString += "<output>";
            returnString += "<row>";
            returnString += "<TRANSACTION_STATUS>0</TRANSACTION_STATUS>";
            returnString += "</row>";
            returnString += "</output>";
            returnString += "</Response>";
            //return returnString;

            return true;
        }
        private bool SxGetAutoNumberMax()
        {
            object[] inputParams = new object[]{
                                                "TransNum",
                                                ""
                                                };

            InvokeResponseData responseData = InvokeIDO("SLDctas", "SxGetAutoNumberMax", inputParams);
            nextTransNumber = Convert.ToInt64(responseData.ReturnValue.ToString(), CultureInfo.InvariantCulture) + 1; // FTDEV-9247
            return true;

        }




        #region AutoLunch methods

        private string AddIndirectWithAutoLunch(string IndirectEmployee, string IndirectShift, string IndirectDeviceId, DateTime IndirectDtStart, DateTime IndirectDtEnd, string Indirectwhse = "", string IndirectuserInitials = "SA")
        {
            string retVal = "";
            string lunchdate = "";
            //MSF161931: We need to check for 0 hr lunch  JH:20130506
            if (lunchhr == 0)
            {//auto lunch can be enabled but today the employee does not get a lunch.
                retVal = CreateIndirect(IndirectEmployee, shift, IndirectDeviceId, IndirectDtStart, IndirectDtEnd, userId, "", postRealTime);
                return retVal;
            }
            if (!AutoLunchEnabled)
            {
                if (IndirectDtEnd.Date.CompareTo(IndirectDtStart.Date) > 0)
                {
                    lunchdate = IndirectDtStart.ToString("MMddyyyy");
                    retVal = CreateIndirect(IndirectEmployee, shift, IndirectDeviceId, IndirectDtStart, DateTime.ParseExact(lunchdate + " " + "2359", "MMddyyyy HHmm", CultureInfo.CurrentCulture), userId, "", postRealTime);
                    retVal = CreateIndirect(IndirectEmployee, shift, IndirectDeviceId, DateTime.ParseExact(IndirectDtEnd.ToString("MMddyyyy") + " " + "0000", "MMddyyyy HHmm", CultureInfo.CurrentCulture), IndirectDtEnd, userId, "", postRealTime);
                }
                else
                    retVal = CreateIndirect(IndirectEmployee, shift, IndirectDeviceId, IndirectDtStart, IndirectDtEnd, userId, "", postRealTime);
                return retVal;
            }
            //check to see if it crosses lunch.
            if ((IndirectDtStart < lunchStartTime) & (IndirectDtStart < lunchEndTime))
            {//the start time is between the lunch time
                if ((IndirectDtEnd > lunchStartTime) & (IndirectDtEnd > lunchEndTime))
                {//case 1                    
                    retVal = CreateIndirect(IndirectEmployee, shift, IndirectDeviceId, IndirectDtStart, lunchStartTime, userId, "", postRealTime);
                    retVal = CreateLunch(EmpNum, lunchStartTime.ToString("yyyy-MM-dd"), transTime, transType, userId, shift, deviceId, stopLaborRecords.ToString(),
                               recordMachineTime.ToString(), processRealTime.ToString(), taImplemented.ToString(), validatePreviousTARecord.ToString(), lunchStartTime, lunchEndTime);
                    if (IndirectDtEnd.Date.CompareTo(lunchEndTime.Date) > 0)
                    {
                        lunchdate = lunchEndTime.ToString("MMddyyyy");
                        retVal = CreateIndirect(IndirectEmployee, shift, IndirectDeviceId, lunchEndTime, DateTime.ParseExact(lunchdate + " " + "2359", "MMddyyyy HHmm", CultureInfo.CurrentCulture), userId, "", postRealTime);
                        retVal = CreateIndirect(IndirectEmployee, shift, IndirectDeviceId, DateTime.ParseExact(IndirectDtEnd.ToString("MMddyyyy") + " " + "0000", "MMddyyyy HHmm", CultureInfo.CurrentCulture), IndirectDtEnd, userId, "", postRealTime);
                    }
                    else
                        retVal = CreateIndirect(IndirectEmployee, shift, IndirectDeviceId, lunchEndTime, IndirectDtEnd, userId, "", postRealTime);
                }
                if ((IndirectDtEnd > lunchStartTime) & (IndirectDtEnd <= lunchEndTime))
                {//no change case 2
                    retVal = CreateIndirect(IndirectEmployee, shift, IndirectDeviceId, IndirectDtStart, lunchStartTime, userId, "", postRealTime);
                    retVal = CreateLunch(EmpNum, lunchStartTime.ToString("yyyy-MM-dd"), transTime, transType, userId, shift, deviceId, stopLaborRecords.ToString(),
                               recordMachineTime.ToString(), processRealTime.ToString(), taImplemented.ToString(), validatePreviousTARecord.ToString(), lunchStartTime, lunchEndTime);
                }
                if ((IndirectDtEnd < lunchStartTime) & (IndirectDtEnd < lunchEndTime))
                {//no change case 3
                    if (IndirectDtEnd.Date.CompareTo(IndirectDtStart.Date) > 0)
                    {
                        lunchdate = IndirectDtStart.ToString("MMddyyyy");
                        retVal = CreateIndirect(IndirectEmployee, shift, IndirectDeviceId, IndirectDtStart, DateTime.ParseExact(lunchdate + " " + "2359", "MMddyyyy HHmm", CultureInfo.CurrentCulture), userId, "", postRealTime);
                        retVal = CreateIndirect(IndirectEmployee, shift, IndirectDeviceId, DateTime.ParseExact(IndirectDtEnd.ToString("MMddyyyy") + " " + "0000", "MMddyyyy HHmm", CultureInfo.CurrentCulture), IndirectDtEnd, userId, "", postRealTime);
                    }
                    else
                        retVal = CreateIndirect(IndirectEmployee, shift, IndirectDeviceId, IndirectDtStart, IndirectDtEnd, userId, "", postRealTime);
                }
            }

            if ((IndirectDtStart >= lunchStartTime) & (IndirectDtStart < lunchEndTime))
            {
                if ((IndirectDtEnd > lunchStartTime) & (IndirectDtEnd > lunchEndTime))
                {//case4

                    retVal = CreateLunch(EmpNum, lunchStartTime.ToString("yyyy-MM-dd"), transTime, transType, userId, shift, deviceId, stopLaborRecords.ToString(),
                               recordMachineTime.ToString(), processRealTime.ToString(), taImplemented.ToString(), validatePreviousTARecord.ToString(), lunchStartTime, lunchEndTime);
                    if (IndirectDtEnd.Date.CompareTo(lunchEndTime.Date) > 0)
                    {
                        lunchdate = lunchEndTime.ToString("MMddyyyy");
                        retVal = CreateIndirect(IndirectEmployee, shift, IndirectDeviceId, lunchEndTime, DateTime.ParseExact(lunchdate + " " + "2359", "MMddyyyy HHmm", CultureInfo.CurrentCulture), userId, "", postRealTime);
                        retVal = CreateIndirect(IndirectEmployee, shift, IndirectDeviceId, DateTime.ParseExact(IndirectDtEnd.ToString("MMddyyyy") + " " + "0000", "MMddyyyy HHmm", CultureInfo.CurrentCulture), IndirectDtEnd, userId, "", postRealTime);
                    }
                    else
                        retVal = CreateIndirect(IndirectEmployee, shift, IndirectDeviceId, lunchEndTime, IndirectDtEnd, userId, "", postRealTime);

                }
                else if ((IndirectDtEnd > lunchStartTime) & (IndirectDtEnd >= lunchEndTime))
                {
                    //if ((IndirectDtEnd > lunchStartTime) & (IndirectDtEnd >= lunchEndTime))
                    //{//casex  indirect the sametime as lunch

                    retVal = CreateLunch(EmpNum, lunchStartTime.ToString("yyyy-MM-dd"), transTime, transType, userId, shift, deviceId, stopLaborRecords.ToString(),
                                recordMachineTime.ToString(), processRealTime.ToString(), taImplemented.ToString(), validatePreviousTARecord.ToString(), lunchStartTime, lunchEndTime);
                    //}
                }
            }

            if ((IndirectDtStart > lunchStartTime) & (IndirectDtStart > lunchEndTime))
            {
                if (IndirectDtEnd.Date.CompareTo(IndirectDtStart.Date) > 0)
                {
                    lunchdate = IndirectDtStart.ToString("MMddyyyy");
                    retVal = CreateIndirect(IndirectEmployee, shift, IndirectDeviceId, IndirectDtStart, DateTime.ParseExact(lunchdate + " " + "2359", "MMddyyyy HHmm", CultureInfo.CurrentCulture), userId, "", postRealTime);
                    retVal = CreateIndirect(IndirectEmployee, shift, IndirectDeviceId, DateTime.ParseExact(IndirectDtEnd.ToString("MMddyyyy") + " " + "0000", "MMddyyyy HHmm", CultureInfo.CurrentCulture), IndirectDtEnd, userId, "", postRealTime);
                }
                else
                    retVal = CreateIndirect(IndirectEmployee, shift, IndirectDeviceId, IndirectDtStart, IndirectDtEnd, userId, "", postRealTime);
            }


            return retVal;
        }

        #endregion


        //private string CreateLunch(string employee, string deviceId, string shift, string transDate, DateTime lunchStartTime, DateTime lunchEndTime, bool processRealTime = false)
        //{
        //    string ActualTansType = this.transType;
        //    string ActualTransTime = this.transTime;
        //    string infobar = "";
        //    bool returnVal = false;
        //    this.transType = "4";
        //    returnVal=performTimeAttendanceUpdate(out infobar);
        //    if (returnVal == true)
        //    {
        //        this.transType = "3";
        //        returnVal = performTimeAttendanceUpdate(out infobar);
        //    }
        //    this.transType = ActualTansType;
        //    //this.transTime = ActualTransTime;

        //    return returnVal.ToString();
        //}
        

        private Boolean PerformDelete(out string infobar)
        {
            infobar = "";
            bool retunval = true;
            LoadCollectionRequestData LoadRequestData = new LoadCollectionRequestData();
            LoadRequestData.IDOName = "SLDctas";
            LoadRequestData.PropertyList.SetProperties("EmpNum,TransDate");
            LoadRequestData.Filter = "EmpNum ='" + EmpNum + "' and TransDate ='" + "2015-06-18 00:00:00.000" + "'";
            LoadRequestData.RecordCap = -1;
            LoadCollectionResponseData LoadResponeData = ExcuteQueryRequest(LoadRequestData);
            for (int i = 0; i < LoadResponeData.Items.Count; i++)
            {
                // retunval= performTimeAttendanceDelete(LoadResponeData[i, "_ItemId"].ToString(), out infobar );
                retunval = performTimeAttendanceDelete(LoadResponeData.Items[i].ItemID, out infobar);
            }
            return retunval;
        }

        private bool performDeleteJobTran(string transNum, string recordDate, string rowPointer)
        {
            UpdateCollectionRequestData updateRequestData = new UpdateCollectionRequestData();
            updateRequestData.IDOName = "SL.SLJobTrans";
            updateRequestData.RefreshAfterUpdate = true;
            updateRequestData.CustomDelete = "DeleteJobtranitemSp(TransNum),STD";

            IDOUpdateItem updateItem = new IDOUpdateItem();
            updateItem.Action = UpdateAction.Delete;
            updateItem.Properties.Add("TransNum", transNum); // add recorddate and rowpointer
            updateItem.Properties.Add("RecordDate", recordDate); // add recorddate and rowpointer
            updateItem.Properties.Add("RowPointer", rowPointer); // add recorddate and rowpointer
            updateRequestData.Items.Add(updateItem);

            UpdateCollectionResponseData updateResponseData = null;
            try
            {
                updateResponseData = this.Context.Commands.UpdateCollection(updateRequestData);
            }
            catch (Exception ee)
            {
                errorMessage = constructErrorMessage(ee.Message, null, null);
                return false;
            }
            return true;
        }

        private bool performTimeAttendanceDelete(string ItemId, out string infobar)
        {
            infobar = "";
            
            UpdateCollectionRequestData updateRequestData = new UpdateCollectionRequestData();
            updateRequestData.IDOName = "SLDctas";
            updateRequestData.RefreshAfterUpdate = false;
            IDOUpdateItem updateItem = new IDOUpdateItem();
            updateItem.ItemID = ItemId;
            updateItem.Action = UpdateAction.Delete;

            //updateItem.Properties.Add("TransNum", this.nextTransNumber);
            updateItem.Properties.Add("EmpNum", EmpNum);
            updateItem.Properties.Add("TransDate", "2015-06-18 00:00:00.000");
            //updateItem.Properties.Add("_ItemId", ItemId);
            //updateItem.Properties.Add("RowPointer", "548C447E-0552-41BB-8D7A-168F9802BF4B");
            //updateItem.Properties.Add("RecordDate", "2015-06-17 08:59:32.373");
            updateRequestData.Items.Add(updateItem);
            UpdateCollectionResponseData updateResponseData = this.Context.Commands.UpdateCollection(updateRequestData);
            return true;
        }

    }
}