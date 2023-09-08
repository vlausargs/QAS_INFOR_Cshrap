//PROJECT NAME: Logistics
//CLASS NAME: PredisplayServiceContractsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService
{
	public class PredisplayServiceContractsFactory
	{
		public IPredisplayServiceContracts Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PredisplayServiceContracts = new Logistics.FieldService.PredisplayServiceContracts(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPredisplayServiceContractsExt = timerfactory.Create<Logistics.FieldService.IPredisplayServiceContracts>(_PredisplayServiceContracts);
			
			return iPredisplayServiceContractsExt;
		}
	}
}
