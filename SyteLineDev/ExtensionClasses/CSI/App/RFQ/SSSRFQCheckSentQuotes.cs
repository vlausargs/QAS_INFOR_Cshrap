//PROJECT NAME: RFQ
//CLASS NAME: SSSRFQCheckSentQuotes.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.RFQ
{
	public interface ISSSRFQCheckSentQuotes
	{
		(int? ReturnCode, byte? NoneToSend, string Infobar) SSSRFQCheckSentQuotesSp(string RFQ,
		int? RFQLine,
		byte? NoneToSend,
		string Infobar,
		int? RFQSeq = null);
	}
	
	public class SSSRFQCheckSentQuotes : ISSSRFQCheckSentQuotes
	{
		readonly IApplicationDB appDB;
		
		public SSSRFQCheckSentQuotes(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, byte? NoneToSend, string Infobar) SSSRFQCheckSentQuotesSp(string RFQ,
		int? RFQLine,
		byte? NoneToSend,
		string Infobar,
		int? RFQSeq = null)
		{
			RFQNumType _RFQ = RFQ;
			RFQLineType _RFQLine = RFQLine;
			ListYesNoType _NoneToSend = NoneToSend;
			Infobar _Infobar = Infobar;
			RFQSeqType _RFQSeq = RFQSeq;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSRFQCheckSentQuotesSp";
				
				appDB.AddCommandParameter(cmd, "RFQ", _RFQ, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RFQLine", _RFQLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NoneToSend", _NoneToSend, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RFQSeq", _RFQSeq, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				NoneToSend = _NoneToSend;
				Infobar = _Infobar;
				
				return (Severity, NoneToSend, Infobar);
			}
		}
	}
}
