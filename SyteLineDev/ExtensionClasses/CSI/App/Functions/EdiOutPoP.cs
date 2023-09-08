//PROJECT NAME: Data
//CLASS NAME: EdiOutPoP.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EdiOutPoP : IEdiOutPoP
	{
		readonly IApplicationDB appDB;
		
		public EdiOutPoP(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? EdiOutPoPSp(
			decimal? ProcessId)
		{
			TokenType _ProcessId = ProcessId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EdiOutPoPSp";
				
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
