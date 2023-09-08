//PROJECT NAME: Logistics
//CLASS NAME: IUpdatePOReqLine.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IUpdatePOReqLine
	{
		(int? ReturnCode, string Infobar) UpdatePOReqLineSp(decimal? QtyConv,
		decimal? PriceConv,
		string NonBaseUM,
		string Item,
		DateTime? DueDate,
		string ReqNum,
		int? ReqLine,
		string IprId,
		decimal? IprSeq,
		string Infobar);
	}
}

