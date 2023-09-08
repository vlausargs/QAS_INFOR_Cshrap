//PROJECT NAME: Reporting
//CLASS NAME: IRpt_VAT.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_VAT
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_VATSp(int? TaxJurTaxSystem = null,
		int? ExOptszShowDetail = null,
		string TaxJurTaxJur = null,
		DateTime? ExBegInvStaxInvDate = null,
		DateTime? ExEndInvStaxInvDate = null,
		int? TaxDateStartingOffset = null,
		int? TaxDateEndingOffset = null,
		string ExOptgoJournalId = null,
		int? DisplayHeader = null,
		string BGSessionId = null,
		int? TaskId = null,
		string pSite = null,
		string BGUser = null,
		string SortBy = null,
		int? ExcludeNullLineNum = 0,
		int? ExcludeJournalEntries = 0);
	}
}

