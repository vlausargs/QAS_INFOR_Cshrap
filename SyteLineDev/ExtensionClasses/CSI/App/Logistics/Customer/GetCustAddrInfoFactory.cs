//PROJECT NAME: Logistics
//CLASS NAME: GetCustAddrInfoFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class GetCustAddrInfoFactory
	{
		public IGetCustAddrInfo Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetCustAddrInfo = new Logistics.Customer.GetCustAddrInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetCustAddrInfoExt = timerfactory.Create<Logistics.Customer.IGetCustAddrInfo>(_GetCustAddrInfo);
			
			return iGetCustAddrInfoExt;
		}
	}
}
