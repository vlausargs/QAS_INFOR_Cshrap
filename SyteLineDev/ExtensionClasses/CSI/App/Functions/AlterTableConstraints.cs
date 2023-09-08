//PROJECT NAME: Data
//CLASS NAME: AlterTableConstraints.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class AlterTableConstraints : IAlterTableConstraints
	{
		readonly IApplicationDB appDB;
		
		public AlterTableConstraints(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? AlterTableConstraintsSp(
			string Action,
			string TableName = null)
		{
			StringType _Action = Action;
			StringType _TableName = TableName;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AlterTableConstraintsSp";
				
				appDB.AddCommandParameter(cmd, "Action", _Action, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TableName", _TableName, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
