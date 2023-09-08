using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data;

using Mongoose.Core.Configuration;
using Mongoose.IDO.Protocol;
using Mongoose.IDO;
using Mongoose.Core;
using System.Globalization;

namespace InforCollect.ERP.SL.ICSLShopFloorTrans
{
    /// <summary>
    /// Utility class for Shopfloor module/transaction.  The derived class contains methods unique to the shopfloor module.
    /// </summary>
    /// <remarks>
    /// Created: 2014/01/08     By:Jason Hammock
    /// </remarks>
    public class ShopFloorUtilities : ICSLCommonLibrary
    {

        public new LoadCollectionResponseData employeeResponseData = null;
        public LoadCollectionResponseData workcenterResponseData = null;
        public PropertyList queryPropertyList = null;


        public string GetJobDetails(string job, string suffix, string item, string whse, string uom)
        {
            string errorMessage;
            object[] inputValues = new object[]{
                                                job,
                                                suffix,
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                ""};

            InvokeResponseData invokeResponseData = InvokeIDO("SLJobitems", "GetJobDetailSp", inputValues);
            if (!invokeResponseData.ReturnValue.Equals("0"))
            {
                errorMessage = invokeResponseData.Parameters.ElementAt(7).ToString();
                //return false;
                return errorMessage;
            }

            if (!(item.Equals(invokeResponseData.Parameters.ElementAt(4).ToString())))
            {
                IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                substitutorDictionary.Add("item", item);
                substitutorDictionary.Add("sub1", invokeResponseData.Parameters.ElementAt(4).ToString());
                errorMessage = "Input Item  {item} Not Matching Job Item {sub1} ";
                return errorMessage;
            }

            if (!(whse.Equals(invokeResponseData.Parameters.ElementAt(6).ToString())))
            {
                IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                substitutorDictionary.Add("whse", whse);
                substitutorDictionary.Add("sub1", invokeResponseData.Parameters.ElementAt(6).ToString());
                errorMessage = "Input Whse {whse} Not Matching Job Item {sub1}";
                return errorMessage;
            }

            // formattedJob = invokeResponseData.Parameters.ElementAt(3).ToString();
            return "";
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
            return this.ExcuteQueryRequest(requestData);
        }

        public LoadCollectionResponseData GetJobDetails(string job, string suffix)
        {
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLJobs";
            requestData.PropertyList.SetProperties("Job, Suffix, Item,ItemDescription,ItemLotTracked,ItemSerialTracked,Whse,DerOrderQty, DerQtyRemaining, QtyComplete,QtyReleased,QtyScrapped,DerNewStatus,Stat");
            string filterString = "Job = '" + job + "'";

            if (suffix != null && !(suffix.Trim().Equals("")))
            {
                filterString += " and Suffix ='" + suffix + "'";
            }

            requestData.Filter = filterString;
            requestData.RecordCap = 0;
            requestData.OrderBy = "Job";

            LoadCollectionResponseData responseData = ExcuteQueryRequest(requestData);
            return responseData;
        }
        /*   Code Moved to Common Library
        public bool ValidateEmployee(string employee, out string errorMessage)
        {
            errorMessage = "";
            employeeResponseData = GetEmployeeDetails(employee);
            if (employeeResponseData.Items.Count == 0)
            {
                errorMessage = "Employee Details Not Found";
                return false;

            }
            return true;
        }
        public LoadCollectionResponseData GetEmployeeDetails(string employee)
        {            
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLEmployees";
            //added fields: RegRate, OtRate, DtRate, MfgRegRate, MfgOtRate, MfgDtRate for calculating overtime and double time
            requestData.PropertyList.SetProperties("EmpNum,Name,Lname,ADate, TermDate, Shift, LunchAuto, IndCode, RegRate, OtRate, DtRate, MfgRegRate, MfgOtRate, MfgDtRate");
            string filterString = "EmpNum = '" + employee + "'";
            requestData.Filter = filterString;
            requestData.RecordCap = 1;
            requestData.OrderBy = "EmpNum";
            return ExcuteQueryRequest(requestData);
        }
        */
        public bool ValidateWorkCenter(string workCenter, out string errorMessage)
        {
            errorMessage = "";
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLWcs";
            requestData.PropertyList.SetProperties("Wc, Description");
            string filterString = "Wc = '" + workCenter + "'";

            requestData.Filter = filterString;
            requestData.RecordCap = 1;
            requestData.OrderBy = "Wc";

            workcenterResponseData = ExcuteQueryRequest(requestData);

            if (workcenterResponseData == null || workcenterResponseData.Items.Count == 0)
            {
                errorMessage = "Work Center Invalid";
                return false;
            }
            return true;
        }


