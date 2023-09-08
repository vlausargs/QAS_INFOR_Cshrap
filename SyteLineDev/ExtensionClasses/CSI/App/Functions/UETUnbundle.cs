//PROJECT NAME: Data
//CLASS NAME: UETUnbundle.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class UETUnbundle : IUETUnbundle
	{
		readonly IApplicationDB appDB;
		
		public UETUnbundle(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string SQLUpdate,
			string SQLUpdateWhere,
			string SQLInsertColumns,
			string SQLInsertValues) UETUnbundleSp(
			string UETListPairs,
			string SQLUpdate = null,
			string SQLUpdateWhere = null,
			string SQLInsertColumns = null,
			string SQLInsertValues = null,
			string TableName = null)
		{
			VeryLongListType _UETListPairs = UETListPairs;
			VeryLongListType _SQLUpdate = SQLUpdate;
			VeryLongListType _SQLUpdateWhere = SQLUpdateWhere;
			VeryLongListType _SQLInsertColumns = SQLInsertColumns;
			VeryLongListType _SQLInsertValues = SQLInsertValues;
			TableNameType _TableName = TableName;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UETUnbundleSp";
				
				appDB.AddCommandParameter(cmd, "UETListPairs", _UETListPairs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SQLUpdate", _SQLUpdate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SQLUpdateWhere", _SQLUpdateWhere, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SQLInsertColumns", _SQLInsertColumns, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SQLInsertValues", _SQLInsertValues, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TableName", _TableName, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				SQLUpdate = _SQLUpdate;
				SQLUpdateWhere = _SQLUpdateWhere;
				SQLInsertColumns = _SQLInsertColumns;
				SQLInsertValues = _SQLInsertValues;
				
				return (Severity, SQLUpdate, SQLUpdateWhere, SQLInsertColumns, SQLInsertValues);
			}
		}
	}
}
