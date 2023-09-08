//PROJECT NAME: CSIVendor
//CLASS NAME: AppmtLeaveDomAmt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
    public interface IAppmtLeaveDomAmt
    {
        int AppmtLeaveDomAmtSp(string PDomCurrCode,
                               decimal? PDomCheckAmt,
                               DateTime? PRecptDate,
                               short? PCheckNum,
                               string PBankCode,
                               string PVendNum,
                               ref decimal? PExchRate,
                               ref decimal? PForCheckAmt,
                               ref decimal? PDomApplied,
                               ref decimal? PForApplied,
                               ref decimal? PDomRemaining,
                               ref decimal? PForRemaining,
                               ref string Infobar);
    }

    public class AppmtLeaveDomAmt : IAppmtLeaveDomAmt
    {
        readonly IApplicationDB appDB;

        public AppmtLeaveDomAmt(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int AppmtLeaveDomAmtSp(string PDomCurrCode,
                                      decimal? PDomCheckAmt,
                                      DateTime? PRecptDate,
                                      short? PCheckNum,
                                      string PBankCode,
                                      string PVendNum,
                                      ref decimal? PExchRate,
                                      ref decimal? PForCheckAmt,
                                      ref decimal? PDomApplied,
                                      ref decimal? PForApplied,
                                      ref decimal? PDomRemaining,
                                      ref decimal? PForRemaining,
                                      ref string Infobar)
        {
            CurrCodeType _PDomCurrCode = PDomCurrCode;
            AmountType _PDomCheckAmt = PDomCheckAmt;
            DateType _PRecptDate = PRecptDate;
            ApCheckSeqType _PCheckNum = PCheckNum;
            BankCodeType _PBankCode = PBankCode;
            VendNumType _PVendNum = PVendNum;
            ExchRateType _PExchRate = PExchRate;
            AmountType _PForCheckAmt = PForCheckAmt;
            AmountType _PDomApplied = PDomApplied;
            AmountType _PForApplied = PForApplied;
            AmountType _PDomRemaining = PDomRemaining;
            AmountType _PForRemaining = PForRemaining;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AppmtLeaveDomAmtSp";

                appDB.AddCommandParameter(cmd, "PDomCurrCode", _PDomCurrCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PDomCheckAmt", _PDomCheckAmt, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PRecptDate", _PRecptDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PCheckNum", _PCheckNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PBankCode", _PBankCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PExchRate", _PExchRate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PForCheckAmt", _PForCheckAmt, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PDomApplied", _PDomApplied, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PForApplied", _PForApplied, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PDomRemaining", _PDomRemaining, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PForRemaining", _PForRemaining, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                PExchRate = _PExchRate;
                PForCheckAmt = _PForCheckAmt;
                PDomApplied = _PDomApplied;
                PForApplied = _PForApplied;
                PDomRemaining = _PDomRemaining;
                PForRemaining = _PForRemaining;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
