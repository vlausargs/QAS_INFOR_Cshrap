//PROJECT NAME: Data
//CLASS NAME: RebuildIndexes.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class RebuildIndexes : IRebuildIndexes
	{
		readonly IApplicationDB appDB;
		
		public RebuildIndexes(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? RebuildIndexesSp(
			string DatabaseName = null)
		{
			StringType _DatabaseName = DatabaseName;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RebuildIndexesSp";
				
				appDB.AddCommandParameter(cmd, "DatabaseName", _DatabaseName, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
