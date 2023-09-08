//PROJECT NAME: Logistics
//CLASS NAME: ICLM_SchedGetEvents.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Partner
{
	public interface ICLM_SchedGetEvents
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_SchedGetEventsSp(string Username,
		string ProfileUsername,
		string ScheduleID,
		string FilterUsername,
		string FilterName,
		int? FilterType,
		int? ColorCoding,
		DateTime? StartDate,
		DateTime? EndDate,
		int? PartnerFilterOverride,
		string SelectedPartnerList,
		int? TaskFilterOverride,
		string SelectedTaskList,
		int? View = 0,
		int? RecordCap = 200);
	}
}

