//PROJECT NAME: Data
//CLASS NAME: IGetAmountFromChartD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetAmountFromChartD
	{
		(ICollectionLoadResponse Data, int? ReturnCode) GetAmountFromChartDSp(
			DateTime? PDate,
			decimal? PDomAmount,
			string PAcct,
			int? PDomCurrencyPlaces,
			decimal? PForDAmount);
	}
}

