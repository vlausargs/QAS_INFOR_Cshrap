//PROJECT NAME: Data
//CLASS NAME: DropTempTables.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class DropTempTables : IDropTempTables
	{
		readonly IApplicationDB appDB;
		
		public DropTempTables(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? DropTempTablesSp(
			string DatabaseName = null)
		{
			StringType _DatabaseName = DatabaseName;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DropTempTablesSp";
				
				appDB.AddCommandParameter(cmd, "DatabaseName", _DatabaseName, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
