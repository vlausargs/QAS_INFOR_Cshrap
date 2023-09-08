//PROJECT NAME: Material
//CLASS NAME: IMrpPreFirmPlan.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IMrpPreFirmPlan
	{
		(int? ReturnCode,
			DateTime? DueDate,
			string RefTab,
			string Source,
			string PlanCode,
			string Buyer,
			DateTime? ReleaseDate,
			int? Found,
			string Infobar) MrpPreFirmPlanSp(
			string Item,
			decimal? ReqdQty,
			DateTime? DueDate,
			string RefTab,
			string Source,
			string PlanCode,
			string Buyer,
			DateTime? ReleaseDate,
			int? Found,
			string Infobar,
			string ItemVend = null,
			string FromSite = null,
			string FromWhse = null,
			string ApsParmApsmode = null,
			decimal? HrsPerDay = null,
			string parms_Site = null,
			int? mrp_parm_PreqMrp = null,
			int? UsePln = 1,
			string ThingsToProcess = "I");
	}
}

