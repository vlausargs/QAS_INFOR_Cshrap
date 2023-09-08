//PROJECT NAME: Data
//CLASS NAME: TruncateDatabase.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class TruncateDatabase : ITruncateDatabase
	{
		readonly IApplicationDB appDB;
		
		public TruncateDatabase(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? TruncateDatabaseSp(
			string DbName)
		{
			StringType _DbName = DbName;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TruncateDatabaseSp";
				
				appDB.AddCommandParameter(cmd, "DbName", _DbName, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
