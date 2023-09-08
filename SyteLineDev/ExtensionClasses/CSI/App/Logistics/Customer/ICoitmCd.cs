//PROJECT NAME: Logistics
//CLASS NAME: ICoitmCd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICoitmCd
	{
		(int? ReturnCode, string Infobar) CoitmCdSp(string CoNum,
		int? CoLine,
		int? CoRelease,
		string Stat = null,
		decimal? QtyOrdered = null,
		decimal? QtyShipped = null,
		decimal? QtyReturned = null,
		string Infobar = null,
		string ShipSite = null);
	}
}

