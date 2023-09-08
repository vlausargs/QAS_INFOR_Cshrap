//PROJECT NAME: Data
//CLASS NAME: IPlanningLateAlert.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPlanningLateAlert
	{
		int? PlanningLateAlertFn(
			string PProjNum,
			int? PProjTaskNum,
			string Site = null);
	}
}

