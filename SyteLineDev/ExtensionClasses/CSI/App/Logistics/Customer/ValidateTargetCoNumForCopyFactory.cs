//PROJECT NAME: CSICustomer
//CLASS NAME: ValidateTargetCoNumForCopyFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ValidateTargetCoNumForCopyFactory
	{
		public IValidateTargetCoNumForCopy Create(IApplicationDB appDB)
		{
			var _ValidateTargetCoNumForCopy = new Logistics.Customer.ValidateTargetCoNumForCopy(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateTargetCoNumForCopyExt = timerfactory.Create<Logistics.Customer.IValidateTargetCoNumForCopy>(_ValidateTargetCoNumForCopy);
			
			return iValidateTargetCoNumForCopyExt;
		}
	}
}
