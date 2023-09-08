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

namespace InforCollect.ERP.SL
{

    public class ICSLCommonLibrary : ICSLBase
    {
        #region Local Variables
        public LoadCollectionResponseData employeeResponseData = null;
        #endregion
        #region ERP Parameters

        /// Infor methods/class used to read the ERP parameters used by Collect and retain the values for use in other IC classes.                 
        /// The parameters are not dynamically read.   Meaning if the parameter is read then changed in the ERP the 
        ///   ReadERPParameters method will need to be called.  Also this class does not have a way to know if the parameter 
        ///   is changed in the ERP.  However Parameters are usually not changed so one read during a update should be ok
        /// As we determine parameters that need to be used by collect we should add them to this class.  Preferably in 
        ///   side the ERP Parameters region 
        /// These parameters are in side the Common ibrary because they need to read values from the ERP and must have access to 
        ///   a valid contaxt object.  Putting them into another class is less clear and can potentially lead to inhertiance problems. JH: 20131212

        bool _paramHaveBeenRead = false;
        public bool ParamHaveBeenRead
        {
            get { return _paramHaveBeenRead; }
        }
        public bool ParamTrack_tax_free_imports
        {
            get;
            set;
        }

        public void ReadERPParameters()
        {
            _paramHaveBeenRead = true;
            ParamTrack_tax_free_imports = GetBool(GetInvParamValue("TrackTaxFreeImports"));
        }
        #endregion


        #region validation methods
        //public bool validWhseItemRecordExists(string whse, string item, bool allowIfCycleCountExists)
        //{
        //    //Initialize();
        //    object[] itemwhseDetails = new object[] { item,
        //                                              whse, 
        //                                              "",
        //                                              "",
        //                                              "",
        //                                              "",
        //                                              "",
        //                                              ""
        //                                              };

        //    InvokeResponseData rDataStep = Context.Commands.Invoke("SLItemWhses", "ItemwhseGetDetailsSp", itemwhseDetails);
        //    if (rDataStep.Parameters.ElementAt(4).ToString().Equals("1"))
        //    {
        //        if (allowIfCycleCountExists == false)
        //        {
        //           // errorMessage = "Count in Process is Yes for Item :"+item+" Warehouse :"+whse;
        //            return false;
        //        }
        //    }
        //    return true;
        //}
        //InventoryUtils.cs
        public bool validWhseItemRecordExists(string whse, string item, bool allowIfCycleCountExists, out string ErrorMessage)
        {
            ErrorMessage = "";
            Initialize();
            object[] itemwhseDetails = new object[] { item,
                                                      whse,
                                                      "",
                                                      "",
                                                      "",
                                                      "",
                                                      "",
                                                      ""
                                                      };

            InvokeResponseData rDataStep = this.Context.Commands.Invoke("SLItemWhses", "ItemwhseGetDetailsSp", itemwhseDetails);
            if (rDataStep.Parameters.ElementAt(4).ToString().Equals("1"))
            {
                if (allowIfCycleCountExists == false)
                {
                    ErrorMessage = "Count in Process is Yes for Item :" + item + " Warehouse :" + whse;
                    return false;
                }
            }
            return true;
        }

        public bool GetItemLocRecord(string site, string whse, string item, string loc, ref double onHandQty)
        {
            object[] step1Params = new object[] { site, whse, item, loc, onHandQty };
            InvokeResponseData invokeResponseDataStep1 = this.Context.Commands.Invoke("SLItemLocAlls", "GetItemlocQtySp", step1Params);
            if (invokeResponseDataStep1.ReturnValue.Equals("0"))
            {
                string returnQty = invokeResponseDataStep1.Parameters.ElementAt(4).ToString();
                onHandQty = Convert.ToDouble(returnQty, CultureInfo.InvariantCulture); // FTDEV-9247
                return true;
            }
            return false;
        }

