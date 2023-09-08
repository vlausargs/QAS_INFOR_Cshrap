using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using CSI.Logistics.Vendor;
using Microsoft.Extensions.DependencyInjection;
namespace CSI.MG.Customer
{
    [IDOExtensionClass("SLRateShopViews")]
    public class SLRateShopViews : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ProcessFreightRateShopRequest(

            string TransactionType,
            string bearerToken, 
            string URL,
            string tenantId,
            [Optional] string CustNum,
            [Optional] int CustSeq,
            [Optional] string CustomerOrder,
            [Optional] string ShipVia,
            [Optional] decimal? ShipmentID,
            [Optional] ref string jsonString,
            [Optional] ref int? httpResponseCode,
            [Optional] ref decimal? CarrierUpchargePct,
            [Optional] ref string Infobar)
        {
            int Severity = 0;

            var processFreightRateShopRequest = this.GetService<IProcessFreightRateShopRequest>();

            var process = processFreightRateShopRequest.Process(bearerToken, URL, tenantId, CustNum, CustSeq, CustomerOrder, ShipVia, ShipmentID, TransactionType);

            Infobar = process.infobar;
            Severity = process.severity;
            jsonString = process.jsonResponses;
            httpResponseCode = process.httpResponseCode;
            CarrierUpchargePct = process.CarrierUpchargePct;
            return Severity;
        }


        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_GetFreightRateShop(
           [Optional] string jsonString,
           [Optional] int? httpResponseCode
        )
        {
            DataTable tblReturn = new DataTable();
            var iGetFreightShopRates = this.GetService<IGetFreightRateShop>();
            var freightRateShopResponse = iGetFreightShopRates.CLM_FreightRateShop(jsonString, httpResponseCode);
            if (freightRateShopResponse!=null)
                tblReturn= freightRateShopResponse;
            return tblReturn;
        }


        [IDOMethod(MethodFlags.None, "Infobar")]
        public int CalcTotalFreightAmount(
            string CustNum,
            int CustSeq,
            [Optional] DateTime? PickUpDateTime,
            [Optional] decimal? CarrierUpchargePct,
            [Optional] decimal? CarrierFreight,
            string CarrierCoCurrCode,
            string ShipmentCoCurrCode,
            ref decimal TotalFreightAmount,
            ref decimal ExchangeRate,
            ref string Infobar)
        {
            int Severity = 0;
            var iCalcFreightAmounts = this.GetService<ICalcFreightAmounts>();

            (Severity, Infobar) = iCalcFreightAmounts.CalcTotalFreightAmount(
                                                        CustNum,
                                                        CustSeq,
                                                        PickUpDateTime,
                                                        CarrierUpchargePct,
                                                        CarrierFreight,
                                                        CarrierCoCurrCode,
                                                        ShipmentCoCurrCode,
                                                        ref TotalFreightAmount,
                                                        ref ExchangeRate);

            return Severity;
        }
    }
}
