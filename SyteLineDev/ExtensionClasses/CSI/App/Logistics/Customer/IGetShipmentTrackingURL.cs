//PROJECT NAME: Logistics
//CLASS NAME: IGetShipmentTrackingURL.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGetShipmentTrackingURL
	{
		(int? ReturnCode, string TrackingURL) GetShipmentTrackingURLSp(decimal? ShipmentID,
		string TrackingNumber = null,
		string TrackingURL = null);
		string GetShipmentTrackingURLFn(
			decimal? ShipmentID,
			string TrackingNumber = null);

	}
}

