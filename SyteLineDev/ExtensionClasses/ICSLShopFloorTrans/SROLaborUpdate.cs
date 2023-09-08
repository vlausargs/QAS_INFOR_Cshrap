using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mongoose.Core.Configuration;
using Mongoose.IDO.Protocol;
using Mongoose.IDO;
using Mongoose.Core;
namespace InforCollect.ERP.SL.ICSLShopFloorTrans
{
    class SROLaborUpdate  : ShopFloorUtilities 
    {

        //input variables
        private string partnerId;
        private string sroNum;
        private string sroLine;
        private string sroOper;
        private string startDateTime;
        private string endDateTime;
        private string hoursWorked;
        private string billHours;
        private string workCode;
        private string billCode;

        //local variables
        private string unitCost;
        private string unitRate;
        private string errorMessage = "";

        public SROLaborUpdate(string partnerId, string sroNum, string sroLine, string sroOper, string startDateTime, string endDateTime, string hoursWorked, string billHours, string workCode, string billCode)
        {
            this.partnerId = partnerId;
            this.sroNum = sroNum;
            this.sroLine = sroLine;
            this.sroOper = sroOper;
            this.startDateTime = startDateTime;
            this.endDateTime = endDateTime;
            this.hoursWorked = hoursWorked;
            this.billHours = billHours;
            this.workCode = workCode;
            this.billCode = billCode;
        }

        public void initialize()
        {

            partnerId = "";
            sroNum = "";
            sroLine = "";
            sroOper = "";
            startDateTime = "";
            endDateTime = "";
            hoursWorked = "0";
            billHours = "0";
            workCode = "";
            billCode = "";

            //Local variable
            unitCost = "0";
            unitRate = "0"; 
        }
        
        public bool formatInputs()
        {
            if (partnerId == null || partnerId.Trim().Equals(""))
            {
                errorMessage = "PartnerId input mandatory";
                return false;
            }

            if (sroNum == null || sroNum.Trim().Equals(""))
            {
                errorMessage = "SRO Number input mandatory";
                return false;
            }

             if (sroLine == null || sroLine.Trim().Equals(""))
            {
                errorMessage = "SRO Line input mandatory";
                return false;
            }

             if (sroOper == null || sroOper.Trim().Equals("")) 
            {
                errorMessage = "SRO Oper input mandatory";
                return false;
            }

            if (startDateTime == null || startDateTime.Trim().Equals(""))
            {
                errorMessage = "Start date and time input mandatory";
                return false;
            }

            if (endDateTime == null || endDateTime.Trim().Equals(""))
            {
                errorMessage = "End date and time input mandatory";
                return false;
            }

            return true;
        }

        public bool ValidateInputs()
        {
            if (IsStringContainsNumericValue(partnerId) && IsStringStartsWithNumEndsWithNonNumeric(partnerId)==false)
                partnerId = formatDataByIDOAndPropertyName("FSPartners", "PartnerId", partnerId);
            sroNum = formatDataByIDOAndPropertyName("FSSROs", "SroNum", sroNum);
            LoadCollectionResponseData partnerResponseData = GetPartnerDetails(partnerId);
            if (partnerResponseData.Items.Count == 0)
            {
                errorMessage = "PartnerId Details Not Found";
                return false;
            }

            LoadCollectionResponseData SroResponseData = GetSRODetails(sroNum);
            if (SroResponseData.Items.Count == 0)
            {
                errorMessage = "Service Order Details Not Found";
                return false;
            }

            LoadCollectionResponseData SroLineResponseData = GetSROLineDetails(sroNum, sroLine);
            if (SroLineResponseData.Items.Count == 0)
            {
                errorMessage = "Line Details Not Found";
                return false;
            }
            if (SroLineResponseData.Items.Count > 0)
            {
                if (SroLineResponseData[0, "Stat"].Value == "C")
                {
                    errorMessage = "Line# is Closed for Service Request Order that has [SRO Number:" + sroNum + "] and [Line#:" + sroLine + "]";
                    return false;
                }
            }
            LoadCollectionResponseData SroOperResponseData = GetSROOperDetails(sroNum, sroLine, sroOper);
            if (SroOperResponseData.Items.Count == 0)
            {
                errorMessage = "SroOper Details Not Found";
                return false;
            }
            if (SroOperResponseData.Items.Count > 0)
            {
                if (SroOperResponseData[0, "Stat"].Value == "C")
                {
                    errorMessage = "Oper# is Closed for Service Request Order that has [SRO Number:" + sroNum  + "] and [Line#:" + sroLine + "] and [Oper#: " + sroOper +"]";
                    return false;
                }
            }
            ValidateSROLaborDC(partnerId, workCode, sroNum, sroLine, sroOper, endDateTime, ref unitCost, ref unitRate);

            return true;
        }

