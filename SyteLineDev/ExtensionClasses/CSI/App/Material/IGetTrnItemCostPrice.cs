//PROJECT NAME: Material
//CLASS NAME: IGetTrnItemCostPrice.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IGetTrnItemCostPrice
	{
		(int? ReturnCode, string Origin,
		decimal? UnitWeight,
		decimal? UnitCost,
		decimal? UnitCostConv,
		decimal? MatlCost,
		decimal? LbrCost,
		decimal? FovhdCost,
		decimal? VovhdCost,
		decimal? OutCost,
		decimal? UnitPrice,
		decimal? UnitPriceConv,
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
		decimal? UnitTotalCost,
		decimal? ExtPrice,
		string Infobar) GetTrnItemCostPriceSp(string TrnNum,
		string Item,
		string Pricecode,
		decimal? QtyReq,
		int? PriceOnly,
		int? Update,
		int? TrnLine,
		string FromSite,
		string ToSite,
		string UM,
		string Origin,
		decimal? UnitWeight,
		decimal? UnitCost,
		decimal? UnitCostConv,
		decimal? MatlCost,
		decimal? LbrCost,
		decimal? FovhdCost,
		decimal? VovhdCost,
		decimal? OutCost,
		decimal? UnitPrice,
		decimal? UnitPriceConv,
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
		decimal? UnitTotalCost,
		decimal? ExtPrice,
		string Infobar,
		string Whse);
	}
}

