//PROJECT NAME: Production
//CLASS NAME: IRSQC_CreateVrma.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_CreateVrma
	{
		(int? ReturnCode, int? o_vrma,
		string Infobar) RSQC_CreateVrmaSp(string i_mrr,
		decimal? i_qty,
		string i_vend,
		string i_reason,
		int? o_vrma,
		string Infobar);
	}
}

