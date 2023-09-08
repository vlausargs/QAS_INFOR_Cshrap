//PROJECT NAME: Logistics
//CLASS NAME: GetCoCompEnableFlagsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class GetCoCompEnableFlagsFactory
	{
		public IGetCoCompEnableFlags Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetCoCompEnableFlags = new Logistics.Customer.GetCoCompEnableFlags(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetCoCompEnableFlagsExt = timerfactory.Create<Logistics.Customer.IGetCoCompEnableFlags>(_GetCoCompEnableFlags);
			
			return iGetCoCompEnableFlagsExt;
		}
	}
}
