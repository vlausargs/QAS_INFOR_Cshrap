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
    public class LaborUpdateJobCompleteOpeStatus
    {
        private ParseUploadRequest parseRequest = null;
        private string RowPointer = "";
        private string RecordDate = "";
        private string _itemId = "";
        private string job = "";
        private string suffix = "";
        private string oper = "";

        private IIDOExtensionClassContext context = null;
        private string inputXML = "";
        public LaborUpdateJobCompleteOpeStatus(IIDOExtensionClassContext context, string inputXML)
        {

            this.context = context;
            this.inputXML = inputXML;
        }

        public bool validateInputs()
        {
            if (job == null || (job.Trim().Equals("")))
            {
                //errorMessage = constructErrorMessage("Job input is Mandatory", "SLAXXXX049", null);
                return false;
            }
            return true;
        }

        //public string processMessage(Request request)
        //{
        //    initialize();

        //    Request Request = (Request)request;


        //    return processRequest(Request);
        //}


        public int PerformUpdate(out string infobar)
        {
            parseRequest = new ParseUploadRequest();

            try
            {
                Request request = new RequestParser().parseRequest(inputXML);
                infobar = processRequest(request);
            }
            catch (Exception ex)
            {
                infobar = ex.Message.ToString();
                return 16;
            }

            return 0;
        }
        public LoadCollectionResponseData ValidateJobStatus(string job, string suffix)
        {
            LoadCollectionRequestData validateJobRequestData = new LoadCollectionRequestData();
            validateJobRequestData.IDOName = "SLJobs";

            validateJobRequestData.PropertyList.SetProperties("Job, Suffix, Item,ItemDescription,ItemLotTracked,ItemSerialTracked,Whse,QtyComplete,QtyReleased,QtyScrapped,DerNewStatus,Stat");

            string filterString = "Job = '" + job + "' and Suffix ='" + suffix + "'";

            validateJobRequestData.Filter = filterString;
            validateJobRequestData.RecordCap = 1;
            validateJobRequestData.OrderBy = "Job";
            LoadCollectionResponseData validateJobResponseData = this.context.Commands.LoadCollection(validateJobRequestData);
            return validateJobResponseData;
        }
        private string processRequest(Request updateRequest)
        {
            parseRequest = new ParseUploadRequest();


            InputDataSet dataSet = parseRequest.ParseData(updateRequest);



            // dataSet.JobQtyLines.

            this.job = dataSet.JobQtyLines[0].GetValue("Job");//dataSet.JobQtyLines.Contains("");
            this.suffix = dataSet.JobQtyLines[0].GetValue("Suffix");
            this.oper = dataSet.JobQtyLines[0].GetValue("Oper");

            LoadCollectionResponseData orderValidateResponseData = ValidateJobStatus(job, suffix);
            if (orderValidateResponseData.Items.Count == 0)
            {
                return constructErrorMessage("Job Details Not Found", "-1");
            }
            if (orderValidateResponseData[0, "Stat"].ToString().ToUpper() == "F")
            {
                return constructErrorMessage("Job status is [Firm] Cannot proceed", "-1");
            }
            else if (orderValidateResponseData[0, "Stat"].ToString().ToUpper() == "S")
            {
                return constructErrorMessage("Job status is [Stopped] Cannot proceed", "-1");
            }
            else if (orderValidateResponseData[0, "Stat"].ToString().ToUpper() == "C")
            {
                return constructErrorMessage("Job status is [Complete] Cannot proceed", "-1");
            }

            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLJobRoutes";
            requestData.PropertyList.SetProperties("RowPointer, RecordDate, Job,JobSuffix,OperNum,Complete");
            string filterString = "Job = '" + this.job + "'   and JobSuffix ='" + this.suffix + "'  and OperNum ='" + this.oper + "'";


            requestData.Filter = filterString;
            requestData.RecordCap = 0;
            requestData.OrderBy = "Job";
            LoadCollectionResponseData JobResponseData;
            JobResponseData = context.Commands.LoadCollection(requestData);
            if (JobResponseData != null && JobResponseData.Items.Count > 0)
            {
                this.RowPointer = JobResponseData[0, "RowPointer"].Value;
                this.RecordDate = JobResponseData[0, "RecordDate"].Value;
                this._itemId = JobResponseData.Items[0].ItemID;

                UpdateCollectionRequestData updateContRequestData = new UpdateCollectionRequestData();
                updateContRequestData.IDOName = "SLJobRoutes";
                updateContRequestData.RefreshAfterUpdate = true;
                IDOUpdateItem SlJobItem = new IDOUpdateItem();
                SlJobItem.Action = UpdateAction.Update;
                SlJobItem.ItemID = this._itemId;
                SlJobItem.ItemNumber = 0;
                SlJobItem.Properties.Add("RowPointer", RowPointer, false);
                SlJobItem.Properties.Add("RecordDate", RecordDate, false);

                SlJobItem.Properties.Add("Complete", "0", true);
                updateContRequestData.Items.Add(SlJobItem);
                UpdateCollectionResponseData updateResponseData = null;
                updateResponseData = context.Commands.UpdateCollection(updateContRequestData);

            }

            string returnString = "<Response>";
            returnString += "<output>";
            returnString += "<row>";
            returnString += "<TRANSACTION_STATUS>0</TRANSACTION_STATUS>";
            returnString += "</row>";
            returnString += "</output>";
            returnString += "</Response>";

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
