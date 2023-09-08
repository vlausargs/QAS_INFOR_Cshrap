//PROJECT NAME: CSIMaterial
//CLASS NAME: ItemwhseWithNameValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IItemwhseWithNameValid
    {
        int ItemwhseWithNameValidSp(ref WhseType Whse,
                                    ItemType Item,
                                    ref NameType Name,
                                    ref InfobarType Infobar);
    }

    public class ItemwhseWithNameValid : IItemwhseWithNameValid
    {
        readonly IApplicationDB appDB;

        public ItemwhseWithNameValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ItemwhseWithNameValidSp(ref WhseType Whse,
                                           ItemType Item,
                                           ref NameType Name,
                                           ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ItemwhseWithNameValidSp";

                appDB.AddCommandParameter(cmd, "Whse", Whse, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Item", Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Name", Name, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
