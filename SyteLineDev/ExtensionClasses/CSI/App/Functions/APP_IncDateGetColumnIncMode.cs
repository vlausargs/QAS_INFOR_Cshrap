//PROJECT NAME: Data
//CLASS NAME: APP_IncDateGetColumnIncMode.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class APP_IncDateGetColumnIncMode : IAPP_IncDateGetColumnIncMode
	{
		readonly IApplicationDB appDB;
		
		public APP_IncDateGetColumnIncMode(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string IncrementMode) APP_IncDateGetColumnIncModeSp(
			string TableName,
			string ColumnName,
			string IncrementMode)
		{
			StringType _TableName = TableName;
			StringType _ColumnName = ColumnName;
			StringType _IncrementMode = IncrementMode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "APP_IncDateGetColumnIncModeSp";
				
				appDB.AddCommandParameter(cmd, "TableName", _TableName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ColumnName", _ColumnName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncrementMode", _IncrementMode, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				IncrementMode = _IncrementMode;
				
				return (Severity, IncrementMode);
			}
		}
	}
}