        public bool checkLot(string item, string lot, bool itemLotTracked, out string errorMessage)
        {
            errorMessage = "";
            if (itemLotTracked == false)
            {
                if (! string.IsNullOrEmpty(lot))
                {
                    errorMessage = "Item is not controlled, Lot should be blank";
                    return false;
                }
                return true;
            }
            if (itemLotTracked == true)
            {
                if (string.IsNullOrEmpty(lot))
                {
                    errorMessage = "Item is controlled, Lot is mandatory";
                    return false;
                }
            }
            LoadCollectionResponseData responseData = GetLotDetails(item, lot);
            if (responseData.PropertyList.Count == 0)
            {
                errorMessage = "Item/Lot Details Not Found";
                return false;
            }
            return true;
        }
        private bool checkIfItemLotExists(string whse, string item, string loc, string lot)
        {
            object[] inputValues;
            int paramcount = 0;
            paramcount = GetIDOMethodParameterCount("SLTrnacts", "SvallotSp");
            switch (paramcount)
            {
                case 14:
                    inputValues = new object[] { whse,
                                                  item,
                                                  loc,
                                                  lot,
                                                  "rcv",
                                                  "0",
                                                  "Miscellaneous Receipt",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  ""};
                    break;
                default:
                    inputValues = new object[] { whse,
                                                  item,
                                                  loc,
                                                  lot,
                                                  "rcv",
                                                  "0",
                                                  "Miscellaneous Receipt",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  ""};
                    break;
            }
            InvokeResponseData responseDataStep = this.InvokeIDO("SLTrnacts", "SvallotSp", inputValues);
            if (!(responseDataStep.ReturnValue.Equals("0")))
            {

                return false;
            }

            if (responseDataStep.Parameters.ElementAt(7) != null && !(responseDataStep.Parameters.ElementAt(7).ToString().Trim().Equals("")))
            {
                return false;
            }
            return true;
        }
        //error messages are passed via the out errorMessage parameter
        //public bool checkLot(string item, string lot, bool itemLotTracked)
        //{
        //    if (itemLotTracked == false)
        //    {
        //        if (lot != null && !(lot.Trim().Equals("")))
        //        {
        //            errorMessage = constructErrorMessage("Item is not controlled, Lot should be blank", "SLAIMES001", null);
        //            return false;
        //        }
        //        return true;
        //    }
        //    if (itemLotTracked == true)
        //    {
        //        if (lot.Trim().Equals(""))
        //        {
        //            errorMessage = constructErrorMessage("Item is controlled, Lot is mandatory", "SLAIMES002", null);
        //            return false;
        //        }
        //    }
        //    LoadCollectionResponseData responseData = GetLotDetails(item, lot);
        //    if (responseData.PropertyList.Count == 0)
        //    {
        //        errorMessage = constructErrorMessage("Item/Lot Details Not Found", "SLAXXXX002", null);
        //        return false;
        //    }
        //    return true;
        //}
        public bool checkLocationDetails(string item, string whse, string site, string loc, out string errorMessage)
        {
            errorMessage = "";
            object[] step1Params = new object[] { item, whse, site, loc, "", "", "", "" };

            InvokeResponseData invokeResponseDataStep1 = this.Context.Commands.Invoke("SLTrnacts", "TrnShipLocValidSp", step1Params);
            if (invokeResponseDataStep1.ReturnValue.Equals("0"))
            {
                if (invokeResponseDataStep1.Parameters.ElementAt(4).ToString().Equals("1"))
                {
                    errorMessage = invokeResponseDataStep1.Parameters.ElementAt(5).ToString();
                    return false;
                }
                return true;
            }

            errorMessage = invokeResponseDataStep1.Parameters.ElementAt(7).ToString();
            return false;
        }
        //public bool checkLocationDetails(string item, string whse, string site, string loc)
        //{
        //    string errorMessage = "";
        //    object[] step1Params = new object[] { item, whse, site, loc, "", "", "", "" };

        //    InvokeResponseData invokeResponseDataStep1 = this.Context.Commands.Invoke("SLTrnacts", "TrnShipLocValidSp", step1Params);
        //    if (invokeResponseDataStep1.ReturnValue.Equals("0"))
        //    {
        //        if (invokeResponseDataStep1.Parameters.ElementAt(4).ToString().Equals("1"))
        //        {
        //            errorMessage = invokeResponseDataStep1.Parameters.ElementAt(5).ToString();
        //            return false;
        //        }
        //        return true;
        //    }

        //    errorMessage = invokeResponseDataStep1.Parameters.ElementAt(7).ToString();
        //    return false;
        //}
        public bool isItemLotControled(string item)
        {
            LoadCollectionResponseData loadResponseData = GetItemDetails(item);
            if (loadResponseData.Items.Count == 0)
            {
                return false;
            }
            return GetBool(loadResponseData[0, "LotTracked"].ToString());
        }


