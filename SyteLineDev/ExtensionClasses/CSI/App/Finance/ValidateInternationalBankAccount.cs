//PROJECT NAME: CSIFinance
//CLASS NAME: ValidateInternationalBankAccount.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance
{
    public interface IValidateInternationalBankAccount
    {
        int ValidateInternationalBankAccountSp(InternationalBankAccountType IBAN,
                                               ref InfobarType Infobar);
    }

    public class ValidateInternationalBankAccount : IValidateInternationalBankAccount
    {
        readonly IApplicationDB appDB;

        public ValidateInternationalBankAccount(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ValidateInternationalBankAccountSp(InternationalBankAccountType IBAN,
                                                      ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ValidateInternationalBankAccountSp";

                appDB.AddCommandParameter(cmd, "IBAN", IBAN, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
