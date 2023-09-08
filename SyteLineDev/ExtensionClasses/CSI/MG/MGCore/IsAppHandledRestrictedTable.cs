using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL.UDDT;
using System.Data;

namespace CSI.MG.MGCore
{
	public class IsAppHandledRestrictedTable : IIsAppHandledRestrictedTable
	{
		IApplicationDB appDB;


		public IsAppHandledRestrictedTable(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public int? IsAppHandledRestrictedTableFn(string TableName)
		{
			StringType _TableName = TableName;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[IsAppHandledRestrictedTable](@TableName)";

				appDB.AddCommandParameter(cmd, "TableName", _TableName, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<int?>(cmd);

				return Output;
			}
		}
	}
}
