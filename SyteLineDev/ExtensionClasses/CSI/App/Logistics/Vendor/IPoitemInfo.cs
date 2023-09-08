//PROJECT NAME: Logistics
//CLASS NAME: IPoitemInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IPoitemInfo
	{
		(int? ReturnCode, string OutItem,
		string OutItemDesc,
		string OutUM,
		decimal? QtyShipped) PoitemInfoSp(string PoNum,
		int? PoLine,
		int? PoRelease,
		string OutItem,
		string OutItemDesc,
		string OutUM,
		decimal? QtyShipped);
	}
}

