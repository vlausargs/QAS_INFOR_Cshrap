//PROJECT NAME: Logistics
//CLASS NAME: ITHAGetTaxAccts.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ITHAGetTaxAccts
	{
		(int? ReturnCode, string rChartAcct,
		string rAccessUnit1,
		string rAccessUnit2,
		string rAccessUnit3,
		string rAccessUnit4,
		string rDescription,
		string Infobar) THAGetTaxAcctsSp(string TaxCode,
		string pSite,
		string pType,
		string pVendNum,
		decimal? pDiscAmt,
		string rChartAcct,
		string rAccessUnit1,
		string rAccessUnit2,
		string rAccessUnit3,
		string rAccessUnit4,
		string rDescription,
		string Infobar);
	}
}

