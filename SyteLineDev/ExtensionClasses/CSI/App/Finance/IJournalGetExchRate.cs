//PROJECT NAME: Finance
//CLASS NAME: IJournalGetExchRate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IJournalGetExchRate
	{
		(int? ReturnCode,
			decimal? PExchRate,
			int? PFixedEuro,
			string Infobar) JournalGetExchRateSp(
			string PCurrCode,
			DateTime? TransDate,
			decimal? PExchRate,
			int? PFixedEuro,
			string Infobar);
	}
}

