//PROJECT NAME: Logistics
//CLASS NAME: IPoReleaseDefault.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IPoReleaseDefault
	{
		(int? ReturnCode, string Stat,
		string Item,
		string Description,
		string VendItem,
		decimal? BlanketQtyConv,
		string UM,
		decimal? PlanCostConv,
		decimal? ItemCostConv,
		DateTime? EffDate,
		DateTime? ExpDate,
		string Revision,
		string DrawingNbr,
		decimal? UnitMatCostConv,
		decimal? UnitFreightCostConv,
		decimal? UnitDutyCostConv,
		decimal? UnitBrokerageCostConv,
		decimal? UnitInsuranceCostConv,
		decimal? UnitLocFrtCostConv,
		int? LeadTime,
		string Origin,
		string CommCode,
		decimal? UnitWeight,
		int? SerialTracked,
		string TaxCode1,
		string TaxCode2,
		int? ItemExists,
		decimal? TotalQtyOrderedConv,
		string NonInvAcct,
		string NonInvAcctDesc,
		string NonInvAcctUnit1,
		string NonInvAcctUnit2,
		string NonInvAcctUnit3,
		string NonInvAcctUnit4,
		string AccessUnit1,
		string AccessUnit2,
		string AccessUnit3,
		string AccessUnit4,
		string ManufacturerId,
		string ManufacturerName,
		string ManufacturerItem,
		string ManufacturerItemDesc,
		string Infobar,
		int? AcctIsControl) PoReleaseDefaultSp(string PoNum,
		int? PoLine,
		string Stat,
		string Item,
		string Description,
		string VendItem,
		decimal? BlanketQtyConv,
		string UM,
		decimal? PlanCostConv,
		decimal? ItemCostConv,
		DateTime? EffDate,
		DateTime? ExpDate,
		string Revision,
		string DrawingNbr,
		decimal? UnitMatCostConv,
		decimal? UnitFreightCostConv,
		decimal? UnitDutyCostConv,
		decimal? UnitBrokerageCostConv,
		decimal? UnitInsuranceCostConv,
		decimal? UnitLocFrtCostConv,
		int? LeadTime,
		string Origin,
		string CommCode,
		decimal? UnitWeight,
		int? SerialTracked,
		string TaxCode1,
		string TaxCode2,
		int? ItemExists,
		decimal? TotalQtyOrderedConv,
		string NonInvAcct,
		string NonInvAcctDesc,
		string NonInvAcctUnit1,
		string NonInvAcctUnit2,
		string NonInvAcctUnit3,
		string NonInvAcctUnit4,
		string AccessUnit1,
		string AccessUnit2,
		string AccessUnit3,
		string AccessUnit4,
		string ManufacturerId,
		string ManufacturerName,
		string ManufacturerItem,
		string ManufacturerItemDesc,
		string Infobar,
		int? AcctIsControl);
	}
}

