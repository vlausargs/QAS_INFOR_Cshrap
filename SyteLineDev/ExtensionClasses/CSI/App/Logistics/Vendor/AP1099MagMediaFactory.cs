//PROJECT NAME: CSIVendor
//CLASS NAME: AP1099MagMediaFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class AP1099MagMediaFactory
	{
		public IAP1099MagMedia Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _AP1099MagMedia = new Logistics.Vendor.AP1099MagMedia(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAP1099MagMediaExt = timerfactory.Create<Logistics.Vendor.IAP1099MagMedia>(_AP1099MagMedia);
			
			return iAP1099MagMediaExt;
		}
	}
}
