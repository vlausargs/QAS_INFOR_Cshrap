//PROJECT NAME: Logistics
//CLASS NAME: UpdateShipItemFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class UpdateShipItemFactory
	{
		public IUpdateShipItem Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _UpdateShipItem = new Logistics.Customer.UpdateShipItem(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUpdateShipItemExt = timerfactory.Create<Logistics.Customer.IUpdateShipItem>(_UpdateShipItem);
			
			return iUpdateShipItemExt;
		}
	}
}
