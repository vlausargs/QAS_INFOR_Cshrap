//PROJECT NAME: Logistics
//CLASS NAME: CoitmCdFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CoitmCdFactory
	{
		public ICoitmCd Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CoitmCd = new Logistics.Customer.CoitmCd(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCoitmCdExt = timerfactory.Create<Logistics.Customer.ICoitmCd>(_CoitmCd);
			
			return iCoitmCdExt;
		}
	}
}
