//PROJECT NAME: CSIMaterial
//CLASS NAME: ItemUMCheck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IItemUMCheck
    {
        int ItemUMCheckSp(ItemType Item,
                          UMType UM,
                          ref InfobarType Infobar);
    }

    public class ItemUMCheck : IItemUMCheck
    {
        readonly IApplicationDB appDB;

        public ItemUMCheck(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ItemUMCheckSp(ItemType Item,
                                 UMType UM,
                                 ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ItemUMCheckSp";

                appDB.AddCommandParameter(cmd, "Item", Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UM", UM, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
