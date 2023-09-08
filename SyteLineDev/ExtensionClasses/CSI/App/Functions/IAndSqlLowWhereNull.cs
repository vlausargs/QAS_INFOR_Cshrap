//PROJECT NAME: Data
//CLASS NAME: IAndSqlLowWhereNull.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IAndSqlLowWhereNull
	{
		string AndSqlLowWhereNullFn(
			string TableAlias,
			string ColumnName,
			int? UseQuotes,
			string LowValue,
			string HighValue);
	}
}

