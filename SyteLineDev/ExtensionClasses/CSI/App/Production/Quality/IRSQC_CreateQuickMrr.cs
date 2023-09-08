//PROJECT NAME: Production
//CLASS NAME: IRSQC_CreateQuickMrr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_CreateQuickMrr
	{
		(int? ReturnCode, string o_Messages,
		int? o_rcvr,
		string o_mrr,
		string Infobar) RSQC_CreateQuickMrrSp(int? i_rcvr,
		string i_problem,
		int? i_UseHoldLoc,
		string i_MRRLoc,
		string o_Messages,
		int? o_rcvr,
		string o_mrr,
		string Infobar);
	}
}

