using System;
using CSI.Data;
using CSI.Logistics.Vendor;
using CSI.Material;

namespace CSI.Logistics.Customer
{
    public interface ICalcFreightAmounts
    {
        (int Severity, string Infobar) CalcTotalFreightAmount(string CustNum, int CustSeq, DateTime? PickUpDateTime, decimal? CarrierUpchargePct, decimal? CarrierFreight, string CarrierCoCurrCode, string ShipmentCoCurrCode, ref decimal TotalFreightAmount, ref decimal ExchangeRate);
        (int Severity, string Infobar) GetCarrierUpchargePct(string CustNum, int CustSeq, ref decimal GetCarrierUpchargePct);
    }
    public class CalcFreightAmounts : ICalcFreightAmounts
    {
        IExpandKyByType _expandKyByType;
        ICalcFreightAmountsCRUD _CalcFreightAmountsCRUD;
        ICurrCnvt _iCurrCnvt;
        IDateTimeUtil _dateTimeUtil;

        public CalcFreightAmounts(
            IExpandKyByType expandKyByType,
            ICalcFreightAmountsCRUD CalcFreightAmountsCRUD,
            ICurrCnvt iCurrCnvt,
            IDateTimeUtil dateTimeUtil
            )
        {
            _expandKyByType = expandKyByType;
            _CalcFreightAmountsCRUD = CalcFreightAmountsCRUD;
            _iCurrCnvt = iCurrCnvt;
            _dateTimeUtil = dateTimeUtil;
        }

        public (int Severity, string Infobar) GetCarrierUpchargePct(string CustNum, int CustSeq, ref decimal GetCarrierUpchargePct)
        {
            int Severity = 0;
            string Infobar = "";
            GetCarrierUpchargePct = 0M;

            string custNum = _expandKyByType.ExpandKyByTypeFn("CustNumType", CustNum);

            GetCarrierUpchargePct = _CalcFreightAmountsCRUD.GetCarrierUpchargePct(custNum, CustSeq)??0M;

            return (Severity, Infobar);
        }

        public (int Severity, string Infobar) CalcTotalFreightAmount(
            string CustNum,
            int CustSeq,
            DateTime? PickUpDateTime,
            decimal? CarrierUpchargePct,
            decimal? CarrierFreight,
            string CarrierCoCurrCode,
            string ShipmentCoCurrCode,
            ref decimal TotalFreightAmount,
            ref decimal ExchangeRate)
        {
            int Severity = 0;
            string Infobar = "";
            decimal carrierUpchargePct = CarrierUpchargePct ?? 0M;
            decimal carrierUpchargeAmount = 0M;
            decimal carrierFreight = CarrierFreight ?? 0M;
            decimal carrierFreightConv = 0M;
            decimal? exchangeRate=null;
            DateTime pickupDateTime = PickUpDateTime?? _dateTimeUtil.Now();

            try
            {
                string custNum = _expandKyByType.ExpandKyByTypeFn("CustNumType", CustNum);

                if (CarrierUpchargePct == null)
                {
                    (Severity, Infobar) = GetCarrierUpchargePct(CustNum, CustSeq, ref carrierUpchargePct);
                    if (Severity != 0)
                    {
                        return (Severity, Infobar);
                    }
                }
                if (CarrierCoCurrCode== ShipmentCoCurrCode)
                {
                    exchangeRate = 1M;
                }

                var CurrCnvt = _iCurrCnvt.CurrCnvtSp(
                                CurrCode: ShipmentCoCurrCode,
                                FromDomestic: 1,
                                UseBuyRate: 0,
                                RoundResult: 1,
                                Date: pickupDateTime,
                                TRate: exchangeRate,
                                Infobar: Infobar,
                                Amount1: carrierFreight,
                                Result1: carrierFreightConv,
                                DomCurrCode: CarrierCoCurrCode );


                Severity = CurrCnvt.ReturnCode ?? 0;
                ExchangeRate = CurrCnvt.TRate ?? 1M;
                Infobar = CurrCnvt.Infobar;
                carrierFreightConv = CurrCnvt.Result1 ?? 0M;

                if (Severity != 0 && (Infobar!=""))
                {
                    return (Severity,Infobar);
                }
 
                carrierUpchargeAmount = (carrierUpchargePct/100M) * carrierFreightConv;
                TotalFreightAmount = carrierFreightConv + carrierUpchargeAmount;

            }
            catch (Exception e)
            {
                Severity = 16;
                Infobar = e.Message;
            }

            return (Severity, Infobar);
        }
    }
}
