//PROJECT NAME: Reporting
//CLASS NAME: Rpt_TaxInvoicedParametricFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_TaxInvoicedParametricFactory
	{
		public IRpt_TaxInvoicedParametric Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_TaxInvoicedParametric = new Reporting.Rpt_TaxInvoicedParametric(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_TaxInvoicedParametricExt = timerfactory.Create<Reporting.IRpt_TaxInvoicedParametric>(_Rpt_TaxInvoicedParametric);
			
			return iRpt_TaxInvoicedParametricExt;
		}
	}
}
