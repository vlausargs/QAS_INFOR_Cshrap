//PROJECT NAME: CSIFinance
//CLASS NAME: PRGetNextCheckNumber.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance
{
    public interface IPRGetNextCheckNumber
    {
        int PRGetNextCheckNumberSp(BankCodeType pBankCode,
                                   ref GlCheckNumType rNextCheckNumber);
    }

    public class PRGetNextCheckNumber : IPRGetNextCheckNumber
    {
        readonly IApplicationDB appDB;

        public PRGetNextCheckNumber(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int PRGetNextCheckNumberSp(BankCodeType pBankCode,
                                          ref GlCheckNumType rNextCheckNumber)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PRGetNextCheckNumberSp";

                appDB.AddCommandParameter(cmd, "pBankCode", pBankCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "rNextCheckNumber", rNextCheckNumber, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