        public string FormatJobString(string job)
        {
            try
            {
                int IJob = Convert.ToInt32(job, CultureInfo.InvariantCulture); // FTDEV-9247
                PropertyInfo JobPropertyInfo = GetPropertyInfo("SLJobs", "Job");
                job = padSpaces(job, JobPropertyInfo.DataLength, true);
            }
            catch (Exception)
            {
            }
            return job;
        }
        public PropertyInfo GetPropertyInfo(string idoName, string propertyName)
        {
            GetPropertyInfoResponseData propertyResponseData = this.Context.Commands.GetPropertyInfo(idoName);
            if (propertyResponseData != null)
            {
                PropertyInfo propertyInfo = propertyResponseData.Properties.ElementAt(propertyResponseData.Properties.IndexOf(propertyName));
                if (propertyInfo != null)
                {
                    return propertyInfo;
                }
            }
            return null;
        }
        public LoadCollectionResponseData ValidateJob(string job, string suffix)
        {
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLJobs";
            requestData.PropertyList.SetProperties("Job, Suffix, Item,ItemDescription,ItemLotTracked,ItemSerialTracked,Whse,QtyComplete,QtyReleased,QtyScrapped,DerNewStatus,Stat,RefJob,CoProductMix,Revision");
            string filterString = "Job = '" + job + "' and Suffix ='" + suffix + "'";

            requestData.Filter = filterString;
            requestData.RecordCap = 1;
            requestData.OrderBy = "Job";
            LoadCollectionResponseData responseData = ExcuteQueryRequest(requestData);
            return responseData;

        }
        public bool ValidateJobOper(string job, string suffix, string oper)
        {
            string PropertiesList = "";
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLJobRoutes";
            PropertiesList = PropertiesList + "Job,Suffix,ItmItem,ItmDescription,QtyComplete,QtyMoved,QtyScrapped,QtyReceived, ";
            PropertiesList = PropertiesList + "PsStat,Type,Wc,WcDescription,Complete";
            requestData.PropertyList.SetProperties(PropertiesList);
            string filterString = "Job = '" + job + "' and Suffix = '" + suffix + "'";
            filterString += " and OperNum ='" + oper + "' ";

            requestData.Filter = filterString;
            requestData.RecordCap = 1;
            requestData.OrderBy = "Job,Suffix,OperNum";

            LoadCollectionResponseData responseData = ExcuteQueryRequest(requestData);

            if (responseData == null || responseData.Items.Count == 0)
            {
                return false;
            }
            return true;
        }

        public LoadCollectionResponseData ValidateIndirectCode(string indirectCode)
        {
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLIndcodes";
            requestData.PropertyList.SetProperties("IndCode,Description");
            string filterString = "IndCode = '" + indirectCode + "'";
            requestData.Filter = filterString;
            requestData.RecordCap = 1;
            requestData.OrderBy = "IndCode";
            return ExcuteQueryRequest(requestData);
        }

        public bool ValidateWorkCenter(string workCenter)
        {
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLWcs";
            requestData.PropertyList.SetProperties("Wc, Description");
            string filterString = "Wc = '" + workCenter + "'";

            requestData.Filter = filterString;
            requestData.RecordCap = 1;
            requestData.OrderBy = "Wc";

            workcenterResponseData = ExcuteQueryRequest(requestData);

            if (workcenterResponseData == null || workcenterResponseData.Items.Count == 0)
            {
                return false;
            }
            return true;
        }
        public InvokeResponseData JobtranJobValidSp(string Type, string Job, string Suffix, string OperNum, out string ErrorMessage)
        {
            ErrorMessage = "";
            object[] inputValues = null;
            //int paramcount = 0;
            //paramcount = GetIDOMethodParameterCount("SLJobTrans", "JobtranJobValidSp");
            //Console.WriteLine("ValidateJob: JobtranJobValidSp paramcount = " + paramcount);
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
                //case 46:
                //    #region 46 values
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
                //                                "", // new input for 9.00.00 JH:20130809
                //                                "", // new input for 9.00.00 JH:20130809
                //                                "", // new input for 9.00.00 JH:20130809
                //                                ""  // new input for 9.00.00 JH:20130809
                //                                };
                //    break;
                //#endregion
                //case 42:
                //    #region 42 values
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
                //                                "" // new field for 8.03.10
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
                //                                };
                //    #endregion
                //    break;
           // }


            InvokeResponseData responseData = InvokeIDO("SLJobTrans", "JobtranJobValidSp", inputValues);
            if (!responseData.ReturnValue.Equals("0"))
            {
                ErrorMessage = responseData.Parameters.ElementAt(32).ToString();
            }
            return responseData;
        }