        /// <summary>
        /// Common method to preform QC Check and set variables
        /// </summary>
        /// <param name="order">In: Order number</param>
        /// <param name="line">In: Order Line</param>
        /// <param name="release">In: release number </param>
        /// <param name="qty">In: Order Qty</param>
        /// <param name="loc">In: location </param>
        /// <param name="lot">In: Lot number</param>
        /// <param name="whse">In: Warehouse</param>
        /// <param name="holdLoc">Out: Hold location</param>
        /// <param name="qcChecked">Out: Needs QC Checked</param>
        /// <param name="isCertified">Out: Is Certified</param>
        /// <returns>When there is a error this returns a formatted error message.  Normally returns "" on success</returns>
        /// <remarks>With MSF153966 a hot fix was provided to a customer for QCS and it 
        ///          added a parameter to the stored proc RSQC_QCCheckSp.  To help mobility to detect when the stored proc has 
        ///          12 params vs 13 params the method RSQC_QCCheckSp was added to the IDO RS_QCInspSups. This common QCcheck 
        ///          method was added to accomidate the change where the stored procedure RSQC_QCCheckSp was added as a 
        ///          method to the IDO RS_QCInspSups.  The IDO/Method will be present in SL8.03.0 and above.  This method 
        ///          also handles older SL versions that do not have the IDO/Method.  JH:20130221
        /// </remarks>
        // --> needs out errorMessage conversion.
        public string QCCheck(string order, string line, string release, string qty, string loc, string lot, string whse, out string holdLoc, out bool qcChecked, out bool isCertified)
        {//if success returns "" .   if fails returns the error message

            InvokeResponseData responseData = null;
            object[] inputValues;
            string tmpval, message = "";
            int paramcount = -1, iqc = -1, icertified = -1, inputcount = 0;
            holdLoc = "";
            qcChecked = false;
            isCertified = false;
            string errorMessage = "";

            paramcount = GetIDOMethodParameterCount("RS_QCInspSups", "RSQC_QCCheckSp");
            if (paramcount > 0)
            {//we have a ido with the method.
                #region IDO RS_QCInspSups call
                switch (paramcount)
                {
                    case 13:
                        inputValues = new object[]{//13
                                                    order,
                                                    line,
                                                    release,
                                                    qty,
                                                    loc,
                                                    lot,
                                                    "0",
                                                    whse,
                                                    System.DateTime.Now.ToString(WMShortDatePattern),
                                                    "", //-3

                                                    "", //-2
                                                    "", //-1
                                                    ""
                                                    };
                        break;
                    default:
                        inputValues = new object[]{//12
                                                    order,
                                                    line,
                                                    release,
                                                    qty,
                                                    loc,
                                                    lot,
                                                    "0",  //seq
                                                    whse,
                                                    "",   //-4 =loc
                                                    "",   //-3 =isqc

                                                    "",   //-2 =cert
                                                    ""    //-1                            
                                                    };

                        break;
                }

                try
                {//ido call
                    //DebugInfoOutputArrayValue(inputValues1);  added for MSF153966  JH:20130208
                    responseData = InvokeIDO("RS_QCInspSups", "RSQC_QCCheckSp", inputValues);

                    if (!(responseData.ReturnValue.Equals("0")) || responseData.Parameters.ElementAt(paramcount - 2).ToString() != "")
                    {
                        //Console.WriteLine("QCCheck: Response data returned from RSQC_QCCheckSp >>" + responseData.ReturnValue);
                        errorMessage = responseData.Parameters.ElementAt(paramcount - 2).ToString();
                    }
                    inputcount = inputValues.Length;


                    holdLoc = responseData.Parameters.ElementAt(inputcount - 4).ToString();
                    //Console.WriteLine("InspectItem Setting Hold Loc = " + holdLoc);

                    tmpval = responseData.Parameters.ElementAt(inputcount - 3).ToString();
                    //Console.WriteLine("InspectItem Setting QC = " + tmpval);
                    iqc = Convert.ToInt32(tmpval, CultureInfo.InvariantCulture); // FTDEV-9247

                    if (Convert.ToInt32(iqc, CultureInfo.InvariantCulture) > 0) // FTDEV-9247
                    { qcChecked = true; }
                    else
                    { qcChecked = false; }

                    tmpval = responseData.Parameters.ElementAt(inputcount - 2).ToString();
                    //Console.WriteLine("InspectItem Setting certified = " + tmpval);
                    icertified = Convert.ToInt32(tmpval, CultureInfo.InvariantCulture); // FTDEV-9247

                    if (Convert.ToInt32(icertified, CultureInfo.InvariantCulture) > 0) // FTDEV-9247
                    { isCertified = true; }
                    else
                    { isCertified = false; }

                }
                catch (Exception e)
                {
                    //Console.WriteLine("QCCheck: Exception returned from RSQC_QCCheckSp >>" + e.Message);
                    message = e.Message;

                }

                #endregion
            }
            else
            {//no ido present call the stored procedure.  all versions pre 8.03.00 should do this and the sp should only have 12 params. JH:20130221

                inputValues = new object[]{//12
                                                 order,
                                                    line,
                                                    release,
                                                    qty,
                                                    loc,
                                                    lot,
                                                    "0",  //seq
                                                    whse,
                                                    "",   //-4 =loc
                                                    "",   //-3 =isqc

                                                    "",   //-2 =cert
                                                    ""    //-1                                                 
                                                    };
                try
                {
                    //DebugInfoOutputArrayValue(inputValues1);  added for MSF153966  JH:20130208
                    responseData = InvokeIDO("RS_QCInspSups", "RSQC_QCCheckSp", inputValues);

                    if (!(responseData.ReturnValue.Equals("0")) || responseData.Parameters.ElementAt(11).ToString() != "")
                    {
                        //Console.WriteLine("QCCheck: Response data returned from RSQC_QCCheckSp >>" + responseData.ReturnValue);
                        message = responseData.Parameters.ElementAt(11).ToString();
                    }

                    inputcount = inputValues.Length;
                    holdLoc = responseData.Parameters.ElementAt(inputcount - 4).ToString();
                    //Console.WriteLine("InspectItem Setting Hold Loc = " + holdLoc);

                    tmpval = responseData.Parameters.ElementAt(inputcount - 3).ToString();
                    //Console.WriteLine("InspectItem Setting QC = " + tmpval);
                    iqc = Convert.ToInt32(tmpval, CultureInfo.InvariantCulture); // FTDEV-9247

                    if (Convert.ToInt32(iqc, CultureInfo.InvariantCulture) > 0) // FTDEV-9247
                    { qcChecked = true; }
                    else
                    { qcChecked = false; }

                    tmpval = responseData.Parameters.ElementAt(inputcount - 2).ToString();
                    icertified = Convert.ToInt32(tmpval, CultureInfo.InvariantCulture); // FTDEV-9247

                    if (Convert.ToInt32(icertified, CultureInfo.InvariantCulture) > 0) // FTDEV-9247
                    { isCertified = true; }
                    else
                    { isCertified = false; }
                }
                catch (Exception e)
                {
                    //Console.WriteLine("QCCheck: Exception returned from RSQC_QCCheckSp >>" + e.Message);
                    message = e.Message;

                }

            }

            return message;
        }

