//PROJECT NAME: Finance
//CLASS NAME: IArpmtCalcExchRate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AR
{
	public interface IArpmtCalcExchRate
	{
		(int? ReturnCode,
			decimal? PExchRate) ArpmtCalcExchRateSp(
			string PCurrCode,
			decimal? PDomAmt,
			decimal? PForAmt,
			decimal? PExchRate);
	}
}

