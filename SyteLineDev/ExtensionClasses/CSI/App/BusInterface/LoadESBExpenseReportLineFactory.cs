//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBExpenseReportLineFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBExpenseReportLineFactory
	{
		public ILoadESBExpenseReportLine Create(IApplicationDB appDB)
		{
			var _LoadESBExpenseReportLine = new BusInterface.LoadESBExpenseReportLine(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBExpenseReportLineExt = timerfactory.Create<BusInterface.ILoadESBExpenseReportLine>(_LoadESBExpenseReportLine);
			
			return iLoadESBExpenseReportLineExt;
		}
	}
}
