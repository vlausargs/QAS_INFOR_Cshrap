//PROJECT NAME: Data
//CLASS NAME: IIntraSiteTransferDetailRefresh.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IIntraSiteTransferDetailRefresh
	{
		int? IntraSiteTransferDetailRefreshSp(
			int? RowCount,
			string PCFilter = null,
			int? PageCount = 1);
	}
}

