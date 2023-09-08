//PROJECT NAME: CSICustomer
//CLASS NAME: ValidateShipmentPackageFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ValidateShipmentPackageFactory
	{
		public IValidateShipmentPackage Create(IApplicationDB appDB)
		{
			var _ValidateShipmentPackage = new Logistics.Customer.ValidateShipmentPackage(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateShipmentPackageExt = timerfactory.Create<Logistics.Customer.IValidateShipmentPackage>(_ValidateShipmentPackage);
			
			return iValidateShipmentPackageExt;
		}
	}
}
