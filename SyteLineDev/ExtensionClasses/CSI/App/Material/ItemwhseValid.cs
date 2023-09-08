//PROJECT NAME: CSIMaterial
//CLASS NAME: ItemwhseValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IItemwhseValid
    {
        int ItemwhseValidSp(ref WhseType Whse,
                            ItemType Item,
                            ref InfobarType Infobar);
    }

    public class ItemwhseValid : IItemwhseValid
    {
        readonly IApplicationDB appDB;

        public ItemwhseValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ItemwhseValidSp(ref WhseType Whse,
                                   ItemType Item,
                                   ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ItemwhseValidSp";

                appDB.AddCommandParameter(cmd, "Whse", Whse, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Item", Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
