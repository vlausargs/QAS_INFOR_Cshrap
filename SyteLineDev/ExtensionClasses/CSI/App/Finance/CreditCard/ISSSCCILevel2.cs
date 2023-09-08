//PROJECT NAME: Finance
//CLASS NAME: ISSSCCILevel2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.CreditCard
{
	public interface ISSSCCILevel2
	{
		(int? ReturnCode,
			string CustPo,
			decimal? TaxAmt,
			string ShipToName,
			string ShipToStreet,
			string ShipToCity,
			string ShipToState,
			string ShipToZip,
			string ShipToCountryCode,
			decimal? TaxRate) SSSCCILevel2Sp(
			string InvNum,
			string CustPo,
			decimal? TaxAmt,
			string ShipToName,
			string ShipToStreet,
			string ShipToCity,
			string ShipToState,
			string ShipToZip,
			string ShipToCountryCode,
			decimal? TaxRate = 0);
	}
}

