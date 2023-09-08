//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RSQC_VRMAPendingSSRS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RSQC_VRMAPendingSSRS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_VRMAPendingSSRSSp(string BegItem = null,
		string EndItem = null,
		string BegVendor = null,
		string EndVendor = null,
		int? BegVrma = null,
		int? EndVrma = null,
		DateTime? BegDate = null,
		DateTime? EndDate = null,
		int? _internal = null,
		int? external = null,
		string orderby = null,
		string psite = null);
	}
}

