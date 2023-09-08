//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ProductionScheduleScrappedFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ProductionScheduleScrappedFactory
	{
		public IRpt_ProductionScheduleScrapped Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ProductionScheduleScrapped = new Reporting.Rpt_ProductionScheduleScrapped(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ProductionScheduleScrappedExt = timerfactory.Create<Reporting.IRpt_ProductionScheduleScrapped>(_Rpt_ProductionScheduleScrapped);
			
			return iRpt_ProductionScheduleScrappedExt;
		}
	}
}
