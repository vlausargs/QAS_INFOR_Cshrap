//PROJECT NAME: Data
//CLASS NAME: ApsTransferOutOrderId.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Data.Functions
{
    public class ApsTransferOutOrderId : IApsTransferOutOrderId
    {
        readonly IApplicationDB appDB;

        public ApsTransferOutOrderId(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public string ApsTransferOutOrderIdFn(
            string PTrnNum,
            int? PTrnLine)
        {
            TrnNumType _PTrnNum = PTrnNum;
            TrnLineType _PTrnLine = PTrnLine;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  dbo.[ApsTransferOutOrderId](@PTrnNum, @PTrnLine)";

                appDB.AddCommandParameter(cmd, "PTrnNum", _PTrnNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PTrnLine", _PTrnLine, ParameterDirection.Input);

                var Output = appDB.ExecuteScalar<string>(cmd);

                return Output;
            }
        }
    }
}
