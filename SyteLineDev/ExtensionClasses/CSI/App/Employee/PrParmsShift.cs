//PROJECT NAME: CSIEmployee
//CLASS NAME: PrParmsShift.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
    public interface IPrParmsShift
    {
        int PrParmsShiftSp(ref ListYesNoType Prompted,
                           ref InfobarType PromptMsg,
                           ref Infobar PromptButtons,
                           ref InfobarType Infobar);
    }

    public class PrParmsShift : IPrParmsShift
    {
        readonly IApplicationDB appDB;

        public PrParmsShift(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int PrParmsShiftSp(ref ListYesNoType Prompted,
                                  ref InfobarType PromptMsg,
                                  ref Infobar PromptButtons,
                                  ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PrParmsShiftSp";

                appDB.AddCommandParameter(cmd, "Prompted", Prompted, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptMsg", PromptMsg, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptButtons", PromptButtons, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
