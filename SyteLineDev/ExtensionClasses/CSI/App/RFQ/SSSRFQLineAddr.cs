//PROJECT NAME: RFQ
//CLASS NAME: SSSRFQLineAddr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.RFQ
{
	public class SSSRFQLineAddr : ISSSRFQLineAddr
	{
		readonly IApplicationDB appDB;
		
		public SSSRFQLineAddr(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string SSSRFQLineAddrFn(
			string RfqNum,
			int? RfqLine,
			int? RfqSeq)
		{
			RFQNumType _RfqNum = RfqNum;
			RFQLineType _RfqLine = RfqLine;
			RFQSeqType _RfqSeq = RfqSeq;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSRFQLineAddr](@RfqNum, @RfqLine, @RfqSeq)";
				
				appDB.AddCommandParameter(cmd, "RfqNum", _RfqNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RfqLine", _RfqLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RfqSeq", _RfqSeq, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
