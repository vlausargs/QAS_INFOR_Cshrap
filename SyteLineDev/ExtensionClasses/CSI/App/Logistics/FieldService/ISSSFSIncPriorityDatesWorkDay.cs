//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSIncPriorityDatesWorkDay.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSIncPriorityDatesWorkDay
	{
		int? SSSFSIncPriorityDatesWorkDayFn(
			DateTime? Date,
			int? WorkDay1,
			int? WorkDay2,
			int? WorkDay3,
			int? WorkDay4,
			int? WorkDay5,
			int? WorkDay6,
			int? WorkDay7,
			int? ServOnHolidays);
	}
}

