//PROJECT NAME: Data
//CLASS NAME: ApsOrderId.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Data.Functions
{
    public class ApsOrderId : IApsOrderId
    {
        readonly IApplicationDB appDB;

        public ApsOrderId(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public string ApsOrderIdFn(
            string POrder,
            int? PLine,
            int? PRelease)
        {
            CoNumType _POrder = POrder;
            CoLineType _PLine = PLine;
            CoReleaseType _PRelease = PRelease;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  dbo.[ApsOrderId](@POrder, @PLine, @PRelease)";

                appDB.AddCommandParameter(cmd, "POrder", _POrder, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PLine", _PLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PRelease", _PRelease, ParameterDirection.Input);

                var Output = appDB.ExecuteScalar<string>(cmd);

                return Output;
            }
        }

        public int? ApsOrderIdSp()
        {

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ApsOrderIdSp";

                var Severity = appDB.ExecuteNonQuery(cmd);

                return (Severity);
            }
        }
    }
}
