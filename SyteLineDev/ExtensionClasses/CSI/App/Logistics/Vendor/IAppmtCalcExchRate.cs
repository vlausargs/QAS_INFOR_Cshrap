//PROJECT NAME: Logistics
//CLASS NAME: IAppmtCalcExchRate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IAppmtCalcExchRate
	{
		(int? ReturnCode,
			decimal? PExchRate) AppmtCalcExchRateSp(
			string PCurrCode,
			decimal? PDomAmt,
			decimal? PForAmt,
			decimal? PExchRate);
	}
}

