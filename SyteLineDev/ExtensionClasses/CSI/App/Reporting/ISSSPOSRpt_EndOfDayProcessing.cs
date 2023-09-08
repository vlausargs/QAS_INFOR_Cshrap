//PROJECT NAME: Reporting
//CLASS NAME: ISSSPOSRpt_EndOfDayProcessing.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ISSSPOSRpt_EndOfDayProcessing
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSPOSRpt_EndOfDayProcessingSp(string CashDrawer = null,
		DateTime? AdjustmentPostingDate = null,
		decimal? EndingCashBalance = 0.00M,
		decimal? EndingCheckBalance = 0.00M,
		int? CheckInBalance = null,
		int? CheckInNotBalance = null,
		string pSite = null);
	}
}

