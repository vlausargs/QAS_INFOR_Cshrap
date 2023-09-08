//PROJECT NAME: Logistics
//CLASS NAME: IRmaReplUM.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IRmaReplUM
	{
		(int? ReturnCode, decimal? RQtyConv,
		decimal? RUnitPrice,
		string Infobar) RmaReplUMSp(string POldUM,
		string PNewUM,
		string PItem,
		string PCustNum,
		decimal? RQtyConv,
		decimal? RUnitPrice,
		string Infobar);
	}
}

