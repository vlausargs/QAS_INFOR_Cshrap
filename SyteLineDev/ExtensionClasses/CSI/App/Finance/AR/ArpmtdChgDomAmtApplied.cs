//PROJECT NAME: CSICustomer
//CLASS NAME: ArpmtdChgDomAmtApplied.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.AR
{
    public interface IArpmtdChgDomAmtApplied
    {
        int ArpmtdChgDomAmtAppliedSp(SiteType PArpmtdSite,
                                     StringType PArpmtdType,
                                     CurrCodeType PDerCustCurrCode,
                                     DateType PArpmtRecptDate,
                                     AmountType PArpmtdForAmtApplied,
                                     AmountType PArpmtdForDiscAmt,
                                     AmountType PArpmtdForAllowAmt,
                                     AmountType PArpmtdDomAmtApplied,
                                     ref ExchRateType PArpmtdExchRate,
                                     ref AmountType PArpmtdDomDiscAmt,
                                     ref AmountType PArpmtdDomAllowAmt,
                                     ref InfobarType Infobar);
    }

    public class ArpmtdChgDomAmtApplied : IArpmtdChgDomAmtApplied
    {
        readonly IApplicationDB appDB;

        public ArpmtdChgDomAmtApplied(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ArpmtdChgDomAmtAppliedSp(SiteType PArpmtdSite,
                                            StringType PArpmtdType,
                                            CurrCodeType PDerCustCurrCode,
                                            DateType PArpmtRecptDate,
                                            AmountType PArpmtdForAmtApplied,
                                            AmountType PArpmtdForDiscAmt,
                                            AmountType PArpmtdForAllowAmt,
                                            AmountType PArpmtdDomAmtApplied,
                                            ref ExchRateType PArpmtdExchRate,
                                            ref AmountType PArpmtdDomDiscAmt,
                                            ref AmountType PArpmtdDomAllowAmt,
                                            ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ArpmtdChgDomAmtAppliedSp";

                appDB.AddCommandParameter(cmd, "PArpmtdSite", PArpmtdSite, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PArpmtdType", PArpmtdType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PDerCustCurrCode", PDerCustCurrCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PArpmtRecptDate", PArpmtRecptDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PArpmtdForAmtApplied", PArpmtdForAmtApplied, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PArpmtdForDiscAmt", PArpmtdForDiscAmt, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PArpmtdForAllowAmt", PArpmtdForAllowAmt, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PArpmtdDomAmtApplied", PArpmtdDomAmtApplied, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PArpmtdExchRate", PArpmtdExchRate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PArpmtdDomDiscAmt", PArpmtdDomDiscAmt, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PArpmtdDomAllowAmt", PArpmtdDomAllowAmt, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
