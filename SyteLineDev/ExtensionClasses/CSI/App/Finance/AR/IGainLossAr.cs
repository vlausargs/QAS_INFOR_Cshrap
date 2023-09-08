//PROJECT NAME: Finance.AR
//CLASS NAME: IGainLossAr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AR
{
    public interface IGainLossAr
    {
        (int? ReturnCode,
            decimal? rTDomBal,
            decimal? rTForBal,
            decimal? rTGainLoss,
            string rInfobar,
            decimal? TAvgExchRate) GainLossArSp(
            string pCustNum,
            string pInvNum,
            string pCustCurrCode,
            int? pUseHistRate,
            int? pTTransDom,
            string pSite = null,
            int? pInvSeq = 0,
            int? pCheckSeq = 0,
            decimal? rTDomBal = 0,
            decimal? rTForBal = 0,
            decimal? rTGainLoss = 0,
            string rInfobar = null,
            DateTime? pCutoffDate = null,
            int? ReturnTable = 1,
            decimal? TAvgExchRate = null,
            DateTime? AgingDate = null);
    }
}