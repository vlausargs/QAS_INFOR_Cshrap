//PROJECT NAME: Reporting
//CLASS NAME: IRpt_VendorVoucherDebitMemo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_VendorVoucherDebitMemo
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_VendorVoucherDebitMemoSp(int? DetailPurchaseOrder = 0,
		int? DetailItem = 0,
		int? DetailVendorItem = 0,
		int? VendorProfileUseProfile = 0,
		string VendorStarting = null,
		string VendorEnding = null,
		int? VoucherStarting = null,
		int? VoucherEnding = null,
		string PoNumStarting = null,
		string PoNumEnding = null,
		string InvNumStarting = null,
		string InvNumEnding = null,
		DateTime? VoucherDateStarting = null,
		DateTime? VoucherDateEnding = null,
		int? VoucherDateStartingOffset = null,
		int? VoucherDateEndingOffset = null,
		int? VoucherDateIncrement = 0,
		int? DisplayHeader = 0,
		int? ShowInternal = 0,
		int? ShowExternal = 0,
		int? PrintItemOverview = 0,
		int? TaskID = null,
		string BGSessionId = null,
		string pSite = null);
	}
}

