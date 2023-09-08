//PROJECT NAME: CSIRFQ
//CLASS NAME: SSSRFQPOCreateFromOne.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.RFQ
{
    public interface ISSSRFQPOCreateFromOne
    {
        int SSSRFQPOCreateFromOneSp(string RFQNum,
                                    int? RFQLine,
                                    ref string Infobar);
    }

    public class SSSRFQPOCreateFromOne : ISSSRFQPOCreateFromOne
    {
        readonly IApplicationDB appDB;

        public SSSRFQPOCreateFromOne(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSRFQPOCreateFromOneSp(string RFQNum,
                                           int? RFQLine,
                                           ref string Infobar)
        {
            RFQNumType _RFQNum = RFQNum;
            RFQLineType _RFQLine = RFQLine;
            Infobar _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSRFQPOCreateFromOneSp";

                appDB.AddCommandParameter(cmd, "RFQNum", _RFQNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RFQLine", _RFQLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