        public bool ValidateQtyForRcvIntoContainerSp(string item, string whse, string loc, string lot, string site, out string errorMessage)
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


        public bool checkAdjReasonCodes(string reasonCode, string transactionType, string item, string containerFlag, out string accountCode,
            out string accountUnit1, out string accountUnit2, out string accountUnit3, out string accountUnit4, out string errorMessage)
        {
            accountCode = accountUnit1 = accountUnit2 = accountUnit3 = accountUnit4 = errorMessage = "";
            LoadCollectionResponseData reasonValidateResponseData = GetReasonCodeDetails(reasonCode, transactionType);
            if (reasonValidateResponseData.Items.Count == 0)
            {
                errorMessage = "Reason Code : " + reasonCode + " Not Found";
                return false;
            }
            InvokeResponseData reasonCodeResData = null;
            object[] reasonCodeValues; //added for SL9 Qualification.  JH:20130708
            int paramcount = 0; //added for SL9 Qualification.  JH:20130708
            paramcount = GetIDOMethodParameterCount("SLReasons", "ReasonGetInvAdjAcctSp");
            switch (paramcount)
            {
                case 16: //added for SL9 Qualification.  JH:20130708
                    reasonCodeValues = new object[] { reasonCode,
                                                      transactionType,
                                                      item,
                                                      "",
                                                      "",
                                                      "",
                                                      "",
                                                      "",
                                                      "",
                                                      "", //10

                                                      "",
                                                      "",
                                                      "",
                                                      "",
                                                     containerFlag,
                                                      ""
                                                        };
                    break;
                case 15:
                    reasonCodeValues = new object[] { reasonCode,
                                                      transactionType,
                                                      item,
                                                      "",
                                                      "",
                                                      "",
                                                      "",
                                                      "",
                                                      "",
                                                      "", //10

                                                      "",
                                                      "",
                                                      "",
                                                      "",
                                                     containerFlag

                                                        };
                    break;
                case 14:
                default: //the default case is 14 
                    reasonCodeValues = new object[] { reasonCode,
                                                      transactionType,
                                                      item,
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
                                                      ""};
                    break;
            }

            reasonCodeResData = this.Context.Commands.Invoke("SLReasons", "ReasonGetInvAdjAcctSp", reasonCodeValues);
            if (!(reasonCodeResData.ReturnValue.Equals("0")))
            {
                errorMessage = reasonCodeResData.Parameters.ElementAt(13).ToString();
                return false;
            }
            else
            {
                accountCode = reasonCodeResData.Parameters.ElementAt(3).ToString();
                accountUnit1 = reasonCodeResData.Parameters.ElementAt(4).ToString();
                accountUnit2 = reasonCodeResData.Parameters.ElementAt(5).ToString();
                accountUnit3 = reasonCodeResData.Parameters.ElementAt(6).ToString();
                accountUnit4 = reasonCodeResData.Parameters.ElementAt(7).ToString();
            }
            return true;
        }

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

        #endregion

        #region  Methods that format data
        public string formatDataByIDOAndPropertyName(string idoName, string propertyName, string input)
        {
            if (input == null)
            {
                return input;
            }

            if (propertyName.Equals("Lot"))
            {
                if (GetInvParamValue("LotGenExp").Equals("0"))
                {
                    return input;
                }
                else
                {
                    return GetExpandedString(input, "LotType", null);
                }
            }
            if (propertyName.Equals("Job"))
            {              
                    return GetExpandedString(input, "JobType", null);              
            }
            if (propertyName.Equals("SerNum"))
            {
                if (GetInvParamValue("SerialLength").Equals("0"))
                {
                    return input;
                }
                else
                {
                    return GetExpandedString(input, "SerNumType", null);
                }
            }

            if (propertyName.Equals("EmpNum"))
            {
                return GetExpandedString(input, "EmpNumType", null);
            }
            if (propertyName.Equals("ContainerNum"))
            {
                return GetExpandedString(input, "ContainerNumType", null);
            }

            GetPropertyInfoResponseData propertyResponseData = this.Context.Commands.GetPropertyInfo(idoName);
            if (propertyResponseData != null)
            {
                PropertyInfo propertyInfo = propertyResponseData.Properties.ElementAt(propertyResponseData.Properties.IndexOf(propertyName));
                if (propertyInfo != null)
                {
                    return formatByPropertInfo(propertyInfo, input);
                }
            }
            return input;
        }
        //subsitutes error codes.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="error">The error message with tag</param>
        /// <param name="messageCode">The code that represents the message</param>
        /// <param name="substitutorDictionary">A directory of substitutions</param>
        /// <returns></returns>
        public string constructErrorMessage(string error, string messageCode, IDictionary<string, string> substitutorDictionary)
        {
            return constructErrorMessage(error, "0", messageCode, substitutorDictionary);
        }
        public string constructErrorMessage(string error, string errorCode, string messageCode, IDictionary<string, string> substitutorDictionary)
        {
            if (substitutorDictionary != null)
            {
                foreach (string substitutorKey in substitutorDictionary.Keys)
                {
                    error = error.Replace(substitutorKey, substitutorDictionary[substitutorKey]);
                }
            }
            return error;
        }


