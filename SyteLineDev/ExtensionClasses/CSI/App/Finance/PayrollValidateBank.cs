//PROJECT NAME: CSIFinance
//CLASS NAME: PayrollValidateBank.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance
{
    public interface IPayrollValidateBank
    {
        int PayrollValidateBankSp(BankCodeType pBankCode,
                                  ref GlCheckNumType rNextCheckNumber,
                                  ref Infobar Infobar);
    }

    public class PayrollValidateBank : IPayrollValidateBank
    {
        readonly IApplicationDB appDB;

        public PayrollValidateBank(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int PayrollValidateBankSp(BankCodeType pBankCode,
                                         ref GlCheckNumType rNextCheckNumber,
                                         ref Infobar Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PayrollValidateBankSp";

                appDB.AddCommandParameter(cmd, "pBankCode", pBankCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "rNextCheckNumber", rNextCheckNumber, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}