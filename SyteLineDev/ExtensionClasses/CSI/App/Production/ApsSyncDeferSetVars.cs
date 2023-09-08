//PROJECT NAME: CSIProduct
//CLASS NAME: ApsSyncDeferSetVars.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface IApsSyncDeferSetVars
    {
        int ApsSyncDeferSetVarsSp(ProcessIndType SET,
                                  ref InfobarType Infobar);
    }

    public class ApsSyncDeferSetVars : IApsSyncDeferSetVars
    {
        readonly IApplicationDB appDB;

        public ApsSyncDeferSetVars(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ApsSyncDeferSetVarsSp(ProcessIndType SET,
                                         ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ApsSyncDeferSetVarsSp";

                appDB.AddCommandParameter(cmd, "SET", SET, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