        public int PerformUpdate(out string infobar)
        {
            infobar = "";

            //1 Format Inputs
            if (formatInputs() == false)
            {
                infobar = errorMessage;
                infobar = formatResponse(infobar);
                return 1;
            }
            //2 validate Inputs
            if (ValidateInputs() == false)
            {
                infobar = errorMessage;
                infobar = formatResponse(infobar);
                return 2;
            }

            //3 Perform Labor Start Updates
            if (performLaborStartUpdate(out errorMessage) == false)
            {
                infobar = errorMessage;
                infobar = formatResponse(infobar);
                return 3;
            }

            //3 Perform Labor Stop Updates
            if (performLaborStopUpdate(out errorMessage) == false)
            {
                infobar = errorMessage;
                infobar = formatResponse(infobar);
                return 4;
            }

            infobar = formatResponse(infobar);
            return 0;
        }

        private Boolean performLaborStartUpdate(out string infobar)
        {
            try {
                infobar = "";

                object[] StartInputs = new object[] {   partnerId,
                                                    "S",
                                                    "",
                                                    infobar,
                                                    sroNum,
                                                    sroLine,
                                                    sroOper,
                                                    startDateTime};

                InvokeResponseData StartResponseData = this.Context.Commands.Invoke("FSSROLabors", "SSSFSSROLaborDCStartSp", StartInputs);

                if (!StartResponseData.ReturnValue.Equals("0"))
                {
                    infobar = StartResponseData.Parameters.ElementAt(3).ToString();
                    return false;
                }
            }
            catch(Exception ex)
            {
                infobar = ex.Message;
                return false;
            }
            return true;
        }

        private Boolean performLaborStopUpdate(out string infobar)
        {
            try { 
            infobar = "";
                if (SSSFSSROLaborCostSp(out infobar) == false) { return false; }//getting labor cost
                if (SSSFSSroLaborRateSp(out infobar) == false) { return false; }
                IDORuntime.LogUserMessage("SROLaborUpdate.performLaborStopUpdate", UserDefinedMessageType.UserDefined1, "SSSFSSroLaborRateSp Complete the Call : infobar :" + infobar);
                IDORuntime.LogUserMessage("SROLaborUpdate.performLaborStopUpdate", UserDefinedMessageType.UserDefined1, "SSSFSSROLaborDCFinishSp : Starts..");
                object[] StopInputs = new object[] {    partnerId, 
                                                    sroNum, 
                                                    sroLine, 
                                                    sroOper, 
                                                    workCode, 
                                                    hoursWorked, 
                                                    billHours, 
                                                    endDateTime, 
                                                    "", 
                                                    infobar, 
                                                    billCode, 
                                                    unitCost, 
                                                    unitRate, 
                                                    "0", 
                                                    ""
                                                };

            InvokeResponseData StopResponseData = this.Context.Commands.Invoke("FSSROLabors", "SSSFSSROLaborDCFinishSp", StopInputs);
                IDORuntime.LogUserMessage("SROLaborUpdate.performLaborStopUpdate", UserDefinedMessageType.UserDefined1, "SSSFSSROLaborDCFinishSp : Stop: StopResponseValue :" + StopResponseData.ReturnValue);
                IDORuntime.LogUserMessage("SROLaborUpdate.performLaborStopUpdate", UserDefinedMessageType.UserDefined1, "SSSFSSROLaborDCFinishSp : Stop: InfoBarMessage :" + StopResponseData.Parameters.ElementAt(14).ToString());

                if (!StopResponseData.ReturnValue.Equals("0"))
            {
                infobar = StopResponseData.Parameters.ElementAt(9).ToString();
                return false;
            }
            }
            catch (Exception ex)
            {
                infobar = ex.Message;
                return false;
            }
            return true;
        }

