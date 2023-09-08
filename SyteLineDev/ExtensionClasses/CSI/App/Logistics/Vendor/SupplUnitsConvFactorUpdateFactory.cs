//PROJECT NAME: Logistics
//CLASS NAME: SupplUnitsConvFactorUpdateFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class SupplUnitsConvFactorUpdateFactory
	{
		public ISupplUnitsConvFactorUpdate Create(IApplicationDB appDB)
		{
			var _SupplUnitsConvFactorUpdate = new Logistics.Vendor.SupplUnitsConvFactorUpdate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSupplUnitsConvFactorUpdateExt = timerfactory.Create<Logistics.Vendor.ISupplUnitsConvFactorUpdate>(_SupplUnitsConvFactorUpdate);
			
			return iSupplUnitsConvFactorUpdateExt;
		}
	}
}
