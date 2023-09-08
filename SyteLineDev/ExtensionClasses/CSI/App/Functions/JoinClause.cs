//PROJECT NAME: Data
//CLASS NAME: JoinClause.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class JoinClause : IJoinClause
	{
		readonly IApplicationDB appDB;
		
		public JoinClause(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string JoinClauseFn(
			string TableName,
			string JoinTableName,
			string Keys,
			string JoinKeys,
			string AssumedKeys,
			string AssumedJoinKeys,
			string Delim = ",")
		{
			StringType _TableName = TableName;
			StringType _JoinTableName = JoinTableName;
			StringType _Keys = Keys;
			StringType _JoinKeys = JoinKeys;
			StringType _AssumedKeys = AssumedKeys;
			StringType _AssumedJoinKeys = AssumedJoinKeys;
			StringType _Delim = Delim;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[JoinClause](@TableName, @JoinTableName, @Keys, @JoinKeys, @AssumedKeys, @AssumedJoinKeys, @Delim)";
				
				appDB.AddCommandParameter(cmd, "TableName", _TableName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JoinTableName", _JoinTableName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Keys", _Keys, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JoinKeys", _JoinKeys, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AssumedKeys", _AssumedKeys, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AssumedJoinKeys", _AssumedJoinKeys, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Delim", _Delim, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
