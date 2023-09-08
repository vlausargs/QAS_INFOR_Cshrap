//PROJECT NAME: CSIVendor
//CLASS NAME: PreqExistsFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class PreqExistsFactory
	{
		public IPreqExists Create(IApplicationDB appDB)
		{
			var _PreqExists = new Logistics.Vendor.PreqExists(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPreqExistsExt = timerfactory.Create<Logistics.Vendor.IPreqExists>(_PreqExists);
			
			return iPreqExistsExt;
		}
	}
}
