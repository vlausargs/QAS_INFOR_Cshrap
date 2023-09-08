//PROJECT NAME: Reporting
//CLASS NAME: IRpt_JobBOM.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_JobBOM
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) Rpt_JobBOMSp(
			string JobStarting = null,
			string JobEnding = null,
			int? SuffixStarting = null,
			int? SuffixEnding = null,
			string PageJob3 = null,
			int? RefFields = null,
			string SortBy = null,
			string DisplayLevel = null,
			int? PrintCost = null,
			int? DisplayHeader = null,
			string pSite = null);
	}
}

