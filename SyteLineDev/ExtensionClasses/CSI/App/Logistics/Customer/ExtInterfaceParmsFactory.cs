//PROJECT NAME: Logistics
//CLASS NAME: ExtInterfaceParmsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class ExtInterfaceParmsFactory
	{
		public IExtInterfaceParms Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ExtInterfaceParms = new Logistics.Customer.ExtInterfaceParms(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iExtInterfaceParmsExt = timerfactory.Create<Logistics.Customer.IExtInterfaceParms>(_ExtInterfaceParms);
			
			return iExtInterfaceParmsExt;
		}
	}
}
