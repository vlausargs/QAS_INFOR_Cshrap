//PROJECT NAME: Reporting
//CLASS NAME: IRpt_MaterialAnalysisbyWorkCenter.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_MaterialAnalysisbyWorkCenter
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_MaterialAnalysisbyWorkCenterSp(string StartingWc = null,
		string EndingWc = null,
		string StartingIterm = null,
		string EndingIterm = null,
		DateTime? StartingTransDate = null,
		DateTime? EndingTransDate = null,
		int? StartingTransDateOffset = null,
		int? EndingTransDateOffset = null,
		int? ShowDetail = null,
		int? ShowHeader = null,
		string pSite = null,
		string DocumentNumStarting = null,
		string DocumentNumEnding = null);
	}
}

