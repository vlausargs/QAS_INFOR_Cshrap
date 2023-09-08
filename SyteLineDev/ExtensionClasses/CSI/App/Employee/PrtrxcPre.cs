//PROJECT NAME: CSIEmployee
//CLASS NAME: PrtrxcPre.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
    public interface IPrtrxcPre
    {
        int PrtrxcPreSp(ref InfobarType PromptMsg,
                        ref Infobar PromptButtons,
                        ref InfobarType Infobar);
    }

    public class PrtrxcPre : IPrtrxcPre
    {
        readonly IApplicationDB appDB;

        public PrtrxcPre(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int PrtrxcPreSp(ref InfobarType PromptMsg,
                               ref Infobar PromptButtons,
                               ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PrtrxcPreSp";

                appDB.AddCommandParameter(cmd, "PromptMsg", PromptMsg, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptButtons", PromptButtons, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
