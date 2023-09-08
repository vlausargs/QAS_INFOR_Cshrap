//PROJECT NAME: Logistics
//CLASS NAME: VchPrDelFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class VchPrDelFactory
	{
		public IVchPrDel Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _VchPrDel = new Logistics.Vendor.VchPrDel(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iVchPrDelExt = timerfactory.Create<Logistics.Vendor.IVchPrDel>(_VchPrDel);
			
			return iVchPrDelExt;
		}
	}
}
