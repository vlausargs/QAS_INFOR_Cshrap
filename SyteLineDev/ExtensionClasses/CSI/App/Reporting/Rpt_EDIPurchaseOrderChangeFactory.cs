//PROJECT NAME: Reporting
//CLASS NAME: Rpt_EDIPurchaseOrderChangeFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_EDIPurchaseOrderChangeFactory
	{
		public IRpt_EDIPurchaseOrderChange Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_EDIPurchaseOrderChange = new Reporting.Rpt_EDIPurchaseOrderChange(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_EDIPurchaseOrderChangeExt = timerfactory.Create<Reporting.IRpt_EDIPurchaseOrderChange>(_Rpt_EDIPurchaseOrderChange);
			
			return iRpt_EDIPurchaseOrderChangeExt;
		}
	}
}
