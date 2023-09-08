//PROJECT NAME: Data
//CLASS NAME: EdiInAutoPostEdiCo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EdiInAutoPostEdiCo : IEdiInAutoPostEdiCo
	{
		readonly IApplicationDB appDB;
		
		public EdiInAutoPostEdiCo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? EdiInAutoPostEdiCoSp(
			decimal? ProcessId,
			string Username)
		{
			TokenType _ProcessId = ProcessId;
			UsernameType _Username = Username;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EdiInAutoPostEdiCoSp";
				
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Username", _Username, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
