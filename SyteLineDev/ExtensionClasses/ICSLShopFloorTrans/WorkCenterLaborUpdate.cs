using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mongoose.Core.Configuration;
using Mongoose.IDO.Protocol;
using Mongoose.IDO;
using Mongoose.Core;
using System.Globalization;

namespace InforCollect.ERP.SL.ICSLShopFloorTrans
{
    class WorkCenterLaborUpdate : ShopFloorUtilities
    {
        #region InputVariables

        private string employee = "";
        private string workCenter = "";
        private string shift = "";
        private string transDate = "";  //yyyy/mm/dd
        private string startTime = "";  //hh:mm
        private string endTime = "";  //hh:mm
        private double totalHours = 0.0;            //if totalHours passed = 0 then it will automatically calculate
        private bool reportMachineTime = false;

        #endregion

        #region LocalVariables
        private string errorMessage = "";

        #endregion

        public WorkCenterLaborUpdate(string employee, string workCenter, string shift, string transDate,
                                     string startTime, string endTime, double totalHours, bool reportMachineTime)
        {
            this.employee = employee;
            this.workCenter = workCenter;
            this.shift = shift;
            this.transDate = transDate;
            this.startTime = startTime;
            this.endTime = endTime;
            this.totalHours = totalHours;
            this.reportMachineTime = reportMachineTime;
        }

        public void initialize()
        {
            employee = "";
            workCenter = "";
            shift = "";
            transDate = "";
            startTime = "";
            endTime = "";
            totalHours = 0.0;
            reportMachineTime = false;
        }

        public bool formatInputs()
        {

            if (workCenter == null || workCenter.Trim().Equals(""))
            {
                errorMessage = "workcenter input mandatory";
                return false;
            }

            employee = employee = formatDataByIDOAndPropertyName("SLEmployees", "EmpNum", employee);
            if (employee == null || employee.Trim().Equals(""))
            {
                errorMessage = "employee input mandatory";
                return false;
            }

            if (shift == null || shift.Trim().Equals(""))
            {
                errorMessage = "shift input mandatory";
                return false;
            }

            if (transDate == null || transDate.Trim().Equals(""))
            {
                errorMessage = "transDate input mandatory";
                return false;
            }


            if (startTime == null || startTime.Trim().Equals(""))
            {
                errorMessage = "startTime input mandatory";
                return false;
            }

            if (endTime == null || endTime.Trim().Equals(""))
            {
                errorMessage = "endTime input mandatory";
                return false;
            }

            return true;
        }

        private bool validateInputs()
        {
            //Employee Validation

            if (ValidateEmployee(employee, out errorMessage) == false)
            {
                return false;
            }

            if (ValidateWorkCenter(workCenter) == false)
            {
                return false;
            }

            //Shift Field Checks
            LoadCollectionResponseData responseData = GetShiftDetails(shift);
            if (responseData.Items.Count == 0)
            {
                errorMessage = "Shift Details Not Found";
                return false;
            }
            return true;
        }

        public int PerformUpdate(out string infobar)
        {
            // string returnString = "";
            infobar = "";

            //2 Format Inputs
            if (formatInputs() == false)
            {
                infobar = errorMessage;
                return 1;
            }
            //3 validate Inputs
            if (validateInputs() == false)
            {
                infobar = errorMessage;
                return 2;
            }

            //4 Perform Updates

            if (performWorkCenterLabor() == false)
            {
                infobar = errorMessage;
                infobar = formatResponse(infobar);
                return 3;

            }

            infobar = formatResponse(infobar);
            return 0;
        }

        private bool performWorkCenterLabor()
        {
            if (PerformTransaction() == false)
            {
                return false;
            }

            return true;
        }

        private bool PerformTransaction()
        {
            string GUID = "";
            if (GenerateGUID(ref GUID, out errorMessage) == false)
            {
                return false;
            }

            if (PerformPosting(GUID) == false)
            {
                return false;
            }

            if (reportMachineTime)                                                      //Kiran 12-29-2011.sn
            {
                if (PerformMachinePosting(GUID) == false)
                {
                    return false;
                }
            }                                                                           //Kiran 12-29-2011.en

            return true;
        }

