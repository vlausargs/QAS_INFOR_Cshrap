//PROJECT NAME: Data
//CLASS NAME: GetCostCode.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Data.Functions
{
    public class GetCostCode : IGetCostCode
    {
        readonly IApplicationDB appDB;

        public GetCostCode(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public string GetCostCodeFn(
            string Item = null)
        {
            ItemType _Item = Item;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  dbo.[GetCostCode](@Item)";

                appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);

                var Output = appDB.ExecuteScalar<string>(cmd);

                return Output;
            }
        }
    }
}
