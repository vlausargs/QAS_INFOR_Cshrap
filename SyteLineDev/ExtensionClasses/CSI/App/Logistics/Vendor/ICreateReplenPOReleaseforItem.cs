//PROJECT NAME: Logistics
//CLASS NAME: ICreateReplenPOReleaseforItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ICreateReplenPOReleaseforItem
	{
		(int? ReturnCode, int? PPoLine,
		int? PPoRelease,
		decimal? PExchRate,
		decimal? PUnitMatCostConv,
		decimal? PUnitBrokerageCostConv,
		decimal? PUnitFreightCostConv,
		decimal? PUnitInsuranceCostConv,
		decimal? PUnitDutyCostConv,
		decimal? PUnitLocFrtCostConv,
		decimal? PUnitMatCost,
		decimal? PUnitBrokerageCost,
		decimal? PUnitFreightCost,
		decimal? PUnitInsuranceCost,
		decimal? PUnitDutyCost,
		decimal? PUnitLocFrtCost,
		decimal? PItemCostConv,
		decimal? PExtendedItemCostConv,
		string PUbWorkKey,
		Guid? PPoitemRowPointer,
		string Infobar) CreateReplenPOReleaseforItemSp(string CurWhse,
		string PoNum,
		string Item,
		string VendNum,
		decimal? ReqQty,
		string UM,
		int? PPoLine,
		int? PPoRelease,
		decimal? PExchRate,
		decimal? PUnitMatCostConv,
		decimal? PUnitBrokerageCostConv,
		decimal? PUnitFreightCostConv,
		decimal? PUnitInsuranceCostConv,
		decimal? PUnitDutyCostConv,
		decimal? PUnitLocFrtCostConv,
		decimal? PUnitMatCost,
		decimal? PUnitBrokerageCost,
		decimal? PUnitFreightCost,
		decimal? PUnitInsuranceCost,
		decimal? PUnitDutyCost,
		decimal? PUnitLocFrtCost,
		decimal? PItemCostConv,
		decimal? PExtendedItemCostConv,
		string PUbWorkKey,
		Guid? PPoitemRowPointer,
		string Infobar);
	}
}

