//PROJECT NAME: Logistics
//CLASS NAME: CoNextKeyDelFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CoNextKeyDelFactory
	{
		public ICoNextKeyDel Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CoNextKeyDel = new Logistics.Customer.CoNextKeyDel(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCoNextKeyDelExt = timerfactory.Create<Logistics.Customer.ICoNextKeyDel>(_CoNextKeyDel);
			
			return iCoNextKeyDelExt;
		}
	}
}
