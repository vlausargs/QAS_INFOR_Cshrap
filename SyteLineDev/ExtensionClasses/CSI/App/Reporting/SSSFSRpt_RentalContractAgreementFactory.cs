//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_RentalContractAgreementFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class SSSFSRpt_RentalContractAgreementFactory
	{
		public ISSSFSRpt_RentalContractAgreement Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSRpt_RentalContractAgreement = new Reporting.SSSFSRpt_RentalContractAgreement(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSRpt_RentalContractAgreementExt = timerfactory.Create<Reporting.ISSSFSRpt_RentalContractAgreement>(_SSSFSRpt_RentalContractAgreement);
			
			return iSSSFSRpt_RentalContractAgreementExt;
		}
	}
}
