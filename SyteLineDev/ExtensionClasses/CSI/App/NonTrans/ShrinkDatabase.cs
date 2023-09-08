//PROJECT NAME: NonTrans
//CLASS NAME: ShrinkDatabase.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.NonTrans
{
	public class ShrinkDatabase : IShrinkDatabase
	{
		readonly IApplicationDB appDB;
		
		
		public ShrinkDatabase(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ShrinkDatabaseSp(string DatabaseName = null)
		{
			StringType _DatabaseName = DatabaseName;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ShrinkDatabaseSp";
				
				appDB.AddCommandParameter(cmd, "DatabaseName", _DatabaseName, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
