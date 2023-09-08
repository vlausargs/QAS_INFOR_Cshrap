//PROJECT NAME: CSIMaterial
//CLASS NAME: GetTransferFobSite.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IGetTransferFobSite
    {
        int GetTransferFobSiteSp(SiteType FromSite,
                                 SiteType ToSite,
                                 ref SiteType FobSite,
                                 ref ExchRateType ExchRate);
    }

    public class GetTransferFobSite : IGetTransferFobSite
    {
        readonly IApplicationDB appDB;

        public GetTransferFobSite(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int GetTransferFobSiteSp(SiteType FromSite,
                                        SiteType ToSite,
                                        ref SiteType FobSite,
                                        ref ExchRateType ExchRate)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetTransferFobSiteSp";

                appDB.AddCommandParameter(cmd, "FromSite", FromSite, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ToSite", ToSite, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FobSite", FobSite, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ExchRate", ExchRate, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
