//PROJECT NAME: Logistics
//CLASS NAME: ICoItemPriceBreakMarkup.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICoItemPriceBreakMarkup
	{
		(int? ReturnCode,
		string InfoBar) CoItemPriceBreakMarkupSp(
			string CoNum,
			int? CoLine,
			int? VendorPriceBreaks,
			decimal? ItemQty,
			decimal? ProdCycles,
			decimal? QtyPerCycle,
			string Item,
			DateTime? DueDate,
			string Whse,
			string BOMType,
			string Resource,
			string CoProductMix,
			string AlternateID,
			string PriceBasis,
			decimal? PriceBasisValue,
			decimal? CoDisc,
			string InfoBar);
	}
}