        public InvokeResponseData JobtranOperNumValidSp(string Type, string Job, string Suffix, string OperNum, string workcenter, out string ErrorMessage)
        {
            ErrorMessage = "";
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
                ErrorMessage = responseData.Parameters.ElementAt(17).ToString();
            }
            return responseData;
        }
        public string GetEmployeeIndirectCode(String employee)
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


        public InvokeResponseData PSVal10Sp(string item, string cmpl)
        {
            object[] inputParams = new object[]{
                                                item,
                                                cmpl,
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                ""
                                                };

            InvokeResponseData responseData = InvokeIDO("SLPs", "PSVal10Sp", inputParams);
            return responseData;
        }
        public InvokeResponseData PSVal3Sp(string prodschedule, string item, string cmpl, string whse, string psitemjob, string psitemsuffix)
        {
            object[] inputParams = new object[]{
                                                prodschedule,
                                                item,
                                                cmpl,
                                                whse,
                                                "",
                                                "",
                                                psitemjob,
                                                psitemsuffix,
                                                ""
                                                };

            InvokeResponseData responseData = InvokeIDO("SLPs", "PSVal3Sp", inputParams);
            return responseData;
        }

        public InvokeResponseData PSVal4Sp(string prodschedule, string item, string wc, string cmpl)
        {
            object[] inputParams = null;
            int paramcount = 0;
            paramcount = GetIDOMethodParameterCount("SLPs", "PSVal4Sp");
            switch (paramcount)
            {
                case 7:
                    inputParams = new object[]{
                                                prodschedule,
                                                item,
                                                wc,
                                                cmpl,
                                                "",
                                                "",
                                                "0"
                                                };
                    break;
                default:
                    inputParams = new object[]{
                                                prodschedule,
                                                item,
                                                wc,
                                                cmpl,
                                                "",
                                                ""
                                                };
                    break;
            }
            InvokeResponseData responseData = InvokeIDO("SLPs", "PSVal4Sp", inputParams);
            return responseData;
        }

        public InvokeResponseData PSVal5Sp(string prodschedule, string item, string operation, string cmpl, string Wc)
        {
            object[] inputParams = null;
            int paramcount = 0;
            paramcount = GetIDOMethodParameterCount("SLPs", "PSVal5Sp");
            switch(paramcount)
            {
                case 12:
                    inputParams = new object[]{
                                                prodschedule,
                                                item,
                                                operation,
                                                cmpl,
                                                Wc,
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "0"
                                                };
                    break;
                default:
                    inputParams = new object[]{
                                                prodschedule,
                                                item,
                                                operation,
                                                cmpl,
                                                Wc,
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                ""
                                                };
                    break;
            }
            InvokeResponseData responseData = InvokeIDO("SLPs", "PSVal5Sp", inputParams);
            return responseData;
        }

        public InvokeResponseData PsQtyValidSp(string qty, string item, string cmpl, string scrpFlag)
        {
            object[] inputParams = new object[]{
                                                qty,
                                                item,
                                                cmpl,
                                                scrpFlag,
                                                ""
                                                };

            InvokeResponseData responseData = InvokeIDO("SLPs", "PsQtyValidSp", inputParams);
            return responseData;
        }

