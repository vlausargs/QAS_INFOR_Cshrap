//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ProductSalesAnalysis.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ProductSalesAnalysis
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ProductSalesAnalysisSp(string StartProdCode = null,
		string EndProdCode = null,
		string StartFamCode = null,
		string EndFamCode = null,
		string StartItem = null,
		string EndItem = null,
		DateTime? AsOfDate = null,
		string UsePriceOrQty = null,
		string SortBy = null,
		int? AsOfDateOffset = null,
		int? PrintPrice = 0,
		int? DisplayHeader = null,
		int? DisplayNonInventoryItem = null,
		int? TaskId = null,
		string pSite = null);
	}
}

