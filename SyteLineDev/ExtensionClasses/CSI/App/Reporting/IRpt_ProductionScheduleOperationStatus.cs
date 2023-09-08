//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ProductionScheduleOperationStatus.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ProductionScheduleOperationStatus
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ProductionScheduleOperationStatusSp(string ScheduleIDStarting = null,
		string ScheduleIDEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		DateTime? DateStarting = null,
		DateTime? DateEnding = null,
		string ScheduleIDStatus = null,
		string ScheduleReleaseStatus = null,
		int? ControlPointsOnly = null,
		int? DateStartingOffset = null,
		int? DateEndingOffset = null,
		int? DisplayHeader = null,
		string pSite = null);
	}
}

