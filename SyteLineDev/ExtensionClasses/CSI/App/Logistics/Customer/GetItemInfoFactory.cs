//PROJECT NAME: Logistics
//CLASS NAME: GetItemInfoFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class GetItemInfoFactory
	{
		public IGetItemInfo Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetItemInfo = new Logistics.Customer.GetItemInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetItemInfoExt = timerfactory.Create<Logistics.Customer.IGetItemInfo>(_GetItemInfo);
			
			return iGetItemInfoExt;
		}
	}
}
