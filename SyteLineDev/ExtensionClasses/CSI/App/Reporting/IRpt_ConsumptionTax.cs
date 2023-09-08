//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ConsumptionTax.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ConsumptionTax
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ConsumptionTaxSp(int? TranslateToDomesticCurrency = null,
		int? DisplayHeader = null,
		int? Year = null,
		int? Period = null,
		string Style = null,
		string pSite = null);
	}
}

