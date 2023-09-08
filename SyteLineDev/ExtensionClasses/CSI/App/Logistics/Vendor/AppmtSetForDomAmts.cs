//PROJECT NAME: CSIVendor
//CLASS NAME: AppmtSetForDomAmts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
    public interface IAppmtSetForDomAmts
    {
        int AppmtSetForDomAmtsSp(string PVendCurr,
                                 string PBankCurr,
                                 decimal? PAmt,
                                 decimal? PExchRate,
                                 ref decimal? PDomAmt,
                                 ref decimal? PForAmt,
                                 ref string Infobar);
    }

    public class AppmtSetForDomAmts : IAppmtSetForDomAmts
    {
        readonly IApplicationDB appDB;

        public AppmtSetForDomAmts(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int AppmtSetForDomAmtsSp(string PVendCurr,
                                        string PBankCurr,
                                        decimal? PAmt,
                                        decimal? PExchRate,
                                        ref decimal? PDomAmt,
                                        ref decimal? PForAmt,
                                        ref string Infobar)
        {
            CurrCodeType _PVendCurr = PVendCurr;
            CurrCodeType _PBankCurr = PBankCurr;
            AmountType _PAmt = PAmt;
            ExchRateType _PExchRate = PExchRate;
            AmountType _PDomAmt = PDomAmt;
            AmountType _PForAmt = PForAmt;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AppmtSetForDomAmtsSp";

                appDB.AddCommandParameter(cmd, "PVendCurr", _PVendCurr, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PBankCurr", _PBankCurr, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PAmt", _PAmt, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PExchRate", _PExchRate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PDomAmt", _PDomAmt, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PForAmt", _PForAmt, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                PDomAmt = _PDomAmt;
                PForAmt = _PForAmt;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
