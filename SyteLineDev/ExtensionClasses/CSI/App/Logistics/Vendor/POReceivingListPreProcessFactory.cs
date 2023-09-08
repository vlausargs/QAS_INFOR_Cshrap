//PROJECT NAME: CSIVendor
//CLASS NAME: POReceivingListPreProcessFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class POReceivingListPreProcessFactory
	{
		public IPOReceivingListPreProcess Create(IApplicationDB appDB)
		{
			var _POReceivingListPreProcess = new Logistics.Vendor.POReceivingListPreProcess(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPOReceivingListPreProcessExt = timerfactory.Create<Logistics.Vendor.IPOReceivingListPreProcess>(_POReceivingListPreProcess);
			
			return iPOReceivingListPreProcessExt;
		}
	}
}
