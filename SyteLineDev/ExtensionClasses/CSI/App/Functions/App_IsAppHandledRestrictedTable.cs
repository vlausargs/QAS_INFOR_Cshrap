//PROJECT NAME: Data
//CLASS NAME: App_IsAppHandledRestrictedTable.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class App_IsAppHandledRestrictedTable : IApp_IsAppHandledRestrictedTable
	{
		readonly IApplicationDB appDB;
		
		public App_IsAppHandledRestrictedTable(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? App_IsAppHandledRestrictedTableFn(
			string TableName)
		{
			StringType _TableName = TableName;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[App_IsAppHandledRestrictedTable](@TableName)";
				
				appDB.AddCommandParameter(cmd, "TableName", _TableName, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
