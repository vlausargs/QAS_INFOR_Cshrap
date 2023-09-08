//PROJECT NAME: Logistics
//CLASS NAME: IEDICalculateCoitemPrice.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IEDICalculateCoitemPrice
	{
		(int? ReturnCode, decimal? PriceConv,
		string Infobar) EDICalculateCoitemPriceSp(string CoNum,
		string CustNum,
		string Item,
		string UM,
		DateTime? EffDate,
		DateTime? ExpDate,
		decimal? QtyConv,
		string CurrCode,
		string PriceCode,
		decimal? PriceConv,
		string Infobar,
		string ItemWhse = null);
	}
}