        public LoadCollectionResponseData GetJobMatlsByContainer(string site, string job, string suffix, string item, string whse, string containerNum, out string InfoBar)
        {
            LoadCollectionRequestData requestDataNew = new LoadCollectionRequestData();
            InfoBar = "";
            requestDataNew.IDOName = "SLJobmatls";
            requestDataNew.PropertyList.SetProperties("JobItem,UbSelect,OperNum,Sequence,Item,Description,DerQtyConv,UM,DerLoc,DerLot,DerCostCode,Job,Suffix,UbImportDocId,MatlCostConv,LbrCostConv,FovhdCostConv,VovhdCostConv,OutCostConv,UbAcct,DerQtyOnHandConv,DerReqQtyConv,DerQtyIssuedConv,DerPlanCostConv,ACost,UbAcctUnit1,UbAcctUnit2,UbAcctUnit3,UbAcctUnit4,UbTargetQty,UbSelectedQty,UbGenerateQty,UbRangeQty,OrdType,Backflush,DerWC,ScrapFact,MatlQty,MatlQtyConv,DerItemExist,DerReqQty,QtyIssued,DerQty,DerItemUMConvFactor,MatlCost,LbrCost,FovhdCost,VovhdCost,OutCost,DerPlanCost,DerItemLotTracked,DerItemSerialTracked,DerItemIssueBy,UbDelTempSer,UbWhse,RowPointer,DerQtyOnHand,Units,QtyReleased,Cost,CostConv,DerItemUM,AMatlCost,ALbrCost,AFovhdCost,AVovhdCost,AOutCost,ItmMatlCost,ItmLbrCost,ItmFovhdCost,ItmVovhdCost,ItmOutCost,DerPoVendNum,RefType,RefNum,UbAcctAccessUnit1,UbAcctAccessUnit2,UbAcctAccessUnit3,UbAcctAccessUnit4,UbTransDate,RefLineSuf,RefRelease,DerByProduct,DerItemTaxFreeMatl,WcOutside,RecordDate,UbStartingSerial,UbEndingSerial");
            requestDataNew.Filter = "Job = '" + job + "' and Suffix = '" + suffix + "'";
            requestDataNew.RecordCap = -1;
            requestDataNew.OrderBy = "Job";
            CustomLoadMethod customLoadMethod = new CustomLoadMethod();
            customLoadMethod.Name = "GetJobMatlsSp";
            customLoadMethod.Parameters.Add(site);
            customLoadMethod.Parameters.Add(job);
            customLoadMethod.Parameters.Add(suffix);
            customLoadMethod.Parameters.Add("");
            customLoadMethod.Parameters.Add("");
            customLoadMethod.Parameters.Add(item);
            customLoadMethod.Parameters.Add("");
            customLoadMethod.Parameters.Add("1");
            customLoadMethod.Parameters.Add(whse);
            customLoadMethod.Parameters.Add("0");
            customLoadMethod.Parameters.Add(containerNum);                //container num
            customLoadMethod.Parameters.Add("");                //inforBar
            requestDataNew.CustomLoadMethod = customLoadMethod;

            LoadCollectionResponseData responseDataNew = ExcuteQueryRequest(requestDataNew);
            if (responseDataNew == null || responseDataNew.Items.Count > 0)
            {


            }


            return responseDataNew;
        }