        #endregion

        #region Methods that get data/information        

        public LoadCollectionResponseData GetItemDetails(string item)
        {
            Initialize();
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLItems";
            requestData.PropertyList.SetProperties("Item, Description, UM, LotTracked, SerialTracked, MatlType, ProdType, Stat, MatlCost, LbrCost, FovhdCost, VovhdCost, OutCost, UnitCost , PMTCode, LotPrefix");
            requestData.Filter = "Item = '" + item + "'";
            requestData.RecordCap = 1;
            requestData.OrderBy = "Item";

            //Console.WriteLine("GetItemDetails: Item = " + item);
            return ExcuteQueryRequest(requestData);
        }
        public LoadCollectionResponseData GetLocationDetails(string loc)
        {
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLLocations";
            requestData.PropertyList.SetProperties("Loc, Description, LocType");
            requestData.Filter = "Loc = '" + loc + "'";
            requestData.RecordCap = 1;
            requestData.OrderBy = "Loc";
            return ExcuteQueryRequest(requestData);
        }
        public LoadCollectionResponseData GetLotDetails(string item, string lot)
        {
            //Initialize();
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLLots";
            requestData.PropertyList.SetProperties("Lot, Item, VendLot");
            requestData.Filter = "Item = '" + item + "' and Lot = '" + lot + "'";
            requestData.RecordCap = 0;
            requestData.OrderBy = "Lot";
            return ExcuteQueryRequest(requestData);
        }
        public LoadCollectionResponseData GetParameters(string IDOName, string FieldName)
        {

            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = IDOName;
            requestData.PropertyList.SetProperties(FieldName);
            requestData.RecordCap = -1; //1 = one record 0 = default number of records (~250) -1 = all
            requestData.OrderBy = FieldName;
            return ExcuteQueryRequest(requestData);
        }
        public LoadCollectionResponseData GetReasonCodeDetails(string ReasonCode, string ReasonClass)
        {
            Initialize();
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLReasons";
            requestData.PropertyList.SetProperties("ReasonCode, Description, ReasonClass");
            if (ReasonCode != null && !(ReasonCode.Trim().Equals("")))
            {
                requestData.Filter = "ReasonCode = '" + ReasonCode + "' and ReasonClass = '" + ReasonClass + "'";
            }
            else
            {
                requestData.Filter = "ReasonClass = '" + ReasonClass + "'";
            }
            requestData.RecordCap = 0;
            requestData.OrderBy = "ReasonCode";
            return ExcuteQueryRequest(requestData);
        }
        public LoadCollectionResponseData GetSiteDetails(string site)
        {
            Initialize();
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLSites";
            requestData.PropertyList.SetProperties("Site");
            requestData.Filter = "Site = '" + site + "'";
            requestData.RecordCap = 1;
            requestData.OrderBy = "Site";
            return ExcuteQueryRequest(requestData);
        }
        public LoadCollectionResponseData GetWhseDetailsBySite(string whse, string site)
        {
            Initialize();
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLWhseAlls";
            requestData.PropertyList.SetProperties("SiteRef, Whse, PhyInvFlg");
            requestData.Filter = "Whse = '" + whse + "' and SiteRef = '" + site + "'";
            requestData.RecordCap = 1;
            requestData.OrderBy = "Whse";
            return ExcuteQueryRequest(requestData);
        }
        public bool GetWhseDetailsBySite(string Whse, string Site, out LoadCollectionResponseData WhseResponseData, out string ErrorMessage)
        {
            ErrorMessage = "";
            Initialize();
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLWhseAlls";
            requestData.PropertyList.SetProperties("SiteRef, Whse, PhyInvFlg");
            requestData.Filter = "Whse = '" + Whse + "' and SiteRef = '" + Site + "'";
            requestData.RecordCap = 1;
            requestData.OrderBy = "Whse";
            WhseResponseData = ExcuteQueryRequest(requestData);

            if (WhseResponseData.Items.Count == 0)
            {
                ErrorMessage = "Whse Details Not Found";
                return false;
            }

            string physicalInventoryFlag = WhseResponseData[0, "PhyInvFlg"].ToString();
            if (physicalInventoryFlag == null)
            {
                ErrorMessage = "Error Reading WhseAll record";
                return false;
            }

            if (!(physicalInventoryFlag.Equals("0")))
            {

                ErrorMessage = "Physical Inventory is active in Warehouse : " + Whse + ", Adjustment not allowed";
                return false;
            }

            return true;
        }

