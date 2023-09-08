//PROJECT NAME: Reporting
//CLASS NAME: IRpt_CostingAnalysisCustomerOrderMargin.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_CostingAnalysisCustomerOrderMargin
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_CostingAnalysisCustomerOrderMarginSp(string CostingAlt = null,
		int? GroupByCustomer = 0,
		int? GroupByCO = 0,
		string CustomerStarting = null,
		string CustomerEnding = null,
		string OrderStarting = null,
		string OrderEnding = null,
		string EstimateOrderStarting = null,
		string EstimateOrderEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		string ProductCodeStarting = null,
		string ProductCodeEnding = null,
		int? DisplayHeader = 0,
		string OrderType = null,
		string pSite = null);
	}
}

