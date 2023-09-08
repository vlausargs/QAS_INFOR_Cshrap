//PROJECT NAME: CSIMaterial
//CLASS NAME: GetSiteInvParmsInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IGetSiteInvParmsInfo
    {
        int GetSiteInvParmsInfoSp(SiteType Site,
                                  ref ListYesNoType TrackTaxFreeImports,
                                  ref CountryType Country);
    }

    public class GetSiteInvParmsInfo : IGetSiteInvParmsInfo
    {
        readonly IApplicationDB appDB;

        public GetSiteInvParmsInfo(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int GetSiteInvParmsInfoSp(SiteType Site,
                                         ref ListYesNoType TrackTaxFreeImports,
                                         ref CountryType Country)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetSiteInvParmsInfoSp";

                appDB.AddCommandParameter(cmd, "Site", Site, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TrackTaxFreeImports", TrackTaxFreeImports, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Country", Country, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
