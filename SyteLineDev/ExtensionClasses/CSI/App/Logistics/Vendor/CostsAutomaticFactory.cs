//PROJECT NAME: Logistics
//CLASS NAME: CostsAutomaticFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class CostsAutomaticFactory
	{
		public ICostsAutomatic Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CostsAutomatic = new Logistics.Vendor.CostsAutomatic(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCostsAutomaticExt = timerfactory.Create<Logistics.Vendor.ICostsAutomatic>(_CostsAutomatic);
			
			return iCostsAutomaticExt;
		}
	}
}
