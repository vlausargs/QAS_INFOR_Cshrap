//PROJECT NAME: Data
//CLASS NAME: EdiOutAckP.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EdiOutAckP : IEdiOutAckP
	{
		readonly IApplicationDB appDB;
		
		public EdiOutAckP(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? EdiOutAckPSp(
			decimal? ProcessId)
		{
			TokenType _ProcessId = ProcessId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EdiOutAckPSp";
				
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
