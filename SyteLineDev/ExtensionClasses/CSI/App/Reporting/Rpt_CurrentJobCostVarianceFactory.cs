//PROJECT NAME: Reporting
//CLASS NAME: Rpt_CurrentJobCostVarianceFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_CurrentJobCostVarianceFactory
	{
		public IRpt_CurrentJobCostVariance Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_CurrentJobCostVariance = new Reporting.Rpt_CurrentJobCostVariance(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_CurrentJobCostVarianceExt = timerfactory.Create<Reporting.IRpt_CurrentJobCostVariance>(_Rpt_CurrentJobCostVariance);
			
			return iRpt_CurrentJobCostVarianceExt;
		}
	}
}
