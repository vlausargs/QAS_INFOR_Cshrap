//PROJECT NAME: Reporting
//CLASS NAME: IRpt_VoucherPreregister.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_VoucherPreregister
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_VoucherPreregisterSp(int? PreregisterStarting = null,
		int? PreregisterEnding = null,
		string VendorNumStarting = null,
		string VendorNumEnding = null,
		string NameStarting = null,
		string NameEnding = null,
		DateTime? VoucherDateStarting = null,
		DateTime? VoucherDateEnding = null,
		string ExOptszSortPreVend = null,
		string Status = null,
		int? ExOptszShowDetail = null,
		int? ExOptszTransDomCurr = null,
		int? VoucherDateStartingOffset = null,
		int? VoucherDateEndingOffset = null,
		int? DisplayHeader = null,
		string BGSessionId = null,
		int? TaskId = null,
		string pSite = null);
	}
}

