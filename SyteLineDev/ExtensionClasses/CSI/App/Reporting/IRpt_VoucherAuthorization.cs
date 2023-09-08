//PROJECT NAME: Reporting
//CLASS NAME: IRpt_VoucherAuthorization.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_VoucherAuthorization
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_VoucherAuthorizationSp(int? POLineRel = null,
		int? PrintGoodsReceiveNote = null,
		int? DisplayVoucherTotal = null,
		int? TransDomCurr = null,
		int? PageBetweenAuth = null,
		string SortBy = null,
		string StartAuthorizer = null,
		string EndAuthorizer = null,
		int? StartVoucher = null,
		int? EndVoucher = null,
		DateTime? StartInvDate = null,
		DateTime? EndInvDate = null,
		string StartVendor = null,
		string EndVendor = null,
		string StartName = null,
		string EndName = null,
		string StartPO = null,
		string EndPO = null,
		string StartGRN = null,
		string EndGRN = null,
		int? StartDateOffset = null,
		int? EndDateOffset = null,
		int? DisplayHeader = 1,
		string BGSessionId = null,
		int? TaskId = null,
		string pSite = null);
	}
}

