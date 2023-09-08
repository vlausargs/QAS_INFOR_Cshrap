//PROJECT NAME: Data
//CLASS NAME: IApp_IsAppHandledRestrictedTable.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IApp_IsAppHandledRestrictedTable
	{
		int? App_IsAppHandledRestrictedTableFn(
			string TableName);
	}
}

