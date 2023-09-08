//PROJECT NAME: Reporting
//CLASS NAME: IRpt_CostingAnalysisInventoryVariance.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_CostingAnalysisInventoryVariance
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_CostingAnalysisInventoryVarianceSp(string CostingAlt,
		string CostingAltVersus,
		string BOMTypeVersus,
		string WhseVersus = null,
		string PMTCode = null,
		string ABCCode = null,
		string CostMethod = null,
		string MatlType = null,
		int? GroupByProdCode = null,
		int? DisplayHeader = null,
		string ProdCodeStarting = null,
		string ProdCodeEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		string pSite = null);
	}
}

