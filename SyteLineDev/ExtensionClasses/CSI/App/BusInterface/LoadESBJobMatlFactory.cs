//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBJobMatlFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBJobMatlFactory
	{
		public ILoadESBJobMatl Create(IApplicationDB appDB)
		{
			var _LoadESBJobMatl = new BusInterface.LoadESBJobMatl(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBJobMatlExt = timerfactory.Create<BusInterface.ILoadESBJobMatl>(_LoadESBJobMatl);
			
			return iLoadESBJobMatlExt;
		}
	}
}
