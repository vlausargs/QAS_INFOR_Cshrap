//PROJECT NAME: Finance
//CLASS NAME: IArpmtCalcEuroAmt.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AR
{
	public interface IArpmtCalcEuroAmt
	{
		decimal? ArpmtCalcEuroAmtFn(
			decimal? PCheckAmt,
			string PCurrCode);
	}
}

