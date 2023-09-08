//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBExpenseReportLinePostFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBExpenseReportLinePostFactory
	{
		public ILoadESBExpenseReportLinePost Create(IApplicationDB appDB)
		{
			var _LoadESBExpenseReportLinePost = new BusInterface.LoadESBExpenseReportLinePost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBExpenseReportLinePostExt = timerfactory.Create<BusInterface.ILoadESBExpenseReportLinePost>(_LoadESBExpenseReportLinePost);
			
			return iLoadESBExpenseReportLinePostExt;
		}
	}
}
