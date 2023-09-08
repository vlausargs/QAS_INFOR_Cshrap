//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ARAdjustmentPostingFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ARAdjustmentPostingFactory
	{
		public IRpt_ARAdjustmentPosting Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ARAdjustmentPosting = new Reporting.Rpt_ARAdjustmentPosting(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ARAdjustmentPostingExt = timerfactory.Create<Reporting.IRpt_ARAdjustmentPosting>(_Rpt_ARAdjustmentPosting);
			
			return iRpt_ARAdjustmentPostingExt;
		}
	}
}
