//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ProjectedItemCompletionsbyResourceMRPAPS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ProjectedItemCompletionsbyResourceMRPAPS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ProjectedItemCompletionsbyResourceMRPAPSSp(string ResourceStarting = null,
		string ResourceEnding = null,
		string ResourceGroupStarting = null,
		string ResourceGroupEnding = null,
		DateTime? DateStarting = null,
		DateTime? DateEnding = null,
		int? DateStartingOffset = null,
		int? DateEndingOffset = null,
		int? DisplayHeader = null,
		string pSite = null);
	}
}

