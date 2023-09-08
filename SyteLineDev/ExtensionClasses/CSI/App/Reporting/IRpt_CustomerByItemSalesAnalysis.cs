//PROJECT NAME: Reporting
//CLASS NAME: IRpt_CustomerByItemSalesAnalysis.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_CustomerByItemSalesAnalysis
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_CustomerByItemSalesAnalysisSp(string COStatus = null,
		string Source = null,
		int? PageBetweenItems = null,
		string CustomerStarting = null,
		string CustomerEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		string ProductCodeStarting = null,
		string ProductCodeEnding = null,
		DateTime? OrderDateStarting = null,
		DateTime? OrderDateEnding = null,
		int? OrderDateStartingOffset = null,
		int? OrderDateEndingOffset = null,
		int? PrintPrice = 0,
		int? DisplayHeader = null,
		int? TaskId = null,
		string pSite = null);
	}
}

