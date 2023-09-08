//PROJECT NAME: DataCollection
//CLASS NAME: PurgeEDICustomerOrdersFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
	public class PurgeEDICustomerOrdersFactory
	{
		public IPurgeEDICustomerOrders Create(IApplicationDB appDB)
		{
			var _PurgeEDICustomerOrders = new DataCollection.PurgeEDICustomerOrders(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPurgeEDICustomerOrdersExt = timerfactory.Create<DataCollection.IPurgeEDICustomerOrders>(_PurgeEDICustomerOrders);
			
			return iPurgeEDICustomerOrdersExt;
		}
	}
}
