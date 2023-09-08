//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RSQC_CustInspecStatSSRS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RSQC_CustInspecStatSSRS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_CustInspecStatSSRSSp(DateTime? CutoffDate = null,
		string BegCust = null,
		string EndCust = null,
		string BegOrder = null,
		string EndOrder = null,
		string BegItem = null,
		string EndItem = null,
		string BegWhse = null,
		string EndWhse = null,
		string CoType = null,
		string COStat = null,
		string COLineStat = null,
		int? ShowDetail = null,
		int? ShipEarly = null,
		int? DisplayHeader = null,
		string psite = null);
	}
}

