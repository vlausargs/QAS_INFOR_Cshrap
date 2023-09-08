//PROJECT NAME: Logistics
//CLASS NAME: ICLM_ShipmentASN.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICLM_ShipmentASN
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) CLM_ShipmentASNSp(
			string StartCustNum = null,
			string EndCustNum = null,
			int? StartCustSeq = null,
			int? EndCustSeq = null,
			decimal? StartShipmentID = null,
			decimal? EndShipmentID = null);
	}
}