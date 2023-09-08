//PROJECT NAME: Logistics
//CLASS NAME: SSSFSOrNotInAndLikeSql.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSOrNotInAndLikeSql : ISSSFSOrNotInAndLikeSql
	{
		readonly IApplicationDB appDB;
		
		public SSSFSOrNotInAndLikeSql(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string SSSFSOrNotInAndLikeSqlFn(
			string TableAlias,
			string ColumnName,
			string FieldName = null,
			string Input1 = null,
			string Input2 = null,
			string Input3 = null,
			int? UseQuotes = null,
			string LowValue = null,
			string HighValue = null)
		{
			StringType _TableAlias = TableAlias;
			StringType _ColumnName = ColumnName;
			StringType _FieldName = FieldName;
			ProductCodeType _Input1 = Input1;
			ProductCodeType _Input2 = Input2;
			ProductCodeType _Input3 = Input3;
			ListYesNoType _UseQuotes = UseQuotes;
			LongListType _LowValue = LowValue;
			LongListType _HighValue = HighValue;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSFSOrNotInAndLikeSql](@TableAlias, @ColumnName, @FieldName, @Input1, @Input2, @Input3, @UseQuotes, @LowValue, @HighValue)";
				
				appDB.AddCommandParameter(cmd, "TableAlias", _TableAlias, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ColumnName", _ColumnName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FieldName", _FieldName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Input1", _Input1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Input2", _Input2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Input3", _Input3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseQuotes", _UseQuotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LowValue", _LowValue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "HighValue", _HighValue, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
