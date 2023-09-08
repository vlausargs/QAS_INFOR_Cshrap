using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InforCollect.ERP.SL.ICSLShopFloorTrans.Labor
{
    class ParseUploadRequest
    {
        /*
         * Formats with key identifiers. When changing the identifier in below format ensure you update all the references as well
         */
        private string _masterLineFormat = "MASTER~Und1~Employee~Startdate~Starttime~EndDate~Endtime~ReportDate~Processed";
        private string _hoursLineFormat = "HOURS~Employee~ReportDate~Sequence~TransType~Job~Suffix~Oper~Workcenter~Machine~Task~Shift~PayType~Startdate~Starttime~Enddate~Endtime~ManTimeInMins~MachineTimeInMins~logincode~CostCode~PartnerId~SROLine~WorkCode~BillCode~NextOper~RESID~QTY~QtySequence~QtyReported~QtyMoved~QtyRejected~ReasonCode~CompleteOper"; 
        private string _qtyLineFormat = "QTY~Employee~ReportDate~Sequence~TransType~Job~Suffix~Oper~QtyCompleted~QtyMoved~QtyScrapped~ReasonCode~OperationComplete";
        private string _attendanceLineFormat = "ATTEND~Employee~TransDate~Sequence~TransType~TransTime~UserId~Shift~DeviceId";
        //private string _qtyLineFormat = "QTY~Employee~ReportDate~Sequence~Job~Suffix~Oper~QtyCompleted~QtyMoved~QtyScrapped~ReasonCode"; 
        //QTY~~11282013~7|kiran00001~0~10~1.00000000~1.00000000~~~
        
        /* 
         * 1. MasterLine should always be followed by a HoursLine, in which case the HoursLine belongs to the MasterLine 
         * 2. If a Hoursline is encountered without a master line, it is ignored
         * 3. A request should always belong to 1 employee's data (we may need to rewrite, but currently - 1 request = 1 employee data(labor or qty recrod))
         */
        public InputDataSet ParseData(Request updateRequest)
        {
            InputDataSet dataSet = new InputDataSet();

            InputDataSet.MasterLine currMasterLine = null;
            InputDataSet.HoursLine hrsLine = null;
            InputDataSet.QtyLine qtyLine = null;
            InputDataSet.AttendanceLine attendanceLine = null;

            dataSet.PostOffSets = updateRequest.GetBoolFieldValue("postOffSets");
            dataSet.UserInitials = updateRequest.GetFieldValue("userInitials");
            dataSet.DeviceId = updateRequest.GetFieldValue("deviceId");

            try
            {
                dataSet.StopPostJobs = updateRequest.GetBoolFieldValue("StopPostJobs");
            }
            catch {
                 dataSet.StopPostJobs = false;
            }

            List<Field> inputFieldsList = updateRequest.InputFieldsList;
            foreach (Field field in inputFieldsList)
            {
                if (field.Name.StartsWith("MASTER"))
                {
                    if (currMasterLine != null)
                    {
                        dataSet.MasterLines.Add(currMasterLine);
                        currMasterLine = null;
                    }

                    currMasterLine = parseMasterLine(field.Value);
                    currMasterLine.InputField = field;
                }
                else if (field.Name.StartsWith("Hours"))
                {
                    if (currMasterLine == null)
                    {
                        continue;
                    }
                    hrsLine = parseHoursLine(field.Value);
                    hrsLine.InputField = field;

                    if (hrsLine.IsJobLine == true)
                    {
                        currMasterLine.JobHrsLines.Add(hrsLine);
                    }

                    if (hrsLine.IsProjectLine == true)
                    {
                        currMasterLine.ProjectHrsLines.Add(hrsLine);
                    }

                    if (hrsLine.IsSROLine == true)
                    {
                        currMasterLine.SROHrsLines.Add(hrsLine);
                    }
                }
                else if (field.Name.StartsWith("QTY"))
                {
                    qtyLine = parseQtyLine(field.Value);
                    qtyLine.InputField = field;

                    dataSet.JobQtyLines.Add(qtyLine);
                }
                else if (field.Name.StartsWith("Attend"))
                {
                    attendanceLine = parseAttendanceLine(field.Value);
                    attendanceLine.InputField = field;
                    
                    //dataSet.AttendanceLines.Add(attendanceLine);
                    currMasterLine.AttendanceLines.Add(attendanceLine);
                }
          
            }

            if (currMasterLine != null)
            {
                dataSet.MasterLines.Add(currMasterLine);
                currMasterLine = null;
            }

            return dataSet;
        }


        private InputDataSet.MasterLine parseMasterLine(string inputStr)
        {
            InputDataSet.MasterLine masterLine = new InputDataSet.MasterLine();

            masterLine.SetDataDictionary(parseString(_masterLineFormat, inputStr));

            return masterLine;
        }

        private InputDataSet.HoursLine parseHoursLine(string inputStr)
        {
            InputDataSet.HoursLine hoursLine = new InputDataSet.HoursLine();

            hoursLine.SetDataDictionary(parseString(_hoursLineFormat, inputStr));

            if (hoursLine.GetValue("TransType").Equals("21") || hoursLine.GetValue("TransType").Equals("22") || hoursLine.GetValue("TransType").Equals("23")
                    || hoursLine.GetValue("TransType").Equals("24"))
            {
                hoursLine.IsJobLine = true;
            }

            if (hoursLine.GetValue("TransType").Equals("31") )
            {
                hoursLine.IsProjectLine = true;
            }

            if (hoursLine.GetValue("TransType").Equals("34"))
            {
                hoursLine.IsSROLine = true;
            }

            return hoursLine;
        }

        private InputDataSet.QtyLine parseQtyLine(string inputStr)
        {
            InputDataSet.QtyLine qtyLine = new InputDataSet.QtyLine();

            qtyLine.SetDataDictionary(parseString(_qtyLineFormat, inputStr));

            return qtyLine;
        }

        private InputDataSet.AttendanceLine parseAttendanceLine(string inputStr)
        {
            InputDataSet.AttendanceLine attendanceLine = new InputDataSet.AttendanceLine();
            attendanceLine.SetDataDictionary(parseString(_attendanceLineFormat,inputStr));
            return attendanceLine ;
        }

        private Dictionary<string, string> parseString(string inputDetailFormat, string inputString)
        {
            Dictionary<string, string> dataDictionary = new Dictionary<string, string>();
            string[] stringFormat;
            string[] stringData;

            inputString = inputString.Replace('|', '~');

            stringFormat = inputDetailFormat.Split('~');
            stringData = inputString.Split('~');

            if (stringFormat.Length != stringData.Length && stringFormat.Length - 7 != stringData.Length)
            {
                throw new Exception("Input fields do not match the expected number of fields. \nExpected: " + inputDetailFormat
                     + " \nInput: " + inputString);
            }

            //Parsing data
            for (int ind = 0; ind < stringData.Length; ind++)
            {
                if (stringData[ind] != null && stringData[ind] != "")
                {
                    dataDictionary.Add(stringFormat[ind], stringData[ind]);
                }
                else
                {
                    dataDictionary.Add(stringFormat[ind], "");
                }
            }

            return dataDictionary;
        }
    }
}
