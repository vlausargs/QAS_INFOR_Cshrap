//PROJECT NAME: Reporting
//CLASS NAME: IRpt_VendorASNReconciliation.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_VendorASNReconciliation
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_VendorASNReconciliationSp(string StartingGrn = null,
			string EndingGrn = null,
			string StartingVendor = null,
			string EndingVendor = null,
			DateTime? StartingHdrDate = null,
			DateTime? EndingHdrDate = null,
			int? ExceptionsOnly = 0,
			int? PrintGrnHdrNotes = 0,
			int? PrintGrnLineNotes = 0,
			int? ShowInternalNotes = 0,
			int? ShowExternalNotes = 0,
			int? StartingHdrDateOffset = null,
			int? EndingHdrDateOffset = null,
			int? DisplayHeader = 1,
			int? TaskId = null,
			string pSite = null,
			int? PrintItemOverview = 0);
	}
}

