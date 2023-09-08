//PROJECT NAME: Reporting
//CLASS NAME: Rpt_TaxReceivableFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_TaxReceivableFactory
	{
		public IRpt_TaxReceivable Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_TaxReceivable = new Reporting.Rpt_TaxReceivable(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_TaxReceivableExt = timerfactory.Create<Reporting.IRpt_TaxReceivable>(_Rpt_TaxReceivable);
			
			return iRpt_TaxReceivableExt;
		}
	}
}
