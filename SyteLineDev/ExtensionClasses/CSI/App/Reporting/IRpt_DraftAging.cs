//PROJECT NAME: Reporting
//CLASS NAME: IRpt_DraftAging.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_DraftAging
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_DraftAgingSp(string BegCusNum = null,
		string EndCusNum = null,
		DateTime? ExBegDueDate = null,
		DateTime? ExEndDueDate = null,
		int? ExBegDateOffset = null,
		int? ExEndDateOffset = null,
		int? DisplayHeader = null,
		int? TaskId = null,
		string pSite = null);
	}
}

