//PROJECT NAME: CSICustomer
//CLASS NAME: Home_GetTodaysKeySalespersonValuesFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class Home_GetTodaysKeySalespersonValuesFactory
	{
		public IHome_GetTodaysKeySalespersonValues Create(IApplicationDB appDB)
		{
			var _Home_GetTodaysKeySalespersonValues = new Logistics.Customer.Home_GetTodaysKeySalespersonValues(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHome_GetTodaysKeySalespersonValuesExt = timerfactory.Create<Logistics.Customer.IHome_GetTodaysKeySalespersonValues>(_Home_GetTodaysKeySalespersonValues);
			
			return iHome_GetTodaysKeySalespersonValuesExt;
		}
	}
}
