//PROJECT NAME: CSIFinance
//CLASS NAME: GetNextJournalSeq.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance
{
    public interface IGetNextJournalSeq
    {
        int GetNextJournalSeqSp(JournalIdType JournalID,
                                ref JournalSeqType JournalSeq);
    }

    public class GetNextJournalSeq : IGetNextJournalSeq
    {
        readonly IApplicationDB appDB;

        public GetNextJournalSeq(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int GetNextJournalSeqSp(JournalIdType JournalID,
                                       ref JournalSeqType JournalSeq)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetNextJournalSeqSp";

                appDB.AddCommandParameter(cmd, "JournalID", JournalID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "JournalSeq", JournalSeq, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
