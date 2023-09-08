//PROJECT NAME: CSIAdmin
//CLASS NAME: DelJournalTx.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Admin
{
    public interface IDelJournalTx
    {
        int DelJournalTxSp(JournalIdType pJourHdrId,
                           ref Infobar Infobar);
    }

    public class DelJournalTx : IDelJournalTx
    {
        IApplicationDB appDB;

        public DelJournalTx(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int DelJournalTxSp(JournalIdType pJourHdrId,
                                  ref Infobar Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DelJournalTxSp";

                appDB.AddCommandParameter(cmd, "pJourHdrId", pJourHdrId, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
