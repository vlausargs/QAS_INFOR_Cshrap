//PROJECT NAME: CSIReport
//CLASS NAME: CHSRpt_ManualVoucherPrintFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class CHSRpt_ManualVoucherPrintFactory
	{
		public ICHSRpt_ManualVoucherPrint Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CHSRpt_ManualVoucherPrint = new Reporting.CHSRpt_ManualVoucherPrint(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCHSRpt_ManualVoucherPrintExt = timerfactory.Create<Reporting.ICHSRpt_ManualVoucherPrint>(_CHSRpt_ManualVoucherPrint);
			
			return iCHSRpt_ManualVoucherPrintExt;
		}
	}
}
