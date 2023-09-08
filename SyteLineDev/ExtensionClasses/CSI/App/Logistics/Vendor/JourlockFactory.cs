//PROJECT NAME: Logistics
//CLASS NAME: JourlockFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class JourlockFactory
	{
		public IJourlock Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _Jourlock = new Logistics.Vendor.Jourlock(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJourlockExt = timerfactory.Create<Logistics.Vendor.IJourlock>(_Jourlock);
			
			return iJourlockExt;
		}
	}
}
