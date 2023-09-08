//PROJECT NAME: Finance
//CLASS NAME: ISSSVTXGetECCountry.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.TaxInterface
{
	public interface ISSSVTXGetECCountry
	{
		string SSSVTXGetECCountryFn(
			string Country);
	}
}

