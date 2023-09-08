//PROJECT NAME: CSIRFQ
//CLASS NAME: SSSRFQSendQuoteSent.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.RFQ
{
    public interface ISSSRFQSendQuoteSent
    {
        int SSSRFQSendQuoteSentSp(string RfqNum,
                                  int? RfqLine,
                                  int? RfqSeq,
                                  ref string Infobar);
    }

    public class SSSRFQSendQuoteSent : ISSSRFQSendQuoteSent
    {
        readonly IApplicationDB appDB;

        public SSSRFQSendQuoteSent(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSRFQSendQuoteSentSp(string RfqNum,
                                         int? RfqLine,
                                         int? RfqSeq,
                                         ref string Infobar)
        {
            RFQNumType _RfqNum = RfqNum;
            RFQLineType _RfqLine = RfqLine;
            RFQSeqType _RfqSeq = RfqSeq;
            Infobar _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSRFQSendQuoteSentSp";

                appDB.AddCommandParameter(cmd, "RfqNum", _RfqNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RfqLine", _RfqLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RfqSeq", _RfqSeq, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
