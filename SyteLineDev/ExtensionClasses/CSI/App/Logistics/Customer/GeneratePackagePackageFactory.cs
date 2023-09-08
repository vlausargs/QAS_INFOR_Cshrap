//PROJECT NAME: CSICustomer
//CLASS NAME: GeneratePackagePackageFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GeneratePackagePackageFactory
	{
		public IGeneratePackagePackage Create(IApplicationDB appDB)
		{
			var _GeneratePackagePackage = new Logistics.Customer.GeneratePackagePackage(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGeneratePackagePackageExt = timerfactory.Create<Logistics.Customer.IGeneratePackagePackage>(_GeneratePackagePackage);
			
			return iGeneratePackagePackageExt;
		}
	}
}
