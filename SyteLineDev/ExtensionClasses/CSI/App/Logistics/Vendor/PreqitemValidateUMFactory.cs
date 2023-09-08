//PROJECT NAME: CSIVendor
//CLASS NAME: PreqitemValidateUMFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class PreqitemValidateUMFactory
	{
		public IPreqitemValidateUM Create(IApplicationDB appDB)
		{
			var _PreqitemValidateUM = new Logistics.Vendor.PreqitemValidateUM(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPreqitemValidateUMExt = timerfactory.Create<Logistics.Vendor.IPreqitemValidateUM>(_PreqitemValidateUM);
			
			return iPreqitemValidateUMExt;
		}
	}
}
