//PROJECT NAME: Reporting
//CLASS NAME: Rpt_LettersOfCreditByVendorFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_LettersOfCreditByVendorFactory
	{
		public IRpt_LettersOfCreditByVendor Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_LettersOfCreditByVendor = new Reporting.Rpt_LettersOfCreditByVendor(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_LettersOfCreditByVendorExt = timerfactory.Create<Reporting.IRpt_LettersOfCreditByVendor>(_Rpt_LettersOfCreditByVendor);
			
			return iRpt_LettersOfCreditByVendorExt;
		}
	}
}
