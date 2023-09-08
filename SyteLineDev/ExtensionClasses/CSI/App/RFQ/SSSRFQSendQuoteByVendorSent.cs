//PROJECT NAME: RFQ
//CLASS NAME: SSSRFQSendQuoteByVendorSent.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.RFQ
{
	public class SSSRFQSendQuoteByVendorSent : ISSSRFQSendQuoteByVendorSent
	{
		readonly IApplicationDB appDB;
		
		
		public SSSRFQSendQuoteByVendorSent(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SSSRFQSendQuoteByVendorSentSp(string RfqNum,
		int? RfqLine,
		int? RfqSeq,
		string DistMethod,
		string Infobar)
		{
			RFQNumType _RfqNum = RfqNum;
			RFQLineType _RfqLine = RfqLine;
			RFQSeqType _RfqSeq = RfqSeq;
			RFQDistMethodType _DistMethod = DistMethod;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSRFQSendQuoteByVendorSentSp";
				
				appDB.AddCommandParameter(cmd, "RfqNum", _RfqNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RfqLine", _RfqLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RfqSeq", _RfqSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DistMethod", _DistMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
