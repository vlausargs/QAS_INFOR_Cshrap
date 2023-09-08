//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSOrNotInAndLikeSql.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSOrNotInAndLikeSql
	{
		string SSSFSOrNotInAndLikeSqlFn(
			string TableAlias,
			string ColumnName,
			string FieldName = null,
			string Input1 = null,
			string Input2 = null,
			string Input3 = null,
			int? UseQuotes = null,
			string LowValue = null,
			string HighValue = null);
	}
}

