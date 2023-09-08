//PROJECT NAME: CSIFinance
//CLASS NAME: GetDefaultBankCode.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance
{
    public interface IGetDefaultBankCode
    {
        int GetDefaultBankCodeSp(ref BankCodeType BankCode);
    }

    public class GetDefaultBankCode : IGetDefaultBankCode
    {
        readonly IApplicationDB appDB;

        public GetDefaultBankCode(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int GetDefaultBankCodeSp(ref BankCodeType BankCode)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetDefaultBankCodeSp";

                appDB.AddCommandParameter(cmd, "BankCode", BankCode, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}