        private bool PerformPosting(string GUID)
        {
            DateTime startDateTime;
            DateTime endDateTime;
            string reportDate;
            try
            {
                //*** Should probably use System.DateTime.Now.ToString(WMShortDatePattern) rather than culture info.  
                //   This should be changed in a later itteration.  JH:20140103
                startDateTime = DateTime.ParseExact(this.transDate + " " + this.startTime, "MMddyyyy HHmm", CultureInfo.CurrentCulture);
                endDateTime = DateTime.ParseExact(this.transDate + " " + this.endTime, "MMddyyyy HHmm", CultureInfo.CurrentCulture);

                reportDate = startDateTime.ToString("yyyy/MM/dd");
            }
            catch (Exception)
            {
                errorMessage = "Date Time Conversion Failed";
                return false;
            }

            TimeSpan span = endDateTime.Subtract(startDateTime);
            string diff = (span.TotalMinutes / 60).ToString("0.###");

            if (totalHours > 0)
            {
                diff = totalHours.ToString();
            }

            object[] inputValues = new object[]{
                                                workCenter,
                                                employee,
                                                diff,
                                                startDateTime.TimeOfDay.TotalSeconds.ToString(),
                                                endDateTime.TimeOfDay.TotalSeconds.ToString(),
                                                shift,
                                                reportDate,
                                                GUID,
                                                "",
                                                "",
                                                "",
                                                ""
                                                };

            InvokeResponseData responseData = InvokeIDO("SLJobTrans", "PostWcLaborSp", inputValues);
            if (!(responseData.ReturnValue.Equals("0")))
            {
                errorMessage = responseData.Parameters.ElementAt(10).ToString();
                return false;
            }

            inputValues = new object[]{
                                        GUID,
                                        responseData.Parameters.ElementAt(8).ToString(),
                                        responseData.Parameters.ElementAt(9).ToString(),
                                        ""
                                      };

            responseData = InvokeIDO("SLJobTrans", "JobWipTransPost", inputValues);
            if (!(responseData.ReturnValue.Equals("0")))
            {
                errorMessage = responseData.Parameters.ElementAt(10).ToString();
                return false;
            }
            return true;
        }

        private bool PerformMachinePosting(string GUID)
        {
            DateTime startDateTime;
            DateTime endDateTime;
            string reportDate;
            try
            {//MSF157397: as a result of this issue we are adding a try catch and debug statement around date time conversions.  JH:20130116

                //*** Should probably use System.DateTime.Now.ToString(WMShortDatePattern) rather than culture info.  
                //   This should be changed in a later itteration.  JH:20140103                
                startDateTime = DateTime.ParseExact(this.transDate + " " + this.startTime, "MMddyyyy HHmm", CultureInfo.CurrentCulture);
                endDateTime = DateTime.ParseExact(this.transDate + " " + this.endTime, "MMddyyyy HHmm", CultureInfo.CurrentCulture);

                reportDate = startDateTime.ToString("yyyy/MM/dd");
            }
            catch (Exception)
            {
                errorMessage = "Date Time Conversion Failed";
                return false;
            }
            TimeSpan span = endDateTime.Subtract(startDateTime);
            string diff = (span.TotalMinutes / 60).ToString("0.###");

            if (totalHours > 0)
            {
                diff = totalHours.ToString();
            }

            object[] inputValues = new object[]{
                                                workCenter,
                                                diff,
                                                startDateTime.TimeOfDay.TotalSeconds.ToString(),
                                                endDateTime.TimeOfDay.TotalSeconds.ToString(),
                                                shift,
                                                reportDate,
                                                employee,
                                                "SA",
                                                GUID,
                                                "",
                                                "",
                                                ""
                                                };

            InvokeResponseData responseData = InvokeIDO("SLJobtranitems", "SWcmachISp", inputValues);
            if (!(responseData.ReturnValue.Equals("0")))
            {
                errorMessage = responseData.Parameters.ElementAt(10).ToString();
                return false;
            }

            inputValues = new object[]{
                                        GUID,
                                        responseData.Parameters.ElementAt(10).ToString(),
                                        responseData.Parameters.ElementAt(9).ToString(),
                                        ""
                                      };

            responseData = InvokeIDO("SLJobTrans", "JobWipTransPost", inputValues);
            if (!(responseData.ReturnValue.Equals("0")))
            {
                errorMessage = responseData.Parameters.ElementAt(11).ToString();
                return false;
            }
            return true;
        }
    }
}