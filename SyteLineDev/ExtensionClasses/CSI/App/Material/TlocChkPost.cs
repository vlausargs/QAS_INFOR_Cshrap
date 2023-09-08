//PROJECT NAME: CSIMaterial
//CLASS NAME: TlocChkPost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface ITlocChkPost
    {
        int TlocChkPostSp(SiteType Site,
                          WhseType Whse,
                          ItemType Item,
                          LocType Loc,
                          ref InfobarType Infobar);
    }

    public class TlocChkPost : ITlocChkPost
    {
        readonly IApplicationDB appDB;

        public TlocChkPost(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int TlocChkPostSp(SiteType Site,
                                 WhseType Whse,
                                 ItemType Item,
                                 LocType Loc,
                                 ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TlocChkPostSp";

                appDB.AddCommandParameter(cmd, "Site", Site, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Whse", Whse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Item", Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Loc", Loc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
