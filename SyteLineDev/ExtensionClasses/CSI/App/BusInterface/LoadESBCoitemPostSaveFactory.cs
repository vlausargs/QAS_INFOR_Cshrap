//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBCoitemPostSaveFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBCoitemPostSaveFactory
	{
		public ILoadESBCoitemPostSave Create(IApplicationDB appDB)
		{
			var _LoadESBCoitemPostSave = new BusInterface.LoadESBCoitemPostSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBCoitemPostSaveExt = timerfactory.Create<BusInterface.ILoadESBCoitemPostSave>(_LoadESBCoitemPostSave);
			
			return iLoadESBCoitemPostSaveExt;
		}
	}
}
