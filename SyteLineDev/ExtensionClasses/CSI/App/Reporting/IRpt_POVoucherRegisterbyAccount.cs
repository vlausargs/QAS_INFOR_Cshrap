//PROJECT NAME: Reporting
//CLASS NAME: IRpt_POVoucherRegisterbyAccount.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_POVoucherRegisterbyAccount
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_POVoucherRegisterbyAccountSp(string StartAccount = null,
		string EndAccount = null,
		string StartItem = null,
		string EndItem = null,
		DateTime? StartInvDate = null,
		DateTime? EndInvDate = null,
		int? TransDomCurr = 1,
		int? StartVoucher = null,
		int? EndVoucher = null,
		string StartVendor = null,
		string EndVendor = null,
		string StartPO = null,
		string EndPO = null,
		string StartGRN = null,
		string EndGRN = null,
		int? StartDateOffset = null,
		int? EndDateOffset = null,
		int? PDisplayHeader = null,
		string PMessageLanguage = null,
		string BGSessionId = null,
		int? TaskId = null,
		string pSite = null);
	}
}

