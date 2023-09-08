//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ECVAT.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ECVAT
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ECVATsp(int? TaxJurTaxSystem = null,
		int? ExOptszShowDetail = null,
		string TaxJurTaxJur = null,
		DateTime? ExBegInvStaxInvDate = null,
		DateTime? ExEndInvStaxInvDate = null,
		int? ExOptprPostTrx = null,
		int? TaxDateStartingOffset = null,
		int? TaxDateEndingOffset = null,
		string ExOptgoJournalId = null,
		int? DisplayHeader = null,
		string BGSessionId = null,
		int? TaskId = null,
		string pSite = null,
		string BGUser = null);
	}
}