        public List<string> GetSerialList(string SessionID)
        {
            List<string> SerialList = new List<string>(1);

            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            //requestData.IDOName = "TABLE!tmp_ser";
            requestData.IDOName = "ICSLTmpSers";
            //requestData.PropertyList.SetProperties("SessionID, ref_str, ser_num");
            requestData.PropertyList.SetProperties("SessionID, RefStr, SerNum");
            requestData.Filter = "SessionID = '" + SessionID + "'";
            requestData.RecordCap = -1;
            requestData.OrderBy = "SerNum";
            LoadCollectionResponseData responseData = ExcuteQueryRequest(requestData);

            for (int i = 0; i < responseData.Items.Count; i++)
            {
                SerialList.Add(responseData[i, "SerNum"].ToString());
            }

            return SerialList;


        }

        public string GetPropertyValue(LoadCollectionResponseData responseData, string propertyName)
        {
            return GetPropertyValue(responseData.PropertyList, responseData.Items, propertyName);
        }
        public string GetPropertyValue(PropertyList propertyList, List<IDOItem> idoItemsList, string propertyName)
        {
            int propertyPos = propertyList.IndexOf(propertyName);
            if (propertyPos == -1)
            {
                return null;
            }
            foreach (IDOItem idoItem in idoItemsList)
            {
                IDOPropertyValueList propertyValueList = idoItem.PropertyValues;
                return propertyValueList.ElementAt(propertyPos).Value.ToString();
            }
            return null;
        }
        public string GetInvParamValue(string parameterName)
        {
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLInvparms";
            requestData.PropertyList.SetProperties(parameterName);
            requestData.RecordCap = 1;
            //LoadCollectionResponseData responseData = this.Context.Commands.LoadCollection(requestData);
            LoadCollectionResponseData responseData = ExcuteQueryRequest(requestData);
            return responseData[0, 0].ToString();
        }

        public string GetItemConvertedQtyToBaseUnit(string item, string qty, string uom, string vendorNum, out string errorMessage)
        {
            errorMessage = "";
            object[] step1Params = new object[] { uom, item, vendorNum, "", "1", qty, "", "" };
            InvokeResponseData invokeResponseDataStep1 = this.Context.Commands.Invoke("SLUMs", "UMConvQtySp", step1Params);
            if (invokeResponseDataStep1.ReturnValue.Equals("0"))
            {
                return invokeResponseDataStep1.Parameters.ElementAt(6).ToString();
            }
            errorMessage = invokeResponseDataStep1.Parameters.ElementAt(7).ToString();
            return null;
        }

