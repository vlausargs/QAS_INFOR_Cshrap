//PROJECT NAME: Employee
//CLASS NAME: ICLM_ESSPopulateTimeOffCalendar.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface ICLM_ESSPopulateTimeOffCalendar
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESSPopulateTimeOffCalendarSp(string EmpNum);
	}
}

