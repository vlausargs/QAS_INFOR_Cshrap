//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBInventoryCountLotSerialFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBInventoryCountLotSerialFactory
	{
		public ILoadESBInventoryCountLotSerial Create(IApplicationDB appDB)
		{
			var _LoadESBInventoryCountLotSerial = new BusInterface.LoadESBInventoryCountLotSerial(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBInventoryCountLotSerialExt = timerfactory.Create<BusInterface.ILoadESBInventoryCountLotSerial>(_LoadESBInventoryCountLotSerial);
			
			return iLoadESBInventoryCountLotSerialExt;
		}
	}
}