        #region Serial Information
        public LoadCollectionResponseData GetSerialInfo(string whse, string item, string loc, string serial, string lot, bool excludePreassignedSN = false)  //added optional parameter excludePreassignedSN to allow us to implement preassigned serial numbers.  jh:20121220
        {
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLMSSerials";
            requestData.PropertyList.SetProperties("SerNum, Stat,RowPointer,RecordDate");
            //string filterString = "SerNum = '" + serial + "' and Item ='" + item + "' and whse ='" + whse + "' and Loc ='" + loc + "'";            
            string filterString = "SerNum = '" + IDOStrFormat(serial) + "' "; //MSF165152 added formating to handle special charcters JH:20130717

            if (item != null && !(item.Trim().Equals("")))
            {
                filterString += "  and Item ='" + IDOStrFormat(item) + "' "; //MSF165152 added formating to handle special charcters JH:20130717
            }

            if (whse != null && !(whse.Trim().Equals("")))
            {
                filterString += "  and Whse ='" + IDOStrFormat(whse) + "'";//MSF165152 added formating to handle special charcters JH:20130717
            }

            if (loc != null && !(loc.Trim().Equals("")))
            {
                filterString += " and Loc ='" + IDOStrFormat(loc) + "'";//MSF165152 added formating to handle special charcters JH:20130717
            }
            if (lot != null && !(lot.Trim().Equals("")))
            {
                filterString += " and Lot ='" + IDOStrFormat(lot) + "'";//MSF165152 added formating to handle special charcters JH:20130717
            }
            if (excludePreassignedSN) //filter for preassigned serials JH:20121226
            {
                filterString += " and Stat != 'P' ";
            }
            requestData.Filter = filterString;
            requestData.RecordCap = 0;
            requestData.OrderBy = "SerNum";
            //Console.WriteLine("In GetSerialInfo method, " + filterString);

            LoadCollectionResponseData responseData = ExcuteQueryRequest(requestData);
            if (responseData != null)
            {
                //Console.WriteLine("Response Data Item Count =, " + responseData.Items.Count);
            }
            if (responseData != null && responseData.Items.Count == 0)
            {
                //filterString = "SerNum = '" + serial.Trim() + "' and Item ='" + item + "' and whse ='" + whse + "' and Loc ='" + loc + "'";

                filterString = "SerNum = '" + serial.Trim() + "' and Item ='" + IDOStrFormat(item) + "'";//MSF165152 added formating to handle special charcters JH:20130717

                if (whse != null && !(whse.Trim().Equals("")))
                {
                    filterString += "  and Whse ='" + IDOStrFormat(whse) + "'"; //MSF165152 added formating to handle special charcters JH:20130717
                }

                if (loc != null && !(loc.Trim().Equals("")))
                {
                    filterString += " and Loc ='" + IDOStrFormat(loc) + "'";//MSF165152 added formating to handle special charcters JH:20130717
                }

                if (lot != null && !(lot.Trim().Equals("")))
                {
                    filterString += " and Lot ='" + IDOStrFormat(lot) + "'";//MSF165152 added formating to handle special charcters JH:20130717
                }
                if (excludePreassignedSN)  //filter for preassigned serials JH:20121226
                {
                    filterString += " and Stat != 'P' ";
                }
                requestData.Filter = filterString;
                requestData.RecordCap = 0;
                requestData.OrderBy = "SerNum";
                //Console.WriteLine("In GetSerialInfo method, " + filterString);

                responseData = ExcuteQueryRequest(requestData);
            }
            return responseData;

        }
        public LoadCollectionResponseData GetSerialInfoBySerialTable(string whse, string item, string loc, string serial, string lot)
        {
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLSerials";
            requestData.PropertyList.SetProperties("SerNum, RecordDate, RowPointer,InWorkflow, NoteExistsFlag, Whse, Loc, Item, Lot, RefRelease, RefNum, RefLine");

            string filterString = "SerNum = '" + serial + "' and Item ='" + IDOStrFormat(item) + "' and Whse ='" + IDOStrFormat(whse) + "' and Loc ='" + IDOStrFormat(loc) + "'";//MSF165152 added formating to handle special charcters JH:20130717
            if (lot != null && !(lot.Trim().Equals("")))
            {
                filterString += " and Lot ='" + IDOStrFormat(lot) + "'"; //MSF165152 added formating to handle special charcters JH:20130717
            }
            requestData.Filter = filterString;
            requestData.RecordCap = 0;
            requestData.OrderBy = "SerNum";
            return ExcuteQueryRequest(requestData);
        }
        public void ClearSerailsBySessionID(string SessionID)
        {
            try
            {
                object[] inputString = new object[] { SessionID };

                InvokeResponseData invokeResponseDataStep = this.InvokeIDO("SLSerials", "DeleteTmpSerSp", inputString);
            }
            catch (Exception)
            {
                // We aren't using an Exception e in this try/catch because we don't care what the error message is.
                // If this call works, great. If not, ok.
            }

            //LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            ////requestData.IDOName = "TABLE!tmp_ser";
            //requestData.IDOName = "ICSLTmpSers";
            //requestData.PropertyList.SetProperties("RowPointer,RecordDate");
            //requestData.Filter = "SessionID = '" + SessionID + "'";
            //requestData.RecordCap = -1;
            //requestData.OrderBy = "ser_num";
            //LoadCollectionResponseData responseData = ExcuteQueryRequest(requestData);

            //if (responseData.Items.Count == 0)
            //{
            //    return;
            //}

            //UpdateCollectionRequestData updateRequestData = new UpdateCollectionRequestData();
            ////updateRequestData.IDOName = "TABLE!tmp_ser";
            //requestData.IDOName = "ICSLTmpSers";

            //for (int i = 0; i < responseData.Items.Count; i++)
            //{
            //    IDOUpdateItem serialItem = new IDOUpdateItem();
            //    serialItem.Action = UpdateAction.Delete;
            //    serialItem.ItemNumber = i;
            //    serialItem.Properties.Add("RowPointer", responseData[i, "RowPointer"].ToString());
            //    serialItem.Properties.Add("RecordDate", responseData[i, "RecordDate"].ToString());
            //    updateRequestData.Items.Add(serialItem);
            //}

            //try
            //{
            //    UpdateCollectionResponseData updateResponseData = this.Context.Commands.UpdateCollection(updateRequestData);
            //}
            //catch (Exception e)
            //{
            //}
        }
        #endregion

        #endregion

        #region Methods that preform an action
        public bool transferBetweenSitesAllowed(string fromSite, string toSite, out string errorMessage)
        {
            errorMessage = "";
            object[] step1Params = new object[] { fromSite, toSite, "" };
            InvokeResponseData invokeResponseDataStep1 = this.Context.Commands.Invoke("SLMSMoves", "ValidateSiteMoveSp", step1Params);
            if (invokeResponseDataStep1.ReturnValue.Equals("0"))
            {
                return true;
            }

            errorMessage = invokeResponseDataStep1.Parameters.ElementAt(2).ToString();
            return false;
        }
        //error messages should be passed via the out parameter
        //public bool transferBetweenSitesAllowed(string fromSite, string toSite)
        //{
        //    object[] step1Params = new object[] { fromSite, toSite, "" };
        //    InvokeResponseData invokeResponseDataStep1 = this.Context.Commands.Invoke("SLMSMoves", "ValidateSiteMoveSp", step1Params);
        //    if (invokeResponseDataStep1.ReturnValue.Equals("0"))
        //    {
        //        return true;
        //    }

