//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ProductionSchedule.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ProductionSchedule
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ProductionScheduleSp(string StartScheduleID = null,
		string EndScheduleID = null,
		string StartItem = null,
		string EndItem = null,
		DateTime? StartDate = null,
		DateTime? EndDate = null,
		string SchIDStatus = "R",
		string SchRelStatus = "R",
		string BinType = "D",
		string SumOrDetail = "D",
		int? StartDateOffset = null,
		int? EndDateOffset = null,
		int? DisplayHeader = null,
		string pSite = null);
	}
}

