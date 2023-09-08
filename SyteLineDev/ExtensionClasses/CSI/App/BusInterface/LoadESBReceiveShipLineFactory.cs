//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBReceiveShipLineFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBReceiveShipLineFactory
	{
		public ILoadESBReceiveShipLine Create(IApplicationDB appDB)
		{
			var _LoadESBReceiveShipLine = new BusInterface.LoadESBReceiveShipLine(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBReceiveShipLineExt = timerfactory.Create<BusInterface.ILoadESBReceiveShipLine>(_LoadESBReceiveShipLine);
			
			return iLoadESBReceiveShipLineExt;
		}
	}
}
