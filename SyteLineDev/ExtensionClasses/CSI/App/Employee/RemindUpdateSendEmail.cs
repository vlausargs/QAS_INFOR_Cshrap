//PROJECT NAME: CSIEmployee
//CLASS NAME: RemindUpdateSendEmail.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
    public interface IRemindUpdateSendEmail
    {
        int RemindUpdateSendEmailSp(ProcessManagerProcessIDType ProcessId,
                                    UsernameType UserName,
                                    ref Infobar Infobar);
    }

    public class RemindUpdateSendEmail : IRemindUpdateSendEmail
    {
        readonly IApplicationDB appDB;

        public RemindUpdateSendEmail(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int RemindUpdateSendEmailSp(ProcessManagerProcessIDType ProcessId,
                                           UsernameType UserName,
                                           ref Infobar Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "RemindUpdateSendEmailSp";

                appDB.AddCommandParameter(cmd, "ProcessId", ProcessId, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UserName", UserName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
