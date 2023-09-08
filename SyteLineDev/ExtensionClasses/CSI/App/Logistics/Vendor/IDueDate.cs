//PROJECT NAME: Logistics
//CLASS NAME: IDueDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IDueDate
	{
		(int? ReturnCode, DateTime? DueDate,
		DateTime? DiscDate) DueDateSp(DateTime? InvoiceDate,
		int? DueDays,
		int? ProxCode,
		int? ProxDay,
		string pTermsCode,
		int? ProxMonthToForward,
		int? CutoffDay,
		string HolidayOffsetMethod,
		int? ProxDiscMonthToForward,
		int? ProxDiscDay,
		int? DiscDays,
		DateTime? DueDate,
		DateTime? DiscDate);
	}
}

