//PROJECT NAME: CSIVendor
//CLASS NAME: AppmtExchRateLeave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
    public interface IAppmtExchRateLeave
    {
        int AppmtExchRateLeaveSp(string PaymentType,
                                 string PDomCurrCode,
                                 ref decimal? PDomCheckAmt,
                                 DateTime? PRecptDate,
                                 short? PCheckSeq,
                                 string PBankCode,
                                 string PVendNum,
                                 decimal? PExchRate,
                                 ref decimal? PForCheckAmt,
                                 ref decimal? PDomApplied,
                                 ref decimal? PForApplied,
                                 ref decimal? PDomRemaining,
                                 ref decimal? PForRemaining,
                                 ref string Infobar);
    }

    public class AppmtExchRateLeave : IAppmtExchRateLeave
    {
        readonly IApplicationDB appDB;

        public AppmtExchRateLeave(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int AppmtExchRateLeaveSp(string PaymentType,
                                        string PDomCurrCode,
                                        ref decimal? PDomCheckAmt,
                                        DateTime? PRecptDate,
                                        short? PCheckSeq,
                                        string PBankCode,
                                        string PVendNum,
                                        decimal? PExchRate,
                                        ref decimal? PForCheckAmt,
                                        ref decimal? PDomApplied,
                                        ref decimal? PForApplied,
                                        ref decimal? PDomRemaining,
                                        ref decimal? PForRemaining,
                                        ref string Infobar)
        {
            AppmtPayTypeType _PaymentType = PaymentType;
            CurrCodeType _PDomCurrCode = PDomCurrCode;
            AmountType _PDomCheckAmt = PDomCheckAmt;
            DateType _PRecptDate = PRecptDate;
            ApCheckSeqType _PCheckSeq = PCheckSeq;
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
                cmd.CommandText = "AppmtExchRateLeaveSp";

                appDB.AddCommandParameter(cmd, "PaymentType", _PaymentType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PDomCurrCode", _PDomCurrCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PDomCheckAmt", _PDomCheckAmt, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PRecptDate", _PRecptDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PCheckSeq", _PCheckSeq, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PBankCode", _PBankCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PExchRate", _PExchRate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PForCheckAmt", _PForCheckAmt, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PDomApplied", _PDomApplied, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PForApplied", _PForApplied, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PDomRemaining", _PDomRemaining, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PForRemaining", _PForRemaining, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                PDomCheckAmt = _PDomCheckAmt;
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
