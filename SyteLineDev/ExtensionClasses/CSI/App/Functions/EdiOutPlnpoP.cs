//PROJECT NAME: Data
//CLASS NAME: EdiOutPlnpoP.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EdiOutPlnpoP : IEdiOutPlnpoP
	{
		readonly IApplicationDB appDB;
		
		public EdiOutPlnpoP(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? EdiOutPlnpoPSp(
			decimal? ProcessId)
		{
			TokenType _ProcessId = ProcessId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EdiOutPlnpoPSp";
				
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
