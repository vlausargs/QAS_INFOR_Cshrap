//PROJECT NAME: CSIVendor
//CLASS NAME: PostRemPopulateTTFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class PostRemPopulateTTFactory
	{
		public IPostRemPopulateTT Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _PostRemPopulateTT = new Logistics.Vendor.PostRemPopulateTT(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPostRemPopulateTTExt = timerfactory.Create<Logistics.Vendor.IPostRemPopulateTT>(_PostRemPopulateTT);
			
			return iPostRemPopulateTTExt;
		}
	}
}
