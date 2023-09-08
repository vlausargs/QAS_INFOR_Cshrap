//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ProductionScheduleDetail.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ProductionScheduleDetail
	{
		int? Rpt_ProductionScheduleDetailSp(
			string StartScheduleID = null,
			string EndScheduleID = null,
			string StartItem = null,
			string EndItem = null,
			DateTime? StartDate = null,
			DateTime? EndDate = null,
			string SchIDStatus = "R",
			string SchRelStatus = "R",
			int? StartDateOffset = null,
			int? EndDateOffset = null);
	}
}

