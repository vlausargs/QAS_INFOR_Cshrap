//PROJECT NAME: Production
//CLASS NAME: IRSQC_CreateEachTests.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_CreateEachTests
	{
		(int? ReturnCode, string Infobar) RSQC_CreateEachTestsSp(int? i_rcvr,
		DateTime? i_trans_date,
		decimal? i_num_entries,
		string Infobar);
	}
}

