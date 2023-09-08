//PROJECT NAME: BusInterface
//CLASS NAME: ILoadProcessReqLine.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ILoadProcessReqLine
	{
		(int? ReturnCode, string Infobar) LoadProcessReqLineSp(string LineReqNum,
		int? ReqLine,
		string ActionCode,
		string Item,
		string Description,
		decimal? QtyOrderedConv,
		string UM,
		decimal? UnitMatCostConv,
		string CurrCode,
		DateTime? DueDate,
		string Whse,
		string VendNum,
		string Infobar);
	}
}

