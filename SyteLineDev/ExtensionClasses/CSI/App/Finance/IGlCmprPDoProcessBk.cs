//PROJECT NAME: Finance
//CLASS NAME: IGlCmprPDoProcessBk.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IGlCmprPDoProcessBk
	{
		int? GlCmprPDoProcessBkSp(string CompressBy,
		string CompressionLevel,
		int? AnalyticalLedger,
		DateTime? PerStart,
		DateTime? PerEnd,
		string AcctStart,
		string AcctEnd,
		string Site,
		decimal? UserId,
		string CurrentCultureName,
		decimal? BGTaskId);
	}
}

