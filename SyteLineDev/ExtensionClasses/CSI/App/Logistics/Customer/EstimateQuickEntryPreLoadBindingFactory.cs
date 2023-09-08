//PROJECT NAME: CSICustomer
//CLASS NAME: EstimateQuickEntryPreLoadBindingFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class EstimateQuickEntryPreLoadBindingFactory
	{
		public IEstimateQuickEntryPreLoadBinding Create(IApplicationDB appDB)
		{
			var _EstimateQuickEntryPreLoadBinding = new Logistics.Customer.EstimateQuickEntryPreLoadBinding(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEstimateQuickEntryPreLoadBindingExt = timerfactory.Create<Logistics.Customer.IEstimateQuickEntryPreLoadBinding>(_EstimateQuickEntryPreLoadBinding);
			
			return iEstimateQuickEntryPreLoadBindingExt;
		}
	}
}
