//PROJECT NAME: Admin
//CLASS NAME: IOpportunityTaskCalendar.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IOpportunityTaskCalendar
	{
		(ICollectionLoadResponse Data, int? ReturnCode) OpportunityTaskCalendarSp(DateTime? StartDate,
		DateTime? EndDate,
		string Action,
		string Slsman);
	}
}

