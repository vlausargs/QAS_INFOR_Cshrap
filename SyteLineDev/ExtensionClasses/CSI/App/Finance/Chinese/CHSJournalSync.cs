//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSJournalSync.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.Chinese
{
    public interface ICHSJournalSync
    {
        int CHSJournalSyncSp(JournalIdType Id,
                             DateType TransDate,
                             UsernameType UserName,
                             ref InfobarType InfoBar);
    }

    public class CHSJournalSync : ICHSJournalSync
    {
        readonly IApplicationDB appDB;

        public CHSJournalSync(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CHSJournalSyncSp(JournalIdType Id,
                                    DateType TransDate,
                                    UsernameType UserName,
                                    ref InfobarType InfoBar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CHSJournalSyncSp";

                appDB.AddCommandParameter(cmd, "Id", Id, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TransDate", TransDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UserName", UserName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InfoBar", InfoBar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}

