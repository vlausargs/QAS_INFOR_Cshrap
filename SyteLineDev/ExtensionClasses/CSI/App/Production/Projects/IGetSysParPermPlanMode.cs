//PROJECT NAME: Production
//CLASS NAME: IGetSysParPermPlanMode.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IGetSysParPermPlanMode
	{
		(int? ReturnCode, string ApsParmApsmode,
		int? CanAdd,
		int? CanUpdate,
		int? CanDelete,
		string PlanMode,
		string Parm_DefWhse,
		string Infobar) GetSysParPermPlanModeSp(string ApsParmApsmode,
		int? CanAdd,
		int? CanUpdate,
		int? CanDelete,
		string PlanMode,
		string Parm_DefWhse,
		string Infobar);
	}
}

