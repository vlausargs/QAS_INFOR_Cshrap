//PROJECT NAME: CSIMaterial
//CLASS NAME: GetQtyOnHand.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IGetQtyOnHand
    {
        int GetQtyOnHandSp(ItemType item,
                           WhseType whse,
                           ref QtyTotlType QtyOnHand);
    }

    public class GetQtyOnHand : IGetQtyOnHand
    {
        readonly IApplicationDB appDB;

        public GetQtyOnHand(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int GetQtyOnHandSp(ItemType item,
                                  WhseType whse,
                                  ref QtyTotlType QtyOnHand)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetQtyOnHandSp";

                appDB.AddCommandParameter(cmd, "item", item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "whse", whse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "QtyOnHand", QtyOnHand, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
