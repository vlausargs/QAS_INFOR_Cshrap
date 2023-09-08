//PROJECT NAME: Data
//CLASS NAME: CopyDatabases.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CopyDatabases : ICopyDatabases
	{
		readonly IApplicationDB appDB;
		
		public CopyDatabases(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CopyDatabasesSp(
			string DbName,
			string Dest)
		{
			StringType _DbName = DbName;
			StringType _Dest = Dest;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CopyDatabasesSp";
				
				appDB.AddCommandParameter(cmd, "DbName", _DbName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Dest", _Dest, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
