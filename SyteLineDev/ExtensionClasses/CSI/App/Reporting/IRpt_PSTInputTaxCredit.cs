//PROJECT NAME: Reporting
//CLASS NAME: IRpt_PSTInputTaxCredit.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_PSTInputTaxCredit
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_PSTInputTaxCreditSp(int? TaxSystem = null,
		string TaxCode = null,
		DateTime? TaxDateStarting = null,
		DateTime? TaxDateEnding = null,
		int? TaxDateStartingOffset = null,
		int? TaxDateEndingOffset = null,
		int? DisplayHeader = null,
		string pSite = null);
	}
}

