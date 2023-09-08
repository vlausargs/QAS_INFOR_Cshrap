//PROJECT NAME: Data
//CLASS NAME: PurgeAndResetIntNextKeys.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class PurgeAndResetIntNextKeys : IPurgeAndResetIntNextKeys
	{
		readonly IApplicationDB appDB;
		
		public PurgeAndResetIntNextKeys(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PurgeAndResetIntNextKeysSp(
			string TableName,
			string ColumnName,
			string SubKeyName,
			string SubKeyValue)
		{
			StringType _TableName = TableName;
			StringType _ColumnName = ColumnName;
			StringType _SubKeyName = SubKeyName;
			GenericKeyType _SubKeyValue = SubKeyValue;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PurgeAndResetIntNextKeysSp";
				
				appDB.AddCommandParameter(cmd, "TableName", _TableName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ColumnName", _ColumnName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SubKeyName", _SubKeyName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SubKeyValue", _SubKeyValue, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
