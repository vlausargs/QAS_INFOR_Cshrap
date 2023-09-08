//PROJECT NAME: Data
//CLASS NAME: IGetItemCst.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetItemCst
	{
		(int? ReturnCode,
			decimal? UnitCost,
			decimal? MatlCost,
			decimal? LbrCost,
			decimal? FovhdCost,
			decimal? VovhdCost,
			decimal? OutCost,
			decimal? UnitPrice,
			decimal? UnitDutyCost,
			decimal? UnitFreightCost,
			decimal? UnitBrokerageCost,
			decimal? UnitInsuranceCost,
			decimal? UnitLocFrtCost,
			decimal? UnitWeight,
			string Origin,
			decimal? UnitMatCost,
			string Infobar) GetItemCstSp(
			int? PriceOnly,
			string Item,
			string Pricecode,
			decimal? QtyReq,
			decimal? UnitCost,
			decimal? MatlCost,
			decimal? LbrCost,
			decimal? FovhdCost,
			decimal? VovhdCost,
			decimal? OutCost,
			decimal? UnitPrice,
			decimal? UnitDutyCost,
			decimal? UnitFreightCost,
			decimal? UnitBrokerageCost,
			decimal? UnitInsuranceCost,
			decimal? UnitLocFrtCost,
			decimal? UnitWeight,
			string Origin,
			decimal? UnitMatCost,
			string Infobar,
			string TransferFromSite = null,
			string TransferToSite = null,
			decimal? TransferExchRate = null,
			DateTime? TransferOrderDate = null,
			string Whse = null);
	}
}

