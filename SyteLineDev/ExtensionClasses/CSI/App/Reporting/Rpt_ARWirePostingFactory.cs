//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ARWirePostingFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ARWirePostingFactory
	{
		public IRpt_ARWirePosting Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ARWirePosting = new Reporting.Rpt_ARWirePosting(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ARWirePostingExt = timerfactory.Create<Reporting.IRpt_ARWirePosting>(_Rpt_ARWirePosting);
			
			return iRpt_ARWirePostingExt;
		}
	}
}
