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
    public class LaborUpload
    {
        private ParseUploadRequest parseRequest = null;
        private DispatcherService jobDispatcher = null;
        private DispatcherService projectDispatcher = null;
        private DispatcherService SRODispatcher = null;
        private AttendanceDispatcher attendanceDispatcher = null;
        private IIDOExtensionClassContext context = null;
        private string inputXML = "";

        public LaborUpload(IIDOExtensionClassContext context, string inputXML)
        {
            this.context = context;
            this.inputXML = inputXML;
        }

        #region Flow Methods

        public void initialize()
        {
            parseRequest = new ParseUploadRequest();
            jobDispatcher = new JobDispatcher(context);
            projectDispatcher = new ProjectLaborDispatcher(context);
            SRODispatcher = new SROLaborDispatcher(context);
            attendanceDispatcher = new AttendanceDispatcher(context);
        }

        public int PerformUpdate(out string infobar)
        {
            initialize();

            try
            {
                IDORuntime.LogUserMessage("LaborUpdate.PerformUpdate", UserDefinedMessageType.UserDefined1, "Before XML Parsing");
                Request request = new RequestParser().parseRequest(inputXML);
                IDORuntime.LogUserMessage("LaborUpdate.PerformUpdate", UserDefinedMessageType.UserDefined1, "After XML Parsing");
                infobar = processRequest(request);
                IDORuntime.LogUserMessage("LaborUpdate.PerformUpdate", UserDefinedMessageType.UserDefined1, "After Process Method");

            }
            catch (Exception ex)
            {
                infobar = constructErrorMessage(ex.Message, "-1");
                return 16;
            }

            return 0;
        }

        #endregion

        private string processRequest(Request updateRequest)
        {

            InputDataSet dataSet = parseRequest.ParseData(updateRequest);

            IDORuntime.LogUserMessage("LaborUpdate.processRequest", UserDefinedMessageType.UserDefined1, "After InputDataSet {0}", dataSet.MasterLines.Count);


        foreach (InputDataSet.MasterLine masterLine in dataSet.MasterLines)
            {
                //if (masterLine.JobHrsLines.Count > 0)
                //{
                IDORuntime.LogUserMessage("LaborUpdate.processRequest", UserDefinedMessageType.UserDefined1, "Before Job Dispatcher");
                jobDispatcher.ProcessLaborUpdate(masterLine, dataSet.PostOffSets, dataSet.StopPostJobs);
                IDORuntime.LogUserMessage("LaborUpdate.processRequest", UserDefinedMessageType.UserDefined1, "After Job Dispatcher");
                //}

                //if (masterLine.ProjectHrsLines.Count > 0)
                //{
                IDORuntime.LogUserMessage("LaborUpdate.processRequest", UserDefinedMessageType.UserDefined1, "Before Project Dispatcher");
                projectDispatcher.ProcessLaborUpdate(masterLine, dataSet.PostOffSets, dataSet.StopPostJobs);
                IDORuntime.LogUserMessage("LaborUpdate.processRequest", UserDefinedMessageType.UserDefined1, "After Job Dispatcher");
                //}

                //if (masterLine.SROHrsLines.Count > 0)
                //{
                IDORuntime.LogUserMessage("LaborUpdate.processRequest", UserDefinedMessageType.UserDefined1, "Before SRO Dispatcher");

                SRODispatcher.ProcessLaborUpdate(masterLine, dataSet.PostOffSets, dataSet.StopPostJobs);

                IDORuntime.LogUserMessage("LaborUpdate.processRequest", UserDefinedMessageType.UserDefined1, "After Job Dispatcher");

                //}
                IDORuntime.LogUserMessage("LaborUpdate.processRequest", UserDefinedMessageType.UserDefined1, "Before Attendance {0}", masterLine.AttendanceLines.Count);
                if (masterLine.AttendanceLines.Count > 0)
                {
                    attendanceDispatcher.ProcessLaborAttendance(masterLine, dataSet.PostOffSets);
                }
                IDORuntime.LogUserMessage("LaborUpdate.processRequest", UserDefinedMessageType.UserDefined1, "After Attendance {0}", masterLine.AttendanceLines.Count);
            }

            IDORuntime.LogUserMessage("LaborUpdate.processRequest", UserDefinedMessageType.UserDefined1, "Before Quantity {0}", dataSet.JobQtyLines.Count);

            foreach (InputDataSet.QtyLine qtyLine in dataSet.JobQtyLines)
            {
                jobDispatcher.ProcessQtyUpdate(qtyLine);
            }
            IDORuntime.LogUserMessage("LaborUpdate.processRequest", UserDefinedMessageType.UserDefined1, "After Quantity {0}", dataSet.JobQtyLines.Count);
            

            string returnString = "<TT><Response><Output>";


            foreach (InputDataSet.MasterLine masterLine in dataSet.MasterLines)
            {
                returnString += "<fieldValueList>"+ConstructReturnStr(masterLine.InputField, masterLine.ErrorMessage)+"</fieldValueList>";

                foreach (InputDataSet.HoursLine hrsLine in masterLine.ProjectHrsLines)
                {
                    returnString += "<fieldValueList>"+ConstructReturnStr(hrsLine.InputField, hrsLine.ErrorMessage)+"</fieldValueList>";
                }

                foreach (InputDataSet.HoursLine hrsLine in masterLine.JobHrsLines)
                {
                    returnString += "<fieldValueList>" + ConstructReturnStr(hrsLine.InputField, hrsLine.ErrorMessage) + "</fieldValueList>";
                }

                foreach (InputDataSet.HoursLine hrsLine in masterLine.SROHrsLines)
                {
                    returnString += "<fieldValueList>" + ConstructReturnStr(hrsLine.InputField, hrsLine.ErrorMessage) + "</fieldValueList>";
                }
                foreach (InputDataSet.AttendanceLine attendanceLine in masterLine.AttendanceLines)
                {
                    returnString += "<fieldValueList>" + ConstructReturnStr(attendanceLine.InputField, attendanceLine.ErrorMessage) + "</fieldValueList>";
                }
            }

            foreach (InputDataSet.QtyLine qtyLine in dataSet.JobQtyLines)
            {
                returnString += "<fieldValueList>"+ConstructReturnStr(qtyLine.InputField, qtyLine.ErrorMessage)+"</fieldValueList>";
            }
            

            returnString += "</Output></Response></TT>";
            return returnString;
        }

        private bool IsStrNotNull(string value)
        {
            if (value == null || value.Trim() == "")
            {
                return false;
            }
            return true;
        }

        private string ConstructReturnStr(Field field, string errorMessage)
        {
            errorMessage = GetErrorStringFromErrorMessage(errorMessage); 

            //string returnString = "<fieldValueList><name>" + field.Name + "</name><value>" + field.Value + "</value>";
            string returnString = "<name>" + field.Name + "</name><value>" + field.Value + "</value>";

            if (IsStrNotNull(errorMessage))
            {
                string errorString = errorMessage.Replace("\n", "");
                errorString = errorString.Replace("\r", "");
                returnString += "<errorInfo>" + errorString + "</errorInfo>";
            }

            //returnString += "</fieldValueList>";
            return returnString;
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

        public string constructErrorMessage(string error, string errorCode)
        {
            string returnString = "<Response>";
            returnString += "<TRANSACTION_STATUS>ERROR</TRANSACTION_STATUS>";
            returnString += "<error>" + error + "</error>";
            returnString += "<errorCode>" + errorCode + "</errorCode>";
            returnString += "</Response>";
            return (returnString);
        }
    }
}
