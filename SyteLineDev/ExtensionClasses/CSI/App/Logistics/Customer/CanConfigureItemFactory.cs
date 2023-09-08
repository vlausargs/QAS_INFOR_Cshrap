//PROJECT NAME: Logistics
//CLASS NAME: CanConfigureItemFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CanConfigureItemFactory
	{
		public ICanConfigureItem Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CanConfigureItem = new Logistics.Customer.CanConfigureItem(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCanConfigureItemExt = timerfactory.Create<Logistics.Customer.ICanConfigureItem>(_CanConfigureItem);
			
			return iCanConfigureItemExt;
		}
	}
}
