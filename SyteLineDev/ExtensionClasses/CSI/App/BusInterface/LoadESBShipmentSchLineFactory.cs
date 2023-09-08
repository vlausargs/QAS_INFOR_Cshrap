//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBShipmentSchLineFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBShipmentSchLineFactory
	{
		public ILoadESBShipmentSchLine Create(IApplicationDB appDB)
		{
			var _LoadESBShipmentSchLine = new BusInterface.LoadESBShipmentSchLine(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBShipmentSchLineExt = timerfactory.Create<BusInterface.ILoadESBShipmentSchLine>(_LoadESBShipmentSchLine);
			
			return iLoadESBShipmentSchLineExt;
		}
	}
}
