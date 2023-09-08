//PROJECT NAME: Reporting
//CLASS NAME: IRpt_productionCostbyWorkCenter.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_productionCostbyWorkCenter
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_productionCostbyWorkCenterSp(string StartingWorkCenter = null,
		string EndingWorkCenter = null,
		DateTime? StartingTransDate = null,
		DateTime? EndingTransDate = null,
		int? StartingTransDateOffset = null,
		int? EndingTransDateOffset = null,
		int? DisplayHeader = null,
		string pSite = null);
	}
}

