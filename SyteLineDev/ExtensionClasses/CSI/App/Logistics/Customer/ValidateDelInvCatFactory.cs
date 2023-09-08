//PROJECT NAME: CSICustomer
//CLASS NAME: ValidateDelInvCatFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ValidateDelInvCatFactory
	{
		public IValidateDelInvCat Create(IApplicationDB appDB)
		{
			var _ValidateDelInvCat = new Logistics.Customer.ValidateDelInvCat(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateDelInvCatExt = timerfactory.Create<Logistics.Customer.IValidateDelInvCat>(_ValidateDelInvCat);
			
			return iValidateDelInvCatExt;
		}
	}
}
