//PROJECT NAME: CSICustomer
//CLASS NAME: COQuickEntryPreLoadBindingFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class COQuickEntryPreLoadBindingFactory
	{
		public ICOQuickEntryPreLoadBinding Create(IApplicationDB appDB)
		{
			var _COQuickEntryPreLoadBinding = new Logistics.Customer.COQuickEntryPreLoadBinding(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCOQuickEntryPreLoadBindingExt = timerfactory.Create<Logistics.Customer.ICOQuickEntryPreLoadBinding>(_COQuickEntryPreLoadBinding);
			
			return iCOQuickEntryPreLoadBindingExt;
		}
	}
}
