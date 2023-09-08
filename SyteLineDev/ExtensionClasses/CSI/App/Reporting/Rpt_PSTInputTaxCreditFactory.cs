//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PSTInputTaxCreditFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_PSTInputTaxCreditFactory
	{
		public IRpt_PSTInputTaxCredit Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_PSTInputTaxCredit = new Reporting.Rpt_PSTInputTaxCredit(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_PSTInputTaxCreditExt = timerfactory.Create<Reporting.IRpt_PSTInputTaxCredit>(_Rpt_PSTInputTaxCredit);
			
			return iRpt_PSTInputTaxCreditExt;
		}
	}
}
