//PROJECT NAME: Reporting
//CLASS NAME: IRpt_PreassignedLotLabels.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_PreassignedLotLabels
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_PreassignedLotLabelsSp(string LotStarting = null,
		string LotEnding = null,
		int? IncludePO = 0,
		string PoStarting = null,
		string PoEnding = null,
		int? PoLineStarting = null,
		int? PoLineEnding = null,
		int? PoReleaseStarting = 0,
		int? PoReleaseEnding = 0,
		int? IncludeJob = 0,
		string JobStarting = null,
		string JobEnding = null,
		int? SuffixStarting = null,
		int? SuffixEnding = null,
		int? IncludeTrn = 0,
		string TrnStarting = null,
		string TrnEnding = null,
		int? TrnLineStarting = null,
		int? TrnLineEnding = null,
		string pSite = null);
	}
}

