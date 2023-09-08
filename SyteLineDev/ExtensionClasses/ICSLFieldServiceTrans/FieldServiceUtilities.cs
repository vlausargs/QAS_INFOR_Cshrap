using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Mongoose.Core.Configuration;
using Mongoose.IDO.Protocol;
using Mongoose.IDO;
using Mongoose.Core;
namespace InforCollect.ERP.SL.ICSLFieldServiceTrans
{
    public class FieldServiceUtilities : ICSLCommonLibrary
    {

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

        public LoadCollectionResponseData GetSROLineDetails(string SroNum, long SroLine)
        {
            LoadCollectionRequestData LoadRequestData = new LoadCollectionRequestData();
            LoadRequestData.IDOName = "FSSROLines";
            LoadRequestData.PropertyList.SetProperties("SroNum,SroLine");
            LoadRequestData.Filter = "SroNum='" + SroNum + "' and SroLine='" + SroLine + "'";
            LoadRequestData.RecordCap = -1;
            LoadRequestData.OrderBy = "SroLine";

            return ExcuteQueryRequest(LoadRequestData);
        }

        public LoadCollectionResponseData GetSROOperDetails(string SroNum, long SroLine, long SroOper)
        {
            LoadCollectionRequestData LoadRequestData = new LoadCollectionRequestData();
            LoadRequestData.IDOName = "FSSROOpers";
            //LoadRequestData.PropertyList.SetProperties("SroOper,SroNum,SroLine");// 20201110.o
            LoadRequestData.PropertyList.SetProperties("SroOper,SroNum,SroLine,SROSroStat,SROLineStat,Stat");// 20201110.n
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
            LoadRequestData.IDOName = "SLItemcusts";
            LoadRequestData.PropertyList.SetProperties("Item,CustItem");
            LoadRequestData.Filter = "Item='" + item + "' and CustItem='" + custItem + "'";
            LoadRequestData.RecordCap = -1;
            LoadRequestData.OrderBy = "CustItem";

            return ExcuteQueryRequest(LoadRequestData);
        }
        public LoadCollectionResponseData GetSROCustItemDetails(string SroNum, string Item, string custItem)
        {
            LoadCollectionRequestData LoadRequestData = new LoadCollectionRequestData();
            LoadRequestData.IDOName = "FSSROs";
            LoadRequestData.PropertyList.SetProperties("SroNum,CustNum");
            LoadRequestData.Filter = "SroNum='" + SroNum + "'";
            LoadRequestData.RecordCap = -1;
            LoadRequestData.OrderBy = "SroNum";
            var responseData = ExcuteQueryRequest(LoadRequestData);
            if (responseData == null || responseData.Items == null || responseData.Items.Count <= 0)
                return new LoadCollectionResponseData();

            var custName = responseData[0, "CustNum"].Value;
            LoadRequestData = null;
            if (string.IsNullOrWhiteSpace(custName))
                return new LoadCollectionResponseData();

            LoadRequestData = new LoadCollectionRequestData();
            LoadRequestData.IDOName = "SLItemcusts";
            LoadRequestData.PropertyList.SetProperties("Item,CustItem");
            LoadRequestData.Filter = string.Format("CustNum='{0}' and Item='{1}' and CustItem='{2}'", custName, Item, custItem);
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



        public bool ValidateSROLaborDC(string partnerid, string SroNum, long SroLine, long SroOper, string stopTime, ref string unitCost, ref string unitRate)
        {
            object[] inputValues = new object[]{"Oper",
                                                partnerid,
                                                "",
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
            object[] LotCheckInputValues;
            int paramcount = 0;
            paramcount = GetIDOMethodParameterCount("SLTrnacts", "SvallotSp");
            switch (paramcount)
            {
                case 14:
                    LotCheckInputValues = new object[] { whse, item, loc, lot, "ISS", "0", "", "", "", "", "", infobar, 0, "" };
                    break;
                default:
                    LotCheckInputValues = new object[] { whse, item, loc, lot, "ISS", "0", "", "", "", "", "", infobar, 0 };
                    break;
            }
            InvokeResponseData invokeResponseDataStep = this.Context.Commands.Invoke("SLTrnacts", "SvallotSp", LotCheckInputValues);
            if (!(invokeResponseDataStep.ReturnValue.Equals("0")))
            {
                errorMessage = invokeResponseDataStep.Parameters.ElementAt(11).ToString();
                return false;
            }

            return true;
        }
    }
}