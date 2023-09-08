//PROJECT NAME: Production
//CLASS NAME: IRSQC_RcvrUpdate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_RcvrUpdate
	{
		(int? ReturnCode, string Infobar) RSQC_RcvrUpdateSp(int? RcvrNum = null,
		decimal? Qty = null,
		int? Complete = null,
		string Infobar = null);
	}
}

