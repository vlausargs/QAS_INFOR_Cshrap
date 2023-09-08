//PROJECT NAME: Data
//CLASS NAME: QueryRuntimeIDODefinition.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class QueryRuntimeIDODefinition : IQueryRuntimeIDODefinition
	{
		readonly IApplicationDB appDB;
		
		public QueryRuntimeIDODefinition(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? QueryRuntimeIDODefinitionSp(
			string Name)
		{
			StringType _Name = Name;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "QueryRuntimeIDODefinition";
				
				appDB.AddCommandParameter(cmd, "Name", _Name, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
