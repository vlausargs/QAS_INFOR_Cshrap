using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using Mongoose.Core.Configuration;
using Mongoose.IDO.Protocol;
using Mongoose.IDO;
using Mongoose.Core;
using System.Globalization;

namespace InforCollect.ERP.SL.ICSLShopFloorTrans.Labor
{
    public class FTLaborUpload
    {
        private IIDOExtensionClassContext context = null;
        private string inputXML = "";
        private string _SessionID = "";
        private string _StartDate = "";
        private string _EndDate = "";
        private string _Employee = "";
        private string _systemWideWHSE = "";
        private int _NumOfHeaderRecords = -1;

        public FTLaborUpload(IIDOExtensionClassContext context, string inputXML)
        {
            this.context = context;
            this.inputXML = inputXML;
        }

        #region Flow Methods

        public int PerformUpdate(string preserveSessionData, out string infobar)
        {
            try
            {
                bool preserveSession = (preserveSessionData == "1" ? true : false);
                IDORuntime.LogUserMessage("FTLaborUpdate.PerformUpdate", UserDefinedMessageType.UserDefined1, "preserveSessionData [" + (preserveSession ? "1" : "0") + "]");

                Stopwatch completeUpdateWatch = new Stopwatch();
                completeUpdateWatch.Start();

                IDORuntime.LogUserMessage("FTLaborUpdate.PerformUpdate", UserDefinedMessageType.UserDefined1, "Initializing SQL Session Data...");
                initializeSQLSession();
                IDORuntime.LogUserMessage("FTLaborUpdate.PerformUpdate", UserDefinedMessageType.UserDefined1, "DBG - Num Of Header records received [" + _NumOfHeaderRecords.ToString() + "]");
                IDORuntime.LogUserMessage("FTLaborUpdate.PerformUpdate", UserDefinedMessageType.UserDefined1, "Initializing SQL Session Data... Done.");

                IDORuntime.LogUserMessage("FTLaborUpdate.PerformUpdate", UserDefinedMessageType.UserDefined1, "Processing Jobs...");
                PerformUpdateJobs();
                IDORuntime.LogUserMessage("FTLaborUpdate.PerformUpdate", UserDefinedMessageType.UserDefined1, "Processing Jobs... Done.");

                // Call SP to extract XML and clean session data
                string outputXMLstr = getOutputXmlStringAndTidy(preserveSession);
                infobar = outputXMLstr;

                completeUpdateWatch.Stop();
                TimeSpan ts = completeUpdateWatch.Elapsed; // Get the elapsed time as a TimeSpan value, then Format and display the TimeSpan value.
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                IDORuntime.LogUserMessage("FTLaborUpdate.PerformUpdate", UserDefinedMessageType.UserDefined1, "Total time to perform updates [" + elapsedTime + "]");
            }
            catch (Exception ex)
            {
                string errMsg = string.Empty;
                errMsg += @"Message [" + ex.Message + @"] ";
                errMsg += @"FullText [" + ex.ToString() + @"]";

                IDORuntime.LogUserMessage("FTLaborUpdate.PerformUpdate", UserDefinedMessageType.UserDefined1, "FTLaborUpload-PerformUpdate-Error [" + errMsg.ToString() + "]");
                infobar = "<TT>" + constructErrorMessage(ex.Message, "-1") + "</TT>";
                return 16;
            }
            return 0;
        }

