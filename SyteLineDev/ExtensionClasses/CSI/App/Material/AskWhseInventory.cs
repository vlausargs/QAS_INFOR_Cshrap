//PROJECT NAME: CSIMaterial
//CLASS NAME: AskWhseInventory.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IAskWhseInventory
    {
        int AskWhseInventorySp(ref InfobarType PromptMsg,
                               ref InfobarType PromptButtons,
                               ref InfobarType Infobar);
    }

    public class AskWhseInventory : IAskWhseInventory
    {
        readonly IApplicationDB appDB;

        public AskWhseInventory(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int AskWhseInventorySp(ref InfobarType PromptMsg,
                                      ref InfobarType PromptButtons,
                                      ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AskWhseInventorySp";

                appDB.AddCommandParameter(cmd, "PromptMsg", PromptMsg, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptButtons", PromptButtons, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
