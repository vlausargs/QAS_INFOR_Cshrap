//PROJECT NAME: CSIMaterial
//CLASS NAME: TlocChk.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface ITlocChk
    {
        int TlocChkSp(SiteType Site,
                      WhseType Whse,
                      ItemType Item,
                      LocType Loc,
                      ref InfobarType PromptMsg,
                      ref InfobarType PromptButtons,
                      ref InfobarType Infobar);
    }

    public class TlocChk : ITlocChk
    {
        readonly IApplicationDB appDB;

        public TlocChk(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int TlocChkSp(SiteType Site,
                             WhseType Whse,
                             ItemType Item,
                             LocType Loc,
                             ref InfobarType PromptMsg,
                             ref InfobarType PromptButtons,
                             ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TlocChkSp";

                appDB.AddCommandParameter(cmd, "Site", Site, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Whse", Whse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Item", Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Loc", Loc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PromptMsg", PromptMsg, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptButtons", PromptButtons, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