        private void PerformUpdateJobs()
        {
            Stopwatch thisUpdateWatch;
            TimeSpan totalUpdateTime = new TimeSpan();

            string _UserInitials = "LMI";
            int NumOfCallsToPerformPosting = 0;
            int totalRecordsInserted = 0;
            JobLaborDaoImpl laborUpdate = new JobLaborDaoImpl(this.context);

            for (int headerRecord = 1; headerRecord <= _NumOfHeaderRecords; headerRecord++)
            {
                totalRecordsInserted = insertJobRecords(headerRecord);

                for (int postingIterations = 1; postingIterations <= totalRecordsInserted; postingIterations++)
                {
                    string errorMsg = string.Empty;
                    int badRecord = -1;
                    NumOfCallsToPerformPosting++;

                    // Time the record posting
                    thisUpdateWatch = new Stopwatch();
                    thisUpdateWatch.Start();

                    // Post the new records
                    errorMsg = performPosting(_StartDate, _EndDate, _Employee, _UserInitials, _systemWideWHSE);

                    thisUpdateWatch.Stop();
                    totalUpdateTime = totalUpdateTime.Add(thisUpdateWatch.Elapsed);

                    // if errormsg detected, try to extract any transaction number returned from posting
                    if (errorMsg.Length == 0)
                        break; // No errors, great. Move on.
                    else
                    {
                        IDORuntime.LogUserMessage("FTLaborUpdate.PerformUpdate", UserDefinedMessageType.UserDefined1, "DBG Job Posting threw error [" + errorMsg + "]");
                        badRecord = extractTransNumFromErrorMsg(errorMsg);
                        IDORuntime.LogUserMessage("FTLaborUpdate.PerformUpdate", UserDefinedMessageType.UserDefined1, "DBG Job Posting Extracted record number [" + badRecord.ToString() + "]");
                    }

                    // if we detected a transaction number, process that bad Record
                    if (badRecord > 0) processBadRecord(badRecord, errorMsg);
                }
                IDORuntime.LogUserMessage("FTLaborUpdate.PerformUpdate", UserDefinedMessageType.UserDefined1, "DBG Job Posting calls made this pass [" + NumOfCallsToPerformPosting.ToString() + "]");
            }

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", totalUpdateTime.Hours, totalUpdateTime.Minutes, totalUpdateTime.Seconds, totalUpdateTime.Milliseconds / 10);
            IDORuntime.LogUserMessage("FTLaborUpdate.PerformUpdate", UserDefinedMessageType.UserDefined1, "Total time to perform Job postings [" + elapsedTime + "]");
        }

        private void fetchWhse()
        {
            LoadCollectionRequestData ProcessDefaultsrequestData = new LoadCollectionRequestData();
            LoadCollectionResponseData ProcessDefaultsresponseData = new LoadCollectionResponseData();
            ProcessDefaultsrequestData.IDOName = "MGCore.SystemProcessDefaults";
            ProcessDefaultsrequestData.PropertyList.SetProperties("DefaultTypeDesc,DefaultValue");
            string filterString = "DefaultTypeDesc = '" + "FactoryTrackWarehouse" + "'";
            ProcessDefaultsrequestData.Filter = filterString;
            ProcessDefaultsrequestData.RecordCap = 1;
            ProcessDefaultsresponseData = this.context.Commands.LoadCollection(ProcessDefaultsrequestData);
            if (ProcessDefaultsresponseData.Items.Count > 0 && ProcessDefaultsresponseData[0, "DefaultValue"].Value.Trim() != "")
            {
                _systemWideWHSE = ProcessDefaultsresponseData[0, "DefaultValue"].Value;
            }
        }

        private void initializeSQLSession()
        {
            InvokeRequestData request = new InvokeRequestData();
            InvokeResponseData response;
            string Infobar = string.Empty;

            request.IDOName = "ICSLShopFloorTrans";
            request.MethodName = "FTTTInitializeSp";
            request.Parameters.Add(inputXML.ToString()); // ERPXML As String, input
            request.Parameters.Add(IDONull.Value);       // sp output - @ReturnSessionID RowPointerType (VARCHAR)
            request.Parameters.Add(IDONull.Value);       // sp output - @ReturnHeaderRowCount int
            request.Parameters.Add(IDONull.Value);       // sp output - @Infobar

            response = this.context.Commands.Invoke(request);
            _SessionID = "";
            _NumOfHeaderRecords = -1;

            _systemWideWHSE = string.Empty;
            // fetchWhse(); // TODO DD 20190201 - Need to test this. 

            _SessionID = response.Parameters[1].IsNull ? string.Empty : response.Parameters[1].GetValue<string>();
            _NumOfHeaderRecords = response.Parameters[2].IsNull ? 0 : response.Parameters[2].GetValue<int>();
            Infobar = response.Parameters[3].IsNull ? string.Empty : response.Parameters[3].GetValue<string>();

            if (response.IsReturnValueStdError())
            {
                throw new SystemException(Infobar);
            }
        }

