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
    public class JobLaborDaoImpl : ALaborUtils
    {
        #region InputVariables

        private string transType = "";
        private string employee = "";
        private string reportDate = "";
        private string job = "";
        private string suffix = "0";
        private string oper = "0";
        private string indirectCode = "";
        private string workCenter = "";
        private string shift = "";
        private string caltotalTimeInHours = "";
        private string payType = "";    //R - Regular O - Over Time and D - Double Time
        private string startTimeInSeconds = "0";
        private string endTimeInSeconds = "0";
        private string userInitials = "";

        private string qtyCompleted = "0";
        private string qtyMoved = "0";
        private string qtyRejected = "0";
        private string reasonCode = "";
        private string completeOper = "";
        private string nextOper = "0";
        private string RESID = "";
        private bool StopPostJobs = false;
        #endregion

        #region LocalVariables
        private new InvokeResponseData employeeResponseData = null;
        private LoadCollectionResponseData orderResponseData = null;
        private InvokeResponseData invokeOrderResponseData = null;
        private InvokeResponseData invokeOrderOperResponseData = null;
        private InvokeResponseData payTypeResponseData = null;
        private IDOUpdateItem returnUpdateItem = null;
        private string JobWhse = "";
        #endregion

        #region Flow Methods

        public JobLaborDaoImpl(IIDOExtensionClassContext context)
        {
            initialize();
            this.Context = context;
            
        }

        public void initialize()
        {
            base.Initialize();

            transType = "";
            employee = "";
            reportDate = "";
            job = "";
            suffix = "0";
            oper = "0";
            indirectCode = "";
            workCenter = "";
            shift = "";
            caltotalTimeInHours = "0";
            payType = "";    //R - Regular O - Over Time and D - Double Time
            userInitials = "";

            qtyCompleted = "0";
            qtyMoved = "0";
            qtyRejected = "0";
            reasonCode = "";
            completeOper = "";
            nextOper = "0";
            RESID = "";
            employeeResponseData = null;
            orderResponseData = null;
            invokeOrderResponseData = null;
            invokeOrderOperResponseData = null;
            payTypeResponseData = null;
            returnUpdateItem = null;
            startTimeInSeconds = "0";
            endTimeInSeconds = "0";
            StopPostJobs = false;
        }

        public bool formatInputs(Request updateRequest)
        {
            employee = formatDataByIDOAndPropertyName("SLEmployees", "EmpNum", updateRequest.GetFieldValue("employee"));
            job = FormatJobString(updateRequest.GetFieldValue("job"));
            suffix = formatDataByIDOAndPropertyName("SLDcsfcs", "Suffix", updateRequest.GetFieldValue("suffix"));
            oper = updateRequest.GetFieldValue("oper");
            transType = updateRequest.GetFieldValue("transType");
            indirectCode = updateRequest.GetFieldValue("indirectCode");
            userInitials = updateRequest.GetFieldValue("userInitials");
            reportDate = updateRequest.GetFieldValue("reportDate");
            caltotalTimeInHours = updateRequest.GetFieldValue("caltotalTimeInHours");
            startTimeInSeconds = updateRequest.GetFieldValue("startTimeInSeconds");
            endTimeInSeconds = updateRequest.GetFieldValue("endTimeInSeconds");
            workCenter = updateRequest.GetFieldValue("workCenter");
            shift = updateRequest.GetFieldValue("shift");
            payType = updateRequest.GetFieldValue("payType");

            try
            {
                qtyCompleted = updateRequest.GetFieldValue("qtyCompleted");
                if (qtyCompleted == null || qtyCompleted == "")
                {
                    qtyCompleted = "0";
                }

                qtyMoved = updateRequest.GetFieldValue("qtyMoved");
                if (qtyMoved == null || qtyMoved == "")
                {
                    qtyMoved = "0";
                }

                qtyRejected = updateRequest.GetFieldValue("qtyRejected");
                if (qtyRejected == null || qtyRejected == "")
                {
                    qtyRejected = "0";
                }

                reasonCode = updateRequest.GetFieldValue("reasonCode");
                completeOper = updateRequest.GetFieldValue("completeOper");

            }
            catch { }

            try
            {
                StopPostJobs = updateRequest.GetBoolFieldValue("StopPostJobs");
            }
            catch {
                StopPostJobs = false;
            }

            nextOper = updateRequest.GetFieldValue("nextOper");
            RESID  = updateRequest.GetFieldValue("RESID");
            if (this.transType.Equals("22") || this.transType.Equals("23") || this.transType.Equals("24") || this.transType.Equals("M"))
            {
                if (job == null || job.Trim().Equals(""))
                {
                    IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                    //substitutorDictionary.Add("transactionType", "R");
                    substitutorDictionary.Add("transactionType", GetUnPostedTransTypeString(transType));
                    throw new Exception("Job input mandatory for Transaction Type " + transType);
                }
                if (suffix == null || suffix.Trim().Equals(""))
                {
                    IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                    //substitutorDictionary.Add("transactionType", "R");
                    substitutorDictionary.Add("transactionType", GetUnPostedTransTypeString(transType));

                    throw new Exception("Suffix input mandatory for Transaction Type " + transType);
                }
                if (oper == null || oper.Trim().Equals(""))
                {
                    IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                    //substitutorDictionary.Add("transactionType", "R");
                    substitutorDictionary.Add("transactionType", GetUnPostedTransTypeString(transType));
                    throw new Exception("Operation input mandatory for Transaction Type " + transType);
                }
            }

            if (indirectCode == null || indirectCode.Trim().Equals(""))
            {
                if (this.transType.Equals("21"))
                {
                    throw new Exception("Indirect Code is mandatory for Indirect Transaction Type");
                }
            }

            if (!this.transType.Equals("M") && !this.transType.Equals("24"))
            {
                if (shift == null || shift.Trim().Equals(""))
                {
                    throw new Exception("Shift input mandatory");
                }

                if (payType == null || payType.Trim().Equals(""))
                {
                    throw new Exception("Pay Type input mandatory");
                }

                if (!(payType.Equals("R") || payType.Equals("O") || payType.Equals("D")))
                {
                    throw new Exception("Pay Type Should be one of R/O/D");
                }
            }


            if (reportDate == null || reportDate.Trim().Equals(""))
            {
                throw new Exception("Report Date input mandatory");
            }

            if (suffix.Trim().Equals(""))
            {
                suffix = "0";
            }

            if (oper.Trim().Equals(""))
            {
                oper = "0";
            }

            if (nextOper.Trim().Equals(""))
            {
                nextOper = "0";
            }

            return true;
        }

        private bool validateInputs(Request updateRequest)
        {
            reportDate = updateRequest.GetFieldValue("reportDate");

            //Date Check

            if (TransDateCheck(reportDate) == false)
            {
                if (errorMessage != null && !(errorMessage.Trim().Equals("")))
                {
                    throw new Exception(GetErrorStringFromErrorMessage(errorMessage));
                }
                return false;
            }

            if (!transType.Equals("24") && !transType.Equals("M"))
            {
                if (ValidateEmployee(employee) == false)
                {
                    throw new Exception("Employee Details Not Found");
                }

                employeeResponseData = JobtranEmpValidSp(employee, payType, reportDate);
                if (errorMessage != null && !(errorMessage.Trim().Equals("")))
                {
                    throw new Exception(GetErrorStringFromErrorMessage(errorMessage));
                }
            }

            if (transType.Equals("24"))                                          //Kiran 01-07-2014.sn
            {
                if (employee != null && !(employee.Trim().Equals("")))
                {
                    if (ValidateEmployee(employee) == false)
                    {
                        throw new Exception("Employee Details Not Found");
                    }
                }
            }                                                                   //Kiran 01-07-2014.en

            if (transType.Equals("22") || transType.Equals("23") || transType.Equals("24") || transType.Equals("M"))
            {
                orderResponseData = ValidateJob(job, suffix);
                if (orderResponseData.Items.Count == 0)
                {
                    throw new Exception("Job Details Not Found");
                }
                else
                {
                    JobWhse = orderResponseData[0, "Whse"].ToString();
                }

                if (orderResponseData[0, "Stat"].ToString().ToUpper() == "F")
                {
                    throw new Exception("Job status is [Firm] Cannot proceed");
                }
                else if (orderResponseData[0, "Stat"].ToString().ToUpper() == "S")
                {
                    throw new Exception("Job status is [Stopped] Cannot proceed");
                }
                else if (orderResponseData[0, "Stat"].ToString().ToUpper() == "C")
                {
                    throw new Exception("Job status is [Complete] Cannot proceed");
                }

                if (ValidateJobOper(job, suffix, oper) == false)
                {
                    throw new Exception("Job Operation details not found");
                }

                if (workCenter != null && !(workCenter.Trim().Equals("")))
                {
                    if (ValidateWorkCenter(workCenter) == false)
                    {
                        throw new Exception(GetErrorStringFromErrorMessage(errorMessage));
                    }
                }

                if (transType.Equals("M"))
                {
                    invokeOrderResponseData = JobtranJobValidSp("M", job, suffix, oper);
                }
                else
                {
                    //invokeOrderResponseData = JobtranJobValidSp("R", job, suffix, oper);
                    invokeOrderResponseData = JobtranJobValidSp(GetUnPostedTransTypeString(transType), job, suffix, oper);
                }

                if (errorMessage != null && !(errorMessage.Trim().Equals("")))
                {
                    throw new Exception(GetErrorStringFromErrorMessage(errorMessage));
                }

                if (transType.Equals("M"))
                {
                    invokeOrderOperResponseData = JobtranOperNumValidSp("M", job, suffix, oper, workCenter);
                }
                else
                {
                    //invokeOrderOperResponseData = JobtranOperNumValidSp("R", job, suffix, oper, workCenter);
                    invokeOrderOperResponseData = JobtranOperNumValidSp(GetUnPostedTransTypeString(transType), job, suffix, oper, workCenter);

                }

                if (errorMessage != null && !(errorMessage.Trim().Equals("")))
                {
                    throw new Exception(GetErrorStringFromErrorMessage(errorMessage));
                }
            }

            if (!transType.Equals("M") && !transType.Equals("24"))
            {
                //Shift Field Checks
                LoadCollectionResponseData responseData = GetShiftDetails(shift);
                if (responseData.Items.Count == 0)
                {
                    throw new Exception("Shift Details Not Found");
                }

                //Pay Type Field Checks
                payTypeResponseData = JobtranCalcRateSp(payType, employee, shift, reportDate);
                if (errorMessage != null && !(errorMessage.Trim().Equals("")))
                {
                    throw new Exception(GetErrorStringFromErrorMessage(errorMessage));
                }

                //Validate Work Center
                if (workCenter != null && !(workCenter.Trim().Equals("")))
                {
                    if (ValidateWorkCenter(workCenter) == false)
                    {
                        throw new Exception("Work Center Details Not Found");
                    }
                }
            }

            //Indirect Task Code Validation
            if (this.transType.Equals("21"))
            {
                LoadCollectionResponseData indirectResponseData = ValidateIndirectCode();
                if (indirectResponseData.Items.Count == 0)
                {
                    throw new Exception("Indirect code details not found");
                }
            }
            return true;
        }

        private bool TransDateCheck(string transDate)
        {
            //1 Date Check
            object[] dateCheckValues = new object[] { transDate,
                                                      "Transaction Date",
                                                      "@%update",
                                                      "",
                                                      "",
                                                      "" };

            InvokeResponseData invokeResponseDataStep1 = this.Context.Commands.Invoke("SLPeriods", "DateChkSp", dateCheckValues);
            if (!(invokeResponseDataStep1.ReturnValue.Equals("0")))
            {
                errorMessage = invokeResponseDataStep1.Parameters.ElementAt(3).ToString();
                if (!invokeResponseDataStep1.Parameters.ElementAt(4).ToString().Equals(""))
                {
                    errorMessage = invokeResponseDataStep1.Parameters.ElementAt(4).ToString();
                }
                return false;
            }
            return true;
        }

        public int PerformUpdate(Request updateRequest, out string infobar)
        {
            initialize();

            try
            {
                if (formatInputs(updateRequest) == false)
                {
                    infobar = errorMessage;
                    return 16;
                }

                if (validateInputs(updateRequest) == false)
                {
                    infobar = errorMessage;
                    return 16;
                }
            }
            catch (Exception ex)
            {
                infobar = ex.Message;
                return 16;
            }

            //4 Perform Updates
            if (performJobPosting(updateRequest) > 0)
            {
                infobar = errorMessage;
                return 16;
            }

            infobar = "";
            return 0;
        }

        #endregion

        #region private methods

        private int performJobPosting(Request updateRequest)
        {
            if (insertIntoMainTable(updateRequest) == false)
            {
                return 16;
            }

            if (StopPostJobs == false)
            {
                if (performPosting() == false)
                {
                    deleteFromMainTable();
                    return 16;
                }
            }
            return 0;
        }

        private bool insertIntoMainTable(Request updateRequest)
        {
            UpdateCollectionRequestData updateRequestData = new UpdateCollectionRequestData();

            updateRequestData.IDOName = "SL.SLJobTrans";
            updateRequestData.RefreshAfterUpdate = true;
            updateRequestData.CustomUpdate = "STD,JobtranPostSaveSp(Job,Suffix,OperNum,JobrWc),REF";
            updateRequestData.CustomInsert = "STD,JobtranPostSaveSp(Job,Suffix,OperNum,JobrWc),REF";
            updateRequestData.CustomDelete = "DeleteJobtranitemSp(TransNum),STD";

            IDOUpdateItem updateItem = new IDOUpdateItem();
            updateItem.Action = UpdateAction.Insert;
            updateItem.Properties.Add("TransNum", "");
            updateItem.Properties.Add("Posted", "0");
            updateItem.Properties.Add("Job", job);
            updateItem.Properties.Add("JobrWc", workCenter);
            updateItem.Properties.Add("NoteExistsFlag", "", false);
            updateItem.Properties.Add("OperNum", oper);
            updateItem.Properties.Add("RowPointer", "", false);
            updateItem.Properties.Add("Suffix", suffix);
            updateItem.Properties.Add("InWorkflow", "", false);
            updateItem.Properties.Add("_ItemWarnings", "", false);
            updateItem.Properties.Add("DerOrdNum", "");
            updateItem.Properties.Add("DerOrdLine", "0");
            updateItem.Properties.Add("DerOrdRelease", "0");

            //updateItem.Properties.Add("TransType", transactionType);
            if (transType.Equals("21"))
            {
                updateItem.Properties.Add("TransType", "I");
            }
            else if (transType.Equals("22"))
            {
                updateItem.Properties.Add("TransType", "R");
            }
            else if (transType.Equals("23"))
            {
                updateItem.Properties.Add("TransType", "S");
            }
            else if (transType.Equals("24"))
            {
                updateItem.Properties.Add("TransType", "C");
            }
            else
            {
                updateItem.Properties.Add("TransType", "M");
            }

            updateItem.Properties.Add("TransDate", reportDate);
            if (userInitials != null && !(userInitials.Trim().Equals("")))                      //12-28-11.sn       - Kiran
            {
                updateItem.Properties.Add("UserCode", userInitials);
            }
            else
            {
                updateItem.Properties.Add("UserCode", "SA");                            // Need to Fix      //12-28-11.en       - Kiran
            }

            updateItem.Properties.Add("JobItem", "");
            updateItem.Properties.Add("ItemDescription", "");
            updateItem.Properties.Add("WcDescription", "");
            if (transType.Equals("M") || transType.Equals("24"))
            {
                if (employee != null && !(employee.Trim().Equals("")))
                {
                    updateItem.Properties.Add("EmpNum", employee);
                }
                else
                {
                    updateItem.Properties.Add("EmpNum", "");
                }
                updateItem.Properties.Add("EmpName", "");
                updateItem.Properties.Add("Shift", "");
                updateItem.Properties.Add("PayRate", "");
                updateItem.Properties.Add("PrRate", "");
                updateItem.Properties.Add("JobRate", "");
                updateItem.Properties.Add("IndCode", "");
                updateItem.Properties.Add("IndcodeDescription", "");
            }
            else
            {
                updateItem.Properties.Add("EmpNum", employee);
                updateItem.Properties.Add("EmpName", "");
                updateItem.Properties.Add("Shift", shift);
                updateItem.Properties.Add("PayRate", payType);
                updateItem.Properties.Add("PrRate", payTypeResponseData.Parameters.ElementAt(4).ToString());
                updateItem.Properties.Add("JobRate", payTypeResponseData.Parameters.ElementAt(5).ToString());
                updateItem.Properties.Add("IndCode", this.indirectCode);
                updateItem.Properties.Add("IndcodeDescription", "");
            }

            updateItem.Properties.Add("QtyComplete", qtyCompleted);
            updateItem.Properties.Add("QtyScrapped", qtyRejected);
            updateItem.Properties.Add("QtyMoved", qtyMoved);
            updateItem.Properties.Add("ReasonCode", reasonCode);
            updateItem.Properties.Add("Loc", "");
            updateItem.Properties.Add("LocDescription", "");
            updateItem.Properties.Add("Lot", "");

            updateItem.Properties.Add("ItemUM", "");

            if (!nextOper.Equals("0"))
            {
                updateItem.Properties.Add("NextOper", nextOper);
            }
            else
            {
                if (transType.Equals("M"))
                {
                    if (invokeOrderOperResponseData == null || (invokeOrderOperResponseData.Parameters.ElementAt(9).ToString().Equals("")))
                    {
                        updateItem.Properties.Add("NextOper", oper);
                    }
                    else
                    {
                        updateItem.Properties.Add("NextOper", invokeOrderOperResponseData.Parameters.ElementAt(9).ToString());
                    }
                }
                else
                {
                    if (invokeOrderOperResponseData == null || (invokeOrderOperResponseData.Parameters.ElementAt(9).ToString().Equals("")))
                    {
                        updateItem.Properties.Add("NextOper", "");
                    }
                    else
                    {
                        updateItem.Properties.Add("NextOper", invokeOrderOperResponseData.Parameters.ElementAt(9).ToString());
                    }
                }
            }
            updateItem.Properties.Add("RESID", RESID);
            updateItem.Properties.Add("XjobrWc", "");
            updateItem.Properties.Add("XwcDescription", "");
            updateItem.Properties.Add("ReasonDescription", "");

            updateItem.Properties.Add("DerStartTimeHrs", "", false);
            updateItem.Properties.Add("DerStartTimeMin", "");
            updateItem.Properties.Add("DerEndTimeMin", "");
            updateItem.Properties.Add("AHrs", caltotalTimeInHours);
            updateItem.Properties.Add("DerEndTimeHrs", "", false);
            updateItem.Properties.Add("Whse", JobWhse);
            updateItem.Properties.Add("CostCode", ((invokeOrderOperResponseData == null) ? "" : invokeOrderOperResponseData.Parameters.ElementAt(8).ToString()));
            updateItem.Properties.Add("JobrCntrlPoint", "");

            if (completeOper != null && completeOper != "")
            {
                updateItem.Properties.Add("CompleteOp", completeOper);
            }
            else
            {
                updateItem.Properties.Add("CompleteOp", "0");
            }

            updateItem.Properties.Add("CloseJob", "0");
            updateItem.Properties.Add("IssueParent", "0");
            updateItem.Properties.Add("UbTargetQty", "0");
            updateItem.Properties.Add("UbSelectedQty", "0");

            updateItem.Properties.Add("UbGenerateQty", "0");
            updateItem.Properties.Add("UbRangeQty", "0");
            updateItem.Properties.Add("UbSerialPrefix", "", false);
            updateItem.Properties.Add("JobCoProductMix", "");
            updateItem.Properties.Add("JobOrdType", "I");

            updateItem.Properties.Add("JobJob", "", false);
            updateItem.Properties.Add("JobRefJob", "");
            updateItem.Properties.Add("JobRootJob", job);
            updateItem.Properties.Add("JobRootSuf", suffix);
            updateItem.Properties.Add("ItemSerialTracked", "0");
            updateItem.Properties.Add("TransClass", "J");
            updateItem.Properties.Add("UbNewOper", "0");
            updateItem.Properties.Add("ItemLotTracked", "0");
            updateItem.Properties.Add("JobStat", "F");
            updateItem.Properties.Add("JobType", "E");
            updateItem.Properties.Add("UbOldEmp", "");
            updateItem.Properties.Add("DerQtyComplete", "0");
            updateItem.Properties.Add("DerQtyScrapped", "0");
            updateItem.Properties.Add("DerQtyMoved", "0");

            updateItem.Properties.Add("StartTime", startTimeInSeconds);

            updateItem.Properties.Add("EndTime", endTimeInSeconds);
            updateItem.Properties.Add("Wc", workCenter);
            updateItem.Properties.Add("CoProductMix", "");
            // Added Properties
            updateItem.Properties.Add("IsJobXrefdToProject", "0");
            updateItem.Properties.Add("IsSubJobTiedToProject", "0");
            updateItem.Properties.Add("JobtranitemQtyComplete", "");
            updateItem.Properties.Add("JobtranitemQtyScrapped", "");
            updateItem.Properties.Add("JobtranitemQtyMoved", "");
            // Ended 
            updateItem.ItemID = "";
            updateItem.ItemNumber = 1;
            updateRequestData.Items.Add(updateItem);
            UpdateCollectionResponseData updateResponseData = null;

            try
            {

                updateResponseData = this.Context.Commands.UpdateCollection(updateRequestData);

                //Console.WriteLine(updateResponseData.ToXml());
            }
            catch (Exception ee)
            {
                //Console.WriteLine(ee.Message);
                throw ee;
            }

            //second update
            #region second update

            returnUpdateItem = updateResponseData.Items.ElementAt(0);


            UpdateCollectionRequestData updateRequestDatasecond = new UpdateCollectionRequestData();
            updateRequestDatasecond.IDOName = "SL.SLJobTrans";
            updateRequestDatasecond.RefreshAfterUpdate = true;
            updateRequestDatasecond.CustomUpdate = "Null(),REF";
            updateRequestDatasecond.CustomInsert = "Null(),REF";
            updateRequestDatasecond.CustomDelete = "Null()";

            updateItem = new IDOUpdateItem();
            updateItem.Action = UpdateAction.Insert;


            updateItem.Properties.Add("TransNum", returnUpdateItem.Properties.ElementAt(0).Value);
            updateItem.Properties.Add("Posted", "0");
            updateItem.Properties.Add("Job", job);
            updateItem.Properties.Add("JobrWc", workCenter);
            updateItem.Properties.Add("NoteExistsFlag", "", false);
            updateItem.Properties.Add("OperNum", oper);
            updateItem.Properties.Add("RowPointer", returnUpdateItem.Properties.ElementAt(returnUpdateItem.Properties.IndexOf("RowPointer")).Value);
            updateItem.Properties.Add("Suffix", suffix);
            updateItem.Properties.Add("InWorkflow", "", false);
            updateItem.Properties.Add("_ItemWarnings", "", false);
            updateItem.Properties.Add("DerOrdNum", "");
            updateItem.Properties.Add("DerOrdLine", "0");
            updateItem.Properties.Add("DerOrdRelease", "0");

            
            if (transType.Equals("21"))
            {
                updateItem.Properties.Add("TransType", "I");
            }
            else if (transType.Equals("22"))
            {
                updateItem.Properties.Add("TransType", "R");
            }
            else if (transType.Equals("23"))
            {
                updateItem.Properties.Add("TransType", "S");
            }
            else if (transType.Equals("24"))
            {
                updateItem.Properties.Add("TransType", "C");
            }
            else
            {
                updateItem.Properties.Add("TransType", "M");
            }

            updateItem.Properties.Add("TransDate", reportDate);
            //updateItem.Properties.Add("UserCode", "SA");
            if (userInitials != null && !(userInitials.Trim().Equals("")))                      //12-28-11.sn       - Kiran
            {
                updateItem.Properties.Add("UserCode", userInitials);
            }
            else
            {
                updateItem.Properties.Add("UserCode", "SA");                            // Need to Fix      //12-28-11.en       - Kiran
            }
            updateItem.Properties.Add("JobItem", "");
            updateItem.Properties.Add("ItemDescription", "");
            updateItem.Properties.Add("WcDescription", "");

            if (transType.Equals("M") || transType.Equals("24"))
            {
                updateItem.Properties.Add("EmpNum", "");
                updateItem.Properties.Add("EmpName", "");
                updateItem.Properties.Add("Shift", "");
                updateItem.Properties.Add("PayRate", "");
                updateItem.Properties.Add("PrRate", "");
                updateItem.Properties.Add("JobRate", "");
                updateItem.Properties.Add("IndCode", "");
                updateItem.Properties.Add("IndcodeDescription", "");
            }
            else
            {
                updateItem.Properties.Add("EmpNum", employee);
                updateItem.Properties.Add("EmpName", "");
                updateItem.Properties.Add("Shift", shift);
                updateItem.Properties.Add("PayRate", payType);
                updateItem.Properties.Add("PrRate", payTypeResponseData.Parameters.ElementAt(4).ToString());
                updateItem.Properties.Add("JobRate", payTypeResponseData.Parameters.ElementAt(5).ToString());
                updateItem.Properties.Add("IndCode", this.indirectCode);
                updateItem.Properties.Add("IndcodeDescription", "");
            }

            updateItem.Properties.Add("QtyComplete", qtyCompleted);
            updateItem.Properties.Add("ItemUM", "");
            updateItem.Properties.Add("QtyScrapped", qtyRejected);
            updateItem.Properties.Add("QtyMoved", qtyMoved);

            if (!nextOper.Equals("0"))
            {
                updateItem.Properties.Add("NextOper", nextOper);
            }
            else
            {
                if (transType.Equals("M"))
                {
                    if (invokeOrderOperResponseData == null || (invokeOrderOperResponseData.Parameters.ElementAt(9).ToString().Equals("")))
                    {
                        updateItem.Properties.Add("NextOper", oper);
                    }
                    else
                    {
                        updateItem.Properties.Add("NextOper", invokeOrderOperResponseData.Parameters.ElementAt(9).ToString());
                    }
                }
                else
                {
                    if (invokeOrderOperResponseData == null || (invokeOrderOperResponseData.Parameters.ElementAt(9).ToString().Equals("")))
                    {
                        updateItem.Properties.Add("NextOper", "");
                    }
                    else
                    {
                        updateItem.Properties.Add("NextOper", invokeOrderOperResponseData.Parameters.ElementAt(9).ToString());
                    }
                }
            }
            updateItem.Properties.Add("RESID", RESID);
            updateItem.Properties.Add("XjobrWc", "");
            updateItem.Properties.Add("XwcDescription", "");
            updateItem.Properties.Add("ReasonCode", reasonCode);
            updateItem.Properties.Add("ReasonDescription", "");
            updateItem.Properties.Add("Loc", "");
            updateItem.Properties.Add("LocDescription", "");
            updateItem.Properties.Add("Lot", "");

            updateItem.Properties.Add("DerStartTimeHrs", "", false);
            updateItem.Properties.Add("DerStartTimeMin", "");
            updateItem.Properties.Add("DerEndTimeMin", "");
            updateItem.Properties.Add("AHrs", caltotalTimeInHours);
            updateItem.Properties.Add("DerEndTimeHrs", "", false);
            updateItem.Properties.Add("Whse", JobWhse);
            updateItem.Properties.Add("CostCode", ((invokeOrderOperResponseData == null) ? "" : invokeOrderOperResponseData.Parameters.ElementAt(8).ToString()));
            updateItem.Properties.Add("JobrCntrlPoint", "0");

            if (completeOper != null)
            {
                updateItem.Properties.Add("CompleteOp", completeOper);
            }
            else
            {
                updateItem.Properties.Add("CompleteOp", "0");
            }

            updateItem.Properties.Add("CloseJob", "0");
            updateItem.Properties.Add("IssueParent", "0");
            updateItem.Properties.Add("UbTargetQty", "0");
            updateItem.Properties.Add("UbSelectedQty", "0");
            updateItem.Properties.Add("UbGenerateQty", "0");
            updateItem.Properties.Add("UbRangeQty", "0");
            updateItem.Properties.Add("UbSerialPrefix", "", false);
            updateItem.Properties.Add("JobCoProductMix", "");
            updateItem.Properties.Add("JobOrdType", "I");

            updateItem.Properties.Add("JobJob", "", false);
            updateItem.Properties.Add("JobRefJob", "");
            updateItem.Properties.Add("JobRootJob", job);
            updateItem.Properties.Add("JobRootSuf", suffix);
            updateItem.Properties.Add("ItemSerialTracked", "0");
            updateItem.Properties.Add("TransClass", "J");
            updateItem.Properties.Add("UbNewOper", "0");
            updateItem.Properties.Add("ItemLotTracked", "0");
            updateItem.Properties.Add("JobStat", "F");
            updateItem.Properties.Add("JobType", "E");
            updateItem.Properties.Add("UbOldEmp", "");
            updateItem.Properties.Add("DerQtyComplete", "0");
            updateItem.Properties.Add("DerQtyScrapped", "0");
            updateItem.Properties.Add("DerQtyMoved", "0");

            updateItem.Properties.Add("StartTime", startTimeInSeconds);

            updateItem.Properties.Add("EndTime", endTimeInSeconds);
            updateItem.Properties.Add("Wc", workCenter);
            updateItem.Properties.Add("CoProductMix", "");

            // Added Properties
            updateItem.Properties.Add("IsJobXrefdToProject", "0");
            updateItem.Properties.Add("IsSubJobTiedToProject", "0");
            updateItem.Properties.Add("JobtranitemQtyComplete", "");
            updateItem.Properties.Add("JobtranitemQtyScrapped", "");
            updateItem.Properties.Add("JobtranitemQtyMoved", "");
            // Ended 
            updateItem.ItemID = returnUpdateItem.ItemID;
            updateItem.ItemNumber = 1;
            updateRequestDatasecond.Items.Add(updateItem);
            updateResponseData = null;
            try
            {
                updateResponseData = this.Context.Commands.UpdateCollection(updateRequestDatasecond);
                //Console.WriteLine(updateResponseData.ToXml());
            }
            catch (Exception ee)
            {
                //Console.WriteLine(ee.Message);
                throw ee;
            }

            #endregion

            return true;
        }

        private LoadCollectionResponseData ValidateIndirectCode()
        {
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SL.SLIndcodes";
            requestData.PropertyList.SetProperties("IndCode,Description");
            string filterString = "IndCode = '" + indirectCode + "'";
            requestData.Filter = filterString;
            requestData.RecordCap = 1;
            requestData.OrderBy = "IndCode";
            return this.Context.Commands.LoadCollection(requestData);
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

        private string GetUnPostedTransTypeString(string transType)
        {
            if (transType.Equals("21"))
            {
                return "I";
            }

            if (transType.Equals("22"))
            {
                return "R";
            }

            if (transType.Equals("23"))
            {
                return "S";
            }

            if (transType.Equals("24"))
            {
                return "C";
            }

            return "";
        }

        private bool performPosting()
        {
            //if a customer reports a error with the number of params for JobJobP see LaborStopDaoImpl.performPosting() JH:20130215
            //  no error has been reported in this class or for previous version of this class and it appears to work.  So no changes were made at this time 
            //  but this has been a significant issue in the past for labor stop.
            object[] inputValues = new object[]{
                                                "1",
                                                "0",
                                                job,
                                                job,
                                                suffix,
                                                suffix,
                                                reportDate,
                                                reportDate,
                                                employee,
                                                employee,
                                                "",
                                                "",
                                                "",
                                                "",
                                                userInitials,
                                                userInitials,
                                                "H S N",
                                                JobWhse,//WHSE
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                ""      //new
                                                };
            try
            {
                InvokeResponseData responseData = InvokeIDO("SL.SLJobTrans", "JobJobP", inputValues);
                if (!responseData.ReturnValue.Equals("0"))
                {
                    errorMessage = constructErrorMessage(responseData.Parameters.ElementAt(20).ToString(), "-1", null);
                    return false;
                }
            }
            catch (Exception e)
            {
                errorMessage = constructErrorMessage(e.Message.ToString(), "-1", null);
                return false;
            }
            return true;

        }

        public bool deleteFromMainTable()
        {
            //UpdateCollectionRequestData updateRequestData = new UpdateCollectionRequestData();
            //updateRequestData.IDOName = "SL.SLJobTrans";
            //updateRequestData.RefreshAfterUpdate = true;
            //updateRequestData.CustomUpdate = "STD,JobtranPostSaveSp(Job,Suffix,OperNum,JobrWc),REF";
            //updateRequestData.CustomInsert = "STD,JobtranPostSaveSp(Job,Suffix,OperNum,JobrWc),REF";
            //updateRequestData.CustomDelete = "DeleteJobtranitemSp(TransNum),STD";

            //IDOUpdateItem updateItem = new IDOUpdateItem();
            //updateItem.Action = UpdateAction.Delete;

            //updateItem.Properties.Add("TransNum", returnUpdateItem.Properties.ElementAt(0).Value);
            //updateItem.Properties.Add("Posted", "0");
            //updateItem.Properties.Add("Job", job);
            //updateItem.Properties.Add("JobrWc", invokeOrderResponseData.Parameters.ElementAt(21).ToString());
            //updateItem.Properties.Add("NoteExistsFlag", "0", false);
            //updateItem.Properties.Add("OperNum", oper);
            //Console.WriteLine("SLJobTrans Update RowPointer3: " + returnUpdateItem.Properties.ElementAt(7).Value);
            //updateItem.Properties.Add("RowPointer", returnUpdateItem.Properties.ElementAt(7).Value);
            //updateItem.Properties.Add("Suffix", suffix);
            //updateItem.Properties.Add("InWorkflow", "", false);
            //updateItem.Properties.Add("_ItemWarnings", "", false);
            //if (!this.GetSyteLineVersion().Equals("8.01.00") && !this.GetSyteLineVersion().Equals("8.01.11") && !this.GetSyteLineVersion().Equals("8.00.20") && !this.GetSyteLineVersion().Equals("8.01.20"))
            //{
            //    updateItem.Properties.Add("DerOrdNum", "");
            //}

            //if (!this.GetSyteLineVersion().Equals("8.01.11") && !this.GetSyteLineVersion().Equals("8.00.20") && !this.GetSyteLineVersion().Equals("8.01.20"))
            //{
            //    updateItem.Properties.Add("DerOrdLine", "0");
            //    updateItem.Properties.Add("DerOrdRelease", "0");
            //}

            //updateItem.Properties.Add("TransType", "M");
            //updateItem.Properties.Add("TransDate", reportDate);
            //updateItem.Properties.Add("UserCode", userInitials);
            //updateItem.Properties.Add("JobItem", jobItem);
            //updateItem.Properties.Add("ItemDescription", "");
            //updateItem.Properties.Add("WcDescription", "");
            //updateItem.Properties.Add("EmpNum", employee);
            //updateItem.Properties.Add("EmpName", "", false);

            //updateItem.Properties.Add("Shift", "");
            //updateItem.Properties.Add("PayRate", "");


            //updateItem.Properties.Add("PrRate", "");
            //updateItem.Properties.Add("JobRate", "");
            //updateItem.Properties.Add("IndCode", "");
            //updateItem.Properties.Add("IndcodeDescription", "");

            //updateItem.Properties.Add("QtyComplete", qtyCompleted);
            //updateItem.Properties.Add("ItemUM", uom);
            //updateItem.Properties.Add("QtyScrapped", qtyScrapped);
            //updateItem.Properties.Add("QtyMoved", qtyMoved);
            //updateItem.Properties.Add("NextOper", ((invokeOrderOperResponseData == null) ? "" : invokeOrderOperResponseData.Parameters.ElementAt(9).ToString()));

            //updateItem.Properties.Add("XjobrWc", "");               //can be filled 
            //updateItem.Properties.Add("XwcDescription", "");    //can be filled
            //updateItem.Properties.Add("ReasonCode", reasonCode);
            //updateItem.Properties.Add("ReasonDescription", GetReasonCodeDesc());
            //updateItem.Properties.Add("Loc", loc);
            //updateItem.Properties.Add("LocDescription", "");
            //updateItem.Properties.Add("Lot", lot);

            //updateItem.Properties.Add("DerStartTimeHrs", "", false);
            //updateItem.Properties.Add("DerStartTimeMin", "", false);
            //updateItem.Properties.Add("DerEndTimeMin", "", false);
            //updateItem.Properties.Add("AHrs", HrNullCheck("")); //MSF162514: total hours can not be null or "".  JH:20130528
            //updateItem.Properties.Add("DerEndTimeHrs", "", false);
            //updateItem.Properties.Add("Whse", whse);
            //updateItem.Properties.Add("CostCode", "", false);
            //updateItem.Properties.Add("JobrCntrlPoint", "need to be filled");
            //updateItem.Properties.Add("CompleteOp", GetIDOInputBoolValue(operComplete));
            //updateItem.Properties.Add("CloseJob", GetIDOInputBoolValue(closeJob));
            //updateItem.Properties.Add("IssueParent", "0");
            //updateItem.Properties.Add("UbTargetQty", "0");
            //updateItem.Properties.Add("UbSelectedQty", "0");
            //updateItem.Properties.Add("UbGenerateQty", "0");
            //updateItem.Properties.Add("UbRangeQty", "0");
            //updateItem.Properties.Add("UbSerialPrefix", "", false);
            //updateItem.Properties.Add("JobCoProductMix", "0");
            //updateItem.Properties.Add("JobOrdType", "I");

            //updateItem.Properties.Add("JobJob", "", false);
            //updateItem.Properties.Add("JobRefJob", "");
            //updateItem.Properties.Add("JobRootJob", job);
            //updateItem.Properties.Add("JobRootSuf", suffix);
            //updateItem.Properties.Add("ItemSerialTracked", GetIDOInputBoolValue(itemSerialTracked));
            //updateItem.Properties.Add("TransClass", "J");
            //updateItem.Properties.Add("UbNewOper", "0");
            //updateItem.Properties.Add("ItemLotTracked", GetIDOInputBoolValue(itemLotTracked));
            //updateItem.Properties.Add("JobStat", "F");      //not sure
            //updateItem.Properties.Add("JobType", "E");      //not sure
            //updateItem.Properties.Add("UbOldEmp", "");
            //updateItem.Properties.Add("DerQtyComplete", "0");
            //updateItem.Properties.Add("DerQtyScrapped", "0");
            //updateItem.Properties.Add("DerQtyMoved", "0");

            //updateItem.Properties.Add("StartTime", "", false);

            //updateItem.Properties.Add("EndTime", "", false);
            ////updateItem.Properties.Add("Wc", invokeOrderResponseData.Parameters.ElementAt(21).ToString());
            //updateItem.Properties.Add("Wc", invokeOrderOperResponseData.Parameters.ElementAt(6).ToString()); //should be the wc on the operation not the job.  JH:20130228 MSF157944
            //updateItem.Properties.Add("CoProductMix", "0");


            //updateItem.ItemID = returnUpdateItem.ItemID;
            //updateItem.ItemNumber = 1;
            //updateRequestData.Items.Add(updateItem);
            //UpdateCollectionResponseData updateResponseData = null;
            //try
            //{
            //    updateResponseData = this.sytelineClient.UpdateCollection(updateRequestData);
            //    Console.WriteLine(updateResponseData.ToXml());
            //}
            //catch (Exception ee)
            //{
            //    Console.WriteLine(ee.Message);
            //    errorMessage = constructErrorMessage(ee.Message, null, null);
            //    return false;
            //}
            return true;

        }
        #endregion


    }
}
