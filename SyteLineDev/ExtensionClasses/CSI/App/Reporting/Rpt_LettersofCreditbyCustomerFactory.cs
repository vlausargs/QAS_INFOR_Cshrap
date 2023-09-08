//PROJECT NAME: Reporting
//CLASS NAME: Rpt_LettersofCreditbyCustomerFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_LettersofCreditbyCustomerFactory
	{
		public IRpt_LettersofCreditbyCustomer Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_LettersofCreditbyCustomer = new Reporting.Rpt_LettersofCreditbyCustomer(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_LettersofCreditbyCustomerExt = timerfactory.Create<Reporting.IRpt_LettersofCreditbyCustomer>(_Rpt_LettersofCreditbyCustomer);
			
			return iRpt_LettersofCreditbyCustomerExt;
		}
	}
}
