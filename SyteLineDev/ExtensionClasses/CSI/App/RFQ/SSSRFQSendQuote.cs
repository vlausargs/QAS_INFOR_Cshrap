//PROJECT NAME: CSIRFQ
//CLASS NAME: SSSRFQSendQuote.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.RFQ
{
    public interface ISSSRFQSendQuote
    {
        DataTable SSSRFQSendQuoteSp(string RfqNum,
                                    int? RfqLine,
                                    int? RfqSeq,
                                    byte? Resend,
                                    string SelectedRFQNumLine);
    }

    public class SSSRFQSendQuote : ISSSRFQSendQuote
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public SSSRFQSendQuote(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable SSSRFQSendQuoteSp(string RfqNum,
                                           int? RfqLine,
                                           int? RfqSeq,
                                           byte? Resend,
                                           string SelectedRFQNumLine)
        {
            RFQNumType _RfqNum = RfqNum;
            RFQLineType _RfqLine = RfqLine;
            RFQSeqType _RfqSeq = RfqSeq;
            ListYesNoType _Resend = Resend;
            LongListType _SelectedRFQNumLine = SelectedRFQNumLine;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSRFQSendQuoteSp";

                appDB.AddCommandParameter(cmd, "RfqNum", _RfqNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RfqLine", _RfqLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RfqSeq", _RfqSeq, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Resend", _Resend, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SelectedRFQNumLine", _SelectedRFQNumLine, ParameterDirection.Input);

                dtReturn = appDB.ExecuteQuery(cmd);

                return dtReturn;
            }
        }
    }
}
