//PROJECT NAME: Logistics
//CLASS NAME: ICoitemValidateQtyOrdered.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICoitemValidateQtyOrdered
	{
		(int? ReturnCode, decimal? QtyReady,
		string Infobar,
		int? DispMsg) CoitemValidateQtyOrderedSp(int? NewRecord,
		string CoNum,
		int? CoLine,
		string Item,
		string UM,
		string CoCustNum,
		string CurrCode,
		string ItemPriceCode,
		decimal? QtyOrderedConv,
		string CustItem,
		string ShipSite,
		DateTime? CoOrderDate,
		string Whse,
		string RefType,
		decimal? Price,
		decimal? QtyReady,
		string Infobar,
		int? DispMsg = 0);
	}
}

