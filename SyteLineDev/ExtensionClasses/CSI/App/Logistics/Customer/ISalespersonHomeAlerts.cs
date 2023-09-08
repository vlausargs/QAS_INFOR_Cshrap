//PROJECT NAME: Logistics
//CLASS NAME: ISalespersonHomeAlerts.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ISalespersonHomeAlerts
	{
		(int? ReturnCode, int? PastDueOpps,
		int? PastDueOppTasks,
		int? EstimatesToExpire,
		int? NumberOfUserTasks,
		int? NumberOfEventMessages) SalespersonHomeAlertsSp(string Slsman,
		int? PastDueOpps,
		int? PastDueOppTasks,
		int? EstimatesToExpire,
		int? NumberOfUserTasks,
		int? NumberOfEventMessages);
	}
}

