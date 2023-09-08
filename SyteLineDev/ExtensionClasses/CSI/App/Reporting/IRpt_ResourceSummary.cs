//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ResourceSummary.cs

using CSI.Data.CRUD;

namespace CSI.Reporting
{
    public interface IRpt_ResourceSummary
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ResourceSummarySp(string ResourceStarting = null,
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

