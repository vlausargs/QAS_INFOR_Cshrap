//PROJECT NAME: Logistics
//CLASS NAME: RefTypeValidateFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class RefTypeValidateFactory
	{
		public IRefTypeValidate Create(IApplicationDB appDB)
		{
			var _RefTypeValidate = new Logistics.Customer.RefTypeValidate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRefTypeValidateExt = timerfactory.Create<Logistics.Customer.IRefTypeValidate>(_RefTypeValidate);
			
			return iRefTypeValidateExt;
		}
	}
}
