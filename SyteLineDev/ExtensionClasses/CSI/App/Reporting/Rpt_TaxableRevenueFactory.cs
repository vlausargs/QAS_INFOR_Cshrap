//PROJECT NAME: Reporting
//CLASS NAME: Rpt_TaxableRevenueFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_TaxableRevenueFactory
	{
		public IRpt_TaxableRevenue Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_TaxableRevenue = new Reporting.Rpt_TaxableRevenue(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_TaxableRevenueExt = timerfactory.Create<Reporting.IRpt_TaxableRevenue>(_Rpt_TaxableRevenue);
			
			return iRpt_TaxableRevenueExt;
		}
	}
}
