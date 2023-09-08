//PROJECT NAME: Data
//CLASS NAME: RecompileStoredProcedure.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class RecompileStoredProcedure : IRecompileStoredProcedure
	{
		readonly IApplicationDB appDB;
		
		public RecompileStoredProcedure(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? RecompileStoredProcedureSp(
			string StoredProcedure,
			string DatabaseName = null)
		{
			StringType _StoredProcedure = StoredProcedure;
			StringType _DatabaseName = DatabaseName;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RecompileStoredProcedureSp";
				
				appDB.AddCommandParameter(cmd, "StoredProcedure", _StoredProcedure, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DatabaseName", _DatabaseName, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
