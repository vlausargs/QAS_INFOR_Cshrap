//PROJECT NAME: Data
//CLASS NAME: IInvTransDist.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IInvTransDist
	{
		(int? ReturnCode,
			string Infobar,
			decimal? PTcAmtTAmount,
			decimal? PTcAmtFtotDr,
			decimal? PTcAmtFTotCr,
			decimal? PDomTcAmtAmount,
			decimal? PDomTcAmtDr,
			decimal? PDomTcAmtCr) InvTransDistSp(
			string Infobar,
			int? PSysGen,
			int? PGainLoss,
			decimal? PExchRate,
			string PCurrCode,
			string PAcct,
			string PAcctUnit1,
			string PAcctUnit2,
			string PAcctUnit3,
			string PAcctUnit4,
			string PAcctDesc,
			decimal? PTcAmtTAmount,
			decimal? PTcAmtFtotDr,
			decimal? PTcAmtFTotCr,
			decimal? PDomTcAmtAmount,
			decimal? PDomTcAmtDr,
			decimal? PDomTcAmtCr);
	}
}

