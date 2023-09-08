//PROJECT NAME: Reporting
//CLASS NAME: IRpt_PrintingEstimateWorksheet.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_PrintingEstimateWorksheet
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_PrintingEstimateWorksheetSp(string CoNum = null,
		int? CoLine = 0,
		decimal? CompQty2 = 0,
		decimal? CompQty3 = 0,
		decimal? CompQty4 = 0,
		decimal? CompQty5 = 0,
		string pSite = null);
	}
}

