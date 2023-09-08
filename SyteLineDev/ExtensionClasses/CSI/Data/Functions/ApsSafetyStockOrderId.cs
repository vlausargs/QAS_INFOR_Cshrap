//PROJECT NAME: Data
//CLASS NAME: ApsSafetyStockOrderId.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Data.Functions
{
    public class ApsSafetyStockOrderId : IApsSafetyStockOrderId
    {
        readonly IApplicationDB appDB;

        public ApsSafetyStockOrderId(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public string ApsSafetyStockOrderIdFn(
            string PItem,
            string PWhse)
        {
            ItemType _PItem = PItem;
            WhseType _PWhse = PWhse;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  dbo.[ApsSafetyStockOrderId](@PItem, @PWhse)";

                appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PWhse", _PWhse, ParameterDirection.Input);

                var Output = appDB.ExecuteScalar<string>(cmd);

                return Output;
            }
        }
    }
}
