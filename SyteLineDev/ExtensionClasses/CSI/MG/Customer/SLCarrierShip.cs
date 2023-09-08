//PROJECT NAME: CustomerExt
//CLASS NAME: SLCarrierShip.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Customer
{
	[IDOExtensionClass("SLCarrierShip")]
	public class SLCarrierShip : ExtensionClassBase
	{


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetShipmentTrackingURLSp(decimal? ShipmentID,
		[Optional] string TrackingNumber,
		ref string TrackingURL)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetShipmentTrackingURLExt = new GetShipmentTrackingURLFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetShipmentTrackingURLExt.GetShipmentTrackingURLSp(ShipmentID,
				TrackingNumber,
				TrackingURL);
				
				int Severity = result.ReturnCode.Value;
				TrackingURL = result.TrackingURL;
				return Severity;
			}
		}
	}
}
