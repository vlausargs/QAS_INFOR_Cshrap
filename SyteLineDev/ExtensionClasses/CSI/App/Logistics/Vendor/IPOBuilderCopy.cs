//PROJECT NAME: Logistics
//CLASS NAME: IPOBuilderCopy.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IPOBuilderCopy
	{
		(int? ReturnCode,
			string Infobar) POBuilderCopySP(
			Guid? ProcessID,
			string SiteRef,
			string Item,
			string Description,
			string VendItem,
			decimal? QtyOrdered,
			decimal? QtyOrderedConv,
			string UM,
			string Stat,
			decimal? PlanCost,
			decimal? PlanCostConv,
			decimal? UnitMatCost,
			decimal? UnitMatCostConv,
			decimal? UnitDutyCost,
			decimal? UnitDutyCostConv,
			decimal? UnitFreightCost,
			decimal? UnitFreightCostConv,
			decimal? UnitBrokerageCost,
			decimal? UnitBrokerageCostConv,
			decimal? UnitLocalFreight,
			decimal? UnitLocalFreightConv,
			decimal? UnitInsuranceCost,
			decimal? UnitInsuranceCostConv,
			DateTime? DueDate,
			DateTime? ReleaseDate,
			string NonInvAcct,
			string NonInvAcctUnit1,
			string NonInvAcctUnit2,
			string NonInvAcctUnit3,
			string NonInvAcctUnit4,
			int? LcOverride,
			Guid? ApsPlanRowPointer,
			string ManufacturerId,
			string ManufacturerItem,
			string Infobar);
	}
}

