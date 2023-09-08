//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RSQC_SupVRMAStatusSSRS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RSQC_SupVRMAStatusSSRS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_SupVRMAStatusSSRSSp(string begitem = null,
		string enditem = null,
		string begvend = null,
		string endvend = null,
		DateTime? begcdate = null,
		DateTime? endcdate = null,
		string sortby = null,
		int? displayheader = null,
		string psite = null);
	}
}

