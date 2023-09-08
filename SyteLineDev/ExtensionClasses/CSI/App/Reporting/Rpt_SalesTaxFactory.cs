//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SalesTaxFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_SalesTaxFactory
	{
		public IRpt_SalesTax Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_SalesTax = new Reporting.Rpt_SalesTax(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_SalesTaxExt = timerfactory.Create<Reporting.IRpt_SalesTax>(_Rpt_SalesTax);
			
			return iRpt_SalesTaxExt;
		}
	}
}
