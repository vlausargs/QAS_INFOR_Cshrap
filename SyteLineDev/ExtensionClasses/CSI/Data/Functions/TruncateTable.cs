//PROJECT NAME: Data.Functions
//CLASS NAME: TruncateTable.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Data.Functions
{
	public class TruncateTable : ITruncateTable
	{
		readonly IApplicationDB appDB;

		public TruncateTable(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public int? TruncateTableSp(
			string TableName)
		{
			TableNameType _TableName = TableName;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TruncateTableSp";

				appDB.AddCommandParameter(cmd, "TableName", _TableName, ParameterDirection.Input);

				var Severity = appDB.ExecuteNonQuery(cmd);

				return (Severity);
			}
		}
	}
}
