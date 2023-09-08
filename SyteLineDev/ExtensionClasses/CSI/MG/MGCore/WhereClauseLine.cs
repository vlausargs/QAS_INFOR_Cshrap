using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL.UDDT;
using System.Data;

namespace CSI.MG.MGCore
{
	public class WhereClauseLine : IWhereClauseLine
	{
		IApplicationDB appDB;


		public WhereClauseLine(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public string WhereClauseLineFn(string WhereClause,
		string KeyName,
		string KeyValue,
		string TableAlias)
		{
			LongListType _WhereClause = WhereClause;
			StringType _KeyName = KeyName;
			LongListType _KeyValue = KeyValue;
			StringType _TableAlias = TableAlias;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[WhereClauseLine](@WhereClause, @KeyName, @KeyValue, @TableAlias)";

				appDB.AddCommandParameter(cmd, "WhereClause", _WhereClause, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "KeyName", _KeyName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "KeyValue", _KeyValue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TableAlias", _TableAlias, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<string>(cmd);

				return Output;
			}
		}
	}
}
