//PROJECT NAME: CSIVendor
//CLASS NAME: Appmtg.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
    public interface IAppmtg
    {
        int AppmtgSp(ref string Infobar);
    }

    public class Appmtg : IAppmtg
    {
        readonly IApplicationDB appDB;

        public Appmtg(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int AppmtgSp(ref string Infobar)
        {
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AppmtgSp";

                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
