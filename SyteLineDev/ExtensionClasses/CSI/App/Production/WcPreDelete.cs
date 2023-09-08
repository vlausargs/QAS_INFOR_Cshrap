//PROJECT NAME: CSIProduct
//CLASS NAME: WcPreDelete.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface IWcPreDelete
    {
        int WcPreDeleteSp(string PWc,
                          ref string Infobar);
    }

    public class WcPreDelete : IWcPreDelete
    {
        readonly IApplicationDB appDB;

        public WcPreDelete(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int WcPreDeleteSp(string PWc,
                                 ref string Infobar)
        {
            WcType _PWc = PWc;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "WcPreDeleteSp";

                appDB.AddCommandParameter(cmd, "PWc", _PWc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
