//PROJECT NAME: Logistics
//CLASS NAME: GenerateShipmentFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class GenerateShipmentFactory
	{
		public IGenerateShipment Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GenerateShipment = new Logistics.Customer.GenerateShipment(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGenerateShipmentExt = timerfactory.Create<Logistics.Customer.IGenerateShipment>(_GenerateShipment);
			
			return iGenerateShipmentExt;
		}
	}
}
