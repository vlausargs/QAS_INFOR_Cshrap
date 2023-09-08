//PROJECT NAME: CSIFinance
//CLASS NAME: IsExecutiveHomeSiteGroupValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance
{
    public interface IIsExecutiveHomeSiteGroupValid
    {
        int IsExecutiveHomeSiteGroupValidSp(ref SiteGroupType SiteGroup,
                                            ref InfobarType SiteList,
                                            ref InfobarType Infobar);
    }

    public class IsExecutiveHomeSiteGroupValid : IIsExecutiveHomeSiteGroupValid
    {
        readonly IApplicationDB appDB;

        public IsExecutiveHomeSiteGroupValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int IsExecutiveHomeSiteGroupValidSp(ref SiteGroupType SiteGroup,
                                                   ref InfobarType SiteList,
                                                   ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "IsExecutiveHomeSiteGroupValidSp";

                appDB.AddCommandParameter(cmd, "SiteGroup", SiteGroup, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "SiteList", SiteList, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}