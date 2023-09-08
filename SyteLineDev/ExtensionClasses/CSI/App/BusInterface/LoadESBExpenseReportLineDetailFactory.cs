//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBExpenseReportLineDetailFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBExpenseReportLineDetailFactory
	{
		public ILoadESBExpenseReportLineDetail Create(IApplicationDB appDB)
		{
			var _LoadESBExpenseReportLineDetail = new BusInterface.LoadESBExpenseReportLineDetail(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBExpenseReportLineDetailExt = timerfactory.Create<BusInterface.ILoadESBExpenseReportLineDetail>(_LoadESBExpenseReportLineDetail);
			
			return iLoadESBExpenseReportLineDetailExt;
		}
	}
}
