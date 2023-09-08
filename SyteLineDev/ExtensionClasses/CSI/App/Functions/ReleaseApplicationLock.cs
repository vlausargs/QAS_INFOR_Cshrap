//PROJECT NAME: Data
//CLASS NAME: ReleaseApplicationLock.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ReleaseApplicationLock : IReleaseApplicationLock
	{
		readonly IApplicationDB appDB;
		
		public ReleaseApplicationLock(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ReleaseApplicationLockSp(
			string Resource)
		{
			StringType _Resource = Resource;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ReleaseApplicationLockSp";
				
				appDB.AddCommandParameter(cmd, "Resource", _Resource, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
