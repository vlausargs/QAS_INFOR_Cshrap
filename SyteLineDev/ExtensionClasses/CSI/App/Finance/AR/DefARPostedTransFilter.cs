//PROJECT NAME: CSICustomer
//CLASS NAME: DefARPostedTransFilter.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.AR
{
    public interface IDefARPostedTransFilter
    {
        int DefARPostedTransFilterSp(StringType SiteQuery,
                                     ref StringType SiteFilterVar,
                                     ref InfobarType Infobar);
    }

    public class DefARPostedTransFilter : IDefARPostedTransFilter
    {
        readonly IApplicationDB appDB;

        public DefARPostedTransFilter(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int DefARPostedTransFilterSp(StringType SiteQuery,
                                            ref StringType SiteFilterVar,
                                            ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DefARPostedTransFilterSp";

                appDB.AddCommandParameter(cmd, "SiteQuery", SiteQuery, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SiteFilterVar", SiteFilterVar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
