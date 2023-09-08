//PROJECT NAME: Reporting
//CLASS NAME: IRpt_OrderShippedCost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_OrderShippedCost
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_OrderShippedCostSp(int? TranslateToDomestic = 0,
		string OrderStarting = null,
		string OrderEnding = null,
		string CustomerStarting = null,
		string CustomerEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		DateTime? DateShippedStarting = null,
		DateTime? DateShippedEnding = null,
		int? DateShippedStartingOffset = null,
		int? DateShippedEndingOffset = null,
		int? DisplayReportHeader = 1,
		string pSite = null);
	}
}

