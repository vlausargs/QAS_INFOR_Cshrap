//PROJECT NAME: Finance
//CLASS NAME: ICHSDetailLeftOverOneAccount.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Chinese
{
	public interface ICHSDetailLeftOverOneAccount
	{
		(int? ReturnCode,
			decimal? Psbalance,
			decimal? Pdamount,
			decimal? Pcamount,
			decimal? Pebalance) CHSDetailLeftOverOneAccountSp(
			string PAcct,
			string Punit1,
			string PUnit2,
			string PUnit3,
			string PUnit4,
			DateTime? Psdate,
			DateTime? Pedate,
			decimal? Psbalance,
			decimal? Pdamount,
			decimal? Pcamount,
			decimal? Pebalance);
	}
}

