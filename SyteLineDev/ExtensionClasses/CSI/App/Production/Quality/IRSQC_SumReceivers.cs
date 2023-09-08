//PROJECT NAME: Production
//CLASS NAME: IRSQC_SumReceivers.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_SumReceivers
	{
		(int? ReturnCode, decimal? qty_received_tot,
		decimal? qty_accepted_tot,
		decimal? qty_rejected_tot,
		decimal? qty_hold_tot,
		string Infobar) RSQC_SumReceiversSp(string i_item,
		string i_ref_type,
		string i_entity,
		string i_test_type = null,
		int? i_test_seq = null,
		decimal? qty_received_tot = null,
		decimal? qty_accepted_tot = null,
		decimal? qty_rejected_tot = null,
		decimal? qty_hold_tot = null,
		string Infobar = null);
	}
}

