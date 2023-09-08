//PROJECT NAME: Reporting
//CLASS NAME: Rpt_CycleCountSheetFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_CycleCountSheetFactory
	{
		public IRpt_CycleCountSheet Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_CycleCountSheet = new Reporting.Rpt_CycleCountSheet(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_CycleCountSheetExt = timerfactory.Create<Reporting.IRpt_CycleCountSheet>(_Rpt_CycleCountSheet);
			
			return iRpt_CycleCountSheetExt;
		}
	}
}
