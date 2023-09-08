//PROJECT NAME: Logistics
//CLASS NAME: IPOItemlog.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IPOItemlog
	{
		(int? ReturnCode,
			string Infobar) POItemlogSp(
			string PAction,
			string PPoNum,
			int? PPoLine,
			int? PPoRelease,
			string PNewItem = null,
			string POldItem = null,
			string PNewUM = null,
			string POldUM = null,
			string PNewStatus = null,
			string POldStatus = null,
			decimal? PNewQty = 0,
			decimal? POldQty = 0,
			decimal? PNewItemCost = 0,
			decimal? POldItemCost = 0,
			decimal? PNewMaterialCost = 0,
			decimal? POldMaterialCost = 0,
			decimal? PNewFreightCost = 0,
			decimal? POldFreightCost = 0,
			decimal? PNewDutyCost = 0,
			decimal? POldDutyCost = 0,
			decimal? PNewBrokerageCost = 0,
			decimal? POldBrokerageCost = 0,
			decimal? PNewInsuranceCost = 0,
			decimal? POldInsuranceCost = 0,
			decimal? PNewLocalFreightCost = 0,
			decimal? POldLocalFreightCost = 0,
			decimal? PNewPlanCost = 0,
			decimal? POldPlanCost = 0,
			DateTime? PNewDueDate = null,
			DateTime? POldDueDate = null,
			DateTime? PNewPromiseDate = null,
			DateTime? POldPromiseDate = null,
			decimal? PNewConvFactor = null,
			decimal? POldConvFactor = null,
			string Infobar = null);
	}
}

