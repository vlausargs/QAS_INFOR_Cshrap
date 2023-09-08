//PROJECT NAME: Data
//CLASS NAME: EdiOutShschP.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EdiOutShschP : IEdiOutShschP
	{
		readonly IApplicationDB appDB;
		
		public EdiOutShschP(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? EdiOutShschPSp(
			decimal? ProcessId)
		{
			TokenType _ProcessId = ProcessId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EdiOutShschPSp";
				
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
