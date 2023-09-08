//PROJECT NAME: Logistics
//CLASS NAME: GetItemRefFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class GetItemRefFactory
	{
		public IGetItemRef Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetItemRef = new Logistics.Customer.GetItemRef(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetItemRefExt = timerfactory.Create<Logistics.Customer.IGetItemRef>(_GetItemRef);
			
			return iGetItemRefExt;
		}
	}
}
