//PROJECT NAME: CSIMaterial
//CLASS NAME: MrpSyncMpw.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IMrpSyncMpw
    {
        int MrpSyncMpwSp(RowPointerType SessionID,
                         ItemType PItem,
                         ref ListYesNoType DeleteMpw,
                         ref InfobarType PromptMsg,
                         ref InfobarType PromptButtons,
                         ref InfobarType Infobar);
    }

    public class MrpSyncMpw : IMrpSyncMpw
    {
        readonly IApplicationDB appDB;

        public MrpSyncMpw(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int MrpSyncMpwSp(RowPointerType SessionID,
                                ItemType PItem,
                                ref ListYesNoType DeleteMpw,
                                ref InfobarType PromptMsg,
                                ref InfobarType PromptButtons,
                                ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "MrpSyncMpwSp";

                appDB.AddCommandParameter(cmd, "SessionID", SessionID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PItem", PItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DeleteMpw", DeleteMpw, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptMsg", PromptMsg, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptButtons", PromptButtons, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
