//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RSQC_SupItemDetailSSRS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RSQC_SupItemDetailSSRS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_SupItemDetailSSRSSp(string begitem = null,
		string enditem = null,
		string begvend = null,
		string endvend = null,
		int? numsamples = null,
		int? printworksheet = null,
		int? displayheader = null,
		int? PrintInternal = null,
		int? PrintExternal = null,
		string psite = null);
	}
}

