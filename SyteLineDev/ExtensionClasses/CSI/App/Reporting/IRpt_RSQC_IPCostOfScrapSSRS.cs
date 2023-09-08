//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RSQC_IPCostOfScrapSSRS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RSQC_IPCostOfScrapSSRS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_IPCostOfScrapSSRSSp(string BegItem = null,
		string EndItem = null,
		string begjob = null,
		string endjob = null,
		DateTime? begtdate = null,
		DateTime? endtdate = null,
		string begreason = null,
		string endreason = null,
		int? DisplayHeader = 0,
		string psite = null);
	}
}

