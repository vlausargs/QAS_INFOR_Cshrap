//PROJECT NAME: Logistics
//CLASS NAME: IAU_CalculateCustomeOrderLinePrice.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IAU_CalculateCustomeOrderLinePrice
	{
		(int? ReturnCode,
			string ItemUM,
			decimal? PriceConv,
			string Infobar,
			int? DispMsg,
			decimal? LineDisc,
			int? TaxInPriceDiff) AU_CalculateCustomeOrderLinePriceSp(
			string CoNum,
			string CustNum,
			string Item,
			string ItemUM,
			string CustItem,
			string ShipSite,
			DateTime? OrderDate,
			decimal? InQtyConv,
			string CurrCode,
			string ItemPriceCode,
			decimal? PriceConv,
			string Infobar,
			int? CoLine,
			int? DispMsg = 0,
			string ItemWhse = null,
			decimal? LineDisc = 0,
			int? TaxInPriceDiff = 0,
			string PromotionCode = null,
			string AUContractPriceMethod = null,
			string ConTractID = null);
	}
}

