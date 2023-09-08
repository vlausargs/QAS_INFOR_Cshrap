//PROJECT NAME: CSIMaterial
//CLASS NAME: ItemNew.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IItemNew
    {
        int ItemNewSp(ItemType Item,
                      ref DescriptionType ItemDescription,
                      ref UMType ItemUM);
    }

    public class ItemNew : IItemNew
    {
        readonly IApplicationDB appDB;

        public ItemNew(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ItemNewSp(ItemType Item,
                             ref DescriptionType ItemDescription,
                             ref UMType ItemUM)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ItemNewSp";

                appDB.AddCommandParameter(cmd, "Item", Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ItemDescription", ItemDescription, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ItemUM", ItemUM, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
