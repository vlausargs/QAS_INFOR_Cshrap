//PROJECT NAME: Logistics
//CLASS NAME: GetArParmsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class GetArParmsFactory
	{
		public IGetArParms Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetArParms = new Logistics.Customer.GetArParms(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetArParmsExt = timerfactory.Create<Logistics.Customer.IGetArParms>(_GetArParms);
			
			return iGetArParmsExt;
		}
	}
}
