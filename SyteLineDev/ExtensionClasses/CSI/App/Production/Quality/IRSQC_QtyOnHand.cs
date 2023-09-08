//PROJECT NAME: Production
//CLASS NAME: IRSQC_QtyOnHand.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_QtyOnHand
	{
		(int? ReturnCode, decimal? o_qtyonhand,
		string Infobar) RSQC_QtyOnHandSp(string i_item = null,
		string i_whse = null,
		decimal? o_qtyonhand = null,
		string Infobar = null);
	}
}

