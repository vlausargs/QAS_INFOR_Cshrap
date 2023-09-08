//PROJECT NAME: Logistics
//CLASS NAME: GetCOLineParmsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class GetCOLineParmsFactory
	{
		public IGetCOLineParms Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetCOLineParms = new Logistics.Customer.GetCOLineParms(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetCOLineParmsExt = timerfactory.Create<Logistics.Customer.IGetCOLineParms>(_GetCOLineParms);
			
			return iGetCOLineParmsExt;
		}
	}
}
