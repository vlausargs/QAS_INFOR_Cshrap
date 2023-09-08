//PROJECT NAME: CSIFinance
//CLASS NAME: GetSiteInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance
{
    public interface IGetSiteInfo
    {
        int GetSiteInfoSp(ref SiteType SiteType,
                          ref SiteType SiteReportsTo,
                          ref ListSiteEntityType SiteReportsToType,
                          ref ListYesNoType SiteAnalyticalLedger);
    }

    public class GetSiteInfo : IGetSiteInfo
    {
        readonly IApplicationDB appDB;

        public GetSiteInfo(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int GetSiteInfoSp(ref SiteType SiteType,
                                 ref SiteType SiteReportsTo,
                                 ref ListSiteEntityType SiteReportsToType,
                                 ref ListYesNoType SiteAnalyticalLedger)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetSiteInfoSp";

                appDB.AddCommandParameter(cmd, "SiteType", SiteType, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "SiteReportsTo", SiteReportsTo, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "SiteReportsToType", SiteReportsToType, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "SiteAnalyticalLedger", SiteAnalyticalLedger, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
