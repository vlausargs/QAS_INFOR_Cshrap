//PROJECT NAME: CSIFinance
//CLASS NAME: GljousPre.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance
{
    public interface IGljousPre
    {
        int GljousPreSp(JournalIdType PId,
                        ref JournalSeqType PFromSeq,
                        ref JournalSeqType PToSeq,
                        ref JournalSeqType PFirstSeq,
                        ref JournalSeqType PStepSize,
                        ref InfobarType Infobar);
    }

    public class GljousPre : IGljousPre
    {
        readonly IApplicationDB appDB;

        public GljousPre(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int GljousPreSp(JournalIdType PId,
                               ref JournalSeqType PFromSeq,
                               ref JournalSeqType PToSeq,
                               ref JournalSeqType PFirstSeq,
                               ref JournalSeqType PStepSize,
                               ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GljousPreSp";

                appDB.AddCommandParameter(cmd, "PId", PId, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PFromSeq", PFromSeq, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PToSeq", PToSeq, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PFirstSeq", PFirstSeq, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PStepSize", PStepSize, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}