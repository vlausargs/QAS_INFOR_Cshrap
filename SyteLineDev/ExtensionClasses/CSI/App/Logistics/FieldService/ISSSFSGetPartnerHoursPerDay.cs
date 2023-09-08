//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSGetPartnerHoursPerDay.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSGetPartnerHoursPerDay
	{
		decimal? SSSFSGetPartnerHoursPerDayFn(
			string PartnerId,
			int? DayOfTheWeek);
	}
}

