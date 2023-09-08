//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RSQC_SupVendorPerformance.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RSQC_SupVendorPerformance
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_SupVendorPerformanceSp(
			string begvend = null,
			string endvend = null,
			DateTime? begtdate = null,
			DateTime? endtdate = null,
			string begitem = null,
			string enditem = null,
			int? showdetail = null,
			int? displayheader = null);
	}
}

