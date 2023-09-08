//PROJECT NAME: Data
//CLASS NAME: DisallowPageLocks.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class DisallowPageLocks : IDisallowPageLocks
	{
		readonly IApplicationDB appDB;
		
		public DisallowPageLocks(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? DisallowPageLocksSp(
			string DatabaseName = null)
		{
			StringType _DatabaseName = DatabaseName;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DisallowPageLocksSp";
				
				appDB.AddCommandParameter(cmd, "DatabaseName", _DatabaseName, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
