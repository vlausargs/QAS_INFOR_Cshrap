//PROJECT NAME: Finance
//CLASS NAME: ICHSGLGroupAccount.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Chinese
{
	public interface ICHSGLGroupAccount
	{
		(int? ReturnCode,
			decimal? Pstartdr,
			decimal? Pstartcr,
			decimal? Pdramount,
			decimal? Pcramount,
			decimal? Penddr,
			decimal? Pendcr) CHSGLGroupAccountSP(
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

