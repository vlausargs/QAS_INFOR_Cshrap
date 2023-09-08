//PROJECT NAME: CSIEmployee
//CLASS NAME: RemindAssigneeSendEmail.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
    public interface IRemindAssigneeSendEmail
    {
        int RemindAssigneeSendEmailSp(ProcessManagerProcessIDType ProcessId,
                                      ProcessManagerTaskNumType TaskNum,
                                      ref Infobar Infobar);
    }

    public class RemindAssigneeSendEmail : IRemindAssigneeSendEmail
    {
        readonly IApplicationDB appDB;

        public RemindAssigneeSendEmail(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int RemindAssigneeSendEmailSp(ProcessManagerProcessIDType ProcessId,
                                             ProcessManagerTaskNumType TaskNum,
                                             ref Infobar Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "RemindAssigneeSendEmailSp";

                appDB.AddCommandParameter(cmd, "ProcessId", ProcessId, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TaskNum", TaskNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
