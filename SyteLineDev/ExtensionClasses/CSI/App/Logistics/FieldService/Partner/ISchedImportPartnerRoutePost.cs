//PROJECT NAME: Logistics
//CLASS NAME: ISchedImportPartnerRoutePost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Partner
{
	public interface ISchedImportPartnerRoutePost
	{
		(int? ReturnCode, string Infobar) SchedImportPartnerRoutePostSp(Guid? SessionID,
		string ProfileUsername,
		string ScheduleID,
		string PartnerID,
		DateTime? NextApptDate,
		string Durations,
		string Infobar);
	}
}

