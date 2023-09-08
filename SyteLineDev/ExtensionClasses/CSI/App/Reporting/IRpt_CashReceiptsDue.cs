//PROJECT NAME: Reporting
//CLASS NAME: IRpt_CashReceiptsDue.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_CashReceiptsDue
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_CashReceiptsDueSp(int? TransDomCurr = null,
		string StartCustNum = null,
		string EndCustNum = null,
		string CurSiteGroup = null,
		int? DisplayHeader = null,
		int? TaskId = null,
		string pSite = null);
	}
}

