//PROJECT NAME: Reporting
//CLASS NAME: Rpt_LandedCostVarianceFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_LandedCostVarianceFactory
	{
		public IRpt_LandedCostVariance Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_LandedCostVariance = new Reporting.Rpt_LandedCostVariance(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_LandedCostVarianceExt = timerfactory.Create<Reporting.IRpt_LandedCostVariance>(_Rpt_LandedCostVariance);
			
			return iRpt_LandedCostVarianceExt;
		}
	}
}
