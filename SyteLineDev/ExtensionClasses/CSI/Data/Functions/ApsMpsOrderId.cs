//PROJECT NAME: Data
//CLASS NAME: ApsMpsOrderId.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Data.Functions
{
    public class ApsMpsOrderId : IApsMpsOrderId
    {
        readonly IApplicationDB appDB;

        public ApsMpsOrderId(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public string ApsMpsOrderIdFn(
            string PItem,
            string PRefNum)
        {
            ItemType _PItem = PItem;
            UnknownRefNumLastTranType _PRefNum = PRefNum;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  dbo.[ApsMpsOrderId](@PItem, @PRefNum)";

                appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PRefNum", _PRefNum, ParameterDirection.Input);

                var Output = appDB.ExecuteScalar<string>(cmd);

                return Output;
            }
        }
    }
}
