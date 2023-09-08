//PROJECT NAME: CSIEmployee
//CLASS NAME: InitProcessEmail.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
    public interface IInitProcessEmail
    {
        int InitProcessEmailSp(ProcessManagerProcessIDType Id,
                               ref Infobar Infobar);
    }

    public class InitProcessEmail : IInitProcessEmail
    {
        readonly IApplicationDB appDB;

        public InitProcessEmail(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int InitProcessEmailSp(ProcessManagerProcessIDType Id,
                                      ref Infobar Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InitProcessEmailSp";

                appDB.AddCommandParameter(cmd, "Id", Id, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
