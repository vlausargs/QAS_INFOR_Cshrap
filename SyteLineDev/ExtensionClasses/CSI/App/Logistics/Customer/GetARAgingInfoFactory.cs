//PROJECT NAME: Logistics
//CLASS NAME: GetARAgingInfoFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class GetARAgingInfoFactory
	{
		public IGetARAgingInfo Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetARAgingInfo = new Logistics.Customer.GetARAgingInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetARAgingInfoExt = timerfactory.Create<Logistics.Customer.IGetARAgingInfo>(_GetARAgingInfo);
			
			return iGetARAgingInfoExt;
		}
	}
}
