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
    public class ProjectLaborUpdate : ShopFloorUtilities
    {
        #region InputVariables

        //Input Variables.

        private string employee;
        private string shift;
        private string payType;
        private string project;
        private string task;
        private string costCode;
        private string transDate;           //yyyyMMdd
        private string totalHours;
        private bool autoProcessHours = false;
        
        #endregion

        #region localvariables
        private InvokeResponseData projectLabResponseData = null;
        private InvokeResponseData employeeProjectResponseData = null;
        private string errorMessage = "";
        #endregion

       
        public ProjectLaborUpdate(string employee, string shift, string payType, string project, string task, string costCode, string transDate, string totalHours, bool autoProcessHours)
        {
            this.employee = employee;
            this.shift = shift;
            this.payType = payType;
            this.project = project;
            this.task = task;
            this.costCode = costCode;
            this.transDate = transDate;
            this.totalHours = totalHours;
            this.autoProcessHours = autoProcessHours;
        }

        public void initialize()
        {
            this.Initialize();

            employee = "";
            shift = "";
            payType = "";
            project = "";
            task = "";
            costCode = "";
            transDate = "";
            totalHours = "";
            autoProcessHours = false;

            //local variables
            employeeResponseData = null;
            projectLabResponseData = null;
            employeeProjectResponseData = null;
            errorMessage = "";
        }
        
        public bool formatInputs()
        {
            employee = formatDataByIDOAndPropertyName("SLEmployees", "EmpNum", employee);
            if ((employee == null || employee.Trim().Equals("")))
            {
                errorMessage = "employee input mandatory";
                return false;
            }

            if (shift == null || shift.Trim().Equals(""))
            {
                errorMessage = "shift input mandatory";
                return false;
            }

            if (payType == null || payType.Trim().Equals(""))
            {
                errorMessage = "payType input mandatory";
                return false;
            }

            if (!(payType.Equals("R") || payType.Equals("O") || payType.Equals("D")))
            {
                errorMessage = "payType Should be one of R/O/D";
                return false;
            }           
            project = formatDataByIDOAndPropertyName("SLProjLabrs", "ProjNum", project);
            if (string.IsNullOrEmpty(project))
            {
                errorMessage = "project input mandatory";
                return false;
            }
            task = formatDataByIDOAndPropertyName("SLProjTasks", "TaskNum", task);
            if (task == null || task.Trim().Equals(""))
            {
                errorMessage = "task input mandatory";
                return false;
            }

            if (costCode == null || costCode.Trim().Equals(""))
            {
                errorMessage = "costCode input mandatory";
                return false;
            }

            if (transDate == null || transDate.Trim().Equals(""))
            {
                errorMessage = "transDate input mandatory";
                return false;
            }

            if (totalHours == null || totalHours.Trim().Equals(""))
            {
                errorMessage = "totalHours input mandatory";
                return false;
            }

            return true;
        }

        private bool validateInputs()
        {
            if (ValidateEmployee(employee,out errorMessage) == false)
            {
                return false;
            }

            if (ValidateProjectEmployee(employee, out employeeProjectResponseData) == false)
            {
                return false;
            }

            if (ValidateShift(shift) == false)
            {
                return false;
            }

            //Date Check

            if (TransDateCheck(transDate) == false)
            {
                return false;
            }

            //project labor rate

            if (ProjLabrInitialRateSp(out projectLabResponseData) == false)
            {
                return false;
            }

            //project validation
            project = formatDataByIDOAndPropertyName("SLProjLabrs", "ProjNum", project);
            if (ValidateProject(project) == false)
            {
                return false;
            }

            //task validation
            if (ValidateTask(project, task) == false)
            {
                return false;
            }

            if (ValidateCostCode(costCode) == false)
            {
                return false;
            }
            
            return true;
        }

        public int PerformUpdate(out string infobar)
        {
            string transactionID = "";

            //1 Format Inputs
            if (formatInputs() == false)
            {
                infobar = errorMessage;
                return 16;
            }
            //2 validate Inputs
            if (validateInputs() == false)
            {
                infobar = errorMessage;
                return 16;
            }
            //3 Updates
            if (UpdateProjectLaborHours(out transactionID) == false)
            {
                infobar = errorMessage;
                return 16;
            }
            if (autoProcessHours)
            {
                if (!performPosting(out errorMessage))
                {
                    infobar = errorMessage;
                    return 16;
                }
            }
            infobar = "";
            return 0;
        }

        #region Private Methods
        private bool performPosting(out string errorString)
        {
            string GUID = "";
            if (GenerateGUID(ref GUID, out errorMessage) == false)
            {
                errorMessage = "Problem generating GUID";
            }
            errorString = "";
            LoadCollectionResponseData projlabResponseData = null;
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLProjLabrs";
            requestData.PropertyList.SetProperties("EmpNum,EmpName,TransDate,ProjNum,TaskNum");
            CustomLoadMethod customLoadMethod = new CustomLoadMethod();
            customLoadMethod.Name = "CLM_PostProjectLaborTransSp";
            InvokeParameterList parameterList = new InvokeParameterList();
            parameterList.Add(project);
            parameterList.Add(project);
            parameterList.Add(transDate);
            parameterList.Add(transDate);
            parameterList.Add(employee);
            parameterList.Add(employee);
            parameterList.Add("");
            parameterList.Add("");
            parameterList.Add(GUID);
            customLoadMethod.Parameters = parameterList;
            requestData.CustomLoadMethod = customLoadMethod;
            requestData.RecordCap = -1;
            projlabResponseData = ExcuteQueryRequest(requestData);


            object[] inputValues = new object[]{
                                                project,
                                                project,
                                                transDate,
                                                transDate,
                                                employee,
                                                employee,
                                                "",
                                                "",
                                                "",
                                                GUID
                                                };
            try
            {
                InvokeResponseData responseData1 = InvokeIDO("SL.SLProjLabrs", "ProjlabrPostSp", inputValues);
                if (!responseData1.ReturnValue.Equals("0"))
                {
                    errorMessage = responseData1.Parameters.ElementAt(6).ToString();
                    errorString = errorMessage;
                    return false;
                }
            }
            catch (Exception e)
            {
                errorMessage = e.Message.ToString();
                errorString = errorMessage;
                return false;
            }
            return true;

        }
        private bool ValidateEmployee(string employee)
        {
            employeeResponseData = GetEmployeeDetails(employee);
            if (employeeResponseData.Items.Count == 0)
            {
                errorMessage = "Employee Details Not Found";
                return false;
            }
            return true;
        }

        private bool ValidateShift(string shift)
        {
            LoadCollectionResponseData shiftResponseData = GetShiftDetails(shift); //shift lunch time records                        
            if ((shiftResponseData == null) || (shiftResponseData.Items.Count == 0))
            {//no shift records found is an error
                errorMessage = "Shift record not found. Please make sure the user is on a vaild shift.";
                //Console.WriteLine("Shift record not found."); //is a critical error.
                return false;
            }
            return true;
        }

        private bool ValidateProjectEmployee(string employee, out InvokeResponseData employeeProjectResponseData)
        {
            employeeProjectResponseData = null;
            object[] inputValues = new object[]{//6+
                                                employee,
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                ""
                                                };
            employeeProjectResponseData = InvokeIDO("SLProjLabrs", "ProjLabrEmpNumValidSp", inputValues);
            if (!employeeProjectResponseData.ReturnValue.Equals("0"))
            {
                errorMessage = employeeProjectResponseData.Parameters.ElementAt(4).ToString();
                if (!employeeProjectResponseData.Parameters.ElementAt(5).ToString().Equals(""))
                {
                    errorMessage = employeeProjectResponseData.Parameters.ElementAt(5).ToString();
                }

                return false;
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

        private bool ProjLabrInitialRateSp(out InvokeResponseData projectLabResponseData)
        {

            projectLabResponseData = null;
            object[] inputValues = new object[]{//6+
                                                employee,
                                                payType,
                                                shift,
                                                transDate,
                                                "",
                                                "",
                                                ""
                                                };
            projectLabResponseData = InvokeIDO("SLProjLabrs", "ProjLabrInitialRateSp", inputValues);
            if (!projectLabResponseData.ReturnValue.Equals("0"))
            {
                errorMessage = projectLabResponseData.Parameters.ElementAt(6).ToString();

                return false;
            }
            return true;
        }

        private bool ValidateProject(string project)
        {
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLProjs";
            requestData.PropertyList.SetProperties("ProjNum,ProjDesc");
            string filterString = "ProjNum = '" + project + "'";
            requestData.Filter = filterString;
            requestData.RecordCap = 1;
            requestData.OrderBy = "ProjNum";
            LoadCollectionResponseData responseData = this.Context.Commands.LoadCollection(requestData);

            if (responseData.Items.Count == 0)
            {
                errorMessage = "Project Details Not Found";
                return false;
            }
            return true;
        }

        private bool ValidateTask(string project, string task)
        {
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLProjTasks";
            requestData.PropertyList.SetProperties("TaskNum,TaskDesc,Stat");
            string filterString = "ProjNum = '" + project + "' and Stat='A' and TaskNum='" + task+"'";
            requestData.Filter = filterString;
            requestData.RecordCap = 1;
            requestData.OrderBy = "TaskNum";
            LoadCollectionResponseData responseData = this.Context.Commands.LoadCollection(requestData);

            if (responseData.Items.Count == 0)
            {
                errorMessage = "Task Details Not Found";
                return false;
            }
            return true;
        }

        private bool ValidateCostCode(string costcode)
        {
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLCostCodes";
            requestData.PropertyList.SetProperties("CostCode,CostDesc");
            string filterString = "CostCode = '" + costcode + "' ";
            requestData.Filter = filterString;
            requestData.RecordCap = 1;
            requestData.OrderBy = "CostCode";
            LoadCollectionResponseData responseData = this.Context.Commands.LoadCollection(requestData);

            if (responseData.Items.Count == 0)
            {
                errorMessage = "Task Details Not Found";
                return false;
            }
            return true;
        }

        private bool UpdateProjectLaborHours(out string transactionID)
        {
            transactionID = "";
            UpdateCollectionRequestData updateRequestData = new UpdateCollectionRequestData();

            updateRequestData.IDOName = "SLProjLabrs";
            updateRequestData.RefreshAfterUpdate = true;

            IDOUpdateItem updateItem = new IDOUpdateItem();
            updateItem.Action = UpdateAction.Insert;
            updateItem.Properties.Add("TransNum", "",false);
            updateItem.Properties.Add("NoteExistsFlag", "", false);
            updateItem.Properties.Add("RowPointer", "", false);
            updateItem.Properties.Add("InWorkflow", "", false);
            updateItem.Properties.Add("_ItemWarnings", "", false);

            updateItem.Properties.Add("EmpNum", employee);
            updateItem.Properties.Add("EmpName", employeeProjectResponseData.Parameters.ElementAt(1).ToString());
            updateItem.Properties.Add("Shift", shift);
            updateItem.Properties.Add("PayType", payType);
            updateItem.Properties.Add("ProjNum", project);
            updateItem.Properties.Add("ProjProjDesc", "");
            updateItem.Properties.Add("TaskNum", task);
            updateItem.Properties.Add("PrtTaskDesc", "");
            updateItem.Properties.Add("CostCode", costCode);
            updateItem.Properties.Add("CCCostDesc", "");
            updateItem.Properties.Add("TransDate", transDate);
            updateItem.Properties.Add("AHrs", this.totalHours);
            updateItem.Properties.Add("PrRate", projectLabResponseData.Parameters.ElementAt(4).ToString());
            updateItem.Properties.Add("ProjRate", projectLabResponseData.Parameters.ElementAt(5).ToString());
            updateItem.Properties.Add("DerTotAHrs", employeeProjectResponseData.Parameters.ElementAt(3).ToString());

            updateRequestData.Items.Add(updateItem);
            try
            {

                UpdateCollectionResponseData updateResponseData = this.Context.Commands.UpdateCollection(updateRequestData);
                //PropertyList propertyList = updateResponseData.Items.ElementAt(0).Properties;
                //foreach(Property

                //Console.WriteLine(updateResponseData.ToXml());
            }
            catch (Exception ee)
            {
                //Console.WriteLine(ee.Message);
                errorMessage = ee.Message;
                return false;
            }


            return true;
        }

        #endregion
    }
}
