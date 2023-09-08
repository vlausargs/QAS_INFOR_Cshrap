//PROJECT NAME: Reporting
//CLASS NAME: IRpt_VoucherTransaction.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_VoucherTransaction
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_VoucherTransactionSp(string VendorStarting = null,
		string VendorEnding = null,
		string NameStarting = null,
		string NameEnding = null,
		int? PrintVoucherTotal = null,
		int? VoucherStarting = null,
		int? VoucherEnding = null,
		DateTime? DueDateStarting = null,
		DateTime? DueDateEnding = null,
		DateTime? DistDateStarting = null,
		DateTime? DistDateEnding = null,
		int? DueDateStartingOffset = null,
		int? DueDateEndingOffset = null,
		int? DistDateStartingOffset = null,
		int? DistDateEndingOffset = null,
		string SortBy = null,
		string AuthStatus = null,
		int? DisplayHeader = null,
		string pSite = null);
	}
}

