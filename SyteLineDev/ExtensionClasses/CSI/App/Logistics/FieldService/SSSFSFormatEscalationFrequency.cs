//PROJECT NAME: Logistics
//CLASS NAME: SSSFSFormatEscalationFrequency.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSFormatEscalationFrequency : ISSSFSFormatEscalationFrequency
	{
		readonly IApplicationDB appDB;
		
		public SSSFSFormatEscalationFrequency(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string SSSFSFormatEscalationFrequencyFn(
			Guid? RowPointer,
			string Table = "E")
		{
			RowPointerType _RowPointer = RowPointer;
			ListSingleAllType _Table = Table;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSFSFormatEscalationFrequency](@RowPointer, @Table)";
				
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Table", _Table, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
