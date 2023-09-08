//PROJECT NAME: Material
//CLASS NAME: IMrpExplode.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IMrpExplode
	{
		(int? ReturnCode,
			string Infobar) MrpExplodeSp(
			string ItemItem,
			string ItemJob,
			int? ItemPassReq,
			int? ItemLeadTime,
			decimal? ItemVarLead,
			int? ItemPlanFlag,
			decimal? HrsPerDay,
			int? MrpParmScrapFlag,
			int? MrpParmUseSchedTimesInPlanning,
			int? MrpParmPlanPlannedPs,
			int? ApsParmPlanMaterialsAtOperStart,
			Guid? ProcessId,
			string UserMrpPlanningType,
			string Infobar,
			int? MrpParmPlanStoppedJob,
			int? DebugLevel,
			int? ItemElapsedTime,
			int? BgTaskID);
	}
}

