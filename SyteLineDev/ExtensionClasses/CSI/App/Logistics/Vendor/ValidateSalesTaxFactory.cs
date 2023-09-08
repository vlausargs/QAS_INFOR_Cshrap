//PROJECT NAME: Logistics
//CLASS NAME: ValidateSalesTaxFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class ValidateSalesTaxFactory
	{
		public IValidateSalesTax Create(IApplicationDB appDB)
		{
			var _ValidateSalesTax = new Logistics.Vendor.ValidateSalesTax(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateSalesTaxExt = timerfactory.Create<Logistics.Vendor.IValidateSalesTax>(_ValidateSalesTax);
			
			return iValidateSalesTaxExt;
		}
	}
}
