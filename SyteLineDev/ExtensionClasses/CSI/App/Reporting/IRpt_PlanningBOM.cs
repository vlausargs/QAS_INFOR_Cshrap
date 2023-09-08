//PROJECT NAME: Reporting
//CLASS NAME: IRpt_PlanningBOM.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_PlanningBOM
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_PlanningBOMSP(string ItemStarting,
		string ItemEnding,
		string ProductCodeStarting,
		string ProductCodeEnding,
		string MaterialType,
		string ABCCode,
		DateTime? EffectiveDate,
		int? EffectiveDateOffset = null,
		int? IndentedLevelView = null,
		int? PageBetweenItems = null,
		int? ShowPrice = null,
		int? DisplayHeader = null,
		string pSite = null);
	}
}

