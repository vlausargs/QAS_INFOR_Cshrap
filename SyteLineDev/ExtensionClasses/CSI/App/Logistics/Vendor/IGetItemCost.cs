//PROJECT NAME: Logistics
//CLASS NAME: IGetItemCost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IGetItemCost
	{
		(int? ReturnCode, decimal? UnitMatCost,
		decimal? UnitMatCostConv,
		decimal? UnitFreightCost,
		decimal? UnitFreightCostConv,
		decimal? UnitDutyCost,
		decimal? UnitDutyCostConv,
		decimal? UnitBrokerageCost,
		decimal? UnitBrokerageCostConv,
		decimal? UnitInsuranceCost,
		decimal? UnitInsuranceCostConv,
		decimal? UnitLocFrtCost,
		decimal? UnitLocFrtCostConv,
		string Infobar,
		int? DispMsg) GetItemCostSp(string Item,
		string UM,
		string VendNum,
		string VendorCurrCode,
		decimal? ExchRate,
		decimal? QtyOrderedConv,
		DateTime? EffectiveDate,
		decimal? UnitMatCost,
		decimal? UnitMatCostConv,
		decimal? UnitFreightCost,
		decimal? UnitFreightCostConv,
		decimal? UnitDutyCost,
		decimal? UnitDutyCostConv,
		decimal? UnitBrokerageCost,
		decimal? UnitBrokerageCostConv,
		decimal? UnitInsuranceCost,
		decimal? UnitInsuranceCostConv,
		decimal? UnitLocFrtCost,
		decimal? UnitLocFrtCostConv,
		string Infobar,
		string PoNum,
		int? DispMsg = 0,
		string Site = null,
		string Whse = null,
		int? PoLine = null,
		string AUContractPriceMethod = null,
		string ContractID = null);
	}
}

