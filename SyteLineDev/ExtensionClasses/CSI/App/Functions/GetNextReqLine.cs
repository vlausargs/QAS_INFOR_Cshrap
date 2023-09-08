//PROJECT NAME: Data
//CLASS NAME: GetNextReqLine.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetNextReqLine : IGetNextReqLine
	{
		readonly IApplicationDB appDB;
		
		public GetNextReqLine(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? ReqLine) GetNextReqLineSp(
			string ReqNum,
			int? ReqLine)
		{
			ReqNumType _ReqNum = ReqNum;
			ReqLineType _ReqLine = ReqLine;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetNextReqLineSp";
				
				appDB.AddCommandParameter(cmd, "ReqNum", _ReqNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReqLine", _ReqLine, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ReqLine = _ReqLine;
				
				return (Severity, ReqLine);
			}
		}
	}
}
