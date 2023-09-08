//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RSQC_CustRMAAnalysisSSRS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RSQC_CustRMAAnalysisSSRS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_CustRMAAnalysisSSRSSp(string begitem = null,
		string enditem = null,
		string begcust = null,
		string endcust = null,
		DateTime? begtdate = null,
		DateTime? endtdate = null,
		string sortby = null,
		int? displayheader = null,
		string psite = null);
	}
}

