//PROJECT NAME: CSIAdmin
//CLASS NAME: UnlockUser.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Admin
{
    public interface IUnlockUser
    {
        int UnlockUserSp(UsernameType Username,
                         ref InfobarType Infobar);
    }

    public class UnlockUser : IUnlockUser
    {
        IApplicationDB appDB;

        public UnlockUser(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int UnlockUserSp(UsernameType Username,
                                ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UnlockUserSp";

                appDB.AddCommandParameter(cmd, "Username", Username, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}