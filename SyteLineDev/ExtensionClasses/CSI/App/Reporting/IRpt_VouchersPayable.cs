//PROJECT NAME: Reporting
//CLASS NAME: IRpt_VouchersPayable.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_VouchersPayable
	{
		(ICollectionLoadResponse Data,int? ReturnCode) Rpt_VouchersPayableSp(string POType = null,
			int? TransDomCurr = null,
			int? ShowDetail = null,
			DateTime? CutoffDate = null,
			string PoStarting = null,
			string PoEnding = null,
			string VendorStarting = null,
			string VendorEnding = null,
			int? CutoffDateOffset = null,
			int? DisplayHeader = null,
			string SiteGroup = null,
			string BuilderPoStarting = null,
			string BuilderPoEnding = null,
			int? TaskId = null,
			int? PrintItemOverview = null,
			string BGSessionId = null,
			string pSite = null);
	}
}

