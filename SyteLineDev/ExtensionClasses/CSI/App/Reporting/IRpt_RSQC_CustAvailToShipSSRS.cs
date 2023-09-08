//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RSQC_CustAvailToShipSSRS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RSQC_CustAvailToShipSSRS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_CustAvailToShipSSRSSp(DateTime? CutoffDate = null,
		string BegCust = null,
		string EndCust = null,
		string BegOrder = null,
		string EndOrder = null,
		string BegItem = null,
		string EndItem = null,
		string BegWhse = null,
		string EndWhse = null,
		string CoType = null,
		string COLineStat = null,
		string COStat = null,
		string sortby = null,
		int? ShipEarly = null,
		int? DisplayHeader = null,
		string psite = null);
	}
}

