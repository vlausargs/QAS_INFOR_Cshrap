//PROJECT NAME: Production
//CLASS NAME: IProductionPlannerAlerts.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IProductionPlannerAlerts
	{
		(int? ReturnCode, int? PastDueJobs,
		int? ProductionDueJobs,
		int? NumberOfUserTasks,
		int? NumberOfEventMessages) ProductionPlannerAlertsSp(int? PastDueJobs,
		int? ProductionDueJobs,
		int? NumberOfUserTasks,
		int? NumberOfEventMessages);
	}
}

