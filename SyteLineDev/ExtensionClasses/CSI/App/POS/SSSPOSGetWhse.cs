//PROJECT NAME: CSIPOS
//CLASS NAME: SSSPOSGetWhse.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.POS
{
    public interface ISSSPOSGetWhse
    {
        int SSSPOSGetWhseSp(string Drawer,
                            string UserName,
                            ref string Whse);
    }

    public class SSSPOSGetWhse : ISSSPOSGetWhse
    {
        readonly IApplicationDB appDB;

        public SSSPOSGetWhse(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSPOSGetWhseSp(string Drawer,
                                   string UserName,
                                   ref string Whse)
        {
            POSMDrawerType _Drawer = Drawer;
            UsernameType _UserName = UserName;
            WhseType _Whse = Whse;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSPOSGetWhseSp";

                appDB.AddCommandParameter(cmd, "Drawer", _Drawer, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UserName", _UserName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Whse = _Whse;

                return Severity;
            }
        }
    }
}
