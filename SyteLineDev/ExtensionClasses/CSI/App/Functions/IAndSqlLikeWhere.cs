//PROJECT NAME: Data
//CLASS NAME: IAndSqlLikeWhere.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IAndSqlLikeWhere
	{
		string AndSqlLikeWhereFn(
			string TableAlias,
			string ColumnName,
			int? UseQuotes,
			string LowValue,
			string HighValue);
	}
}

