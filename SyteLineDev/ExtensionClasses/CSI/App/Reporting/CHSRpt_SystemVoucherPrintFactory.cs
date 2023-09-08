//PROJECT NAME: CSIReport
//CLASS NAME: CHSRpt_SystemVoucherPrintFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class CHSRpt_SystemVoucherPrintFactory
	{
		public ICHSRpt_SystemVoucherPrint Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CHSRpt_SystemVoucherPrint = new Reporting.CHSRpt_SystemVoucherPrint(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCHSRpt_SystemVoucherPrintExt = timerfactory.Create<Reporting.ICHSRpt_SystemVoucherPrint>(_CHSRpt_SystemVoucherPrint);
			
			return iCHSRpt_SystemVoucherPrintExt;
		}
	}
}
