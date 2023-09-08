//PROJECT NAME: Admin
//CLASS NAME: IProspectInteractionCalendar.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IProspectInteractionCalendar
	{
		(ICollectionLoadResponse Data, int? ReturnCode) ProspectInteractionCalendarSp(DateTime? StartDate,
		DateTime? EndDate,
		string ProspectID,
		string Slsman,
		string SiteRef);
	}
}

