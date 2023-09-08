//PROJECT NAME: Data
//CLASS NAME: IEuroCustSumCo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEuroCustSumCo
	{
		int? EuroCustSumCoSp(
			string pUpdateOrderType,
			string pCoNum,
			int? pCurrencyPlaces);
	}
}

