//PROJECT NAME: Data
//CLASS NAME: TriggerIupCustomPostCode.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class TriggerIupCustomPostCode : ITriggerIupCustomPostCode
	{
		readonly IApplicationDB appDB;
		
		public TriggerIupCustomPostCode(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string CustomPostInsertCode,
			string CustomPostUpdateCode,
			int? InsertNeedSeverityOrInfobar,
			int? UpdateNeedSeverityOrInfobar) TriggerIupCustomPostCodeSp(
			string TableName,
			string CustomPostInsertCode,
			string CustomPostUpdateCode,
			int? InsertNeedSeverityOrInfobar,
			int? UpdateNeedSeverityOrInfobar)
		{
			StringType _TableName = TableName;
			LongListType _CustomPostInsertCode = CustomPostInsertCode;
			LongListType _CustomPostUpdateCode = CustomPostUpdateCode;
			IntType _InsertNeedSeverityOrInfobar = InsertNeedSeverityOrInfobar;
			IntType _UpdateNeedSeverityOrInfobar = UpdateNeedSeverityOrInfobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TriggerIupCustomPostCodeSp";
				
				appDB.AddCommandParameter(cmd, "TableName", _TableName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomPostInsertCode", _CustomPostInsertCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustomPostUpdateCode", _CustomPostUpdateCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InsertNeedSeverityOrInfobar", _InsertNeedSeverityOrInfobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UpdateNeedSeverityOrInfobar", _UpdateNeedSeverityOrInfobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CustomPostInsertCode = _CustomPostInsertCode;
				CustomPostUpdateCode = _CustomPostUpdateCode;
				InsertNeedSeverityOrInfobar = _InsertNeedSeverityOrInfobar;
				UpdateNeedSeverityOrInfobar = _UpdateNeedSeverityOrInfobar;
				
				return (Severity, CustomPostInsertCode, CustomPostUpdateCode, InsertNeedSeverityOrInfobar, UpdateNeedSeverityOrInfobar);
			}
		}
	}
}
