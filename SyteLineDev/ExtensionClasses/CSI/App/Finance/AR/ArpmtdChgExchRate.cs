//PROJECT NAME: CSICustomer
//CLASS NAME: ArpmtdChgExchRate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.AR
{
    public interface IArpmtdChgExchRate
    {
        int ArpmtdChgExchRateSp(SiteType PArpmtdSite,
                                StringType PArpmtdType,
                                CurrCodeType PDerCustCurrCode,
                                DateType PArpmtRecptDate,
                                ExchRateType PArpmtdExchRate,
                                AmountType PArpmtdForAmtApplied,
                                AmountType PArpmtdForDiscAmt,
                                AmountType PArpmtdForAllowAmt,
                                ref AmountType PArpmtdDomAmtApplied,
                                ref AmountType PArpmtdDomDiscAmt,
                                ref AmountType PArpmtdDomAllowAmt,
                                ref InfobarType Infobar);
    }

    public class ArpmtdChgExchRate : IArpmtdChgExchRate
    {
        readonly IApplicationDB appDB;

        public ArpmtdChgExchRate(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ArpmtdChgExchRateSp(SiteType PArpmtdSite,
                                       StringType PArpmtdType,
                                       CurrCodeType PDerCustCurrCode,
                                       DateType PArpmtRecptDate,
                                       ExchRateType PArpmtdExchRate,
                                       AmountType PArpmtdForAmtApplied,
                                       AmountType PArpmtdForDiscAmt,
                                       AmountType PArpmtdForAllowAmt,
                                       ref AmountType PArpmtdDomAmtApplied,
                                       ref AmountType PArpmtdDomDiscAmt,
                                       ref AmountType PArpmtdDomAllowAmt,
                                       ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ArpmtdChgExchRateSp";

                appDB.AddCommandParameter(cmd, "PArpmtdSite", PArpmtdSite, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PArpmtdType", PArpmtdType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PDerCustCurrCode", PDerCustCurrCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PArpmtRecptDate", PArpmtRecptDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PArpmtdExchRate", PArpmtdExchRate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PArpmtdForAmtApplied", PArpmtdForAmtApplied, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PArpmtdForDiscAmt", PArpmtdForDiscAmt, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PArpmtdForAllowAmt", PArpmtdForAllowAmt, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PArpmtdDomAmtApplied", PArpmtdDomAmtApplied, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PArpmtdDomDiscAmt", PArpmtdDomDiscAmt, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PArpmtdDomAllowAmt", PArpmtdDomAllowAmt, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
