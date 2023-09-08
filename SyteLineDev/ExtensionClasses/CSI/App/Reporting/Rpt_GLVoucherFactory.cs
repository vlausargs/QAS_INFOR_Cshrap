//PROJECT NAME: Reporting
//CLASS NAME: Rpt_GLVoucherFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_GLVoucherFactory
	{
		public IRpt_GLVoucher Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_GLVoucher = new Reporting.Rpt_GLVoucher(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_GLVoucherExt = timerfactory.Create<Reporting.IRpt_GLVoucher>(_Rpt_GLVoucher);
			
			return iRpt_GLVoucherExt;
		}
	}
}
