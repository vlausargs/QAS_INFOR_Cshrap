//PROJECT NAME: BusInterface
//CLASS NAME: GenerateReceiveShipBODPLFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.BusInterface
{
	public class GenerateReceiveShipBODPLFactory
	{
		public IGenerateReceiveShipBODPL Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GenerateReceiveShipBODPL = new BusInterface.GenerateReceiveShipBODPL(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGenerateReceiveShipBODPLExt = timerfactory.Create<BusInterface.IGenerateReceiveShipBODPL>(_GenerateReceiveShipBODPL);
			
			return iGenerateReceiveShipBODPLExt;
		}
	}
}