        private Boolean SSSFSSROLaborCostSp(out string infobar) //Labor cost
        {
            infobar = "";
            object[] StopInputs = new object[] {    "A",
                                                    sroNum,
                                                    sroLine,
                                                    sroOper,
                                                    partnerId,
                                                    workCode,
                                                    endDateTime,
                                                    "",
                                                    infobar

                                                };

            InvokeResponseData StopResponseData = this.Context.Commands.Invoke("FSSROLabors", "SSSFSSROLaborCostSp", StopInputs);
            if (StopResponseData.ReturnValue.Equals("0"))
            {
                unitCost = StopResponseData.Parameters.ElementAt(7).ToString();
                return true;
            }
            else if (!StopResponseData.ReturnValue.Equals("0"))
            {
                infobar = StopResponseData.Parameters.ElementAt(8).ToString();
                return false;
            }


            return true;
        }

        private Boolean SSSFSSroLaborRateSp(out string infobar)  // Labor Rate
        {
            infobar = "";
            object[] StopInputs = new object[] {    "A",
                                                    sroNum,
                                                    sroLine,
                                                    sroOper,
                                                    billCode,
                                                    endDateTime,
                                                    partnerId,
                                                    workCode,
                                                    unitCost,
                                                    hoursWorked,
                                                    billHours,
                                                    "",
                                                    infobar
                                                };

            InvokeResponseData StopResponseData = this.Context.Commands.Invoke("FSSROLabors", "SSSFSSroLaborRateSp", StopInputs);
            IDORuntime.LogUserMessage("SROLaborUpdate.SSSFSSroLaborRateSp", UserDefinedMessageType.UserDefined1, "StopResponseData ReturnValue :" + StopResponseData.ReturnValue);
            IDORuntime.LogUserMessage("SROLaborUpdate.SSSFSSroLaborRateSp", UserDefinedMessageType.UserDefined1, "StopResponseData InfoBarMessage :" + StopResponseData.Parameters.ElementAt(12).ToString());
            if (StopResponseData.ReturnValue.Equals("0"))
            {
                IDORuntime.LogUserMessage("SROLaborUpdate.SSSFSSroLaborRateSp", UserDefinedMessageType.UserDefined1, "UnitRate beforeToString : " + StopResponseData.Parameters.ElementAt(11));
                try
                {
                    unitRate = StopResponseData.Parameters.ElementAt(11).ToString();

                }
                catch (Exception e)
                {
                    IDORuntime.LogUserMessage("SROLaborUpdate.SSSFSSroLaborRateSp", UserDefinedMessageType.UserDefined1, "UnitRate ToString():" + unitRate);
                    IDORuntime.LogUserMessage("SROLaborUpdate.SSSFSSroLaborRateSp", UserDefinedMessageType.UserDefined1, "Exception  :" + e.Message);
                }

                return true;
            }
            else if (!StopResponseData.ReturnValue.Equals("0"))
            {
                infobar = StopResponseData.Parameters.ElementAt(12).ToString();
                return false;
            }


            return true;
        }

    }
}
