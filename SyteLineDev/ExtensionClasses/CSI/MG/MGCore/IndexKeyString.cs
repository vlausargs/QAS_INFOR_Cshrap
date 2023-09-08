using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL.UDDT;
using System.Data;

namespace CSI.MG.MGCore
{
	public class IndexKeyString : IIndexKeyString
	{
		IApplicationDB appDB;


		public IndexKeyString(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public string IndexKeyStringFn(string IndexName,
		string TableName)
		{
			StringType _IndexName = IndexName;
			StringType _TableName = TableName;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[IndexKeyString](@IndexName, @TableName)";

				appDB.AddCommandParameter(cmd, "IndexName", _IndexName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TableName", _TableName, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<string>(cmd);

				return Output;
			}
		}
	}
}
