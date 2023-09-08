//PROJECT NAME: Production
//CLASS NAME: IRSQC_CreateTrr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_CreateTrr
	{
		(int? ReturnCode, string o_trr,
		string Infobar) RSQC_CreateTrrSp(int? i_trcvr,
		string o_trr,
		string Infobar);
	}
}

