//PROJECT NAME: CSICustomer
//CLASS NAME: ArpmtLeavePayToCustAmt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.AR
{
    public interface IArpmtLeavePayToCustAmt
    {
        int ArpmtLeavePayToCustAmtSp(CurrCodeType PFromCurrCode,
                                     CurrCodeType PToCurrCode,
                                     CurrCodeType DomCurrCode,
                                     ref AmountType PToCheckAmt,
                                     DateType PRecptDate,
                                     ArCheckNumType PCheckNum,
                                     BankCodeType PBankCode,
                                     CustNumType PCustNum,
                                     ArpmtTypeType PType,
                                     InvNumType PCreditMemoNum,
                                     ref ExchRateType PExchRate,
                                     AmountType PFromCheckAmt,
                                     ref AmountType PToApplied,
                                     ref AmountType PFromApplied,
                                     AmountType DomApplied,
                                     ref AmountType PToRemaining,
                                     ref AmountType PFromRemaining,
                                     ref InfobarType Infobar);
    }

    public class ArpmtLeavePayToCustAmt : IArpmtLeavePayToCustAmt
    {
        readonly IApplicationDB appDB;

        public ArpmtLeavePayToCustAmt(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ArpmtLeavePayToCustAmtSp(CurrCodeType PFromCurrCode,
                                            CurrCodeType PToCurrCode,
                                            CurrCodeType DomCurrCode,
                                            ref AmountType PToCheckAmt,
                                            DateType PRecptDate,
                                            ArCheckNumType PCheckNum,
                                            BankCodeType PBankCode,
                                            CustNumType PCustNum,
                                            ArpmtTypeType PType,
                                            InvNumType PCreditMemoNum,
                                            ref ExchRateType PExchRate,
                                            AmountType PFromCheckAmt,
                                            ref AmountType PToApplied,
                                            ref AmountType PFromApplied,
                                            AmountType DomApplied,
                                            ref AmountType PToRemaining,
                                            ref AmountType PFromRemaining,
                                            ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ArpmtLeavePayToCustAmtSp";

                appDB.AddCommandParameter(cmd, "PFromCurrCode", PFromCurrCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PToCurrCode", PToCurrCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DomCurrCode", DomCurrCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PToCheckAmt", PToCheckAmt, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PRecptDate", PRecptDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PCheckNum", PCheckNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PBankCode", PBankCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PCustNum", PCustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PType", PType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PCreditMemoNum", PCreditMemoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PExchRate", PExchRate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PFromCheckAmt", PFromCheckAmt, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PToApplied", PToApplied, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PFromApplied", PFromApplied, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "DomApplied", DomApplied, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PToRemaining", PToRemaining, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PFromRemaining", PFromRemaining, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
