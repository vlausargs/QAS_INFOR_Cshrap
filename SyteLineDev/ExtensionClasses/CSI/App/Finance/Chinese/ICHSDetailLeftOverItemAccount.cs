//PROJECT NAME: Finance
//CLASS NAME: ICHSDetailLeftOverItemAccount.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Chinese
{
	public interface ICHSDetailLeftOverItemAccount
	{
		(int? ReturnCode,
			decimal? Psdebit,
			decimal? Pscredit,
			decimal? Pdebitamt,
			decimal? Pcreditamt,
			decimal? Pedebit,
			decimal? Pecredit,
			DateTime? Psdate,
			DateTime? Pedate) CHSDetailLeftOverItemAccountSP(
			string Group,
			int? Psseq,
			int? Peseq,
			decimal? Psdebit = 0,
			decimal? Pscredit = 0,
			decimal? Pdebitamt = 0,
			decimal? Pcreditamt = 0,
			decimal? Pedebit = 0,
			decimal? Pecredit = 0,
			DateTime? Psdate = null,
			DateTime? Pedate = null);
	}
}

