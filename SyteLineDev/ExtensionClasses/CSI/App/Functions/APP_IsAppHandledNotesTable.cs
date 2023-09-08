//PROJECT NAME: Data
//CLASS NAME: APP_IsAppHandledNotesTable.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class APP_IsAppHandledNotesTable : IAPP_IsAppHandledNotesTable
	{
		readonly IApplicationDB appDB;
		
		public APP_IsAppHandledNotesTable(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? IsAppHandled) APP_IsAppHandledNotesTableSp(
			string TableName,
			int? IsAppHandled)
		{
			StringType _TableName = TableName;
			ListYesNoType _IsAppHandled = IsAppHandled;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "APP_IsAppHandledNotesTableSp";
				
				appDB.AddCommandParameter(cmd, "TableName", _TableName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IsAppHandled", _IsAppHandled, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				IsAppHandled = _IsAppHandled;
				
				return (Severity, IsAppHandled);
			}
		}
	}
}
