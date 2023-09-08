//PROJECT NAME: CSIReport
//CLASS NAME: CHSRpt_VoucherTotalFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class CHSRpt_VoucherTotalFactory
	{
		public ICHSRpt_VoucherTotal Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CHSRpt_VoucherTotal = new Reporting.CHSRpt_VoucherTotal(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCHSRpt_VoucherTotalExt = timerfactory.Create<Reporting.ICHSRpt_VoucherTotal>(_CHSRpt_VoucherTotal);
			
			return iCHSRpt_VoucherTotalExt;
		}
	}
}
