//PROJECT NAME: Logistics
//CLASS NAME: IPoitemValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IPoitemValid
	{
		(int? ReturnCode, string Item,
		string ItemDesc,
		int? SerialTracked,
		int? LotTracked,
		decimal? QtyOrdered,
		decimal? QtyReceived,
		int? EnableContainer,
		string Infobar,
		string Whse) PoitemValidSp(string PoNum,
		int? PoLine,
		int? PoRelease,
		string Item,
		string ItemDesc,
		int? SerialTracked,
		int? LotTracked,
		decimal? QtyOrdered,
		decimal? QtyReceived,
		int? EnableContainer,
		string Infobar,
		string Whse);
	}
}

