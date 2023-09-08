//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBAcknowledgeFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBAcknowledgeFactory
	{
		public ILoadESBAcknowledge Create(IApplicationDB appDB)
		{
			var _LoadESBAcknowledge = new BusInterface.LoadESBAcknowledge(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBAcknowledgeExt = timerfactory.Create<BusInterface.ILoadESBAcknowledge>(_LoadESBAcknowledge);
			
			return iLoadESBAcknowledgeExt;
		}
	}
}