        /*   Code Moved to Common Library
       public bool ValidateQtyForRcvIntoContainerSp(string item,string whse,string loc,string lot,string site,out string errorMessage)
       {
           errorMessage = "";
           object[] inputValues = new object[]{
                                               item,
                                               whse,
                                               loc,
                                               lot,
                                               site,
                                               ""
                                               };

           InvokeResponseData invokeResponseData = this.InvokeIDO("SLContainers", "ValidateQtyForRcvIntoContainerSp", inputValues);
           if (!(invokeResponseData.ReturnValue.Equals("0")))
           {
               errorMessage = invokeResponseData.Parameters.ElementAt(5).ToString();
               return false;
           }
           return true;
       }

       public bool ValidateContainerExist(string ContainerNum, string Whse, String Loc, bool containerLocMismatch, out string ErrorMessage)
       {
           ErrorMessage = "";

           LoadCollectionRequestData requestData = new LoadCollectionRequestData();
           requestData.IDOName = "SLContainers";
           requestData.PropertyList.SetProperties("ContainerNum,Whse,Loc");
           requestData.RecordCap = 1;

           //requestData.Filter = "Whse = '" + Whse + "' AND Loc = '" + Loc + "' AND CHARINDEX(RefType, ISNULL('','IKJO'))>0 AND ContainerNum = '" + ContainerNum + "'";
           requestData.Filter = "ContainerNum = '" + ContainerNum + "'";
           LoadCollectionResponseData responseData = ExcuteQueryRequest(requestData);

           if (responseData.Items.Count == 0)
           {
               // Container does not exists   
               return false;
           }
           else
           {
               // Container exists in the system
               if ((!(Whse.Trim().Equals(responseData[0, "Whse"].ToString())) || (!Loc.Trim().Equals(responseData[0, "Loc"].ToString()))))
               {
                   containerLocMismatch = true;
               }
               else
               {
                   containerLocMismatch = false;
               }
               return true;
           }

       }
       public bool PerformCreateContainer(string containerNum,string whse,string loc,out string errorMessage)
       {
           errorMessage = "";
           object[] inputValues = new object[]{
                                               containerNum,
                                               whse,
                                               loc,
                                               ""
                                               };

           InvokeResponseData invokeResponseData = this.InvokeIDO("SLContainers", "ContainerAddSp", inputValues);
           if (!(invokeResponseData.ReturnValue.Equals("0")))
           {
               errorMessage = invokeResponseData.Parameters.ElementAt(3).ToString();
               return false;
           }

           return true;
       }
         * /
       /*
        SerialLoadSpByContainer("T", item, whse, loc, lot, 
                                                                 doNum, doLine, trnNum, trnLine, rcvdNum,
                                                                 refNum, refLine,refRelease, site, importDocID,
                                                                 preAssignSerials, containerNum, startingSer, endingSer )
         
        */
        public LoadCollectionResponseData SerialLoadSpByContainer(string transType, string item, string whse, string loc, string lot,
                                                                  string doNum, string doLine, string trnNum, string trnLine, string rcvdNum,
                                                                  string refNum, string refLine, string refRelease, string site, string importDocID,
                                                                  string preAssignSerials, string containerNum, string startingSer, string endingSer, out string errorMessage)
        {
            errorMessage = "";
            LoadCollectionRequestData requestDataNew = new LoadCollectionRequestData();

            requestDataNew.IDOName = "SLSerials";
            requestDataNew.PropertyList.SetProperties("SerNum,UbRefStr,UbSelect");

            requestDataNew.OrderBy = "SerNum";
            CustomLoadMethod customLoadMethod = new CustomLoadMethod();
            customLoadMethod.Name = "SerialLoadSp";
            customLoadMethod.Parameters.Add("");
            customLoadMethod.Parameters.Add(transType);
            customLoadMethod.Parameters.Add("");
            customLoadMethod.Parameters.Add("");
            customLoadMethod.Parameters.Add("0");
            customLoadMethod.Parameters.Add("");
            customLoadMethod.Parameters.Add(item);
            customLoadMethod.Parameters.Add(whse);
            customLoadMethod.Parameters.Add(loc);
            customLoadMethod.Parameters.Add(lot);
            customLoadMethod.Parameters.Add(doNum);
            customLoadMethod.Parameters.Add(doLine);
            customLoadMethod.Parameters.Add(trnNum);
            customLoadMethod.Parameters.Add(trnLine);
            customLoadMethod.Parameters.Add(rcvdNum);
            customLoadMethod.Parameters.Add(refNum);
            customLoadMethod.Parameters.Add(refLine);
            customLoadMethod.Parameters.Add(refRelease);
            customLoadMethod.Parameters.Add(site);
            customLoadMethod.Parameters.Add(importDocID);
            customLoadMethod.Parameters.Add(preAssignSerials);
            customLoadMethod.Parameters.Add(containerNum);
            customLoadMethod.Parameters.Add(startingSer);
            customLoadMethod.Parameters.Add(endingSer);
            customLoadMethod.Parameters.Add("");
            requestDataNew.CustomLoadMethod = customLoadMethod;

            LoadCollectionResponseData responseDataNew = ExcuteQueryRequest(requestDataNew);
            if (responseDataNew == null || responseDataNew.Items.Count == 0)
            {
                errorMessage = "Serials Not found";

            }


            return responseDataNew;
        }


