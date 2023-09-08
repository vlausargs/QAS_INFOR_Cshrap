//PROJECT NAME: Reporting
//CLASS NAME: IRPT_RSQC_GageReport2SSRS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRPT_RSQC_GageReport2SSRS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) RPT_RSQC_GageReport2SSRSSp(string BegGage = null,
		int? IncludeHistory = null,
		string pSite = null);
	}
}

