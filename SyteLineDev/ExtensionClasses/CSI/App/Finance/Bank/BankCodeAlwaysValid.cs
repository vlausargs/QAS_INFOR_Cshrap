//PROJECT NAME: CSIFinance
//CLASS NAME: BankCodeAlwaysValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.Bank
{
    public interface IBankCodeAlwaysValid
    {
        int BankCodeAlwaysValidSp(BankCodeType BankCode,
                                  ref NameType BankName,
                                  ref Infobar Infobar);
    }

    public class BankCodeAlwaysValid : IBankCodeAlwaysValid
    {
        readonly IApplicationDB appDB;

        public BankCodeAlwaysValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int BankCodeAlwaysValidSp(BankCodeType BankCode,
                                         ref NameType BankName,
                                         ref Infobar Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "BankCodeAlwaysValidSp";

                appDB.AddCommandParameter(cmd, "BankCode", BankCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BankName", BankName, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
