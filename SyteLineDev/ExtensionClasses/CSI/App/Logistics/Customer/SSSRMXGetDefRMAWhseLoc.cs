//PROJECT NAME: CSICustomer
//CLASS NAME: SSSRMXGetDefRMAWhseLoc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface ISSSRMXGetDefRMAWhseLoc
    {
        int SSSRMXGetDefRMAWhseLocSp(ref string Whse,
                                     ref string Loc,
                                     ref string Infobar);
    }

    public class SSSRMXGetDefRMAWhseLoc : ISSSRMXGetDefRMAWhseLoc
    {
        readonly IApplicationDB appDB;

        public SSSRMXGetDefRMAWhseLoc(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSRMXGetDefRMAWhseLocSp(ref string Whse,
                                            ref string Loc,
                                            ref string Infobar)
        {
            WhseType _Whse = Whse;
            LocType _Loc = Loc;
            Infobar _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSRMXGetDefRMAWhseLocSp";

                appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Whse = _Whse;
                Loc = _Loc;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
