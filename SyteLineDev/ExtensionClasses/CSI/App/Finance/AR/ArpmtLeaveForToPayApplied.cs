//PROJECT NAME: CSICustomer
//CLASS NAME: ArpmtLeaveForToPayApplied.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.AR
{
    public interface IArpmtLeaveForToPayApplied
    {
        int ArpmtLeaveForToPayAppliedSp(CurrCodeType PayCurrCode,
                                        CurrCodeType BankCurrCode,
                                        CurrCodeType DomCurrCode,
                                        AmountType PayCheckAmt,
                                        DateType RecptDate,
                                        ExchRateType PayExchRate,
                                        ref AmountType PayApplied,
                                        AmountType ForApplied,
                                        AmountType DomApplied,
                                        ref AmountType PayRemaining,
                                        ref InfobarType Infobar);
    }

    public class ArpmtLeaveForToPayApplied : IArpmtLeaveForToPayApplied
    {
        readonly IApplicationDB appDB;

        public ArpmtLeaveForToPayApplied(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ArpmtLeaveForToPayAppliedSp(CurrCodeType PayCurrCode,
                                               CurrCodeType BankCurrCode,
                                               CurrCodeType DomCurrCode,
                                               AmountType PayCheckAmt,
                                               DateType RecptDate,
                                               ExchRateType PayExchRate,
                                               ref AmountType PayApplied,
                                               AmountType ForApplied,
                                               AmountType DomApplied,
                                               ref AmountType PayRemaining,
                                               ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ArpmtLeaveForToPayAppliedSp";

                appDB.AddCommandParameter(cmd, "PayCurrCode", PayCurrCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BankCurrCode", BankCurrCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DomCurrCode", DomCurrCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PayCheckAmt", PayCheckAmt, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RecptDate", RecptDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PayExchRate", PayExchRate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PayApplied", PayApplied, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ForApplied", ForApplied, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DomApplied", DomApplied, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PayRemaining", PayRemaining, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
