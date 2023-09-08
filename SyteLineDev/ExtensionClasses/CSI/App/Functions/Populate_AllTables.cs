//PROJECT NAME: Data
//CLASS NAME: Populate_AllTables.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Populate_AllTables : IPopulate_AllTables
	{
		readonly IApplicationDB appDB;
		
		public Populate_AllTables(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? Populate_AllTablesSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Populate_AllTablesSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
		public int? Populate_AllTablesFn(
			string TableName)
		{
			StringType _TableName = TableName;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[Populate_AllTables](@TableName)";

				appDB.AddCommandParameter(cmd, "TableName", _TableName, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<int?>(cmd);

				return Output;
			}
		}

	}
}
