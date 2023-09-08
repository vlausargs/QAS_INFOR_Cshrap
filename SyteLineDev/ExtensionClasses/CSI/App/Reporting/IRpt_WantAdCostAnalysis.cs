//PROJECT NAME: Reporting
//CLASS NAME: IRpt_WantAdCostAnalysis.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_WantAdCostAnalysis
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_WantAdCostAnalysisSp(int? PWaNumStarting = null,
		int? PWaNumEnding = null,
		DateTime? PDateStarting = null,
		DateTime? PDateEnding = null,
		string PSortBy = null,
		int? PPrintCost = 0,
		string PSite = null);
	}
}

