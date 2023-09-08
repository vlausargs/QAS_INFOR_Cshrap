//PROJECT NAME: CSIRFQ
//CLASS NAME: SSSRFQItemGenVendors.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.RFQ
{
    public interface ISSSRFQItemGenVendors
    {
        int SSSRFQItemGenVendorsSp(string RfqNum,
                                   int? RfqLine,
                                   string GenMethod,
                                   string LastRfqNum,
                                   int? LastRfqLine,
                                   string PSessionId,
                                   ref string Infobar);
    }

    public class SSSRFQItemGenVendors : ISSSRFQItemGenVendors
    {
        readonly IApplicationDB appDB;

        public SSSRFQItemGenVendors(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSRFQItemGenVendorsSp(string RfqNum,
                                          int? RfqLine,
                                          string GenMethod,
                                          string LastRfqNum,
                                          int? LastRfqLine,
                                          string PSessionId,
                                          ref string Infobar)
        {
            RFQNumType _RfqNum = RfqNum;
            RFQLineType _RfqLine = RfqLine;
            StringType _GenMethod = GenMethod;
            RFQNumType _LastRfqNum = LastRfqNum;
            RFQLineType _LastRfqLine = LastRfqLine;
            StringType _PSessionId = PSessionId;
            Infobar _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSRFQItemGenVendorsSp";

                appDB.AddCommandParameter(cmd, "RfqNum", _RfqNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RfqLine", _RfqLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "GenMethod", _GenMethod, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "LastRfqNum", _LastRfqNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "LastRfqLine", _LastRfqLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PSessionId", _PSessionId, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