        private int insertJobRecords(int headerRecord)
        {
            InvokeRequestData request = new InvokeRequestData();
            InvokeResponseData response;
            int numberOfRecordsInserted = 0;

            request.IDOName = "ICSLShopFloorTrans";
            request.MethodName = "FTTTInsertJobSp";
            request.Parameters.Add(_SessionID);               // 0 sp Input  - SessionID as string
            request.Parameters.Add(headerRecord.ToString());  // 1 sp Input  - HeaderRecord integer to correspond with _rowID in Header table.
            request.Parameters.Add(IDONull.Value);            // 2 sp Output - StartDate as string
            request.Parameters.Add(IDONull.Value);            // 3 sp Output - EndDate as string
            request.Parameters.Add(IDONull.Value);            // 4 sp Output - EmployeeNumber  as string
            request.Parameters.Add(IDONull.Value);            // 5 sp Output - NumOfRecordsInserted as string

            response = this.context.Commands.Invoke(request);

            _StartDate = response.Parameters[2].IsNull ? string.Empty : response.Parameters[2].GetValue<string>();
            _EndDate = response.Parameters[3].IsNull ? string.Empty : response.Parameters[3].GetValue<string>();
            _Employee = response.Parameters[4].IsNull ? string.Empty : response.Parameters[4].GetValue<string>();
            numberOfRecordsInserted = response.Parameters[5].IsNull ? 0 : response.Parameters[5].GetValue<int>();

            if (response.IsReturnValueStdError())
            {
                throw new SystemException("IDO ICSLShopFloorTrans (FTTTInsertJobSp) didn't return anything");
            }
            return numberOfRecordsInserted;
        }

        public string performPosting(string _StartDate, string _EndDate, string _Employee, string _UserInitials, string _whse)
        {
            string errMessage = ""; // If this returns empty string, query successful. If non-empty string, then it's carrying the error message to post to SQL.

            // Convert the report date to a format the jobjobp stored procedure will accept.
            string line_StartDate = _StartDate
                  , line_EndDate = _EndDate;
            DateTime line_StartDateFormatted, line_EndDateFormatted;
            if (DateTime.TryParseExact(line_StartDate, "MMddyyyy", System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None, out line_StartDateFormatted))
                _StartDate = line_StartDateFormatted.ToString("yyyy-MM-dd");
            if (DateTime.TryParseExact(line_EndDate, "MMddyyyy", System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None, out line_EndDateFormatted))
                _EndDate = line_EndDateFormatted.ToString("yyyy-MM-dd");

            if (_whse == string.Empty) { _whse = ""; }

            //if a customer reports a error with the number of params for JobJobP see LaborStopDaoImpl.performPosting() JH:20130215
            //  no error has been reported in this class or for previous version of this class and it appears to work.  So no changes were made at this time 
            //  but this has been a significant issue in the past for labor stop.
            InvokeRequestData request = new InvokeRequestData();
            request.IDOName = "SL.SLJobTrans";
            request.MethodName = "JobJobP";
            request.Parameters.Add("1");           // PostComplete
            request.Parameters.Add("0");           // PostNegativeInventory
            request.Parameters.Add("");            // Start job,
            request.Parameters.Add("");            // End   job,
            request.Parameters.Add("");            // Start suffix,
            request.Parameters.Add("");            // End   suffix,
            request.Parameters.Add(_StartDate);    // Start reportDate-- line.GetValue("ReportDate"),
            request.Parameters.Add(_EndDate);      // End   reportDate-- line.GetValue("ReportDate"),
            request.Parameters.Add(_Employee);     // Start employee,
            request.Parameters.Add(_Employee);     // End   employee,
            request.Parameters.Add("");            // Start dept
            request.Parameters.Add("");            // End   dept
            request.Parameters.Add("");            // Start shift
            request.Parameters.Add("");            // End   shift
            request.Parameters.Add(_UserInitials); // Start UserCode
            request.Parameters.Add(_UserInitials); // End   UserCode
            request.Parameters.Add("H S N");       // EmpType
            request.Parameters.Add(_whse);         // CurWhse -- //line.GetValue("JobWhse"));                // using value fetched above.
            request.Parameters.Add("");            // Start TranDateOffset
            request.Parameters.Add("");            // End   TranDateOffset
            request.Parameters.Add("");            // infobar OUTPUT
            request.Parameters.Add("");            // prompt buttons OUTPUT
            request.Parameters.Add("");            // Wc 
            request.Parameters.Add("");            // DocumentNum

            try
            {
                InvokeResponseData responseData = this.context.Commands.Invoke(request); // InvokeIDO("SL.SLJobTrans", "JobJobP", inputValues);
                if (!responseData.ReturnValue.Equals("0"))
                {
                    errMessage = constructErrorMessage(responseData.Parameters.ElementAt(20).ToString(), "-1");
                }
            }
            catch (Exception e)
            {
                errMessage = constructErrorMessage(e.Message.ToString(), "-1");
            }

            return errMessage;
        }

