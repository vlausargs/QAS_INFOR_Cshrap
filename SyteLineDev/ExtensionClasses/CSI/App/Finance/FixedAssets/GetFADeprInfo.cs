//PROJECT NAME: CSIFinance
//CLASS NAME: GetFADeprInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.FixedAssets
{
    public interface IGetFADeprInfo
    {
        int GetFADeprInfoSp(FaNumType pFaNum,
                            ref ListYesNoType pFixedAssetDeprExist,
                            ref ListYesNoType pNotAllUnitAccumDeprIsZero);
    }

    public class GetFADeprInfo : IGetFADeprInfo
    {
        readonly IApplicationDB appDB;

        public GetFADeprInfo(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int GetFADeprInfoSp(FaNumType pFaNum,
                                   ref ListYesNoType pFixedAssetDeprExist,
                                   ref ListYesNoType pNotAllUnitAccumDeprIsZero)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetFADeprInfoSp";

                appDB.AddCommandParameter(cmd, "pFaNum", pFaNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pFixedAssetDeprExist", pFixedAssetDeprExist, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "pNotAllUnitAccumDeprIsZero", pNotAllUnitAccumDeprIsZero, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}