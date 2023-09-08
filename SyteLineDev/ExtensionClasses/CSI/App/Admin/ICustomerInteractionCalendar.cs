//PROJECT NAME: Admin
//CLASS NAME: ICustomerInteractionCalendar.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface ICustomerInteractionCalendar
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CustomerInteractionCalendarSp(DateTime? StartDate,
		DateTime? EndDate,
		string Action,
		string SiteRef = null);
	}
}

