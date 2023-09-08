//PROJECT NAME: Finance
//CLASS NAME: ICHSDetailLeftOverAmtGroupAccount.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Chinese
{
	public interface ICHSDetailLeftOverAmtGroupAccount
	{
		(int? ReturnCode,
			decimal? Pstartdr,
			decimal? Pstartcr,
			decimal? Pdramount,
			decimal? Pcramount,
			decimal? Penddr,
			decimal? Pendcr) CHSDetailLeftOverAmtGroupAccountSP(
			string Group,
			int? Pseq,
			decimal? Pstartdr,
			decimal? Pstartcr,
			decimal? Pdramount,
			decimal? Pcramount,
			decimal? Penddr,
			decimal? Pendcr,
			DateTime? Psdate,
			DateTime? Pedate);
	}
}

