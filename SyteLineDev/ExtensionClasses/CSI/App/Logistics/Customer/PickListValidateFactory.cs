//PROJECT NAME: CSICustomer
//CLASS NAME: PickListValidateFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class PickListValidateFactory
	{
		public IPickListValidate Create(IApplicationDB appDB)
		{
			var _PickListValidate = new Logistics.Customer.PickListValidate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPickListValidateExt = timerfactory.Create<Logistics.Customer.IPickListValidate>(_PickListValidate);
			
			return iPickListValidateExt;
		}
	}
}
