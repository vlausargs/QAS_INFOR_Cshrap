//PROJECT NAME: Reporting
//CLASS NAME: Rpt_CycleCountVarianceFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_CycleCountVarianceFactory
	{
		public IRpt_CycleCountVariance Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_CycleCountVariance = new Reporting.Rpt_CycleCountVariance(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_CycleCountVarianceExt = timerfactory.Create<Reporting.IRpt_CycleCountVariance>(_Rpt_CycleCountVariance);
			
			return iRpt_CycleCountVarianceExt;
		}
	}
}
