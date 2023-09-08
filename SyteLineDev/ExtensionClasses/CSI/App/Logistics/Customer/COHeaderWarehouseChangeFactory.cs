//PROJECT NAME: CSICustomer
//CLASS NAME: COHeaderWarehouseChangeFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class COHeaderWarehouseChangeFactory
	{
		public ICOHeaderWarehouseChange Create(IApplicationDB appDB)
		{
			var _COHeaderWarehouseChange = new Logistics.Customer.COHeaderWarehouseChange(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCOHeaderWarehouseChangeExt = timerfactory.Create<Logistics.Customer.ICOHeaderWarehouseChange>(_COHeaderWarehouseChange);
			
			return iCOHeaderWarehouseChangeExt;
		}
	}
}
