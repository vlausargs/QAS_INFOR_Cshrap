//PROJECT NAME: Logistics
//CLASS NAME: IGetPOBlanketReleaseCost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IGetPOBlanketReleaseCost
	{
		(int? ReturnCode, decimal? UnitMatCostConv,
		decimal? UnitFreightCostConv,
		decimal? UnitDutyCostConv,
		decimal? UnitBrokerageCostConv,
		decimal? UnitInsuranceCostConv,
		decimal? UnitLocFrtCostConv,
		decimal? ItemCostConv) GetPOBlanketReleaseCostSp(string PoNum,
		int? PoLine,
		decimal? UnitMatCostConv,
		decimal? UnitFreightCostConv,
		decimal? UnitDutyCostConv,
		decimal? UnitBrokerageCostConv,
		decimal? UnitInsuranceCostConv,
		decimal? UnitLocFrtCostConv,
		decimal? ItemCostConv);
	}
}

