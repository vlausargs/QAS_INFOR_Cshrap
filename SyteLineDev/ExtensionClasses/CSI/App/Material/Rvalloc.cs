//PROJECT NAME: CSIMaterial
//CLASS NAME: Rvalloc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IRvalloc
    {
        int RvallocSp(string Site,
                      string Whse,
                      string Item,
                      string Loc,
                      ref string PromptMsg,
                      ref string PromptButtons,
                      ref string Infobar);
    }

    public class Rvalloc : IRvalloc
    {
        readonly IApplicationDB appDB;

        public Rvalloc(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int RvallocSp(string Site,
                             string Whse,
                             string Item,
                             string Loc,
                             ref string PromptMsg,
                             ref string PromptButtons,
                             ref string Infobar)
        {
            SiteType _Site = Site;
            WhseType _Whse = Whse;
            ItemType _Item = Item;
            LocType _Loc = Loc;
            InfobarType _PromptMsg = PromptMsg;
            InfobarType _PromptButtons = PromptButtons;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "RvallocSp";

                appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                PromptMsg = _PromptMsg;
                PromptButtons = _PromptButtons;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
