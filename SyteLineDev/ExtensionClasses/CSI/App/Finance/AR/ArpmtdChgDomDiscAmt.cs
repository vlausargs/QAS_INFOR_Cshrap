//PROJECT NAME: CSICustomer
//CLASS NAME: ArpmtdChgDomDiscAmt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.AR
{
    public interface IArpmtdChgDomDiscAmt
    {
        int ArpmtdChgDomDiscAmtSp(SiteType PArpmtdSite,
                                  CurrCodeType PDerCustCurrCode,
                                  DateType PArpmtRecptDate,
                                  AmountType PArpmtdForDiscAmt,
                                  AmountType PArpmtdForAllowAmt,
                                  AmountType PArpmtdDomDiscAmt,
                                  ref ExchRateType PArpmtdExchRate,
                                  ref AmountType PArpmtdDomAllowAmt,
                                  ref InfobarType Infobar);
    }

    public class ArpmtdChgDomDiscAmt : IArpmtdChgDomDiscAmt
    {
        readonly IApplicationDB appDB;

        public ArpmtdChgDomDiscAmt(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ArpmtdChgDomDiscAmtSp(SiteType PArpmtdSite,
                                         CurrCodeType PDerCustCurrCode,
                                         DateType PArpmtRecptDate,
                                         AmountType PArpmtdForDiscAmt,
                                         AmountType PArpmtdForAllowAmt,
                                         AmountType PArpmtdDomDiscAmt,
                                         ref ExchRateType PArpmtdExchRate,
                                         ref AmountType PArpmtdDomAllowAmt,
                                         ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ArpmtdChgDomDiscAmtSp";

                appDB.AddCommandParameter(cmd, "PArpmtdSite", PArpmtdSite, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PDerCustCurrCode", PDerCustCurrCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PArpmtRecptDate", PArpmtRecptDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PArpmtdForDiscAmt", PArpmtdForDiscAmt, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PArpmtdForAllowAmt", PArpmtdForAllowAmt, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PArpmtdDomDiscAmt", PArpmtdDomDiscAmt, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PArpmtdExchRate", PArpmtdExchRate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PArpmtdDomAllowAmt", PArpmtdDomAllowAmt, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
