//PROJECT NAME: Data
//CLASS NAME: EdiInPovsnIn.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EdiInPovsnIn : IEdiInPovsnIn
	{
		readonly IApplicationDB appDB;
		
		public EdiInPovsnIn(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? EdiInPovsnInSp(
			int? ProcessId,
			string Username)
		{
			GenericNoType _ProcessId = ProcessId;
			UsernameType _Username = Username;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EdiInPovsnInSp";
				
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Username", _Username, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
