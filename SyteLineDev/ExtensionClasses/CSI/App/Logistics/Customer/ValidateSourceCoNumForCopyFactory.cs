//PROJECT NAME: CSICustomer
//CLASS NAME: ValidateSourceCoNumForCopyFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ValidateSourceCoNumForCopyFactory
	{
		public IValidateSourceCoNumForCopy Create(IApplicationDB appDB)
		{
			var _ValidateSourceCoNumForCopy = new Logistics.Customer.ValidateSourceCoNumForCopy(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateSourceCoNumForCopyExt = timerfactory.Create<Logistics.Customer.IValidateSourceCoNumForCopy>(_ValidateSourceCoNumForCopy);
			
			return iValidateSourceCoNumForCopyExt;
		}
	}
}
