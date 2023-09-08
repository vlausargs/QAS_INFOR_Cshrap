//PROJECT NAME: Data
//CLASS NAME: EdiProcessLog.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EdiProcessLog : IEdiProcessLog
	{
		readonly IApplicationDB appDB;
		
		public EdiProcessLog(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? EdiProcessLogSp(
			decimal? ProcessId,
			string PElement,
			string PMsgStack,
			int? PStdMsg,
			int? PDemandSide)
		{
			TokenType _ProcessId = ProcessId;
			InfobarType _PElement = PElement;
			InfobarType _PMsgStack = PMsgStack;
			FlagNyType _PStdMsg = PStdMsg;
			FlagNyType _PDemandSide = PDemandSide;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EdiProcessLogSp";
				
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PElement", _PElement, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMsgStack", _PMsgStack, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStdMsg", _PStdMsg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDemandSide", _PDemandSide, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
