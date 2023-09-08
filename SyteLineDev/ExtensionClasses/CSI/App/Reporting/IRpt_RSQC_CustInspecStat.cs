//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RSQC_CustInspecStat.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RSQC_CustInspecStat
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_CustInspecStatSp(
			DateTime? CutoffDate,
			string BegCust,
			string EndCust,
			string BegOrder,
			string EndOrder,
			string BegItem,
			string EndItem,
			string BegWhse,
			string EndWhse,
			string CoType,
			string COStat,
			string COLineStat,
			int? ShowDetail,
			int? ShipEarly,
			int? DisplayHeader,
			string pSite);
	}
}

