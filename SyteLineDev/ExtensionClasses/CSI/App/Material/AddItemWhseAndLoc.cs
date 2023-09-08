//PROJECT NAME: CSIMaterial
//CLASS NAME: AddItemWhseAndLoc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IAddItemWhseAndLoc
    {
        int AddItemWhseAndLocSp(ItemType Item,
                                WhseType Whse,
                                ref Infobar Infobar);
    }

    public class AddItemWhseAndLoc : IAddItemWhseAndLoc
    {
        readonly IApplicationDB appDB;

        public AddItemWhseAndLoc(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int AddItemWhseAndLocSp(ItemType Item,
                                       WhseType Whse,
                                       ref Infobar Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddItemWhseAndLocSp";

                appDB.AddCommandParameter(cmd, "Item", Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Whse", Whse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
