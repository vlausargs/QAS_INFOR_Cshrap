//PROJECT NAME: Reporting
//CLASS NAME: IRpt_GSTInputTaxCredit.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_GSTInputTaxCredit
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_GSTInputTaxCreditSp(int? TTaxSystem = null,
		string TTaxCode = null,
		DateTime? TaxPreDateStarting = null,
		DateTime? TaxPreDateEnding = null,
		int? TaxPreDateStartingOffset = null,
		int? TaxPreDateEndingOffset = null,
		int? PDisplayHeader = null,
		string BGSessionId = null,
		string pSite = null,
		string BGUser = null);
	}
}

