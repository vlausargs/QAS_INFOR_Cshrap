//PROJECT NAME: CSIEmployee
//CLASS NAME: ValidateDirDepAccount.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
    public interface IValidateDirDepAccount
    {
        int ValidateDirDepAccountSp(EmpNumType EmpNum,
                                    BankNumType BankNum,
                                    BankAccountType DepAccount,
                                    EmpPrbankRankType Rank,
                                    ref InfobarType Infobar);
    }

    public class ValidateDirDepAccount : IValidateDirDepAccount
    {
        readonly IApplicationDB appDB;

        public ValidateDirDepAccount(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ValidateDirDepAccountSp(EmpNumType EmpNum,
                                           BankNumType BankNum,
                                           BankAccountType DepAccount,
                                           EmpPrbankRankType Rank,
                                           ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ValidateDirDepAccountSp";

                appDB.AddCommandParameter(cmd, "EmpNum", EmpNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BankNum", BankNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DepAccount", DepAccount, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Rank", Rank, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
