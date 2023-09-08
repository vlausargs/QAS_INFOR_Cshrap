//PROJECT NAME: Reporting
//CLASS NAME: IRpt_InventoryCost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_InventoryCost
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) Rpt_InventoryCostSp(
			string ExbegWhse = null,
			string ExendWhse = null,
			string ExbegLoc = null,
			string ExendLoc = null,
			string ExbegProductcode = null,
			string ExendProductcode = null,
			string ExbegItem = null,
			string ExendItem = null,
			string ExOptgoItemStat = "AOS",
			string ExOptgoMatlType = "MTFO",
			string ExOptprPMTCode = "PMT",
			string ExOptszStocked = "B",
			string ExOptacAbcCode = "ABC",
			int? ExOptprPrZeroQty = 0,
			int? ShowDetail = 0,
			int? PrintCost = 0,
			int? DisplayHeader = null,
			string PMessageLanguage = null,
			string pSite = null,
			Guid? ProcessId = null);
	}
}