        public List<string> GetBackFlushLotList(string SessionID)
        {
            List<string> InvRecordList = new List<string>(1);

            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "ICSLTmpMatlTrans";
            requestData.PropertyList.SetProperties("Item,Qty,Loc,Lot,Wc,JobLot,JobSerNum, RefNum, RefLineSuf,RefRelease,Backflush,ProcessId");
            requestData.Filter = "ProcessId = '" + SessionID + "'";
            requestData.RecordCap = -1;
            requestData.OrderBy = "RefLineSuf";  // RefLineSuf field being used for job sequence number
            LoadCollectionResponseData responseData = ExcuteQueryRequest(requestData);

            for (int i = 0; i < responseData.Items.Count; i++)
            {
                InvRecordList.Add(responseData[i, "Item"].ToString());
                InvRecordList.Add(responseData[i, "Qty"].ToString());
                InvRecordList.Add(responseData[i, "Loc"].ToString());
                InvRecordList.Add(responseData[i, "Lot"].ToString());
                InvRecordList.Add(responseData[i, "Wc"].ToString());
                InvRecordList.Add(responseData[i, "JobLot"].ToString());
                InvRecordList.Add(responseData[i, "JobSerNum"].ToString());
                InvRecordList.Add(responseData[i, "RefLineSuf"].ToString());
                InvRecordList.Add(responseData[i, "Backflush"].ToString());
                InvRecordList.Add(responseData[i, "Item"].ToString());
            }

            return InvRecordList;


        }
        public new void Initialize()
        {
            //    errorMessage = "";
            queryPropertyList = null;
        }

        public LoadCollectionResponseData GetPartnerDetails(string partnerid)
        {
            LoadCollectionRequestData LoadRequestData = new LoadCollectionRequestData();

            LoadRequestData.IDOName = "FSPartners";
            LoadRequestData.PropertyList.SetProperties("PartnerId");
            LoadRequestData.Filter = "PartnerId='" + partnerid + "' and Active='" + 1 + "'";
            LoadRequestData.RecordCap = -1;
            LoadRequestData.OrderBy = "PartnerId";

            return ExcuteQueryRequest(LoadRequestData);
        }

        public LoadCollectionResponseData GetSRODetails(string SroNum)
        {
            LoadCollectionRequestData LoadRequestData = new LoadCollectionRequestData();
            LoadRequestData.IDOName = "FSSROs";
            LoadRequestData.PropertyList.SetProperties("SroNum");
            LoadRequestData.Filter = "SroNum='" + SroNum + "'";
            LoadRequestData.RecordCap = -1;
            LoadRequestData.OrderBy = "SroNum";

            return ExcuteQueryRequest(LoadRequestData);
        }

        public LoadCollectionResponseData GetSROLineDetails(string SroNum, string SroLine)
        {
            LoadCollectionRequestData LoadRequestData = new LoadCollectionRequestData();
            LoadRequestData.IDOName = "FSSROLines";
            LoadRequestData.PropertyList.SetProperties("SroNum,SroLine,Stat");
            LoadRequestData.Filter = "SroNum='" + SroNum + "' and SroLine='" + SroLine + "'";
            LoadRequestData.RecordCap = -1;
            LoadRequestData.OrderBy = "SroLine";

            return ExcuteQueryRequest(LoadRequestData);
        }

        public LoadCollectionResponseData GetSROOperDetails(string SroNum, string SroLine, string SroOper)
        {
            LoadCollectionRequestData LoadRequestData = new LoadCollectionRequestData();
            LoadRequestData.IDOName = "FSSROOpers";
            LoadRequestData.PropertyList.SetProperties("SroOper,SroNum,SroLine,Stat");
            LoadRequestData.Filter = "SroNum='" + SroNum + "' and SroLine='" + SroLine + "' and SroOper='" + SroOper + "'";
            LoadRequestData.RecordCap = -1;
            LoadRequestData.OrderBy = "SroOper";

            return ExcuteQueryRequest(LoadRequestData);
        }

        public LoadCollectionResponseData GetSROItemDetails(string item)
        {
            LoadCollectionRequestData LoadRequestData = new LoadCollectionRequestData();
            LoadRequestData.IDOName = "SLCoitems";
            LoadRequestData.PropertyList.SetProperties("Item");
            LoadRequestData.Filter = "Item='" + item + "'";
            LoadRequestData.RecordCap = -1;
            LoadRequestData.OrderBy = "Item";

            return ExcuteQueryRequest(LoadRequestData);
        }