        //    constructErrorMessage(invokeResponseDataStep1.Parameters.ElementAt(2).ToString(), "-5", null);
        //    return false;
        //}

        public bool addLocItemRecord(string item, string whse, string site, string loc, bool addPermanentItemWhseLocLink, out string errorMessage)
        {
            errorMessage = "";
            string setPermFlag = "0";
            if (addPermanentItemWhseLocLink == true)
            {
                setPermFlag = "1";
            }
            object[] step1Params = new object[] { whse,
                                                  item,
                                                  loc,
                                                  0,
                                                  0,
                                                  0,
                                                  0,
                                                  0,
                                                  0,
                                                  0,
                                                  setPermFlag,
                                                  site,
                                                  "",
                                                  ""
                                                };

            InvokeResponseData invokeResponseDataStep1 = this.InvokeIDO("SLItemLocs", "ItemLocAddRemoteSp", step1Params);
            if (invokeResponseDataStep1.ReturnValue.Equals("0"))
            {
                return true;
            }

            errorMessage = invokeResponseDataStep1.Parameters.ElementAt(13).ToString();
            return false;
        }
        public bool addLocItemRecord(string item, string whse, string site, string loc, bool addPermanentItemWhseLocLink)
        {
            string setPermFlag = "0";
            string errorMessage = "";
            if (addPermanentItemWhseLocLink == true)
            {
                setPermFlag = "1";
            }
            object[] step1Params = new object[] { whse,
                                                  item,
                                                  loc,
                                                  0,
                                                  0,
                                                  0,
                                                  0,
                                                  0,
                                                  0,
                                                  0,
                                                  setPermFlag,
                                                  site,
                                                  "",
                                                  ""
                                                };

            InvokeResponseData invokeResponseDataStep1 = this.Context.Commands.Invoke("SLItemLocs", "ItemLocAddRemoteSp", step1Params);
            if (invokeResponseDataStep1.ReturnValue.Equals("0"))
            {
                return true;
            }

            errorMessage = invokeResponseDataStep1.Parameters.ElementAt(13).ToString();
            return false;
        }

        public bool performAddLot(string item, string lot, string qty, string poNum, string vendorLot, string nonUnique, string site, out string errormessage)
        {
            errormessage = "";
            object[] inputValues;
            int paramcount = 0;
            paramcount = GetIDOMethodParameterCount("SLLots", "LotAddSp");
            switch (paramcount)
            {
                case 12:
                    inputValues = new object[] { item,
                                                  lot,
                                                  qty,
                                                  poNum,
                                                  vendorLot,
                                                  nonUnique,
                                                  "",
                                                  "",
                                                  site,
                                                  "",
                                                  "",
                                                  ""};
                    break;
                default:
                    inputValues = new object[] { item,
                                                  lot,
                                                  qty,
                                                  poNum,
                                                  vendorLot,
                                                  nonUnique,
                                                  "",
                                                  site};
                    break;
            }

            InvokeResponseData responseDataStep = this.InvokeIDO("SLLots", "LotAddSp", inputValues);
            if (!(responseDataStep.ReturnValue.Equals("0")))
            {
                errormessage = responseDataStep.Parameters.ElementAt(6).ToString();
                return false;
            }
            return true;
        }

        public bool PerformCreateContainer(string containerNum, string whse, string loc, out string errorMessage)
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

        public bool UpdateUserInitial(string UserInitial, out string errorMessage)
        {
            errorMessage = "";
            object[] inputValues = new object[]{
                                                UserInitial,
                                                ""
                                                };

            InvokeResponseData invokeResponseData = this.InvokeIDO("ICSLMethods", "ICUpdateUserInitialSp", inputValues);
            if (invokeResponseData.ReturnValue.Equals("16"))
            {
                errorMessage = invokeResponseData.Parameters.ElementAt(1).ToString();
                return false;
            }
            object[] defineVarialbeInputValues = new object[]{
                                                "FTUserInital",
                                                UserInitial,
                                                ""
                                                };
            try
            {
                InvokeResponseData defineVarialbeInvokeResponseData = this.InvokeIDO("DefineVariables", "DefineVariableSp", defineVarialbeInputValues);
                if (defineVarialbeInvokeResponseData.ReturnValue.Equals("16"))
                {
                    IDORuntime.LogUserMessage("CommonLibrary.UpdateUserInitial : ", UserDefinedMessageType.UserDefined1,
                            defineVarialbeInvokeResponseData.Parameters.ElementAt(2).ToString());

                }
            }
            catch (Exception ex)
            {
                IDORuntime.LogUserMessage("CommonLibrary.UpdateUserInitial : ", UserDefinedMessageType.UserDefined1, ex.Message);
            }
            return true;
        }

        #endregion

    }
}
