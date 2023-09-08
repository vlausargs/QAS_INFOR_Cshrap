using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL.UDDT;
using System.Data;

namespace CSI.MG.MGCore
{
	public class FullTextIndexColumnString : IFullTextIndexColumnString
	{
		IApplicationDB appDB;


		public FullTextIndexColumnString(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public string FullTextIndexColumnStringFn(string TableName)
		{
			StringType _TableName = TableName;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[FullTextIndexColumnString](@TableName)";

				appDB.AddCommandParameter(cmd, "TableName", _TableName, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<string>(cmd);

				return Output;
			}
		}
	}
}
