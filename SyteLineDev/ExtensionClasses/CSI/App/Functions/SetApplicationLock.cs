//PROJECT NAME: Data
//CLASS NAME: SetApplicationLock.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class SetApplicationLock : ISetApplicationLock
	{
		readonly IApplicationDB appDB;
		
		public SetApplicationLock(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SetApplicationLockSp(
			string Resource)
		{
			StringType _Resource = Resource;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SetApplicationLockSp";
				
				appDB.AddCommandParameter(cmd, "Resource", _Resource, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
