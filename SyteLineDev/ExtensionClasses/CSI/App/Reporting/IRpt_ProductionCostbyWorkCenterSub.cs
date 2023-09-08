//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ProductionCostbyWorkCenterSub.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ProductionCostbyWorkCenterSub
	{
		int? Rpt_ProductionCostbyWorkCenterSubSp(
			string StartingWorkCenter = null,
			string EndingWorkCenter = null,
			DateTime? StartingTransDate = null,
			DateTime? EndingTransDate = null,
			int? StartingTransDateOffset = null,
			int? EndingTransDateOffset = null,
			int? DisplayHeader = null);
	}
}

