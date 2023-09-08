//PROJECT NAME: Reporting
//CLASS NAME: IRpt_PrintDeliveryOrderPackingSlip.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_PrintDeliveryOrderPackingSlip
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_PrintDeliveryOrderPackingSlipSp(string StartingDo = null,
		string EndingDo = null,
		int? PrPickupDate = null,
		int? PrDoSeqText = null,
		int? PrDoLineText = null,
		int? PrDoText = null,
		int? PageByDoLine = null,
		int? PrSerialNumbers = null,
		string StatingCust = null,
		string EndingCust = null,
		int? StatingShipTo = null,
		int? EndingShipTo = null,
		DateTime? StatingPickupDate = null,
		DateTime? EndingPickupDate = null,
		int? StatingPickupDateOffset = null,
		int? EndingPickupDateOffset = null,
		int? ShowInternal = 1,
		int? ShowExternal = 1,
		int? PrintItemOverview = null,
		int? DisplayHeader = null,
		int? TaskId = null,
		string pSite = null);
	}
}

