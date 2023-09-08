//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SupplyUsageMrpApsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_SupplyUsageMrpApsFactory
	{
		public IRpt_SupplyUsageMrpAps Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_SupplyUsageMrpAps = new Reporting.Rpt_SupplyUsageMrpAps(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_SupplyUsageMrpApsExt = timerfactory.Create<Reporting.IRpt_SupplyUsageMrpAps>(_Rpt_SupplyUsageMrpAps);
			
			return iRpt_SupplyUsageMrpApsExt;
		}
	}
}
