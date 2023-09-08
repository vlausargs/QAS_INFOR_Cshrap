//PROJECT NAME: CSIFinance
//CLASS NAME: CheckNumValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.Bank
{
    public interface ICheckNumValid
    {
        int CheckNumValidSp(DraftNumType CheckNum,
                            GlbankTypeType BankReconciliationType,
                            BankCodeType BankCode,
                            CurrCodeType BankCurrCode,
                            ref AmountType Amount,
                            ref Infobar Infobar);
    }

    public class CheckNumValid : ICheckNumValid
    {
        readonly IApplicationDB appDB;

        public CheckNumValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CheckNumValidSp(DraftNumType CheckNum,
                                   GlbankTypeType BankReconciliationType,
                                   BankCodeType BankCode,
                                   CurrCodeType BankCurrCode,
                                   ref AmountType Amount,
                                   ref Infobar Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CheckNumValidSp";

                appDB.AddCommandParameter(cmd, "CheckNum", CheckNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BankReconciliationType", BankReconciliationType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BankCode", BankCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BankCurrCode", BankCurrCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Amount", Amount, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
