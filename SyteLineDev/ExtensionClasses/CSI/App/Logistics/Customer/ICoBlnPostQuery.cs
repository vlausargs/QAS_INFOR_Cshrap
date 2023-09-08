//PROJECT NAME: Logistics
//CLASS NAME: ICoBlnPostQuery.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICoBlnPostQuery
	{
		(int? ReturnCode, decimal? QtyReserved,
		decimal? QtyShipped,
		decimal? QtyReleased,
		string Infobar) CoBlnPostQuerySp(string CoNum,
		int? CoLine,
		decimal? QtyReserved,
		decimal? QtyShipped,
		decimal? QtyReleased,
		string Infobar,
		string Site = null);
	}
}

