using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL.UDDT;
using System.Data;
using CSI.MG.MGCore;
using CSI.MG;

namespace CSI.Data.SQL
{
	public class AndSqlWhere : IAndSqlWhere
	{
		IApplicationDB appDB;


		public AndSqlWhere(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public string AndSqlWhereFn(string TableAlias,
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
				cmd.CommandText = "SELECT  dbo.[AndSqlWhere](@TableAlias, @ColumnName, @UseQuotes, @LowValue, @HighValue)";

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
