//PROJECT NAME: Data
//CLASS NAME: AndSqlLowWhereNull.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class AndSqlLowWhereNull : IAndSqlLowWhereNull
	{
		readonly IApplicationDB appDB;
		
		public AndSqlLowWhereNull(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string AndSqlLowWhereNullFn(
			string TableAlias,
			string ColumnName,
			int? UseQuotes,
			string LowValue,
			string HighValue)
		{
			StringType _TableAlias = TableAlias;
			StringType _ColumnName = ColumnName;
			ListYesNoType _UseQuotes = UseQuotes;
			LongListType _LowValue = LowValue;
			LongListType _HighValue = HighValue;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[AndSqlLowWhereNull](@TableAlias, @ColumnName, @UseQuotes, @LowValue, @HighValue)";
				
				appDB.AddCommandParameter(cmd, "TableAlias", _TableAlias, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ColumnName", _ColumnName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseQuotes", _UseQuotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LowValue", _LowValue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "HighValue", _HighValue, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
