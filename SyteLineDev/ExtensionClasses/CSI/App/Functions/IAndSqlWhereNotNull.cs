//PROJECT NAME: Data
//CLASS NAME: IAndSqlWhereNotNull.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IAndSqlWhereNotNull
	{
		string AndSqlWhereNotNullFn(
			string TableAlias,
			string ColumnName,
			int? UseQuotes,
			string LowValue,
			string HighValue);
	}
}

