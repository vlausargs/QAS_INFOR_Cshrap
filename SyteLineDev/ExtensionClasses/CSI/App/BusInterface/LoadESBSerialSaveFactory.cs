//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBSerialSaveFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBSerialSaveFactory
	{
		public ILoadESBSerialSave Create(IApplicationDB appDB)
		{
			var _LoadESBSerialSave = new BusInterface.LoadESBSerialSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBSerialSaveExt = timerfactory.Create<BusInterface.ILoadESBSerialSave>(_LoadESBSerialSave);
			
			return iLoadESBSerialSaveExt;
		}
	}
}
