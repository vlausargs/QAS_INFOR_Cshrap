using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mongoose.Core.Configuration;
using Mongoose.IDO.Protocol;
using Mongoose.IDO;
using Mongoose.Core;
namespace InforCollect.ERP.SL.ICSLFieldServiceTrans
{
    class SROLaborUpdate  : FieldServiceUtilities
    {

        //input variables
        private string partnerId;
        private string sroNum;
        private long sroLine;
        private long sroOper;
        private string startDateTime;
        private string endDateTime;
        private decimal hoursWorked;
        private decimal billHours;
        private string workCode;
        private string billCode;

        //local variables
        private string unitCost;
        private string unitRate;
        private string errorMessage = "";

        public SROLaborUpdate(string partnerId, string sroNum, long sroLine, long sroOper, string startDateTime, string endDateTime, decimal hoursWorked, decimal billHours, string workCode, string billCode)
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
            sroLine = 0;
            sroOper = 0;
            startDateTime = "";
            endDateTime = "";
            hoursWorked = 0;
            billHours = 0;
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

            if (sroLine == 0)
            {
                errorMessage = "SRO Line input mandatory";
                return false;
            }

            if (sroOper == 0)
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
        public bool ValidateInputs()
        {
            if (IsStringContainsNumericValue(partnerId))
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

            LoadCollectionResponseData SroOperResponseData = GetSROOperDetails(sroNum, sroLine, sroOper);
            if (SroOperResponseData.Items.Count == 0)
            {
                errorMessage = "SroOper Details Not Found";
                return false;
            }

            ValidateSROLaborDC(partnerId, sroNum, sroLine, sroOper, endDateTime, ref unitCost, ref unitRate);

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
            if (performLaborStartUpdate(out infobar) == false)
            {
                infobar = errorMessage;
                infobar = formatResponse(infobar);
                return 3;
            }

            //3 Perform Labor Stop Updates
            if (performLaborStopUpdate(out infobar) == false)
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
                infobar = StartResponseData.Parameters.ElementAt(7).ToString();
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

        private Boolean performLaborStopUpdate(out string infobar)
        {
            try { 
            infobar = "";
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
                                                    "", 
                                                    ""
                                                };

            InvokeResponseData StopResponseData = this.Context.Commands.Invoke("FSSROLabors", "SSSFSSROLaborDCFinishSp", StopInputs);
            if (!StopResponseData.ReturnValue.Equals("0"))
            {
                infobar = StopResponseData.Parameters.ElementAt(14).ToString();
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
    }
}
