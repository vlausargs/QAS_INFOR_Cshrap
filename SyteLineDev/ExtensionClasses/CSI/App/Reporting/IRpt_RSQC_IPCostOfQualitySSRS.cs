//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RSQC_IPCostOfQualitySSRS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RSQC_IPCostOfQualitySSRS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_IPCostOfQualitySSRSSp(string begitem = null,
		string enditem = null,
		DateTime? begddate = null,
		DateTime? endddate = null,
		string begmrr = null,
		string endmrr = null,
		string begcar = null,
		string endcar = null,
		int? displayheader = 0,
		string psite = null);
	}
}

