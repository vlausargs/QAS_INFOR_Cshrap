//PROJECT NAME: Logistics
//CLASS NAME: AP012RFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class AP012RFactory
	{
		public IAP012R Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _AP012R = new Logistics.Vendor.AP012R(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAP012RExt = timerfactory.Create<Logistics.Vendor.IAP012R>(_AP012R);
			
			return iAP012RExt;
		}
	}
}