        public LoadCollectionResponseData GetSROCustItemDetails(string item, string custItem)
        {
            LoadCollectionRequestData LoadRequestData = new LoadCollectionRequestData();
            LoadRequestData.IDOName = "SLCoBlns";
            LoadRequestData.PropertyList.SetProperties("Item,CustItem");
            LoadRequestData.Filter = "Item='" + item + "' and CustItem='" + custItem + "'";
            LoadRequestData.RecordCap = -1;
            LoadRequestData.OrderBy = "CustItem";

            return ExcuteQueryRequest(LoadRequestData);
        }

        public LoadCollectionResponseData GetSROItemLocDetails(string item, string whse, string loc)
        {
            LoadCollectionRequestData LoadRequestData = new LoadCollectionRequestData();
            LoadRequestData.IDOName = "SLItemLocs";
            LoadRequestData.PropertyList.SetProperties("Item,Whse,Loc");
            LoadRequestData.Filter = "Item='" + item + "' and Whse='" + whse + "' and Loc='" + loc + "'";
            LoadRequestData.RecordCap = -1;
            LoadRequestData.OrderBy = "Loc";

            return ExcuteQueryRequest(LoadRequestData);
        }



        public bool ValidateSROLaborDC(string partnerid, string WorkCode, string SroNum, string SroLine, string SroOper, string stopTime, ref string unitCost, ref string unitRate)
        {
            object[] inputValues = new object[]{"Oper",
                                                partnerid,
                                                WorkCode,
                                                stopTime,
                                                SroNum,
                                                SroLine,
                                                SroOper,
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "" };

            InvokeResponseData invokeResponseData = InvokeIDO("FSP.FSSROLabors", "SSSFSSROLaborDCValidSp", inputValues);
            if (!invokeResponseData.ReturnValue.Equals("0"))
            {
                unitCost = "0";
                unitRate = "0";
                return false;
            }

            unitCost = invokeResponseData.Parameters.ElementAt(11).ToString();
            unitRate = invokeResponseData.Parameters.ElementAt(12).ToString();

            return true;
        }

        public bool ValidateSRoItemLot(string whse, string item, string loc, string lot, ref string errorMessage)
        {
            string infobar = "";
            object[] LotCheckInputValues = new object[] { whse, item, loc, lot, "ISS", "0", "", "", "", "", "", infobar, 0, "" };
            InvokeResponseData invokeResponseDataStep = this.Context.Commands.Invoke("SLTrnacts", "SvallotSp", LotCheckInputValues);
            if (!(invokeResponseDataStep.ReturnValue.Equals("0")))
            {
                errorMessage = invokeResponseDataStep.Parameters.ElementAt(11).ToString();
                return false;
            }

            return true;
        }




        public LoadCollectionResponseData GetProjectTaskDetails(string ProjNum, string Task)
        {
            LoadCollectionRequestData LoadRequestData = new LoadCollectionRequestData();
            LoadRequestData.IDOName = "SLProjTasks";
            LoadRequestData.PropertyList.SetProperties("ProjNum,TaskNum");
            LoadRequestData.Filter = "Stat='A' AND ProjNum='" + ProjNum + "' AND TaskNum='" + Task + "'";
            LoadRequestData.RecordCap = -1;
            LoadRequestData.OrderBy = "ProjNum";

            return ExcuteQueryRequest(LoadRequestData);
        }



        public LoadCollectionResponseData GetProjectDetails(string ProjNum)
        {
            LoadCollectionRequestData LoadRequestData = new LoadCollectionRequestData();
            LoadRequestData.IDOName = "SLProjs";
            LoadRequestData.PropertyList.SetProperties("ProjNum");
            LoadRequestData.Filter = "Stat='A' AND ProjNum='" + ProjNum + "'";
            LoadRequestData.RecordCap = -1;
            LoadRequestData.OrderBy = "ProjNum";

            return ExcuteQueryRequest(LoadRequestData);
        }
        public bool IsStringContainsNumericValue(string Value)
        {
            bool isNumeric = false;
            foreach (char c in Value)
            {
                if (Char.IsNumber(c))
                {
                    isNumeric = true;
                    break;
                }
            }
            return isNumeric;
        }
        public bool IsStringStartsWithNumEndsWithNonNumeric(string Value)
        {
            bool isNumeric = false;
            if (Char.IsNumber(Convert.ToChar(Value.Substring(0, 1))) == false)
            {
                return false;
            }
            foreach (char c in Value)
            {
                if (Char.IsNumber(c) == false)
                {
                    isNumeric = true;
                    break;
                }
            }
            return isNumeric;

        }

    }
}