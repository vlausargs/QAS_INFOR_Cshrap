//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSConInvSubGetHoursInDay.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSConInvSubGetHoursInDay
	{
		decimal? SSSFSConInvSubGetHoursInDayFn(
			DateTime? WorkDay);
	}
}

