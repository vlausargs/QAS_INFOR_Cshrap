//PROJECT NAME: RFQ
//CLASS NAME: SSSRFQSendQuoteLine.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.RFQ
{
	public class SSSRFQSendQuoteLine : ISSSRFQSendQuoteLine
	{
		readonly IApplicationDB appDB;
		
		public SSSRFQSendQuoteLine(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSRFQSendQuoteLineSp(
			string RfqNum,
			int? RfqLine,
			int? RfqSeq,
			int? Preview)
		{
			RFQNumType _RfqNum = RfqNum;
			RFQLineType _RfqLine = RfqLine;
			RFQSeqType _RfqSeq = RfqSeq;
			ListYesNoType _Preview = Preview;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSRFQSendQuoteLineSp";
				
				appDB.AddCommandParameter(cmd, "RfqNum", _RfqNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RfqLine", _RfqLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RfqSeq", _RfqSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Preview", _Preview, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
