//PROJECT NAME: Production
//CLASS NAME: IRSQC_RePrintTags.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_RePrintTags
	{
		(ICollectionLoadResponse Data, int? ReturnCode) RSQC_RePrintTagssp(
			int? i_rcvrnum,
			string i_stat,
			DateTime? i_transdate,
			decimal? i_qtychar,
			int? i_numtags);
	}
}

