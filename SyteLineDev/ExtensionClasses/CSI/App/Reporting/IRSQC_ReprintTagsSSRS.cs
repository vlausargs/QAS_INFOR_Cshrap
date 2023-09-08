//PROJECT NAME: Reporting
//CLASS NAME: IRSQC_ReprintTagsSSRS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRSQC_ReprintTagsSSRS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) RSQC_ReprintTagsSSRSSp(int? i_rcvrnum,
		string i_stat,
		DateTime? i_transdate,
		decimal? i_qtychar,
		int? i_numtags,
		string psite);
	}
}

