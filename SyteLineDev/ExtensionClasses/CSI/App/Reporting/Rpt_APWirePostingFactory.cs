//PROJECT NAME: Reporting
//CLASS NAME: Rpt_APWirePostingFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_APWirePostingFactory
	{
		public IRpt_APWirePosting Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_APWirePosting = new Reporting.Rpt_APWirePosting(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_APWirePostingExt = timerfactory.Create<Reporting.IRpt_APWirePosting>(_Rpt_APWirePosting);
			
			return iRpt_APWirePostingExt;
		}
	}
}
