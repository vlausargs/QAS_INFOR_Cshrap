//PROJECT NAME: Logistics
//CLASS NAME: ExtInterfaceDoInfoFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class ExtInterfaceDoInfoFactory
	{
		public IExtInterfaceDoInfo Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ExtInterfaceDoInfo = new Logistics.Customer.ExtInterfaceDoInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iExtInterfaceDoInfoExt = timerfactory.Create<Logistics.Customer.IExtInterfaceDoInfo>(_ExtInterfaceDoInfo);
			
			return iExtInterfaceDoInfoExt;
		}
	}
}
