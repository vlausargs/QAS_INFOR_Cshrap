//PROJECT NAME: Finance
//CLASS NAME: ICHSGLOneAccount.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Chinese
{
	public interface ICHSGLOneAccount
	{
		(int? ReturnCode,
			decimal? Psbalance,
			decimal? Pdamount,
			decimal? Pcamount,
			decimal? Pebalance) CHSGLOneAccountSp(
			string PAcct,
			DateTime? Psdate,
			DateTime? Pedate,
			decimal? Psbalance,
			decimal? Pdamount,
			decimal? Pcamount,
			decimal? Pebalance);
	}
}

