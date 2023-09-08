//PROJECT NAME: Data
//CLASS NAME: BuildDependencyTablesStatements.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class BuildDependencyTablesStatements : IBuildDependencyTablesStatements
	{
		readonly IApplicationDB appDB;
		
		public BuildDependencyTablesStatements(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string BuildDependencyTablesStatementsFn(
			string IDO_Name,
			int? From_Source_Table)
		{
			StringType _IDO_Name = IDO_Name;
			ListYesNoType _From_Source_Table = From_Source_Table;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[BuildDependencyTablesStatements](@IDO_Name, @From_Source_Table)";
				
				appDB.AddCommandParameter(cmd, "IDO_Name", _IDO_Name, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "From_Source_Table", _From_Source_Table, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
