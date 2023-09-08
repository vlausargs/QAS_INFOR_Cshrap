//PROJECT NAME: CSIRFQ
//CLASS NAME: SSSRFQSendQuoteByVendorSent2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.RFQ
{
    public interface ISSSRFQSendQuoteByVendorSent2
    {
        int SSSRFQSendQuoteByVendorSent2Sp(string DistMethod,
                                           string SelectedRfqNumLine);
    }

    public class SSSRFQSendQuoteByVendorSent2 : ISSSRFQSendQuoteByVendorSent2
    {
        readonly IApplicationDB appDB;

        public SSSRFQSendQuoteByVendorSent2(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSRFQSendQuoteByVendorSent2Sp(string DistMethod,
                                                  string SelectedRfqNumLine)
        {
            RFQDistMethodType _DistMethod = DistMethod;
            LongListType _SelectedRfqNumLine = SelectedRfqNumLine;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSRFQSendQuoteByVendorSent2Sp";

                appDB.AddCommandParameter(cmd, "DistMethod", _DistMethod, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SelectedRfqNumLine", _SelectedRfqNumLine, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
