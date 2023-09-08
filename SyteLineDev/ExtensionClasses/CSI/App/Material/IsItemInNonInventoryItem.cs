//PROJECT NAME: CSIMaterial
//CLASS NAME: IsItemInNonInventoryItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IIsItemInNonInventoryItem
    {
        int IsItemInNonInventoryItemSp(ItemType Item,
                                       ref ListYesNoType ExistsInNonInventoryItem,
                                       ref InfobarType Infobar);
    }

    public class IsItemInNonInventoryItem : IIsItemInNonInventoryItem
    {
        readonly IApplicationDB appDB;

        public IsItemInNonInventoryItem(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int IsItemInNonInventoryItemSp(ItemType Item,
                                              ref ListYesNoType ExistsInNonInventoryItem,
                                              ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "IsItemInNonInventoryItemSp";

                appDB.AddCommandParameter(cmd, "Item", Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExistsInNonInventoryItem", ExistsInNonInventoryItem, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
