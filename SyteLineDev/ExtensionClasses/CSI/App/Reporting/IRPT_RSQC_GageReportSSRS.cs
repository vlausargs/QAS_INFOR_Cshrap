//PROJECT NAME: Reporting
//CLASS NAME: IRPT_RSQC_GageReportSSRS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRPT_RSQC_GageReportSSRS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) RPT_RSQC_GageReportSSRSSp(string BegGage = null,
		string EndGage = null,
		string BegStat = null,
		string EndStat = null,
		string BegGageType = null,
		string EndGageType = null,
		int? DisplayHistory = null,
		int? DisplayHeader = null,
		string pSite = null);
	}
}

