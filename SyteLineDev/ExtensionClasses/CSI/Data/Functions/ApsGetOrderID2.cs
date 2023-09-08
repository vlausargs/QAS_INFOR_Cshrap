//PROJECT NAME: Data
//CLASS NAME: ApsGetOrderID2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Data.Functions
{
    public class ApsGetOrderID2 : IApsGetOrderID2
    {
        readonly IApplicationDB appDB;

        public ApsGetOrderID2(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public string ApsGetOrderID2Fn(
            string DemandType,
            string DemandRef)
        {
            RefType _DemandType = DemandType;
            ApsOrderType _DemandRef = DemandRef;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  dbo.[ApsGetOrderID2](@DemandType, @DemandRef)";

                appDB.AddCommandParameter(cmd, "DemandType", _DemandType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DemandRef", _DemandRef, ParameterDirection.Input);

                var Output = appDB.ExecuteScalar<string>(cmd);

                return Output;
            }
        }
    }
}
