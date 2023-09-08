//PROJECT NAME: CSIAdmin
//CLASS NAME: CheckReadOnlyJournal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Admin
{
    public interface ICheckReadOnlyJournal
    {
        int CheckReadOnlyJournalSp(JournalIdType JournalID,
                                   ref ListYesNoType ReadOnly);
    }

    public class CheckReadOnlyJournal : ICheckReadOnlyJournal
    {
        IApplicationDB appDB;

        public CheckReadOnlyJournal(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CheckReadOnlyJournalSp(JournalIdType JournalID,
                                          ref ListYesNoType ReadOnly)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CheckReadOnlyJournalSp";

                appDB.AddCommandParameter(cmd, "JournalID", JournalID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ReadOnly", ReadOnly, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}