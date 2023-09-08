//PROJECT NAME: Admin
//CLASS NAME: IPurgeTable.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IPurgeTable
	{
		(int? ReturnCode,
		int? RowAmount,
		int? CanRetry,
		string Infobar) PurgeTableSp(
			string TableName,
			string DeleteSite,
			int? ForcePurge = 0,
			int? RowAmount = null,
			int? CanRetry = null,
			string Infobar = null);
	}
}

