//PROJECT NAME: Data
//CLASS NAME: IEuroCustProjMs.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEuroCustProjMs
	{
		int? EuroCustProjMsSp(
			Guid? pProjRowPointer,
			int? pToCurrencyPlaces,
			int? pForToEuro);
	}
}

