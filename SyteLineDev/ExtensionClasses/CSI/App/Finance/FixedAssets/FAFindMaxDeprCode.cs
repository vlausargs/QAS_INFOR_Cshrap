//PROJECT NAME: CSIFinance
//CLASS NAME: FAFindMaxDeprCode.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.FixedAssets
{
    public interface IFAFindMaxDeprCode
    {
        int FAFindMaxDeprCodeSp(FaNumType AssetNumber,
                                ref IntType MaxDeprCode);
    }

    public class FAFindMaxDeprCode : IFAFindMaxDeprCode
    {
        readonly IApplicationDB appDB;

        public FAFindMaxDeprCode(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int FAFindMaxDeprCodeSp(FaNumType AssetNumber,
                                       ref IntType MaxDeprCode)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "FAFindMaxDeprCodeSp";

                appDB.AddCommandParameter(cmd, "AssetNumber", AssetNumber, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "MaxDeprCode", MaxDeprCode, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
