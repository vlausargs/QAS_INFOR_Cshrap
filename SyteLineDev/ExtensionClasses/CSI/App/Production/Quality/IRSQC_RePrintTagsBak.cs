//PROJECT NAME: Production
//CLASS NAME: IRSQC_RePrintTagsBak.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_RePrintTagsBak
	{
		(ICollectionLoadResponse Data, int? ReturnCode) RSQC_RePrintTagsBaksp(
			int? i_rcvrnum,
			string i_stat,
			DateTime? i_transdate,
			decimal? i_qty,
			int? i_numtags);
	}
}

