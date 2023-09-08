//PROJECT NAME: Reporting
//CLASS NAME: Rpt_TaxVoucheredParametricFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_TaxVoucheredParametricFactory
	{
		public IRpt_TaxVoucheredParametric Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_TaxVoucheredParametric = new Reporting.Rpt_TaxVoucheredParametric(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_TaxVoucheredParametricExt = timerfactory.Create<Reporting.IRpt_TaxVoucheredParametric>(_Rpt_TaxVoucheredParametric);
			
			return iRpt_TaxVoucheredParametricExt;
		}
	}
}
