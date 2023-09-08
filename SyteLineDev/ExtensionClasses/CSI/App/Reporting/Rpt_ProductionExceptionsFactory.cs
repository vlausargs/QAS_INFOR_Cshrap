//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ProductionExceptionsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ProductionExceptionsFactory
	{
		public IRpt_ProductionExceptions Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ProductionExceptions = new Reporting.Rpt_ProductionExceptions(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ProductionExceptionsExt = timerfactory.Create<Reporting.IRpt_ProductionExceptions>(_Rpt_ProductionExceptions);
			
			return iRpt_ProductionExceptionsExt;
		}
	}
}
