//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ProductionScheduleRouting.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ProductionScheduleRouting
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ProductionScheduleRoutingSp(string StartScheduleID = null,
		string EndScheduleID = null,
		string StartItem = null,
		string EndItem = null,
		DateTime? StartDueDate = null,
		DateTime? EndDueDate = null,
		string ScheduleIDStat = null,
		string ScheduleReleaseStat = null,
		int? PrintBarcodeFmt = null,
		string BarcodeWhichOper = null,
		int? ShowInternal = null,
		int? ShowExternal = null,
		int? JobRouteNotes = null,
		int? JobMatlNotes = null,
		int? IncludePSRel = null,
		int? DisplayHeader = null,
		string BGSessionId = null,
		string pSite = null);
	}
}

