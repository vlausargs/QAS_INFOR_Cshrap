//PROJECT NAME: CSIMaterial
//CLASS NAME: ItemLotExists.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IItemLotExists
    {
        int ItemLotExistsSp(ItemType Item,
                            ref InfobarType Infobar,
                            ref InfobarType PromptMsg,
                            ref Infobar PromptButtons);
    }

    public class ItemLotExists : IItemLotExists
    {
        readonly IApplicationDB appDB;

        public ItemLotExists(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ItemLotExistsSp(ItemType Item,
                                   ref InfobarType Infobar,
                                   ref InfobarType PromptMsg,
                                   ref Infobar PromptButtons)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ItemLotExistsSp";

                appDB.AddCommandParameter(cmd, "Item", Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptMsg", PromptMsg, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptButtons", PromptButtons, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
