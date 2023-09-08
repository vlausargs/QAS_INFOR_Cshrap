//PROJECT NAME: Data
//CLASS NAME: DetachAttachDatabases.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class DetachAttachDatabases : IDetachAttachDatabases
	{
		readonly IApplicationDB appDB;
		
		public DetachAttachDatabases(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? DetachAttachDatabasesSp(
			string DbName,
			int? Drop = 1,
			int? Attach = 1)
		{
			StringType _DbName = DbName;
			IntType _Drop = Drop;
			IntType _Attach = Attach;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DetachAttachDatabasesSp";
				
				appDB.AddCommandParameter(cmd, "DbName", _DbName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Drop", _Drop, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Attach", _Attach, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
