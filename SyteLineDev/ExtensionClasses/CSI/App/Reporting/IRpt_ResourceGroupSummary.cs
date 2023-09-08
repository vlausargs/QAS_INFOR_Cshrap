//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ResourceGroupSummary.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ResourceGroupSummary
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ResourceGroupSummarySp(string ResourceStarting = null,
			string ResourceEnding = null,
			string ResourceGroupStarting = null,
			string ResourceGroupEnding = null,
			string ResourceTypeStarting = null,
			string ResourceTypeEnding = null,
			decimal? PercentLoadStarting = null,
			decimal? PercentLoadEnding = null,
			int? DisplayHeader = null,
			int? ALTNO = null,
			string pSite = null);
	}
}

