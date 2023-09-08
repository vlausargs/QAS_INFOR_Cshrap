//PROJECT NAME: Finance.AR
//CLASS NAME: GainLossAr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.AR
{
    public class GainLossAr : IGainLossAr
    {
        readonly IApplicationDB appDB;

        public GainLossAr(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public (int? ReturnCode,
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
            DateTime? AgingDate = null)
        {
            CustNumType _pCustNum = pCustNum;
            InvNumType _pInvNum = pInvNum;
            CurrCodeType _pCustCurrCode = pCustCurrCode;
            ListYesNoType _pUseHistRate = pUseHistRate;
            ListYesNoType _pTTransDom = pTTransDom;
            SiteType _pSite = pSite;
            ArInvSeqType _pInvSeq = pInvSeq;
            ArCheckNumType _pCheckSeq = pCheckSeq;
            AmountType _rTDomBal = rTDomBal;
            AmountType _rTForBal = rTForBal;
            AmountType _rTGainLoss = rTGainLoss;
            InfobarType _rInfobar = rInfobar;
            DateType _pCutoffDate = pCutoffDate;
            ListYesNoType _ReturnTable = ReturnTable;
            GenericDecimalType _TAvgExchRate = TAvgExchRate;
            DateType _AgingDate = AgingDate;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GainLossArSp";

                appDB.AddCommandParameter(cmd, "pCustNum", _pCustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pInvNum", _pInvNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pCustCurrCode", _pCustCurrCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pUseHistRate", _pUseHistRate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pTTransDom", _pTTransDom, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pInvSeq", _pInvSeq, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pCheckSeq", _pCheckSeq, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "rTDomBal", _rTDomBal, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "rTForBal", _rTForBal, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "rTGainLoss", _rTGainLoss, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "rInfobar", _rInfobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "pCutoffDate", _pCutoffDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ReturnTable", _ReturnTable, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TAvgExchRate", _TAvgExchRate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "AgingDate", _AgingDate, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                rTDomBal = _rTDomBal;
                rTForBal = _rTForBal;
                rTGainLoss = _rTGainLoss;
                rInfobar = _rInfobar;
                TAvgExchRate = _TAvgExchRate;

                return (Severity, rTDomBal, rTForBal, rTGainLoss, rInfobar, TAvgExchRate);
            }
        }
    }
}
