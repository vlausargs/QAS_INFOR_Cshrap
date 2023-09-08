//PROJECT NAME: Reporting
//CLASS NAME: Rpt_productionCostbyWorkCenterFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_productionCostbyWorkCenterFactory
	{
		public IRpt_productionCostbyWorkCenter Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_productionCostbyWorkCenter = new Reporting.Rpt_productionCostbyWorkCenter(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_productionCostbyWorkCenterExt = timerfactory.Create<Reporting.IRpt_productionCostbyWorkCenter>(_Rpt_productionCostbyWorkCenter);
			
			return iRpt_productionCostbyWorkCenterExt;
		}
	}
}
