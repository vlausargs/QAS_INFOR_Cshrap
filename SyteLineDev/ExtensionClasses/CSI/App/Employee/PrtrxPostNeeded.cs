//PROJECT NAME: CSIEmployee
//CLASS NAME: PrtrxPostNeeded.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
    public interface IPrtrxPostNeeded
    {
        int PrtrxPostNeededSp(RowPointerType PSessionID,
                              ref FlagNyType RPostNeeded,
                              ref InfobarType Infobar);
    }

    public class PrtrxPostNeeded : IPrtrxPostNeeded
    {
        readonly IApplicationDB appDB;

        public PrtrxPostNeeded(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int PrtrxPostNeededSp(RowPointerType PSessionID,
                                     ref FlagNyType RPostNeeded,
                                     ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PrtrxPostNeededSp";

                appDB.AddCommandParameter(cmd, "PSessionID", PSessionID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RPostNeeded", RPostNeeded, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
