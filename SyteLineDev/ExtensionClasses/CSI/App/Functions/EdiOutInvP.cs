//PROJECT NAME: Data
//CLASS NAME: EdiOutInvP.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EdiOutInvP : IEdiOutInvP
	{
		readonly IApplicationDB appDB;
		
		public EdiOutInvP(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? EdiOutInvPSp(
			decimal? ProcessId)
		{
			TokenType _ProcessId = ProcessId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EdiOutInvPSp";
				
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
