//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RSQC_SupVendorPPMSSRS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RSQC_SupVendorPPMSSRS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_SupVendorPPMSSRSSp(string begitem = null,
		string enditem = null,
		string begvend = null,
		string endvend = null,
		DateTime? begtdate = null,
		DateTime? endtdate = null,
		string sortby = null,
		int? displayheader = null,
		string psite = null);
	}
}

