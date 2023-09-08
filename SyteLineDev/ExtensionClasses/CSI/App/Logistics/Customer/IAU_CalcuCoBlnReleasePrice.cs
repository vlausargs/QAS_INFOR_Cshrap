//PROJECT NAME: Logistics
//CLASS NAME: IAU_CalcuCoBlnReleasePrice.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IAU_CalcuCoBlnReleasePrice
	{
		(int? ReturnCode,
			string Infobar) AU_CalcuCoBlnReleasePriceSp(
			string CoNum,
			string CustNum,
			string Item,
			string ItemUM,
			string CustItem,
			string ShipSite,
			string CurrCode,
			string ItemPriceCode,
			decimal? PriceConv,
			DateTime? OrderDate,
			string Infobar,
			int? CoLine,
			string ItemWhse = null);
	}
}

