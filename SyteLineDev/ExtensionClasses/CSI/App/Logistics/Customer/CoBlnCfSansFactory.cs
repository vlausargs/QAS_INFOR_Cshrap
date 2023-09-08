//PROJECT NAME: Logistics
//CLASS NAME: CoBlnCfSansFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CoBlnCfSansFactory
	{
		public ICoBlnCfSans Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CoBlnCfSans = new Logistics.Customer.CoBlnCfSans(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCoBlnCfSansExt = timerfactory.Create<Logistics.Customer.ICoBlnCfSans>(_CoBlnCfSans);
			
			return iCoBlnCfSansExt;
		}
	}
}
