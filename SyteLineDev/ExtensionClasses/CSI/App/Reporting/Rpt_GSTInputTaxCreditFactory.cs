//PROJECT NAME: Reporting
//CLASS NAME: Rpt_GSTInputTaxCreditFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_GSTInputTaxCreditFactory
	{
		public IRpt_GSTInputTaxCredit Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_GSTInputTaxCredit = new Reporting.Rpt_GSTInputTaxCredit(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_GSTInputTaxCreditExt = timerfactory.Create<Reporting.IRpt_GSTInputTaxCredit>(_Rpt_GSTInputTaxCredit);
			
			return iRpt_GSTInputTaxCreditExt;
		}
	}
}
