//PROJECT NAME: Logistics
//CLASS NAME: UnpickPickListPopulateFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class UnpickPickListPopulateFactory
	{
		public IUnpickPickListPopulate Create(IApplicationDB appDB)
		{
			var _UnpickPickListPopulate = new Logistics.Customer.UnpickPickListPopulate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUnpickPickListPopulateExt = timerfactory.Create<Logistics.Customer.IUnpickPickListPopulate>(_UnpickPickListPopulate);
			
			return iUnpickPickListPopulateExt;
		}
	}
}
