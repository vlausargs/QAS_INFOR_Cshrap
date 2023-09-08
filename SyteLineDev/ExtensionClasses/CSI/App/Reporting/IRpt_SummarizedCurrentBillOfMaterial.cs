//PROJECT NAME: Reporting
//CLASS NAME: IRpt_SummarizedCurrentBillOfMaterial.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_SummarizedCurrentBillOfMaterial
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_SummarizedCurrentBillOfMaterialSp(string ItemStarting = null,
		string ItemEnding = null,
		string ProductCodeStarting = null,
		string ProductCodeEnding = null,
		string MaterialType = null,
		string Source = null,
		string Shocked = null,
		string ABCCode = null,
		DateTime? EffectiveDate = null,
		int? PageBetweenItems = null,
		int? PrintOnlyZeroLevelItems = null,
		int? EffectiveDateOffset = null,
		int? DisplayHeader = null,
		int? PrintCost = 0,
		string pSite = null);
	}
}

