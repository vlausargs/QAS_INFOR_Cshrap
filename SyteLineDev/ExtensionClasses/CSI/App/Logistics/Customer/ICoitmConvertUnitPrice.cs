//PROJECT NAME: Logistics
//CLASS NAME: ICoitmConvertUnitPrice.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICoitmConvertUnitPrice
	{
		(int? ReturnCode,
			decimal? PriceConv,
			decimal? Price,
			string Infobar) CoitmConvertUnitPriceSp(
			string ItemUM,
			string Item,
			string CustNum,
			string CurrCode,
			string ConvertTo,
			string Site = null,
			decimal? PriceConv = null,
			decimal? Price = null,
			string Infobar = null);
	}
}

