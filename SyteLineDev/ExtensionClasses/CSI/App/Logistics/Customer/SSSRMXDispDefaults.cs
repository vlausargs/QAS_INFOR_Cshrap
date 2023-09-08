//PROJECT NAME: CSICustomer
//CLASS NAME: SSSRMXDispDefaults.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface ISSSRMXDispDefaults
    {
        int SSSRMXDispDefaultsSp(ref string DefWhse,
                                 ref string DefRmxWhse,
                                 ref string DefRmxLoc,
                                 ref string Infobar);
    }

    public class SSSRMXDispDefaults : ISSSRMXDispDefaults
    {
        readonly IApplicationDB appDB;

        public SSSRMXDispDefaults(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSRMXDispDefaultsSp(ref string DefWhse,
                                        ref string DefRmxWhse,
                                        ref string DefRmxLoc,
                                        ref string Infobar)
        {
            WhseType _DefWhse = DefWhse;
            WhseType _DefRmxWhse = DefRmxWhse;
            LocType _DefRmxLoc = DefRmxLoc;
            Infobar _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSRMXDispDefaultsSp";

                appDB.AddCommandParameter(cmd, "DefWhse", _DefWhse, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "DefRmxWhse", _DefRmxWhse, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "DefRmxLoc", _DefRmxLoc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                DefWhse = _DefWhse;
                DefRmxWhse = _DefRmxWhse;
                DefRmxLoc = _DefRmxLoc;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
