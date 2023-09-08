//PROJECT NAME: Logistics
//CLASS NAME: GenerateTmpShipSeqPackageFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class GenerateTmpShipSeqPackageFactory
	{
		public IGenerateTmpShipSeqPackage Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GenerateTmpShipSeqPackage = new Logistics.Customer.GenerateTmpShipSeqPackage(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGenerateTmpShipSeqPackageExt = timerfactory.Create<Logistics.Customer.IGenerateTmpShipSeqPackage>(_GenerateTmpShipSeqPackage);
			
			return iGenerateTmpShipSeqPackageExt;
		}
	}
}
