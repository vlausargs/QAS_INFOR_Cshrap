//PROJECT NAME: CSICustomer
//CLASS NAME: PopulateTmpPickList_ForSplitFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class PopulateTmpPickList_ForSplitFactory
	{
		public IPopulateTmpPickList_ForSplit Create(IApplicationDB appDB)
		{
			var _PopulateTmpPickList_ForSplit = new Logistics.Customer.PopulateTmpPickList_ForSplit(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPopulateTmpPickList_ForSplitExt = timerfactory.Create<Logistics.Customer.IPopulateTmpPickList_ForSplit>(_PopulateTmpPickList_ForSplit);
			
			return iPopulateTmpPickList_ForSplitExt;
		}
	}
}
