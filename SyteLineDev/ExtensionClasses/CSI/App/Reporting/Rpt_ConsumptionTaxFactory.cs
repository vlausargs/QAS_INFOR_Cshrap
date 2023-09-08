//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ConsumptionTaxFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ConsumptionTaxFactory
	{
		public IRpt_ConsumptionTax Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ConsumptionTax = new Reporting.Rpt_ConsumptionTax(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ConsumptionTaxExt = timerfactory.Create<Reporting.IRpt_ConsumptionTax>(_Rpt_ConsumptionTax);
			
			return iRpt_ConsumptionTaxExt;
		}
	}
}
