//PROJECT NAME: CSIMaterial
//CLASS NAME: ItemCheckShipSite.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IItemCheckShipSite
    {
        int ItemCheckShipSiteSp(ItemType Item,
                                ref InfobarType Infobar);
    }

    public class ItemCheckShipSite : IItemCheckShipSite
    {
        readonly IApplicationDB appDB;

        public ItemCheckShipSite(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ItemCheckShipSiteSp(ItemType Item,
                                       ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ItemCheckShipSiteSp";

                appDB.AddCommandParameter(cmd, "Item", Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
