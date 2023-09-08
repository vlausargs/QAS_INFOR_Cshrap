//PROJECT NAME: Data.Functions
//CLASS NAME: ITruncateTable.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Data.Functions
{
	public interface ITruncateTable
	{
		int? TruncateTableSp(
			string TableName);
	}
}

