//PROJECT NAME: Logistics
//CLASS NAME: CalculateShipmentWeightAndPackagesFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CalculateShipmentWeightAndPackagesFactory
	{
		public ICalculateShipmentWeightAndPackages Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CalculateShipmentWeightAndPackages = new Logistics.Customer.CalculateShipmentWeightAndPackages(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCalculateShipmentWeightAndPackagesExt = timerfactory.Create<Logistics.Customer.ICalculateShipmentWeightAndPackages>(_CalculateShipmentWeightAndPackages);
			
			return iCalculateShipmentWeightAndPackagesExt;
		}
	}
}
