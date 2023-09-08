//PROJECT NAME: Data
//CLASS NAME: IHomepage_TodaysSalesActivity.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IHomepage_TodaysSalesActivity
	{
		(int? ReturnCode,
			decimal? InteractionCount,
			decimal? CloseAmt,
			decimal? OrdersEntered,
			DateTime? Date) Homepage_TodaysSalesActivitySp(
			decimal? InteractionCount,
			decimal? CloseAmt,
			decimal? OrdersEntered,
			DateTime? Date);
	}
}

