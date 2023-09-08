//PROJECT NAME: CSIAdmin
//CLASS NAME: BI_UpdateSite.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Admin
{
    public interface IBI_UpdateSite
    {
        (int? ReturnCode, string InforBar) BI_UpdateSiteSp(string DefSite,
        string InforBar);
    }

    public class BI_UpdateSite : IBI_UpdateSite
    {
        IApplicationDB appDB;

        public BI_UpdateSite(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public (int? ReturnCode, string InforBar) BI_UpdateSiteSp(string DefSite,
       string InforBar)
        {
            StringType _DefSite = DefSite;
            InfobarType _InforBar = InforBar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "BI_UpdateSiteSp";

                appDB.AddCommandParameter(cmd, "DefSite", _DefSite, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InforBar", _InforBar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                InforBar = _InforBar;

                return (Severity, InforBar);
            }
        }
    }
}