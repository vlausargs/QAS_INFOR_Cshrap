//PROJECT NAME: CSICustomer
//CLASS NAME: PickListSplittingFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class PickListSplittingFactory
	{
		public IPickListSplitting Create(IApplicationDB appDB)
		{
			var _PickListSplitting = new Logistics.Customer.PickListSplitting(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPickListSplittingExt = timerfactory.Create<Logistics.Customer.IPickListSplitting>(_PickListSplitting);
			
			return iPickListSplittingExt;
		}
	}
}
