//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RMAVerificationFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_RMAVerificationFactory
	{
		public IRpt_RMAVerification Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_RMAVerification = new Reporting.Rpt_RMAVerification(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_RMAVerificationExt = timerfactory.Create<Reporting.IRpt_RMAVerification>(_Rpt_RMAVerification);
			
			return iRpt_RMAVerificationExt;
		}
	}
}
