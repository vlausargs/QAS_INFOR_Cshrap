//PROJECT NAME: Logistics
//CLASS NAME: SSSFSFormatEscalationAction.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSFormatEscalationAction : ISSSFSFormatEscalationAction
	{
		readonly IApplicationDB appDB;
		
		public SSSFSFormatEscalationAction(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string SSSFSFormatEscalationActionFn(
			Guid? RowPointer,
			string Table = "E")
		{
			RowPointerType _RowPointer = RowPointer;
			ListSingleAllType _Table = Table;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSFSFormatEscalationAction](@RowPointer, @Table)";
				
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Table", _Table, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
