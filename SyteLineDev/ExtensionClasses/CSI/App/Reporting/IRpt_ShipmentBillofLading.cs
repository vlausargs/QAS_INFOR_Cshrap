//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ShipmentBillofLading.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ShipmentBillofLading
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ShipmentBillofLadingSp(decimal? ShipmentStarting = null,
		decimal? ShipmentEnding = null,
		string CustomerStarting = null,
		string CustomerEnding = null,
		int? CustSeqStarting = null,
		int? CustSeqEnding = null,
		DateTime? PickupDateStarting = null,
		DateTime? PickupDateEnding = null,
		int? PickupDateStartingOffset = null,
		int? PickupDateEndingOffset = null,
		int? DisplayHeader = null,
		string pSite = null);
	}
}

