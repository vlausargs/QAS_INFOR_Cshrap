//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RSQC_IPQualityPlanSSRS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RSQC_IPQualityPlanSSRS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_IPQualityPlanSSRSSp(string BegItem = null,
		string EndItem = null,
		int? PrintInternal = null,
		int? PrintExternal = null,
		int? DisplayHeader = null,
		string pSite = null);
	}
}