        private int extractTransNumFromErrorMsg(string errorMessage)
        {
            int extractedTransNum = -1;
            /*
            * If error message looks like:
            * "JOB does not exist.[Post Job Transaction(s)] was not successful for Job Transaction that has [Transaction: 51862]."
            * then extract 51892 and send it to stored procedure to delete that job transaction.
            * To get this error to show up, unset an entry as posted and change its' transtype from 'I' to 'M'.
            */
            if (errorMessage.ToLowerInvariant().Contains("transaction: "))
            {
                int itransNum;
                int startOfTransNum = errorMessage.ToLowerInvariant().LastIndexOf("transaction: ") + "transaction: ".Length;
                var numInString = errorMessage.Substring(startOfTransNum).TakeWhile(Char.IsNumber);
                string newtransNum = new string(numInString.ToArray());
                if (int.TryParse(newtransNum, out itransNum)) extractedTransNum = itransNum;
            }
            return extractedTransNum;
        }

        private void processBadRecord(int badTransNum, string errorMsg)
        {
            InvokeRequestData request = new InvokeRequestData();
            InvokeResponseData response;
            int InfobarTypeMaxLength = 2800;
            string Infobar = string.Empty;

            errorMsg = errorMsg.Replace(System.Environment.NewLine, " ");
            if (errorMsg.Length > InfobarTypeMaxLength)
            {
                errorMsg = errorMsg.Substring(0, InfobarTypeMaxLength);
            }

            request.IDOName = "ICSLShopFloorTrans";
            request.MethodName = "FTTTProcessBadRecordSp";
            request.Parameters.Add(_SessionID);             // 0 sp Input  - SessionID as string
            request.Parameters.Add(badTransNum.ToString()); // 1 sp Input  - TransNum integer that matches transactionnumber in Syteline jobtran Table
            request.Parameters.Add(errorMsg.ToString());    // 2 sp Input  - ErrorMsg to add to record in _temp tables, by matching _temp table data against Syteline record.
            request.Parameters.Add(IDONull.Value);          // 3 sp Output - Infobar message

            response = this.context.Commands.Invoke(request);

            Infobar = response.Parameters[4].IsNull ? string.Empty : response.Parameters[4].GetValue<string>();

            if (response.IsReturnValueStdError())
            {
                throw new SystemException(Infobar);
            }

        }

        private string getOutputXmlStringAndTidy(bool preserveSessionData)
        {
            InvokeRequestData request = new InvokeRequestData();
            InvokeResponseData response;
            string outputXML = string.Empty;
            string Infobar = string.Empty;
            string preserveSession = (preserveSessionData ? "1" : "0");

            request.IDOName = "ICSLShopFloorTrans";
            request.MethodName = "FTTTGenerateOutputAndTidySp";
            request.Parameters.Add(_SessionID);     // 0 sp Input  - SessionID as string
            request.Parameters.Add(preserveSession);  // 1 sp Input  - @PreserveSession as ListYesNoType -- If "1", then don't clear the session info from the table when done
            request.Parameters.Add(IDONull.Value);  // 2 sp output - @ReturnXmlAsString NVARCHAR
            request.Parameters.Add(IDONull.Value);  // 3 sp output - @Infobar

            response = this.context.Commands.Invoke(request);

            outputXML = response.Parameters[2].GetValue<string>();
            Infobar = response.Parameters[3].IsNull ? string.Empty : response.Parameters[3].GetValue<string>();

            if (response.IsReturnValueStdError())
            {
                throw new SystemException(Infobar);
            }

            return outputXML;
        }
        #endregion

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
